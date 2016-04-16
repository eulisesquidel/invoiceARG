<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="UsuariosDetalle.aspx.cs" Inherits="FacturaElectronica.Ui.Web.Pages.UsuariosDetalle" %>

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
        Detalle Usuarios
    </h2>
    <div class="editionContainerFilter">
        <div class="clear">
        </div>
        <asp:ValidationSummary ID="valSumm" runat="server" CssClass="failureNotification"
            ShowSummary="true" HeaderText="Se han encontrado los siguientes errores:" DisplayMode="BulletList" />
        <br />
        <p>
            <span class="title2">Nombre Usuario:</span>
            <asp:TextBox ID="txtNombre" runat="server" Width="200px" MaxLength="50" CssClass="inputs"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                CssClass="failureNotification" ErrorMessage="Debe ingresar un nombre." Display="Static"
                Text="*"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="cvRazonSocial" runat="server" ControlToValidate="txtNombre"
                ErrorMessage="Debe asignar un cliente al usuario." Display="Static" Text="*"
                EnableClientScript="false" CssClass="failureNotification" OnServerValidate="cvRazonSocial_ServerValidate"></asp:CustomValidator>
        </p>
        <div class="clear">
        </div>
        <asp:Panel ID="pnlPassword" runat="server">
            <p>
                <span class="title2">Password:</span>
                <asp:TextBox ID="txtPassword" TextMode="Password" Width="200px" MaxLength="50" runat="server" CssClass="inputs"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPass" runat="server" ControlToValidate="txtPassword"
                    CssClass="failureNotification" ErrorMessage="Debe ingresar una contraseña." Display="Static"
                    Text="*"></asp:RequiredFieldValidator>
            </p>
        </asp:Panel>
        <div class="clear">
        </div>
        <asp:UpdatePanel ID="UpdatePanelCliente" runat="server">
            <ContentTemplate>
                <p>
                    <span class="title2">Rol:</span>
                    <asp:DropDownList ID="ddlRoles" runat="server" CssClass="cbo" OnSelectedIndexChanged="ddlRoles_SelectedIndexChanged"
                        AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvRoles" runat="server" ControlToValidate="ddlRoles"
                        CssClass="failureNotification" ErrorMessage="Debe seleccionar un rol." Display="Static"
                        InitialValue="-1" Text="*"></asp:RequiredFieldValidator>
                </p>
                <div class="clear">
                </div>
                <asp:Panel ID="pnlCientes" runat="server">
                    <p>
                        <span class="title2">Cliente Asignado:</span>
                        <asp:TextBox ID="txtRazonSocial" runat="server" CssClass="inputs" ReadOnly="True" Width="300px"></asp:TextBox>
                        <asp:HiddenField ID="hfClienteId" runat="server" />
                    </p>
                    <div class="clear">
                    </div>
                    <div class="editionContainerFilter">
                        <h3>
                            Asignación Cliente:</h3>
                        <p>
                            <span class="title2">Buscar por R. Social:</span>
                            <asp:TextBox ID="txtBuscarRazSoc" runat="server" CssClass="inputs"></asp:TextBox>
                            <asp:Button ID="btnBuscarCliente" CssClass="btn" runat="server" Text="Buscar" ClientIDMode="Static"
                                OnClick="btnBuscarCliente_Click" CausesValidation="False" />
                        </p>
                        <div class="clear">
                        </div>
                        <p>
                            <asp:GridView ID="Grid" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                                AutoGenerateColumns="False" DataKeyNames="Id" Width="400px" AllowPaging="True"
                                PageSize="5" OnPageIndexChanging="Grid_PageIndexChanging" OnRowCommand="Grid_RowCommand"
                                OnRowDataBound="Grid_RowDataBound">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Id" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-Width="30px" Visible="false" />
                                    <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Left" />
                                    <asp:TemplateField HeaderText="Asignar">
                                        <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEditar" CausesValidation="false" runat="server" ImageUrl="~/Images/editar.png" CommandName="asignar"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#4b6c9e" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                <PagerStyle BackColor="#4b6c9e" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                <EmptyDataTemplate>
                                    <p>
                                        No existen clientes</p>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </p>
                    </div>
                </asp:Panel>
                <div class="clear">
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div>
        <p>
            <asp:Button ID="btnAceptar" CssClass="btn" runat="server" Text="Aceptar" ClientIDMode="Static"
                OnClick="btnAceptar_Click" />
            <asp:Button ID="btnCancelar" CssClass="btn" runat="server" Text="Cancelar" ClientIDMode="Static"
                OnClick="btnCancelar_Click" CausesValidation="false" />
        </p>
    </div>
</asp:Content>
