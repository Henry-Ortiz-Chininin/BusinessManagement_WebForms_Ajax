
Partial Class Controles_frmPrint
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Page.Title = Session("Titulo").ToString()
            lblTitulo.Text = Session("Titulo").ToString()
            If Not Session("Datos") Is Nothing Then
                lblDatos.Text = Session("Datos").ToString()
            End If
            Contenido.Text = Session("Impresion").ToString()
        End If
    End Sub
End Class
