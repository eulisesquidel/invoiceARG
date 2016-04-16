using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Collections;

namespace FacturaElectronica.Common.Contracts
{
    [Serializable]
    [DataContract]
    public class SearchResult
    {
        [DataMember]
        public int Total { get; set; }

        [DataMember]
        public IList Resultado { get; set; }
    }
}
