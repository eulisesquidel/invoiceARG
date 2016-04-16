<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ReporteComprobantes.aspx.cs" Inherits="FacturaElectronica.Ui.Web.Pages.ReporteComprobantes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript">
        function openPdf(file) {
            w = $(window).width();
            h = $(window).height();
            window.open("../Handlers/PdfHandler.ashx?file=" + file, 'blank', 'width=' + w + ',height=' + h + ',top=0,left=0');

            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 onclick="window.AppCommonObj.toggleVisibility('img1', 'searchBox');" class="collapsible_panel">
        <img width="15px" height="15px" id="img1" class="imgExpand" src="/Images/icon_blockexpanded.png"
            alt="" />
        Buscar Comprobantes<span class="clear"></span>
    </h2>
    <div class="editionContainerFilter" id="searchBox">
        <div class="clear">
        </div>
        <asp:ValidationSummary ID="valSumm" runat="server" CssClass="failureNotification"
            ShowSummary="true" HeaderText="Se han encontrado los siguientes errores:" DisplayMode="BulletList" />
        <br />
        <p>
            <span class="title2">Razon Social:</span>
            <asp:TextBox ID="txtRazonSocial" runat="server" CssClass="inputs" Width="470px" MaxLength="200"></asp:TextBox>
        </p>
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
                <span class="title2">Fecha de Carga Desde:</span>
                <asp:TextBox ID="txtFechaDeCargaDesde" runat="server" ClientIDMode="Static" CssClass="inputs"></asp:TextBox>
                <asp:CompareValidator ID="cvFechaDesde" runat="server" Text="*" Display="Static"
                    CssClass="failureNotification" ControlToValidate="txtFechaDeCargaDesde" ControlToCompare="txtFechaDeCargaHasta"
                    Operator="LessThanEqual" Type="Date" ErrorMessage="Fecha Carga Desde debe ser menor o igual a Fecha Carga Hasta"></asp:CompareValidator>
            </p>
            <div class="clear">
            </div>
            <p>
                <span class="title2">Fecha de Venc. Desde:</span>
                <asp:TextBox ID="txtFechaVencDesde" runat="server" ClientIDMode="Static" CssClass="inputs"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" Text="*" Display="Static"
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
                <span class="title2">Mes Facturaci&oacute;n</span>
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
                <span class="title2">Monto Total Desde:</span>
                <asp:TextBox ID="txtMontoTotalDesde" runat="server" ClientIDMode="Static" CssClass="inputs"></asp:TextBox>
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
            <p>
                <span class="title2">Estado:</span>
                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="cbo">
                </asp:DropDownList>
            </p>
            <div class="clear">
            </div>   
            <p>
                <span class="title2">S&oacute;lo Docs. con "NN días":</span>
                <asp:CheckBox ID="chkSoloDocsConNDias" runat="server" />
            </p>
            <div class="clear">
            </div>         
        </div>
        <div class="divSearchLeft">
            <p>
                <span class="title2 secondColumn">Nro. Comprobante:</span>
                <asp:TextBox ID="txtNroComprobante" runat="server" MaxLength="100" CssClass="inputs"></asp:TextBox>
            </p>
            <div class="clear">
            </div>
            <p>
                <span class="title2 secondColumn">Hasta:</span>
                <asp:TextBox ID="txtFechaDeCargaHasta" runat="server" ClientIDMode="Static" CssClass="inputs"></asp:TextBox>
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
                <span class="title2 secondColumn">A&ntilde;o Facturaci&oacute;n</span>
                <asp:DropDownList ID="ddlAnioFacturacion" runat="server" CssClass="cbo">
                </asp:DropDownList>
            </p>
            <div class="clear">
            </div>
            <p>
                <span class="title2 secondColumn">Documentos Vencidos:</span>
                <asp:CheckBox ID="chkDocumentosVencidos" runat="server" CssClass="chk"></asp:CheckBox>
            </p>
            <div class="clear">
            </div>
            <div class="clear">
            </div>
            <p>
                <span class="title2 secondColumn">Hasta:</span>
                <asp:TextBox ID="txtMontoTotalHasta" runat="server" ClientIDMode="Static" CssClass="inputs"></asp:TextBox>
            </p>
            <div class="clear">
            </div>  
             <p>
                <span class="title2 secondColumn">Hasta:</span>
                <asp:TextBox ID="txtDiasAlVtoHasta" runat="server" ClientIDMode="Static" CssClass="inputs"></asp:TextBox>                
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
                OnClick="btnLimpiar_Click" />
        </p>
        <div class="clear">
        </div>
    </div>
    <h2 onclick="window.AppCommonObj.toggleVisibility('imgExpand', 'pnlResults');" class="collapsible_panel">
        <img width="15px" height="15px" id="imgExpand" class="imgExpand" src="/Images/icon_blockexpanded.png"
            alt="" />
        Listado de Comprobantes<asp:Label ID="lblCantReg" runat="server"></asp:Label>
    </h2>
    <asp:Panel ID="pnlResults" CssClass="editionContainerForGrid" runat="server" ClientIDMode="Static">
        <asp:GridView ID="Grid" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
            PageSize="15" AutoGenerateColumns="False" DataKeyNames="ArchivoAsociadoId" Width="100%"
            AllowPaging="True" OnPageIndexChanging="Grid_PageIndexChanging" OnRowCommand="Grid_RowCommand"
            OnRowDataBound="Grid_RowDataBound">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ClienteRazonSocial" HeaderText="Razon Social" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="TipoComprobanteDescripcion" HeaderText="Tipo de Comprobante"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="NroComprobante" HeaderText="Nro. Comprobante" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="FechaDeCarga" HeaderText="Fecha de Carga" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" DataFormatString="{0: dd/MM/yyyy hh:mm:ss tt}" />
                <asp:BoundField DataField="FechaVencimiento" HeaderText="Fecha de Vencimiento" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="FechaVisualizacion" HeaderText="Fecha de Visualizaci&oacute;n"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="{0: dd/MM/yyyy hh:mm:ss tt}" />
                <asp:BoundField DataField="DireccionIp" HeaderText="Direccion Ip" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="EstadoDescripcion" HeaderText="Estado" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="MontoTotal" HeaderText="Monto Total" HeaderStyle-HorizontalAlign="Center"
                    DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderText="Fecha de Recepción">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Panel ID="pnlFechaRecepción" runat="server">                                                    
                            <script type="text/javascript">
                                $(function () {
                                    $('#txtFechaDeRecepcion_<%#Eval("ArchivoAsociadoId") %>').datepick({ dateFormat: 'dd/mm/yyyy', maxDate: new Date() });
                                    $('#txtFechaDeRecepcion_<%#Eval("ArchivoAsociadoId") %>').attr('name', 'txtFechaDeRecepcion_<%#Eval("ArchivoAsociadoId") %>');
                                });                            
                            </script>
                        </asp:Panel>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Factura Asociada">
                    <HeaderStyle HorizontalAlign="Left" Width="30px" />
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:ImageButton ID="imgPdf" ImageUrl="~/Images/pdf.png" Width="16px" Height="16px"
                            OnClientClick='<%# "openPdf(\"" + Eval("ArchivoAsociadoId") + "\");" %>' runat="server"
                            CommandName="ver" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Borrar Comprobante">
                    <HeaderStyle HorizontalAlign="Center" Width="30px" />
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/Images/eliminar.png"
                            CommandName="eliminar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                            OnClientClick="return confirm('Esta seguro que desea eliminar el registro?');" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Auditoría">
                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:ImageButton ID="btnVer" runat="server" ImageUrl="~/Images/viewItem.png" CommandName="ver"
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
                    No existen comprobantes</p>
            </EmptyDataTemplate>
        </asp:GridView>
    </asp:Panel>
    <br class="clear" />
    &nbsp;
    <div>
        <p>
            <asp:Button ID="btnAceptar" CssClass="btn" runat="server" Text="Guardar" OnClick="btnAceptar_Click"
                ClientIDMode="Static" />
            <asp:Button ID="btnExportToExcel" Text="Exportar Datos a Excel" Width="200px" CssClass="btn"
                runat="server" OnClick="btnExportToExcel_Click" />
        </p>
        <div class="clear">
        </div>
    </div>
    <script type='text/javascript'>

        $(document).ready(function () {

            if (!window.AppCommonObj) {
                window.AppCommonObj = new AppCommon();
            }

            $('#txtFechaVencDesde').datepick({ dateFormat: 'dd/mm/yyyy' });
            $('#txtFechaVencHasta').datepick({ dateFormat: 'dd/mm/yyyy' });
            $('#txtFechaDeCargaDesde').datepick({ dateFormat: 'dd/mm/yyyy' });
            $('#txtFechaDeCargaHasta').datepick({ dateFormat: 'dd/mm/yyyy' });
            $('#txtFechaDeRecepcionDesde').datepick({ dateFormat: 'dd/mm/yyyy' });
            $('#txtFechaDeRecepcionHasta').datepick({ dateFormat: 'dd/mm/yyyy' });
            
            $('#btnBuscar').toggleClass('bounce');
            //$('#btnBuscar').toggleClass('bounce');

            window.AppCommonObj.initializeEnterKeyEvent($('#searchBox'), function () {
                __doPostBack($('#lnkBuscar').attr('aspnetid'), '');
            });
            
        });
    </script>
</asp:Content>
