using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FacturaElectronica.Common.Contracts.Search
{
    [Serializable]
    [DataContract]
    public class LogSearch
    {
        [DataMember]
        public long? LogId { get; set; }

        [DataMember]
        public long CorridaId { get; set; }
    }
}
