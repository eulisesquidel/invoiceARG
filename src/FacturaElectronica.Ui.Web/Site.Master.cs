using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FacturaElectronica.Ui.Web.Code;
using FacturaElectronica.Common.Contracts;
using FacturaElectronica.Ui.Web.Code.Security;
using System.Web.Security;

namespace FacturaElectronica.Ui.Web
{
    public partial class SiteMaster : BaseMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.pnlMessages.CssClass = "pnlMessagesClass displayNone";
            this.BuildMenu();
        }

        public override void ShowMessage(string message, WebMessageType type)
        {
            ShowMessage("Mensaje", message, type);
        }

        public override void ShowMessage(string title, string message, WebMessageType type)
        {
            this.pnlMessages.CssClass = "pnlMessagesClass displayBlock";
            this.txtErrorTitle.Text = title;
            this.txtMessages.Text = message;
        }

        public override void RedirectToAccesoDenegado(string message)
        {
            Response.Redirect(string.Format("~/AccesoDenegado.aspx?message={0}", message), true);
        }

        public override void BuildMenu()
        {
            CustomIdentity ident = HttpContext.Current.User.Identity as CustomIdentity;

            if (ident != null && ident.IsAuthenticated)
            {
                // Home
                MenuItem home = new MenuItem() { Text="Home", NavigateUrl = "~/Default.aspx" };
                this.NavigationMenu.Items.Add(home);
                // Cambiar pass
                MenuItem cambiarPass = new MenuItem() { Text = "Cambiar Contraseña", NavigateUrl = "~/Account/ChangePassword.aspx" };
                this.NavigationMenu.Items.Add(cambiarPass);
                if (this.EsAdministrador)
                {
                    // Usuarios
                    MenuItem usuarios = new MenuItem() { Text = "Usuarios", NavigateUrl = "~/Pages/UsuariosListado.aspx" };
                    this.NavigationMenu.Items.Add(usuarios);
                    // Clientes
                    MenuItem clientes = new MenuItem() { Text = "Clientes", NavigateUrl = "~/Pages/ClienteListado.aspx" };
                    this.NavigationMenu.Items.Add(clientes);
                    // Reporte Comprobantes
                    MenuItem reporteComprobantes = new MenuItem() { Text = "Reporte Comprobantes", NavigateUrl = "~/Pages/ReporteComprobantes.aspx" };
                    this.NavigationMenu.Items.Add(reporteComprobantes);
                }
                else if (this.EsCliente)
                {
                    // Datos Cliente
                    MenuItem misDatos = new MenuItem() { Text = "Mis Datos", NavigateUrl = "~/Pages/ClienteDetalle.aspx" };
                    this.NavigationMenu.Items.Add(misDatos);

                    // Comprobantes Cliente
                    MenuItem misComprobantes = new MenuItem() { Text = "Mis Comprobantes", NavigateUrl = "~/Pages/ComprobantesListado.aspx" };
                    this.NavigationMenu.Items.Add(misComprobantes);
                }
                // Mensaje y Alertas Listado
                MenuItem mensajeAlertasListado = new MenuItem() { Text = "Mensajes y Alertas", NavigateUrl = "~/Pages/MensajesAlertasListado.aspx" };
                this.NavigationMenu.Items.Add(mensajeAlertasListado);
                // Contacto
                MenuItem contacto = new MenuItem() { Text = "Contacto", NavigateUrl = "~/Pages/Contacto.aspx" };
                this.NavigationMenu.Items.Add(contacto);
            }

        }

        protected void HeadLoginStatus_LoggedOut(object sender, EventArgs e)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
        }
    }
}
