using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacturaElectronica.Common.Contracts
{
    [Serializable]
    public class EstadoComprobantesDto
    {
        public int Visualizados { get; set; }

        public int NoVisualizados { get; set; }

        public int NoVisualizadosVencidos { get; set; }
        
        public int TotalComprobantes { get; set; }
    }
}
