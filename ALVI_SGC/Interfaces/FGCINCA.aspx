<%@ Page Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCINCA.aspx.vb" Inherits="Interfaces_FGCINCA" title="Sistema de Gestión de Costos - Alta Visión Consultores" %>
<%@ MasterType VirtualPath="~/Masterpage/General.master"  %>
<%@ Register TagPrefix="UC" TagName="Articulo" Src="~/Controles/ctlArticulo_Buscar.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script language="javascript">
function Buscar(InputId)
{
   var IdKardex = document.getElementById(InputId);
   IdKardex.value = prompt("Ingrese Codigo de Movimiento",IdKardex.value);
   return true;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="divCuerpo">
<div id="divHeader">Registro de Ingresos al Almacen</div>
<div id="divOpciones">
<table cellpadding="1" cellspacing="1" border="0">
    <tr>
    <td><asp:ImageButton ID="btnNuevo" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'" onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif" /></td>
    <td><asp:ImageButton ID="btnRegistrar" runat="server" onmouseover="this.src='../images/btnRegistrar_on.gif'" onmouseout="this.src='../images/btnRegistrar.gif'" ImageUrl="../images/btnRegistrar.gif" /></td>
    <td><asp:ImageButton ID="btnAsignar" runat="server" onmouseover="this.src='../images/btnAsignar_on.gif'" onmouseout="this.src='../images/btnAsignar.gif'" ImageUrl="../images/btnAsignar.gif" /></td>
    <td><asp:ImageButton ID="btnImprimir" runat="server" onmouseover="this.src='../images/btnImprimir_on.gif'" onmouseout="this.src='../images/btnImprimir.gif'" ImageUrl="../images/btnImprimir.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
    </tr>
    </table>
</div>
    <asp:HiddenField ID="hdnIdKardex" runat="server" />
<table cellpadding="0" cellspacing="1" border="0">
    <tr>
        <td class="Titulo12">Codigo de Movimiento</td>
        <td>
        <asp:TextBox ID="txtIdKardex" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">Fecha de Movimiento</td>
        <td>
        <nobr>
        <asp:TextBox ID="txtFecha" Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
        <asp:Image ID="btnFecha" runat="server" ImageUrl="~/Images/im_calendar.gif" />
        </nobr></td>
    </tr>
    <tr>
        <td class="Titulo12">Tipo Movimiento</td>
        <td>
            <asp:DropDownList ID="ddlTipoMovimiento" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">Tipo Documento</td>
        <td>
            <asp:DropDownList ID="ddlTipoDocumento" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">Número de documento</td>
        <td><asp:TextBox ID="txtNumeroDocumento" MaxLength="20" onChange="validadigito(this,'TEL');" onKeypress="return Valida(event, 'TEL');" CssClass="Texto12" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="Titulo12">Orden de compra</td>
        <td><asp:TextBox ID="txtOPReferencia" MaxLength="20" onChange="validadigito(this,'TEL');" onKeypress="return Valida(event, 'TEL');" CssClass="Texto12" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="Titulo12">Observación</td>
        <td><asp:TextBox ID="txtObservacionGeneral" MaxLength="500" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server"></asp:TextBox></td>
    </tr>
</table>
<asp:GridView ID="grdDatos" Width="1000"  ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>
    <asp:BoundField DataField="var_IdArticulo" HeaderText="Codigo" HeaderStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" />
    <asp:BoundField DataField="var_Articulo" HeaderText="Articulo" />
    <asp:BoundField DataField="num_Cantidad" HeaderText="Cantidad" DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right" />
    <asp:BoundField DataField="var_UnidadMedida" HeaderText="Medida" />
    <asp:BoundField DataField="num_CostoUnitario" HeaderText="Precio/Unidad" DataFormatString="{0:#,##0.0000}" ItemStyle-HorizontalAlign="Right" />
    <asp:BoundField DataField="num_Importe" HeaderText="Total" DataFormatString="{0:#,##0.0000}" ItemStyle-HorizontalAlign="Right" />
    <asp:BoundField DataField="var_Moneda" HeaderText="Mon" />
    <asp:BoundField DataField="var_Almacen" HeaderText="Destino" />
    <asp:BoundField DataField="var_Observacion" HeaderText="Observación" />
    <asp:TemplateField>
    <ItemTemplate>
        <asp:ImageButton ID="btnModificar" CommandArgument='<%#Container.DataItem("var_IdArticulo") %>' CommandName="Modificar" ImageUrl="../images/btnAbrir.gif" runat="server" onmouseover="this.src='../images/btnAbrir_on.gif'" onmouseout="this.src='../images/btnAbrir.gif'" />
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField>
    <ItemTemplate>
        <asp:ImageButton ID="btnEliminar" CommandArgument='<%#Container.DataItem("var_IdArticulo") %>' CommandName="Eliminar" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    <HeaderStyle CssClass="GridHeader" />
    <FooterStyle CssClass="GridFooter" />
    <AlternatingRowStyle CssClass="GridAltItem" />
    <RowStyle CssClass="GridItem" />
    </asp:GridView>
    <asp:Panel ID="pnlFormulario" CssClass="Formulario" runat="server">
    <div id="divTitulo">Asignación de Articulo al movimiento</div>
    <table cellpadding="2" cellspacing="2" border="0" width="500" align="center" valign="middle">
        <tr>
        <td class="Titulo12">Almacen destino</td>
        <td width="350">
            <asp:DropDownList ID="ddlAlmacen" CssClass="Texto12" runat="server">
            </asp:DropDownList>
        </td>        
        </tr>
        <tr>
            <td colspan="2">
                <UC:Articulo runat="server" ID="ctlArticulo" />
            </td>        
        </tr>
        
        <tr>
                <td class="Titulo12" width="150">Cantidad</td>
                <td width="200">
                    <asp:TextBox ID="txtCantidad" AutoPostBack="true" MaxLength="14" onChange="validadigito(this,'NUM');" onKeypress="return Valida(event, 'NUM');" CssClass="Texto12" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="Titulo12">Costo Unitario</td>
                <td><asp:UpdatePanel ID="udpCosto" runat="server">
                    <ContentTemplate>
                    <asp:TextBox ID="txtCostoUnitario" MaxLength="20" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                    </ContentTemplate>
                    <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="txtCantidad" EventName="TextChanged" />
                    <asp:AsyncPostBackTrigger ControlID="txtImporte" EventName="TextChanged" />
                    </Triggers> 
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="Titulo12">Importe</td>
                <td>
                    <asp:TextBox ID="txtImporte" MaxLength="20" AutoPostBack="true" onChange="validadigito(this,'NUM');" onKeypress="return Valida(event, 'NUM');" CssClass="Texto12" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="Titulo12">Moneda</td>
                <td>
                    <asp:DropDownList ID="ddlMoneda" CssClass="Texto12" runat="server" AutoPostBack="true" >
                        <asp:ListItem Value="S">Nuevos Soles</asp:ListItem>
                        <asp:ListItem Value="D">Dolares</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr> 
             <tr>
                <td class="Titulo12">Tipo cambio</td>
                <td>
                    <asp:TextBox ID="txtTipoCambio" AutoPostBack="true" CssClass="Texto12" runat="server" Width="100px"></asp:TextBox>
                </td> 
          </tr>   
            <tr>
                <td class="Titulo12">Importe S/:</td>
                <td>
                    <asp:UpdatePanel ID="upnImporte" runat="server" >
                    <ContentTemplate>
                    <asp:TextBox ID="txtImporteMoneda" CssClass="Texto12" runat="server" Width="100px"></asp:TextBox>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlMoneda" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtTipoCambio" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtImporte" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtCantidad" EventName="TextChanged" />
                    </Triggers>
                    </asp:UpdatePanel></td>
            </tr>    
        <tr>
            <td class="Titulo12">Observación</td>
            <td><asp:TextBox ID="txtObservacionDetalle" MaxLength="500" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
        <td colspan="2">
            <asp:ImageButton ID="btnRegistrar2" CssClass="Boton" onmouseover="this.src='../images/btnRegistrar_on.gif';" onmouseout="this.src='../images/btnRegistrar.gif';" ImageUrl="../images/btnRegistrar.gif" runat="server" />
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

