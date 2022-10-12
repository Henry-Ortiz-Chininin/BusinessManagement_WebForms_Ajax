<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlSolicitante_Buscar.ascx.vb" Inherits="Controles_ctlSolicitante_Buscar" %>
<asp:UpdatePanel ID="upnCtlPersonal" runat="server" >
<ContentTemplate>
<div id="pnlPersonal" class="clsControlBusqueda">
 <div class ="Titulo">Solicitante</div>
<table cellpadding="0" cellspacing="0" border="0" width="150">
    <tr>
        <td class="Titulo12" width="100" >Codigo</td>
        <td><asp:TextBox ID="txtIdSolicitante"  AutoPostBack="true"  CssClass="Codigo" runat="server"></asp:TextBox></td>
        <td><asp:ImageButton CssClass="Boton" ID="btnBuscar1" ImageUrl="~/images/lupa.gif"  onmouseover="this.src='../images/lupa_on.gif'" onmouseout="this.src='../images/lupa.gif'" runat="server" /></td>
    </tr>
    <tr>
        <td class="Titulo12" width="100" >Nombre</td>
        <td><asp:TextBox ID="txtNombre"  AutoPostBack="true" CssClass="Texto"  runat="server"></asp:TextBox></td>
        <td><asp:ImageButton CssClass="Boton" ID="btnBuscar2" ImageUrl="~/images/lupa.gif"  onmouseover="this.src='../images/lupa_on.gif'" onmouseout="this.src='../images/lupa.gif'" runat="server" /></td>
    </tr>
    <tr>
        <td class="Titulo12" width="100" >Apellidos:</td>
        <td><asp:TextBox ID="txtApellido"  AutoPostBack="true" CssClass="Texto"  runat="server"></asp:TextBox></td>
        <td><asp:ImageButton CssClass="Boton" ID="btnBuscar3" ImageUrl="~/images/lupa.gif"  onmouseover="this.src='../images/lupa_on.gif'" onmouseout="this.src='../images/lupa.gif'" runat="server" /></td>
    </tr>


    <tr> 
    <td></td>
    <td colspan="3">
    <div id="pnlLista" runat="server" class="Lista">
    <asp:DataList ID="dtlLista" runat="server"> 
        <ItemTemplate>
            <table cellpadding="0" cellspacing="1" border="0" width="290">
            <tr>
            <td width="210"><asp:LinkButton ID="btnSeleccion2" CommandArgument='<%#Container.DataItem("var_IdSolicitante") %>' CommandName="Seleccionar" CssClass="ListaItem" runat="server" Text='<%#Container.DataItem("var_Nombre") %>' /></td>
            <td width="210"><asp:LinkButton ID="btnSeleccion3" CommandArgument='<%#Container.DataItem("var_IdSolicitante") %>' CommandName="Seleccionar" CssClass="ListaItem" runat="server" Text='<%#Container.DataItem("Apellidos") %>' /></td>
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
        <asp:AsyncPostBackTrigger ControlID="txtIdSolicitante" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtNombre" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtApellido" EventName="TextChanged" />
    </Triggers>
</asp:UpdatePanel> 


