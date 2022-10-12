<%@ Page Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCSEAC.aspx.vb" Inherits="Security_FGCSEAC" title="Página sin título" %>

<%@ MasterType VirtualPath="~/Masterpage/General.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">Asignación de Accesos Especiales a Grupos de Usuarios</div>
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
        <td width="100" class="Titulo12">Grupo</td>
        <td>
            <asp:HiddenField ID="hdnIdGrupo" runat="server" />
            <asp:Label CssClass="Titulo12" ID="lblGrupo" runat="server" Text=""></asp:Label>
        </td>        
    </tr>
    </table>
    <asp:GridView ID="grdDatos" Width="600" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>
        <asp:BoundField DataField="chr_IdAccesoTipo" HeaderText="" />
        <asp:BoundField DataField="var_AccesoTipo" HeaderText="Tipo de Acceso" >
            <ItemStyle Width="300" />
        </asp:BoundField>
        <asp:BoundField DataField="int_Secuencia" HeaderText="Id" />
        <asp:BoundField DataField="var_AccesoValor" HeaderText="Valor Asignado" >
            <ItemStyle Width="300" />
        </asp:BoundField>
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
    <div id="divTitulo">Asignación de Acceso Especial a Grupo</div>
    <table cellpadding="2" cellspacing="2" border="0" width="400" align="center" valign="middle">
    <tr>
        <td class="Titulo12">Tipo</td>
        <td>
            <asp:DropDownList ID="ddlAccesoTipo" AutoPostBack="true" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">Valor</td>
        <td><asp:UpdatePanel ID="upnAccesoValor" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="ddlAccesoValor" runat="server">
            </asp:DropDownList>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlAccesoTipo" EventName="SelectedIndexChanged" />
            </Triggers> 
            </asp:UpdatePanel>
        </td>
    </tr>
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
