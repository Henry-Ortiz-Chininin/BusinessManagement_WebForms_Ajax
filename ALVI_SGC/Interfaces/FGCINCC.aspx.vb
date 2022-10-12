
Partial Class Interfaces_FGCINCC
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindAnno()
            BindFamilia()
            hdnGenerado.Value = "S"

        End If
    End Sub

    Private Sub BindAnno()
        For Indice As Int16 = 0 To 3
            ddlAnno.Items.Add(New ListItem(DateAdd(DateInterval.Year, Indice * (-1), Date.Now).Year))
        Next
        ddlAnno.SelectedIndex = 0
    End Sub

    Private Sub BindFamilia()
        Dim objFamilia As New ALVI_LOGIC.Maestros.Articulo.Familia
        ddlFamilia.Items.Clear()
        If objFamilia.Listar() = True Then
            ddlFamilia.DataValueField = "chr_IdFamilia"
            ddlFamilia.DataTextField = "var_Descripcion"
            ddlFamilia.DataSource = objFamilia.Datos
            ddlFamilia.DataBind()
        End If
        ddlFamilia.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlFamilia.SelectedIndex = 0
    End Sub

    Private Sub CreateSchemaResumen()
        Dim dtbResumen As New Data.DataTable
        dtbResumen.Columns.Add("chr_Anno", GetType(String))
        dtbResumen.Columns.Add("chr_Mes", GetType(String))
        dtbResumen.Columns.Add("var_IdAlmacen", GetType(String))
        dtbResumen.Columns.Add("var_IdTipoMovimiento", GetType(String))
        dtbResumen.Columns.Add("var_IdArticulo", GetType(String))
        dtbResumen.Columns.Add("num_Cantidad", GetType(String))
        dtbResumen.Columns.Add("num_CostoUnitario", GetType(String))
        dtbResumen.Columns.Add("num_Importe", GetType(String))
        dtbResumen.Columns.Add("var_IdUnidadMedida", GetType(String))

        Dim pkResumen(5) As Data.DataColumn
        pkResumen(0) = dtbResumen.Columns("chr_Anno")
        pkResumen(1) = dtbResumen.Columns("chr_Mes")
        pkResumen(2) = dtbResumen.Columns("var_IdAlmacen")
        pkResumen(3) = dtbResumen.Columns("var_IdTipoMovimiento")
        pkResumen(4) = dtbResumen.Columns("var_IdArticulo")

        dtbResumen.PrimaryKey = pkResumen
        Session("dtbResumen") = dtbResumen
    End Sub

    Protected Sub btnGenerar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGenerar.Click
        Dim objResumen As New ALVI_LOGIC.Proceso.Logistica.Kardex.Resumen
        objResumen.Anno = ddlAnno.SelectedValue
        objResumen.Mes = ddlMes.SelectedValue
        objResumen.IdArticulo = ddlFamilia.SelectedValue
        objResumen.IdTipoMovimiento = ""
        objResumen.IdAlmacen = ""
        objResumen.Listar()
        If objResumen.Datos.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('El periodo ya esta cerrado.');</script>")
            hdnGenerado.Value = "N"
        Else
            BindResumen(tblResumen)

        End If
    End Sub

    Private Sub BindResumen(ByRef tblDatos As Table)
        If ddlFamilia.SelectedValue <> "" AndAlso ddlAnno.SelectedValue <> "" AndAlso ddlMes.SelectedValue <> "" Then
            hdnGenerado.Value = "S"
            CreateSchemaResumen()
            Dim dtbResumen = CType(Session("dtbResumen"), Data.DataTable)

            Dim objTipoMovimiento As New ALVI_LOGIC.Maestros.Logistica.TipoMovimiento
            Dim objMovimientos As New ALVI_LOGIC.Proceso.Logistica.Kardex.Detalle
            Dim objResumen As New ALVI_LOGIC.Proceso.Logistica.Kardex.Resumen
            Dim objAlmacen As New ALVI_LOGIC.Maestros.Logistica.Almacen
            Dim dtmPeriodoAnterior As Date = DateAdd(DateInterval.Month, -1, New Date(ddlAnno.SelectedValue, ddlMes.SelectedValue, 1))
            Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Articulo
            objTipoMovimiento.Clasificacion = ""
            objTipoMovimiento.Listar()

            '*********************************************************
            'INICIO: CABECERA
            '*********************************************************

            Dim rowItem As TableRow
            rowItem = New TableRow
            rowItem.Cells.Add(CreateCelll("Almacen", "Head", "C", 1, 1))
            rowItem.Cells.Add(CreateCelll("Articulo", "Head", "C", 1, 1))
            For Each dtrTipoMovimiento As Data.DataRow In objTipoMovimiento.Datos.Select("var_IdTipoMovimiento='A01'")
                rowItem.Cells.Add(CreateCelll(dtrTipoMovimiento("var_Descripcion"), "Head", "C", 3, 1))
            Next

            For Each dtrTipoMovimiento As Data.DataRow In objTipoMovimiento.Datos.Select("chr_Clase = 'I'")
                rowItem.Cells.Add(CreateCelll(dtrTipoMovimiento("var_Descripcion"), "Head", "C", 3, 1))
            Next

            For Each dtrTipoMovimiento As Data.DataRow In objTipoMovimiento.Datos.Select("chr_Clase = 'S'")
                rowItem.Cells.Add(CreateCelll(dtrTipoMovimiento("var_Descripcion"), "Head", "C", 3, 1))
            Next

            For Each dtrTipoMovimiento As Data.DataRow In objTipoMovimiento.Datos.Select("var_IdTipoMovimiento='A02'")
                rowItem.Cells.Add(CreateCelll(dtrTipoMovimiento("var_Descripcion"), "Head", "C", 3, 1))
            Next
            tblDatos.Rows.Add(rowItem)

            rowItem = New TableRow
            rowItem.Cells.Add(CreateCelll("&nbsp;", "Foot", "C", 1, 1))
            rowItem.Cells.Add(CreateCelll("&nbsp;", "Foot", "C", 1, 1))
            For Each dtrTipoMovimiento As Data.DataRow In objTipoMovimiento.Datos.Select("var_IdTipoMovimiento='A01'")
                rowItem.Cells.Add(CreateCelll("Cantidad", "Foot", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll("PU S/.", "Foot", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll("Total S/.", "Foot", "C", 1, 1))
            Next

            For Each dtrTipoMovimiento As Data.DataRow In objTipoMovimiento.Datos.Select("chr_Clase = 'I'")
                rowItem.Cells.Add(CreateCelll("Cantidad", "Foot", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll("PU S/.", "Foot", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll("Total S/.", "Foot", "C", 1, 1))
            Next

            For Each dtrTipoMovimiento As Data.DataRow In objTipoMovimiento.Datos.Select("chr_Clase = 'S'")
                rowItem.Cells.Add(CreateCelll("Cantidad", "Foot", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll("PU S/.", "Foot", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll("Total S/.", "Foot", "C", 1, 1))
            Next

            For Each dtrTipoMovimiento As Data.DataRow In objTipoMovimiento.Datos.Select("var_IdTipoMovimiento='A02'")
                rowItem.Cells.Add(CreateCelll("Cantidad", "Foot", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll("PU S/.", "Foot", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll("Total S/.", "Foot", "C", 1, 1))
            Next

            tblDatos.Rows.Add(rowItem)
            '*********************************************************
            'FINAL: CABECERA
            '*********************************************************

            objAlmacen.Listar()
            objArticulo.IdSubFamilia = ddlFamilia.SelectedValue
            objArticulo.Listar()
            '*********************************************************
            'INICIO: CUERPO
            '*********************************************************

            objMovimientos.ListarPeriodo(ddlAnno.SelectedValue, ddlMes.SelectedValue)

            'OBTENERMOS EL INVENTARIO FINAL DEL PERIODO ANTERIOR
            objResumen.Anno = Format(dtmPeriodoAnterior.Year, "0000")
            objResumen.Mes = Format(dtmPeriodoAnterior.Month, "00")
            objResumen.IdTipoMovimiento = "A02"
            objResumen.IdArticulo = ""
            objResumen.IdAlmacen = ""
            objResumen.Listar()

            For Each dtrAlmacen As Data.DataRow In objAlmacen.Datos.Rows
                If objMovimientos.Datos.Select("var_IdAlmacen='" & dtrAlmacen("var_IdAlmacen") & "'").Count > 0 _
                OrElse objResumen.Datos.Select("var_IdAlmacen='" & dtrAlmacen("var_IdAlmacen") & "'").Count > 0 Then

                    For Each dtrArticulo As Data.DataRow In objArticulo.Datos.Rows
                        If objMovimientos.Datos.Select("var_IdAlmacen='" & dtrAlmacen("var_IdAlmacen") & "' AND var_IdArticulo='" & dtrArticulo("var_IdArticulo") & "'").Count > 0 _
                        OrElse objResumen.Datos.Select("var_IdAlmacen='" & dtrAlmacen("var_IdAlmacen") & "' AND var_IdArticulo='" & dtrArticulo("var_IdArticulo") & "'").Count > 0 Then

                            rowItem = New TableRow
                            Dim dblCantidad As Double = 0
                            Dim dblImporte As Double = 0
                            Dim dblCostoUnitario As Double = 0
                            Dim dblCosto As Double = 0
                            'Acumuladores de Inventario final
                            Dim dblIFCantidad As Double = 0
                            Dim dblIFImporte As Double = 0
                            Dim dblIFCostoUnitario As Double = 0
                            Dim dblIFCosto As Double = 0


                            rowItem.Cells.Add(CreateCelll("(" & dtrAlmacen("var_IdAlmacen") & ") " & dtrAlmacen("var_Descripcion"), "Item", "C", 1, 1))
                            rowItem.Cells.Add(CreateCelll("(" & dtrArticulo("var_IdArticulo") & ") " & dtrArticulo("var_Descripcion"), "Item", "C", 1, 1))

                            '----------------------------------------
                            'INVENTARIO INICIAL
                            '----------------------------------------

                            'OBTENERMOS EL INVENTARIO FINAL DEL PERIODO ANTERIOR
                            For Each dtrResumen As Data.DataRow In objResumen.Datos.Select("var_IdArticulo='" & dtrArticulo("var_IdArticulo") & "' AND var_IdAlmacen='" & dtrAlmacen("var_IdAlmacen") & "'")
                                dblCantidad = dtrResumen("num_Cantidad")
                                dblIFCantidad = dtrResumen("num_Cantidad")
                                dblCostoUnitario = dtrResumen("num_CostoUnitario")
                                dblIFCosto = dblCostoUnitario * dblCantidad
                                dblImporte = dtrResumen("num_Importe")
                                dblIFImporte = dtrResumen("num_Importe")
                            Next

                            rowItem.Cells.Add(CreateCelll(Format(dblCantidad, "#,##0.00"), "Item", "R", 1, 1))
                            rowItem.Cells.Add(CreateCelll(Format(dblCostoUnitario, "#,##0.00"), "Item", "R", 1, 1))
                            rowItem.Cells.Add(CreateCelll(Format(dblImporte, "#,##0.00"), "Item", "R", 1, 1))

                            '----------------------------------------
                            'INGRESOS
                            '----------------------------------------
                            For Each dtrTipoMovimiento As Data.DataRow In objTipoMovimiento.Datos.Select("chr_Clase = 'I'")
                                'INICIALIZAR LAS VARIABLES
                                dblCantidad = 0
                                dblCostoUnitario = 0
                                dblImporte = 0
                                dblCosto = 0
                                'OBTENEMOS LOS MOVIMIENTO ACTIVOS DE ACUERDO AL TIPO DE MOVIMIENTO
                                'RECORREMOS CADA MOVIMIENTO
                                For Each dtrMovimiento As Data.DataRow In objMovimientos.Datos.Select("var_IdTipoMovimiento='" & dtrTipoMovimiento("var_IdTipoMovimiento") & "' and var_IdArticulo='" & dtrArticulo("var_IdArticulo") & "' AND var_IdAlmacen='" & dtrAlmacen("var_IdAlmacen") & "'")
                                    dblCantidad = dblCantidad + dtrMovimiento("num_Cantidad")
                                    dblIFCantidad = dblIFCantidad + dtrMovimiento("num_Cantidad")
                                    dblCosto = dblCosto + (dtrMovimiento("num_Cantidad") * dtrMovimiento("num_CostoUnitario"))
                                    dblIFCosto = dblIFCosto + (dtrMovimiento("num_Cantidad") * dtrMovimiento("num_CostoUnitario"))
                                    dblImporte = dblImporte + dtrMovimiento("num_Importe")
                                    dblIFImporte = dblIFImporte + dtrMovimiento("num_Importe")
                                Next
                                If dblCantidad > 0 Then
                                    dblCostoUnitario = dblCosto / dblCantidad
                                Else
                                    dblCostoUnitario = 0
                                End If

                                'AGREGAMOS EN LA TABLA
                                rowItem.Cells.Add(CreateCelll(Format(dblCantidad, "#,##0.00"), "Item", "R", 1, 1))
                                rowItem.Cells.Add(CreateCelll(Format(dblCostoUnitario, "#,##0.00"), "Item", "R", 1, 1))
                                rowItem.Cells.Add(CreateCelll(Format(dblImporte, "#,##0.00"), "Item", "R", 1, 1))

                            Next

                            '----------------------------------------
                            'SALIDAS
                            '----------------------------------------
                            For Each dtrTipoMovimiento As Data.DataRow In objTipoMovimiento.Datos.Select("chr_Clase = 'S'")
                                'INICIALIZAR LAS VARIABLES
                                dblCantidad = 0
                                dblCostoUnitario = 0
                                dblImporte = 0
                                dblCosto = 0
                                'OBTENEMOS LOS MOVIMIENTO ACTIVOS DE ACUERDO AL TIPO DE MOVIMIENTO
                                'RECORREMOS CADA MOVIMIENTO
                                For Each dtrMovimiento As Data.DataRow In objMovimientos.Datos.Select("var_IdTipoMovimiento='" & dtrTipoMovimiento("var_IdTipoMovimiento") & "' and var_IdArticulo='" & dtrArticulo("var_IdArticulo") & "' AND var_IdAlmacen='" & dtrAlmacen("var_IdAlmacen") & "'")
                                    dblCantidad = dblCantidad + dtrMovimiento("num_Cantidad")
                                    dblIFCantidad = dblIFCantidad - dtrMovimiento("num_Cantidad")
                                    dblCosto = dblCosto + (dtrMovimiento("num_Cantidad") * dtrMovimiento("num_CostoUnitario"))
                                    dblIFCosto = dblIFCosto - (dtrMovimiento("num_Cantidad") * dtrMovimiento("num_CostoUnitario"))
                                    dblImporte = dblImporte + dtrMovimiento("num_Importe")
                                    dblIFImporte = dblIFImporte - dtrMovimiento("num_Importe")
                                Next
                                If dblCantidad > 0 Then
                                    dblCostoUnitario = dblCosto / dblCantidad
                                Else
                                    dblCostoUnitario = 0
                                End If
                                'AGREGAMOS EN LA TABLA
                                rowItem.Cells.Add(CreateCelll(Format(dblCantidad, "#,##0.00"), "Item", "R", 1, 1))
                                rowItem.Cells.Add(CreateCelll(Format(dblCostoUnitario, "#,##0.00"), "Item", "R", 1, 1))
                                rowItem.Cells.Add(CreateCelll(Format(dblImporte, "#,##0.00"), "Item", "R", 1, 1))

                            Next

                            '----------------------------------------
                            'INVENTARIO FINAL
                            '----------------------------------------
                            If dblIFCantidad > 0 Then
                                dblIFCostoUnitario = dblIFCosto / dblIFCantidad
                            Else
                                dblIFCostoUnitario = 0
                            End If
                            If dblIFCantidad < 0 Then
                                hdnGenerado.Value = "N"
                            End If

                            rowItem.Cells.Add(CreateCelll(Format(dblIFCantidad, "#,##0.00"), "Item", "R", 1, 1))
                            rowItem.Cells.Add(CreateCelll(Format(dblIFCostoUnitario, "#,##0.00"), "Item", "R", 1, 1))
                            rowItem.Cells.Add(CreateCelll(Format(dblIFImporte, "#,##0.00"), "Item", "R", 1, 1))

                            tblDatos.Rows.Add(rowItem)
                        End If
                    Next
                End If
            Next
            '*********************************************************
            'FINAL: CUERPO
            '*********************************************************
            Session("dtbResumen") = dtbResumen
        End If
    End Sub
    Private Function CreateCelll(ByVal strTexto As String, ByVal strTipo As String, _
                                 ByVal strAlign As String, ByVal intCols As Int16, ByVal intRows As Int16) As TableCell
        Dim celItem As New TableCell
        celItem.Text = strTexto
        celItem.ColumnSpan = intCols
        celItem.RowSpan = intRows
        Select Case strTipo
            Case "Head"
                celItem.CssClass = "GridHeader"
            Case "Foot"
                celItem.CssClass = "GridFooter"
            Case "Item"
                celItem.CssClass = "GridItem"
            Case "Alt"
                celItem.CssClass = "GridAltItem"
        End Select
        Select Case strAlign
            Case "L"
                celItem.HorizontalAlign = HorizontalAlign.Left
            Case "R"
                celItem.HorizontalAlign = HorizontalAlign.Right
            Case "C"
                celItem.HorizontalAlign = HorizontalAlign.Center
            Case "J"
                celItem.HorizontalAlign = HorizontalAlign.Justify
        End Select
        Return celItem
    End Function

    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExportar.Click
        Dim stringWrite As New System.IO.StringWriter
        Dim htmlWrite As New System.Web.UI.HtmlTextWriter(stringWrite)
        Dim tblExcel As New Table
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment;filename=Cierre_" & ddlAnno.SelectedValue & ddlMes.SelectedValue & ".xls")
        Response.ContentEncoding = Encoding.Default
        BindResumen(tblExcel)

        tblExcel.RenderControl(htmlWrite)
        Response.Write(stringWrite.ToString)
        Response.End()
    End Sub

    Protected Sub ddlAnno_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAnno.SelectedIndexChanged
        hdnGenerado.Value = "N"
    End Sub

    Protected Sub ddlFamilia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlFamilia.SelectedIndexChanged
        hdnGenerado.Value = "N"
    End Sub

    Protected Sub ddlMes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMes.SelectedIndexChanged
        hdnGenerado.Value = "N"
    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        If ddlFamilia.SelectedValue <> "" AndAlso ddlAnno.SelectedValue <> "" _
        AndAlso ddlMes.SelectedValue <> "" Then
            'AndAlso hdnGenerado.Value = "S"
            Dim objRegistro As New ALVI_LOGIC.Proceso.Logistica.Kardex.Resumen

            Dim objTipoMovimiento As New ALVI_LOGIC.Maestros.Logistica.TipoMovimiento
            Dim objMovimientos As New ALVI_LOGIC.Proceso.Logistica.Kardex.Detalle
            Dim objResumen As New ALVI_LOGIC.Proceso.Logistica.Kardex.Resumen
            Dim objAlmacen As New ALVI_LOGIC.Maestros.Logistica.Almacen
            Dim dtmPeriodoAnterior As Date = DateAdd(DateInterval.Month, -1, New Date(ddlAnno.SelectedValue, ddlMes.SelectedValue, 1))
            Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Articulo
            objTipoMovimiento.Clasificacion = ""
            objTipoMovimiento.Listar()

            objAlmacen.Listar()
            objArticulo.IdSubFamilia = ddlFamilia.SelectedValue
            objArticulo.Listar()
            '*********************************************************
            'INICIO: CUERPO
            '*********************************************************

            objMovimientos.ListarPeriodo(ddlAnno.SelectedValue, ddlMes.SelectedValue)

            'OBTENERMOS EL INVENTARIO FINAL DEL PERIODO ANTERIOR
            objResumen.Anno = Format(dtmPeriodoAnterior.Year, "0000")
            objResumen.Mes = Format(dtmPeriodoAnterior.Month, "00")
            objResumen.IdTipoMovimiento = "A02"
            objResumen.IdArticulo = ""
            objResumen.IdAlmacen = ""
            objResumen.Listar()

            For Each dtrAlmacen As Data.DataRow In objAlmacen.Datos.Rows
                If objMovimientos.Datos.Select("var_IdAlmacen='" & dtrAlmacen("var_IdAlmacen") & "'").Count > 0 _
                OrElse objResumen.Datos.Select("var_IdAlmacen='" & dtrAlmacen("var_IdAlmacen") & "'").Count > 0 Then

                    For Each dtrArticulo As Data.DataRow In objArticulo.Datos.Rows
                        If objMovimientos.Datos.Select("var_IdAlmacen='" & dtrAlmacen("var_IdAlmacen") & "' AND var_IdArticulo='" & dtrArticulo("var_IdArticulo") & "'").Count > 0 _
                        OrElse objResumen.Datos.Select("var_IdAlmacen='" & dtrAlmacen("var_IdAlmacen") & "' AND var_IdArticulo='" & dtrArticulo("var_IdArticulo") & "'").Count > 0 Then

                            Dim dblCantidad As Double = 0
                            Dim dblImporte As Double = 0
                            Dim dblCostoUnitario As Double = 0
                            Dim dblCosto As Double = 0
                            'Acumuladores de Inventario final
                            Dim dblIFCantidad As Double = 0
                            Dim dblIFImporte As Double = 0
                            Dim dblIFCostoUnitario As Double = 0
                            Dim dblIFCosto As Double = 0

                            '----------------------------------------
                            'INVENTARIO INICIAL
                            '----------------------------------------

                            'OBTENERMOS EL INVENTARIO FINAL DEL PERIODO ANTERIOR
                            For Each dtrResumen As Data.DataRow In objResumen.Datos.Select("var_IdArticulo='" & dtrArticulo("var_IdArticulo") & "' AND var_IdAlmacen='" & dtrAlmacen("var_IdAlmacen") & "'")
                                dblCantidad = dtrResumen("num_Cantidad")
                                dblIFCantidad = dtrResumen("num_Cantidad")
                                dblCostoUnitario = dtrResumen("num_CostoUnitario")
                                dblIFCosto = dblCostoUnitario * dblCantidad
                                dblImporte = dtrResumen("num_Importe")
                                dblIFImporte = dtrResumen("num_Importe")
                            Next

                            'AGREGAMOS EL DATO A LA TABLA DE RESUMEN
                            objRegistro.Anno = ddlAnno.SelectedValue
                            objRegistro.Mes = ddlMes.SelectedValue
                            objRegistro.IdTipoMovimiento = "A01"
                            objRegistro.IdArticulo = dtrArticulo("var_IdArticulo")
                            objRegistro.Cantidad = dblCantidad
                            objRegistro.CostoUnitario = dblCostoUnitario
                            objRegistro.Importe = dblImporte
                            objRegistro.IdUnidadMedida = dtrArticulo("var_IdUnidadMedida")
                            objRegistro.IdAlmacen = dtrAlmacen("var_idAlmacen")
                            objRegistro.Estado = "ACT"
                            objRegistro.Usuario = Session("USUARIO")
                            objRegistro.Registrar()

                            '----------------------------------------
                            'INGRESOS
                            '----------------------------------------
                            For Each dtrTipoMovimiento As Data.DataRow In objTipoMovimiento.Datos.Select("chr_Clase = 'I'")
                                'INICIALIZAR LAS VARIABLES
                                dblCantidad = 0
                                dblCostoUnitario = 0
                                dblImporte = 0
                                dblCosto = 0
                                'OBTENEMOS LOS MOVIMIENTO ACTIVOS DE ACUERDO AL TIPO DE MOVIMIENTO
                                'RECORREMOS CADA MOVIMIENTO
                                For Each dtrMovimiento As Data.DataRow In objMovimientos.Datos.Select("var_IdTipoMovimiento='" & dtrTipoMovimiento("var_IdTipoMovimiento") & "' and var_IdArticulo='" & dtrArticulo("var_IdArticulo") & "' AND var_IdAlmacen='" & dtrAlmacen("var_IdAlmacen") & "'")
                                    dblCantidad = dblCantidad + dtrMovimiento("num_Cantidad")
                                    dblIFCantidad = dblIFCantidad + dtrMovimiento("num_Cantidad")
                                    dblCosto = dblCosto + (dtrMovimiento("num_Cantidad") * dtrMovimiento("num_CostoUnitario"))
                                    dblIFCosto = dblIFCosto + (dtrMovimiento("num_Cantidad") * dtrMovimiento("num_CostoUnitario"))
                                    dblImporte = dblImporte + dtrMovimiento("num_Importe")
                                    dblIFImporte = dblIFImporte + dtrMovimiento("num_Importe")
                                Next
                                If dblCantidad > 0 Then
                                    dblCostoUnitario = dblCosto / dblCantidad
                                Else
                                    dblCostoUnitario = 0
                                End If

                                'AGREGAMOS EL DATO A LA TABLA DE RESUMEN
                                objRegistro.Anno = ddlAnno.SelectedValue
                                objRegistro.Mes = ddlMes.SelectedValue
                                objRegistro.IdTipoMovimiento = dtrTipoMovimiento("var_IdTipoMovimiento")
                                objRegistro.IdArticulo = dtrArticulo("var_IdArticulo")
                                objRegistro.Cantidad = dblCantidad
                                objRegistro.CostoUnitario = dblCostoUnitario
                                objRegistro.Importe = dblImporte
                                objRegistro.IdUnidadMedida = dtrArticulo("var_IdUnidadMedida")
                                objRegistro.IdAlmacen = dtrAlmacen("var_idAlmacen")
                                objRegistro.Estado = "ACT"
                                objRegistro.Usuario = Session("USUARIO")
                                objRegistro.Registrar()
                            Next

                            '----------------------------------------
                            'SALIDAS
                            '----------------------------------------
                            For Each dtrTipoMovimiento As Data.DataRow In objTipoMovimiento.Datos.Select("chr_Clase = 'S'")
                                'INICIALIZAR LAS VARIABLES
                                dblCantidad = 0
                                dblCostoUnitario = 0
                                dblImporte = 0
                                dblCosto = 0
                                'OBTENEMOS LOS MOVIMIENTO ACTIVOS DE ACUERDO AL TIPO DE MOVIMIENTO
                                'RECORREMOS CADA MOVIMIENTO
                                For Each dtrMovimiento As Data.DataRow In objMovimientos.Datos.Select("var_IdTipoMovimiento='" & dtrTipoMovimiento("var_IdTipoMovimiento") & "' and var_IdArticulo='" & dtrArticulo("var_IdArticulo") & "' AND var_IdAlmacen='" & dtrAlmacen("var_IdAlmacen") & "'")
                                    dblCantidad = dblCantidad + dtrMovimiento("num_Cantidad")
                                    dblIFCantidad = dblIFCantidad - dtrMovimiento("num_Cantidad")
                                    dblCosto = dblCosto + (dtrMovimiento("num_Cantidad") * dtrMovimiento("num_CostoUnitario"))
                                    dblIFCosto = dblIFCosto - (dtrMovimiento("num_Cantidad") * dtrMovimiento("num_CostoUnitario"))
                                    dblImporte = dblImporte + dtrMovimiento("num_Importe")
                                    dblIFImporte = dblIFImporte - dtrMovimiento("num_Importe")
                                Next
                                If dblCantidad > 0 Then
                                    dblCostoUnitario = dblCosto / dblCantidad
                                Else
                                    dblCostoUnitario = 0
                                End If

                                'AGREGAMOS EL DATO A LA TABLA DE RESUMEN TEMPORAL
                                'AGREGAMOS EL DATO A LA TABLA DE RESUMEN
                                objRegistro.Anno = ddlAnno.SelectedValue
                                objRegistro.Mes = ddlMes.SelectedValue
                                objRegistro.IdTipoMovimiento = dtrTipoMovimiento("var_IdTipoMovimiento")
                                objRegistro.IdArticulo = dtrArticulo("var_IdArticulo")
                                objRegistro.Cantidad = dblCantidad
                                objRegistro.CostoUnitario = dblCostoUnitario
                                objRegistro.Importe = dblImporte
                                objRegistro.IdUnidadMedida = dtrArticulo("var_IdUnidadMedida")
                                objRegistro.IdAlmacen = dtrAlmacen("var_idAlmacen")
                                objRegistro.Estado = "ACT"
                                objRegistro.Usuario = Session("USUARIO")
                                objRegistro.Registrar()
                            Next

                            '----------------------------------------
                            'INVENTARIO FINAL
                            '----------------------------------------
                            If dblIFCantidad > 0 Then
                                dblIFCostoUnitario = dblIFCosto / dblIFCantidad
                            Else
                                dblIFCostoUnitario = 0
                            End If

                            'AGREGAMOS EL DATO A LA TABLA DE RESUMEN TEMPORAL
                            'AGREGAMOS EL DATO A LA TABLA DE RESUMEN
                            objRegistro.Anno = ddlAnno.SelectedValue
                            objRegistro.Mes = ddlMes.SelectedValue
                            objRegistro.IdTipoMovimiento = "A02"
                            objRegistro.IdArticulo = dtrArticulo("var_IdArticulo")
                            objRegistro.Cantidad = dblIFCantidad
                            objRegistro.CostoUnitario = dblIFCostoUnitario
                            objRegistro.Importe = dblIFImporte
                            objRegistro.IdUnidadMedida = dtrArticulo("var_IdUnidadMedida")
                            objRegistro.IdAlmacen = dtrAlmacen("var_idAlmacen")
                            objRegistro.Estado = "ACT"
                            objRegistro.Usuario = Session("USUARIO")
                            objRegistro.Registrar()
                        End If
                    Next
                End If
            Next
            '*********************************************************
            'FINAL: CUERPO
            '*********************************************************
        Else
            ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('Revise su información, data no consistente.');</script>")
        End If
    End Sub
End Class
