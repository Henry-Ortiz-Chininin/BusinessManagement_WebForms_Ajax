<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGLREAA.aspx.vb" Inherits="Reportes_FGLREAA" %>

<%@ Register src="../Controles/ctlSolicitante_Buscar.ascx" tagname="ctlSolicitante_Buscar" tagprefix="uc1" %>
<%@ Register src="../Controles/ctlProyecto_Buscar.ascx" tagname="ctlProyecto_Buscar" tagprefix="uc1" %>
<%@ Register src="../Controles/ctlCentroCosto_Buscar.ascx" tagname="ctlCentroCosto_Buscar" tagprefix="uc1" %>
<%@ Register src="../Controles/ctlCargo_Buscar.ascx" tagname="ctlCargo_Buscar" tagprefix="uc2" %>
<%@ Register Src="~/Controles/ctlValidacion_Registro.ascx" TagName="ValidadorRegistro" TagPrefix="UC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="divCuerpo">
<div id="divHeader">REPORTE SEGUIMIENTO DE REQUISICIONES</div>

<div id="divOpciones">
<table cellpadding="0" cellspacing="1" border="0"> 
    <tr>
    <td><asp:ImageButton ID="btnGenerar" runat="server" onmouseover="this.src='../images/btnGenerar_on.gif'" onmouseout="this.src='../images/btnGenerar.gif'" ImageUrl="../images/btnGenerar.gif" /></td>
    <td><asp:ImageButton ID="btnBuscar"  Visible ="false" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'" onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
   </tr>
    </table>
</div> 
<table cellpadding="1" border="0">
    <tr>
        <td>
        <table cellpadding="0" cellspacing="0" border="0" width="400">
            <tr>
                 <td class="Titulo12">tipo</td>
                 <td>
                     <asp:RadioButtonList CssClass="Texto" RepeatDirection="Horizontal" ID="rbtTipo" runat="server">
                     <asp:ListItem Text="Compra" Value="C"></asp:ListItem>
                     <asp:ListItem Text="Servicio" Value="S"></asp:ListItem>
                     </asp:RadioButtonList>
                </td> 
            </tr>
            <tr>
                <td class="Titulo12">Codigo</td>
                <td>
                    <asp:TextBox ID="txtCodigo" CssClass="Texto12" runat="server" Width="200px"></asp:TextBox>
                </td> 
                <td></td>
            </tr> 
            <tr>
                <td  class="Titulo12">Fecha Emision</td>
                <td><asp:TextBox ID="txtFechaEmisionInicio" Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                <asp:Image ID="btnFechaEmisionInicio" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
            </tr>
            <tr>
                <td  class="Titulo12" visible ="false"> </td>
                <td><asp:TextBox ID="txtFechaEmisionFinal"  Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                <asp:Image ID="btnFechaEmisionFinal" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
            </tr>
            <tr>
                <td  class="Titulo12">Fecha Recepcion</td>
                <td><asp:TextBox ID="txtFechaRecepcionInicio" Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                <asp:Image ID="btnFechaRecepcionInicio" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
            </tr>
            <tr>
                <td  class="Titulo12" visible ="false"></td>
                <td><asp:TextBox ID="txtFechaRecepcionFinal"  Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                <asp:Image ID="btnFechaRecepcionFinal" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
            </tr>
            <tr>
                <td  class="Titulo12">Fecha Plazo</td>
                <td><asp:TextBox ID="txtFechaPlazoInicio" Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                <asp:Image ID="btnFechaPlazoInicio" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
            </tr>
            <tr>
                <td  class="Titulo12" visible ="false"></td>
                <td><asp:TextBox ID="txtFechaPlazoFinal"  Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                <asp:Image ID="btnFechaPlazoFinal" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <table cellpadding="1" border="0">
                        <tr>
                            <td class="Titulo12">Abierto</td>
                            <td>
                                <asp:CheckBox ID="chkAbierto" runat="server" >
                                </asp:CheckBox>
                            </td>
                            <td class="Titulo12">Aprobado</td>
                            <td>
                            <asp:CheckBox ID="chkAprobado" runat="server" >
                            </asp:CheckBox>
                            </td> 
                            <td class="Titulo12">Cerrado</td>
                            <td>
                              <asp:CheckBox ID="chkCerrado" runat="server" >
                               </asp:CheckBox>
                            </td> 
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        </td>
        <td>
            <uc1:ctlSolicitante_Buscar ID="ctlSolicitante_Buscar1" runat="server" />
            <br />
            <uc2:ctlCargo_Buscar ID="ctlCargo_Buscar1" runat="server" />
        </td>
        <td>
            <uc1:ctlProyecto_Buscar ID="ctlProyecto_Buscar1" runat="server" />
            <br />
            <uc1:ctlCentroCosto_Buscar ID="ctlCentroCosto_Buscar1" runat="server" />
        </td>
    </tr>
</table>

</div>

</asp:Content>

