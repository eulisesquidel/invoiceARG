using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace FacturaElectronica.Ui.Web.Code
{
    public class BasePage : System.Web.UI.Page, IWebMessage
    {
        protected BaseMasterPage BaseMaster
        {
            get
            {
                return (BaseMasterPage) this.Master;
            }

        }

        protected void HasPermissionToSeeMe(Operaciones operacion)
        {
            this.BaseMaster.HasPermissionToSeeMe(operacion);
        }
        
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            ExceptionManager.Instance.WebMessager = this.Master as IWebMessage;
        }       

        public void ShowMessage(string message, WebMessageType type)
        {
            SiteMaster main = (SiteMaster)this.Master;
            main.ShowMessage(message, type);
        }

        public void ShowMessage(string title, string message, WebMessageType type)
        {
            SiteMaster main = (SiteMaster)this.Master;
            main.ShowMessage(title, message, type);
        }

        protected void SignOut()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}