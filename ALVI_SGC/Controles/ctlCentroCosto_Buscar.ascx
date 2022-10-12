<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlCentroCosto_Buscar.ascx.vb" Inherits="Controles_ctlCentroCosto_Buscar" %>
<fieldset>
    <legend>Centro de Costo</legend>
    <asp:UpdatePanel ID="upnCtlCentroCosto" runat="server" >
<ContentTemplate>
<div id="pnlCentroCosto" class="clsControlBusqueda">
<table cellpadding="0" cellspacing="0" border="0" width="120">
    <tr>
        <td class="Titulo12" width="200" >Código</td>
        <td><asp:TextBox ID="txtIdCentroCosto" AutoPostBack="true" CssClass="Codigo" runat="server"></asp:TextBox></td>
        <td><asp:ImageButton CssClass="Boton" ID="btnBuscar1" ImageUrl="~/images/lupa.gif"  onmouseover="this.src='../images/lupa_on.gif'" onmouseout="this.src='../images/lupa.gif'" runat="server" /></td>
    </tr>
    <tr>
        <td class="Titulo12" width="150" >Descripción</td>
        <td><asp:TextBox ID="txtCentroCosto" AutoPostBack="true" CssClass="Texto" runat="server"></asp:TextBox></td>
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
            <td width="80"><asp:LinkButton ID="btnSeleccion1" CommandArgument='<%#Container.DataItem("var_IdCentroCosto") %>' CommandName="Seleccionar" CssClass="ListaItem" runat="server" Text='<%#Container.DataItem("var_IdCentroCosto") %>' /></td>
            <td width="210"><asp:LinkButton ID="btnSeleccion2" CommandArgument='<%#Container.DataItem("var_IdCentroCosto") %>' CommandName="Seleccionar" CssClass="ListaItem" runat="server" Text='<%#Container.DataItem("var_Descripcion") %>' /></td>
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
        <asp:AsyncPostBackTrigger ControlID="txtIdCentroCosto" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtCentroCosto" EventName="TextChanged" />
    </Triggers>
</asp:UpdatePanel>
</fieldset>