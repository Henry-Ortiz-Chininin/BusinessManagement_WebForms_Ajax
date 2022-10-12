<%@ Page Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCSEAB.aspx.vb" Inherits="Security_FGCSEAB" title="Página sin título" %>
<%@ MasterType VirtualPath="~/Masterpage/General.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">Mantenimiento de Valores de Accesos Especiales</div>
<div id="divOpciones">
<table cellpadding="0" cellspacing="1" border="0">
    <tr>
    <td><asp:ImageButton ID="btnNuevo" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'" onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
   </tr>
    </table>
</div>
    <table cellpadding="0" cellspacing="0" border="0" width="400">
    <tr>
        <td width="100" class="Titulo12">Tipo de Acceso</td>
        <td>
            <asp:HiddenField ID="hdnIdAccesoTipo" runat="server" />
            <asp:Label CssClass="Titulo12" ID="lblAccesoTipo" runat="server" Text=""></asp:Label>
        </td>        
    </tr>
    </table>
    <asp:GridView ID="grdDatos" Width="600" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>
         <asp:BoundField DataField="int_Secuencia" HeaderText="Código" />
        <asp:BoundField DataField="var_Descripcion" HeaderText="Descripción" >
            <ItemStyle Width="300" />
        </asp:BoundField>
        <asp:TemplateField>
        <ItemTemplate>
            <asp:ImageButton ID="btnModificar" CommandArgument='<%#Container.DataItem("int_Secuencia") %>' CommandName="Modificar" ImageUrl="../images/btnAbrir.gif" runat="server" onmouseover="this.src='../images/btnAbrir_on.gif'" onmouseout="this.src='../images/btnAbrir.gif'" />
        </ItemTemplate>
        <ItemStyle Width="50" />
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
    <div id="divTitulo">Registro - Valor de Acceso Especial</div>
    <table cellpadding="2" cellspacing="2" border="0" width="300" align="center" valign="middle">
    <tr>
        <td class="Titulo12">Código</td>
        <td>
            <asp:TextBox CssClass="Texto12" onChange="validadigito(this,'INT');" onKeypress="return Valida(event, 'INT');" MaxLength="4" ID="txtCodigo" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="Titulo12">Valor</td>
        <td>
            <asp:TextBox ID="txtDescripcion" MaxLength="200" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server"></asp:TextBox></td>
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