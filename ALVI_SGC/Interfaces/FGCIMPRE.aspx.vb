Imports Utilitarios
Imports ALVI_LOGIC
Imports CrystalDecisions.CrystalReports.Engine
Imports ALVI_LOGIC.Maestros.Ventas
Partial Class Interfaces_FGCIMPRE
    Inherits System.Web.UI.Page
    Private objUtility As New Utility

#Region "PARAMETROS"
    Private _bolValidar As Boolean
    Private _objComprobante As Factura
    Private rpt As New ReportDocument
    Public Sub DatosComprobante(ByVal pdtbDatos As Data.DataTable)
        'Dim pdtbDatos As New Data.DataTable

        pdtbDatos.Columns.Add("var_IdComprobante", GetType(String))
        pdtbDatos.Columns.Add("int_Secuencia", GetType(Integer))
        pdtbDatos.Columns.Add("var_IdFactura", GetType(String))
        pdtbDatos.Columns.Add("var_Correlativo", GetType(String))
        pdtbDatos.Columns.Add("var_Ruc", GetType(String))
        pdtbDatos.Columns.Add("var_Cliente", GetType(String))
        pdtbDatos.Columns.Add("var_Direccion", GetType(String))
        pdtbDatos.Columns.Add("var_GuiaRemision", GetType(String))
        pdtbDatos.Columns.Add("dtm_FechaEmision", GetType(String))
        pdtbDatos.Columns.Add("num_Cantidad", GetType(Decimal))
        pdtbDatos.Columns.Add("var_IdArticulo", GetType(String))
        pdtbDatos.Columns.Add("var_Articulo", GetType(String))
        pdtbDatos.Columns.Add("var_Moneda", GetType(String))
        pdtbDatos.Columns.Add("num_PrecioUnitario", GetType(Decimal))
        pdtbDatos.Columns.Add("num_Importe", GetType(Decimal))
        pdtbDatos.Columns.Add("num_Igv", GetType(Decimal))
        pdtbDatos.Columns.Add("num_SubTotal", GetType(Decimal))
        pdtbDatos.Columns.Add("num_Total", GetType(Decimal))
        pdtbDatos.Columns.Add("num_Desc", GetType(Decimal))
        pdtbDatos.Columns.Add("num_TotalParcial", GetType(Decimal))
        pdtbDatos.Columns.Add("var_TipoPago", GetType(String))
        pdtbDatos.Columns.Add("var_Son", GetType(String))
        pdtbDatos.Columns.Add("var_Cancelado", GetType(String))
        pdtbDatos.Columns.Add("int_Dia", GetType(String))
        pdtbDatos.Columns.Add("int_Mes", GetType(String))
        pdtbDatos.Columns.Add("intAnio", GetType(String))
        pdtbDatos.Columns.Add("var_Estado", GetType(String))
        pdtbDatos.Columns.Add("var_codMoneda", GetType(String))

        'Dim pkDetalle(1) As Data.DataColumn
        'pkDetalle(0) = pdtbDatos.Columns("int_Secuencia")
        'pdtbDatos.PrimaryKey = pkDetalle
    End Sub
#End Region
#Region "PROPIEDADES"
    Public Property ValidarDatos() As Boolean
        Get
            Return _bolValidar
        End Get
        Set(ByVal value As Boolean)
            _bolValidar = value
        End Set
    End Property

    Public Property objComprobante() As ALVI_LOGIC.Maestros.Ventas.Factura
        Get
            Return _objComprobante
        End Get
        Set(ByVal value As ALVI_LOGIC.Maestros.Ventas.Factura)
            _objComprobante = value
        End Set
    End Property

    Protected Property Report() As ReportDocument
        Get
            Return rpt
        End Get
        Set(ByVal value As ReportDocument)
            rpt = value
        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ValidarDatos = False
            Dim strAction As String = ""
            Dim strMensaje As String = ""

            If Request.QueryString("Repor") <> Nothing Then
                Dim objSeguridad As New ALVI_Security.General
                If "CO" = objSeguridad.Decrypta(Request.QueryString("Repor")) Then
                    _objComprobante = New Factura
                    _objComprobante.NumeroDocumento = objSeguridad.Decrypta(Request.QueryString("CO"))
                    strAction = objSeguridad.Decrypta(Request.QueryString("Act"))
                    rptComprobante(_objComprobante)
                    Enable_Obj(ValidarDatos)
                    If ValidarDatos = True Then
                        If strAction = "IMPR" Then
                            Imprimir(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
                        ElseIf strAction = "EXPO" Then
                            ExportarReporte(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
                        End If
                    Else
                        txtMensaje.Text = objComprobante.exError.Message
                        btnCerrar.Attributes.Add("onClick", "window.top.close();")
                        'ClientScript.RegisterStartupScript(ClientScript.GetType, "CONFIRMACION", "<script language='javascript'>alert('" + strMensaje + "');</script>")
                    End If
                End If
            End If

        End If
    End Sub

    Public Sub Enable_Obj(ByVal _pbolValor As Boolean)
        If _bolValidar Then
            lbtAnterior.Visible = True
            lbtInicio.Visible = True
            lbtUltimo.Visible = True
            lbtSiguiente.Visible = True
            btnExportarReportePDF.Visible = True
            btnImprimirReporte.Visible = True
            txtMensaje.Visible = False
        Else
            lbtAnterior.Visible = False
            lbtInicio.Visible = False
            lbtUltimo.Visible = False
            lbtSiguiente.Visible = False
            btnExportarReportePDF.Visible = False
            btnImprimirReporte.Visible = False
            txtMensaje.Visible = True
        End If
    End Sub

    Public Sub Validar(ByVal prptReporte As CrystalDecisions.CrystalReports.Engine.ReportDocument)
        If _bolValidar = True Then
            If prptReporte.Rows.Count > 0 Then
                CrystalReportViewer1.ReportSource = prptReporte
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Visible = True
                Enable_Obj(True)
            Else
                Enable_Obj(False)
            End If
        Else
            Enable_Obj(False)
        End If
    End Sub

    Public Function rptComprobante(ByVal pobjComprobante As Factura) As Boolean
        _objComprobante = New Factura
        Dim objUtil As New Utility
        Dim dtbDatos As New Data.DataTable
        ValidarDatos = True
        rpt.Load(Server.MapPath("~\\Interfaces\\reportes\\rptComprobante.rpt"))
        rpt.Refresh()

        _objComprobante = pobjComprobante
        If _objComprobante.Impresion Then
            DatosComprobante(dtbDatos)
            For Each dtrItem As Data.DataRow In objComprobante.Datos.Rows
                dtrItem("var_Son") = objUtil.NombreNumero(Convert.ToDouble(dtrItem("num_Total")), dtrItem("var_codMoneda"))
                dtbDatos.Rows.Add(dtrItem.ItemArray)
                dtbDatos.AcceptChanges()
            Next
            rpt.SetDataSource(dtbDatos)
        Else
            ValidarDatos = False
        End If
        Return ValidarDatos
    End Function

    Public Sub ExportarReporte(ByVal exp As CrystalDecisions.Shared.ExportFormatType)
        Dim objSeguridad As New ALVI_Security.General
        If "CO" = objSeguridad.Decrypta(Request.QueryString("Repor")) Then
            _objComprobante = New Factura
            _objComprobante.NumeroDocumento = objSeguridad.Decrypta(Request.QueryString("CO"))
            If rptComprobante(_objComprobante) = False Then
                Exit Sub
            End If
        End If

        If rpt.Rows.Count > 0 Then
            If "CO" = objSeguridad.Decrypta(Request.QueryString("Repor")) Then
                rpt.ExportToHttpResponse(exp, Response, True, "CO_" & _objComprobante.IdComprobante)
                rpt.PrintToPrinter(1, True, exp, "Comprobante")
            End If
        End If
    End Sub

    Public Sub Imprimir(ByVal exp As CrystalDecisions.Shared.ExportFormatType)
        Dim objSeguridad As New ALVI_Security.General
        If "CO" = objSeguridad.Decrypta(Request.QueryString("Repor")) Then
            Dim objComprobante As New ALVI_LOGIC.Maestros.Ventas.Factura
            objComprobante.NumeroDocumento = objSeguridad.Decrypta(Request.QueryString("CO"))
            If rptComprobante(objComprobante) = False Then
                Exit Sub
            End If
        End If
        If rpt.Rows.Count > 0 Then
            If "CO" = objSeguridad.Decrypta(Request.QueryString("Repor")) Then
                rpt.PrintToPrinter(1, True, 0, 0)
            End If
        End If
    End Sub

    Public Sub Siguiente()
        Dim objSeguridad As New ALVI_Security.General
        If "CO" = objSeguridad.Decrypta(Request.QueryString("Repor")) Then
            Dim objComprobante As New ALVI_LOGIC.Maestros.Ventas.Factura
            objComprobante.NumeroDocumento = objSeguridad.Decrypta(Request.QueryString("CO"))
            If rptComprobante(objComprobante) = False Then
                Exit Sub
            End If
        End If
        If rpt.Rows.Count > 0 Then

            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.RefreshReport()

            CrystalReportViewer1.Visible = True
            CrystalReportViewer1.ShowNextPage()
        End If
    End Sub

    Public Sub Inicio()
        Dim objSeguridad As New ALVI_Security.General
        If "CO" = objSeguridad.Decrypta(Request.QueryString("Repor")) Then
            Dim objComprobante As New ALVI_LOGIC.Maestros.Ventas.Factura
            objComprobante.NumeroDocumento = objSeguridad.Decrypta(Request.QueryString("CO"))
            If rptComprobante(objComprobante) = False Then
                Exit Sub
            End If
        End If

        If rpt.Rows.Count > 0 Then

            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.RefreshReport()

            CrystalReportViewer1.Visible = True
            CrystalReportViewer1.ShowFirstPage()
        End If

    End Sub

    Public Sub Anterior()
        Dim objSeguridad As New ALVI_Security.General
        If "CO" = objSeguridad.Decrypta(Request.QueryString("Repor")) Then
            Dim objComprobante As New ALVI_LOGIC.Maestros.Ventas.Factura
            objComprobante.NumeroDocumento = objSeguridad.Decrypta(Request.QueryString("CO"))
            If rptComprobante(objComprobante) = False Then
                Exit Sub
            End If
        End If
        If rpt.Rows.Count > 0 Then

            CrystalReportViewer1.ReportSource = rpt

            CrystalReportViewer1.RefreshReport()

            CrystalReportViewer1.Visible = True
            CrystalReportViewer1.ShowPreviousPage()
        End If

    End Sub

    Public Sub Ultimo()
        Dim objSeguridad As New ALVI_Security.General
        If "CO" = objSeguridad.Decrypta(Request.QueryString("Repor")) Then
            Dim objComprobante As New ALVI_LOGIC.Maestros.Ventas.Factura
            objComprobante.NumeroDocumento = objSeguridad.Decrypta(Request.QueryString("CO"))
            If rptComprobante(objComprobante) = False Then
                Exit Sub
            End If
        End If

        If rpt.Rows.Count > 0 Then

            CrystalReportViewer1.ReportSource = rpt

            CrystalReportViewer1.RefreshReport()

            CrystalReportViewer1.Visible = True
            CrystalReportViewer1.ShowLastPage()
        End If
    End Sub

    Protected Sub btnExportarReportePDF_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnExportarReportePDF.Click
        ExportarReporte(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
    End Sub

    Protected Sub lbtSiguiente_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles lbtSiguiente.Click
        Siguiente()
    End Sub

    Protected Sub lbtInicio_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles lbtInicio.Click
        Inicio()
    End Sub

    Protected Sub lbtAnterior_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles lbtAnterior.Click
        Anterior()
    End Sub

    Protected Sub lbtUltimo_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles lbtUltimo.Click
        Ultimo()
    End Sub

    Protected Sub btnImprimirReporte_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnImprimirReporte.Click
        Imprimir(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
    End Sub
End Class
