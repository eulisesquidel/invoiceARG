using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FacturaElectronica.Common.Contracts
{
    [DataContract]
    public class TipoComprobanteDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public int? CodigoAfip { get; set; }

        [DataMember]
        public string Codigo { get; set; }

        public string ShowDescription
        {
            get
            {
                return String.Format("{0}({1})", Descripcion, Codigo);
            }
        }
    }
}