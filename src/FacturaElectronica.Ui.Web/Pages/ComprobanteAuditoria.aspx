<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ComprobanteAuditoria.aspx.cs" Inherits="FacturaElectronica.Ui.Web.Pages.ComprobanteAuditoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Comprobante:&nbsp;<asp:Label ID="lblComprobante" runat="server"></asp:Label> 
    </h2>
    <h3 onclick="window.AppCommonObj.toggleVisibility('img1', 'pnlResults');" class="collapsible_panel">
        <img width="15px" height="15px" id="img1" class="imgExpand" src="/Images/icon_blockexpanded.png"
            alt="" />
        Auditor&iacute;a del Comprobante<asp:Label ID="lblCantReg" runat="server"></asp:Label><span class="clear"></span><span
            class="clear"></span>
    </h3>
    <asp:Panel ID="pnlResults" CssClass="editionContainerForGrid" runat="server" ClientIDMode="Static">
        <asp:GridView ID="Grid" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
            PageSize="15" AutoGenerateColumns="False" Width="100%" AllowPaging="True"
            OnPageIndexChanging="Grid_PageIndexChanging" OnRowCommand="Grid_RowCommand" OnRowDataBound="Grid_RowDataBound">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                 <asp:BoundField DataField="Fecha" HeaderText="Fecha" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="Left" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="UsuarioNombre" HeaderText="Modificado Por" HeaderStyle-HorizontalAlign="Left" 
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="CampoModificado" HeaderText="Campo" HeaderStyle-HorizontalAlign="Left" 
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="ValorAnterior" HeaderText="Valor Anterior" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="Left" />
                     <asp:BoundField DataField="ValorNuevo" HeaderText="Valor Nuevo" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="Left" />
               
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
                    No existen registros</p>
            </EmptyDataTemplate>
        </asp:GridView>
    </asp:Panel>
    <br />
    <asp:Button ID="btnVolverNuevo" CssClass="btn" runat="server" Text="Volver" ClientIDMode="Static"
        OnClick="btnVolver_Click" />
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

