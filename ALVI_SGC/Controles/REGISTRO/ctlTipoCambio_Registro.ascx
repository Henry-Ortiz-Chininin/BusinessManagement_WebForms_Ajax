<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlTipoCambio_Registro.ascx.vb"
    Inherits="CONTROLES_REGISTRO_ctlTipoCambio_Registro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div class="Titulo">
    REGISTRO DE TIPO DE CAMBIO</div>
<asp:HiddenField runat="server" ID="hdnUsuario" />
<asp:HiddenField runat="server" ID="hdnEmpresa" />
<asp:HiddenField runat="server" ID="hdnNomEmpresa" />
<table cellpadding="1" cellspacing="1" border="0" width="300">
    <tr>
        <td class="Etiqueta">
            Codigo:
        </td>
        <td>
            <asp:TextBox ID="txtIdTipoCambio" CssClass="CajaTexto" runat="server" Width="124px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Empresa
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
        <td class="Etiqueta">
            Moneda
        </td>
        <td>
            <asp:UpdatePanel runat="server" ID="updMoneda">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlMoneda" runat="server" Width="130px">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Fecha
        </td>
        <td>
            <asp:TextBox ID="txtFecha" CssClass="CajaTexto" runat="server" Width="124px"></asp:TextBox>
        </td>
        <asp:CalendarExtender ID="clnFecha" runat="server" TargetControlID="txtFecha" Format="dd/MM/yyyy">
        </asp:CalendarExtender>
    </tr>
    <tr>
        <td class="Etiqueta">
            Compra
        </td>
        <td>
            <asp:TextBox ID="txtCompra" CssClass="CajaTexto" runat="server" Width="124px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Venta
        </td>
        <td>
            <asp:TextBox ID="txVenta" CssClass="CajaTexto" runat="server" Width="124px"></asp:TextBox><asp:LinkButton
                runat="server" Text="Cambio" ID="lnktipok"></asp:LinkButton>
        </td>
    </tr>
</table>
<div id="Opciones">
    <asp:Button ID="btnTerminar" CssClass="Boton" runat="server" Text="Registrar y Cerrar" />
    <asp:Button ID="btnRegistrar" CssClass="Boton" runat="server" Text="Registrar" />
    <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
</div>
