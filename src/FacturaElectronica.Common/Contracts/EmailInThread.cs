using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacturaElectronica.Common.Contracts
{
    public class EmailInThread
    {
        public long CorridaId { get; set; }

        public long Cuit { get; set; }

        public string Email { get; set; }

        public string ConnectionString { get; set; }

        public EmailConfiguration Configuration { get; set; }

    }
}
