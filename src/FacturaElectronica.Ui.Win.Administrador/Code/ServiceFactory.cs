using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacturaElectronica.Common.Services;
using FacturaElectronica.Business.Services;
using FacturaElectronica.Ui.Win.Administrador.Code.Corrida;
using FacturaElectronica.Ui.Win.Administrador.Code.Cert;

namespace FacturaElectronica.Ui.Win.Administrador.Code
{
    public static class ServiceFactory
    {
        static ServiceFactory()
        {
            CertUtil.SetCertificatePolicy();
        }

        public static IComprobanteService GetComprobanteService()
        {
            return new ComprobanteServiceProxy();
        }
       
        public static ISubidaArchivoService GetSubidaArchivoService()
        {
            return new SubidaArchivoServiceProxy();
        }

        public static IProcesoCorridaService GetProcesoCorridaService()
        {            
           return new ProcesoCorridaWcfProxy();            
        }        

        public static IMaestrosService GetMaestroService()
        {            
            return new MaestroServiceProxy();
        }

        public static IAfipWrapperService GetAfipWrapperService()
        {            
            return new AfipWrapperWcfProxy();
        }
    }
}
