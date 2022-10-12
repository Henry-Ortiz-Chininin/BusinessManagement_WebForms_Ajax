<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false"
    CodeFile="FGCCOAP.aspx.vb" Inherits="CONFIG_FGCCOAP" %>

<%@ Register TagPrefix="AVC" TagName="UsuarioEmpresa" Src="~/CONTROLES/REGISTRO/ctlUsuarioEmpresa_Registro.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div id="divCuerpo">
    <div class="TituloPrincipal">
        USUARIO EMPRESA - LISTADO</div>
    <div class="Opciones">
        <asp:HiddenField runat="server" ID="hdnUsuario" />
        <asp:HiddenField runat="server" ID="hdnEmpresa" />
        <asp:Button ID="btnBuscar" CssClass="Boton" runat="server" Text="Buscar" />
        <asp:Button ID="btnNuevo" CssClass="Boton" runat="server" Text="Nuevo" />
        <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
    </div>
    <br />
    <asp:GridView ID="grdUsuarioEmpresa" Width="700" ShowFooter="true" AutoGenerateColumns="false"
        runat="server" AllowPaging="true">
        <Columns>
            <asp:BoundField DataField="IdEmpresa" HeaderText="IdEmpresa" HeaderStyle-CssClass="NoVisible"
                ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
            <asp:BoundField DataField="IdUsuario" HeaderText="Login" />
            <asp:BoundField DataField="Nombre" HeaderText="Identificacion de Usuario" />
            <asp:BoundField DataField="RazonSocial" HeaderText="RazonSocial" />
            <asp:BoundField DataField="Ruc" HeaderText="Ruc" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnEliminar" CssClass="Boton" CommandName="ELIMINAR" CommandArgument='<%#Container.DataItemIndex %>'
                        runat="server" Text="Eliminar" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="GridHeader" />
        <RowStyle CssClass="GridItem" />
        <AlternatingRowStyle CssClass="GridAltItem" />
    </asp:GridView>
    <asp:Panel ID="pnlRegistroUsuarioEmpresa" CssClass="Formulario" runat="server">
        <AVC:UsuarioEmpresa ID="ctlUsuarioEmpresa" runat="server" />
    </asp:Panel>
    </div>
</asp:Content>
