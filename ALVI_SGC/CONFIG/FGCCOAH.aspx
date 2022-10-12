<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false"
    CodeFile="FGCCOAH.aspx.vb" Inherits="CONFIG_FGCCOAH" Debug="true" %>

<%@ Register TagPrefix="UC" TagName="OperacionCuenta" Src="~/Controles/REGISTRO/ctlOperacionCuenta_Registro.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div id="divCuerpo">
    <div class="TituloPrincipal">
        CONFIGURACIÓN-OPERACION / [
        <asp:Label runat="server" ID="lblOperacion"></asp:Label>]-[<asp:Label runat="server"
            ID="lblSuboperacion"></asp:Label>]-[<asp:Label runat="server" ID="lblSubOperacionn"></asp:Label>]
    </div>
    <div class="Opciones">
        <asp:HiddenField runat="server" ID="hdnUsuario" />
        <asp:HiddenField runat="server" ID="hdnEmpresa" />
        <asp:HiddenField runat="server" ID="hdnOperacion" />
        <asp:HiddenField runat="server" ID="hdnNomOperacion" />
        <asp:HiddenField runat="server" ID="hdnBC" />
        <asp:HiddenField runat="server" ID="hdnId" />
        <asp:HiddenField runat="server" ID="hdnFlag" />
        <asp:HiddenField runat="server" ID="hdnIsSubop" />
        <asp:HiddenField runat="server" ID="hdnIdOperacion" />
        <asp:Button ID="btnBuscar" CssClass="Boton" runat="server" Text="Buscar" />
        <asp:Button ID="btnNuevo" CssClass="Boton" runat="server" Text="Nuevo" />
        <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
    </div>
    <asp:GridView ID="grdDatos" Width="800" ShowFooter="true" AutoGenerateColumns="false"
        runat="server" AllowPaging="true">
        <Columns>
            <asp:BoundField DataField="IdCuentaContable" HeaderText="Plan_Cuenta" />
            <asp:BoundField DataField="Nombre" HeaderText="Operacion Cuenta" />
            <asp:BoundField DataField="IdEmpresa" HeaderText="Cod_Empresa" HeaderStyle-CssClass="NoVisible"
                ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
            <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" />
            <asp:BoundField DataField="IdOperacion" HeaderText="Cod_Operacion" HeaderStyle-CssClass="NoVisible"
                ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
            <asp:BoundField DataField="Operacion" HeaderText="Operacion" HeaderStyle-CssClass="NoVisible"
                ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
            <asp:BoundField DataField="IdContabilidad" HeaderText="Cod_Conta" HeaderStyle-CssClass="NoVisible"
                ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
            <asp:BoundField DataField="Contabilidad" HeaderText="Contabilidad" />
            <asp:BoundField DataField="EsCargo" HeaderText="Cargo" />
            <asp:BoundField DataField="EsAbono" HeaderText="Abono" />
            <asp:BoundField DataField="EsObligatorio" HeaderText="Obligatorio" />
            <asp:BoundField DataField="IdSubOperacion" HeaderText="IdSuboperacion" HeaderStyle-CssClass="NoVisible"
                ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
            <asp:BoundField DataField="CuentaContable" HeaderText="NombreCuenta" HeaderStyle-CssClass="NoVisible"
                ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
            <asp:BoundField DataField="Observacion" HeaderText="Descripcion" />
            <asp:BoundField DataField="IdOperacionCuenta" HeaderText="IdOperacionCuenta" HeaderStyle-CssClass="NoVisible"
                ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnEliminar" CssClass="Boton" CommandName="ELIMINAR" CommandArgument='<%#Container.DataItemIndex %>'
                        runat="server" Text="Eliminar" />
                    <asp:Button ID="btnEditar" CssClass="Boton" CommandName="MODIFICAR" CommandArgument='<%#Container.DataItemIndex %>'
                        runat="server" Text="Editar" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="GridHeader" />
        <RowStyle CssClass="GridItem" />
        <AlternatingRowStyle CssClass="GridAltItem" />
    </asp:GridView>
    <asp:Panel ID="pnlOperacionCuenta" CssClass="Formulario" runat="server">
        <UC:OperacionCuenta ID="ctlOperacionCuenta" runat="server" />
    </asp:Panel>
    </div>
</asp:Content>
