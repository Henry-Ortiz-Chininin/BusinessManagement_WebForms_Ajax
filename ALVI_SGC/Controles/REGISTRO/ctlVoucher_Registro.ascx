<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlVoucher_Registro.ascx.vb"
    Inherits="CONTROLES_REGISTRO_ctlVoucher_Registro" %>
<div class="Titulo">
<asp:HiddenField runat="server" ID="hdnUsuario" />
<asp:HiddenField runat="server" ID="hdnEmpresa" />
    <script type="text/javascript">
        function JvfunonBlur() {
            var grid = document.getElementById('<%=grdVoucher.ClientID %>');
            var col1;
            var totalcol1 = 0;
            var col2;
            var totalcol2 = 0;
            for (i = 0; i < grid.rows.length; i++) {
                col1 = grid.rows[i].cells[2];
                col2 = grid.rows[i].cells[3];

                for (j = 0; j < col1.childNodes.length; j++) {
                    if (col1.childNodes[j].type == "text") {
                        if (!isNaN(col1.childNodes[j].value) && col1.childNodes[j].value != "") {
                            totalcol1 += parseInt(col1.childNodes[j].value)
                        }
                    }
                }
                for (j = 0; j < col2.childNodes.length; j++) {
                    if (col2.childNodes[j].type == "text") {
                        if (!isNaN(col2.childNodes[j].value) && col2.childNodes[j].value != "") {
                            totalcol2 += parseInt(col2.childNodes[j].value)
                        }
                    }
                }
            }
            document.getElementById('<%=txtTotalCargo.ClientID %>').value = totalcol1;
            document.getElementById('<%=txtTotalAbono.ClientID %>').value = totalcol2;
        }
    </script>
    REGISTRO DE VOUCHER</div>
<br />
<%--<div id="Opciones">
    <asp:Button ID="btnRegistrar" CssClass="Boton" runat="server" Text="Registrar" />&nbsp;
    <asp:Button ID="btnBuscar" CssClass="Boton" runat="server" Text="Buscar" />&nbsp;
    <asp:Button ID="btnNuevo" CssClass="Boton" runat="server" Text="Nuevo" />&nbsp;
    <asp:Button ID="btnImprimir" CssClass="Boton" runat="server" Text="Imprimir" />&nbsp;
    <asp:Button ID="btnCerrar" CssClass="Boton" runat="server" Text="Cerrar" />
</div>--%>
<br />
<table cellpadding="1" cellspacing="1" border="0">
    <tr>
        <td class="Etiqueta">
            Operacion:
        </td>
        <td width="170">
            <asp:DropDownList ID="ddlOperacion" runat="server" Width="130px">
            </asp:DropDownList>
        </td>
        <td>
            Fecha:
        </td>
        <td width="170">
            <asp:TextBox ID="txtFecha" Width="80" MaxLength="10" onChange="validadigito(this,'');"
                onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
            <asp:Image ID="btnFecha" runat="server" ImageUrl="~/IMAGES/Calendar.gif" />
        </td>
        <td>
            Voucher:
        </td>
        <td>
            <asp:TextBox ID="txtCodigoVoucher" runat="server" Width="124px"></asp:TextBox>
        </td>
    </tr>
</table>
<br />
<div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="grdVoucher" Width="700" ShowFooter="true" AutoGenerateColumns="false"
                runat="server" AllowPaging="true" PageSize="5">
                <Columns>
                    <asp:TemplateField HeaderText="Cuenta">
                        <ItemTemplate>
                            <asp:TextBox ID="lblCuenta" runat="server" Text='<%# Eval("IdCuenta") %>'></asp:TextBox>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtCuentaRegistro1" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Descripcion">
                        <ItemTemplate>
                            <asp:TextBox ID="lblDescripcion" runat="server" Text='<%# Eval("DesOperacion") %>'></asp:TextBox>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtDescripcionRegistro1" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cargo">
                        <ItemTemplate>
                            <asp:TextBox ID="lblCargo1" runat="server" Text='<%# Eval ("EsCargo") %>'></asp:TextBox>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtCargoRegistro1" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Abono">
                        <ItemTemplate>
                            <asp:TextBox ID="lblAbono1" runat="server" Text='<%# Eval ("EsAbono") %>'></asp:TextBox>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtAbonoRegistro1" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Observacion">
                        <ItemTemplate>
                            <asp:TextBox ID="lblObservacion1" runat="server" Text='<%# Eval ("Observacion") %>'></asp:TextBox>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtObservacionRegistro1" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnEliminar" CssClass="Boton" CommandName="ELIMINAR" CommandArgument='<%#Eval("IdCuenta") %>'
                                runat="server" Text="Eliminar" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Button ID="btnRegistrar1" CssClass="Boton" CommandName="AGREGAR" CommandArgument='<%#Container.DataItemIndex %>'
                                runat="server" Text="Registrar" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="GridHeader" />
                <RowStyle CssClass="GridItem" />
                <AlternatingRowStyle CssClass="GridAltItem" />
            </asp:GridView>
            <br />
            <table>
                <tr>
                    <td>
                        Total Cargo:
                    </td>
                    <td width="170">
                        <asp:TextBox ID="txtTotalCargo" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Total Abono:
                    </td>
                    <td width="170">
                        <asp:TextBox ID="txtTotalAbono" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Diferencia:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDiferencia" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <div>
                <asp:Label ID="lblMensaje" ForeColor="Red" runat="server" Text=""></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
<br />
<%--<table cellpadding="1" cellspacing="1" border="0">
    <tr>
        <td>
            Total Cargo:
        </td>
        <td width="170">
            <asp:TextBox ID="txtTotalCargo" runat="server"></asp:TextBox>
        </td>
        <td>
            Total Abono:
        </td>
        <td width="170">
            <asp:TextBox ID="txtTotalAbono" runat="server"></asp:TextBox>
        </td>
        <td>
            Diferencia:
        </td>
        <td>
            <asp:TextBox ID="txtDiferencia" runat="server"></asp:TextBox>
        </td>
    </tr>
</table>--%>
<br />
