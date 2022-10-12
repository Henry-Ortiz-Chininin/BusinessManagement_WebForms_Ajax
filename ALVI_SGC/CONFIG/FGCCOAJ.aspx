<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false"
    CodeFile="FGCCOAJ.aspx.vb" Inherits="CONFIG_FGCCOAJ" %>

<%@ Register TagPrefix="AVC" TagName="TipoCuenta" Src="~/CONTROLES/REGISTRO/ctlTipoCuenta_Registrar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div id="divCuerpo">
    <div class="TituloPrincipal">
        TIPO DE CUENTA- LISTADO</div>
    <asp:HiddenField runat="server" ID="hdnUsuario" />
    <asp:HiddenField runat="server" ID="hdnEmpresa" />
    <div class="Opciones">
        <asp:Button ID="btnBuscar" CssClass="Boton" runat="server" Text="Buscar" />
        <asp:Button ID="btnNuevo" CssClass="Boton" runat="server" Text="Nuevo" />
        <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
    </div>
    <br />
    <asp:GridView ID="grdTipoCuenta" Width="700" ShowFooter="true" AutoGenerateColumns="false"
        runat="server" AllowPaging="true">
        <Columns>
            <asp:BoundField DataField="IdTipoCuenta" HeaderText="Cod_TipoCuenta" />
            <asp:BoundField DataField="IdEmpresa" HeaderText="Cod_Empresa" HeaderStyle-CssClass="NoVisible"
                ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
            <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" />
            <asp:BoundField DataField="TipoCuenta" HeaderText="Descripcion" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnEliminar" CssClass="Boton" CommandName="Eliminar" CommandArgument='<%#Container.DataItemIndex %>'
                        runat="server" Text="Eliminar" />
                    <asp:Button ID="btnEditar" CssClass="Boton" CommandName="Editar" CommandArgument='<%#Container.DataItemIndex %>'
                        runat="server" Text="Editar" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="GridHeader" />
        <RowStyle CssClass="GridItem" />
        <AlternatingRowStyle CssClass="GridAltItem" />
    </asp:GridView>
    <asp:Panel ID="pnlRegistroTipoCuenta" CssClass="Formulario" runat="server">
        <AVC:TipoCuenta ID="ctlTipoCuenta" runat="server" />
    </asp:Panel>
    </div>
</asp:Content>
