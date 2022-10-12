<%@ Page Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCESIC.aspx.vb" Inherits="Estandares_FGCESIC" title="Sistema de Gestión de Costos - Alta Visión Consultores" %>
<%@ MasterType VirtualPath="~/Masterpage/General.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">Mantenimiento De Tipo De Cambio</div>
<div id="divOpciones">
<table cellpadding="0" cellspacing="1" border="0">
    <tr>
    <td><asp:ImageButton ID="btnNuevo" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'" onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif" /></td>
    <td><asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'" onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
   </tr>
    </table>
</div>
    <table cellpadding="0" cellspacing="0" border="0" width="400">
    <tr>
        <td class="Titulo12">Fecha Inicio</td>
        <td>
            <asp:TextBox ID="txtFechaInicio" CssClass="Texto12" runat="server"></asp:TextBox>
        </td>
        <td>
        <asp:Image ID="btnFechaInicio" runat="server" ImageUrl="~/Images/im_calendar.gif" />
        </td> 
    </tr> 
    <tr>
        <td class="Titulo12">Fecha Final</td>
        <td>
            <asp:TextBox ID="txtFechaFinal" CssClass="Texto12" runat="server"></asp:TextBox>
        </td> 
        <td>
        <asp:Image ID="btnFechaFinal" runat="server" ImageUrl="~/Images/im_calendar.gif" />
        </td>       
    </tr> 

    </table>
    <asp:GridView ID="grdDatos" Width="600" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>
        <asp:BoundField DataField="var_IdTipoCambio" HeaderText="Id"  />
        <asp:BoundField DataField="dtm_Fecha" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha" />
        <asp:BoundField DataField="num_Compra" DataFormatString="{0:#,##0.0000}" HeaderText="Compra" />
        <asp:BoundField DataField="num_Venta"  DataFormatString="{0:#,##0.0000}" HeaderText="Venta" />
        
        <asp:TemplateField>
        <ItemTemplate>
            <asp:ImageButton ID="btnModificar" CommandArgument='<%#Container.DataItemIndex %>' CommandName="Modificar" ImageUrl="../images/btnAbrir.gif" runat="server" onmouseover="this.src='../images/btnAbrir_on.gif'" onmouseout="this.src='../images/btnAbrir.gif'" />
        </ItemTemplate>
        <ItemStyle Width="50" />
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="btnEliminar" CommandArgument='<%#Container.DataItem("var_IdTipoCambio") %>' CommandName="Eliminar" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
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
    <div id="divTitulo">Registro - Tipo de Cambio</div>
    <table cellpadding="2" cellspacing="2" border="0" width="300" align="center" valign="middle">
    <tr>
        <td class="Titulo12">Código</td>
        <td>
            <asp:TextBox CssClass="Texto12" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" MaxLength="8" ID="txtCodigo" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="Titulo12">Fecha</td>
        <td><nobr>
            <asp:TextBox ID="txtFecha" MaxLength="10" Width="80" CssClass="Texto12" runat="server"></asp:TextBox>
            <asp:Image ID="btnFecha" runat="server" ImageUrl="~/Images/im_calendar.gif" /></nobr>
        </td>
    </tr>    
    <tr>
        <td class="Titulo12">Compra</td>
        <td>
            <asp:TextBox ID="txtCompra" MaxLength="200"  CssClass="Texto12" runat="server"></asp:TextBox></td>
  
    </tr>  
        <tr>
        <td class="Titulo12">Venta</td>
        <td>
            <asp:TextBox ID="txtVenta" MaxLength="200"   CssClass="Texto12" runat="server"></asp:TextBox></td>
                
    </tr>
  
    <tr>
        <td colspan="2">
        <asp:ImageButton ID="btnRegistrar" CssClass="Boton" onmouseover="this.src='../images/btnRegistrar_on.gif';" onmouseout="this.src='../images/btnRegistrar.gif';" ImageUrl="../images/btnRegistrar.gif" runat="server" />
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

