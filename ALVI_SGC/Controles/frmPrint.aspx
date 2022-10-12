<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmPrint.aspx.vb" Inherits="Controles_frmPrint" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sistema de Gestión de Costos - Alta Visión Consultores</title>
    <link href="../css/General.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="divImprimir">
    <div><p class="Titulo"><asp:Label ID="lblTitulo" runat="server"></asp:Label></p></div>
    <p class="Titulo12"><asp:Label ID="lblDatos" runat="server"></asp:Label></p>
    <asp:Literal runat="server" ID="Contenido"></asp:Literal>
    </div>
    </form>
    <script type="text/javascript" language="javascript">
    window.print();
    </script>
</body>
</html>
