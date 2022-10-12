<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGLINDA.aspx.vb" Inherits="Interfaces_FGLINDA" %>
<%@ Register src="../Controles/ctlProveedor_Buscar.ascx" tagname="ProveedorBuscar" tagprefix="AVC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">COMPRA POR CAJA CHICHA</div>

<div id="divOpciones">
    <table cellpadding="1" cellspacing="1" border="0">
    <tr>
        <td><asp:ImageButton ID="btnRegistrar" runat="server" onmouseover="this.src='../images/btnRegistrar_on.gif'" onmouseout="this.src='../images/btnRegistrar.gif'" ImageUrl="../images/btnRegistrar.gif" /></td>
        <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
    </tr>
    </table>
</div>
<table cellpadding="0" cellspacing="1" border="0">
    <tr>
        <td class="Titulo12">Codigo:</td>
        <td>
            <asp:TextBox ID="txtCodigo" CssClass="Texto12" runat="server" Width="200px"></asp:TextBox>
        </td>
        <td rowspan="4">
            <AVC:ProveedorBuscar ID="ctlProveedor" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="Titulo12">Documento:</td>
        <td>
            <asp:TextBox ID="txtSerie" CssClass="Texto12" runat="server" Width="50px"></asp:TextBox>
            <asp:TextBox ID="txtNumero" CssClass="Texto12" runat="server" Width="120px"></asp:TextBox>
        </td> 
    </tr> 
    <tr>
        <td  class="Titulo12">Emisión</td>
        <td><asp:TextBox ID="txtEmision" Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
            <asp:Image ID="btnEmision" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
    </tr>
    <tr>
        <td  class="Titulo12">Fecha Vencimiento</td>
                <td><asp:TextBox ID="txtVencimiento" Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                <asp:Image ID="btnVencimiento" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
    </tr>
    <tr>
        <td class="Titulo12">Tipo Documento</td>
        <td>
            <asp:DropDownList ID="ddlTipo" runat="server">
            </asp:DropDownList>
        </td>
     </tr>
    <tr>
        <td class="Titulo12">Moneda</td>
        <td>
            <asp:DropDownList ID="ddlMoneda" runat="server">
                <asp:ListItem Value="S">Nuevos Soles</asp:ListItem>
                <asp:ListItem Value="D">Dolares</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">Operacion</td>
            <td>
                <asp:DropDownList ID="ddlOperacion" runat="server">
                </asp:DropDownList>
            </td>
    </tr>
</table>

<asp:GridView ID="grdDatos" Width="800" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>
        <asp:BoundField DataField="var_IdRequisicion" HeaderText="Req" HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
        <asp:BoundField DataField="var_IdValeAlmacen" HeaderText="NP" HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
        <asp:BoundField DataField="var_IdDetalle" HeaderText="Nro." />
        <asp:BoundField DataField="var_IdArticulo" HeaderText="Idarticulo" HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
        <asp:BoundField DataField="var_Articulo" HeaderText="Articulo">
            <HeaderStyle Width="250" />
        </asp:BoundField>
        <asp:BoundField DataField="var_IdUnidadMedida" HeaderText="IdUnidadMedida" HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
        <asp:BoundField DataField="var_UnidadMedida" HeaderText="Medida" />
        <asp:TemplateField HeaderText="Cod. Proveedor">
            <ItemTemplate>
                <asp:TextBox ID="txtIdArticulo" Width="50" Text='<%#Container.DataItem("var_IdArticuloProveedor") %>' runat="server"></asp:TextBox>
            </ItemTemplate>
            <ItemStyle Width="50" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Articulo Proveedor">
            <ItemTemplate>
                <asp:TextBox ID="txtArticulo" Width="150" Text='<%#Container.DataItem("var_NombreArticuloProveedor") %>' runat="server"></asp:TextBox>
            </ItemTemplate>
            <ItemStyle Width="50" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cant.">
            <ItemTemplate>
                <asp:TextBox ID="txtCantidad" Width="30" Text='<%#Container.DataItem("num_Cantidad") %>' runat="server"></asp:TextBox>
            </ItemTemplate>
            <ItemStyle Width="30" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Importe">
            <ItemTemplate>
                <asp:TextBox ID="txtImporte"  Width="50" Text='<%#Container.DataItem("num_ImporteOrigen") %>' runat="server"></asp:TextBox>
            </ItemTemplate>
            <ItemStyle Width="50" />
        </asp:TemplateField>
             
        <asp:BoundField DataField="dec_TipoCambio" HeaderText="T.C." />
        
    </Columns>
    <HeaderStyle CssClass="GridHeader" />
    <FooterStyle CssClass="GridFooter" />
    <AlternatingRowStyle CssClass="GridAltItem" />
    <RowStyle CssClass="GridItem" />
    </asp:GridView>
    <table>
    <tr>
        <td class="Titulo12">Sub-total:</td>
        <td>
            <asp:TextBox ID="txtSubTotal" Enabled="false" CssClass="Texto12" runat="server" Width="130px"></asp:TextBox>
        </td>
        <td class="Titulo12">IGV:</td>
        <td>
            <asp:TextBox ID="txtIGV" Enabled="false" CssClass="Texto12" runat="server" Width="130px"></asp:TextBox>
        </td>
        <td class="Titulo12">Total:</td>
        <td>
            <asp:TextBox ID="txtTotal" Enabled="false" CssClass="Texto12" runat="server" Width="130px"></asp:TextBox>
        </td>
    </tr>
    </table>


</div>
</asp:Content>

