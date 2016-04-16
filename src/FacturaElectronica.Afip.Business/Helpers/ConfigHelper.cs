using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;

namespace FacturaElectronica.Afip.Business.Helpers
{
    public class ConfigHelper
    {
        public static StoreLocation ObtenerStoreLocation()
        {
            StoreLocation storeLocationVal = StoreLocation.LocalMachine;
            string storeLocationConfig = ConfigurationManager.AppSettings["storeLocation"];
            if (!string.IsNullOrEmpty(storeLocationConfig))
            {
                storeLocationVal = (StoreLocation) Enum.Parse(typeof(StoreLocation), storeLocationConfig);
            }
            return storeLocationVal;
        }

        public static StoreName ObtenerStoreName()
        {
            StoreName storeNameVal = StoreName.My;
            string storeNameConfig = ConfigurationManager.AppSettings["storeName"];
            if (!string.IsNullOrEmpty(storeNameConfig))
            {
                storeNameVal = (StoreName)Enum.Parse(typeof(StoreName), storeNameConfig);
            }
            return storeNameVal;
        }
    }
}
