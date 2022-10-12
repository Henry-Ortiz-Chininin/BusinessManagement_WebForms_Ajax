
Imports System
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.UI.WebControls
Imports System.Data.Common
Imports System.Globalization
Partial Class Reportes_FGLREAB
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            btnFechaEmisionInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmisionInicio.ClientID & ", 'dd/mm/yyyy');")
            'txtFechaEmisionInicio.Text = Format(Now.Date, "dd/MM/yyyy")
            btnFechaEmisionFinal.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmisionFinal.ClientID & ", 'dd/mm/yyyy');")
            'txtFechaEmisionFinal.Text = Format(Now.Date, "dd/MM/yyyy")

            btnFechaVencimientoInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaVencimientoInicio.ClientID & ", 'dd/mm/yyyy');")
            'txtFechaVencimientoInicio.Text = Format(Now.Date, "dd/MM/yyyy")

            btnFechaVencimientoFinal.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaVencimientoFinal.ClientID & ", 'dd/mm/yyyy');")

            'txtFechaVencimientoFinal.Text = Format(Now.Date, "dd/MM/yyyy")


        End If
    End Sub


    Protected Sub btnGenerar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGenerar.Click
        Dim objDocumento As New ALVI_LOGIC.Proceso.Logistica.Documento
        objDocumento.Buscar(txtNumeroDumento.Text, _
                         txtFechaEmisionInicio.Text, _
                         txtFechaEmisionFinal.Text, _
                          txtFechaVencimientoInicio.Text, _
                         txtFechaVencimientoFinal.Text, _
                         ctlProveedor_Buscar1.IdProveedor
                        )

        If objDocumento.Datos.Rows.Count > 0 Then

            Dim stringWrite As New StringWriter()
            Dim htmlWrite As New HtmlTextWriter(stringWrite)


            Dim tblResumen As New Table
            Dim tblDatos As New Table


            Session("Titulo") = "Seguimiento de Vales: "
            BindDatos(tblDatos)
            tblDatos.RenderControl(htmlWrite)
            Session("Datos") = stringWrite.ToString

            BindReporte(tblResumen)
            tblResumen.RenderControl(htmlWrite)
            Session("Impresion") = stringWrite.ToString

            ClientScript.RegisterStartupScript(ClientScript.GetType, "Imprimir", "<script language='javascript'>window.open('../Controles/frmPrint.aspx','Reporte', 'resizable=1,height=600,width=1000,top=0,left=0,scrollbars=1');</script>")

        End If

    End Sub

    Private Sub cargar()
        Dim objDocumento As New ALVI_LOGIC.Proceso.Logistica.Documento
        objDocumento.Buscar(txtNumeroDumento.Text, _
                         txtFechaEmisionInicio.Text, _
                         txtFechaEmisionFinal.Text, _
                          txtFechaVencimientoInicio.Text, _
                         txtFechaVencimientoFinal.Text, _
                         ctlProveedor_Buscar1.IdProveedor
                        )

        Session("datos") = objDocumento.Datos

    End Sub



    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExportar.Click
        Dim stringWrite As New System.IO.StringWriter
        Dim htmlWrite As New System.Web.UI.HtmlTextWriter(stringWrite)
        Dim tblExcel As New Table
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment;filename=ReporteCompra_" & Format(Now, "yyyyMMdd_HHmm") & ".xls")
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


        'FECHA VENCIMIENTO
        If txtFechaVencimientoInicio.Text = "" Then
            rowTable = New TableRow
            rowTable.Cells.Add(objUtilitario.CreateCell("Fecha Vencimiento Inicio: " & ".. / .. / ....", "Item", "L", 5, 1))

            tblDatos.Rows.Add(rowTable)
        Else
            rowTable = New TableRow
            rowTable.Cells.Add(objUtilitario.CreateCell("Fecha Vencimiento Inicio: " & txtFechaVencimientoInicio.Text, "Item", "L", 5, 1))

            tblDatos.Rows.Add(rowTable)
        End If


        If txtFechaVencimientoFinal.Text = "" Then
            rowTable = New TableRow
            rowTable.Cells.Add(objUtilitario.CreateCell("Fecha Vencimiento Final: " & ".. / .. / ....", "Item", "L", 5, 1))
            tblDatos.Rows.Add(rowTable)
        Else
            rowTable = New TableRow
            rowTable.Cells.Add(objUtilitario.CreateCell("Fecha Vencimiento Final: " & txtFechaVencimientoFinal.Text, "Item", "L", 5, 1))
            tblDatos.Rows.Add(rowTable)
        End If

        If ctlProveedor_Buscar1.RazonSocial = "" Then
            rowTable = New TableRow
            rowTable.Cells.Add(objUtilitario.CreateCell("Razon Social: " & " ", "Item", "L", 5, 1))
            tblDatos.Rows.Add(rowTable)

        Else
            rowTable = New TableRow
            rowTable.Cells.Add(objUtilitario.CreateCell("Razon Social: " & ctlProveedor_Buscar1.RazonSocial, "Item", "L", 5, 1))
            tblDatos.Rows.Add(rowTable)
        End If
        Dim objDocumento As New ALVI_LOGIC.Proceso.Logistica.Documento
        objDocumento.Buscar(txtNumeroDumento.Text, _
                         txtFechaEmisionInicio.Text, _
                         txtFechaEmisionFinal.Text, _
                          txtFechaVencimientoInicio.Text, _
                         txtFechaVencimientoFinal.Text, _
                         ctlProveedor_Buscar1.IdProveedor
                        )

        Session("datos") = objDocumento.Datos

        rowTable = New TableRow
        rowTable.Cells.Add(objUtilitario.CreateCell("ID", "Head", "C", 1, 1))
        rowTable.Cells.Add(objUtilitario.CreateCell("Documento", "Head", "C", 1, 1))
        rowTable.Cells.Add(objUtilitario.CreateCell("Numero", "Head", "C", 1, 1))
        rowTable.Cells.Add(objUtilitario.CreateCell("Proveedor", "", "C", 1, 1))
        rowTable.Cells.Add(objUtilitario.CreateCell("Emision", "Head", "C", 1, 1))
        rowTable.Cells.Add(objUtilitario.CreateCell("RUC", "Head", "C", 1, 1))
        rowTable.Cells.Add(objUtilitario.CreateCell("Vencimiento", "Head", "C", 1, 1))
        'rowTable.Cells.Add(objUtilitario.CreateCell("Pago", "Head", "C", 1, 1))
        'rowTable.Cells.Add(objUtilitario.CreateCell("Estado", "Head", "C", 1, 1))

        tblDatos.Rows.Add(rowTable)

        Dim cont As Integer = 0
        Dim datos As New System.Data.DataTable
        Dim dato As New DataSet

        datos = Session("datos")
        For Each dtrItem As Data.DataRow In datos.Rows
            cont += 1
            rowTable = New TableRow

            rowTable.Cells.Add(CreateCell(dtrItem("var_IdDocumentoCompra"), "Item", "C", 1, 1, 1))
            rowTable.Cells.Add(CreateCell(dtrItem("Documento"), "Item", "C", 1, 1, 1))
            rowTable.Cells.Add(CreateCell(dtrItem("var_NumeroDocumento"), "Item", "C", 1, 1, 1))
            rowTable.Cells.Add(CreateCell(dtrItem("var_IdProveedor"), "Item", "C", 1, 1, 1))
            rowTable.Cells.Add(CreateCell(dtrItem("dtm_Fecha"), "Item", "C", 1, 1, 1))
            rowTable.Cells.Add(CreateCell(dtrItem("RazonSocial"), "Item", "C", 1, 1, 1))

            rowTable.Cells.Add(CreateCell(dtrItem("dtm_FechaVencimiento"), "Item", "C", 1, 1, 1))

            tblDatos.Rows.Add(rowTable)
            tblDatos.ID = "tablaBorde"

        Next
        rowTable = New TableRow
        rowTable.Cells.Add(objUtilitario.CreateCell("TOTAL REGITROS : ", "Foot", "L", 8, 1))

        rowTable.Cells.Add(objUtilitario.CreateCell(cont, "Foot", "C", 1, 1))
        tblDatos.Rows.Add(rowTable)


    End Sub

    Private Sub BindDatos(tblDatos As Table)
        Dim stringWrite As New StringWriter()
        Dim htmlWrite As New HtmlTextWriter(stringWrite)

        Dim rowItem As TableRow


        rowItem = New TableRow
        rowItem.Cells.Add(CreateCelll("Nro Documento:", "Item", "L", 2, 1))
        rowItem.Cells.Add(CreateCelll(txtNumeroDumento.Text, "Item", "C", 2, 1))
        rowItem.Cells.Add(CreateCelll("        ", "Item", "L", 8, 1))
        rowItem.Cells.Add(CreateCelll("Razon Social:", "Item", "L", 2, 1))
        rowItem.Cells.Add(CreateCelll(ctlProveedor_Buscar1.RazonSocial, "Item", "C", 4, 1))
        tblDatos.Rows.Add(rowItem)

        rowItem = New TableRow
        rowItem.Cells.Add(CreateCelll("Fecha Emision:", "Item", "L", 4, 1))
        rowItem.Cells.Add(CreateCelll(txtFechaEmisionInicio.Text, "Item", "C", 3, 1))
        rowItem.Cells.Add(CreateCelll("al:", "Item", "C", 1, 1))
        rowItem.Cells.Add(CreateCelll(txtFechaEmisionFinal.Text, "Item", "C", 3, 1))
        rowItem.Cells.Add(CreateCelll("", "Item", "L", 2, 1))
        rowItem.Cells.Add(CreateCelll("Ruc:", "Item", "L", 2, 1))
        rowItem.Cells.Add(CreateCelll(ctlProveedor_Buscar1.IdProveedor, "Item", "C", 4, 1))
        tblDatos.Rows.Add(rowItem)

        rowItem = New TableRow
        rowItem.Cells.Add(CreateCelll("Fecha vencimiento:", "Item", "L", 4, 1))
        rowItem.Cells.Add(CreateCelll(txtFechaVencimientoInicio.Text, "Item", "C", 3, 1))
        rowItem.Cells.Add(CreateCelll("al:", "Item", "C", 1, 1))
        rowItem.Cells.Add(CreateCelll(txtFechaVencimientoFinal.Text, "Item", "C", 3, 1))
        rowItem.Cells.Add(CreateCelll("", "Item", "L", 2, 1))
        'rowItem.Cells.Add(CreateCelll("Estado", "Item", "L", 2, 1))
        'rowItem.Cells.Add(CreateCelll(ctlProyecto_Buscar1.Nombre, "Item", "C", 4, 1))
        rowItem.Cells.Add(CreateCelll("Impresion:", "Item", "L", 2, 1))
        tblDatos.Rows.Add(rowItem)


    End Sub

    Private Sub BindResumen(ByRef tblDatos As Table)
        If (txtNumeroDumento.Text <> "") Then
            Dim objDocumento As New ALVI_LOGIC.Proceso.Logistica.Documento


            Dim stringWrite As New StringWriter()
            Dim htmlWrite As New HtmlTextWriter(stringWrite)

            Dim dtbResumen = CType(Session("dtbResumen"), Data.DataTable)

            Dim objResumen As New ALVI_LOGIC.Maestros.Logistica.Compra



            '*********************************************************
            'INICIO: CABECERA
            '*********************************************************

            Dim rowItem As TableRow
            rowItem = New TableRow
            rowItem.Cells.Add(CreateCelll("Id", "Head", "C", 1, 1))
            rowItem.Cells.Add(CreateCelll("Documento", "Head", "C", 1, 1))
            rowItem.Cells.Add(CreateCelll("Numero", "Head", "C", 1, 1))
            rowItem.Cells.Add(CreateCelll("Proveedor", "Head", "C", 1, 1))
            rowItem.Cells.Add(CreateCelll("Emision", "Head", "C", 1, 1))
            rowItem.Cells.Add(CreateCelll("RUC", "Head", "C", 1, 1))
            rowItem.Cells.Add(CreateCelll("Vencimiento", "Head", "C", 1, 1))
            rowItem.Cells.Add(CreateCelll("Pago", "Head", "C", 1, 1))
            rowItem.Cells.Add(CreateCelll("Estado", "Head", "C", 1, 1))
            tblDatos.Rows.Add(rowItem)


            Dim strCodigo As String = ""
            Dim strDocumento As String = ""
            Dim strNumero As String = ""
            Dim strProveedor As String = ""
            Dim strRUC As String = ""
            Dim strEmision As String = ""
            Dim strVencimiento As String = ""
            Dim strPago As String = ""
            Dim strEstado As String = ""



            objDocumento.Buscar(txtNumeroDumento.Text, _
                             txtFechaEmisionInicio.Text, _
                             txtFechaEmisionFinal.Text, _
                              txtFechaVencimientoInicio.Text, _
                             txtFechaVencimientoFinal.Text, _
                             ctlProveedor_Buscar1.IdProveedor
                            )


            For Each dtrResumen As Data.DataRow In objDocumento.Datos.Rows

                strCodigo = dtrResumen("var_IdDocumentoCompra")
                strDocumento = dtrResumen("Documento")
                strNumero = dtrResumen("var_NumeroDocumento")
                strProveedor = dtrResumen("var_IdProveedor")
                strRUC = dtrResumen("RazonSocial")
                strEmision = dtrResumen("dtm_Fecha")
                strVencimiento = dtrResumen("dtm_FechaVencimiento")

                rowItem = New TableRow


                rowItem.Cells.Add(CreateCelll(strCodigo, "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(strDocumento, "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(strNumero, "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(strProveedor, "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(strEmision, "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(strRUC, "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(strEmision, "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(strVencimiento, "Item", "C", 1, 1))


                tblDatos.Rows.Add(rowItem)
                tblDatos.Width = 1500




            Next



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
