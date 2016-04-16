using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacturaElectronica.Common.Services;
using FacturaElectronica.Common.Contracts;
using System.ServiceModel;
using FacturaElectronica.Business.Services;
using FacturaElectronica.Common.Contracts.Search;
using FacturaElectronica.Afip.Business;
using System.Configuration;
using System.IO;

namespace FacturaElectronica.Facade
{    
    public class ProcesoCorridaService : IProcesoCorridaService
    {        
        public CorridaAutorizacionDto CrearNuevaCorrida(string nombreDeArchivo)
        {
            CorridaService corridaSvc = new CorridaService();
            return corridaSvc.CrearNuevaCorrida(nombreDeArchivo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="corridaId"></param>
        /// <remarks>El metodo se ejecuta asincronicamente</remarks>
        public void EjecutarCorrida(long corridaId)
        {
            CorridaService corridaSvc = new CorridaService();

            var corridas = corridaSvc.ObtenerCorridas(new CorridaSearch() { CorridaId = corridaId });
            if (corridas.Count == 1)
            {
                CorridaAutorizacionDto corridaAutorizacionDto = corridas.Single();

                // Asigno el verdadero path                
                // El path se forma con la corrida y la configuracion
                string basePath = ConfigurationManager.AppSettings["PathDestinoArchivosFactura"];
                basePath = Path.Combine(basePath, "ArchivosXml");
                basePath = Path.Combine(basePath, corridaId.ToString());
                basePath = Path.Combine(basePath, corridaAutorizacionDto.PathArchivo);
                corridaAutorizacionDto.PathArchivo = basePath;

                ProcesoAutorizador autorizador = new ProcesoAutorizador(true);
                autorizador.AutorizarComprobantes(corridaAutorizacionDto);
            }                        
        }

        public List<CorridaAutorizacionDto> ObtenerCorridas(CorridaSearch search)
        {
            CorridaService corridaSvc = new CorridaService();
            return corridaSvc.ObtenerCorridas(search);
        }

        public List<LogCorridaDto> ConsultarLog(LogSearch search)
        {
            CorridaService corridaSvc = new CorridaService();
            return corridaSvc.ConsultarLog(search);
        }
    }
}
