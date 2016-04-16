<%@ Page  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="MensajesAlertasDetalle.aspx.cs" Inherits="FacturaElectronica.Ui.Web.Pages.MensajesAlertasDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function checkListBoxIsEmpty(sender, args) {
            args.IsValid = document.getElementById(sender.controltovalidate).options.length > 0;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Detalle Mensajes y Alertas
    </h2>
    <div class="editionContainerFilter">
        <div class="clear">
        </div>
        <asp:ValidationSummary ID="valSumm" runat="server" CssClass="failureNotification"
            ShowSummary="true" HeaderText="Se han encontrado los siguientes errores:" DisplayMode="BulletList" />
        <br />
        <p>
            <span class="title2">Asunto:</span>
            <asp:TextBox ID="txtAsunto" runat="server" Width="500px" MaxLength="50" CssClass="inputs"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAsunto"
                CssClass="failureNotification" ErrorMessage="Debe ingresar un Asunto." Display="Static"
                Text="*"></asp:RequiredFieldValidator>
        </p>
        <div class="clear">
        </div>
        <div>
            <p style="vertical-align: top">
                <span class="title2">Mensaje:</span>
                <asp:TextBox ID="txtMensaje" CssClass="text_area" runat="server" Width="500px" Height="200px"
                    MaxLength="1000" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvMensaje" runat="server" ControlToValidate="txtMensaje"
                    CssClass="failureNotification" ErrorMessage="Debe ingresar un Mensaje." Display="Static"
                    Text="*"></asp:RequiredFieldValidator>
            </p>
        </div>
        <div class="clear">
        </div>
        <div>
            <p>
                <span class="title2">Archivo:</span>
                <asp:FileUpload ID="fileUpload" Width="500px" runat="server" CssClass="inputs" />
                <asp:Label ID="lblNoAdjunto" runat="server" Text="No tiene archivo adjunto" Visible="false"></asp:Label>
                <asp:HyperLink ID="lblNombreArchivo" runat="server" Visible="false">                                        
                    <img src="../Images/save_file.png" height="16px" width="16px" alt="Descargar" style="border:0" />    
                    Descargar
                </asp:HyperLink>
            </p>
        </div>
        <div class="clear">
        </div>
    </div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div id="pnlAsignacionClientes" runat="server">
                <h2>
                    Clientes destinatarios</h2>                   
                <div class="editionContainerFilter">
                    <br />
                    <div class="clear">
                    </div>
                    <p>                        
                        <div>
                            <div id="pnlClientes" runat="server" style="float: left">
                                <asp:ListBox ID="lbxClientes" runat="server" CssClass="lstbox" Width="400px" Height="300px"
                                    SelectionMode="Multiple"></asp:ListBox>
                                <br />
                                <span id="lblOrdenar" runat="server">Ordernar por:</span>
                                <asp:RadioButtonList ID="rblOrden" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
                                    OnSelectedIndexChanged="rblOrden_SelectedIndexChanged">
                                    <asp:ListItem Value="RAZSOC" Text="Razon Social" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="CUIT" Text="CUIT"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div id="pnlBotones" runat="server" style="float: left; padding: 0 20px 0 20px">
                                <asp:Button ID="btnAgregar" runat="server" Text=">" Width="40px" OnClick="btnAgregar_Click"
                                    CausesValidation="false" />
                                <br />
                                <asp:Button ID="btnRemover" runat="server" Text="<" Width="40px" OnClick="btnRemover_Click"
                                    CausesValidation="false" />
                                <br />
                                <asp:Button ID="btnAgregarTodos" runat="server" Text=">>" Width="40px" OnClick="btnAgregarTodos_Click"
                                    CausesValidation="false" />
                                <br />
                                <asp:Button ID="btnRemoverTodos" runat="server" Text="<<" Width="40px" OnClick="btnRemoverTodos_Click"
                                    CausesValidation="false" />
                            </div>
                            <div id="pnlClientesSeleccionados" runat="server" cssclass="lstbox" style="float: left">
                                <asp:ListBox ID="lbxClientesSeleccionados" runat="server" Width="400px" Height="300px"
                                    SelectionMode="Multiple"></asp:ListBox>
                            </div>
                            <asp:CustomValidator ID="cvClientes" runat="server" Text="*" ControlToValidate="lbxClientesSeleccionados"
                                ErrorMessage="Debe seleccionar al menos 1 cliente como destinatario." CssClass="failureNotification"
                                ClientValidationFunction="checkListBoxIsEmpty" ValidateEmptyText="true"></asp:CustomValidator>
                        </div>
                    </p>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="clear">
    </div>
    <div>
        <p>
            <asp:Button ID="btnAceptar" CssClass="btn" runat="server" Text="Aceptar" OnClick="btnAceptar_Click"
                ClientIDMode="Static" />
            <asp:Button ID="btnCancelar" CssClass="btn" runat="server" Text="Cancelar" CausesValidation="false"
                OnClick="btnCancelar_Click" ClientIDMode="Static" />
            <asp:Button ID="btnVolver" CssClass="btn" runat="server" Text="Volver" CausesValidation="false"
                 ClientIDMode="Static" Visible="False" onclick="btnVolver_Click" />
        </p>
        <div class="clear">
        </div>
    </div>
</asp:Content>
