
Partial Class Controles_ctlCerrar
    Inherits System.Web.UI.UserControl

    Private _strDestino As String
    Public Property Destino() As String
        Get
            Return _strDestino
        End Get
        Set(ByVal value As String)
            _strDestino = value
        End Set
    End Property

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        If _strDestino = "" Then
            _strDestino = "../Security/Default.aspx"
        End If
        Response.Redirect(_strDestino, True)
    End Sub
End Class
