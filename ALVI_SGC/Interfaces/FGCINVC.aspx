<%@ Page Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCINVC.aspx.vb" Inherits="Estandares_FGCINVC" title="Sistema de Gestión de Costos - Alta Visión Consultores sin título" %>
<%@ MasterType VirtualPath="~/Masterpage/General.master" %>
<%@ Register TagName="ctlCliente" TagPrefix="Cliente" Src="~/Controles/ctlCliente_BuscarEX.ascx" %>
<%@ Register TagName="ctlArticulo" TagPrefix="Articulo" Src="~/Controles/ctlArticulo_BuscarTL.ascx" %>
<%@ Register TagName="ctlArticulo" TagPrefix="ART" Src="~/Controles/ctlArticulo_BuscarTL.ascx" %>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">Notas de Debito</div>  
<div id="divOpciones">
<table cellpadding="0" cellspacing="1" border="0"> 
    <tr>
    <td><asp:ImageButton ID="btnNuevo" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'" onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
    <td><asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'" onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" /></td>
    </tr>
    </table> 
</div>
    <asp:HiddenField ID ="hdnIdCliente" runat = "server"/> 
    <asp:HiddenField ID="hdnIdParticiones" Value="0" runat="server" /> 
 <table cellpadding="3" cellspacing="3" border="0"> 
    <tr> 
        <td class="Titulo12">ID Documento</td>
        <td><asp:TextBox ID="txtIdNota" CssClass="Texto12" runat="server"></asp:TextBox></td>
        <td class="Titulo12">Fecha Inicio</td>        
        <td> 
        <nobr>
        <asp:TextBox ID="txtFechaInicio" Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
        <asp:Image ID="btnFechaInicio" runat="server" ImageUrl="~/Images/im_calendar.gif" />
        </nobr></td>
    </tr> 
    <tr>
        <td class="Titulo12">Razón Social Cliente</td>
        <td><asp:TextBox ID="txtCliente" CssClass="Texto12" runat="server"></asp:TextBox></td>
        <td class="Titulo12">Fecha Final</td>       
        <td>
        <nobr>
        <asp:TextBox ID="txtFechaFin" Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
        <asp:Image ID="btnFechaFin" runat="server" ImageUrl="~/Images/im_calendar.gif" />
        </nobr></td>
    </tr>
    <tr>
    <td class="Titulo12">Nº Documento</td>
    <td>  
    <table> 
    <tr>
    <td>
        <asp:TextBox ID="txtSerieNota" runat="server" Width = "30" MaxLength = "3"></asp:TextBox>
    </td>
    <td>
    -
    </td>
    <td>
    <asp:TextBox ID="txtNumNota" runat="server" Width = "70" MaxLength = "7"></asp:TextBox>
    </td>
    </tr>
        
    </table>
    </td>
    </tr>
 </table>
    <asp:GridView ID="grdDatos" Width="1000" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>
        <asp:BoundField DataField="var_Nota" HeaderText="Nº Documento" />
        <asp:BoundField DataField="var_IdCliente" HeaderText="Cliente" >
        <ItemStyle Width="300" />
        </asp:BoundField>
        <asp:BoundField DataField="dtm_FechaEmision" HeaderText="Emision" >
                    <ItemStyle Width="50" />
        </asp:BoundField>
        <asp:BoundField DataField="var_Estado" HeaderText="Estado" />
                <asp:BoundField DataField="var_TipoOperacion" HeaderText="Tipo Servicio" />
        <asp:BoundField DataField="var_idVendedor" HeaderText="Vendedor" /> 
        <asp:TemplateField> 
        <ItemTemplate>
            <asp:ImageButton ID="btnModificar" CommandArgument='<%#Container.DataItem("var_IdNota") %>' CommandName="Modificar" ImageUrl="../images/btnAbrir.gif" runat="server" onmouseover="this.src='../images/btnAbrir_on.gif'" onmouseout="this.src='../images/btnAbrir.gif'" />
        </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <HeaderStyle CssClass="GridHeader" />
    <FooterStyle CssClass="GridFooter" />
    <AlternatingRowStyle CssClass="GridAltItem" />
    <RowStyle CssClass="GridItem" />
    </asp:GridView>
    <asp:Panel ID="pnlFormulario" CssClass="Formulario" runat="server">
    <div id="divTitulo">Registro - Notas de debito</div>
    <table cellpadding="2" cellspacing="2" border="0" width="500" align="center" valign="middle">
    <tr>
 <td>
        <table cellpadding="2" cellspacing="2" border="0" width="500" align="center" valign="middle">
        <tr>
        <td colspan = 10>
        <table width = "500">
        <tr>
        <td colspan = "2">
        <table >
        <tr>
             <td class="Titulo12">
                <asp:RadioButton ID="rbtProducto" runat="server" GroupName="Servicio" text = "Producto" AutoPostBack = "true" Width = "100"/>    
            </td>
               <td class="Titulo12">
               <asp:RadioButton ID="rbtServicio" runat="server"  GroupName="Servicio" text = "Servicio" AutoPostBack = "true" Width = "100"/>
            </td>
            <td align="right ">
                        <table>  
            <tr>
            <td class="Titulo12">  
            Comprobantes: 
            </td> <td>
            </td>
            <td><asp:ImageButton ID="btnBuscaComprobante" runat="server" onmouseover="this.src='../images/lupa_on.gif'" onmouseout="this.src='../images/lupa.gif'" ImageUrl="../images/lupa.gif" />
            <asp:Label ID="lblSpacing" runat="server" Width = "10"></asp:Label>
            </td>
            </tr> </table>
             
            </td>
    
            <td class="Titulo12">
            <asp:Label ID="lblSpacing6" Tect="" runat="server" Width = "10"></asp:Label>
            <asp:Label ID="lblTipo" Tect="Tipo :" runat="server" Width = "50"></asp:Label></td>
            <td>
            <asp:UpdatePanel  ID = "upnTipoDescuento" runat = "server">
            <ContentTemplate> 
            <asp:DropDownList ID="ddlTipoDescuento" runat="server">
            <asp:ListItem Value = "1" > Nota - %</asp:ListItem>
            <asp:ListItem Value = "0" > Nota - Importe</asp:ListItem>
            </asp:DropDownList>
            </ContentTemplate>
             <Triggers> 
            <asp:AsyncPostBackTrigger ControlID="grdComprobante" EventName="RowDeleting" />
            <asp:AsyncPostBackTrigger ControlID="grdComprobante" EventName="RowCreated" />
            </Triggers>  
            </asp:UpdatePanel>   
            </td>  
        </tr>
        </table> 
        
        </td>
        </tr></table></td></tr>
            <tr><td colspan="6""><hr width="100%" height="1" noshadow /></td></tr>
        <tr>
            <td class="Titulo12">DATOS GENERALES</td> 
        </tr>
                <tr>
                <td colspan ="10">
                <table>
                <tr>
                 
                <td class="Titulo12">ID: </td>
            <td>
            <asp:TextBox  ID="txtCodigo" runat="server" Width ="30">
            </asp:TextBox>
            </td>
                          <td class="Titulo12">NºDoc. </td> 
            <td>
            <asp:TextBox  ID="txtNumero" runat="server" Width ="30" MaxLength = "3">
            </asp:TextBox> 
            </td>
                          <td class="Titulo12"> - </td> 
            <td>
            <asp:TextBox  ID="txtCorrelativo" runat="server" Width = "70" MaxLength = "7">
            </asp:TextBox>
            <asp:Label ID="lblSpacing2" runat="server" Width = "20"></asp:Label>
            </td>
                        <td class="Titulo12">Emision</td>
            <td>
            <nobr>
            <asp:TextBox ID="txtFechaEmision" Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
            <asp:Image ID="btnFechaEmision" runat="server" ImageUrl="~/Images/im_calendar.gif"/>
            <asp:Label ID="lblSpacing3" runat="server" Width = "20"></asp:Label>
            </nobr></td>
                        <td class="Titulo12">Vendedor</td>
            <td>
            <asp:DropDownList ID="ddlVendedor" runat="server">
            </asp:DropDownList> 
            </td>
                </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
                </td>
                </tr>
            <tr><td colspan="6"><hr width="100%" height="1" noshadow /></td></tr>
                <tr>
            <td class="Titulo12" colspan = "6">DATOS DEL CLIENTE</td>
        </tr>
            <tr>
            <td class="Titulo12" colspan="2">
            <Cliente:ctlCliente ID="ctlCliente2" runat="server" />
            </td>
             
            <td align="justify">
            <table>
            <tr> 
            <td class="Titulo12">Moneda: </td> 
            <td>
            <asp:DropDownList ID="ddlMoneda" runat="server" Width = "158">
            </asp:DropDownList>
            </td> 
            </tr>
            <tr>
            <td class="Titulo12">Motivo: </td>
            <td>
            <asp:DropDownList ID="ddlMotivo" runat="server" Width = "158">
            </asp:DropDownList> 
            </td> 
            </tr>
            <tr>
            <td class="Titulo12">Estado :</td>
            <td>

            <asp:DropDownList ID="ddlEstado" runat="server" Width = "158">
            <asp:ListItem Value = "ACT" > Activo</asp:ListItem>
            <asp:ListItem Value = "DES" > Inactivo</asp:ListItem>
            </asp:DropDownList>
            </td>
            </tr>
            </table> 
            </td> 
        </tr>
         <tr>
        <td colspan = "5">
        <table>
        <tr>
        <td class="Titulo12" width = "100">
        Glosa : 
        </td> 
        <td>
        <asp:TextBox ID = "txtGlosa" runat= "Server" width = "530" ></asp:TextBox>
        </td> 
        </tr>
        </table>
        </td>
        </tr>
        <tr>
                    <td align ="center" colspan = "8">
                </td> </tr> <tr>
                         <td colspan="10"> 
                          <asp:UpdatePanel ID="upnTelaCruda" runat="server"> 
                           <ContentTemplate> 
                                         <asp:GridView ID="grdComprobante" runat="server" align="center" 
                                            AutoGenerateColumns="false" ShowFooter="true" Width="900"> 
                                            <Columns>
                                            <asp:BoundField DataField="int_Secuencia" HeaderText="Item" /> 
                                            <asp:BoundField DataField="var_Tipo" HeaderText="Tipo"/> 
                                            <asp:BoundField DataField="var_IdComprobante" HeaderText="Nº Comprobante"/> 
                                            <asp:BoundField DataField="var_IdArticulo"  HeaderText="Codigo"/> 
                                            <asp:BoundField DataField="var_DesArticulo"  HeaderText="Descripcion"/>
                                            <asp:BoundField DataField="num_Cantidad"  HeaderText="Cantidad" DataFormatString="{0:N4}" />
                                            <asp:BoundField DataField="num_CostoUnitario"  HeaderText="CU" DataFormatString="{0:N4}" /> 
                                            <asp:BoundField DataField="num_ImporteOriginal"  HeaderText="Imp. Doc" DataFormatString="{0:N4}"/> 
                                            <asp:BoundField DataField="num_DescPantalla"  HeaderText="Desc. %" DataFormatString="{0:N4}" /> 
                                            <asp:BoundField DataField="num_ImportePantalla"  HeaderText="Importe" DataFormatString="{0:N4}"/> 
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
             <table cellpadding="0" cellspacing="3" border="0"> 
                <tr> <td colspan="20"><hr width="130%" height="1" noshadow /> </td> </tr>  
                <tr> <td class="Titulo12">Total Parcial</td><td> 
             <asp:TextBox ID="txtTotalParcial" Width="100" CssClass="Texto12" runat="server"></asp:TextBox></td>
                <td class="Titulo12">Desc%</td> <td> <nobr>
             <asp:TextBox ID="txtTotalDesc" Width="50" visible = "False" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
               <asp:TextBox ID="txtTotalDescVisible" Width="50" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                </nobr> </td>
                <td class="Titulo12">Sub Total</td><td> 
             <asp:TextBox ID="txtSubTotal" CssClass="Texto12" runat="server"  Width = "100"></asp:TextBox></td>
                <td class="Titulo12">IGV</td>
                <td> <nobr>
             <asp:TextBox ID="txtIGV" Width="50" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                </nobr></td>
                <td class="Titulo12">Total</td>
                <td> <td> <nobr>
             <asp:TextBox ID="txtTotal" Width="100" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                </nobr></td></tr>  
        </table> 
        </ContentTemplate>
        </asp:UpdatePanel>
        </td>
            </tr>
            <tr>
                <td colspan="2"> 
                    <asp:ImageButton ID="btnTerminar" runat="server" CssClass="Boton" 
                        ImageUrl="../images/btnRegistroCierre.gif" 
                        onmouseout="this.src='../images/btnRegistroCierre.gif';" 
                        onmouseover="this.src='../images/btnRegistroCierre_on.gif';" />
                    <asp:ImageButton ID="btnRegistrar" runat="server" CssClass="Boton" 
                        ImageUrl="../images/btnRegistrar.gif" 
                        onmouseout="this.src='../images/btnRegistrar.gif';" 
                        onmouseover="this.src='../images/btnRegistrar_on.gif';" />
                    <asp:ImageButton ID="btnCancelar" runat="server" CssClass="Boton" 
                        ImageUrl="../images/btnCancelar.gif" 
                        onmouseout="this.src='../images/btnCancelar.gif';" 
                        onmouseover="this.src='../images/btnCancelar_on.gif';" />
           </td> </tr> </tr>
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
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>&nbsp;</div>
    </asp:Panel>

    <asp:Panel ID="pnlBusqueda" CssClass="Formulario" runat="server">
    <div id="divTitulo">Busqueda - Comprobantes</div>
    <table cellpadding="2" cellspacing="2" border="0" width="700" align="center" valign="middle">
         <tr> 
             <td>
                 <table>
                     <tr>
                         <td>
                             <table>
                                 <tr>
                                     <td>
                                         <asp:UpdatePanel ID="upnFiltro" runat="server">
                                             <ContentTemplate>
                                                 <asp:TextBox ID="txtFiltro" runat="server" AutoPostBack="true" Width="100"></asp:TextBox>
                                             </ContentTemplate>
                                             <Triggers>
                                                 <asp:AsyncPostBackTrigger ControlID="ddlfiltro" 
                                                     EventName="SelectedIndexChanged" />
                                             </Triggers>
                                         </asp:UpdatePanel>
                                     </td>
                                     <td>
                                         <asp:UpdatePanel ID="upnFecInicio" runat="server">
                                             <ContentTemplate>
                                                 <asp:Image ID="btnFecInicio" runat="server" 
                                                     ImageUrl="~/Images/im_calendar.gif" />
                                             </ContentTemplate>
                                             <Triggers>
                                                 <asp:AsyncPostBackTrigger ControlID="ddlfiltro" 
                                                     EventName="SelectedIndexChanged" />
                                             </Triggers>
                                         </asp:UpdatePanel>
                                     </td>
                                 </tr>
                             </table>
                         </td>
                         <td>
                             <table>
                                 <tr>
                                     <td>
                                         <table>
                                             <tr>
                                                 <td>
                                                     <asp:UpdatePanel ID="unptxtFecFin" runat="server">
                                                         <ContentTemplate>
                                                             <asp:TextBox ID="txtFecFin" runat="server" AutoPostBack="true" Width="100"></asp:TextBox>
                                                         </ContentTemplate>
                                                         <Triggers>
                                                             <asp:AsyncPostBackTrigger ControlID="ddlfiltro" 
                                                                 EventName="SelectedIndexChanged" />
                                                         </Triggers>
                                                     </asp:UpdatePanel>
                                                 </td>
                                                 <td>
                                                     <asp:UpdatePanel ID="unpbtnFecfin" runat="server">
                                                         <ContentTemplate>
                                                             <asp:Image ID="btnFecFin" runat="server" ImageUrl="~/Images/im_calendar.gif" />
                                                         </ContentTemplate>
                                                         <Triggers>
                                                             <asp:AsyncPostBackTrigger ControlID="ddlfiltro" 
                                                                 EventName="SelectedIndexChanged" />
                                                         </Triggers>
                                                     </asp:UpdatePanel>
                                                 </td>
                                             </tr>
                                         </table>
                                     </td>
                                     <td>
                                     </td>
                                 </tr>
                             </table>
                         </td>
                         <td>
                             <asp:DropDownList ID="ddlfiltro" runat="server" AutoPostBack="true">
                                 <asp:ListItem value="2">Nº</asp:ListItem>
                                 <asp:ListItem value="3">serie</asp:ListItem>
                                 <asp:ListItem value="4">Monto</asp:ListItem>
                                 <asp:ListItem value="7">Moneda</asp:ListItem>
                                 <asp:ListItem value="5">Razon Social</asp:ListItem>
                                 <asp:ListItem value="6">F.Emision</asp:ListItem>
                             </asp:DropDownList>
                         </td>
                         <td>
                             <asp:ImageButton ID="btnFiltrar" runat="server" 
                                 ImageUrl="../images/btnBuscar.gif" 
                                 onmouseout="this.src='../images/btnBuscar.gif'" 
                                 onmouseover="this.src='../images/btnBuscar_on.gif'" />
                         </td>
                     </tr>
                 </table>
             </td>
             <tr>
                 <td colspan="6">
                     <hr width="100%" height="1" noshadow />
                 </td>
             </tr>
             <tr>
                 <td colspan="6">
                     <div ID="Div1" runat="server" class="Lista">
                         <asp:GridView ID="grdBusqueda" runat="server" align="center" 
                             AutoGenerateColumns="false" ShowFooter="true" Width="700">
                             <Columns>
                                 <asp:BoundField DataField="var_Tipo" HeaderText="Factura/Boleta" />
                                 <asp:BoundField DataField="var_IdComprobante" HeaderText="Nº Comprobante" />
                                 <asp:BoundField DataField="var_IdCliente" HeaderText="Id.Cliente" />
                                 <asp:BoundField DataField="var_Cliente" HeaderText="Cliente" />
                                 <asp:BoundField DataField="dtm_FechaEmision" DataFormatString="{0:dd/MM/yyyy}" 
                                     HeaderText="Emision">
                                 <ItemStyle Width="50" />
                                 </asp:BoundField>
                                 <asp:BoundField DataField="dtm_FechaVencimiento" 
                                     DataFormatString="{0:dd/MM/yyyy}" HeaderText="vencimiento">
                                 <ItemStyle Width="50" />
                                 </asp:BoundField>
                                 <asp:BoundField DataField="var_TipoServicio" HeaderText="Tipo Servicio" />
                                 <asp:TemplateField>
                                     <ItemTemplate>
                                         <asp:ImageButton ID="btnAsignar" runat="server" 
                                             CommandArgument="<%#Container.DataItemIndex%>" CommandName="Asignar" 
                                             ImageUrl="../images/btnAsignar.gif" 
                                             onmouseout="this.src='../images/btnAsignar.gif'" 
                                             onmouseover="this.src='../images/btnAsignar_on.gif'" />
                                     </ItemTemplate>
                                 </asp:TemplateField>
                             </Columns>
                             <HeaderStyle CssClass="GridHeader" />
                             <RowStyle CssClass="GridItem" />
                             <AlternatingRowStyle CssClass="GridAltItem" />
                             <FooterStyle CssClass="GridFooter" />
                         </asp:GridView>
                     </div>
                 </td>
             </tr>
             <tr>
                 <td colspan="6">
                     <hr width="100%" height="1" noshadow />
                 </td>
             </tr>
             <tr>
                 <td colspan="6">
                     <div ID="pnlLista" runat="server" class="Lista">
                         <asp:GridView ID="grdArticulos" runat="server" align="center" 
                             AutoGenerateColumns="false" ShowFooter="true" Width="700">
                             <Columns>
                                 <asp:BoundField DataField="int_Secuencia" HeaderText="Item" />
                                 <asp:BoundField DataField="var_Tipo" HeaderText="Tipo" />
                                 <asp:BoundField DataField="var_IdComprobante" HeaderText="Nº Comprobante" />
                                 <asp:BoundField DataField="var_DesArticulo" HeaderText="Descripcion" />
                                 <asp:BoundField DataField="num_Cantidad" HeaderText="Cantidad" />
                                 <asp:BoundField DataField="num_CostoUnitario" HeaderText="CU" />
                                 <asp:TemplateField HeaderText="D%">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txtDescPantalla" runat="server" CssClass="Texto12" width="70"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="50" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Importe"> 
                                     <ItemTemplate>
                                         <asp:TextBox ID="txtImporte" runat="server" CssClass="Texto12" 
                                             Text='<%#Container.DataItem("num_ImportePantalla")%>' width="70" ></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="50" />
                                 </asp:TemplateField>
                                 <asp:BoundField DataField="num_ImportePantalla" HeaderText="Imp.C" />
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
                     </div>
                 </td>
             </tr>
             <tr>
                 <td>
                     <table align="center" border="0" cellpadding="2" cellspacing="6" 
                         valign="middle" width="500">
                         <tr>
                             <td align="left">
                                 <asp:ImageButton ID="btnDocumentoAceptar" runat="server" 
                                     ImageUrl="../images/btnAceptar.gif" 
                                     onmouseout="this.src='../images/btnAceptar.gif'" 
                                     onmouseover="this.src='../images/btnAceptar_on.gif'" />
                                 <asp:ImageButton ID="btnCancelarDocumento" runat="server" 
                                     ImageUrl="../images/btnCancelar.gif" 
                                     onmouseout="this.src='../images/btnCancelar.gif'" 
                                     onmouseover="this.src='../images/btnCancelar_on.gif'" />
                             </td>
                         </tr>
                     </table>
                 </td>
             </tr>
        </tr> 
            
    </table>
    <div id="divFooter">
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
            <img src="../images/loader.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:Label ID="Label1" runat="server"></asp:Label>&nbsp;</div>   
    </asp:Panel>
</div>
</asp:Content>
  
