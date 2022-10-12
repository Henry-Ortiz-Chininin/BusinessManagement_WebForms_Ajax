<%@ Page Language="VB" MasterPageFile="~/Masterpage/Externo.master" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="Security_login" Title="Sistema de Gestión de Costos - Alta Visión Consultores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Cuerpo">
        <div class="Formulario">

            <table border="0" cellpadding="1" cellspacing="1" align="center" width="200" valign="middle">
                <tr>
                    <td class="Texto12">Usuario</td>
                    <td>
                        <asp:TextBox ID="txtLogin" runat="server" CssClass="TextoLogin"
                            Width="124px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Texto12">Clave</td>
                    <td>
                        <asp:TextBox ID="txtClave" runat="server" AutoPostBack="true" TextMode="Password" Width="124px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:ImageButton ID="btnAceptar" runat="server" Text="Ingresar" ImageUrl="~/images/btnAceptar.gif" />
                    </td>
                </tr>
            </table>
        </div>

    </div>
</asp:Content>

