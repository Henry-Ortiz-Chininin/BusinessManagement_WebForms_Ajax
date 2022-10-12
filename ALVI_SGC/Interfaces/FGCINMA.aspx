<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCINMA.aspx.vb" Inherits="Interfaces_FGCINMA" %>

<%@ Register src="../Controles/ctlCentroCosto_Buscar.ascx" tagname="ctlCentroCosto_Buscar" tagprefix="uc1" %>
<%@ Register src="../Controles/ctlElementoReferencial_Buscar.ascx" tagname="ctlElementoReferencial_Buscar" tagprefix="uc2" %>
<%@ Register src="../Controles/ctlUnidadMedida_Buscar.ascx" tagname="ctlUnidadMedida_Buscar" tagprefix="uc3" %>
<%@ Register src="../Controles/ctlSolicitante_Buscar.ascx" tagname="ctlSolicitante_Buscar" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<script language="javascript">
    function Buscar(InputId) {
        var IdVale = document.getElementById(InputId);
        IdVale.value = prompt("Ingrese Vale de Pedido ", IdVale.value);
        return true;
    }
  </script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
    <div id="divCuerpo">
<div id="divHeader">Salidas por Nota de Pedido</div>


<div id="divOpciones">
<table cellpadding="1" cellspacing="1" border="0">
    <tr>
    <td><asp:ImageButton ID="btnNuevo" Visible="false" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'" onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif" /></td>
    <td><asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'" onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" /></td>
    <td><asp:ImageButton ID="btnRegistrar" runat="server" onmouseover="this.src='../images/btnRegistrar_on.gif'" onmouseout="this.src='../images/btnRegistrar.gif'" ImageUrl="../images/btnRegistrar.gif" /></td>
    <td><asp:ImageButton ID="btnAsignar" Visible ="false" runat="server" onmouseover="this.src='../images/btnAsignar_on.gif'" onmouseout="this.src='../images/btnAsignar.gif'" ImageUrl="../images/btnAsignar.gif" /></td>
      <td><asp:ImageButton ID="btnDocumentos" Visible="false" runat="server" onmouseover="this.src='../images/btnDocumentos_on.gif'" onmouseout="this.src='../images/btnDocumentos.gif'" ImageUrl="../images/btnDocumentos.gif" /></td>
    <td><asp:ImageButton ID="btnImprimir" runat="server" onmouseover="this.src='../images/btnImprimir_on.gif'" onmouseout="this.src='../images/btnImprimir.gif'" ImageUrl="../images/btnImprimir.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
    </tr>
    </table>
</div> 

    <asp:HiddenField ID="hdnIdKardex" runat="server" />
 <asp:HiddenField ID="hdnIdVale" runat="server" />
<table>
 <tr>
        <td class="Titulo12">Codigo</td>

        <td>
            <asp:TextBox ID="txtCodigo" CssClass="Texto12" runat="server" Width="200px"></asp:TextBox>
             <asp:TextBox ID="txtIdKardex" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server" Visible="false"></asp:TextBox>
        </td> 

      
  </tr> 

     <tr>
            <td class="Titulo12">
                Fecha Emision</td>
            <td>
                <asp:TextBox ID="txtFechaEmision" runat="server" Width="80px"></asp:TextBox>
                <asp:Image ID="btnFechaEmision" runat="server" 
                    ImageUrl="~/Images/im_calendar.gif" />
            </td>
        </tr>

       <tr>
        <td class="Titulo12">Tipo Movimiento</td>
        <td>
            <asp:DropDownList ID="ddlOperacion" CssClass="texto12" runat="server">
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
        <td><asp:TextBox ID="txtNumeroDocumento" MaxLength="20" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'TEL');" CssClass="Texto12" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="Titulo12">Vale Asociado</td>
        <td><asp:TextBox ID="txtOPReferencia" MaxLength="20" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'TEL');" CssClass="Texto12" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="Titulo12">Observación</td>
        <td><asp:TextBox ID="txtObservacionGeneral" MaxLength="500" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server"></asp:TextBox></td>
    </tr>

        </table>
 <div style="position:absolute; top:70px; left:550px; z-index:0;">
<table>
<tr>
<td>
<uc4:ctlSolicitante_Buscar ID="ctlSolicitante_Buscar1"  runat="server" Visible="false" />
<uc1:ctlCentroCosto_Buscar ID="ctlCentroCosto_Buscar1" runat="server" />
</td>
</tr>
</table>
</div> 


       <asp:GridView ID="grdDatos" Width="900" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>
        <asp:BoundField DataField="var_IdArticulo" HeaderText="IdArticulo"  HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
         <asp:BoundField DataField="var_Articulo" HeaderText="Articulo" />

        <asp:BoundField DataField="var_IdUnidadMedida" HeaderText="IdUnidadMedida" HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
        <asp:BoundField DataField="var_UnidadMedida" HeaderText="Medida" />
        
         <asp:BoundField DataField="num_Cantidad" HeaderText="Cantidad">
         </asp:BoundField>
        <asp:TemplateField HeaderText ="Cantidad">
            <ItemTemplate>
                <asp:TextBox ID ="txtCantidadSalida" runat="server" Width="80px"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Almacen">
            <ItemTemplate>
                <asp:DropDownList ID="ddlAlmacen"  CssClass="Texto12" Width="200" runat="server">
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cuenta de Gasto">
            <ItemTemplate>
                <asp:DropDownList ID="ddlCuentaGasto"  CssClass="Texto12" Width="200" runat="server">
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
            
    
        <asp:TemplateField Visible ="false">
        <ItemTemplate>
            <asp:ImageButton ID="btnModificar" CommandArgument='<%#Container.DataItem("var_IdArticulo") %>' CommandName="Modificar" ImageUrl="../images/btnAbrir.gif" runat="server" onmouseover="this.src='../images/btnAbrir_on.gif'" onmouseout="this.src='../images/btnAbrir.gif'" />
        </ItemTemplate>
        <ItemStyle Width="50" />
            <FooterStyle CssClass="Ocultar" />
            <ItemStyle CssClass="Ocultar" />
            <FooterStyle CssClass="Ocultar" />
        </asp:TemplateField>

        <asp:TemplateField Visible="false">
            <ItemTemplate> 
                <asp:ImageButton ID="btnEliminar" CommandArgument='<%#Container.DataItem("var_IdArticulo") %>' CommandName="Eliminar" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
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
    <div id="divTitulo">VALE DE PEDIDO A ALMACEN – ASIGNACION DE ARTICULOS</div>
    <table cellpadding="2" cellspacing="2" border="0" width="500" align="center" valign="middle">
    <table>
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
  
        <td class="Titulo12">Cantidad</td>
        <td>
            <asp:TextBox ID="txtCantidad" MaxLength="200" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server" Width = "150"></asp:TextBox>
        </td>

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
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>&nbsp;</div>   
    </asp:Panel>
    

     <asp:Panel ID="pnlDocumento" CssClass="Formulario" runat="server">
    <div id="div1">VALE DE PEDIDO A ALMACEN – DOCUMENTOS ASOCIADOS</div>
    <table cellpadding="2" cellspacing="2" border="0" width="500" align="center" valign="middle">
    <table>
     <tr>
        <td class="Titulo12">Tipo</td>
        <td>
            <asp:DropDownList ID="ddlTipo" CssClass="texto12" runat="server">
            </asp:DropDownList>
        </td>
      </tr>
</table>
<table>
     <tr>
        <td class="Titulo12">Numero</td>
           <td>
            <asp:TextBox ID="txtNumero" CssClass="Texto12" runat="server" Width="200px"></asp:TextBox>
            </td> 

    </tr> 
</table>
    <tr>
    <td>
    
    
    
       <asp:GridView ID="grdDatosDocumentos"  Width="600" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>
        <asp:BoundField DataField="chr_IdTipoDocumento" HeaderText="IdTipoDocumento" />
        <asp:BoundField DataField="var_TipoDocumento" HeaderText="TipoDocumento" />
         <asp:BoundField DataField="var_IdNumeroDocumento" HeaderText="Numero" />
         
        

            
    
        <asp:TemplateField>
        <ItemTemplate>
            <asp:ImageButton ID="btnModificar" CommandArgument='<%#Container.DataItem("chr_IdTipoDocumento") %>' CommandName="Modificar" ImageUrl="../images/btnAbrir.gif" runat="server" onmouseover="this.src='../images/btnAbrir_on.gif'" onmouseout="this.src='../images/btnAbrir.gif'" />
        </ItemTemplate>
        <ItemStyle Width="50" />
        </asp:TemplateField>

        <asp:TemplateField>
            <ItemTemplate> 
                <asp:ImageButton ID="btnEliminar" CommandArgument='<%#Container.DataItem("chr_IdTipoDocumento") %>' CommandName="Eliminar" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
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
       <div id="divFooter">
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                <ProgressTemplate>
                <img src="../images/loader.gif" />
                </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:Label ID="lblMensaje2" runat="server"></asp:Label>&nbsp;</div>  

    </asp:Panel>
    </div>

</asp:Content>

