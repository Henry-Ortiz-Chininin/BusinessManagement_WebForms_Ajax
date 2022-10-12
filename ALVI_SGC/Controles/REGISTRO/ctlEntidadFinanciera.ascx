<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlEntidadFinanciera.ascx.vb"
    Inherits="CONTROLES_REGISTRO_ctlEntidadFinanciera" %>
<div class="Titulo">
    REGISTRO DE ENTIDAD FINANCIERA</div>
<asp:HiddenField runat="server" ID="hdnUsuario" />
<asp:HiddenField runat="server" ID="hdnEmpresa" />
<asp:HiddenField runat="server" ID="hdnNomEmpresa" />
<table cellpadding="1" cellspacing="1" border="0" width="300">
    <tr>
        <td class="Etiqueta">
            Codigo:
        </td>
        <td>
            <asp:TextBox ID="txtIdEntidadFinanciera" runat="server" Width = "124px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Codigo Sunat:
        </td>
        <td>
            <asp:TextBox ID="txtSunat" runat="server" Width = "124px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Empresa
        </td>
        <td>
            <asp:DropDownList ID="ddlEmpresa" runat="server" Width="130px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
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
