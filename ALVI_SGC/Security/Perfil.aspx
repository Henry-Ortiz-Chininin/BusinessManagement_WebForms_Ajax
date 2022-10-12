<%@ Page Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="Perfil.aspx.vb" Inherits="Perfil" title="Sistema de Gestión de Costos - Alta Visión Consultores" %>
<%@ MasterType VirtualPath="~/Masterpage/General.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="divCuerpo">
        <asp:GridView ID="grdPerfil" runat="server" AutoGenerateColumns="False" ShowFooter="True" DataKeyNames="int_IDPerfil">
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <HeaderStyle CssClass="GridHeader" />
                    <FooterStyle CssClass="GridFooter" />
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblIDPerfil" Text='<%#Container.Dataitem("int_IDPerfil") %>'></asp:Label> 
                    </ItemTemplate>                
                    <EditItemTemplate>
                        <asp:Label ID="lblIDPerfilE" runat="server" Text='<%#Container.Dataitem("int_IDPerfil") %>'></asp:Label>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nombre">
                    <HeaderStyle CssClass="GridHeader" />
                    <FooterStyle CssClass="GridFooter" />
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblNombre" Text='<%#Container.Dataitem("var_NombrePerfil") %>'></asp:Label> 
                    </ItemTemplate>                
                    <EditItemTemplate>
                        <asp:TextBox ID="txtNombreE" runat="server" Text='<%#Container.Dataitem("var_NombrePerfil") %>' CssClass="InputText"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtNombreF" runat="server" CssClass="InputText"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Estado">
                    <HeaderStyle CssClass="GridHeader" />
                    <FooterStyle CssClass="GridFooter" />
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblEstado" Text='<%#Container.Dataitem("chr_Estado") %>'></asp:Label> 
                    </ItemTemplate>
                    <FooterTemplate>
                        &nbsp;<asp:DropDownList ID="ddlEstado" runat="server" CssClass="InputText">
                            <asp:ListItem Selected="True" Value="ACT">Activo</asp:ListItem>
                            <asp:ListItem Value="INA">Inactivo</asp:ListItem>
                        </asp:DropDownList>
                    </FooterTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblEstadoE" runat="server" Text='<%# Container.Dataitem("chr_Estado") %>'></asp:Label>
                    </EditItemTemplate>
                </asp:TemplateField>            
                <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center" />
                    <FooterTemplate>
                        <asp:ImageButton ID="btnAgregar" runat="server" CommandName="Agregar" ImageUrl="~/images/btnRegistrar.gif" />
                   </FooterTemplate>
                  <EditItemTemplate>
                        <asp:ImageButton ID="btnUpdate" runat="server" CommandName="Actualizar" ImageUrl="~/images/btnRegistrar.gif" />
                  </EditItemTemplate> 
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEdit" runat="server" CommandName="Edit" ImageUrl="~/images/btnAbrir.gif" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:ImageButton CommandName="Eliminar" CommandArgument='<%# Container.Dataitem("int_IDPerfil") %>'  ID="btnElimina" runat="server" ImageUrl="~/images/btnDesactivar.gif" />
                        <asp:ImageButton CommandName="Restaurar"  CommandArgument='<%# Container.Dataitem("int_IDPerfil") %>'  ID="btnRestaurar" runat="server" ImageUrl="~/images/btnActivar.gif" />
                    </ItemTemplate>
                </asp:TemplateField>            
                <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:ImageButton CommandName="Usuarios" CommandArgument='<%# Container.Dataitem("int_IDPerfil") %>'  ID="btnUsuarios" runat="server" ImageUrl="~/images/btnUsuarios.gif" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:ImageButton CommandName="Menu" CommandArgument='<%# Container.Dataitem("int_IDPerfil") %>'  ID="btnMenu" runat="server" ImageUrl="~/images/btnPermisos.gif" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEspecial" CommandArgument='<%#Container.DataItem("int_IDPerfil") %>' CommandName="Especial" ImageUrl="../images/btnEspecial.gif" runat="server" onmouseover="this.src='../images/btnEspecial_on.gif'" onmouseout="this.src='../images/btnEspecial.gif'" />                        
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
            <HeaderStyle CssClass="GridHeader" />
            <FooterStyle CssClass="GridFooter" />
            <RowStyle CssClass="GridItem" />
            <AlternatingRowStyle CssClass="GridAltItem" />
        </asp:GridView>
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label></div>
</asp:Content>