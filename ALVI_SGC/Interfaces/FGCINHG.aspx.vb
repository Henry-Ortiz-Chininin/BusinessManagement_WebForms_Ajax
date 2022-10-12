
Partial Class Interface_FGCINHG
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objMovimiento As New ALVI_LOGIC.Proceso.Logistica.Kardex.Movimiento
        If Not IsPostBack Then
            txtFecha.Text = Format(Now.Date, "dd/MM/yyyy")
            btnFecha.Attributes.Add("onclick", "popUpCalendar(this, " & txtFecha.ClientID & ", 'dd/mm/yyyy');")
            txtFechaDoc.Text = Format(Now.Date, "dd/MM/yyyy")
            btnFechaDoc.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaDoc.ClientID & ", 'dd/mm/yyyy');")

            LimpiarFormulario()

            'objMovimiento.ListarOP()
            btnBuscar.Attributes.Add("onclick", "javascript:return Buscar('" & hdnIdOrden.ClientID & "');")
            btnImprimir.Attributes.Add("onclick", "javascript:return Buscar2('" & hdnIdKardex.ClientID & "');")

        End If

    End Sub
    'Private Sub BindProveedor(ByVal strIdOrden As String)
    '    LimpiarFormulario()
    '    txtOPReferencia.Text = hdnIdOrden.Value
    '    Dim objMovimiento As New ALVI_LOGIC.Proceso.Logistica.Kardex.Movimiento
    '    objMovimiento.ListarMaterial(strIdOrden)
    '    grdDatos.DataSource = objMovimiento.Datos
    '    grdDatos.DataBind()

    'End Sub

    Private Sub BindTipoDocumento()
        Dim objTipoDocumento As New ALVI_LOGIC.Maestros.Administracion.TipoDocumento
        ddlPTipoDocumento.Items.Clear()
        objTipoDocumento.Clasificacion = "I"
        If objTipoDocumento.Listar() = True Then
            ddlPTipoDocumento.DataValueField = "chr_IdTipoDocumento"
            ddlPTipoDocumento.DataTextField = "var_Descripcion"
            ddlPTipoDocumento.DataSource = objTipoDocumento.Datos
            ddlPTipoDocumento.DataBind()
        End If
        ddlPTipoDocumento.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlPTipoDocumento.SelectedIndex = 0
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
        ddlTipoMovimiento.SelectedValue = "I03"
    End Sub

    Private Sub LimpiarFormulario()
        txtFecha.Text = Format(Now.Date, "dd/MM/yyyy")
        txtFechaDoc.Text = Format(Now.Date, "dd/MM/yyyy")
        txtNumeroDocumento.Text = ""
        BindTipoDocumento()
        ddlPTipoDocumento.SelectedValue = ""
        BindTipoMovimiento()
        ddlTipoMovimiento.SelectedValue = "I03"
        'pnlFormulario.Visible = False
        ddlTipoMovimiento.Enabled = False
        txtOrdenProduccion.Enabled = False
        txtOPReferencia.Enabled = False
        'grdDatos.DataSource = CType(Session("dtbDatos"), Data.DataTable)
        'grdDatos.DataBind()
    End Sub

    Private Sub BindAlmacen(ByRef ddlAlmacen As DropDownList)
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
    Public Sub LimpiaPanel()
        Dim dtbPDatos As New Data.DataTable
        ddlPTipoDocumento.SelectedValue = ""
        txtNumeroDocumento.Text = ""
        txtImporte.Text = "0"
        'grdProveedor.DataSource = dtbPDatos
        'grdProveedor.DataBind()
        'pnlFormulario.Visible = False


    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click

        'CARGAMOS LOS DATOS DE LOS ARTICULOS A DESPACHAR
        Dim numImporteTotal As Integer = 0
        Dim dtbDatos As New Data.DataTable
        dtbDatos.Columns.Add("var_IdArticulo", GetType(String))
        dtbDatos.Columns.Add("var_IdUnidadMedida", GetType(String))
        dtbDatos.Columns.Add("var_UnidadMedida", GetType(String))
        dtbDatos.Columns.Add("var_IdAlmacen", GetType(String))
        dtbDatos.Columns.Add("var_IdCentroCosto", GetType(String))
        dtbDatos.Columns.Add("var_IdCuentaGasto", GetType(String))
        dtbDatos.Columns.Add("num_Cantidad", GetType(Double))
        dtbDatos.Columns.Add("num_Importe", GetType(Double))
        dtbDatos.Columns.Add("num_CostoUnitario", GetType(Double))
        dtbDatos.Columns.Add("var_Observacion", GetType(String))

        Dim pkDetalle(1) As Data.DataColumn
        pkDetalle(0) = dtbDatos.Columns("var_IdArticulo")
        dtbDatos.PrimaryKey = pkDetalle

        Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Articulo

        For Each grdItem As GridViewRow In grdDatos.Rows
            Dim txtDespacho As TextBox = CType(grdItem.FindControl("txtDespacho"), TextBox)
            Dim ddlAlmacen As DropDownList = CType(grdItem.FindControl("ddlAlmacen"), DropDownList)

            If txtDespacho.Text <> "" AndAlso ddlAlmacen.SelectedValue <> "" Then
                Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                dtrNuevo("var_IdArticulo") = grdItem.Cells(2).Text
                dtrNuevo("var_IdUnidadMedida") = grdItem.Cells(9).Text
                dtrNuevo("var_IdAlmacen") = ddlAlmacen.SelectedValue
                dtrNuevo("var_IdCentroCosto") = grdItem.Cells(0).Text
                dtrNuevo("var_IdCuentaGasto") = ""
                dtrNuevo("num_Cantidad") = txtDespacho.Text
                dtrNuevo("num_CostoUnitario") = objArticulo.ObtenerPrecio(grdItem.Cells(2).Text, ddlAlmacen.SelectedValue)
                dtrNuevo("num_Importe") = dtrNuevo("num_Cantidad") * dtrNuevo("num_CostoUnitario")
                dtrNuevo("var_Observacion") = ""
                numImporteTotal = dtrNuevo("num_Importe") + numImporteTotal
                dtbDatos.LoadDataRow(dtrNuevo.ItemArray, True)
                dtbDatos.AcceptChanges()

            End If

        Next

        Dim dtbDocumentos As New Data.DataTable
        dtbDocumentos.Columns.Add("Codigo")
        dtbDocumentos.Columns.Add("IdProveedor")
        dtbDocumentos.Columns.Add("numero")
        dtbDocumentos.Columns.Add("Fecha")
        dtbDocumentos.Columns.Add("Importe")

        For Each itmDocumento As GridViewRow In grdProveedor.Rows
            Dim dtrActual As Data.DataRow = dtbDocumentos.NewRow
            dtrActual("Codigo") = itmDocumento.Cells(0).Text
            dtrActual("IdProveedor") = itmDocumento.Cells(3).Text
            dtrActual("numero") = itmDocumento.Cells(2).Text
            dtrActual("Fecha") = itmDocumento.Cells(5).Text
            dtrActual("Importe") = itmDocumento.Cells(6).Text
            dtbDocumentos.LoadDataRow(dtrActual.ItemArray, True)
            dtbDocumentos.AcceptChanges()
        Next

        If dtbDocumentos.Rows.Count = 0 Then
            ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('Debe Agregar al menos un Documento.');</script>")
            Exit Sub
        End If

        'PROCED CON LA GRABACION
        If dtbDatos.Rows.Count > 0 AndAlso dtbDocumentos.Rows.Count > 0 Then
            Dim objMovimiento As New ALVI_LOGIC.Proceso.Logistica.Kardex.Movimiento
            Dim objDetalle As New ALVI_LOGIC.Proceso.Logistica.Kardex.Detalle

            Dim strFecha() = txtFecha.Text.Split("/")
            Dim dtmFecha As New Date(strFecha(2), strFecha(1), strFecha(0))

            objMovimiento.IdKardex = Right(strFecha(2), 2) & strFecha(1)
            objMovimiento.FechaOperacion = txtFecha.Text
            objMovimiento.IdOrdenProduccion = txtOPReferencia.Text
            objMovimiento.IdTipoMovimiento = ddlTipoMovimiento.SelectedValue
            objMovimiento.Observacion = txtObservacionGeneral.Text
            objMovimiento.Usuario = Session("Usuario")
            objMovimiento.Estado = "ACT"
            If objMovimiento.KardexSalidaServicio(dtbDatos, dtbDocumentos) Then
                Dim intRegistros As Int16 = 0

                hdnIdKardex.Value = objMovimiento.IdKardex
                txtIdKardex.Text = objMovimiento.IdKardex

                ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('Registro exitoso.');</script>")

            End If
        End If

    End Sub

    Protected Sub grdDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDatos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim ddlAlmacen As DropDownList = CType(e.Row.FindControl("ddlAlmacen"), DropDownList)
            BindAlmacen(ddlAlmacen)
        End If
    End Sub
    Private Sub BindDespacho(ByVal strIdOrden As String)
        LimpiarFormulario()
        LimpiaPanel()
        'pnlFormulario.Visible = False
        txtIdKardex.Text = ""
        txtObservacionGeneral.Text = ""
        txtOPReferencia.Text = hdnIdOrden.Value

        Dim objMovimiento As New ALVI_LOGIC.Proceso.Logistica.Kardex.Movimiento
        objMovimiento.ListarIngresoOrdenServicio(strIdOrden)
        grdDatos.DataSource = objMovimiento.Datos
        grdDatos.DataBind()

        If objMovimiento.Datos.Rows.Count > 0 Then
            lblCliente.Text = objMovimiento.Datos.Rows(0)("var_NombreCliente")
            lblProveedor.Text = objMovimiento.Datos.Rows(0)("var_NombreProveedor")
            hdnIdProveedor.Value = objMovimiento.Datos.Rows(0)("var_IdProveedor")
            txtOrdenProduccion.Text = objMovimiento.Datos.Rows(0)("var_IdOrden")
        End If

    End Sub
    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        If hdnIdOrden.Value <> "" Then
            BindDespacho(hdnIdOrden.Value)
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

                'ORDEN DE SERVICIO
                rowTable = New TableRow
                celTable = New TableCell : celTable.Font.Bold = True : celTable.Text = "Orden de servicio:" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = objMovimiento.IdOrdenProduccion : rowTable.Cells.Add(celTable)
                tblMovimiento.Rows.Add(rowTable)

                'ORDEN DE PRODUCCION
                rowTable = New TableRow
                celTable = New TableCell : celTable.Font.Bold = True : celTable.Text = "Orden de produccion:" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = txtOrdenProduccion.Text : rowTable.Cells.Add(celTable)
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
                    celTable.Font.Bold = True : celTable.Text = "Centro de Costo" : rowTable.Cells.Add(celTable)
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

                        rowTable = New TableRow
                        celTable = New TableCell : celTable.Text = dtrItem("var_IdArticulo") : rowTable.Cells.Add(celTable)
                        celTable = New TableCell : celTable.Text = objArticulo.Descripcion : rowTable.Cells.Add(celTable)
                        celTable = New TableCell : celTable.Text = dtrItem("var_IdAlmacen") & ": " & objAlmacen.Descripcion : rowTable.Cells.Add(celTable)
                        celTable = New TableCell : celTable.Text = dtrItem("num_Cantidad") : rowTable.Cells.Add(celTable)
                        celTable = New TableCell : celTable.Text = dtrItem("num_CostoUnitario") : rowTable.Cells.Add(celTable)
                        celTable = New TableCell : celTable.Text = dtrItem("num_Importe") : rowTable.Cells.Add(celTable)
                        celTable = New TableCell : celTable.Text = "(" & dtrItem("var_IdCentroCosto") & ") " & objCentroCosto.Descripcion : rowTable.Cells.Add(celTable)
                        celTable = New TableCell : celTable.Text = dtrItem("var_Observacion") : rowTable.Cells.Add(celTable)
                        tblDetalle.Rows.Add(rowTable)
                    Next

                End If


                Session("Titulo") = "Ingreso al Almacen por Servicio de Terceros"
                tblMovimiento.RenderControl(htmlWrite1)
                Session("Impresion") = stringWrite1.ToString
                tblDetalle.RenderControl(htmlWrite2)
                Session("Impresion") = Session("Impresion") & "<br>" & stringWrite2.ToString

                ClientScript.RegisterStartupScript(ClientScript.GetType, "Imprimir", "<script language='javascript'>window.open('../Controles/frmPrint.aspx','Reporte', 'resizable=1, height=600, width=1000, top=0, left=0');</script>")
            End If
        End If
    End Sub

    'Protected Sub btnDocumento_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnDocumento.Click
    '    Dim objMovimiento As New ALVI_LOGIC.Proceso.Logistica.Kardex.Movimiento
    '    objMovimiento.ListarOP()
    '    pnlFormulario.Visible = True

    'End Sub

    Protected Sub btnRegistrar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar2.Click
        If ddlPTipoDocumento.SelectedValue <> "" AndAlso txtNumeroDocumento.Text <> "" Then
            'DataPanel()
            RegistroDocumento()
            LimpiaPanel()
        Else
            ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('Faltan datos.');</script>")
        End If
    End Sub

    Private Sub RegistroDocumento()
        Dim dtbPDatos As New Data.DataTable
        dtbPDatos.Columns.Add("Codigo")
        dtbPDatos.Columns.Add("IdProveedor")
        dtbPDatos.Columns.Add("Proveedor")
        dtbPDatos.Columns.Add("Tipo")
        dtbPDatos.Columns.Add("numero")
        dtbPDatos.Columns.Add("Fecha")
        dtbPDatos.Columns.Add("Importe")

        For Each itmDocumento As GridViewRow In grdProveedor.Rows
            Dim dtrActual As Data.DataRow = dtbPDatos.NewRow
            dtrActual("Codigo") = itmDocumento.Cells(0).Text
            dtrActual("IdProveedor") = hdnIdProveedor.Value
            dtrActual("Proveedor") = lblProveedor.Text
            dtrActual("Tipo") = ddlPTipoDocumento.SelectedItem
            dtrActual("numero") = txtNumeroDocumento.Text
            dtrActual("Fecha") = txtFechaDoc.Text
            dtrActual("Importe") = txtImporte.Text
            dtbPDatos.LoadDataRow(dtrActual.ItemArray, True)
            dtbPDatos.AcceptChanges()

        Next

        Dim dtrNuevo As Data.DataRow = dtbPDatos.NewRow

        dtrNuevo("Codigo") = ddlPTipoDocumento.SelectedValue
        dtrNuevo("IdProveedor") = hdnIdProveedor.Value
        dtrNuevo("Proveedor") = lblProveedor.Text
        dtrNuevo("Tipo") = ddlPTipoDocumento.SelectedItem
        dtrNuevo("numero") = txtNumeroDocumento.Text
        dtrNuevo("Fecha") = txtFechaDoc.Text
        dtrNuevo("Importe") = txtImporte.Text
        dtbPDatos.LoadDataRow(dtrNuevo.ItemArray, True)
        dtbPDatos.AcceptChanges()

        grdProveedor.DataSource = dtbPDatos
        grdProveedor.DataBind()
        '("tablaPanel") = dtbPDatos

    End Sub

    Protected Sub grdProveedor_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdProveedor.RowDeleting
        Dim dtbPDatos As New Data.DataTable
        dtbPDatos.Columns.Add("Codigo")
        dtbPDatos.Columns.Add("IdProveedor")
        dtbPDatos.Columns.Add("Proveedor")
        dtbPDatos.Columns.Add("Tipo")
        dtbPDatos.Columns.Add("numero")
        dtbPDatos.Columns.Add("Fecha")
        dtbPDatos.Columns.Add("Importe")

        For Each itmDocumento As GridViewRow In grdProveedor.Rows
            If itmDocumento.RowIndex <> e.RowIndex Then
                Dim dtrActual As Data.DataRow = dtbPDatos.NewRow
                dtrActual("Codigo") = itmDocumento.Cells(0).Text
                dtrActual("IdProveedor") = itmDocumento.Cells(3).Text
                dtrActual("Proveedor") = itmDocumento.Cells(4).Text
                dtrActual("Tipo") = itmDocumento.Cells(1).Text
                dtrActual("numero") = itmDocumento.Cells(2).Text
                dtrActual("Fecha") = itmDocumento.Cells(5).Text
                dtrActual("Importe") = itmDocumento.Cells(6).Text
                dtbPDatos.LoadDataRow(dtrActual.ItemArray, True)
                dtbPDatos.AcceptChanges()
            End If

        Next

        grdProveedor.DataSource = dtbPDatos
        grdProveedor.DataBind()


    End Sub
End Class
