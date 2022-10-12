<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false"
    CodeFile="FGCCOAQ.aspx.vb" Inherits="CONFIG_FGCCOAQ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div id="divCuerpo">
    <div class="TituloPrincipal">
        SUB-OPERACIÓN - LISTADO / Operacion :
        [<asp:Label runat="server" ID="lblOperacion" Width="100px"></asp:Label>]
        <asp:Label runat="server" ID="lblNivel1" Width="100px"></asp:Label>
        <asp:Label runat="server" ID="lblNivel2" Width="100px"></asp:Label>
    </div>
    <div class="Opciones">
        <asp:HiddenField runat="server" ID="hdnUsuario" />
        <asp:HiddenField runat="server" ID="hdnEmpresa" />
        <asp:HiddenField runat="server" ID="hdnOperacion" />
        <asp:HiddenField runat="server" ID="hdnflag" />
        <asp:HiddenField runat="server" ID="hdnNivel" />
        <asp:HiddenField runat="server" ID="hdnUbicacion" />
        <asp:Button ID="btnBuscar" CssClass="Boton" runat="server" Text="Buscar" />
        <asp:Button ID="btnNuevo" CssClass="Boton" runat="server" Text="Nuevo" />
        <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
    </div>
    <table width="100%">
        <tr>
            <td valign="top">
                <asp:GridView ID="grDatos" Width="700px" ShowFooter="True" AutoGenerateColumns="False"
                    runat="server" AllowPaging="True">
                    <Columns>
                        <asp:BoundField DataField="IdSubOperacion" HeaderText="Id" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Operacion" HeaderStyle-CssClass="NoVisible"
                            ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible">
                            <FooterStyle CssClass="NoVisible"></FooterStyle>
                            <HeaderStyle CssClass="NoVisible"></HeaderStyle>
                            <ItemStyle CssClass="NoVisible"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="IdEmpresa" HeaderText="Empresa" HeaderStyle-CssClass="NoVisible"
                            ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible">
                            <FooterStyle CssClass="NoVisible"></FooterStyle>
                            <HeaderStyle CssClass="NoVisible"></HeaderStyle>
                            <ItemStyle CssClass="NoVisible"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Idempresa" HeaderText="IdEmpresa" HeaderStyle-CssClass="NoVisible"
                            ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible">
                            <FooterStyle CssClass="NoVisible"></FooterStyle>
                            <HeaderStyle CssClass="NoVisible"></HeaderStyle>
                            <ItemStyle CssClass="NoVisible"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="SubOperacion" HeaderText="SubOperacion" />
                        <asp:BoundField DataField="IdOperacion" HeaderText="IdOperacion" HeaderStyle-CssClass="NoVisible"
                            ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible">
                            <FooterStyle CssClass="NoVisible"></FooterStyle>
                            <HeaderStyle CssClass="NoVisible"></HeaderStyle>
                            <ItemStyle CssClass="NoVisible"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="SubOperacion" HeaderText="Fecha" 
                            HtmlEncode="False" HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible"
                            FooterStyle-CssClass="NoVisible" />
                        <asp:BoundField DataField="IdOperacion" HeaderText="Nivel" HeaderStyle-CssClass="NoVisible"
                            ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                        <asp:BoundField DataField="Agno" HeaderText="Contador" HeaderStyle-CssClass="NoVisible"
                            ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnEliminar" CssClass="Boton" CommandName="ELIMINAR" CommandArgument='<%#Container.DataItemIndex %>'
                                    runat="server" Text="Eliminar" Enabled="true" />
                                <asp:Button ID="btnEditar" Enabled="true" CssClass="Boton" CommandName="EDITAR" CommandArgument='<%#Container.DataItemIndex %>'
                                    runat="server" Text="Editar" />
                                <asp:Button Text="Detalle" Enabled="true" CssClass="Boton" runat="server" ID="btnDetalle"
                                    CommandName="DETALLE" CommandArgument='<%#(Container.DataItemIndex) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="IdSubOperacion" HeaderText="IdSubOperacion" HeaderStyle-CssClass="NoVisible"
                            ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible">
                            <FooterStyle CssClass="NoVisible"></FooterStyle>
                            <HeaderStyle CssClass="NoVisible"></HeaderStyle>
                            <ItemStyle CssClass="NoVisible"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="GridHeader" />
                    <RowStyle CssClass="GridItem" />
                    <AlternatingRowStyle CssClass="GridAltItem" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlRegistroTipoCambio" CssClass="Formulario" runat="server">
        <div class="Titulo">
            REGISTRO SUBOPERACION</div>
        <table cellpadding="1" cellspacing="1" border="0" width="300">
            <caption>
                <br />
                <br />
                <tr>
                    <td class="Etiqueta">
                        Codigo:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCodigo" runat="server" CssClass="CajaTexto"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Etiqueta">
                        Empresa
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlEmpresa" runat="server" AutoPostBack="True">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="Etiqueta">
                        Operacion
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList runat="server" ID="ddlOperacion" AutoPostBack="True">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="Etiqueta">
                        Descripcion
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="CajaTexto" Width="200px"></asp:TextBox>
                    </td>
                </tr>
            </caption>
        </table>
        <table>
            <tr>
                <td>
                    <div id="Opciones">
                        <asp:Button ID="btnTerminar" CssClass="Boton" runat="server" Text="Registrar y Cerrar" />
                        <asp:Button ID="btnRegistrar" CssClass="Boton" runat="server" Text="Registrar" />
                        <asp:Button ID="btnCerrar2" CssClass="Boton" runat="server" Text="Cerrar" />
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel>
    </div>
</asp:Content>
