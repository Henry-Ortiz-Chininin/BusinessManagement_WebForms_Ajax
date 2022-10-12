<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlTipoDocumento_Buscar.ascx.vb"
    Inherits="CONTROLES_BUSQUEDA_ctlTipoDocumento_Buscar" %>
<asp:UpdatePanel ID="upnCtlTipoDocumento" runat="server">
    <ContentTemplate>
        <asp:HiddenField runat="server" ID="hdnIdTipoDocumento" />
        <div id="pnlTipoDocuemnto">
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
                        <asp:TextBox ID="txtDescripcion" AutoPostBack="true" CssClass="Texto" runat="server"
                            Width="200"></asp:TextBox>
                    </td>
                    <td>
                        <asp:ImageButton CssClass="Boton" ID="btnBuscar2" ImageUrl="~/images/lupa.gif" onmouseover="this.src='../images/lupa_on.gif'"
                            onmouseout="this.src='../images/lupa.gif'" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div id="pnlLista" runat="server" class="Lista" style="overflow: scroll;">
                            <asp:DataList ID="dtlLista" runat="server">
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="1" border="0">
                                        <tr>
                                            <td width="210">
                                                <asp:LinkButton ID="btnSeleccion2" CommandArgument='<%# Eval ("Descripcion") %>'
                                                    CommandName="Seleccionar" CssClass="ListaItem" runat="server" Text='<%# Eval ("Descripcion") %>' />
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
        <asp:AsyncPostBackTrigger ControlID="btnBuscar2" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="dtlLista" EventName="ItemCommand" />
        <asp:AsyncPostBackTrigger ControlID="txtDescripcion" EventName="TextChanged" />
    </Triggers>
</asp:UpdatePanel>
