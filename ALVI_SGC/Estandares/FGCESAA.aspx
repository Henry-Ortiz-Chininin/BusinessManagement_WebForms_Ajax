<%@ Page Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCESAA.aspx.vb" Inherits="Estandares_FGCESAA" title="Sistema de Gestión de Costos - Alta Visión Consultores sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">Mantenimiento de Articulos - Lista</div>
<div id="divOpciones">
<table cellpadding="0" cellspacing="1" border="0">
    <tr>
    <td><asp:ImageButton ID="btnNuevo" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'" onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
    <td><asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'" onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" /></td>
    </tr>
    </table>
</div>
 <table cellpadding="0" cellspacing="1" border="0">
    <tr>
        <td>Familia</td>
        <td>
            <asp:DropDownList ID="ddlFamiliaBusqueda" AutoPostBack="true" CssClass="Texto12" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>Sub-Familia</td>
        <td>
            <asp:UpdatePanel ID="updSubFamilia" runat="server">
            <ContentTemplate>
                <asp:DropDownList ID="ddlSubFamiliaBusqueda" CssClass="Texto12" runat="server">
                </asp:DropDownList>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlFamiliaBusqueda" EventName="SelectedIndexChanged" />
            </Triggers>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">Id Articulo:</td>
        <td><asp:TextBox ID="txtIdArticuloBusqueda" CssClass="Texto12" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="Titulo12">Descripción Articulo:</td>
        <td><asp:TextBox ID="txtBusqueda" CssClass="Texto12" runat="server"></asp:TextBox></td>
    </tr>
 </table>   
    <asp:GridView ID="grdDatos" Width="800" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>
        <asp:BoundField DataField="chr_IdFamilia" HeaderText="CF" />
        <asp:BoundField DataField="var_Familia" HeaderText="Familia" >
        <ItemStyle Width="300" />
        </asp:BoundField>
        <asp:BoundField DataField="var_IdSubFamilia" HeaderText="CSF" />
        <asp:BoundField DataField="var_SubFamilia" HeaderText="Descripción" >
            <ItemStyle Width="300" />
        </asp:BoundField>
        <asp:BoundField DataField="var_IdArticulo" HeaderText="Código" />
        <asp:BoundField DataField="var_Descripcion" HeaderText="Descripción" >
            <ItemStyle Width="300" />
        </asp:BoundField>
        <asp:BoundField DataField="var_IdUnidadMedida" HeaderText="UND" />
        <asp:BoundField DataField="var_UnidadMedida" HeaderText="Unidad de Medida" >
            <ItemStyle Width="300" />
        </asp:BoundField>
        <asp:TemplateField>
        <ItemTemplate>
            <asp:ImageButton ID="btnModificar" CommandArgument='<%#Container.DataItem("var_IdArticulo") %>' CommandName="Modificar" ImageUrl="../images/btnAbrir.gif" runat="server" onmouseover="this.src='../images/btnAbrir_on.gif'" onmouseout="this.src='../images/btnAbrir.gif'" />
        </ItemTemplate>
        <ItemStyle Width="50" />
        </asp:TemplateField>
    <asp:TemplateField>
    <ItemTemplate>
        <asp:ImageButton ID="btnEliminar" CommandArgument='<%#Container.DataItem("var_IdArticulo") %>' CommandName="Eliminar" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
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
    <div id="divTitulo">Registro - Articulo</div>
    <table cellpadding="2" cellspacing="2" border="0" width="300" align="center" valign="middle">
    <tr>
        <td class="Titulo12">Código</td>
        <td><asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <asp:TextBox CssClass="Texto12" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" MaxLength="4" ID="txtCodigo" runat="server"></asp:TextBox>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlSubFamilia" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlAtributoTipo" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="btnAsignar" EventName="Click" />
            </Triggers> 
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">Descripción</td>
        <td><asp:UpdatePanel ID="upnDescripcion" runat="server">
            <ContentTemplate>
            <asp:TextBox ID="txtDescripcion" MaxLength="200" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server"></asp:TextBox>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlSubFamilia" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlAtributoTipo" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="btnAsignar" EventName="Click" />
            </Triggers> 
            </asp:UpdatePanel>
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
        <td class="Titulo12">Unidad de medida</td>
        <td><asp:UpdatePanel ID="upnUnidadMedida" runat="server">
            <ContentTemplate>            
            <asp:DropDownList ID="ddlUnidadMedida" CssClass="Texto12" runat="server">
            </asp:DropDownList> 
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlSubFamilia" EventName="SelectedIndexChanged" />
            </Triggers> 
            </asp:UpdatePanel>
        </td>        
    </tr>
    <tr><td colspan="2"><hr width="100%" height="1" noshadow /></td></tr>
    <tr>
        <td class="Titulo12">Atributos</td>       
    </tr>    
    <tr><td colspan="2"><hr width="100%" height="1" noshadow /></td></tr>
    <tr>
        <td class="Titulo12">Tipo</td>
        <td>
        <asp:UpdatePanel ID="upnAtributoTipo" runat="server">
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
    <tr><td colspan="2"><asp:ImageButton ID="btnAsignar" CssClass="Boton" onmouseover="this.src='../images/btnAsignar_on.gif';" onmouseout="this.src='../images/btnAsignar.gif';" ImageUrl="../images/btnAsignar.gif" runat="server" /></td></tr>
    <tr><td colspan="2">
    <asp:UpdatePanel ID="upnAtributos" runat="server">
        <ContentTemplate> 
        <asp:GridView ID="grdAtributos" Width="400" ShowFooter="true" AutoGenerateColumns="false" runat="server">
        <Columns>
        <asp:BoundField DataField="var_IdAtributoTipo" HeaderText="" />
        <asp:BoundField DataField="var_AtributoTipo" HeaderText="Tipo" />
        <asp:BoundField DataField="var_IdAtributoValor" HeaderText="Id" />
        <asp:BoundField DataField="var_AtributoValor" HeaderText="Valor" />
        </Columns>
        <HeaderStyle CssClass="GridHeader" />
        <RowStyle CssClass="GridItem" />
        <AlternatingRowStyle CssClass="GridAltItem" />
        <FooterStyle CssClass="GridFooter" />
        </asp:GridView>
        </ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAsignar" EventName="Click" />
        </Triggers> 
        </asp:UpdatePanel>
    </td></tr>    
    <tr>
        <td colspan="2">
        <asp:ImageButton ID="btnTerminar" CssClass="Boton" onmouseover="this.src='../images/btnRegistroCierre_on.gif';" onmouseout="this.src='../images/btnRegistroCierre.gif';" ImageUrl="../images/btnRegistroCierre.gif" runat="server" />
        <asp:ImageButton ID="btnRegistrar" CssClass="Boton" onmouseover="this.src='../images/btnRegistrar_on.gif';" onmouseout="this.src='../images/btnRegistrar.gif';" ImageUrl="../images/btnRegistrar.gif" runat="server" />
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

