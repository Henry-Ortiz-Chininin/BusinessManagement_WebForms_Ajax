<%@ Page Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCESAP.aspx.vb" Inherits="Estandares_FGCESAP" title="Sistema de Gestión de Costos - Alta Visión Consultores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">Mantenimiento de Operaciones - Lista</div>
<div id="divOpciones">
<table cellpadding="0" cellspacing="1" border="0"> 
    <tr>
    <td><asp:ImageButton ID="btnNuevo" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'" onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
   <td><asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'" onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" /></td>
   </tr>
   <tr>
   <td colspan ="3">
       <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
   </td>
   </tr> 
    </table>
</div>
    <asp:UpdatePanel ID="updBuscar" runat="server">
    <ContentTemplate >
    <asp:GridView ID="grdDatos" Width="600" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>
    <asp:BoundField DataField="chr_IdEtapa" HeaderText="" />
    <asp:BoundField DataField="var_Etapa" HeaderText="Etapa" >
    <ItemStyle Width="300" />
    </asp:BoundField>
    <asp:BoundField DataField="chr_IdProceso" HeaderText="" />
    <asp:BoundField DataField="var_Proceso" HeaderText="Proceso" >
    <ItemStyle Width="300" />
    </asp:BoundField>
    <asp:BoundField DataField="var_IdOperacion" HeaderText="Código" />
    <asp:BoundField DataField="var_Descripcion" HeaderText="Descripción" >
    <ItemStyle Width="300" />
    </asp:BoundField>
    <asp:TemplateField>
    <ItemTemplate>
        <asp:ImageButton ID="btnModificar" CommandArgument='<%#Container.DataItem("var_IdSecuencia") %>' CommandName="Modificar" ImageUrl="../images/btnAbrir.gif" runat="server" onmouseover="this.src='../images/btnAbrir_on.gif'" onmouseout="this.src='../images/btnAbrir.gif'" />
    </ItemTemplate>
    <ItemStyle Width="50" />
    </asp:TemplateField>
    <asp:TemplateField>
    <ItemTemplate>
        <asp:ImageButton ID="btnEliminar" CommandArgument='<%#Container.DataItem("var_IdSecuencia") %>' CommandName="Eliminar" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
    </ItemTemplate>
    <ItemStyle Width="50" />
    </asp:TemplateField>
    </Columns>
    <HeaderStyle CssClass="GridHeader" />
    <FooterStyle CssClass="GridFooter" />
    <AlternatingRowStyle CssClass="GridAltItem" />
    <RowStyle CssClass="GridItem" />
    </asp:GridView>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="txtBuscar" EventName="TextChanged"/>
        <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="click"/>
    </Triggers>
    </asp:UpdatePanel>
    <asp:Panel ID="pnlFormulario" CssClass="Formulario" runat="server">
    <div id="divTitulo">Registro - Operación</div>
    <table cellpadding="2" cellspacing="2" border="0" width="300" align="center" valign="middle">
    <tr>
        <td class="Titulo12">Código</td>
        <td>
            <asp:TextBox CssClass="Texto12" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" MaxLength="8" ID="txtCodigo" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="Titulo12">Descripción</td>
        <td>
            <asp:TextBox ID="txtDescripcion" MaxLength="200" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server"></asp:TextBox></td>
    </tr>
<tr>
        <td class="Titulo12">Etapa</td>
        <td>
            <asp:DropDownList ID="ddlEtapa" AutoPostBack="true" CssClass="Texto12" runat="server">
            </asp:DropDownList>
        </td>        
    </tr>
    <tr>
        <td class="Titulo12">Proceso</td>
        <td><asp:UpdatePanel ID="upnProceso" runat="server">
                    <ContentTemplate>
            <asp:DropDownList ID="ddlProceso" AutoPostBack="true" CssClass="Texto12" runat="server">
            </asp:DropDownList>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlEtapa" EventName="SelectedIndexChanged" />
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
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>&nbsp;</div>    
    </asp:Panel>
    
</div>
</asp:Content>

