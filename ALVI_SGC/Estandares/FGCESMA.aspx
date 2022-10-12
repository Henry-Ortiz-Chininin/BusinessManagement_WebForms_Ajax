<%@ Page Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCESMA.aspx.vb" Inherits="Estandares_FGCESMA" title="Sistema de Gestión de Costos - Alta Visión Consultores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script language="javascript" type="text/javascript">
    function SetParticion(IdParticion, strOP) {
        var objParticion = document.getElementById(IdParticion);
        objParticion.value = "0";
        objParticion.value = prompt("Ingrese el número de particiones para la orden " + strOP, "0");
        if (objParticion.value != "0")
        { return true; }
        return false;
    } 
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="divCuerpo">
<div id="divHeader">Mantenimiento de Impuestos - Lista</div>
<div id="divOpciones">
<table cellpadding="0" cellspacing="1" border="0">
<tr>
<td>
<table>
    <tr> 
    <td><asp:ImageButton ID="btnNuevo" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'" onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
    <td><asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'" onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" /></td>
   </tr>
</table>
</td></tr><tr>
<td colspan = "3">
<table>
<tr>
<td class="Titulo12"> Fecha Inicio</td>
<td>
<nobr>
<asp:TextBox ID="txtFechaInicio" Width="80" runat = "server" ></asp:TextBox>
<asp:Image ID="btnFechaInicio" runat="server" ImageUrl="~/Images/im_calendar.gif"/>
</nobr>
</td>
<td class="Titulo12"> Fecha Fin</td>
<td>
<nobr>
<asp:TextBox ID = "txtFechaFin" Width="80" runat = "server"></asp:TextBox>
<asp:Image ID="btnFechaFin" runat="server" ImageUrl="~/Images/im_calendar.gif"/>
</nobr> 
</td>
<td class="Titulo12"> Tipo Busqueda</td> 
<td><asp:DropDownList Id = "ddlTipo" runat = "server">
<asp:ListItem Value =""  class="Titulo12"> Creacion</asp:ListItem>
<asp:ListItem Value = "1" class="Titulo12">Vencimiento</asp:ListItem>
</asp:DropDownList> 
</td> 
</tr> 
</table>
</td>
</tr>
    </table>
</div>
    <asp:GridView ID="grdDatos" Width="800" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>
    <asp:BoundField DataField="int_Secuencia" HeaderText="Codigo"/>
    <asp:BoundField DataField="num_Impuesto1" HeaderText="IGV" DataFormatString="{0:#,##0.0000}"/>
    <asp:BoundField DataField="num_Impuesto2" HeaderText="Impuesto2" DataFormatString="{0:#,##0.0000}" />
    <asp:BoundField DataField="num_Impuesto3" HeaderText="Impuesto3" DataFormatString="{0:#,##0.0000}" />
    <asp:BoundField DataField="num_Percepcion" HeaderText="Percepcion" DataFormatString="{0:#,##0.0000}"/>
    <asp:BoundField DataField="num_Retencion" HeaderText="Retencion" DataFormatString="{0:#,##0.0000}"/>
    <asp:BoundField DataField="num_Detraccion" HeaderText="Detracción" DataFormatString="{0:#,##0.0000}"/> 
    <asp:BoundField DataField="chr_Estado" HeaderText="Estado"/>
    <asp:BoundField DataField="dtm_FechaVencimiento" HeaderText="Fecha Vigencia"  DataFormatString="{0:dd/MM/yyyy}"/>
    <asp:TemplateField>
    <ItemTemplate>
        <asp:ImageButton ID="btnModificar" CommandArgument='<%#Container.DataItem("int_Secuencia") %>' CommandName="Modificar" ImageUrl="../images/btnAbrir.gif" runat="server" onmouseover="this.src='../images/btnAbrir_on.gif'" onmouseout="this.src='../images/btnAbrir.gif'" />
    </ItemTemplate>
    <ItemStyle Width="50"/>
    </asp:TemplateField>
    <asp:TemplateField>
    <ItemTemplate>
        <asp:ImageButton ID="btnEliminar" CommandArgument='<%#Container.DataItem("int_Secuencia") %>' CommandName="Eliminar" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
    </ItemTemplate>
    <ItemStyle Width="50" />
    </asp:TemplateField>
    </Columns>
    <HeaderStyle CssClass="GridHeader" />
    <FooterStyle CssClass="GridFooter" />
    <AlternatingRowStyle CssClass="GridAltItem" />
    <RowStyle CssClass="GridItem" />
    </asp:GridView>
    <asp:Panel ID="pnlFormulario" CssClass="Formulario" runat="server">
    <div id="divTitulo">Registro - Proceso</div>
    <table cellpadding="1" cellspacing="1" border="0" width="400" align="center" valign="middle">
    <tr>
        <td class="Titulo12">Codigo</td>
        <td>
            <asp:TextBox CssClass="Texto12" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" ID="txtCodigo" runat="server" Width = "150"></asp:TextBox></td>
    </tr> 
    <tr>
        <td class="Titulo12">IGV %</td> 
        <td > 
            <asp:TextBox CssClass="Texto12" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" ID="txtImpuesto1" runat="server" Width = "150"></asp:TextBox></td>
    </tr>
    <tr> 
        <td class="Titulo12">Impuesto2</td>
        <td>
            <asp:TextBox ID="txtImpuesto2" MaxLength="200" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server" Width = "150"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="Titulo12">Impuesto3</td>
        <td>
            <asp:TextBox ID="txtImpuesto3" MaxLength="5" onChange="validadigito(this,'NUM');" onKeypress="return Valida(event, 'NUM');" CssClass="Texto12" runat="server" Width = "150"></asp:TextBox></td>
    </tr>
        <tr>
        <td class="Titulo12">Percepcion</td>
        <td>
            <asp:TextBox ID="txtPercepcion" MaxLength="5" onChange="validadigito(this,'NUM');" onKeypress="return Valida(event, 'NUM');" CssClass="Texto12" runat="server" Width = "150"></asp:TextBox></td>
    </tr>
        <tr>
        <td class="Titulo12">Retencion</td>
        <td>
            <asp:TextBox ID="txtRetencion" MaxLength="5" onChange="validadigito(this,'NUM');" onKeypress="return Valida(event, 'NUM');" CssClass="Texto12" runat="server" Width = "150"></asp:TextBox></td>
    </tr>
            <tr>
        <td class="Titulo12">Detracción</td>
        <td>
            <asp:TextBox ID="txtdetraccion" MaxLength="5" onChange="validadigito(this,'NUM');" onKeypress="return Valida(event, 'NUM');" CssClass="Texto12" runat="server" Width = "150"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="Titulo12">Estado</td>
        <td>
            <asp:DropDownList ID="ddlEstado" CssClass="texto12" runat ="server">
            <asp:ListItem value = "ACT">Activo</asp:ListItem>
            <asp:ListItem value = "DES">Inactivo</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr> 
                <tr>
        <td class="Titulo12">Fecha de Caducidad</td>
        <td>
        <nobr> 
            <asp:TextBox ID="txtFechaCaducidad" onChange="validadigito(this,'NUM');" onKeypress="return Valida(event, 'NUM');" CssClass="Texto12" runat="server" Width = "150"></asp:TextBox>
        <asp:Image ID="btnFechaCaducidad" runat="server" ImageUrl="~/Images/im_calendar.gif"/>
</nobr> 
</td> 
    </tr> 
    <tr> 
    <td colspan="2"> 
        <asp:ImageButton ID="btnRegistrar" CssClass="Boton" onmouseover="this.src='../images/btnRegistrar_on.gif';" onmouseout="this.src='../images/btnRegistrar.gif';" ImageUrl="../images/btnRegistrar.gif" runat="server" />
        <asp:ImageButton ID="btnCancelar" CssClass="Boton" onmouseover="this.src='../images/btnCancelar_on.gif';" onmouseout="this.src='../images/btnCancelar.gif';" ImageUrl="../images/btnCancelar.gif" runat="server" />
    </td>
    </tr>
    </table>
    <div id="divFooter">
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>&nbsp;</div>    
    </asp:Panel>
</div>
</asp:Content>

