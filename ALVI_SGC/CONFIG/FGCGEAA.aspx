<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCGEAA.aspx.vb" Inherits="GENERAL_FGCGEAA" %>
<%@ Register  TagPrefix="AVC"  TagName="Empresa" Src="~/CONTROLES/REGISTRO/ctlEmpresa_Registrar.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:HiddenField runat="server" ID="hdnUsuario" />
<div class="TituloPrincipal">EMPRESA - LISTADO</div>

 <div class="Opciones">
    <asp:Button ID="btnBuscar" CssClass="Boton" runat="server" Text="Buscar" />
    <asp:Button ID="btnNuevo" CssClass="Boton" runat="server" Text="Nuevo" />
    <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
 </div>

<asp:GridView ID="grdEmpresa" Width="700" ShowFooter="true" 
        AutoGenerateColumns="false" runat="server" AllowPaging="true" >
<Columns>
 <asp:BoundField DataField="IdEmpresa" HeaderText="IdEmpresa" HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
 <asp:BoundField DataField="Ruc" HeaderText="Ruc" />
 <asp:BoundField DataField="RazonSocial" HeaderText="RazonSocial" />
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

<asp:Panel ID="pnlRegistroEmpresa" CssClass="Formulario" runat="server"> 
<AVC:Empresa ID="ctlEmpresa" runat="server" /> 
</asp:Panel>

</asp:Content>

