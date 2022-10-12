<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlEquipo_Buscar.ascx.vb" Inherits="Controles_ctlEquipo_Buscar" %>
<asp:UpdatePanel ID="upnCtlEquipo" runat="server" >
<ContentTemplate>
<div id="pnlEquipo" class="clsControlBusqueda">
<table cellpadding="0" cellspacing="0" border="0" width="500">
    <tr>
        <td class="Titulo12" width="200" >Código Equipo</td>
        <td><asp:TextBox ID="txtIdEquipo" AutoPostBack="true" CssClass="Codigo" runat="server"></asp:TextBox></td>
        <td><asp:ImageButton CssClass="Boton" ID="btnBuscar1" ImageUrl="~/images/lupa.gif"  onmouseover="this.src='../images/lupa_on.gif'" onmouseout="this.src='../images/lupa.gif'" runat="server" /></td>
    </tr>
    <tr>
        <td class="Titulo12" width="150" >Descripción</td>
        <td><asp:TextBox ID="txtDescripcion" AutoPostBack="true" CssClass="Texto" runat="server"></asp:TextBox></td>
        <td><asp:ImageButton CssClass="Boton" ID="btnBuscar2" ImageUrl="~/images/lupa.gif"  onmouseover="this.src='../images/lupa_on.gif'" onmouseout="this.src='../images/lupa.gif'" runat="server" /></td>
    </tr>
    <tr>
    <td></td>
    <td colspan="3">
    <div id="pnlLista" runat="server" class="Lista">
    <asp:DataList ID="dtlLista" runat="server">
        <ItemTemplate>
            <asp:LinkButton ID="btnSeleccion2" CommandArgument='<%#Container.DataItem("var_IdMaquina") %>' CommandName="Seleccionar" CssClass="ListaItem" runat="server" Text='<%#Container.DataItem("var_Descripcion") %>' />
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
        <asp:AsyncPostBackTrigger ControlID="txtIdEquipo" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtDescripcion" EventName="TextChanged" />
    </Triggers>
</asp:UpdatePanel>