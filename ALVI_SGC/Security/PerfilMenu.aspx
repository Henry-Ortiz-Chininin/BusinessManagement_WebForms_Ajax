<%@ Page Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="PerfilMenu.aspx.vb" Inherits="PerfilMenu" title="Sistema de Gestión de Costos - Alta Visión Consultores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="divCuerpo">
    <div id="divOpciones">
    <table cellpadding="0" cellspacing="1" border="0">
        <tr>
        <td><asp:ImageButton ID="btnRegistrar" CssClass="Boton" onmouseover="this.src='../images/btnRegistrar_on.gif';" onmouseout="this.src='../images/btnRegistrar.gif';" ImageUrl="../images/btnRegistrar.gif" runat="server" /></td>
        <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
       </tr>
    </table>
    </div>
        <input type="hidden" name = "hdnIDPerfil" id="hdnIDPerfil" runat="server" />
        <table cellpadding="1" cellspacing="1" border="0">
            <tr>
                <td>Nivel 1</td>
                <td><asp:DropDownList ID="ddlNivel1" runat="server" AutoPostBack="True" CssClass="InputText">
                </asp:DropDownList></td>
            </tr>
            <tr>
                <td>Nivel 2</td>
                <td>
                <asp:UpdatePanel ID="updNivel2" runat="server">
                    <ContentTemplate>
                    <asp:DropDownList ID="ddlNivel2" runat="server" AutoPostBack="True" CssClass="InputText">
                    </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlNivel1" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>Nivel 3</td>
                <td><asp:UpdatePanel ID="updNivel3" runat="server">
                    <ContentTemplate>
                    <asp:DropDownList ID="ddlNivel3" runat="server" AutoPostBack="true" CssClass="InputText">
                </asp:DropDownList>
                </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlNivel2" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>Nivel 4</td>
                <td><asp:UpdatePanel ID="updNivel4" runat="server">
                    <ContentTemplate>
                    <asp:DropDownList ID="ddlNivel4" runat="server" CssClass="InputText">
                </asp:DropDownList>
                </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlNivel3" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <asp:GridView ID="grdPerfil" runat="server" AutoGenerateColumns="False" ShowFooter="True" >
            <Columns>
                <asp:TemplateField HeaderText="Perfil">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblIDPerfil" Text='<%#Container.Dataitem("var_NombrePerfil") %>'></asp:Label> 
                    </ItemTemplate>                
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Menu (Nivel 0)">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblNivel0" Text='<%#Container.Dataitem("var_NombreNivel0") %>'></asp:Label> 
                    </ItemTemplate>                
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Menu (Nivel 1)">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblNivel1" Text='<%#Container.Dataitem("var_NombreNivel1") %>'></asp:Label> 
                    </ItemTemplate>                
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Menu (Nivel 2)">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblNivel2" Text='<%#Container.Dataitem("var_NombreNivel2") %>'></asp:Label> 
                    </ItemTemplate>                
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="Menu (Nivel 3)">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblNivel3" Text='<%#Container.Dataitem("var_NombreNivel3") %>'></asp:Label> 
                    </ItemTemplate>                
                </asp:TemplateField> 
                  
                <asp:TemplateField>
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