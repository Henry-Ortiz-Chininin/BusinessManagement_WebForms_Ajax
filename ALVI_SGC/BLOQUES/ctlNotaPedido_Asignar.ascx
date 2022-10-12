<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlNotaPedido_Asignar.ascx.vb" Inherits="BLOQUES_ctlNotaPedido_Asignar" %>
<table cellpadding="1" cellspacing="1" border="0">
    <tr>
        <td class="Titulo12">Codigo</td>
        <td>
            <asp:TextBox ID="txtCodigo" CssClass="Texto12" runat="server" Width="200px"></asp:TextBox>
        </td>
    </tr> 
</table>
<asp:UpdatePanel runat="server" ID="upnPedido">
<ContentTemplate>
    <asp:GridView ID="grdDatos" Width="800" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
        <Columns>
            <asp:BoundField DataField="var_IdValeAlmacen" HeaderText="NP"  HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
            <asp:BoundField DataField="var_IdArticulo" HeaderText="IdArticulo"  HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
            <asp:BoundField DataField="var_Articulo" HeaderText="Articulo" />
            <asp:BoundField DataField="var_IdUnidadMedida" HeaderText="IdUnidadMedida" HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
            <asp:BoundField DataField="var_UnidadMedida" HeaderText="Medida" />
            <asp:BoundField DataField="num_Cantidad" HeaderText="Pendiente"></asp:BoundField>
            <asp:TemplateField HeaderText ="Asignar">
                <ItemTemplate>
                    <asp:TextBox ID ="txtCantidadSalida" runat="server" Width="80px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText ="Observacion">
                <ItemTemplate>
                    <asp:TextBox ID ="txtObservacion" TextMode="MultiLine" Rows="2" Columns="100" runat="server" Width="150px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="GridHeader" />
        <FooterStyle CssClass="GridFooter" />
        <AlternatingRowStyle CssClass="GridAltItem" />
        <RowStyle CssClass="GridItem" />
    </asp:GridView>
</ContentTemplate>
<Triggers>
    <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
</Triggers>
</asp:UpdatePanel>
<table cellpadding="1" cellspacing="1" border="0">
    <tr>
        <td><asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'" onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" /></td>
        <td><asp:ImageButton ID="btnAsignar" runat="server" onmouseover="this.src='../images/btnAsignar_on.gif'" onmouseout="this.src='../images/btnAsignar.gif'" ImageUrl="../images/btnAsignar.gif" /></td>
    </tr> 
</table>

