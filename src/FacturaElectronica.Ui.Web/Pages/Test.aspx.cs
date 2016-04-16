using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FacturaElectronica.Ui.Web.Code;
using FacturaElectronica.Core.Helpers;

namespace FacturaElectronica.Ui.Web.Pages
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string salt1= SecurityHelper.CreateSalt(30);
            string hash1 = SecurityHelper.CreatePasswordHash("admin2", salt1);
            string salt = hash1.Substring(hash1.Length - 40);
            bool resultHash = salt1 == salt;
            string hash2 = SecurityHelper.CreatePasswordHash("admin2", salt);
            bool resultPass = hash1 == hash2;
        }

        protected void HideButton_Click(object sender, EventArgs e)
        {
            OptionDropDownList.Visible = !OptionDropDownList.Visible;
        }
    }
}