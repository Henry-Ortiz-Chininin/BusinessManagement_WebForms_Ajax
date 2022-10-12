
Partial Class Operacion_FGCOPCB
    Inherits System.Web.UI.Page

    Protected Sub btnGenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim objEmpresa As New LN_ALVINET_CONTA.GENERAL.LN_Empresa

        If chkCompras.Checked Then
            objEmpresa.CerrarCompras(ddlAnno.SelectedValue, ddlMes.SelectedValue)
            ClientScript.RegisterStartupScript(ClientScript.GetType, "mensaje", "<script> alert('Cierre completado'); </script>")

        End If
        If chkVentas.Checked Then
            objEmpresa.CerrarVentas(ddlAnno.SelectedValue, ddlMes.SelectedValue)
            ClientScript.RegisterStartupScript(ClientScript.GetType, "mensaje", "<script> alert('Cierre completado'); </script>")

        End If
    End Sub
End Class
