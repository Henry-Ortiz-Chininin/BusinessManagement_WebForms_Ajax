<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false"
    CodeFile="FGCOPCA.aspx.vb" Inherits="OPERACION_FGCOPCA" %>

<%@ Register TagPrefix="AVC" TagName="OrdenServicio" Src="~/Controles/REGISTRO/ctlOrdenServicio_Registrol.ascx" %>
<%@ Register TagPrefix="AVC" TagName="Cliente" Src="~/Controles/BUSQUEDA/ctlCliente_Buscar.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="divCuerpo">
        <div id="divHeader">
            ORDEN DE SERVICIO - LISTADO</div>
        <div class="Opciones">
            <table cellpadding="1" cellspacing="1" border="0">
                <tr>
                    <td>
                        <asp:ImageButton ID="btnNuevo" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'"
                            onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'"
                            onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'"
                            onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" />
                    </td>
                </tr>
            </table>
        </div>
        <table cellpadding="1" cellspacing="1" border="0" width="500px">
            <tr>
                <td class="Titulo12" width="115px">
                    Código:
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtCodigo" CssClass="Texto12" runat="server" Width="160"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Titulo12" width="115px">
                    Fecha Emision:
                </td>
                <td>
                    <asp:TextBox ID="txtFechaInicio" CssClass="Texto12" runat="server" Width="75px"></asp:TextBox>
                    <asp:CalendarExtender ID="clnFechaInicio" runat="server" TargetControlID="txtFechaInicio"
                        Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtFechaFinal" CssClass="Texto12" runat="server" Width="75px"></asp:TextBox>
                    <asp:CalendarExtender ID="clnFechaFinal" runat="server" TargetControlID="txtFechaFinal"
                        Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                </td>
                <td class="Titulo12">
                    Departamento
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlDepartamento" CssClass="Texto12" Width="150px">
                    </asp:DropDownList>
                </td>
                <td style="width: 100px;">
                </td>
            </tr>
            <tr>
                <td class="Titulo12">
                    Cliente:
                </td>
                <td colspan="5" style="margin-left: -10px;">
                    <AVC:Cliente runat="server" ID="ctlCliente" />
                </td>
            </tr>
            <tr>
                <td class="Titulo12">
                    Estado:
                </td>
                <td colspan="2">
                    <asp:DropDownList CssClass="Texto12" ID="ddlEstado" runat="server">
                        <asp:ListItem Value="">Todo</asp:ListItem>
                        <asp:ListItem Value="ACT">Activo</asp:ListItem>
                        <asp:ListItem Value="ANU">Anulado</asp:ListItem>
                        <asp:ListItem Value="TER">Terminado</asp:ListItem>
                        <asp:ListItem Value="CER">Cerrado</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 5px;">
                </td>
                <td class="Titulo12">
                    Tipo:
                </td>
                <td>
                    <asp:DropDownList CssClass="Texto12" ID="ddlTipo" runat="server">
                        <asp:ListItem Value="">Todo</asp:ListItem>
                        <asp:ListItem Value="MTC">Montacarga</asp:ListItem>
                        <asp:ListItem Value="GRA">Grua</asp:ListItem>
                        <asp:ListItem Value="STR">Semi trailer</asp:ListItem>
                        <asp:ListItem Value="TYG">Transporte y Grua</asp:ListItem>
                        <asp:ListItem Value="OPE">Operador</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <asp:GridView ID="grdDatos" Width="1200" ShowFooter="true" AutoGenerateColumns="false"
            runat="server" AllowPaging="true" PageSize="10">
            <Columns>
                <asp:BoundField DataField="IdOrdenServicio" HeaderText="Id OS" />
                <asp:BoundField DataField="IdDepartamento" HeaderText="IdCliente" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="Departamento" HeaderText="Departamento" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="IdCliente" HeaderText="IdCliente" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="RazonSocial" HeaderText="Cliente" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="LugarOperacion" HeaderText="Lugar" />
                <asp:BoundField DataField="TrabaSolicitante" HeaderText="Solicitado por" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono">
                    <ItemStyle Width="30px" />
                </asp:BoundField>
                <asp:BoundField DataField="TrabajoEfectuado" HeaderText="Trabajo efectuado" />
                <asp:BoundField DataField="Operador" HeaderText="Operador" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="Riger" HeaderText="Riger" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="Ayudante" HeaderText="Ayudante" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="FechaEmision" HeaderText="Fecha Emisión" DataFormatString="{0:dd/MM/yyyy}">
                    <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="HoraSalidaBase" HeaderText="Salida Base" DataFormatString="{0:00:00}">
                    <ItemStyle Width="30px" />
                </asp:BoundField>
                <asp:BoundField DataField="HoraLlegadaObra" HeaderText="Llegada Obra" DataFormatString="{0:00:00}">
                    <ItemStyle Width="30px" />
                </asp:BoundField>
                <asp:BoundField DataField="HoraInicioOperacion" HeaderText="Inicio Oper." DataFormatString="{0:00:00}">
                    <ItemStyle Width="30px" />
                </asp:BoundField>
                <asp:BoundField DataField="HoraTerminoOperacion" HeaderText="Termino Oper." DataFormatString="{0:00:00}">
                    <ItemStyle Width="30px" />
                </asp:BoundField>
                <asp:BoundField DataField="HoraSalidaObra" HeaderText="Salida Obra" DataFormatString="{0:00:00}">
                    <ItemStyle Width="30px" />
                </asp:BoundField>
                <asp:BoundField DataField="HoraLlegadaBase" HeaderText="Llegada Base" DataFormatString="{0:00:00}">
                    <ItemStyle Width="30px" />
                </asp:BoundField>
                <asp:BoundField DataField="TarifaHora" HeaderText="Tarifa" DataFormatString="{0:#,##0.0000}"
                    ItemStyle-HorizontalAlign="Right">
                    <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="ImporteTotal" HeaderText="Total Facturar" DataFormatString="{0:#,##0.0000}"
                    ItemStyle-HorizontalAlign="Right">
                    <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="IdMoneda" HeaderText="Id Moneda" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="Moneda" HeaderText="Moneda">
                    <ItemStyle Width="30px" />
                </asp:BoundField>
                <asp:BoundField DataField="IdTipoServicio" HeaderText="Id Tipo Servicio" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="TipoServicio" HeaderText="Tipo Servicio" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="Estado" HeaderText="Estado">
                    <ItemStyle Width="30px" />
                </asp:BoundField>
                <asp:BoundField DataField="Placa_Grua" HeaderText="Placa" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="Observacion" HeaderText="Observacion" HeaderStyle-CssClass="NoVisible"
                    ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:TemplateField ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <nobr>
                            <asp:Button ID="btnEliminar" CssClass="Boton" CommandName="ELIMINAR" CommandArgument='<%#Container.DataItemIndex %>'
                                runat="server" Text="Eliminar" />
                            <asp:Button ID="btnEditar" CssClass="Boton" CommandName="MODIFICAR" CommandArgument='<%#Container.DataItemIndex %>'
                                runat="server" Text="Editar" />
                        </nobr>
                            <asp:Button ID="btnImprimir" CssClass="Boton" CommandName="IMPRIMIR" CommandArgument='<%#Container.DataItemIndex %>'
                                runat="server" Text="Imprimir" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="GridHeader" />
            <FooterStyle CssClass="GridFooter" />
            <AlternatingRowStyle CssClass="GridAltItem" />
            <RowStyle CssClass="GridItem" />
        </asp:GridView>
        <asp:Panel ID="pnlFormulario" CssClass="Formulario" runat="server">
            <AVC:OrdenServicio runat="server" ID="ctlOrdenServicio"></AVC:OrdenServicio>
        </asp:Panel>
    </div>
</asp:Content>
