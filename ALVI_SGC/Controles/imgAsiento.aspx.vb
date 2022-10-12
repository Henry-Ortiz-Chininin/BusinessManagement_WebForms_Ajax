
Partial Class Controles_imgAsiento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim objGeneral As New Utilitarios

            
            Response.ContentType = "image/gif"
            Dim objImagen As Drawing.Bitmap = objGeneral.BuildAvance(CInt(Request("Proc")), Request("Titulo"), Request("Por"))
            objImagen.Save(Response.OutputStream, Drawing.Imaging.ImageFormat.Jpeg)

        End If
    End Sub
End Class
