using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacturaElectronica.Common.Services;
using FacturaElectronica.Business.Services;

namespace FacturaElectronica.Ui.Web.Code
{
    public static class ServiceFactory
    {
        public static ISeguridadService GetSecurityService()
        {
            return new SeguridadService();
        }

        public static IComprobanteService GetComprobanteService()
        {
            return new ComprobanteService();
        }

        public static IClienteService GetClienteService()
        {
            return new ClienteService();
        }

        public static IMensajeService GetMensajeService()
        {
            return new MensajeService();
        }
    }
}