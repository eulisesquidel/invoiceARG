using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using FacturaElectronica.Common.Contracts;
using FacturaElectronica.Common.Contracts.Search;

namespace FacturaElectronica.Common.Services
{
    [ServiceContract]
    public interface ISubidaArchivoService
    {
        [OperationContract]
        CorridaSubidaArchivoDto CrearNuevaCorrida();

        [OperationContract(IsOneWay = true)]
        void EjecutarCorrida(EjecutarCorridaSubidaArchivo corrida);

        [OperationContract]
        List<CorridaSubidaArchivoDto> ObtenerCorridas(CorridaSubidaArchivoSearch search);        
    }
}
