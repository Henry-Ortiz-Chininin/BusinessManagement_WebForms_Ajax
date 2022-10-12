<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlCuentaGasto_Buscar.ascx.vb" Inherits="Controles_ctlCuentaGasto_Buscar" %>
<asp:UpdatePanel ID="upnCtlCuentaGasto" runat="server" >
<ContentTemplate>
<div id="pnlCuentaGasto" class="clsControlBusqueda">
<table cellpadding="0" cellspacing="0" border="0" width="500">
    <tr>
        <td class="Titulo12" width="200" >Código CG</td>
        <td><asp:TextBox ID="txtIdCuentaGasto" AutoPostBack="true" CssClass="Codigo" runat="server"></asp:TextBox></td>
        <td><asp:ImageButton CssClass="Boton" ID="btnBuscar1" ImageUrl="~/images/lupa.gif"  onmouseover="this.src='../images/lupa_on.gif'" onmouseout="this.src='../images/lupa.gif'" runat="server" /></td>
    </tr>
    <tr>
        <td class="Titulo12" width="150" >Descripción CG</td>
        <td><asp:TextBox ID="txtCuentaGasto" AutoPostBack="true" CssClass="Texto" runat="server"></asp:TextBox></td>
        <td><asp:ImageButton CssClass="Boton" ID="btnBuscar2" ImageUrl="~/images/lupa.gif"  onmouseover="this.src='../images/lupa_on.gif'" onmouseout="this.src='../images/lupa.gif'" runat="server" /></td>
    </tr>
    <tr>
    <td></td>
    <td colspan="3">
    <div id="pnlLista" runat="server" class="Lista">
    <asp:DataList ID="dtlLista" runat="server">
        <ItemTemplate>
            <table cellpadding="0" cellspacing="1" border="0" width="290">
            <tr>
            <td width="80"><asp:LinkButton ID="btnSeleccion1" CommandArgument='<%#Container.DataItem("var_IdCuentaGasto") %>' CommandName="Seleccionar" CssClass="ListaItem" runat="server" Text='<%#Container.DataItem("var_IdCuentaGasto") %>' /></td>
            <td width="210"><asp:LinkButton ID="btnSeleccion2" CommandArgument='<%#Container.DataItem("var_IdCuentaGasto") %>' CommandName="Seleccionar" CssClass="ListaItem" runat="server" Text='<%#Container.DataItem("var_Descripcion") %>' /></td>
            </tr>
            </table>
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
        <asp:AsyncPostBackTrigger ControlID="txtIdCuentaGasto" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtCuentaGasto" EventName="TextChanged" />
    </Triggers>
</asp:UpdatePanel>