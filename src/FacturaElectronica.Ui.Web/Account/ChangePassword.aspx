<%@ Page  Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="FacturaElectronica.Ui.Web.Account.ChangePassword" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Cambiar Contrase&ntilde;a
    </h2>
    <p>
        Use el formulario para cambiar su contrase&ntilde;a.
    </p>
    <span class="failureNotification">
        <asp:Literal ID="FailureText" runat="server"></asp:Literal>
    </span>
    <asp:ValidationSummary ID="ChangeUserPasswordValidationSummary" runat="server" CssClass="failureNotification"
        ValidationGroup="ChangeUserPasswordValidationGroup" />
    <div class="accountInfo">
        <fieldset class="changePassword">
            <legend>Informaci&oacute;n de cuenta</legend>
            <p>
                <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">Contrase&ntilde;a Anterior:</asp:Label>
                <asp:TextBox ID="CurrentPassword" runat="server" CssClass="passwordEntry" 
                    TextMode="Password" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                    CssClass="failureNotification" ErrorMessage="Contrase&ntilde;a Anterior es requerida." ToolTip="Contrase&ntilde;a Anterior es requerida"
                    ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">Nueva Contrase&ntilde;a:</asp:Label>
                <asp:TextBox ID="NewPassword" runat="server" CssClass="passwordEntry" 
                    TextMode="Password" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                    CssClass="failureNotification" ErrorMessage="Nueva Contrase&ntilde;a es requerida." ToolTip="Nueva Contrase&ntilde;a es requerida."
                    ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirmar Nueva Contrase&ntilde;a:</asp:Label>
                <asp:TextBox ID="ConfirmNewPassword" runat="server" CssClass="passwordEntry" 
                    TextMode="Password" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                    CssClass="failureNotification" Display="Dynamic" ErrorMessage="Confirmar Nueva Contrase&ntilde;a es requerida."
                    ToolTip="Confirmar Nueva Contrase&ntilde;a es requerida." ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                    ControlToValidate="ConfirmNewPassword" CssClass="failureNotification" Display="Dynamic"
                    ErrorMessage="Confirmar Nueva Contrase&ntilde;a debe coincidir con Nueva Contrase&ntilde;a." ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:CompareValidator>
            </p>
        </fieldset>
        <p class="submitButton">
            <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword" CssClass="btn" Width="150px"
                Text="Cambiar Contrase&ntilde;a" ValidationGroup="ChangeUserPasswordValidationGroup" OnClick="ChangePasswordPushButton_Click" />
        </p>
    </div>
</asp:Content>
