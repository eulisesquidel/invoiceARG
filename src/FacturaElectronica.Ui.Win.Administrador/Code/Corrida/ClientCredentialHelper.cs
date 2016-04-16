using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;

namespace FacturaElectronica.Ui.Win.Administrador.Code.Corrida
{
    internal class ClientCredentialHelper
    {
        public static void SetCredentials(ClientCredentials clientCredentials)
        {
            clientCredentials.UserName.UserName = "winfeclient";
            clientCredentials.UserName.Password = "3nd3s4";
        }
    }
}
