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
    public interface IProcesoCorridaService
    {
        [OperationContract]
        CorridaAutorizacionDto CrearNuevaCorrida(string nombreDeArchivo);

        [OperationContract(IsOneWay=true)]
        void EjecutarCorrida(long corridaId);

        [OperationContract]
        List<CorridaAutorizacionDto> ObtenerCorridas(CorridaSearch search);

        [OperationContract]
        List<LogCorridaDto> ConsultarLog(LogSearch search);

    }
}
