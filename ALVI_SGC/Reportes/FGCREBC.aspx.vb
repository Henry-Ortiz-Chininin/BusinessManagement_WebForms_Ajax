
Partial Class Reportes_FGCREBC
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindFamilia()
            BindAtributoTipo()
            btnFecha.Attributes.Add("onclick", "popUpCalendar(this, " & txtFecha.ClientID & ", 'dd/mm/yyyy');")
            txtFecha.Text = Format(Now, "dd/MM/yyyy")
        End If
    End Sub


    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExportar.Click
        Dim stringWrite As New System.IO.StringWriter
        Dim htmlWrite As New System.Web.UI.HtmlTextWriter(stringWrite)
        Dim tblExcel As New Table
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment;filename=ReporteStock" & Replace(txtFecha.Text, "/", "") & ".xls")
        Response.ContentEncoding = Encoding.Default
        Select Case ddlTipoReporte.SelectedValue
            Case "RF"
                BindResumenFamilia(tblExcel)
            Case "RS"
                BindResumenSubFamilia(tblExcel)
            Case "DE"
                BindDetalleFamilia(tblExcel)
        End Select

        tblExcel.RenderControl(htmlWrite)
        Response.Write(stringWrite.ToString)
        Response.End()
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
    Private Sub BindSubFamilia()
        Dim objSubFamilia As New ALVI_LOGIC.Maestros.Articulo.SubFamilia
        ddlSubFamilia.Items.Clear()
        objSubFamilia.IdFamilia = ddlFamilia.SelectedValue
        If objSubFamilia.Listar() = True Then
            ddlSubFamilia.DataValueField = "var_IdSubFamilia"
            ddlSubFamilia.DataTextField = "var_Descripcion"
            ddlSubFamilia.DataSource = objSubFamilia.Datos
            ddlSubFamilia.DataBind()
        End If
        ddlSubFamilia.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlSubFamilia.SelectedIndex = 0
    End Sub
    Private Sub BindAtributoTipo()
        Dim objAtributo As New ALVI_LOGIC.Maestros.Articulo.Atributo.Tipo
        ddlAtributoTipo.Items.Clear()
        objAtributo.IdSubFamilia = ddlSubFamilia.SelectedValue
        If objAtributo.Listar() = True Then
            ddlAtributoTipo.DataValueField = "chr_IdAtributo"
            ddlAtributoTipo.DataTextField = "var_Descripcion"
            ddlAtributoTipo.DataSource = objAtributo.Datos
            ddlAtributoTipo.DataBind()
        End If
        ddlAtributoTipo.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlAtributoTipo.SelectedIndex = 0
    End Sub
    Private Sub BindAtributoValor()
        Dim objAtributo As New ALVI_LOGIC.Maestros.Articulo.Atributo.Valores
        ddlAtributoValor.Items.Clear()
        objAtributo.IdSubFamilia = ddlSubFamilia.SelectedValue
        objAtributo.IdAtributoTipo = ddlAtributoTipo.SelectedValue
        If objAtributo.Listar() = True Then
            ddlAtributoValor.DataValueField = "var_IdAtributoValor"
            ddlAtributoValor.DataTextField = "var_Descripcion"
            ddlAtributoValor.DataSource = New Data.DataView(objAtributo.Datos, "", "var_Descripcion", Data.DataViewRowState.OriginalRows)
            ddlAtributoValor.DataBind()
        End If
        ddlAtributoValor.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlAtributoValor.SelectedIndex = 0
    End Sub

    Protected Sub ddlFamilia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlFamilia.SelectedIndexChanged
        BindSubFamilia()
    End Sub

    Private Sub BindResumenFamilia(ByRef tblDatos As Table)
        Dim rowTable As TableRow
        Dim strIdArticulo As String = ""
        Dim objFamilia As New ALVI_LOGIC.Maestros.Articulo.Familia
        Dim objAlmacen As New ALVI_LOGIC.Maestros.Logistica.Almacen
        objFamilia.Listar()
        objAlmacen.Listar()

        If ddlAtributoTipo.SelectedValue <> "" Then
            Dim objAtributo As New ALVI_LOGIC.Maestros.Articulo.Atributo.Tipo
            objAtributo.IdSubFamilia = ddlSubFamilia.SelectedValue
            objAtributo.IdAtributoTipo = ddlAtributoTipo.SelectedValue
            If objAtributo.Obtener Then
                For intIndice As Int16 = 1 To 20
                    If objAtributo.Posicion = intIndice Then
                        strIdArticulo = strIdArticulo & ddlAtributoValor.SelectedValue
                    Else
                        strIdArticulo = strIdArticulo & "_"
                    End If
                Next

            End If
        End If
        If ctlArticulo1.IdArticulo <> "" Then
            strIdArticulo = ctlArticulo1.IdArticulo
        End If

        rowTable = New TableRow
        rowTable.Cells.Add(CreateCell("Familia", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Almacen", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Cantidad", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Costo Unitario", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Importe", "Head", "C", 1, 1))
        tblDatos.Rows.Add(rowTable)

        'OBTENEMOS LOS DATOS
        Dim objKardex As New ALVI_LOGIC.Proceso.Logistica.Kardex.Resumen
        objKardex.ObtenerStock(ddlFamilia.SelectedValue, ddlSubFamilia.SelectedValue, _
                               strIdArticulo, txtFecha.Text, txtCriterio.Text)
        For Each dtrFamilia As Data.DataRow In objFamilia.Datos.Select("chr_IdFamilia like  '%" & ddlFamilia.SelectedValue & "'", "var_Descripcion", Data.DataViewRowState.OriginalRows)
            For Each dtrAlmacen As Data.DataRow In objAlmacen.Datos.Rows
                Dim strQuery As String
                strQuery = "chr_IdFamilia='" & dtrFamilia("chr_IdFamilia") & _
                "' AND var_IdAlmacen='" & dtrAlmacen("var_IdAlmacen") & "'"

                Dim dblCantidad As Double = 0
                Dim dblImporte As Double = 0
                Dim dvwKardex As New Data.DataView(objKardex.Datos, strQuery, "var_IdArticulo", Data.DataViewRowState.OriginalRows)
                For Each dtrItem As Data.DataRowView In dvwKardex
                    dblCantidad = dblCantidad + dtrItem("num_Cantidad")
                    dblImporte = dblImporte + dtrItem("num_Importe")
                Next

                If dblCantidad > 0 AndAlso dblImporte > 0 Then
                    rowTable = New TableRow
                    rowTable.Cells.Add(CreateCell(dtrFamilia("var_Descripcion"), "Item", "C", 1, 1))
                    rowTable.Cells.Add(CreateCell(dtrAlmacen("var_Descripcion"), "Item", "C", 1, 1))
                    rowTable.Cells.Add(CreateCell(Format(dblCantidad, "#,##0.00"), "Item", "R", 1, 1))
                    If dblCantidad > 0 Then
                        rowTable.Cells.Add(CreateCell(Format(dblImporte / dblCantidad, "#,##0.0000"), "Item", "R", 1, 1))
                    Else
                        rowTable.Cells.Add(CreateCell("0.00", "Item", "R", 1, 1))
                    End If
                    rowTable.Cells.Add(CreateCell(Format(dblImporte, "#,##0.0000"), "Item", "R", 1, 1))
                    tblDatos.Rows.Add(rowTable)
                End If
            Next
        Next

    End Sub
    Private Sub BindResumenSubFamilia(ByRef tblDatos As Table)
        Dim rowTable As TableRow
        Dim strIdArticulo As String = ""
        Dim objFamilia As New ALVI_LOGIC.Maestros.Articulo.Familia
        Dim objSubFamilia As New ALVI_LOGIC.Maestros.Articulo.SubFamilia
        Dim objAlmacen As New ALVI_LOGIC.Maestros.Logistica.Almacen

        objAlmacen.Listar()
        objFamilia.Listar()
        If ddlAtributoTipo.SelectedValue <> "" Then
            Dim objAtributo As New ALVI_LOGIC.Maestros.Articulo.Atributo.Tipo
            objAtributo.IdSubFamilia = ddlSubFamilia.SelectedValue
            objAtributo.IdAtributoTipo = ddlAtributoTipo.SelectedValue
            If objAtributo.Obtener Then
                For intIndice As Int16 = 1 To 20
                    If objAtributo.Posicion = intIndice Then
                        strIdArticulo = strIdArticulo & ddlAtributoValor.SelectedValue
                    Else
                        strIdArticulo = strIdArticulo & "_"
                    End If
                Next

            End If
        End If
        If ctlArticulo1.IdArticulo <> "" Then
            strIdArticulo = ctlArticulo1.IdArticulo
        End If

        rowTable = New TableRow
        rowTable.Cells.Add(CreateCell("Familia", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Sub-Familia", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Almacen", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Cantidad", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Costo Unitario", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Importe", "Head", "C", 1, 1))
        tblDatos.Rows.Add(rowTable)

        'OBTENEMOS LOS DATOS
        Dim objKardex As New ALVI_LOGIC.Proceso.Logistica.Kardex.Resumen
        objKardex.ObtenerStock(ddlFamilia.SelectedValue, ddlSubFamilia.SelectedValue, _
                               strIdArticulo, txtFecha.Text, txtCriterio.Text)
        For Each dtrFamilia As Data.DataRow In objFamilia.Datos.Select("chr_IdFamilia like  '%" & ddlFamilia.SelectedValue & "'", "var_Descripcion", Data.DataViewRowState.OriginalRows)
            Dim strQuery1 As String
            strQuery1 = "chr_IdFamilia like  '%" & dtrFamilia("chr_IdFamilia") & _
            "' AND var_IdSubFamilia like '%" & ddlSubFamilia.SelectedValue & "'"

            objSubFamilia.IdFamilia = dtrFamilia("chr_IdFamilia")
            objSubFamilia.Listar()
            For Each dtrSubFamilia As Data.DataRow In objSubFamilia.Datos.Select(strQuery1, "var_Descripcion", Data.DataViewRowState.OriginalRows)
                For Each dtrAlmacen As Data.DataRow In objAlmacen.Datos.Rows
                    Dim dblCantidad As Double = 0
                    Dim dblImporte As Double = 0
                    Dim strQuery2 As String
                    strQuery2 = "chr_IdFamilia='" & dtrFamilia("chr_IdFamilia") & _
                    "' AND var_IdSubFamilia='" & dtrSubFamilia("var_IdSubFamilia") & _
                    "' AND var_IdAlmacen='" & dtrAlmacen("var_IdAlmacen") & "'"

                    Dim dvwKardex As New Data.DataView(objKardex.Datos, strQuery2, "var_IdArticulo", Data.DataViewRowState.OriginalRows)
                    For Each dtrItem As Data.DataRowView In dvwKardex
                        dblCantidad = dblCantidad + dtrItem("num_Cantidad")
                        dblImporte = dblImporte + dtrItem("num_Importe")
                    Next

                    If dblCantidad > 0 AndAlso dblImporte > 0 Then
                        rowTable = New TableRow
                        rowTable.Cells.Add(CreateCell(dtrFamilia("var_Descripcion"), "Item", "C", 1, 1))
                        rowTable.Cells.Add(CreateCell(dtrSubFamilia("var_Descripcion"), "Item", "C", 1, 1))
                        rowTable.Cells.Add(CreateCell(dtrAlmacen("var_Descripcion"), "Item", "C", 1, 1))
                        rowTable.Cells.Add(CreateCell(Format(dblCantidad, "#,##0.00"), "Item", "R", 1, 1))
                        If dblCantidad > 0 Then
                            rowTable.Cells.Add(CreateCell(Format(dblImporte / dblCantidad, "#,##0.0000"), "Item", "R", 1, 1))
                        Else
                            rowTable.Cells.Add(CreateCell("0.00", "Item", "R", 1, 1))
                        End If
                        rowTable.Cells.Add(CreateCell(Format(dblImporte, "#,##0.0000"), "Item", "R", 1, 1))
                        tblDatos.Rows.Add(rowTable)
                    End If
                Next
            Next
        Next

    End Sub

    Private Sub BindDetalleFamilia(ByRef tblDatos As Table)
        Dim rowTable As TableRow
        Dim strIdArticulo As String = ""
        If ddlAtributoTipo.SelectedValue <> "" Then
            Dim objAtributo As New ALVI_LOGIC.Maestros.Articulo.Atributo.Tipo
            objAtributo.IdSubFamilia = ddlSubFamilia.SelectedValue
            objAtributo.IdAtributoTipo = ddlAtributoTipo.SelectedValue
            If objAtributo.Obtener Then
                For intIndice As Int16 = 1 To 20
                    If objAtributo.Posicion = intIndice Then
                        strIdArticulo = strIdArticulo & ddlAtributoValor.SelectedValue
                    Else
                        strIdArticulo = strIdArticulo & "_"
                    End If
                Next

            End If
        End If
        If ctlArticulo1.IdArticulo <> "" Then
            strIdArticulo = ctlArticulo1.IdArticulo
        End If


        rowTable = New TableRow
        rowTable.Cells.Add(CreateCell("Almacen", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Familia", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Sub-Familia", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Articulo", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Descripción", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Unidad", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Cantidad", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Costo Unitario", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Importe", "Head", "C", 1, 1))
        tblDatos.Rows.Add(rowTable)

        'OBTENEMOS LOS DATOS
        Dim objKardex As New ALVI_LOGIC.Proceso.Logistica.Kardex.Resumen
        Dim objAlmacen As New ALVI_LOGIC.Maestros.Logistica.Almacen
        objAlmacen.Listar()
        objKardex.ObtenerStock(ddlFamilia.SelectedValue, ddlSubFamilia.SelectedValue, _
                               strIdArticulo, txtFecha.Text, txtCriterio.Text)

        For Each dtrAlmacen As Data.DataRow In objAlmacen.Datos.Rows

            Dim dvwKardex As New Data.DataView(objKardex.Datos, "var_IdAlmacen='" & dtrAlmacen("var_IdAlmacen") & "'", "var_IdArticulo", Data.DataViewRowState.OriginalRows)

            For Each dtrItem As Data.DataRowView In dvwKardex
                Dim dblPrecio As Double = 0

                If dtrItem("num_Cantidad") > 0 AndAlso dtrItem("num_Importe") > 0 Then
                    dblPrecio = dtrItem("num_Importe") / dtrItem("num_Cantidad")
                End If
                rowTable = New TableRow
                rowTable.Cells.Add(CreateCell(dtrItem("var_Almacen"), "Item", "C", 1, 1))
                rowTable.Cells.Add(CreateCell(dtrItem("var_Familia"), "Item", "C", 1, 1))
                rowTable.Cells.Add(CreateCell(dtrItem("var_SubFamilia"), "Item", "C", 1, 1))
                rowTable.Cells.Add(CreateCell(dtrItem("var_IdArticulo"), "Item", "C", 1, 1))
                rowTable.Cells.Add(CreateCell(dtrItem("var_Articulo"), "Item", "C", 1, 1))
                rowTable.Cells.Add(CreateCell(dtrItem("var_UnidadMedida"), "Item", "C", 1, 1))
                rowTable.Cells.Add(CreateCell(Format(dtrItem("num_Cantidad"), "#,##0.00"), "Item", "R", 1, 1))
                rowTable.Cells.Add(CreateCell(Format(dblPrecio, "#,##0.0000"), "Item", "R", 1, 1))
                rowTable.Cells.Add(CreateCell(Format(dtrItem("num_Importe"), "#,##0.0000"), "Item", "R", 1, 1))
                tblDatos.Rows.Add(rowTable)


            Next

        Next


    End Sub

    Private Function CreateCell(ByVal strTexto As String, ByVal strTipo As String, _
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

    Protected Sub btnGenerar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGenerar.Click
        Dim stringWrite As New System.IO.StringWriter
        Dim htmlWrite As New System.Web.UI.HtmlTextWriter(stringWrite)
        Dim tblExcel As New Table
        Select Case ddlTipoReporte.SelectedValue
            Case "RF"
                BindResumenFamilia(tblExcel)
            Case "RS"
                BindResumenSubFamilia(tblExcel)
            Case "DE"
                BindDetalleFamilia(tblExcel)
        End Select

        Session("Titulo") = "Reporte de Stock a la fecha " & txtFecha.Text
        tblExcel.RenderControl(htmlWrite)
        Session("Impresion") = stringWrite.ToString

        ClientScript.RegisterStartupScript(ClientScript.GetType, "Imprimir", "<script language='javascript'>window.open('../Controles/frmPrint.aspx','Reporte', 'resizable=1,height=600,width=1000,top=0,left=0,scrollbars=1');</script>")


    End Sub

    Protected Sub ddlAtributoTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAtributoTipo.SelectedIndexChanged
        BindAtributoValor()
        ddlAtributoValor.Focus()
    End Sub

    Protected Sub ddlSubFamilia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSubFamilia.SelectedIndexChanged
        BindAtributoTipo()
    End Sub

End Class
