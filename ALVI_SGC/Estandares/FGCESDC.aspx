<%@ Page Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCESDC.aspx.vb" Inherits="Estandares_FGCESDC" title="Página sin título" %>
<%@ Register TagPrefix="UC" TagName="CentroCosto" Src="~/Controles/ctlCentroCosto_Buscar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">  
<div id="divHeader">Mantenimiento de Vendedor - Lista</div>  
<div id="divOpciones"> 
<table cellpadding="0" cellspacing="1" border="0">  
    <tr>
    <td><asp:ImageButton ID="btnNuevo" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'" onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
    </tr>
    </table>
</div>
    
    <asp:GridView ID="grdDatos" Width="600" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" > 
    <Columns>
    <asp:BoundField DataField="var_Idvendedor" HeaderText="IdVendedor" />
    <asp:BoundField DataField="var_NombreVendedor" HeaderText="Nombre" />
    <asp:BoundField DataField="var_ApellidosVendedor" HeaderText="Apellido"  />
    <asp:BoundField DataField="var_Estado" HeaderText="Estado"/>
    <asp:TemplateField>  
    <ItemTemplate>
        <asp:ImageButton ID="btnModificar" CommandArgument='<%#Container.DataItem("var_Idvendedor") %>' CommandName="Modificar" ImageUrl="../images/btnAbrir.gif" runat="server" onmouseover="this.src='../images/btnAbrir_on.gif'" onmouseout="this.src='../images/btnAbrir.gif'" />
    </ItemTemplate>
    <ItemStyle Width="50" />
    </asp:TemplateField>
    <asp:TemplateField>
    <ItemTemplate>
        <asp:ImageButton ID="btnEliminar" CommandArgument='<%#Container.DataItem("var_Idvendedor") %>' CommandName="Eliminar" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
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
    <div id="divTitulo">Registro - Personal</div>
    <table cellpadding="2" cellspacing="2" border="0" width="300" align="center" valign="middle">
    <tr>
        <td class="Titulo12">DNI</td>
        <td> 
            <asp:TextBox CssClass="Texto12" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" MaxLength="8" ID="txtDni" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="Titulo12">Nombre</td>
        <td>
            <asp:TextBox ID="txtNombre" MaxLength="200" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="Titulo12">Apellidos</td> 
        <td>
            <asp:TextBox ID="txtApPaterno" MaxLength="200" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server"></asp:TextBox></td>
    </tr>
            <tr>
        <td class="Titulo12">Estado</td>
        <td>
            <asp:DropDownList ID="ddlEstado" runat="server">
            <asp:ListItem value="ACT">Activo</asp:ListItem>
            <asp:ListItem value="INA">Inactivo</asp:ListItem> 
            </asp:DropDownList>
            </td>
    </tr>
    <tr>
    <td colspan="2">
    <nobr>
        <asp:ImageButton ID="btnTerminar" CssClass="Boton" onmouseover="this.src='../images/btnRegistroCierre_on.gif';" onmouseout="this.src='../images/btnRegistroCierre.gif';" ImageUrl="../images/btnRegistroCierre.gif" runat="server" />
        <asp:ImageButton ID="btnRegistrar" CssClass="Boton" onmouseover="this.src='../images/btnRegistrar_on.gif';" onmouseout="this.src='../images/btnRegistrar.gif';" ImageUrl="../images/btnRegistrar.gif" runat="server" />
        <asp:ImageButton ID="btnCancelar" CssClass="Boton" onmouseover="this.src='../images/btnCancelar_on.gif';" onmouseout="this.src='../images/btnCancelar.gif';" ImageUrl="../images/btnCancelar.gif" runat="server" />
    </nobr>
    </td>
    </tr>
    </table>
    <div id="divFooter">
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>&nbsp;</div>    
    </asp:Panel>
    
</div>
</asp:Content>

