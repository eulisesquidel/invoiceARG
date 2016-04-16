using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacturaElectronica.Common.Contracts;
using FacturaElectronica.Afip.Ws.Wsfe;
using System.ServiceModel;
using FacturaElectronica.Common.Contracts.Search;

namespace FacturaElectronica.Common.Services
{
    [ServiceContract]
    public interface ICorridaService
    {
        [OperationContract]
        CorridaAutorizacionDto CrearNuevaCorrida(string nombreDeArchivo);

        [OperationContract]
        List<CorridaAutorizacionDto> ObtenerCorridas(CorridaSearch search);

        [OperationContract]
        List<LogCorridaDto> ConsultarLog(LogSearch search);

        CorridaAutorizacionDto ProcesarCorrida(CorridaAutorizacionDto corridaDto, FECAEResponse feCAEResponse);

        void Log(long corridaId, string mensaje, string detalle);
    }
}
