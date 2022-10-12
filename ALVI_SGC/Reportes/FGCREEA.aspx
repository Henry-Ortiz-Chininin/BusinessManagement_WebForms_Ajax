<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCREEA.aspx.vb" Inherits="Reportes_FGCREEA" %>
<%@ Register TagName="ctlArticulo" TagPrefix="ART" Src="~/Controles/ctlArticulo_Buscar.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">Reporte General de Servicios</div>
<div id="divOpciones">
<table cellpadding="0" cellspacing="1" border="0">
    <tr>
    <td><asp:ImageButton ID="btnGenerar" runat="server" onmouseover="this.src='../images/btnGenerar_on.gif'" onmouseout="this.src='../images/btnGenerar.gif'" ImageUrl="../images/btnGenerar.gif" /></td>
    <td><asp:ImageButton ID="btnExportar" runat="server" onmouseover="this.src='../images/btnExportar_on.gif'" onmouseout="this.src='../images/btnExportar.gif'" ImageUrl="../images/btnExportar.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
    </tr>
    </table>
</div>    
    <table cellpadding="1" cellspacing="1" border="0">
        <tr>
            <td class="Titulo12">Fecha Inicio</td>
            <td><nobr>
                <asp:TextBox ID="txtFechaInicio" runat="server"></asp:TextBox>&nbsp;
                <asp:Image ID="btnFechaInicio" runat="server" ImageUrl="~/Images/im_calendar.gif" />
                </nobr>
            </td>        
        </tr>
        <tr>
            <td class="Titulo12">Fecha Final</td>
            <td><nobr>
                <asp:TextBox ID="txtFechaFinal" runat="server"></asp:TextBox>&nbsp;
                <asp:Image ID="btnFechaFinal" runat="server" ImageUrl="~/Images/im_calendar.gif" />
                </nobr>
            </td>        
        </tr>
        <tr>
            <td class="Titulo12">Orden de Producción</td>
            <td><asp:TextBox ID="txtOrden" runat="server"></asp:TextBox>
            </td>        
        </tr>
        <tr>
            <td class="Titulo12">Proveedor</td>
            <td>
                <asp:DropDownList ID="ddlProveedor" CssClass="Texto12" runat="server">
                </asp:DropDownList>
            </td>        
        </tr>
        <tr>
            <td class="Titulo12" colspan="2"><hr /><br />Articulo<br /><hr /></td>
        </tr>
        <tr>
            <td colspan="2">
            <ART:ctlArticulo ID="ctlArticulo1" runat="server" />            
            </td>
        </tr>

    </table>
</div>
</asp:Content>

