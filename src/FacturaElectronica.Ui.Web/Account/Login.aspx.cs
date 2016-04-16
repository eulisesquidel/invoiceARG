using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using FacturaElectronica.Ui.Web.Code;
using FacturaElectronica.Common.Services;
using FacturaElectronica.Common.Contracts;
using System.Configuration;
using FacturaElectronica.Ui.Web.Code.Security;
using System.Security.Principal;
using System.Threading;

namespace FacturaElectronica.Ui.Web.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {          
        }

        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            ISeguridadService svc = ServiceFactory.GetSecurityService();
            try
            {
                if (svc.AutenticarUsuario(this.LoginUser.UserName, this.LoginUser.Password))
                {
                    UsuarioDto usuario = this.ObtenerUsuario(this.LoginUser.UserName.Trim());

                    // Query the user store to get this user's User Data
                    string userDataString = string.Format("{0}|{1}", usuario.Id, usuario.ClienteId);

                    // Create the cookie that contains the forms authentication ticket
                    HttpCookie authCookie = FormsAuthentication.GetAuthCookie(usuario.NombreUsuario, false);

                    // Get the FormsAuthenticationTicket out of the encrypted cookie
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

                    // Create a new FormsAuthenticationTicket that includes our custom User Data
                    FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, userDataString);

                    // Update the authCookie's Value to use the encrypted version of newTicket
                    authCookie.Value = FormsAuthentication.Encrypt(newTicket);

                    // Manually add the authCookie to the Cookies collection
                    Response.Cookies.Add(authCookie);

                    // Determine redirect URL and send user there
                    string redirUrl = FormsAuthentication.GetRedirectUrl(usuario.NombreUsuario, false);
                    if (String.IsNullOrEmpty(redirUrl))
                    {
                        redirUrl = "~/Default.aspx";
                    }

                    Response.Redirect(redirUrl);


                    ////LoginData loginData = new LoginData();
                    ////loginData.UsuarioId = usuario.Id;
                    ////loginData.ClienteId = usuario.ClienteId;
                    ////loginData.Roles = this.GetRolesDelimitedByComma(usuario.Roles);
                    //CustomIdentity identity = new CustomIdentity();
                    //identity.Usuario = usuario;
                    //IPrincipal principal = new CustomPrincipal(identity);
                    //// Attach the CustomPrincipal to HttpContext.User and Thread.CurrentPrincipal
                    //HttpContext.Current.User = principal;
                    //Thread.CurrentPrincipal = principal;


                    //FormsAuthentication.RedirectFromLoginPage(this.LoginUser.UserName, false);
                }
                else 
                {
                    this.AgregarErrorDeLogin();
                }
            }
            catch (Exception ex)
            {
                AgregarErrorDeLogin();
            }
        }

        private void AgregarErrorDeLogin()
        {
            //CustomValidator validator = new CustomValidator();
            //validator.IsValid = false;
            //validator.ValidationGroup = "LoginUserValidationGroup";
            //validator.ErrorMessage = "Usuario y Contraseña incorrectos";
            //this.Validators.Add(validator);
            this.LoginUser.FailureText = "Usuario y Contraseña incorrectos";
        }

        private UsuarioDto ObtenerUsuario(string userName)
        {
            ISeguridadService svc = ServiceFactory.GetSecurityService();
            return svc.ObtenerUsuario(userName);
        }
        
        private string GetRolesDelimitedByComma(List<RolDto> roles)
        {
            CommaDelimitedStringCollection list = new CommaDelimitedStringCollection();
            foreach (RolDto rol in roles)
            {
                list.Add(rol.Codigo);
            }
            return list.ToString();
        }
    }
}
