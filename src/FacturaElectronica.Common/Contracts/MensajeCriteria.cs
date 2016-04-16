using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FacturaElectronica.Common.Contracts
{
    [Serializable]
    [DataContract]
    public class MensajeCriteria
    {
        [DataMember]
        public long? ClienteId { get; set; }

        [DataMember]
        public DateTime? FechaDeCargaDesde { get; set; }

        [DataMember]
        public DateTime? FechaDeCargaHasta { get; set; }

        [DataMember]
        public string Asunto { get; set; }

        [DataMember]
        public string NombreDeArchivo { get; set; }

        [DataMember]
        public bool? Leido { get; set; }
    }
}
