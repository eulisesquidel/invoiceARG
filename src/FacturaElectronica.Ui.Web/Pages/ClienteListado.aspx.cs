using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FacturaElectronica.Common.Contracts;
using FacturaElectronica.Ui.Web.Code;

namespace FacturaElectronica.Ui.Web.Pages
{
    public partial class ClienteListado : BasePage
    {
        private const string pagDetalle = "ClienteDetalle.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HasPermissionToSeeMe(Operaciones.ClienteListado);
                if (!this.IsPostBack)
                {
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
            // cargo los filtros
            ClienteCriteria criteria = new ClienteCriteria();
            CargarCriteria(criteria);

            List<ClienteDto> list = ServiceFactory.GetClienteService().ObtenerClientes(criteria);
            this.lblCantReg.Text = string.Format(" ({0})", list.Count);
            this.Grid.DataSource = list;
            this.Grid.DataBind();
        }

        private void CargarCriteria(ClienteCriteria criteria)
        {
            criteria.RazonSocial = this.txtRazonSocial.Text.Trim();
            criteria.CUIT = this.txtCuit.Text.Trim() != string.Empty ? long.Parse(this.txtCuit.Text.Trim()) : default(long?);
            criteria.NombreContacto = this.txtNombreContacto.Text.Trim();
            criteria.ApellidoContacto = this.txtApellidoContacto.Text.Trim();
        }

        protected void Grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "editar" || e.CommandName == "eliminar")
            {
                try
                {
                    long clienteId = Convert.ToInt64(this.Grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
                    if (e.CommandName == "editar")
                    {
                        this.Response.Redirect(string.Format("{0}?Id={1}", pagDetalle, clienteId), true);
                    }
                    else if (e.CommandName == "eliminar")
                    {
                        ServiceFactory.GetClienteService().EliminarCliente(clienteId);
                        Buscar();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionManager.Instance.HandleException(ex);
                }
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

        protected void btnAgregarNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Response.Redirect(pagDetalle, true);
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
                this.txtRazonSocial.Text = string.Empty;
                this.txtCuit.Text = string.Empty;
                this.txtApellidoContacto.Text = string.Empty;
                this.txtNombreContacto.Text = string.Empty;
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
                GridViewExportUtil.Export("Clientes.xls", this.Grid);
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }
    }
}