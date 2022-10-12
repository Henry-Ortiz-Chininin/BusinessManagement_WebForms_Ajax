<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlCuentaEntidad.ascx.vb"
    Inherits="CONTROLES_REGISTRO_ctlCuentaEntidad" %>
<div class="Titulo">
    REGISTRO DE CUENTA ENTIDAD</div>
<asp:HiddenField runat="server" ID="hdnUsuario" />
<asp:HiddenField runat="server" ID="hdnEmpresa" />
<asp:HiddenField runat="server" ID="hdnNomEmpresa" />
<table cellpadding="1" cellspacing="1" border="0" width="300">
    <tr>
        <td class="Etiqueta">
            Codigo:
        </td>
        <td>
            <asp:TextBox ID="txtSecuencia" runat="server" Width="75px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Empresa
        </td>
        <td>
        <asp:UpdatePanel ID="updEmpresa" runat="server">
        <ContentTemplate>
            <asp:DropDownList ID="ddlIdEmpresa" runat="server" Width="127px" 
                AutoPostBack="True">
            </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            EntidadFinanciera
        </td>
        <td><asp:UpdatePanel ID="updEntidadFinanciera" runat="server">
        <ContentTemplate>
            <asp:DropDownList ID="ddlEntidadFinanciera" runat="server" Width="127px">
            </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Moneda
        </td>
        <td><asp:UpdatePanel ID="updMoneda" runat="server">
        <ContentTemplate>
            <asp:DropDownList ID="ddlIdMoneda" runat="server" Width="127px">
            </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            NumeroCuenta
        </td>
        <td>
            <asp:TextBox ID="txtNumeroCuenta" runat="server"></asp:TextBox>
        </td>
    </tr>
</table>
<div id="Opciones">
    <asp:Button ID="btnTerminar" CssClass="Boton" runat="server" Text="Registrar y Cerrar" />
    <asp:Button ID="btnRegistrar" CssClass="Boton" runat="server" Text="Registrar" />
    <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
</div>
