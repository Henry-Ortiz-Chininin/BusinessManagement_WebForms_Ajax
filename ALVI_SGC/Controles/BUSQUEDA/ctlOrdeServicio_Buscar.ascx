<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlOrdeServicio_Buscar.ascx.vb"
    Inherits="Controles_ctlOrdenServicio" %>
<%@ Register TagName="ctlCliente" TagPrefix="AVC1" Src="~/Controles/BUSQUEDA/ctlCliente_Buscar.ascx" %>
<asp:UpdatePanel ID="upnCtlCliente" runat="server">
    <ContentTemplate>
        <asp:HiddenField runat="server" ID="hdnRazonSocial" />
        <asp:HiddenField runat="server" ID="hdnImporte" />
        <div id="pnlCliente" class="clsControlBusqueda">
            <table cellpadding="2" cellspacing="0" border="0" width="400">
                <tr>
                    <td class="Titulo12" width="100">
                        <asp:Label runat="server" ID="lblIdOrdeServ" Text="Codigo" CssClass="Titulo12"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtIdOrdenServ" AutoPostBack="true" CssClass="Código OS" runat="server"
                            placeHolder="Ingresar Codigo Orden Servicio" Width="180"></asp:TextBox>
                    </td>
                    <td>
                        <asp:ImageButton CssClass="Boton" ID="btnBuscar1" ImageUrl="~/images/lupa.gif" onmouseover="this.src='../images/lupa_on.gif'"
                            onmouseout="this.src='../images/lupa.gif'" runat="server" Visible="false" />
                    </td>
                </tr>
                <tr>
                    <td class="Titulo12" width="100">
                        <asp:Label runat="server" ID="lblPlaca" Text="Placa" CssClass="Titulo12"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPlaca" AutoPostBack="true" CssClass="Texto12" runat="server"
                            placeHolder="Ingresar Placa Grua" Width="180"></asp:TextBox>
                    </td>
                    <td>
                        <asp:ImageButton CssClass="Boton" ID="btnBuscar2" ImageUrl="~/images/lupa.gif" onmouseover="this.src='../images/lupa_on.gif'"
                            onmouseout="this.src='../images/lupa.gif'" runat="server" Visible="true" />
                    </td>
                </tr>
                <tr>
                    <td class="Titulo12" width="100" colspan="3" align="left">
                        <AVC1:ctlCliente runat="server" ID="ctlCliente_Buscar" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <div id="pnlLista" runat="server" class="Lista">
                            <asp:DataList ID="dtlLista" runat="server">
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="1" border="0" width="290">
                                        <tr>
                                            <td width="50">
                                                <asp:LinkButton ID="btnSeleccion1" CommandArgument='<%#Eval ("IdOrdenServicio") %>'
                                                    CommandName="Seleccionar" CssClass="ListaItem" runat="server" Text='<%#Eval ("IdOrdenServicio") %>' />
                                            </td>
                                            <td width="170">
                                                <asp:LinkButton ID="btnSeleccion2" CommandArgument='<%#Eval ("IdOrdenServicio") %>'
                                                    CommandName="Seleccionar" CssClass="ListaItem" runat="server" Text='<%#Eval("RazonSocial") %>' />
                                            </td>
                                            <td width="50">
                                                <asp:LinkButton ID="btnSeleccion3" CommandArgument='<%#Eval ("IdOrdenServicio") %>'
                                                    CommandName="Seleccionar" CssClass="ListaItem" runat="server" Text='<%#Eval ("Placa_Grua") %>' />
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
        <asp:AsyncPostBackTrigger ControlID="txtIdOrdenServ" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtPlaca" EventName="TextChanged" />
    </Triggers>
</asp:UpdatePanel>
