<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGLINAA.aspx.vb" Inherits="Interfaces_FGLINAA" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../Controles/ctlSolicitante_Buscar.ascx" tagname="ctlSolicitante_Buscar" tagprefix="uc1" %>
<%@ Register src="../Controles/ctlProyecto_Buscar.ascx" tagname="ctlProyecto_Buscar" tagprefix="uc1" %>
<%@ Register src="../Controles/ctlCentroCosto_Buscar.ascx" tagname="ctlCentroCosto_Buscar" tagprefix="uc1" %>
<%@ Register src="~/BLOQUES/ctlNotaPedido_Asignar.ascx" tagname="NotaPedido_Asignar" tagprefix="AVC" %>

<%@ Register src="../Controles/ctlElementoReferencial_Buscar.ascx" tagname="ctlElementoReferencial_Buscar" tagprefix="uc2" %>
<%@ Register src="../Controles/ctlUnidadMedida_Buscar.ascx" tagname="ctlUnidadMedida_Buscar" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script language="javascript">
    function Buscar(InputId) {
        var IdRequisicion = document.getElementById(InputId);
        IdRequisicion.value = prompt("Ingrese Codigo ", IdRequisicion.value);
        return true;
    }
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divOpciones">
    <table cellpadding="0" cellspacing="1" border="0">
        <tr> 
            <td><asp:ImageButton ID="btnNuevo" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'" onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif" /></td>
            <td><asp:ImageButton ID="btnRegistrar" runat="server" onmouseover="this.src='../images/btnRegistrar_on.gif'" onmouseout="this.src='../images/btnRegistrar.gif'" ImageUrl="../images/btnRegistrar.gif" /></td>
            <td> <asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'" onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" /></td>
            <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
        </tr>
    </table>
</div>
 
<asp:Panel ID="pnlFormulario" CssClass="Formulario" runat="server">
<div id="divTitulo">REGISTRO DE REQUISICIONES - Registro</div>
 <table border="0" cellpadding="1" cellspacing="1" width="500">
        <tr>
            <td class="Titulo12">Codigo</td>
            <td><asp:TextBox ID="txtCodigo" runat="server" CssClass="Texto12" Width="200px"></asp:TextBox></td>
            <td class="Titulo12">Tipo</td>
            <td><asp:RadioButtonList ID="rbtTipo" runat="server">
                    <asp:ListItem Text="Compra" Value="C"></asp:ListItem>
                    <asp:ListItem Text="Servicio" Value="S"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
    <br />
     <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
         Width="900px" Height="1207px" CssClass="ajax__tab_xp"  >   
    <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Requisicion"><ContentTemplate>
         <asp:HiddenField ID="hdnIdRequisicion" runat="server" />
    <table border="0" cellpadding="1" cellspacing="1" width="600">
        <tr>
            <td>
                <uc1:ctlSolicitante_Buscar ID="ctlSolicitante_Buscar1" runat="server" />
            </td>
            <td rowspan="3" valign="top">
                <table border="0" cellpadding="1" cellspacing="1" width="500">
                    <tr>
                        <td class="Titulo12">Fecha PLazo</td>
                        <td><asp:TextBox ID="txtFechaPlazo" runat="server" Width="80px"></asp:TextBox>
                                <asp:Image ID="btnFechaPlazo" runat="server" 
                                ImageUrl="~/Images/im_calendar.gif" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Titulo12">Referencia</td>
                        <td><asp:TextBox ID="txtReferencia" runat="server" CssClass="Texto12" 
                                MaxLength="200" onChange="validadigito(this,'ALN');" 
                                onKeypress="return Valida(event, 'ALN');" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Titulo12" colspan="2">Motivo/Justificacion</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="txtMotivo" runat="server" CssClass="Texto12" Height="65px" 
                                MaxLength="200" onChange="validadigito(this,'ALN');" 
                                onKeypress="return Valida(event, 'ALN');" TextMode="MultiLine" Width="300px"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="Titulo12">Proveedor (es) sugeridos</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="txtProveedor" runat="server" CssClass="Texto12" Height="65px" 
                            MaxLength="200" onChange="validadigito(this,'ALN');" 
                            onKeypress="return Valida(event, 'ALN');" TextMode="MultiLine" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ctlProyecto_Buscar ID="ctlProyecto_Buscar1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ctlCentroCosto_Buscar ID="ctlCentroCosto_Buscar1" runat="server" />
            </td>
        </tr>
    </table>
    
</ContentTemplate>
</asp:TabPanel>
   <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Detalle"><ContentTemplate>
    <%--   <table border="0" cellpadding="1" cellspacing="1" width="600">
           <tr>
                <td class="Titulo12">Correlativo</td>
                <td>
                   <asp:TextBox ID="txtCorrlativo" runat="server" CssClass="Texto12" 
                       Enabled="false" Width="200px"></asp:TextBox>
                </td>
           </tr>
           <tr>
                <td colspan="2">
                    <uc2:ctlElementoReferencial_Buscar ID="ctlElementoReferencial_Buscar1" runat="server" />
                </td>
                <td rowspan="2">
                    <table border="0" cellpadding="1" cellspacing="1" width="600">
                        <tr>
                            <td class="Titulo12" valign="top">Descripcion</td>
                            <td>
                                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="Texto12" Height="65" 
                                        MaxLength="200" onChange="validadigito(this,'ALN');" 
                                        onKeypress="return Valida(event, 'ALN');" TextMode="MultiLine" Width="300px"></asp:TextBox>
                            </td>
                        <tr>                            
                            <td class="Titulo12">Cantidad</td>
                            <td><asp:TextBox ID="txtCantidad" runat="server" CssClass="Texto12" MaxLength="20" 
                               onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" 
                               Width="150"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
               <td colspan="2">
                   <uc3:ctlUnidadMedida_Buscar ID="ctlUnidadMedida_Buscar1" runat="server" />
               </td>
            </tr>
       </table>
       <asp:ImageButton ID="btnRegistarGrilla" runat="server" CssClass="Boton" 
                ImageUrl="../images/btnRegistrar.gif" 
                onmouseout="this.src='../images/btnRegistrar.gif';" 
                onmouseover="this.src='../images/btnRegistrar_on.gif';" />--%>
        <AVC:NotaPedido_Asignar runat="server" ID="ctlNotaPedido_Asignar" />
        <asp:HiddenField runat="server" ID="hdnCorrelativo"></asp:HiddenField>
        <p class="Titulo">La lista mostrada abajo sera incluida en el presente requerimiento.</p>
        <asp:GridView ID="grdDatos" runat="server" AllowPaging="true" 
                AutoGenerateColumns="false" PageSize="20" ShowFooter="true" Width="800"><Columns>
                <asp:BoundField DataField="var_IdValeAlmacen" HeaderText="NP" />
                <asp:BoundField DataField="var_IdDetalle" HeaderText="#Sec" />
                <asp:BoundField DataField="var_IdArticuloReferencia" HeaderText="articulo referencia"  HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="var_Articulo" HeaderText="Articulo" />
                <asp:BoundField DataField="var_Descripcion" HeaderText="Observacion" />
                <asp:BoundField DataField="num_Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="var_IdUnidadMedida" HeaderText="Idunidad"  HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="var_UnidadMedida" HeaderText="Medida" />
                <asp:TemplateField><ItemTemplate>
                    <asp:ImageButton ID="btnModificar" runat="server" 
                            CommandArgument='<%#Container.DataItem("var_IdDetalle") %>' 
                            CommandName="Modificar" ImageUrl="../images/btnAbrir.gif" 
                            onmouseout="this.src='../images/btnAbrir.gif'" 
                            onmouseover="this.src='../images/btnAbrir_on.gif'" />
                    </ItemTemplate>
                    <ItemStyle Width="50" /></asp:TemplateField>
                <asp:TemplateField><ItemTemplate>
                <asp:ImageButton ID="btnEliminar" runat="server" 
                            CommandArgument='<%#Container.DataItem("var_IdDetalle") %>' 
                            CommandName="Eliminar" ImageUrl="../images/btnEliminar.gif" 
                            onmouseout="this.src='../images/btnEliminar.gif'" 
                            onmouseover="this.src='../images/btnEliminar_on.gif'" />
                    </ItemTemplate>
                    <ItemStyle Width="50" /></asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="GridHeader" />
            <FooterStyle CssClass="GridFooter" />
            <AlternatingRowStyle CssClass="GridAltItem" />
            <RowStyle CssClass="GridItem" />
        </asp:GridView>
                   
    
</ContentTemplate>
</asp:TabPanel>
        
</asp:TabContainer> 
<div id="divFooter">
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        
        </div>


</asp:Panel> 

   

    

   

</div> 

</asp:Content>

