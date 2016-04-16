using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FacturaElectronica.Common.Services;
using FacturaElectronica.Ui.Web.Code;
using FacturaElectronica.Core.Helpers;
using System.Web.Security;

namespace FacturaElectronica.Ui.Web.Account
{
    public partial class ChangePassword : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
        {
            try
            {
                string passwordActual = this.CurrentPassword.Text.Trim();
                string passwordNueva = this.NewPassword.Text.Trim();

                ISeguridadService seguridadService = ServiceFactory.GetSecurityService();
                seguridadService.CambiarPassword(this.BaseMaster.UserName, passwordActual, passwordNueva);
                ShowMessage("Los datos fueron grabados con éxito", WebMessageType.Notification);
                this.SignOut();
            }
            catch (Exception ex)
            {
                CustomValidator validator = new CustomValidator();
                validator.IsValid = false;
                validator.ValidationGroup = "ChangeUserPasswordValidationGroup";
                validator.Text = "*";
                validator.ControlToValidate = "CurrentPassword";
                validator.ErrorMessage = ex.Message;
                this.Validators.Add(validator);
            }
        }
    }
}
