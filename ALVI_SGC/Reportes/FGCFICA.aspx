<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCFICA.aspx.vb" Inherits="Reportes_FGCFICA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">LIBRO DIARIO - FORMATO 5.1</div>
<div id="divOpciones">
<table cellpadding="0" cellspacing="1" border="0">
    <tr>
        <td><asp:Button ID="btnGenerar" CssClass="Boton" runat="server" Text="Generar" /></td>
        <td><asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" /></td>
   </tr>
    </table>
</div> 

<table cellpadding="0" cellspacing="1" border="0">
    <tr><td class="Titulo12">Año:</td>
        <td>
            <asp:DropDownList ID="ddlAnno" runat="server">
                <asp:ListItem Value="2013">2013</asp:ListItem>
                <asp:ListItem Value="2014">2014</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>Mes:</td>
        <td><asp:DropDownList ID="ddlMes" runat="server">
            <asp:ListItem Value="01">Enero</asp:ListItem>
            <asp:ListItem Value="02">Febrero</asp:ListItem>
            <asp:ListItem Value="03">Marzo</asp:ListItem>
            <asp:ListItem Value="04">Abril</asp:ListItem>
            <asp:ListItem Value="05">Mayo</asp:ListItem>
            <asp:ListItem Value="06">Junio</asp:ListItem>
            <asp:ListItem Value="07">Julio</asp:ListItem>
            <asp:ListItem Value="08">Agosto</asp:ListItem>
            <asp:ListItem Value="09">Setiembre</asp:ListItem>
            <asp:ListItem Value="10">Octubre</asp:ListItem>
            <asp:ListItem Value="11">Noviembre</asp:ListItem>
            <asp:ListItem Value="12">Diciembre</asp:ListItem>
        </asp:DropDownList></td>
    </tr>
</table>
</div>
</asp:Content>

