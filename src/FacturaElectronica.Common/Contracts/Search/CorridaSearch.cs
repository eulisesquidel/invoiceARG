using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FacturaElectronica.Common.Contracts.Search
{
    [DataContract]
    public class CorridaSearch
    {
        [DataMember]
        public long? CorridaId { get; set; }

        [DataMember]
        public DateTime? FechaDesde { get; set; }

        [DataMember]
        public DateTime? FechaHasta { get; set; }
    }
}
