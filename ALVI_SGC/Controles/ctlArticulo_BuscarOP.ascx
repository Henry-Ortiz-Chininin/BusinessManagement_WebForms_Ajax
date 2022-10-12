<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlArticulo_BuscarOP.ascx.vb" Inherits="Controles_ctlArticulo_BuscarOP" %>
<asp:UpdatePanel ID="upnCtlArticulo" runat="server" >
<ContentTemplate>
<div id="pnlCentroCosto" class="clsControlBusqueda">
    <asp:HiddenField ID="hdnIdSubFamilia" runat="server" />
    <asp:HiddenField ID="hdnIdOrden" runat="server" />
<table cellpadding="0" cellspacing="0" border="0" width="500"> 
    <tr>
        <td class="Titulo12" width="200" >Código Articulo</td>
        <td><asp:TextBox ID="txtIdArticulo" AutoPostBack="true" CssClass="Codigo" runat="server"></asp:TextBox></td>
        <td><asp:ImageButton CssClass="Boton" ID="btnBuscar1" ImageUrl="~/images/lupa.gif"  onmouseover="this.src='../images/lupa_on.gif'" onmouseout="this.src='../images/lupa.gif'" runat="server" /></td>
    </tr>
    <tr>
        <td class="Titulo12" width="150" >Descripción Articulo</td>
        <td><asp:TextBox ID="txtDescripcion" AutoPostBack="true" CssClass="Texto" runat="server"></asp:TextBox></td>
        <td><asp:ImageButton CssClass="Boton" ID="btnBuscar2" ImageUrl="~/images/lupa.gif"  onmouseover="this.src='../images/lupa_on.gif'" onmouseout="this.src='../images/lupa.gif'" runat="server" /></td>
    </tr>
    <tr>
    <td></td>
    <td colspan="2">
    <div id="pnlLista" runat="server" class="Lista">
    <asp:DataList ID="dtlLista" runat="server">
        <ItemTemplate>
            <asp:LinkButton ID="btnSeleccion2" CommandArgument='<%#Container.DataItem("var_IdArticulo") %>' CommandName="Seleccionar" CssClass="ListaItem" runat="server" Text='<%#Container.DataItem("var_Descripcion") %>' />
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
        <asp:AsyncPostBackTrigger ControlID="txtIdArticulo" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtDescripcion" EventName="TextChanged" />
    </Triggers>
</asp:UpdatePanel>