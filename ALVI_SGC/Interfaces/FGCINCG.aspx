<%@ Page Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCINCG.aspx.vb" Inherits="Interfaces_FGCINCG" title="Página sin título" %>
<%@ MasterType VirtualPath="~/Masterpage/General.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">Busqueda de Salidas del Almacen</div>
<div id="divOpciones">
<table cellpadding="0" cellspacing="1" border="0">
    <tr>
    <td><asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'" onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
   </tr>
    </table>
</div>    
    <table cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td  class="Titulo12">Fecha Inicio</td>
            <td><asp:TextBox ID="txtFechaInicio" Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
            <asp:Image ID="btnFechaInicio" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
        </tr>
        <tr>
            <td  class="Titulo12">Fecha Final</td>
            <td><asp:TextBox ID="txtFechaFinal"  Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
            <asp:Image ID="btnFechaFinal" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
        </tr>
        <tr>
            <td class="Titulo12">Tipo Movimiento</td>
            <td>
                <asp:DropDownList ID="ddlTipoMovimiento" runat="server">
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
            <td><asp:TextBox ID="txtNumeroDocumento" MaxLength="20" onChange="validadigito(this,'TEL');" onKeypress="return Valida(event, 'TEL');" CssClass="Texto12" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="Titulo12">Orden de producción</td>
            <td><asp:TextBox ID="txtOPReferencia" MaxLength="20" onChange="validadigito(this,'TEL');" onKeypress="return Valida(event, 'TEL');" CssClass="Texto12" runat="server"></asp:TextBox></td>
        </tr>
    </table>

    <asp:GridView ID="grdDatos" Width="800" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>
    <asp:BoundField DataField="chr_IdKardex" HeaderText="Código" />
    <asp:BoundField DataField="var_IdTipoMovimiento" HeaderText="" />
    <asp:BoundField DataField="var_TipoMovimiento" HeaderText="Tipo Movimiento" />
    <asp:BoundField DataField="chr_IdTipoDocumento" HeaderText="" />
    <asp:BoundField DataField="var_TipoDocumento" HeaderText="Tipo Documento" />
    <asp:BoundField DataField="var_NumeroDocumento" HeaderText="Nro. Documento" />
    <asp:BoundField DataField="dtm_FechaMovimiento" HeaderText="Fecha" />
    <asp:BoundField DataField="var_IdOrdenProduccion" HeaderText="Orden de Producción" />
    <asp:TemplateField>
    <ItemTemplate>
        <asp:ImageButton ID="btnModificar" CommandArgument='<%#Container.DataItem("chr_IdKardex") %>' CommandName="Modificar" ImageUrl="../images/btnAbrir.gif" runat="server" onmouseover="this.src='../images/btnAbrir_on.gif'" onmouseout="this.src='../images/btnAbrir.gif'" />
    </ItemTemplate>
    <ItemStyle Width="50" />
    </asp:TemplateField>
    </Columns>
    <HeaderStyle CssClass="GridHeader" />
    <FooterStyle CssClass="GridFooter" />
    <AlternatingRowStyle CssClass="GridAltItem" />
    <RowStyle CssClass="GridItem" />
    </asp:GridView>
</div>
</asp:Content>

