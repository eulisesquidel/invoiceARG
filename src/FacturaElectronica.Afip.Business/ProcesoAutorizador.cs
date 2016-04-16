using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Xml.Serialization;
using FacturaElectronica.Afip.Business.Wsaa;
using System.Configuration;
using FacturaElectronica.Afip.Business.Wsfe;
using System.Security.Cryptography.X509Certificates;
using FacturaElectronica.Afip.Business.Helpers;
using FacturaElectronica.Afip.Ws.Wsfe;
using FacturaElectronica.Data;
using FacturaElectronica.Business.Services;
using FacturaElectronica.Common.Contracts;
using FacturaElectronica.Core.Helpers;
using FacturaElectronica.Common.Constants;
using FacturaElectronica.Afip.Ws.Wsfex;

namespace FacturaElectronica.Afip.Business
{
    public class ProcesoAutorizador
    {
        private bool debeLoguear = false;
        private bool validaEsquema = true;
        private StringBuilder validacionesEsquema;
        private string nombreDeArchivo = string.Empty;
        private ComprobanteService comprobanteSvc = new ComprobanteService();
        private ClienteService clienteSvc = new ClienteService();
        private CorridaService corridaSvc = new CorridaService();
        private CorridaAutorizacionDto corridaDto = null;

        public delegate void NotifyEventHandler(string message);

        public event NotifyEventHandler NotifyProgress;

        public ProcesoAutorizador()
        {

        }

        public ProcesoAutorizador(bool debeLoguear)
        {
            this.debeLoguear = debeLoguear;
        }

        public CorridaAutorizacionDto AutorizarComprobantes(CorridaAutorizacionDto corridaDto)
        {
            try
            {
                this.corridaDto = corridaDto;
                string pathArchivoOrigen = corridaDto.PathArchivo;

                if (string.IsNullOrEmpty(corridaDto.PathArchivo))
                    this.Log("ERROR: No se ha ingresado el path del archivo");

                // Cambio para el WSFEX
                 
                bool procesarFacturaExportacion = false;
                using (StreamReader reader = new StreamReader(corridaDto.PathArchivo))
                {
                    string line = reader.ReadLine();
                    line = reader.ReadLine();
                    if (line.Contains("FacturaExportacion"))
                    {
                        procesarFacturaExportacion = true;
                    }
                    reader.Close();
                }

                if (procesarFacturaExportacion)
                {
                    corridaDto = AutorizarComprobantesParaWsFeX(this.corridaDto);
                }
                else
                {
                    // Fin Cambio para el WSFEX

                    // Marco la corrida como en proceso en la base de datos
                    if (this.corridaSvc.MarcarCorridaEnProceso(corridaDto.Id))
                    {
                        // Inicio Proceso
                        this.Log(string.Format("Iniciando procesamiento de archivo {0}...", this.nombreDeArchivo));

                        // Valido el Esquema de Xml
                        this.Log(string.Format("Validando esquema de archivo"));
                        string xmlSchemaPath = "";

                        if (!this.ValidarEsquemaXml(corridaDto.PathArchivo, xmlSchemaPath))
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine("ERROR: el formato del archivo es invalido");
                            sb.AppendLine(this.validacionesEsquema.ToString());
                            this.Log(sb.ToString());
                            return null;
                        }

                        // Leo archivo XML y lo paso a string
                        this.Log("Leyendo archivo...");
                        string xmlString = LeerArchivo(corridaDto.PathArchivo);

                        // Reemplazo <Lote></Lote> por <FeCAEReq></FeCAEReq>
                        xmlString = xmlString.Replace("<Lote>", "<FECAERequest>").Replace("</Lote>", "</FECAERequest>");

                        // Deserealizo el XML y obtengo solo la parte del request
                        FECAERequest feCAERequest = null;
                        try
                        {
                            feCAERequest = DeserializarXml<FECAERequest>(xmlString);
                        }
                        catch (Exception ex)
                        {
                            this.Log("El formato del archivo es inválido.");
                            return null;
                        }

                        // Obtengo Ticket de Autorizacion
                        this.Log("Iniciando comunicacion con la AFIP");
                        FEAuthRequest feAuthRequest = this.ObtenerTicket();

                        // Cargo los comprobantes que estan autorizados en la AFIP
                        // pero que no fueron cargados en la DB por problemas en 
                        // la comunicacion
                        this.CargarComprobantesYaAutorizados(feAuthRequest, feCAERequest);

                        // Remover Comprobantes que ya han sido autorizados
                        string resultado = this.RemoverComprobantesAutorizados(feAuthRequest, feCAERequest);
                        if (!string.IsNullOrEmpty(resultado))
                        {
                            this.Log(resultado);
                            feCAERequest.FeCabReq.CantReg = feCAERequest.FeDetReq.Count();
                        }

                        if (feCAERequest.FeDetReq != null && feCAERequest.FeDetReq.Count() > 0)
                        {
                            // Autorizar Comprobantes con la AFIP
                            this.Log("Autorizando Comprobantes con la AFIP...");
                            FECAEResponse feCAEResponse = this.AutorizarComprobantes(feAuthRequest, feCAERequest);

                            // Proceso Resultado AFIP
                            this.Log("Procesando respuesta de la AFIP...");
                            corridaDto = this.corridaSvc.ProcesarCorrida(corridaDto, feCAEResponse);
                        }
                        else
                        {
                            // Todos los comprobantes del archivo ya tienen un CAE asignado
                            // y existen en DB
                            this.Log("Todos los comprobantes del archivo ya han sido autorizados");
                        }

                        // Muevo el archivo a una carpeta de procesados
                        GuardarArchivoProcesado(pathArchivoOrigen);

                        this.Log("Fin procesamiento de archivo.");
                    }
                    else
                    {
                        this.Log("La corrida ya se está ejecutando");
                    }
                }

                return corridaDto;
            }
            catch (Exception ex)
            {
                string detalle = string.Format("ex.Message: {0} ex.StackTrace: {1}", ex.Message, ex.StackTrace);
                this.Log(string.Format("ERROR: Se ha producido un error. Contactese con el administrador. Error: {0}", ex.Message), detalle);
                return null;
            }
            finally
            {
                this.Log(CorridaService.FinCorridaMsg);
            }
        }

        public CorridaAutorizacionDto AutorizarComprobantesParaWsFeX(CorridaAutorizacionDto corridaDto)
        {
            try
            {
                this.corridaDto = corridaDto;
                string pathArchivoOrigen = corridaDto.PathArchivo;

                if (string.IsNullOrEmpty(corridaDto.PathArchivo))
                    this.Log("ERROR: No se ha ingresado el path del archivo");

                // Marco la corrida como en proceso en la base de datos
                if (this.corridaSvc.MarcarCorridaEnProceso(corridaDto.Id))
                {
                    // Inicio Proceso
                    this.Log(string.Format("Iniciando procesamiento de archivo {0}...", this.nombreDeArchivo));

                    // Valido el Esquema de Xml
                    this.Log(string.Format("Validando esquema de archivo"));
                    string xmlSchemaPath = "";

                    if (!this.ValidarEsquemaXml(corridaDto.PathArchivo, xmlSchemaPath))
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("ERROR: el formato del archivo es invalido");
                        sb.AppendLine(this.validacionesEsquema.ToString());
                        this.Log(sb.ToString());
                        return null;
                    }

                    // Leo archivo XML y lo paso a string
                    this.Log("Leyendo archivo...");
                    string xmlString = LeerArchivo(corridaDto.PathArchivo);

                    // Reemplazo <Lote></Lote> por <FeCAEReq></FeCAEReq>
                    xmlString = xmlString.Replace("<FacturaExportacion>", "<ClsFEXRequest>").Replace("</FacturaExportacion>", "</ClsFEXRequest>");

                    // Deserealizo el XML y obtengo solo la parte del request
                    ClsFEXRequest feXCAERequest = null;
                    try
                    {
                        feXCAERequest = DeserializarXml<ClsFEXRequest>(xmlString, "http://ar.gov.afip.dif.fexv1/");

                        //feXCAERequest = new ClsFEXRequest();
                        //feXCAERequest.Id = 1;
                        //feXCAERequest.Fecha_cbte = "20120820";
                        //feXCAERequest.Punto_vta = 19;
                        //feXCAERequest.Cbte_nro = 1;
                        //feXCAERequest.Tipo_expo = 1;
                        //feXCAERequest.Permiso_existente = "S";
                        //feXCAERequest.Permisos = new Permiso[2];
                        //feXCAERequest.Permisos[0] = new Permiso();
                        //feXCAERequest.Permisos[0].Dst_merc = 203;
                        //feXCAERequest.Permisos[1] = new Permiso();
                        //feXCAERequest.Permisos[1].Id_permiso = "09052EC01006154G";
                        //feXCAERequest.Permisos[1].Dst_merc = 202;
                        //feXCAERequest.Dst_cmp = 203;
                        //feXCAERequest.Cliente = "Joao Da Silva";
                        //feXCAERequest.Cuit_pais_cliente = 50000000016;
                        //feXCAERequest.Domicilio_cliente = "Rua 76 km 34.5 Alagoas";
                        //feXCAERequest.Id_impositivo = "PJ54482221-l";
                        //feXCAERequest.Moneda_Id = "012";
                        //feXCAERequest.Moneda_ctz = 0.51M;
                        //feXCAERequest.Obs_comerciales = "Sin observaciones";
                        //feXCAERequest.Imp_total = 500;
                        //feXCAERequest.Forma_pago = "Contado";
                        //feXCAERequest.Incoterms = "CIF";
                        //feXCAERequest.Incoterms_Ds = "Texto dic.";
                        //feXCAERequest.Idioma_cbte = 1;
                        //feXCAERequest.Items = new Item[1];
                        //feXCAERequest.Items[0] = new Item();
                        //feXCAERequest.Items[0].Pro_codigo = "PRO1";
                        //feXCAERequest.Items[0].Pro_ds = "Producto Tipo 1 Exportacion MERCOSUR ISO 9001";
                        //feXCAERequest.Items[0].Pro_qty = 2;
                        //feXCAERequest.Items[0].Pro_umed = 7;
                        //feXCAERequest.Items[0].Pro_precio_uni = 250;
                        //feXCAERequest.Items[0].Pro_total_item = 500;

                        //feXCAERequest.Cmps_asoc = new Cmp_asoc[0];
                       
                        //var revisar = SerializarXml<ClsFEXRequest>(feXCAERequest);
                        //revisar = revisar.ToString();
                    }
                    catch (Exception ex)
                    {
                        this.Log("El formato del archivo es inválido.");
                        return null;
                    }

                    // Obtengo Ticket de Autorizacion
                    this.Log("Iniciando comunicacion con la AFIP");
                    ClsFEXAuthRequest feXAuthRequest = this.ObtenerTicketWSFeX();

                    // Cargo los comprobantes que estan autorizados en la AFIP
                    // pero que no fueron cargados en la DB por problemas en 
                    // la comunicacion
                    //-------------------------------------
                    //-------------------------------------
                    // IMPORTANTE!!!!!!
                    //-------------------------------------
                    //-------------------------------------
                    // El siguiente codigo tiene que refactorearse según como trabaja este nuevo servicio
                    // ByAd TODO: this.CargarComprobantesYaAutorizados(feAuthRequest, feCAERequest);


                    // Remover Comprobantes que ya han sido autorizados
                    //string resultado = this.RemoverComprobantesAutorizados(feAuthRequest, feCAERequest);
                    //if (!string.IsNullOrEmpty(resultado))
                    //{
                    //    this.Log(resultado);
                    //    feCAERequest.FeCabReq.CantReg = feCAERequest.FeDetReq.Count();
                    //}
                    //-------------------------------------
                    //-------------------------------------
                    //-------------------------------------

                    if (feXCAERequest != null)
                    {
                        // Autorizar Comprobantes con la AFIP
                        this.Log("Autorizando Comprobantes con la AFIP...");
                        FEXResponseAuthorize feXCAEResponse = this.AutorizarComprobantes(feXAuthRequest, feXCAERequest);

                        // Proceso Resultado AFIP
                        this.Log("Procesando respuesta de la AFIP...");
                        corridaDto = this.corridaSvc.ProcesarCorridaWsFeX(corridaDto, feXCAEResponse, feXCAERequest);
                    }
                    else
                    {
                        // Todos los comprobantes del archivo ya tienen un CAE asignado
                        // y existen en DB
                        this.Log("Todos los comprobantes del archivo ya han sido autorizados");
                    }

                    // Muevo el archivo a una carpeta de procesados
                    GuardarArchivoProcesado(pathArchivoOrigen);

                    this.Log("Fin procesamiento de archivo.");
                }
                else
                {
                    this.Log("La corrida ya se está ejecutando");
                }

                return corridaDto;
            }
            catch (Exception ex)
            {
                string detalle = string.Format("ex.Message: {0} ex.StackTrace: {1}", ex.Message, ex.StackTrace);
                this.Log(string.Format("ERROR: Se ha producido un error. Contactese con el administrador. Error: {0}", ex.Message), detalle);
                return null;
            }
            finally
            {
                this.Log(CorridaService.FinCorridaMsg);
            }
        }

        /// <summary>
        /// Mueve el archivo procesado a una nueva carpeta de procesados
        /// </summary>
        /// <param name="pathArchivo"></param>
        private void GuardarArchivoProcesado(string pathArchivo)
        {
            string destinationPath = ConfigurationManager.AppSettings["PathDestinoArchivosFactura"];

            string fileName = Path.GetFileName(pathArchivo);

            destinationPath = Path.Combine(destinationPath, "Procesados");
            destinationPath = Path.Combine(destinationPath, DateTime.Now.ToString("yyyy"));
            destinationPath = Path.Combine(destinationPath, DateTime.Now.ToString("MM"));

            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            destinationPath = Path.Combine(destinationPath, fileName);

            if (File.Exists(destinationPath))
            {
                File.Delete(destinationPath);
            }

            File.Move(pathArchivo, destinationPath);
        }

        private void Log(string mensaje, string detalle = null)
        {
            if (corridaDto != null)
                this.corridaSvc.Log(this.corridaDto.Id, mensaje, detalle);
        }

        private string RemoverComprobantesAutorizados(FEAuthRequest feAuthRequest, FECAERequest feCAERequest)
        {
            StringBuilder comprobanteAutorizados = new StringBuilder();
            // Remover comprobantes que ya tienen CAE
            if (feCAERequest.FeDetReq.Length > 0)
            {
                FERecuperaLastCbteResponse ultimoCbteAutorizadoAfip = this.ObtenerUltimoComprobanteAutorizado(feAuthRequest, feCAERequest);
                List<FECAEDetRequest> feDetReqList = new List<FECAEDetRequest>();
                TipoComprobanteDto tipoCbteDto = this.comprobanteSvc.ObtenerTipoComprobantePorCodigoAfip(feCAERequest.FeCabReq.CbteTipo);
                foreach (var cbte in feCAERequest.FeDetReq)
                {
                    if (ultimoCbteAutorizadoAfip != null && cbte.CbteDesde <= ultimoCbteAutorizadoAfip.CbteNro)
                    {
                        // En el archivo hay comprobantes ya autorizados 
                        // se debe remover del pedido y reportar la advertencia
                        comprobanteAutorizados.AppendFormat("ADVERTENCIA: {0} Pto Venta: {1} Nro Desde: {2} Hasta: {3} ya ha sido autorizado", tipoCbteDto.Descripcion
                                                                                                                                             , feCAERequest.FeCabReq.PtoVta
                                                                                                                                             , cbte.CbteDesde
                                                                                                                                             , cbte.CbteHasta);
                    }
                    else
                    {
                        feDetReqList.Add(cbte);
                    }
                }
                feCAERequest.FeDetReq = feDetReqList.ToArray();
            }
            return comprobanteAutorizados.ToString();
        }

        private void CargarComprobantesYaAutorizados(FEAuthRequest feAuthRequest, FECAERequest feCAERequest)
        {
            // Agregar comprobantes que fueron autorizados pero que no fueron cargados
            // por problemas en la comunicacion (devolucion de datos por parte de la AFIP)
            FERecuperaLastCbteResponse ultimoCbteAutorizadoAfip = this.ObtenerUltimoComprobanteAutorizado(feAuthRequest, feCAERequest);
            ComprobanteDto ultimoCbteCargado = this.ObtenerUltimoComprobanteCargado(feCAERequest);
            if (ultimoCbteCargado == null ||
                ultimoCbteCargado.CbteHasta < ultimoCbteAutorizadoAfip.CbteNro)
            {
                // Cargarlo en la base los comprobantes faltantes
                long cbteNro = ultimoCbteCargado != null ? (long)ultimoCbteCargado.CbteHasta + 1 : 1;
                ComprobanteDto cbteDto = null;
                while (cbteNro <= ultimoCbteAutorizadoAfip.CbteNro)
                {
                    FECompConsResponse cbteAfip = this.ObtenerComprobanteAfip(feAuthRequest, feCAERequest, cbteNro).ResultGet;
                    if (cbteAfip == null) break;

                    if (cbteAfip.EmisionTipo == "CAE")
                    {
                        cbteDto = new ComprobanteDto();
                        cbteDto.CAE = cbteAfip.CodAutorizacion;
                        cbteDto.CAEFechaVencimiento = DateTimeHelper.ConvertyyyyMMddToDate(cbteAfip.FchVto);
                        cbteDto.CbteDesde = cbteAfip.CbteDesde;
                        cbteDto.CbteHasta = cbteAfip.CbteHasta;
                        cbteDto.CbteFecha = DateTimeHelper.ConvertyyyyMMddToDate(cbteAfip.CbteFch);
                        cbteDto.PtoVta = cbteAfip.PtoVta;
                        cbteDto.TipoComprobanteId = cbteAfip.CbteTipo;
                        TipoComprobanteDto tipoCbteDto = this.comprobanteSvc.ObtenerTipoComprobantePorCodigoAfip(cbteDto.TipoComprobanteId);
                        if (tipoCbteDto != null)
                        {
                            cbteDto.TipoComprobanteId = tipoCbteDto.Id;
                        }
                        if (cbteAfip.DocTipo == 80) // CUIT
                        {
                            ClienteDto clienteDto = this.clienteSvc.ObtenerClientePorCuit(cbteAfip.DocNro);
                            if (clienteDto != null)
                            {
                                cbteDto.ClienteId = clienteDto.Id;
                            }
                        }
                        // #TODO: borrar
                        //EstadoComprobanteDto estadoDto = this.comprobanteSvc.ObtenerEstado(CodigoEstadoCbte.NoVisualizado);
                        //if (estadoDto != null)
                        //{
                        //    cbteDto.EstadoId = estadoDto.Id;
                        //}
                        this.comprobanteSvc.CrearComprobante(cbteDto);
                        cbteNro = (long)cbteDto.CbteHasta + 1;
                    }
                    else
                        break;
                }
            }
        }

        private ComprobanteDto ObtenerUltimoComprobanteCargado(FECAERequest feCAERequest)
        {
            return this.comprobanteSvc.ObtenerUltimoComprobanteCargado(feCAERequest.FeCabReq.PtoVta, feCAERequest.FeCabReq.CbteTipo);
        }

        private FERecuperaLastCbteResponse ObtenerUltimoComprobanteAutorizado(FEAuthRequest feAuthRequest, FECAERequest feCAERequest)
        {
            WsfeClient client = new WsfeClient();
            return client.CompUltimoAutorizado(feAuthRequest, feCAERequest.FeCabReq.PtoVta, feCAERequest.FeCabReq.CbteTipo);
        }

        private FECompConsultaResponse ObtenerComprobanteAfip(FEAuthRequest feAuthRequest, FECAERequest feCAERequest, long cbteNro)
        {
            WsfeClient client = new WsfeClient();
            FECompConsultaReq feCompConsultaReq = new FECompConsultaReq();
            feCompConsultaReq.CbteNro = cbteNro;
            feCompConsultaReq.CbteTipo = feCAERequest.FeCabReq.CbteTipo;
            feCompConsultaReq.PtoVta = feCAERequest.FeCabReq.PtoVta;
            return client.CompConsultar(feAuthRequest, feCompConsultaReq);
        }

        private FEAuthRequest ObtenerTicket()
        {
            WsfeClient client = new WsfeClient();
            return client.ObtenerTicket();
        }

        private ClsFEXAuthRequest ObtenerTicketWSFeX()
        {
            WsfeClient client = new WsfeClient();
            return client.ObtenerTicketFex();
        }

        private FECAEResponse AutorizarComprobantes(FEAuthRequest feAuthRequest, FECAERequest feCAERequest)
        {
            WsfeClient client = new WsfeClient();
            return client.AutorizarComprobantes(feAuthRequest, feCAERequest);
        }

        private FEXResponseAuthorize AutorizarComprobantes(ClsFEXAuthRequest feXAuthRequest, ClsFEXRequest feXCAERequest)
        {
            WsfeClient client = new WsfeClient();
            return client.AutorizarComprobanteExportacion(feXAuthRequest, feXCAERequest);
        }

        //public FECAERequest DeserializarXml(string xmlString)
        //{
        //    FECAERequest feCAERequest = new FECAERequest();
        //    try
        //    {
        //        feCAERequest = LoadObjectFromXml<FECAERequest>(xmlString);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("No se pudo deserialzar el archivo", ex);
        //    }

        //    return feCAERequest;

        //}

        //private static T LoadObjectFromXml<T>(string xmlPath)
        //{
        //    T objeto = default(T);

        //    Type entityType = typeof(T);
        //    XmlSerializer serializer = new XmlSerializer(entityType);

        //    using (FileStream stream = new FileStream(xmlPath, FileMode.Open))
        //    {
        //        using (XmlReader reader = XmlReader.Create(stream))
        //        {
        //            objeto = (T)serializer.Deserialize(reader);
        //        }
        //    }

        //    return objeto;
        //}

        public static string SerializarXml<T>(T obj)
        {
            string xml;
            try
            {
                using (StringWriter sw = new StringWriter())
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    xs.Serialize(sw, obj);
                    xml = sw.ToString();
                    sw.Close();
                }                 
            }
            catch (Exception ex)
            {
                throw new Exception("El archivo no esta bien formado", ex);
            }

            return xml;
        }

        public static T DeserializarXml<T>(string xml, string defaultNamespace = "")
        {
            T obj = default(T);
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(T), defaultNamespace);
                obj = (T)xs.Deserialize(new StringReader(xml));
            }

            catch (Exception ex)
            {
                throw new Exception("El archivo no esta bien formado", ex);
            }

            return obj;

        }

        public static string LeerArchivo(string xmlPath)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(xmlPath);
                // Now create StringWriter object to get data from xml document.
                StringWriter sw = new StringWriter();
                XmlTextWriter xw = new XmlTextWriter(sw);
                doc.WriteTo(xw);
                return sw.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Leer el archivo", ex);
            }
        }

        public bool ValidarEsquemaXml(string xmlPath, string xmlSchemaPath)
        {
            return true;
            this.validaEsquema = true;
            this.validacionesEsquema = new StringBuilder();
            XmlSchema schema;
            using (StreamReader streamReader = File.OpenText(xmlSchemaPath))
            {
                using (XmlReader xmlReader = XmlReader.Create(streamReader))
                {
                    schema = XmlSchema.Read(xmlReader, SchemaHandler);
                }
            }
            XmlDocument doc = new XmlDocument();
            doc.Schemas.Add(schema);
            doc.Load(xmlPath);
            doc.Validate(SchemaHandler);

            return this.validaEsquema;
        }

        private void SchemaHandler(object o, ValidationEventArgs e)
        {
            validaEsquema = false;
            validacionesEsquema.AppendLine(e.Message);
        }

        private void OnNotifyProgress(string message)
        {
            if (this.debeLoguear)
            {
                if (this.NotifyProgress != null)
                {
                    this.NotifyProgress(message);
                }
            }
        }
    }
}
