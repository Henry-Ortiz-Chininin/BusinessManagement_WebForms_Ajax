<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlDetraccionRegistro.ascx.vb" Inherits="Controles_REGISTRO_ctlDetraccionRegistro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<div class="Titulo">REGISTRO DE DETRACCION</div>
<table border="0" cellpadding="1" cellspacing="1" width="300">
    <tr>
        <td class="Etiqueta">Codigo compra:</td>
        <td><asp:TextBox ID="txtCodigo" CssClass="Texto12" ReadOnly="true" Enabled="false" runat="server" Width="124px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="Etiqueta">Documento:</td>
        <td><asp:TextBox ID="txtDocumento" CssClass="Texto12" ReadOnly="true" Enabled="false" runat="server" Width="124px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Fecha Documento:
        </td>
        <td>
            <asp:TextBox ID="txtFecha" CssClass="Texto12" ReadOnly="true" Enabled="false" runat="server" Width="124px" ></asp:TextBox>
            <asp:CalendarExtender ID="cldFechaInicio" runat="server" TargetControlID="txtFecha" Format="dd/MM/yyyy">
            </asp:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">Cuenta de Detracción:</td>
        <td><asp:TextBox ID="txtCuentaDetraccion" CssClass="Texto12" runat="server" Width="124px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">Fecha Operación:
        </td>
        <td>
            <asp:TextBox ID="txtFechaOperacion" CssClass="Texto12" runat="server" Width="124px"></asp:TextBox>
            <asp:CalendarExtender ID="cldFechaFinal" runat="server" TargetControlID="txtFechaOperacion"
                Format="dd/MM/yyyy">
            </asp:CalendarExtender>
        </td>
    </tr>
     <tr>
        <td class="Etiqueta">
            Importe:
        </td>
        <td>
            <asp:TextBox ID="txtImporte" CssClass="Texto12" runat="server" Width="124px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Importe Documento:
        </td>
        <td>
            <asp:TextBox ID="txtTotalDocumento" CssClass="Texto12" ReadOnly="true" Enabled="false" runat="server" Width="200px"></asp:TextBox>
        </td>
    </tr>
   
</table>
<div id="Opciones">
    <asp:Button ID="btnTerminar" CssClass="Boton" runat="server" Text="Registrar y Cerrar" />
    <asp:Button ID="btnRegistrar" CssClass="Boton" runat="server" Text="Registrar" />
    <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
</div>
