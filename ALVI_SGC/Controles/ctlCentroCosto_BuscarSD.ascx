<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlCentroCosto_BuscarSD.ascx.vb" Inherits="Controles_ctlCentroCosto_BuscarSD" %>
<asp:UpdatePanel ID="upnCtlCentroCosto" runat="server" >
<ContentTemplate>
<div id="pnlCentroCosto" class="clsControlBusqueda">
<table cellpadding="0" cellspacing="0" border="0" width="120">
    <tr>
        <td class="Titulo12" width="200" >Código CC</td>
        <td><asp:TextBox ID="txtIdCentroCosto" AutoPostBack="true" CssClass="Codigo" runat="server"></asp:TextBox></td>
        <td><asp:ImageButton CssClass="Boton" ID="btnBuscar1" ImageUrl="~/images/lupa.gif"  onmouseover="this.src='../images/lupa_on.gif'" onmouseout="this.src='../images/lupa.gif'" runat="server" /></td>
    </tr>
    <tr>
        <td ></td>
        <td colspan="2">
            <div ID="pnlLista" runat="server" class="Lista">
                <asp:DataList ID="dtlLista" runat="server">
                    <ItemTemplate>
                        <table border="0" cellpadding="0" cellspacing="1" width="290">
                            <tr>
                                <td width="80">
                                    <asp:LinkButton ID="btnSeleccion1" runat="server" 
                                        CommandArgument='<%#Container.DataItem("var_IdCentroCosto") %>' 
                                        CommandName="Seleccionar" CssClass="ListaItem" 
                                        Text='<%#Container.DataItem("var_IdCentroCosto") %>' />
                                </td>
                                <td width="210">
                                    <asp:LinkButton ID="btnSeleccion2" runat="server" 
                                        CommandArgument='<%#Container.DataItem("var_IdCentroCosto") %>' 
                                        CommandName="Seleccionar" CssClass="ListaItem" 
                                        Text='<%#Container.DataItem("var_Descripcion") %>' />
                                </td>
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
<%--        <asp:AsyncPostBackTrigger ControlID="btnBuscar2" EventName="Click" />--%>
        <asp:AsyncPostBackTrigger ControlID="dtlLista" EventName="ItemCommand" />
        <asp:AsyncPostBackTrigger ControlID="txtIdCentroCosto" EventName="TextChanged" />
<%--        <asp:AsyncPostBackTrigger ControlID="txtCentroCosto" EventName="TextChanged" />--%>
    </Triggers>
</asp:UpdatePanel>