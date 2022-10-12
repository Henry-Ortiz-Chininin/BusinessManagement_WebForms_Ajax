<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlCliente_Registro.ascx.vb"
    Inherits="CONTROLES_REGISTRO_ctlCliente_Registro" %>
<div id="divTitulo">
    Registro - Cliente</div>
<table cellpadding="2" cellspacing="2" border="0" width="300" align="center" valign="middle">
    <tr>
        <td class="Titulo12">
            RUC
        </td>
        <td>
            <asp:TextBox CssClass="Texto12" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');"
                MaxLength="11" ID="txtCodigo" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">
            Razón Social
        </td>
        <td>
            <asp:TextBox ID="txtDescripcion" MaxLength="200" onChange="validadigito(this,'ALN');"
                onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">
            Dirección
        </td>
        <td>
            <asp:TextBox ID="txtDireccion" MaxLength="200" onChange="validadigito(this,'ALN');"
                onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">
            Telefóno
        </td>
        <td>
            <asp:TextBox ID="TxtTelefono" MaxLength="200" onChange="validadigito(this,'TEL');"
                onKeypress="return Valida(event, 'TEL');" CssClass="Texto12" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">
            Persona de Contacto
        </td>
        <td>
            <asp:TextBox ID="TxtPersonaContacto" MaxLength="200" onChange="validadigito(this,'ALN');"
                onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">
            Telefono Persona de Contacto
        </td>
        <td>
            <asp:TextBox ID="TxtTelefonoPersonaContacto" MaxLength="200" onChange="validadigito(this,'TEL');"
                onKeypress="return Valida(event, 'TEL');" CssClass="Texto12" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">
            Mercado
        </td>
        <td>
            <asp:DropDownList ID="ddlMercado" runat="server">
                <asp:ListItem Value="N" Selected="True">Nacional</asp:ListItem>
                <asp:ListItem Value="E">Extranjero</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:ImageButton ID="btnTerminar" CssClass="Boton" onmouseover="this.src='../images/btnRegistroCierre_on.gif';"
                onmouseout="this.src='../images/btnRegistroCierre.gif';" ImageUrl="../../images/btnRegistroCierre.gif"
                runat="server" />
            <asp:ImageButton ID="btnRegistrar" CssClass="Boton" onmouseover="this.src='../images/btnRegistrar_on.gif';"
                onmouseout="this.src='../images/btnRegistrar.gif';" ImageUrl="../../images/btnRegistrar.gif"
                runat="server" />
            <asp:ImageButton ID="btnCancelar" CssClass="Boton" onmouseover="this.src='../images/btnCancelar_on.gif';"
                onmouseout="this.src='../images/btnCancelar.gif';" ImageUrl="../../images/btnCancelar.gif"
                runat="server" />
        </td>
    </tr>
</table>
<div id="divFooter">
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>&nbsp;</div>
