using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacturaElectronica.Common.Contracts
{
    [Serializable]
    public class EstadoArchivoAsociadoDto
    {
        public long Id { get; set; }

        public string Codigo { get; set; }

        public string Descripcion { get; set; }
    }
}
