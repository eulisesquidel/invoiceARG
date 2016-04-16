using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FacturaElectronica.Common.Contracts
{
    [DataContract]
    public class ComprobanteArchivoAsociadoDto
    {
        [DataMember]
        public long ArchivoAsociadoId { get; set; }

        [DataMember]
        public long ComprobanteId { get; set; }

        [DataMember]
        public DateTime? FechaVencimiento { get; set; }

        [DataMember]
        public int? DiasVencimiento { get; set; }

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
        public bool ClienteCalculaVencimientoConVisualizacion { get; set; }

        [DataMember]
        public DateTime? FechaDeRecepcion { get; set; }

        [DataMember]
        public string ClienteRazonSocial { get; set; }

        [DataMember]
        public string EstadoCodigo { get; set; }

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
        public string PathArchivo { get; set; }

        [DataMember]
        public int? PtoVta { get; set; }

        [DataMember]
        public int? TipoContratoId { get; set; }

        [DataMember]
        public string TipoContratoDescripcion { get; set; }

        [DataMember]
        public string PeriodoFacturacion { get; set; }

        [DataMember]
        public decimal? MontoTotal { get; set; }
    }
}
