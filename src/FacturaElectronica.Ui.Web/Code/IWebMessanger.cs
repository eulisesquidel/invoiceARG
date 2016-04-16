using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturaElectronica.Ui.Web.Code
{
    public interface IWebMessage
    {
        void ShowMessage(string message, WebMessageType type);

        void ShowMessage(string title, string message, WebMessageType type);
    }

    public enum WebMessageType
    {
        Warning,
        Notification,
        Error
    }
}