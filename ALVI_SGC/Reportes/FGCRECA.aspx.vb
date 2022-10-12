Imports EN_ALVINET_CONTA.REPORTE
Imports LN_ALVINET_CONTA.REPORTE

Partial Class Reportes_FGCRECA
    Inherits System.Web.UI.Page

    Dim rpt2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument()


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            rpt2 = GenerarReporte()

            If rpt2.Rows.Count > 0 Then
                CrystalReportViewer1.ReportSource = rpt2
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Visible = True
            End If
        Else
            rpt2 = GenerarReporte()
        End If
    End Sub

    Private Function GenerarReporte() As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim _objLNLibroDiario As New LN_Reportes

        Dim rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        rpt.Load(Server.MapPath("./") + "LibroDiario_5_1.rpt")


        rpt.SetDataSource(_objLNLibroDiario.LibroDiario51(Session("Empresa"), _
                                                          Session("EjercicioEmpresa"), _
                                                          Session("Contabilidad"), _
                                                          Request("Mes")))

        
        rpt.Refresh()

        Return rpt
    End Function

    Public Sub exportarReporte(ByVal exp As CrystalDecisions.Shared.ExportFormatType)
        If rpt2.Rows.Count > 0 Then
            rpt2.ExportToHttpResponse(exp, Response, True, "LibroDiario")
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
