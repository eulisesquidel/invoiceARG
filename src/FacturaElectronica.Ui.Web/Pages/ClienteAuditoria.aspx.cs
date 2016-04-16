using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FacturaElectronica.Ui.Web.Code;
using FacturaElectronica.Common.Contracts;
using System.Drawing;
using FacturaElectronica.Common.Services;

namespace FacturaElectronica.Ui.Web.Pages
{
    public partial class ClienteAuditoria : BasePage
    {
        private IClienteService clienteSvc = null;
        private const string pagClienteDetalle = "ClienteDetalle.aspx";

        public long ClienteId
        {
            get
            {
                return long.Parse(ViewState["ClienteId"].ToString());
            }
            set
            {
                ViewState["ClienteId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HasPermissionToSeeMe(Operaciones.MensajesAlertasClientes);
                this.clienteSvc = ServiceFactory.GetClienteService();
                if (!this.IsPostBack)
                {
                    if (this.Request.QueryString["Id"] != null)
                    {
                        ClienteDto client = this.clienteSvc.ObtenerCliente(long.Parse(this.Request.QueryString["Id"].ToString()));
                        this.ClienteId = client.Id;
                        this.lblCliente.Text = client.RazonSocial;
                    }

                    this.Buscar();
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }

        private void Buscar()
        {
            List<RegistroAuditoria> list = this.clienteSvc.ObtenerAuditoriaCliente(ClienteId);
            this.lblCantReg.Text = string.Format(" ({0})", list.Count);
            this.Grid.DataSource = list;
            this.Grid.DataBind();
        }

        protected void Grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
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
                    //MensajeClienteDto item = e.Row.DataItem as MensajeClienteDto;
                    //e.Row.Cells[2].ForeColor = item.Leido ? Color.Green : Color.Red;
                    //e.Row.Cells[2].Text = item.Leido ? "Sí" : "No";
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            try
            {
                this.Response.Redirect(string.Format("{0}?Id={1}", pagClienteDetalle, ClienteId), true);
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

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //  exporto la grilla
                GridViewExportUtil.Export("ClienteAuditoria.xls", this.Grid);
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }
    }
}