using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacturaElectronica.Ui.Web.Code.Security;
using FacturaElectronica.Common.Services;
using FacturaElectronica.Ui.Web.Code;
using FacturaElectronica.Common.Contracts;
using System.IO;

namespace FacturaElectronica.Ui.Web.Handlers
{
    /// <summary>
    /// Summary description for FileHandler
    /// </summary>
    public class FileHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse r = context.Response;
            long mensajeId = Convert.ToInt64(context.Request.QueryString["file"].ToString());

            // Obtengo el path del archivo de la DB
            MensajeDto mensaje = ObtenerMensaje(context, mensajeId);
            string filePath = mensaje.Path;

            if (!string.IsNullOrEmpty(filePath))
            {
                if (System.IO.File.Exists(filePath))
                {
                    try
                    {
                        r.AppendHeader("Content-Disposition", "attachment; filename=Mensaje_ArchivoAdjunto" + Path.GetExtension(filePath));
                        r.TransmitFile(filePath);
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

        private static MensajeDto ObtenerMensaje(HttpContext context, long mensajeId)
        {
            CustomPrincipal principal = context.User as CustomPrincipal;
            CustomIdentity identity = principal.Identity as CustomIdentity;

            IMensajeService svc = ServiceFactory.GetMensajeService();
            MensajeDto mensaje = null;
            if (principal.IsInRole(Roles.Administrador) || principal.IsInRole(Roles.Cliente))
            {
                mensaje = svc.ObtenerMensaje(mensajeId);
            }
            return mensaje;
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