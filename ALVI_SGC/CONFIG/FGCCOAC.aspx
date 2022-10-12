<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false"
    CodeFile="FGCCOAC.aspx.vb" Inherits="CONFIG_FGCCOAC" %>

<%@ Register TagPrefix="UC" TagName="EjercicioEmpresa" Src="~/CONTROLES/REGISTRO/ctlEjercicioEmpresa_Registro.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div id="divCuerpo">
    <asp:HiddenField runat="server" ID="hdnEmpresa" />
    <div class="TituloPrincipal">
        EJERCICIO EMPRESA - LISTADO</div>
    <div class="Opciones">
        <asp:Button ID="btnBuscar" CssClass="Boton" runat="server" Text="Buscar" />
        <asp:Button ID="btnNuevo" CssClass="Boton" runat="server" Text="Nuevo" />
        <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
    </div>
    <br />
    <div id="divGRidview" runat="server">
        <center>
            <asp:GridView ID="grdDatos" Width="800" ShowFooter="true" AutoGenerateColumns="false"
                runat="server" AllowPaging="true">
                <Columns>
                    <asp:BoundField DataField="IdEjercicioEmpresa" HeaderText="ID" />
                    <asp:BoundField DataField="IdEmpresa" HeaderText="Cod_Empresa" HeaderStyle-CssClass="NoVisible"
                        ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                    <asp:BoundField DataField="IdEmpresa" HeaderText="Empresa" />
                    <asp:BoundField DataField="IdContabilidad" HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible"
                        FooterStyle-CssClass="NoVisible" />
                    <asp:BoundField DataField="Contabilidad" HeaderText="Contabilidad" />
                    <asp:BoundField DataField="IdEjercicio" HeaderText="cod_Ejercicio" HeaderStyle-CssClass="NoVisible"
                        ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                    <asp:BoundField DataField="Ejercicio" HeaderText="Fecha" />
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
        </center>
    </div>
    <asp:Panel ID="pnlEjercicioEmpresa" CssClass="Formulario" runat="server">
        <UC:EjercicioEmpresa ID="ctlEjercicioEmpresa" runat="server" />
    </asp:Panel>
    </div>
</asp:Content>
