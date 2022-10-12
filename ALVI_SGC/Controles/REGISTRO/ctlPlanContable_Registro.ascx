<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlPlanContable_Registro.ascx.vb"
    Inherits="CONTROLES_REGISTRO_ctlPlanContable_Registro" %>
<div class="Titulo">
    REGISTRO DE PLAN CONTABLE</div>
<asp:HiddenField runat="server" ID="hdnUsuario" />
<asp:HiddenField runat="server" ID="hdnEmpresa" />
<asp:HiddenField runat="server" ID="hdnNomEmpresa" />
<table border="0" cellpadding="1" cellspacing="1" width="300">
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
            <asp:UpdatePanel runat="server" ID="updEmpresa">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlEmpresa" runat="server" Width="130px" AutoPostBack="True">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="Etiqueta">
            Contabilidad:
        </td>
        <td class="Etiqueta">
            <asp:UpdatePanel runat="server" ID="updContabilidad">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlContabilidad" runat="server" Width="130px" AutoPostBack="True">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Formato:
        </td>
        <td colspan="4">
            <asp:TextBox ID="txtFormato" runat="server" Width="324"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="4" align="center">
            Longitudes
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Nivel 1
        </td>
        <td>
            <asp:TextBox ID="txtNivel1" runat="server" Width="124px"></asp:TextBox>
        </td>
        <td class="Etiqueta">
            Nivel 2
        </td>
        <td>
            <asp:TextBox ID="txtNivel2" runat="server" Width="124px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Nivel 3
        </td>
        <td>
            <asp:TextBox ID="txtNivel3" runat="server" Width="124px"></asp:TextBox>
        </td>
        <td class="Etiqueta">
            Nivel 4
        </td>
        <td>
            <asp:TextBox ID="txtNivel4" runat="server" Width="124px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Nivel 5
        </td>
        <td>
            <asp:TextBox ID="txtNivel5" runat="server" Width="124px"></asp:TextBox>
        </td>
        <td class="Etiqueta">
            Nivel 6
        </td>
        <td>
            <asp:TextBox ID="txtNivel6" runat="server" Width="124px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Nivel 7
        </td>
        <td>
            <asp:TextBox ID="txtNivel7" runat="server" Width="124px"></asp:TextBox>
        </td>
        <td class="Etiqueta">
            Nivel 8
        </td>
        <td>
            <asp:TextBox ID="txtNivel8" runat="server" Width="124px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Estado:
        </td>
        <td>
            <asp:UpdatePanel runat="server" ID="updEstado">
                <ContentTemplate>
                    <asp:CheckBox ID="chkEstado" runat="server" AutoPostBack="true" Text="Activo" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
<div id="Opciones">
    <asp:Button ID="btnTerminar" CssClass="Boton" runat="server" Text="Registrar y Cerrar" />
    <asp:Button ID="btnRegistrar" CssClass="Boton" runat="server" Text="Registrar" />
    <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
</div>
