Imports EN_ALVINET_CONTA.REPORTE
Imports LN_ALVINET_CONTA.REPORTE

Partial Class Reportes_FGCRECE
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
        Dim objDatos As New LN_ALVINET_CONTA.OPERACION.LN_OrdenServicio

        Dim rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        rpt.Load(Server.MapPath("./") + "OrdenServicio_F1.rpt")

        objDatos.entDato.IdOrdenServicio = ""
        objDatos.entDato.IdCliente = Request("IdCliente")
        objDatos.entDato.FechaInicio = Request("FechaInicio")
        objDatos.entDato.FechaFinal = Request("FechaFinal")
        objDatos.entDato.TipoServicio = Request("Tipo")
        objDatos.entDato.Estado = Request("Estado")

        objDatos.Buscar()

        rpt.SetDataSource(objDatos.lstDatos)

        rpt.Refresh()

        Return rpt
    End Function

    Public Sub exportarReporte(ByVal exp As CrystalDecisions.Shared.ExportFormatType)
        If rpt2.Rows.Count > 0 Then
            rpt2.ExportToHttpResponse(exp, Response, True, "Registro_Orden_Servicio")
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
