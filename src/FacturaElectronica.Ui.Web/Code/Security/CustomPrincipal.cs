using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using FacturaElectronica.Common.Services;
using FacturaElectronica.Common.Contracts;

namespace FacturaElectronica.Ui.Web.Code.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private CustomIdentity customIdentity;
        
        public IIdentity Identity
        {
            get { return this.customIdentity; }
        }

        public CustomPrincipal(CustomIdentity identity)
        {
            this.customIdentity = identity;
        }               

        public bool IsInRole(string role)
        {            
            bool isInRole = false;
            ISeguridadService svc = ServiceFactory.GetSecurityService();
            UsuarioDto usuarioDto = svc.ObtenerUsuario(this.customIdentity.Name);
            if (usuarioDto != null &&
                usuarioDto.Roles != null &&
                usuarioDto.Roles.Count > 0)
            {
                foreach (var rol in usuarioDto.Roles)
                {
                    if (rol.Codigo == role)
                    {
                        isInRole = true;
                        break;
                    }
                }
            }
            return isInRole;
        }
    }
}