<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCINVD.aspx.vb" Inherits="Interfaces_FGCINVD" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagName="CajaBanco" TagPrefix="AVC" Src="~/Controles/REGISTRO/ctlCajaBanco_Registro.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">Movimientos de Caja</div>  
<div id="divOpciones">
<table cellpadding="0" cellspacing="1" border="0"> 
    <tr>
    <td><asp:ImageButton ID="btnNuevo" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'" onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif" /></td>
    <td><asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'" onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
    </tr>
    </table> 
</div>
<table cellpadding="1" cellspacing="1" border = "0">
    <tr>
        <td class="Titulo12">Fecha Inicio:</td>
        <td><asp:TextBox ID="txtFechaInicio" Width="100" CssClass="Texto12" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="calFecha1" TargetControlID="txtFechaInicio"
                    enabled="true" DaysModeTitleFormat="MMMM-yyyy" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy" runat="server">
                    </asp:CalendarExtender></td>
        <td class="Titulo12">Fecha Final:</td>
        <td><asp:TextBox ID="txtFechaFinal" Width="100" CssClass="Texto12" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="calFecha2" TargetControlID="txtFechaFinal"
                    enabled="true" DaysModeTitleFormat="MMMM-yyyy" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy" runat="server">
                    </asp:CalendarExtender></td>
    </tr>
</table>
<asp:GridView ID="grdDatos" Width="1000" ShowFooter="true" AutoGenerateColumns="false" runat="server" 
        AllowPaging="true" PageSize="20" >
    <Columns>
        <asp:BoundField DataField="var_IdMovimiento" HeaderText="IdMovimiento" />
        <asp:BoundField DataField="var_IdEntidadFinanciera" HeaderText="IdEntidadFinanciera" HeaderStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" />
        <asp:BoundField DataField="var_IdTipoComprobante" HeaderText="IdTipoComprobante" HeaderStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" />
        <asp:BoundField DataField="var_IdMoneda" HeaderText="IdMoneda" HeaderStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" />
        <asp:BoundField DataField="var_IdCliente" HeaderText="IdCliente" HeaderStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" />
        <asp:BoundField DataField="var_IdProveedor" HeaderText="IdProveedor" HeaderStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" />
        <asp:BoundField DataField="var_IdTipoDocumento" HeaderText="IdTipoDocumento" HeaderStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" />
        <asp:BoundField DataField="var_IdOperacion" HeaderText="IdOperacion" HeaderStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" />
        <asp:BoundField DataField="var_IdSubOperacion" HeaderText="IdSubOperacion" HeaderStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" />
        <asp:BoundField DataField="var_EntidadFinanciera" HeaderText="Caja/Banco" />
        <asp:BoundField DataField="var_TipoComprobante" HeaderText="Tipo" />
        <asp:BoundField DataField="var_Comprobante" HeaderText="Comprobante" />
        <asp:BoundField DataField="dec_Importe" HeaderText="Importe" />
        <asp:BoundField DataField="dtm_Fecha" HeaderText="Fecha" />
        <asp:BoundField DataField="var_Moneda" HeaderText="Moneda" />
        <asp:BoundField DataField="var_Cliente" HeaderText="Cliente" />
        <asp:BoundField DataField="var_Proveedor" HeaderText="Proveedor" />
        <asp:BoundField DataField="var_TipoDocumento" HeaderText="Tipo Documento" />
        <asp:BoundField DataField="var_NumeroDocumento" HeaderText="Nº Documento" />
        <asp:BoundField DataField="var_Operacion" HeaderText="Operacion" />
        <asp:BoundField DataField="var_SubOperacion" HeaderText="Sub-Operacion" />
        <asp:BoundField DataField="var_Observacion" HeaderText="Observacion" />
        <asp:TemplateField>
        <ItemTemplate>
            <asp:Button ID="btnAbrir" CssClass="Boton" CommandArgument='<%#Container.DataItemIndex %>' CommandName="ABRIR" runat="server" Text="Abrir" />
        </ItemTemplate> 
        </asp:TemplateField>
        
    </Columns>
    <HeaderStyle CssClass="GridHeader" />
    <AlternatingRowStyle CssClass="GridAltItem" />
    <RowStyle CssClass="GridItem" />
</asp:GridView>


    <asp:Panel ID="pnlCajaBanco" CssClass="Formulario" runat="server">
        <AVC:CajaBanco runat="server" ID="ctlCajaBanco" />

    </asp:Panel>
</div>
</asp:Content>

