using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FacturaElectronica.Common.Services;
using FacturaElectronica.Common.Contracts;
using FacturaElectronica.Ui.Web.Code;
using FacturaElectronica.Core.Helpers;

namespace FacturaElectronica.Ui.Web.Pages
{
    public partial class CambiarPassword : BasePage
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
        
        ISeguridadService seguridadService = ServiceFactory.GetSecurityService();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.HasPermissionToSeeMe(Operaciones.CambiarPassVariosUsuarios);
            try
            {
                if (!this.IsPostBack)
                {
                    if (this.Request.QueryString["Id"] != null)
                    {
                        usuarioCurrent = seguridadService.ObtenerUsuario(Convert.ToInt64(this.Request.QueryString["Id"]));
                    }

                    Bindear();
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }

        private void Bindear()
        {
            if (usuarioCurrent.Id != 0)
            {
                this.txtNombre.Text = usuarioCurrent.NombreUsuario;
            }
        }


        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string passwordNueva = this.txtPasswordNueva.Text.Trim();

                seguridadService.CambiarPassword(usuarioCurrent.Id, passwordNueva);
                ShowMessage("Los datos fueron grabados con éxito", WebMessageType.Notification);
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
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
    }
}