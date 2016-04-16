using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FacturaElectronica.Common.Contracts
{
    [DataContract]
    public class LogCorridaDto
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public long CorridaId { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public string Mensaje { get; set; }

        [DataMember]
        public bool CorridaTerminada { get; set; }
    }
}
