<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false"
    CodeFile="FGCCOAB.aspx.vb" Inherits="CONFIG_FGCCOAB" %>

<%@ Register TagPrefix="CO" TagName="Ejercicio" Src="~/CONTROLES/REGISTRO/ctlEjercicio_Registro.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div id="divCuerpo">
    <asp:HiddenField runat="server" ID="hdnUsuario" />
    <asp:HiddenField runat="server" ID="hdnEmpresa" />
    <div class="TituloPrincipal">
        EJERCICIO - LISTADO</div>
    <div class="Opciones">
        <asp:Button ID="btnBuscar" CssClass="Boton" runat="server" Text="Buscar" />
        <asp:Button ID="btnNuevo" CssClass="Boton" runat="server" Text="Nuevo" />
        <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
    </div>
    <br />
    <center>
        <asp:GridView ID="grdDatos" Width="700px" ShowFooter="True" AutoGenerateColumns="False"
            runat="server" AllowPaging="True" PageSize="20">
            <Columns>
                <asp:BoundField DataField="IdEjercicio" HeaderText="ID" />
                <asp:BoundField DataField="IdEmpresa" HeaderText="Cod_Empresa" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible">
                    <FooterStyle CssClass="NoVisible"></FooterStyle>
                    <HeaderStyle CssClass="NoVisible"></HeaderStyle>
                    <ItemStyle CssClass="NoVisible"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="IdEmpresa" HeaderText="Empresa" />
                <asp:BoundField DataField="FechaInicio" HeaderText="Inicio" DataFormatString="{0:dd/MM/yy}"
                    HtmlEncode="False" />
                <asp:BoundField DataField="FechaFinal" HeaderText="Final" DataFormatString="{0:dd/MM/yy}"
                    HtmlEncode="false" />
                <asp:BoundField DataField="Ejercicio" HeaderText="Ejercicio" />
                <asp:BoundField DataField="Agno" HeaderText="Año" />
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
    <asp:Panel ID="pnlEjercicio" CssClass="Formulario" runat="server">
        <CO:Ejercicio ID="ctlEjercicio" runat="server" />
    </asp:Panel>
    </div>
</asp:Content>
