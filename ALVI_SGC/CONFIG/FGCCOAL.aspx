<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false"
    CodeFile="FGCCOAL.aspx.vb" Inherits="CONFIG_FGCCOAL" %>

<%@ Register TagPrefix="AVCE" TagName="CuentaEntidad" Src="~/CONTROLES/REGISTRO/ctlCuentaEntidad.ascx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div id="divCuerpo">
    <div class="TituloPrincipal">
        CUENTA ENTIDAD- LISTADO / Entidad Financiera :
        <asp:Label runat="server" ID="lblOperacion" Width="100px"></asp:Label>
    </div>
    <asp:HiddenField runat="server" ID="hdnUsuario" />
    <asp:HiddenField runat="server" ID="hdnEmpresa" />
    <asp:HiddenField runat="server" ID="hdnEFinanciera" />
    <div class="Opciones">
        <asp:Button ID="btnBuscar" CssClass="Boton" runat="server" Text="Buscar" />
        <asp:Button ID="btnNuevo" CssClass="Boton" runat="server" Text="Nuevo" />
        <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
    </div>
    <center>
        <asp:GridView ID="grdCuentaEntidad" Width="900" ShowFooter="true" AutoGenerateColumns="false"
            runat="server" AllowPaging="true" PageSize="10">
            <Columns>
                <asp:BoundField DataField="Secuencia" HeaderText="Secuencia" />
                <asp:BoundField DataField="IdEmpresa" HeaderText="Cod_Empresa" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="RazonSocial" HeaderText="Empresa" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="IdEntidadFinanciera" HeaderText="Cod_Ent_Financiera" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="NombreEntidad" HeaderText="Entidad Financiera" />
                <asp:BoundField DataField="IdMoneda" HeaderText="Cod_Moneda" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="Moneda" HeaderText="Moneda" />
                <asp:BoundField DataField="NumeroCuenta" HeaderText="NumeroCuenta" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnEliminar" CssClass="Boton" CommandName="ELIMINAR" CommandArgument='<%#Container.DataItemIndex %>'
                            runat="server" Text="Eliminar" />
                        <asp:Button ID="btnEditar" CssClass="Boton" CommandName="EDITAR" CommandArgument='<%#Container.DataItemIndex %>'
                            runat="server" Text="Editar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="GridHeader" />
            <RowStyle CssClass="GridItem" />
            <AlternatingRowStyle CssClass="GridAltItem" />
        </asp:GridView>
    </center>
    <asp:Panel ID="pnlCuentaEntidad" CssClass="Formulario" runat="server">
        <AVCE:CuentaEntidad ID="ctlCtaEntidad" runat="server" />
    </asp:Panel>
    </div>
</asp:Content>
