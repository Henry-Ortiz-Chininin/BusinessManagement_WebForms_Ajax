<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlArticuloAlmacen_Asignar.ascx.vb" Inherits="BLOQUES_ctlArticuloAlmacen_Asignar" %>
<%@ Register TagPrefix="AVC" TagName="Articulo" Src="~/Controles/ctlArticulo_Buscar.ascx" %>

<asp:UpdatePanel runat="server" ID="upnArticulo">
<ContentTemplate>
<div id="divTitulo">Asignación de Articulo al movimiento</div>
<table cellpadding="2" cellspacing="2" border="0" width="500" align="center" valign="middle">
    <tr>
        <td valign="top">
        <table cellpadding="2" cellspacing="2" border="0" width="500" align="center" valign="middle">
            <tr>
                <td class="Titulo12">Almacen destino</td>
                <td width="300">
                    <asp:DropDownList ID="ddlAlmacen" CssClass="Texto12" runat="server">
                    </asp:DropDownList>
                </td>        
            </tr>
            <tr>
                <td colspan="2">
                    <AVC:Articulo runat="server" ID="ctlArticulo" />
                </td>        
            </tr> 
        </table>
        </td>
        <td valign="top">
        <table cellpadding="2" cellspacing="2" border="0" width="350" align="center" valign="middle">
            <tr>
                <td class="Titulo12" width="150">Cantidad</td>
                <td width="200">
                    <asp:TextBox ID="txtCantidad" AutoPostBack="true" MaxLength="14" onChange="validadigito(this,'NUM');" onKeypress="return Valida(event, 'NUM');" CssClass="Texto12" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="Titulo12">Costo Unitario</td>
                <td><asp:UpdatePanel ID="udpCosto" runat="server">
                    <ContentTemplate>
                    <asp:TextBox ID="txtCostoUnitario" MaxLength="20" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                    </ContentTemplate>
                    <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="txtCantidad" EventName="TextChanged" />
                    <asp:AsyncPostBackTrigger ControlID="txtImporte" EventName="TextChanged" />
                    </Triggers> 
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="Titulo12">Importe</td>
                <td>
                    <asp:TextBox ID="txtImporte" MaxLength="20" AutoPostBack="true" onChange="validadigito(this,'NUM');" onKeypress="return Valida(event, 'NUM');" CssClass="Texto12" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="Titulo12">Moneda</td>
                <td>
                    <asp:DropDownList ID="ddlMoneda" CssClass="Texto12" runat="server">
                        <asp:ListItem Value="S">Nuevos Soles</asp:ListItem>
                        <asp:ListItem Value="D">Dolares</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>   
            <tr>
                <td class="Titulo12">Importe S/:</td>
                <td>
                    <asp:TextBox ID="txtImporteMoneda" Enabled="false"  CssClass="Texto12" runat="server"></asp:TextBox></td>
            </tr>    
            <tr>
                <td class="Titulo12">Observación</td>
                <td><asp:TextBox ID="txtObservacionDetalle" MaxLength="500" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server"></asp:TextBox></td>
            </tr>

        </table> 
        </td>
    </tr>
</table>
<table cellpadding="1" border="0" cellspacing="1">
    <tr>
        <td><asp:ImageButton ID="btnRegistrar" CssClass="Boton" onmouseover="this.src='../images/btnAsignar_on.gif';" onmouseout="this.src='../images/btnAsignar.gif';" ImageUrl="../images/btnAsignar.gif" runat="server" /></td>
        <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
    </tr>
</table> 
    

<asp:GridView ID="grdDatos" Width="1000"  ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>  
        <asp:BoundField DataField="var_IdArticulo" HeaderText="Codigo" HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
        <asp:BoundField DataField="var_Articulo" HeaderText="Articulo" />
        <asp:BoundField DataField="num_Cantidad" HeaderText="Cantidad" DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundField DataField="var_UnidadMedida" HeaderText="Medida" />
        <asp:BoundField DataField="num_CostoUnitario" HeaderText="PU" DataFormatString="{0:#,##0.0000}" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundField DataField="num_ImporteMoneda" HeaderText="Total" DataFormatString="{0:#,##0.0000}" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundField DataField="var_Moneda" HeaderText="MON" HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
        <asp:BoundField DataField="num_TipoCambio" HeaderText="TC" DataFormatString="{0:#,##0.0000}" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
        <asp:BoundField DataField="num_Importe" HeaderText="Importe S/." DataFormatString="{0:#,##0.0000}" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
        <asp:BoundField DataField="var_Almacen" HeaderText="Almacen destino" />
        <asp:BoundField DataField="var_Observacion" HeaderText="Observación" HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible"  />
        <asp:TemplateField>
        <ItemTemplate>
            <asp:ImageButton ID="btnModificar" CommandArgument='<%#Container.DataItem("var_IdArticulo") %>' CommandName="Modificar" ImageUrl="../images/btnAbrir.gif" runat="server" onmouseover="this.src='../images/btnAbrir_on.gif'" onmouseout="this.src='../images/btnAbrir.gif'" />
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
        <ItemTemplate>
            <asp:ImageButton ID="btnEliminar" CommandArgument='<%#Container.DataItem("var_IdArticulo") %>' CommandName="Eliminar" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
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
    <asp:AsyncPostBackTrigger ControlID="btnRegistrar" EventName="Click" />
    <asp:AsyncPostBackTrigger ControlID="grdDatos" EventName="RowCommand" />
</Triggers>
</asp:UpdatePanel>

<div id="divFooter">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
        <img src="../images/loader.gif" /> 
        </ProgressTemplate>
    </asp:UpdateProgress>
<asp:Label ID="lblMensaje" runat="server"></asp:Label>&nbsp;
</div>