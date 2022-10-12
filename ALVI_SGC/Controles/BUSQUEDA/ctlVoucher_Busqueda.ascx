<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlVoucher_Busqueda.ascx.vb"
    Inherits="CONTROLES_BUSQUEDA_ctlVoucher_Busqueda" %>
<div runat="server" id="divVisible">
    <table width="300px">
        <tr>
            <td align="right">
                <asp:ImageButton CssClass="Boton" ID="ImageButton1" ImageUrl="~/images/cerrar_cuadrado.png"
                    onmouseover="this.src='../images/cerrar_cuadrado.png'" onmouseout="this.src='../images/cerrar_cuadrado.png'"
                    runat="server" Height="21px" Width="20px" />
            </td>
        </tr>
    </table>
    <div id="pnlProveedor" class="clsControlBusqueda" runat="server">
        <div class="Titulo">
            BUSQUEDA DE CUENTA</div>
        <table>
            <tr>
                <td>
                    <asp:TextBox runat="server" Width="220px" ID="txtDescripcion"></asp:TextBox>
                </td>
                <td>
                    <asp:ImageButton CssClass="Boton" ID="btnBuscar" ImageUrl="~/images/lupa.gif" onmouseover="this.src='../images/lupa_on.gif'"
                        onmouseout="this.src='../images/lupa.gif'" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:DataList ID="dtlLista" runat="server">
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="1" border="0" width="290">
                                <tr>
                                    <td width="80">
                                        <asp:LinkButton ID="btnSeleccion1" CommandArgument='<%# Eval ("Descripcion") %>'
                                            CommandName="Seleccionar" CssClass="ListaItem" runat="server" Text='<%# Eval ("IdCuenta") %>' />
                                    </td>
                                    <td width="210">
                                        <asp:LinkButton ID="btnSeleccion2" CommandArgument='<%# Eval ("Descripcion") %>'
                                            CommandName="Seleccionar" CssClass="ListaItem" runat="server" Text='<%# Eval ("Descripcion") %>' />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
            </tr>
        </table>
    </div>
</div>
