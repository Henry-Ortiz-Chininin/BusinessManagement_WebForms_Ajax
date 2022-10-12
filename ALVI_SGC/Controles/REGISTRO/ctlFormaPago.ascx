<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlFormaPago.ascx.vb"
    Inherits="CONTROLES_REGISTRO_ctlFormaPago" %>
<asp:HiddenField runat="server" ID="hdnUsuario" />
<asp:HiddenField runat="server" ID="hdnEmpresa" />
<asp:HiddenField runat="server" ID="hdnNomEmpresa" />
<asp:UpdatePanel ID="upnListCredito" runat="server">
    <ContentTemplate>
        <table cellpadding="1" cellspacing="1" border="0">
            <tr>
                <td>
                    <table>
                        <tr>
                            <td valign="bottom">
                                <asp:RadioButton ID="rbtContado" Text="Contado" runat="server" AutoPostBack="True"
                                    Width="100px" GroupName="C"></asp:RadioButton>
                            </td>
                            <td valign="bottom">
                                <asp:RadioButton ID="rbtCredito" Text="Crédito" runat="server" AutoPostBack="True"
                                    Width="100px" GroupName="C"></asp:RadioButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <table>
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="updPnlddlCredito" runat="server">
                                    <ContentTemplate>
                                        <asp:Panel ID="pnlCredito" runat="server">
                                            <td>
                                                <asp:DropDownList Width="100" ID="ddlCredito" runat="server" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdPnlMontoCuota" runat="server">
                                    <ContentTemplate>
                                        <asp:Panel ID="pnlMontoCuota" runat="server">
                                            <td>
                                                Monto:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMontoCuota" Width="80px" runat="server" AutoPostBack="true" CssClass="Texto"></asp:TextBox>
                                            </td>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                </td>
        </table>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <asp:UpdatePanel ID="updPnlFechaAdicion" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="pnlFechaAdicion" runat="server">
                                    <td>
                                        Fecha Adicion
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFechaAdicion" runat="server" AutoPostBack="true" CssClass="Texto"></asp:TextBox>
                                    </td>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </tr>
                </table>
            </td>
        </tr>
        </table>
    </ContentTemplate>
    <Triggers>
        <%--<asp:AsyncPostBackTrigger ControlID="RadioButtonList1" EventName="RadioButtonList1_TextChanged" />--%>
        <%-- <asp:AsyncPostBackTrigger ControlID="rbtcontado" EventName="CheckedChanged" />--%>
    </Triggers>
</asp:UpdatePanel>
