<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlMovimientoCajaBancoBuscar.ascx.vb"
    Inherits="CONTROLES_BUSQUEDA_ctlMovimientoCajaBancoBuscar" %>
<style type="text/css">
    .style1
    {
        width: 134px;
    }
    .style2
    {
        width: 196px;
    }
    .Boton
    {
    }
</style>
<div runat="server" id="divVisible">
    <table>
        <tr>
            <td class="style1">
                <asp:Label runat="server" ID="lblTitulo"></asp:Label>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td align="right">
                <asp:ImageButton CssClass="Boton" ID="ImageButton1" ImageUrl="~/images/cerrar_cuadrado.png"
                    onmouseover="this.src='../images/cerrar_cuadrado.png'" onmouseout="this.src='../images/cerrar_cuadrado.png'"
                    runat="server" Height="21px" Width="19px" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel runat="server" ID="updTipo">
                    <ContentTemplate>
                        <asp:DropDownList runat="server" ID="ddlTipo" AutoPostBack="True">
                            <asp:ListItem Value="0" Text="Seleccione>>">
                    
                            </asp:ListItem>
                            <asp:ListItem Value="1" Text="Cuenta">
                    
                            </asp:ListItem>
                            <asp:ListItem Value="2" Text="Nombre">
                    
                            </asp:ListItem>
                            <asp:ListItem Value="3" Text="Sede">
                    
                            </asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="style2">
                <asp:TextBox runat="server" Width="220px" ID="txtDescripcion"></asp:TextBox>
            </td>
            <td>
                <asp:ImageButton CssClass="Boton" ID="btnBuscar" ImageUrl="~/images/lupa.gif" onmouseover="this.src='../images/lupa_on.gif'"
                    onmouseout="this.src='../images/lupa.gif'" runat="server" />
            </td>
            <td>
            </td>
            <td>
                <asp:ImageButton CssClass="Boton" ID="ImageButton2" ImageUrl="~/images/excel.jpg"
                    onmouseover="this.src='../images/excel.jpg'" onmouseout="this.src='../images/excel.jpg'"
                    runat="server" Height="22px" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:UpdatePanel runat="server" ID="updDatos">
                    <ContentTemplate>
                        <asp:GridView runat="server" ID="grdDatos" AutoGenerateColumns="false" 
                            AllowPaging="True" PageSize="15" Width="348px">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton Width="20px" CssClass="Boton" ID="btnBuscar" ImageUrl="~/images/Select.png"
                                            onmouseover="this.src='../images/Select.png'" onmouseout="this.src='../images/Select.png'"
                                            runat="server" CommandName="PARTIR" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cuenta">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCuenta" Text='<%# Eval("Cuenta") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblNopmbre" Text='<%# Eval("Nombre") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sede">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblSede" Text='<%# Eval("NomDepartamento") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
</div>
