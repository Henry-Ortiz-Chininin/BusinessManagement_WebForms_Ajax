
Partial Class Reportes_FGCREHD
    Inherits System.Web.UI.Page
    Dim strEstado As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            btnDesde.Attributes.Add("onclick", "popUpCalendar(this, " & txtDesde.ClientID & ", 'dd/mm/yyyy');")
            btnHasta.Attributes.Add("onclick", "popUpCalendar(this, " & txtHasta.ClientID & ", 'dd/mm/yyyy');")
            rbtTodos.Checked = True
        End If
    End Sub
    Private Sub BinReporte()
        Dim stringWrite3 As New System.IO.StringWriter
        Dim htmlWrite3 As New System.Web.UI.HtmlTextWriter(stringWrite3)
        Dim objResultado As New ALVI_LOGIC.Proceso.Ventas.VentasReportes
        Dim objDocumento As New ALVI_LOGIC.Proceso.Ventas.VentasReportes
        Dim objSecurity As New ALVI_Security.General
        Dim DocumentoRelacionado As String = ""
        Dim objUtil As New Utilitarios


        Dim tblReporte As New Table
        Dim rowTable As TableRow
        Dim celTable As TableCell
        Dim tblCliente As New Table
        Dim Item As Int32 = 0

        If rbtActivo.Checked = True Then
            strEstado = "ACT"
        ElseIf rbtInactivo.Checked = True Then
            strEstado = "DES"
        ElseIf rbtTodos.Checked = True Then
            strEstado = ""
        End If
        objResultado.Estatus = strEstado
        objResultado.IdCliente = ctlCliente1.IdCliente
        objResultado.FechaFin = txtHasta.Text
        objResultado.FechaInicio = txtDesde.Text
        objResultado.TipoDocumento = ddlTipoDocumento.SelectedValue
        If objResultado.VentasReporte Then
            rowTable = New TableRow
            celTable = New TableCell


            rowTable.Cells.Add(objUtil.CreateCell("Item", "Head", "C", 1, 1))
            rowTable.Cells.Add(objUtil.CreateCell("Fecha Emisión", "Head", "C", 1, 1))
            rowTable.Cells.Add(objUtil.CreateCell("Fecha Vencimiento", "Head", "C", 1, 1))
            rowTable.Cells.Add(objUtil.CreateCell("Documento", "Head", "C", 1, 1))
            rowTable.Cells.Add(objUtil.CreateCell("Nº Documento", "Head", "C", 1, 1))
            rowTable.Cells.Add(objUtil.CreateCell("Código  Cliente", "Head", "C", 1, 1))
            rowTable.Cells.Add(objUtil.CreateCell("Razón  Social", "Head", "C", 1, 1))
            rowTable.Cells.Add(objUtil.CreateCell("Código  Articulo", "Head", "C", 1, 1))
            rowTable.Cells.Add(objUtil.CreateCell("Descripción  Articulo", "Head", "C", 1, 1))
            rowTable.Cells.Add(objUtil.CreateCell("Cantidad", "Head", "C", 1, 1))
            rowTable.Cells.Add(objUtil.CreateCell("CU", "Head", "C", 1, 1))
            rowTable.Cells.Add(objUtil.CreateCell("SubTotal", "Head", "C", 1, 1))
            rowTable.Cells.Add(objUtil.CreateCell("IGV %", "Head", "C", 1, 1))
            rowTable.Cells.Add(objUtil.CreateCell("Total", "Head", "C", 1, 1))
            rowTable.Cells.Add(objUtil.CreateCell("Moneda", "Head", "C", 1, 1))
            rowTable.Cells.Add(objUtil.CreateCell("T.C.", "Head", "C", 1, 1))
            rowTable.Cells.Add(objUtil.CreateCell("Importe Origen", "Head", "C", 1, 1))
            rowTable.Cells.Add(objUtil.CreateCell("Doc. Relacionado (Tipo/Número)", "Head", "C", 1, 1))

            tblReporte.Rows.Add(rowTable)

            Dim dblSubTotal As Double = 0
            Dim dblIGV As Double = 0
            Dim dblTotal As Double = 0

            For Each dtrItem As Data.DataRow In objResultado.Datos.Rows
                rowTable = New TableRow
                rowTable.Cells.Add(objUtil.CreateCell(Item, "Item", "C", 1, 1))
                rowTable.Cells.Add(objUtil.CreateCell(String.Format("{0:dd/MM/yyyy}", dtrItem("dtm_FechaEmision")), "Item", "C", 1, 1))
                rowTable.Cells.Add(objUtil.CreateCell(String.Format("{0:dd/MM/yyyy}", dtrItem("dtm_FechaVencimiento")), "Item", "C", 1, 1))
                rowTable.Cells.Add(objUtil.CreateCell(dtrItem("var_Tipo"), "Item", "C", 1, 1))
                rowTable.Cells.Add(objUtil.CreateCell(dtrItem("var_CodigoComprobante"), "Item", "C", 1, 1))
                rowTable.Cells.Add(objUtil.CreateCell(dtrItem("var_IdCliente"), "Item", "L", 1, 1))
                rowTable.Cells.Add(objUtil.CreateCell(dtrItem("var_Cliente"), "Item", "L", 1, 1))
                rowTable.Cells.Add(objUtil.CreateCell(dtrItem("var_IdArticulo"), "Item", "L", 1, 1))
                rowTable.Cells.Add(objUtil.CreateCell(dtrItem("var_Articulo"), "Item", "L", 1, 1))
                rowTable.Cells.Add(objUtil.CreateCell(String.Format("{0:0,0}", dtrItem("num_Cantidad")), "Item", "R", 1, 1))
                rowTable.Cells.Add(objUtil.CreateCell(dtrItem("num_CostoUnitario"), "Item", "R", 1, 1))
                rowTable.Cells.Add(objUtil.CreateCell(String.Format("{0:0,0}", dtrItem("num_SubTotal")), "Item", "R", 1, 1))
                rowTable.Cells.Add(objUtil.CreateCell(Math.Round(CDbl(dtrItem("var_IGV")), 0), "Item", "R", 1, 1))
                rowTable.Cells.Add(objUtil.CreateCell(Math.Round(CDbl(dtrItem("num_Total")), 2), "Item", "R", 1, 1))
                rowTable.Cells.Add(objUtil.CreateCell(dtrItem("var_Moneda"), "Item", "C", 1, 1))
                rowTable.Cells.Add(objUtil.CreateCell(dtrItem("num_TipoCambio"), "Item", "R", 1, 1))
                rowTable.Cells.Add(objUtil.CreateCell(dtrItem("num_ImporteOrigen"), "Item", "R", 1, 1))

                If dtrItem("var_Tipo") = "NOTA CREDITO" Then
                    dblSubTotal = dblSubTotal - CDbl(dtrItem("num_SubTotal"))
                    dblTotal = dblTotal - CDbl(dtrItem("num_Total"))
                Else
                    dblSubTotal = dblSubTotal + CDbl(dtrItem("num_SubTotal"))
                    dblIGV = dblIGV + CDbl(dtrItem("var_IGV"))
                    dblTotal = dblTotal + CDbl(dtrItem("num_Total"))
                End If

                objDocumento.IdNota = dtrItem("var_IdNota")
                objDocumento.ComprobantesReporte()
                For Each drtDoc As Data.DataRow In objDocumento.Comprobantes.Rows
                    Dim Comprobante As String = ""

                    Dim IdComprobante As String = ""
                    Dim Separador As String = ""
                    Dim InSeparador As String = ""
                    Separador = "/"
                    IdComprobante = drtDoc("var_IdComprobante")
                    Comprobante = drtDoc("var_TipoComprobante")
                    InSeparador = "-"
                    DocumentoRelacionado = Comprobante + " " + InSeparador + " " + IdComprobante + " " + Separador + " " + DocumentoRelacionado
                Next
                celTable = New TableCell : celTable.Text = DocumentoRelacionado : celTable.Font.Bold = False : celTable.Font.Size = 8 : celTable.Font.Name = "Arial" : rowTable.Cells.Add(celTable)
                tblReporte.Rows.Add(rowTable)
                Item = Item + 1
                DocumentoRelacionado = ""
            Next
            rowTable = New TableRow
            rowTable.Cells.Add(objUtil.CreateCell("Totales", "Foot", "R", 12, 1))
            rowTable.Cells.Add(objUtil.CreateCell(Format(dblSubTotal, "#,##0.00"), "Foot", "R", 1, 1))
            rowTable.Cells.Add(objUtil.CreateCell(Format(dblIGV, "#,##0.00"), "Foot", "R", 1, 1))
            rowTable.Cells.Add(objUtil.CreateCell(Format(dblTotal, "#,##0.00"), "Foot", "R", 1, 1))
            
            tblReporte.Rows.Add(rowTable)

            Session("Titulo") = "Reporte de Ventas"
            Session("Impresion") = stringWrite3.ToString
            tblReporte.RenderControl(htmlWrite3)
            Session("Impresion") = Session("Impresion") & "<br>" & stringWrite3.ToString & "<P align=" & "right" & ">" & "" & "</P>"
            ClientScript.RegisterStartupScript(ClientScript.GetType, "Imprimir", "<script language='javascript'>window.open('../Controles/frmPrint.aspx','Reporte', 'resizable=1, height=800, width=1000, top=0, left=0, scrollbars=1');</script>")
            'ClientScript.RegisterStartupScript(ClientScript.GetType, "Imprimir", "<script language='javascript'>window.open('../Controles/frmPrint.aspx','Reporte', 'resizable=1, height=800, width=1000, top=0, left=0');</script>")
        Else
            ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('No hay datos.');</script>")
        End If
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

        BinReporte()
    End Sub
    Protected Sub rbtTodos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtTodos.CheckedChanged
        rbtInactivo.Checked = False
        rbtActivo.Checked = False
    End Sub
    Protected Sub rbtActivo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtActivo.CheckedChanged
        rbtInactivo.Checked = False
        rbtTodos.Checked = False
    End Sub
    Protected Sub rbtInactivo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtInactivo.CheckedChanged
        rbtActivo.Checked = False
        rbtTodos.Checked = False
    End Sub
End Class
