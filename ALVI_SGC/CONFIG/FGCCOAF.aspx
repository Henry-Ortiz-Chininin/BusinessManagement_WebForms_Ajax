<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false"
    CodeFile="FGCCOAF.aspx.vb" Inherits="CONFIG_FGCCOAF" %>

<%@ Register TagPrefix="UC" TagName="PlanContable" Src="~/CONTROLES/REGISTRO/ctlPlanContable_Registro.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div id="divCuerpo">
    <div class="TituloPrincipal">
        CONFIGURACION CONTABLE - LISTADO</div>
    <asp:HiddenField runat="server" ID="hdnUsuario" />
    <asp:HiddenField runat="server" ID="hdnEmpresa" />
    <div class="Opciones">
        <asp:Button ID="btnBuscar" CssClass="Boton" runat="server" Text="Buscar" />
        <asp:Button ID="btnNuevo" CssClass="Boton" runat="server" Text="Nuevo" />
        <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
    </div>
    <br />
    <asp:GridView ID="grdDatos" Width="700" ShowFooter="true" AutoGenerateColumns="false"
        runat="server" AllowPaging="true">
        <Columns>
            <asp:BoundField DataField="IdPlanContable" HeaderText="ID" />
            <asp:BoundField DataField="IdEmpresa" HeaderText="Cod_Empresa" HeaderStyle-CssClass="NoVisible"
                ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
            <asp:BoundField DataField="IdEmpresa" HeaderText="Empresa" />
            <asp:BoundField DataField="Contabilidad" HeaderText="Cod_Conta" HeaderStyle-CssClass="NoVisible"
                ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
            <asp:BoundField DataField="IdContabilidad" HeaderText="Contabilidad" />
            <asp:BoundField DataField="Formato" HeaderText="Formato" />
            <asp:BoundField DataField="LongitudNivel1" HeaderText="Nivel 1" />
            <asp:BoundField DataField="LongitudNivel2" HeaderText="Nivel 2" />
            <asp:BoundField DataField="LongitudNivel3" HeaderText="Nivel 3" />
            <asp:BoundField DataField="LongitudNivel4" HeaderText="Nivel 4" />
            <asp:BoundField DataField="LongitudNivel5" HeaderText="Nivel 5" />
            <asp:BoundField DataField="LongitudNivel6" HeaderText="Nivel 6" />
            <asp:BoundField DataField="LongitudNivel7" HeaderText="Nivel 7" />
            <asp:BoundField DataField="LongitudNivel8" HeaderText="Nivel 8" />
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
    <asp:Panel ID="pnlPlanContable" CssClass="Formulario" runat="server">
        <UC:PlanContable ID="ctlPlanContable" runat="server" />
    </asp:Panel>
    </div>
</asp:Content>
