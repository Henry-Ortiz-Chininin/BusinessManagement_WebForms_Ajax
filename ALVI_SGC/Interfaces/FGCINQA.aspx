<%@ Page Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false"
    CodeFile="FGCINQA.aspx.vb" Inherits="Estandares_FGCINQA" Title="Sistema de Gestión de Costos - Alta Visión Consultores sin título" %>

<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<%@ MasterType VirtualPath="~/Masterpage/General.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagName="ctlCliente" TagPrefix="Cliente" Src="~/Controles/ctlCliente_BuscarEX.ascx" %>
<%@ Register TagName="ctlArticulo" TagPrefix="ART" Src="~/Controles/ctlArticulo_Buscar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript" type="text/javascript">
        function SetParticion(IdParticion, strOP) {
            var objParticion = document.getElementById(IdParticion);
            objParticion.value = "0";
            objParticion.value = prompt("Ingrese el número de particiones para la orden " + strOP, "0");
            if (objParticion.value != "0")
            { return true; }
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="divCuerpo">
        <div id="divHeader">
            Nota de Pedido</div>
        <div id="divOpciones">
            <table cellpadding="0" cellspacing="1" border="0">
                <tr>
                    <td>
                        <asp:ImageButton ID="btnNuevo" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'"
                            onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'"
                            onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'"
                            onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:HiddenField ID="hdnIdParticiones" Value="0" runat="server" />
        <table cellpadding="3" cellspacing="3" border="0">
            <tr>
                <td class="Titulo12">
                    Pedido
                </td>
                <td>
                    <asp:TextBox ID="txtIdArticuloBusqueda" CssClass="Texto12" runat="server"></asp:TextBox>
                </td>
                <td class="Titulo12">
                    Fecha Inicio
                </td>
                <td>
                    <nobr>
                        <asp:TextBox ID="txtFechaInicio" Width="80" MaxLength="10" CssClass="Texto12" runat="server"></asp:TextBox>
                        <asp:Image ID="btnFechaInicio" Visible="false" runat="server" ImageUrl="~/Images/im_calendar.gif" />
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtFechaInicio"
                        DaysModeTitleFormat="MMMM - yyyy" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </nobr>
                </td>
            </tr>
            <tr>
                <td class="Titulo12">
                    Razón Social Cliente
                </td>
                <td>
                    <asp:TextBox ID="txtCliente" CssClass="Texto12" runat="server"></asp:TextBox>
                </td>
                <td class="Titulo12">
                    Fecha Final
                </td>
                <td>
                    <asp:TextBox ID="txtFechaFin" Width="80" MaxLength="10" CssClass="Texto12" runat="server"></asp:TextBox>
                    <asp:Image ID="btnFechaFin" Visible="false" runat="server" ImageUrl="~/Images/im_calendar.gif" />
                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="txtFechaFin"
                        DaysModeTitleFormat="MMMM - yyyy" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy">
                    </asp:CalendarExtender>
                </td>
            </tr>
        </table>
        <asp:GridView ID="grdDatos" Width="1000" ShowFooter="true" AutoGenerateColumns="false"
            runat="server" AllowPaging="true" PageSize="20">
            <Columns>
                <asp:BoundField DataField="var_IdPedido" HeaderText="ID Pedido" />
                <asp:BoundField DataField="var_IdCliente" HeaderText="Cliente">
                    <ItemStyle Width="300" />
                </asp:BoundField>
                <asp:BoundField DataField="dtm_FechaEmision" HeaderText="Emision">
                    <ItemStyle Width="50" />
                </asp:BoundField>
                <asp:BoundField DataField="var_Aprobado" HeaderText="AprobadoPor" />
                <asp:BoundField DataField="var_Estado" HeaderText="Estado" />
                <asp:BoundField DataField="var_TipoServicio" HeaderText="Tipo Servicio" />
                <asp:BoundField DataField="var_idVendedor" HeaderText="Vendedor" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnModificar" CommandArgument='<%#Container.DataItem("var_IdPedido") %>'
                            CommandName="Modificar" ImageUrl="../images/btnAbrir.gif" runat="server" onmouseover="this.src='../images/btnAbrir_on.gif'"
                            onmouseout="this.src='../images/btnAbrir.gif'" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEliminar" CommandArgument='<%#Container.DataItem("var_IdPedido") %>'
                            CommandName="Eliminar" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'"
                            onmouseout="this.src='../images/btnEliminar.gif'" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="GridHeader" />
            <FooterStyle CssClass="GridFooter" />
            <AlternatingRowStyle CssClass="GridAltItem" />
            <RowStyle CssClass="GridItem" />
        </asp:GridView>
        <asp:Panel ID="pnlFormulario" CssClass="Formulario" runat="server">
            <div id="divTitulo">
                Registro - Pedido</div>
            <table cellpadding="2" cellspacing="2" border="0" width="500" align="center" valign="middle">
                <tr>
                    <td colspan="6">
                        <table>
                            <tr>
                                <td class="Titulo12">
                                    <asp:RadioButton ID="rbtProducto" runat="server" GroupName="Servicio" Text="Producto"
                                        AutoPostBack="true" Width="80px" />
                                </td>
                                <td class="Titulo12">
                                    <asp:RadioButton ID="rbtServicio" runat="server" GroupName="Servicio" Text="Servicio"
                                        AutoPostBack="true" Width="130px" />
                                </td>
                                <td class="Titulo12">
                                    <asp:Label Text="Vendedor" ID="lblVendedor" runat="server" Width="80px"> </asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlVendedor" runat="server" Width="100px">
                                    </asp:DropDownList>
                                </td>
                                <td colspan="50">
                                    <asp:Label Text="" ID="lblSpace1" runat="server" Width="40"> </asp:Label>
                                </td>
                                <td class="Titulo12">
                                    Moneda
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlMoneda" runat="server" Width="100px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <hr width="100%" height="1" noshadow />
                    </td>
                </tr>
                <tr>
                    <td class="Titulo12">
                        DATOS GENERALES
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td colspan="6">
                                    <table>
                                        <tr valign="top">
                                            <td class="Titulo12" width="70px">
                                                Codigo
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCodigo" Width="100px" runat="server"></asp:TextBox>
                                            </td>
                                            <td class="Titulo12" width="100px">
                                                Fecha Emisión
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFechaEmision" Width="80px" MaxLength="10" CssClass="Texto12"
                                                    runat="server" Enabled="false"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" TargetControlID="txtFechaEmision"
                                                    DaysModeTitleFormat="MMMM - yyyy" PopupButtonID="btnFechaEmision" Format="dd/MM/yyyy"
                                                    TodaysDateFormat="dd/MM/yyyy">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:Image ID="btnFechaEmision" Visible="true" ToolTip="Click para ver el Calendario"
                                                    runat="server" ImageUrl="~/Images/im_calendar.gif" />
                                            </td>
                                            <td class="Titulo12" width="100px">
                                                Estado Pedido :
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlEstado" runat="server" Width="65px">
                                                    <asp:ListItem Value="ACT"> Activo</asp:ListItem>
                                                    <asp:ListItem Value="INA"> Inactivo</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <hr width="100%" height="1" noshadow />
                                </td>
                            </tr>
                            <tr>
                                <td class="Titulo12">
                                    DATOS DEL CLIENTE
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="Titulo12" width="200px" colspan="1" rowspan="2">
                                    <Cliente:ctlCliente ID="ctlCliente2" runat="server" />
                                </td>
                                <td colspan="1">
                                    <asp:DropDownList runat="server" ID="ddlDepartamento" CssClass="Texto12" Width="165px">
                                    </asp:DropDownList>
                                </td>
                                <td align="justify">
                                </td>
                            </tr>
                            <tr valign="top">
                                <td align="justify">
                                    <asp:TextBox ID="txtAprobado" runat="server" Width="160px" CssClass="Texto12" placeHolder="Aprobado por">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <hr width="100%" height="1" noshadow />
                                </td>
                            </tr>
                            <tr>
                                <td class="Titulo12">
                                    FORMA DE PAGO
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <table>
                                        <tr>
                                            <td class="Titulo12">
                                                <asp:RadioButton Width="100" ID="rbtcontado" runat="server" Text="Contado" GroupName="Pago"
                                                    AutoPostBack="true" />
                                            </td>
                                            <td class="Titulo12">
                                                <asp:RadioButton Width="100" ID="rbtCredito" runat="server" Text="Credito" GroupName="Pago"
                                                    AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:UpdatePanel ID="upnListCredito" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList Width="100px" ID="ddlCredito" runat="server" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="rbtCredito" EventName="CheckedChanged" />
                                                        <asp:AsyncPostBackTrigger ControlID="rbtcontado" EventName="CheckedChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td class="Titulo12">
                                                <asp:Label Text="" ID="lblSpacing" runat="server" Width="100"> </asp:Label>
                                                <asp:Label Text="Tipo Pago" ID="lblTipoPago" runat="server" Width="70"> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:UpdatePanel ID="UpnTipoPago" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList Width="100" ID="ddlTipoPago" runat="server">
                                                            <asp:ListItem Value="0">Mas IGV</asp:ListItem>
                                                            <asp:ListItem Value="1">Inc.IGV</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="grdArticulo" EventName="RowCreated" />
                                                        <asp:AsyncPostBackTrigger ControlID="grdArticulo" EventName="RowDeleting" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="10">
                                    <hr width="100%" height="1" noshadow />
                                </td>
                            </tr>
                            <tr>
                                <td class="Titulo12">
                                    ARTICULO/SERVICIO
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="Titulo12" width="200px" colspan="1" rowspan="1">
                                    <ART:ctlArticulo ID="ctlArticulo1" IdSubFamilia="SA" runat="server" />
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:Label Text="Cantidad" ID="lblCantidad" runat="server" Width="70" CssClass="Titulo12"> </asp:Label>
                                            <asp:TextBox ID="txtCantidad" runat="server" Width="80" CssClass="Texto12" onChange="validadigito(this,'NUM');"
                                                onKeypress="return Valida(event, 'NUM');"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnAgregar" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="Titulo12" colspan="10" width="100px">
                                    <table>
                                        <tr>
                                            <td class="Titulo12">
                                                Lugar de Operación:
                                            </td>
                                            <td colspan="4">
                                                <asp:TextBox runat="server" ID="txtLugarOperacion" CssClass="Texto12"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Titulo12">
                                                Solicitado por:
                                            </td>
                                            <td colspan="4">
                                                <asp:TextBox runat="server" ID="txtTrabajoSolicitado" CssClass="Texto12"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Titulo12">
                                                Trabajo Efectuado:
                                            </td>
                                            <td colspan="4">
                                                <asp:TextBox runat="server" ID="txtTrabajoEjectuado" CssClass="Texto12"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Titulo12">
                                                Operador:
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtOperador" CssClass="Texto12"></asp:TextBox>
                                            </td>
                                            <td style="width: 5px;">
                                            </td>
                                            <td class="Titulo12" align="left">
                                                Riger:
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtRiger" CssClass="Texto12"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Titulo12">
                                                Ayudante
                                            </td>
                                            <td colspan="4">
                                                <asp:TextBox runat="server" ID="txtAyudante" CssClass="Texto12"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Titulo12">
                                                Salida Base:
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtSalidaBase" CssClass="Texto12" Width="70"></asp:TextBox>
                                                <asp:CalendarExtender runat="server" ID="calSalidaBase" TargetControlID="txtSalidaBase" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                <MKB:TimeSelector ID="tisSalidaBase" runat="server" DisplaySeconds="false" SelectedTimeFormat="TwentyFour">
                                                </MKB:TimeSelector>
                                            </td>
                                            <td style="width: 5px;">
                                            </td>
                                            <td class="Titulo12">
                                                Llegada Obra:
                                            </td>
                                            <td>
                                                <MKB:TimeSelector ID="tisLlegadaObra" runat="server" DisplaySeconds="false" SelectedTimeFormat="TwentyFour">
                                                </MKB:TimeSelector>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Titulo12">
                                                Inicio de Operación:
                                            </td>
                                            <td>
                                                <MKB:TimeSelector ID="tisInicioOperacion" runat="server" DisplaySeconds="false" SelectedTimeFormat="TwentyFour">
                                                </MKB:TimeSelector>
                                            </td>
                                            <td style="width: 5px;">
                                            </td>
                                            <td class="Titulo12">
                                                Termino de Operación:
                                            </td>
                                            <td>
                                                <MKB:TimeSelector ID="tisTerminoOperacion" runat="server" DisplaySeconds="false"
                                                    SelectedTimeFormat="TwentyFour">
                                                </MKB:TimeSelector>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Titulo12">
                                                Salio de Obra:
                                            </td>
                                            <td>
                                                <MKB:TimeSelector ID="tisSalidaObra" runat="server" DisplaySeconds="false" SelectedTimeFormat="TwentyFour">
                                                </MKB:TimeSelector>
                                            </td>
                                            <td style="width: 5px;">
                                            </td>
                                            <td class="Titulo12">
                                                Llegó a Base:
                                            </td>
                                            <td>
                                                <MKB:TimeSelector ID="tisLlegoBase" runat="server" DisplaySeconds="false" SelectedTimeFormat="TwentyFour">
                                                </MKB:TimeSelector>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5">
                                                <hr style="width: 100%;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Titulo12">
                                                Tiempo Recorrido:
                                            </td>
                                            <td>
                                                <asp:UpdatePanel runat="server" ID="upnTiempoRecorrido">
                                                    <ContentTemplate>
                                                        <asp:TextBox runat="server" ID="txtTiempoRecorrido" CssClass="Texto12" Enabled="false"></asp:TextBox>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="btnCalcularTiempo" EventName="Click" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td style="width: 5px;">
                                            </td>
                                            <td class="Titulo12">
                                                Tiempo Trabajado:
                                            </td>
                                            <td>
                                                <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                                    <ContentTemplate>
                                                        <asp:TextBox runat="server" ID="txtTiempoTrabajo" CssClass="Texto12" Enabled="false"></asp:TextBox>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="btnCalcularTiempo" EventName="Click" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Titulo12">
                                                Tiempo Total a Facturar:
                                            </td>
                                            <td>
                                                <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                                                    <ContentTemplate>
                                                        <asp:TextBox runat="server" ID="txtTiempoTotal" CssClass="Texto12" Enabled="false"></asp:TextBox>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="btnCalcularTiempo" EventName="Click" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td style="width: 5px;">
                                            </td>
                                            <td class="Titulo12">
                                                Tarifa:
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtTarifa" CssClass="Texto12" ToolTip="Tarifa por hora"
                                                    onChange="validadigito(this,'NUM');" onKeypress="return Valida(event, 'NUM');"
                                                    placeHolder="Tarifa por hora"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 5px; text-align: right;" colspan="3">
                                                <asp:Button runat="server" ID="btnCalcularTiempo" Text="Calcular" ToolTip="Click para calcular los tiempos y el Total a Pagar" />
                                            </td>
                                            <td class="Titulo12">
                                                Total:
                                            </td>
                                            <td>
                                                <asp:UpdatePanel runat="server" ID="UpdatePanel4">
                                                    <ContentTemplate>
                                                        <asp:TextBox runat="server" ID="txtImporte" CssClass="Texto12" ToolTip="Total" Enabled="false"></asp:TextBox>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="btnCalcularTiempo" EventName="Click" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Titulo12">
                                                Observación:
                                            </td>
                                            <td colspan="4">
                                                <asp:TextBox runat="server" ID="txtDesServicio" CssClass="Texto12" ToolTip="Total"
                                                    TextMode="MultiLine" Height="50px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    <asp:ImageButton ID="btnAgregar" runat="server" CssClass="Boton" ImageUrl="../images/btnAsignar.gif"
                                        onmouseout="this.src='../images/btnAsignar.gif';" onmouseover="this.src='../images/btnAsignar_on.gif';" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="10">
                                    <hr width="100%" height="1" noshadow />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:UpdatePanel ID="upnTelaCruda" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdArticulo" runat="server" align="center" AutoGenerateColumns="false"
                                    ShowFooter="true" Width="700">
                                    <Columns>
                                        <asp:BoundField DataField="int_Secuencia" HeaderText="" />
                                        <asp:BoundField DataField="var_CodArticulo" HeaderText="Codigo Articulo" />
                                        <asp:BoundField DataField="var_DesArticulo" HeaderText="Descripcion" />
                                        <asp:BoundField DataField="var_Unidad" HeaderText="Unidad" />
                                        <asp:BoundField DataField="num_Cantidad" HeaderText="Cantidad" DataFormatString="{0:N}" />
                                        <asp:BoundField DataField="num_Rollos" HeaderText="Rollos" DataFormatString="{0:N}" />
                                        <asp:BoundField DataField="num_Importe" HeaderText="Importe" DataFormatString="{0:N}" />
                                        <asp:BoundField DataField="var_DesServicio" HeaderText="Descripcion Servicio" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnEliminar" runat="server" CommandName="Delete" ImageUrl="../images/btnEliminar.gif"
                                                    onmouseout="this.src='../images/btnEliminar.gif'" onmouseover="this.src='../images/btnEliminar_on.gif'" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                    <RowStyle CssClass="GridItem" />
                                    <AlternatingRowStyle CssClass="GridAltItem" />
                                    <FooterStyle CssClass="GridFooter" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnAgregar" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:ImageButton ID="btnTerminar" runat="server" CssClass="Boton" ImageUrl="../images/btnRegistroCierre.gif"
                            onmouseout="this.src='../images/btnRegistroCierre.gif';" onmouseover="this.src='../images/btnRegistroCierre_on.gif';" />
                        <asp:ImageButton ID="btnRegistrar" runat="server" CssClass="Boton" ImageUrl="../images/btnRegistrar.gif"
                            onmouseout="this.src='../images/btnRegistrar.gif';" onmouseover="this.src='../images/btnRegistrar_on.gif';" />
                        <asp:ImageButton ID="btnCancelar" runat="server" CssClass="Boton" ImageUrl="../images/btnCancelar.gif"
                            onmouseout="this.src='../images/btnCancelar.gif';" onmouseover="this.src='../images/btnCancelar_on.gif';" />
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
    </div>
</asp:Content>
