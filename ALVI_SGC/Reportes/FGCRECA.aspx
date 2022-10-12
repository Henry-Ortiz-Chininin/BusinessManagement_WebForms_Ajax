<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FGCRECA.aspx.vb" Inherits="Reportes_FGCRECA" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LIBRO DIARIO - FORMATO 5.1</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
            <tr>
                <td><asp:ImageButton ID="lbtInicio" runat="server" Height="40px" ImageUrl="~/images/btnInicio.jpg" /></td>
                <td><asp:ImageButton ID="lbtAnterior" runat="server" Height="40px" ImageUrl="~/images/btnAnterior.jpg" /></td>
                <td><asp:ImageButton ID="lbtSiguiente" runat="server" Height="40px" ImageUrl="~/images/btnSiguiente.jpg" /></td>
                <td><asp:ImageButton ID="lbtUltimo" runat="server" Height="40px" ImageUrl="~/images/btnFin.jpg" /></td>
                <td><asp:ImageButton ID="btnExportarReportePDF" runat="server" ImageUrl="~/images/btnExportar.gif" /></td>
            </tr>
        </table>
    </div>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
     hassearchbutton="False"
        hastogglegrouptreebutton="False" displaytoolbar="false" enabledrilldown="False"
        toolpanelview="None" />
    </form>
</body>
</html>
