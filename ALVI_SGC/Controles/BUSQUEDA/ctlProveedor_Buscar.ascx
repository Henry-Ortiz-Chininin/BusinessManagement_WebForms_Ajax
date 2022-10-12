<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlProveedor_Buscar.ascx.vb" Inherits="CONTROLES_BUSQUEDA_ctlProveedor_Buscar" %>
<asp:UpdatePanel ID="upnCtlPersonal" runat="server" >
<ContentTemplate>
<div id="pnlPersonal" class="clsControlBusqueda">
<table cellpadding="0" cellspacing="0" border="0" width="180">
    <tr>
        <td><asp:TextBox ID="txtIdProveedor" AutoPostBack="true" width="60" CssClass="Codigo" runat="server"></asp:TextBox></td>
        <td><asp:TextBox ID="txtRazonSocial" width="120" CssClass="Texto" runat="server"></asp:TextBox></td>
        <td><asp:ImageButton CssClass="Boton" ID="btnBuscar" ImageUrl="~/images/lupa.gif"  onmouseover="this.src='../images/lupa_on.gif'" onmouseout="this.src='../images/lupa.gif'" runat="server" /></td>
    </tr>
    <tr>
        <td colspan="3">
            <div id="pnlLista" runat="server" class="Lista">
            <asp:DataList ID="dtlLista" runat="server"> 
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="1" border="0" width="290">
                    <tr>
                    <td width="80"><asp:LinkButton ID="btnSeleccion1" CommandArgument='<%#Container.DataItem("var_IdProveedor") %>' CommandName="Seleccionar" CssClass="ListaItem" runat="server" Text='<%#Container.DataItem("var_IdProveedor") %>' /></td>
                    <td width="210"><asp:LinkButton ID="btnSeleccion2" CommandArgument='<%#Container.DataItem("var_IdProveedor") %>' CommandName="Seleccionar" CssClass="ListaItem" runat="server" Text='<%#Container.DataItem("var_Descripcion") %>' /></td>

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
        <asp:AsyncPostBackTrigger ControlID="txtIdProveedor" EventName="TextChanged" />
    </Triggers>
</asp:UpdatePanel>