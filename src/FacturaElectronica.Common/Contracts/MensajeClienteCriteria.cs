using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FacturaElectronica.Common.Contracts
{
    [Serializable]
    [DataContract]
    public class MensajeClienteCriteria
    {
        [DataMember]
        public long MensajeId { get; set; }

        [DataMember]
        public bool? Leido { get; set; }

        [DataMember]
        public string RazonSocial { get; set; }

        [DataMember]
        public long? CuitDesde { get; set; }

        [DataMember]
        public long? CuitHasta { get; set; }
    }
}
