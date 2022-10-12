<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false"
    CodeFile="FGCCOAN.aspx.vb" Inherits="CONFIG_FGCCOAN" %>

<%@ Register TagPrefix="AVEF" TagName="EntidadFinanciera" Src="~/CONTROLES/REGISTRO/ctlEntidadFinanciera.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div id="divCuerpo">
    <div class="TituloPrincipal">
        ENTIDAD FINANCIERA- LISTADO</div>
    <asp:HiddenField runat="server" ID="hdnUsuario" />
    <asp:HiddenField runat="server" ID="hdnEmpresa" />
    <div class="Opciones">
        <asp:Button ID="btnBuscar" CssClass="Boton" runat="server" Text="Buscar" />
        <asp:Button ID="btnNuevo" CssClass="Boton" runat="server" Text="Nuevo" />
        <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
    </div>
    <center>
        <asp:GridView ID="grdEntidadFinanciera" Width="700" ShowFooter="true" AutoGenerateColumns="false"
            runat="server" AllowPaging="true" PageSize="10">
            <Columns>
                <asp:BoundField DataField="IdEntidadFinanciera" HeaderText="IdEntidadFinanciera" />
                <asp:BoundField DataField="IdEmpresa" HeaderText="cod_Empresa" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="IdEmpresa" HeaderText="Razon Social" />
                <asp:BoundField DataField="NombreEntidad" HeaderText="Descripcion" />
                <asp:BoundField DataField="IdSunat" HeaderText="Sunat" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnEliminar" CssClass="Boton" CommandName="ELIMINAR" CommandArgument='<%#Container.DataItemIndex %>'
                            runat="server" Text="Eliminar" />
                        <asp:Button ID="btnEditar" CssClass="Boton" CommandName="EDITAR" CommandArgument='<%#Container.DataItemIndex %>'
                            runat="server" Text="Editar" />
                        <asp:Button ID="btnDetalle" CssClass="Boton" CommandName="DETALLE" CommandArgument='<%#Container.DataItemIndex %>'
                            runat="server" Text="Detalle" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="GridHeader" />
            <RowStyle CssClass="GridItem" />
            <AlternatingRowStyle CssClass="GridAltItem" />
        </asp:GridView>
    </center>
    <asp:Panel ID="pnlEntidadFinanciera" CssClass="Formulario" runat="server">
        <AVEF:EntidadFinanciera ID="ctlEntidadFinanciera" runat="server" />
    </asp:Panel>
    </div>
</asp:Content>
