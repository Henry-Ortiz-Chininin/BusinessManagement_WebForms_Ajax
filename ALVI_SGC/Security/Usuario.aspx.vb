Imports System.Data
Imports ALVI_Security

Partial Class Usuario
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindGrid()
        End If
    End Sub

    Private Sub BindGrid()
        Dim objUsuario As New clsUsuario
        objUsuario.Listar()

        grdUsuarios.DataSource = New Data.DataView(objUsuario.Datos, "var_IdUsuario LIKE'" & txtUsuario.Text & "%' AND var_Nombre LIKE '%" & txtNombre.Text & "%'", "var_IdUsuario", DataViewRowState.OriginalRows)


        grdUsuarios.DataBind()
    End Sub

    Protected Sub grdUsuarios_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdUsuarios.RowCommand
        If e.CommandName = "Agregar" Then
            Dim objUsuario As New clsUsuario
            objUsuario.IDUsuario = CType(grdUsuarios.FooterRow.FindControl("txtLoginF"), TextBox).Text
            objUsuario.Nombre = CType(grdUsuarios.FooterRow.FindControl("txtNombreF"), TextBox).Text
            objUsuario.Clave = CType(grdUsuarios.FooterRow.FindControl("txtClaveF"), TextBox).Text
            objUsuario.Estado = CType(grdUsuarios.FooterRow.FindControl("ddlEstado"), DropDownList).SelectedValue
            If objUsuario.Agregar = True Then
                lblMensaje.Text = "Usuario registrado"
            Else
                lblMensaje.Text = "No se registro"
            End If
            BindGrid()
        ElseIf e.CommandName = "Eliminar" Then
            Dim objUsuario As New clsUsuario
            objUsuario.IDUsuario = CType(e.CommandArgument, String)
            If objUsuario.CambiarEstado("INA") = True Then
                lblMensaje.Text = "Usuario actualizado"
            Else
                lblMensaje.Text = "No se actualizo el usuario"
            End If
            BindGrid()
        ElseIf e.CommandName = "Restaurar" Then
            Dim objUsuario As New clsUsuario
            objUsuario.IDUsuario = CType(e.CommandArgument, String)
            If objUsuario.CambiarEstado("ACT") = True Then
                lblMensaje.Text = "Usuario actualizado"
            Else
                lblMensaje.Text = "No se actualizo"
            End If
            BindGrid()

        ElseIf e.CommandName = "Menu" Then
            Dim strURL As String = "UsuarioMenu.ASPX"
            strURL = strURL & "?IdSeccion=" & Master.IdSeccion
            strURL = strURL & "&IdMenu=" & Master.IdMenu
            strURL = strURL & "&IdSubMenu=" & Master.IdSubMenu
            strURL = strURL & "&IdUsuario=" & CType(e.CommandArgument, String)
            Response.Redirect(strURL)
        ElseIf e.CommandName = "Actualizar" Then
            Dim objUsuario As New clsUsuario
            objUsuario.IDUsuario = CType(grdUsuarios.Rows(grdUsuarios.EditIndex).FindControl("lblLoginE"), Label).Text
            objUsuario.Nombre = CType(grdUsuarios.Rows(grdUsuarios.EditIndex).FindControl("txtNombreE"), TextBox).Text
            objUsuario.Clave = CType(grdUsuarios.Rows(grdUsuarios.EditIndex).FindControl("txtClaveE"), TextBox).Text
            If objUsuario.Actualizar = True Then
                lblMensaje.Text = "Usuario modificado"
            Else
                lblMensaje.Text = "No se modifico"
            End If
            grdUsuarios.ShowFooter = True
            grdUsuarios.EditIndex = -1
            BindGrid()
        End If
    End Sub

    Protected Sub grdUsuarios_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdUsuarios.RowDataBound
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

    Protected Sub grdUsuarios_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdUsuarios.RowEditing
        grdUsuarios.EditIndex = e.NewEditIndex
        grdUsuarios.ShowFooter = False
        BindGrid()
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        BindGrid()


    End Sub
End Class
