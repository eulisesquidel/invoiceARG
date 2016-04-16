using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacturaElectronica.Common.Contracts;
using FacturaElectronica.Common.Services;
using FacturaElectronica.Ui.Win.Administrador.ServiceReferenceMaestro;

namespace FacturaElectronica.Ui.Win.Administrador.Code.Corrida
{
    public class MaestroServiceProxy : FacturaElectronica.Common.Services.IMaestrosService
    {      
        public List<WebServiceAfipDto> ObtenerWebServicesAfip()
        {
            List<WebServiceAfipDto> dto = new List<WebServiceAfipDto>();
            MaestrosServiceClient client = new MaestrosServiceClient();
            ClientCredentialHelper.SetCredentials(client.ClientCredentials);
            try
            {
                dto = client.ObtenerWebServicesAfip();
                client.Close();
            }
            catch
            {
                if (client.State != System.ServiceModel.CommunicationState.Closed)
                {
                    client.Abort();
                }

                throw;
            }

            return dto;
        }
    }
}
