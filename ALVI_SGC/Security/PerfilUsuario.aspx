<%@ Page Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="PerfilUsuario.aspx.vb" Inherits="PerfilUsuario" title="Sistema de Gestión de Costos - Alta Visión Consultores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="divCuerpo">
        <input type="hidden" name = "hdnIDPerfil" id="hdnIDPerfil" runat="server" />
        <asp:GridView ID="grdPerfil" runat="server" AutoGenerateColumns="False" ShowFooter="True" DataKeyNames="var_IDUsuario">
            <Columns>
                <asp:TemplateField HeaderText="Perfil">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblIDPerfil" Text='<%#Container.Dataitem("var_NombrePerfil") %>'></asp:Label> 
                    </ItemTemplate>                
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Usuario">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblUsuario" Text='<%#Container.Dataitem("var_Nombre") %>'></asp:Label> 
                    </ItemTemplate>                
                    <FooterTemplate>
                        <asp:TextBox ID="txtIDUsuarioF" runat="server" CssClass="InputText"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>                                              
                <asp:TemplateField>
                    <FooterTemplate>
                        <asp:ImageButton ID="btnAgregar" runat="server" CommandName="Agregar" ImageUrl="~/images/btnRegistrar.gif" />
                   </FooterTemplate>
                    <ItemTemplate>
                        <asp:ImageButton CommandName="Eliminar" CommandArgument='<%# Container.Dataitem("var_IDUsuario") %>'  ID="btnElimina" runat="server" ImageUrl="~/images/btnEliminar.gif" />
                    </ItemTemplate>
                </asp:TemplateField>
               </Columns>
            <FooterStyle CssClass="GridFooter" />
            <RowStyle CssClass="GridItem" />
            <HeaderStyle CssClass="GridHeader" />
            <AlternatingRowStyle CssClass="GridAltItem" />
        </asp:GridView>
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label></div>
</asp:Content>