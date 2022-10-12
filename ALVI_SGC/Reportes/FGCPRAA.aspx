<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FGCPRAA.aspx.vb" Inherits="Reportes_FGCPRAA" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" media="screen" href="../CSS/scrOrdenServicio.css" />
    <link rel="Stylesheet" media="print" href="../CSS/prnOrdenServicio.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="Impresion">
        <asp:Label ID="lblNumero" CssClass="Numero" runat="server" Text=""></asp:Label>
        <div class="Fecha">
            <asp:Label ID="lblDia" CssClass="Dia" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblMes" CssClass="Mes" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblAgno" CssClass="Agno" runat="server" Text=""></asp:Label>
        </div>
        <asp:Label ID="lblCliente" CssClass="Cliente" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblRUC" CssClass="RUC" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblLugar" CssClass="Lugar" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblSolicitado" CssClass="Solicitado" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblEfectuado" CssClass="Efectuado" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblResponsable" CssClass="Responsable" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblTelefono" CssClass="Telefono" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblDireccion" CssClass="Direccion" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblDNI" CssClass="DNI" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblSalida" CssClass="Salida" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblLlegada" CssClass="Llegada" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblTermino" CssClass="Termino" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblRegreso" CssClass="Regreso" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblTotalHora" CssClass="TotalHora" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblTarifa" CssClass="Tarifa" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblTotalSoles" CssClass="TotalSoles" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblHoras" CssClass="Horas" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblTotal" CssClass="Total" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblOpcion1" CssClass="Opcion1" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblOpcion2" CssClass="Opcion2" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblOpcion3" CssClass="Opcion3" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblOpcion4" CssClass="Opcion4" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblOpcion5" CssClass="Opcion5" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblObservacion" CssClass="Observacion" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
