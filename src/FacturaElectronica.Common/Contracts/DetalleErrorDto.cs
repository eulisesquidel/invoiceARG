using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FacturaElectronica.Common.Contracts
{
    [DataContract]
    public class DetalleErrorDto
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public int Codigo { get; set; }

        [DataMember]
        public string Mensaje { get; set; }
    }
}
