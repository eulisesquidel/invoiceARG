<%@ Page  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="MensajesAlertasClientes.aspx.cs" Inherits="FacturaElectronica.Ui.Web.Pages.MensajesAlertasClientes" %>

<%@ Register Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Mensaje:&nbsp;<asp:Label ID="lblMensaje" runat="server"></asp:Label> </h2>
    <h3 onclick="window.AppCommonObj.toggleVisibility('imgExpand', 'searchBox');" class="collapsible_panel">
        <img width="15px" height="15px" id="imgExpand" class="imgExpand" src="/Images/icon_blockexpanded.png"
            alt="" />
        Buscar Clientes<span class="clear"></span>
    </h3>
    <div class="editionContainerFilter" id="searchBox">
        <div class="clear">
        </div>
        <asp:ValidationSummary ID="valSumm" runat="server" CssClass="failureNotification"
            ShowSummary="true" HeaderText="Se han encontrado los siguientes errores:" DisplayMode="BulletList" />
        <br />
        <div class="clear">
        </div>
        <%--primero--%>
        <div class="divSearchLeft">
            <p>
                <span class="title2">CUIT Desde:</span>
                <asp:TextBox ID="txtCuitDesde" runat="server" CssClass="inputs" ClientIDMode="Static" MaxLength="11" onkeypress="AllowDigitsOnly('txtCuitDesde')"></asp:TextBox>
                <asp:CustomValidator ID="cvCuit" 
                    runat="server" 
                    ControlToValidate="txtCuitDesde"
                    EnableClientScript="true"                    
                    Text="*" 
                    Display="Static"
                    CssClass="failureNotification" 
                    ErrorMessage="Cuit Desde debe ser menor o igual al Cuit Hasta"
                    ClientValidationFunction="validarRangoCuit"></asp:CustomValidator>
            </p>
            <div class="clear">
            </div>
            <p>
                <span class="title2">Razon Social:</span>
                <asp:TextBox ID="txtRazonSocial" runat="server" Width="300px" ClientIDMode="Static"
                    CssClass="inputs"></asp:TextBox>
            </p>
            <div class="clear">
            </div>
        </div>
        <%--segundo--%>
        <div class="divSearchLeft">
            <p>
                <span class="title2 secondColumn">Hasta:</span>
                <asp:TextBox ID="txtCuitHasta" runat="server" CssClass="inputs" ClientIDMode="Static" MaxLength="11" onkeypress="AllowDigitsOnly('txtCuitHasta')"></asp:TextBox>
            </p>
            <div class="clear">
            </div>
            <p>
                <span class="title2 secondColumn">Estado:</span>
                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="cbo">
                    <asp:ListItem Value="0" Text="Todos"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Leido"></asp:ListItem>
                    <asp:ListItem Value="2" Text="No Leido"></asp:ListItem>
                </asp:DropDownList>
            </p>
            <div class="clear">
            </div>
        </div>
        <div class="clear">
        </div>
        <p>
            <asp:Button ID="btnBuscar" ClientIDMode="Static" CssClass="btn" runat="server" Text="Buscar" 
                OnClick="btnBuscar_Click" />
            <asp:Button ID="btnLimpiar" ClientIDMode="Static" CssClass="btn" runat="server" Text="Limpiar" CausesValidation="false"
                OnClick="btnLimpiar_Click" />
        </p>
        <div class="clear">
        </div>
    </div>
    <h3 onclick="window.AppCommonObj.toggleVisibility('img1', 'pnlResults');" class="collapsible_panel">
        <img width="15px" height="15px" id="img1" class="imgExpand" src="/Images/icon_blockexpanded.png"
            alt="" />
        Listado de Clientes<asp:Label ID="lblCantReg" runat="server"></asp:Label><span class="clear"></span><span
            class="clear"></span>
    </h3>
    <asp:Panel ID="pnlResults" CssClass="editionContainerForGrid" runat="server" ClientIDMode="Static">
        <asp:GridView ID="Grid" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
            PageSize="15" AutoGenerateColumns="False" Width="100%" AllowPaging="True"
            OnPageIndexChanging="Grid_PageIndexChanging" OnRowCommand="Grid_RowCommand" OnRowDataBound="Grid_RowDataBound">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Cuit" HeaderText="CUIT" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="300px"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:TemplateField HeaderText="Le&iacute;do">
                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
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
    </asp:Panel>
    <br />
    <asp:Button ID="btnVolverNuevo" CssClass="btn" runat="server" Text="Volver" ClientIDMode="Static"
        OnClick="btnVolver_Click" />
    &nbsp;
    <asp:Button ID="btnExportToExcel" Text="Exportar Datos a Excel" Width="200px" CssClass="btn"
        runat="server" OnClick="btnExportToExcel_Click" />
    <script type='text/javascript'>

        $(document).ready(function () {

            if (!window.AppCommonObj) {
                window.AppCommonObj = new AppCommon();
            }
            //                 $('input[title]').inputHints();


            window.AppCommonObj.initializeEnterKeyEvent($('#searchBox'), function () {
                __doPostBack($('#lnkBuscar').attr('aspnetid'), '');
            });
        });
    </script>
</asp:Content>
