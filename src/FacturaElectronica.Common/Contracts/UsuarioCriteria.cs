using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacturaElectronica.Common.Contracts
{
    [Serializable]
    public class UsuarioCriteria
    {
        public string NombreUsuario { get; set; }

        public long? RolId { get; set; }

        public long? Cuit { get; set; }

        public string RazonSocial { get; set; }
    }
}
