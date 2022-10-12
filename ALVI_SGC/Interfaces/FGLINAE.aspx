<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGLINAE.aspx.vb" Inherits="Interfaces_FGLINAE" %>

<%@ Register Src="../Controles/ctlElementoReferencial_Buscar.ascx" TagName="ctlElementoReferencial_Buscar" TagPrefix="uc2" %>
<%@ Register Src="../Controles/ctlProveedor_Buscar.ascx" TagName="ctlProveedor_Buscar" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="divCuerpo">
        <div id="divHeader">ORDENES DE COMPRA - LISTADO</div>
        <div id="divOpciones">
            <table cellpadding="1" cellspacing="1" border="0">
                <tr>
                    <td>
                        <asp:ImageButton ID="btnNuevo" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'" onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif" /></td>

                    <td>
                        <asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'" onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" /></td>
                    <td>
                        <asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
                </tr>
            </table>
        </div>

        <table cellpadding="0" cellspacing="1" border="0">

            <tr>
                <td class="Titulo12">Codigo OC:</td>

                <td>
                    <asp:TextBox ID="txtCodigo" CssClass="Texto12" runat="server" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Titulo12">Fecha Emision</td>
                <td>
                    <asp:TextBox ID="txtFechaEmisionInicio" Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                    <asp:Image ID="btnFechaEmisionInicio" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
            </tr>
            <tr>
                <td class="Titulo12" visible="false"></td>
                <td>
                    <asp:TextBox ID="txtFechaEmisionFinal" Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                    <asp:Image ID="btnFechaEmisionFinal" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
            </tr>

            <tr>
                <td class="Titulo12">Fecha Entrega</td>
                <td>
                    <asp:TextBox ID="txtFechaEntregaInicio" Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                    <asp:Image ID="btnFechaEntregaInicio" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
            </tr>
            <tr>
                <td class="Titulo12" visible="false"></td>
                <td>
                    <asp:TextBox ID="txtFechaEntregaFinal" Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                    <asp:Image ID="btnFechaEntregaFinal" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
            </tr>
            <tr>
                <td class="Titulo12">Tipo Documento</td>
                <td>
                    <asp:DropDownList ID="ddlTipo" runat="server" CssClass="Texto12" Width="155px">
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td class="Titulo12">Número de documento</td>
                <td>
                    <asp:TextBox ID="txtNumeroDocumento"
                        MaxLength="20" onChange="validadigito(this,'TEL');" Width="150px"
                        onKeypress="return Valida(event, 'TEL');" CssClass="Texto12" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td class="Titulo12">Tipo</td>
                <td>

                    <asp:RadioButtonList ID="rbtTipo" runat="server">
                        <asp:ListItem Text="Compra" Value="C"></asp:ListItem>
                        <asp:ListItem Text="Servicio" Value="S"></asp:ListItem>
                    </asp:RadioButtonList>

                </td>
            </tr>
        </table>
        <div style="position: absolute; top: 65px; left: 330px; z-index: 0;">
            <table>
                <tr>
                    <td>
                        <uc1:ctlProveedor_Buscar ID="ctlProveedor_Buscar1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc2:ctlElementoReferencial_Buscar ID="ctlElementoReferencial_Buscar1" runat="server" />

                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="grdDatos" Width="900" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20">
            <Columns>
                <asp:BoundField DataField="var_IdOrdenCompra" HeaderText="Orden Compra" />
                <asp:BoundField DataField="var_IdDetalle" HeaderText="correlativo" />
                <asp:BoundField DataField="var_IdArticuloReferencia" HeaderText="articulo referencia" />
                <asp:BoundField DataField="var_Articulo" HeaderText="Descripcion Articulo" >
                      <ItemStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="int_Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="var_UnidadMedida" HeaderText="U/M" />
                <asp:BoundField DataField="var_RazonSocial" HeaderText="Razon Social" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnModificar" CommandArgument='<%#Container.DataItem("var_IdDetalle") %>' 
                            CommandName="Modificar" ImageUrl="../images/btnAbrir.gif" runat="server" Visible="false"
                            onmouseover="this.src='../images/btnAbrir_on.gif'" onmouseout="this.src='../images/btnAbrir.gif'" />
                    </ItemTemplate>
                    <ItemStyle Width="50" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEliminar" CommandArgument='<%#Container.DataItem("var_IdDetalle") %>' Visible="false"
                            CommandName="Eliminar" ImageUrl="../images/btnEliminar.gif" runat="server" 
                            onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
                    </ItemTemplate>
                    <ItemStyle Width="50" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="GridHeader" />
            <FooterStyle CssClass="GridFooter" />
            <AlternatingRowStyle CssClass="GridAltItem" />
            <RowStyle CssClass="GridItem" />
        </asp:GridView>

        



    </div>

</asp:Content>

