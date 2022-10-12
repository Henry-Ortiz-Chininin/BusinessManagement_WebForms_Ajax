<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGLINDB.aspx.vb" Inherits="Interfaces_FGLINDB" %>
<%@ Register src="../Controles/ctlProveedor_Buscar.ascx" tagname="ProveedorBuscar" tagprefix="AVC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divTitulo">COTIZACION - REGISTRO URGENTE</div>
<div id="divOpciones">
    <table cellpadding="1" cellspacing="1" border="0">
    <tr>
        <td><asp:ImageButton ID="btnRegistrar" runat="server" onmouseover="this.src='../images/btnRegistrar_on.gif'" onmouseout="this.src='../images/btnRegistrar.gif'" ImageUrl="../images/btnRegistrar.gif" /></td>
        <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
    </tr>
    </table>
</div>
    <table cellpadding="2" cellspacing="2" border="0" width="900">
    <tr>
        <td class="Titulo12">Codigo OC:</td>
        <td><asp:TextBox ID="txtRequisicion" CssClass="Texto12" runat="server" Width="80px"></asp:TextBox>
        </td>
        <td rowspan="4" >
        <AVC:ProveedorBuscar ID="ctlProveedor" runat="server" />
        </td>
    </tr> 
    <tr>
        <td class="Titulo12">Fecha Emision</td>
        <td>
            <asp:TextBox ID="txtEmision" runat="server" Width="80px"></asp:TextBox>
            <asp:Image ID="btnEmision" runat="server" ImageUrl="~/Images/im_calendar.gif" />
        </td>
    </tr>
    <tr>
        <td class="Titulo12">Observacion</td>
        <td><asp:TextBox ID="txtObservacion" runat="server" TextMode="MultiLine" Width="200"></asp:TextBox></td> 
     </tr>
     <tr>
         <td class="Titulo12">Archivo adjunto</td>
         <td>
            <asp:TextBox ID="txtArchivo" CssClass="Texto12" runat="server"  Width="200"></asp:TextBox>
        </td>
     </tr>
     <tr>
         <td class="Titulo12"></td>
         <td>
            <asp:FileUpload ID="FileUpload1" runat="server"/>
         </td>
     </tr>
    </table>
 
    <asp:GridView ID="grdDatos"  Width="800" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>
        <asp:BoundField DataField="var_IdRequisicion" HeaderText="Req" HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
        <asp:BoundField DataField="var_IdValeAlmacen" HeaderText="NP" HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
        <asp:BoundField DataField="var_IdDetalle" HeaderText="Nro" />
        <asp:BoundField DataField="var_IdArticulo"  HeaderText="IdArticulo"  HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
        <asp:BoundField DataField="var_Articulo" HeaderText="Articulo" />
        <asp:BoundField DataField="var_IdUnidadMedida"  HeaderText="IdUnidadMedida"  HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
        <asp:BoundField DataField="var_UnidadMedida" HeaderText="Medida" />
        <asp:BoundField DataField="num_Cantidad" HeaderText="Cantidad" />
        <asp:TemplateField HeaderText ="Precio Ref.">
            <ItemTemplate>
                <asp:TextBox ID ="txtPrecio" runat="server" Width="100px"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText ="Observación">
            <ItemTemplate>
                <asp:TextBox ID ="txtObservacion"  runat="server" ></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <HeaderStyle CssClass="GridHeader" />
    <FooterStyle CssClass="GridFooter" />
    <AlternatingRowStyle CssClass="GridAltItem" />
    <RowStyle CssClass="GridItem" />
    </asp:GridView>
</div>
</asp:Content>

