<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false"
    CodeFile="FGCCOAG.aspx.vb" Inherits="CONFIG_FGCCOAG" %>

<%@ Register TagPrefix="UC" TagName="PlanCuenta" Src="~/CONTROLES/REGISTRO/ctlPlanCuenta.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div id="divCuerpo">
    <div class="TituloPrincipal">
        PLAN CONTABLE - LISTADO</div>
    <div class="Opciones">
        <asp:Button ID="btnBuscar" CssClass="Boton" runat="server" Text="Buscar" />
        <asp:Button ID="btnNuevo" CssClass="Boton" runat="server" Text="Nuevo" />
        <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
        <asp:HiddenField runat="server" ID="hdnusuario" />
        <asp:HiddenField runat="server" ID="hdnEmpresa" />
        <asp:HiddenField runat="server" ID="hdnTipo" />
        <asp:HiddenField runat="server" ID="hdnNivel" />
    </div>
    <div class="Busquea">
        <table>
            <tr>
                <td>
                    <fieldset>
                        <legend>Busqueda </legend>
                        <table>
                            <tr>
                                <td class="Etiqueta">
                                    Cuenta:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtCuenta" Width="105px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="Etiqueta">
                                    Nombre:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtNombre" Width="305px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
        </table>
    </div>
    <center>
        <asp:GridView ID="grdDatos" Width="800" ShowFooter="true" AutoGenerateColumns="false"
            runat="server" AllowPaging="true" PageSize="20">
            <Columns>
                <asp:TemplateField HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible"
                    FooterStyle-CssClass="NoVisible">
                    <ItemTemplate>
                        <img alt="" src="../images/plus.gif" orderid='<%# Eval("IdCuentaContable") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="IdCuentaContable" HeaderText="Cuenta" />
                <asp:BoundField DataField="IdEmpresa" HeaderText="Cod_Empresa" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="IdEmpresa" HeaderText="Empresa" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="IdContabilidad" HeaderText="Cod_Conta" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="idContabilidad" HeaderText="Contabilidad" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="IdPlanContable" HeaderText="Cod_Contable" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="idPlanContable" HeaderText="Plan_Contable" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="IdNivel" HeaderText="Cod_Nivel" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="idNivel" HeaderText="Nivel_Plan" />
                <asp:BoundField DataField="IdTipoAnalisis" HeaderText="Cod_TipoAnalisis" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="idTipoAnalisis" HeaderText="Analisis" />
                <asp:BoundField DataField="IdTipoCuenta" HeaderText="Cod_TipoCuenta" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="idTipoCuenta" HeaderText="Tipo" />
                <asp:BoundField DataField="DiferenciaCambio" HeaderText="Dif_Cambio" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="ConversionMoneda" HeaderText="Conv_Moneda" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="IdEntidadFinanciera" HeaderText="Cod_EntFinanciera" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="idEntidadFinanciera" HeaderText="Banco" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="IdMoneda" HeaderText="Cod_Moneda" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="idMoneda" HeaderText="Moneda" />
                <asp:BoundField DataField="CuentaEntidad" HeaderText="Cod_Cta_Entidad" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="CuentaEntidad" HeaderText="Cta Corriente" />
                <asp:BoundField DataField="CuentaDebe" HeaderText="Cta_Debe" />
                <asp:BoundField DataField="CuentaHaber" HeaderText="Cta_Haber" />
                <asp:BoundField DataField="IdCuentaPadre" HeaderText="Cta_Padre" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:TemplateField HeaderStyle-Width="150px">
                    <ItemTemplate>
                        <asp:Button ID="btnEliminar" CssClass="Boton" CommandName="ELIMINAR" CommandArgument='<%#Container.DataItemIndex %>'
                            runat="server" Text="Eliminar" />
                        <asp:Button ID="btnEditar" CssClass="Boton" CommandName="MODIFICAR" CommandArgument='<%#Container.DataItemIndex %>'
                            runat="server" Text="Editar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="GridHeader" />
            <RowStyle CssClass="GridItem" />
            <AlternatingRowStyle CssClass="GridAltItem" />
        </asp:GridView>
    </center>
    <asp:Panel ID="pnlPlanCuenta" CssClass="Formulario" runat="server">
        <UC:PlanCuenta ID="ctlPlanCuenta" runat="server" />
    </asp:Panel>
    </div>
</asp:Content>
