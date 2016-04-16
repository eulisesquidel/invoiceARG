using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacturaElectronica.Afip.Business.Wsfe;
using System.IO;
using System.Xml;
using System.Globalization;
using FacturaElectronica.Afip.Ws.Wsfe;
using FacturaElectronica.Afip.Ws.Wsfex;
using FacturaElectronica.Common.Services;
using FacturaElectronica.Ui.Win.Administrador.Code;
using FacturaElectronica.Business.Services;
using FacturaElectronica.Common.Contracts;

namespace FacturaElectronica.Ui.Win.Administrador
{
    public partial class FormConsultaWebServicesAFIP : Form
    {
        #region [Constantes]

        private const string GetTiposMonedasNombre = "FEParamGetTiposMonedas";
        private const string GetTiposCbtesNombre = "FEParamGetTiposCbte";
        private const string GetTiposTributosNombre = "FEParamGetTiposTributos";
        private const string GetTiposIvaNombre = "FEParamGetTiposIva";
        private const string GetTiposOpcionalNombre = "FEParamGetTiposOpcional";
        private const string CompTotXRequestNombre = "FECompTotXRequest";
        private const string GetTiposDocNombre = "FEParamGetTiposDoc";
        private const string CompUltimoAutorizadoNombre = "FECompUltimoAutorizado";
        private const string GetTiposConceptoNombre = "FEParamGetTiposConcepto";
        private const string GetCotizacionNombre = "FEParamGetCotizacion";
        private const string FEXCheck_Permiso = "FEXCheck_Permiso";
        private const string FEXGetCMP = "FEXGetCMP";
        private const string FEXGetLast_CMP = "FEXGetLast_CMP";
        private const string FEXGetLast_ID = "FEXGetLast_ID";
        private const string FEXGetPARAM_Cbte_Tipo = "FEXGetPARAM_Cbte_Tipo";
        private const string FEXGetPARAM_Ctz = "FEXGetPARAM_Ctz";
        private const string FEXGetPARAM_DST_CUIT = "FEXGetPARAM_DST_CUIT";
        private const string FEXGetPARAM_DST_pais = "FEXGetPARAM_DST_pais";
        private const string FEXGetPARAM_Idiomas = "FEXGetPARAM_Idiomas";
        private const string FEXGetPARAM_Incoterms = "FEXGetPARAM_Incoterms";
        private const string FEXGetPARAM_MON = "FEXGetPARAM_MON";
        private const string FEXGetPARAM_PtoVenta = "FEXGetPARAM_PtoVenta";
        private const string FEXGetPARAM_Tipo_Expo = "FEXGetPARAM_Tipo_Expo";
        private const string FEXGetPARAM_UMed = "FEXGetPARAM_UMed";


        #endregion [Constantes]

        #region [Atributos]

        private FacturaElectronica.Afip.Ws.Wsfe.FEAuthRequest ticket;
        private FacturaElectronica.Afip.Ws.Wsfex.ClsFEXAuthRequest ticketFex;
        private IAfipWrapperService client;
        private IComprobanteService ComprobanteService = ServiceFactory.GetComprobanteService();
        private Point panelInitialLocation = new Point(17, 95);
        private const int minPanelHeight = 20;

        #endregion [Atributos]

        public FormConsultaWebServicesAFIP()
        {
            InitializeComponent();
            try
            {
                client = ServiceFactory.GetAfipWrapperService();

                this.ticket = client.ObtenerTicket();

                // TODO: habilitar para factura de exportación
                //this.ticketFex = client.ObtenerTicketFex();
                this.CargarMetodos();
                this.AcomodarControles(false,minPanelHeight);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void InicializarControles()
        {
            this.lblResultados.Text = "Resultados:";
            this.lblResultados.Visible = true;
            this.panelMoneda.Visible = 
            this.panelUltimoCbte.Visible =
            this.panelGetComprobanteFex.Visible = false;
            this.panelMoneda.Location =
            this.panelUltimoCbte.Location =
            this.panelGetComprobanteFex.Location = panelInitialLocation;
            this.txtResultados.Visible = false;
            this.gridResultados.Visible = false;
        }

        #region [Cargar Combos]

        private void CargarMetodos()        
        {
            this.cbWebService.ValueMember = "Id";
            this.cbWebService.DisplayMember = "Nombre";
            IMaestrosService svc = ServiceFactory.GetMaestroService();
            this.cbWebService.DataSource = svc.ObtenerWebServicesAfip();
            this.cbWebService.SelectedIndex = 0;
        }

        private void CargarMonedas()
        {
            if (cbMoneda.Items.Count == 0)
            {
                FacturaElectronica.Afip.Ws.Wsfe.MonedaResponse resultado = client.GetTiposMonedas(this.ticket);
                this.cbMoneda.DisplayMember = "Desc";
                this.cbMoneda.ValueMember = "Id";
                this.cbMoneda.DataSource = resultado.ResultGet.OrderBy(m => m.Desc).ToList();
            }
        }

        private void CargarTiposCbte()
        {
            if (cbTiposCbte.Items.Count == 0)
            {
                FacturaElectronica.Afip.Ws.Wsfe.CbteTipoResponse resultado = client.GetTiposCbte(this.ticket);
                this.cbTiposCbte.DisplayMember = "Desc";
                this.cbTiposCbte.ValueMember = "Id";
                this.cbTiposCbte.DataSource = resultado.ResultGet;
            }
        }

        private void CargarTiposCbteFex()
        {
            if (cbTiposCbte.Items.Count == 0)
            {
                FEXResponse_Cbte_Tipo resultado = client.GetTiposComprobantes(this.ticketFex);
                this.cbTiposCbteFex.DisplayMember = "Cbte_Ds";
                this.cbTiposCbteFex.ValueMember = "Cbte_Id";
                this.cbTiposCbteFex.DataSource = resultado.FEXResultGet;
            }
        }

        private void CargarPtosVtaFex()
        {
            if (cbTiposCbte.Items.Count == 0)
            {
                FEXResponse_PtoVenta resultado = client.GetPuntosDeVenta(this.ticketFex);
                this.cbPtosVtaFex.DisplayMember = "Pve_Nro";
                this.cbPtosVtaFex.ValueMember = "Pve_Nro";
                this.cbPtosVtaFex.DataSource = resultado.FEXResultGet;
            }
        }

        private void CargarMonedasFex()
        {
            if (cbMoneda.Items.Count == 0)
            {
                FEXResponse_Mon resultado = client.GetMonedas(this.ticketFex);
                this.cbMoneda.DisplayMember = "Mon_Ds";
                this.cbMoneda.ValueMember = "Mon_Id";
                this.cbMoneda.DataSource = resultado.FEXResultGet.OrderBy(m => m.Mon_Ds).ToList();
            }
        }

        #endregion [Cargar Combos]

        private void cbWebService_SelectedIndexChanged(object sender, EventArgs e)
        {
            InicializarControles();
            int panelSearchHeight = 0;
            this.txtResultados.Visible = true;
            if (cbWebService.SelectedItem != null)
            {
                bool mostrarPanelParametros = false;
                WebServiceAfipDto dto = cbWebService.SelectedItem as WebServiceAfipDto;
                string selectedValue = dto.Nombre.Trim();

                if (selectedValue == GetCotizacionNombre)
                {
                    mostrarPanelParametros = true;                    
                    panelSearchHeight = this.panelMoneda.Height;
                    this.CargarMonedas();
                    this.panelMoneda.Visible = true;
                }
                else if (selectedValue == GetTiposMonedasNombre ||
                         selectedValue == GetTiposCbtesNombre ||
                         selectedValue == GetTiposTributosNombre ||
                         selectedValue == GetTiposIvaNombre ||
                         selectedValue == GetTiposOpcionalNombre ||
                         selectedValue == GetTiposDocNombre ||
                         selectedValue == GetTiposConceptoNombre ||
                         selectedValue == FEXGetPARAM_Cbte_Tipo ||
                         selectedValue == FEXGetPARAM_DST_CUIT ||
                         selectedValue == FEXGetPARAM_DST_pais ||
                         selectedValue == FEXGetPARAM_Idiomas ||
                         selectedValue == FEXGetPARAM_Incoterms ||
                         selectedValue == FEXGetPARAM_MON ||
                         selectedValue == FEXGetPARAM_PtoVenta ||
                         selectedValue == FEXGetPARAM_Tipo_Expo ||
                         selectedValue == FEXGetPARAM_UMed)
                {
                    this.gridResultados.Visible = true;
                    this.gridResultados.DataSource = null;
                    this.txtResultados.Visible = false;
                }
                else if (selectedValue == CompUltimoAutorizadoNombre)
                {                    
                    this.txtPtoVta.Text = string.Empty;                    
                    panelSearchHeight = this.panelUltimoCbte.Height;                    
                    this.CargarTiposCbte();
                    mostrarPanelParametros = true;
                    this.panelUltimoCbte.Visible = true;
                }
                else if( selectedValue == FEXGetCMP)
                {
                    mostrarPanelParametros = true;
                    this.CargarTiposCbteFex();
                    this.CargarPtosVtaFex();
                    panelSearchHeight = this.panelGetComprobanteFex.Height;
                    this.txtNroCbteFex.Visible = 
                    this.lblNroCbteFex.Visible = true;
                    this.panelGetComprobanteFex.Visible = true;
                }
                else if (selectedValue == FEXGetLast_CMP)
                {
                    mostrarPanelParametros = true;
                    this.CargarTiposCbteFex();
                    this.CargarPtosVtaFex();
                    this.txtNroCbteFex.Visible =
                    this.lblNroCbteFex.Visible = false;
                    panelSearchHeight = this.panelGetComprobanteFex.Height;
                    this.panelGetComprobanteFex.Visible = true;
                }
                else if (selectedValue == FEXGetPARAM_Ctz)
                {
                    mostrarPanelParametros = true;
                    panelSearchHeight = this.panelMoneda.Height;
                    this.CargarMonedasFex();
                    this.panelMoneda.Visible = true;
                }

                AcomodarControles(mostrarPanelParametros, panelSearchHeight);

                this.lblNombreWs.Text = dto.Nombre;
                this.lblDescripcionWs.Text = dto.Descripcion;
            }
        }

        private void AcomodarControles(bool mostrarPanelParametros, int panelSearchHeight)
        {
            this.btnConsultar.Location = new Point(this.btnConsultar.Location.X, panelInitialLocation.Y + minPanelHeight);
            this.gridResultados.Location = new Point(this.lblResultados.Location.X, btnConsultar.Location.Y + 30);
            this.txtResultados.Location = this.gridResultados.Location;
            this.lblResultados.Location = new Point(this.gridResultados.Location.X,
                                                    this.btnConsultar.Location.Y + (this.btnConsultar.Height/2));

            if (mostrarPanelParametros)
            {
                this.lblResultados.Location = new Point(this.lblResultados.Location.X,
                                                        this.lblResultados.Location.Y + panelSearchHeight - 10);
                this.btnConsultar.Location = new Point(this.btnConsultar.Location.X,
                                                       this.btnConsultar.Location.Y + panelSearchHeight);
                this.gridResultados.Location = new Point(this.gridResultados.Location.X,
                                                         this.gridResultados.Location.Y + panelSearchHeight);
                this.txtResultados.Location = new Point(this.txtResultados.Location.X,
                                                        this.txtResultados.Location.Y + panelSearchHeight);
            }
            this.gridResultados.Height = this.Height - this.gridResultados.Location.Y - 50;
            this.txtResultados.Height = this.gridResultados.Height;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            this.txtResultados.Text = string.Empty;
            if (cbWebService.SelectedItem != null)
            {
                string selectedValue = (cbWebService.SelectedItem as WebServiceAfipDto).Nombre.Trim();
                if (selectedValue == GetTiposMonedasNombre)
                {
                    this.gridResultados.DataSource = this.client.GetTiposMonedas(this.ticket).ResultGet;
                }
                else if (selectedValue == GetTiposCbtesNombre)
                {
                    this.gridResultados.DataSource = this.client.GetTiposCbte(this.ticket).ResultGet;
                }
                else if (selectedValue == GetTiposTributosNombre)
                {
                    this.gridResultados.DataSource = this.client.GetTiposTributos(this.ticket).ResultGet;
                }
                else if (selectedValue == GetTiposIvaNombre)
                {
                    this.gridResultados.DataSource = this.client.GetTiposIva(this.ticket).ResultGet;
                }
                else if (selectedValue == GetTiposOpcionalNombre)
                {
                    this.gridResultados.DataSource = this.client.GetTiposOpcional(this.ticket).ResultGet;
                }
                else if (selectedValue == CompTotXRequestNombre)
                {
                    this.txtResultados.Text = this.client.CompTotXRequest(this.ticket).RegXReq.ToString();
                }
                else if (selectedValue == GetTiposDocNombre)
                {
                    this.gridResultados.DataSource = this.client.GetTiposDoc(this.ticket).ResultGet;
                }
                else if (selectedValue == CompUltimoAutorizadoNombre)
                {
                    if (string.IsNullOrEmpty(this.txtPtoVta.Text))
                    {
                        MessageBox.Show("Debe ingresar un valor para el Punto de Venta", "Validación campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    int ptoVtaInt = int.Parse(this.txtPtoVta.Text);
                    int cbteTipo = int.Parse(this.cbTiposCbte.SelectedValue.ToString());
                    FERecuperaLastCbteResponse result = this.client.CompUltimoAutorizado(this.ticket, ptoVtaInt, cbteTipo);

                    var tiposDeComprobante = ComprobanteService.ObtenerTiposComprobantes();

                    string tipoComprobanteStr = result.CbteTipo.ToString();
                    var tipoDeComprobante = tiposDeComprobante.Where(t => t.CodigoAfip.HasValue && t.CodigoAfip.Value == result.CbteTipo).SingleOrDefault();
                    if (tipoDeComprobante != null)
                    {
                        tipoComprobanteStr = string.Format("{0}, AFIP {1} {2}", tipoDeComprobante.Codigo, tipoDeComprobante.CodigoAfip, tipoDeComprobante.Descripcion);
                    }

                    this.txtResultados.Text = string.Format(@"CbteNro: {0}{1}CbteTipo: {2}{3}PtoVta: {4}{5}",
                                                              result.CbteNro,
                                                              Environment.NewLine,
                                                              tipoComprobanteStr,
                                                              Environment.NewLine,
                                                              result.PtoVta,
                                                              Environment.NewLine);
                }
                else if (selectedValue == GetTiposConceptoNombre)
                {
                    this.gridResultados.DataSource = this.client.GetTiposConcepto(this.ticket).ResultGet;
                }
                else if (selectedValue == GetCotizacionNombre)
                {
                    string monId = this.cbMoneda.SelectedValue.ToString();
                    Cotizacion cotizacion = this.client.GetCotizacion(this.ticket, monId).ResultGet;
                    if (cotizacion != null)
                    {
                        this.txtResultados.Text = string.Format(@"Fecha: {0}{1}Cotizacion: ${2}{3}",
                                                                 DateTime.ParseExact(cotizacion.FchCotiz, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"),
                                                                 Environment.NewLine,
                                                                 cotizacion.MonCotiz,
                                                                 Environment.NewLine);
                    }
                    else
                    {
                        this.txtResultados.Text = "No hay cotizacion disponible";
                    }

                }
                else if (selectedValue == FEXGetLast_ID)
                {
                    this.gridResultados.DataSource = this.client.GetLastId(this.ticketFex).FEXResultGet;
                }
                else if (selectedValue == FEXGetPARAM_Cbte_Tipo)
                {
                    this.gridResultados.DataSource = this.client.GetTiposComprobantes(this.ticketFex).FEXResultGet;
                }
                else if (selectedValue == FEXGetPARAM_DST_CUIT)
                {
                    this.gridResultados.DataSource =
                        this.client.GetCuits(this.ticketFex).FEXResultGet.OrderBy(c => c.DST_Ds).ToList();
                }
                else if (selectedValue == FEXGetPARAM_DST_pais)
                {
                    this.gridResultados.DataSource = this.client.GetPaises(this.ticketFex).FEXResultGet.OrderBy(p => p.DST_Ds).ToList();
                }
                else if (selectedValue == FEXGetPARAM_Idiomas)
                {
                    this.gridResultados.DataSource = this.client.GetIdiomas(this.ticketFex).FEXResultGet;
                }
                else if (selectedValue == FEXGetPARAM_Incoterms)
                {
                    this.gridResultados.DataSource = this.client.GetIncoterms(this.ticketFex).FEXResultGet;
                }
                else if (selectedValue == FEXGetPARAM_MON)
                {
                    this.gridResultados.DataSource = this.client.GetMonedas(this.ticketFex).FEXResultGet.OrderBy(m => m.Mon_Ds).ToList();
                }
                else if (selectedValue == FEXGetPARAM_PtoVenta)
                {
                    this.gridResultados.DataSource = this.client.GetPuntosDeVenta(this.ticketFex).FEXResultGet;
                }
                else if (selectedValue == FEXGetPARAM_Tipo_Expo)
                {
                    this.gridResultados.DataSource = this.client.GetTiposDeExportacion(this.ticketFex).FEXResultGet;
                }
                else if (selectedValue == FEXGetPARAM_UMed)
                {
                    this.gridResultados.DataSource = this.client.GetUnidadesDeMedida(this.ticketFex).FEXResultGet.Where(u => u != null).OrderBy(u => u.Umed_Ds).ToList();
                }
                if (selectedValue == GetTiposMonedasNombre ||
                         selectedValue == GetTiposCbtesNombre ||
                         selectedValue == GetTiposTributosNombre ||
                         selectedValue == GetTiposIvaNombre ||
                         selectedValue == GetTiposOpcionalNombre ||
                         selectedValue == GetTiposDocNombre ||
                         selectedValue == GetTiposConceptoNombre)
                {
                    this.lblResultados.Text = string.Format("Resultados: {0} registros", this.gridResultados.RowCount);
                }
                else if(selectedValue == FEXGetCMP)
                {
                    if (string.IsNullOrEmpty(this.txtNroCbteFex.Text.Trim()) ||
                        string.IsNullOrEmpty(this.cbTiposCbteFex.SelectedValue.ToString()) ||
                        string.IsNullOrEmpty(this.cbPtosVtaFex.SelectedValue.ToString()))
                    {
                        MensajeValidarParametros();
                        return;
                    }
                    ClsFEXGetCMP fexGetCmp = new ClsFEXGetCMP();
                    fexGetCmp.Cbte_nro = long.Parse(this.txtNroCbteFex.Text.Trim());
                    fexGetCmp.Cbte_tipo = short.Parse(this.cbTiposCbteFex.SelectedValue.ToString());
                    fexGetCmp.Punto_vta = short.Parse(this.cbPtosVtaFex.SelectedValue.ToString());
                    FEXGetCMPResponse result = this.client.GetComprobante(this.ticketFex, fexGetCmp);
                    // TODO: mostrar resultado
                }
                else if (selectedValue == FEXGetLast_CMP)
                {
                    if (string.IsNullOrEmpty(this.cbTiposCbteFex.SelectedValue.ToString()) ||
                        string.IsNullOrEmpty(this.cbPtosVtaFex.SelectedValue.ToString()))
                    {
                        MensajeValidarParametros();
                        return;
                    }
                    ClsFEX_LastCMP fexLastCmp = new ClsFEX_LastCMP();
                    fexLastCmp.Cbte_Tipo = short.Parse(this.cbTiposCbteFex.SelectedValue.ToString());
                    fexLastCmp.Pto_venta = short.Parse(this.cbPtosVtaFex.SelectedValue.ToString());
                    fexLastCmp.Cuit = this.ticketFex.Cuit;
                    fexLastCmp.Sign = this.ticketFex.Sign;
                    fexLastCmp.Token = this.ticketFex.Token;
                    FEXResponseLast_CMP result = this.client.GetUltimoComprobanteAutorizado(fexLastCmp);
                    // TODO: mostrar resultado
                }
                else if (selectedValue == FEXGetLast_ID)
                {
                    FEXResponse_LastID result = this.client.GetLastId(this.ticketFex);
                    this.txtResultados.Text = result.FEXResultGet.Id.ToString();
                }
                else if (selectedValue == FEXGetPARAM_Ctz)
                {
                    if(string.IsNullOrEmpty(this.cbMoneda.SelectedValue.ToString()))
                    {
                        MensajeValidarParametros();
                        return;
                    }
                    string monId = this.cbMoneda.SelectedValue.ToString();
                    FEXResponse_Ctz cotizacion = this.client.GetFexCotizacion(this.ticketFex,monId);
                    if (cotizacion != null)
                    {
                        this.txtResultados.Text = string.Format(@"Fecha: {0}{1}Cotizacion: ${2}{3}",
                                                                 DateTime.ParseExact(cotizacion.FEXResultGet.Mon_fecha, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"),
                                                                 Environment.NewLine,
                                                                 cotizacion.FEXResultGet.Mon_ctz,
                                                                 Environment.NewLine);
                    }
                    else
                    {
                        this.txtResultados.Text = "No hay cotizacion disponible";
                    }
                }
            }
        }

        private void MensajeValidarParametros()
        {
            MessageBox.Show("Debe ingresar un valor para todos los parametros", "Validación campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
