<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlTipoAnalisis_Registrarl.ascx.vb" Inherits="CONTROLES_REGISTRO_ctlTipoAnalisis_Registrarl" %>

<div class="Titulo">REGISTRO DE TIPO DE ANALISIS</div>
<asp:HiddenField runat="server" ID="hdnUsuario" />
<asp:HiddenField runat="server" ID="hdnEmpresa" />
<asp:HiddenField runat="server" ID="hdnNomEmpresa" />
<table border="0" cellpadding="1" cellspacing="1" width="300">

<tr>
    <td class="Etiqueta" >Codigo:</td>
    <td><asp:TextBox ID="txtcodigoTipoAnalisis"   CssClass="CajaTexto"  runat="server" Width="124px" /></td>
</tr>
<tr>
    <td class="Etiqueta">Empresa:</td>
    <td><asp:DropDownList ID="ddlEmpresa" runat="server" Width="130px"></asp:DropDownList></td>
</tr>
<tr>
    <td  class="Etiqueta">Descripcion:</td>
    <td><asp:TextBox ID="txtDescripcion" CssClass="CajaTexto" runat ="server" Width="124px"/></td>
</tr>

</table>

<div id="Opciones">
    <asp:Button ID="btnTerminar" CssClass="Boton" runat="server" Text="Registrar y Cerrar" />
    <asp:Button ID="btnRegistrar" CssClass="Boton" runat="server" Text="Registrar" />
    <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
</div>






