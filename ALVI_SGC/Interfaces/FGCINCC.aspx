<%@ Page Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCINCC.aspx.vb" Inherits="Interfaces_FGCINCC" title="Sistema de Gestión de Costos - Alta Visión Consultores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">Registro del Cierre de almacenes por Periodo</div>
<div id="divOpciones">
    <asp:HiddenField ID="hdnGenerado" runat="server" />
<table cellpadding="0" cellspacing="1" border="0">
    <tr>
    <td><asp:ImageButton ID="btnGenerar" runat="server" onmouseover="this.src='../images/btnGenerar_on.gif'" onmouseout="this.src='../images/btnGenerar.gif'" ImageUrl="../images/btnGenerar.gif" /></td>    
    <td><asp:ImageButton ID="btnExportar" onmouseover="this.src='../images/btnExportar_on.gif';" onmouseout="this.src='../images/btnExportar.gif';" ImageUrl="../images/btnExportar.gif" runat="server" /></td>
    <td><asp:ImageButton ID="btnRegistrar" runat="server" onmouseover="this.src='../images/btnRegistrar_on.gif'" onmouseout="this.src='../images/btnRegistrar.gif'" ImageUrl="../images/btnRegistrar.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
    <td><img src="../images/spacer.gif" width="50px" /></td>
    <td>
    <table cellpadding="0" cellspacing="1" border="0">
        <tr>
            <td class="Titulo12">Familia:</td>
            <td>
                <asp:DropDownList ID="ddlFamilia" runat="server">
                </asp:DropDownList>
            </td>
            <td class="Titulo12">Año:</td>
            <td>
                <asp:DropDownList ID="ddlAnno" Width="80px" runat="server">
                </asp:DropDownList>
            </td>
            <td class="Titulo12">Mes:</td>
            <td><asp:DropDownList ID="ddlMes" Width="100px" runat="server">
                    <asp:ListItem Value="01">ENERO</asp:ListItem>
                    <asp:ListItem Value="02">FEBRERO</asp:ListItem>
                    <asp:ListItem Value="03">MARZO</asp:ListItem>
                    <asp:ListItem Value="04">ABRIL</asp:ListItem>
                    <asp:ListItem Value="05">MAYO</asp:ListItem>
                    <asp:ListItem Value="06">JUNIO</asp:ListItem>
                    <asp:ListItem Value="07">JULIO</asp:ListItem>
                    <asp:ListItem Value="08">AGOSTO</asp:ListItem>
                    <asp:ListItem Value="09">SETIEMBRE</asp:ListItem>
                    <asp:ListItem Value="10">OCTUBRE</asp:ListItem>
                    <asp:ListItem Value="11">NOVIEMBRE</asp:ListItem>
                    <asp:ListItem Value="12">DICIEMBRE</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
    </table>
    </td>
   </tr>
    </table>
</div>
    <asp:Table ID="tblResumen" CellPadding="1" CellSpacing="2" Border="0" runat="server">
    </asp:Table>
    
</div>
</asp:Content>

