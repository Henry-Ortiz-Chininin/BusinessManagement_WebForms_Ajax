<%@ Page Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCREHC.aspx.vb" Inherits="Reportes_FGCREHC" title="Página sin título" %>
<%@ Register TagName="ctlArticulo" TagPrefix="ART" Src="~/Controles/ctlArticulo_Buscar.ascx" %>
<%@ Register TagName="ctlCliente" TagPrefix="Cliente" Src="~/Controles/ctlCliente_Buscar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>  
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
<div id="divCuerpo">  
<div id="divHeader">Seguimiento de Pedidos </div>
<div id="divOpciones">
<table cellpadding="0" cellspacing="1" border="0">  
    <tr>
    <td><asp:ImageButton ID="btnGenerar" runat="server" onmouseover="this.src='../images/btnGenerar_on.gif'" onmouseout="this.src='../images/btnGenerar.gif'" ImageUrl="../images/btnGenerar.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
    </tr> 
    </table> 
</div> 
    <table cellpadding="1" cellspacing="1" border="0"> 
        <tr>
        <td colspan = "6">
         
        <table> 
        <tr>
            <td class="Titulo12" width = "100">Desde</td>
            <td><nobr>
                <asp:TextBox ID="txtDesde" runat="server" Width ="100"></asp:TextBox>&nbsp;
                <asp:Image ID="btnDesde" runat="server" ImageUrl="~/Images/im_calendar.gif" />
                </nobr>
            </td>
            <td class="Titulo12">Hasta</td>
            <td><nobr>
                <asp:TextBox ID="txtHasta" runat="server" Width ="100"></asp:TextBox>&nbsp;
                <asp:Image ID="btnHasta" runat="server" ImageUrl="~/Images/im_calendar.gif" />
                </nobr>
            </td>
        </tr>
        </table>
        </td> 
        </tr> 
        <tr> 
      <td colspan = "2">
        <table>
        <tr>
        <td class="Titulo12" width = "100"> 
        Estatus  
        </td> 
        <td class="Titulo12">
        <asp:RadioButton ID = "rbtActivo" runat = "server" Text = "Activo" Width = "120" AutoPostBack = "true"/>
        </td>  
        <td class="Titulo12">
        <asp:RadioButton ID = "rbtInactivo" runat = "server" Text = "Inactivo" Width = "120" AutoPostBack = "true"/>
        </td>   
        <td class="Titulo12">
        <asp:RadioButton ID = "rbtTodos" runat = "server" Text = "Todos" Width = "120" AutoPostBack = "true" />
        </td>  
        </tr>  
        </table>    
        </td>  
        </tr>
        <tr><td colspan = "6">
        <Cliente:ctlCliente ID="ctlCliente1" runat="server" /> </td> </tr>
    </table>
</div>
</asp:Content>

