using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacturaElectronica.Afip.Business.Wsfe;
using FacturaElectronica.Afip.Business.Wsaa;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;
using FacturaElectronica.Afip.Business.Helpers;
using FacturaElectronica.Afip.Ws.Wsfe;
using FacturaElectronica.Afip.Ws.Wsfex;
using FacturaElectronica.Common.Services;
using System.Net;
using System.Net.Security;
using DummyResponse = FacturaElectronica.Afip.Ws.Wsfe.DummyResponse;
using ServiceSoapClient = FacturaElectronica.Afip.Ws.Wsfe.ServiceSoapClient;

namespace FacturaElectronica.Afip.Business.Wsfe
{
    public class WsfeClient : IAfipWrapperService
    {
        private string idServicioNegocio;
        private string idServicioNegocioFex;
        private string certSigner;
        private string cuit;
        private StoreName storeName;
        private StoreLocation storeLocation;

        private const string errorWsfe = "***Error INVOCANDO al servicio WSFE : ";
        private const string errorWsfex = "***Error INVOCANDO al servicio WSFEX : ";

        public WsfeClient()
        {
            this.idServicioNegocio = ConfigurationManager.AppSettings["idServicioNegocio"];
            this.idServicioNegocioFex = ConfigurationManager.AppSettings["idServicioNegocioFex"];
            this.certSigner = ConfigurationManager.AppSettings["certSigner"];
            this.cuit = ConfigurationManager.AppSettings["cuit"];

            this.storeName = ConfigHelper.ObtenerStoreName();
            this.storeLocation = ConfigHelper.ObtenerStoreLocation();
        }

        public DummyResponse DummyResponse()
        {
            try
            {
                DummyResponse result;
                using (ServiceSoapClient client = new ServiceSoapClient()) 
                {
                    return result = client.FEDummy();
                }
            }

            catch (Exception excepcionAlInvocarWsaa)
            {
                throw new Exception("***Error INVOCANDO al servicio WSAA : " + excepcionAlInvocarWsaa.Message);
            }
        }

        #region [Maestros]

        public MonedaResponse GetTiposMonedas(FEAuthRequest feAuthRequest)
        {
            try
            {
                MonedaResponse result;
                using (ServiceSoapClient client = new ServiceSoapClient())
                {
                    return result = client.FEParamGetTiposMonedas(feAuthRequest);                    
                }
            }

            catch (Exception excepcionAlInvocarWsfe)
            {
                throw new Exception("***Error INVOCANDO al servicio WFSE : " + excepcionAlInvocarWsfe.Message);
            }
        }

        public FECotizacionResponse GetCotizacion(FEAuthRequest feAuthRequest, string MonId)
        {
            try
            {
                FECotizacionResponse result;
                using (ServiceSoapClient client = new ServiceSoapClient())
                {
                    return result = client.FEParamGetCotizacion(feAuthRequest, MonId);
                }
            }

            catch (Exception excepcionAlInvocarWsfe)
            {
                throw new Exception("***Error INVOCANDO al servicio WFSE : " + excepcionAlInvocarWsfe.Message);
            }
        }

        public CbteTipoResponse GetTiposCbte(FEAuthRequest feAuthRequest)
        {
            try
            {
                CbteTipoResponse result;
                using (ServiceSoapClient client = new ServiceSoapClient())
                {
                    return result = client.FEParamGetTiposCbte(feAuthRequest);
                }
            }

            catch (Exception excepcionAlInvocarWsfe)
            {
                throw new Exception("***Error INVOCANDO al servicio WFSE : " + excepcionAlInvocarWsfe.Message);
            }
        }

        public FETributoResponse GetTiposTributos(FEAuthRequest feAuthRequest)
        {
            try
            {
                FETributoResponse result;
                using (ServiceSoapClient client = new ServiceSoapClient())
                {
                    return result = client.FEParamGetTiposTributos(feAuthRequest);
                }
            }

            catch (Exception excepcionAlInvocarWsfe)
            {
                throw new Exception("***Error INVOCANDO al servicio WFSE : " + excepcionAlInvocarWsfe.Message);
            }
        }

        public IvaTipoResponse GetTiposIva(FEAuthRequest feAuthRequest)
        {
            try
            {
                IvaTipoResponse result;
                using (ServiceSoapClient client = new ServiceSoapClient())
                {
                    return result = client.FEParamGetTiposIva(feAuthRequest);
                }
            }

            catch (Exception excepcionAlInvocarWsfe)
            {
                throw new Exception("***Error INVOCANDO al servicio WFSE : " + excepcionAlInvocarWsfe.Message);
            }
        }

        public OpcionalTipoResponse GetTiposOpcional(FEAuthRequest feAuthRequest)
        {
            try
            {
                OpcionalTipoResponse result;
                using (ServiceSoapClient client = new ServiceSoapClient())
                {
                    return result = client.FEParamGetTiposOpcional(feAuthRequest);
                }
            }

            catch (Exception excepcionAlInvocarWsfe)
            {
                throw new Exception("***Error INVOCANDO al servicio WFSE : " + excepcionAlInvocarWsfe.Message);
            }
        }

        public FERegXReqResponse CompTotXRequest(FEAuthRequest feAuthRequest)
        {
            try
            {
                FERegXReqResponse result;
                using (ServiceSoapClient client = new ServiceSoapClient())
                {
                    return result = client.FECompTotXRequest(feAuthRequest);
                }
            }

            catch (Exception excepcionAlInvocarWsfe)
            {
                throw new Exception("***Error INVOCANDO al servicio WFSE : " + excepcionAlInvocarWsfe.Message);
            }
        }

        public DocTipoResponse GetTiposDoc(FEAuthRequest feAuthRequest)
        {
            try
            {
                DocTipoResponse result;
                using (ServiceSoapClient client = new ServiceSoapClient())
                {
                    return result = client.FEParamGetTiposDoc(feAuthRequest);
                }
            }

            catch (Exception excepcionAlInvocarWsfe)
            {
                throw new Exception("***Error INVOCANDO al servicio WFSE : " + excepcionAlInvocarWsfe.Message);
            }
        }

        public FERecuperaLastCbteResponse CompUltimoAutorizado(FEAuthRequest feAuthRequest, int ptoVta, int cbteTipo)
        {
            try
            {
                FERecuperaLastCbteResponse result;
                using (ServiceSoapClient client = new ServiceSoapClient())
                {
                    return result = client.FECompUltimoAutorizado(feAuthRequest, ptoVta, cbteTipo); 
                }
            }

            catch (Exception excepcionAlInvocarWsfe)
            {
                throw new Exception("***Error INVOCANDO al servicio WFSE : " + excepcionAlInvocarWsfe.Message);
            }
        }

        public FECompConsultaResponse CompConsultar(FEAuthRequest feAuthRequest, FECompConsultaReq feCompConsultaReq)
        {
            try
            {
                FECompConsultaResponse result;
                using (ServiceSoapClient client = new ServiceSoapClient())
                {
                    return result = client.FECompConsultar(feAuthRequest, feCompConsultaReq);
                }
            }

            catch (Exception excepcionAlInvocarWsfe)
            {
                throw new Exception("***Error INVOCANDO al servicio WFSE : " + excepcionAlInvocarWsfe.Message);
            }
        }

        public ConceptoTipoResponse GetTiposConcepto(FEAuthRequest feAuthRequest)
        {
            try
            {
                ConceptoTipoResponse result;
                using (ServiceSoapClient client = new ServiceSoapClient())
                {
                    return result = client.FEParamGetTiposConcepto(feAuthRequest);
                }
            }

            catch (Exception excepcionAlInvocarWsfe)
            {
                throw new Exception("***Error INVOCANDO al servicio WFSE : " + excepcionAlInvocarWsfe.Message);
            }
        }

        #endregion [Maestros]

        #region [Wfse]

        public FECAEResponse AutorizarComprobantes(FEAuthRequest feAuthRequest, FECAERequest feCAERequest)
        {
            try
            {
                using (ServiceSoapClient client = new ServiceSoapClient())
                {
                    return client.FECAESolicitar(feAuthRequest,feCAERequest);
                }
            }

            catch (Exception ex)
            {
                throw new Exception(errorWsfe + ex.Message);
            }
        
        }

        #region [Ticket Autorizacion]

        public FEAuthRequest ObtenerTicket()
        {
            LoginTicket loginTicket = new LoginTicket();
            loginTicket.ObtenerLoginTicketResponse(this.idServicioNegocio, this.certSigner, false, this.storeName, this.storeLocation);

            FEAuthRequest feAuthRequest = new FEAuthRequest();
            feAuthRequest.Cuit = Convert.ToInt64(this.cuit);
            feAuthRequest.Sign = loginTicket.Sign;
            feAuthRequest.Token = loginTicket.Token;

            return feAuthRequest;
        }

        #endregion [Ticket Autorizacion]

        #endregion [Wfse]

        #region [Wsfex]

        public FEXResponseAuthorize AutorizarComprobanteExportacion(ClsFEXAuthRequest fexAuthRequest, ClsFEXRequest fexRequest)
        {
            try
            {
                using (Ws.Wsfex.ServiceSoapClient client = new Ws.Wsfex.ServiceSoapClient())
                {
                    return client.FEXAuthorize(fexAuthRequest, fexRequest);
                }
            }

            catch (Exception ex)
            {
                throw new Exception(errorWsfe + ex.Message);
            }

        }

        public FEXResponse_CheckPermiso CheckPermiso(ClsFEXAuthRequest fexAuthRequest, string idPermiso, int destMerc)
        {
            try
            {
                using (Ws.Wsfex.ServiceSoapClient client =
                        new Ws.Wsfex.ServiceSoapClient())
                {
                    return client.FEXCheck_Permiso(fexAuthRequest, idPermiso, destMerc);
                }
            }
            catch (Exception excepcionAlInvocarWsfe)
            {
                throw new Exception(errorWsfex + excepcionAlInvocarWsfe.Message);
            }
        }

        public FEXGetCMPResponse GetComprobante(ClsFEXAuthRequest fexAuthRequest, ClsFEXGetCMP fexGetCmp)
        {
            try
            {
                using (Ws.Wsfex.ServiceSoapClient client =
                        new Ws.Wsfex.ServiceSoapClient())
                {
                    return client.FEXGetCMP(fexAuthRequest, fexGetCmp);
                }
            }
            catch (Exception excepcionAlInvocarWsfe)
            {
                throw new Exception(errorWsfex + excepcionAlInvocarWsfe.Message);
            }
        }

        public FEXResponseLast_CMP GetUltimoComprobanteAutorizado(ClsFEX_LastCMP fexLastCmp)
        {
            try
            {
                using (Ws.Wsfex.ServiceSoapClient client =
                        new Ws.Wsfex.ServiceSoapClient())
                {
                    return client.FEXGetLast_CMP(fexLastCmp);
                }
            }
            catch (Exception excepcionAlInvocarWsfe)
            {
                throw new Exception(errorWsfex + excepcionAlInvocarWsfe.Message);
            }
        }

        public FEXResponse_LastID GetLastId(ClsFEXAuthRequest fexAuthRequest)
        {
            try
            {
                using (Ws.Wsfex.ServiceSoapClient client =
                        new Ws.Wsfex.ServiceSoapClient())
                {
                    return client.FEXGetLast_ID(fexAuthRequest);
                }
            }
            catch (Exception excepcionAlInvocarWsfe)
            {
                throw new Exception(errorWsfex + excepcionAlInvocarWsfe.Message);
            }
        }

        public FEXResponse_Cbte_Tipo GetTiposComprobantes(ClsFEXAuthRequest fexAuthRequest)
        {
            try
            {
                using (Ws.Wsfex.ServiceSoapClient client =
                        new Ws.Wsfex.ServiceSoapClient())
                {
                    return client.FEXGetPARAM_Cbte_Tipo(fexAuthRequest);
                }
            }
            catch (Exception excepcionAlInvocarWsfe)
            {
                throw new Exception(errorWsfex + excepcionAlInvocarWsfe.Message);
            }
        }        

        public FEXResponse_Ctz GetFexCotizacion(ClsFEXAuthRequest fexAuthRequest, string monId)
        {
            try
            {
                using (Ws.Wsfex.ServiceSoapClient client =
                        new Ws.Wsfex.ServiceSoapClient())
                {
                    return client.FEXGetPARAM_Ctz(fexAuthRequest, monId);
                }
            }
            catch (Exception excepcionAlInvocarWsfe)
            {
                throw new Exception(errorWsfex + excepcionAlInvocarWsfe.Message);
            }
        }

        public FEXResponse_DST_cuit GetCuits(ClsFEXAuthRequest fexAuthRequest)
        {
            try
            {
                using (Ws.Wsfex.ServiceSoapClient client =
                        new Ws.Wsfex.ServiceSoapClient())
                {
                    return client.FEXGetPARAM_DST_CUIT(fexAuthRequest);
                }
            }
            catch (Exception excepcionAlInvocarWsfe)
            {
                throw new Exception(errorWsfex + excepcionAlInvocarWsfe.Message);
            }
        }

        public FEXResponse_DST_pais GetPaises(ClsFEXAuthRequest fexAuthRequest)
        {
            try
            {
                using (Ws.Wsfex.ServiceSoapClient client =
                        new Ws.Wsfex.ServiceSoapClient())
                {
                    return client.FEXGetPARAM_DST_pais(fexAuthRequest);
                }
            }
            catch (Exception excepcionAlInvocarWsfe)
            {
                throw new Exception(errorWsfex + excepcionAlInvocarWsfe.Message);
            }
        }

        public FEXResponse_Idi GetIdiomas(ClsFEXAuthRequest fexAuthRequest)
        {
            try
            {
                using (Ws.Wsfex.ServiceSoapClient client =
                        new Ws.Wsfex.ServiceSoapClient())
                {
                    return client.FEXGetPARAM_Idiomas(fexAuthRequest);
                }
            }
            catch (Exception excepcionAlInvocarWsfe)
            {
                throw new Exception(errorWsfex + excepcionAlInvocarWsfe.Message);
            }
        }

        public FEXResponse_Inc GetIncoterms(ClsFEXAuthRequest fexAuthRequest)
        {
            try
            {
                using (Ws.Wsfex.ServiceSoapClient client =
                        new Ws.Wsfex.ServiceSoapClient())
                {
                    return client.FEXGetPARAM_Incoterms(fexAuthRequest);
                }
            }
            catch (Exception excepcionAlInvocarWsfe)
            {
                throw new Exception(errorWsfex + excepcionAlInvocarWsfe.Message);
            }
        }

        public FEXResponse_Mon GetMonedas(ClsFEXAuthRequest fexAuthRequest)
        {
            try
            {
                using (Ws.Wsfex.ServiceSoapClient client =
                        new Ws.Wsfex.ServiceSoapClient())
                {
                    return client.FEXGetPARAM_MON(fexAuthRequest);
                }
            }
            catch (Exception excepcionAlInvocarWsfe)
            {
                throw new Exception(errorWsfex + excepcionAlInvocarWsfe.Message);
            }
        }

        public FEXResponse_PtoVenta GetPuntosDeVenta(ClsFEXAuthRequest fexAuthRequest)
        {
            try
            {
                using (Ws.Wsfex.ServiceSoapClient client =
                        new Ws.Wsfex.ServiceSoapClient())
                {
                    return client.FEXGetPARAM_PtoVenta(fexAuthRequest);
                }
            }
            catch (Exception excepcionAlInvocarWsfe)
            {
                throw new Exception(errorWsfex + excepcionAlInvocarWsfe.Message);
            }
        }

        public FEXResponse_Tex GetTiposDeExportacion(ClsFEXAuthRequest fexAuthRequest)
        {
            try
            {
                using (Ws.Wsfex.ServiceSoapClient client =
                        new Ws.Wsfex.ServiceSoapClient())
                {
                    return client.FEXGetPARAM_Tipo_Expo(fexAuthRequest);
                }
            }
            catch (Exception excepcionAlInvocarWsfe)
            {
                throw new Exception(errorWsfex + excepcionAlInvocarWsfe.Message);
            }
        }

        public FEXResponse_Umed GetUnidadesDeMedida(ClsFEXAuthRequest fexAuthRequest)
        {
            try
            {
                using (Ws.Wsfex.ServiceSoapClient client =
                        new Ws.Wsfex.ServiceSoapClient())
                {
                    return client.FEXGetPARAM_UMed(fexAuthRequest);
                }
            }
            catch (Exception excepcionAlInvocarWsfe)
            {
                throw new Exception(errorWsfex + excepcionAlInvocarWsfe.Message);
            }
        }

        #region [Ticket Autorizacion]

        public ClsFEXAuthRequest ObtenerTicketFex()
        {
            LoginTicket loginTicket = new LoginTicket();
            loginTicket.ObtenerLoginTicketResponse(this.idServicioNegocioFex, this.certSigner, false, this.storeName, this.storeLocation);

            ClsFEXAuthRequest feAuthRequest = new ClsFEXAuthRequest();
            feAuthRequest.Cuit = Convert.ToInt64(this.cuit);
            feAuthRequest.Sign = loginTicket.Sign;
            feAuthRequest.Token = loginTicket.Token;

            return feAuthRequest;
        }

        #endregion [Ticket Autorizacion]

        #endregion [Wsfex]


    }
}
