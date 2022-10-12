<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGLINBC.aspx.vb" Inherits="Interfaces_FGLINBC" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../Controles/ctlElementoReferencial_Buscar.ascx" TagName="ctlElementoReferencial_Buscar" TagPrefix="uc2" %>
<%@ Register Src="../Controles/ctlUnidadMedida_Buscar.ascx" TagName="ctlUnidadMedida_Buscar" TagPrefix="uc3" %>
<%@ Register Src="../Controles/ctlSolicitante_Buscar.ascx" TagName="ctlSolicitante_Buscar" TagPrefix="uc1" %>
<%@ Register Src="../Controles/ctlProveedor_Buscar.ascx" TagName="ctlProveedor_Buscar" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript">
        function Buscar(InputId) {
            var var_IdOrdenCompra = document.getElementById(InputId);
            var_IdOrdenCompra.value = prompt("Ingrese Codigo ", var_IdOrdenCompra.value);
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="divCuerpo">
        <div id="divHeader">REGISTRO DE ORDEN DE COMPRA</div>
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

        <asp:HiddenField ID="hdnIdComprar" runat="server" />
        <table cellpadding="0" cellspacing="1" border="0">
            <tr>
                <td class="Titulo12">Codigo OC:</td>
                <td>
                    <asp:TextBox ID="txtCodigo" CssClass="Texto12" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="Titulo12">Fecha Emision</td>
                <td>
                    <asp:TextBox ID="txtFechaEmision" runat="server" Width="80px"></asp:TextBox>
                    <%--<asp:Image ID="btnFechaEmision" runat="server"
                        ImageUrl="~/Images/im_calendar.gif" />--%>
                    <asp:CalendarExtender ID="calFechaEmision" runat="server" Enabled="True" TargetControlID="txtFechaEmision"
                        DaysModeTitleFormat="MMMM - yyyy" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy">
                    </asp:CalendarExtender>
                </td>
            </tr>


            <tr>
                <td class="Titulo12">Fecha Entrega</td>
                <td>
                    <asp:TextBox ID="txtFechaEntrega" runat="server" Width="80px"></asp:TextBox>

                    <%--<asp:Image ID="btnFechaEntrega" runat="server"
                        ImageUrl="~/Images/im_calendar.gif" />--%>
                    <asp:CalendarExtender ID="calFechaEntrega" runat="server" Enabled="True" TargetControlID="txtFechaEntrega"
                        DaysModeTitleFormat="MMMM - yyyy" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy">
                    </asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td class="Titulo12">Términos:</td>
                <td class="Titulo12">Observaciones</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtTerminos" Height="65" TextMode="MultiLine" CssClass="Texto12" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TxtObservaciones" Height="65" TextMode="MultiLine" CssClass="Texto12" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div style="position: absolute; top: 65px; left: 330px; z-index: 0;">
            <uc4:ctlProveedor_Buscar ID="ctlProveedor_Buscar1" runat="server" />
        </div>

        <asp:GridView ID="grdDatos" Width="600" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20">
            <Columns>
                <asp:BoundField DataField="var_IdDetalle" HeaderText="Item" />
                <asp:BoundField DataField="var_IdArticulo" HeaderText="Codigo Articulo" />
                <asp:BoundField DataField="var_Articulo" HeaderText="Articulo referencia" />
                <asp:BoundField DataField="int_Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="var_IdUnidadMedida" HeaderText="Id Unidad" HeaderStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible"/>
                <asp:BoundField DataField="var_UnidadMedida" HeaderText="Unidad" />
                <asp:BoundField DataField="dec_PrecioReferencia" HeaderText="Precio Ref." />
                <asp:BoundField DataField="var_Observacion" HeaderText="Observacción" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnModificar" CommandArgument='<%#Container.DataItem("var_IdDetalle") %>' CommandName="Modificar" ImageUrl="../images/btnAbrir.gif" runat="server" onmouseover="this.src='../images/btnAbrir_on.gif'" onmouseout="this.src='../images/btnAbrir.gif'" />
                    </ItemTemplate>
                    <ItemStyle Width="50" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEliminar" CommandArgument='<%#Container.DataItem("var_IdDetalle") %>' CommandName="Eliminar" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
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
            <div id="divTitulo">ORDEN DE COMPRA – ASIGNACION DE ARTICULOS</div>
            <table cellpadding="2" cellspacing="2" border="0" width="500" align="center" valign="middle">
                <table>
                    <tr>
                        <td>

                            <asp:HiddenField ID="hdnIdCorrelativo1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <tr>
                            <td>
                                <uc2:ctlElementoReferencial_Buscar ID="ctlElementoReferencial_Buscar1" runat="server" />

                            </td>
                        </tr>

                        <tr>

                            <td>
                                <uc3:ctlUnidadMedida_Buscar ID="ctlUnidadMedida_Buscar1" runat="server" />
                            </td>
                        </tr>
                </table>

                <table>
                    <tr>

                        <td class="Titulo12" width="105px">Cantidad</td>
                        <td>
                            <asp:TextBox ID="txtCantidad" MaxLength="10" onChange="validadigito(this,'NUM');" onKeypress="return Valida(event, 'NUM');" CssClass="Texto12" runat="server" Width="150"></asp:TextBox>
                        </td>

                    </tr>

                    <tr>

                        <td class="Titulo12">Precio Ref</td>
                        <td>
                            <asp:TextBox ID="txtPrecioRef" MaxLength="10" onChange="validadigito(this,'NUM');" onKeypress="return Valida(event, 'NUM');" CssClass="Texto12" runat="server" Width="150"></asp:TextBox>
                        </td>

                    </tr>


                </table>
                <table>

                    <tr>
                        <td class="Titulo12">Observación</td>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtObservacion" runat="server" CssClass="Texto12" Height="85"
                                    MaxLength="300" onChange="validadigito(this,'ALN');"
                                    onKeypress="return Valida(event, 'ALN');" TextMode="MultiLine" Width="250"></asp:TextBox>
                            </td>
                        </tr>
                    </tr>

                </table>


                <tr>
                    <td colspan="2">
                        <nobr>
                    <asp:ImageButton ID="btnTerminar" runat="server" CssClass="Boton" 
                        ImageUrl="../images/btnRegistroCierre.gif" 
                        onmouseout="this.src='../images/btnRegistroCierre.gif';" 
                        onmouseover="this.src='../images/btnRegistroCierre_on.gif';" />
                    <asp:ImageButton ID="btnRegistrar_Formulario" runat="server" CssClass="Boton" 
                        ImageUrl="../images/btnRegistrar.gif" 
                        onmouseout="this.src='../images/btnRegistrar.gif';" 
                        onmouseover="this.src='../images/btnRegistrar_on.gif';" />
                    <asp:ImageButton ID="btnCancelar" runat="server" CssClass="Boton" 
                        ImageUrl="../images/btnCancelar.gif" 
                        onmouseout="this.src='../images/btnCancelar.gif';" 
                        onmouseover="this.src='../images/btnCancelar_on.gif';" />
                    </nobr>
                    </td>
                </tr>
            </table>

            <div id="divFooter">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img src="../images/loader.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>&nbsp;
            </div>
        </asp:Panel>

        <asp:Panel ID="pnlDocumento" CssClass="Formulario" runat="server">
            <div id="div1">ORDEN DE COMPRA – DOCUMENTOS ASOCIADOS</div>
            <table cellpadding="2" cellspacing="2" border="0" width="500" align="center" valign="middle">
                <table>
                    <tr>
                        <td>

                            <asp:HiddenField ID="hdnIdCorrelativo" runat="server" />
                        </td>
                    </tr>
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

                    <tr>
                        <td class="Titulo12">Observacion</td>
                        <td>
                            <asp:TextBox ID="txtObservacionDocumento" CssClass="Texto12" runat="server" Width="200px"></asp:TextBox>
                        </td>

                    </tr>

                </table>
                <tr>
                    <td>



                        <asp:GridView ID="grdDatosDocumentos" Width="600" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20">
                            <Columns>
                                <asp:BoundField DataField="var_IdReferencia" HeaderText="Id" />
                                <asp:BoundField DataField="chr_IdTipoDocumento" HeaderText="IdTipoDocumento" />
                                <asp:BoundField DataField="var_TipoDocumento" HeaderText="TipoDocumento" />
                                <asp:BoundField DataField="var_NumeroDocumento" HeaderText="NumeroDocumento" />
                                <asp:BoundField DataField="var_Observacion" HeaderText="Observacion" />






                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnModificar" CommandArgument='<%#Container.DataItem("var_IdReferencia") %>' CommandName="Modificar" ImageUrl="../images/btnAbrir.gif" runat="server" onmouseover="this.src='../images/btnAbrir_on.gif'" onmouseout="this.src='../images/btnAbrir.gif'" />
                                    </ItemTemplate>
                                    <ItemStyle Width="50" />
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEliminar" CommandArgument='<%#Container.DataItem("var_IdReferencia") %>' CommandName="Eliminar" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
                                    </ItemTemplate>
                                    <ItemStyle Width="50" />
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" />
                            <FooterStyle CssClass="GridFooter" />
                            <AlternatingRowStyle CssClass="GridAltItem" />
                            <RowStyle CssClass="GridItem" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:ImageButton ID="btnRegistraCierreDocumento" runat="server" CssClass="Boton"
                            ImageUrl="../images/btnRegistroCierre.gif"
                            onmouseout="this.src='../images/btnRegistroCierre.gif';"
                            onmouseover="this.src='../images/btnRegistroCierre_on.gif';" />
                        <asp:ImageButton ID="btnRegistraDocumento" runat="server" CssClass="Boton"
                            ImageUrl="../images/btnRegistrar.gif"
                            onmouseout="this.src='../images/btnRegistrar.gif';"
                            onmouseover="this.src='../images/btnRegistrar_on.gif';" />
                        <asp:ImageButton ID="btnCerrarDocumento" runat="server" CssClass="Boton"
                            ImageUrl="../images/btnCancelar.gif"
                            onmouseout="this.src='../images/btnCancelar.gif';"
                            onmouseover="this.src='../images/btnCancelar_on.gif';" />
                    </td>
                </tr>

            </table>
            <div id="div1">
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

