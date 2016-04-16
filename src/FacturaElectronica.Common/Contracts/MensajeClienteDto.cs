using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FacturaElectronica.Common.Contracts
{
    [Serializable]
    [DataContract]
    public class MensajeClienteDto
    {
        [DataMember]
        public long ClienteId { get; set; }
        
        [DataMember]
        public string RazonSocial { get; set; }

        [DataMember]
        public bool Leido { get; set; }

        [DataMember]
        public long Cuit { get; set; }
    }
}
