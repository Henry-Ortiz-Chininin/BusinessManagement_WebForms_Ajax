<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlEjercicioEmpresa_Registro.ascx.vb"
    Inherits="CONTROLES_REGISTRO_ctlEjercicioEmpresa_Registro" %>
<div class="Titulo">
    REGISTRO DE EJERCICIO EMPRESA</div>
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
            <asp:UpdatePanel ID="updEmpresa" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlEmpresa" runat="server" Width="130px" AutoPostBack="true">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Contabilidad:
        </td>
        <td>
            <asp:UpdatePanel ID="updContabilidad" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlContabilidad" runat="server" Width="130px">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Ejercicio:
        </td>
        <td>
            <asp:DropDownList ID="ddlEjercicio" runat="server" Width="130px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Estado:
        </td>
        <td class="Etiqueta">
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
