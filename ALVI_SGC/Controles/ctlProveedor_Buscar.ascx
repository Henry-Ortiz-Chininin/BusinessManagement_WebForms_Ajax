<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlProveedor_Buscar.ascx.vb" Inherits="Controles_ctlProveedor_Buscar" %>
<fieldset>
    <legend>Proveedor</legend>
<asp:UpdatePanel ID="upnCtlPersonal" runat="server" >
<ContentTemplate>
<div id="pnlPersonal" class="clsControlBusqueda">
<table cellpadding="0" cellspacing="0" border="0" width="300" style="background-color:white;">
    <tr>
        <td class="Titulo12" width="100" >RUC</td>
        <td><asp:TextBox ID="txtIdProveedor" AutoPostBack="true" CssClass="Codigo" runat="server"></asp:TextBox></td>
        <td><asp:ImageButton ID="btnBuscar1" ImageUrl="~/images/lupa.gif"  onmouseover="this.src='../images/lupa_on.gif'" onmouseout="this.src='../images/lupa.gif'" runat="server" /></td>
    </tr>

    <tr>
        <td class="Titulo12" width="150" ><nobr>Razon Social:</nobr></td>
        <td><asp:TextBox ID="txtRazonSocial" AutoPostBack="true" CssClass="Texto" runat="server"></asp:TextBox></td>
        <td><asp:ImageButton ID="btnBuscar3" ImageUrl="~/images/lupa.gif"  onmouseover="this.src='../images/lupa_on.gif'" onmouseout="this.src='../images/lupa.gif'" runat="server" /></td>
    </tr>


    <tr> 
    <td></td>
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
        <asp:AsyncPostBackTrigger ControlID="btnBuscar1" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnBuscar3" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="dtlLista" EventName="ItemCommand" />
        <asp:AsyncPostBackTrigger ControlID="txtIdProveedor" EventName="TextChanged" />
       <asp:AsyncPostBackTrigger ControlID="txtRazonSocial" EventName="TextChanged" />
    </Triggers>
</asp:UpdatePanel>
</fieldset>