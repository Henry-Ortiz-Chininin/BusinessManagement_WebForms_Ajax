<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCREGA.aspx.vb" Inherits="Reportes_FGCREGA" %>
<%@ Register TagName="ctlAvance" TagPrefix="UC" Src="~/Controles/ctlAvanceOP.ascx" %>
<%@ Register TagPrefix="UC" TagName="ctlCliente" Src="~/Controles/ctlCliente_Buscar.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">Reporte De Paros De Produccion</div>
<div id="divOpciones">
<table cellpadding="0" cellspacing="1" border="0">
    <tr>
    <td><asp:ImageButton ID="btnGenerar" runat="server" onmouseover="this.src='../images/btnGenerar_on.gif'" onmouseout="this.src='../images/btnGenerar.gif'" ImageUrl="../images/btnGenerar.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
    </tr>
    </table>
</div>
    <table cellpadding="1" cellspacing="1" border="0" width="500">
        <tr>
            <td class="Titulo12" width="150">Fecha Inicio:</td>
            <td><nobr>
                <asp:TextBox ID="txtFechaInicio" runat="server"></asp:TextBox>&nbsp;
                <asp:Image ID="btnFechaInicio" runat="server" ImageUrl="~/Images/im_calendar.gif" />
                </nobr>
            </td>        
        </tr>
        <tr>
            <td class="Titulo12">Fecha Fin:</td>
            <td><nobr>
                <asp:TextBox ID="txtFechaFinal" runat="server"></asp:TextBox>&nbsp;
                <asp:Image ID="btnFechaFinal" runat="server" ImageUrl="~/Images/im_calendar.gif" />
                </nobr>
            </td>        
        </tr>
        <tr>
            <td class="Titulo12">Maquina:</td>
            <td><asp:DropDownList ID="ddlMaquina" runat="server">
            </asp:DropDownList>
            </td>        
        </tr>
        </table>
    <asp:GridView ID="grdDatos" Width="1000"  ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>
    <asp:BoundField DataField="var_idMaquina" HeaderText="Codigo Maquina" />
    <asp:BoundField DataField="var_Descripcion" HeaderText="Maquina" />
    <asp:BoundField DataField="var_DesMotivo" HeaderText="Motivo de Paro" />
    <asp:BoundField DataFormatString="{0:dd/MM/yyyy}" DataField="dtm_FechaInicio" HeaderText="Fecha de Inicio" />
    <asp:BoundField DataFormatString="{0:HH:mm}" DataField="dtm_FechaInicio" HeaderText="Hora de Inicio" />
    <asp:BoundField DataFormatString="{0:dd/MM/yyyy}" DataField="dtm_FechaFinal" HeaderText="Fecha Fin" />
    <asp:BoundField DataFormatString="{0:HH:mm}" DataField="dtm_FechaFinal" HeaderText="Hora Fin" />
    <asp:BoundField DataField="var_FechaDuracion" HeaderText="Total Horas" />
    </Columns>
    <HeaderStyle CssClass="GridHeader" />
    <FooterStyle CssClass="GridFooter" />
    <AlternatingRowStyle CssClass="GridAltItem" />
    <RowStyle CssClass="GridItem" />
    </asp:GridView>
</div>
</asp:Content>

