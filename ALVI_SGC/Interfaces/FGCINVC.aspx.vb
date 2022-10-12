
Partial Class Estandares_FGCINVC
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim dtbComprobantes As New Data.DataTable
            Dim dtbArticulos As New Data.DataTable
            pnlFormulario.Visible = False
            pnlBusqueda.Visible = False
            BindGrid()
            btnFechaInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaInicio.ClientID & ", 'dd/mm/yyyy');")
            btnFechaFin.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaFin.ClientID & ", 'dd/mm/yyyy');")
            btnFechaEmision.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmision.ClientID & ", 'dd/mm/yyyy');")
            btnFecInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFiltro.ClientID & ", 'dd/mm/yyyy');")
            btnFecFin.Attributes.Add("onclick", "popUpCalendar(this, " & txtFecFin.ClientID & ", 'dd/mm/yyyy');")
            BindMoneda(ddlMoneda)
            BindVendedor(ddlVendedor)
            BindMotivo(ddlMotivo)
            btnFecInicio.Visible = False
            btnFecFin.Visible = False
            txtFecFin.Visible = False
            rbtProducto.Checked = False
            rbtServicio.Checked = True
            CreateSchemaComprobantes()
            txtCodigo.Enabled = False
            txtFechaEmision.Text = Format(Now.Date, "dd/MM/yyyy")
        End If
    End Sub
    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        Dim objComprobante As New ALVI_LOGIC.Maestros.Ventas.Notadebito
        LimpiarFormulario()
        txtCodigo.ReadOnly = True
        txtCodigo.MaxLength = 21
        pnlFormulario.Visible = True
        objComprobante.SerieMayor()
        txtNumero.Text = objComprobante.Maximo
        txtCodigo.Focus()
    End Sub
    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub
    Private Sub Cancelar()
        BindGrid()
        LimpiarFormulario()
        pnlFormulario.Visible = False
    End Sub
    Private Sub LimpiarBuscador()
        Dim Limpia As New Data.DataTable
        ddlfiltro.SelectedIndex = 0
        txtFiltro.Text = ""
        grdArticulos.DataSource = Limpia
    End Sub
    Private Sub LimpiarFormulario()
        Dim objComprobante As New ALVI_LOGIC.Maestros.Ventas.Notadebito
        ddlVendedor.Enabled = True
        ddlMoneda.Enabled = True
        txtCodigo.Enabled = True
        txtCorrelativo.Enabled = True
        txtNumero.Enabled = True
        rbtServicio.Enabled = True
        rbtProducto.Enabled = True
        txtFechaEmision.Enabled = True
        ddlMotivo.Enabled = True
        btnBuscaComprobante.Visible = True
        grdComprobante.Enabled = True
        btnFechaEmision.Visible = True
        ddlTipoDescuento.Enabled = True
        txtTotal.Enabled = True
        txtTotalParcial.Enabled = True
        txtTotalDesc.Enabled = True
        txtTotalDescVisible.Enabled = True
        txtIGV.Enabled = True
        txtSubTotal.Enabled = True
        txtGlosa.Enabled = True
        objComprobante.SerieMayor()
        CreateSchemaComprobantesAsignados()
        txtNumero.Text = objComprobante.Maximo
        txtCodigo.ReadOnly = True
        pnlFormulario.Visible = True
        txtCodigo.Text = ""
        txtNumero.Text = ""
        txtTotalDescVisible.Text = ""
        txtCorrelativo.Text = ""
        lblMensaje.Text = ""
        txtGlosa.Text = ""
        txtFechaEmision.Text = Format(Now.Date, "dd/MM/yyyy")
        txtTotalParcial.Text = ""
        txtTotalDesc.Text = ""
        txtSubTotal.Text = ""
        txtIGV.Text = ""
        txtTotal.Text = ""

        ddlVendedor.SelectedIndex = 0
        ctlCliente2.Limpia()
        CreateSchemaComprobantes()
        Dim dtbComprobantes As Data.DataTable = CType(Session("dtbComprobantes"), Data.DataTable)
        Dim dtbArticulos As Data.DataTable = CType(Session("dtbArticulos"), Data.DataTable)
        grdComprobante.DataSource = dtbComprobantes
        grdComprobante.DataBind()
    End Sub
    Private Sub BindMoneda(ByRef pddlAtributos As DropDownList)
        Dim objAtributos As New ALVI_LOGIC.Maestros.Administracion.Moneda
        pddlAtributos.Items.Clear()
        If objAtributos.Listar() = True Then
            pddlAtributos.DataValueField = "var_IdMoneda"
            pddlAtributos.DataTextField = "var_DesMoneda"
            pddlAtributos.DataSource = objAtributos.Datos
            pddlAtributos.DataBind()
        End If
        pddlAtributos.SelectedIndex = 0
    End Sub
    Private Sub BindVendedor(ByRef pddlVendedor As DropDownList)
        Dim objAtributos As New ALVI_LOGIC.Maestros.Ventas.Vendedor
        pddlVendedor.Items.Clear()
        If objAtributos.Listar() = True Then
            pddlVendedor.DataValueField = "var_IdVendedor"
            pddlVendedor.DataTextField = "var_Nombrecompleto"
            pddlVendedor.DataSource = objAtributos.Datos
            pddlVendedor.DataBind()
        End If
        pddlVendedor.Items.Insert(0, New ListItem("Seleccionar", ""))
        pddlVendedor.SelectedIndex = 0
    End Sub
    Private Sub BindMotivo(ByRef pddlMotivo As DropDownList)
        Dim objMotivos As New ALVI_LOGIC.Maestros.Ventas.AtributoMotivo
        objMotivos.IdMotivo = "ND"
        pddlMotivo.Items.Clear()
        If objMotivos.Listar() = True Then
            pddlMotivo.DataValueField = "var_IdMotivoAtributo"
            pddlMotivo.DataTextField = "var_Descripcion"
            pddlMotivo.DataSource = objMotivos.Datos
            pddlMotivo.DataBind()
        End If
        pddlMotivo.Items.Insert(0, New ListItem("Seleccionar", ""))
        pddlMotivo.SelectedIndex = 0
    End Sub
    Private Sub BindValores(ByRef pddlValores As DropDownList, ByVal pstrIdAtributoTipo As String)
        Dim objValores As New ALVI_LOGIC.Maestros.Pedido.PedidoValor
        pddlValores.Items.Clear()
        objValores.IdAtributoTipo = pstrIdAtributoTipo
        If objValores.Listar() = True Then
            pddlValores.DataValueField = "var_IdAtributoValor"
            pddlValores.DataTextField = "var_Descripcion"
            pddlValores.DataSource = objValores.Datos
            pddlValores.DataBind()
        End If
        pddlValores.Items.Insert(0, New ListItem("Seleccionar", ""))
        pddlValores.SelectedIndex = 0
    End Sub
    Private Sub BindDocumentos(ByRef pddlDocumentos As DropDownList)
        Dim objValores As New ALVI_LOGIC.Maestros.Administracion.TipoDocumento
        objValores.Clasificacion = "S"
        pddlDocumentos.Items.Clear()
        If objValores.Listar() = True Then
            pddlDocumentos.DataValueField = "chr_IdTipoDocumento"
            pddlDocumentos.DataTextField = "var_Descripcion"
            pddlDocumentos.DataSource = objValores.Datos
            pddlDocumentos.DataBind()
        End If
        pddlDocumentos.Items.Insert(0, New ListItem("Seleccionar", ""))
        pddlDocumentos.SelectedIndex = 2
    End Sub
    Private Sub CreateSchemaComprobantes()
        Dim dtbComprobantes As New Data.DataTable
        dtbComprobantes.Columns.Add("int_Secuencia", GetType(Int16))
        dtbComprobantes.Columns.Add("var_IdCliente", GetType(String))
        dtbComprobantes.Columns.Add("var_IdComprobante", GetType(String))
        dtbComprobantes.Columns.Add("dtm_FechaEmision", GetType(String))
        dtbComprobantes.Columns.Add("dtm_FechaVencimiento", GetType(String))
        dtbComprobantes.Columns.Add("var_TipoServicio", GetType(String))
        Dim pkTelas(1) As Data.DataColumn
        pkTelas(0) = dtbComprobantes.Columns("int_Secuencia")
        dtbComprobantes.PrimaryKey = pkTelas
        Session("dtbComprobantes") = dtbComprobantes
    End Sub
    Private Sub CreateSchemaArticulosAsignados()
        Dim dtbArtAsignados As New Data.DataTable
        dtbArtAsignados.Columns.Add("int_Secuencia", GetType(Integer))
        dtbArtAsignados.Columns.Add("var_Tipo", GetType(String))
        dtbArtAsignados.Columns.Add("var_IdComprobante", GetType(String))
        dtbArtAsignados.Columns.Add("var_IdArticulo", GetType(String))
        dtbArtAsignados.Columns.Add("var_DesArticulo", GetType(String))
        dtbArtAsignados.Columns.Add("num_Cantidad", GetType(String))
        dtbArtAsignados.Columns.Add("num_CostoUnitario", GetType(String))
        dtbArtAsignados.Columns.Add("num_ImportePantalla", GetType(String))
        dtbArtAsignados.Columns.Add("num_DescPantalla", GetType(String))
        Dim pkTelas(1) As Data.DataColumn
        pkTelas(0) = dtbArtAsignados.Columns("int_Secuencia")

        dtbArtAsignados.PrimaryKey = pkTelas
        Session("dtbArtAsignados") = dtbArtAsignados
    End Sub
    Private Sub CreateSchemaComprobantesAsignados()
        Dim dtbComprobantes As New Data.DataTable
        dtbComprobantes.Columns.Add("var_IdComprobante", GetType(String))
        dtbComprobantes.Columns.Add("int_Secuencia", GetType(String))
        Dim pkTelas(1) As Data.DataColumn
        pkTelas(0) = dtbComprobantes.Columns("var_IdComprobante")
        dtbComprobantes.PrimaryKey = pkTelas
        Session("dtbComprobantesAsignados") = dtbComprobantes
    End Sub
    Private Sub BindGrid()
        Dim objComprobante As New ALVI_LOGIC.Maestros.Ventas.Notadebito
        Dim dtbDatos As New Data.DataTable
        dtbDatos.Columns.Add("var_IdNota", GetType(String))
        dtbDatos.Columns.Add("var_Nota", GetType(String))
        dtbDatos.Columns.Add("var_IdCliente", GetType(String))
        dtbDatos.Columns.Add("dtm_FechaEmision", GetType(String))
        dtbDatos.Columns.Add("var_Estado", GetType(String))
        dtbDatos.Columns.Add("var_TipoOperacion", GetType(String))
        dtbDatos.Columns.Add("var_idVendedor", GetType(String))
        dtbDatos.Columns.Add("var_Comprobante", GetType(String))
        objComprobante.Idnota = txtIdNota.Text
        objComprobante.SerieNota = txtSerieNota.Text
        objComprobante.IdCliente = txtCliente.Text
        objComprobante.FechaInicio = txtFechaInicio.Text
        objComprobante.NumeroNota = txtNumNota.Text
        objComprobante.FechaFin = txtFechaFin.Text
        txtCorrelativo.ReadOnly = True
        objComprobante.Buscar()
        Try
            For Each dtrItem As Data.DataRow In objComprobante.Datos.Rows
                Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                Dim FechaIngreso As DateTime
                dtrNuevo("var_IdNota") = dtrItem("var_IdNota")
                dtrNuevo("var_Nota") = dtrItem("var_Nota")
                dtrNuevo("var_IdCliente") = dtrItem("var_IdCliente")
                FechaIngreso = CDate(dtrItem("dtm_FechaEmision"))
                dtrNuevo("dtm_FechaEmision") = Format(FechaIngreso, "dd/MM/yyyy")
                dtrNuevo("var_Estado") = dtrItem("var_Estado")
                dtrNuevo("var_TipoOperacion") = dtrItem("var_TipoOperacion")
                dtrNuevo("var_idVendedor") = dtrItem("var_idVendedor")
                dtbDatos.Rows.Add(dtrNuevo.ItemArray)
                dtbDatos.AcceptChanges()
            Next
        Catch
        End Try
        Session("dtbArticulos") = dtbDatos
        grdDatos.DataSource = Session("dtbArticulos")
        grdDatos.DataBind()
    End Sub
    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        Registrar()
        txtCodigo.Focus()
    End Sub
    Private Sub Registrar()
        Dim dtbArticulos As Data.DataTable = CType(Session("dtbArticulos"), Data.DataTable)
        Dim Condicion As String = 1
        Condicion = hdnIdCliente.Value.CompareTo(ctlCliente2.IdCliente)
        If Condicion > 0 Then
            ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('El Cliente Seleccionado no coincide con el de los comprobantes elegidos.');</script>")
        End If
        If txtFechaEmision.Text <> "" AndAlso ctlCliente2.RazonSocial <> "" AndAlso Condicion < 1 _
            AndAlso grdComprobante.Rows.Count > 0 Then
            Dim objNota As New ALVI_LOGIC.Maestros.Ventas.NotaDebito
            objNota.Idnota = txtCodigo.Text
            objNota.IdCliente = ctlCliente2.IdCliente.ToString
            objNota.idVendedor = ddlVendedor.SelectedValue.ToString
            objNota.idMoneda = ddlMoneda.SelectedValue
            objNota.SerieNota = txtNumero.Text
            objNota.NumeroNota = txtCorrelativo.Text
            objNota.IdComprobante = ""
            If rbtServicio.Checked Then
                objNota.TipoOperacion = "S"
            Else
                objNota.TipoOperacion = "P"
            End If
            objNota.FechaEmision = txtFechaEmision.Text
            objNota.Estado = ddlEstado.SelectedValue
            objNota.Usuario = Session("Usuario")
            objNota.IdMotivo = ddlMotivo.SelectedValue
            objNota.IdTipoNota = ddlTipoDescuento.SelectedValue
            objNota.totalParcial = CDbl(txtTotalParcial.Text)
            objNota.Subtotal = CDbl(txtSubTotal.Text)
            objNota.Descuento = CDbl(txtTotalDesc.Text.Replace("%", ""))
            objNota.IGV = CDbl(txtIGV.Text.Replace("%", ""))
            objNota.Total = CDbl(txtTotal.Text)
            objNota.Glosa = txtGlosa.Text
            If objNota.Registrar(dtbArticulos) = True Then
                LimpiarFormulario()
                lblMensaje.Text = "Registro exitoso"
                dtbArticulos.Rows.Clear()
                BindGrid()
                grdDatos.EditIndex = -1
            Else
                lblMensaje.Text = "Datos Incorrectos"
            End If
        Else
            ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('Faltan Datos.');</script>")
        End If
    End Sub
    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        Response.Redirect("default.aspx")
    End Sub
    Protected Sub grdDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDatos.PageIndexChanging
        grdDatos.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub
    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        If e.CommandName = "Modificar" Then
            Dim objComprobante As New ALVI_LOGIC.Maestros.Ventas.Notadebito
            objComprobante.Idnota = e.CommandArgument.ToString
            If objComprobante.Obtener = True Then
                LimpiarFormulario()
                txtNumero.Text = ""
                ctlCliente2.IdCliente = objComprobante.IdCliente
                ctlCliente2.RazonSocial = objComprobante.Cliente
                Try
                    ddlVendedor.SelectedValue = objComprobante.idVendedor
                Catch
                    ddlVendedor.SelectedIndex = 1
                End Try
                ddlVendedor.Enabled = False
                ddlMotivo.Enabled = False

                txtTotal.Text = Format(CDbl(objComprobante.Total), "#,###,##0.00")
                txtTotalParcial.Text = Format(CDbl(objComprobante.totalParcial), "#,###,##0.00")
                txtTotalDesc.Text = objComprobante.Descuento.ToString + " %"
                txtIGV.Text = Format(CDbl(objComprobante.IGV), "#,###,##0.00")
                txtSubTotal.Text = Format(CDbl(objComprobante.Subtotal), "#,###,##0.00")
                txtTotal.Enabled = False
                txtTotalParcial.Enabled = False
                txtTotalDesc.Enabled = False
                txtIGV.Enabled = False
                txtSubTotal.Enabled = False

                ddlMoneda.SelectedValue = objComprobante.idMoneda
                ddlMoneda.Enabled = False
                txtCodigo.Text = objComprobante.Idnota
                txtCodigo.Enabled = False
                txtCorrelativo.Text = objComprobante.NumeroNota
                txtCorrelativo.Enabled = False
                txtNumero.Text = objComprobante.SerieNota
                txtNumero.Enabled = False
                If objComprobante.TipoOperacion = "S" Then
                    rbtServicio.Checked = True
                    rbtProducto.Checked = False
                    rbtServicio.Enabled = False
                    rbtProducto.Enabled = False
                Else
                    rbtServicio.Checked = False
                    rbtProducto.Checked = True
                    rbtServicio.Enabled = False
                    rbtProducto.Enabled = False
                End If
                txtFechaEmision.Text = objComprobante.FechaEmision
                txtFechaEmision.Enabled = False
                ddlEstado.SelectedValue = objComprobante.Estado
                ddlMotivo.Enabled = False
                txtTotalDescVisible.Enabled = False
                BindGridDetalle(e.CommandArgument)
                grdComprobante.Enabled = False
                btnFechaEmision.Visible = False
                txtGlosa.Text = objComprobante.Glosa
                txtGlosa.Enabled = False
                txtCodigo.ReadOnly = True
                btnBuscaComprobante.Visible = False
                txtCodigo.MaxLength = 20
                pnlFormulario.Visible = True
            End If
        End If
        If e.CommandName = "Eliminar" Then
            Dim objComprobante As New ALVI_LOGIC.Maestros.Ventas.Notadebito
            Dim strParametros As String = e.CommandArgument.ToString
            objComprobante.Idnota = e.CommandArgument.ToString
            If objComprobante.Eliminar = True Then
                BindGrid()
            Else
                ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('No se Pudo eliminar el Pedido.');</script>")
                BindGrid()
            End If
        End If
    End Sub
    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTerminar.Click
        Registrar()
        If lblMensaje.Text = "Registro exitoso" Then
            pnlFormulario.Visible = False
        End If
    End Sub
    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        BindGrid()
    End Sub
    Private Sub BindGridDetalle(ByVal Numero As String)
        CreateSchemaComprobantes()
        Dim objAtributo As New ALVI_LOGIC.Maestros.Ventas.Notadebito
        objAtributo.Idnota = Numero
        objAtributo.ObtenerAtributos()
        Dim dtbAsignados As New Data.DataTable
        Dim dtbDatos As New Data.DataTable
        Dim intSecuencia As Int16 = 0
        dtbDatos.Columns.Add("int_Secuencia", GetType(Integer))
        dtbDatos.Columns.Add("var_Tipo", GetType(String))
        dtbDatos.Columns.Add("var_IdComprobante", GetType(String))
        dtbDatos.Columns.Add("var_IdArticulo", GetType(String))
        dtbDatos.Columns.Add("var_DesArticulo", GetType(String))
        dtbDatos.Columns.Add("num_Cantidad", GetType(String))
        dtbDatos.Columns.Add("num_CostoUnitario", GetType(String))
        dtbDatos.Columns.Add("num_ImportePantalla", GetType(String))
        dtbDatos.Columns.Add("num_DescPantalla", GetType(String))
        dtbDatos.Columns.Add("num_Comprobante", GetType(Integer))
        dtbDatos.Columns.Add("var_IdTipo", GetType(String))
        dtbDatos.Columns.Add("num_ImporteOriginal", GetType(String))
        Try

            For Each dtrItem As Data.DataRow In objAtributo.DatosArticulos.Rows
                Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                dtrNuevo("var_Tipo") = dtrItem("var_Tipo")
                dtrNuevo("var_IdComprobante") = dtrItem("var_IdComprobante")
                dtrNuevo("var_IdArticulo") = dtrItem("var_IdArticulo")
                dtrNuevo("var_DesArticulo") = dtrItem("var_DesArticulo")
                dtrNuevo("num_Cantidad") = dtrItem("num_Cantidad")
                dtrNuevo("num_CostoUnitario") = Math.Round(CDbl(dtrItem("num_ImportePantalla")) / CDbl(dtrItem("num_Cantidad")), 2)
                dtrNuevo("num_ImportePantalla") = Math.Round(CDbl(dtrItem("num_ImportePantalla")), 2)
                dtrNuevo("num_Comprobante") = dtrItem("num_Comprobante")
                dtrNuevo("var_IdTipo") = dtrItem("var_IdTipo")
                dtrNuevo("num_ImporteOriginal") = Math.Round(CDbl(dtrItem("num_ImportePantalla")), 2)
                Try
                    intSecuencia = dtbDatos.Compute("Max(int_Secuencia)", "") + 1
                Catch
                    intSecuencia = 0
                End Try
                dtrNuevo("int_Secuencia") = intSecuencia
                dtbDatos.Rows.Add(dtrNuevo.ItemArray)
                dtbDatos.AcceptChanges()
            Next
        Catch
        End Try
        Session("dtbArticulos") = dtbDatos
        grdComprobante.DataSource = Session("dtbArticulos")
        grdComprobante.DataBind()
    End Sub
    Protected Sub grdDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDatos.RowDataBound
    End Sub

    Protected Sub grdComprobante_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdComprobante.RowCreated
        Totales()
    End Sub
    Protected Sub grdComprobante_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdComprobante.RowDeleting
        Dim dtbArticulos As Data.DataTable = CType(Session("dtbComprobantes"), Data.DataTable)
        Dim dtbTemporal As Data.DataTable = dtbArticulos.Clone
        Dim strIndice As String = grdComprobante.Rows(e.RowIndex).Cells(0).Text
        For Each itmAtributoTela As Data.DataRow In dtbArticulos.Rows
            If itmAtributoTela("int_Secuencia") <> strIndice Then
                dtbTemporal.LoadDataRow(itmAtributoTela.ItemArray, True)
                dtbTemporal.AcceptChanges()
            End If
        Next
        Session("dtbArticulos") = dtbTemporal
        grdComprobante.DataSource = dtbTemporal
        grdComprobante.DataBind()
        If grdComprobante.Rows.Count = 0 Then
            ddlTipoDescuento.Enabled = True
        End If
        Totales()
    End Sub
    Protected Sub rbtProducto_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtProducto.CheckedChanged
        rbtServicio.Checked = False
    End Sub
    Protected Sub rbtServicio_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtServicio.CheckedChanged
        rbtProducto.Checked = False
    End Sub
    Protected Sub btnBuscaComprobante_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscaComprobante.Click
        Dim dtbLimpia As New Data.DataTable
        If hdnIdCliente.Value = "" AndAlso ctlCliente2.IdCliente <> "" Then
            hdnIdCliente.Value = ctlCliente2.IdCliente
        ElseIf hdnIdCliente.Value <> "" AndAlso ctlCliente2.IdCliente = "" AndAlso grdComprobante.Rows.Count = 0 Then

        End If
        grdArticulos.DataSource = dtbLimpia
        grdArticulos.DataBind()
        grdBusqueda.DataSource = dtbLimpia
        grdBusqueda.DataBind()
        txtFiltro.Text = ""
        btnFecInicio.Visible = False
        txtFecFin.Visible = False
        btnFecFin.Visible = False
        pnlBusqueda.Visible = True
        pnlFormulario.Visible = False
    End Sub
    Public Sub BuscarComprobante()
        If ctlCliente2.IdCliente = "" AndAlso grdArticulos.Rows.Count = 0 AndAlso grdComprobante.Rows.Count = 0 Then
            hdnIdCliente.Value = ""
        End If
        Dim objComprobante As New ALVI_LOGIC.Maestros.Ventas.Factura
        Dim IdComprobante As String = ""
        Dim NumeroComprobante As String = ""
        Dim IdCliente As String = hdnIdCliente.Value.ToString
        Dim Correlativo As String = ""
        objComprobante.IdCliente = IdCliente
        objComprobante.IdComprobante = ""
        objComprobante.Correlativo = ""
        objComprobante.Moneda = ""
        objComprobante.Monto = ""
        objComprobante.Cliente = ""
        objComprobante.FechaIngreso = ""
        objComprobante.FechaEntrega = ""
        If ddlfiltro.SelectedValue = 2 Then
            objComprobante.IdComprobante = txtFiltro.Text
        ElseIf ddlfiltro.SelectedValue = 3 Then
            objComprobante.Correlativo = txtFiltro.Text
        ElseIf ddlfiltro.SelectedValue = 4 Then
            objComprobante.Monto = txtFiltro.Text
        ElseIf ddlfiltro.SelectedValue = 5 Then
            objComprobante.Cliente = txtFiltro.Text
        ElseIf ddlfiltro.SelectedValue = 6 Then
            objComprobante.FechaIngreso = txtFiltro.Text
            objComprobante.FechaEntrega = txtFecFin.Text
        ElseIf ddlfiltro.SelectedValue = 7 Then
            objComprobante.Moneda = txtFiltro.Text
        End If
        objComprobante.AsignarComprobante()
        grdBusqueda.DataSource = objComprobante.Datos
        grdBusqueda.DataBind()
    End Sub
    Protected Sub grdBusqueda_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdBusqueda.RowCommand
        If e.CommandName = "Asignar" Then
            If grdBusqueda.Rows.Count = 0 Then
                Dim dtbNuevo As New Data.DataTable
                Session("dtbComprobantesAsignados") = dtbNuevo
            End If
            Dim dtbArticulos As Data.DataTable
            dtbArticulos = CType(Session("dtbComprobantesAsignados"), Data.DataTable)
            Dim dtrNuevoArticulo As Data.DataRow = dtbArticulos.NewRow
            Dim intSecuencia As Int16 = 0
            Dim hdIdValor As String = hdnIdCliente.Value
            grdBusqueda.SelectedIndex = e.CommandArgument
            If hdnIdCliente.Value = "" Or hdnIdCliente.Value = grdBusqueda.SelectedRow.Cells(2).Text Or grdArticulos.Rows.Count = 0 Then
                dtrNuevoArticulo("var_IdComprobante") = grdBusqueda.SelectedRow.Cells(1).Text
                Try
                    dtrNuevoArticulo("Int_Secuencia") = dtbArticulos.Compute("", "max(Int_Secuencia") + 1
                Catch
                    dtrNuevoArticulo("Int_Secuencia") = 0
                End Try
                hdnIdCliente.Value = grdBusqueda.SelectedRow.Cells(2).Text
                Dim pkTelas(1) As Data.DataColumn
                pkTelas(0) = dtbArticulos.Columns("var_IdComprobante")
                dtbArticulos.LoadDataRow(dtrNuevoArticulo.ItemArray, True)
                dtbArticulos.AcceptChanges()
                dtbArticulos.PrimaryKey = pkTelas
                Session("dtbComprobantesAsignados") = dtbArticulos
                BindGridArticulos()
            Else
                ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('El Cliente no coincide con el Asignado.');</script>")
            End If
        End If
    End Sub
    Private Sub BindGridArticulos()
        Dim dtbAsignados As New Data.DataTable
        Dim dtbDatos As New Data.DataTable
        Dim objArticulo As New ALVI_LOGIC.Maestros.Ventas.Factura
        Dim intSecuencia As Int16 = 0
        dtbAsignados = Session("dtbComprobantesAsignados")
        dtbDatos.Columns.Add("int_Secuencia", GetType(Integer))
        dtbDatos.Columns.Add("var_Tipo", GetType(String))
        dtbDatos.Columns.Add("var_IdComprobante", GetType(String))
        dtbDatos.Columns.Add("var_IdArticulo", GetType(String))
        dtbDatos.Columns.Add("var_DesArticulo", GetType(String))
        dtbDatos.Columns.Add("num_Cantidad", GetType(String))
        dtbDatos.Columns.Add("num_CostoUnitario", GetType(String))
        dtbDatos.Columns.Add("num_ImportePantalla", GetType(String))
        dtbDatos.Columns.Add("num_DescPantalla", GetType(String))
        dtbDatos.Columns.Add("num_Comprobante", GetType(Integer))
        dtbDatos.Columns.Add("var_IdTipo", GetType(String))
        dtbDatos.Columns.Add("num_ImporteOriginal", GetType(String))
        Try
            For index = 0 To dtbAsignados.Rows.Count
                objArticulo.IdComprobante = dtbAsignados.Rows.Item(index).Item(0).ToString
                objArticulo.BuscarArticulos()
                For Each dtrItem As Data.DataRow In objArticulo.Datos.Rows
                    Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                    dtrNuevo("var_Tipo") = dtrItem("var_Tipo")
                    dtrNuevo("var_IdComprobante") = dtrItem("var_IdComprobante")
                    dtrNuevo("var_IdArticulo") = dtrItem("var_IdArticulo")
                    dtrNuevo("var_DesArticulo") = dtrItem("var_DesArticulo")
                    dtrNuevo("num_Cantidad") = dtrItem("num_Cantidad")
                    dtrNuevo("num_CostoUnitario") = Math.Round(CDbl(dtrItem("num_ImportePantalla")) / CDbl(dtrItem("num_Cantidad")), 2)
                    dtrNuevo("num_ImportePantalla") = Math.Round(CDbl(dtrItem("num_ImportePantalla")), 2)
                    dtrNuevo("num_Comprobante") = dtrItem("num_Comprobante")
                    dtrNuevo("var_IdTipo") = dtrItem("var_IdTipo")
                    dtrNuevo("num_ImporteOriginal") = Math.Round(CDbl(dtrItem("num_ImportePantalla")), 2)
                    Try
                        intSecuencia = dtbDatos.Compute("Max(int_Secuencia)", "") + 1
                    Catch
                        intSecuencia = 0
                    End Try
                    dtrNuevo("int_Secuencia") = intSecuencia
                    dtbDatos.Rows.Add(dtrNuevo.ItemArray)
                    dtbDatos.AcceptChanges()
                Next
            Next
        Catch
        End Try
        Session("dtbArticulos") = dtbDatos
        grdArticulos.DataSource = Session("dtbArticulos")
        grdArticulos.DataBind()
    End Sub
    Protected Sub btnCancelarDocumento_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelarDocumento.Click
        Dim datos As New Data.DataTable
        Session("dtbComprobantesAsignados") = datos
        grdBusqueda.DataSource = datos
        grdBusqueda.DataBind()
        grdArticulos.DataSource = datos
        grdArticulos.DataBind()
        pnlBusqueda.Visible = False
        pnlFormulario.Visible = True
    End Sub
    Private Sub Totales()
        Dim dtbArticulos As Data.DataTable
        Dim objImpuesto As New ALVI_LOGIC.Maestros.Produccion.Impuesto
        dtbArticulos = CType(Session("dtbArticulos"), Data.DataTable)
        Dim Parcial As String = 0
        Dim Desc As String = 0
        Dim SumCantidades As String = 0
        Dim SubTotal As String = 0
        Dim ImporteSinDescuento As String = 0
        objImpuesto.ObtenerImpuesto1()
        Dim IGV As String = (CDbl(objImpuesto.Impuesto1) / 100).ToString
        Dim Total As String = 0
        Dim ImporteIngresado As String = 0
        Dim ImporteCalculado As String = 0
        Dim objComprobante As New ALVI_LOGIC.Maestros.Ventas.Notadebito

        If objComprobante.IGV > 0 AndAlso objComprobante.Total > 0 AndAlso objComprobante.Subtotal > 0 AndAlso objComprobante.totalParcial > 0 Then
            txtTotalParcial.Text = objComprobante.totalParcial.ToString
            txtTotalDesc.Text = objComprobante.Descuento.ToString
            txtSubTotal.Text = objComprobante.Subtotal.ToString
            txtIGV.Text = objComprobante.IGV.ToString
            txtTotal.Text = objComprobante.Total.ToString
        ElseIf dtbArticulos.Rows.Count > 0 AndAlso txtTotal.Enabled = True Then
            For Each itmAtributoTela As Data.DataRow In dtbArticulos.Rows
                Try
                    Dim Ingresado As String = itmAtributoTela("num_ImporteOriginal")
                    Dim Calculado As String = itmAtributoTela("num_ImportePantalla")
                    Dim Descuento As String = itmAtributoTela("num_DescPantalla")
                    Dim Cantidad As String = itmAtributoTela("num_Cantidad")
                    Dim CostoUnitario As String = itmAtributoTela("num_CostoUnitario")
                    Ingresado = Ingresado.Replace(",", ".")
                    Calculado = Calculado.Replace(",", ".")
                    Descuento = Descuento.Replace(",", ".")
                    Cantidad = Cantidad.Replace(",", ".")
                    CostoUnitario = CostoUnitario.Replace(",", ".")

                    If ddlTipoDescuento.SelectedValue = 0 Then
                        ImporteCalculado = CDbl(Calculado) + CDbl(ImporteCalculado)
                        ImporteIngresado = CDbl(Ingresado) + CDbl(ImporteIngresado)
                        Total = ImporteCalculado
                    ElseIf ddlTipoDescuento.SelectedValue = 1 Then
                        ImporteCalculado = (CDbl(Ingresado) * (Descuento / 100)) + CDbl(ImporteCalculado)
                        ImporteIngresado = CDbl(Ingresado) + CDbl(ImporteIngresado)
                        Total = ImporteCalculado
                    End If
                Catch
                    ImporteIngresado = 0
                    ImporteCalculado = 0
                    Total = 0
                End Try
            Next
            IGV = CDbl(ImporteCalculado) - (CDbl(ImporteCalculado) / (1 + IGV))
            Desc = (ImporteCalculado / ImporteIngresado) * 100
            SubTotal = Total - (IGV)
            Parcial = SubTotal + (SubTotal * (Desc / 100))
            txtTotalParcial.Text = Format(CDbl(SubTotal), "#,###,##0.00")
            'Format(CDbl(Parcial), "#,###,##0.00")
            txtTotalDesc.Text = Math.Round(CDbl(Desc), 2).ToString + " %"
            txtSubTotal.Text = Format(CDbl(SubTotal), "#,###,##0.00")
            txtIGV.Text = Format(Math.Round(CDbl(IGV), 2), "#,###,##0.00")
            txtTotal.Text = Format(CDbl(Total), "#,###,##0.00")
        ElseIf grdComprobante.Rows.Count = 0 AndAlso txtTotal.Enabled = True Then
            txtTotalParcial.Text = ""
            txtTotalDesc.Text = ""
            txtSubTotal.Text = ""
            txtIGV.Text = ""
            txtTotal.Text = ""
        End If
    End Sub
    Protected Sub grdArticulos_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdArticulos.RowDeleting
        Dim dtbArticulos As Data.DataTable = CType(Session("dtbArticulos"), Data.DataTable)
        Dim dtbTemporal As Data.DataTable = dtbArticulos.Clone
        Dim strIndice As String = grdArticulos.Rows(e.RowIndex).Cells(0).Text
        Dim dtbClientes As Data.DataTable = CType(Session("dtbComprobantesAsignados"), Data.DataTable)
        Dim dtbTempCliente As Data.DataTable = dtbClientes.Clone
        For Each itmAtributoTela As Data.DataRow In dtbArticulos.Rows
            If itmAtributoTela("int_Secuencia") <> strIndice Then
                dtbTemporal.LoadDataRow(itmAtributoTela.ItemArray, True)
                dtbTemporal.AcceptChanges()
            End If
        Next
        For Each itmAtributoClientes As Data.DataRow In dtbClientes.Rows
            If itmAtributoClientes("int_Secuencia") <> strIndice Then
                dtbTempCliente.LoadDataRow(itmAtributoClientes.ItemArray, True)
                dtbTempCliente.AcceptChanges()
            End If
        Next
        Session("dtbArticulos") = dtbTemporal
        grdArticulos.DataSource = dtbTemporal
        Session("dtbComprobantesAsignados") = dtbTempCliente
        grdArticulos.DataBind()
    End Sub
    Protected Sub grdArticulos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdArticulos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If ddlTipoDescuento.SelectedValue = 0 Then
                Dim gvrow As GridViewRow = CType(e.Row.Cells(7).NamingContainer, GridViewRow)
                Dim Descuento As TextBox = CType(gvrow.FindControl("txtDescPantalla"), TextBox)
                Descuento.Text = "-"
                Descuento.Enabled = False
                Descuento.BackColor = Drawing.Color.LightGray
            ElseIf ddlTipoDescuento.SelectedValue = 1 Then
                Dim gvrow As GridViewRow = CType(e.Row.Cells(8).NamingContainer, GridViewRow)
                Dim Importe As TextBox = CType(gvrow.FindControl("txtImporte"), TextBox)
                Importe.Enabled = False
                Importe.BackColor = Drawing.Color.LightGray
            End If
        End If
    End Sub

    Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnFiltrar.Click
        If grdArticulos.Rows.Count = 0 AndAlso grdComprobante.Rows.Count = 0 AndAlso ctlCliente2.IdCliente = "" Then
            CreateSchemaComprobantesAsignados()
        End If
        BuscarComprobante()
    End Sub

    Protected Sub ddlfiltro_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlfiltro.SelectedIndexChanged
        If ddlfiltro.SelectedValue = 6 Then
            btnFecInicio.Visible = True
            btnFecFin.Visible = True
            txtFecFin.Visible = True
            txtFiltro.Text = Format(Now.Date.AddDays(-7), "dd/MM/yyyy")
            txtFecFin.Text = Format(Now.Date, "dd/MM/yyyy")
        Else
            txtFiltro.Text = ""
            txtFecFin.Text = ""
            btnFecInicio.Visible = False
            btnFecFin.Visible = False
            txtFecFin.Visible = False
        End If
    End Sub

    Protected Sub btnDocumentoAceptar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnDocumentoAceptar.Click
        Dim dtbDatos As New Data.DataTable
        Dim Condicion As Integer = 1
        Dim intSecuencia As Int32 = -1
        Dim Secuencia As Int32 = 0
        dtbDatos.Columns.Add("int_Secuencia", GetType(Integer))
        dtbDatos.Columns.Add("var_Tipo", GetType(String))
        dtbDatos.Columns.Add("var_IdComprobante", GetType(String))
        dtbDatos.Columns.Add("var_IdArticulo", GetType(String))
        dtbDatos.Columns.Add("var_DesArticulo", GetType(String))
        dtbDatos.Columns.Add("num_Cantidad", GetType(String))
        dtbDatos.Columns.Add("num_CostoUnitario", GetType(String))
        dtbDatos.Columns.Add("num_ImportePantalla", GetType(String))
        dtbDatos.Columns.Add("num_DescPantalla", GetType(String))
        dtbDatos.Columns.Add("num_Comprobante", GetType(Integer))
        dtbDatos.Columns.Add("var_IdTipo", GetType(String))
        dtbDatos.Columns.Add("num_ImporteOriginal", GetType(String))
        Dim grdPrueba As New GridView
        grdPrueba.DataSource = Session("dtbArticulos")
        grdPrueba.DataBind()
        For Each dtrItem As GridViewRow In grdArticulos.Rows
            Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
            Dim Descuento As TextBox = CType(dtrItem.FindControl("txtDescPantalla"), TextBox)
            Dim Importe As TextBox = CType(dtrItem.FindControl("txtImporte"), TextBox)
            Dim Item As Int32 = dtrItem.RowIndex
            dtrNuevo("int_Secuencia") = Secuencia
            dtrNuevo("var_Tipo") = grdPrueba.Rows.Item(Item).Cells(1).Text
            dtrNuevo("var_IdComprobante") = grdPrueba.Rows.Item(Item).Cells(2).Text
            dtrNuevo("var_IdArticulo") = grdPrueba.Rows.Item(Item).Cells(3).Text
            dtrNuevo("var_DesArticulo") = HttpUtility.HtmlDecode(grdPrueba.Rows.Item(Item).Cells(4).Text.ToString)
            dtrNuevo("num_Cantidad") = grdPrueba.Rows.Item(Item).Cells(5).Text
            dtrNuevo("num_Comprobante") = CInt(grdPrueba.Rows.Item(Item).Cells(9).Text)
            dtrNuevo("var_IdTipo") = grdPrueba.Rows.Item(Item).Cells(10).Text
            dtrNuevo("num_ImporteOriginal") = grdPrueba.Rows.Item(Item).Cells(11).Text
            If Importe.Text = "" Then
                Importe.Text = 0
            End If
            If Descuento.Text = "" Then
                Descuento.Text = 0
            ElseIf Descuento.Text = "-" Then
                Descuento.Text = 0
            End If
            Dim strComprobante As String = dtrItem.Cells(8).Text
            If strComprobante = "" Then
                strComprobante = 0
            End If
            Dim ImpComprobante As Double = strComprobante
            Dim ImpDescuento As Double = Importe.Text
            If ImpComprobante < ImpDescuento Then
                Condicion = 0
            End If
            If Descuento.Text > 0 Then
                Dim Imp As String = Importe.Text
                Importe.Text = CDbl(Imp) * (CDbl(Descuento.Text) / 100)
            End If
            dtrNuevo("num_DescPantalla") = Descuento.Text
            dtrNuevo("num_ImportePantalla") = Importe.Text
            dtrNuevo("num_CostoUnitario") = Math.Round((Importe.Text) / CDbl(grdPrueba.Rows.Item(Item).Cells(5).Text), 2)
            dtbDatos.Rows.Add(dtrNuevo.ItemArray)
            dtbDatos.AcceptChanges()
            Secuencia = Secuencia + 1
        Next
        If Condicion = 1 Then
            Session("dtbArticulos") = dtbDatos
            grdComprobante.DataSource = Session("dtbArticulos")
            grdComprobante.DataBind()
            If grdComprobante.Rows.Count > 0 Then
                ddlTipoDescuento.Enabled = False
                ctlCliente2.IdCliente = hdnIdCliente.Value
                LimpiarBuscador()
                ctlCliente2.BuscarId()
                pnlBusqueda.Visible = False
                pnlFormulario.Visible = True
            End If
        ElseIf Condicion = 0 Then
            ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('El importe Asignado es mayor al del comprobante.');</script>")
        End If

    End Sub
End Class