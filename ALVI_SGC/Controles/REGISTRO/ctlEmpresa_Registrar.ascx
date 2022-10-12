<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlEmpresa_Registrar.ascx.vb" Inherits="CONTROLES_REGISTRO_ctlEmpresa_Registrar" %>
<div class="Titulo">REGISTRO DE EMPRESA</div>
<table cellpadding="1" cellspacing="1" border="0" width="300">
<tr>
    <td class="Etiqueta">Codigo:</td>
        <td class="Etiqueta"><asp:TextBox ID="txtCodigo"  runat="server" Width = "124px"></asp:TextBox></td>
</tr>
<tr>
    <td class="Etiqueta">RUC:</td>
    <td><asp:TextBox CssClass="CajaTexto" ID="txtRuc" runat="server" Width = "124px"/></td>
</tr>
<tr>
    <td class="Etiqueta">Razon Social:</td>
    <td><asp:TextBox CssClass="CajaTexto" ID="txtRazonSocial" runat ="server" Width = "124px" /></td>
</tr>
</table>
<div id="Opciones">
    <asp:Button ID="btnTerminar" CssClass="Boton" runat="server" Text="Registrar y Cerrar" />
    <asp:Button ID="btnRegistrar" CssClass="Boton" runat="server" Text="Registrar" />
    <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
</div>


