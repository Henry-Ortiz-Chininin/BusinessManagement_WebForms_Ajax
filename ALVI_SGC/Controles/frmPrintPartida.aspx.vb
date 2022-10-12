
Partial Class Controles_frmPrintPartida
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Page.Title = Session("Titulo")
            lblTitulo.Text = Session("Titulo")
            lblDatos.Text = Session("Datos")

            Contenido.Text = Session("Impresion")
        End If
    End Sub
End Class
