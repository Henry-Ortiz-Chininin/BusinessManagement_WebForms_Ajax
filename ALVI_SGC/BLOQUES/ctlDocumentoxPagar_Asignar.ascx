<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlDocumentoxPagar_Asignar.ascx.vb" Inherits="BLOQUES_ctlDocumentoxPagar_Asignar" %>
<%@ Register TagPrefix="AVC" TagName="Proveedor" Src="~/Controles/ctlProveedor_Buscar.ascx" %>
<div id="divTitulo">Ingreso de Documentos</div>
<asp:UpdatePanel runat="server" ID="upnFormulario">
    <ContentTemplate>
        <table cellpadding="2" cellspacing="2" border="0" width="700" >
            <tr>
            <td class="Titulo12" width="150">Tipo Documento</td>
            <td>
                <asp:DropDownList ID="ddlTipoDocumento" runat="server">
                </asp:DropDownList>
            </td>
            <td rowspan="4" valign="top">
                <AVC:Proveedor ID="ctlProveedor" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="Titulo12">Número de documento</td>
            <td><asp:TextBox ID="txtNumeroDocumento" MaxLength="20" onChange="validadigito(this,'TEL');" onKeypress="return Valida(event, 'TEL');" CssClass="Texto12" runat="server"></asp:TextBox></td>
        </tr>  
        <tr>
            <td class="Titulo12">Fecha de Documento</td>
            <td>
                <asp:TextBox ID="txtFecha" Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                <asp:Image ID="btnFecha" runat="server" ImageUrl="~/Images/im_calendar.gif" />
            </td>
        </tr>
        <tr>
            <td class="Titulo12">Importe</td>
            <td><asp:TextBox ID="txtImporte" MaxLength="500" onChange="validadigito(this,'NUM');" onKeypress="return Valida(event, 'NUM');" CssClass="Texto12" runat="server"></asp:TextBox></td>
        </tr>     
    </table>
    <asp:GridView ID="grdDocumento" Width="600"  ShowFooter="true" 
                runat="server" AutoGenerateColumns="false" 
                align ="center" ViewStateMode="Enabled" >
        <Columns>
            <asp:BoundField DataField="chr_IdTipoDocumento" HeaderText="IDT" HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
            <asp:BoundField DataField="var_TipoDocumento" HeaderText="Documento" />
            <asp:BoundField DataField="var_NumeroDocumento" HeaderText="Numero" />
            <asp:BoundField DataField="var_IdProveedor" HeaderText="RUC" />
            <asp:BoundField DataField="var_RazonSocial" HeaderText="Razon Social" />
            <asp:BoundField DataField="var_Fecha" HeaderText="Fecha" />
            <asp:BoundField DataField="num_Importe" DataFormatString="{0:#,##0.00}" HeaderText="Importe" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEliminar" CommandName="Delete" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="GridHeader" />
        <FooterStyle CssClass="GridFooter" />
        <AlternatingRowStyle CssClass="GridAltItem" />
        <RowStyle CssClass="GridItem" />
    </asp:GridView>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnRegistrar" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="grdDocumento" EventName="RowCommand" />
        <asp:AsyncPostBackTrigger ControlID="grdDocumento" EventName="RowDeleting" />
        </Triggers>
    </asp:UpdatePanel>
    <table cellpadding="1" border="0" cellspacing="1">
        <tr>
            <td><asp:ImageButton ID="btnRegistrar" CssClass="Boton" onmouseover="this.src='../images/btnAsignar_on.gif';" onmouseout="this.src='../images/btnAsignar.gif';" ImageUrl="../images/btnAsignar.gif" runat="server" /></td>
            <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
        </tr>
    </table>
    <div id="divFooter">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
            <img src="../images/loader.gif" />
            </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>&nbsp;</div>    
