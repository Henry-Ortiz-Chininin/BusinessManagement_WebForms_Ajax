<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlCuenta_Buscar.ascx.vb"
    Inherits="CONTROLES_BUSQUEDA_ctlCuenta_Buscar" %>
<div class="Titulo">BUSQUEDA DE CUENTA CONTABLE</div>
<%--<div runat="server" id="divCuenta">--%>
<div id="pnlDocumento" class="clsControlBusqueda">
    <table cellpadding="0" cellspacing="0" border="0" width="400">
        <tr>
            <td class="Etiqueta">
                Numero:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtCuenta"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="Etiqueta">
                Cuenta:
            </td>
            <td>
                <asp:TextBox ID="txtDescripcion" CssClass="Texto" runat="server" Width="280px"></asp:TextBox>
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
                                        <asp:LinkButton ID="btnSeleccion1" CommandArgument='<%# Eval ("IdCuentaContable") %>' CommandName="Seleccionar"
                                            CssClass="ListaItem" runat="server" Text='<%# Eval ("IdCuentaContable") %>' />
                                    </td>
                                    <td width="210">
                                        <asp:LinkButton ID="btnSeleccion2" CommandArgument='<%# Eval ("IdCuentaContable") %>' CommandName="Seleccionar"
                                            CssClass="ListaItem" runat="server" Text='<%# Eval ("Nombre") %>' />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="right">
            </td>
            <td>
                <asp:Button runat="server" ID="btnCerrarr" CssClass="Boton" Text="Cerrar" />
            </td>
        </tr>
    </table>
</div>
<%--</div>--%>
