<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlValidacion_Registro.ascx.vb" Inherits="Controles_ctlValidacion_Registro" %>
<%@ Register TagPrefix="UC" TagName="Validador" Src="~/Controles/ctlValidador_Buscar.ascx" %>

<div id="divTitulo">Aprobación de Requisición</div>
<table cellpadding="1" cellspacing="1" border="0">
    <tr>
        <td>
            <UC:Validador ID="ctlValidador" runat="server" />
            
        </td>
        <td valign="top">
           <table cellpadding="1" cellspacing="1" border="0">
            <tr>
                <td>Usuario</td>
                <td><asp:TextBox ID="txtLogin" runat="server" CssClass="TextoLogin" Width="124px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Clave</td>
                <td><asp:TextBox ID="txtClave" runat="server" TextMode="Password" Width="124px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Estado</td>
                <td>
                    <asp:DropDownList ID="ddlEstado" runat="server">
                        <asp:ListItem Value="">Seleccionar</asp:ListItem>
                        <asp:ListItem Value="ABI">Abierto</asp:ListItem>
                        <asp:ListItem Value="APR">Aprobado</asp:ListItem>
                        <asp:ListItem Value="CER">Cerrado</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>
                     
                     <asp:HiddenField ID="hdnIdRequisicion" runat="server" />
                </td>
              
            </tr>

            </table>
        </td>
    </tr>
</table>

<br />


<asp:GridView ID="grdValidador" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="var_IdValidador" HeaderText="IdValidador" />
        <asp:BoundField DataField="var_Nombre" HeaderText="Validador" />
        <asp:BoundField DataField="var_Cargo" HeaderText="Cargo" />
        <asp:BoundField DataField="var_Area" HeaderText="Area" />
        <asp:BoundField DataField="Estado" HeaderText="Estado" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="btnEliminar"  CommandArgument='<%#Container.DataItemIndex() %>'  CommandName="ELIMINAR" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
            </ItemTemplate>
        </asp:TemplateField>          
    </Columns>
    <HeaderStyle CssClass="GridHeader" />
    <RowStyle CssClass="GridItem" />
    <AlternatingRowStyle CssClass="GridAltItem" />
</asp:GridView>


<asp:Label ID="lblMensaje" CssClass="Error" runat="server" Text=""></asp:Label>

<div id="Opciones">
    
    
    
    <br />
    <asp:ImageButton ID="btnTerminar" runat="server" onmouseover="this.src='../images/btnRegistroCierre_on.gif'" onmouseout="this.src='../images/btnRegistroCierre.gif'" ImageUrl="../images/btnRegistroCierre.gif" />
    <asp:ImageButton ID="btnRegistrar" runat="server" onmouseover="this.src='../images/btnRegistrar_on.gif'" onmouseout="this.src='../images/btnRegistrar.gif'" ImageUrl="../images/btnRegistrar.gif" />
    <asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" />
</div>