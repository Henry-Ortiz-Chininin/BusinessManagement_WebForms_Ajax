<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlPlanCuenta.ascx.vb"
    Inherits="CONTROLES_REGISTRO_ctlPlanCuenta" %>
<div class="Titulo">
    <asp:HiddenField runat="server" ID="hdnUsuario" />
    <asp:HiddenField runat="server" ID="hdnEmpresa" />
    <asp:HiddenField runat="server" ID="hdnPlanContable" />
    <asp:HiddenField runat="server" ID="hdnContabilidad" />
    REGISTRO DE PLAN DE CUENTA</div>
<table border="0" cellpadding="1" cellspacing="1" width="600">
    <tr>
        <td>
            &nbsp;
        </td>
        <td>
            <asp:UpdatePanel runat="server" ID="updEmpresa">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlEmpresa" Visible="false" runat="server" Width="130px" AutoPostBack="True">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td>
            &nbsp;
        </td>
        <td>
            <asp:UpdatePanel runat="server" ID="updContabilidad">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlContabilidad" Visible="false" runat="server" Width="130px"
                        AutoPostBack="True">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Codigo:
        </td>
        <td>
            <asp:TextBox ID="txtCodigo" runat="server" Width="124px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <%-- <td>
            Plan Contable:
        </td>
        <td>
            <asp:DropDownList ID="ddlPlanContable" runat="server" Width="127px">
            </asp:DropDownList>
        </td>--%>
        <td class="Etiqueta">
            Nivel Plan:
        </td>
        <td>
            <asp:UpdatePanel runat="server" ID="updNivelPlan">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlNivelPlan" runat="server" Width="130px" AutoPostBack="True">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Nombre:
        </td>
        <td colspan="3">
            <asp:TextBox ID="txtNombre" runat="server" Width="433px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Tipo Analisis:
        </td>
        <td>
            <asp:UpdatePanel runat="server" ID="updTipoanalisis">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlTipoAnalisis" runat="server" Width="130px">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="Etiqueta">
            Tipo Cuenta:
        </td>
        <td>
            <asp:UpdatePanel runat="server" ID="updTipoCuenta">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlTipoCuenta" runat="server" Width="130px">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Diferencia de cambio:
        </td>
        <td>
            <asp:TextBox ID="txtDiferenciaCambio" runat="server" Width="124px"></asp:TextBox>
        </td>
        <td class="Etiqueta">
            Conversion de Moneda:
        </td>
        <td>
            <asp:TextBox ID="txtConversionMoneda" runat="server" Width="124px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Entidad Financiera:
        </td>
        <td>
            <asp:UpdatePanel runat="server" ID="updEntidadF">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlEntidadFinanciera" runat="server" Width="130px" 
                        AutoPostBack="True">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="Etiqueta">
            Moneda:
        </td>
        <td>
            <asp:UpdatePanel runat="server" isd="updMoneda">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlMoneda" runat="server" Width="130px">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Cuenta Entidad:
        </td>
        <td colspan="3">
            <asp:UpdatePanel runat="server" ID="updCuentaE">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlCuentaEntidad" runat="server" Width="130px">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Cuenta Debe:
        </td>
        <td>
            <asp:TextBox ID="txtCuentaDebe" runat="server" Width="124px"></asp:TextBox>
        </td>
        <td class="Etiqueta">
            Cuenta Haber:
        </td>
        <td>
            <asp:TextBox ID="txtCuentaHaber" runat="server" Width="124px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Etiqueta">
            Cuenta Padre:
        </td>
        <td colspan="3">
            <asp:TextBox ID="txtCuentaPadre" runat="server" Width="433px"></asp:TextBox>
        </td>
    </tr>
</table>
<div id="Opciones">
    <asp:Button ID="btnTerminar" CssClass="Boton" runat="server" Text="Registrar y Cerrar" />
    <asp:Button ID="btnRegistrar" CssClass="Boton" runat="server" Text="Registrar" />
    <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
</div>
