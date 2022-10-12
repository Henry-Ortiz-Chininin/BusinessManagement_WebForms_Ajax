
Partial Class Reportes_FGCFICE
    Inherits System.Web.UI.Page

    Protected Sub btnGenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim strURL As String = "FGCRECE.aspx?FechaInicio=" & txtFechaInicio.Text & _
            "&FechaFinal=" & txtFechaFinal.Text & "&IdCliente=" & ctlCliente.IdCliente & _
            "&Tipo=" & ddlTipo.SelectedValue & "&Estado=" & ddlEstado.SelectedValue


        ScriptManager.RegisterStartupScript(Me, ClientScript.GetType, "REPORTE", "window.open('" & strURL & "');", True)
    End Sub
End Class
