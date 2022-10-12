Imports System.Data
Imports System.IO
Imports System.Web.UI.WebControls
Partial Class Reportes_FGLREAC
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            btnFechaEmision.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmisionInicio.ClientID & ", 'dd/mm/yyyy');")
            txtFechaEmisionInicio.Text = Format(Now.Date, "dd/MM/yyyy")
            btnFechaEmisionFinal.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmisionFinal.ClientID & ", 'dd/mm/yyyy');")
            txtFechaEmisionFinal.Text = Format(Now.Date, "dd/MM/yyyy")

        End If
    End Sub


    Protected Sub btnGenerar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGenerar.Click

        Dim objvale As New ALVI_LOGIC.Maestros.Logistica.Vale

        objvale.Buscar1(txtCodigo.Text, _
                             ctlSolicitante_Buscar1.IdSolicitante, _
                             txtFechaEmisionInicio.Text, _
                             txtFechaEmisionFinal.Text, _
                              ctlElementoReferencial_Buscar1.idArticulo, _
                              ctlCentroCosto_Buscar1.IdCentroCosto
                              )

        If objvale.Datos.Rows.Count > 0 Then

            Dim stringWrite As New StringWriter()
            Dim htmlWrite As New HtmlTextWriter(stringWrite)


            Dim tblResumen As New Table
            Dim tblDatos As New Table


            BindDatos(tblDatos)
            Session("Datos") = stringWrite.ToString
            tblDatos.RenderControl(htmlWrite)

            BindResumen(tblResumen)
            Session("Titulo") = "REPORTE DE SEGUIMIENTO DE VALES DE PEDIDO A ALMACEN"
            tblResumen.RenderControl(htmlWrite)


            Session("Impresion") = stringWrite.ToString

            ClientScript.RegisterStartupScript(ClientScript.GetType, "Imprimir", "<script language='javascript'>window.open('../Controles/frmPrint.aspx','Reporte', 'resizable=1,height=600,width=1000,top=0,left=0,scrollbars=1');</script>")



        End If

    End Sub

    Private Sub BindDatos(tblDatos As Table)
        Dim stringWrite As New StringWriter()
        Dim htmlWrite As New HtmlTextWriter(stringWrite)

        Dim rowItem As TableRow


        rowItem = New TableRow
        rowItem.Cells.Add(CreateCelll("Codigo:", "Item", "L", 2, 1))
        rowItem.Cells.Add(CreateCelll(txtCodigo.Text, "Item", "C", 2, 1))
        rowItem.Cells.Add(CreateCelll("        ", "Item", "L", 8, 1))
        rowItem.Cells.Add(CreateCelll("Solicitante", "Item", "L", 2, 1))
        rowItem.Cells.Add(CreateCelll(ctlSolicitante_Buscar1.Nombre, "Item", "C", 4, 1))
        tblDatos.Rows.Add(rowItem)

        rowItem = New TableRow
        rowItem.Cells.Add(CreateCelll("Fecha Emision:", "Item", "L", 4, 1))
        rowItem.Cells.Add(CreateCelll(txtFechaEmisionInicio.Text, "Item", "C", 3, 1))
        rowItem.Cells.Add(CreateCelll("al:", "Item", "C", 1, 1))
        rowItem.Cells.Add(CreateCelll(txtFechaEmisionFinal.Text, "Item", "C", 3, 1))
        rowItem.Cells.Add(CreateCelll("", "Item", "L", 2, 1))
        rowItem.Cells.Add(CreateCelll("CC Destino:", "Item", "L", 2, 1))
        rowItem.Cells.Add(CreateCelll(ctlCentroCosto_Buscar1.Descripcion, "Item", "C", 4, 1))
        tblDatos.Rows.Add(rowItem)

        rowItem = New TableRow
        rowItem.Cells.Add(CreateCelll("Articulo:", "Item", "L", 4, 1))
        rowItem.Cells.Add(CreateCelll(ctlElementoReferencial_Buscar1.Nombre, "Item", "C", 3, 1))
        rowItem.Cells.Add(CreateCelll("", "Item", "C", 1, 1))
        rowItem.Cells.Add(CreateCelll("Estado:", "Item", "L", 2, 1))
        'rowItem.Cells.Add(CreateCelll(, "Item", "C", 4, 1))
        tblDatos.Rows.Add(rowItem)




    End Sub

    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExportar.Click
        Dim stringWrite As New System.IO.StringWriter
        Dim htmlWrite As New System.Web.UI.HtmlTextWriter(stringWrite)
        Dim tblExcel As New Table
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment;filename=REPORTE DE SEGUIMIENTO DE VALES DE PEDIDO A ALMACEN_" & Format(Now, "yyyyMMdd_HHmm") & ".xls")
        Response.ContentEncoding = Encoding.Default
        BindReporte(tblExcel)
        tblExcel.RenderControl(htmlWrite)
        Response.Write(stringWrite.ToString)
        Response.End()

    End Sub
    Private Sub BindReporte(ByRef tblDatos As Table)

        Dim rowTable As TableRow
        Dim objUtilitario As New Utilitarios


        'FECHA EMISION 
        If txtFechaEmisionInicio.Text = "" Then
            rowTable = New TableRow
            rowTable.Cells.Add(objUtilitario.CreateCell("Fecha Emision Inicio: " & ".. / .. / ....", "Item", "L", 5, 1))

            tblDatos.Rows.Add(rowTable)
        Else
            rowTable = New TableRow
            rowTable.Cells.Add(objUtilitario.CreateCell("Fecha Emision Inicio: " & txtFechaEmisionInicio.Text, "Item", "L", 5, 1))

            tblDatos.Rows.Add(rowTable)
        End If


        If txtFechaEmisionFinal.Text = "" Then
            rowTable = New TableRow
            rowTable.Cells.Add(objUtilitario.CreateCell("Fecha Emision Final: " & ".. / .. / ....", "Item", "L", 5, 1))
            tblDatos.Rows.Add(rowTable)
        Else
            rowTable = New TableRow
            rowTable.Cells.Add(objUtilitario.CreateCell("Fecha Emision Final: " & txtFechaEmisionFinal.Text, "Item", "L", 5, 1))
            tblDatos.Rows.Add(rowTable)
        End If


        

        If ctlSolicitante_Buscar1.Nombre = "" Then
            rowTable = New TableRow
            rowTable.Cells.Add(objUtilitario.CreateCell("Solicitante: " & " ", "Item", "L", 5, 1))
            tblDatos.Rows.Add(rowTable)

        Else
            rowTable = New TableRow
            rowTable.Cells.Add(objUtilitario.CreateCell("Solicitante: " & ctlSolicitante_Buscar1.Nombre, "Item", "L", 5, 1))
            tblDatos.Rows.Add(rowTable)
        End If



        If ctlElementoReferencial_Buscar1.Nombre = "" Then
            rowTable = New TableRow
            rowTable.Cells.Add(objUtilitario.CreateCell("Articulo: " & " ", "Item", "L", 5, 1))
            tblDatos.Rows.Add(rowTable)

        Else
            rowTable = New TableRow
            rowTable.Cells.Add(objUtilitario.CreateCell("Articulo: " & ctlElementoReferencial_Buscar1.Nombre, "Item", "L", 5, 1))
            tblDatos.Rows.Add(rowTable)
        End If



        If ctlCentroCosto_Buscar1.Descripcion = "" Then
            rowTable = New TableRow
            rowTable.Cells.Add(objUtilitario.CreateCell("CC Destino: " & " ", "Item", "L", 5, 1))
            tblDatos.Rows.Add(rowTable)

        Else
            rowTable = New TableRow
            rowTable.Cells.Add(objUtilitario.CreateCell("CC Destino: " & ctlCentroCosto_Buscar1.Descripcion, "Item", "L", 5, 1))
            tblDatos.Rows.Add(rowTable)
        End If



        Dim objvale As New ALVI_LOGIC.Maestros.Logistica.Vale

        objvale.Buscar1(txtCodigo.Text, _
                             ctlSolicitante_Buscar1.IdSolicitante, _
                             txtFechaEmisionInicio.Text, _
                             txtFechaEmisionFinal.Text, _
                              ctlElementoReferencial_Buscar1.idArticulo, _
                              ctlCentroCosto_Buscar1.IdCentroCosto)
        Session("datos") = objvale.Datos

        rowTable = New TableRow
        rowTable.Cells.Add(objUtilitario.CreateCell("Codigo", "Head", "C", 1, 1))
        rowTable.Cells.Add(objUtilitario.CreateCell("Solicitante", "Head", "C", 1, 1))
        rowTable.Cells.Add(objUtilitario.CreateCell("Cargo", "Head", "C", 1, 1))
        rowTable.Cells.Add(objUtilitario.CreateCell("Area/Proceso", "", "C", 1, 1))
        rowTable.Cells.Add(objUtilitario.CreateCell("F. Emision", "Head", "C", 1, 1))
        rowTable.Cells.Add(objUtilitario.CreateCell("CC Destino", "Head", "C", 1, 1))
        rowTable.Cells.Add(objUtilitario.CreateCell("Articulo", "Head", "C", 1, 1))
        rowTable.Cells.Add(objUtilitario.CreateCell("Cantidad", "Head", "C", 1, 1))
        'rowTable.Cells.Add(objUtilitario.CreateCell("Estado", "Head", "C", 1, 1))

        tblDatos.Rows.Add(rowTable)

        Dim cont As Integer = 0
        Dim datos As New System.Data.DataTable
        Dim dato As New DataSet

        datos = Session("datos")
        For Each dtrItem As Data.DataRow In datos.Rows
            cont += 1
            rowTable = New TableRow

            rowTable.Cells.Add(CreateCell(dtrItem("var_IdValeAlmacen"), "Item", "C", 1, 1, 1))
            rowTable.Cells.Add(CreateCell(dtrItem("var_Solicitante"), "Item", "C", 1, 1, 1))
            rowTable.Cells.Add(CreateCell(dtrItem("cargo"), "Item", "C", 1, 1, 1))
            rowTable.Cells.Add(CreateCell(dtrItem("CentroCosto"), "Item", "C", 1, 1, 1))
            rowTable.Cells.Add(CreateCell(dtrItem("dtm_Fecha"), "Item", "C", 1, 1, 1))

            rowTable.Cells.Add(CreateCell(dtrItem("Area"), "Item", "C", 1, 1, 1))
            rowTable.Cells.Add(CreateCell(dtrItem("Articulo"), "Item", "C", 1, 1, 1))
            rowTable.Cells.Add(CreateCell(dtrItem("Cantidad"), "Item", "C", 1, 1, 1))


            tblDatos.Rows.Add(rowTable)
            tblDatos.ID = "tablaBorde"

        Next
        rowTable = New TableRow
        rowTable.Cells.Add(objUtilitario.CreateCell("TOTAL REGITROS : ", "Foot", "L", 8, 1))

        rowTable.Cells.Add(objUtilitario.CreateCell(cont, "Foot", "C", 1, 1))
        tblDatos.Rows.Add(rowTable)


    End Sub


    Private Sub BindResumen(ByRef tblDatos As Table)

      
            Dim objRequisicion As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Requisicion

            Dim stringWrite As New StringWriter()
            Dim htmlWrite As New HtmlTextWriter(stringWrite)

            Dim dtbResumen = CType(Session("dtbResumen"), Data.DataTable)

            Dim objResumen As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Requisicion



            '*********************************************************
            'INICIO: CABECERA
            '*********************************************************

            Dim rowItem As TableRow
            rowItem = New TableRow
            rowItem.Cells.Add(CreateCelll("Codigo", "Head", "C", 1, 1))
            rowItem.Cells.Add(CreateCelll("Solicitante", "Head", "C", 1, 1))
            rowItem.Cells.Add(CreateCelll("Cargo", "Head", "C", 1, 1))
            rowItem.Cells.Add(CreateCelll("Area/Proceso", "Head", "C", 1, 1))
            rowItem.Cells.Add(CreateCelll("F. Emision", "Head", "C", 1, 1))
            rowItem.Cells.Add(CreateCelll("CC Destino", "Head", "C", 1, 1))
            rowItem.Cells.Add(CreateCelll("Articulo", "Head", "C", 1, 1))
            rowItem.Cells.Add(CreateCelll("Cantidad", "Head", "C", 1, 1))

            tblDatos.Rows.Add(rowItem)


            Dim strCodigo As String = ""
            Dim strSolicitante As String = ""
            Dim strCargo As String = ""
            Dim strArea As String = ""
            Dim strEmision As String = ""
            Dim strDestino As String = ""
            Dim strArticulo As String = ""
            Dim intCantidad As Integer = 0



            Dim objvale As New ALVI_LOGIC.Maestros.Logistica.Vale

            objvale.Buscar1(txtCodigo.Text, _
                                 ctlSolicitante_Buscar1.IdSolicitante, _
                                 txtFechaEmisionInicio.Text, _
                                 txtFechaEmisionFinal.Text, _
                                  ctlElementoReferencial_Buscar1.idArticulo, _
                                  ctlCentroCosto_Buscar1.IdCentroCosto
                                  )



            For Each dtrResumen As Data.DataRow In objvale.Datos.Rows

                strCodigo = dtrResumen("var_IdValeAlmacen")
                strSolicitante = dtrResumen("var_Solicitante")
                strCargo = dtrResumen("cargo")
                strDestino = dtrResumen("CentroCosto")
                strEmision = dtrResumen("dtm_Fecha")
                strArea = dtrResumen("Area")
                strArticulo = dtrResumen("Articulo")
                intCantidad = dtrResumen("Cantidad")

                rowItem = New TableRow

                rowItem.Cells.Add(CreateCelll(strCodigo, "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(strSolicitante, "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(strCargo, "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(strArea, "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(strEmision, "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(strDestino, "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(strArticulo, "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(intCantidad, "Item", "C", 1, 1))


                tblDatos.Rows.Add(rowItem)
                tblDatos.Width = 1500

            Next

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




    Private Function CreateCell(ByVal strTexto As String, ByVal strTipo As String, _
                                ByVal strAlign As String, ByVal intCols As Int16, ByVal intRows As Int16, ByVal intAncho As Int16) As TableCell
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
            Case "A"
                celItem.HorizontalAlign = HorizontalAlign.Center
                celItem.Width = intAncho
        End Select
        Return celItem
    End Function

    

  



End Class
