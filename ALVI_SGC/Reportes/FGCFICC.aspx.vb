
Partial Class Reportes_FGCFICC
    Inherits System.Web.UI.Page

    Protected Sub btnGenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        ScriptManager.RegisterStartupScript(Me, ClientScript.GetType, "REPORTE", "window.open('FGCRECC.aspx?anno=" & ddlAnno.SelectedValue & "&mes=" & ddlMes.SelectedValue & "');", True)
    End Sub
End Class
