using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacturaElectronica.Common.Contracts
{
    [Serializable]
    public class ClienteCriteria
    {
        public string RazonSocial { get; set; }

        public long? CUIT { get; set; }

        public string NombreContacto { get; set; }

        public string ApellidoContacto { get; set; }

    }
}
