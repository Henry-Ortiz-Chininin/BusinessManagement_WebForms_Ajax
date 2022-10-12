<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FGRVI.aspx.vb" Inherits="REPORTES_CrystalReport_FGRVI" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <%--   <asp:LinkButton ID="lbtInicio" runat="server" onclick="lbtInicio_Click" 
                        Visible="False">Inicio</asp:LinkButton>--%>
                    <asp:ImageButton ID="lbtInicio" runat="server" Height="40px" ImageUrl="~/IMAGES/btnInicio.jpg" />
                </td>
                <td>
                    <%-- <asp:LinkButton ID="lbtAnterior" runat="server" onclick="lbtAnterior_Click" 
                        Visible="False">Anterior</asp:LinkButton>--%>
                    <asp:ImageButton ID="lbtAnterior" runat="server" Height="40px" ImageUrl="~/IMAGES/btnAnterior.jpg" />
                </td>
                <td>
                    <%--<asp:LinkButton ID="lbtSiguiente" runat="server" onclick="lbtSiguiente_Click" 
                        Visible="False">Siguiente</asp:LinkButton>--%>
                    <asp:ImageButton ID="lbtSiguiente" runat="server" Height="40px" ImageUrl="~/IMAGES/btnSiguiente.jpg" />
                </td>
                <td>
                    <%--<asp:LinkButton ID="lbtUltimo" runat="server" onclick="lbtUltimo_Click" 
                         Visible="False">Ultimo</asp:LinkButton>--%>
                    <asp:ImageButton ID="lbtUltimo" runat="server" Height="40px" ImageUrl="~/IMAGES/btnFin.jpg" />
                </td>
                <td>
                    <%-- <asp:Button ID="btnExportarReportePDF" runat="server" 
                        onclick="btnExportarReportePDF_Click" Text="Exportar PDF" Width="119px" />--%>
                    <asp:ImageButton ID="btnExportarReportePDF" runat="server" ValidationGroup="Formulario"
                        onmouseover="this.src='../../IMAGES/btnExportar_on.gif'" onmouseout="this.src='../../IMAGES/btnExportar.gif'"
                        ImageUrl="../../IMAGES/btnExportar.gif" />
                </td>
            </tr>
        </table>
    </div>
    <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" hassearchbutton="False"
        hastogglegrouptreebutton="False" displaytoolbar="false" enabledrilldown="False"
        toolpanelview="None" width="350px" />
    </form>
</body>
</html>
