
Partial Class Interfaces_FGCINCE
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
            btnBuscar.Attributes.Add("onclick", "javascript:return Buscar('" & hdnIdKardex.ClientID & "');")

            If Request("IdKardex") <> "" Then
                Dim objSeguridad As New ALVI_Security.General
                hdnIdKardex.Value = objSeguridad.Decrypta(Request("IdKardex"))
                Buscar()
            End If
        End If
    End Sub

    Private Sub BindTipoDocumento()
        Dim objTipoDocumento As New ALVI_LOGIC.Maestros.Administracion.TipoDocumento
        ddlTipoDocumento.Items.Clear()
        objTipoDocumento.Clasificacion = "S"
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
        objTipoMovimiento.Clasificacion = "S"
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
            ctlCentroCosto1.IdCentroCosto = ""
            ctlCentroCosto1.Descripcion = ""
            ctlCuentaGasto1.IdCuentaGasto = ""
            ctlCuentaGasto1.Descripcion = ""
            txtObservacionDetalle.Text = ""
            txtImporte.Text = 0
            ctlArticulo.IdArticulo = ""
            ctlArticulo.BuscarId()
            BindAlmacen()
        Else
            txtFecha.Text = Format(Now.Date, "dd/MM/yyyy")
            txtNumeroDocumento.Text = ""
            txtOPReferencia.Text = ""
            txtObservacionGeneral.Text = ""
            BindTipoDocumento()
            BindTipoMovimiento()
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


    Protected Sub btnRegistrar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar2.Click
        If txtCantidad.Text <> "" AndAlso _
        txtCostoUnitario.Text <> "" AndAlso _
        txtImporte.Text <> "" AndAlso _
        ddlAlmacen.SelectedValue <> "" AndAlso _
        ctlArticulo.IdArticulo <> "" AndAlso _
        ctlArticulo.Metrica <> "" AndAlso _
        ctlCentroCosto1.IdCentroCosto <> "" AndAlso _
        ctlCuentaGasto1.IdCuentaGasto <> "" Then
            Dim objKardex As New ALVI_LOGIC.Proceso.Logistica.Kardex.Resumen
            If objKardex.ObtenerStock("", "", ctlArticulo.IdArticulo, Format(Now, "dd/MM/yyyy"), "") Then
                If objKardex.Datos.Select("var_IdAlmacen='" & ddlAlmacen.SelectedValue & "'").Length > 0 Then
                    If txtCantidad.Text > objKardex.Datos.Select("var_IdAlmacen='" & ddlAlmacen.SelectedValue & "'")(0)("num_Cantidad") Then
                        ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('La cantidad excede el stock en almacen.');</script>")
                        Exit Sub
                    End If
                End If
            End If

            Dim objDetalle As New ALVI_LOGIC.Proceso.Logistica.Kardex.Detalle
            objDetalle.IdAlmacen = ddlAlmacen.SelectedValue
            objDetalle.IdArticulo = ctlArticulo.IdArticulo
            objDetalle.IdCentroCosto = ctlCentroCosto1.IdCentroCosto
            objDetalle.IdCuentaGasto = ctlCuentaGasto1.IdCuentaGasto
            objDetalle.IdKardex = txtIdKardex.Text
            objDetalle.IdUnidadMedida = ctlArticulo.Metrica
            objDetalle.Importe = txtImporte.Text
            objDetalle.Cantidad = txtCantidad.Text
            objDetalle.CostoUnitario = txtCostoUnitario.Text
            objDetalle.Observacion = txtObservacionDetalle.Text
            objDetalle.Usuario = Session("Usuario")
            objDetalle.Estado = "ACT"
            objDetalle.Registrar()
            BindGrid()
            LimpiarFormulario()
        End If
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        LimpiarFormulario()
        pnlFormulario.Visible = False

    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click

        If txtFecha.Text <> "" AndAlso txtNumeroDocumento.Text <> "" _
        AndAlso ddlTipoMovimiento.SelectedValue <> "" _
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
                objMovimiento.IdKardex = txtIdKardex.Text
                objMovimiento.FechaOperacion = txtFecha.Text
                objMovimiento.IdOrdenProduccion = txtOPReferencia.Text
                objMovimiento.IdTipoDocumento = ddlTipoDocumento.SelectedValue
                objMovimiento.IdTipoMovimiento = ddlTipoMovimiento.SelectedValue
                objMovimiento.NumeroDocumento = txtNumeroDocumento.Text
                objMovimiento.Observacion = txtObservacionGeneral.Text
                objMovimiento.Usuario = Session("Usuario")
                objMovimiento.Estado = "ACT"
                If objMovimiento.Registrar Then
                    Dim intRegistros As Int16 = 0
                    For Each dtrItem As Data.DataRow In dtbDatos.Rows
                        objDetalle.Cantidad = dtrItem("num_Cantidad")
                        objDetalle.CostoUnitario = dtrItem("num_CostoUnitario")
                        objDetalle.IdAlmacen = dtrItem("var_IdAlmacen")
                        objDetalle.IdArticulo = dtrItem("var_IdArticulo")
                        objDetalle.IdCentroCosto = dtrItem("var_IdCentroCosto")
                        objDetalle.IdCuentaGasto = dtrItem("var_IdCuentaGasto")
                        objDetalle.IdKardex = objMovimiento.IdKardex
                        objDetalle.IdUnidadMedida = dtrItem("var_IdUnidadMedida")
                        objDetalle.Observacion = dtrItem("var_Observacion")
                        objDetalle.Importe = dtrItem("num_Importe")
                        objDetalle.Usuario = Session("Usuario")
                        objDetalle.Estado = "ACT"
                        If objDetalle.Registrar() = True Then
                            intRegistros = intRegistros + 1
                        End If
                    Next
                    If intRegistros = dtbDatos.Rows.Count Then
                        txtIdKardex.Text = objMovimiento.IdKardex
                        ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('Registro exitoso.');</script>")
                        hdnIdKardex.Value = objMovimiento.IdKardex
                        LimpiarFormulario()
                    Else
                        For Each dtrItem As Data.DataRow In dtbDatos.Rows
                            objDetalle.IdKardex = objMovimiento.IdKardex
                            objDetalle.IdArticulo = dtrItem("var_IdArticulo")
                            objDetalle.Eliminar()
                        Next
                        objMovimiento.Eliminar()
                        ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('Sucedio un error al registrar.');</script>")
                    End If
                End If
            End If

        End If

    End Sub

    Protected Sub grdDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDatos.PageIndexChanging
        grdDatos.PageIndex = e.NewPageIndex
        BindGrid()
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
                ctlCentroCosto1.IdCentroCosto = dtrItem("var_IdCentroCosto")
                ctlCentroCosto1.Descripcion = dtrItem("var_CentroCosto")

                ctlCuentaGasto1.IdCuentaGasto = dtrItem("var_IdCuentaGasto")
                ctlCuentaGasto1.Descripcion = dtrItem("var_CuentaGasto")


            Next
        End If
        If e.CommandName = "Eliminar" Then
            Dim objDetalle As New ALVI_LOGIC.Proceso.Logistica.Kardex.Detalle
            objDetalle.IdKardex = txtIdKardex.Text
            objDetalle.IdArticulo = e.CommandArgument
            objDetalle.Eliminar()
            BindGrid()
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

                'ORDEN DE PRODUCCION
                rowTable = New TableRow
                celTable = New TableCell : celTable.Font.Bold = True : celTable.Text = "Orden de producción:" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = objMovimiento.IdOrdenProduccion : rowTable.Cells.Add(celTable)
                tblMovimiento.Rows.Add(rowTable)

                'OBSERVACION
                rowTable = New TableRow
                celTable = New TableCell : celTable.Font.Bold = True : celTable.Text = "Observación general:" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = objMovimiento.Observacion : rowTable.Cells.Add(celTable)

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
                    celTable.Font.Bold = True : celTable.Text = "Cuenta de Gasto" : rowTable.Cells.Add(celTable)

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
                        celTable = New TableCell : celTable.Text = "(" & dtrItem("var_IdCentroCosto") & ") " & objCentroCosto.Descripcion : rowTable.Cells.Add(celTable)
                        celTable = New TableCell : celTable.Text = "(" & dtrItem("var_IdCuentaGasto") & ") " & objCuentaGasto.Descripcion : rowTable.Cells.Add(celTable)
                        celTable = New TableCell : celTable.Text = dtrItem("var_Observacion") : rowTable.Cells.Add(celTable)
                        tblDetalle.Rows.Add(rowTable)
                    Next

                End If


                Session("Titulo") = "Salidas del almacen"
                tblMovimiento.RenderControl(htmlWrite1)
                Session("Impresion") = stringWrite1.ToString
                tblDetalle.RenderControl(htmlWrite2)
                Session("Impresion") = Session("Impresion") & "<br>" & stringWrite2.ToString

                ClientScript.RegisterStartupScript(ClientScript.GetType, "Imprimir", "<script language='javascript'>window.open('../Controles/frmPrint.aspx','Reporte', 'resizable=1, height=600, width=1000, top=0, left=0');</script>")
            End If
        End If
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        Buscar()
    End Sub

    Private Sub Buscar()
        If hdnIdKardex.Value <> "" Then
            Dim objMovimiento As New ALVI_LOGIC.Proceso.Logistica.Kardex.Movimiento

            objMovimiento.IdKardex = hdnIdKardex.Value
            If objMovimiento.Obtener = True Then
                Dim objTipoMovimiento As New ALVI_LOGIC.Maestros.Logistica.TipoMovimiento
                objTipoMovimiento.IdTipoMovimiento = objMovimiento.IdTipoMovimiento
                objTipoMovimiento.Obtener()
                If objTipoMovimiento.Clasificacion <> "S" Then
                    ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('No existe ingreso al almacen con el codigo ingresado');</script>")
                    Exit Sub
                End If

                txtIdKardex.Text = objMovimiento.IdKardex
                txtFecha.Text = objMovimiento.FechaOperacion
                txtNumeroDocumento.Text = objMovimiento.NumeroDocumento
                txtOPReferencia.Text = objMovimiento.IdOrdenProduccion
                BindTipoMovimiento()
                ddlTipoMovimiento.SelectedValue = objMovimiento.IdTipoMovimiento
                BindTipoDocumento()
                ddlTipoDocumento.SelectedValue = objMovimiento.IdTipoDocumento

                BindGrid()
            End If

        End If
    End Sub
    Private Sub BindGrid()
        CreateSchemaDetalle()
        Dim objDetalle As New ALVI_LOGIC.Proceso.Logistica.Kardex.Detalle
        objDetalle.IdKardex = txtIdKardex.Text
        If objDetalle.Listar Then
            Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Articulo
            Dim objUnidadMedida As New ALVI_LOGIC.Configuracion.UnidadMedida
            Dim objCentroCosto As New ALVI_LOGIC.Configuracion.CentroCosto
            Dim objCuentaGasto As New ALVI_LOGIC.Configuracion.CuentaGasto
            Dim objAlmacen As New ALVI_LOGIC.Maestros.Logistica.Almacen


            Dim dtbDatos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
            For Each dtrItem As Data.DataRow In objDetalle.Datos.Rows
                Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                dtrNuevo("chr_IdFamilia") = Left(dtrItem("var_IdArticulo"), 2)
                dtrNuevo("var_IdSubFamilia") = Left(dtrItem("var_IdArticulo"), 4)
                dtrNuevo("var_IdArticulo") = dtrItem("var_IdArticulo")
                dtrNuevo("var_Observacion") = dtrItem("var_Observacion")
                objArticulo.IdArticulo = dtrItem("var_IdArticulo")
                objArticulo.Obtener()
                dtrNuevo("var_Articulo") = objArticulo.Descripcion
                dtrNuevo("var_IdUnidadMedida") = dtrItem("var_IdUnidadMedida")
                objUnidadMedida.IdUnidadMedida = dtrItem("var_IdUnidadMedida")
                objUnidadMedida.Obtener()
                dtrNuevo("var_UnidadMedida") = objUnidadMedida.Descripcion
                dtrNuevo("var_IdAlmacen") = dtrItem("var_IdAlmacen")
                objAlmacen.IdAlmacen = dtrItem("var_IdAlmacen")
                objAlmacen.Obtener()
                dtrNuevo("var_Almacen") = objAlmacen.Descripcion
                dtrNuevo("var_IdCentroCosto") = dtrItem("var_IdCentroCosto")
                objCentroCosto.IdCentroCosto = dtrItem("var_IdCentroCosto")
                objCentroCosto.Obtener()
                dtrNuevo("var_CentroCosto") = objCentroCosto.Descripcion
                dtrNuevo("var_IdCuentaGasto") = dtrItem("var_IdCuentaGasto")
                objCuentaGasto.IdCuentaGasto = dtrItem("var_IdCuentaGasto")
                objCuentaGasto.Obtener()
                dtrNuevo("var_CuentaGasto") = objCuentaGasto.Descripcion
                dtrNuevo("num_Cantidad") = dtrItem("num_Cantidad")
                dtrNuevo("num_Importe") = dtrItem("num_Importe")
                dtrNuevo("num_CostoUnitario") = dtrItem("num_CostoUnitario")

                dtbDatos.LoadDataRow(dtrNuevo.ItemArray, True)
                dtbDatos.AcceptChanges()

            Next
            Session("dtbDatos") = dtbDatos

            grdDatos.DataSource = dtbDatos
            grdDatos.DataBind()
        End If

    End Sub

    Protected Sub txtCantidad_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidad.TextChanged
        If txtCantidad.Text <> "" AndAlso ctlArticulo.IdArticulo <> "" Then
            Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Articulo
            txtCostoUnitario.Text = objArticulo.ObtenerPrecio(ctlArticulo.IdArticulo, ddlAlmacen.SelectedValue)

            If IsNumeric(txtCantidad.Text) AndAlso IsNumeric(txtCostoUnitario.Text) Then
                If txtCantidad.Text > 0 AndAlso txtCostoUnitario.Text > 0 Then
                    txtImporte.Text = Format(txtCostoUnitario.Text * txtCantidad.Text, "0.00")
                Else
                    txtImporte.Text = "0.00"
                End If
            Else
                txtImporte.Text = "0.00"
            End If

        End If
    End Sub

    
End Class
