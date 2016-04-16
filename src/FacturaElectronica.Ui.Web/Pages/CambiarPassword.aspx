<%@ Page  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CambiarPassword.aspx.cs" Inherits="FacturaElectronica.Ui.Web.Pages.CambiarPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/Styles/GridStyle.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/jquery-ui-1.8.10.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/DirtyCheck.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script src="/Scripts/ajaxupload.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.8.10.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.8.10.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/site.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Cambiar Password
    </h2>
    <div class="editionContainerFilter">
        <div class="clear">
        </div>
        <p>
            <asp:ValidationSummary ID="valSumm" runat="server" CssClass="failureNotification"
            ShowSummary="true" HeaderText="Se han encontrado los siguientes errores:" DisplayMode="BulletList" />
        </p>
        <br />
        <p>
            <span class="title2">Nombre Usuario:</span>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="inputs" Enabled="false" Width="200px"></asp:TextBox>
        </p>
        <div class="clear">
        </div>
        <p>
            <span class="title2">Password Nueva:</span>
            <asp:TextBox ID="txtPasswordNueva" TextMode="Password" runat="server" CssClass="inputs" Width="200px" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPasswordNueva" runat="server" ControlToValidate="txtPasswordNueva" CssClass="failureNotification"
                                        ErrorMessage="Debe ingresar una contraseña." Display="Static" Text="*"></asp:RequiredFieldValidator>
        </p>
        <div class="clear">
        </div>
    </div>
    <div>
        <p>
            <asp:Button ID="btnAceptar"  CssClass="btn" runat="server" Text="Aceptar"  ClientIDMode="Static"
                onclick="btnAceptar_Click" />
            <asp:Button ID="btnCancelar" CssClass="btn" runat="server" Text="Cancelar" ClientIDMode="Static"
                onclick="btnCancelar_Click" CausesValidation="false" />
        </p>    
    </div>
</asp:Content>
