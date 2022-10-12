<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGLESAB.aspx.vb" Inherits="Estandares_FGLESAB" %>

<%@ Register src="../Controles/ctlCargo_Buscar.ascx" tagname="ctlCargo_Buscar" tagprefix="uc1" %>
<%@ Register src="../Controles/CtlArea_Buscar.ascx" tagname="CtlArea_Buscar" tagprefix="uc2" %>

<%@ Register src="../Controles/ctlPersonal_Buscar1.ascx" tagname="ctlPersonal_Buscar1" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo"> 
<div id="divHeader">MAESTRO DE SOLICITANTES - Listado
    </div>




<div id="divOpciones">
<table cellpadding="0" cellspacing="1" border="0">
<tr>
    
    <td><asp:ImageButton ID="btnNuevo" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'" onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
    <td> <asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'" onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" /></td>
    </tr>
    </table>
</div>
    <table>
     <tr> 
        <td class="Titulo12">Nombres</td> 
        <td>
            <asp:TextBox ID="txtNombre" CssClass="Texto12" runat="server"></asp:TextBox>
        </td>        
    </tr>

         <tr> 
        <td class="Titulo12">Apellido Paterno</td> 
        <td>
            <asp:TextBox ID="txtPaterno" CssClass="Texto12" runat="server"></asp:TextBox>
        </td>        
    </tr> 

         <tr> 
        <td class="Titulo12">Apellido Materno:</td> 
        <td>
            <asp:TextBox ID="TxtMaterno" CssClass="Texto12" runat="server"></asp:TextBox>
        </td>        
    </tr>

    </table>
       

   
   <table>
   
   <tr>  
                <td >
                  <uc1:ctlCargo_Buscar ID="ctlCargo_Buscar1" runat="server" />  
                </td>

                <td>
                    <uc2:CtlArea_Buscar ID="CtlArea_Buscar1" runat="server" />
                </td>
            </tr>
   
   </table>

    <br /><br />

    <asp:UpdatePanel ID="updBuscar" runat="server">
    <ContentTemplate > 


    <asp:GridView ID="grdDatos" Width="600" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>
    <asp:BoundField DataField="var_IdSolicitante" HeaderText="Id" />
    
    <asp:BoundField DataField="var_Nombre" HeaderText="Nombre" >
    </asp:BoundField>
    <asp:BoundField DataField="var_ApePat" HeaderText="Ap.Paterno" />
    <asp:BoundField DataField="var_ApeMat" HeaderText="Ap. Materno" >
    </asp:BoundField>
    <asp:BoundField DataField="cargo" HeaderText="cargo" />
    <asp:BoundField DataField="area" HeaderText="area" />
  
  
    <asp:TemplateField>
    <ItemTemplate>
        <asp:ImageButton ID="btnModificar" CommandArgument='<%#Container.DataItem("var_IdSolicitante") %>' CommandName="Modificar" ImageUrl="../images/btnAbrir.gif" runat="server" onmouseover="this.src='../images/btnAbrir_on.gif'" onmouseout="this.src='../images/btnAbrir.gif'" />
    </ItemTemplate>
    <ItemStyle Width="50" />
    </asp:TemplateField>
    <asp:TemplateField>
    <ItemTemplate>
        <asp:ImageButton ID="btnEliminar" CommandArgument='<%#Container.DataItem("var_IdSolicitante") %>' CommandName="Eliminar" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
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
     <div id="divTitulo">MAESTRO DE SOLICITANTES  - Registro</div>
    <table cellpadding="1" cellspacing="1" border="0" width="500" align="center" valign="middle">

     <tr>
        <td class="Titulo12" width="150">Código</td>
        <td width="340">
            <asp:TextBox CssClass="Texto12" onChange="validadigito(this,'ALN');" onKeypress="return Valida(event, 'ALN');" MaxLength="200" ID="txtCodigoSolicitante" runat="server"></asp:TextBox></td>
    </tr>
        <caption>
          
            <tr>
                <td colspan="2">
                    <uc3:ctlPersonal_Buscar1 ID="ctlPersonal_Buscar1" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <nobr>
                    <asp:ImageButton ID="btnTerminar" runat="server" CssClass="Boton" 
                        ImageUrl="../images/btnRegistroCierre.gif" 
                        onmouseout="this.src='../images/btnRegistroCierre.gif';" 
                        onmouseover="this.src='../images/btnRegistroCierre_on.gif';" />
                    <asp:ImageButton ID="btnRegistrar" runat="server" CssClass="Boton" 
                        ImageUrl="../images/btnRegistrar.gif" 
                        onmouseout="this.src='../images/btnRegistrar.gif';" 
                        onmouseover="this.src='../images/btnRegistrar_on.gif';" />
                    <asp:ImageButton ID="btnCancelar" runat="server" CssClass="Boton" 
                        ImageUrl="../images/btnCancelar.gif" 
                        onmouseout="this.src='../images/btnCancelar.gif';" 
                        onmouseover="this.src='../images/btnCancelar_on.gif';" />
                    </nobr>
                </td>
            </tr>
        </caption>

    </table>
     <div id="divFooter">
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>&nbsp;</div>

    </asp:Panel>

     </ContentTemplate>

       <Triggers>
        <asp:AsyncPostBackTrigger ControlID="txtNombre" EventName="TextChanged"/>
        <asp:AsyncPostBackTrigger ControlID="txtPaterno" EventName="TextChanged"/>
        <asp:AsyncPostBackTrigger ControlID="TxtMaterno" EventName="TextChanged"/>
     
        
        <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="click"/>
    </Triggers>
    </asp:UpdatePanel>
    
</div>




</asp:Content>

