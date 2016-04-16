//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using FacturaElectronica.Common.Services;
//using FacturaElectronica.Afip.Ws.Wsfe;
//using FacturaElectronica.Afip.Business.Wsfe;

//namespace FacturaElectronica.Facade
//{
//    public class AfipWrapperService : IAfipWrapperService
//    {
//        public MonedaResponse GetTiposMonedas(FEAuthRequest feAuthRequest)
//        {
//            WsfeClient client = new WsfeClient();
//            return client.GetTiposMonedas(feAuthRequest);
//        }

//        public FECotizacionResponse GetCotizacion(FEAuthRequest feAuthRequest, string MonId)
//        {
//            throw new NotImplementedException();
//        }

//        public CbteTipoResponse GetTiposCbte(FEAuthRequest feAuthRequest)
//        {
//            throw new NotImplementedException();
//        }

//        public FETributoResponse GetTiposTributos(FEAuthRequest feAuthRequest)
//        {
//            throw new NotImplementedException();
//        }

//        public IvaTipoResponse GetTiposIva(FEAuthRequest feAuthRequest)
//        {
//            throw new NotImplementedException();
//        }

//        public OpcionalTipoResponse GetTiposOpcional(FEAuthRequest feAuthRequest)
//        {
//            throw new NotImplementedException();
//        }

//        public FERegXReqResponse CompTotXRequest(FEAuthRequest feAuthRequest)
//        {
//            throw new NotImplementedException();
//        }

//        public DocTipoResponse GetTiposDoc(FEAuthRequest feAuthRequest)
//        {
//            throw new NotImplementedException();
//        }

//        public FERecuperaLastCbteResponse CompUltimoAutorizado(FEAuthRequest feAuthRequest, int ptoVta, int cbteTipo)
//        {
//            throw new NotImplementedException();
//        }

//        public FECompConsultaResponse CompConsultar(FEAuthRequest feAuthRequest, FECompConsultaReq feCompConsultaReq)
//        {
//            throw new NotImplementedException();
//        }

//        public ConceptoTipoResponse GetTiposConcepto(FEAuthRequest feAuthRequest)
//        {
//            throw new NotImplementedException();
//        }

//        public FEAuthRequest ObtenerTicket()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
