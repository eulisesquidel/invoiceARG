using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacturaElectronica.Ui.Web.Code.Security;

namespace FacturaElectronica.Ui.Web.Code
{
    public abstract class BaseMasterPage : System.Web.UI.MasterPage, IWebMessage
    {
        public bool EstaAutenticado
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated;
            }
        }


        public bool EsAdministrador
        {
            get
            {
                return HttpContext.Current.User.IsInRole(Roles.Administrador);
            }
        }

        public bool EsCliente
        {
            get
            {
                CustomPrincipal principal = HttpContext.Current.User as CustomPrincipal;
                return HttpContext.Current.User.IsInRole(Roles.Cliente);
            }
        }

        public string UserName
        {
            get
            {
                CustomIdentity identity = HttpContext.Current.User.Identity as CustomIdentity;
                return identity.Name;
            }
        }


        public long ClienteId
        {
            get
            {
                CustomIdentity identity = HttpContext.Current.User.Identity as CustomIdentity;
                return identity.ClientId.Value;
            }
        }


        public void HasPermissionToSeeMe(Operaciones operacion)
        {
            bool hasPermission = false;
            if (this.EstaAutenticado)
            {
                if (this.EsAdministrador)
                {
                    if (operacion != Operaciones.ComprobanteListado)
                    {
                        hasPermission = true;
                    }
                }
                else if (this.EsCliente)
                {
                    if (operacion == Operaciones.Home ||
                        operacion == Operaciones.Contacto ||
                        operacion == Operaciones.ComprobanteListado ||
                        operacion == Operaciones.ClienteDetalle ||
                        operacion == Operaciones.MensajesAlertasListado ||
                        operacion == Operaciones.MensajesAlertasDetalle)
                    { 
                        hasPermission = true;
                    }

                }
            }

            if (!hasPermission)
                RedirectToAccesoDenegado(string.Empty);                
        }

        public abstract void ShowMessage(string message, WebMessageType type);

        public abstract void ShowMessage(string title, string message, WebMessageType type);

        public abstract void RedirectToAccesoDenegado(string message);

        public abstract void BuildMenu();

        
    }
}
