<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGLINAI.aspx.vb" Inherits="Interfaces_FGLINAI" %>
<%@ Register src="../Controles/ctlSolicitante_Buscar.ascx" tagname="ctlSolicitante_Buscar" tagprefix="uc1" %>
<%@ Register src="../Controles/ctlProyecto_Buscar.ascx" tagname="ctlProyecto_Buscar" tagprefix="uc1" %>
<%@ Register src="../Controles/ctlCentroCosto_Buscar.ascx" tagname="ctlCentroCosto_Buscar" tagprefix="uc1" %>
<%@ Register Src="~/Controles/ctlValidacion_Registro.ascx" TagName="ValidadorRegistro" TagPrefix="UC" %>
<%@ Register Src="~/BLOQUES/ctlRequerimiento_Estado.ascx" TagName="RequerimientoEstado" TagPrefix="AVC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="../js/jquery-1.7.1.js"></script>
<script >
    $(document).ready(function () {
        $(".Filtro").hide();
        $(".Boton").click(function () {
            $(".Filtro").toggle();
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">APROBACION DE REQUERIMIENTOS</div>

<div id="divOpciones">
<table cellpadding="0" cellspacing="1" border="0"> 
    <tr>
    <td><asp:Image ID="btnFiltrar" CssClass="Boton" runat="server" onmouseover="this.src='../images/Lupa_on.gif'" onmouseout="this.src='../images/Lupa.gif'" ImageUrl="../images/Lupa.gif" /></td>
    <td><asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'" onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
   </tr>
    </table>
</div> 
<div class="Filtro">
<table cellpadding="1" cellspacing="1" border="0">
    <tr>
        <td valign="top">
        <table cellpadding="0" cellspacing="0" border="0" width="400">
            <tr>
                 <td class="Titulo12">tipo</td>
                 <td>
                     <asp:RadioButtonList CssClass="Texto" RepeatDirection="Horizontal" ID="rbtTipo" runat="server">
                     <asp:ListItem Text="Compra" Value="C"></asp:ListItem>
                     <asp:ListItem Text="Servicio" Value="S"></asp:ListItem>
                     </asp:RadioButtonList>
                </td> 
            </tr>
            <tr>
                <td class="Titulo12">Codigo</td>
                <td>
                    <asp:TextBox ID="txtCodigo" CssClass="Texto12" runat="server" Width="200px"></asp:TextBox>
                </td> 
                <td></td>
            </tr> 
            <tr>
                <td  class="Titulo12">Fecha Emision</td>
                <td><asp:TextBox ID="txtFechaEmisionInicio" Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                <asp:Image ID="btnFechaEmisionInicio" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
            </tr>
            <tr>
                <td  class="Titulo12" visible ="false"> </td>
                <td><asp:TextBox ID="txtFechaEmisionFinal"  Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                <asp:Image ID="btnFechaEmisionFinal" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:CheckBoxList ID="chkEstado" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value='ACT' Text="INGRESADO"></asp:ListItem>
                        <asp:ListItem Value='APR' Text="APROBADO"></asp:ListItem>
                        <asp:ListItem Value='REC' Text="RECHAZADO"></asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
        </table>
        </td>
        <td valign="top">
            <uc1:ctlProyecto_Buscar ID="ctlProyecto_Buscar1" runat="server" />
            <br />
            <uc1:ctlCentroCosto_Buscar ID="ctlCentroCosto_Buscar1" runat="server" />
        </td>
    </tr>
</table>
</div>
<asp:GridView ID="grdDatos" Width="800" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>  
        <asp:BoundField DataField="var_IdRequisicion" HeaderText="Codigo" />
        <asp:BoundField DataField="var_Solicitante" HeaderText="Solicitante" >
            <ItemStyle Width="200" />
        </asp:BoundField>
        <asp:BoundField DataField="var_Cargo" HeaderText="Cargo" > 
            <ItemStyle Width="200" />
        </asp:BoundField>  
        <asp:BoundField DataField="var_CentroCostoDestino" HeaderText="Destino" > 
            <ItemStyle Width="200" />
        </asp:BoundField>  
        <asp:BoundField DataField="dtm_FechaEmision" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Emisión" />
        <asp:BoundField DataField="dtm_FechaRecepcion"  HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Recepción" /> 
        <asp:BoundField DataField="dtm_FechaPlazo" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Plazo" /> 
        <asp:BoundField DataField="dtm_FechaCierre" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Cierre" /> 
        <asp:BoundField DataField="var_IdSolicitante" HeaderText="" HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" /> 
        <asp:BoundField DataField="var_IdPersonal" HeaderText="" HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible"  /> 
        <asp:BoundField DataField="var_Nombre" HeaderText="" HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible"  /> 
        <asp:BoundField DataField="var_ApePat" HeaderText=""  HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" /> 
        <asp:BoundField DataField="var_ApeMat" HeaderText=""  HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" /> 
        <asp:BoundField DataField="var_IdCargo" HeaderText=""  HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" /> 
        <asp:BoundField DataField="var_IdArea" HeaderText=""  HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" /> 
        <asp:BoundField DataField="chr_IdEstado" HeaderText=""  HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" /> 
        <asp:BoundField DataField="var_IdTipoOperacion" HeaderText=""  HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" /> 
        <asp:BoundField DataField="var_IdCentroCostoDestino" HeaderText=""  HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" /> 
        <asp:BoundField DataField="var_IdProyecto" HeaderText=""  HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" /> 
        <asp:BoundField DataField="var_Motivo" HeaderText=""  HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible" /> 
        <asp:BoundField DataField="var_Doc_Referencia" HeaderText=""  HeaderStyle-CssClass="NoVisible" ItemStyle-CssClass="NoVisible" FooterStyle-CssClass="NoVisible"  /> 
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="btnModificar" CommandArgument='<%#Container.DataItemIndex() %>' CommandName="ABRIR" ImageUrl="../images/btnAbrir.gif" runat="server" onmouseover="this.src='../images/btnAbrir_on.gif'" onmouseout="this.src='../images/btnAbrir.gif'" />
            </ItemTemplate>
        </asp:TemplateField>        
    </Columns>
    <HeaderStyle CssClass="GridHeader" />
    <FooterStyle CssClass="GridFooter" />
    <AlternatingRowStyle CssClass="GridAltItem" />
    <RowStyle CssClass="GridItem" />
    </asp:GridView>

<asp:Panel ID="pnlRequerimientoEstado" runat="server" CssClass="Formulario"> 
        <AVC:RequerimientoEstado id="ctlRequerimientoEstado" runat="server"></AVC:RequerimientoEstado>
    </asp:Panel>

</div>
</asp:Content>

