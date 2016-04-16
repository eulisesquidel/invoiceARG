using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacturaElectronica.Common.Services;
using FacturaElectronica.Ui.Web.Code;
using FacturaElectronica.Ui.Web.Code.Security;

namespace FacturaElectronica.Ui.Web.Handlers
{
    /// <summary>
    /// Summary description for PdfHandler
    /// </summary>
    public class PdfHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse r = context.Response;            
            long archivoId = Convert.ToInt64(context.Request.QueryString["file"].ToString());
            
            // Obtengo el path del archivo de la DB
            string file = ObtenerArchivo(context, archivoId);

            if (!string.IsNullOrEmpty(file))
            {
                if (System.IO.File.Exists(file))
                {
                    try
                    {
                        r.ContentType = "application/pdf";
                        //r.AppendHeader("Content-Disposition", "attachment; filename=Comprobante.pdf");
                        r.TransmitFile(file);
                        r.End();
                    }
                    catch
                    {

                    }
                }
                else
                {
                    r.Redirect("~/Error.aspx");
                }
            }
        }

        private static string ObtenerArchivo(HttpContext context, long archivoId)
        {
            CustomPrincipal principal = context.User as CustomPrincipal;
            CustomIdentity identity = principal.Identity as CustomIdentity;

            IComprobanteService svc = ServiceFactory.GetComprobanteService();
            string file = string.Empty;
            if (principal.IsInRole(Roles.Administrador))
                file = svc.ObtenerArchivo(archivoId);
            else if (principal.IsInRole(Roles.Cliente))
                file = svc.ObtenerArchivo(archivoId, identity.ClientId.Value);
            return file;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}