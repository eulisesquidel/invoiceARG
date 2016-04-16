using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FacturaElectronica.Common.Contracts;
using FacturaElectronica.Ui.Web.Code;
using FacturaElectronica.Common.Services;
using System.Globalization;
using System.Drawing;
using FacturaElectronica.Common.Constants;
using System.IO;
using FacturaElectronica.Ui.Web.Code.Search;
using FacturaElectronica.Ui.Web.Code.Security;
using System.Configuration;

namespace FacturaElectronica.Ui.Web.Pages
{
    public partial class ComprobantesListado : ComprobantesBase
    {
        private SortDirection SortDirectionViewState
        {
            get
            {
                if (ViewState["SortDirectionViewState"] == null)
                    return SortDirection.Ascending;
                else
                    return (SortDirection)ViewState["SortDirectionViewState"];
            }
            set
            {
                ViewState["SortDirectionViewState"] = value;
            }
        }

        private string SortExpressionViewState
        {
            get
            {
                return Convert.ToString(ViewState["SortExpressionViewState"]);
            }
            set
            {
                ViewState["SortExpressionViewState"] = value;
            }
        }

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

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HasPermissionToSeeMe(Operaciones.ComprobanteListado);
                base.Page_Load();
                this.btnBuscar.Attributes.Add("aspnetid", this.btnBuscar.ClientID);
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
            foreach (var estado in estados)
            {
                if (estado.Codigo != CodigosEstadoArchivoAsociado.Eliminado)
                {
                    this.ddlEstado.Items.Add(new ListItem(estado.Descripcion, estado.Id.ToString()));
                }
            }
            this.ddlEstado.Items.Insert(0, new ListItem(Constants.ValorInicialDdl, Constants.CboNullValue));
        }

        protected override void CargarCriteria(ComprobanteCriteria criteria)
        {
            base.CargarCriteria(criteria);
            criteria.ClienteId = this.BaseMaster.ClienteId;
            string codigoEstado = this.Request.Params["Estado"];
            if (!string.IsNullOrEmpty(codigoEstado) &&
                (codigoEstado == CodigosEstadoArchivoAsociado.NoVisualizado ||
                 codigoEstado == CodigosEstadoArchivoAsociado.Visualizado))
            {
                criteria.Estado = codigoEstado;
                if (codigoEstado == CodigosEstadoArchivoAsociado.NoVisualizado)
                {
                    if (this.Request.Params["Venc"] != null)
                    {
                        criteria.DocumentosVencidos = true;
                    }
                    else
                    {
                        criteria.DocumentosNoVencidos = true;
                    }
                }
            }
        }

        protected override List<ComprobanteArchivoAsociadoDto> ObtenerComprobantes(ComprobanteCriteria criteria)
        {
            int cantCbtes = this.Page.IsPostBack ? 0 : int.Parse(ConfigurationManager.AppSettings["cantUltimosReg"].ToString());
            return ServiceFactory.GetComprobanteService().ObtenerComprobantesPorCliente(criteria, cantCbtes);
        }

        private void BindToGrid()
        {
            //search.DebeBuscar = true;
            //this.Grid.DataSourceID = "CustomerObjectDs";   
        }

        // private ObjectDataSourceComprobanteListado search = new ObjectDataSourceComprobanteListado();

        protected void CustomerObjectDs_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
            //GridViewSearchObjectDataSource searchProvider = new GridViewSearchObjectDataSource();

            //search.SearchCriteria = criteria;
            ////this.CustomerSearchProvider = new SearchCustomerObjDataSourceProvider();
            ////this.CustomerSearchProvider.SearchParam = this.CustomerSearchParamSession;
            ////this.CustomerSearchProvider.WebServiceHelper = this.WebServiceHelper;

            //searchProvider.Provider = search;
            //e.ObjectInstance = searchProvider;
        }

        protected void Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                this.Grid.PageIndex = e.NewPageIndex;
                //BindToGrid();
                Buscar();
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }

        protected void Grid_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                // Si es la misma columna
                SortDirection sortDirection = e.SortDirection;
                if (this.SortExpressionViewState == e.SortExpression)
                {
                    if (this.SortDirectionViewState == SortDirection.Ascending)
                    {
                        this.SortDirectionViewState = SortDirection.Descending;
                        sortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        this.SortDirectionViewState = SortDirection.Ascending;
                        sortDirection = SortDirection.Ascending;
                    }
                }

                this.SortExpressionViewState = e.SortExpression;
                //criteria.SortIsAsc = sortDirection == SortDirection.Ascending;
                //criteria.SortingField = e.SortExpression;

                this.SortExpressionViewState = e.SortExpression;

                BindToGrid();
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }

        protected void Grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "ver")
                {
                    VisualizacionComprobanteDto dto = new VisualizacionComprobanteDto();
                    dto.ArchivoAsociadoId = Convert.ToInt64(this.Grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
                    string ip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(ip))
                    {
                        ip = Request.ServerVariables["REMOTE_ADDR"];
                    }
                    if (string.IsNullOrEmpty(ip))
                    {
                        ip = Request.UserHostAddress;
                    }
                    dto.Ip = ip;
                    IComprobanteService svc = ServiceFactory.GetComprobanteService();
                    dto.UsuarioIdAuditoria = UIHelper.GetCustomIdentity().UserId;
                    svc.AgregarVisualizacion(dto);

                    Buscar();
                    //// Actualizo Estado
                    //EstadoArchivoAsociadoDto estado = svc.ObtenerEstado(CodigosEstadoArchivoAsociado.Visualizado);
                    //int columnaEstado = 4;
                    //this.Grid.Rows[Convert.ToInt32(e.CommandArgument)].Cells[columnaEstado].Text = estado.Descripcion;
                    //this.Grid.Rows[Convert.ToInt32(e.CommandArgument)].Cells[columnaEstado].ForeColor = Color.Green;
                }
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
                    int columnaFechaVencimiento = 3;
                    int columnaEstado = 5;
                    EstablecerFechaVencimiento(e, dto, columnaFechaVencimiento);
                    EstablecerColorEstado(e, dto, columnaEstado);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
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
                LimpiarControles();
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
    }
}