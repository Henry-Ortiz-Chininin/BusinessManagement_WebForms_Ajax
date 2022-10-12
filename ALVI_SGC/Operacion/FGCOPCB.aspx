﻿<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCOPCB.aspx.vb" Inherits="Operacion_FGCOPCB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">CIERRE MENSUAL</div>
<div id="divOpciones">
<table cellpadding="0" cellspacing="1" border="0">
    <tr>
        <td><asp:Button ID="btnGenerar" CssClass="Boton" runat="server" Text="Generar" /></td>
        <td><asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" /></td>
   </tr>
    </table>
</div> 
<table cellpadding="1" cellspacing="1" border = "0">
    <tr>
        <td class="Titulo12">Año:</td>
        <td>
            <asp:DropDownList ID="ddlAnno" runat="server">
                <asp:ListItem Value="0000002" Selected="True">2013</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">Mes:</td>
        <td>
            <asp:DropDownList ID="ddlMes" runat="server">
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
    <tr>
        <td class="Titulo12" colspan="2">
            <asp:CheckBox ID="chkCompras" Text="Cerrar Compras" runat="server" /></td>
    </tr>
    <tr>
        <td class="Titulo12" colspan="2">
            <asp:CheckBox ID="chkVentas" Text="Cerrar Ventas" runat="server" /></td>
    </tr>
</table>
</div>
</asp:Content>

