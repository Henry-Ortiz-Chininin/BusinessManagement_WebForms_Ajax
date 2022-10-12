<%@ Page Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCESAM.aspx.vb" Inherits="Estandares_FGCESAM" title="Sistema de Gestión de Costos - Alta Visión Consultores" %>
<%@ MasterType VirtualPath="~/Masterpage/General.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">Mantenimiento de Tipo de Atributos por Sub-Familia de Articulos  - Lista</div>
<div id="divOpciones">
<table cellpadding="0" cellspacing="1" border="0">
    <tr>
    <td><asp:ImageButton ID="btnNuevo" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'" onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif" /></td>
    <td><asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'" onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
   </tr>
    </table>
</div>
    <table cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td class="Titulo12">Familia</td>
        <td>
            <asp:DropDownList ID="ddlFamiliaTop" AutoPostBack="true" CssClass="Texto12" runat="server">
            </asp:DropDownList>
        </td>        
    </tr>
    <tr>
        <td class="Titulo12">Sub-Familia</td>
        <td><asp:UpdatePanel ID="upnSubFamiliaTop" runat="server">
                    <ContentTemplate>
            <asp:DropDownList ID="ddlSubFamiliaTop" CssClass="Texto12" runat="server">
            </asp:DropDownList>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlFamiliaTop" EventName="SelectedIndexChanged" />
            </Triggers> 
            </asp:UpdatePanel>
        </td>        
    </tr>    
    </table>
    <asp:GridView ID="grdDatos" Width="600" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>
        <asp:BoundField DataField="chr_IdFamilia" HeaderText="CF" />
        <asp:BoundField DataField="var_Familia" HeaderText="Familia" >
        <ItemStyle Width="300" />
        </asp:BoundField>
        <asp:BoundField DataField="var_IdSubFamilia" HeaderText="CSF" />
        <asp:BoundField DataField="var_SubFamilia" HeaderText="Descripción" >
            <ItemStyle Width="300" />
        </asp:BoundField>
        <asp:BoundField DataField="var_IdAtributoTipo" HeaderText="Código" />
        <asp:BoundField DataField="var_Descripcion" HeaderText="Descripción" >
            <ItemStyle Width="300" />
        </asp:BoundField>
        <asp:BoundField DataField="int_Posicion" HeaderText="Posición" />
        <asp:TemplateField>
        <ItemTemplate>
            <asp:ImageButton ID="btnModificar" CommandArgument='<%#Container.DataItem("var_Codigo") %>' CommandName="Modificar" ImageUrl="../images/btnAbrir.gif" runat="server" onmouseover="this.src='../images/btnAbrir_on.gif'" onmouseout="this.src='../images/btnAbrir.gif'" />
        </ItemTemplate>
        <ItemStyle Width="50" />
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="btnDetalle" CommandArgument='<%#Container.DataItem("var_Codigo") %>' CommandName="Detalle" ImageUrl="../images/btnDetalle.gif" runat="server" onmouseover="this.src='../images/btnDetalle_on.gif'" onmouseout="this.src='../images/btnDetalle.gif'" />
            </ItemTemplate>
            <ItemStyle Width="50" />
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="btnEliminar" CommandArgument='<%#Container.DataItem("var_Codigo") %>' CommandName="Eliminar" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
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
    <div id="divTitulo">Registro - Tipo de Atributo por SubFamilia de Articulo</div>
    <table cellpadding="2" cellspacing="2" border="0" width="300" align="center" valign="middle">
    <tr>
        <td class="Titulo12">Código</td>
        <td>
            <asp:TextBox CssClass="Texto12" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" MaxLength="4" ID="txtCodigo" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="Titulo12">Descripción</td>
        <td>
            <asp:TextBox ID="txtDescripcion" MaxLength="200" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="Titulo12">Posición</td>
        <td>
            <asp:TextBox CssClass="Texto12" onChange="validadigito(this,'INT');" onKeypress="return Valida(event, 'INT');" MaxLength="2" ID="txtPosicion" runat="server"></asp:TextBox></td>
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
            <asp:DropDownList ID="ddlSubFamilia" CssClass="Texto12" runat="server">
            </asp:DropDownList>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlFamilia" EventName="SelectedIndexChanged" />
            </Triggers> 
            </asp:UpdatePanel>
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
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
        <img src="../images/loader.gif" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>&nbsp;</div>    
    </asp:Panel>
    
</div>
</asp:Content>

