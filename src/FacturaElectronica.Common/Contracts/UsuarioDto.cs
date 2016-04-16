using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FacturaElectronica.Common.Contracts
{
    [Serializable]
    [DataContract]
    public class UsuarioDto
    {
        public UsuarioDto()
        {
            Roles = new List<RolDto>();
        }

        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string NombreUsuario { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public long? ClienteId { get; set; }

        [DataMember]
        public string ClienteRazonSocial { get; set; }

        [DataMember]
        public long? ClienteCuit { get; set; }

        [DataMember]
        public string RolNombre { get; set; }

        [DataMember]
        public List<RolDto> Roles { get; set; }
    }
}
