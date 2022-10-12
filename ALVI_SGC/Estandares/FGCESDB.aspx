<%@ Page Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGCESDB.aspx.vb" Inherits="Estandares_FGCESDB" title="Página sin título" %>
<%@ Register TagPrefix="UC" TagName="CentroCosto" Src="~/Controles/ctlCentroCosto_Buscar.ascx" %>
<%@ Register src="../Controles/ctlCargo_Buscar.ascx" tagname="ctlCargo_Buscar" tagprefix="uc1" %>
<%@ Register src="../Controles/CtlArea_Buscar.ascx" tagname="CtlArea_Buscar" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo"> 
<div id="divHeader">Mantenimiento de Personal - Lista</div> 
<div id="divOpciones"> 
<table cellpadding="0" cellspacing="1" border="0">  
    <tr>
    <td><asp:ImageButton ID="btnNuevo" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'" onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif" /></td>
    <td><asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'" onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
   </tr>
 </table>
<table>
<tr> 
        <td class="Titulo12">Codigo</td> 
        <td>
            <asp:TextBox ID="txtCodigo" CssClass="Texto12" runat="server"></asp:TextBox>
        </td>        
    </tr>

   
       <tr> 
        <td class="Titulo12">Nombre</td> 
        <td>
            <asp:TextBox ID="txtNombrePersonal" CssClass="Texto12" runat="server"></asp:TextBox>
        </td>        
    </tr>


  

    <tr> 
        <td class="Titulo12">Apellido Paterno</td> 
        <td>
            <asp:TextBox ID="txtApePaterno" CssClass="Texto12" runat="server"></asp:TextBox>
        </td>        
    </tr> 


     <tr> 
        <td class="Titulo12">Apellido Materno</td> 
        <td>
            <asp:TextBox ID="txtApeMaterno" CssClass="Texto12" runat="server"></asp:TextBox>
        </td>        
    </tr> 


</table>
</div>
    <asp:UpdatePanel ID="updBuscar" runat="server">
    <ContentTemplate > 
    <asp:GridView ID="grdDatos" Width="800" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" > 
    <Columns>
    <asp:BoundField DataField="var_IdPersonal" HeaderText="Codigo" />
    <asp:BoundField DataField="var_Nombre" HeaderText="Nombre" />
    <asp:BoundField DataField="var_ApePat" HeaderText="ApellidoPaterno" />
    <asp:BoundField DataField="var_ApeMat" HeaderText="ApellidoMaterno" />
    <asp:BoundField DataField="var_IdCentroCosto" HeaderText="ID Centro Costo"  />
    <asp:BoundField DataField="var_CentroCosto" HeaderText="Centro Costo"  />
    <asp:BoundField DataField="var_Cargo" HeaderText="IdCargo"  />
    <asp:BoundField DataField="Cargo" HeaderText="Cargo"  />
    <asp:BoundField DataField="var_IdArea" HeaderText="IdArea"  />
    <asp:BoundField DataField="Area" HeaderText="Area"  />
    <asp:TemplateField>
    <ItemTemplate>
        <asp:ImageButton ID="btnModificar" CommandArgument='<%#Container.DataItem("var_IdPersonal") %>' CommandName="Modificar" ImageUrl="../images/btnAbrir.gif" runat="server" onmouseover="this.src='../images/btnAbrir_on.gif'" onmouseout="this.src='../images/btnAbrir.gif'" />
    </ItemTemplate>
    <ItemStyle Width="50" />
    </asp:TemplateField>
    <asp:TemplateField>
    <ItemTemplate>
        <asp:ImageButton ID="btnEliminar" CommandArgument='<%#Container.DataItem("var_IdPersonal") %>' CommandName="Eliminar" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
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
    <table cellpadding="2" cellspacing="2" border="0" width="300" align="left" valign="middle">
    <tr>
        <td class="Titulo12">Codigo</td>
        <td> 
            <asp:TextBox CssClass="Texto12" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" MaxLength="8" ID="txtDni" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="Titulo12">Nombre</td>
        <td>
            <asp:TextBox ID="txtNombre" MaxLength="200" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="Titulo12">Ap Paterno</td>
        <td>
            <asp:TextBox ID="txtApPaterno" MaxLength="200" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server"></asp:TextBox></td>
    </tr>
        <tr>
        <td class="Titulo12">Ap Materno</td>
        <td>
            <asp:TextBox ID="txtApMaterno" MaxLength="200" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server"></asp:TextBox></td>
    </tr>
            <tr>
        <td class="Titulo12"></td>
        <td>
            <asp:TextBox ID="txtCargo"  Visible="false" MaxLength="200" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" CssClass="Texto12" runat="server"></asp:TextBox></td>
    </tr>

        </table>

        <table>
            <tr>  
                <td valign="top">
                    <UC:CentroCosto ID="ctlCentroCosto1" runat="server" />
                </td>
            </tr>

            </table>

            <table>

               <tr>  
                <td valign="top" >
                  <uc1:ctlCargo_Buscar ID="ctlCargo_Buscar1" runat="server" />  
                </td>

                <td valign="top">
                    <uc2:CtlArea_Buscar ID="CtlArea_Buscar1" runat="server" />
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
        <asp:AsyncPostBackTrigger ControlID="txtCodigo" EventName="TextChanged"/>
        <asp:AsyncPostBackTrigger ControlID="txtNombrePersonal" EventName="TextChanged"/>
        <asp:AsyncPostBackTrigger ControlID="txtApePaterno" EventName="TextChanged"/>
        <asp:AsyncPostBackTrigger ControlID="txtApMaterno" EventName="TextChanged"/>
        
        <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="click"/>
    </Triggers>
    </asp:UpdatePanel>
    
</div>
</asp:Content>

