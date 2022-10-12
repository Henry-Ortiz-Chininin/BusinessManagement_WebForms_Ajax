
Partial Class Reportes_FGCREHC
    Inherits System.Web.UI.Page
    Dim strEstado As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            btnDesde.Attributes.Add("onclick", "popUpCalendar(this, " & txtDesde.ClientID & ", 'dd/mm/yyyy');")
            btnHasta.Attributes.Add("onclick", "popUpCalendar(this, " & txtHasta.ClientID & ", 'dd/mm/yyyy');")
            rbtTodos.Checked = True
        End If
    End Sub
    Protected Sub btnGenerar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGenerar.Click
        BinReporte()
    End Sub
    Private Sub BinReporte()
        Dim stringWrite3 As New System.IO.StringWriter
        Dim htmlWrite3 As New System.Web.UI.HtmlTextWriter(stringWrite3)
        Dim objResultado As New ALVI_LOGIC.Proceso.Ventas.VentasReportes
        Dim objSecurity As New ALVI_Security.General

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

        If objResultado.PedidosReporte Then
            rowTable = New TableRow
            celTable = New TableCell
            celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(2, UnitType.Pixel)
            celTable.Font.Bold = True : celTable.Text = "Item" : celTable.Font.Size = 8 : rowTable.Cells.Add(celTable)
            celTable = New TableCell
            celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(2, UnitType.Pixel)
            celTable.Font.Bold = True : celTable.Text = "Fecha Emisión" : celTable.Font.Size = 8 : rowTable.Cells.Add(celTable)
            celTable = New TableCell
            celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(2, UnitType.Pixel)
            celTable.Font.Bold = True : celTable.Text = "Fecha Creación" : celTable.Font.Size = 8 : rowTable.Cells.Add(celTable)
            celTable = New TableCell
            celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(2, UnitType.Pixel)
            celTable.Font.Bold = True : celTable.Text = "Nro Pedido" : celTable.Font.Size = 8 : rowTable.Cells.Add(celTable)
            celTable = New TableCell
            celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(2, UnitType.Pixel)
            celTable.Font.Bold = True : celTable.Text = "Estatus Pedido" : celTable.Font.Size = 8 : rowTable.Cells.Add(celTable)
            celTable = New TableCell
            celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(2, UnitType.Pixel)
            celTable.Font.Bold = True : celTable.Text = "Vendedor" : celTable.Font.Size = 8 : rowTable.Cells.Add(celTable)
            celTable = New TableCell
            celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(2, UnitType.Pixel)
            celTable.Font.Bold = True : celTable.Text = "Cod. Cliente" : celTable.Font.Size = 8 : rowTable.Cells.Add(celTable)
            celTable = New TableCell
            celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(2, UnitType.Pixel)
            celTable.Font.Bold = True : celTable.Text = "Razón social Cliente" : celTable.Font.Size = 8 : rowTable.Cells.Add(celTable)
            celTable = New TableCell
            celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(2, UnitType.Pixel)
            celTable.Font.Bold = True : celTable.Text = "Cod Articulo Crudo" : celTable.Font.Size = 8 : rowTable.Cells.Add(celTable)
            celTable = New TableCell
            celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(2, UnitType.Pixel)
            celTable.Font.Bold = True : celTable.Text = "Des. Articulo Crudo" : celTable.Font.Size = 8 : rowTable.Cells.Add(celTable)
            celTable = New TableCell
            celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(2, UnitType.Pixel)
            celTable.Font.Bold = True : celTable.Text = "Moneda" : celTable.Font.Size = 8 : rowTable.Cells.Add(celTable)
            celTable = New TableCell
            celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(2, UnitType.Pixel)
            celTable.Font.Bold = True : celTable.Text = "Cantidad" : celTable.Font.Size = 8 : rowTable.Cells.Add(celTable)
            celTable = New TableCell
            celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(2, UnitType.Pixel)
            celTable.Font.Bold = True : celTable.Text = "CU" : celTable.Font.Size = 8 : rowTable.Cells.Add(celTable)
            celTable = New TableCell
            celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(2, UnitType.Pixel)
            celTable.Font.Bold = True : celTable.Text = "Subtotal" : celTable.Font.Size = 8 : rowTable.Cells.Add(celTable)
            celTable = New TableCell
            celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(2, UnitType.Pixel)
            celTable.Font.Bold = True : celTable.Text = "IGV %" : celTable.Font.Size = 8 : rowTable.Cells.Add(celTable)
            celTable = New TableCell
            celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(2, UnitType.Pixel)
            celTable.Font.Bold = True : celTable.Text = "Total" : celTable.Font.Size = 8 : rowTable.Cells.Add(celTable)
            celTable = New TableCell
            tblReporte.Rows.Add(rowTable)

            For Each dtrItem As Data.DataRow In objResultado.Datos.Rows
                rowTable = New TableRow
                celTable = New TableCell : celTable.Text = Item : celTable.Font.Bold = False : celTable.Font.Size = 8 : celTable.Font.Name = "Arial" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = String.Format("{0:dd/MM/yyyy}", dtrItem("dtm_FechaEmision")) : celTable.Font.Bold = False : celTable.Font.Size = 8 : celTable.Font.Name = "Arial" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = String.Format("{0:dd/MM/yyyy}", dtrItem("dtm_FechaCreacion")) : celTable.Font.Bold = False : celTable.Font.Size = 8 : celTable.Font.Name = "Arial" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = dtrItem("var_idPedido") : celTable.Font.Bold = False : celTable.Font.Size = 8 : celTable.Font.Name = "Arial" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = dtrItem("var_Estado") : celTable.Font.Bold = False : celTable.Font.Size = 8 : celTable.Font.Name = "Arial" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = dtrItem("var_Vendedor") : celTable.Font.Bold = False : celTable.Font.Size = 8 : celTable.Font.Name = "Arial" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = dtrItem("var_IdCliente") : celTable.Font.Bold = False : celTable.Font.Size = 8 : celTable.Font.Name = "Arial" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = dtrItem("var_Cliente") : celTable.Font.Bold = False : celTable.Font.Size = 8 : celTable.Font.Name = "Arial" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = dtrItem("var_IdArticulo") : celTable.Font.Bold = False : celTable.Font.Size = 8 : celTable.Font.Name = "Arial" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = dtrItem("var_Articulo") : celTable.Font.Bold = False : celTable.Font.Size = 8 : celTable.Font.Name = "Arial" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = dtrItem("var_IdMoneda") : celTable.Font.Bold = False : celTable.Font.Size = 8 : celTable.Font.Name = "Arial" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = String.Format("{0:0,0}", dtrItem("num_Cantidad")) : celTable.Font.Bold = False : celTable.HorizontalAlign = HorizontalAlign.Right : celTable.Font.Size = 8 : celTable.Font.Name = "Arial" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = Math.Round(CDbl(dtrItem("var_SubTotal")) / CDbl(dtrItem("num_Cantidad")), 2) : celTable.Font.Bold = False : celTable.HorizontalAlign = HorizontalAlign.Right : celTable.Font.Size = 8 : celTable.Font.Name = "Arial" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = String.Format("{0:0,0}", dtrItem("var_SubTotal")) : celTable.Font.Bold = True : celTable.HorizontalAlign = HorizontalAlign.Right : celTable.Font.Size = 8 : celTable.Font.Name = "Arial" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = Math.Round(CDbl(dtrItem("var_IGV")), 0) : celTable.Font.Bold = False : celTable.HorizontalAlign = HorizontalAlign.Right : celTable.Font.Size = 8 : celTable.Font.Name = "Arial" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = String.Format("{0:0,0}", dtrItem("var_Total")) : celTable.Font.Bold = True : celTable.HorizontalAlign = HorizontalAlign.Right : celTable.Font.Size = 8 : celTable.Font.Name = "Arial" : rowTable.Cells.Add(celTable)
                tblReporte.Rows.Add(rowTable)
                Item = Item + 1
            Next
            Session("Titulo") = "Reporte de Pedidos"
            Session("Impresion") = stringWrite3.ToString
            tblReporte.RenderControl(htmlWrite3)
            Session("Impresion") = Session("Impresion") & "<br>" & stringWrite3.ToString & "<P align=" & "right" & ">" & "" & "</P>"

            ClientScript.RegisterStartupScript(ClientScript.GetType, "Imprimir", "<script language='javascript'>window.open('../Controles/frmPrint.aspx','Reporte', 'resizable=1, height=800, width=1000, top=0, left=0');</script>")
        Else
            ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('No hay datos.');</script>")
        End If
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