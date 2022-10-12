<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGLESAA.aspx.vb" Inherits="Estandares_FGLESAA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">MAESTRO DE PROYECTOS - Listado</div>
<div id="divOpciones">
<table cellpadding="0" cellspacing="1" border="0">
    <tr>
    <td><asp:ImageButton ID="btnNuevo" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'" onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
    <td><asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'" onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" /></td>
    </tr>
 </table>
</div>

    <table cellpadding="0" cellspacing="0" border="0" width="400">
    <tr> 
        <td class="Titulo12">Nombre</td> 
        <td>
            <asp:TextBox ID="txtNombre" CssClass="Texto12" runat="server"></asp:TextBox>
        </td>        
    </tr> 


    <tr> 
        <td class="Titulo12">Descripcion</td> 
        <td>
            <asp:TextBox ID="txtDescripcion" CssClass="Texto12" runat="server" TextMode="MultiLine"></asp:TextBox>
        </td>        
    </tr>  

      <tr>
        <td class="Titulo12">Estado</td>
        <td>
            <asp:DropDownList ID="ddlEstado" runat="server">
            <asp:ListItem value="" Text="Seleccionar"></asp:ListItem>
            <asp:ListItem value="ACT" Text="Activo"></asp:ListItem>
            <asp:ListItem value="INA" Text="Inactivo"></asp:ListItem> 
            </asp:DropDownList>
            </td>
    </tr>


    </table>


<asp:UpdatePanel ID="updBuscar" runat="server">
<ContentTemplate > 
 <asp:GridView ID="grdDatos" Width="600" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" > 
    <Columns>
    <asp:BoundField DataField="var_IdProyecto" HeaderText="IdProyecto" />
    <asp:BoundField DataField="var_Nombre" HeaderText="Nombre" />
     <asp:BoundField DataField="var_Descripcion" HeaderText="Descripcion" />
    
    <asp:BoundField DataField="num_ImpPresupuesto" HeaderText="Presupuesto"  />
    <asp:BoundField DataField="num_ImpUtilizado" HeaderText="Ejecución"/>
    <asp:BoundField DataField="var_Estado" HeaderText="Estado"/>
    

    <asp:TemplateField>  
    <ItemTemplate>
        <asp:ImageButton ID="btnModificar" CssClass="Separacion"
        CommandArgument='<%#Container.DataItem("var_IdProyecto") %>' 
        CommandName="Modificar" ImageUrl="../images/btnAbrir.gif" runat="server"
         onmouseover="this.src='../images/btnAbrir_on.gif'" onmouseout="this.src='../images/btnAbrir.gif'" />
    </ItemTemplate>
    <ItemStyle Width="50" />
    </asp:TemplateField>
    <asp:TemplateField>
    <ItemTemplate>
        <asp:ImageButton ID="btnEliminar" CssClass="Separacion"
        CommandArgument='<%#Container.DataItem("var_IdProyecto") %>' 
        CommandName="Eliminar" ImageUrl="../images/btnEliminar.gif" runat="server" 
        onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
    </ItemTemplate>
    <ItemStyle Width="50" />
    </asp:TemplateField> 
    </Columns>
    <HeaderStyle CssClass="GridHeader" />
    <FooterStyle CssClass="GridFooter" />
    <AlternatingRowStyle CssClass="GridAltItem" />
    <RowStyle CssClass="GridItem" />
    </asp:GridView> 
   
   <br />

     <asp:Panel ID="pnlFormulario" CssClass="Formulario" runat="server">
    <div id="divTitulo">MAESTRO DE PROYECTOS - Registro</div>
    <table cellpadding="2" cellspacing="2" border="0" width="300" align="center" valign="middle">
    <tr>
        <td class="Titulo12">codigo</td>
        <td> 
            <asp:TextBox ID="txtCodigo" MaxLength="20" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');"  runat="server" CssClass="Texto12"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="Titulo12">Nombre</td>
        <td>
            <asp:TextBox ID="txtNombreProyecto" MaxLength="200" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="Titulo12">Descripcion</td> 
        <td>
            <asp:TextBox ID="txtDescripcionProyecto" MaxLength="200" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server"></asp:TextBox></td>
    </tr>

    <tr>
        <td class="Titulo12">Presupuestado (S/.)</td> 
        <td>
            <asp:TextBox ID="txtPresupuestado" MaxLength="200" onChange="validadigito(this,'NUM');" onKeypress="return Valida(event, 'INT');" CssClass="Texto12" runat="server"></asp:TextBox></td>
    </tr>

    <tr>
        <td class="Titulo12">Ejecutado (S/.):</td> 
        <td>
            <asp:TextBox ID="txtEjecutado" MaxLength="200" onChange="validadigito(this,'NUM');" onKeypress="return Valida(event, 'INT');" CssClass="Texto12" runat="server"></asp:TextBox></td>
    </tr>



            <tr>
        <td class="Titulo12">Estado</td>
        <td>
            <asp:DropDownList ID="ddlEstadoProyecto" runat="server">
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

     </ContentTemplate>

       <Triggers>
        <asp:AsyncPostBackTrigger ControlID="txtNombre" EventName="TextChanged"/>
        <asp:AsyncPostBackTrigger ControlID="txtDescripcion" EventName="TextChanged"/>
        <asp:AsyncPostBackTrigger ControlID="ddlEstado" EventName="TextChanged"/>
        <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="click"/>
    </Triggers>
    </asp:UpdatePanel>
    
</div>
</asp:Content>

