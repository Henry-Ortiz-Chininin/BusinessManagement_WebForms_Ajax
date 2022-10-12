<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlLibro_Registrar.ascx.vb"
    Inherits="CONTROLES_REGISTRO_ctlLibro_Registrar" %>
<div class="Titulo">
    REGISTRO DE LIBRO</div>
<asp:HiddenField runat="server" ID="hdnUsuario" />
<table cellpadding="1" cellspacing="1" border="0" width="300">
    <tr>
        <td class="Etiqueta">
            Sunat:
        </td>
        <td>
            <asp:TextBox ID="txtIdSunat" CssClass="CajaTexto" runat="server" Width="124px" />
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Libro:
        </td>
        <td>
            <asp:TextBox ID="txtIdLibro" CssClass="CajaTexto" runat="server" Width="124px" />
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Descripcion:
        </td>
        <td>
            <asp:TextBox ID="txtDescripcion" CssClass="CajaTexto" runat="server" Width="124px" />
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
