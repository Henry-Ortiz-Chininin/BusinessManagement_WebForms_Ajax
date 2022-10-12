<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlOrdenServicio_Registrol.ascx.vb"
    Inherits="Controles_REGISTRO_ctlOrdenServicio_Registrol" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<%@ Register TagPrefix="AVC" TagName="Cliente" Src="~/Controles/BUSQUEDA/ctlCliente_Buscar.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div class="Titulo">
    REGISTRO ORDEN DE SERVICIO</div>
<table cellpadding="2" cellspacing="1" border="0" width="600px">
    <tr>
        <td width="115px" class="Titulo12">
            Código:
        </td>
        <td>
            <asp:TextBox ID="txtCodigo" CssClass="Texto12" runat="server" Width="124px" ReadOnly="true" BackColor="LightGray"></asp:TextBox>
        </td>
        <td style="width: 5px;">
        </td>
        <td class="Titulo12">
            Fecha Emisión:
        </td>
        <td>
            <asp:TextBox ID="txtFecha" CssClass="Texto12" runat="server" Width="75px" Enabled="false"></asp:TextBox>
            <asp:Image ImageUrl="~/images/im_calendar.gif" runat="server" ID="imgFecha" />
            <asp:CalendarExtender ID="clnFecha" runat="server" PopupButtonID="imgFecha" TargetControlID="txtFecha"
                Format="dd/MM/yyyy">
            </asp:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">
            Departamento
        </td>
        <td>
            <asp:DropDownList runat="server" ID="ddlDepartamento" CssClass="Texto12" Width="130px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="Titulo12" style="margin-right: -10px;">
            Cliente:
        </td>
        <td colspan="4" style="margin-left: -10px;">
            <AVC:Cliente runat="server" ID="ctlCliente" />
        </td>
    </tr>
    <tr>
        <td class="Titulo12">
            Lugar de operación:
        </td>
        <td colspan="4">
            <asp:TextBox ID="txtLugarOperacion" CssClass="Texto12" runat="server" Width="450px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">
            Trab. Solicitado por:
        </td>
        <td colspan="4">
            <asp:TextBox ID="txtTrabSolicitado" CssClass="Texto12" runat="server" Width="450px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">
            Telefono:
        </td>
        <td>
            <asp:TextBox ID="txtTelefono" CssClass="Texto12" runat="server" Width="124px" onChange="validadigito(this,'NUM');"
                onKeypress="return Valida(event, 'NUM');"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">
            Trab. efectuado:
        </td>
        <td colspan="4">
            <asp:TextBox ID="txtTrabEfectuado" CssClass="Texto12" runat="server" Width="450px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">
            Operador:
        </td>
        <td colspan="4">
            <asp:TextBox ID="txtOperador" CssClass="Texto12" runat="server" Width="450px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">
            Riger:
        </td>
        <td colspan="4">
            <asp:TextBox ID="txtRiger" CssClass="Texto12" runat="server" Width="450px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">
            Ayudante:
        </td>
        <td colspan="4">
            <asp:TextBox ID="txtAyudante" CssClass="Texto12" runat="server" Width="450px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <%--<td style="width: 5px; text-align: right;" colspan="2">
            <asp:Button Visible="false" runat="server" ID="btnCalcularTiempo" Text="Calcular" ToolTip="Click para calcular los tiempos y el Total a Pagar" />
        </td>--%>
        <td class="Titulo12">
            Moneda
        </td>
        <td>
            <asp:DropDownList runat="server" ID="ddlMoneda" CssClass="Texto12" Width="145px">
            </asp:DropDownList>
        </td>
        <td style="width: 5px;">
        </td>
        <td class="Titulo12">
            Tipo Pago:
        </td>
        <td>
            <asp:UpdatePanel ID="UpnTipoPago" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlTipoPago" runat="server" Width="145px">
                        <asp:ListItem Value="0">Mas IGV</asp:ListItem>
                        <asp:ListItem Value="1">Inc.IGV</asp:ListItem>
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">
            Tipo Servicio:
        </td>
        <td>
            <asp:DropDownList CssClass="Texto12" ID="ddlTipoServicio" runat="server" Width="145px">
                <asp:ListItem Value="">Seleccionar</asp:ListItem>
                <asp:ListItem Value="MTC">Montacarga</asp:ListItem>
                <asp:ListItem Value="GRA">Grua</asp:ListItem>
                <asp:ListItem Value="STR">Semi trailer</asp:ListItem>
                <asp:ListItem Value="TYG">Transporte y Grua</asp:ListItem>
                <asp:ListItem Value="OPE">Operador</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td style="width: 5px;">
        </td>
        <td class="Titulo12">
            Estado:
        </td>
        <td>
            <asp:DropDownList CssClass="Texto12" ID="ddlEstado" runat="server" Width="145px">
                <asp:ListItem Value="">Seleccionar</asp:ListItem>
                <asp:ListItem Value="ACT">Activo</asp:ListItem>
                <asp:ListItem Value="ANU">Anulado</asp:ListItem>
                <asp:ListItem Value="TER">Terminado</asp:ListItem>
                <asp:ListItem Value="CER">Cerrado</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">
            Placa Grua
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtPlacaGrua" CssClass="Texto12" Width="140px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="5">
            <hr />
        </td>
    </tr>
    <tr>
        <td class="Titulo12">
            Salida de Base:
        </td>
        <td>
            <MKB:TimeSelector ID="timSalidaBase" runat="server" CssClass="Texto12" SelectedTimeFormat="TwentyFour">
            </MKB:TimeSelector>
        </td>
        <td style="width: 5px;">
        </td>
        <td class="Titulo12">
            Llegada Obra:
        </td>
        <td>
            <MKB:TimeSelector ID="timLlegadaObra" runat="server" CssClass="Texto12" SelectedTimeFormat="TwentyFour">
            </MKB:TimeSelector>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">
            Inicio Operación:
        </td>
        <td>
            <MKB:TimeSelector ID="timInicioOperacion" runat="server" CssClass="Texto12" SelectedTimeFormat="TwentyFour">
            </MKB:TimeSelector>
        </td>
        <td style="width: 5px;">
        </td>
        <td class="Titulo12">
            Termino Operación:
        </td>
        <td>
            <MKB:TimeSelector ID="timTerminoOperacion" runat="server" CssClass="Texto12" SelectedTimeFormat="TwentyFour">
            </MKB:TimeSelector>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">
            Salio Obra:
        </td>
        <td>
            <MKB:TimeSelector ID="timSalidaObra" runat="server" CssClass="Texto12" SelectedTimeFormat="TwentyFour">
            </MKB:TimeSelector>
        </td>
        <td style="width: 5px;">
        </td>
        <td class="Titulo12">
            Llegada Base:
        </td>
        <td>
            <MKB:TimeSelector ID="timLlegoBase" runat="server" CssClass="Texto12" SelectedTimeFormat="TwentyFour">
            </MKB:TimeSelector>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">
            Tiempo Recorrido:
        </td>
        <td>
            <asp:UpdatePanel runat="server" ID="upnTiempoRecorrido">
                <ContentTemplate>
                    <asp:TextBox runat="server" ID="txtTiempoRecorrido" CssClass="Texto12" ReadOnly="true"
                        BackColor="LightGray" Width="140px"></asp:TextBox>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="txtTarifa" EventName="TextChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </td>
        <td style="width: 5px;">
        </td>
        <td class="Titulo12">
            Tiempo Trabajado:
        </td>
        <td>
            <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                <ContentTemplate>
                    <asp:TextBox runat="server" ID="txtTiempoTrabajo" CssClass="Texto12" ReadOnly="true"
                        BackColor="LightGray" Width="140px"></asp:TextBox>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="txtTarifa" EventName="TextChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">
            Tiempo Total a Facturar:
        </td>
        <td>
            <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                <ContentTemplate>
                    <asp:TextBox runat="server" ID="txtTiempoTotal" CssClass="Texto12" ReadOnly="true"
                        BackColor="LightGray" Width="140px"></asp:TextBox>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="txtTarifa" EventName="TextChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </td>
        <td style="width: 5px;">
        </td>
        <td class="Titulo12">
            Tarifa (x Hora):
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtTarifa" CssClass="Texto12" ToolTip="Tarifa por hora"
                onChange="validadigito(this,'NUM');" onKeypress="return Valida(event, 'NUM');"
                placeHolder="Tarifa por hora" Width="140px" AutoPostBack="true"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2">
        </td>
        <td style="width: 5px;">
        </td>
        <td class="Titulo12">
            Total Facturar:
        </td>
        <td>
            <asp:UpdatePanel runat="server" ID="UpdatePanel4">
                <ContentTemplate>
                    <asp:TextBox runat="server" ID="txtTotalFacturar" CssClass="Texto12" ToolTip="Total Facturar"
                        ReadOnly="true" BackColor="LightGray" Width="140px"></asp:TextBox>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="txtTarifa" EventName="TextChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td colspan="5">
            <hr />
        </td>
    </tr>
    <tr>
        <td class="Titulo12">
            Observación:
        </td>
        <td colspan="4">
            <asp:TextBox runat="server" ID="txtObservacion" CssClass="Texto12" ToolTip="Total"
                TextMode="MultiLine" Height="50px" Width="450px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <asp:UpdatePanel runat="server" ID="upnMensaje">
                <ContentTemplate>
                    <asp:Label runat="server" ID="lblMensaje" CssClass="Texto"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
<div id="Opciones">
    <table cellpadding="1" cellspacing="1" border="0" style="background-color: White;">
        <tr>
            <td style="width: 115px;">
            </td>
            <td>
                <asp:ImageButton ID="btnTerminar" runat="server" CssClass="Boton" ImageUrl="~/images/btnRegistroCierre.gif"
                    onmouseout="this.src='../images/btnRegistroCierre.gif';" onmouseover="this.src='../images/btnRegistroCierre_on.gif';" />
            </td>
            <td>
                <asp:ImageButton ID="btnRegistrar" runat="server" CssClass="Boton" ImageUrl="~/images/btnRegistrar.gif"
                    onmouseout="this.src='../images/btnRegistrar.gif';" onmouseover="this.src='../images/btnRegistrar_on.gif';" />
            </td>
            <td>
                <asp:ImageButton ID="btnCerrar" runat="server" CssClass="Boton" ImageUrl="~/images/btnCancelar.gif"
                    onmouseout="this.src='../images/btnCancelar.gif';" onmouseover="this.src='../images/btnCancelar_on.gif';" />
            </td>
        </tr>
    </table>
</div>
