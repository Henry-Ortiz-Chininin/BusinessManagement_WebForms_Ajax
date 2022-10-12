
Partial Class Reportes_FGCFICA
    Inherits System.Web.UI.Page

    Protected Sub btnGenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        ScriptManager.RegisterStartupScript(Me, ClientScript.GetType, "REPORTE", "window.open('FGCRECA.aspx?Mes=" & ddlMes.SelectedValue & "');", True)
    End Sub
End Class
