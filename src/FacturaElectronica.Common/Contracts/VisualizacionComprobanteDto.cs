using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacturaElectronica.Common.Contracts
{
    public class VisualizacionComprobanteDto
    {
        public long ArchivoAsociadoId { get; set; }

        public string Ip { get; set; }

        public long UsuarioIdAuditoria { get; set; }
    }
}
