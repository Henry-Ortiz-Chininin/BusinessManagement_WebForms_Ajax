<%@ Page Title="" Language="VB" MasterPageFile="~/Masterpage/General.master" AutoEventWireup="false" CodeFile="FGLINAB.aspx.vb" Inherits="Interfaces_FGLINAB" %>
<%@ Register src="../Controles/ctlSolicitante_Buscar.ascx" tagname="ctlSolicitante_Buscar" tagprefix="uc1" %>
<%@ Register src="../Controles/ctlProyecto_Buscar.ascx" tagname="ctlProyecto_Buscar" tagprefix="uc1" %>
<%@ Register src="../Controles/ctlCentroCosto_Buscar.ascx" tagname="ctlCentroCosto_Buscar" tagprefix="uc1" %>
<%@ Register src="../Controles/ctlCargo_Buscar.ascx" tagname="ctlCargo_Buscar" tagprefix="uc2" %>
<%@ Register Src="~/Controles/ctlValidacion_Registro.ascx" TagName="ValidadorRegistro" TagPrefix="UC" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCuerpo">
<div id="divHeader">ADMINISTRACION DE REQUISICIONES</div>

<div id="divOpciones">
<table cellpadding="0" cellspacing="1" border="0"> 
    <tr>
    <td><asp:ImageButton ID="btnNuevo" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'" onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif" /></td>
    <td><asp:ImageButton ID="btnBuscar" runat="server" onmouseover="this.src='../images/btnBuscar_on.gif'" onmouseout="this.src='../images/btnBuscar.gif'" ImageUrl="../images/btnBuscar.gif" /></td>
    <td><asp:ImageButton ID="btnCerrar" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" ImageUrl="../images/btnCerrar.gif" /></td>
   </tr>
    </table>
</div> 
<table cellpadding="1" border="0">
    <tr>
        <td>
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
                <td  class="Titulo12">Fecha Recepcion</td>
                <td><asp:TextBox ID="txtFechaRecepcionInicio" Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                <asp:Image ID="btnFechaRecepcionInicio" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
            </tr>
            <tr>
                <td  class="Titulo12" visible ="false"></td>
                <td><asp:TextBox ID="txtFechaRecepcionFinal"  Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                <asp:Image ID="btnFechaRecepcionFinal" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
            </tr>
            <tr>
                <td  class="Titulo12">Fecha Plazo</td>
                <td><asp:TextBox ID="txtFechaPlazoInicio" Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                <asp:Image ID="btnFechaPlazoInicio" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
            </tr>
            <tr>
                <td  class="Titulo12" visible ="false"></td>
                <td><asp:TextBox ID="txtFechaPlazoFinal"  Width="80" MaxLength="10" onChange="validadigito(this,'');" onKeypress="return Valida(event, '');" CssClass="Texto12" runat="server"></asp:TextBox>
                <asp:Image ID="btnFechaPlazoFinal" runat="server" ImageUrl="~/Images/im_calendar.gif" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <table cellpadding="1" border="0">
                        <tr>
                            <td class="Titulo12">Abierto</td>
                            <td>
                                <asp:CheckBox ID="chkAbierto" runat="server" >
                                </asp:CheckBox>
                            </td>
                            <td class="Titulo12">Aprobado</td>
                            <td>
                            <asp:CheckBox ID="chkAprobado" runat="server" >
                            </asp:CheckBox>
                            </td> 
                            <td class="Titulo12">Cerrado</td>
                            <td>
                              <asp:CheckBox ID="chkCerrado" runat="server" >
                               </asp:CheckBox>
                            </td> 
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        </td>
        <td>
            <uc1:ctlSolicitante_Buscar ID="ctlSolicitante_Buscar1" runat="server" />
            <br />
            <uc2:ctlCargo_Buscar ID="ctlCargo_Buscar1" runat="server" />
        </td>
        <td>
            <uc1:ctlProyecto_Buscar ID="ctlProyecto_Buscar1" runat="server" />
            <br />
            <uc1:ctlCentroCosto_Buscar ID="ctlCentroCosto_Buscar1" runat="server" />
        </td>
    </tr>
</table>

<asp:GridView ID="grdDatos" Width="1000" ShowFooter="true" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" >
    <Columns>  
        <asp:BoundField DataField="var_IdRequisicion" HeaderText="Codigo" />
        <asp:BoundField DataField="var_Solicitante" HeaderText="Solicitante" >
            <ItemStyle Width="200" />
        </asp:BoundField>
        <asp:BoundField DataField="var_Cargo" HeaderText="Cargo" > 
            <ItemStyle Width="300" />
        </asp:BoundField>  
        <asp:BoundField DataField="var_CentroCostoDestino" HeaderText="Destino" > 
            <ItemStyle Width="300" />
        </asp:BoundField>  
        <asp:BoundField DataField="dtm_FechaEmision" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Emisión" />
        <asp:BoundField DataField="dtm_FechaRecepcion" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Recepción" /> 
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
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="btnAprobar"  CommandArgument='<%#Container.DataItemIndex() %>' CommandName="APROBAR" ImageUrl="../images/btnAprobar.gif" runat="server" onmouseover="this.src='../images/btnAprobar_on.gif'" onmouseout="this.src='../images/btnAprobar.gif'" />
            </ItemTemplate>
        </asp:TemplateField> 
         <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="btnAtender"  CommandArgument='<%#Container.DataItemIndex() %>' CommandName="ATENDER" ImageUrl="../images/btnGenerar.gif" runat="server" onmouseover="this.src='../images/btnGenerar_on.gif'" onmouseout="this.src='../images/btnGenerar.gif'" />
            </ItemTemplate>
        </asp:TemplateField> 
         <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="btnCerrar"  CommandArgument='<%#Container.DataItemIndex() %>'  CommandName="CERRAR" ImageUrl="../images/btnCerrar.gif" runat="server" onmouseover="this.src='../images/btnCerrar_on.gif'" onmouseout="this.src='../images/btnCerrar.gif'" />
            </ItemTemplate>
        </asp:TemplateField> 
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="btnEliminar"  CommandArgument='<%#Container.DataItemIndex() %>'  CommandName="ELIMINAR" ImageUrl="../images/btnEliminar.gif" runat="server" onmouseover="this.src='../images/btnEliminar_on.gif'" onmouseout="this.src='../images/btnEliminar.gif'" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <HeaderStyle CssClass="GridHeader" />
    <FooterStyle CssClass="GridFooter" />
    <AlternatingRowStyle CssClass="GridAltItem" />
    <RowStyle CssClass="GridItem" />
    </asp:GridView>

    <asp:Panel ID="pnlValidadorRegistro" runat="server" CssClass="Formulario"> 
        <UC:ValidadorRegistro id="ctlValidadorRegistro" runat="server"></UC:ValidadorRegistro>
    </asp:Panel>


     <asp:Panel ID="pnlAtencion" runat="server" CssClass="Formulario"> 
        <div id="divTitulo">ATENCION DE REQUISICION</div>
        <table>
            
            <tr>
                <td align="center">
                    <asp:Button  ID="btnValeSalida" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'" onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif"  Width="190px" Height="50px" Text="VALE DE SALIDA"/>
                    
                    <asp:Button ID="btnCompraMenor" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'" onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif"  Width="190px" Height="50px" Text ="COMPRA MENOR"/>

                    <asp:Button ID="btnOrdenCompra" runat="server" onmouseover="this.src='../images/btnNuevo_on.gif'" onmouseout="this.src='../images/btnNuevo.gif'" ImageUrl="../images/btnNuevo.gif"  Width="190px" Height="50px" Text ="ORDEN COMPRA/SERVICIO"/>

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

