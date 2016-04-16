<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ClienteDetalle.aspx.cs" Inherits="FacturaElectronica.Ui.Web.Pages.ClienteDetalle" %>

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
        <asp:Label ID="lblTituloPagina" runat="server" Text="Detalle Cliente"></asp:Label>
    </h2>
    <div class="editionContainerFilter">
        <div class="clear">
        </div>
        <asp:ValidationSummary ID="valSumm" runat="server" CssClass="failureNotification"
            ShowSummary="true" HeaderText="Se han encontrado los siguientes errores:" DisplayMode="BulletList" />
        <br />        
        <p>
            <span class="title2">Razon Social:</span>
            <asp:TextBox ID="txtRazonSocial" Width="500px" MaxLength="200" runat="server" CssClass="inputs"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvRazonSocial" runat="server" ControlToValidate="txtRazonSocial" CssClass="failureNotification"
                ErrorMessage="Debe ingresar la Razon Social." Display="Static" Text="*"></asp:RequiredFieldValidator>
        </p>
        <div class="clear">
        </div>
        <p>
            <span class="title2">CUIT:</span>
            <asp:TextBox ID="txtCuit" runat="server" CssClass="inputs" Height="22px" 
                MaxLength="11"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCuit" runat="server" ControlToValidate="txtCuit" CssClass="failureNotification"
                ErrorMessage="Debe ingresar el CUIT." Display="Static" Text="*"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="cvCuit" runat="server" ControlToValidate="txtCuit" ErrorMessage="El CUIT es invalido"
                Display="Static" Text="*" EnableClientScript="false" CssClass="failureNotification"
                onservervalidate="cvCuit_ServerValidate"></asp:CustomValidator>
            <asp:CustomValidator ID="cvCUITExistente" runat="server" ControlToValidate="txtCuit" ErrorMessage="Ya existe un cliente con el CUIT ingresado"
                Display="Static" Text="*" EnableClientScript="false" CssClass="failureNotification"
                onservervalidate="cvCuitExistente_ServerValidate"></asp:CustomValidator>
        </p>
        <div class="clear">
        </div>        
        <fieldset>
        
            <legend>Datos Contacto</legend>
        
            <p>
                <span class="title2">Nombre:</span>
                <asp:TextBox ID="txtNombreContacto" Width="300px" MaxLength="100" runat="server" CssClass="inputs"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombreContacto" runat="server" ControlToValidate="txtNombreContacto" CssClass="failureNotification"
                    ErrorMessage="Debe ingresar el Nombre del Contacto." Display="Static" Text="*"></asp:RequiredFieldValidator>
            </p>
            <p>
                <span class="title2 secondColumn">Apellido:</span>
                <asp:TextBox ID="txtApellidoContacto" Width="300px" MaxLength="100" runat="server" CssClass="inputs"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvApellidoContacto" runat="server" ControlToValidate="txtApellidoContacto" CssClass="failureNotification"
                    ErrorMessage="Debe ingresar el Apellido del Contacto." Display="Static" Text="*"></asp:RequiredFieldValidator>
            </p>
            <div class="clear">
            </div>
            <p>
                <span class="title2">Email:</span>
                <asp:TextBox ID="txtEmailContacto" Width="300px" MaxLength="100" runat="server" CssClass="inputs"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmailContacto" runat="server" ControlToValidate="txtEmailContacto" CssClass="failureNotification"
                    ErrorMessage="Debe ingresar el Email del Contacto." Display="Static" Text="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmailContacto" runat="server" ControlToValidate="txtEmailContacto" CssClass="failureNotification"
                    ErrorMessage="Debe ingresar un Email de Contacto valido." ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Text="*">
                </asp:RegularExpressionValidator>
            </p>
            <div class="clear">
            </div>
       
        </fieldset>
        <div class="clear">
        </div>
        <fieldset>
            <legend>Datos Contacto Secundario</legend>
        
            <p>
                <span class="title2">Nombre:</span>
                <asp:TextBox ID="txtNombreContactoSecundario" Width="300px" MaxLength="100" runat="server" CssClass="inputs"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombreContactoSecundario" runat="server" ControlToValidate="txtNombreContactoSecundario"
                    ErrorMessage="Debe ingresar el Nombre de Contacto Secundario." Display="Static" CssClass="failureNotification"
                    Text="*"></asp:RequiredFieldValidator>
            </p>
            <p>
                <span class="title2 secondColumn">Apellido:</span>
                <asp:TextBox ID="txtApellidoContactoSecundario" Width="300px" MaxLength="100" runat="server" CssClass="inputs"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvApellidoContactoSecundario" runat="server" ControlToValidate="txtApellidoContactoSecundario"
                    ErrorMessage="Debe ingresar el Apellido del Contacto Secundario." Display="Static" CssClass="failureNotification"
                    Text="*"></asp:RequiredFieldValidator>
            </p>
            <div class="clear">
            </div>
            <p>
                <span class="title2">Email:</span>
                <asp:TextBox ID="txtEmailContactoSecundario" Width="300px" MaxLength="100" runat="server" CssClass="inputs"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmailContactoSecundario" runat="server" ControlToValidate="txtEmailContactoSecundario"
                    ErrorMessage="Debe ingresar el Email del Contacto Secundario." Display="Static" CssClass="failureNotification"
                    Text="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmailContactoSecundario" runat="server" ControlToValidate="txtEmailContactoSecundario" CssClass="failureNotification"
                    ErrorMessage="Debe ingresar un Email de Contacto Secundario valido." ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Text="*">
                </asp:RegularExpressionValidator>
            </p>
            <div class="clear">
            </div>
        </fieldset>
        <br />
        <div class="clear">
        </div>
        <p>
            <span class="title2">Calcula Vencimiento con Visualización de PDF?:</span>
            <asp:CheckBox ID="chkCalculaVencimientoConVisualizacionDoc" runat="server" Checked="False" />            
        </p>
        <div class="clear">
           </div>
    </div>
    <asp:Panel ID="pnlUsuario" runat="server" Visible="false">
        <h2>
            Usuario Asociado</h2>
        <div class="editionContainerFilter">
            <p>
                <span class="title2">Usuario:</span>
                <asp:TextBox ID="txtNombreUsuario" Width="300px" runat="server" CssClass="inputs" Enabled="false"></asp:TextBox>
            </p>
            <div class="clear">
            </div>
        </div>
         
    </asp:Panel>
    
     
  <div>
   
        <p>        
            <asp:Button ID="btnAceptar" CssClass="btn" runat="server" Text="Aceptar" OnClick="btnAceptar_Click"
                ClientIDMode="Static" />
            <asp:Button ID="btnCancelar" CssClass="btn" runat="server" Text="Cancelar" CausesValidation="false" OnClick="btnCancelar_Click"
                ClientIDMode="Static" />
                <asp:Button ID="btnVerAuditoria" CssClass="btn btnwidther" runat="server" Text="Ver Auditoría" CausesValidation="false" OnClick="btnVerAuditoria_Click"
                ClientIDMode="Static" />
        </p>
        <div class="clear">
        </div>
    </div>
</asp:Content>
