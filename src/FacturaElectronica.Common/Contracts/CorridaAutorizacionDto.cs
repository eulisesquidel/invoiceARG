using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FacturaElectronica.Common.Contracts
{
    [DataContract]
    public class CorridaAutorizacionDto
    {
        public CorridaAutorizacionDto()
        {
            ComprobantesAutorizados = new List<DetalleComprobanteDto>();
            ComprobantesConObservaciones = new List<DetalleComprobanteDto>();
            Errores = new List<DetalleErrorDto>();
            Eventos = new List<DetalleEventoDto>();
        }

        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public string NombreDeArchivo { get; set; }

        [DataMember]
        public string PathArchivo { get; set; }

        [DataMember]
        public bool? Procesada { get; set; }

        [DataMember]
        public string TipoComprobante { get; set; }

        [DataMember]
        public List<DetalleComprobanteDto> ComprobantesAutorizados { get; set; }

        [DataMember]
        public List<DetalleComprobanteDto> ComprobantesConObservaciones { get; set; }

        [DataMember]
        public List<DetalleErrorDto> Errores { get; set; }

        [DataMember]
        public List<DetalleEventoDto> Eventos { get; set; }
    }
}
