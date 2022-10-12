<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCFICB.aspx.vb" Inherits="Reportes_FGCFICB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">LIBRO CAJA - FORMATO 1.1</div>
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
</div>
</asp:Content>

