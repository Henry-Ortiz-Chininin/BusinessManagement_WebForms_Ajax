Imports ALVI_Security

Partial Class Perfil
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim IDUsuario As String = Request("ID")

            BindGrid()
        End If
    End Sub

    Private Sub BindGrid()
        Dim objPerfil As New clsPerfil
        grdPerfil.DataSource = objPerfil.Listar
        grdPerfil.DataBind()
    End Sub

    Protected Sub grdUsuarios_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdPerfil.RowCommand
        If e.CommandName = "Agregar" Then
            Dim objPerfil As New clsPerfil
            objPerfil.Nombre = CType(grdPerfil.FooterRow.FindControl("txtNombreF"), TextBox).Text
            objPerfil.Usuario = Session("Usuario")
            If objPerfil.Agregar = True Then
                lblMensaje.Text = "Usuario registrado"
            Else
                lblMensaje.Text = "No se registro"
            End If
            BindGrid()
        ElseIf e.CommandName = "Eliminar" Then
            Dim objPerfil As New clsPerfil
            objPerfil.IDPerfil = CType(e.CommandArgument, String)
            objPerfil.Usuario = Session("Usuario")
            If objPerfil.CambiarEstado("INA") = True Then
                lblMensaje.Text = "Perfil actualizado"
            Else
                lblMensaje.Text = "No se actualizo"
            End If
            BindGrid()
        ElseIf e.CommandName = "Restaurar" Then
            Dim objPerfil As New clsPerfil
            objPerfil.IDPerfil = CType(e.CommandArgument, String)
            objPerfil.Usuario = Session("Usuario")
            If objPerfil.CambiarEstado("ACT") = True Then
                lblMensaje.Text = "Usuario actualizado"
            Else
                lblMensaje.Text = "No se actualizo"
            End If
            BindGrid()
        ElseIf e.CommandName = "Usuarios" Then
            Dim strURL As String = "PerfilUsuario.ASPX"
            strURL = strURL & "?IdSeccion=" & Master.IdSeccion
            strURL = strURL & "&IdMenu=" & Master.IdMenu
            strURL = strURL & "&IdSubMenu=" & Master.IdSubMenu
            strURL = strURL & "&IDPerfil=" & CType(e.CommandArgument, Int16)
            Response.Redirect(strURL)

        ElseIf e.CommandName = "Menu" Then
            Dim strURL As String = "PerfilMenu.ASPX"
            strURL = strURL & "?IdSeccion=" & Master.IdSeccion
            strURL = strURL & "&IdMenu=" & Master.IdMenu
            strURL = strURL & "&IdSubMenu=" & Master.IdSubMenu
            strURL = strURL & "&IDPerfil=" & CType(e.CommandArgument, Int16)
            Response.Redirect(strURL)

        ElseIf e.CommandName = "Especial" Then
            Dim objSeguridad As New ALVI_Security.General
            Dim strURL As String = "FGCSEAC.ASPX"
            strURL = strURL & "?IdSeccion=" & Master.IdSeccion
            strURL = strURL & "&IdMenu=" & Master.IdMenu
            strURL = strURL & "&IdSubMenu=" & Master.IdSubMenu
            strURL = strURL & "&IdGrupo=" & objSeguridad.Encrypta(e.CommandArgument)

            Response.Redirect(strURL)
        ElseIf e.CommandName = "Actualizar" Then
            Dim objPerfil As New clsPerfil
            objPerfil.IDPerfil = CType(grdPerfil.Rows(grdPerfil.EditIndex).FindControl("lblIDPerfilE"), Label).Text
            objPerfil.Nombre = CType(grdPerfil.Rows(grdPerfil.EditIndex).FindControl("txtNombreE"), TextBox).Text
            objPerfil.Usuario = Session("Usuario")
            If objPerfil.Actualizar = True Then
                lblMensaje.Text = "Usuario modificado"
            Else
                lblMensaje.Text = "No se modifico"
            End If
            grdPerfil.ShowFooter = True
            grdPerfil.EditIndex = -1
            BindGrid()

        End If
    End Sub

    Protected Sub grdUsuarios_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdPerfil.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim drvItem As Data.DataRowView = CType(e.Row.DataItem, Data.DataRowView)
            If drvItem("chr_Estado") = "ACT" Then
                Dim btnElimina As ImageButton = CType(e.Row.FindControl("btnElimina"), ImageButton)
                Dim btnRestaurar As ImageButton = CType(e.Row.FindControl("btnRestaurar"), ImageButton)
                btnElimina.Visible = True
                btnRestaurar.Visible = False
            ElseIf drvItem("chr_Estado") = "INA" Then
                Dim btnElimina As ImageButton = CType(e.Row.FindControl("btnElimina"), ImageButton)
                Dim btnRestaurar As ImageButton = CType(e.Row.FindControl("btnRestaurar"), ImageButton)
                btnElimina.Visible = False
                btnRestaurar.Visible = True
            End If


        End If
    End Sub

    Protected Sub grdUsuarios_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdPerfil.RowEditing
        grdPerfil.EditIndex = e.NewEditIndex
        grdPerfil.ShowFooter = False
        BindGrid()
    End Sub

End Class
