<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCCOAI.aspx.vb" Inherits="CONFIG_FGCCOAI" %>
<%@ Register  TagPrefix="AVC"  TagName="TipoAnalisis" Src="~/CONTROLES/REGISTRO/ctlTipoAnalisis_Registrarl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div class="TituloPrincipal">TIPO DE ANALISIS - LISTADO</div>
<asp:HiddenField runat="server" ID="hdnUsuario" />
<asp:HiddenField runat="server" ID="hdnEmpresa" />

  <div class="Opciones">
    <asp:Button ID="btnBuscar" CssClass="Boton" runat="server" Text="Buscar" />
    <asp:Button ID="btnNuevo" CssClass="Boton" runat="server" Text="Nuevo" />
    <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
 </div>
 <br />
<asp:GridView ID="grdTipoAnalisis" Width="700" ShowFooter="true" 
        AutoGenerateColumns="false" runat="server" AllowPaging="true" >

    <Columns>
    <asp:BoundField DataField="IdTipoAnalisis" HeaderText="IdTipoAnalisis" />
    <asp:BoundField DataField="IdEmpresa" HeaderText="Cod_Empresa" HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible"/>
    <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" />
    <asp:BoundField DataField="TipoAnalisis" HeaderText="Descripcion" />

        <asp:TemplateField>
            <ItemTemplate> 
                <asp:Button ID="btnEliminar" CssClass="Boton" CommandName="ELIMINAR" CommandArgument='<%#Container.DataItemIndex %>' runat="server" Text="Eliminar" />
                <asp:Button ID="btnEditar" CssClass="Boton" CommandName="EDITAR" CommandArgument='<%#Container.DataItemIndex %>' runat="server" Text="Editar" />
            </ItemTemplate>  
        </asp:TemplateField>
    </Columns>

        <headerStyle CssClass="GridHeader" />
        <RowStyle CssClass="GridItem"  />
        <AlternatingRowStyle CssClass="GridAltItem" />

</asp:GridView>



 <asp:Panel ID="pnlRegistroTipoAnalisis"  CssClass="Formulario" runat="server"> 
    <AVC:TipoAnalisis ID="ctlTipoAnalisis" runat="server" /> 
 </asp:Panel>
 </div>
</asp:Content>

