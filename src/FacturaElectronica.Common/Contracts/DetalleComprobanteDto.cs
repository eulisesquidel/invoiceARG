using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FacturaElectronica.Common.Contracts
{
    [DataContract]
    public class DetalleComprobanteDto
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public int Concepto { get; set; }
        [DataMember]
        public string ConceptoDesc { get; set; }
        [DataMember]
        public int DocTipo { get; set; }
        [DataMember]
        public string DocTipoDesc { get; set; }
        [DataMember]
        public long DocNro { get; set; }
        [DataMember]
        public long CbteDesde { get; set; }
        [DataMember]
        public long CbteHasta { get; set; }
        [DataMember]
        public DateTime CbteFecha { get; set; }
        [DataMember]
        public string CAE { get; set; }
        [DataMember]
        public DateTime CAEFechaVto { get; set; }

        [DataMember]
        public List<ObservacionComprobanteDto> Observaciones { get; set; }
    }
}
