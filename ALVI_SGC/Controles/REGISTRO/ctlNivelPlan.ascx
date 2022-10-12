<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlNivelPlan.ascx.vb"
    Inherits="CONTROLES_REGISTRO_ctlNivelPlan" %>
<div class="Titulo">
    REGISTRO DE NIVEL PLAN</div>
<asp:HiddenField runat="server" ID="hdnUsuario" />
<asp:HiddenField runat="server" ID="hdnEmpresa" />
<asp:HiddenField runat="server" ID="hdnNomEmpresa" />
<table cellpadding="1" cellspacing="1" border="0" width="300">
    <tr>
        <td class="titulo20">
            Codigo:
        </td>
        <td>
            <asp:TextBox ID="txtNivelPlan" runat="server" Width = "124px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="titulo20">
            Empresa
        </td>
        <td>
            <asp:DropDownList ID="ddlEmpresa" runat="server" Width="130px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="titulo20">
            Descripcion
        </td>
        <td>
            <asp:TextBox ID="txtDescripcion" runat="server" Width = "124px"></asp:TextBox>
        </td>
    </tr>
</table>
<div id="Opciones">
    <asp:Button ID="btnTerminar" CssClass="Boton" runat="server" Text="Registrar y Cerrar" />
    <asp:Button ID="btnRegistrar" CssClass="Boton" runat="server" Text="Registrar" />
    <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
</div>
