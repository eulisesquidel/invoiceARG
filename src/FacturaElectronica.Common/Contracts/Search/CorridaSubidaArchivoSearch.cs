using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FacturaElectronica.Common.Contracts.Search
{
    [DataContract]
    public class CorridaSubidaArchivoSearch
    {
        [DataMember]
        public long? CorridaId { get; set; }

        [DataMember]
        public string NombreArchivoLike { get; set; }

        [DataMember]
        public DateTime? FechaDesde { get; set; }

        [DataMember]
        public DateTime? FechaHasta { get; set; }

        [DataMember]
        public DateTime? FechaLog { get; set; }

        [DataMember]
        public bool LoadDetalle { get; set; }

        [DataMember]
        public bool LoadLog { get; set; }
    }
}
