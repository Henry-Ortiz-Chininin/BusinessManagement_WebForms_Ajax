<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlTipoDocumento_Registrar.ascx.vb"
    Inherits="CONTROLES_REGISTRO_ctlTipoDocumento" %>
<div class="Titulo">
    REGISTRO DE TIPO DE DOCUMENTO</div>
<asp:HiddenField runat="server" ID="hdnUsuario" />
<asp:HiddenField runat="server" ID="hdnEmpresa" />
<asp:HiddenField runat="server" ID="hdnNomEmpresa" />
<table cellpadding="1" cellspacing="1" border="0" width="300">
    <tr>
        <td class="Etiqueta">
            Codigo:
        </td>
        <td>
            <asp:TextBox CssClass="CajaTexto" ID="txtIdTipoDocumento" runat="server" Width="124px" />
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Codigo Sunat:
        </td>
        <td>
            <asp:TextBox CssClass="CajaTexto" ID="txtSunat" runat="server" Width="124px" />
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
            Descripcion
        </td>
        <td>
            <asp:TextBox CssClass="CajaTexto" ID="txtDescripcion" runat="server" Width="124px" />
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Clase
        </td>
        <td>
            <asp:DropDownList ID="ddlClase" runat="server" Width="130px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Estado
        </td>
        <td>
            <asp:UpdatePanel runat="server" ID="updEstado">
                <ContentTemplate>
                    <asp:CheckBox ID="chkEstado" runat="server" AutoPostBack="true" Text="Activo" />
                </ContentTemplate>
            </asp:UpdatePanel>
    </tr>
</table>
<div id="Opciones">
    <asp:Button ID="btnTerminar" CssClass="Boton" runat="server" Text="Registrar y Cerrar" />
    <asp:Button ID="btnRegistrar" CssClass="Boton" runat="server" Text="Registrar" />
    <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
</div>
