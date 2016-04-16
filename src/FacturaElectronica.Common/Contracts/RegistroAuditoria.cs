using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FacturaElectronica.Common.Contracts
{
    [DataContract]
    public class RegistroAuditoria
    {
        [DataMember]
        public long UsuarioId { get; set; }

        [DataMember]
        public string UsuarioNombre { get; set; }

        [DataMember]
        public string CampoModificado { get; set; }

        [DataMember]
        public string ValorAnterior { get; set; }

        [DataMember]
        public string ValorNuevo { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }
    }
}
