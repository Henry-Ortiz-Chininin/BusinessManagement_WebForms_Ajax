
Partial Class Reportes_FGCREEA
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindProveedor()
            btnFechaInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaInicio.ClientID & ", 'dd/mm/yyyy');")
            txtFechaInicio.Text = Format(Now, "dd/MM/yyyy")
            btnFechaFinal.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaFinal.ClientID & ", 'dd/mm/yyyy');")
            txtFechaFinal.Text = Format(Now, "dd/MM/yyyy")
        End If
    End Sub


    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExportar.Click
        Dim stringWrite As New System.IO.StringWriter
        Dim htmlWrite As New System.Web.UI.HtmlTextWriter(stringWrite)
        Dim tblExcel As New Table
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment;filename=ReporteServicios.xls")
        Response.ContentEncoding = Encoding.Default
        BindReporteGeneral(tblExcel)
        tblExcel.RenderControl(htmlWrite)
        Response.Write(stringWrite.ToString)
        Response.End()
    End Sub


    Private Sub BindProveedor()
        Dim objProveedor As New ALVI_LOGIC.Maestros.Compras.Proveedor
        ddlProveedor.Items.Clear()
        If objProveedor.Listar() = True Then
            ddlProveedor.DataValueField = "var_IdProveedor"
            ddlProveedor.DataTextField = "var_Descripcion"
            ddlProveedor.DataSource = objProveedor.Datos
            ddlProveedor.DataBind()
        End If
        ddlProveedor.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlProveedor.SelectedIndex = 0
    End Sub


    Private Sub BindReporteGeneral(ByRef tblDatos As Table)
        Dim rowTable As TableRow
        Dim objReporte As New ALVI_LOGIC.Resultado.Produccion

        'CABECERA
        rowTable = New TableRow
        rowTable.Cells.Add(CreateCell("Nro. OP", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Orden Servicio", "Head", "C", 1, 1))
        'rowTable.Cells.Add(CreateCell("Id Articulo", "Head", "C", 1, 1))
        'rowTable.Cells.Add(CreateCell("Descripción Articulo", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Proceso", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Cliente", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Proveedor", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Importe", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Enviado", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Retorno", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Saldo", "Head", "C", 1, 1))

        rowTable.Cells.Add(CreateCell("1er Envio", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Ult. Envio", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("1er Retorno", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Ult. Retorno", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Fecha Entrega Programado", "Head", "C", 1, 1))
        rowTable.Cells.Add(CreateCell("Retrazo (Días)", "Head", "C", 1, 1))

        tblDatos.Rows.Add(rowTable)

        'OBTENEMOS LOS DATOS
        objReporte.ReporteServicio(txtFechaInicio.Text, txtFechaFinal.Text, ctlArticulo1.IdArticulo, txtOrden.Text, ddlProveedor.SelectedValue)

        For Each dtrItem As Data.DataRow In objReporte.Datos.Rows

            rowTable = New TableRow
            rowTable.Cells.Add(CreateCell(dtrItem("var_IdOrden"), "Item", "C", 1, 1))
            rowTable.Cells.Add(CreateCell(dtrItem("var_OrdenServicio"), "Item", "C", 1, 1))
            'rowTable.Cells.Add(CreateCell(dtrItem("var_IdArticulo"), "Item", "C", 1, 1))
            'rowTable.Cells.Add(CreateCell(dtrItem("var_Material"), "Item", "C", 1, 1))
            rowTable.Cells.Add(CreateCell(dtrItem("var_Proceso"), "Item", "C", 1, 1))
            rowTable.Cells.Add(CreateCell(dtrItem("var_NombreCliente"), "Item", "C", 1, 1))
            rowTable.Cells.Add(CreateCell(dtrItem("var_NombreProveedor"), "Item", "C", 1, 1))
            rowTable.Cells.Add(CreateCell(Format(dtrItem("num_ImporteServicio"), "#,##0.00"), "Item", "R", 1, 1))
            rowTable.Cells.Add(CreateCell(Format(dtrItem("num_CantidadOrden"), "#,##0.00"), "Item", "R", 1, 1))
            rowTable.Cells.Add(CreateCell(Format(dtrItem("num_CantidadDespacho"), "#,##0.00"), "Item", "R", 1, 1))
            rowTable.Cells.Add(CreateCell(Format(dtrItem("num_SaldoPendiente"), "#,##0.00"), "Item", "R", 1, 1))
            Try
                rowTable.Cells.Add(CreateCell(Format(dtrItem("dtm_SalidaMin"), "dd/MM/yyyy"), "Item", "R", 1, 1))
            Catch ex As Exception
                rowTable.Cells.Add(CreateCell("", "Item", "R", 1, 1))

            End Try
            Try
                rowTable.Cells.Add(CreateCell(Format(dtrItem("dtm_SalidaMax"), "dd/MM/yyyy"), "Item", "R", 1, 1))
            Catch ex As Exception
                rowTable.Cells.Add(CreateCell("", "Item", "R", 1, 1))
            End Try
            Try
                rowTable.Cells.Add(CreateCell(Format(dtrItem("dtm_RetornoMin"), "dd/MM/yyyy"), "Item", "R", 1, 1))
            Catch ex As Exception
                rowTable.Cells.Add(CreateCell("", "Item", "R", 1, 1))
            End Try
            Try
                rowTable.Cells.Add(CreateCell(Format(dtrItem("dtm_RetornoMax"), "dd/MM/yyyy"), "Item", "R", 1, 1))
            Catch ex As Exception
                rowTable.Cells.Add(CreateCell("", "Item", "R", 1, 1))
            End Try
            rowTable.Cells.Add(CreateCell(Format(dtrItem("dtm_ProgramaMax"), "dd/MM/yyyy"), "Item", "R", 1, 1))

            Dim dblDiferencia As Double = 0
            Try
                dblDiferencia = DateDiff(DateInterval.Day, dtrItem("dtm_ProgramaMax"), dtrItem("dtm_RetornoMax"))
            Catch ex As Exception
                dblDiferencia = 0
            End Try

            If dblDiferencia > 0 Then
                rowTable.Cells.Add(CreateCell(Format(dblDiferencia, "0.##"), "SOS", "R", 1, 1))
            Else
                rowTable.Cells.Add(CreateCell(Format(dblDiferencia, "0.##"), "Item", "R", 1, 1))
            End If

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
            Case "SOS"
                celItem.CssClass = "GridItem"
                celItem.BackColor = Drawing.Color.Red
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
        BindReporteGeneral(tblExcel)
        Session("Titulo") = "Reporte de Servicios: " & txtFechaInicio.Text & " - " & txtFechaFinal.Text
        tblExcel.RenderControl(htmlWrite)
        Session("Impresion") = stringWrite.ToString

        ClientScript.RegisterStartupScript(ClientScript.GetType, "Imprimir", "<script language='javascript'>window.open('../Controles/frmPrint.aspx','Reporte', 'resizable=1,height=600,width=1000,top=0,left=0,scrollbars=1');</script>")


    End Sub

End Class
