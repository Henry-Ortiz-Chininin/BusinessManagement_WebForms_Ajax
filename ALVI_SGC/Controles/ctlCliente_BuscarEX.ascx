<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlCliente_BuscarEX.ascx.vb"
    Inherits="Controles_ctlCliente_BuscarEX" %>
<asp:UpdatePanel ID="upnCtlCliente" runat="server">
    <ContentTemplate>
        <div id="pnlCliente" class="clsControlBusqueda">
            <table cellpadding="2" cellspacing="0" border="0" width="400">
                <tr>
                    <td class="Titulo12" width="100">
                        <asp:Label runat="server" ID="lblIdCliente" Text="Ruc"  CssClass="Titulo12"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtIdCliente" AutoPostBack="true" CssClass="Codigo" runat="server"
                            placeHolder="Ingresar Ruc" Width="180"></asp:TextBox>
                    </td>
                    <td>
                        <asp:ImageButton CssClass="Boton" ID="btnBuscar1" ImageUrl="~/images/lupa.gif" onmouseover="this.src='../images/lupa_on.gif'"
                            onmouseout="this.src='../images/lupa.gif'" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="Titulo12" width="100">
                        Razon social
                    </td>
                    <td>
                        <asp:TextBox ID="txtRazonSocial" AutoPostBack="true" CssClass="Texto" runat="server"
                            placeHolder="Ingresar Razon Social" Width="180"></asp:TextBox>
                    </td>
                    <td>
                        <asp:ImageButton CssClass="Boton" ID="btnBuscar2" ImageUrl="~/images/lupa.gif" onmouseover="this.src='../images/lupa_on.gif'"
                            onmouseout="this.src='../images/lupa.gif'" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="Titulo12" width="100">
                        <asp:Label runat="server" ID="lblDireccion" CssClass="Titulo12" Text="Direccion:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDireccion" AutoPostBack="true" CssClass="Texto" runat="server"
                            placeHolder="Ingresar Dirección" Width="180"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="Titulo12" width="100" align="center"> 
                        <asp:Label Height="30px" runat="server" ID="lblContacto" CssClass="Titulo12" Text="Contacto:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtcontacto" AutoPostBack="true" CssClass="Texto" runat="server"
                            placeHolder="Ingresar Contacto" Width="180"></asp:TextBox>
                    </td>
                    <td>
                        <asp:ImageButton CssClass="Boton" ID="btnAgregarCliente" ImageUrl="~/images/btnCliente.jpg"
                            onmouseover="this.src='../images/btnCliente.jpg'" Width="40px" AutoPostBack="true" Visible="false"
                            onmouseout="this.src='../images/btnCliente.jpg'" runat="server" ToolTip="Click para agregar un Cliente" />
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
        <asp:AsyncPostBackTrigger ControlID="btnBuscar1" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnBuscar2" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="dtlLista" EventName="ItemCommand" />
        <asp:AsyncPostBackTrigger ControlID="txtIdCliente" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtRazonSocial" EventName="TextChanged" />
    </Triggers>
</asp:UpdatePanel>
