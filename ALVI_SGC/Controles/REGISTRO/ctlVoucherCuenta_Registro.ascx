<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlVoucherCuenta_Registro.ascx.vb"
    Inherits="CONTROLES_REGISTRO_ctlVoucherCuenta_Registro" %>
<div class="Titulo">
    REGISTRO DE VOUCHER CUENTA</div>
<asp:HiddenField runat="server" ID="hdnUsuario" />
<asp:HiddenField runat="server" ID="hdnEmpresa" />
<table border="0" cellpadding="1" cellspacing="1" width="300">
    <tr>
        <td>
            Codigo:
        </td>
        <td>
            <asp:TextBox CssClass="CajaTexto" ID="txtcodigo" runat="server" Width="124px" />
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Empresa:
        </td>
        <td>
            <asp:UpdatePanel runat="server" ID="updEmpresa">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlEmpresa" runat="server" Width="130px" AutoPostBack="True">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td>
            Eercicio Empresa:
        </td>
        <td>
            <asp:UpdatePanel runat="server" ID="updEjercicio">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlEjercicioEmpresa" runat="server" Width="130px" AutoPostBack="True">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td>
            Contabilidad:
        </td>
        <td>
            <asp:UpdatePanel runat="server" ID="updContabilidad">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlContabilidad" runat="server" Width="130px" AutoPostBack="True">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td>
            Operacion:
        </td>
        <td>
            <asp:UpdatePanel runat="server" ID="updOperacionk">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlOperacion" runat="server" Width="130px" AutoPostBack="True">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td>
            IdAsiento:
        </td>
        <td>
            <asp:DropDownList ID="ddlAsiento" runat="server" Width="130px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            EsCargo:
        </td>
        <td>
            <asp:TextBox CssClass="CajaTexto" ID="txtEsCargo" runat="server" Width="124px" />
        </td>
    </tr>
    <tr>
        <td>
            Importe:
        </td>
        <td>
            <asp:TextBox CssClass="CajaTexto" ID="txtImporte" runat="server" Width="124px" />
        </td>
    </tr>
    <tr>
        <td>
            Observacion:
        </td>
        <td>
            <asp:TextBox CssClass="CajaTexto" ID="txtObservacion" runat="server" Width="124px" />
        </td>
    </tr>
</table>
<div id="Opciones">
    <asp:Button ID="btnTerminar" CssClass="Boton" runat="server" Text="Registrar y Cerrar" />
    <asp:Button ID="btnRegistrar" CssClass="Boton" runat="server" Text="Registrar" />
    <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
</div>
