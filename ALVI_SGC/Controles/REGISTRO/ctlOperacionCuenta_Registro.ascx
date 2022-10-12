<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlOperacionCuenta_Registro.ascx.vb"
    Inherits="CONTROLES_REGISTRO_ctlOperacionCuenta_Registro" %>
<%@ Register TagPrefix="AVC" TagName="ctlVoucherBuscar" Src="~/CONTROLES/BUSQUEDA/ctlCuenta_Buscar.ascx" %>
<div class="Titulo">
    REGISTRO DE OPERACION CUENTA</div>
<asp:HiddenField runat="server" ID="hdnUsuario" />
<asp:HiddenField runat="server" ID="hdnEmpresa" />
<asp:HiddenField runat="server" ID="hdnNomEmpresa" />
<asp:HiddenField runat="server" ID="hdnContabilidad" />
<asp:HiddenField runat="server" ID="hdnIdCuenta" />
<asp:HiddenField runat="server" ID="hdnTipoMovimiento" />
<asp:Label runat="server" ID="lblTipoMovimiento" Visible="false"></asp:Label>
<table cellpadding="1" cellspacing="1" border="0" width="300">
    <tr>
        <td class="Etiqueta">
            Codigo:
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtCodigo" Enabled="false"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Empresa:
        </td>
        <td>
            <asp:UpdatePanel runat="server" ID="pnlEmpresa">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlEmpresa" runat="server" Width="130px" AutoPostBack="True">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="Etiqueta">
            Operacion:
        </td>
        <td>
            <asp:UpdatePanel runat="server" ID="pnlSuboperacion">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlSubOperacion" runat="server" Width="130px" AutoPostBack="True">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Sub Operacion:
        </td>
        <td>
            <asp:UpdatePanel runat="server" ID="pnlSubOperacionn">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlSubOperacionn" runat="server" Width="130px">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="Etiqueta" width="150px">
            Cuenta:
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtDescripcio" Width="203px"></asp:TextBox>
        </td>
        <td>
            <asp:ImageButton CssClass="Boton" ID="btnBuscar" ImageUrl="~/images/lupa.gif" onmouseover="this.src='../images/lupa_on.gif'"
                onmouseout="this.src='../images/lupa.gif'" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Cargo:
        </td>
        <td>
            <asp:CheckBox runat="server" ID="chkCargo" />
        </td>
        <td class="Etiqueta">
            Abono:
        </td>
        <td>
            <asp:CheckBox runat="server" ID="chkAbono" />
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            EsObligatorio:
        </td>
        <td>
            <asp:CheckBox runat="server" ID="chkObligatorio" />
        </td>
    </tr>
    <tr>
        <td class="Etiqueta" colspan="4">
            <table>
                <tr>
                    <td>
                        Descripcion :
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescripcion" runat="server" Width="197px" Height="62px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<asp:Panel ID="pnlCuenta" CssClass="Formulario" runat="server">
    <br />
    <AVC:ctlVoucherBuscar ID="ctlCuentaBuscar" runat="server" />
</asp:Panel>
<div id="Opciones">
    <asp:Button ID="btnTerminar" CssClass="Boton" runat="server" Text="Registrar y Cerrar" />
    <asp:Button ID="btnRegistrar" CssClass="Boton" runat="server" Text="Registrar" />
    <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
</div>
