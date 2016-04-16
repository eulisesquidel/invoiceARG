using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using FacturaElectronica.Common.Contracts;
using System.Web.Security;

namespace FacturaElectronica.Ui.Web.Code.Security
{
    public class CustomIdentity : IIdentity
    {
        private FormsAuthenticationTicket _ticket;
        private long userId = 0;

        public long UserId 
        {
            get 
            {
                if (userId == 0)
                    userId = Convert.ToInt64(_ticket.UserData.Split("|".ToCharArray())[0]);

                return userId;
            } 

        }
        public long? ClientId
        {
            get
            {
                return Convert.ToInt64(_ticket.UserData.Split("|".ToCharArray())[1]);
            } 
        }


        public CustomIdentity(FormsAuthenticationTicket ticket)
        {
            _ticket = ticket;

        }

        public string AuthenticationType
        {
            get { return "Custom"; }
        }

        public bool IsAuthenticated
        {
            get { return this.UserId > 0; }
        }

        public string Name
        {
            get { return this._ticket.Name; }
        }
    }
}