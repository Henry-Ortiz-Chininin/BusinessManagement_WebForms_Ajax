<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlRequerimiento_Estado.ascx.vb" Inherits="BLOQUES_ctlRequerimiento_Estado" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../Controles/ctlSolicitante_Buscar.ascx" tagname="ctlSolicitante_Buscar" tagprefix="uc1" %>
<%@ Register src="../Controles/ctlProyecto_Buscar.ascx" tagname="ctlProyecto_Buscar" tagprefix="uc1" %>
<%@ Register src="../Controles/ctlCentroCosto_Buscar.ascx" tagname="ctlCentroCosto_Buscar" tagprefix="uc1" %>


<div id="divTitulo">ACTUALIZACION DE REQUERIMIENTO</div>
 <table border="0" cellpadding="1" cellspacing="1" width="500">
        <tr>
            <td class="Titulo12">Codigo</td>
            <td><asp:TextBox ID="txtCodigo" runat="server" Enabled="false" CssClass="Texto12" Width="200px"></asp:TextBox></td>
            <td class="Titulo12">Tipo</td>
            <td><asp:RadioButtonList ID="rbtTipo" RepeatDirection="Horizontal" Enabled="false" runat="server">
                    <asp:ListItem Text="Compra" Value="C"></asp:ListItem>
                    <asp:ListItem Text="Servicio" Value="S"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
<br />
<asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
         Width="820px" Height="800px" CssClass="ajax__tab_xp"  >   
    <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Requisicion">
    <ContentTemplate>
        <asp:HiddenField ID="hdnIdRequisicion" runat="server" />
        <table border="0" cellpadding="1" cellspacing="1" width="600">
        <tr>
            <td>
                <uc1:ctlSolicitante_Buscar SoloLectura="true" ID="ctlSolicitante_Buscar1" runat="server" />
            </td>
            <td rowspan="3" valign="top">
                <table border="0" cellpadding="1" cellspacing="1" width="500">
                    <tr>
                        <td class="Titulo12">Fecha PLazo</td>
                        <td><asp:TextBox ID="txtFechaPlazo" Enabled="false" runat="server" Width="80px"></asp:TextBox>
                                <asp:Image ID="btnFechaPlazo" runat="server" 
                                ImageUrl="~/Images/im_calendar.gif" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Titulo12">Referencia</td>
                        <td><asp:TextBox ID="txtReferencia" ReadOnly="true" runat="server" CssClass="Texto12" 
                                MaxLength="200" onChange="validadigito(this,'ALN');" 
                                onKeypress="return Valida(event, 'ALN');" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Titulo12" colspan="2">Motivo/Justificacion</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="txtMotivo" ReadOnly="true" runat="server" CssClass="Texto12" Height="65px" 
                                MaxLength="200" onChange="validadigito(this,'ALN');" 
                                onKeypress="return Valida(event, 'ALN');" TextMode="MultiLine" Width="300px"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="Titulo12">Proveedor (es) sugeridos</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="txtProveedor" ReadOnly="true" runat="server" CssClass="Texto12" Height="65px" 
                            MaxLength="200" onChange="validadigito(this,'ALN');" 
                            onKeypress="return Valida(event, 'ALN');" TextMode="MultiLine" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ctlProyecto_Buscar ID="ctlProyecto_Buscar1" SoloLectura="true" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ctlCentroCosto_Buscar ID="ctlCentroCosto_Buscar1" SoloLectura="true" runat="server" />
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:TabPanel>
    <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Detalle">
    <ContentTemplate>
        <asp:GridView ID="grdDatos" runat="server" AllowPaging="true" 
                AutoGenerateColumns="false" PageSize="20" ShowFooter="true" Width="800">
            <Columns>
                <asp:BoundField DataField="var_IdValeAlmacen" HeaderText="NP" />
                <asp:BoundField DataField="var_IdDetalle" HeaderText="#Sec" />
                <asp:BoundField DataField="var_IdArticuloReferencia" HeaderText="articulo referencia"  HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="var_Articulo" HeaderText="Articulo" />
                <asp:BoundField DataField="var_Descripcion" HeaderText="Observacion" />
                <asp:TemplateField HeaderText ="Cantidad">
                <ItemTemplate>
                    <asp:TextBox ID ="txtCantidad" Text='<%#Container.DataItem("num_Cantidad") %>' runat="server" Width="80px"></asp:TextBox>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="var_IdUnidadMedida" HeaderText="Idunidad"  HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" />
                <asp:BoundField DataField="var_UnidadMedida" HeaderText="Medida" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:DropDownList runat="server" ID="ddlEstado">                        
                        </asp:DropDownList>
                    </ItemTemplate>
                    <ItemStyle Width="50" />
                </asp:TemplateField>
                <asp:BoundField DataField="num_Precio" HeaderText="Precio Ref." />
                <asp:BoundField DataField="num_Total" HeaderText="Total Ref." />
            </Columns>
            <HeaderStyle CssClass="GridHeader" />
            <FooterStyle CssClass="GridFooter" />
            <AlternatingRowStyle CssClass="GridAltItem" />
            <RowStyle CssClass="GridItem" />
        </asp:GridView>
                   
    
</ContentTemplate>
</asp:TabPanel>        
</asp:TabContainer>
<table cellpadding="1" cellspacing="1" border="0">
    <tr>
        <td><asp:ImageButton ID="btnRegistrar" runat="server" onmouseover="this.src='../images/btnRegistroCierre_on.gif'" onmouseout="this.src='../images/btnRegistroCierre.gif'" ImageUrl="../images/btnRegistroCierre.gif" /></td>
        <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
    </tr> 
</table>
<div id="divFooter">
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
</div>

