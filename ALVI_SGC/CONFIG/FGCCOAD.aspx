<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false"
    CodeFile="FGCCOAD.aspx.vb" Inherits="CONFIG_FGCCOAD" %>

<%@ Register TagPrefix="UC" TagName="EjercicioMes" Src="~/CONTROLES/REGISTRO/ctlEjercicioMes_Registrar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div id="divCuerpo">
    <asp:HiddenField runat="server" ID="hdnEmpresa" />
    <div class="TituloPrincipal">
        EJERCICIO MES - LISTADO</div>
    <div class="Opciones">
        <asp:Button ID="btnBuscar" CssClass="Boton" runat="server" Text="Buscar" />
        <asp:Button ID="btnNuevo" CssClass="Boton" runat="server" Text="Nuevo" />
        <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
    </div>
    <center>
        <asp:GridView ID="grdDatos" Width="800" ShowFooter="true" AutoGenerateColumns="false"
            runat="server" AllowPaging="true">
            <Columns>
                <asp:BoundField DataField="IdEjercicioMes" HeaderText="ID" />
                <asp:BoundField DataField="IdEmpresa" HeaderText="Cod_Empresa" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="IdEmpresa" HeaderText="Empresa" />
                <asp:BoundField DataField="IdEjercicioEmpresa" HeaderText="Ejercicio_Empresa" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="Ejercicio" HeaderText="Ejercicio" />
                <asp:BoundField DataField="FechaInicio" HeaderText="Inicio" DataFormatString="{0:dd/MM/yy}"
                    HtmlEncode="false" />
                <asp:BoundField DataField="FechaFinal" HeaderText="Fin" DataFormatString="{0:dd/MM/yy}"
                    HtmlEncode="false" />
                <asp:BoundField DataField="EjercicioMes" HeaderText="Descripcion" />
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
    <asp:Panel ID="pnlEjercicioMes" CssClass="Formulario" runat="server">
        <UC:EjercicioMes ID="ctlEjercicioMes" runat="server" />
    </asp:Panel>
    </div>
</asp:Content>
