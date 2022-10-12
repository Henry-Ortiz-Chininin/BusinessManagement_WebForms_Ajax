<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlEjercicio_Registro.ascx.vb"
    Inherits="CONTROLES_REGISTRO_ctlEjercicio_Registro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div class="Titulo">
    REGISTRO DE EJERCICIO</div>
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
        <td><asp:UpdatePanel ID="updEmpresa" runat="server">
        <ContentTemplate>
            <asp:DropDownList ID="ddlEmpresa" runat="server" Width="130px">
            </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Fecha Inicio:
        </td>
        <td>
            <asp:TextBox ID="txtFechaInicio" runat="server" Width="124px" ></asp:TextBox>
            <asp:CalendarExtender ID="cldFechaInicio" runat="server" TargetControlID="txtFechaInicio"
                Format="dd/MM/yyyy">
            </asp:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Fecha final:
        </td>
        <td>
            <asp:TextBox ID="txtFechaFin" runat="server" Width="124px"></asp:TextBox>
            <asp:CalendarExtender ID="cldFechaFinal" runat="server" TargetControlID="txtFechaFin"
                Format="dd/MM/yyyy">
            </asp:CalendarExtender>
        </td>
    </tr>
     <tr>
        <td class="Etiqueta">
            Año:
        </td>
        <td>
            <asp:TextBox ID="txtAgno" runat="server" Width="124px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Descripción:
        </td>
        <td>
            <asp:TextBox ID="txtDescripcion" runat="server" Width="200px"></asp:TextBox>
        </td>
    </tr>
   
</table>
<div id="Opciones">
    <asp:Button ID="btnTerminar" CssClass="Boton" runat="server" Text="Registrar y Cerrar" />
    <asp:Button ID="btnRegistrar" CssClass="Boton" runat="server" Text="Registrar" />
    <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
</div>
