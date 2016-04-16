using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FacturaElectronica.Common.Contracts
{
    [Serializable]
    [DataContract]
    public class ComprobanteDto
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public int TipoComprobanteId { get; set; }

        [DataMember]
        public string TipoComprobanteDescripcion { get; set; }

        [DataMember]
        public long NroComprobante { get; set; }

        [DataMember]
        public DateTime FechaDeCarga { get; set; }

        [DataMember]
        public long? ClienteId { get; set; }

        [DataMember]
        public string ClienteNombre { get; set; }

        [DataMember]
        public int EstadoId { get; set; }

        [DataMember]
        public string EstadoDescripcion { get; set; }

        [DataMember]
        public string DireccionIp { get; set; }

        [DataMember]
        public DateTime? FechaVisualizacion { get; set; }

        [DataMember]
        public string CAE { get; set; }

        [DataMember]
        public DateTime? CAEFechaVencimiento { get; set; }

        [DataMember]
        public string PathFile { get; set; }

        [DataMember]
        public long? CbteDesde { get; set; }

        [DataMember]
        public long? CbteHasta { get; set; }

        [DataMember]
        public DateTime? CbteFecha { get; set; }

        [DataMember]
        public int? PtoVta { get; set; }
    }
}
