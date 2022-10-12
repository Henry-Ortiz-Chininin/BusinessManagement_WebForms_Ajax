<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGLINAF.aspx.vb" Inherits="Interfaces_FGLINAF" %>
<%@ Register src="../Controles/ctlProveedor_Buscar.ascx" tagname="ctlProveedor_Buscar" tagprefix="uc1" %>
<%@ Register TagName="CajaBanco" TagPrefix="AVC" Src="~/Controles/REGISTRO/ctlCajaBanco_Registro.ascx" %>
<%@ Register TagPrefix="AVC" TagName="Detraccion" Src="~/Controles/REGISTRO/ctlDetraccionRegistro.ascx"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">DOCUMENTOS DE COMPRA - LISTADO</div>

<div id="divOpciones">
<table cellpadding="1" cellspacing="1" border="0">
    <tr>
    <td><asp:ImageButton ID="btnNuevo" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'" onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif" /></td>
   
    <td><asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'" onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
    </tr>
    </table>
</div>
 <table cellpadding="0" cellspacing="1" border="0">
  
 <tr>
        <td class="Titulo12">Nro Documento:</td>

        <td>
            <asp:TextBox ID="txtNumeroDumento" CssClass="Texto12" runat="server" Width="200px"></asp:TextBox>
        </td> 

      
  </tr> 
          
          <tr>
            <td  class="Titulo12">Fecha Emision</td>
            <td><asp:TextBox ID="txtFechaEmisionInicio" Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
            <asp:Image ID="btnFechaEmisionInicio" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
        </tr>
        <tr>
            <td  class="Titulo12" visible ="false"> </td>
            <td><asp:TextBox ID="txtFechaEmisionFinal"  Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
            <asp:Image ID="btnFechaEmisionFinal" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
        </tr>

        <tr></tr>
        <tr></tr>
          <tr>
            <td  class="Titulo12">Fecha Vencimiento</td>
            <td><asp:TextBox ID="txtFechaVencimientoInicio" Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
            <asp:Image ID="btnFechaVencimientoInicio" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
        </tr>
        <tr>
             <td  class="Titulo12" visible ="false"></td>
            <td><asp:TextBox ID="txtFechaVencimientoFinal"  Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
            <asp:Image ID="btnFechaVencimientoFinal" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
        </tr>
   </table> 

 
<table>
   <tr>
   <td>
         <asp:GridView ID="grdDatos" Width="600" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>
        <asp:BoundField DataField="var_IdDocumentoCompra" HeaderText="Id" />
        <asp:BoundField DataField="var_NumeroDocumento" HeaderText="NumeroDocumentoCompra" />
        <asp:BoundField DataField="var_IdProveedor" HeaderText="Proveedor" />
         <asp:BoundField DataField="RazonSocial" HeaderText="Ruc" />
          <asp:BoundField DataField="dtm_Fecha" HeaderText="FechaEmision" />
           <asp:BoundField DataField="dtm_FechaVencimiento" HeaderText="FechaVencimiento" />    
           <asp:BoundField DataField="dec_Total" HeaderText="Importe" />    
           <asp:BoundField DataField="var_Estado" HeaderText="Estado" />    
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
            <asp:Button ID="btnCajaBanco" CssClass="Boton" CommandArgument='<%#Container.DataItemIndex() %>' CommandName="CAJABANCO" runat="server" Text="Caja/Banco" />
        </ItemTemplate> 
        </asp:TemplateField>        
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnDetraccion" CssClass="Boton" CommandArgument='<%#Container.DataItemIndex() %>' CommandName="DETRACCION" runat="server" Text="Detracción" />
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
   
 <div style="position:absolute; top:70px; left:450px; z-index:0;">
<table>

  <tr>
  <td>
  <uc1:ctlProveedor_Buscar ID="ctlProveedor_Buscar1" runat="server" />
  
  </td>
  
  </tr>
 </table>

</div> 

    <asp:Panel ID="pnlCajaBanco" CssClass="Formulario" runat="server">
        <AVC:CajaBanco runat="server" ID="ctlCajaBanco" />
    </asp:Panel>

    
    <asp:Panel ID="pnlDetracion" CssClass="Formulario" runat="server">
        <AVC:Detraccion runat="server" ID="ctlDetraccion" />
    </asp:Panel>

</div>

</asp:Content>

