
Partial Class Interfaces_FGCINIA
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtFecha.Text = Format(Now.Date, "dd/MM/yyyy")
            btnFecha.Attributes.Add("onclick", "popUpCalendar(this, " & txtFecha.ClientID & ", 'dd/mm/yyyy');")
            pnlFormulario.Visible = False
            LimpiarFormulario()
            CreateSchemaDetalle()
            'BindTipoDocumento()
            'BindTipoMovimiento()
            btnImprimir.Attributes.Add("onclick", "javascript:return Buscar('" & hdnIdKardex.ClientID & "');")
        End If
    End Sub

    Private Sub BindTipoDocumento()
        Dim objTipoDocumento As New ALVI_LOGIC.Maestros.Administracion.TipoDocumento
        ddlTipoDocumento.Items.Clear()
        objTipoDocumento.Clasificacion = "I"
        If objTipoDocumento.Listar() = True Then
            ddlTipoDocumento.DataValueField = "chr_IdTipoDocumento"
            ddlTipoDocumento.DataTextField = "var_Descripcion"
            ddlTipoDocumento.DataSource = objTipoDocumento.Datos
            ddlTipoDocumento.DataBind()
        End If
        ddlTipoDocumento.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlTipoDocumento.SelectedIndex = 0
    End Sub

    Private Sub BindTipoMovimiento()
        Dim objTipoMovimiento As New ALVI_LOGIC.Maestros.Logistica.TipoMovimiento
        ddlTipoMovimiento.Items.Clear()
        objTipoMovimiento.Clasificacion = "I"
        If objTipoMovimiento.Listar() = True Then
            ddlTipoMovimiento.DataValueField = "var_IdTipoMovimiento"
            ddlTipoMovimiento.DataTextField = "var_Descripcion"
            ddlTipoMovimiento.DataSource = objTipoMovimiento.Datos
            ddlTipoMovimiento.DataBind()
        End If
        ddlTipoMovimiento.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlTipoMovimiento.SelectedIndex = 0
    End Sub

    Private Sub LimpiarFormulario()
        If pnlFormulario.Visible = True Then
            txtCantidad.Text = 0
            txtCostoUnitario.Text = 0
            txtImporte.Text = 0
            txtObservacionDetalle.Text = ""
            ctlArticulo.IdArticulo = ""
            ctlArticulo.Descripcion = ""
            ctlArticulo.BuscarId()
            BindAlmacen()
        Else
            txtFecha.Text = Format(Now.Date, "dd/MM/yyyy")
            'txtNumeroDocumento.Text = ""
            'txtOPReferencia.Text = ""
            'txtObservacionGeneral.Text = ""
            BindTipoDocumento()
            ddlTipoDocumento.SelectedValue = ""
            BindTipoMovimiento()
            ddlTipoMovimiento.SelectedValue = ""
            CreateSchemaDetalle()
            grdDatos.DataSource = CType(Session("dtbDatos"), Data.DataTable)
            grdDatos.DataBind()
        End If
    End Sub
    Private Sub BindAlmacen()
        Dim objAlmacen As New ALVI_LOGIC.Maestros.Logistica.Almacen
        ddlAlmacen.Items.Clear()
        If objAlmacen.Listar() = True Then
            ddlAlmacen.DataValueField = "var_IdAlmacen"
            ddlAlmacen.DataTextField = "var_Descripcion"
            ddlAlmacen.DataSource = objAlmacen.Datos
            ddlAlmacen.DataBind()
        End If
        ddlAlmacen.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlAlmacen.SelectedIndex = 0
    End Sub
    'Private Sub BindUnidadMedida()
    '    Dim objUnidad As New ALVI_LOGIC.Configuracion.UnidadMedida
    '    ddlUnidadMedida.Items.Clear()
    '    If objUnidad.Listar() = True Then
    '        ddlUnidadMedida.DataValueField = "var_IdUnidadMedida"
    '        ddlUnidadMedida.DataTextField = "var_Descripcion"
    '        ddlUnidadMedida.DataSource = objUnidad.Datos
    '        ddlUnidadMedida.DataBind()
    '    End If
    '    ddlUnidadMedida.Items.Insert(0, New ListItem("Seleccionar", ""))
    '    ddlUnidadMedida.SelectedIndex = 0
    'End Sub

    Private Sub CreateSchemaDetalle()
        Dim dtbDatos As New Data.DataTable
        dtbDatos.Columns.Add("chr_IdFamilia", GetType(String))
        dtbDatos.Columns.Add("var_IdSubFamilia", GetType(String))
        dtbDatos.Columns.Add("var_IdArticulo", GetType(String))
        dtbDatos.Columns.Add("var_Articulo", GetType(String))
        dtbDatos.Columns.Add("var_IdUnidadMedida", GetType(String))
        dtbDatos.Columns.Add("var_UnidadMedida", GetType(String))
        dtbDatos.Columns.Add("var_IdAlmacen", GetType(String))
        dtbDatos.Columns.Add("var_Almacen", GetType(String))
        dtbDatos.Columns.Add("var_IdCentroCosto", GetType(String))
        dtbDatos.Columns.Add("var_CentroCosto", GetType(String))
        dtbDatos.Columns.Add("var_IdCuentaGasto", GetType(String))
        dtbDatos.Columns.Add("var_CuentaGasto", GetType(String))
        dtbDatos.Columns.Add("num_Cantidad", GetType(Double))
        dtbDatos.Columns.Add("num_Importe", GetType(Double))
        dtbDatos.Columns.Add("num_CostoUnitario", GetType(Double))
        dtbDatos.Columns.Add("var_Observacion", GetType(String))

        Dim pkDetalle(1) As Data.DataColumn
        pkDetalle(0) = dtbDatos.Columns("var_IdArticulo")
        dtbDatos.PrimaryKey = pkDetalle
        Session("dtbDatos") = dtbDatos

    End Sub

    Protected Sub btnAsignar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAsignar.Click
        pnlFormulario.Visible = True
        LimpiarFormulario()
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        txtFecha.Text = Format(Now.Date, "dd/MM/yyyy")
        btnFecha.Attributes.Add("onclick", "popUpCalendar(this, " & txtFecha.ClientID & ", 'dd/mm/yyyy');")
        pnlFormulario.Visible = False
        LimpiarFormulario()
        CreateSchemaDetalle()
    End Sub

    Protected Sub btnRegistrar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar2.Click
        If txtCantidad.Text <> "" AndAlso _
        txtCostoUnitario.Text <> "" AndAlso _
        txtImporte.Text <> "" AndAlso ctlArticulo.IdArticulo <> "" AndAlso _
        ddlAlmacen.SelectedValue <> "" Then
            Dim dtbDatos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
            Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
            dtrNuevo("chr_IdFamilia") = Left(ctlArticulo.IdArticulo, 4)
            dtrNuevo("var_IdSubFamilia") = Left(ctlArticulo.IdArticulo, 4)
            dtrNuevo("var_IdArticulo") = ctlArticulo.IdArticulo
            dtrNuevo("var_Articulo") = ctlArticulo.Descripcion
            dtrNuevo("var_IdUnidadMedida") = ctlArticulo.Metrica
            dtrNuevo("var_UnidadMedida") = ctlArticulo.NombreMetrica
            dtrNuevo("var_IdAlmacen") = ddlAlmacen.SelectedItem.Value
            dtrNuevo("var_Almacen") = ddlAlmacen.SelectedItem.Text
            dtrNuevo("var_Observacion") = txtObservacionDetalle.Text
            dtrNuevo("num_Cantidad") = txtCantidad.Text
            dtrNuevo("num_Importe") = txtImporte.Text
            dtrNuevo("num_CostoUnitario") = txtImporte.Text / txtCantidad.Text

            dtbDatos.LoadDataRow(dtrNuevo.ItemArray, True)
            dtbDatos.AcceptChanges()
            LimpiarFormulario()

            Session("dtbDatos") = dtbDatos
            grdDatos.DataSource = dtbDatos
            grdDatos.DataBind()
        End If
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        LimpiarFormulario()
        pnlFormulario.Visible = False

    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click

        If txtFecha.Text <> "" AndAlso ddlTipoMovimiento.SelectedValue <> "" _
        AndAlso ddlTipoDocumento.SelectedValue <> "" Then
            Dim strFecha() = txtFecha.Text.Split("/")
            Dim dtmFecha As New Date(strFecha(2), strFecha(1), strFecha(0))

            If dtmFecha > Now.Date Then
                ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('La fecha no permitida');</script>")
                Exit Sub
            End If

            Dim dtbDatos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
            If dtbDatos.Rows.Count > 0 Then
                Dim objMovimiento As New ALVI_LOGIC.Proceso.Logistica.Kardex.Movimiento
                Dim objDetalle As New ALVI_LOGIC.Proceso.Logistica.Kardex.Detalle

                objMovimiento.IdKardex = Right(strFecha(2), 2) & strFecha(1)
                objMovimiento.FechaOperacion = txtFecha.Text
                'objMovimiento.IdOrdenProduccion = txtOPReferencia.Text
                objMovimiento.IdTipoDocumento = ddlTipoDocumento.SelectedValue
                objMovimiento.IdTipoMovimiento = ddlTipoMovimiento.SelectedValue
                'objMovimiento.NumeroDocumento = txtNumeroDocumento.Text
                'objMovimiento.Observacion = txtObservacionGeneral.Text
                objMovimiento.Usuario = Session("Usuario")
                objMovimiento.Estado = "ACT"
                If objMovimiento.MovimientoAlmacen(dtbDatos) Then
                    Dim intRegistros As Int16 = 0
                    ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('Registro exitoso.');</script>")
                    hdnIdKardex.Value = objMovimiento.IdKardex
                    txtIdKardex.Text = objMovimiento.IdKardex
                End If
            End If

        End If

    End Sub

    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        If e.CommandName = "Modificar" Then
            pnlFormulario.Visible = True
            LimpiarFormulario()
            Dim dtbDatos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
            For Each dtrItem As Data.DataRow In dtbDatos.Select("var_IdArticulo='" & e.CommandArgument.ToString & "'")
                BindAlmacen()
                ddlAlmacen.SelectedValue = dtrItem("var_IdAlmacen")

                ctlArticulo.IdArticulo = dtrItem("var_IdArticulo")
                ctlArticulo.BuscarId()

                txtObservacionDetalle.Text = dtrItem("var_Observacion")
                txtCantidad.Text = dtrItem("num_Cantidad")
                txtCostoUnitario.Text = dtrItem("num_CostoUnitario")
                txtImporte.Text = dtrItem("num_Importe")
            Next
        End If
        If e.CommandName = "Eliminar" Then
            Dim dtbRegistro As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
            CreateSchemaDetalle()
            Dim dtbNuevo As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
            Dim strItem As String = e.CommandArgument
            For Each dtrItem As Data.DataRow In dtbRegistro.Rows
                If dtrItem("var_IdArticulo") <> strItem Then
                    dtbNuevo.Rows.Add(dtrItem.ItemArray)
                    dtbNuevo.AcceptChanges()
                End If
            Next
            Session("dtbDatos") = dtbNuevo
            grdDatos.DataSource = dtbNuevo
            grdDatos.DataBind()

        End If
    End Sub

    Protected Sub btnImprimir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnImprimir.Click
        If hdnIdKardex.Value <> "" Then
            Dim stringWrite1 As New System.IO.StringWriter
            Dim stringWrite2 As New System.IO.StringWriter
            Dim htmlWrite1 As New System.Web.UI.HtmlTextWriter(stringWrite1)
            Dim htmlWrite2 As New System.Web.UI.HtmlTextWriter(stringWrite2)
            Dim objMovimiento As New ALVI_LOGIC.Proceso.Logistica.Kardex.Movimiento
            Dim objDetalle As New ALVI_LOGIC.Proceso.Logistica.Kardex.Detalle

            Dim tblMovimiento As New Table
            Dim tblDetalle As New Table
            Dim rowTable As TableRow
            Dim celTable As TableCell

            objMovimiento.IdKardex = hdnIdKardex.Value
            If objMovimiento.Obtener() Then
                Dim objTipoMovimiento As New ALVI_LOGIC.Maestros.Logistica.TipoMovimiento
                Dim objTipoDocumento As New ALVI_LOGIC.Maestros.Administracion.TipoDocumento
                Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Articulo
                Dim objCentroCosto As New ALVI_LOGIC.Configuracion.CentroCosto
                Dim objCuentaGasto As New ALVI_LOGIC.Configuracion.CuentaGasto

                'CODIGO DE INGRESO
                rowTable = New TableRow
                celTable = New TableCell : celTable.Font.Bold = True : celTable.Text = "Cod. Ingreso" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = objMovimiento.IdKardex : rowTable.Cells.Add(celTable)
                tblMovimiento.Rows.Add(rowTable)
                'FECHA
                rowTable = New TableRow
                celTable = New TableCell : celTable.Font.Bold = True : celTable.Text = "Fecha" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = objMovimiento.FechaOperacion : rowTable.Cells.Add(celTable)
                tblMovimiento.Rows.Add(rowTable)
                'TIPO DE MOVIMIENTO
                objTipoMovimiento.IdTipoMovimiento = objMovimiento.IdTipoMovimiento
                objTipoMovimiento.Obtener()
                rowTable = New TableRow
                celTable = New TableCell : celTable.Font.Bold = True : celTable.Text = "Operación:" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = objTipoMovimiento.Descripcion : rowTable.Cells.Add(celTable)
                tblMovimiento.Rows.Add(rowTable)

                'TIPO DE DOCUMENTO
                objTipoDocumento.IdTipoDocumento = objMovimiento.IdTipoDocumento
                objTipoDocumento.Obtener()
                rowTable = New TableRow
                celTable = New TableCell : celTable.Font.Bold = True : celTable.Text = "Documento:" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = objTipoDocumento.Descripcion & " : " & objMovimiento.NumeroDocumento : rowTable.Cells.Add(celTable)
                tblMovimiento.Rows.Add(rowTable)

                'ORDEN DE COMPRA
                rowTable = New TableRow
                celTable = New TableCell : celTable.Font.Bold = True : celTable.Text = "Orden de compra:" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = objMovimiento.IdOrdenProduccion : rowTable.Cells.Add(celTable)
                tblMovimiento.Rows.Add(rowTable)

                'OBSERVACION
                rowTable = New TableRow
                celTable = New TableCell : celTable.Font.Bold = True : celTable.Text = "Observación general:" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = objMovimiento.Observacion : rowTable.Cells.Add(celTable)
                tblMovimiento.Rows.Add(rowTable)

                objDetalle.IdKardex = objMovimiento.IdKardex
                If objDetalle.Listar() Then
                    Dim objAlmacen As New ALVI_LOGIC.Maestros.Logistica.Almacen

                    rowTable = New TableRow
                    celTable = New TableCell
                    celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(1, UnitType.Pixel)
                    celTable.Font.Bold = True : celTable.Text = "Cod. Articulo" : rowTable.Cells.Add(celTable)
                    celTable = New TableCell
                    celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(1, UnitType.Pixel)
                    celTable.Font.Bold = True : celTable.Text = "Descripción" : rowTable.Cells.Add(celTable)
                    celTable = New TableCell
                    celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(1, UnitType.Pixel)
                    celTable.Font.Bold = True : celTable.Text = "Almacen" : rowTable.Cells.Add(celTable)
                    celTable = New TableCell
                    celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(1, UnitType.Pixel)
                    celTable.Font.Bold = True : celTable.Text = "Cantidad" : rowTable.Cells.Add(celTable)
                    celTable = New TableCell
                    celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(1, UnitType.Pixel)
                    celTable.Font.Bold = True : celTable.Text = "PU" : rowTable.Cells.Add(celTable)
                    celTable = New TableCell
                    celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(1, UnitType.Pixel)
                    celTable.Font.Bold = True : celTable.Text = "Total" : rowTable.Cells.Add(celTable)
                    celTable = New TableCell
                    celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(1, UnitType.Pixel)
                    celTable.Font.Bold = True : celTable.Text = "Observación" : rowTable.Cells.Add(celTable)

                    tblDetalle.Rows.Add(rowTable)

                    For Each dtrItem As Data.DataRow In objDetalle.Datos.Rows
                        objArticulo.IdArticulo = dtrItem("var_IdArticulo")
                        objArticulo.Obtener()
                        objAlmacen.IdAlmacen = dtrItem("var_IdAlmacen")
                        objAlmacen.Obtener()
                        objCentroCosto.IdCentroCosto = dtrItem("var_IdCentroCosto")
                        objCentroCosto.Obtener()
                        objCuentaGasto.IdCuentaGasto = dtrItem("var_IdCuentaGasto")
                        objCuentaGasto.Obtener()

                        rowTable = New TableRow
                        celTable = New TableCell : celTable.Text = dtrItem("var_IdArticulo") : rowTable.Cells.Add(celTable)
                        celTable = New TableCell : celTable.Text = objArticulo.Descripcion : rowTable.Cells.Add(celTable)
                        celTable = New TableCell : celTable.Text = dtrItem("var_IdAlmacen") & ": " & objAlmacen.Descripcion : rowTable.Cells.Add(celTable)
                        celTable = New TableCell : celTable.Text = dtrItem("num_Cantidad") : rowTable.Cells.Add(celTable)
                        celTable = New TableCell : celTable.Text = dtrItem("num_CostoUnitario") : rowTable.Cells.Add(celTable)
                        celTable = New TableCell : celTable.Text = dtrItem("num_Importe") : rowTable.Cells.Add(celTable)
                        celTable = New TableCell : celTable.Text = dtrItem("var_Observacion") : rowTable.Cells.Add(celTable)
                        tblDetalle.Rows.Add(rowTable)
                    Next

                End If


                Session("Titulo") = "Ingreso al almacen"
                tblMovimiento.RenderControl(htmlWrite1)
                Session("Impresion") = stringWrite1.ToString
                tblDetalle.RenderControl(htmlWrite2)
                Session("Impresion") = Session("Impresion") & "<br>" & stringWrite2.ToString

                ClientScript.RegisterStartupScript(ClientScript.GetType, "Imprimir", "<script language='javascript'>window.open('../Controles/frmPrint.aspx','Reporte', 'resizable=1, height=600, width=1000, top=0, left=0');</script>")
            End If
        End If
    End Sub


    Protected Sub txtImporte_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtImporte.TextChanged
        If txtCantidad.Text <> "" AndAlso txtImporte.Text <> "" Then
            If IsNumeric(txtCantidad.Text) AndAlso IsNumeric(txtImporte.Text) Then
                If txtCantidad.Text > 0 AndAlso txtImporte.Text > 0 Then
                    txtCostoUnitario.Text = Format(txtImporte.Text / txtCantidad.Text, "0.00")
                Else
                    txtCostoUnitario.Text = "0.00"
                End If
            Else
                txtCostoUnitario.Text = "0.00"
            End If

        End If
    End Sub

    Protected Sub txtCantidad_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidad.TextChanged
        If txtCantidad.Text <> "" AndAlso txtImporte.Text <> "" Then
            If IsNumeric(txtCantidad.Text) AndAlso IsNumeric(txtImporte.Text) Then
                If txtCantidad.Text > 0 AndAlso txtImporte.Text > 0 Then
                    txtCostoUnitario.Text = Format(txtImporte.Text / txtCantidad.Text, "0.00")
                Else
                    txtCostoUnitario.Text = "0.00"
                End If
            Else
                txtCostoUnitario.Text = "0.00"
            End If

        End If
    End Sub

End Class
