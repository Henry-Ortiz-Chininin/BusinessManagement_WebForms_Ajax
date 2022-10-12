
Partial Class Controles_ctlImprimir
    Inherits System.Web.UI.UserControl

    Public Sub Imprimir(ByVal pstrContenido As String)
        frmPrint.Attributes.Add("src", "frmPrint.aspx?Contenido=" & pstrContenido)

    End Sub

End Class
