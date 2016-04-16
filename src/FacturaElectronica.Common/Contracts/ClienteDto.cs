using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FacturaElectronica.Common.Contracts
{
    [Serializable]
    [DataContract]
    public class ClienteDto
    {
        public ClienteDto()
        {
            CalculaVencimientoConVisualizacionDoc = false; // valor x defecto
        }

        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string RazonSocial { get; set; }

        [DataMember]
        public long CUIT { get; set; }

        [DataMember]
        public string NombreContacto { get; set; }

        [DataMember]
        public string ApellidoContacto { get; set; }

        [DataMember]
        public string EmailContacto { get; set; }

        [DataMember]
        public string NombreContactoSecundario { get; set; }

        [DataMember]
        public string ApellidoContactoSecundario { get; set; }

        [DataMember]
        public string EmailContactoSecundario { get; set; }

        [DataMember]
        public long UsuarioId { get; set; }

        [DataMember]
        public bool CalculaVencimientoConVisualizacionDoc { get; set; }

        [DataMember]
        public long Auditoria_UsuarioId { get; set; }
    }
}
