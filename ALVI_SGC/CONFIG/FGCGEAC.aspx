<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false"
    CodeFile="FGCGEAC.aspx.vb" Inherits="GENERAL_FGCGEAC" %>

<%@ Register TagPrefix="AVC" TagName="MedioPago" Src="~/CONTROLES/REGISTRO/ctlMedioPago_Registrar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="TituloPrincipal">
        MEDIO DE PAGO - LISTADO</div>
    <asp:HiddenField runat="server" ID="hdnUsuario" />
    <asp:HiddenField runat="server" ID="hdnEmpresa" />
    <div class="Opciones">
        <asp:Button ID="btnBuscar" CssClass="Boton" runat="server" Text="Buscar" />
        <asp:Button ID="btnNuevo" CssClass="Boton" runat="server" Text="Nuevo" />
        <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
    </div>
    <asp:GridView ID="grdMedioPago" Width="700" ShowFooter="true" AutoGenerateColumns="false"
        runat="server" AllowPaging="true">
        <Columns>
            <asp:BoundField DataField="IdMedioPago" HeaderText="IdMedioPago" />
            <asp:BoundField DataField="IdEmpresa" HeaderText="cod_dEmpresa" HeaderStyle-CssClass="NoVisible"
                ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
            <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" />
            <asp:BoundField DataField="MedioPago" HeaderText="Descripcion" />
            <asp:BoundField DataField="CodigoSunat" HeaderText="CodigoSunat" />
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
    <asp:Panel ID="pnlRegistroMedioPago" CssClass="Formulario" runat="server">
        <AVC:MedioPago ID="ctlMedioPago" runat="server" />
    </asp:Panel>
</asp:Content>
