using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacturaElectronica.Common.Contracts
{
    [Serializable]
    public class MensajeDto
    {
        public long Id { get; set; }

        public string Asunto { get; set; }

        public string NombreArchivo { get; set; }
        
        public string Path { get; set; }

        public string Texto { get; set; }

        public DateTime FechaDeCarga { get; set; }

        public bool Leido { get; set; }

        public int MensajesLeidos { get; set; }

        public int CantClientes { get; set; }

        public List<ClienteDto> Clientes { get; set; }
    }
}
