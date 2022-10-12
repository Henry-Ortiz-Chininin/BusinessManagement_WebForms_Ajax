<%@ Page Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="Usuario.aspx.vb" Inherits="Usuario" title="Sistema de Gestión de Costos - Alta Visión Consultores" %>
<%@ MasterType VirtualPath="~/Masterpage/General.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="divCuerpo">
<div id="divHeader">Registro de Usuarios</div>
<div id="divOpciones">
<table cellpadding="1" cellspacing="1" border="0">
    <tr>
    <td><asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'" onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
    </tr>
    </table>
</div>
<table cellpadding="1" cellspacing="1" border="0">
    <tr>
    <td class="Titulo12">Login</td>
    <td>
        <asp:TextBox ID="txtUsuario" CssClass="Texto12" runat="server"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td class="Titulo12">Nombre</td>
    <td>
        <asp:TextBox ID="txtNombre" CssClass="Texto12" runat="server"></asp:TextBox>
    </td>
    </tr>
    </table>

        <asp:GridView ID="grdUsuarios" runat="server" AutoGenerateColumns="False" ShowFooter="True" DataKeyNames="var_IDUsuario">
            <Columns>
                <asp:TemplateField HeaderText="Login">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblLogin" Text='<%#Container.Dataitem("var_IDUsuario") %>'></asp:Label> 
                    </ItemTemplate>                
                    <EditItemTemplate>
                        <asp:Label ID="lblLoginE" runat="server" Text='<%#Container.Dataitem("var_IDUsuario") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtLoginF" runat="server" CssClass="InputText"></asp:TextBox>
                    </FooterTemplate>
                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblNombre" Text='<%#Container.Dataitem("var_Nombre") %>'></asp:Label> 
                    </ItemTemplate>                
                    <EditItemTemplate>
                        <asp:TextBox ID="txtNombreE" runat="server" Text='<%#Container.Dataitem("var_Nombre") %>' CssClass="InputText"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtNombreF" runat="server" CssClass="InputText"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Clave">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblClave" Text='<%#Container.Dataitem("var_Clave") %>'></asp:Label> 
                    </ItemTemplate>                
                    <EditItemTemplate>
                        <asp:TextBox ID="txtClaveE" TextMode="Password"  runat="server" CssClass="InputText" Text='<%#Container.Dataitem("var_Clave") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtClaveF" TextMode="Password"  runat="server" CssClass="InputText"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Estado">
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
                        <asp:ImageButton CommandName="Eliminar" CommandArgument='<%# Container.Dataitem("var_IDUsuario") %>'  ID="btnElimina" runat="server" ImageUrl="~/images/btnDesactivar.gif" />
                        <asp:ImageButton CommandName="Restaurar"  CommandArgument='<%# Container.Dataitem("var_IDUsuario") %>'  ID="btnRestaurar" runat="server" ImageUrl="~/images/btnActivar.gif"/>
                    </ItemTemplate>
                </asp:TemplateField>           
                <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:ImageButton CommandName="Menu" CommandArgument='<%# Container.Dataitem("var_IDUsuario") %>'  ID="btnMenu" runat="server" ImageUrl="~/images/btnPermisos.gif" />
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