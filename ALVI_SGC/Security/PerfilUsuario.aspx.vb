Imports ALVI_Security

Partial Class PerfilUsuario
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Me.hdnIDPerfil.Value = Request("IDPerfil")
            BindGrid()
        End If
    End Sub

    Private Sub BindGrid()
        Dim objPerfil As New clsPerfilUsuario(hdnIDPerfil.Value)
        grdPerfil.DataSource = objPerfil.Datos
        grdPerfil.DataBind()
    End Sub

    Protected Sub grdUsuarios_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdPerfil.RowCommand
        If e.CommandName = "Agregar" Then
            Dim objPerfil As New clsPerfilUsuario
            objPerfil.IDPerfil = Me.hdnIDPerfil.Value
            objPerfil.IDUsuario = CType(grdPerfil.FooterRow.FindControl("txtIDUsuarioF"), TextBox).Text
            objPerfil.Usuario = Session("Usuario")
            If objPerfil.Agregar = True Then
                lblMensaje.Text = "Usuario registrado"
            Else
                lblMensaje.Text = "No se registro"
            End If
            BindGrid()
        ElseIf e.CommandName = "Eliminar" Then
            Dim objPerfil As New clsPerfilUsuario
            objPerfil.IDUsuario = CType(e.CommandArgument, String)
            objPerfil.IDPerfil = Me.hdnIDPerfil.Value
            If objPerfil.Eliminar() = True Then
                lblMensaje.Text = "Perfil actualizado"
            Else
                lblMensaje.Text = "No se actualizo"
            End If
            BindGrid()
        End If
    End Sub

End Class
