using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FacturaElectronica.Ui.Web.Code;
using FacturaElectronica.Common.Contracts;
using FacturaElectronica.Common.Services;
using FacturaElectronica.Core.Helpers;

namespace FacturaElectronica.Ui.Web.Pages
{
    public partial class UsuariosDetalle : BasePage
    {
        private const string pagListado = "UsuariosListado.aspx";

        public UsuarioDto usuarioCurrent
        {
            get
            {
                return (UsuarioDto)ViewState["Usuario"];
            }
            set
            {
                ViewState["Usuario"] = value;
            }
        }

        ISeguridadService seguridadService;

        protected void Page_Load(object sender, EventArgs e)
        {
            HasPermissionToSeeMe(Operaciones.UsuarioDetalle);
            try
            {
                seguridadService = ServiceFactory.GetSecurityService();                             

                if (!this.IsPostBack)
                {
                    if (this.Request.QueryString["Id"] == null)
                    {
                        usuarioCurrent = new UsuarioDto();
                    }
                    else
                    {
                        usuarioCurrent = seguridadService.ObtenerUsuario(Convert.ToInt64(this.Request.QueryString["Id"]));
                    }
                    InicializarListControls();
                    this.pnlPassword.Visible = usuarioCurrent.Id == 0;
                    Bindear();
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
            UIHelper.LoadCbo(roles, this.ddlRoles, "-Selecccionar-");
        }

        private void Bindear()
        {
            if (usuarioCurrent.Id != 0)
            {
                this.txtNombre.Text = usuarioCurrent.NombreUsuario;
                this.ddlRoles.SelectedValue = usuarioCurrent.Roles[0].Id.ToString();

                RolDto rol = ServiceFactory.GetSecurityService().ObtenerRol(int.Parse(this.ddlRoles.SelectedValue));
                if (rol.Codigo == FacturaElectronica.Ui.Web.Code.Roles.Administrador)
                {
                    this.pnlCientes.Visible = false;
                }
                else
                {
                    this.pnlCientes.Visible = true;
                    if (usuarioCurrent.ClienteId.HasValue)
                    {
                        ClienteDto clienteDto = ServiceFactory.GetClienteService().ObtenerCliente(usuarioCurrent.ClienteId.Value);
                        this.txtRazonSocial.Text = clienteDto.RazonSocial;
                        this.hfClienteId.Value = clienteDto.Id.ToString();
                    }
                }
            }
            else
            {
                this.pnlCientes.Visible = false;
            }
        }

        private void SetData()
        {
            usuarioCurrent.NombreUsuario = this.txtNombre.Text.Trim();
            if(this.pnlPassword.Visible)
                usuarioCurrent.Password = SecurityHelper.CreatePasswordHash(this.txtPassword.Text.Trim(), SecurityHelper.CreateSalt(30));
            usuarioCurrent.Roles = new List<RolDto>();
            RolDto rolDto = new RolDto();
            rolDto.Id = (int)UIHelper.GetIntFromInputCbo(this.ddlRoles);
            usuarioCurrent.Roles.Add(rolDto);
            usuarioCurrent.ClienteId = string.IsNullOrEmpty(this.hfClienteId.Value) ? default(long?) : long.Parse(this.hfClienteId.Value);
        }

        private void Save()
        {
            if (usuarioCurrent.Id == 0)
            {
                usuarioCurrent = seguridadService.CrearUsuario(usuarioCurrent);
            }
            else
            {
                usuarioCurrent = seguridadService.EditarUsuario(usuarioCurrent);
            }
        }

        private bool Validar()
        {
            return true;
        }
 
        private void Buscar()
        {
            IClienteService service = ServiceFactory.GetClienteService();
            ClienteCriteria criteria = new ClienteCriteria();
            criteria.RazonSocial = this.txtBuscarRazSoc.Text;
            this.Grid.DataSource = service.ObtenerClientes(criteria);
            this.Grid.DataBind();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SetData();
                    if (Validar())
                    {
                        Save();
                    }
                    this.RedirectToPagListado();
                    //ShowMessage("Los datos fueron grabados con éxito", WebMessageType.Notification);
                }
                catch (Exception ex)
                {
                    ExceptionManager.Instance.HandleException(ex);
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                RedirectToPagListado();
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }

        private void RedirectToPagListado()
        {
            try
            {
                Response.Redirect(pagListado, true);
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }

        protected void btnBuscarCliente_Click(object sender, EventArgs e)
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
            try
            {                
                if (e.CommandName == "asignar")
                {
                    this.txtRazonSocial.Text =
                        Server.HtmlDecode(this.Grid.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
                    this.hfClienteId.Value = this.Grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }

        protected void Grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void ddlRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlRoles.SelectedIndex > 0)
            {
                RolDto rol = ServiceFactory.GetSecurityService().ObtenerRol(int.Parse(this.ddlRoles.SelectedValue));
                this.pnlCientes.Visible = !(rol.Codigo == Roles.Administrador);                   
            }
        }

        protected void cvRazonSocial_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool valid = true;
            RolDto rol = ServiceFactory.GetSecurityService().ObtenerRol(int.Parse(this.ddlRoles.SelectedValue));
            if (rol.Codigo == Roles.Cliente && string.IsNullOrEmpty(this.txtRazonSocial.Text.Trim()))
            {
                valid = false;
            }
            args.IsValid = valid;
        }
    }
}