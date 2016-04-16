using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FacturaElectronica.Common.Contracts
{
    [DataContract]
    public class CorridaSubidaArchivoDetalleDto
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string NombreArchivo { get; set; }

        [DataMember]
        public bool ProcesadoOK { get; set; }

        [DataMember]
        public string Mensaje { get; set; }

        [DataMember]
        public long ArchivoAsociadoId { get; set; }

        [DataMember]
        public long CorridaSubidaArchivoId { get; set; }
    }
}
