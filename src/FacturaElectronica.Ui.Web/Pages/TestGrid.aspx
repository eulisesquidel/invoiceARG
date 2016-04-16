<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestGrid.aspx.cs" Inherits="FacturaElectronica.Ui.Web.Pages.TestGrid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlResults" CssClass="editionContainerForGrid" runat="server" ClientIDMode="Static">
        <a id="A1" href="javascript:void()" onclick="window.CustomerSearchObj.showDialogCmd(); return false;"
            class="lnkCmd" runat="server">
            <asp:Literal ID="Literal23" runat="server" Text="Bo.SearchContacto.AplicarOperacionMasiva" /></a>
        <a class="aconfigurarColumnas" onclick="javascript:$('#sorteableColumnsDiv').dialog('open');"
            href="javascript:void();">
            <asp:Literal ID="Literal24" runat="server" Text="Bo.SearchContacto.ConfigurarColumnas" /></a>
        <div class="clear">
        </div>
        <asp:ObjectDataSource ID="CustomerObjectDs" runat="server" TypeName="Web.Framework.Search.GridViewSearchObjectDataSource"
            SortParameterName="sortExpression" SelectMethod="GetObjects" SelectCountMethod="TotalNumberOfGetObjects"
            EnablePaging="True" OnObjectCreating="CustomerObjectDs_ObjectCreating" OnSelected="GridCustomer_Selected">
        </asp:ObjectDataSource>
        <asp:HiddenField ID="hidCheckedRows" runat="server" ClientIDMode="Static" />
        <asp:GridView ID="GridCustomer" runat="server" CellPadding="4" ForeColor="#333333"
            DataSourceID="" ViewStateMode="Disabled" GridLines="None" AutoGenerateColumns="False"
            DataKeyNames="Id" Width="100%" AllowPaging="True" PageSize="15" OnPageIndexChanging="GridCustomer_PageIndexChanging"
            OnRowCommand="GridCustomer_RowCommand" OnRowDataBound="GridCustomer_RowDataBound"
            AllowSorting="True" OnSorting="GridCustomer_Sorting" OnRowCreated="GridCustomer_RowCreated"
            OnDataBound="GridCustomer_DataBound">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" HeaderStyle-HorizontalAlign="Center"
                    HeaderStyle-Width="30px" Visible="false" />
                <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre de Usuario" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:TemplateField HeaderText="Editar">
                    <HeaderStyle HorizontalAlign="Center" Width="40px" />
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="~/Images/editar.png" CommandName="editar"
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cambiar Password">
                    <HeaderStyle HorizontalAlign="Center" Width="40px" />
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:ImageButton ID="btnPassword" runat="server" ImageUrl="~/Images/key.gif" CommandName="password"
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Eliminar">
                    <HeaderStyle HorizontalAlign="Center" Width="40px" />
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
            <HeaderStyle BackColor="#4b6c9e" Font-Bold="True" ForeColor="White" HorizontalAlign="Left"
                CssClass="gridSortingHeader" />
            <PagerStyle BackColor="#4b6c9e" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" CssClass="gridSortingHeader" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" CssClass="gridSortingHeader" />
        </asp:GridView>
        <a id="lnkWizardCmd" href="javascript:void()"
            class="lnkCmd" runat="server">
            <asp:Literal ID="Literal25" runat="server" Text="Bo.SearchContacto.AplicarOperacionMasiva" /></a>
    </asp:Panel>
</asp:Content>
