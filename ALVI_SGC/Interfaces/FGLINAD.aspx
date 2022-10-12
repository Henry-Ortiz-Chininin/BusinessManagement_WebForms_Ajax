<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGLINAD.aspx.vb" Inherits="Interfaces_FGLINAD" %>
<%@ Register src="../Controles/ctlElementoReferencial_Buscar.ascx" tagname="ctlElementoReferencial_Buscar" tagprefix="uc2" %>
<%@ Register src="../Controles/ctlCentroCosto_Buscar.ascx" tagname="ctlCentroCosto_Buscar" tagprefix="uc1" %>

<%@ Register src="../Controles/ctlSolicitante_Buscar.ascx" tagname="ctlSolicitante_Buscar" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
<div id="divCuerpo">
    <div id="divHeader">VALES DE PEDIDO A ALMACEN - LISTADO</div>

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
        <td class="Titulo12">Codigo OC:</td>
        <td>
            <asp:TextBox ID="txtCodigo" CssClass="Texto12" runat="server" Width="200px"></asp:TextBox>
        </td>
        <td rowspan="6">
            <uc1:ctlSolicitante_Buscar ID="ctlSolicitante_Buscar1" runat="server" />
            <br />
            <uc1:ctlCentroCosto_Buscar ID="ctlCentroCosto_Buscar1" runat="server" />
        </td>
    </tr> 
    <tr>
        <td class="Titulo12">Fecha Emision</td>
        <td>
            <asp:TextBox ID="txtFechaEmisionInicio" runat="server" Width="80px"></asp:TextBox>
            <asp:Image ID="btnFechaEmision" runat="server" ImageUrl="~/Images/im_calendar.gif" />
            <br />
            <asp:TextBox ID="txtFechaEmisionFinal" runat="server" Width="80px"></asp:TextBox>
            <asp:Image ID="btnFechaEmisionFinal" runat="server" ImageUrl="~/Images/im_calendar.gif" />
        </td>
    </tr>
    <tr>
        <td class="Titulo12">Operacion</td>
        <td>
            <asp:DropDownList ID="ddlOperacion" CssClass="Texto12" runat="server">
            </asp:DropDownList>
        </td>   
    </tr> 
    <tr>
         <td class="Titulo12">Tipo documento</td>
        <td>
            <asp:DropDownList ID="ddlTipo" CssClass="Texto12" runat="server">
            </asp:DropDownList>
        </td>  
    </tr> 
    <tr>
        <td class="Titulo12">Numero:</td>
        <td>
            <asp:TextBox ID="txtNumero" CssClass="Texto12" runat="server" Width="200px"></asp:TextBox>
        </td> 
    </tr> 
    <tr>
        <td colspan="2">
            <uc2:ctlElementoReferencial_Buscar ID="ctlElementoReferencial_Buscar1" runat="server" />
       </td>
     </tr> 

</table>

    <asp:GridView ID="grdDatos" Width="900" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>
        <asp:BoundField DataField="var_IdValeAlmacen" HeaderText="IdValeAlmacen" />
        <asp:BoundField DataField="var_IdSolicitante" HeaderText="articulo referencia" />
        <asp:BoundField DataField="var_Solicitante" HeaderText="Solicitante" />
        <asp:BoundField DataField="cargo" HeaderText="descripcion" />
        <asp:BoundField DataField="Area" HeaderText="Area/Proc.Gestion" />
        <asp:BoundField DataField="dtm_Fecha" HeaderText="Emision" />
        <asp:BoundField DataField="CentroCosto" HeaderText="CentroCosto" />

        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="btnModificar" CommandArgument='<%#Container.DataItemIndex() %>' CommandName="ABRIR" ImageUrl="../images/btnAbrir.gif" runat="server" onmouseover="this.src='../images/btnAbrir_on.gif'" onmouseout="this.src='../images/btnAbrir.gif'" />
            </ItemTemplate>
             
        </asp:TemplateField>

        <asp:TemplateField>
            <ItemTemplate>
               <asp:ImageButton ID="btnGenerar" CommandName="GENERAR" CommandArgument='<%#Container.DataItemIndex()%>' runat="server" onmouseover="this.src='../images/btnGenerar_on.gif'" onmouseout="this.src='../images/btnGenerar.gif'" ImageUrl="../images/btnGenerar.gif" />
             </ItemTemplate>
            
        </asp:TemplateField>

        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="btnEliminar"  CommandArgument='<%#Container.DataItemIndex() %>'  CommandName="ELIMINAR" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
            </ItemTemplate>
      
        </asp:TemplateField>

    </Columns>
    <HeaderStyle CssClass="GridHeader" />
    <FooterStyle CssClass="GridFooter" />
    <AlternatingRowStyle CssClass="GridAltItem" />
    <RowStyle CssClass="GridItem" />
    </asp:GridView>

   
</div>

</asp:Content>

