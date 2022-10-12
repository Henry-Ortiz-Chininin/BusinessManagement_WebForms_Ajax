<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGLINBA.aspx.vb" Inherits="Interfaces_FGLINBA" %>
<%@ Register src="../Controles/ctlProveedor_Buscar.ascx" tagname="ctlProveedor_Buscar" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script language="javascript">
    function Buscar(InputId) {
        var var_IdCotizacion = document.getElementById(InputId);
        var_IdCotizacion.value = prompt("Ingrese Codigo ", var_IdCotizacion.value);
        return true;
    } 
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
<div id="divCuerpo">
<div id="divHeader">COTIZACIONES - LISTADO</div>
<div id="divOpciones">
<table cellpadding="1" cellspacing="1" border="0">
    <tr>
    <td><asp:ImageButton ID="btnNuevo" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'" onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif" /></td>
    <td><asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'" onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
    </tr>
    </table>
</div> 
 <asp:HiddenField ID="hdnIdCotizacion" runat="server" />
 <table cellpadding="0" cellspacing="1" border="0">
  <tr>
        <td class="Titulo12">Nro Requisicion:</td>
        <td>
            <asp:TextBox ID="txtRequisicion" CssClass="Texto12" runat="server" Width="200px"></asp:TextBox>
        </td>
        <td rowspan="3">
        <uc4:ctlProveedor_Buscar ID="ctlProveedor_Buscar2" runat="server" />
        </td>
  </tr> 
     <tr>
            <td class="Titulo12">
                Fecha Emision</td>
            <td>
                <asp:TextBox ID="txtFechaEmisionInicio" runat="server" Width="80px"></asp:TextBox>
                <asp:Image ID="btnFechaEmisionInicio" runat="server" 
                    ImageUrl="~/Images/im_calendar.gif" />
            </td>
        </tr>
        <tr>
            <td class="Titulo12">
                </td>
            <td>
                <asp:TextBox ID="txtFechaEmisionFinal" runat="server" Width="80px"></asp:TextBox>
                <asp:Image ID="btnFechaEmisionFinal" runat="server" 
                    ImageUrl="~/Images/im_calendar.gif" />
            </td>
        </tr>
</table>

<asp:GridView ID="grdDatos" Width="800" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>
        <asp:BoundField DataField="var_IdCotizacion" HeaderText="Cotizacion" />
        <asp:BoundField DataField="dtm_FechaEmision" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Emision" />
        <asp:BoundField DataField="var_IdProveedor" HeaderText="RUC" />
        <asp:BoundField DataField="var_RazonSocial" HeaderText="Razon Social" />
        <asp:BoundField DataField="var_Observacion" HeaderText="Observacion" />
        <asp:BoundField DataField="chr_Estado" HeaderText="Estado" />
        <asp:BoundField DataField="chr_AprobadoCaja" HeaderText="Aprobado Caja" />
        <asp:BoundField DataField="var_UsuarioCaja" HeaderText="Caja" />
        <asp:BoundField DataField="dtm_FechaCaja" DataFormatString="{0:dd/MM/yyyy HH:mi}" HeaderText="Actualización" />
        <asp:TemplateField>
        <ItemTemplate>
            <asp:HyperLink ID="lnkArchivo" Target="_blank" runat="server"></asp:HyperLink>
        </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField>
        <ItemTemplate>
            <asp:ImageButton ID="btnModificar" CommandArgument='<%#Container.DataItemIndex() %>' CommandName="ABRIR" ImageUrl="../images/btnAbrir.gif" runat="server" onmouseover="this.src='../images/btnAbrir_on.gif'" onmouseout="this.src='../images/btnAbrir.gif'" />
        </ItemTemplate>
        <ItemStyle Width="50" />
        </asp:TemplateField>

        <asp:TemplateField>
            <ItemTemplate> 
                <asp:ImageButton ID="btnEliminar" CommandArgument='<%#Container.DataItemIndex() %>' CommandName="Eliminar" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
            </ItemTemplate>
            <ItemStyle Width="50" />
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate> 
                <asp:ImageButton ID="btnImprimir" CommandArgument='<%#Container.DataItemIndex() %>' CommandName="Imprimir" ImageUrl="../images/btnImprimir.gif" runat="server" onmouseover="this.src='../images/btnImprimir_on.gif'" onmouseout="this.src='../images/btnImprimir.gif'" />
            </ItemTemplate>
            <ItemStyle Width="50" />
        </asp:TemplateField>
    </Columns>
    <HeaderStyle CssClass="GridHeader" />
    <FooterStyle CssClass="GridFooter" />
    <AlternatingRowStyle CssClass="GridAltItem" />
    <RowStyle CssClass="GridItem" />
    </asp:GridView> 



    <asp:Panel ID="pnlDocumento" CssClass="Formulario" runat="server">
     <div id="divTitulo">COTIZACION - REGISTRO</div>
    <table cellpadding="2" cellspacing="2" border="0" width="900" align="center" valign="middle">
    <tr>
        <td class="Titulo12">Codigo OC:</td>

        <td><asp:HiddenField ID="hdnIdCorrelativo" runat="server" />
            <asp:TextBox ID="txtRequisicion1" CssClass="Texto12" runat="server" Width="200px"  AutoPostBack="true"></asp:TextBox>
        </td>
        <td rowspan="4" >
        <uc4:ctlProveedor_Buscar ID="ctlProveedor_Buscar1" runat="server" />
        </td>
  </tr> 
   <tr>
            <td class="Titulo12">
                Fecha Emision</td>
            <td>
                <asp:TextBox ID="txtFechaEmisionInicio1" runat="server" Width="80px"></asp:TextBox>
                <asp:Image ID="Image1" runat="server" 
                    ImageUrl="~/Images/im_calendar.gif" />
            </td>
        </tr>
         <tr>
            <td class="Titulo12">Observacion</td>
           <td>
            <asp:TextBox ID="txtObservacion" runat="server" TextMode="MultiLine" Width="200"></asp:TextBox>
            </td> 
     </tr>
     <tr>
         <td class="Titulo12">Archivo adjunto</td>
         <td>
            <asp:TextBox ID="txtArchivo" CssClass="Texto12" runat="server"  Width="200"></asp:TextBox>
        </td>
     </tr>
     <tr>
         <td class="Titulo12"></td>
         <td>
            <asp:FileUpload ID="FileUpload1" runat="server"/>
         </td>
     </tr>
    </table>
 
    <asp:GridView ID="grdDatosCOTIZACIONES"  Width="600" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>
     <asp:BoundField DataField="var_IdDetalle" HeaderText="Id" />
            <asp:BoundField DataField="var_IdArticuloReferencia"  HeaderText="IdArticulo">
                <FooterStyle CssClass="Ocultar" />
                <HeaderStyle CssClass="Ocultar" />
                <ItemStyle CssClass="Ocultar" />
            </asp:BoundField>

            <asp:BoundField DataField="Articulo" HeaderText="Articulo" />

            <asp:BoundField DataField="var_IdUnidadMedida"  HeaderText="IdUnidadMedida">
                <FooterStyle CssClass="Ocultar" />
                <HeaderStyle CssClass="Ocultar" />
                <ItemStyle CssClass="Ocultar" />
            </asp:BoundField>

            <asp:BoundField DataField="UNIDADMEDIDA" HeaderText="UNIDADMEDIDA" />
            <asp:BoundField DataField="int_Cantidad" HeaderText="Cantidad" />

               <asp:TemplateField HeaderText ="Precio Ref.">
            <ItemTemplate>
                <asp:TextBox ID ="txtPreciRef" runat="server" Width="100px"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>

             <asp:TemplateField HeaderText ="Observación">
            <ItemTemplate>
                <asp:TextBox ID ="TxtObservación"  runat="server" ></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <HeaderStyle CssClass="GridHeader" />
    <FooterStyle CssClass="GridFooter" />
    <AlternatingRowStyle CssClass="GridAltItem" />
    <RowStyle CssClass="GridItem" />
    </asp:GridView>

  
                <asp:ImageButton ID="btnRegistraCierreDocumento" runat="server" CssClass="Boton" 
                        ImageUrl="../images/btnRegistroCierre.gif" 
                        onmouseout="this.src='../images/btnRegistroCierre.gif';" 
                        onmouseover="this.src='../images/btnRegistroCierre_on.gif';" />
                    <asp:ImageButton ID="btnRegistraCotizacion" runat="server" CssClass="Boton" 
                        ImageUrl="../images/btnRegistrar.gif" 
                        onmouseout="this.src='../images/btnRegistrar.gif';" 
                        onmouseover="this.src='../images/btnRegistrar_on.gif';" />
                         <asp:ImageButton ID="btnActualizar" runat="server" CssClass="Boton" 
                        ImageUrl="../images/btnRegistrar.gif" 
                        onmouseout="this.src='../images/btnRegistrar.gif';" 
                        onmouseover="this.src='../images/btnRegistrar_on.gif';" />
                <asp:ImageButton ID="btnCerrarDocumento" runat="server" CssClass="Boton" 
                        ImageUrl="../images/btnCancelar.gif" 
                        onmouseout="this.src='../images/btnCancelar.gif';" 
                        onmouseover="this.src='../images/btnCancelar_on.gif';" />

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

