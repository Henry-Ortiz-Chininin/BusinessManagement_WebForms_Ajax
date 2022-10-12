<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FGCIMPRE.aspx.vb" Inherits="Interfaces_FGCIMPRE" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        body
        {
            font-size: 25px;
            color: #FFF;
            font-family: Verdana;
            font-size: 12pt;
            margin:0px;
            width: 1000px;
            height: auto;
            text-decoration: none;
        }
        .Contenedor
        {
            margin-top: 50px;
            margin-left: auto;
            height: auto;
            text-align: center;
        }
        .Texto
        {
            color: Blue;
            font-size: 12pt;
            border: 0px;
            width: 500px;
            text-align: center;
        }
        .BotonCerrar
        {
            
            border: solid 1px #2d2d2d;
            text-align: center;
            background: #575757;
            padding: 20px 20px 20px 20px;
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            -o-border-radius: 5px;
            -ms-border-radius: 5px;
            border-radius: 5px;
            background-color: rgba(218, 47, 44, 0.8);
            background: rgba(218, 47, 44, 0.8);
            color: #FFF;
            font-size: 12pt;
            margin-top:10px;
        }
        .BotonCerrar:hover
        {
            background-color: rgba(249, 47, 44, 0.7);
            background: rgba(249, 47, 44, 0.7);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divMensaje" class="Contenedor">
        <asp:TextBox runat="server" ID="txtMensaje" CssClass="Texto" ReadOnly="true"></asp:TextBox>
        <br />
        <asp:Button runat="server" ID="btnCerrar" Text="Cerrar" CssClass="BotonCerrar" />
    </div>
    <div>
        <table>
            <tr>
                <td>
                    <%--<asp:LinkButton ID="lbtInicio" runat="server" onclick="lbtInicio_Click" 
                        Visible="False">Inicio</asp:LinkButton>--%>
                    <asp:ImageButton ID="lbtInicio" runat="server" Height="40px" ImageUrl="~/Images/btnInicio.jpg" />
                </td>
                <td>
                    <%--<asp:LinkButton ID="lbtAnterior" runat="server" onclick="lbtAnterior_Click" 
                        Visible="False">Anterior</asp:LinkButton>--%>
                    <asp:ImageButton ID="lbtAnterior" runat="server" Height="40px" ImageUrl="~/Images/btnAnterior.jpg" />
                </td>
                <td>
                    <%--<asp:LinkButton ID="lbtSiguiente" runat="server" onclick="lbtSiguiente_Click" 
                        Visible="False">Siguiente</asp:LinkButton>--%>
                    <asp:ImageButton ID="lbtSiguiente" runat="server" Height="40px" ImageUrl="~/Images/btnSiguiente.jpg" />
                </td>
                <td>
                    <%--<asp:LinkButton ID="lbtUltimo" runat="server" onclick="lbtUltimo_Click" 
                        Visible="False">Ultimo</asp:LinkButton>--%>
                    <asp:ImageButton ID="lbtUltimo" runat="server" Height="40px" ImageUrl="~/Images/btnFin.jpg" />
                </td>
                <td>
                    <%-- <asp:Button ID="btnExportarReportePDF" runat="server" 
                        onclick="btnExportarReportePDF_Click" Text="Exportar PDF" Width="119px" />--%>
                    <asp:ImageButton ID="btnExportarReportePDF" runat="server" ValidationGroup="Formulario"
                        onmouseover="~/Images/btnExportar_on.gif" onmouseout="~/Images/btnExportar.gif"
                        ImageUrl="~/Images/btnExportar.gif" />
                </td>
                <td>
                    <asp:ImageButton ID="btnImprimirReporte" runat="server" ValidationGroup="Formulario"
                        onmouseover="~/Images/btnImprimir_on.gif'" onmouseout="~/Images/btnImprimir.gif'"
                        ImageUrl="~/Images/btnImprimir.gif" />
                </td>
            </tr>
        </table>
        <br />
        <%--<div style="width:800px; height:400px; overflow:auto;">--%>
        <%--<asp:GridView ID="grvReporte" runat="server">
            </asp:GridView>--%>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" HasSearchButton="False"
            HasToggleGroupTreeButton="False" EnableDrillDown="False" ToolPanelView="None"
            Width="350px" DisplayToolbar="False" />
        <%--</div>--%>
    </div>
    </form>
</body>
</html>
