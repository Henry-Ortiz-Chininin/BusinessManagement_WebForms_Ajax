<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlArticuloConstruir.ascx.vb" Inherits="Controles_ctlArticuloConstruir" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <asp:HiddenField ID="hdnIdSubFamilia" runat="server" />
<table cellpadding="1"  cellspacing="1" border="0" width="500">
    <tr>
        <td  class="Titulo12"  width="150">Codigo Articulo:</td>
        <td>
        <asp:TextBox ID="txtCodigo" CssClass="Texto12" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td  class="Titulo12"  width="150">Descripción Articulo</td>
        <td>
        <asp:TextBox ID="txtDescripcion" CssClass="Texto12" runat="server"></asp:TextBox></td>
    </tr>

</table>
 </ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="btnAsignar" EventName="Click" />
</Triggers> 
</asp:UpdatePanel>
<hr noshadow height="1" width="100%" />
<table cellpadding="1" cellspacing="1" border="0" width="500">
    <tr>
        <td class="Titulo12"  width="150">Atributo</td>
        <td><asp:DropDownList ID="ddlAtributoTipo" AutoPostBack="true" CssClass="Texto12" runat="server">
            </asp:DropDownList>
        </td>
        <td rowspan="2">
        <asp:ImageButton ID="btnAsignar" CssClass="Boton" onmouseover="this.src='../images/btnAsignar_on.gif';" onmouseout="this.src='../images/btnAsignar.gif';" ImageUrl="../images/btnAsignar.gif" runat="server" />
        </td>       
    </tr>    
    <tr>
        <td class="Titulo12"  width="150">Valor</td>
        <td><asp:UpdatePanel ID="upnAtributoValor" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="ddlAtributoValor" CssClass="Texto12" runat="server">
            </asp:DropDownList>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlAtributoTipo" EventName="SelectedIndexChanged" />
            </Triggers> 
            </asp:UpdatePanel>
        </td>        
    </tr>
    <tr><td colspan="2">
    <asp:UpdatePanel ID="upnAtributos" runat="server">
        <ContentTemplate> 
        <asp:GridView ID="grdAtributos" Width="400" ShowFooter="true" AutoGenerateColumns="false" runat="server">
        <Columns>
        <asp:BoundField DataField="var_IdAtributoTipo" HeaderText="" />
        <asp:BoundField DataField="var_AtributoTipo" HeaderText="Tipo" />
        <asp:BoundField DataField="var_IdAtributoValor" HeaderText="Id" />
        <asp:BoundField DataField="var_AtributoValor" HeaderText="Valor" />
        </Columns>
        <HeaderStyle CssClass="GridHeader" />
        <RowStyle CssClass="GridItem" />
        <AlternatingRowStyle CssClass="GridAltItem" />
        <FooterStyle CssClass="GridFooter" />
        </asp:GridView>
        </ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAsignar" EventName="Click" />
        </Triggers> 
        </asp:UpdatePanel>
    </td></tr>  
</table>