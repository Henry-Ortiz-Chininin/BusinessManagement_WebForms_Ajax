<%@ Page Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCREBB.aspx.vb" Inherits="Reportes_FGCREBB" title="Página sin título" %>

<%@ Register TagName="ctlCentroCosto" TagPrefix="CC" Src="~/Controles/ctlCentroCosto_Buscar.ascx" %>
<%@ Register TagName="ctlCuentaGasto" TagPrefix="CG" Src="~/Controles/ctlCuentaGasto_Buscar.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">Reporte de Salidas del Almacen</div>
<div id="divOpciones">
<table cellpadding="0" cellspacing="1" border="0">
    <tr>
    <td><asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'" onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" /></td>
    <td><asp:ImageButton ID="btnExportar" runat="server" onmouseover="this.src='../images/btnExportar_on.gif'" onmouseout="this.src='../images/btnExportar.gif'" ImageUrl="../images/btnExportar.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
    </tr>
    </table>
</div>    
    <table cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td>Fecha Inicio</td>
            <td><asp:TextBox ID="txtFechaInicio" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox></td>
            <td><asp:Image ID="btnFechaInicio" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
        </tr>
        <tr>
            <td>Fecha Final</td>
            <td><asp:TextBox ID="txtFechaFinal" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox></td>
            <td><asp:Image ID="btnFechaFinal" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
        </tr>
        <tr>
            <td class="Titulo12">Tipo Movimiento</td>
            <td>
                <asp:DropDownList ID="ddlTipoMovimiento" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        </tr>
            <td class="Titulo12">Familia</td>
            <td>
                <asp:DropDownList ID="ddlFamilia" AutoPostBack="true" CssClass="Texto12" runat="server">
                </asp:DropDownList>
            </td>        
        </tr>
        <tr>
            <td class="Titulo12">Sub-Familia</td>
            <td><asp:UpdatePanel ID="upnSubFamilia" runat="server">
                        <ContentTemplate>
                <asp:DropDownList ID="ddlSubFamilia" CssClass="Texto12" runat="server">
                </asp:DropDownList>
                </ContentTemplate>
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlFamilia" EventName="SelectedIndexChanged" />
                </Triggers> 
                </asp:UpdatePanel>
            </td>        
        </tr>
        <tr>
            <td class="Titulo12" colspan="2"><hr /><br />Centro de Costo<br /><hr /></td>
        </tr>
        <tr>
            <td colspan="2">
            <CC:ctlCentroCosto ID="ctlCentroCosto1" runat="server" />            
            </td>
        </tr>
        <tr>
            <td class="Titulo12" colspan="2"><hr /><br />Cuenta de Gasto<br /><hr /></td>
        </tr>
        <tr>
            <td colspan="2">
            <CG:ctlCuentaGasto ID="ctlCuentaGasto1" runat="server" />
            </td>
        </tr>

    </table>

    <asp:GridView ID="grdDatos" Width="1000" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>
    <asp:BoundField DataField="chr_IdKardex" HeaderText="Código" />
    <asp:BoundField DataField="var_IdCentroCosto" HeaderText="Id CC" />
    <asp:BoundField DataField="var_CentroCosto" HeaderText="Descripción CC" />
    <asp:BoundField DataField="var_IdCuentaGasto" HeaderText="Id CG" />
    <asp:BoundField DataField="var_CuentaGasto" HeaderText="Descripción CG" />
    <asp:BoundField DataField="var_IdOrdenProduccion" HeaderText="Orden de Producción" />
    <asp:BoundField DataField="dtm_FechaMovimiento" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
    <asp:BoundField DataField="var_TipoDocumento" HeaderText="Tipo Documento" />
    <asp:BoundField DataField="var_NumeroDocumento" HeaderText="Nro. Documento" />
    <asp:BoundField DataField="var_TipoMovimiento" HeaderText="Tipo Movimiento" />
    <asp:BoundField DataField="var_IdArticulo" HeaderText="Articulo" />
    <asp:BoundField DataField="var_Articulo" HeaderText="Descripción" />
    <asp:BoundField DataField="var_UnidadMedida" HeaderText="Unidad" />
    <asp:BoundField DataField="num_Cantidad" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" />
    <asp:BoundField DataField="num_CostoUnitario" HeaderText="Costo Unitario" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.0000}" />
    <asp:BoundField DataField="num_Importe" HeaderText="Importe" ItemStyle-HorizontalAlign="Right"  DataFormatString="{0:#,##0.0000}" />
    </Columns>
    <HeaderStyle CssClass="GridHeader" />
    <FooterStyle CssClass="GridFooter" />
    <AlternatingRowStyle CssClass="GridAltItem" />
    <RowStyle CssClass="GridItem" />
    </asp:GridView>
</div>
</asp:Content>

