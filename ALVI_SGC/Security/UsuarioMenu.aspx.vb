Imports ALVI_Security

Partial Class UsuarioMenu
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Session("Usuario") = "ADMIN"
            Me.hdnIdUsuario.Value = Request("IdUsuario")
            BindGrid()
        End If
    End Sub

    Private Sub BindGrid()
        Dim objPerfil As New clsUsuarioMenu
        objPerfil.Obtener(hdnIdUsuario.Value)
        grdPerfil.DataSource = objPerfil.Datos
        grdPerfil.DataBind()
    End Sub

    Protected Sub grdPerfil_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdPerfil.RowCommand
        If e.CommandName = "Agregar" Then
            Dim objPerfil As New clsUsuarioMenu
            Dim ddlNivel0 As DropDownList = CType(grdPerfil.FooterRow.FindControl("ddlNivel0"), DropDownList)
            Dim ddlNivel1 As DropDownList = CType(grdPerfil.FooterRow.FindControl("ddlNivel1"), DropDownList)
            Dim ddlNivel2 As DropDownList = CType(grdPerfil.FooterRow.FindControl("ddlNivel2"), DropDownList)

            If ddlNivel0.SelectedValue <> 0 Then
                objPerfil.IdUsuario = Me.hdnIdUsuario.Value
                objPerfil.Usuario = Session("Usuario")
                objPerfil.IDMenu = ddlNivel0.SelectedValue
                If objPerfil.Agregar = True Then
                    If ddlNivel1.SelectedValue <> 0 Then
                        objPerfil.IDMenu = ddlNivel1.SelectedValue
                        If objPerfil.Agregar = True Then
                            If ddlNivel2.SelectedValue <> 0 Then
                                objPerfil.IDMenu = ddlNivel2.SelectedValue
                                If objPerfil.Agregar = True Then
                                    lblMensaje.Text = "Opcion registrada"
                                Else
                                    lblMensaje.Text = "No se registro"
                                End If
                            Else
                                lblMensaje.Text = "Opcion registrada"
                            End If
                        Else
                            lblMensaje.Text = "No se registro"
                        End If
                    Else
                        lblMensaje.Text = "Opcion registrada"
                    End If
                Else
                    lblMensaje.Text = "No se registro"
                End If
            End If

            BindGrid()
        ElseIf e.CommandName = "Eliminar" Then
            Dim objPerfilMenu As New clsUsuarioMenu
            objPerfilMenu.IDMenu = CType(e.CommandArgument, String)
            objPerfilMenu.IdUsuario = hdnIdUsuario.Value
            objPerfilMenu.Eliminar()

            BindGrid()
        End If
    End Sub

    Protected Sub grdPerfil_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdPerfil.RowDataBound
        If e.Row.RowType = DataControlRowType.Footer Then
            Dim ddlNivel0 As DropDownList = CType(e.Row.FindControl("ddlNivel0"), DropDownList)
            Dim objPerfilMenu As New clsUsuarioMenu()
            ddlNivel0.DataSource = objPerfilMenu.ObtenerxNivel(0, 0)
            ddlNivel0.DataTextField = "var_TituloMenu"
            ddlNivel0.DataValueField = "int_IDMenu"
            ddlNivel0.DataBind()
            Dim ddlItem As New ListItem("Seleccionar", 0)
            ddlNivel0.Items.Insert(0, ddlItem)
            ddlNivel0.SelectedIndex = 0
        ElseIf e.Row.RowType = DataControlRowType.DataRow Then
            Dim btnEliminar As ImageButton = CType(e.Row.FindControl("btnElimina"), ImageButton)
            btnEliminar.CommandArgument = e.Row.RowIndex
        End If
    End Sub

    Protected Sub ddlNivel0_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlNivel As DropDownList = CType(sender, DropDownList)
        Dim ddlNivel1 As DropDownList = CType(CType(ddlNivel.Parent.Parent, GridViewRow).FindControl("ddlNivel1"), DropDownList)
        Dim objPerfilMenu As New clsUsuarioMenu()
        ddlNivel1.DataSource = objPerfilMenu.ObtenerxNivel(1, ddlNivel.SelectedValue)
        ddlNivel1.DataTextField = "var_TituloMenu"
        ddlNivel1.DataValueField = "int_IDMenu"
        ddlNivel1.DataBind()
        Dim ddlItem As New ListItem("Seleccionar", 0)
        ddlNivel1.Items.Insert(0, ddlItem)
        ddlNivel1.SelectedIndex = 0
    End Sub

    Protected Sub ddlNivel1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlNivel As DropDownList = CType(sender, DropDownList)
        Dim ddlNivel2 As DropDownList = CType(CType(ddlNivel.Parent.Parent, GridViewRow).FindControl("ddlNivel2"), DropDownList)
        Dim objPerfilMenu As New clsUsuarioMenu()
        ddlNivel2.DataSource = objPerfilMenu.ObtenerxNivel(2, ddlNivel.SelectedValue)
        ddlNivel2.DataTextField = "var_TituloMenu"
        ddlNivel2.DataValueField = "int_IDMenu"
        ddlNivel2.DataBind()
        Dim ddlItem As New ListItem("Seleccionar", 0)
        ddlNivel2.Items.Insert(0, ddlItem)
        ddlNivel2.SelectedIndex = 0
    End Sub
End Class
