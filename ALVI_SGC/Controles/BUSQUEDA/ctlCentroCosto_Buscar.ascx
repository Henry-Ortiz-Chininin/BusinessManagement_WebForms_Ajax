<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlCentroCosto_Buscar.ascx.vb" Inherits="CONTROLES_BUSQUEDA_ctlCentroCosto_Buscar" %>
<asp:UpdatePanel ID="upnCtlCentroCosto" runat="server" >
<ContentTemplate>
<div id="pnlCentroCosto" class="clsControlBusqueda">
 <table cellpadding="0" cellspacing="0" border="0" width="180">
    <tr>
        <td><asp:TextBox ID="txtIdCentroCosto" AutoPostBack="true" width="60" CssClass="Codigo" runat="server"></asp:TextBox></td>
        <td><asp:TextBox ID="txtCentroCosto" CssClass="Texto" width="120" runat="server"></asp:TextBox></td>
        <td><asp:ImageButton CssClass="Boton" ID="btnBuscar" ImageUrl="~/images/lupa.gif"  onmouseover="this.src='../images/lupa_on.gif'" onmouseout="this.src='../images/lupa.gif'" runat="server" /></td>
    </tr>
    <tr>
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
        <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="dtlLista" EventName="ItemCommand" />
        <asp:AsyncPostBackTrigger ControlID="txtIdCentroCosto" EventName="TextChanged" />
    </Triggers>
</asp:UpdatePanel>