<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCREGC.aspx.vb" Inherits="Reportes_FGCREGC" %>
<%@ Register TagName="ctlAvance" TagPrefix="UC" Src="~/Controles/ctlAvanceOP.ascx" %>
<%@ Register TagPrefix="UC" TagName="ctlCliente" Src="~/Controles/ctlCliente_Buscar.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">Reporte De Devoluciones</div>
<div id="divOpciones">
<table cellpadding="0" cellspacing="1" border="0">
    <tr>
    <td><asp:ImageButton ID="btnGenerar" runat="server" onmouseover="this.src='../images/btnGenerar_on.gif'" onmouseout="this.src='../images/btnGenerar.gif'" ImageUrl="../images/btnGenerar.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
    </tr>
    </table>
</div>
    <table cellpadding="1" cellspacing="1" border="0" width="500">
        <tr>
            <td class="Titulo12" width="150">Fecha Inicio:</td>
            <td><nobr>
                <asp:TextBox ID="txtFechaInicio" runat="server"></asp:TextBox>&nbsp;
                <asp:Image ID="btnFechaInicio" runat="server" ImageUrl="~/Images/im_calendar.gif" />
                </nobr>
            </td>
        </tr>
        <tr>
            <td class="Titulo12">Fecha Fin:</td>
            <td><nobr>
                <asp:TextBox ID="txtFechaFinal" runat="server"></asp:TextBox>&nbsp;
                <asp:Image ID="btnFechaFinal" runat="server" ImageUrl="~/Images/im_calendar.gif" />
                </nobr>
            </td>
        </tr>
        <tr>
            <td class="Titulo12">Motivo:</td>
            <td><asp:DropDownList ID="ddlMotivo" runat="server">
            </asp:DropDownList>
            </td>
        </tr>
        </table>
    <asp:GridView ID="grdDatos" Width="1000"  ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>
    <asp:BoundField DataField="var_CodigoOrden" HeaderText="HT" />
    <asp:BoundField DataField="var_CodCliente" HeaderText="Cliente" />
    <asp:BoundField DataField="var_DesCliente" HeaderText="Razon Social" />
    <asp:BoundField DataField="dtm_Inicio" HeaderText="Fecha" />
    <asp:BoundField DataField="var_idArticulo" HeaderText="Codigo PT" />
    <asp:BoundField DataField="var_DesArticulo" HeaderText="Producto Terminado" />
    <asp:BoundField DataField="var_DesMotivoProceso" HeaderText="Motivo Devolucion" />
    <asp:BoundField DataField="num_Cantidad" HeaderText="Cantidad" />
    </Columns>
    <HeaderStyle CssClass="GridHeader" />
    <FooterStyle CssClass="GridFooter" />
    <AlternatingRowStyle CssClass="GridAltItem" />
    <RowStyle CssClass="GridItem" />
    </asp:GridView>
</div>
</asp:Content>

