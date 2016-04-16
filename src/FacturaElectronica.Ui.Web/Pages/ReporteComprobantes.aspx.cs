using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FacturaElectronica.Ui.Web.Code;
using FacturaElectronica.Common.Contracts;
using FacturaElectronica.Common.Services;
using FacturaElectronica.Common.Constants;
using System.Drawing;

namespace FacturaElectronica.Ui.Web.Pages
{
    public partial class ReporteComprobantes : ComprobantesBase
    {
        #region [BaseControls]

        protected override DropDownList ddlTipoComprobanteControl
        {
            get { return this.ddlTipoComprobante; }
        }
        protected override DropDownList ddlTipoContratoControl
        {
            get { return this.ddlTipoContrato; }
        }
        protected override DropDownList ddlMesFacturacionControl
        {
            get { return this.ddlMesFacturacion; }
        }
        protected override DropDownList ddlAnioFacturacionControl
        {
            get { return this.ddlAnioFacturacion; }
        }
        protected override DropDownList ddlEstadoControl
        {
            get { return this.ddlEstado; }
        }
        //protected override TextBox txtRazonSocialControl
        //{
        //    get { return this.txtRazonSocial; }
        //}
        protected override TextBox txtNroComprobanteControl
        {
            get { return this.txtNroComprobante; }
        }
        protected override TextBox txtFechaVencDesdeControl
        {
            get { return this.txtFechaVencDesde; }
        }
        protected override TextBox txtFechaVencHastaControl
        {
            get { return this.txtFechaVencHasta; }
        }
        protected override TextBox txtFechaRecepcionDesdeControl
        {
            get { return this.txtFechaDeRecepcionDesde; }
        }

        protected override TextBox txtFechaRecepcionHastaControl
        {
            get { return this.txtFechaDeRecepcionHasta; }
        }

        protected override TextBox txtDiasAlVtoDesdeCtrl
        {
            get { return this.txtDiasAlVtoDesde; }
        }
        protected override TextBox txtDiasAlVtoHastaCtrl
        {
            get { return this.txtDiasAlVtoHasta; }
        }

        protected override GridView GridControl
        {
            get { return this.Grid; }
        }
        protected override Label lblCantRegControl
        {
            get { return this.lblCantReg; }
        }

        #endregion [BaseControls]

        private const string pagComprobanteAuditoria = "ComprobanteAuditoria.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HasPermissionToSeeMe(Operaciones.ReporteComprobantes);
                base.Page_Load();
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }

        protected override void InicializarControles()
        {
            base.InicializarControles();

            // Estados
            IComprobanteService comprobanteSvc = ServiceFactory.GetComprobanteService();
            List<EstadoArchivoAsociadoDto> estados = comprobanteSvc.ObtenerEstados();
            UIHelper.LoadCbo(estados, this.ddlEstado, Constants.ValorInicialDdl, "Id", "Descripcion");
        }

        protected override void CargarCriteria(ComprobanteCriteria criteria)
        {
            base.CargarCriteria(criteria);

            criteria.RazonSocial = this.txtRazonSocial.Text.Trim();
            criteria.FechaDeCargaDesde = UIHelper.GetDateTimeFromInputText(this.txtFechaDeCargaDesde.Text);
            criteria.FechaDeCargaHasta = UIHelper.GetDateTimeFromInputText(this.txtFechaDeCargaHasta.Text);
            if (criteria.FechaDeCargaHasta.HasValue)
            {
                criteria.FechaDeCargaHasta = criteria.FechaDeCargaHasta.Value.AddDays(1).AddSeconds(-1);
            }
            criteria.DocumentosVencidos = this.chkDocumentosVencidos.Checked;
            criteria.MontoTotalDesde = UIHelper.GetDecimalFromInputText(this.txtMontoTotalDesde.Text.Trim());
            criteria.MontoTotalHasta = UIHelper.GetDecimalFromInputText(this.txtMontoTotalHasta.Text.Trim());
            criteria.SoloDocumentosConNDias = this.chkSoloDocsConNDias.Checked;
        }

        protected override List<ComprobanteArchivoAsociadoDto> ObtenerComprobantes(ComprobanteCriteria criteria)
        {
            return ServiceFactory.GetComprobanteService().ObtenerComprobantes(criteria);
        }

        protected void Grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "eliminar")
                {
                    long archivoAsociadoId = Convert.ToInt64(this.Grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
                    IComprobanteService svc = ServiceFactory.GetComprobanteService();
                    svc.CambiarEstado(archivoAsociadoId, CodigosEstadoArchivoAsociado.Eliminado);
                    Buscar();
                }
                else if (e.CommandName == "ver")
                {
                    long archivoAsociadoId = Convert.ToInt64(this.Grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
                    this.Response.Redirect(string.Format("{0}?Id={1}", pagComprobanteAuditoria, archivoAsociadoId), true);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }

        protected void Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                this.Grid.PageIndex = e.NewPageIndex;

                Buscar();
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }

        protected void Grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ComprobanteArchivoAsociadoDto dto = e.Row.DataItem as ComprobanteArchivoAsociadoDto;
                    int columnaFechaVencimiento = 4;
                    int columnaFechaVisualizacion = 5;
                    int columnaEstado = 7;
                    int columnaFechaDeRecepcion = 9;
                    int columnaBorrarComprobante = 11;
                    EstablecerFechaVencimiento(e, dto, columnaFechaVencimiento);
                    EstablecerColorEstado(e, dto, columnaEstado);
                    EstablecerFechaVisualizacion(e, dto, columnaFechaVisualizacion);
                    EstablecerBorrarComprobante(e, dto, columnaBorrarComprobante, columnaEstado);
                    EstablecerFechaDeRecepcion(e, dto, columnaFechaDeRecepcion);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }

        private void EstablecerFechaDeRecepcion(GridViewRowEventArgs e, ComprobanteArchivoAsociadoDto dto, int columnaFechaDeRecepcion)
        {
            ComprobanteArchivoAsociadoDto comprobanteArchivo = (ComprobanteArchivoAsociadoDto)e.Row.DataItem;
            TableCell cell = e.Row.Cells[columnaFechaDeRecepcion];
            Panel pnl = (Panel)cell.FindControl("pnlFechaRecepción");
            TextBox txt = new TextBox();
            txt.ID = "txtFechaDeRecepcion_" + comprobanteArchivo.ArchivoAsociadoId.ToString();
            txt.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            txt.CssClass = "txtFechaVtoEditable";
            txt.ReadOnly = true;
            //txt.Attributes.Add("name", "txtFechaDeRecepcion_" + comprobanteArchivo.ArchivoAsociadoId.ToString());
            
            if (comprobanteArchivo.DiasVencimiento.HasValue)
            {
                pnl.Controls.Add(txt);
                if (dto.FechaDeRecepcion.HasValue)
                {
                    txt.Text = dto.FechaDeRecepcion.Value.ToString("dd/MM/yyyy");
                }
            }
        }

        private void EstablecerFechaVisualizacion(GridViewRowEventArgs e, ComprobanteArchivoAsociadoDto dto, int columnaFechaVisualizacion)
        {
            TableCell cell = e.Row.Cells[columnaFechaVisualizacion];
            if (dto.FechaVisualizacion.HasValue)
            {
                cell.Text = dto.FechaVisualizacion.Value.ToString("dd/MM/yyyy hh:mm:ss tt");
            }
            else
            {
                if (dto.EstadoCodigo == CodigosEstadoArchivoAsociado.NoVisualizado)
                {
                    cell.Text = dto.EstadoDescripcion;
                    cell.ForeColor = Color.Red;
                }
            }
        }

        private void EstablecerBorrarComprobante(GridViewRowEventArgs e, ComprobanteArchivoAsociadoDto dto, int columnaBorrarComprobante, int columnaEstado)
        {
            if (dto.EstadoCodigo == CodigosEstadoArchivoAsociado.Eliminado ||
                dto.EstadoCodigo == CodigosEstadoArchivoAsociado.Visualizado)
            {
                e.Row.Cells[columnaBorrarComprobante].Text = "--";
                e.Row.Cells[columnaBorrarComprobante].Controls.Clear();
                if (dto.EstadoCodigo == CodigosEstadoArchivoAsociado.Eliminado)
                {
                    foreach (TableCell cell in e.Row.Cells)
                    {
                        int cellIndex = e.Row.Cells.GetCellIndex(cell);
                        if (cell.Visible &&
                            cell.Controls.Count == 0 &&
                            cellIndex != columnaEstado &&
                            cellIndex != columnaBorrarComprobante)
                        {
                            cell.CssClass = "lineThrough";
                        }
                    }
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Buscar();
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                base.LimpiarControles();

                this.txtRazonSocial.Text = string.Empty;
                this.txtFechaDeCargaDesde.Text = string.Empty;
                this.txtFechaDeCargaHasta.Text = string.Empty;
                this.chkDocumentosVencidos.Checked = false;
                this.txtMontoTotalDesde.Text = string.Empty;
                this.txtMontoTotalHasta.Text = string.Empty;
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //  exporto la grilla
                GridViewExportUtil.Export("Comprobantes.xls", this.Grid);
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (!this.BaseMaster.EsCliente)
                    {
                        // Cargo los valores de los inputs
                        Dictionary<long, DateTime?> ArchivoAsociadoIdsFechaRecepcion = new Dictionary<long, DateTime?>();
                        foreach (string key in this.Request.Form.AllKeys)
                        {
                            if (key.StartsWith("txtFechaDeRecepcion_"))
                            {
                                string dateValue = this.Request.Form[key];
                                long archivoAsociadoId = Convert.ToInt64(key.Split('_')[1]);
                                DateTime? fechaRecepcion = null;
                                if (!String.IsNullOrEmpty(dateValue))
                                {
                                    fechaRecepcion = DateTime.ParseExact(dateValue, "dd/MM/yyyy", null);
                                }

                                ArchivoAsociadoIdsFechaRecepcion.Add(archivoAsociadoId, fechaRecepcion);
                            }
                        }

                        // Tengo que guardar los cambios
                        IComprobanteService comprobanteSvc = ServiceFactory.GetComprobanteService();
                        comprobanteSvc.AsociarFechaDeRecepcion(ArchivoAsociadoIdsFechaRecepcion, UIHelper.GetCustomIdentity().UserId);
                    }

                    Buscar(); // vuelve a buscar para cargar los datos
                }
                catch (Exception ex)
                {
                    ExceptionManager.Instance.HandleException(ex);
                }
            }
        }
    }
}