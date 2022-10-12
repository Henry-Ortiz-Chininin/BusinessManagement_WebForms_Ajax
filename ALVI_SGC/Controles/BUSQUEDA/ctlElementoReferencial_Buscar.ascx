<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlElementoReferencial_Buscar.ascx.vb"
    Inherits="CONTROLES_BUSQUEDA_ctlElementoReferencial_Buscar" %>
<asp:UpdatePanel ID="upnCtlProceso" runat="server">
    <ContentTemplate>
        <div id="pnlCentroCosto" class="clsControlBusqueda">
            <asp:HiddenField ID="hdnUnidadMedida" runat="server" />
            <asp:HiddenField ID="hdnIdSubFamilia" runat="server" />
            <asp:HiddenField ID="hdnIdEmpresa" runat="server" />
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td class="Titulo12">
                        Codigo
                    </td>
                    <td>
                        <asp:TextBox ID="txtIdElementoReferencial" AutoPostBack="true" CssClass="Codigo"
                            runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:ImageButton CssClass="Boton" ID="btnBuscar1" ImageUrl="~/images/lupa.gif" onmouseover="this.src='../images/lupa_on.gif'"
                            onmouseout="this.src='../images/lupa.gif'" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="Titulo12">
                        Nombre:
                    </td>
                    <td>
                        <asp:TextBox ID="txtNombre" AutoPostBack="true" CssClass="Texto" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:ImageButton CssClass="Boton" ID="btnBuscar2" ImageUrl="~/images/lupa.gif" onmouseover="this.src='../images/lupa_on.gif'"
                            onmouseout="this.src='../images/lupa.gif'" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="Titulo12">
                        Unidad:
                    </td>
                    <td>
                        <asp:TextBox ID="txtUnidadMedida" AutoPostBack="true" CssClass="Texto" runat="server"></asp:TextBox>
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
                                            <td width="100">
                                                <asp:LinkButton ID="btnSeleccion1" CommandArgument='<%#Eval ("IdArticulo") %>' CommandName="Seleccionar"
                                                    CssClass="ListaItem" runat="server" Text='<%#Eval ("IdArticulo") %>' />
                                            </td>
                                            <td width="130">
                                                <asp:LinkButton ID="btnSeleccion2" CommandArgument='<%#Eval ("IdArticulo")  %>' CommandName="Seleccionar"
                                                    CssClass="ListaItem" runat="server" Text='<%#Eval ("Descripcion") %>' />
                                            </td>
                                            <td width="130">
                                                <asp:LinkButton ID="btnSeleccion3" CommandArgument='<%#Eval ("IdArticulo")  %>' CommandName="Seleccionar"
                                                    CssClass="ListaItem" runat="server" Text='<%#Eval ("DesUnidadMedida") %>' />
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
        <asp:AsyncPostBackTrigger ControlID="txtIdElementoReferencial" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtNombre" EventName="TextChanged" />
    </Triggers>
</asp:UpdatePanel>
