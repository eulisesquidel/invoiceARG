using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacturaElectronica.Common.Contracts;
using FacturaElectronica.Common.Services;
using FacturaElectronica.Common.Contracts.Search;
using FacturaElectronica.Data;
using WebFramework.Mapper;
using System.Configuration;
using System.IO;
using FacturaElectronica.Common.Constants;
using System.Threading;
using System.Net.Mail;
using System.Globalization;
using System.Net;

namespace FacturaElectronica.Business.Services
{
    public class SubidaArchivoService : ISubidaArchivoService
    {
        public const string FinCorridaStr = "@FinCorrida";

        public CorridaSubidaArchivoDto CrearNuevaCorrida()
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                CorridaSubidaArchivo corrida = new CorridaSubidaArchivo();
                corrida.FechaProceso = DateTime.Now;
                corrida.Procesada = null;
                ctx.CorridaSubidaArchivoes.AddObject(corrida);
                ctx.SaveChanges();
                CorridaSubidaArchivoDto corridaDto = new CorridaSubidaArchivoDto();

                EntityMapper.Map(corrida, corridaDto);

                return corridaDto;
            }
        }

        public void EjecutarCorrida(EjecutarCorridaSubidaArchivo corrida)
        {
            long corridaId = corrida.CorridaId;

            List<string> files = corrida.FileNames;
            // Proceso los archivos en la corrida y marcos cuales están ok y cuales no            
            using (var ctx = new FacturaElectronicaEntities())
            {
                CorridaSubidaArchivo dbCorrida = ctx.CorridaSubidaArchivoes.Where(c => c.Id == corridaId).SingleOrDefault();
                if (dbCorrida != null)
                {
                    try
                    {
                        // Armo los path destinos Ok y con errores
                        string fileDestinationPathOk = ConfigurationManager.AppSettings["PathDestinoArchivosFactura"];

                        fileDestinationPathOk = Path.Combine(fileDestinationPathOk, "ArchivosPDF");

                        fileDestinationPathOk = Path.Combine(fileDestinationPathOk, corridaId.ToString());
                        string sourceFilePath = Path.Combine(fileDestinationPathOk, "AProcesar");
                        string fileDestinationPathNoOk = Path.Combine(fileDestinationPathOk, "ConErrores"); ;
                        fileDestinationPathOk = Path.Combine(fileDestinationPathOk, "OK");
                        if (!Directory.Exists(fileDestinationPathOk))
                        {
                            Directory.CreateDirectory(fileDestinationPathOk);
                        }

                        if (!Directory.Exists(fileDestinationPathNoOk))
                        {
                            Directory.CreateDirectory(fileDestinationPathNoOk);
                        }

                        // Una vez que tengo los paths, cargo los archivos
                        foreach (string filePathIterator in files)
                        {
                            try
                            {
                                string filePath = Path.Combine(sourceFilePath, filePathIterator);

                                string fileName = Path.GetFileName(filePath);
                                GenerarLog(dbCorrida.Id, string.Format("Procesando Archivo: {0}", fileName));

                                if (File.Exists(filePath))
                                {
                                    if (!corrida.ForzarDatosCliente)
                                    {
                                        ArmarArchivoAsociado(ctx, dbCorrida, filePath, fileDestinationPathOk, fileDestinationPathNoOk, corrida);
                                    }
                                    else
                                    {
                                        ArmarArchivoAsociadoConContexto(ctx, dbCorrida, filePath, fileDestinationPathOk, fileDestinationPathNoOk, corrida);
                                    }
                                }
                                else
                                {
                                    GenerarLog(dbCorrida.Id, string.Format("No Existe el Archivo: {0}", fileName));
                                }

                                GenerarLog(dbCorrida.Id, string.Format("Fin Procesamiento Archivo: {0}", fileName));
                            }
                            catch (Exception ex)
                            {
                                GenerarLog(dbCorrida.Id, ex.Message);
                            }
                        }

                        GenerarLog(dbCorrida.Id, FinCorridaStr);

                        dbCorrida.Procesada = true;
                        ctx.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        GenerarLog(dbCorrida.Id, ex.Message);
                    }
                }
            }

            // Al final, envío emails a los clientes informando que ya están listos X cantidad de facturas para
            // ser visualizadas
            SendMailToCustomers(corridaId);
        }

        private void SendMailToCustomers(long corridaId)
        {

            List<Cliente> clienteList = new List<Cliente>();
            using (FacturaElectronicaEntities ctx = new FacturaElectronicaEntities())
            {
                try
                {
                    var query = (from corrida in ctx.CorridaSubidaArchivoes
                                 join corridaDetalle in ctx.CorridaSubidaArchivoDetalles on corrida.Id equals corridaDetalle.CorridaSubidaArchivoId
                                 join archivo in ctx.ArchivoAsociadoes on corridaDetalle.ArchivoAsociadoId equals archivo.Id
                                 join comp in ctx.Comprobantes on archivo.ComprobanteId equals comp.Id
                                 join cli in ctx.Clientes on comp.ClienteId equals cli.Id
                                 where corridaDetalle.ProcesadoOK
                                 && corrida.Id == corridaId
                                 && corridaDetalle.ArchivoAsociadoId.HasValue
                                 select cli);

                    clienteList = query.Distinct().ToList();

                    // A los clientes les envío un email pero por thread
                    SendEmailToCustomerInThread(corridaId, clienteList);

                }
                catch (Exception ex)
                {
                    GenerarLog(ctx, corridaId, ex.Message);
                }
            }
        }

        private const int arch_cuit = 1;
        private const int arch_tipodocumento = 2;
        private const int arch_nrocomprobante = 3;
        private const int arch_ptovta = 4;
        private const int arch_periodofacturacion = 5;
        private const int arch_fechavencimiento = 6;
        private const int arch_tipoContrato = 7;
        private const int arch_montototal = 8;

        private void ArmarArchivoAsociado(FacturaElectronicaEntities ctx, CorridaSubidaArchivo dbCorrida, string filePath, string fileDestinationPathOk, string fileDestinationPathNoOk, EjecutarCorridaSubidaArchivo corrida)
        {
            string fileName = Path.GetFileName(filePath);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
            string[] filePartes = fileNameWithoutExtension.Split('_');

            StringBuilder mensajeError = new StringBuilder();
            string errorStr = string.Empty;
            bool procesarArchivo = true;
            
            if (filePartes.Length != 9)
            {
                procesarArchivo = false;
                errorStr = "No se pudo interpretar el nombre del archivo " + fileNameWithoutExtension;
                mensajeError.AppendLine(errorStr);
                GenerarLog(dbCorrida.Id, errorStr);
            }

            long cuit = 0;
            TipoComprobante tipoComprobanteObj = null;
            long nroComprobante = 0;
            TipoContrato tipoContrato = null;
            decimal montoTotal = 0M;
            DateTime fechaDeVencimiento = DateTime.MinValue;
            int diasDeVencimiento = 0;
            int periodoFacturacionAnio = 0;
            int periodoFacturacionMes = 0;
            long ptovta = 0;
            bool tieneFechaVencimiento = false;         

            if (procesarArchivo)
            {                
                if (!Int64.TryParse(filePartes[arch_cuit], out cuit))
                {
                    errorStr = "No se pudo interpretar el CUIT " + filePartes[arch_cuit];
                    mensajeError.AppendLine(errorStr);
                    GenerarLog(dbCorrida.Id, errorStr);
                    procesarArchivo = false;
                }

                string tipoComprobante = filePartes[arch_tipodocumento];
               
                if (!String.IsNullOrEmpty(tipoComprobante))
                {
                    tipoComprobanteObj = GetTipoComprobante(ctx).Where(t => t.Codigo == tipoComprobante).SingleOrDefault();
                    if (tipoComprobanteObj == null)
                    {
                        errorStr = "No se pudo interpretar el Tipo de Comprobante " + tipoComprobante;
                        mensajeError.AppendLine(errorStr);
                        GenerarLog(dbCorrida.Id, errorStr);
                        procesarArchivo = false;
                    }
                }
                else
                {
                    errorStr = "No se pudo interpretar el Tipo de Comprobante " + tipoComprobante;
                    mensajeError.AppendLine(errorStr);
                    GenerarLog(dbCorrida.Id, errorStr);
                    procesarArchivo = false;
                }

                string nroComprobanteStr = filePartes[arch_nrocomprobante];               
                if (!Int64.TryParse(nroComprobanteStr, out nroComprobante))
                {
                    errorStr = "No se pudo interpretar el Nro de comprobante " + nroComprobanteStr;
                    mensajeError.AppendLine(errorStr);
                    GenerarLog(dbCorrida.Id, errorStr);
                    procesarArchivo = false;
                }

                string ptovtaStr = filePartes[arch_ptovta];               
                if (!Int64.TryParse(ptovtaStr, out ptovta))
                {
                    errorStr = "No se pudo interpretar el Punto de venta " + ptovtaStr;
                    mensajeError.AppendLine(errorStr);
                    GenerarLog(dbCorrida.Id, errorStr);
                    procesarArchivo = false;
                }

                string periodoFactuStr = filePartes[arch_periodofacturacion];
                string periodoFactuAnioStr = periodoFactuStr.Substring(0, 4);
                string periodoFactuMesStr = periodoFactuStr.Substring(4, 2);               
                if (!Int32.TryParse(periodoFactuAnioStr, out periodoFacturacionAnio) || !Int32.TryParse(periodoFactuMesStr, out periodoFacturacionMes))
                {
                    errorStr = "No se pudo interpretar el Periodo de Facturacion " + periodoFactuStr;
                    mensajeError.AppendLine(errorStr);
                    GenerarLog(dbCorrida.Id, errorStr);
                    procesarArchivo = false;
                }

                string vencimientoFactuStr = filePartes[arch_fechavencimiento];
                string vencimientoFactuAnioStr = vencimientoFactuStr.Substring(0, 4);
                string vencimientoFactuMesStr = vencimientoFactuStr.Substring(4, 2);
                string vencimientoFactuDiaStr = vencimientoFactuStr.Substring(6, 2);
                       
                if (vencimientoFactuAnioStr == "9999")
                {
                    tieneFechaVencimiento = false;
                    if (!Int32.TryParse(vencimientoFactuDiaStr, out diasDeVencimiento))
                    {
                        errorStr = "No se pudo interpretar la fecha de vencimiento " + vencimientoFactuStr;
                        mensajeError.AppendLine(errorStr);
                        GenerarLog(dbCorrida.Id, errorStr);
                        procesarArchivo = false;
                    }
                }
                else
                {
                    tieneFechaVencimiento = true;
                    if (!DateTime.TryParseExact(vencimientoFactuStr, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out fechaDeVencimiento))
                    {
                        errorStr = "No se pudo interpretar la fecha de vencimiento " + vencimientoFactuStr;
                        mensajeError.AppendLine(errorStr);
                        GenerarLog(dbCorrida.Id, errorStr);
                        procesarArchivo = false;
                    }
                }

                string montoTotalStr = filePartes[arch_montototal];              
                montoTotalStr = montoTotalStr.Replace(".", CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);
                if (!Decimal.TryParse(montoTotalStr, out montoTotal))
                {
                    errorStr = "No se pudo interpretar el MontoTotal " + montoTotalStr;
                    mensajeError.AppendLine(errorStr);
                    GenerarLog(dbCorrida.Id, errorStr);
                    procesarArchivo = false;
                }

                string tipoContratoStr = filePartes[arch_tipoContrato];
                
                if (!String.IsNullOrEmpty(tipoContratoStr))
                {
                    tipoContrato = GetTipoContrato(ctx).Where(t => t.Codigo == tipoContratoStr).SingleOrDefault();

                    if (tipoContrato == null)
                    {
                        errorStr = "No se pudo interpretar el Tipo de Contrato " + tipoContratoStr;
                        mensajeError.AppendLine(errorStr);
                        GenerarLog(dbCorrida.Id, errorStr);
                        procesarArchivo = false;
                    }
                }
                else
                {
                    errorStr = "No se pudo interpretar el Tipo de Contrato " + tipoContratoStr;
                    mensajeError.AppendLine(errorStr);
                    GenerarLog(dbCorrida.Id, errorStr);
                    procesarArchivo = false;
                }
            }

            CorridaSubidaArchivoDetalle detalle = new CorridaSubidaArchivoDetalle();
            if (procesarArchivo)
            {
                // obtengo el cliente
                var dbCliente = ctx.Clientes.Where(c => c.CUIT == cuit).SingleOrDefault();
                if (dbCliente == null)
                {
                    errorStr = "No se encuentra el cliente " + cuit.ToString();
                    mensajeError.AppendLine(errorStr);
                    GenerarLog(dbCorrida.Id, errorStr);
                    detalle.ProcesadoOK = false;
                }
                else
                {
                    // Obtengo el comprobante al que hay que asociarle el archivo
                    var dbComprobante = ctx.Comprobantes.Where(c => c.TipoComprobanteId == tipoComprobanteObj.Id && c.PtoVta == ptovta && c.CbteDesde <= nroComprobante && c.CbteHasta >= nroComprobante).FirstOrDefault();
                    if (dbComprobante == null)
                    {
                        // No se puede procesar
                        errorStr = string.Format("No se encuentra el comprobante asociado. Nro {0}, Tipo {1}, PtoVta: {2}", nroComprobante, tipoComprobanteObj.Descripcion, ptovta);
                        mensajeError.AppendLine(errorStr);
                        GenerarLog(dbCorrida.Id, errorStr);

                        // Lo copio a la carpeta de fallidos y registro el estado en el documento
                        //File.Move(filePath, fileDestinationPathNoOk);
                        detalle.ProcesadoOK = false;
                    }
                    else
                    {
                        bool clienteOk = true;
                        if (!dbComprobante.ClienteId.HasValue)
                        {
                            dbComprobante.ClienteId = dbCliente.Id;
                        }
                        else if (dbComprobante.ClienteId.Value != dbCliente.Id)
                        {
                            errorStr = string.Format("El cliente del comprobante CUIT {0} es distinto que el indicado en la factura CUIT {1}", dbComprobante.Cliente.CUIT, dbCliente.CUIT);
                            mensajeError.AppendLine(errorStr);
                            GenerarLog(dbCorrida.Id, errorStr);

                            // Lo copio a la carpeta de fallidos y registro el estado en el documento
                            //File.Move(filePath, fileDestinationPathNoOk);
                            detalle.ProcesadoOK = false;
                            clienteOk = false;
                        }

                        if (clienteOk)
                        {
                            // Lo copio a la carpeta de ok y lo guardo en la base
                            string destPath = Path.Combine(fileDestinationPathOk, fileName);
                            detalle.ProcesadoOK = true;
                            File.Move(filePath, destPath);

                            // Puede ser que el archivo asociado ya exista y lo tengo que actualizar
                            ArchivoAsociado archivoAsociado;
                            archivoAsociado = ctx.ArchivoAsociadoes.Where(a => a.ComprobanteId == dbComprobante.Id && a.NombreArchivo == fileName).SingleOrDefault();
                            if (archivoAsociado != null &&
                                archivoAsociado.EstadoArchivoAsociado.Codigo == CodigosEstadoArchivoAsociado.Visualizado)
                            {
                                // No se puede procesar porque ya fue visualizado
                                errorStr = string.Format("No se puede reemplazar el archivo asociado del comprobante porque ya fue visualizado. (Nro {0}, Tipo {1}, PtoVta: {2})", nroComprobante, tipoComprobanteObj.Descripcion, ptovta);
                                mensajeError.AppendLine(errorStr);
                                GenerarLog(dbCorrida.Id, errorStr);
                            }
                            else
                            {

                                if (archivoAsociado == null)
                                {
                                    archivoAsociado = new ArchivoAsociado();
                                    dbComprobante.ArchivoAsociadoes.Add(archivoAsociado);
                                }

                                detalle.ArchivoAsociado = archivoAsociado;
                                archivoAsociado.NombreArchivo = fileName;
                                archivoAsociado.PathArchivo = destPath;
                                archivoAsociado.NroComprobante = nroComprobante;
                                archivoAsociado.TipoContratoId = tipoContrato.Id;
                                if (tieneFechaVencimiento)
                                {
                                    archivoAsociado.FechaVencimiento = fechaDeVencimiento;
                                }
                                else
                                {
                                    archivoAsociado.DiasVencimiento = diasDeVencimiento;
                                }

                                archivoAsociado.FechaDeCarga = DateTime.Now;
                                archivoAsociado.MesFacturacion = periodoFacturacionMes;
                                archivoAsociado.AnioFacturacion = periodoFacturacionAnio;
                                archivoAsociado.EstadoId = GetEstadoArchivoAsociado(ctx).Where(c => c.Codigo == CodigosEstadoArchivoAsociado.NoVisualizado).Select(e => e.Id).Single();
                                archivoAsociado.MontoTotal = montoTotal;
                            }
                        }
                    }
                }
            }

            if (!detalle.ProcesadoOK)
            {
                // Lo copio a la carpeta de fallidos y registro el estado en el documento
                string destPath = Path.Combine(fileDestinationPathNoOk, fileName);
                File.Move(filePath, destPath);
            }

            detalle.NombreArchivo = fileName;
            detalle.Mensaje = mensajeError.ToString();
            dbCorrida.CorridaSubidaArchivoDetalles.Add(detalle);

        }

        private void ArmarArchivoAsociadoConContexto(FacturaElectronicaEntities ctx, CorridaSubidaArchivo dbCorrida, string filePath, string fileDestinationPathOk, string fileDestinationPathNoOk, EjecutarCorridaSubidaArchivo corrida)
        {
            string fileName = Path.GetFileName(filePath);

            StringBuilder mensajeError = new StringBuilder();
            string errorStr = string.Empty;

            bool procesarArchivo = true;
            long cuit = 0;
            if (!Int64.TryParse(corrida.Cuit, out cuit))
            {
                errorStr = "No se pudo interpretar el CUIT " + corrida.Cuit;
                mensajeError.AppendLine(errorStr);
                GenerarLog(dbCorrida.Id, errorStr);
                procesarArchivo = false;
            }

            string tipoComprobante = corrida.TipoDeComprobanteCodigo;
            TipoComprobante tipoComprobanteObj = null;
            if (!String.IsNullOrEmpty(tipoComprobante))
            {
                tipoComprobanteObj = GetTipoComprobante(ctx).Where(t => t.Codigo == tipoComprobante).SingleOrDefault();
                if (tipoComprobanteObj == null)
                {
                    errorStr = "No se pudo interpretar el Tipo de Comprobante " + tipoComprobante;
                    mensajeError.AppendLine(errorStr);
                    GenerarLog(dbCorrida.Id, errorStr);
                    procesarArchivo = false;
                }
            }
            else
            {
                errorStr = "No se pudo interpretar el Tipo de Comprobante " + tipoComprobante;
                mensajeError.AppendLine(errorStr);
                GenerarLog(dbCorrida.Id, errorStr);
                procesarArchivo = false;
            }

            long nroComprobante = corrida.NroComprobante;

            long? ptovta = corrida.PuntoDeVenta;

            string periodoFactuStr = corrida.PeriodoDeFacturacion;
            string periodoFactuAnioStr = periodoFactuStr.Substring(0, 4);
            string periodoFactuMesStr = periodoFactuStr.Substring(4, 2);
            int periodoFacturacionAnio = 0;
            int periodoFacturacionMes = 0;
            if (!Int32.TryParse(periodoFactuAnioStr, out periodoFacturacionAnio) || !Int32.TryParse(periodoFactuMesStr, out periodoFacturacionMes))
            {
                errorStr = "No se pudo interpretar el Periodo de Facturacion " + periodoFactuStr;
                mensajeError.AppendLine(errorStr);
                GenerarLog(dbCorrida.Id, errorStr);
                procesarArchivo = false;
            }

            bool tieneFechaVencimiento;
            DateTime fechaDeVencimiento = DateTime.MinValue;
            int diasDeVencimiento = 0;
            if (!corrida.FechaDeVencimiento.HasValue)
            {
                tieneFechaVencimiento = false;
                if (!corrida.DiasDeVencimiento.HasValue)
                {
                    errorStr = "No se pudo interpretar la fecha de vencimiento ";
                    mensajeError.AppendLine(errorStr);
                    GenerarLog(dbCorrida.Id, errorStr);
                    procesarArchivo = false;
                }
                else
                {
                    diasDeVencimiento = corrida.DiasDeVencimiento.Value;
                }
            }
            else
            {
                tieneFechaVencimiento = true;
                fechaDeVencimiento = corrida.FechaDeVencimiento.Value.Date;
            }

            string montoTotalStr = corrida.MontoTotal;
            decimal montoTotal;

            montoTotalStr = montoTotalStr.Replace(".", CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);
            if (!Decimal.TryParse(montoTotalStr, out montoTotal))
            {
                errorStr = "No se pudo interpretar el MontoTotal " + montoTotalStr;
                mensajeError.AppendLine(errorStr);
                GenerarLog(dbCorrida.Id, errorStr);
                procesarArchivo = false;
            }

            string tipoContratoStr = corrida.TipoContratoCodigo;
            TipoContrato tipoContrato = null;
            if (!String.IsNullOrEmpty(tipoContratoStr))
            {
                tipoContrato = GetTipoContrato(ctx).Where(t => t.Codigo == tipoContratoStr).SingleOrDefault();

                if (tipoContrato == null)
                {
                    errorStr = "No se pudo interpretar el Tipo de Contrato " + tipoContratoStr;
                    mensajeError.AppendLine(errorStr);
                    GenerarLog(dbCorrida.Id, errorStr);
                    procesarArchivo = false;
                }
            }
            else
            {
                errorStr = "No se pudo interpretar el Tipo de Contrato " + tipoContratoStr;
                mensajeError.AppendLine(errorStr);
                GenerarLog(dbCorrida.Id, errorStr);
                procesarArchivo = false;
            }

            CorridaSubidaArchivoDetalle detalle = new CorridaSubidaArchivoDetalle();
            if (procesarArchivo)
            {
                // obtengo el cliente
                var dbCliente = ctx.Clientes.Where(c => c.CUIT == cuit).SingleOrDefault();
                if (dbCliente == null)
                {
                    errorStr = "No se encuentra el cliente " + cuit.ToString();
                    mensajeError.AppendLine(errorStr);
                    GenerarLog(dbCorrida.Id, errorStr);
                    detalle.ProcesadoOK = false;
                }
                else
                {
                    // Obtengo el comprobante al que hay que asociarle el archivo
                    var dbComprobante = ctx.Comprobantes.Where(c => c.TipoComprobanteId == tipoComprobanteObj.Id && c.PtoVta == ptovta && c.CbteDesde <= nroComprobante && c.CbteHasta >= nroComprobante).FirstOrDefault();
                    bool comprobanteOK = false;
                    if (dbComprobante == null)
                    {
                        if (corrida.ForzarDatosCliente)
                        {
                            // Creo el comprobante
                            dbComprobante = new Comprobante();
                            ctx.Comprobantes.AddObject(dbComprobante);
                            dbComprobante.TipoComprobanteId = tipoComprobanteObj.Id;
                            dbComprobante.FechaDeCarga = DateTime.Now;
                            dbComprobante.ClienteId = dbCliente.Id;
                            dbComprobante.CAE = corrida.CAE;
                            dbComprobante.CAEFechaVencimiento = corrida.FechaVencimientoCAE.Value;
                            dbComprobante.CbteFecha = corrida.FechaComprobante;
                            dbComprobante.CbteDesde = corrida.NroComprobante;
                            dbComprobante.CbteHasta = corrida.NroComprobante;
                            dbComprobante.PtoVta = corrida.PuntoDeVenta;
                            ctx.SaveChanges();
                            comprobanteOK = true;
                        }
                        else
                        {
                            // No se puede procesar
                            errorStr = string.Format("No se encuentra el comprobante asociado. Nro {0}, Tipo {1}, PtoVta: {2}", nroComprobante, tipoComprobanteObj.Descripcion, ptovta);
                            mensajeError.AppendLine(errorStr);
                            GenerarLog(dbCorrida.Id, errorStr);

                            // Lo copio a la carpeta de fallidos y registro el estado en el documento
                            //File.Move(filePath, fileDestinationPathNoOk);
                            detalle.ProcesadoOK = false;
                        }
                    }
                    else
                    {
                        comprobanteOK = true;
                    }

                    if (comprobanteOK)
                    {
                        bool clienteOk = true;
                        if (!dbComprobante.ClienteId.HasValue)
                        {
                            dbComprobante.ClienteId = dbCliente.Id;
                        }
                        else if (dbComprobante.ClienteId.Value != dbCliente.Id)
                        {
                            errorStr = string.Format("El cliente del comprobante CUIT {0} es distinto que el indicado en la factura CUIT {1}", dbComprobante.Cliente.CUIT, dbCliente.CUIT);
                            mensajeError.AppendLine(errorStr);
                            GenerarLog(dbCorrida.Id, errorStr);

                            // Lo copio a la carpeta de fallidos y registro el estado en el documento
                            //File.Move(filePath, fileDestinationPathNoOk);
                            detalle.ProcesadoOK = false;
                            clienteOk = false;
                        }

                        if (clienteOk)
                        {
                            // Lo copio a la carpeta de ok y lo guardo en la base
                            string destPath = Path.Combine(fileDestinationPathOk, fileName);
                            detalle.ProcesadoOK = true;
                            File.Move(filePath, destPath);

                            // Puede ser que el archivo asociado ya exista y lo tengo que actualizar
                            ArchivoAsociado archivoAsociado;
                            archivoAsociado = ctx.ArchivoAsociadoes.Where(a => a.ComprobanteId == dbComprobante.Id && a.NombreArchivo == fileName).SingleOrDefault();
                            if (archivoAsociado != null &&
                                archivoAsociado.EstadoArchivoAsociado.Codigo == CodigosEstadoArchivoAsociado.Visualizado)
                            {
                                // No se puede procesar porque ya fue visualizado
                                errorStr = string.Format("No se puede reemplazar el archivo asociado del comprobante porque ya fue visualizado. (Nro {0}, Tipo {1}, PtoVta: {2})", nroComprobante, tipoComprobanteObj.Descripcion, ptovta);
                                mensajeError.AppendLine(errorStr);
                                GenerarLog(dbCorrida.Id, errorStr);
                            }
                            else
                            {
                                if (archivoAsociado == null)
                                {
                                    archivoAsociado = new ArchivoAsociado();
                                    dbComprobante.ArchivoAsociadoes.Add(archivoAsociado);
                                }

                                detalle.ArchivoAsociado = archivoAsociado;
                                archivoAsociado.NombreArchivo = fileName;
                                archivoAsociado.PathArchivo = destPath;
                                archivoAsociado.NroComprobante = nroComprobante;
                                archivoAsociado.TipoContratoId = tipoContrato.Id;
                                if (tieneFechaVencimiento)
                                {
                                    archivoAsociado.FechaVencimiento = fechaDeVencimiento;
                                }
                                else
                                {
                                    archivoAsociado.DiasVencimiento = diasDeVencimiento;
                                }

                                archivoAsociado.FechaDeCarga = DateTime.Now;
                                archivoAsociado.MesFacturacion = periodoFacturacionMes;
                                archivoAsociado.AnioFacturacion = periodoFacturacionAnio;
                                archivoAsociado.EstadoId = GetEstadoArchivoAsociado(ctx).Where(c => c.Codigo == CodigosEstadoArchivoAsociado.NoVisualizado).Select(e => e.Id).Single();
                                archivoAsociado.MontoTotal = montoTotal;
                            }
                        }
                    }
                }
            }

            if (!detalle.ProcesadoOK)
            {
                // Lo copio a la carpeta de fallidos y registro el estado en el documento
                string destPath = Path.Combine(fileDestinationPathNoOk, fileName);
                File.Move(filePath, destPath);
            }

            detalle.NombreArchivo = fileName;
            detalle.Mensaje = mensajeError.ToString();
            dbCorrida.CorridaSubidaArchivoDetalles.Add(detalle);
        }

        private void SendEmailToCustomerInThread(long corridaId, List<Cliente> clienteList)
        {
            EmailConfiguration configuration = new EmailConfiguration();
            configuration.Subject = ConfigurationManager.AppSettings["MailSubject"];
            configuration.From = ConfigurationManager.AppSettings["MailFrom"];
            configuration.ReplayTo = ConfigurationManager.AppSettings["MailReplayTo"];
            configuration.BodyPathHtml = ConfigurationManager.AppSettings["MailBodyPathHtml"];
            configuration.Host = ConfigurationManager.AppSettings["MailHost"];
            configuration.Port = ConfigurationManager.AppSettings["MailPort"];

            configuration.MailUserName = ConfigurationManager.AppSettings["MailUserName"];
            configuration.MailPassword = ConfigurationManager.AppSettings["MailPassword"];
            configuration.MailEnableSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["MailEnableSSL"]);
            configuration.MailDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings["MailDefaultCredentials"]);

            foreach (Cliente cliente in clienteList)
            {
                // Envio 2 emails por cliente
                EmailInThread emailInThread = new EmailInThread();
                emailInThread.CorridaId = corridaId;
                emailInThread.Cuit = cliente.CUIT;
                emailInThread.Email = cliente.EmailContacto;
                emailInThread.Configuration = configuration;
                emailInThread.ConnectionString = ConfigurationManager.ConnectionStrings["FacturaElectronicaEntities"].ConnectionString;

                ThreadPool.QueueUserWorkItem(SendEmailToCustomer, emailInThread);

                if (!String.IsNullOrEmpty(cliente.EmailContactoSecundario))
                {
                    emailInThread = new EmailInThread();
                    emailInThread.CorridaId = corridaId;
                    emailInThread.Cuit = cliente.CUIT;
                    emailInThread.Email = cliente.EmailContactoSecundario;
                    emailInThread.Configuration = configuration;
                    emailInThread.ConnectionString = ConfigurationManager.ConnectionStrings["FacturaElectronicaEntities"].ConnectionString;

                    ThreadPool.QueueUserWorkItem(SendEmailToCustomer, emailInThread);
                }
            }
        }

        private void SendEmailToCustomer(object param)
        {
            EmailInThread emailInThread = (EmailInThread)param;
            using (FacturaElectronicaEntities ctx = new FacturaElectronicaEntities(emailInThread.ConnectionString))
            {
                try
                {
                    SendMail(emailInThread);
                    GenerarLog(ctx, emailInThread.CorridaId, string.Format("Email enviado a {0}", emailInThread.Email));
                }
                catch (Exception ex)
                {
                    string exceptionMessage = GetExceptionMessage(ex);
                    string exceptionStack = GetExceptionStackTrace(ex);
                    GenerarLog(ctx, emailInThread.CorridaId, string.Format("Email enviado a {0} con error {1}", emailInThread.Email, exceptionMessage + exceptionStack));
                }

                ctx.SaveChanges();
            }
        }

        public string GetExceptionMessage(Exception ex)
        {
            StringBuilder builder = new StringBuilder();

            Exception current = ex;
            while (current != null)
            {
                builder.Append(current.Message);
                current = current.InnerException;
            }

            return builder.ToString();
        }

        public string GetExceptionStackTrace(Exception ex)
        {
            StringBuilder builder = new StringBuilder();

            Exception current = ex;
            while (current != null)
            {
                builder.Append(current.StackTrace);
                current = current.InnerException;
            }

            return builder.ToString();
        }

        private static void SendMail(EmailInThread emailInThread)
        {
            string subject = emailInThread.Configuration.Subject;
            string body = File.ReadAllText(emailInThread.Configuration.BodyPathHtml);
            string from = emailInThread.Configuration.From;
            string replayTo = emailInThread.Configuration.ReplayTo;
            string host = emailInThread.Configuration.Host;
            string port = emailInThread.Configuration.Port;
            string username = emailInThread.Configuration.MailUserName;
            string password = emailInThread.Configuration.MailPassword;
            bool enableSSL = emailInThread.Configuration.MailEnableSSL;
            bool defaultCredentials = emailInThread.Configuration.MailDefaultCredentials;

            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(emailInThread.Email));
            email.Subject = subject;
            email.From = new MailAddress(from);
            email.ReplyToList.Add(new MailAddress(replayTo));
            email.Body = body;
            email.From = new MailAddress(from);
            email.ReplyToList.Add(new MailAddress(replayTo));
            //email.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure | DeliveryNotificationOptions.OnSuccess;
            email.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Host = host;
            client.Port = Convert.ToInt32(port);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            if (defaultCredentials)
            {
                client.UseDefaultCredentials = true;
            }
            else
            {
                if (!String.IsNullOrEmpty(username))
                {
                    client.Credentials = new NetworkCredential(username, password);
                }
            }

            client.EnableSsl = enableSSL;
            client.Send(email);
        }

        private List<TipoComprobante> tiposComprobante;
        private List<TipoComprobante> GetTipoComprobante(FacturaElectronicaEntities ctx)
        {
            if (tiposComprobante == null)
            {
                tiposComprobante = ctx.TipoComprobantes.ToList();
            }

            return tiposComprobante;
        }

        private List<TipoContrato> tiposContrato;
        private List<TipoContrato> GetTipoContrato(FacturaElectronicaEntities ctx)
        {
            if (tiposContrato == null)
            {
                tiposContrato = ctx.TipoContratoes.ToList();
            }

            return tiposContrato;
        }

        public List<EstadoArchivoAsociado> estadosArchivoAsociado;
        private List<EstadoArchivoAsociado> GetEstadoArchivoAsociado(FacturaElectronicaEntities ctx)
        {
            if (estadosArchivoAsociado == null)
            {
                estadosArchivoAsociado = ctx.EstadoArchivoAsociadoes.ToList();
            }

            return estadosArchivoAsociado;
        }

        private void GenerarLog(long corridaId, string mensaje)
        {
            using (FacturaElectronicaEntities ctx = new FacturaElectronicaEntities())
            {
                GenerarLog(ctx, corridaId, mensaje);
            }
        }

        private static void GenerarLog(FacturaElectronicaEntities ctx, long corridaId, string mensaje)
        {
            CorridaSubidaArchivoLog log = new CorridaSubidaArchivoLog();
            log.Mensaje = mensaje;
            log.Fecha = DateTime.Now;
            log.CorridaId = corridaId;
            ctx.CorridaSubidaArchivoLogs.AddObject(log);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Obtiene las corridas de subida de archivo
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<CorridaSubidaArchivoDto> ObtenerCorridas(CorridaSubidaArchivoSearch search)
        {
            List<CorridaSubidaArchivoDto> corridasList = new List<CorridaSubidaArchivoDto>();
            using (FacturaElectronicaEntities ctx = new FacturaElectronicaEntities())
            {
                IQueryable<CorridaSubidaArchivo> query = ctx.CorridaSubidaArchivoes;

                if (search.CorridaId.HasValue)
                {
                    query = query.Where(c => c.Id == search.CorridaId);
                }
                else
                {
                    if (!String.IsNullOrEmpty(search.NombreArchivoLike))
                    {
                        query = query.Where(c => c.CorridaSubidaArchivoDetalles.Where(d => d.NombreArchivo.Contains(search.NombreArchivoLike)).Count() > 0);
                    }

                    if (search.FechaDesde.HasValue)
                    {
                        DateTime desde = search.FechaDesde.Value.Date;
                        query = query.Where(c => c.FechaProceso >= desde);
                    }

                    if (search.FechaHasta.HasValue)
                    {
                        DateTime hasta = search.FechaHasta.Value.Date.AddDays(1).AddSeconds(-1);
                        query = query.Where(c => c.FechaProceso <= hasta);
                    }
                }

                query = query.OrderByDescending(c => c.Id);

                List<CorridaSubidaArchivo> corridas = query.ToList();
                foreach (var dbCorrida in corridas)
                {
                    CorridaSubidaArchivoDto corridaDto = new CorridaSubidaArchivoDto();
                    EntityMapper.Map(dbCorrida, corridaDto);

                    if (search.LoadDetalle)
                    {
                        List<CorridaSubidaArchivoDetalleDto> detalleDtoList = new List<CorridaSubidaArchivoDetalleDto>();
                        foreach (var dbDetalle in dbCorrida.CorridaSubidaArchivoDetalles)
                        {
                            CorridaSubidaArchivoDetalleDto detalle = new CorridaSubidaArchivoDetalleDto();
                            EntityMapper.Map(dbDetalle, detalle);
                            detalleDtoList.Add(detalle);
                        }

                        corridaDto.Detalles = detalleDtoList;
                    }

                    if (search.LoadLog)
                    {
                        List<CorridaSubidaArchivoLogDto> logDtoList = new List<CorridaSubidaArchivoLogDto>();
                        IQueryable<CorridaSubidaArchivoLog> queryLog = dbCorrida.CorridaSubidaArchivoLogs.AsQueryable();

                        if (search.FechaLog.HasValue)
                        {
                            queryLog = queryLog.Where(l => l.Fecha >= search.FechaLog.Value);
                        }

                        foreach (var dbLog in queryLog)
                        {
                            CorridaSubidaArchivoLogDto logDto = new CorridaSubidaArchivoLogDto();
                            EntityMapper.Map(dbLog, logDto);
                            logDtoList.Add(logDto);
                            if (logDto.Mensaje == FinCorridaStr)
                            {
                                logDto.FinCorrida = true;
                            }
                        }

                        corridaDto.Log = logDtoList;
                    }

                    corridasList.Add(corridaDto);
                }
            }

            return corridasList;
        }
    }
}
