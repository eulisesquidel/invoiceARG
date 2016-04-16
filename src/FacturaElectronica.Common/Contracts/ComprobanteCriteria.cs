using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using FacturaElectronica.Common.Constants;

namespace FacturaElectronica.Common.Contracts
{
    [Serializable]
    [DataContract]
    public class ComprobanteCriteria
    {
        [DataMember]
        public long? ArchivoAsociadoId { get; set; }

        [DataMember]
        public DateTime? FechaVencDesde { get; set; }

        [DataMember]
        public DateTime? FechaVencHasta { get; set; }

        [DataMember]
        public DateTime? FechaDeCargaDesde { get; set; }

        [DataMember]
        public DateTime? FechaDeCargaHasta { get; set; }

        [DataMember]
        public DateTime? FechaDeRecepcionDesde { get; set; }

        [DataMember]
        public DateTime? FechaDeRecepcionHasta { get; set; }

        [DataMember]
        public int? DiasDeVencimientoDesde { get; set; }

        [DataMember]
        public int? DiasDeVencimientoHasta { get; set; }

        [DataMember]
        public int? TipoComprobanteId { get; set; }

        [DataMember]
        public long? NroComprobante { get; set; }

        [DataMember]
        public int? TipoContratoId { get; set; }

        [DataMember]
        public int? MesFacturacion { get; set; }

        [DataMember]
        public int? AnioFacturacion { get; set; }

        [DataMember]
        public string RazonSocial { get; set; }

        [DataMember]
        public long? ClienteId { get; set; }

        [DataMember]
        public bool DocumentosVencidos { get; set; }

        [DataMember]
        public bool DocumentosNoVencidos { get; set; }

        [DataMember]
        public decimal? MontoTotalDesde { get; set; }

        [DataMember]
        public decimal? MontoTotalHasta { get; set; }

        [DataMember]
        public int? EstadoId { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public bool SoloDocumentosConNDias { get; set; }

        [DataMember]
        public bool SortIsAsc { get; set; }

        [DataMember]
        public string SortingField { get; set; }

        [DataMember]
        public int PageSize { get; set; }

        [DataMember]
        public int PageSkip { get; set; }
    }
}
