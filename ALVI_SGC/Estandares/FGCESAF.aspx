<%@ Page Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCESAF.aspx.vb" Inherits="Estandares_FGCESAF" title="Sistema de Gestión de Costos - Alta Visión Consultores" %>
<%@ Register TagPrefix="UC" TagName="CentroCosto" Src="~/Controles/ctlCentroCosto_BuscarSD.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">Mantenimiento de Maquinas - Lista</div>
<div id="divOpciones"> 
<table cellpadding="0" cellspacing="1" border="0">
    <tr>
    <td><asp:ImageButton ID="btnNuevo" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'" onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif" /></td>
    <td><asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'" onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
   </tr>
    </table>
</div>
        <table cellpadding="0" cellspacing="0" border="0" width="400">
    <tr>
        <td class="Titulo12">Busqueda</td>
        <td>
            <asp:TextBox ID="txtBusqueda" CssClass="Texto12" runat="server"></asp:TextBox>
        </td>        
    </tr> 
    </table>
    <asp:GridView ID="grdDatos" Width="600" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>
    <asp:BoundField DataField="var_IdTipoMaquina" HeaderText="" />
    <asp:BoundField DataField="var_TipoMaquina" HeaderText="Tipo de Máquina" >
    <ItemStyle Width="300" />
    </asp:BoundField>    
    <asp:BoundField DataField="var_IdMaquina" HeaderText="Código" />
    <asp:BoundField DataField="var_Descripcion" HeaderText="Descripción" >
    <ItemStyle Width="300" />
    </asp:BoundField>
    <asp:BoundField DataField="var_IdPlanta" HeaderText="CP" />
    <asp:BoundField DataField="var_Planta" HeaderText="Planta" >
    <ItemStyle Width="300" />
    </asp:BoundField>    
    <asp:BoundField DataField="var_IdCentroCosto" HeaderText="CC" />
    <asp:BoundField DataField="var_CentroCosto" HeaderText="Centro de Costo" >
    <ItemStyle Width="300" />
    </asp:BoundField>
    <asp:BoundField DataField="var_volmax" HeaderText="Volumen Maximo" />
    <asp:BoundField DataField="var_volmin" HeaderText="Volumen Minimo" >
    <ItemStyle Width="300" />
    </asp:BoundField>
    <asp:BoundField DataField="var_pesoMax" HeaderText="Peso Maximo" />
    <asp:BoundField DataField="var_pesoMin" HeaderText="Peso Minimo" >
    <ItemStyle Width="300" />
    </asp:BoundField>
    <asp:BoundField DataField="var_relacionBano" HeaderText="Relacion Baño" />
    <asp:TemplateField>
    <ItemTemplate>
        <asp:ImageButton ID="btnEnergetico" CommandArgument='<%#Container.DataItem("var_IdMaquina") %>' CommandName="Energetico" ImageUrl="../images/btnDetalle.gif" runat="server" onmouseover="this.src='../images/btnDetalle_on.gif'" onmouseout="this.src='../images/btnDetalle.gif'" />
    </ItemTemplate>
    <ItemStyle Width="50" />
    </asp:TemplateField>
    <asp:TemplateField>
    <ItemTemplate>
        <asp:ImageButton ID="btnModificar" CommandArgument='<%#Container.DataItem("var_IdMaquina") %>' CommandName="Modificar" ImageUrl="../images/btnAbrir.gif" runat="server" onmouseover="this.src='../images/btnAbrir_on.gif'" onmouseout="this.src='../images/btnAbrir.gif'" />
    </ItemTemplate>
    <ItemStyle Width="50" />
    </asp:TemplateField>
    <asp:TemplateField>
    <ItemTemplate>
        <asp:ImageButton ID="btnEliminar" CommandArgument='<%#Container.DataItem("var_IdMaquina") %>' CommandName="Eliminar" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
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
    <div id="divTitulo">Registro - Maquina</div>
    <table cellpadding="2" cellspacing="3" border="0" width="300" align="center" valign="middle">
    <tr>
        <td colspan = "2" class="Titulo12">
                <asp:label ID = "lblCodigo"  Width = "80" Text ="Código" runat = "server"></asp:label>
                <asp:TextBox CssClass="Texto12" onChange="validadigito(this,'ALN');" Width = "100"  onKeypress="return Valida(event, 'ALN');" MaxLength="10" ID="txtCodigo" runat="server"></asp:TextBox>
                <asp:label ID = "lblSpace1" Text ="" Width = "45"  runat = "server"></asp:label>
                <asp:label ID = "lblDescripcion" Text ="Descripcion" Width = "80"  runat = "server"></asp:label>
                <asp:TextBox ID="txtDescripcion" MaxLength="200" onChange="validadigito(this,'ALN');" Width = "135"  onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server"></asp:TextBox>
    </td>
    </tr>
        <tr>
        <td colspan = "2" class="Titulo12">
             <asp:label ID = "lblTipoMaquina"  Width = "80" Text ="Tipo de máquina" runat = "server"></asp:label>
             <asp:DropDownList ID="ddlTipoMaquina" Width = "105"  CssClass="texto12" runat="server"> </asp:DropDownList>
             <asp:label ID = "lblSpacing9" Text ="" Width = "45"  runat = "server"></asp:label>
             <asp:label ID = "lblPlanta" Text ="Planta" Width = "80"  runat = "server"></asp:label>
             <asp:DropDownList ID="ddlPlanta" CssClass="texto12" Width = "135"  runat="server"></asp:DropDownList>
    </td>
    </tr>
    <tr>
                <td colspan="2">
              <UC:CentroCosto ID="ctlCentroCosto1" runat="server" />
                </td>
    </tr> 
       <tr><td colspan="2"><hr width="100%" height="1" noshadow /></td></tr>
        <tr>
        <td colspan = "2" class="Titulo12">
                <asp:label ID = "lblVolmin"  Width = "80" Text ="Volumen Minimo" runat = "server"></asp:label>
                <asp:TextBox ID="txtVolMinimo" MaxLength="200" Width = "100" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server"></asp:TextBox>
                <asp:label ID = "lblSpacing8" Text ="" Width = "50"  runat = "server"></asp:label>
                <asp:label ID = "lblVolmaximo" Text ="Volumen Maximo" Width = "70"  runat = "server"></asp:label>
                <asp:TextBox ID="txtVolMaximo" MaxLength="200" onChange="validadigito(this,'ALN');" Width = "100"  onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server"></asp:TextBox>
               <asp:label ID = "lblSpace2" Text ="" Width = "10"  runat = "server"></asp:label>
                <asp:DropDownList ID="ddlUnidadVolumen" Width = "60" CssClass="Texto12" runat="server"></asp:DropDownList>
    </td>
    </tr> 
            <tr>
        <td colspan = "2" class="Titulo12"> 
                <asp:label ID = "lblPesomin"  Width = "80" Text ="Volumen Minimo" runat = "server"></asp:label>
                <asp:TextBox ID="txtPesoMinimo" MaxLength="200" Width = "100" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server"></asp:TextBox>
                <asp:label ID = "lblSpacing10" Text ="" Width = "50"  runat = "server"></asp:label>
                <asp:label ID = "lblPesoMax" Text ="Volumen Maximo" Width = "70"  runat = "server"></asp:label>
                <asp:TextBox ID="txtPesoMaximo" MaxLength="200" onChange="validadigito(this,'ALN');" Width = "100" onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server"></asp:TextBox>
                <asp:label ID = "lblSpace3" Text ="" Width = "10"  runat = "server"></asp:label>
                <asp:DropDownList ID="ddlUnidadPeso" CssClass="Texto12" Width = "60" runat="server"></asp:DropDownList>
    </td>
    </tr> 
            <tr>
        <td colspan = "2" class="Titulo12">
             <asp:label ID = "lblVelocidad"  Width = "80" Text ="Velocidad" runat = "server"></asp:label>
             <asp:TextBox ID="txtVelocidad" MaxLength="200" Width = "100" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server"></asp:TextBox>
             <asp:label ID = "lblSpace4" Text ="" Width = "55"  runat = "server"></asp:label>
             <asp:DropDownList ID="ddlUnidadVelocidad" CssClass="Texto12" Width = "100" runat="server"></asp:DropDownList>
    </td>
    </tr>
                <tr>
    <td colspan = "2" class="Titulo12">
      <asp:label ID = "lblRelacioBano"  Width = "80" Text ="Relacion Baño" runat = "server"></asp:label>
      <asp:TextBox ID="txtRelacionBano" MaxLength="200" Width = "100" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server"></asp:TextBox></td>
    </td>
    </tr>
    <tr>  


        <td class="Titulo12">&nbsp;</td>
        <td><asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblCentroCosto" runat="server" Text="" CssClass="Texto12"></asp:Label>
                    </ContentTemplate>  
            </asp:UpdatePanel>
        </td>
    </tr>
       <tr><td colspan="2"><hr width="100%" height="1" noshadow /></td></tr>
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
    
    <asp:Panel ID="pnlEnergetico" CssClass="Formulario" runat="server">
    <div id="divTitulo">Registro - Energeticos</div>
        <asp:HiddenField ID="hdnIdMaquina" runat="server" />
    <table cellpadding="2" cellspacing="2" border="0" width="400" align="center" valign="middle">
    <tr>
        <td class="Titulo12">Energetico</td>
        <td>
            <asp:DropDownList ID="ddlEnergetico" CssClass="Texto12" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="Titulo12">Consumo Std.</td>
        <td>
            <asp:TextBox ID="txtConsumo" MaxLength="20" onChange="validadigito(this,'NUM');" onKeypress="return Valida(event, 'NUM');" CssClass="Texto12" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="Titulo12">Unidad Medida</td>
        <td>
            <asp:DropDownList ID="ddlUMConsumo" CssClass="texto12" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    
    <tr>
    <td colspan="2">
        <asp:ImageButton ID="btnRegEnergetico" CssClass="Boton" onmouseover="this.src='../images/btnRegistrar_on.gif';" onmouseout="this.src='../images/btnRegistrar.gif';" ImageUrl="../images/btnRegistrar.gif" runat="server" />
        <asp:ImageButton ID="btnSalEnergetico" CssClass="Boton" onmouseover="this.src='../images/btnCancelar_on.gif';" onmouseout="this.src='../images/btnCancelar.gif';" ImageUrl="../images/btnCancelar.gif" runat="server" />
    </td>
    </tr>
    </table>
     <asp:GridView ID="grdEnergetico" Width="400" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
        <Columns>
            <asp:BoundField DataField="var_IdEnergetico" HeaderText="ID" />
            <asp:BoundField DataField="var_Energetico" HeaderText="Energetico" />
            <asp:BoundField DataField="num_ConsumoSTD" HeaderText="Consumo" />
            <asp:BoundField DataField="var_IdUnidadMedida" HeaderText="IDM" />
            <asp:BoundField DataField="var_UnidadMedida" HeaderText="Unidad Medida" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEliminar" CommandArgument='<%#Container.DataItem("var_IdEnergetico") %>' CommandName="Eliminar" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
                </ItemTemplate>
                <ItemStyle Width="50" />
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="GridHeader" />
        <FooterStyle CssClass="GridFooter" />
        <AlternatingRowStyle CssClass="GridAltItem" />
        <RowStyle CssClass="GridItem" />
    </asp:GridView>

    <div id="div2">
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                <ProgressTemplate>
                <img src="../images/loader.gif" />
                </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:Label ID="lblMensaje2" runat="server"></asp:Label>&nbsp;</div>    
    </asp:Panel>
</div>
</asp:Content>

