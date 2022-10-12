<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGLREAC.aspx.vb" Inherits="Reportes_FGLREAC" %>
<%@ Register src="../Controles/ctlElementoReferencial_Buscar.ascx" tagname="ctlElementoReferencial_Buscar" tagprefix="uc2" %>
<%@ Register src="../Controles/ctlCentroCosto_Buscar.ascx" tagname="ctlCentroCosto_Buscar" tagprefix="uc1" %>

<%@ Register src="../Controles/ctlSolicitante_Buscar.ascx" tagname="ctlSolicitante_Buscar" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">VALES DE PEDIDO A ALMACEN - LISTADO</div>
<div id="divOpciones">
<table cellpadding="1" cellspacing="1" border="0">
    <tr>
    <td><asp:ImageButton ID="btnGenerar" runat="server" onmouseover="this.src='../images/btnGenerar_on.gif'" onmouseout="this.src='../images/btnGenerar.gif'" ImageUrl="../images/btnGenerar.gif" /></td>
     <td><asp:ImageButton ID="btnExportar" onmouseover="this.src='../images/btnExportar_on.gif';" onmouseout="this.src='../images/btnExportar.gif';" ImageUrl="../images/btnExportar.gif" runat="server" /></td>
   <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
   </tr>
</table>

</div>

<table cellpadding="0" cellspacing="1" border="0">
 <tr>
        <td class="Titulo12">Codigo OC:</td>
        <td>
            <asp:TextBox ID="txtCodigo" CssClass="Texto12" runat="server" Width="200px"></asp:TextBox>
        </td>
        <td rowspan="3" valign="top">
            <uc1:ctlSolicitante_Buscar ID="ctlSolicitante_Buscar1" runat="server" />
            <uc1:ctlCentroCosto_Buscar ID="ctlCentroCosto_Buscar1" runat="server" />
        </td>
  </tr> 
     <tr>
            <td class="Titulo12">
                Fecha Emision</td>
             <td>
                <asp:TextBox ID="txtFechaEmisionInicio" runat="server" Width="80px"></asp:TextBox>
                <asp:Image ID="btnFechaEmision" runat="server" 
                    ImageUrl="~/Images/im_calendar.gif" />
                <asp:TextBox ID="txtFechaEmisionFinal" runat="server" Width="80px"></asp:TextBox>
                <asp:Image ID="btnFechaEmisionFinal" runat="server" 
                    ImageUrl="~/Images/im_calendar.gif" />
                </td>
        </tr>
    <tr>
        <td colspan="2">
            <uc2:ctlElementoReferencial_Buscar ID="ctlElementoReferencial_Buscar1" runat="server" />
       </td>
     </tr> 
  </table> 
    
</div>
</asp:Content>

