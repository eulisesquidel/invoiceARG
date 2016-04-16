using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacturaElectronica.Common.Contracts;
using System.ServiceModel;

namespace FacturaElectronica.Common.Services
{
    [ServiceContract]
    public interface IMaestrosService
    {
        [OperationContract]
        List<WebServiceAfipDto> ObtenerWebServicesAfip();
    }
}
