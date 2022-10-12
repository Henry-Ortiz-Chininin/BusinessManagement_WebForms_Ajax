<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGLREAB.aspx.vb" Inherits="Reportes_FGLREAB" %>
<%@ Register src="../Controles/ctlProveedor_Buscar.ascx" tagname="ctlProveedor_Buscar" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">DOCUMENTOS DE COMPRA - LISTADO</div>

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
        <td class="Titulo12">Nro Documento:</td>

        <td>
            <asp:TextBox ID="txtNumeroDumento" CssClass="Texto12" runat="server" Width="200px"></asp:TextBox>
        </td> 

      
  </tr> 
          
          <tr>
            <td  class="Titulo12">Fecha Emision</td>
            <td><asp:TextBox ID="txtFechaEmisionInicio" Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
            <asp:Image ID="btnFechaEmisionInicio" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
        </tr>
        <tr>
            <td  class="Titulo12" visible ="false"> </td>
            <td><asp:TextBox ID="txtFechaEmisionFinal"  Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
            <asp:Image ID="btnFechaEmisionFinal" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
        </tr>

        <tr></tr>
        <tr></tr>
          <tr>
            <td  class="Titulo12">Fecha Vencimiento</td>
            <td><asp:TextBox ID="txtFechaVencimientoInicio" Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
            <asp:Image ID="btnFechaVencimientoInicio" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
        </tr>
        <tr>
             <td  class="Titulo12" visible ="false"></td>
            <td><asp:TextBox ID="txtFechaVencimientoFinal"  Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
            <asp:Image ID="btnFechaVencimientoFinal" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
        </tr>

   </table> 

<div style="position:absolute; top:70px; left:450px; z-index:0;">
<table>

  <tr>
  <td>
  <uc1:ctlProveedor_Buscar ID="ctlProveedor_Buscar1" runat="server" />
  
  </td>
  
  </tr>
 </table>

</div> 




</div>
</asp:Content>

