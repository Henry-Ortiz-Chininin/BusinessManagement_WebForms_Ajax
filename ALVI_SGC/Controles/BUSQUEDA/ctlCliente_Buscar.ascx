<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlCliente_Buscar.ascx.vb"
    Inherits="CONTROLES_BUSQUEDA_ctlCliente_Buscar" %>
<asp:UpdatePanel ID="upnCtlCliente" runat="server">
    <ContentTemplate>
        <div id="pnlCliente" class="clsControlBusqueda" style="border: 0;">
            <table cellpadding="0" cellspacing="0" border="0" width="400px">
                <tr>
                    <td>
                        <asp:TextBox ID="txtIdCliente" AutoPostBack="true" Width="70px" CssClass="Codigo"
                            runat="server" ReadOnly="true" BackColor="LightGray"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRazonSocial" CssClass="Texto12" Width="330px" runat="server"
                            placeHolder="Ingresar Ruc ó Razón Social" AutoPostBack="true"></asp:TextBox>
                    </td>
                    <td>
                        <asp:ImageButton CssClass="Boton" ID="btnBuscar" ImageUrl="~/images/lupa.gif" onmouseover="this.src='../images/lupa_on.gif'"
                            onmouseout="this.src='../images/lupa.gif'" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <div id="pnlLista" runat="server" class="Lista">
                            <asp:DataList ID="dtlLista" runat="server">
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="1" border="0" width="290px">
                                        <tr>
                                            <td width="80">
                                                <asp:LinkButton ID="btnSeleccion1" CommandArgument='<%#Container.DataItem("var_IdCliente") %>'
                                                    CommandName="Seleccionar" CssClass="ListaItem" runat="server" Text='<%#Container.DataItem("var_IdCliente") %>' />
                                            </td>
                                            <td width="210">
                                                <asp:LinkButton ID="btnSeleccion2" CommandArgument='<%#Container.DataItem("var_IdCliente") %>'
                                                    CommandName="Seleccionar" CssClass="ListaItem" runat="server" Text='<%#Container.DataItem("var_Descripcion") %>' />
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
        <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="dtlLista" EventName="ItemCommand" />
        <asp:AsyncPostBackTrigger ControlID="txtIdCliente" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtRazonSocial" EventName="TextChanged" />
    </Triggers>
</asp:UpdatePanel>
