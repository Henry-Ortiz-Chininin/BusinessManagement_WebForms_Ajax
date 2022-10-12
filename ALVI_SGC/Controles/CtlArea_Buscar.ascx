<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CtlArea_Buscar.ascx.vb" Inherits="Controles_CtlArea_Buscar" %>
<asp:UpdatePanel ID="upnCtlProceso" runat="server" >
<ContentTemplate>
<div id="pnlCentroCosto" class="clsControlBusqueda">  
<div class ="Titulo">Area/Proceso de Gestión:</div>
<table cellpadding="0" cellspacing="0" border="0" width="500">
    <tr>  
        <td class="Titulo12" width="100" >Codigo</td>
        <td><asp:TextBox ID="txtIdArea" AutoPostBack="true" CssClass="Codigo" runat="server"></asp:TextBox></td>
        <td><asp:ImageButton CssClass="Boton" ID="btnBuscar1" ImageUrl="~/images/lupa.gif"  onmouseover="this.src='../images/lupa_on.gif'" onmouseout="this.src='../images/lupa.gif'" runat="server" /></td>
    </tr>
    <tr> 
        <td class="Titulo12" width="100" >Nombre:</td>
        <td><asp:TextBox ID="txtNombre" AutoPostBack="true" CssClass="Texto" runat="server"></asp:TextBox></td>
        <td><asp:ImageButton CssClass="Boton" ID="btnBuscar2" ImageUrl="~/images/lupa.gif"  onmouseover="this.src='../images/lupa_on.gif'" onmouseout="this.src='../images/lupa.gif'" runat="server" /></td>
    </tr> 

    <tr> 
    <td></td> 
    <td colspan="2">
    <div id="pnlLista" runat="server" class="Lista">
    <asp:DataList ID="dtlLista" runat="server">
        <ItemTemplate>
            <asp:LinkButton ID="btnSeleccion2" CommandArgument='<%#Container.DataItem("var_IdArea") %>' CommandName="Seleccionar" CssClass="ListaItem" runat="server" Text='<%#Container.DataItem("var_Descripcion") %>' />
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
        <asp:AsyncPostBackTrigger ControlID="txtIdArea" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtNombre" EventName="TextChanged" />
    </Triggers>
</asp:UpdatePanel>