<%@ Page Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCREBC.aspx.vb" Inherits="Reportes_FGCREBC" title="Página sin título" %>
<%@ Register TagName="ctlArticulo" TagPrefix="ART" Src="~/Controles/ctlArticulo_Buscar.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">Reporte de Stock</div>
<div id="divOpciones">
<table cellpadding="0" cellspacing="1" border="0">
    <tr>
    <td><asp:ImageButton ID="btnGenerar" runat="server" onmouseover="this.src='../images/btnGenerar_on.gif'" onmouseout="this.src='../images/btnGenerar.gif'" ImageUrl="../images/btnGenerar.gif" /></td>
    <td><asp:ImageButton ID="btnExportar" runat="server" onmouseover="this.src='../images/btnExportar_on.gif'" onmouseout="this.src='../images/btnExportar.gif'" ImageUrl="../images/btnExportar.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
    </tr>
    </table>
</div>    
    <table cellpadding="1" cellspacing="1" border="0">
        <tr>
            <td class="Titulo12">Tipo de reporte</td>
            <td>
                <asp:DropDownList ID="ddlTipoReporte" runat="server">
                    <asp:ListItem Value="">Seleccionar</asp:ListItem>
                    <asp:ListItem Value="DE">Detallado por Familia/SubFamilia</asp:ListItem>
                    <asp:ListItem Value="RF">Resumido por Familia</asp:ListItem>
                    <asp:ListItem Value="RS">Resumido por Sub-Familia</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="Titulo12">Fecha de corte</td>
            <td><nobr>
                <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>&nbsp;
                <asp:Image ID="btnFecha" runat="server" ImageUrl="~/Images/im_calendar.gif" />
                </nobr>
            </td>        
        </tr>
        <tr>
            <td class="Titulo12">Familia</td>
            <td>
                <asp:DropDownList ID="ddlFamilia" AutoPostBack="true" CssClass="Texto12" runat="server">
                </asp:DropDownList>
            </td>        
        </tr>
        <tr>
            <td class="Titulo12">Sub-Familia</td>
            <td><asp:UpdatePanel ID="upnSubFamilia" runat="server">
                        <ContentTemplate>
                <asp:DropDownList ID="ddlSubFamilia" AutoPostBack="true" CssClass="Texto12" runat="server">
                </asp:DropDownList>
                </ContentTemplate>
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlFamilia" EventName="SelectedIndexChanged" />
                </Triggers> 
                </asp:UpdatePanel>
            </td>        
        </tr>
        
        <tr>
            <td class="Titulo12">Atributo</td>
            <td><asp:UpdatePanel ID="upnAtributoTipo" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="ddlAtributoTipo" AutoPostBack="true" CssClass="Texto12" runat="server">
                </asp:DropDownList>
                </ContentTemplate>
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlSubFamilia" EventName="SelectedIndexChanged" />
                </Triggers> 
                </asp:UpdatePanel>
            </td>        
        </tr>    
        <tr>
            <td class="Titulo12">Valor</td>
            <td><asp:UpdatePanel ID="upnAtributoValor" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="ddlAtributoValor" CssClass="Texto12" runat="server">
                </asp:DropDownList>
                </ContentTemplate>
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlAtributoTipo" EventName="SelectedIndexChanged" />
                </Triggers> 
                </asp:UpdatePanel>
            </td>        
        </tr>
        <tr>
            <td class="Titulo12">Personalizado: </td>
            <td>
                <asp:TextBox ID="txtCriterio" runat="server"></asp:TextBox>
            </td>        
        </tr>        
        <tr>
            <td class="Titulo12" colspan="2"><hr /><br />Articulo<br /><hr /></td>
        </tr>
        <tr>
            <td colspan="2">
            <ART:ctlArticulo ID="ctlArticulo1" runat="server" />            
            </td>
        </tr>

    </table>
</div>
</asp:Content>

