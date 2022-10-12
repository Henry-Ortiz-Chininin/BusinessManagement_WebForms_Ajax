
Partial Class Reportes_FGCFICB
    Inherits System.Web.UI.Page

    Protected Sub btnGenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        ScriptManager.RegisterStartupScript(Me, ClientScript.GetType, "REPORTE", "window.open('FGCRECB.aspx?Inicio=" & txtFechaInicio.Text & "&Final=" & txtFechaFinal.Text & "');", True)
    End Sub
End Class
