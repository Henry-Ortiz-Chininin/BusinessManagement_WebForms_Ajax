<%@ Page Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="UsuarioMenu.aspx.vb" Inherits="UsuarioMenu" title="Sistema de Gestión de Costos - Alta Visión Consultores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="divCuerpo">
        <input type="hidden" name = "hdnIDUsuario" id="hdnIdUsuario" runat="server" />
        <asp:GridView ID="grdPerfil" runat="server" AutoGenerateColumns="False" ShowFooter="True" >
            <Columns>
                <asp:TemplateField HeaderText="Menu (Nivel 0)">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblNivel0" Text='<%#Container.Dataitem("var_NombreNivel0") %>'></asp:Label> 
                    </ItemTemplate>                
                    <FooterTemplate>
                        <asp:DropDownList ID="ddlNivel0" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNivel0_SelectedIndexChanged" CssClass="InputText">
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Menu (Nivel 1)">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblNivel1" Text='<%#Container.Dataitem("var_NombreNivel1") %>'></asp:Label> 
                    </ItemTemplate>                
                    <FooterTemplate>
                        <asp:DropDownList ID="ddlNivel1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNivel1_SelectedIndexChanged" CssClass="InputText">
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Menu (Nivel 2)">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblNivel2" Text='<%#Container.Dataitem("var_NombreNivel2") %>'></asp:Label> 
                    </ItemTemplate>                
                    <FooterTemplate>
                        <asp:DropDownList ID="ddlNivel2" runat="server" CssClass="InputText">
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>   
                <asp:TemplateField>
                    <FooterTemplate>
                        <asp:ImageButton  ID="btnAgregar" runat="server" CommandName="Agregar" ImageUrl="~/images/btnRegistrar.gif" />
                   </FooterTemplate>
                    <ItemTemplate>
                        <asp:ImageButton CommandName="Eliminar" CommandArgument='<%#Container.Dataitem("int_IDMenu") %>'  ID="btnElimina" runat="server" ImageUrl="~/images/btnEliminar.gif" />
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