using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacturaElectronica.Afip.Ws.Wsfe;
using FacturaElectronica.Afip.Ws.Wsfex;
using FacturaElectronica.Common.Services;
using FacturaElectronica.Ui.Win.Administrador.ServiceReferenceAfipWrapperService;

namespace FacturaElectronica.Ui.Win.Administrador.Code.Corrida
{
    public class AfipWrapperWcfProxy : FacturaElectronica.Common.Services.IAfipWrapperService
    {
        public MonedaResponse GetTiposMonedas(FEAuthRequest feAuthRequest)
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.GetTiposMonedas(feAuthRequest);
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


        public FECotizacionResponse GetCotizacion(FEAuthRequest feAuthRequest, string MonId)
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.GetCotizacion(feAuthRequest, MonId);
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


        public CbteTipoResponse GetTiposCbte(FEAuthRequest feAuthRequest)
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.GetTiposCbte(feAuthRequest);
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


        public FETributoResponse GetTiposTributos(FEAuthRequest feAuthRequest)
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.GetTiposTributos(feAuthRequest);
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


        public IvaTipoResponse GetTiposIva(FEAuthRequest feAuthRequest)
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.GetTiposIva(feAuthRequest);
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


        public OpcionalTipoResponse GetTiposOpcional(FEAuthRequest feAuthRequest)
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.GetTiposOpcional(feAuthRequest);
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


        public FERegXReqResponse CompTotXRequest(FEAuthRequest feAuthRequest)
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.CompTotXRequest(feAuthRequest);
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


        public DocTipoResponse GetTiposDoc(FEAuthRequest feAuthRequest)
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.GetTiposDoc(feAuthRequest);
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


        public FERecuperaLastCbteResponse CompUltimoAutorizado(FEAuthRequest feAuthRequest, int ptoVta, int cbteTipo)
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.CompUltimoAutorizado(feAuthRequest, ptoVta, cbteTipo);
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


        public FECompConsultaResponse CompConsultar(FEAuthRequest feAuthRequest, FECompConsultaReq feCompConsultaReq)
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.CompConsultar(feAuthRequest, feCompConsultaReq);
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


        public ConceptoTipoResponse GetTiposConcepto(FEAuthRequest feAuthRequest)
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.GetTiposConcepto(feAuthRequest);
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


        public FEAuthRequest ObtenerTicket()
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.ObtenerTicket();
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

        #region [Wsfex]

        public ClsFEXAuthRequest ObtenerTicketFex()
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.ObtenerTicketFex();
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
            return null;
        }

        public FEXResponseAuthorize AutorizarComprobanteExportacion(ClsFEXAuthRequest fexAuthRequest, ClsFEXRequest fexRequest)
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.AutorizarComprobanteExportacion(fexAuthRequest, fexRequest);
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

        public FEXResponse_CheckPermiso CheckPermiso(ClsFEXAuthRequest fexAuthRequest, string idPermiso, int destMerc)
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.CheckPermiso(fexAuthRequest, idPermiso, destMerc);
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

        public FEXGetCMPResponse GetComprobante(ClsFEXAuthRequest fexAuthRequest, ClsFEXGetCMP fexGetCmp)
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.GetComprobante(fexAuthRequest, fexGetCmp);
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

        public FEXResponseLast_CMP GetUltimoComprobanteAutorizado(ClsFEX_LastCMP fexLastCmp)
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.GetUltimoComprobanteAutorizado(fexLastCmp);
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

        public FEXResponse_LastID GetLastId(ClsFEXAuthRequest fexAuthRequest)
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.GetLastId(fexAuthRequest);
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

        public FEXResponse_Cbte_Tipo GetTiposComprobantes(ClsFEXAuthRequest fexAuthRequest)
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.GetTiposComprobantes(fexAuthRequest);
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

        public FEXResponse_Ctz GetFexCotizacion(ClsFEXAuthRequest fexAuthRequest, string monId)
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.GetFexCotizacion(fexAuthRequest, monId);
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

        public FEXResponse_DST_cuit GetCuits(ClsFEXAuthRequest fexAuthRequest)
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.GetCuits(fexAuthRequest);
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

        public FEXResponse_DST_pais GetPaises(ClsFEXAuthRequest fexAuthRequest)
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.GetPaises(fexAuthRequest);
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

        public FEXResponse_Idi GetIdiomas(ClsFEXAuthRequest fexAuthRequest)
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.GetIdiomas(fexAuthRequest);
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

        public FEXResponse_Inc GetIncoterms(ClsFEXAuthRequest fexAuthRequest)
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.GetIncoterms(fexAuthRequest);
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

        public FEXResponse_Mon GetMonedas(ClsFEXAuthRequest fexAuthRequest)
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.GetMonedas(fexAuthRequest);
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

        public FEXResponse_PtoVenta GetPuntosDeVenta(ClsFEXAuthRequest fexAuthRequest)
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.GetPuntosDeVenta(fexAuthRequest);
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

        public FEXResponse_Tex GetTiposDeExportacion(ClsFEXAuthRequest fexAuthRequest)
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.GetTiposDeExportacion(fexAuthRequest);
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

        public FEXResponse_Umed GetUnidadesDeMedida(ClsFEXAuthRequest fexAuthRequest)
        {
            AfipWrapperServiceClient client = new AfipWrapperServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                var t = client.GetUnidadesDeMedida(fexAuthRequest);
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

        #endregion [Wsfex]
    }
}
