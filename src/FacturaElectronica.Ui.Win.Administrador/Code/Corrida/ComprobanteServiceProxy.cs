using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacturaElectronica.Common.Services;
using FacturaElectronica.Common.Contracts;

namespace FacturaElectronica.Ui.Win.Administrador.Code.Corrida
{
    public class ComprobanteServiceProxy : IComprobanteService
    {
        public ComprobanteDto ObtenerComprobante(long comprobanteId)
        {
            throw new NotImplementedException();
        }

        public List<ComprobanteArchivoAsociadoDto> ObtenerComprobantesPorCliente(ComprobanteCriteria criteria, int cantUltimosCbtes)
        {
            throw new NotImplementedException();
        }

        public List<ComprobanteArchivoAsociadoDto> ObtenerComprobantes(ComprobanteCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public ComprobanteDto ObtenerUltimoComprobanteCargado(int ptoVta, int cbeTipo)
        {
            throw new NotImplementedException();
        }

        public TipoComprobanteDto ObtenerTipoComprobantePorCodigoAfip(int codigoAfip)
        {
            throw new NotImplementedException();
        }

        public List<TipoComprobanteDto> ObtenerTiposComprobantes()
        {
            FacturaElectronica.Ui.Win.Administrador.ServiceReferenceComprobanteService.ComprobanteServiceClient client = new FacturaElectronica.Ui.Win.Administrador.ServiceReferenceComprobanteService.ComprobanteServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.ObtenerTiposComprobantes();
                client.Close();
                return t;
            }
            catch
            {
                if (client.State != System.ServiceModel.CommunicationState.Closed)
                {
                    client.Abort();
                }

                throw;
            }            
        }

        public void AsociarFechaDeRecepcion(Dictionary<long, DateTime?> archivosAsociados, long userId)
        {
            throw new NotImplementedException();
        }

        public List<TipoContratoDto> ObtenerTiposContrato()
        {
            FacturaElectronica.Ui.Win.Administrador.ServiceReferenceComprobanteService.ComprobanteServiceClient client = new FacturaElectronica.Ui.Win.Administrador.ServiceReferenceComprobanteService.ComprobanteServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.ObtenerTiposContrato();
                client.Close();
                return t;
            }
            catch
            {
                if (client.State != System.ServiceModel.CommunicationState.Closed)
                {
                    client.Abort();
                }

                throw;
            }            
        }

        public List<int> ObtenerAniosFacturacion()
        {
            throw new NotImplementedException();
        }

        public void AgregarVisualizacion(VisualizacionComprobanteDto dto)
        {
            throw new NotImplementedException();
        }

        public void CambiarEstado(long archivoAsociadoId, string codigoEstado)
        {
            throw new NotImplementedException();
        }

        public EstadoArchivoAsociadoDto ObtenerEstado(string codigo)
        {
            throw new NotImplementedException();
        }

        public List<EstadoArchivoAsociadoDto> ObtenerEstados()
        {
            throw new NotImplementedException();
        }

        public string ObtenerArchivo(long archivoId)
        {
            throw new NotImplementedException();
        }

        public string ObtenerArchivo(long archivoId, long clienteId)
        {
            throw new NotImplementedException();
        }

        public EstadoComprobantesDto ObtenerEstadoComprobantes(long clientId)
        {
            throw new NotImplementedException();
        }

        public ComprobanteDto ObtenerComprobanteDeArchivoAsociado(long archivoAsociadoId)
        {
            throw new NotImplementedException();
        }

        public List<RegistroAuditoria> ObtenerAuditoriaComprobante(long archivoAsociadoId)
        {
            throw new NotImplementedException();
        }
    }
}
