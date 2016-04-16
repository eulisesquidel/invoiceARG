using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FacturaElectronica.Ui.Web.Code;
using FacturaElectronica.Common.Contracts;

namespace FacturaElectronica.Ui.Web.Pages
{
    public partial class UsuariosListado : BasePage
    {
        private const string pagDetalle = "UsuariosDetalle.aspx";
        private const string pagCambiarPass = "CambiarPassword.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HasPermissionToSeeMe(Operaciones.UsuarioDetalle);
                if (!this.IsPostBack)
                {
                    this.InicializarListControls();
                    this.Buscar();
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }

        private void InicializarListControls()
        {
            List<RolDto> roles = ServiceFactory.GetSecurityService().ObtenerRoles();
            UIHelper.LoadCbo(roles, this.ddlRoles, "-Todos-");
        }

        private void Buscar()
        {
            // cargo los filtros            
            UsuarioCriteria criteria = new UsuarioCriteria();
            criteria.NombreUsuario = this.txtNombre.Text.Trim();
            criteria.RolId = this.ddlRoles.SelectedIndex != 0 ? long.Parse(this.ddlRoles.SelectedValue) : default(long?);
            criteria.Cuit = this.txtCuit.Text.Trim() != string.Empty ? long.Parse(this.txtCuit.Text.Trim()) : default(long?);
            criteria.RazonSocial = this.txtRazonSocial.Text.Trim();
            List<UsuarioDto> list = ServiceFactory.GetSecurityService().ObtenerUsuarios(criteria);
            this.lblCantReg.Text = string.Format(" ({0})", list.Count);
            this.Grid.DataSource = list;
            this.Grid.DataBind();
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

        protected void Grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "editar" || e.CommandName == "eliminar" || e.CommandName == "password")
            {
                try
                {
                    long usuarioId = Convert.ToInt32(this.Grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
                    if (e.CommandName == "editar")
                    {
                        this.Response.Redirect(string.Format("{0}?Id={1}", pagDetalle, usuarioId), true);
                    }
                    else if (e.CommandName == "eliminar")
                    {
                        ServiceFactory.GetSecurityService().EliminarUsuario(usuarioId);
                        Buscar();
                    }
                    else if (e.CommandName == "password")
                    {
                        this.Response.Redirect(string.Format("{0}?Id={1}", pagCambiarPass, usuarioId), true);
                    }
                }
                catch (Exception ex)
                {
                    ExceptionManager.Instance.HandleException(ex);
                }
            }
        }

        protected void Grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {

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
                this.txtNombre.Text = string.Empty;
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
                GridViewExportUtil.Export("Usuarios.xls", this.Grid);
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }
    }
}