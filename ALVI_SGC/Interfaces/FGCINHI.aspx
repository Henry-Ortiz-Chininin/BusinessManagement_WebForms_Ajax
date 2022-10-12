<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCINHI.aspx.vb" Inherits="Interface_FGCINHI" %>
<%@ Register TagPrefix="UC" TagName="Articulo" Src="~/Controles/ctlArticulo_Buscar.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script language="javascript" src="../js/jquery-1.7.1.js"></script>
<style>
.Documentos{
	cursor:pointer;
}
</style>
<script language="javascript">
    function Buscar(InputId) {
        var IdOrden = document.getElementById(InputId);
        IdOrden.value = prompt("Ingrese Codigo de Servicio", IdOrden.value);
        if (IdOrden.value != '') {
            return true;
        } else {
        return false;
        }
    }
    function Buscar2(InputId) {
        var IdKardex = document.getElementById(InputId);
        IdKardex.value = prompt("Ingrese Id de Movimiento", IdKardex.value);
        if (IdKardex.value != '') {
            return true;
        } else {
            return false;
        }
    }


</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">Salida a Servicio de terceros</div>
<div id="divOpciones">
    
<table cellpadding="1" cellspacing="1" border="0">
    <tr>
    <td><asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'" onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" /></td>
    <td><asp:ImageButton ID="btnRegistrar" runat="server" onmouseover="this.src='../images/btnRegistrar_on.gif'" onmouseout="this.src='../images/btnRegistrar.gif'" ImageUrl="../images/btnRegistrar.gif" /></td>
    <td><asp:ImageButton ID="btnImprimir" runat="server" onmouseover="this.src='../images/btnImprimir_on.gif'" onmouseout="this.src='../images/btnImprimir.gif'" ImageUrl="../images/btnImprimir.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
    <td><img ID="btnDocumentos" class="Documentos" onmouseover="this.src='../images/btnDocumentos.gif'" onmouseout="this.src='../images/btnDocumentos.gif'" src="../images/btnDocumentos.gif" /></td>
    </tr>
    </table>
</div>
<asp:HiddenField ID="hdnIdKardex" runat="server" />
<asp:HiddenField ID="hdnIdOrden" runat="server" />
<table cellpadding="1" cellspacing="1" border="0" width="500">
    <tr>
        <td class="Titulo12">Codigo de Movimiento</td>
        <td>
        <asp:TextBox ID="txtIdKardex" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td class="Titulo12">Proveedor</td>
        <td>
            <asp:HiddenField ID="hdnIdProveedor" runat="server" />
            <asp:Label ID="lblProveedor"  CssClass="Texto12" runat="server" Text=""></asp:Label>
        </td>
    </tr>
            <tr>
        <td class="Titulo12">Orden de Servicio</td>
        <td><asp:TextBox ID="txtOPReferencia" MaxLength="20" onChange="validadigito(this,'TEL');" onKeypress="return Valida(event, 'TEL');" CssClass="Texto12" runat="server"></asp:TextBox></td>
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
        <td class="Titulo12">Orden de producción</td>
        <td><asp:TextBox ID="txtOrdenProduccion" MaxLength="20" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="Titulo12">Tipo Movimiento</td>
        <td>
            <asp:DropDownList ID="ddlTipoMovimiento" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
         <tr>
        <td class="Titulo12">Cliente</td>
        <td>
            <asp:Label ID="lblCliente" CssClass="Texto12" runat="server" Text=""></asp:Label>
        </td>
    </tr>
                <tr>
        <td class="Titulo12">Observacion</td>
        <td><asp:TextBox ID="txtObservacionGeneral"  CssClass="Texto12" runat="server"></asp:TextBox></td>
    </tr>


</table>

    <asp:GridView ID="grdDatos" Width="1200"  ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>
        <asp:BoundField DataField="var_IdCentroCosto" HeaderText="IdCC" />
        <asp:BoundField DataField="var_Proceso" HeaderText="Etapa" />
        <asp:BoundField DataField="var_IdArticulo" HeaderText="Codigo" />

        <asp:BoundField DataField="var_Material" HeaderText="Articulo" />
        <asp:TemplateField HeaderText="Almacen" >
            <ItemTemplate>
                <asp:DropDownList ID="ddlAlmacen" Width="200"  CssClass="Texto12" runat="server" >
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Despacho">
            <ItemTemplate>
                <asp:TextBox ID="txtDespacho" Width="50"  onChange="validadigito(this,'NUM');" onKeypress="return Valida(event, 'NUM');" CssClass="Texto12" runat="server"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cuenta de Gasto">
            <ItemTemplate>
                <asp:DropDownList ID="ddlCuentaGasto"  Width="200"  CssClass="Texto12" runat="server">
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField> 
        <asp:BoundField DataField="var_UnidadMedida" HeaderText="Metrica" /> 
        <asp:BoundField DataField="num_CantidadDespacho" HeaderText="Saldo" />
        <asp:BoundField DataField="num_CantidadOrden" HeaderText="Requerido" />
        <asp:BoundField DataField="var_IdUnidadMedida" HeaderText="UND" />
           
        </Columns>
    <HeaderStyle CssClass="GridHeader" />
    <FooterStyle CssClass="GridFooter" />
    <AlternatingRowStyle CssClass="GridAltItem" />
    <RowStyle CssClass="GridItem" />
    </asp:GridView>



     <asp:Panel ID="pnlFormulario" CssClass="Formulario" runat="server">
    <div id="divTitulo">Ingreso de Documentos</div>
    <asp:UpdatePanel runat="server" ID="upnFormulario">
    <ContentTemplate>
    
    <table cellpadding="2" cellspacing="2" border="0" width="600" align="center" valign="middle">
     <tr>
        <td class="Titulo12">Tipo Documento</td>
        <td>
            <asp:DropDownList ID="ddlPTipoDocumento" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">Número de documento</td>
        <td><asp:TextBox ID="txtNumeroDocumento"  Width="100" onChange="validadigito(this,'TEL');" onKeypress="return Valida(event, 'TEL');" CssClass="Texto12" runat="server"></asp:TextBox></td>
    </tr>  

      <tr>
        <td class="Titulo12">Fecha de Documento</td>
        <td>
        <nobr>
        <asp:TextBox ID="txtFechaDoc" Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
        <asp:Image ID="btnFechaDoc" runat="server" ImageUrl="~/Images/im_calendar.gif" />
        </nobr></td>
    </tr>
    <tr>
        <td class="Titulo12">Importe</td>
        <td><asp:TextBox ID="txtImporte" Width="100" onChange="validadigito(this,'NUM');" onKeypress="return Valida(event, 'NUM');" CssClass="Texto12" runat="server"></asp:TextBox></td>
    </tr>     
    <tr>
        <td colspan="2">
        <asp:GridView ID="grdProveedor" Width="600"  ShowFooter="true" 
                runat="server" AutoGenerateColumns="false" 
                align ="center" ViewStateMode="Enabled" >
                <Columns>
                    <asp:BoundField DataField="Codigo" HeaderText="IDT" />
                    <asp:BoundField DataField="Tipo" HeaderText="Documento" />
                    <asp:BoundField DataField="numero" HeaderText="Numero" />
                    <asp:BoundField DataField="IdProveedor" HeaderText="RUC" />
                    <asp:BoundField DataField="Proveedor" HeaderText="Razon Social" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="Importe" HeaderText="Importe" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEliminar" CommandName="Delete" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            <HeaderStyle CssClass="GridHeader" />
            <FooterStyle CssClass="GridFooter" />
            <AlternatingRowStyle CssClass="GridAltItem" />
            <RowStyle CssClass="GridItem" />
            </asp:GridView>
        </td>
    </tr>
    </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnRegistrar2" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="grdProveedor" EventName="RowCommand" />
        <asp:AsyncPostBackTrigger ControlID="grdProveedor" EventName="RowDeleting" />
        </Triggers>
    </asp:UpdatePanel>
    <table cellpadding="1" border="0" cellspacing="1">
        <tr>
        <td>
            <asp:ImageButton ID="btnRegistrar2" CssClass="Boton" onmouseover="this.src='../images/btnRegistrar_on.gif';" onmouseout="this.src='../images/btnRegistrar.gif';" ImageUrl="../images/btnRegistrar.gif" runat="server" />
        </td>
        <td>
            <img ID="btnCancelar" class="Documentos" onmouseover="this.src='../images/btnCancelar_on.gif';" onmouseout="this.src='../images/btnCancelar.gif';" src="../images/btnCancelar.gif" runat="server" />
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

<script>
    $(document).ready(function (e) {

        $(".Documentos").click(function (e) {
            $(".Formulario").toggle();
        });

        $(".Formulario").hide();
    
    });

</script>

</asp:Content>

