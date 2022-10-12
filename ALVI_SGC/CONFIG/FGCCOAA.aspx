<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false"
    CodeFile="FGCCOAA.aspx.vb" Inherits="CONFIG_FGCCOAA" %>

<%@ Register TagPrefix="UC" TagName="Contabilidad" Src="~/CONTROLES/REGISTRO/ctlContabilidad_Registro.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div id="divCuerpo">
    <asp:HiddenField runat="server" ID="hdnEmpresa" />
    <div id="divHeader">CONTABILIDAD - LISTADO</div>
    <div class="Opciones">
        <asp:Button ID="btnBuscar" CssClass="Boton" runat="server" Text="Buscar" />
        <asp:Button ID="btnNuevo" CssClass="Boton" runat="server" Text="Nuevo" />
        <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
    </div>
    <br />
    <asp:GridView ID="grdDatos" Width="800" ShowFooter="true" AutoGenerateColumns="false"
        runat="server" AllowPaging="true">
        <Columns>
            <asp:BoundField DataField="IdContabilidad" HeaderText="ID" />
            <asp:BoundField DataField="IdEmpresa" HeaderText="IdEmpresa" HeaderStyle-CssClass="NoVisible"
                ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
            <asp:BoundField DataField="IdEmpresa" HeaderText="Empresa" />
            <asp:BoundField DataField="IdMoneda" HeaderText="cod_Moneda" HeaderStyle-CssClass="NoVisible"
                ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
            <asp:BoundField DataField="Moneda" HeaderText="Moneda" />
            <asp:BoundField DataField="Contabilidad" HeaderText="Descripción" />
            <asp:BoundField DataField="CuentaGananciaCambio" HeaderText="Ganancia Cambio" HeaderStyle-CssClass="NoVisible"
                ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
            <asp:BoundField DataField="CuentaPerdidaCambio" HeaderText="Perdida Cambio" HeaderStyle-CssClass="NoVisible"
                ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
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
    <asp:Panel ID="pnlContabilidad" CssClass="Formulario" runat="server">
        <UC:Contabilidad ID="ctlContabilidad" runat="server" />
    </asp:Panel>
    </div>
</asp:Content>
