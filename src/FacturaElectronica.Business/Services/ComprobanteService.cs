using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacturaElectronica.Common.Services;
using FacturaElectronica.Common.Contracts;
using FacturaElectronica.Data;
using System.Data.Objects;
using FacturaElectronica.Common.Constants;
using WebFramework.Mapper;
using System.Transactions;

namespace FacturaElectronica.Business.Services
{
    public class ComprobanteService : IComprobanteService
    {
        #region [Comprobantes]

        public void CrearComprobante(ComprobanteDto dto)
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                Comprobante cbte = new Comprobante();
                ToComprobante(dto, cbte);
                ctx.Comprobantes.AddObject(cbte);
                ctx.SaveChanges();
            }
        }

        public ComprobanteDto ObtenerComprobanteDeArchivoAsociado(long archivoAsociadoId)
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                var dbArchivoAsociado = ctx.ArchivoAsociadoes.Where(a => a.Id == archivoAsociadoId).Single();
                var dbComprobante = dbArchivoAsociado.Comprobante;

                ComprobanteDto comprobanteDto = ToComprobanteDto(dbComprobante);
                comprobanteDto.NroComprobante = dbArchivoAsociado.NroComprobante;
                return comprobanteDto;
            }
        }

        /// <summary>
        /// Obtiene los comprobantes para un cliente
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="cantUltimosCbtes">cant. de ultimos comprobantes a mostrar. Si es igual a 0 retorna toda el set de datos</param>
        /// <returns></returns>
        public List<ComprobanteArchivoAsociadoDto> ObtenerComprobantesPorCliente(ComprobanteCriteria criteria, int cantUltimosCbtes)
        {
            // SearchResult result = new SearchResult();
            List<ComprobanteArchivoAsociadoDto> result = null;

            using (var ctx = new FacturaElectronicaEntities())
            {
                DateTime hoy = DateTime.Now.Date;
                var query = (from aa in ctx.ArchivoAsociadoes
                             join c in ctx.Comprobantes on aa.ComprobanteId equals c.Id
                             where
                                 // Fecha Vencimiento
                             (!criteria.FechaVencDesde.HasValue || !aa.FechaVencimiento.HasValue || criteria.FechaVencDesde.Value <= aa.FechaVencimiento)
                             && (!criteria.FechaVencHasta.HasValue || aa.FechaVencimiento <= criteria.FechaVencHasta.Value)
                                 // Fecha de Recepcion
                            && (!criteria.FechaDeRecepcionDesde.HasValue || criteria.FechaDeRecepcionDesde.Value <= aa.FechaDeRecepcion)
                            && (!criteria.FechaDeRecepcionHasta.HasValue || aa.FechaDeRecepcion <= criteria.FechaDeRecepcionHasta.Value)
                                 // Dias de vto
                             && (!criteria.DiasDeVencimientoDesde.HasValue || criteria.DiasDeVencimientoDesde.Value <= aa.DiasVencimiento)
                             && (!criteria.DiasDeVencimientoHasta.HasValue || criteria.DiasDeVencimientoHasta.Value >= aa.DiasVencimiento)
                                 // Razon Social
                             && (string.IsNullOrEmpty(criteria.RazonSocial) || c.Cliente.RazonSocial.Contains(criteria.RazonSocial))
                                 // Tipo Comprobante
                             && (!criteria.TipoComprobanteId.HasValue || c.TipoComprobanteId == criteria.TipoComprobanteId.Value)
                                 // Nro Comprobante
                             && (!criteria.NroComprobante.HasValue || aa.NroComprobante == criteria.NroComprobante.Value)
                                 // Cliente Id
                            && (!criteria.ClienteId.HasValue || c.ClienteId == criteria.ClienteId.Value)
                                 // Tipo Contrato
                             && (!criteria.TipoContratoId.HasValue || aa.TipoContratoId == criteria.TipoContratoId.Value)
                                 // Periodo Facturacion
                             && (!criteria.MesFacturacion.HasValue || aa.MesFacturacion == criteria.MesFacturacion.Value)
                             && (!criteria.AnioFacturacion.HasValue || aa.AnioFacturacion == criteria.AnioFacturacion.Value)
                                 //     // Documentos Vencidos
                             && (!criteria.DocumentosVencidos || aa.FechaVencimiento < hoy)
                                 //     // Documentos No Vencidos
                             && (!criteria.DocumentosNoVencidos || !aa.FechaVencimiento.HasValue || hoy <= aa.FechaVencimiento.Value)
                                 //     // Sacar Documentos Eliminados
                             && (aa.EstadoArchivoAsociado.Codigo != CodigosEstadoArchivoAsociado.Eliminado)
                                 // Estados por Id
                             && (!criteria.EstadoId.HasValue || aa.EstadoArchivoAsociado.Id == criteria.EstadoId)
                                 //     //Estado por Codigo
                             && (string.IsNullOrEmpty(criteria.Estado) || aa.EstadoArchivoAsociado.Codigo == criteria.Estado)
                             select new ComprobanteArchivoAsociadoDto()
                             {
                                 ArchivoAsociadoId = aa.Id,
                                 ClienteId = c.ClienteId,
                                 ClienteRazonSocial = c.Cliente.RazonSocial,
                                 ComprobanteId = c.Id,
                                 EstadoCodigo = aa.EstadoArchivoAsociado.Codigo,
                                 EstadoDescripcion = aa.EstadoArchivoAsociado.Descripcion,
                                 FechaDeCarga = aa.FechaDeCarga,
                                 FechaVencimiento = aa.FechaVencimiento,
                                 DiasVencimiento = aa.DiasVencimiento,
                                 NroComprobante = aa.NroComprobante,
                                 PathArchivo = aa.PathArchivo,
                                 TipoComprobanteId = c.TipoComprobanteId,
                                 TipoComprobanteDescripcion = c.TipoComprobante.Descripcion,
                                 TipoContratoId = aa.TipoContratoId,
                                 TipoContratoDescripcion = aa.TipoContratoId.HasValue ? aa.TipoContrato.Descripcion : string.Empty,
                                 FechaDeRecepcion = aa.FechaDeRecepcion,
                                 ClienteCalculaVencimientoConVisualizacion = aa.Comprobante.Cliente.CalculaVencimientoConVisualizacionDoc
                             }).OrderByDescending(c => c.FechaDeCarga);
                if (cantUltimosCbtes > 0)
                {
                    result = query.Take(cantUltimosCbtes).ToList();
                }
                else
                {
                    result = query.ToList();
                }
                return result;
            }
        }

        public void AsociarFechaDeRecepcion(Dictionary<long, DateTime?> archivosAsociados, long userId)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                using (var ctx = new FacturaElectronicaEntities())
                {
                    foreach (var key in archivosAsociados.Keys)
                    {
                        AsociarFechaDeRecepcion(ctx, key, archivosAsociados[key], userId);
                    }

                    ctx.SaveChanges();
                    ts.Complete();
                }
            }
        }

        public List<RegistroAuditoria> ObtenerAuditoriaComprobante(long archivoAsociadoId)
        {
            List<RegistroAuditoria> registros = new List<RegistroAuditoria>();
            using (var ctx = new FacturaElectronicaEntities())
            {
                foreach (var dbArchivoAsoAuditoria in ctx.ArchivoAsociado_Auditoria.Where(a => a.ArchivoAsociadoId == archivoAsociadoId).OrderByDescending(a => a.Fecha))
                {
                    RegistroAuditoria ra = new RegistroAuditoria();
                    EntityMapper.Map(dbArchivoAsoAuditoria, ra);
                    ra.UsuarioNombre = dbArchivoAsoAuditoria.Usuario.NombreUsuario;
                    registros.Add(ra);
                }

                return registros;
            }
        }

        private void AsociarFechaDeRecepcion(FacturaElectronicaEntities ctx, long archivoAsociadoId, DateTime? fechaDeRecepcion, long userId)
        {
            var dbArchivoAsociado = ctx.ArchivoAsociadoes.Where(a => a.Id == archivoAsociadoId).Single();
            if (dbArchivoAsociado.FechaDeRecepcion != fechaDeRecepcion)
            {
                DateTime now = DateTime.Now;
                // Cargo la fecha de recepcion
                ArchivoAsociado_Auditoria auditoria = new ArchivoAsociado_Auditoria();
                dbArchivoAsociado.ArchivoAsociado_Auditoria.Add(auditoria);
                auditoria.UsuarioId = userId;
                auditoria.CampoModificado = "Fecha de Recepcion";
                auditoria.Fecha = now;
                if (dbArchivoAsociado.FechaDeRecepcion.HasValue)
                    auditoria.ValorAnterior = dbArchivoAsociado.FechaDeRecepcion.Value.ToString("dd/MM/yyyy");

                if (fechaDeRecepcion.HasValue)
                    auditoria.ValorNuevo = fechaDeRecepcion.Value.ToString("dd/MM/yyyy");

                dbArchivoAsociado.FechaDeRecepcion = fechaDeRecepcion;

                if (dbArchivoAsociado.DiasVencimiento.HasValue)
                {
                    // Ademas tengo que calcular la nueva fecha de vencimiento
                    auditoria = new ArchivoAsociado_Auditoria();
                    dbArchivoAsociado.ArchivoAsociado_Auditoria.Add(auditoria);
                    auditoria.UsuarioId = userId;
                    auditoria.CampoModificado = "Fecha de Vencimiento";
                    auditoria.Fecha = now;
                    if (dbArchivoAsociado.FechaVencimiento.HasValue)
                        auditoria.ValorAnterior = dbArchivoAsociado.FechaVencimiento.Value.ToString("dd/MM/yyyy");

                    if (dbArchivoAsociado.FechaDeRecepcion.HasValue)
                    {
                        dbArchivoAsociado.FechaVencimiento = dbArchivoAsociado.FechaDeRecepcion.Value.AddDays(dbArchivoAsociado.DiasVencimiento.Value);
                        auditoria.ValorNuevo = dbArchivoAsociado.FechaVencimiento.Value.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        dbArchivoAsociado.FechaVencimiento = null;
                    }
                }
            }
        }

        public List<ComprobanteArchivoAsociadoDto> ObtenerComprobantes(ComprobanteCriteria criteria)
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                if (criteria.FechaDeRecepcionHasta.HasValue)
                {
                    criteria.FechaDeRecepcionHasta = criteria.FechaDeRecepcionHasta.Value.Date.AddDays(1).AddSeconds(-1);
                }

                DateTime hoy = DateTime.Now.Date;
                List<ComprobanteArchivoAsociadoDto> list = (from aa in ctx.ArchivoAsociadoes
                                                            join c in ctx.Comprobantes on aa.ComprobanteId equals c.Id
                                                            where

                                                            1 == 1
                                                            && (!criteria.SoloDocumentosConNDias || aa.DiasVencimiento.HasValue)
                                                                // Fecha Vencimiento
                                                            && (!criteria.FechaVencDesde.HasValue || !aa.FechaVencimiento.HasValue || criteria.FechaVencDesde.Value <= aa.FechaVencimiento)
                                                            && (!criteria.FechaVencHasta.HasValue || aa.FechaVencimiento <= criteria.FechaVencHasta.Value)
                                                                // Fecha De Carga
                                                            && (!criteria.FechaDeCargaDesde.HasValue || criteria.FechaDeCargaDesde.Value <= aa.FechaDeCarga)
                                                            && (!criteria.FechaDeCargaHasta.HasValue || aa.FechaDeCarga <= criteria.FechaDeCargaHasta.Value)
                                                                // Fecha de Recepcion
                                                            && (!criteria.FechaDeRecepcionDesde.HasValue || criteria.FechaDeRecepcionDesde.Value <= aa.FechaDeRecepcion)
                                                            && (!criteria.FechaDeRecepcionHasta.HasValue || aa.FechaDeRecepcion <= criteria.FechaDeRecepcionHasta.Value)
                                                                // Razon Social
                                                            && (string.IsNullOrEmpty(criteria.RazonSocial) || c.Cliente.RazonSocial.Contains(criteria.RazonSocial))
                                                                // Tipo Comprobante
                                                            && (!criteria.TipoComprobanteId.HasValue || c.TipoComprobanteId == criteria.TipoComprobanteId.Value)
                                                                // rango de vencimiento
                                                            && (!criteria.DiasDeVencimientoDesde.HasValue || criteria.DiasDeVencimientoDesde.Value <= aa.DiasVencimiento)
                                                            && (!criteria.DiasDeVencimientoHasta.HasValue || criteria.DiasDeVencimientoHasta.Value >= aa.DiasVencimiento)
                                                                // Nro Comprobante
                                                            && (!criteria.NroComprobante.HasValue || aa.NroComprobante == criteria.NroComprobante.Value)
                                                                // Cliente Id
                                                            && (!criteria.ClienteId.HasValue || c.ClienteId == criteria.ClienteId.Value)
                                                                // Tipo Contrato
                                                            && (!criteria.TipoContratoId.HasValue || aa.TipoContratoId == criteria.TipoContratoId.Value)
                                                                // Periodo Facturacion
                                                            && (!criteria.MesFacturacion.HasValue || aa.MesFacturacion == criteria.MesFacturacion.Value)
                                                            && (!criteria.AnioFacturacion.HasValue || aa.AnioFacturacion == criteria.AnioFacturacion.Value)
                                                                // Documentos Vencidos
                                                            && (!criteria.DocumentosVencidos || aa.FechaVencimiento < hoy)
                                                                // Documentos No Vencidos
                                                            && (!criteria.DocumentosNoVencidos || !aa.FechaVencimiento.HasValue || hoy <= aa.FechaVencimiento.Value)
                                                                // Monto Desde
                                                            && (!criteria.MontoTotalDesde.HasValue || criteria.MontoTotalDesde.Value <= aa.MontoTotal)
                                                                // Monto Hasta
                                                            && (!criteria.MontoTotalHasta.HasValue || aa.MontoTotal <= criteria.MontoTotalHasta.Value)
                                                                //Estado por Codigo
                                                            && (string.IsNullOrEmpty(criteria.Estado) || aa.EstadoArchivoAsociado.Codigo == criteria.Estado)
                                                                // Estados por Id
                                                            && (!criteria.EstadoId.HasValue || aa.EstadoArchivoAsociado.Id == criteria.EstadoId)
                                                            select new ComprobanteArchivoAsociadoDto()
                                                            {
                                                                ArchivoAsociadoId = aa.Id,
                                                                CAE = c.CAE,
                                                                CAEFechaVencimiento = c.CAEFechaVencimiento,
                                                                ClienteId = c.ClienteId,
                                                                ClienteRazonSocial = c.Cliente.RazonSocial,
                                                                ComprobanteId = c.Id,
                                                                EstadoCodigo = aa.EstadoArchivoAsociado.Codigo,
                                                                EstadoDescripcion = aa.EstadoArchivoAsociado.Descripcion,
                                                                FechaDeCarga = aa.FechaDeCarga,
                                                                FechaVencimiento = aa.FechaVencimiento,
                                                                DiasVencimiento = aa.DiasVencimiento,
                                                                NroComprobante = aa.NroComprobante,
                                                                PathArchivo = aa.PathArchivo,
                                                                TipoComprobanteId = c.TipoComprobanteId,
                                                                TipoComprobanteDescripcion = c.TipoComprobante.Descripcion,
                                                                TipoContratoId = aa.TipoContratoId,
                                                                TipoContratoDescripcion = aa.TipoContratoId.HasValue ? aa.TipoContrato.Descripcion : string.Empty,
                                                                MontoTotal = aa.MontoTotal.HasValue ? aa.MontoTotal.Value : default(decimal?),
                                                                FechaDeRecepcion = aa.FechaDeRecepcion,
                                                                ClienteCalculaVencimientoConVisualizacion = aa.Comprobante.Cliente.CalculaVencimientoConVisualizacionDoc
                                                            }).ToList();

                foreach (var item in list)
                {
                    VisualizacionComprobante visualizacion = ctx.VisualizacionComprobantes.Where(vc => vc.ArchivoAsociadoId == item.ArchivoAsociadoId).ToList().LastOrDefault();
                    if (visualizacion != null)
                    {
                        item.DireccionIp = visualizacion.DireccionIP;
                        item.FechaVisualizacion = visualizacion.Fecha;
                    }
                }
                return list;
            }
        }

        public ComprobanteDto ObtenerUltimoComprobanteCargado(int ptoVta, int cbeTipo)
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                Comprobante cbte = ctx.Comprobantes.Where(c => c.PtoVta == ptoVta && c.TipoComprobante.CodigoAfip == cbeTipo).OrderByDescending(c => c.CbteDesde).FirstOrDefault();
                return ToComprobanteDto(cbte);
            }
        }

        public ComprobanteDto ObtenerComprobante(long comprobanteId)
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                return ToComprobanteDto(ctx.Comprobantes.Where(c => c.Id == comprobanteId).FirstOrDefault());
            }
        }

        public EstadoComprobantesDto ObtenerEstadoComprobantes(long clientId)
        {
            EstadoComprobantesDto dto = new EstadoComprobantesDto();
            ComprobanteCriteria criteria = new ComprobanteCriteria();
            using (var ctx = new FacturaElectronicaEntities())
            {

                criteria.ClienteId = clientId;
                // Total Comprobantes
                //dto.TotalComprobantes = ctx.ArchivoAsociadoes.Where(a => a.Comprobante.ClienteId == clientId &&
                //                                                         a.EstadoArchivoAsociado.Codigo != CodigosEstadoArchivoAsociado.Eliminado).Count();
                // Visualizados
                dto.Visualizados = ctx.ArchivoAsociadoes.Where(a => a.Comprobante.ClienteId == clientId &&
                                                                    a.EstadoArchivoAsociado.Codigo == CodigosEstadoArchivoAsociado.Visualizado).Count();
                // No Visualizados No Vencidos
                DateTime hoy = DateTime.Now.Date;
                dto.NoVisualizados = ctx.ArchivoAsociadoes.Where(a => a.Comprobante.ClienteId == clientId &&
                                                                      a.EstadoArchivoAsociado.Codigo == CodigosEstadoArchivoAsociado.NoVisualizado &&
                                                                      (hoy <= a.FechaVencimiento || a.FechaVencimiento == null)).Count();
                // No Visualizados
                dto.NoVisualizadosVencidos = ctx.ArchivoAsociadoes.Where(a => a.Comprobante.ClienteId == clientId &&
                                                                              a.EstadoArchivoAsociado.Codigo == CodigosEstadoArchivoAsociado.NoVisualizado &&
                                                                              a.FechaVencimiento < hoy).Count();

                dto.TotalComprobantes = dto.Visualizados + dto.NoVisualizados + dto.NoVisualizadosVencidos;
            }

            return dto;
        }

        #endregion [Comprobantes]

        #region [Tipos Comprobante]

        public TipoComprobanteDto ObtenerTipoComprobantePorCodigoAfip(int codigoAfip)
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                TipoComprobante tipoCbte = ctx.TipoComprobantes.Where(t => t.CodigoAfip == codigoAfip).FirstOrDefault();
                return ToTipoComprobanteDto(tipoCbte);
            }
        }

        public List<TipoComprobanteDto> ObtenerTiposComprobantes()
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                return
                    ToTipoComprobanteDtoList(
                        ctx.TipoComprobantes.Where(tc => tc.Codigo != "N/A").OrderBy(tc => tc.Descripcion).ToList());
            }

        }

        #endregion [Tipos Comprobante]

        #region [Estados]

        public EstadoArchivoAsociadoDto ObtenerEstado(string codigo)
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                return ToEstadoArchivoAsociadoDto(ctx.EstadoArchivoAsociadoes.Where(e => e.Codigo == codigo).FirstOrDefault());
            }
        }

        public void CambiarEstado(long archivoAsociadoId, string codigoEstado)
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                EstadoArchivoAsociado nuevoEstado = ctx.EstadoArchivoAsociadoes.Where(e => e.Codigo == codigoEstado).FirstOrDefault();
                if (nuevoEstado != null)
                {
                    ArchivoAsociado aa = ctx.ArchivoAsociadoes.Where(c => c.Id == archivoAsociadoId).FirstOrDefault();
                    if (aa != null)
                    {
                        aa.EstadoArchivoAsociado = nuevoEstado;
                        ctx.SaveChanges();
                    }
                }
            }
        }

        public List<EstadoArchivoAsociadoDto> ObtenerEstados()
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                return ToEstadoArchivoAsociadoDtoList(ctx.EstadoArchivoAsociadoes.ToList());
            }
        }

        #endregion [Estados]

        #region [Tipos Contrato]

        public List<TipoContratoDto> ObtenerTiposContrato()
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                // Obtengo el listado con los tipos de contrato que existen en la base
                var tiposContrato = ctx.TipoContratoes.ToList();

                return ToTipoContratoDtoList(tiposContrato);
            }
        }

        #endregion [Tipo Contrato]

        #region [Visualizaciones]

        public void AgregarVisualizacion(VisualizacionComprobanteDto dto)
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                ArchivoAsociado aa = ctx.ArchivoAsociadoes.Where(c => c.Id == dto.ArchivoAsociadoId).FirstOrDefault();
                if (aa != null)
                {
                    VisualizacionComprobante vc = new VisualizacionComprobante()
                    {
                        ArchivoAsociadoId = aa.Id,
                        Fecha = DateTime.Now,
                        DireccionIP = dto.Ip
                    };
                    if (aa.EstadoArchivoAsociado.Codigo == CodigosEstadoArchivoAsociado.NoVisualizado)
                    {
                        aa.EstadoArchivoAsociado = ctx.EstadoArchivoAsociadoes.Where(e => e.Codigo == CodigosEstadoArchivoAsociado.Visualizado).First();

                        if (aa.Comprobante.Cliente.CalculaVencimientoConVisualizacionDoc && !aa.FechaDeRecepcion.HasValue)
                        {
                            DateTime fechaDeRecepcion = DateTime.Now;
                            AsociarFechaDeRecepcion(ctx, dto.ArchivoAsociadoId, fechaDeRecepcion, dto.UsuarioIdAuditoria);
                        }
                    }

                    aa.VisualizacionComprobantes.Add(vc);

                    //if (!aa.FechaVencimiento.HasValue && aa.DiasVencimiento.HasValue)
                    //{
                    //    aa.FechaVencimiento = DateTime.Now.AddDays(aa.DiasVencimiento.Value);
                    //}

                    ctx.SaveChanges();
                }

            }
        }

        #endregion [Visualizaciones]

        #region [Path Archivo]

        public string ObtenerArchivo(long archivoId)
        {
            return this.ObtenerPathArchivo(archivoId, null);
        }

        public string ObtenerArchivo(long archivoId, long clienteId)
        {
            return this.ObtenerPathArchivo(archivoId, clienteId);
        }

        private string ObtenerPathArchivo(long archivoId, long? clienteId)
        {
            string pathArchivo = string.Empty;
            using (var ctx = new FacturaElectronicaEntities())
            {
                IQueryable<ArchivoAsociado> query = ctx.ArchivoAsociadoes;

                query = query.Where(aa => aa.Id == archivoId);

                if (clienteId.HasValue)
                {
                    query = query.Where(aa => aa.Comprobante.ClienteId == clienteId.Value);
                }

                ArchivoAsociado archivo = query.SingleOrDefault();

                if (archivo != null)
                    pathArchivo = archivo.PathArchivo;
            }
            return pathArchivo;
        }

        #endregion [Path Archivo]

        public List<int> ObtenerAniosFacturacion()
        {
            List<int> aniosFacturacion = new List<int>();
            int start = 2012;
            int fin = DateTime.Now.Year;
            
            while (start <= fin)
            {
                aniosFacturacion.Add(start);
                start++;
            }

            return aniosFacturacion;
        }

        #region [Conversion]

        #region [Comprobante]

        private static void ToComprobante(ComprobanteDto dto, Comprobante cbte)
        {
            cbte.CAE = dto.CAE;
            cbte.CAEFechaVencimiento = dto.CAEFechaVencimiento;
            cbte.FechaDeCarga = DateTime.Now;
            cbte.CbteDesde = dto.CbteDesde;
            cbte.CbteHasta = dto.CbteHasta;
            cbte.CbteFecha = dto.CbteFecha;
            cbte.ClienteId = dto.ClienteId;
            cbte.TipoComprobanteId = dto.TipoComprobanteId;
            cbte.PtoVta = dto.PtoVta;
        }

        private static ComprobanteDto ToComprobanteDto(Comprobante comprobante)
        {
            if (comprobante == null) return null;

            ComprobanteDto dto = new ComprobanteDto();
            dto.Id = comprobante.Id;
            dto.CAE = comprobante.CAE;
            dto.ClienteId = comprobante.ClienteId;
            dto.ClienteNombre = comprobante.Cliente != null ? comprobante.Cliente.RazonSocial : string.Empty;
            dto.CAEFechaVencimiento = comprobante.CAEFechaVencimiento;
            dto.FechaDeCarga = comprobante.FechaDeCarga;
            dto.TipoComprobanteId = comprobante.TipoComprobanteId;
            dto.TipoComprobanteDescripcion = comprobante.TipoComprobante.Descripcion;
            dto.CbteDesde = comprobante.CbteDesde;
            dto.CbteHasta = comprobante.CbteHasta;
            dto.CbteFecha = comprobante.CbteFecha;
            dto.PtoVta = comprobante.PtoVta;
            //#TODO: logica para obtener comprobante de acuerdo al nro.
            // Recordar lo de Factura B que se puede poner un rango.
            ArchivoAsociado archivoAsociado = comprobante.ArchivoAsociadoes.FirstOrDefault();
            if (archivoAsociado != null)
            {
                dto.PathFile = comprobante.ArchivoAsociadoes.First().PathArchivo;
                VisualizacionComprobante visualizacionCbte = archivoAsociado.VisualizacionComprobantes.FirstOrDefault();
                if (visualizacionCbte != null)
                {
                    dto.DireccionIp = visualizacionCbte.DireccionIP;
                    dto.FechaVisualizacion = visualizacionCbte.Fecha;
                }
            }

            return dto;
        }

        private static List<ComprobanteDto> ToComprobanteDtoList(List<Comprobante> comprobanteList)
        {
            List<ComprobanteDto> dtoList = new List<ComprobanteDto>();
            if (comprobanteList.Count > 0)
            {
                foreach (var comprobante in comprobanteList)
                {
                    dtoList.Add(ToComprobanteDto(comprobante));
                }
            }
            return dtoList;
        }

        #endregion [Comprobante]

        #region [TipoComprobante]

        private static TipoComprobanteDto ToTipoComprobanteDto(TipoComprobante tipoComprobante)
        {
            if (tipoComprobante == null) return null;

            TipoComprobanteDto dto = new TipoComprobanteDto();
            dto.Id = tipoComprobante.Id;
            dto.Descripcion = tipoComprobante.Descripcion;
            dto.CodigoAfip = tipoComprobante.CodigoAfip.HasValue ? tipoComprobante.CodigoAfip.Value : (int?)null;
            dto.Codigo = tipoComprobante.Codigo;

            return dto;
        }

        private static List<TipoComprobanteDto> ToTipoComprobanteDtoList(List<TipoComprobante> tiposComprobantesList)
        {
            List<TipoComprobanteDto> dtoList = new List<TipoComprobanteDto>();
            if (tiposComprobantesList.Count > 0)
            {
                foreach (var tipoComprobante in tiposComprobantesList)
                {
                    dtoList.Add(ToTipoComprobanteDto(tipoComprobante));
                }
            }
            return dtoList;
        }

        #endregion [TipoComprobante]

        #region [Estado]

        private static EstadoArchivoAsociadoDto ToEstadoArchivoAsociadoDto(EstadoArchivoAsociado estado)
        {
            if (estado == null) return null;

            EstadoArchivoAsociadoDto dto = new EstadoArchivoAsociadoDto();

            dto.Id = estado.Id;
            dto.Codigo = estado.Codigo;
            dto.Descripcion = estado.Descripcion;

            return dto;
        }

        private static List<EstadoArchivoAsociadoDto> ToEstadoArchivoAsociadoDtoList(List<EstadoArchivoAsociado> estados)
        {
            List<EstadoArchivoAsociadoDto> dtoList = new List<EstadoArchivoAsociadoDto>();
            if (estados.Count > 0)
            {
                foreach (var estado in estados)
                {
                    dtoList.Add(ToEstadoArchivoAsociadoDto(estado));
                }
            }
            return dtoList;
        }


        #endregion [Estado]

        #region [Tipo Contrato]

        private static TipoContratoDto ToTipoContratoDto(TipoContrato tipoContrato)
        {
            if (tipoContrato == null) return null;

            TipoContratoDto dto = new TipoContratoDto();
            dto.Id = tipoContrato.Id;
            dto.Codigo = tipoContrato.Codigo;
            dto.Descripcion = tipoContrato.Descripcion;


            return dto;
        }

        private static List<TipoContratoDto> ToTipoContratoDtoList(List<TipoContrato> tiposContratoList)
        {
            List<TipoContratoDto> dtoList = new List<TipoContratoDto>();
            if (tiposContratoList.Count > 0)
            {
                foreach (var tipoContrato in tiposContratoList)
                {
                    dtoList.Add(ToTipoContratoDto(tipoContrato));
                }
            }
            return dtoList;
        }

        #endregion [Tipo Contrato]

        #endregion [Conversion]
    }
}
