using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacturaElectronica.Common.Contracts;
using System.ServiceModel;

namespace FacturaElectronica.Common.Services
{
    [ServiceContract]
    public interface IComprobanteService
    {
        [OperationContract]
        ComprobanteDto ObtenerComprobante(long comprobanteId);

        ComprobanteDto ObtenerComprobanteDeArchivoAsociado(long archivoAsociadoId);

        [OperationContract]
        List<ComprobanteArchivoAsociadoDto> ObtenerComprobantesPorCliente(ComprobanteCriteria criteria, int cantUltimosCbtes);

        [OperationContract]
        List<ComprobanteArchivoAsociadoDto> ObtenerComprobantes(ComprobanteCriteria criteria);

        [OperationContract]
        ComprobanteDto ObtenerUltimoComprobanteCargado(int ptoVta, int cbeTipo);

        [OperationContract]
        TipoComprobanteDto ObtenerTipoComprobantePorCodigoAfip(int codigoAfip);

        [OperationContract]
        List<TipoComprobanteDto> ObtenerTiposComprobantes();

        [OperationContract]
        List<TipoContratoDto> ObtenerTiposContrato();

        [OperationContract]
        List<int> ObtenerAniosFacturacion();

        [OperationContract]
        void AgregarVisualizacion(VisualizacionComprobanteDto dto);

        [OperationContract]
        void CambiarEstado(long archivoAsociadoId, string codigoEstado);

        [OperationContract]
        EstadoArchivoAsociadoDto ObtenerEstado(string codigo);

        [OperationContract]
        List<EstadoArchivoAsociadoDto> ObtenerEstados();

        [OperationContract(Name="ObtenerArchivoPorId")]
        string ObtenerArchivo(long archivoId);

        [OperationContract]
        string ObtenerArchivo(long archivoId, long clienteId);

        [OperationContract]
        EstadoComprobantesDto ObtenerEstadoComprobantes(long clientId);

        [OperationContract]
        void AsociarFechaDeRecepcion(Dictionary<long, DateTime?> archivosAsociados, long userId);

        List<RegistroAuditoria> ObtenerAuditoriaComprobante(long archivoAsociadoId);
    }
}
