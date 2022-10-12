<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlUsuarioEmpresa_Registro.ascx.vb"
    Inherits="CONTROLES_REGISTRO_ctlUsuarioEmpresa_Registro" %>
<div class="Titulo">
    REGISTRO DE USUARIO EMPRESA</div>
<asp:HiddenField runat="server" ID="hdnUsuario" />
<asp:HiddenField runat="server" ID="hdnEmpresa" />
<asp:HiddenField runat="server" ID="hdnNomEmpresa" />
<table cellpadding="1" cellspacing="1" border="0" width="300">
    <tr>
        <td class="Etiqueta">
            Usuario
        </td>
        <td>
            <asp:UpdatePanel runat="server" ID="updUsuario">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlUsario" runat="server" Width="130px" AutoPostBack="True">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Empresa
        </td>
        <td>
            <asp:DropDownList ID="ddlEmpresa" runat="server" Width="130px">
            </asp:DropDownList>
        </td>
    </tr>
</table>
<div id="Opciones">
    <asp:Button ID="btnTerminar" CssClass="Boton" runat="server" Text="Registrar y Cerrar" />
    <asp:Button ID="btnRegistrar" CssClass="Boton" runat="server" Text="Registrar" />
    <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
</div>
