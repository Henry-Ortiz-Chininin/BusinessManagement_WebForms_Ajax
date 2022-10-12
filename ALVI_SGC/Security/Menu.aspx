<%@ Page Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="Menu.aspx.vb" Inherits="Menu" title="Sistema de Gestión de Costos - Alta Visión Consultores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="divCuerpo">
    <div id="divOpciones">
    <table cellpadding="0" cellspacing="1" border="0">
        <tr>
        <td><asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'" onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" /></td>
        <td><asp:ImageButton ID="btnNuevo" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'" onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif" /></td>
        <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
       </tr>
        </table>
    </div>
    <table cellpadding="1" cellspacing="1" border="0">
                    <tr>
                        <td>Nivel 1</td>
                        <td><asp:DropDownList ID="ddlBuscar1" runat="server" AutoPostBack="True" CssClass="InputText">
                        </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>Nivel 2</td>
                        <td>
                        <asp:UpdatePanel ID="updBuscar2" runat="server">
                            <ContentTemplate>
                            <asp:DropDownList ID="ddlBuscar2" runat="server" AutoPostBack="True" CssClass="InputText">
                            </asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlBuscar1" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>Nivel 3</td>
                        <td><asp:UpdatePanel ID="updBuscar3" runat="server">
                            <ContentTemplate>
                            <asp:DropDownList ID="ddlBuscar3" runat="server" CssClass="InputText">
                        </asp:DropDownList>
                        </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlBuscar2" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                        </td>
                    </tr>

                </table>
   
        <asp:GridView ID="grdMenu" runat="server" AutoGenerateColumns="False" ShowFooter="True" DataKeyNames="int_IDMenu">
            <Columns>
                <asp:BoundField DataField="int_IDMenu" HeaderText="Id" />
                <asp:BoundField DataField="int_IDMenuPadre" HeaderText="Antecesor" />
                <asp:BoundField DataField="var_TituloMenu" HeaderText="Titulo" />
                <asp:BoundField DataField="var_RutaMenu" HeaderText="Ruta" />
                <asp:BoundField DataField="bit_Contenedor" HeaderText="Contenedor" />
                <asp:BoundField DataField="int_Nivel" HeaderText="Nivel" />
                <asp:BoundField DataField="chr_Estado" HeaderText="Estado" />
                <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" />                    
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEdit" runat="server" CommandName="Edit" ImageUrl="~/images/btnAbrir.gif" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:ImageButton CommandName="Eliminar" CommandArgument='<%# Container.Dataitem("int_IDMenu") %>'  ID="btnElimina" runat="server" ImageUrl="~/images/btnDesactivar.gif" />
                        <asp:ImageButton CommandName="Restaurar" CommandArgument='<%# Container.Dataitem("int_IDMenu") %>'  ID="btnRestaurar" runat="server" ImageUrl="~/images/btnActivar.gif" />
                    </ItemTemplate>
                </asp:TemplateField>            
                </Columns>
                    <HeaderStyle CssClass="GridHeader" />
                    <FooterStyle CssClass="GridFooter" />
                    <RowStyle CssClass="GridItem" />
                    <AlternatingRowStyle CssClass="GridAltItem" />
        </asp:GridView>
       
        <asp:Panel ID="pnlFormulario" CssClass="Formulario" runat="server">
        <div id="divTitulo">Registro - Opcion de Menu</div>
        <table cellpadding="1" cellspacing="1" border="0">
        <tr>
            <td>Antecesor: <br />
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
                            <asp:DropDownList ID="ddlNivel3" runat="server" CssClass="InputText">
                        </asp:DropDownList>
                        </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlNivel2" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                        </td>
                    </tr>

                </table>

            </td>
            <td>
                <table cellpadding="1" cellspacing="1" border="0">
                <tr>
                        <td>Codigo</td>
                        <td>
                        <asp:TextBox ID="txtCodigo" runat="server" ReadOnly="true" CssClass="InputText"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Titulo</td>
                        <td>
                        <asp:TextBox ID="txtTitulo" runat="server" CssClass="InputText"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Ruta</td>
                        <td>
                        <asp:TextBox ID="txtRuta" runat="server" CssClass="InputText"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Es contenedor</td>
                        <td>
                        <asp:DropDownList ID="ddlContenedor" runat="server" CssClass="InputText">
                            <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                            <asp:ListItem Value="1">Si</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>Nivel</td>
                        <td>
                        <asp:Label runat="server" ID="lblNivel" ></asp:Label> 
                        </td>
                    </tr>
                    <tr>
                        <td>Estado</td>
                        <td>
                        <asp:Label runat="server" ID="lblEstado" ></asp:Label> 
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ImageButton ID="btnTerminar" CssClass="Boton" onmouseover="this.src='../images/btnRegistroCierre_on.gif';" onmouseout="this.src='../images/btnRegistroCierre.gif';" ImageUrl="../images/btnRegistroCierre.gif" runat="server" />
                <asp:ImageButton ID="btnRegistrar" CssClass="Boton" onmouseover="this.src='../images/btnRegistrar_on.gif';" onmouseout="this.src='../images/btnRegistrar.gif';" ImageUrl="../images/btnRegistrar.gif" runat="server" />
                <asp:ImageButton ID="btnCancelar" CssClass="Boton" onmouseover="this.src='../images/btnCancelar_on.gif';" onmouseout="this.src='../images/btnCancelar.gif';" ImageUrl="../images/btnCancelar.gif" runat="server" />
            </td>
        </tr>
        </table>

        <div id="divFooter">
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
            <img src="../images/loader.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>&nbsp;</div>    
        </asp:Panel>
     </div>

    </asp:Content>