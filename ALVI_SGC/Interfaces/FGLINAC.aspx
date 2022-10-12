<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGLINAC.aspx.vb" Inherits="Interfaces_FGLINAC" %>

<%@ Register Src="../Controles/ctlCentroCosto_Buscar.ascx" TagName="ctlCentroCosto_Buscar" TagPrefix="uc1" %>
<%@ Register Src="../Controles/ctlElementoReferencial_Buscar.ascx" TagName="ctlElementoReferencial_Buscar" TagPrefix="uc2" %>
<%@ Register Src="../Controles/ctlUnidadMedida_Buscar.ascx" TagName="ctlUnidadMedida_Buscar" TagPrefix="uc3" %>
<%@ Register Src="../Controles/ctlSolicitante_Buscar.ascx" TagName="ctlSolicitante_Buscar" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript">
        function Buscar(InputId) {
            var IdVale = document.getElementById(InputId);
            IdVale.value = prompt("Ingrese Nota de pedido ", IdVale.value);
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="divCuerpo">
        <div id="divHeader">NOTA DE PEDIDO A ALMACEN - REGISTRO</div>
        <div id="divOpciones">
            <table cellpadding="1" cellspacing="1" border="0">
                <tr>
                    <td>
                        <asp:ImageButton ID="btnNuevo" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'" onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif" /></td>
                    <td>
                        <asp:ImageButton ID="btnRegistrar" runat="server" onmouseover="this.src='../images/btnRegistrar_on.gif'" onmouseout="this.src='../images/btnRegistrar.gif'" ImageUrl="../images/btnRegistrar.gif" /></td>
                    <td>
                        <asp:ImageButton ID="btnAsignar" runat="server" onmouseover="this.src='../images/btnAsignar_on.gif'" onmouseout="this.src='../images/btnAsignar.gif'" ImageUrl="../images/btnAsignar.gif" /></td>
                    <td>
                        <asp:ImageButton ID="btnDocumentos" runat="server" onmouseover="this.src='../images/btnDocumentos_on.gif'" onmouseout="this.src='../images/btnDocumentos.gif'" ImageUrl="../images/btnDocumentos.gif" /></td>
                    <td>
                        <asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'" onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" /></td>
                    <td>
                        <asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
                </tr>
            </table>
        </div>
        <asp:HiddenField ID="hdnIdVale" runat="server" />
        <table cellpadding="1" cellspacing="1" border="0">
            <tr>
                <td class="Titulo12">Codigo</td>
                <td>
                    <asp:TextBox ID="txtCodigo" CssClass="Texto12" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td rowspan="4">
                    <uc4:ctlSolicitante_Buscar ID="ctlSolicitante_Buscar1" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="Titulo12">Fecha Emision</td>
                <td>
                    <asp:TextBox ID="txtFechaEmision" runat="server" Width="80px"></asp:TextBox>
                    <asp:Image ID="btnFechaEmision" runat="server"
                        ImageUrl="~/Images/im_calendar.gif" />
                </td>
            </tr>
            <tr>
                <td class="Titulo12">Operacion</td>
                <td>
                    <asp:DropDownList ID="ddlOperacion" CssClass="texto12" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <uc1:ctlCentroCosto_Buscar ID="ctlCentroCosto_Buscar1" runat="server" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="grdDatos" Width="800" ShowFooter="true" 
            AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20">
            <Columns>
                <asp:BoundField DataField="var_IdArticulo" HeaderText="IdArticulo" />
                <asp:BoundField DataField="var_Articulo" HeaderText="Articulo" />
                <asp:BoundField DataField="var_IdUnidadMedida" HeaderText="IdUnidadMedida" />
                <asp:BoundField DataField="var_UnidadMedida" HeaderText="UnidadMedida" />
                <asp:BoundField DataField="int_Cantidad" HeaderText="Cantidad" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnModificar" CommandArgument='<%#Container.DataItemIndex() %>' CommandName="Modificar" ImageUrl="../images/btnAbrir.gif" runat="server" onmouseover="this.src='../images/btnAbrir_on.gif'" onmouseout="this.src='../images/btnAbrir.gif'" />
                    </ItemTemplate>
                    <ItemStyle Width="50" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEliminar" CommandArgument='<%#Container.DataItemIndex %>' CommandName="Eliminar" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
                    </ItemTemplate>
                    <ItemStyle Width="50" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="GridHeader" />
            <FooterStyle CssClass="GridFooter" />
            <AlternatingRowStyle CssClass="GridAltItem" />
            <RowStyle CssClass="GridItem" />
        </asp:GridView>

        <asp:Panel ID="pnlFormulario" CssClass="Formulario" runat="server">
            <div id="divTitulo">NOTA DE PEDIDO A ALMACEN – ASIGNACION DE ARTICULOS</div>
            <table cellpadding="1" cellspacing="1" border="0" width="500" align="center">
                <tr>
                    <td valign="top" colspan="2">
                        <uc2:ctlElementoReferencial_Buscar ID="ctlElementoReferencial_Buscar1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td valign="top" colspan="2">
                        <uc3:ctlUnidadMedida_Buscar ID="ctlUnidadMedida_Buscar1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="Titulo12">Cantidad</td>
                    <td>
                        <asp:TextBox ID="txtCantidad" MaxLength="200" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server" Width="150"></asp:TextBox>
                    </td>
                </tr>
            </table>

            <table cellpadding="1" cellspacing="1" border="0">
                <tr>
                    <td>
                        <asp:ImageButton ID="btnTerminar" runat="server" CssClass="Boton"
                            ImageUrl="../images/btnRegistroCierre.gif"
                            onmouseout="this.src='../images/btnRegistroCierre.gif';"
                            onmouseover="this.src='../images/btnRegistroCierre_on.gif';" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnRegistrar_Formulario" runat="server" CssClass="Boton"
                            ImageUrl="../images/btnRegistrar.gif"
                            onmouseout="this.src='../images/btnRegistrar.gif';"
                            onmouseover="this.src='../images/btnRegistrar_on.gif';" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnCancelar" runat="server" CssClass="Boton"
                            ImageUrl="../images/btnCancelar.gif"
                            onmouseout="this.src='../images/btnCancelar.gif';"
                            onmouseover="this.src='../images/btnCancelar_on.gif';" />
                    </td>
                </tr>
            </table>

            <div class="Footer">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img src="../images/loader.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>&nbsp;
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlDocumento" CssClass="Formulario" runat="server">
            <div id="divTitulo">NOTA DE PEDIDO A ALMACEN – DOCUMENTOS ASOCIADOS</div>
            <table cellpadding="2" cellspacing="2" border="0" width="500" align="center" valign="middle">
                <tr>
                    <td class="Titulo12">Tipo</td>
                    <td>
                        <asp:DropDownList ID="ddlTipo" CssClass="texto12" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="Titulo12">Numero</td>
                    <td>
                        <asp:TextBox ID="txtNumero" CssClass="Texto12" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="grdDatosDocumentos" Width="600" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20">
                <Columns>
                    <asp:BoundField DataField="chr_IdTipoDocumento" HeaderText="IdTipoDocumento" />
                    <asp:BoundField DataField="var_TipoDocumento" HeaderText="TipoDocumento" />
                    <asp:BoundField DataField="var_IdNumeroDocumento" HeaderText="Numero" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="btnModificar" CommandArgument='<%#Container.DataItemIndex() %>' CommandName="Modificar" ImageUrl="../images/btnAbrir.gif" runat="server" onmouseover="this.src='../images/btnAbrir_on.gif'" onmouseout="this.src='../images/btnAbrir.gif'" />
                        </ItemTemplate>
                        <ItemStyle Width="50" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEliminar" CommandArgument='<%#Container.DataItemIndex() %>' CommandName="Eliminar" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
                        </ItemTemplate>
                        <ItemStyle Width="50" />
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="GridHeader" />
                <FooterStyle CssClass="GridFooter" />
                <AlternatingRowStyle CssClass="GridAltItem" />
                <RowStyle CssClass="GridItem" />
            </asp:GridView>
            <table cellpadding="1" cellspacing="1" border="0">
                <tr>
                    <td>
                        <asp:ImageButton ID="btnRegistraCierreDocumento" runat="server" CssClass="Boton"
                            ImageUrl="../images/btnRegistroCierre.gif"
                            onmouseout="this.src='../images/btnRegistroCierre.gif';"
                            onmouseover="this.src='../images/btnRegistroCierre_on.gif';" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnRegistraDocumento" runat="server" CssClass="Boton"
                            ImageUrl="../images/btnRegistrar.gif"
                            onmouseout="this.src='../images/btnRegistrar.gif';"
                            onmouseover="this.src='../images/btnRegistrar_on.gif';" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnCerrarDocumento" runat="server" CssClass="Boton"
                            ImageUrl="../images/btnCancelar.gif"
                            onmouseout="this.src='../images/btnCancelar.gif';"
                            onmouseover="this.src='../images/btnCancelar_on.gif';" />
                    </td>
                </tr>
            </table>
            <div class="Footer">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                    <ProgressTemplate>
                        <img src="../images/loader.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:Label ID="lblMensaje2" runat="server"></asp:Label>&nbsp;
            </div>
        </asp:Panel>

    </div>
</asp:Content>

