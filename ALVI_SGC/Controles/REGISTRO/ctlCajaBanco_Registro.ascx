<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlCajaBanco_Registro.ascx.vb"
    Inherits="Controles_REGISTRO_ctlCajaBanco_Registro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="AVC" TagName="Cliente" Src="~/Controles/ctlCliente_Buscar.ascx" %>
<%@ Register TagPrefix="AVC" TagName="Proveedor" Src="~/Controles/ctlProveedor_Buscar.ascx" %>
<%@ Register TagPrefix="AVC" TagName="Documento" Src="~/CONTROLES/BUSQUEDA/ctlDocumento_Buscar.ascx" %>
<div class="Titulo">
    CAJA Y BANCOS - REGISTRO</div>
<asp:HiddenField ID="hdnIdMovimiento" runat="server" />
<table cellpadding="1" cellspacing="1" border="0" width="700">
    <tr>
        <td valign="top" width="180px" rowspan="4">
            <em class="Titulo12">Operación:</em>
            <%--<asp:UpdatePanel ID="upnOperaciones" runat="server">
                <ContentTemplate>--%>
            <asp:ListBox ID="lstOperaciones" Width="200" AutoPostBack="True" CssClass="Texto12"
                Rows="5" runat="server"></asp:ListBox>
            <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
            <br />
            <em class="Titulo12">Medio de Pago:</em>
            <%--<asp:UpdatePanel ID="upnSubOperacion" runat="server">
                <ContentTemplate>--%>
            <asp:ListBox ID="lstSubOperacion" Width="200" AutoPostBack="true" CssClass="Texto12"
                Rows="8" runat="server"></asp:ListBox>
            <%--</ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="lstOperaciones" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>--%>
        </td>
        <td valign="top">
            <AVC:Documento runat="server" ID="ctlDocumentoDeudor" Titulo="Documento Deudor" />
            <AVC:Documento runat="server" ID="ctlDocumentoAcreedor" Titulo="Documento Acreedor" />
        </td>
        <td valign="top">
            <AVC:Cliente runat="server" ID="ctlCliente" />
            <AVC:Proveedor runat="server" ID="ctlProveedor" />
        </td>
    </tr>
    <tr>
        <td colspan="2" class="Titulo12">
            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
            <table cellpadding="1" cellspacing="1" border="0" width="500">
                <tr>
                    <td>
                        Entidad Financiera:
                        <asp:Label ID="lblEntidad" CssClass="Texto12" runat="server"></asp:Label>
                        <asp:HiddenField ID="hdnIdEntidad" runat="server" />
                    </td>
                    <td>
                        Cuenta:
                        <asp:Label ID="lblCuenta" runat="server"></asp:Label>
                        <asp:HiddenField ID="hdnIdCuentaEntidad" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Moneda:
                        <asp:Label ID="lblMoneda" CssClass="Texto12" runat="server"></asp:Label>
                        <asp:HiddenField ID="hdnIdMoneda" runat="server" />
                    </td>
                </tr>
            </table>
            <%--</ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="lstSubOperacion" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>--%>
        </td>
    </tr>
    <tr>
        <td colspan="2" class="Titulo12">
            <table cellpadding="1" cellspacing="1" border="0" width="500">
                <tr>
                    <td width="150">
                        Importe Pagado:<br />
                        <asp:TextBox ID="txtImporte" CssClass="TextoNumero" runat="server"></asp:TextBox>
                    </td>
                    <td width="350" align="right">
                        Fecha de pago:<br />
                        <asp:TextBox ID="txtFecha" Width="100" CssClass="Texto12" runat="server"></asp:TextBox>
                        <%--<asp:CalendarExtender ID="calFecha" TargetControlID="txtFecha" Enabled="true" DaysModeTitleFormat="MMMM-yyyy"
                            Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy" runat="server">
                        </asp:CalendarExtender>--%>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2" class="Titulo12">
            Observación:<br />
            <asp:TextBox ID="txtGlosa" CssClass="Texto12" runat="server"></asp:TextBox>
        </td>
    </tr>
</table>
<div id="Opciones">
    <asp:Button ID="btnTerminar" CssClass="Boton" runat="server" Text="Registrar y Cerrar" />
    <asp:Button ID="btnRegistrar" CssClass="Boton" runat="server" Text="Registrar" />
    <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
</div>
