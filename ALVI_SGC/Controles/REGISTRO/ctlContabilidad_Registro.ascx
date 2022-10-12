<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlContabilidad_Registro.ascx.vb"
    Inherits="CONTROLES_REGISTRO_ctlContabilidad_Registro" %>
<div class="Titulo">
    REGISTRO DE CONTABILIDAD</div>
<asp:HiddenField runat="server" ID="hdnUsuario" />
<asp:HiddenField runat="server" ID="hdnEmpresa" />
<asp:HiddenField runat="server" ID="hdnNomEmpresa" />
<table border="0" cellpadding="1" cellspacing="1" width="320">
    <tr>
        <td class="Etiqueta">
            Codigo:
        </td>
        <td>
            <asp:TextBox ID="txtCodigo" runat="server" Width="124px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Empresa:
        </td>
        <td>
            <asp:UpdatePanel ID="updMoneda" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlEmpresa" runat="server" Width="130px" AutoPostBack="True">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Descripción:
        </td>
        <td>
            <asp:TextBox ID="txtDescripcion" runat="server" Width="124px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Moneda:
        </td>
        <td>
            <asp:UpdatePanel ID="updMoneda2" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlMoneda" runat="server" Width="130px">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Cuenta Ganancia Cambio:
        </td>
        <td>
            <asp:TextBox ID="txtCuentaGananciaCambio" runat="server" Width="124px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Cuenta Perdida Cambio
        </td>
        <td>
            <asp:TextBox ID="txtCuentaPerdidaCambio" runat="server" Width="124px" />
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Estado:
        </td>
        <td class="Etiqueta">
            <asp:CheckBox ID="chkEstado" runat="server" AutoPostBack="true" Text="Activo" />
        </td>
    </tr>
</table>
<div id="Opciones">
    <asp:Button ID="btnTerminar" CssClass="Boton" runat="server" Text="Registrar y Cerrar" />
    <asp:Button ID="btnRegistrar" CssClass="Boton" runat="server" Text="Registrar" />
    <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
</div>
