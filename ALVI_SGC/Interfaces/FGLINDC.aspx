<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGLINDC.aspx.vb" Inherits="Interfaces_FGLINDC" %>
<%@ Register src="../Controles/ctlProveedor_Buscar.ascx" tagname="ctlProveedor_Buscar" tagprefix="uc1" %>
<%@ Register src="../Controles/ctlElementoReferencial_Buscar.ascx" tagname="ctlElementoReferencial_Buscar" tagprefix="uc2" %>
<%@ Register src="../Controles/ctlUnidadMedida_Buscar.ascx" tagname="ctlUnidadMedida_Buscar" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script language="javascript">
    function Buscar(InputId) {
        var var_IdDocumentoCompra = document.getElementById(InputId);
        var_IdDocumentoCompra.value = prompt("Ingrese Codigo ", var_IdDocumentoCompra.value);
        return true;
    } 
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="divCuerpo">
<div id="divHeader">REGISTRO DE DOCUMENTOS DE COMPRA</div>

<div id="divOpciones">
<table cellpadding="1" cellspacing="1" border="0">
    <tr>
      <td><asp:ImageButton ID="btnNuevo" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'" onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif" /></td>
    <td><asp:ImageButton ID="btnRegistrar" runat="server" onmouseover="this.src='../images/btnRegistrar_on.gif'" onmouseout="this.src='../images/btnRegistrar.gif'" ImageUrl="../images/btnRegistrar.gif" /></td>
    <td><asp:ImageButton ID="btnAsignar" runat="server" onmouseover="this.src='../images/btnAsignar_on.gif'" onmouseout="this.src='../images/btnAsignar.gif'" ImageUrl="../images/btnAsignar.gif" /></td>
    <td><asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'" onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
    </tr>
    </table>
</div>
<asp:HiddenField ID="hdnIdComprar" runat="server" />
 <table cellpadding="0" cellspacing="1" border="0">
    <tr>
    <td valign="top">
    <table cellpadding="0" cellspacing="1" border="0">
        <tr>
            <td class="Titulo12">Codigo:</td>
            <td>
                <asp:TextBox ID="txtCodigo" CssClass="Texto12" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr> 
        <tr>
            <td class="Titulo12">Numero:</td>
            <td>
                <asp:TextBox ID="txtNumero1" CssClass="Texto12" runat="server" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtNumero2" CssClass="Texto12" runat="server" Width="120px"></asp:TextBox>
            </td> 
        </tr> 
        <tr>
            <td  class="Titulo12">Fecha Emision</td>
            <td><asp:TextBox ID="txtFechaEmisionInicio" Width="80" MaxLength="10"  CssClass="Texto12" runat="server"></asp:TextBox>
                <asp:Image ID="btnFechaEmisionInicio" runat="server" Visible="false" ImageUrl="~/Images/im_calendar.gif" />
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtFechaEmisionInicio"
                                DaysModeTitleFormat="MMMM - yyyy" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy">
                            </asp:CalendarExtender>
                </td>
        </tr> 
        <tr>
            <td  class="Titulo12">Fecha Vencimiento</td>
                    <td><asp:TextBox ID="txtFechaVencimientoInicio" Width="80" MaxLength="10" CssClass="Texto12" runat="server"></asp:TextBox>
                    <asp:Image ID="btnFechaVencimientoInicio" Visible="false" runat="server" ImageUrl="~/Images/im_calendar.gif" />
                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="txtFechaVencimientoInicio"
                                DaysModeTitleFormat="MMMM - yyyy" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy">
                            </asp:CalendarExtender>
                    </td>
        </tr>
        <tr>
        
            <td class="Titulo12">Tipo Documento</td>
            <td>
                <asp:DropDownList ID="ddlTipo" runat="server">
                </asp:DropDownList>
            </td>
         </tr>
        <tr>
            <td class="Titulo12">Moneda</td>
            <td>
                <asp:DropDownList ID="ddlMoneda" runat="server">
                    <asp:ListItem Value="S">Nuevos Soles</asp:ListItem>
                    <asp:ListItem Value="D">Dolares</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="Titulo12">Operacion</td>
                <td>
                    <asp:DropDownList ID="ddlOperacion" runat="server">
                    </asp:DropDownList>
                </td>
        </tr>
    </table>
    </td>
    <td valign="top">
        <uc1:ctlProveedor_Buscar ID="ctlProveedor_Buscar1" runat="server" />
    </td>
    </tr>
</table>
 <hr width="100%" noshade />
 
<table cellpadding="1" cellspacing="1" border="0">
<tr>
    <td class="Titulo12">Sub-total:</td>
    <td>
        <asp:TextBox ID="txtSubTotal" Enabled="false" CssClass="Texto12" runat="server" Width="130px"></asp:TextBox>
    </td>
    <td class="Titulo12">IGV:</td>
    <td>
        <asp:TextBox ID="txtIGV" Enabled="false" CssClass="Texto12" runat="server" Width="130px"></asp:TextBox>
    </td>
    <td class="Titulo12">Total:</td>
    <td>
        <asp:TextBox ID="txtTotal" Enabled="false" CssClass="Texto12" runat="server" Width="130px"></asp:TextBox>
    </td>
</tr>
</table>
 <hr width="100%" noshade />

<asp:GridView ID="grdDatos" Width="800" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>
        <asp:BoundField DataField="var_IdDetalle" HeaderText="correlativo" HeaderStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" />
        <asp:BoundField DataField="var_IdArticulo" HeaderText="Idarticulo" HeaderStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" />
         <asp:BoundField DataField="var_Articulo" HeaderText="Articulo" >
            <HeaderStyle Width="200" />
         </asp:BoundField>
         <asp:BoundField DataField="var_IdUnidadMedida" HeaderText="IdUnidadMedida" HeaderStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" />
         <asp:BoundField DataField="var_UnidadMedida" HeaderText="Medida" />
         <asp:BoundField DataField="var_IdArticuloProveedor" HeaderText="IdArticuloProveedor" HeaderStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" />
         <asp:BoundField DataField="var_NombreArticuloProveedor" HeaderText="NombreArticuloProveedor" HeaderStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" />
         <asp:BoundField DataField="int_Cantidad" HeaderText="Cantidad" />
         <asp:BoundField DataField="num_ImporteOrigen" HeaderText="Importe" />
          <asp:BoundField DataField="var_IdMoneda" HeaderText="Moneda" HeaderStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" />
          <asp:BoundField DataField="dec_TipoCambio" HeaderText="TipoCambio" />
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
    <div id="divTitulo">DOCUMENTO DE COMPRA – ASIGNACION DE ARTICULOS</div>
    <table cellpadding="2" cellspacing="2" border="0" width="900" align="center" valign="middle">
    <table>
     <tr>
    <td>
        
        <asp:HiddenField ID="hdnIdCorrelativo1" runat="server" />
     </td>
    </tr>
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


    <div id="pnlCentroCosto" class="clsControlBusqueda" style="position:absolute; top:50px;left:550px">  
    
    <div class ="Titulo">Articulo Proveedor:</div>
<table cellpadding="0" cellspacing="0" border="0" width="120">

    <tr>  
        <td class="Titulo12" width="100" >Codigo</td>
        <td><asp:TextBox ID="txtIdArticuloProveedor" Width="200px"  CssClass="Codigo" runat="server"></asp:TextBox></td>
       
    </tr>
    <tr> 
        <td class="Titulo12" width="100" >Nombre:</td>
        <td><asp:TextBox ID="txtNombreArticuloProveedor" Width="200px"  CssClass="Texto" runat="server"></asp:TextBox></td>
       
    </tr> 

    </table> 
  </div>  
  

   <div style="position:absolute; top:120px; left:550px; z-index:0;">
    <table>

    <tr>
        <td class="Titulo12">Cantidad</td>
        <td>
            <asp:TextBox ID="txtCantidad" CssClass="Texto12" runat="server" Width="100px"></asp:TextBox>
        </td>
  </tr>
  <tr>
        <td class="Titulo12">Importe</td>
        <td>
            <asp:TextBox ID="txtImporteOrigen" AutoPostBack="true" CssClass="Texto12" runat="server" Width="100px"></asp:TextBox>
        </td> 

      
  </tr> 

    <tr>
            <td class="Titulo12">Moneda</td>
            <td>
               <asp:DropDownList ID="ddlMonedaFormulario" AutoPostBack="true" CssClass="Texto12" runat="server">
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
        <td class="Titulo12">Importe S/.</td>
        <td>
            <asp:UpdatePanel ID="upnImporte" runat="server" >
            <ContentTemplate>
            <asp:TextBox ID="txtImporte" CssClass="Texto12" runat="server" Width="100px"></asp:TextBox>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlMonedaFormulario" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="txtTipoCambio" EventName="TextChanged" />
                <asp:AsyncPostBackTrigger ControlID="txtImporteOrigen" EventName="TextChanged" />
            </Triggers>
            </asp:UpdatePanel>
        </td> 

      
  </tr> 

    </table>

   </div>



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
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>&nbsp;</div>   
    </asp:Panel>


</div>
</asp:Content>

