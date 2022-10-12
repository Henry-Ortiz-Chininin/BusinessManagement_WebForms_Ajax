Imports ALVI_Security

Partial Class Security_login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtLogin.Focus()
        End If
    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            Dim objConexion As New clsUsuario

            If objConexion.Obtener(Me.txtLogin.Text, txtClave.Text) = True Then
                Session("Usuario") = objConexion.IDUsuario
                Response.Redirect("Default.aspx", True)
            Else
                Session("Usuario") = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
        
    End Sub

    Protected Sub txtClave_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClave.TextChanged
        Try
            Dim objConexion As New clsUsuario

            If objConexion.Obtener(Me.txtLogin.Text, txtClave.Text) = True Then
                Session("Usuario") = objConexion.IDUsuario
                Response.Redirect("Default.aspx", True)
            Else
                Session("Usuario") = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
