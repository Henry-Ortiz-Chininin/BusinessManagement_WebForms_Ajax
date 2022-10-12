<%@ Page Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCINCH.aspx.vb" Inherits="Interfaces_FGCINCH" title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">Registro de Transferencias entre Almacenes</div>
<div id="divOpciones">
<table cellpadding="1" cellspacing="1" border="0">
    <tr>
    <td><asp:ImageButton ID="btnNuevo" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'" onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif" /></td>
    <td><asp:ImageButton ID="btnRegistrar" runat="server" onmouseover="this.src='../images/btnRegistrar_on.gif'" onmouseout="this.src='../images/btnRegistrar.gif'" ImageUrl="../images/btnRegistrar.gif" /></td>
    <td><asp:ImageButton ID="btnAsignar" runat="server" onmouseover="this.src='../images/btnAsignar_on.gif'" onmouseout="this.src='../images/btnAsignar.gif'" ImageUrl="../images/btnAsignar.gif" /></td>
    <td><asp:ImageButton ID="btnImprimir" runat="server" onmouseover="this.src='../images/btnImprimir_on.gif'" onmouseout="this.src='../images/btnImprimir.gif'" ImageUrl="../images/btnImprimir.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
    </tr>
    </table>
</div>
<table cellpadding="0" cellspacing="1" border="0">
    <tr>
        <td>Salida</td>
        <td>Ingreso</td>
    </tr>
    <tr>
        <td>
            <table cellpadding="0" cellspacing="1" border="0">
            <tr>
                <td class="Titulo12">Codigo de Salida</td>
                <td>
                <asp:TextBox ID="txtIdKardexSalida" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Titulo12">Fecha de Movimiento</td>
                <td>
                <nobr>
                <asp:TextBox ID="txtFechaSalida" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                <asp:Image ID="btnFechaSalida" runat="server" ImageUrl="~/Images/im_calendar.gif" />
                </nobr></td>
            </tr>
            <tr>
                <td class="Titulo12">Tipo Movimiento</td>
                <td>
                    <asp:DropDownList ID="ddlTipoMovimientoSalida" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="Titulo12">Tipo Documento</td>
                <td>
                    <asp:DropDownList ID="ddlTipoDocumentoSalida" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="Titulo12">Número de documento</td>
                <td><asp:TextBox ID="txtNumeroDocumentoSalida" MaxLength="20" onChange="validadigito(this,'TEL');" onKeypress="return Valida(event, 'TEL');" CssClass="Texto12" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="Titulo12">Orden de compra</td>
                <td><asp:TextBox ID="txtOPReferenciaSalida" MaxLength="20" onChange="validadigito(this,'TEL');" onKeypress="return Valida(event, 'TEL');" CssClass="Texto12" runat="server"></asp:TextBox></td>
            </tr>
        </table>
        
        </td>
        <td>
        <table cellpadding="0" cellspacing="1" border="0">
        <tr>
            <td class="Titulo12">Codigo de Ingreso</td>
            <td>
            <asp:TextBox ID="txtIdKardexIngreso" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="Titulo12">Fecha de Ingreso</td>
            <td>
            <nobr>
            <asp:TextBox ID="txtFechaIngreso" Width="20" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/im_calendar.gif" />
            </nobr></td>
        </tr>
        <tr>
            <td class="Titulo12">Tipo Movimiento</td>
            <td>
                <asp:DropDownList ID="ddlTipoMovimientoIngreso" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="Titulo12">Tipo Documento</td>
            <td>
                <asp:DropDownList ID="ddlTipoDocumentoIngreso" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="Titulo12">Número de documento</td>
            <td><asp:TextBox ID="TextBox3" MaxLength="20" onChange="validadigito(this,'TEL');" onKeypress="return Valida(event, 'TEL');" CssClass="Texto12" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="Titulo12">Orden de compra</td>
            <td><asp:TextBox ID="TextBox4" MaxLength="20" onChange="validadigito(this,'TEL');" onKeypress="return Valida(event, 'TEL');" CssClass="Texto12" runat="server"></asp:TextBox></td>
        </tr>
    </table>
        
        </td>
    </tr>
</table>



<asp:GridView ID="grdDatos" Width="1000"  ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>
    <asp:BoundField DataField="var_IdArticulo" HeaderText="Codigo" />
    <asp:BoundField DataField="var_Articulo" HeaderText="Articulo" />
    <asp:BoundField DataField="num_Cantidad" HeaderText="Cantidad" />
    <asp:BoundField DataField="var_UnidadMedida" HeaderText="Unidad" />
    <asp:BoundField DataField="num_CostoUnitario" HeaderText="Precio/Unidad" />
    <asp:BoundField DataField="num_Importe" HeaderText="Importe Total" />
    <asp:BoundField DataField="var_Almacen" HeaderText="Almacen" />
    <asp:TemplateField>
    <ItemTemplate>
        <asp:ImageButton ID="btnModificar" CommandArgument='<%#Container.DataItem("var_IdArticulo") %>' CommandName="Modificar" ImageUrl="../images/btnAbrir.gif" runat="server" onmouseover="this.src='../images/btnAbrir_on.gif'" onmouseout="this.src='../images/btnAbrir.gif'" />
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField>
    <ItemTemplate>
        <asp:ImageButton ID="btnEliminar" CommandArgument='<%#Container.DataItem("var_IdArticulo") %>' CommandName="Eliminar" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    <HeaderStyle CssClass="GridHeader" />
    <FooterStyle CssClass="GridFooter" />
    <AlternatingRowStyle CssClass="GridAltItem" />
    <RowStyle CssClass="GridItem" />
    </asp:GridView>
    <asp:Panel ID="pnlFormulario" CssClass="Formulario" runat="server">
    <div id="divTitulo">Asignación de Articulo al movimiento</div>
    <table cellpadding="2" cellspacing="2" border="0" width="500" align="center" valign="middle">
        <tr>
        <td class="Titulo12">Almacen</td>
        <td width="350">
            <asp:DropDownList ID="ddlAlmacen" CssClass="Texto12" runat="server">
            </asp:DropDownList>
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
            <td class="Titulo12">Articulo</td>
            <td><asp:UpdatePanel ID="upnArticulo" runat="server">
                        <ContentTemplate>
                <asp:DropDownList ID="ddlArticulo" AutoPostBack="true" CssClass="Texto12" runat="server">
                </asp:DropDownList>
                </ContentTemplate>
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlSubFamilia" EventName="SelectedIndexChanged" />
                </Triggers> 
                </asp:UpdatePanel>
            </td>        
        </tr>
        <tr>
            <td class="Titulo12">Cantidad</td>
            <td>
                <asp:TextBox ID="txtCantidad" AutoPostBack="true" MaxLength="14" onChange="validadigito(this,'NUM');" onKeypress="return Valida(event, 'NUM');" CssClass="Texto12" runat="server"></asp:TextBox></td>
        </tr>    
        <tr>
            <td class="Titulo12">Unidad de medida</td>
            <td>
                <asp:UpdatePanel ID="upnMedida" runat="server">
                        <ContentTemplate>
                    <asp:DropDownList ID="ddlUnidadMedida" CssClass="Texto12" runat="server">
                    </asp:DropDownList>
                </ContentTemplate>
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlArticulo" EventName="SelectedIndexChanged" />
                </Triggers> 
                </asp:UpdatePanel>            
            </td>        
        </tr>
        <tr>
            <td class="Titulo12">Costo Unitario</td>
            <td><asp:UpdatePanel ID="udpCosto" runat="server">
                <ContentTemplate>
                <asp:TextBox ID="txtCostoUnitario" MaxLength="20" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                </ContentTemplate>
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="txtCantidad" EventName="TextChanged" />
                <asp:AsyncPostBackTrigger ControlID="txtImporte" EventName="TextChanged" />
                </Triggers> 
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="Titulo12">Importe</td>
            <td>
                <asp:TextBox ID="txtImporte" MaxLength="20" AutoPostBack="true" onChange="validadigito(this,'NUM');" onKeypress="return Valida(event, 'NUM');" CssClass="Texto12" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
        <td colspan="2">
            <asp:ImageButton ID="btnRegistrar2" CssClass="Boton" onmouseover="this.src='../images/btnRegistrar_on.gif';" onmouseout="this.src='../images/btnRegistrar.gif';" ImageUrl="../images/btnRegistrar.gif" runat="server" />
            <asp:ImageButton ID="btnCancelar" CssClass="Boton" onmouseover="this.src='../images/btnCancelar_on.gif';" onmouseout="this.src='../images/btnCancelar.gif';" ImageUrl="../images/btnCancelar.gif" runat="server" />
        </td>
        </tr>
    </table>
    <div id="divFooter">
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                <img src="../images/loader.gif" />
                </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>&nbsp;</div>    
    </asp:Panel>
</div>    

</asp:Content>

