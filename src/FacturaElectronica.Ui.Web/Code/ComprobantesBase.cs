using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacturaElectronica.Common.Services;
using FacturaElectronica.Common.Contracts;
using System.Web.UI.WebControls;
using FacturaElectronica.Common.Constants;
using System.Globalization;
using System.Drawing;
using System.Web.Caching;

namespace FacturaElectronica.Ui.Web.Code
{
    public abstract class ComprobantesBase : BasePage
    {
        #region [BaseControls]

        protected abstract DropDownList ddlTipoComprobanteControl
        {
            get;
        }
        protected abstract DropDownList ddlTipoContratoControl
        {
            get;
        }
        protected abstract DropDownList ddlMesFacturacionControl
        {
            get;
        }
        protected abstract DropDownList ddlAnioFacturacionControl
        {
            get;
        }

        protected abstract DropDownList ddlEstadoControl
        {
            get;
        }

        //protected abstract TextBox txtRazonSocialControl
        //{
        //    get;
        //}

        protected abstract TextBox txtNroComprobanteControl
        {
            get;
        }

        protected abstract TextBox txtFechaVencDesdeControl
        {
            get;
        }
        protected abstract TextBox txtFechaVencHastaControl
        {
            get;
        }

        protected abstract TextBox txtDiasAlVtoDesdeCtrl
        {
            get;
        }
        protected abstract TextBox txtDiasAlVtoHastaCtrl
        {
            get;
        }

        protected abstract TextBox txtFechaRecepcionDesdeControl
        {
            get;
        }
        protected abstract TextBox txtFechaRecepcionHastaControl
        {
            get;
        }

        protected abstract GridView GridControl
        {
            get;
        }

        protected abstract Label lblCantRegControl
        {
            get;
        }

        #endregion [BaseControls]

        protected virtual void Page_Load()
        {
            if (!Page.IsPostBack)
            {
                this.InicializarControles();
                this.Buscar();
            }
        }

        protected virtual void CargarCriteria(ComprobanteCriteria criteria)
        {
            //criteria.RazonSocial = txtRazonSocialControl.Text.Trim();
            criteria.TipoComprobanteId = UIHelper.GetIntFromInputCbo(this.ddlTipoComprobanteControl);
            criteria.NroComprobante = UIHelper.GetLongFromInputText(this.txtNroComprobanteControl.Text.Trim());
            criteria.FechaVencDesde = UIHelper.GetDateTimeFromInputText(this.txtFechaVencDesdeControl.Text);
            criteria.FechaVencHasta = UIHelper.GetDateTimeFromInputText(this.txtFechaVencHastaControl.Text);
            criteria.FechaDeRecepcionDesde = UIHelper.GetDateTimeFromInputText(this.txtFechaRecepcionDesdeControl.Text);
            criteria.FechaDeRecepcionHasta = UIHelper.GetDateTimeFromInputText(this.txtFechaRecepcionHastaControl.Text);
            criteria.DiasDeVencimientoDesde = UIHelper.GetIntFromInputText(this.txtDiasAlVtoDesdeCtrl.Text);
            criteria.DiasDeVencimientoHasta = UIHelper.GetIntFromInputText(this.txtDiasAlVtoHastaCtrl.Text);

            if (criteria.FechaDeCargaHasta.HasValue)
            {
                criteria.FechaDeCargaHasta = criteria.FechaDeCargaHasta.Value.AddDays(1).AddSeconds(-1);
            }
            criteria.MesFacturacion = UIHelper.GetIntFromInputCbo(this.ddlMesFacturacionControl);
            criteria.AnioFacturacion = UIHelper.GetIntFromInputCbo(this.ddlAnioFacturacionControl);
            criteria.TipoContratoId = UIHelper.GetIntFromInputCbo(this.ddlTipoContratoControl);
            criteria.EstadoId = UIHelper.GetIntFromInputCbo(this.ddlEstadoControl);
        }

        //protected ComprobanteCriteria criteria
        //{
        //    get
        //    {
        //        return (ComprobanteCriteria)ViewState["criteria"];
        //    }
        //    set
        //    {
        //        ViewState["criteria"] = value;
        //    }
        //}

        protected virtual void Buscar()
        {
            // cargo los filtros
            ComprobanteCriteria criteria = new ComprobanteCriteria();
            CargarCriteria(criteria);
            List<ComprobanteArchivoAsociadoDto> list = this.ObtenerComprobantes(criteria);
            this.lblCantRegControl.Text = string.Format(" ({0})", list.Count);
            this.GridControl.DataSource = list;
            this.GridControl.DataBind();

        }

        protected virtual void LimpiarControles()
        {
            //txtRazonSocialControl.Text = string.Empty;
            this.ddlTipoComprobanteControl.SelectedIndex = 0;
            this.txtNroComprobanteControl.Text = string.Empty;
            this.txtFechaVencDesdeControl.Text = string.Empty;
            this.txtFechaVencHastaControl.Text = string.Empty;
            this.txtFechaRecepcionDesdeControl.Text = string.Empty;
            this.txtFechaRecepcionHastaControl.Text = string.Empty;
            this.ddlMesFacturacionControl.SelectedIndex = 0;
            this.ddlAnioFacturacionControl.SelectedIndex = 0;
            this.ddlTipoContratoControl.SelectedIndex = 0;
            this.ddlEstadoControl.SelectedIndex = 0;
        }

        protected virtual void InicializarControles()
        {
            IComprobanteService comprobanteSvc = ServiceFactory.GetComprobanteService();

            // Tipos Comprobante
            List<TipoComprobanteDto> tiposComprobante = ObtenerTiposDeComprobante(comprobanteSvc);
            UIHelper.LoadCbo(tiposComprobante, this.ddlTipoComprobanteControl, Constants.ValorInicialDdl, "Id", "Descripcion");

            // Tipos Contrato
            List<TipoContratoDto> tiposContrato = ObtenerTiposDeContrato(comprobanteSvc);
            UIHelper.LoadCbo(tiposContrato, this.ddlTipoContratoControl, Constants.ValorInicialDdl, "Id", "Descripcion");

            // Mes Facturacion
            this.CargarListaMeses(this.ddlMesFacturacionControl, false);

            // Anio Facturacion
            List<int> aniosFacturacion = comprobanteSvc.ObtenerAniosFacturacion();
            UIHelper.LoadBasicCbo(aniosFacturacion, this.ddlAnioFacturacionControl, Constants.ValorInicialDdl);
        }

        private static List<TipoContratoDto> ObtenerTiposDeContrato(IComprobanteService comprobanteSvc)
        {
            const string key = "ObtenerTiposDeContrato";
            List<TipoContratoDto> tiposContrato = HttpContext.Current.Cache.Get(key) as List<TipoContratoDto>;
            if (tiposContrato == null)
            {
                tiposContrato = comprobanteSvc.ObtenerTiposContrato();
                HttpContext.Current.Cache.Add(key, tiposContrato, null, Cache.NoAbsoluteExpiration, new TimeSpan(1, 0, 0), CacheItemPriority.Normal, null);
            }

            return tiposContrato;
        }

        private static List<TipoComprobanteDto> ObtenerTiposDeComprobante(IComprobanteService comprobanteSvc)
        {           
            const string key = "ObtenerTiposDeComprobante";
            List<TipoComprobanteDto> tiposComprobante = HttpContext.Current.Cache.Get(key) as List<TipoComprobanteDto>;
            if (tiposComprobante == null)
            {
                tiposComprobante = comprobanteSvc.ObtenerTiposComprobantes();
                HttpContext.Current.Cache.Add(key, tiposComprobante, null, Cache.NoAbsoluteExpiration, new TimeSpan(1, 0, 0), CacheItemPriority.Normal, null);
            }

            return tiposComprobante;
        }

        protected virtual void EstablecerFechaVencimiento(GridViewRowEventArgs e, ComprobanteArchivoAsociadoDto dto, int columnaFechaVencimiento)
        {
            e.Row.Cells[columnaFechaVencimiento].Text = dto.FechaVencimiento.HasValue ?
                                                        dto.FechaVencimiento.Value.ToString("dd/MM/yyyy") :
                                                        string.Format("{0} días de recepcionado", dto.DiasVencimiento);
        }

        protected virtual void EstablecerColorEstado(GridViewRowEventArgs e, ComprobanteArchivoAsociadoDto dto, int columnaEstado)
        {
            e.Row.Cells[columnaEstado].ForeColor = dto.EstadoCodigo == CodigosEstadoArchivoAsociado.Visualizado ? Color.Green : Color.Red;
        }

        private void CargarListaMeses(DropDownList ddlMes, bool mesCorriente)
        {
            ddlMes.Items.Clear();
            ddlMes.Items.Add(new ListItem(Constants.ValorInicialDdl, "-1"));

            ddlMes.Items.Add(new ListItem() { Value = "1", Text = "Enero" });
            ddlMes.Items.Add(new ListItem() { Value = "2", Text = "Febrero" });
            ddlMes.Items.Add(new ListItem() { Value = "3", Text = "Marzo" });
            ddlMes.Items.Add(new ListItem() { Value = "4", Text = "Abril" });
            ddlMes.Items.Add(new ListItem() { Value = "5", Text = "Mayo" });
            ddlMes.Items.Add(new ListItem() { Value = "6", Text = "Junio" });
            ddlMes.Items.Add(new ListItem() { Value = "7", Text = "Julio" });
            ddlMes.Items.Add(new ListItem() { Value = "8", Text = "Agosto" });
            ddlMes.Items.Add(new ListItem() { Value = "9", Text = "Septiembre" });
            ddlMes.Items.Add(new ListItem() { Value = "10", Text = "Octubre" });
            ddlMes.Items.Add(new ListItem() { Value = "11", Text = "Noviembre" });
            ddlMes.Items.Add(new ListItem() { Value = "12", Text = "Diciembre" });

            if (mesCorriente == true)
            {
                ddlMes.Items.FindByValue(DateTime.Now.Month.ToString()).Selected = true;
            }
        }

        protected abstract List<ComprobanteArchivoAsociadoDto> ObtenerComprobantes(ComprobanteCriteria criteria);
    }
}