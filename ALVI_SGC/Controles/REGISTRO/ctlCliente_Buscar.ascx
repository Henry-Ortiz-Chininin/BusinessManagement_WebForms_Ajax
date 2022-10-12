<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlCliente_Buscar.ascx.vb"
    Inherits="CONTROLES_REGISTRO_ctlCliente_Buscar" %>
<fieldset>
    <legend>CLIENTE</legend>
    <asp:UpdatePanel ID="upnCtlCliente" runat="server">
        <ContentTemplate>
            <div id="pnlCliente" class="clsControlBusqueda">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td class="Etiqueta" >
                            Código:
                        </td>
                        <td>
                            <asp:TextBox ID="txtIdCliente" AutoPostBack="true" CssClass="Codigo" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:ImageButton CssClass="Boton" ID="btnBuscar1" ImageUrl="~/images/lupa.gif" onmouseover="this.src='../images/lupa_on.gif'"
                                onmouseout="this.src='../images/lupa.gif'" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Etiqueta" >
                            Descripción:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescripcion" AutoPostBack="true" CssClass="Texto" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:ImageButton CssClass="Boton" ID="btnBuscar2" ImageUrl="~/images/lupa.gif" onmouseover="this.src='../images/lupa_on.gif'"
                                onmouseout="this.src='../images/lupa.gif'" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td colspan="2">
                            <div id="pnlLista" runat="server" class="Lista">
                                <asp:DataList ID="dtlLista" runat="server">
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="1" border="0" width="290">
                                            <tr>
                                                <td width="80">
                                                    <asp:LinkButton ID="btnSeleccion1" CommandArgument='<%# Eval ("IdCliente") %>' CommandName="Seleccionar"
                                                        CssClass="ListaItem" runat="server" Text='<%# Eval ("IdCliente") %>' />
                                                </td>
                                                <td width="210">
                                                    <asp:LinkButton ID="btnSeleccion2" CommandArgument='<%# Eval ("IdCliente") %>' CommandName="Seleccionar"
                                                        CssClass="ListaItem" runat="server" Text='<%# Eval ("Descripcion") %>' />
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
            <asp:AsyncPostBackTrigger ControlID="btnBuscar2" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="dtlLista" EventName="ItemCommand" />
            <asp:AsyncPostBackTrigger ControlID="txtIdCliente" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="txtDescripcion" EventName="TextChanged" />
        </Triggers>
    </asp:UpdatePanel>
</fieldset>
