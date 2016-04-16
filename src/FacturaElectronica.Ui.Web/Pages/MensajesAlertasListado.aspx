<%@ Page  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="MensajesAlertasListado.aspx.cs" Inherits="FacturaElectronica.Ui.Web.Pages.MensajesAlertasListado" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 onclick="window.AppCommonObj.toggleVisibility('imgSearch', 'searchBox');" class="collapsible_panel">
        <img width="15px" height="15px" id="imgSearch" class="imgExpand" src="/Images/icon_blockexpanded.png"
            alt="" />
        Buscar Mensajes y Alertas
    </h2>
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
                <span class="title2">Fecha de Carga Desde:</span>
                <asp:TextBox ID="txtFechaDeCargaDesde" runat="server" ClientIDMode="Static" CssClass="inputs"></asp:TextBox>
                <asp:CompareValidator ID="cvFechaDesde" runat="server" Text="*" Display="Static"
                    CssClass="failureNotification" ControlToValidate="txtFechaDeCargaDesde" ControlToCompare="txtFechaDeCargaHasta"
                    Operator="LessThanEqual" Type="Date" ErrorMessage="Fecha Venc. Desde debe ser menor o igual a Fecha Venc. Hasta"></asp:CompareValidator>
            </p>  
            <div class="clear">
            </div>         
            <p>
                <span class="title2">Asunto:</span>
                <asp:TextBox ID="txtAsunto" runat="server" CssClass="inputs" MaxLength="50"></asp:TextBox>
            </p>
            <div class="clear">
            </div>
        </div>
        <%--segundo--%>
        <div class="divSearchLeft">
            <p>
                <span class="title2 secondColumn">Hasta:</span>
                <asp:TextBox ID="txtFechaDeCargaHasta" runat="server" ClientIDMode="Static" CssClass="inputs"></asp:TextBox>
            </p>
            <div class="clear">
            </div>
        </div>
        <div class="clear">
        </div>
        <p>
            <asp:Button ID="btnBuscar" ClientIDMode="Static" CssClass="btn" runat="server" Text="Buscar"
                OnClick="btnBuscar_Click" />
            <asp:Button ID="btnLimpiar" ClientIDMode="Static" CssClass="btn" runat="server" Text="Limpiar"
                OnClick="btnLimpiar_Click" CausesValidation="false" />
        </p>
        <div class="clear">
        </div>
    </div>
    <h2 onclick="window.AppCommonObj.toggleVisibility('img2', 'pnlResults');" class="collapsible_panel">
        <img width="15px" height="15px" id="img2" class="imgExpand" src="/Images/icon_blockexpanded.png"
            alt="" />
        Listado de mensajes y alertas<asp:Label ID="lblCantReg" runat="server"></asp:Label><span class="clear"></span><span
            class="clear"></span>
    </h2>
    <asp:Panel ID="pnlResults" CssClass="editionContainerForGrid" runat="server" ClientIDMode="Static">
        <asp:GridView ID="Grid" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
            PageSize="15" AutoGenerateColumns="False" DataKeyNames="Id" Width="100%" AllowPaging="True"
            OnPageIndexChanging="Grid_PageIndexChanging" 
            OnRowCommand="Grid_RowCommand" onrowdatabound="Grid_RowDataBound">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="FechaDeCarga" HeaderText="Fecha de Carga" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" DataFormatString="{0: dd/MM/yyyy hh:mm:ss tt}" ItemStyle-Width = "20%" />
                <asp:BoundField DataField="Asunto" HeaderText="Asunto" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="Texto" HeaderText="Mensaje" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="Leido" HeaderText="Le&iacute;do" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderText="Le&iacute;do" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center"></asp:TemplateField>
                <asp:TemplateField HeaderText="Clientes">
                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:ImageButton ID="btnClientes" runat="server" ImageUrl="~/Images/clientes.png" CommandName="clientes"
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ver">
                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:ImageButton ID="btnVer" runat="server" ImageUrl="~/Images/viewItem.png" CommandName="ver"
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Eliminar">
                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/Images/eliminar.png"
                            CommandName="eliminar" OnClientClick="return confirm('Esta seguro que desea eliminar el registro?');"
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
                    No existen mensajes y alertas</p>
            </EmptyDataTemplate>
        </asp:GridView>
    </asp:Panel>
    <br />
    <asp:Button ID="btnAgregarNuevo" CssClass="btn" runat="server" Text="Agregar" ClientIDMode="Static"
        OnClick="btnAgregarNuevo_Click" />
    &nbsp;
    <asp:Button ID="btnExportToExcel" Text="Exportar Datos a Excel" Width="200px" CssClass="btn"
        runat="server" OnClick="btnExportToExcel_Click" />
    <script type='text/javascript'>

        $(document).ready(function () {

            if (!window.AppCommonObj) {
                window.AppCommonObj = new AppCommon();
            }

            $('#txtFechaDeCargaDesde').datepick({ dateFormat: 'dd/mm/yyyy' });
            $('#txtFechaDeCargaHasta').datepick({ dateFormat: 'dd/mm/yyyy' });
            $('#btnBuscar').toggleClass('bounce');

            window.AppCommonObj.initializeEnterKeyEvent($('#searchBox'), function () {
                __doPostBack($('#lnkBuscar').attr('aspnetid'), '');
            });
        });
    </script>
</asp:Content>
