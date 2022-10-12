<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlDocumento_Buscar.ascx.vb"
    Inherits="CONTROLES_BUSQUEDA_ctlDocumento_Buscar" %>
<fieldset>
    <legend> <asp:Label ID="lblTitulo" runat="server" Text="Documento"></asp:Label></legend>
    <asp:HiddenField ID="hdnIdEmpresa" runat="server" />
    <asp:UpdatePanel ID="upnCtlDocumento" runat="server">
        <ContentTemplate>
            <div id="pnlDocumento" class="clsControlBusqueda">
                <table cellpadding="1" cellspacing="1" border="0">
                    <tr>
                        <td class="Etiqueta" width="100">
                            Tipo:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTipoDocumento" runat="server" Width="200px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="Etiqueta" width="100">
                            Numero:
                        </td>
                        <td width="150">
                            <asp:TextBox ID="txtNumeroDocumento" CssClass="Texto" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:ImageButton ID="btnBuscar2" ImageUrl="~/images/lupa.gif" onmouseover="this.src='../images/lupa_on.gif'"
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
                                                    <asp:LinkButton ID="btnSeleccion1" CommandArgument='<%# Eval ("IdComprobante") %>'
                                                        CommandName="Seleccionar" CssClass="ListaItem" runat="server" Text='<%# Eval ("IdComprobante") %>' />
                                                </td>
                                                <td width="210">
                                                    <asp:LinkButton ID="btnSeleccion2" CommandArgument='<%# Eval ("IdComprobante") %>'
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
        </Triggers>
    </asp:UpdatePanel>
</fieldset>
