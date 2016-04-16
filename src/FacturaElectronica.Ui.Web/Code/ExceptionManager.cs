using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturaElectronica.Ui.Web.Code
{
    public class ExceptionManager
    {
        public static ExceptionManager Instance
        {
            get
            {
                return privateInstance;
            }
        }

        private static ExceptionManager privateInstance = new ExceptionManager();

        public IWebMessage WebMessager { get; set; }

        public void HandleException(Exception ex)
        {
            if (WebMessager != null)
            {
                WebMessager.ShowMessage(ex.Message, WebMessageType.Error);
            }
        }

        public void ShowMessage(string message)
        {
            if (WebMessager != null)
            {
                WebMessager.ShowMessage(message, WebMessageType.Notification);
            }
        }
    }
}