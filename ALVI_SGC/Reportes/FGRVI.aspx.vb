Imports EN_ALVINET_CONTA.GENERAL
Imports LN_ALVINET_CONTA.GENERAL

Partial Class REPORTES_CrystalReport_FGRVI
    Inherits System.Web.UI.Page

    Dim strEmpresa As String = ""
    Dim rpt2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            rpt2 = GenerarReporte()
            strEmpresa = llenarDatos.IdEmpresa
            If rpt2.Rows.Count > 0 Then
                CrystalReportViewer1.ReportSource = rpt2
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Visible = True
            End If
        Else

            rpt2 = GenerarReporte()
            strEmpresa = llenarDatos.IdEmpresa
        End If
    End Sub

    Public Function llenarDatos() As EN_Comprobante

        Dim _objSecurity As New ALVI_Security.General
        Dim _objENComprobante As New EN_ALVINET_CONTA.REPORTE.EN_Comprobante

        If (Request.QueryString("codRP") <> Nothing) Then

            _objENComprobante.IdEmpresa = _objSecurity.Decrypta(Request.QueryString("codRP").ToString())
        End If

        If (Request.QueryString("FI") <> Nothing) Then

            _objENComprobante.Fechainicio = _objSecurity.Decrypta(Request.QueryString("FI").ToString())
        End If

        If (Request.QueryString("FF") <> Nothing) Then

            _objENComprobante.FechaFinal = _objSecurity.Decrypta(Request.QueryString("FF").ToString())
        End If

        Return _objENComprobante

    End Function

    Public Function GenerarReporte() As CrystalDecisions.CrystalReports.Engine.ReportDocument

        Dim _objLNComprobante As New LN_Comprobante

        Dim rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        rpt.Load(Server.MapPath("./") + "rptRegistroVentasIngreso.rpt")

        _objLNComprobante.entComprobante = llenarDatos()
        _objLNComprobante.ReporteRegistroVentasIngreso()

        rpt.SetDataSource(_objLNComprobante.lstComprobantes)
        rpt.Refresh()
        Return rpt
    End Function

    Public Sub exportarReporte(ByVal exp As CrystalDecisions.Shared.ExportFormatType)
        If rpt2.Rows.Count > 0 Then
            rpt2.ExportToHttpResponse(exp, Response, True, strEmpresa)
        End If

    End Sub

    Protected Sub btnExportarReportePDF_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExportarReportePDF.Click
        exportarReporte(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
    End Sub

    Protected Sub lbtSiguiente_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles lbtSiguiente.Click
        If rpt2.Rows.Count > 0 Then
            CrystalReportViewer1.ReportSource = rpt2
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Visible = True
            CrystalReportViewer1.ShowNextPage()
        End If

    End Sub

    Protected Sub lbtInicio_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles lbtInicio.Click
        If rpt2.Rows.Count > 0 Then
            CrystalReportViewer1.ReportSource = rpt2
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Visible = True
            CrystalReportViewer1.ShowFirstPage()
        End If

    End Sub

    Protected Sub lbtAnterior_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles lbtAnterior.Click
        If rpt2.Rows.Count > 0 Then
            CrystalReportViewer1.ReportSource = rpt2
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Visible = True
            CrystalReportViewer1.ShowPreviousPage()
        End If

    End Sub

    Protected Sub lbtUltimo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles lbtUltimo.Click
        If rpt2.Rows.Count > 0 Then
            CrystalReportViewer1.ReportSource = rpt2
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Visible = True
            CrystalReportViewer1.ShowLastPage()
        End If

    End Sub
End Class
