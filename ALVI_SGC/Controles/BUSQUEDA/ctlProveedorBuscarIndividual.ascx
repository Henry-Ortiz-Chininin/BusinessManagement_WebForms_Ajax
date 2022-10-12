<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlProveedorBuscarIndividual.ascx.vb"
    Inherits="CONTROLES_BUSQUEDA_ctlProveedorBuscarIndividual" %>
<asp:HiddenField ID="hdnIdEmpresa" runat="server" />
<asp:HiddenField ID="hdnRazonSocialProveedor" runat="server" />
<asp:UpdatePanel ID="upnCtlProveedor" runat="server">
    <ContentTemplate>
        <div id="pnlProveedor" class="clsControlBusqueda">
            <table cellpadding="0" cellspacing="0" border="0">
                <%--cellpadding="0" cellspacing="0" border="0" width="400" 
                    style="width: 379px">--%>
                <tr>
                    <td>
                        <asp:TextBox ID="txtRuc" AutoPostBack="true" runat="server" CssClass="Texto" Width="200"></asp:TextBox>
                    </td>
                    <td>
                        <asp:ImageButton CssClass="Boton" ID="btnBuscar1" ImageUrl="~/images/lupa.gif" onmouseover="this.src='../images/lupa_on.gif'"
                            onmouseout="this.src='../images/lupa.gif'" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="Texto" Width="200"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div id="pnlLista" runat="server" class="Lista">
                            <asp:DataList ID="dtlLista" runat="server">
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="1" border="0" width="290">
                                        <tr>
                                            <td width="210">
                                                <asp:LinkButton ID="btnSeleccion2" CommandArgument='<%# Eval ("RazonSocialProveedor") %>'
                                                    CommandName="Seleccionar" CssClass="ListaItem" runat="server" Text='<%# Eval ("RazonSocialProveedor") %>' />
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
        <%-- <asp:AsyncPostBackTrigger ControlID="btnBuscar2" EventName="Click" />--%>
        <asp:AsyncPostBackTrigger ControlID="dtlLista" EventName="ItemCommand" />
        <%--<asp:AsyncPostBackTrigger ControlID="txtDescripcion" EventName="TextChanged" />--%>
    </Triggers>
</asp:UpdatePanel>
