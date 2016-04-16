using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Security.Principal;
using FacturaElectronica.Ui.Web.Code.Security;
using System.Threading;

namespace FacturaElectronica.Ui.Web
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

        void Application_OnPostAuthenticateRequest(object sender, EventArgs e)
        {

            // Get a reference to the current User
            IPrincipal usr = HttpContext.Current.User;
            // If we are dealing with an authenticated forms authentication request

            if (usr.Identity.IsAuthenticated && usr.Identity.AuthenticationType == "Forms")
            {
                FormsIdentity fIdent = usr.Identity as FormsIdentity;
                // Create a CustomIdentity based on the FormsAuthenticationTicket  
                CustomIdentity ci = new CustomIdentity(fIdent.Ticket);
                // Create the CustomPrincipal
                CustomPrincipal p = new CustomPrincipal(ci);
                // Attach the CustomPrincipal to HttpContext.User and Thread.CurrentPrincipal
                HttpContext.Current.User = p;
                Thread.CurrentPrincipal = p;
            }
        }
    }
}
