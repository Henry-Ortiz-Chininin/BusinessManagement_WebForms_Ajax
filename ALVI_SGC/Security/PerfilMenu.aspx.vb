Imports ALVI_Security

Partial Class PerfilMenu
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Session("Usuario") = "ADMIN"
            Me.hdnIDPerfil.Value = Request("IDPerfil")
            BindNivelMenu(ddlNivel1, 0, 0)
            BindGrid()
        End If
    End Sub

    Private Sub BindGrid()
        Dim objPerfil As New clsPerfilMenu(hdnIDPerfil.Value)
        grdPerfil.DataSource = objPerfil.Datos
        grdPerfil.DataBind()
    End Sub

    Private Sub BindNivelMenu(ByRef ddlNivel As DropDownList, ByVal pint_IdNivel As Int16, ByVal pint_IdPadre As Int16)
        Dim objPerfilMenu As New clsPerfilMenu()
        ddlNivel.DataSource = objPerfilMenu.ObtenerxNivel(pint_IdNivel, pint_IdPadre)
        ddlNivel.DataTextField = "var_TituloMenu"
        ddlNivel.DataValueField = "int_IDMenu"
        ddlNivel.DataBind()
        Dim ddlItem As New ListItem("Seleccionar", 0)
        ddlNivel.Items.Insert(0, ddlItem)
        ddlNivel.SelectedIndex = 0
    End Sub

    Protected Sub grdPerfil_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdPerfil.RowCommand
        If e.CommandName = "Agregar" Then
            Dim objPerfil As New clsPerfilMenu
            Dim ddlNivel0 As DropDownList = CType(grdPerfil.FooterRow.FindControl("ddlNivel0"), DropDownList)
            Dim ddlNivel1 As DropDownList = CType(grdPerfil.FooterRow.FindControl("ddlNivel1"), DropDownList)
            Dim ddlNivel2 As DropDownList = CType(grdPerfil.FooterRow.FindControl("ddlNivel2"), DropDownList)

            If ddlNivel0.SelectedValue <> 0 Then
                objPerfil.IDPerfil = Me.hdnIDPerfil.Value
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
            Dim objPerfilMenu As New clsPerfilMenu
            objPerfilMenu.IDMenu = CType(e.CommandArgument, String)
            objPerfilMenu.IDPerfil = hdnIDPerfil.Value
            objPerfilMenu.Eliminar()

            BindGrid()
        End If
    End Sub

    Protected Sub grdPerfil_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdPerfil.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btnEliminar As ImageButton = CType(e.Row.FindControl("btnElimina"), ImageButton)
            btnEliminar.CommandArgument = e.Row.RowIndex
        End If
    End Sub

    Protected Sub ddlNivel1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlNivel1.SelectedIndexChanged
        BindNivelMenu(ddlNivel2, 1, ddlNivel1.SelectedValue)

    End Sub

    Protected Sub ddlNivel2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlNivel2.SelectedIndexChanged
        BindNivelMenu(ddlNivel3, 2, ddlNivel2.SelectedValue)
    End Sub

    Protected Sub ddlNivel3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlNivel3.SelectedIndexChanged
        BindNivelMenu(ddlNivel4, 3, ddlNivel3.SelectedValue)
    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        Dim objPerfil As New clsPerfilMenu
        
        
        objPerfil.IDPerfil = hdnIDPerfil.Value
        objPerfil.Usuario = Session("Usuario")

        If ddlNivel4.Items.Count > 0 AndAlso ddlNivel4.SelectedValue > 0 Then
            objPerfil.IDMenu = ddlNivel1.SelectedValue
            objPerfil.Agregar()

            objPerfil.IDMenu = ddlNivel2.SelectedValue
            objPerfil.Agregar()

            objPerfil.IDMenu = ddlNivel3.SelectedValue
            objPerfil.Agregar()

            objPerfil.IDMenu = ddlNivel4.SelectedValue
            objPerfil.Agregar()

        ElseIf ddlNivel3.Items.Count > 0 AndAlso ddlNivel3.SelectedValue > 0 Then
            objPerfil.IDMenu = ddlNivel1.SelectedValue
            objPerfil.Agregar()

            objPerfil.IDMenu = ddlNivel2.SelectedValue
            objPerfil.Agregar()

            objPerfil.IDMenu = ddlNivel3.SelectedValue
            objPerfil.Agregar()

        ElseIf ddlNivel2.Items.Count > 0 AndAlso ddlNivel2.SelectedValue > 0 Then
            objPerfil.IDMenu = ddlNivel2.SelectedValue
            objPerfil.IDMenu = ddlNivel1.SelectedValue
            objPerfil.Agregar()

            objPerfil.IDMenu = ddlNivel2.SelectedValue
            objPerfil.Agregar()

        ElseIf ddlNivel1.Items.Count > 0 AndAlso ddlNivel1.SelectedValue > 0 Then
            objPerfil.IDMenu = ddlNivel1.SelectedValue
            objPerfil.Agregar()

        End If

        BindGrid()

    End Sub
End Class
