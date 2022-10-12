<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCFICE.aspx.vb" Inherits="Reportes_FGCFICE" %>
<%@ Register TagPrefix="AVC" TagName="Cliente" Src="~/Controles/BUSQUEDA/ctlCliente_Buscar.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">ORDEN DE SERVICIO - FORMATO 1</div>
<div id="divOpciones">
<table cellpadding="0" cellspacing="1" border="0">
    <tr>
        <td><asp:Button ID="btnGenerar" CssClass="Boton" runat="server" Text="Generar" /></td>
        <td><asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" /></td>
   </tr>
    </table>
</div> 
<table cellpadding="1" cellspacing="1" border="0" width="600">
    <tr>
        <td class="Etiqueta">Fecha Inicio:</td>
        <td>
            <asp:TextBox ID="txtFechaInicio" CssClass="CajaTexto" runat="server" Width="124px"></asp:TextBox>
            <asp:CalendarExtender ID="clnFechaInicio" runat="server" TargetControlID="txtFechaInicio" Format="dd/MM/yyyy">
        </asp:CalendarExtender>
        </td>
        <td class="Etiqueta">Fecha Final:</td>
        <td>
            <asp:TextBox ID="txtFechaFinal" CssClass="CajaTexto" runat="server" Width="124px"></asp:TextBox>
            <asp:CalendarExtender ID="clnFechaFinal" runat="server" TargetControlID="txtFechaFinal" Format="dd/MM/yyyy">
        </asp:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">Cliente:</td>
        <td colspan="3"><AVC:Cliente runat="server" ID="ctlCliente" /></td>
    </tr>

    <tr>
        <td class="Etiqueta">Tipo:</td>
        <td>
            <asp:DropDownList CssClass="CajaTexto" ID="ddlTipo" runat="server">
                <asp:ListItem Value="">Seleccionar</asp:ListItem>
                <asp:ListItem Value="MTC">Montacarga</asp:ListItem>
                <asp:ListItem Value="GRA">Grua</asp:ListItem>
                <asp:ListItem Value="STR">Semi trailer</asp:ListItem>
                <asp:ListItem Value="TYG">Transporte y Grua</asp:ListItem>
                <asp:ListItem Value="OPE">Operador</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td class="Etiqueta">Estado:</td>
        <td>
            <asp:DropDownList CssClass="CajaTexto" ID="ddlEstado" runat="server">
                <asp:ListItem Value="">Seleccionar</asp:ListItem>
                <asp:ListItem Value="ACT">Activo</asp:ListItem>
                <asp:ListItem Value="ANU">Anulado</asp:ListItem>
                <asp:ListItem Value="TER">Terminado</asp:ListItem>
                <asp:ListItem Value="CER">Cerrado</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
</table>
</div>
</asp:Content>

