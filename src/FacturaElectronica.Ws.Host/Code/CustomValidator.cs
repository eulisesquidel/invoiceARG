using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

namespace FacturaElectronica.Ws.Host.Code
{
    public class CustomValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName == "winfeclient" && password == "3nd3s4")
                return;
            throw new SecurityTokenException(
                "Usuario o Password Desconocido para servicio FE WS");
        }
    }
}