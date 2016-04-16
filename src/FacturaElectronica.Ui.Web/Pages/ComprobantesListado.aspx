<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ComprobantesListado.aspx.cs" Inherits="FacturaElectronica.Ui.Web.Pages.ComprobantesListado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/Styles/GridStyle.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/jquery-ui-1.8.10.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/DirtyCheck.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script src="/Scripts/ajaxupload.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.8.10.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.datepick.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.datepick-es-AR.js" type="text/javascript"></script>
    <link href="/Styles/jquery.datepick.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 onclick="window.AppCommonObj.toggleVisibility('imgExpand', 'searchBox');" class="collapsible_panel">
        <img width="15px" height="15px" id="imgExpand" class="imgExpand" src="/Images/icon_blockexpanded.png" alt="" />
        Buscar Comprobantes<span class="clear"></span>
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
                <span class="title2">Tipo Comprobante:</span>
                <asp:DropDownList ID="ddlTipoComprobante" runat="server" CssClass="cbo">
                </asp:DropDownList>
            </p>
            <div class="clear">
            </div>
            <p>
                <span class="title2">Fecha de Venc. Desde:</span>
                <asp:TextBox ID="txtFechaVencDesde" runat="server" ClientIDMode="Static" CssClass="inputs"></asp:TextBox>
                <asp:CompareValidator ID="cvFechaDesde" runat="server" Text="*" Display="Static"
                    CssClass="failureNotification" ControlToValidate="txtFechaVencDesde" ControlToCompare="txtFechaVencHasta"
                    Operator="LessThanEqual" Type="Date" ErrorMessage="Fecha Venc. Desde debe ser menor o igual a Fecha Venc. Hasta"></asp:CompareValidator>
            </p>  
            <div class="clear">
            </div>  
             <p>
                <span class="title2">Fecha de Recep. Desde:</span>
                <asp:TextBox ID="txtFechaDeRecepcionDesde" runat="server" ClientIDMode="Static" CssClass="inputs"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator2" runat="server" Text="*" Display="Static"
                    CssClass="failureNotification" ControlToValidate="txtFechaVencDesde" ControlToCompare="txtFechaDeRecepcionHasta"
                    Operator="LessThanEqual" Type="Date" ErrorMessage="Fecha Recep. Desde debe ser menor o igual a Fecha Recep. Hasta"></asp:CompareValidator>
            </p>
            <div class="clear">
            </div>       
            <p>
                <span class="title2">Mes Facturaci&oacute;n:</span>
                <asp:DropDownList ID="ddlMesFacturacion" runat="server" CssClass="cbo">
                </asp:DropDownList>
            </p>
            <div class="clear">
            </div>
            <p>
                <span class="title2">Tipo Contrato:</span>
                <asp:DropDownList ID="ddlTipoContrato" runat="server" CssClass="cbo">
                </asp:DropDownList>
            </p>
            <div class="clear">
            </div>
             <p>
                <span class="title2">Cantidad de Dias para Vencer:</span>
                <asp:TextBox ID="txtDiasAlVtoDesde" runat="server" ClientIDMode="Static" CssClass="inputs"></asp:TextBox>
                <asp:RegularExpressionValidator   ID="RegularExpressionValidator1" runat="server" ErrorMessage="Debe ingresar un número"
                 ControlToValidate="txtDiasAlVtoDesde" ValidationExpression="[0-9]*" Text="*"></asp:RegularExpressionValidator>               
            </p>
            <div class="clear">
            </div>  
        </div>
        <%--segundo--%>
        <div class="divSearchLeft">
            <p>
                <span class="title2 secondColumn">Nro. Comprobante:</span>
                <asp:TextBox ID="txtNroComprobante" MaxLength="100" runat="server" CssClass="inputs"></asp:TextBox>
            </p>
            <div class="clear">
            </div>
            <p>
                <span class="title2 secondColumn">Hasta:</span>
                <asp:TextBox ID="txtFechaVencHasta" runat="server" ClientIDMode="Static" CssClass="inputs"></asp:TextBox>
            </p>
            <div class="clear">
            </div>
             <p>
                <span class="title2 secondColumn">Hasta:</span>
                <asp:TextBox ID="txtFechaDeRecepcionHasta" runat="server" ClientIDMode="Static" CssClass="inputs"></asp:TextBox>
            </p>
            <div class="clear">
            </div>
            <p>
                <span class="title2 secondColumn">A&ntilde;o Facturaci&oacute;n:</span>
                <asp:DropDownList ID="ddlAnioFacturacion" runat="server" CssClass="cbo">
                </asp:DropDownList>
            </p>
            <div class="clear">
            </div>
            <p>
                <span class="title2 secondColumn">Estado:</span>
                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="cbo">
                </asp:DropDownList>
            </p>
            <div class="clear">
            </div>
             <p>
                <span class="title2 secondColumn">Hasta:</span>
                <asp:TextBox ID="txtDiasAlVtoHasta" runat="server" ClientIDMode="Static" CssClass="inputs"></asp:TextBox>       
                 <asp:RegularExpressionValidator   ID="RegularExpressionValidator2" runat="server" ErrorMessage="Debe ingresar un número"
                 ControlToValidate="txtDiasAlVtoHasta" ValidationExpression="[0-9]*" Text="*"></asp:RegularExpressionValidator>         
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
    <h2 onclick="window.AppCommonObj.toggleVisibility('img1', 'pnlResults');" class="collapsible_panel">
        <img width="15px" height="15px" id="img1" class="imgExpand" src="/Images/icon_blockexpanded.png"
             alt="" />
        Listado de Comprobantes<asp:Label ID="lblCantReg" runat="server"></asp:Label>
        <span class="clear"></span>
    </h2>
    <asp:Panel ID="pnlResults" CssClass="editionContainerForGrid" runat="server" ClientIDMode="Static">
        <%--  <asp:ObjectDataSource ID="CustomerObjectDs" runat="server" TypeName="Web.Framework.Search.GridViewSearchObjectDataSource"
            SortParameterName="sortExpression" SelectMethod="GetObjects" SelectCountMethod="TotalNumberOfGetObjects"
            EnablePaging="True" OnObjectCreating="CustomerObjectDs_ObjectCreating" OnSelected="Grid_Selected">
        </asp:ObjectDataSource>--%>
        <asp:GridView ID="Grid" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
            AutoGenerateColumns="False" DataKeyNames="ArchivoAsociadoId" Width="100%" AllowPaging="True" PageSize="15"
            OnPageIndexChanging="Grid_PageIndexChanging" OnRowCommand="Grid_RowCommand" OnSorting="Grid_Sorting"
            OnRowDataBound="Grid_RowDataBound">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="TipoComprobanteDescripcion" HeaderText="Tipo de Comprobante"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="NroComprobante" HeaderText="Nro. Comprobante" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="FechaDeCarga" HeaderText="Fecha de Carga" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="FechaVencimiento" HeaderText="Fecha de Vencimiento" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="FechaDeRecepcion" HeaderText="Fecha de Recepción" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:dd/MM/yyyy}"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="EstadoDescripcion" HeaderText="Estado" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderText="Factura Asociada">
                    <HeaderStyle HorizontalAlign="Left" Width="30px" />
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:ImageButton ID="imgPdf" ImageUrl="~/Images/pdf.png" Width="16px" Height="16px"
                            OnClientClick='<%# "openWindows(\"" + Eval("EstadoCodigo") + "\",\"" + Eval("ArchivoAsociadoId") + "\");" %>'
                            runat="server" CommandName="ver" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
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
                    No existen comprobantes</p>
            </EmptyDataTemplate>
        </asp:GridView>
    </asp:Panel>
    <br class="clear" />
    <asp:Button ID="btnExportToExcel" Text="Exportar Datos a Excel" Width="200px" CssClass="btn" runat="server" OnClick="btnExportToExcel_Click" />
    <script type='text/javascript'>

        $(document).ready(function () {

            if (!window.AppCommonObj) {
                window.AppCommonObj = new AppCommon();
            }

            $('#txtFechaVencDesde').datepick({ dateFormat: 'dd/mm/yyyy' });
            $('#txtFechaVencHasta').datepick({ dateFormat: 'dd/mm/yyyy' });
            $('#txtFechaDeRecepcionDesde').datepick({ dateFormat: 'dd/mm/yyyy' });
            $('#txtFechaDeRecepcionHasta').datepick({ dateFormat: 'dd/mm/yyyy' });
            $('#btnBuscar').toggleClass('bounce');

            //                 $('input[title]').inputHints();

            //                 $('#txtVigenciaDesde').datepick({ dateFormat: 'dd/mm/yyyy' });
            //                 $('#txtVigenciaHasta').datepick({ dateFormat: 'dd/mm/yyyy' });

            window.AppCommonObj.initializeEnterKeyEvent($('#searchBox'), function () {
                __doPostBack($('#lnkBuscar').attr('aspnetid'), '');
            });
        });
    </script>
</asp:Content>
