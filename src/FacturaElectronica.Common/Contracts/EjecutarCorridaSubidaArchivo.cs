using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FacturaElectronica.Common.Contracts
{
    [DataContract]
    public class EjecutarCorridaSubidaArchivo
    {
        public EjecutarCorridaSubidaArchivo()
        {
            FileNames = new List<string>();
        }

        /// <summary>
        /// Indica si utiliza los datos de esta estructura en lugar de usar el nombre del archivo
        /// </summary>
        [DataMember]
        public bool ForzarDatosCliente { get; set; } 

        [DataMember]
        public long CorridaId { get; set; } 

        [DataMember]
        public List<string> FileNames { get; set; }

        [DataMember]
        public string Cuit { get; set; }

        [DataMember]
        public string CAE { get; set; }

        [DataMember]
        public DateTime? FechaVencimientoCAE { get; set; }

        [DataMember]
        public string TipoDeComprobanteCodigo { get; set; }

        [DataMember]
        public long NroComprobante { get; set; }

        [DataMember]
        public DateTime FechaComprobante { get; set; }

        [DataMember]
        public string PeriodoDeFacturacion { get; set; }

        [DataMember]
        public DateTime? FechaDeVencimiento { get; set; }

        [DataMember]
        public int? DiasDeVencimiento { get; set; }

        [DataMember]
        public int? PuntoDeVenta { get; set; }

        [DataMember]
        public string MontoTotal { get; set; }

        [DataMember]
        public string TipoContratoCodigo { get; set; }        
    }
}
