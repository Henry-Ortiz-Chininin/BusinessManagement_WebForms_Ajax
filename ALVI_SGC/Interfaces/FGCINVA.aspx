<%@ Page Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCINVA.aspx.vb" Inherits="Estandares_FGCINVA" title="Sistema de Gestión de Costos - Alta Visión Consultores sin título" %>
<%@ MasterType VirtualPath="~/Masterpage/General.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagName="ctlCliente" TagPrefix="Cliente" Src="~/Controles/ctlCliente_BuscarEX.ascx" %>
<%@ Register TagName="ctlArticulo" TagPrefix="ART" Src="~/Controles/ctlArticulo_Buscar.ascx" %>
<%@ Register TagName="CajaBanco" TagPrefix="AVC" Src="~/Controles/REGISTRO/ctlCajaBanco_Registro.ascx" %>
<%@ Register TagName="ctlCliente" TagPrefix="AVC1" Src="~/Controles/REGISTRO/ctlCliente_Registro.ascx" %>
<%@ Register TagName="ctlOrdenServicio" TagPrefix="AVC2" Src="~/Controles/BUSQUEDA/ctlOrdeServicio_Buscar.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
    <script src="../js/jquery-1.7.1.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".Filtro").hide();
            $(".Mostrar").click(function () {
                $(".Filtro").toggle();
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:HiddenField ID="hdnIdParticiones" Value="0" runat="server" />
<div id="divCuerpo">
<div id="divHeader">Registro de Comprobantes</div>
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
    
 <table cellpadding="3" cellspacing="3" border="0">
    <tr>
        <td class="Titulo12">
            ID Documento
        </td>
        <td>
            <asp:TextBox ID="txtComprobante" CssClass="Texto12" runat="server"></asp:TextBox>
        </td>
        <td class="Titulo12">
            Fecha Inicio
        </td>        
        <td>
            <asp:TextBox ID="txtFechaInicio" Width="80" MaxLength="10" CssClass="Texto12" runat="server"></asp:TextBox>
            <asp:Image ID="btnFechaInicio" runat="server" Visible="false" ImageUrl="~/Images/im_calendar.gif" />
            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="txtFechaInicio"
                                DaysModeTitleFormat="MMMM - yyyy" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy">
                            </asp:CalendarExtender>
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
                <asp:Image ID="btnFechaFin" runat="server" Visible="false" ImageUrl="~/Images/im_calendar.gif" />
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtFechaFin"
                                DaysModeTitleFormat="MMMM - yyyy" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy">
                            </asp:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">
            Nº Documento
        </td>
        <td>  
            <table cellpadding="0" cellspacing="0"> 
                <tr>
                    <td>
                        <asp:TextBox ID="txtNumDoc" runat="server" Width = "40" MaxLength = "3"></asp:TextBox>
                    </td>
                    <td style="width:10px; text-align:center;">
                    -
                    </td>
                    <td>
                        <asp:TextBox ID="txtNumCorrelativo" runat="server" Width = "80" MaxLength = "7"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
        <td class="Titulo12">
            Estado
        </td>
        <td>
            <asp:DropDownList runat="server" ID="ddlEstadoB" CssClass="Texto12">
                <asp:ListItem Text="Todo" Value=""></asp:ListItem>
                <asp:ListItem Selected="True" Text="Activo" Value="ACT"></asp:ListItem>
                <asp:ListItem Text="Anulado" Value="DES"></asp:ListItem>
                <asp:ListItem Text="Pagado" Value="PAG"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
 </table>
<asp:GridView ID="grdDatos" Width="1000" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>
        <asp:BoundField DataField="var_Tipo" HeaderText="Documento"/>
        <asp:BoundField DataField="var_IdComprobante" HeaderText="Factura/Boleta"/>
        <asp:BoundField DataField="var_IdCliente" HeaderText="Cliente">
            <ItemStyle Width="300" />
        </asp:BoundField>
        <asp:BoundField DataField="dtm_FechaVencimiento" HeaderText="Emision">
            <ItemStyle Width="50"/>
        </asp:BoundField>
        <asp:BoundField DataField="dtm_FechaEmision" HeaderText="Vencimiento">
            <ItemStyle Width="50"/>
        </asp:BoundField>
        <asp:BoundField DataField="var_Estado" HeaderText="Estado" /> 
        <asp:BoundField DataField="var_TipoServicio" HeaderText="Tipo Servicio" />
        <asp:BoundField DataField="var_DesMoneda" HeaderText="Moneda" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="btnModificar" CommandArgument='<%#Container.DataItem("int_Secuencia") %>'
                CommandName="Modificar" ImageUrl="../images/btnAbrir.gif" runat="server" onmouseover="this.src='../images/btnAbrir_on.gif'" onmouseout="this.src='../images/btnAbrir.gif'" />
            </ItemTemplate> 
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="btnEliminar" CommandArgument='<%#Container.DataItem("int_Secuencia") %>' 
                    CommandName="Eliminar" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'"
                        onmouseout="this.src='../images/btnEliminar.gif'" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="btnCajaBanco" CommandArgument='<%#Container.DataItem("int_Secuencia") %>' 
                    CommandName="CAJABANCO" ImageUrl="../images/btnCajaBanco.gif" runat="server" onmouseover="this.src='../images/btnCajaBanco_on.gif'"
                        onmouseout="this.src='../images/btnCajaBanco.gif'" />
            </ItemTemplate> 
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="btnImprimir" runat="server" onmouseover="this.src='../images/btnImprimir_on.gif'"
                        onmouseout="this.src='../images/btnImprimir.gif'" ImageUrl="../images/btnImprimir.gif" 
                    CommandArgument='<%#Container.DataItem("int_Secuencia") %>' 
                    CommandName="Imprimir"/>
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
            Registro - Comprobantes
        </div>
        <table cellpadding="2" cellspacing="2" border="0" width="500" align="center" valign="middle">
            <tr>
                <td colspan ="6">
                    <table width = "500"> 
                        <tr>
                            <td class="Titulo12">
                                <asp:RadioButton ID="rbtProducto" runat="server" GroupName="Servicio" text = "Producto" AutoPostBack = "true"/>    
                            </td>
                            <td class="Titulo12">
                                <asp:RadioButton ID="rbtServicio" runat="server"  GroupName="Servicio" text = "Servicio" AutoPostBack = "true"/>
                                <asp:Label ID="Label1"  Text = "" Width ="90" runat="server"></asp:Label>
                            </td>
                            <td class="Titulo12">
                                Vendedor
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlVendedor" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="6"">
                    <hr width="100%" height="1" noshadow />
                </td>
            </tr>
            <tr>
                <td class="Titulo12">
                    DATOS GENERALES
                </td>
            </tr>
            <tr>
                <td colspan ="10">
                    <table>
                        <tr>
                            <td class="Titulo12">
                                ID: 
                            </td>
                            <td>
                                <asp:TextBox  ID="txtCodigo" runat="server" Width ="30"></asp:TextBox>
                            </td>
                            <td class="Titulo12">
                                NºDoc. 
                            </td> 
                            <td>
                                <asp:TextBox  ID="txtNumero" runat="server" Width ="30" MaxLength = "3"></asp:TextBox>
                            </td>
                            <td class="Titulo12"> - </td> 
                            <td>
                                <asp:TextBox  ID="txtCorrelativo" runat="server" Width = "70" MaxLength = "7"></asp:TextBox>
                            </td>
                            <td class="Titulo12">
                                Emisión
                            </td>
                            <td>
                                <asp:TextBox ID="txtFechaEmision" Width="80" MaxLength="10"  CssClass="Texto12" runat="server"></asp:TextBox>
                                <asp:Image ID="btnFechaEmision" Visible="false" runat="server" ImageUrl="~/Images/im_calendar.gif"/>
                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" TargetControlID="txtFechaEmision"
                                        DaysModeTitleFormat="MMMM - yyyy" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy">
                                    </asp:CalendarExtender>
                            </td>
                            <td class="Titulo12">
                                Vencimiento
                            </td>
                            <td>
                                <asp:TextBox ID="txtFechaVencimiento" Width="80" MaxLength="10" CssClass="Texto12" runat="server"></asp:TextBox>
                                <asp:Image ID="btnFechavencimiento" runat="server" visible="false" ImageUrl="~/Images/im_calendar.gif"/>
                                <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" TargetControlID="txtFechaVencimiento"
                                    DaysModeTitleFormat="MMMM - yyyy" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy">
                                </asp:CalendarExtender>
                                <asp:Label ID="lblSpacing3"  Text = "" Width ="30px" runat="server"></asp:Label>
                            </td>
                            <td class="Titulo12">
                                Estado
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlEstado" runat="server">
                                    <asp:ListItem Value = "ACT" >ACTIVO</asp:ListItem>
                                    <asp:ListItem Value = "DES" >ANULADO</asp:ListItem>
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
                <td class="Titulo12" colspan = "6">
                    DATOS DEL CLIENTE
                    <asp:Button ID="btnAgregarCliente" runat="server" ToolTip="Click para Agregar Cliente" Text="Agregar Cliente" />
                </td>
            </tr>
            <tr>
                <td class="Titulo12" colspan="2">
                    <Cliente:ctlCliente ID="ctlCliente2" runat="server" />
                </td> 
                <td align="justify"> 
                    <table>
                        <tr>
                            <td class="Titulo12">
                                Documento
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTipoDocumento" runat="server" Width = "172">
                                    <asp:ListItem value = "BOL">BOLETA DE VENTA</asp:ListItem>
                                    <asp:ListItem value = "FAC">FACTURA - VENTA</asp:ListItem>
                                </asp:DropDownList>
                            </td> 
                        </tr>
                        <tr>  
                            <td class="Titulo12">
                                Moneda
                            </td> 
                            <td>   
                                <asp:DropDownList ID="ddlMoneda" runat="server" Width = "172">
                                </asp:DropDownList>  
                            </td> 
                        </tr> 
                        <tr>   
                            <td class="Titulo12">
                                Tipo Pago
                            </td>
                            <td> 
                                <asp:UpdatePanel ID = "UpnTipoPago" runat ="server">  
                                    <ContentTemplate > 
                                        <asp:DropDownList ID="ddlTipoPago" runat="server" Width = "172"> 
                                            <asp:ListItem value = "0">Mas IGV</asp:ListItem> 
                                            <asp:ListItem value = "1">Inc.IGV</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="grdArticulo" EventName="RowCreated" />
                                        <asp:AsyncPostBackTrigger ControlID="grdArticulo" EventName="RowDeleting" />
                                    </Triggers>
                                </asp:UpdatePanel> 
                            </td>  
                        </tr> 
                        <tr> 
                            <td class="Titulo12">
                                Motivo
                            </td> 
                            <td> 
                                <asp:DropDownList ID="ddlMotivo" runat="server" Width = "172">
                                </asp:DropDownList>
                            </td> 
                        </tr>
                        <tr>
                            <td class="Titulo12">
                                Es unidad Propia
                            </td>
                            <td>
                                <asp:Image ID="btnFiltrar" CssClass="Mostrar" runat="server" onmouseover="this.src='../images/btnMostrar_on.gif'" ToolTip="Click para mostrar el Servicio del tercero"
                                    onmouseout="this.src='../images/btnMostrar.gif'" ImageUrl="../images/btnMostrar.gif" Width="30px" />
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
                <td colspan="6">
                    <div class="Filtro">
                        <table>
                            <tr>
                                <td class="Titulo12" colspan = "7">
                                    DATOS DEL SERVICIO DE TERCEROS
                                    <asp:Button ID="btnAgregarTerceros" runat="server" ToolTip="Click para Agregar Terceros" Text="Agregar Terceros" Visible="false" />
                                </td>
                            </tr>
                            <tr>
                                <td class="Titulo12" colspan="2" width="418px">
                                    <Cliente:ctlCliente ID="ctlClienteTercero" runat="server" />
                                </td> 
                                <td align="justify" valign="bottom"> 
                                    <table>
                                        <tr>
                                            <td class="Titulo12" width="100px">
                                                Importe
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtImporteTercero" CssClass="Texto12"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table> 
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <hr width="100%" height="1" noshadow />
                </td>
            </tr>
            <tr>
                <td class="Titulo12">
                    Artículo
                </td>
            </tr>
            <tr>
                <td colspan = "2">
                    <table>
                        <tr>
                            <td colspan="2" >
                                <ART:ctlArticulo ID="ctlArticulo1" IdSubFamilia="SA" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="Titulo12" width="70px">
                                Observación
                            </td>
                            <td align="left">
                                <asp:UpdatePanel ID="upnDesc" runat="server">
                                    <ContentTemplate> 
                                        <asp:TextBox ID="txtDesServicio" runat="server" CssClass="Texto12" Style="width:98%;"
                                        TextMode="MultiLine" Height="34px"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnAgregar" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </td>
                <td colspan ="4">
                    <table cellpadding="1" cellspacing="1" border="0" width="300">
                            <tr>
                                <td class="Titulo12" width="100">
                                    Cantidad
                                </td>
                                <td width="200">
                                    <asp:UpdatePanel ID="upnCantidad" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtCantidad" runat="server" CssClass="Texto12" 
                                                onChange="validadigito(this,'NUM');" onKeypress="return Valida(event, 'NUM');"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnAgregar" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="Titulo12">
                                    Fecha Inicio
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="upnFechaInicio" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtInicioServicio" runat="server" CssClass="Texto12"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender5" runat="server" Enabled="True" TargetControlID="txtInicioServicio"
                                                DaysModeTitleFormat="MMMM - yyyy" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy">
                                            </asp:CalendarExtender>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnAgregar" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                    <asp:Image ID="btnInicioServicio" Visible="false" runat="server" 
                                    ImageUrl="~/Images/im_calendar.gif" />
                                </td>
                            </tr>
                            <tr>
                                <td class="Titulo12">
                                    Fecha Final
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="updFechaFinal" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtFinalServicio" runat="server" CssClass="Texto12" ></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender6" runat="server" Enabled="True" TargetControlID="txtFinalServicio"
                                                DaysModeTitleFormat="MMMM - yyyy" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy">
                                            </asp:CalendarExtender>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnAgregar" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="Titulo12">CU</td>  
                                <td> 
                                    <asp:UpdatePanel ID="UpnImporte" runat="server"> 
                                        <ContentTemplate> 
                                            <asp:TextBox ID="txtCostoUnitario" runat="server" CssClass="Texto12" 
                                                onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnAgregar" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr> 
                                <td class="Titulo12">% Descuento</td>
                                <td  colspan = "2"> 
                                        <asp:UpdatePanel ID="upnDesServicio" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtDesc"  runat="server" CssClass="Texto12" 
                                            onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" format = "{0:0%}">
                                            </asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnAgregar" EventName="Click" />
                                        </Triggers>
                                        </asp:UpdatePanel> 
                                </td> 
                            </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:ImageButton ID="btnAgregar" runat="server" CssClass="Boton" 
                                ImageUrl="../images/btnAsignar.gif" 
                                onmouseout="this.src='../images/btnAsignar.gif';" 
                                onmouseover="this.src='../images/btnAsignar_on.gif';" />
                            </td>
                        </tr>
                    </table> 
                </td> 
            </tr>  
            <tr>
                <td colspan="6">
                    <asp:UpdatePanel ID="upnTelaCruda" runat="server">
                                                                                                                                                                                                                                                                                <ContentTemplate>
                        <asp:GridView ID="grdArticulo" runat="server" align="center" 
                            AutoGenerateColumns="false" ShowFooter="true" Width="730">
                            <Columns> 
                                <asp:BoundField DataField="int_Secuencia" HeaderText="Item" />
                                <asp:BoundField DataField="var_CodArticulo" HeaderText="Codigo Articulo" />
                                <asp:BoundField DataField="var_DesArticulo" HeaderText="Descripcion"> 
                                    <ItemStyle Width="700" />
                                    </asp:BoundField>     
                                <asp:BoundField DataField="var_Unidad" HeaderText="Unidad"/>
                                <asp:BoundField DataField="num_Cantidad" HeaderText="Cantidad" DataFormatString = "{0:#.##0,00}" />
                                <asp:BoundField DataField="num_CostoUnitario" HeaderText="CU" DataFormatString="{0:#.##0,00}" />
                                <asp:BoundField DataField="var_Descuento" HeaderText="DES.%"  /> 
                                <asp:BoundField DataField="num_Importe" HeaderText="Importe Sin IGV" DataFormatString = "{0:N}" />
                                <asp:BoundField DataField="var_DesServicio" HeaderText="Observacion" />
                                <asp:BoundField DataField="dtm_FechaInicio" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Inicio" />
                                <asp:BoundField DataField="dtm_FechaFinal" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Final" />
                                <asp:TemplateField> 
                                    <ItemTemplate>  
                                        <asp:ImageButton ID="btnEliminar" runat="server" CommandName="Delete" 
                                            ImageUrl="../images/btnEliminar.gif" 
                                            onmouseout="this.src='../images/btnEliminar.gif'" 
                                            onmouseover="this.src='../images/btnEliminar_on.gif'" />
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
                <td colspan="6">
                    <hr width="100%" height="1" noshadow />
                </td>
            </tr>
            <tr>
                <td colspan = "10" align ="right">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table cellpadding="0" cellspacing="3" border="0">
                                <tr>
                                    <td class="Titulo12">T. Parcial</td>
                                    <td><asp:TextBox ID="txtTotalParcial" CssClass="Texto12" runat="server" Width = "100"></asp:TextBox></td>
                                    <td class="Titulo12">Descuento</td>        
                                    <td>  
                                        <nobr> 
                                        <asp:TextBox ID="txtTotalDesc"  Width="50" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                                        </nobr>
                                    </td>
                                    <td class="Titulo12">Sub Total</td>
                                    <td><asp:TextBox ID="txtSubTotal" CssClass="Texto12" runat="server"  Width = "100"></asp:TextBox></td>
                                    <td class="Titulo12">IGV</td>
                                    <td> 
                                        <nobr>
                                        <asp:TextBox ID="txtIGV" Width="50" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                                        </nobr>
                                    </td>
                                    <td class="Titulo12">Total</td>
                                    <td>
                                        <nobr>
                                        <asp:TextBox ID="txtTotal" Width="100" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                                        </nobr>
                                    </td>
                                </tr>  
                            </table> 
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="grdArticulo" EventName="RowCreated" /> 
                            <asp:AsyncPostBackTrigger ControlID="grdArticulo" EventName="RowDeleting" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
            <td colspan = "10" align ="right"  >
                <table cellpadding="0" cellspacing="0"> 
                    <tr>
                        <td valign="middle" align="center">
                            <asp:Button runat="server" ID="btnAsignarOrdenServicio" CssClass="Boton"  Text="Asig. Orden Servicio"/>
                        </td>
                        <td>
                            <asp:ImageButton ID="btnTerminar" runat="server" CssClass="Boton" 
                                ImageUrl="../images/btnRegistroCierre.gif" 
                                onmouseout="this.src='../images/btnRegistroCierre.gif';" 
                                onmouseover="this.src='../images/btnRegistroCierre_on.gif';" />
                        </td>
                        <td>
                            <asp:ImageButton ID="btnRegistrar" runat="server" CssClass="Boton" 
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
    <asp:Panel ID="pnlCajaBanco" CssClass="Formulario" runat="server">
        <AVC:CajaBanco runat="server" ID="ctlCajaBanco" />
    </asp:Panel>
    <asp:Panel ID="pnlClienteRegistro" CssClass="Formulario" runat="server">
        <AVC1:ctlCliente ID="ctlCliente_Registro" runat="server"/>
    </asp:Panel>
    <asp:Panel ID="pnlRegistroOrdenServicio" CssClass="Formulario" runat="server">
        <div id="div1">Asignación de Orden de Servicio a las Facturas</div>
        <table>
            <tr>
                <td>
                    <AVC2:ctlOrdenServicio runat="server" ID="ctlOrdenServicio_Buscar" />
                </td>
            </tr>
            <tr>
                <td style="height:10px; "></td>
            </tr>
        </table>
        <asp:GridView ID="grdOrdenServicios" Width="500px" ShowFooter="true" AutoGenerateColumns="false" 
            runat="server" AllowPaging="true" PageSize="10" >
            <Columns>
                <asp:BoundField DataField="int_Secuencia" HeaderText="Id Sec.">
                    <ItemStyle Width="10px" />
                </asp:BoundField>
                <asp:BoundField DataField="var_IdComprobante" HeaderText="Id Comprobante">
                    <HeaderStyle CssClass="NoVisible" />
                    <ItemStyle CssClass="NoVisible" />
                    <FooterStyle CssClass="NoVisible" />
                </asp:BoundField>
                <asp:BoundField DataField="var_IdOrdenServicio" HeaderText="Id OS"/>
                <asp:BoundField DataField="var_RazonSocial" HeaderText="Razón Social">
                    <ItemStyle Width="300px" />
                </asp:BoundField>
                <asp:BoundField DataField="num_Importe" HeaderText="Importe Total" DataFormatString="{0:#,##0.0000}">
                    <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEliminar" CommandArgument='<%# Container.DataItem("int_Secuencia") %>' 
                            CommandName="Delete" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="GridHeader" />
            <FooterStyle CssClass="GridFooter" />
            <AlternatingRowStyle CssClass="GridAltItem" />
            <RowStyle CssClass="GridItem" />
        </asp:GridView>
        <table cellpadding="0" cellspacing="0"  style="text-align:left; "> 
            <tr>
                <td>
                    <asp:ImageButton ID="btnTerminarOSR" runat="server" CssClass="Boton" 
                        ImageUrl="../images/btnRegistroCierre.gif" 
                        onmouseout="this.src='../images/btnRegistroCierre.gif';" 
                        onmouseover="this.src='../images/btnRegistroCierre_on.gif';" />
                </td>
                <td>
                    <asp:ImageButton ID="btnRegistrarOSR" runat="server" CssClass="Boton" 
                        ImageUrl="../images/btnRegistrar.gif" 
                        onmouseout="this.src='../images/btnRegistrar.gif';" 
                        onmouseover="this.src='../images/btnRegistrar_on.gif';" /> 
                </td>
                <td>
                    <asp:ImageButton ID="btnCancelarOSR" runat="server" CssClass="Boton" 
                        ImageUrl="../images/btnCancelar.gif" 
                        onmouseout="this.src='../images/btnCancelar.gif';" 
                        onmouseover="this.src='../images/btnCancelar_on.gif';" />
                </td>
            </tr>
        </table>
        <div id="div2">
            <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                <ProgressTemplate>
                    <img src="../images/loader.gif" />
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:Label ID="Label2" runat="server"></asp:Label>&nbsp;
        </div> 
    </asp:Panel>
</div>
</asp:Content>

