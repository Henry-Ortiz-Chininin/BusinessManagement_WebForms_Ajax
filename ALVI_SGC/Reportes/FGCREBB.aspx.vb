
Partial Class Reportes_FGCREBB
    Inherits System.Web.UI.Page

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
        ddlTipoMovimiento.Items.Insert(0, New ListItem("Seleccionar", "S"))
        ddlTipoMovimiento.SelectedIndex = 0
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindTipoMovimiento()
            txtFechaInicio.Text = Format(Now.Date, "dd/MM/yyyy")
            btnFechaInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaInicio.ClientID & ", 'dd/mm/yyyy');")
            txtFechaFinal.Text = Format(Now.Date, "dd/MM/yyyy")
            btnFechaFinal.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaFinal.ClientID & ", 'dd/mm/yyyy');")
            BindFamilia()
        End If
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        If txtFechaInicio.Text <> "" AndAlso txtFechaFinal.Text <> "" Then
            BindGrid()
        Else
            ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('Ingrese fecha de inicio y de fin'); </script>")
        End If
    End Sub
    Private Sub BindGrid()
        Dim objMovimientos As New ALVI_LOGIC.Proceso.Logistica.Kardex.Detalle
        objMovimientos.Busqueda(txtFechaInicio.Text, txtFechaFinal.Text, _
                                ddlTipoMovimiento.SelectedValue, _
                                ddlFamilia.SelectedValue, ddlSubFamilia.SelectedValue, _
                                ctlCentroCosto1.IdCentroCosto, _
                                ctlCuentaGasto1.IdCuentaGasto)
        grdDatos.DataSource = New Data.DataView(objMovimientos.Datos, "", "chr_IdKardex", Data.DataViewRowState.OriginalRows)
        grdDatos.DataBind()
    End Sub

    Protected Sub grdDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDatos.PageIndexChanging
        grdDatos.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub

    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExportar.Click
        Dim stringWrite As New System.IO.StringWriter
        Dim htmlWrite As New System.Web.UI.HtmlTextWriter(stringWrite)
        Dim tblExcel As New Table
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment;filename=ReporteLogistica_" & Format(Now, "yyyyMMdd_HHmm") & ".xls")
        Response.ContentEncoding = Encoding.Default
        BindResumen(tblExcel)

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

    Protected Sub ddlFamilia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlFamilia.SelectedIndexChanged
        BindSubFamilia()
    End Sub

    Private Sub BindResumen(ByRef tblDatos As Table)
        Dim rowTable As TableRow

        rowTable = New TableRow
        rowTable.Cells.Add(CreateCell("Código", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Id CC", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Descripción CC", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Id CG", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Descripción CG", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Orden de Producción", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Fecha", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Tipo Documento", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Nro. Documento", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Tipo Movimiento", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Articulo", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Descripción", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Unidad", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Cantidad", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Costo Unitario", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Importe", "Head", "C", 1, 1))
        tblDatos.Rows.Add(rowTable)

        'OBTENEMOS LOS DATOS
        Dim objMovimientos As New ALVI_LOGIC.Proceso.Logistica.Kardex.Detalle
        objMovimientos.Busqueda(txtFechaInicio.Text, txtFechaFinal.Text, _
                                ddlTipoMovimiento.SelectedValue, _
                                ddlFamilia.SelectedValue, ddlSubFamilia.SelectedValue, _
                                ctlCentroCosto1.IdCentroCosto, _
                                ctlCuentaGasto1.IdCuentaGasto)
        Dim dvwMovimientos As New Data.DataView(objMovimientos.Datos, "", "chr_IdKardex", Data.DataViewRowState.OriginalRows)
        For Each dtrItem As Data.DataRowView In dvwMovimientos
            rowTable = New TableRow
            rowTable.Cells.Add(CreateCell(dtrItem("chr_IdKardex"), "Item", "C", 1, 1))
            rowTable.Cells.Add(CreateCell(dtrItem("var_IdCentroCosto"), "Item", "C", 1, 1))
            rowTable.Cells.Add(CreateCell(dtrItem("var_CentroCosto"), "Item", "C", 1, 1))
            rowTable.Cells.Add(CreateCell(dtrItem("var_IdCuentaGasto"), "Item", "C", 1, 1))
            rowTable.Cells.Add(CreateCell(dtrItem("var_CuentaGasto"), "Item", "C", 1, 1))
            rowTable.Cells.Add(CreateCell(dtrItem("var_IdOrdenProduccion"), "Item", "C", 1, 1))
            rowTable.Cells.Add(CreateCell(dtrItem("dtm_FechaMovimiento"), "Item", "C", 1, 1))
            rowTable.Cells.Add(CreateCell(dtrItem("var_TipoDocumento"), "Item", "C", 1, 1))
            rowTable.Cells.Add(CreateCell(dtrItem("var_NumeroDocumento"), "Item", "C", 1, 1))
            rowTable.Cells.Add(CreateCell(dtrItem("var_TipoMovimiento"), "Item", "C", 1, 1))
            rowTable.Cells.Add(CreateCell(dtrItem("var_IdArticulo"), "Item", "C", 1, 1))
            rowTable.Cells.Add(CreateCell(dtrItem("var_Articulo"), "Item", "C", 1, 1))
            rowTable.Cells.Add(CreateCell(dtrItem("var_UnidadMedida"), "Item", "C", 1, 1))
            rowTable.Cells.Add(CreateCell(Format(dtrItem("num_Cantidad"), "#,##0.00"), "Item", "R", 1, 1))
            rowTable.Cells.Add(CreateCell(Format(dtrItem("num_CostoUnitario"), "#,##0.0000"), "Item", "R", 1, 1))
            rowTable.Cells.Add(CreateCell(Format(dtrItem("num_Importe"), "#,##0.0000"), "Item", "R", 1, 1))
            tblDatos.Rows.Add(rowTable)

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
End Class
