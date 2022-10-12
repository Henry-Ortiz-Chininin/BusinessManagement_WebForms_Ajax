<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlPersonal_Buscar.ascx.vb" Inherits="Controles_ctlPersonal_Buscar" %>
<asp:UpdatePanel ID="upnCtlPersonal" runat="server" >
<ContentTemplate>
<div id="pnlPersonal" class="clsControlBusqueda">
<table cellpadding="0" cellspacing="0" border="0" width="500">
    <tr>
        <td class="Titulo12" width="200" >Código Personal</td>
        <td><asp:TextBox ID="txtIdPersonal" AutoPostBack="true" CssClass="Codigo" runat="server"></asp:TextBox></td>
        <td><asp:ImageButton CssClass="Boton" ID="btnBuscar1" ImageUrl="~/images/lupa.gif"  onmouseover="this.src='../images/lupa_on.gif'" onmouseout="this.src='../images/lupa.gif'" runat="server" /></td>
    </tr>
    <tr>
        <td class="Titulo12" width="150" >Nombre</td>
        <td><asp:TextBox ID="txtNombre" AutoPostBack="true" CssClass="Texto" runat="server"></asp:TextBox></td>
        <td><asp:ImageButton CssClass="Boton" ID="btnBuscar2" ImageUrl="~/images/lupa.gif"  onmouseover="this.src='../images/lupa_on.gif'" onmouseout="this.src='../images/lupa.gif'" runat="server" /></td>
    </tr>
    <tr> 
    <td></td>
    <td colspan="3">
    <div id="pnlLista" runat="server" class="Lista">
    <asp:DataList ID="dtlLista" runat="server"> 
        <ItemTemplate>
            <asp:LinkButton ID="btnSeleccion2" CommandArgument='<%#Container.DataItem("var_IdPersonal") %>' CommandName="Seleccionar" CssClass="ListaItem" runat="server" Text='<%#Container.DataItem("var_Nombre") %>' />
        </ItemTemplate>        
    </asp:DataList>
    </div> 
    </td>
    </tr>    
</table> 
  </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnBuscar1" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnBuscar2" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="dtlLista" EventName="ItemCommand" />
        <asp:AsyncPostBackTrigger ControlID="txtIdPersonal" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtNombre" EventName="TextChanged" />
    </Triggers>
</asp:UpdatePanel> 