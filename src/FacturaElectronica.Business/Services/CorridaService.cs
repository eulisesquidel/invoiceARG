using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacturaElectronica.Afip.Ws.Wsfe;
using FacturaElectronica.Data;
using FacturaElectronica.Common.Constants;
using System.Globalization;
using FacturaElectronica.Core.Helpers;
using System.Transactions;
using FacturaElectronica.Common.Contracts;
using FacturaElectronica.Common.Services;
using System.IO;
using FacturaElectronica.Common.Contracts.Search;
using FacturaElectronica.Afip.Ws.Wsfex;

namespace FacturaElectronica.Business.Services
{
    public class CorridaService : ICorridaService
    {
        public static string FinCorridaMsg = "@FinCorrida";
        private ComprobanteService cbteSvc = new ComprobanteService();
        private ClienteService clienteSvc = new ClienteService();

        public CorridaAutorizacionDto CrearNuevaCorrida(string xmlPath)
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                CorridaAutorizacion corrida = new CorridaAutorizacion();
                corrida.Fecha = DateTime.Now;
                corrida.PathArchivo = xmlPath;
                corrida.Procesada = null;
                ctx.CorridaAutorizacions.AddObject(corrida);
                ctx.SaveChanges();
                return ToCorridaDto(corrida, null, null, null);
            }
        }

        public List<CorridaAutorizacionDto> ObtenerCorridas(CorridaSearch search)
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                IQueryable<CorridaAutorizacion> query = ctx.CorridaAutorizacions;

                if (search.CorridaId.HasValue)
                {
                    query = query.Where(c => c.Id == search.CorridaId.Value);
                }
                else
                {
                    if (search.FechaDesde.HasValue)
                    {
                        DateTime desde = search.FechaDesde.Value.Date;
                        query = query.Where(c => desde <= c.Fecha);
                    }

                    if (search.FechaHasta.HasValue)
                    {
                        DateTime hasta = search.FechaHasta.Value.Date.AddDays(1).AddSeconds(-1);
                        query = query.Where(c => c.Fecha <= hasta);
                    }
                }

                query = query.OrderByDescending(c => c.Id);

                return ToCorridaDtoList(query.ToList(), ctx.TipoDocumentoes.ToList(), ctx.TipoComprobantes.ToList(), ctx.TipoConceptoes.ToList());
            }
        }

        public CorridaAutorizacionDto ProcesarCorrida(CorridaAutorizacionDto corridaDto, FECAEResponse feCAEResponse)
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                CorridaAutorizacion corrida = ctx.CorridaAutorizacions.Where(c => c.Id == corridaDto.Id).First();

                // Procesar Cabecera
                DetalleCabecera cabecera = new DetalleCabecera();
                FECabResponse feCabResp = feCAEResponse.FeCabResp;
                cabecera.CantReg = feCabResp.CantReg;
                cabecera.CUIT = feCabResp.Cuit;
                cabecera.CbteTipo = feCabResp.CbteTipo;
                cabecera.FchProceso = DateTimeHelper.ConvertyyyyMMddhhmmssToDate(feCabResp.FchProceso);
                cabecera.Resultado = feCabResp.Resultado;
                cabecera.PtoVta = feCabResp.PtoVta;

                corrida.DetalleCabeceras.Add(cabecera);

                TipoComprobanteDto tipoCbteDto = cbteSvc.ObtenerTipoComprobantePorCodigoAfip(cabecera.CbteTipo);
                int tipoCbteId;
                if (tipoCbteDto != null)
                {
                    tipoCbteId = tipoCbteDto.Id;
                }

                if (feCAEResponse.FeDetResp != null && feCAEResponse.FeDetResp.Count() > 0)
                {
                    // Procesar Comprobantes
                    DetalleComprobante detalleCbte = null;
                    ObservacionComprobante observacionesCbte = null;
                    foreach (FECAEDetResponse cbte in feCAEResponse.FeDetResp)
                    {
                        detalleCbte = new DetalleComprobante();
                        detalleCbte.Concepto = cbte.Concepto;
                        detalleCbte.DocTipo = cbte.DocTipo;
                        detalleCbte.DocNro = cbte.DocNro;
                        detalleCbte.CbteDesde = cbte.CbteDesde;
                        detalleCbte.CbteHasta = cbte.CbteHasta;
                        detalleCbte.CbteFch = DateTimeHelper.ConvertyyyyMMddToDate(cbte.CbteFch);
                        detalleCbte.Resultado = cbte.Resultado;


                        if (cbte.Resultado == ResultadoCbte.Aprobado)
                        {
                            detalleCbte.CAE = cbte.CAE;
                            detalleCbte.CAEFchVto = DateTimeHelper.ConvertyyyyMMddToDate(cbte.CAEFchVto);

                            // Si fue aprobado agrego una entidad Comprobante
                            Comprobante comprobante = new Comprobante();
                            comprobante.CAE = detalleCbte.CAE;
                            comprobante.CAEFechaVencimiento = detalleCbte.CAEFchVto;
                            comprobante.CbteDesde = detalleCbte.CbteDesde;
                            comprobante.CbteHasta = detalleCbte.CbteHasta;
                            comprobante.CbteFecha = detalleCbte.CbteFch;
                            comprobante.PtoVta = cabecera.PtoVta;
                            comprobante.FechaDeCarga = DateTime.Now;
                            comprobante.TipoComprobante = ctx.TipoComprobantes.Where(tc => tc.CodigoAfip == cabecera.CbteTipo).FirstOrDefault();
                            if (detalleCbte.DocTipo == 80) // CUIT
                            {
                                ClienteDto clienteDto = clienteSvc.ObtenerClientePorCuit(detalleCbte.DocNro);
                                if (clienteDto != null)
                                {
                                    comprobante.ClienteId = clienteDto.Id;
                                }
                            }
                            // #TODO: borrar 
                            //EstadoComprobanteDto estadoDto = this.cbteSvc.ObtenerEstado(CodigoEstadoCbte.NoVisualizado);
                            //if (estadoDto != null)
                            //{
                            //    comprobante.EstadoId = estadoDto.Id;
                            //}
                            detalleCbte.Comprobantes.Add(comprobante);
                        }
                        else
                        {
                            if (cbte.Observaciones != null && cbte.Observaciones.Count() > 0)
                            {
                                foreach (Obs obs in cbte.Observaciones)
                                {
                                    observacionesCbte = new ObservacionComprobante();
                                    observacionesCbte.Code = obs.Code;
                                    observacionesCbte.Msg = obs.Msg;
                                    detalleCbte.ObservacionComprobantes.Add(observacionesCbte);
                                }
                            }
                        }
                        corrida.DetalleComprobantes.Add(detalleCbte);
                    }
                }
                if (feCAEResponse.Events != null && feCAEResponse.Events.Count() > 0)
                {
                    // Procesar Eventos
                    DetalleEvento detalleEvento = null;
                    foreach (Evt evento in feCAEResponse.Events)
                    {
                        detalleEvento = new DetalleEvento();
                        detalleEvento.Code = evento.Code;
                        detalleEvento.Msg = evento.Msg;
                        corrida.DetalleEventos.Add(detalleEvento);
                    }
                }
                if (feCAEResponse.Errors != null && feCAEResponse.Errors.Count() > 0)
                {
                    // Procesar Errores
                    DetalleError detalleError = null;
                    foreach (Err error in feCAEResponse.Errors)
                    {
                        detalleError = new DetalleError();
                        detalleError.Code = error.Code;
                        detalleError.Msg = error.Msg;
                        corrida.DetalleErrores.Add(detalleError);
                    }
                }

                corrida.Procesada = true;

                ctx.SaveChanges();
                return ToCorridaDto(corrida, ctx.TipoDocumentoes.ToList(), ctx.TipoComprobantes.ToList(), ctx.TipoConceptoes.ToList());
            }
        }


        public CorridaAutorizacionDto ProcesarCorridaWsFeX(CorridaAutorizacionDto corridaDto, FEXResponseAuthorize feXCAEResponse, ClsFEXRequest feXCAERequest)
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                CorridaAutorizacion corrida = ctx.CorridaAutorizacions.Where(c => c.Id == corridaDto.Id).First();

                // Procesar Cabecera
                DetalleCabecera cabecera = new DetalleCabecera();
                ClsFEXOutAuthorize feCabResp = feXCAEResponse.FEXResultAuth;
                if (feCabResp != null)
                {
                    cabecera.CantReg = 1; // ByAd: revisar
                    cabecera.CUIT = feCabResp.Cuit;
                    cabecera.CbteTipo = feCabResp.Cbte_tipo;
                    cabecera.FchProceso = DateTime.Now; // ByAd: revisar
                    cabecera.Resultado = feCabResp.Resultado;
                    cabecera.PtoVta = feCabResp.Punto_vta;

                    corrida.DetalleCabeceras.Add(cabecera);

                    TipoComprobanteDto tipoCbteDto = cbteSvc.ObtenerTipoComprobantePorCodigoAfip(cabecera.CbteTipo);
                    int tipoCbteId;
                    if (tipoCbteDto != null)
                    {
                        tipoCbteId = tipoCbteDto.Id;
                    }

                    // Procesar Comprobantes
                    DetalleComprobante detalleCbte = null;
                    ObservacionComprobante observacionesCbte = null;

                    detalleCbte = new DetalleComprobante();
                    detalleCbte.Concepto = 1; // ByAd revisar: aca es prdoucto, servicios o ambos
                    detalleCbte.DocTipo = 80;
                    detalleCbte.DocNro = feCabResp.Cuit;
                    detalleCbte.CbteDesde = feCabResp.Cbte_nro;
                    detalleCbte.CbteHasta = feCabResp.Cbte_nro;
                    detalleCbte.CbteFch = DateTimeHelper.ConvertyyyyMMddToDate(feCabResp.Fch_cbte);
                    detalleCbte.Resultado = feCabResp.Resultado;

                    if (feCabResp.Resultado == ResultadoCbte.Aprobado)
                    {
                        detalleCbte.CAE = feCabResp.Cae;
                        detalleCbte.CAEFchVto = DateTimeHelper.ConvertyyyyMMddToDate(feCabResp.Fch_venc_Cae);

                        // Si fue aprobado agrego una entidad Comprobante
                        Comprobante comprobante = new Comprobante();
                        comprobante.CAE = detalleCbte.CAE;
                        comprobante.CAEFechaVencimiento = detalleCbte.CAEFchVto;
                        comprobante.CbteDesde = detalleCbte.CbteDesde;
                        comprobante.CbteHasta = detalleCbte.CbteHasta;
                        comprobante.CbteFecha = detalleCbte.CbteFch;
                        comprobante.PtoVta = cabecera.PtoVta;
                        comprobante.FechaDeCarga = DateTime.Now;
                        comprobante.TipoComprobante = ctx.TipoComprobantes.Where(tc => tc.CodigoAfip == cabecera.CbteTipo).FirstOrDefault();
                        if (detalleCbte.DocTipo == 80) // CUIT
                        {
                            ClienteDto clienteDto = clienteSvc.ObtenerClientePorCuit(detalleCbte.DocNro);
                            if (clienteDto != null)
                            {
                                comprobante.ClienteId = clienteDto.Id;
                            }
                        }
                        // #TODO: borrar 
                        //EstadoComprobanteDto estadoDto = this.cbteSvc.ObtenerEstado(CodigoEstadoCbte.NoVisualizado);
                        //if (estadoDto != null)
                        //{
                        //    comprobante.EstadoId = estadoDto.Id;
                        //}
                        detalleCbte.Comprobantes.Add(comprobante);
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(feCabResp.Motivos_Obs))
                        {
                            observacionesCbte = new ObservacionComprobante();
                            observacionesCbte.Code = 1; // ByAd: hardcodeado, ya que este tipo no recibe
                            observacionesCbte.Msg = feCabResp.Motivos_Obs;
                            detalleCbte.ObservacionComprobantes.Add(observacionesCbte);
                        }
                    }

                    corrida.DetalleComprobantes.Add(detalleCbte);
                }

                if (feXCAEResponse.FEXEvents != null && !String.IsNullOrEmpty(feXCAEResponse.FEXEvents.EventMsg))
                {
                    // Procesar Eventos
                    DetalleEvento detalleEvento = null;
                    detalleEvento = new DetalleEvento();
                    detalleEvento.Code = feXCAEResponse.FEXEvents.EventCode;
                    detalleEvento.Msg = feXCAEResponse.FEXEvents.EventMsg;
                    corrida.DetalleEventos.Add(detalleEvento);
                }
                if (feXCAEResponse.FEXErr != null && !String.IsNullOrEmpty(feXCAEResponse.FEXErr.ErrMsg))
                {
                    // Procesar Errores
                    DetalleError detalleError = null;
                    detalleError = new DetalleError();
                    detalleError.Code = feXCAEResponse.FEXErr.ErrCode;
                    detalleError.Msg = feXCAEResponse.FEXErr.ErrMsg;
                    corrida.DetalleErrores.Add(detalleError);
                }

                corrida.Procesada = true;

                ctx.SaveChanges();
                return ToCorridaDto(corrida, ctx.TipoDocumentoes.ToList(), ctx.TipoComprobantes.ToList(), ctx.TipoConceptoes.ToList());
            }
        }
        /// <summary>
        /// Indica si la corrida puede ejectuarse si es asi la marca en proceso
        /// </summary>
        /// <param name="corridaId"></param>
        /// <returns></returns>
        public bool MarcarCorridaEnProceso(long corridaId)
        {
            bool puedeEjecturar = false;
            using (var ctx = new FacturaElectronicaEntities())
            {
                var corridaAutorizacion = ctx.CorridaAutorizacions.Where(c => c.Id == corridaId).SingleOrDefault();
                if (corridaAutorizacion != null)
                {
                    if (!corridaAutorizacion.Procesada.HasValue)
                    {
                        corridaAutorizacion.Procesada = false; // Significa que está en proceso
                        ctx.SaveChanges();
                        puedeEjecturar = true;
                    }
                }
            }

            return puedeEjecturar;
        }

        public void Log(long corridaId, string mensaje, string detalle)
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                LogCorrida log = new LogCorrida();
                log.CorridaId = corridaId;
                log.Fecha = DateTime.Now;
                log.Mensaje = mensaje;
                log.Detalle = detalle;
                ctx.LogCorridas.AddObject(log);
                ctx.SaveChanges();
            }
        }

        public List<LogCorridaDto> ConsultarLog(LogSearch search)
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                IQueryable<LogCorrida> query = ctx.LogCorridas;

                query = query.Where(l => l.CorridaId == search.CorridaId);

                if (search.LogId.HasValue)
                {
                    query = query.Where(l => search.LogId.Value < l.Id);
                }

                return ToLogCorridaDtoList(query.ToList());
            }
        }


        #region [Conversion]

        public static CorridaAutorizacionDto ToCorridaDto(CorridaAutorizacion corrida, List<TipoDocumento> tiposDoc, List<TipoComprobante> tiposComprobante, List<TipoConcepto> tiposConcepto)
        {
            CorridaAutorizacionDto dto = new CorridaAutorizacionDto();
            dto.Id = corrida.Id;
            dto.Fecha = corrida.Fecha;
            dto.Procesada = corrida.Procesada;
            dto.NombreDeArchivo = Path.GetFileName(corrida.PathArchivo);
            dto.PathArchivo = corrida.PathArchivo;

            if (tiposComprobante != null)
            {
                DetalleCabecera cabecera = corrida.DetalleCabeceras.FirstOrDefault();
                if (cabecera != null)
                {
                    TipoComprobante tipoComprobante = tiposComprobante.Where(c => c.CodigoAfip == cabecera.CbteTipo).First();
                    dto.TipoComprobante = string.Format("{0} - {1}", tipoComprobante.CodigoAfip, tipoComprobante.Descripcion);
                }
            }
            dto.ComprobantesAutorizados = ToDetalleComprobateDtoList(corrida.DetalleComprobantes.Where(dc => dc.Resultado == ResultadoCbte.Aprobado && dc.CorridaId == corrida.Id).ToList(), tiposDoc, tiposConcepto);
            dto.ComprobantesConObservaciones = ToDetalleComprobateDtoList(corrida.DetalleComprobantes.Where(dc => dc.Resultado == ResultadoCbte.Rechazado && dc.CorridaId == corrida.Id).ToList(), tiposDoc, tiposConcepto);
            dto.Errores = ToDetalleErrorDtoList(corrida.DetalleErrores.Where(e => e.CorridaId == corrida.Id).ToList());
            dto.Eventos = ToDetalleEventoDtoList(corrida.DetalleEventos.Where(e => e.CorridaId == corrida.Id).ToList());

            return dto;
        }

        private static List<CorridaAutorizacionDto> ToCorridaDtoList(List<CorridaAutorizacion> corridaList, List<TipoDocumento> tiposDoc, List<TipoComprobante> tiposComprobante, List<TipoConcepto> tiposConcepto)
        {
            List<CorridaAutorizacionDto> dtoList = new List<CorridaAutorizacionDto>();

            foreach (CorridaAutorizacion corrida in corridaList)
            {
                dtoList.Add(ToCorridaDto(corrida, tiposDoc, tiposComprobante, tiposConcepto));
            }

            return dtoList;
        }

        private static DetalleComprobanteDto ToDetalleComprobanteDto(DetalleComprobante detalleComprobante, List<TipoDocumento> tiposDoc, List<TipoConcepto> tiposConcepto)
        {
            if (detalleComprobante == null) return null;

            DetalleComprobanteDto dto = new DetalleComprobanteDto();
            dto.Id = detalleComprobante.Id;
            dto.CbteFecha = detalleComprobante.CbteFch;
            dto.CbteDesde = detalleComprobante.CbteDesde;
            dto.CbteHasta = detalleComprobante.CbteHasta;
            dto.Concepto = detalleComprobante.Concepto;
            dto.DocNro = detalleComprobante.DocNro;
            dto.DocTipo = detalleComprobante.DocTipo;
            StringBuilder sbDocTipo = new StringBuilder();
            sbDocTipo.Append(detalleComprobante.DocTipo.ToString());
            if (tiposDoc != null)
            {
                TipoDocumento tipoDoc = tiposDoc.Where(d => d.CodigoAfip == detalleComprobante.DocTipo).FirstOrDefault();
                if (tipoDoc != null)
                {
                    sbDocTipo.AppendFormat(" ({0}) ", tipoDoc.Descripcion);
                }
            }
            dto.DocTipoDesc = sbDocTipo.ToString();

            StringBuilder sbConcepto = new StringBuilder();
            sbConcepto.Append(detalleComprobante.Concepto.ToString());
            if (tiposConcepto != null)
            {
                TipoConcepto tipoConcepto = tiposConcepto.Where(c => c.Id == detalleComprobante.Concepto).FirstOrDefault();
                if (tipoConcepto != null)
                {
                    sbConcepto.AppendFormat(" - {0} ", tipoConcepto.Descripcion);
                }
            }
            dto.ConceptoDesc = sbConcepto.ToString();


            if (detalleComprobante.Resultado == ResultadoCbte.Aprobado)
            {
                dto.CAE = detalleComprobante.CAE;
                dto.CAEFechaVto = (DateTime)detalleComprobante.CAEFchVto;
            }
            if (detalleComprobante.Resultado == ResultadoCbte.Rechazado)
            {
                dto.Observaciones = ToObservacionComprobateDtoList(detalleComprobante.ObservacionComprobantes.ToList());
            }

            return dto;
        }

        private static List<DetalleComprobanteDto> ToDetalleComprobateDtoList(List<DetalleComprobante> detalleComprobanteList, List<TipoDocumento> tiposDoc, List<TipoConcepto> tiposConcepto)
        {
            List<DetalleComprobanteDto> dtoList = new List<DetalleComprobanteDto>();

            foreach (DetalleComprobante detalleCbte in detalleComprobanteList)
            {
                dtoList.Add(ToDetalleComprobanteDto(detalleCbte, tiposDoc, tiposConcepto));
            }

            return dtoList;
        }

        private static List<ObservacionComprobanteDto> ToObservacionComprobateDtoList(List<ObservacionComprobante> detalleComprobanteList)
        {
            List<ObservacionComprobanteDto> dtoList = new List<ObservacionComprobanteDto>();

            foreach (ObservacionComprobante detalleCbte in detalleComprobanteList)
            {
                dtoList.Add(ToObservacionComprobateDto(detalleCbte));
            }

            return dtoList;
        }

        private static ObservacionComprobanteDto ToObservacionComprobateDto(ObservacionComprobante observacion)
        {
            if (observacion == null) return null;

            ObservacionComprobanteDto dto = new ObservacionComprobanteDto();
            dto.Id = observacion.Id;
            dto.Codigo = observacion.Code;
            dto.Mensaje = observacion.Msg;

            return dto;
        }

        private static List<DetalleErrorDto> ToDetalleErrorDtoList(List<DetalleError> detalleErrorList)
        {
            List<DetalleErrorDto> dtoList = new List<DetalleErrorDto>();

            foreach (DetalleError detalleError in detalleErrorList)
            {
                dtoList.Add(ToDetalleErrorDto(detalleError));
            }

            return dtoList;
        }

        private static DetalleErrorDto ToDetalleErrorDto(DetalleError detalleError)
        {
            if (detalleError == null) return null;

            DetalleErrorDto dto = new DetalleErrorDto();
            dto.Id = detalleError.Id;
            dto.Codigo = detalleError.Code;
            dto.Mensaje = detalleError.Msg;

            return dto;
        }

        private static List<DetalleEventoDto> ToDetalleEventoDtoList(List<DetalleEvento> detalleErrorList)
        {
            List<DetalleEventoDto> dtoList = new List<DetalleEventoDto>();

            foreach (DetalleEvento detalleEvento in detalleErrorList)
            {
                dtoList.Add(ToDetalleEventoDto(detalleEvento));
            }

            return dtoList;
        }

        private static DetalleEventoDto ToDetalleEventoDto(DetalleEvento detalleError)
        {
            if (detalleError == null) return null;

            DetalleEventoDto dto = new DetalleEventoDto();
            dto.Id = detalleError.Id;
            dto.Codigo = detalleError.Code;
            dto.Mensaje = detalleError.Msg;

            return dto;
        }

        private static List<LogCorridaDto> ToLogCorridaDtoList(List<LogCorrida> logCorridaList)
        {
            List<LogCorridaDto> dtoList = new List<LogCorridaDto>();

            foreach (LogCorrida logCorrida in logCorridaList)
            {
                dtoList.Add(ToLogCorridaDto(logCorrida));
            }

            return dtoList;
        }

        private static LogCorridaDto ToLogCorridaDto(LogCorrida logCorrida)
        {
            if (logCorrida == null) return null;

            LogCorridaDto dto = new LogCorridaDto();
            dto.Id = logCorrida.Id;
            dto.CorridaId = logCorrida.CorridaId;
            dto.Fecha = logCorrida.Fecha;
            if (logCorrida.Mensaje == CorridaService.FinCorridaMsg)
            {
                dto.CorridaTerminada = true;
            }
            else
            {
                dto.Mensaje = logCorrida.Mensaje;
            }

            return dto;
        }

        #endregion [Conversion]

    }
}
