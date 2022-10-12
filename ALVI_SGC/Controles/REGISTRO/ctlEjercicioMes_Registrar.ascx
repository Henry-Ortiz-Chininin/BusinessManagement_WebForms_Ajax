<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlEjercicioMes_Registrar.ascx.vb"
    Inherits="CONTROLES_REGISTRO_ctlEjercicioMes_Registrar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div class="Titulo">
    REGISTRO DE EJERCICIO MES</div>
<asp:HiddenField runat="server" ID="hdnUsuario" />
<asp:HiddenField runat="server" ID="hdnEmpresa" />
<asp:HiddenField runat="server" ID="hdnNomEmpresa" />
<asp:HiddenField runat="server" ID="hdnContabilidad" />
<table border="0" cellpadding="1" cellspacing="1" width="350">
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
                    <asp:DropDownList ID="ddlEmpresa" runat="server" AutoPostBack="True" Width="130px">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Ejercicio Empresa:
        </td>
        <td>
            <asp:DropDownList ID="ddlEjercicioEmpresa" runat="server" Width="130px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Fecha Inicio:
        </td>
        <td>
            <asp:TextBox ID="txtFechaInicio" runat="server" Width="124px"></asp:TextBox>
            <asp:CalendarExtender ID="clnFechaInicio" runat="server" TargetControlID="txtFechaInicio"
                Format="dd/MM/yyyy">
            </asp:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Fecha Final:
        </td>
        <td>
            <asp:TextBox ID="txtFechaFin" runat="server" Width="124px"></asp:TextBox>
            <asp:CalendarExtender ID="clnFechaFin" runat="server" TargetControlID="txtFechaFin"
                Format="dd/MM/yyyy">
            </asp:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Descripcion:
        </td>
        <td>
            <asp:TextBox ID="txtDescripcion" runat="server" Width="124px"></asp:TextBox>
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
</table>
<div id="Opciones">
    <asp:Button ID="btnTerminar" CssClass="Boton" runat="server" Text="Registrar y Cerrar" />
    <asp:Button ID="btnRegistrar" CssClass="Boton" runat="server" Text="Registrar" />
    <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
</div>
