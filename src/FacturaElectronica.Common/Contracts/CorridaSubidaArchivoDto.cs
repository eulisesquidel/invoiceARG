using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FacturaElectronica.Common.Contracts
{
    [DataContract]
    public class CorridaSubidaArchivoDto
    {
        public CorridaSubidaArchivoDto()
        {
            Detalles = new List<CorridaSubidaArchivoDetalleDto>();
            Log = new List<CorridaSubidaArchivoLogDto>();
        }

        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public DateTime FechaProceso { get; set; }

        [DataMember]
        public bool? Procesada { get; set; }

        [DataMember]
        public List<CorridaSubidaArchivoDetalleDto> Detalles { get; set; }

        [DataMember]
        public List<CorridaSubidaArchivoLogDto> Log { get; set; }
    }
}
