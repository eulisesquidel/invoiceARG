using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using FacturaElectronica.Afip.Ws.Wsfe;
using FacturaElectronica.Afip.Ws.Wsfex;

namespace FacturaElectronica.Common.Services
{
    [ServiceContract]
    public interface IAfipWrapperService
    {
        [OperationContract]
        MonedaResponse GetTiposMonedas(FEAuthRequest feAuthRequest);

        [OperationContract]
        FECotizacionResponse GetCotizacion(FEAuthRequest feAuthRequest, string MonId);

        [OperationContract]
        CbteTipoResponse GetTiposCbte(FEAuthRequest feAuthRequest);

        [OperationContract]
        FETributoResponse GetTiposTributos(FEAuthRequest feAuthRequest);

        [OperationContract]
        IvaTipoResponse GetTiposIva(FEAuthRequest feAuthRequest);

        [OperationContract]
        OpcionalTipoResponse GetTiposOpcional(FEAuthRequest feAuthRequest);

        [OperationContract]
        FERegXReqResponse CompTotXRequest(FEAuthRequest feAuthRequest);

        [OperationContract]
        DocTipoResponse GetTiposDoc(FEAuthRequest feAuthRequest);

        [OperationContract]
        FERecuperaLastCbteResponse CompUltimoAutorizado(FEAuthRequest feAuthRequest, int ptoVta, int cbteTipo);

        [OperationContract]
        FECompConsultaResponse CompConsultar(FEAuthRequest feAuthRequest, FECompConsultaReq feCompConsultaReq);

        [OperationContract]
        ConceptoTipoResponse GetTiposConcepto(FEAuthRequest feAuthRequest);

        [OperationContract]
        FEAuthRequest ObtenerTicket();

        #region Wsfex
        
        [OperationContract]
        FEXResponseAuthorize AutorizarComprobanteExportacion(ClsFEXAuthRequest fexAuthRequest, ClsFEXRequest fexRequest);

        [OperationContract]
        FEXResponse_CheckPermiso CheckPermiso(ClsFEXAuthRequest fexAuthRequest, string idPermiso, int destMerc);

        [OperationContract]
        FEXGetCMPResponse GetComprobante(ClsFEXAuthRequest fexAuthRequest, ClsFEXGetCMP fexGetCmp);

        [OperationContract]
        FEXResponseLast_CMP GetUltimoComprobanteAutorizado(ClsFEX_LastCMP fexLastCmp);

        [OperationContract]
        FEXResponse_LastID GetLastId(ClsFEXAuthRequest fexAuthRequest);

        [OperationContract]
        FEXResponse_Cbte_Tipo GetTiposComprobantes(ClsFEXAuthRequest auth);

        [OperationContract]
        FEXResponse_Ctz GetFexCotizacion(ClsFEXAuthRequest fexAuthRequest, string monId);

        [OperationContract]
        FEXResponse_DST_cuit GetCuits(ClsFEXAuthRequest fexAuthRequest);

        [OperationContract]
        FEXResponse_DST_pais GetPaises(ClsFEXAuthRequest fexAuthRequest);

        [OperationContract]
        FEXResponse_Idi GetIdiomas(ClsFEXAuthRequest fexAuthRequest);

        [OperationContract]
        FEXResponse_Inc GetIncoterms(ClsFEXAuthRequest fexAuthRequest);

        [OperationContract]
        FEXResponse_Mon GetMonedas(ClsFEXAuthRequest fexAuthRequest);

        [OperationContract]
        FEXResponse_PtoVenta GetPuntosDeVenta(ClsFEXAuthRequest fexAuthRequest);

        [OperationContract]
        FEXResponse_Tex GetTiposDeExportacion(ClsFEXAuthRequest fexAuthRequest);

        [OperationContract]
        FEXResponse_Umed GetUnidadesDeMedida(ClsFEXAuthRequest fexAuthRequest);

        [OperationContract]
        ClsFEXAuthRequest ObtenerTicketFex();

        #endregion

    }
}

