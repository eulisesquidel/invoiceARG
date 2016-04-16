<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Test.aspx.cs" Inherits="FacturaElectronica.Ui.Web.Pages.Test" %>

<%@ Register assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI" tagprefix="asp" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

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
    <style type="text/css">
        .boton
        {
        	color:#050; font: bold 84% 'trebuchet ms',helvetica,sans-serif; background-color:#fed;border:1px solid; border-color: #696 #363 #363 #696;        
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Proyecto - Detalles
    </h2>
    <div class="editionContainerFilter">
        <p>
            <span class="title2">TextBox:</span>
            <asp:TextBox ID="txtId" runat="server" CssClass="inputs readonly" ReadOnly="true"></asp:TextBox>
            <span style="visibility: hidden">*</span>
        </p>
        <div class="clear">
        </div>
        <p>
            <span class="title2">Combo:</span>
            <asp:DropDownList ID="OptionDropDownList" runat="server" CssClass="cbo" ClientIDMode="Static">
                <asp:ListItem Value="t1" Text="Opcion 1"></asp:ListItem>
                <asp:ListItem Value="t2" Text="Opcion 2"></asp:ListItem>
                <asp:ListItem Value="t3" Text="Opcion 3"></asp:ListItem>
                <asp:ListItem Value="t4" Text="Opcion 4"></asp:ListItem>
            </asp:DropDownList>
        </p>
        <div class="clear">
        </div>
        <p>
            <span class="title2">Text Area:</span>
            <asp:TextBox ID="txtTitulo" runat="server" CssClass="inputs multiline" ClientIDMode="Static"
                MaxLength="1500" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtTitulo"
                runat="server" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
        </p>
        <div class="clear">
        </div>
        <p>
            <span class="title2">ListBox:
            </span>
            &nbsp;<asp:ListBox ID="lstUnidadAcademica" runat="server" CssClass="lst" ClientIDMode="Static"
                SelectionMode="Multiple"></asp:ListBox>
        </p>
        <div class="clear">
            
        </div>
    </div>
    <br />
    <div class="buttons">
        <asp:Button ID="HideButton" runat="server" CssClass="boton" Text="Hide Server" OnClick="HideButton_Click" />
    </div>
    <div>
        <asp:Button ID="test" runat="server" Text="test" />
        <asp:Button ID="Button1" runat="server" Text="test" />
    </div>
</asp:Content>
