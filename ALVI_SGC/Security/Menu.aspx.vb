Imports ALVI_Security

Partial Class Menu
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim IDUsuario As String = Request("ID")
            BindNivelMenu(ddlBuscar1, 0, 0)
            pnlFormulario.Visible = False
            BindGrid()
        End If
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

    Private Sub BindGrid()
        Dim objMenu As New clsMenu
        If ddlBuscar3.Items.Count > 0 AndAlso ddlBuscar3.SelectedValue > 0 Then
            grdMenu.DataSource = objMenu.Obtener(ddlBuscar3.SelectedValue)
        ElseIf ddlBuscar2.Items.Count > 0 AndAlso ddlBuscar2.SelectedValue > 0 Then
            grdMenu.DataSource = objMenu.Obtener(ddlBuscar2.SelectedValue)
        ElseIf ddlBuscar1.Items.Count > 0 AndAlso ddlBuscar1.SelectedValue >= 0 Then
            grdMenu.DataSource = objMenu.Obtener(ddlBuscar1.SelectedValue)
        End If
        grdMenu.EditIndex = -1
        grdMenu.DataBind()
    End Sub

    Protected Sub grdUsuarios_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdMenu.RowCommand
        If e.CommandName = "Eliminar" Then
            Dim objMenu As New clsMenu
            objMenu.IDMenu = CType(e.CommandArgument, String)
            objMenu.Usuario = Session("Usuario")
            If objMenu.CambiarEstado("INA") = True Then
                lblMensaje.Text = "Perfil actualizado"
            Else
                lblMensaje.Text = "No se actualizo"
            End If
            BindGrid()
        ElseIf e.CommandName = "Restaurar" Then
            Dim objMenu As New clsMenu
            objMenu.IDMenu = CType(e.CommandArgument, String)
            objMenu.Usuario = Session("Usuario")
            If objMenu.CambiarEstado("ACT") = True Then
                lblMensaje.Text = "Usuario actualizado"
            Else
                lblMensaje.Text = "No se actualizo"
            End If
            BindGrid()

        End If
    End Sub

    Protected Sub grdUsuarios_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdMenu.RowDataBound
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

    Protected Sub grdUsuarios_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdMenu.RowEditing
        pnlFormulario.Visible = True
        
        txtCodigo.Text = grdMenu.Rows(e.NewEditIndex).Cells(0).Text
        txtRuta.Text = grdMenu.Rows(e.NewEditIndex).Cells(3).Text
        txtTitulo.Text = HttpUtility.HtmlDecode(grdMenu.Rows(e.NewEditIndex).Cells(2).Text)
        lblEstado.Text = grdMenu.Rows(e.NewEditIndex).Cells(6).Text
        lblNivel.Text = grdMenu.Rows(e.NewEditIndex).Cells(5).Text
        If CBool(grdMenu.Rows(e.NewEditIndex).Cells(4).Text) Then
            ddlContenedor.SelectedValue = "1"
        Else
            ddlContenedor.SelectedValue = "0"
        End If

        Dim strNivel() As String = {"0", "0", "0", "0"}
        Dim objMenu As New ALVI_Security.clsMenu
        Dim dtbMenu As Data.DataTable = objMenu.Listar()
        If lblNivel.Text = 4 Then
            For Each dtrItem1 As Data.DataRow In dtbMenu.Select("int_IDMenu='" & txtCodigo.Text & "'")
                strNivel(3) = dtrItem1("int_IdMenuPadre")
                For Each dtrItem2 As Data.DataRow In dtbMenu.Select("int_IDMenu='" & dtrItem1("int_IdMenuPadre") & "'")
                    strNivel(2) = dtrItem2("int_IdMenuPadre")
                    For Each dtrItem3 As Data.DataRow In dtbMenu.Select("int_IDMenu='" & dtrItem2("int_IdMenuPadre") & "'")
                        strNivel(1) = dtrItem3("int_IdMenuPadre")
                        For Each dtrItem4 As Data.DataRow In dtbMenu.Select("int_IDMenu='" & dtrItem3("int_IdMenuPadre") & "'")
                            strNivel(0) = dtrItem4("int_IdMenuPadre")
                        Next
                    Next
                Next

            Next
        ElseIf lblNivel.Text = 3 Then
            For Each dtrItem1 As Data.DataRow In dtbMenu.Select("int_IDMenu='" & txtCodigo.Text & "'")
                strNivel(2) = dtrItem1("int_IdMenuPadre")
                For Each dtrItem2 As Data.DataRow In dtbMenu.Select("int_IDMenu='" & dtrItem1("int_IdMenuPadre") & "'")
                    strNivel(1) = dtrItem2("int_IdMenuPadre")
                    For Each dtrItem3 As Data.DataRow In dtbMenu.Select("int_IDMenu='" & dtrItem2("int_IdMenuPadre") & "'")
                        strNivel(0) = dtrItem3("int_IdMenuPadre")
                    Next
                Next
            Next
        ElseIf lblNivel.Text = 2 Then
            For Each dtrItem1 As Data.DataRow In dtbMenu.Select("int_IDMenu='" & txtCodigo.Text & "'")
                strNivel(1) = dtrItem1("int_IdMenuPadre")
                For Each dtrItem2 As Data.DataRow In dtbMenu.Select("int_IDMenu='" & dtrItem1("int_IdMenuPadre") & "'")
                    strNivel(0) = dtrItem2("int_IdMenuPadre")
                Next
            Next
        ElseIf lblNivel.Text = 1 Then
            For Each dtrItem1 As Data.DataRow In dtbMenu.Select("int_IDMenu='" & txtCodigo.Text & "'")
                strNivel(0) = dtrItem1("int_IdMenuPadre")
            Next
        End If

        BindNivelMenu(ddlNivel1, 0, 0)
        ddlNivel1.SelectedValue = strNivel(0)

        BindNivelMenu(ddlNivel2, 1, ddlNivel1.SelectedValue)
        ddlNivel2.SelectedValue = strNivel(1)

        BindNivelMenu(ddlNivel3, 2, ddlNivel2.SelectedValue)
        ddlNivel3.SelectedValue = strNivel(2)

        grdMenu.EditIndex = -1
    End Sub

    Protected Sub ddlBuscar1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBuscar1.SelectedIndexChanged
        BindNivelMenu(ddlBuscar2, 1, ddlBuscar1.SelectedValue)
    End Sub

    Protected Sub ddlBuscar2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBuscar2.SelectedIndexChanged
        BindNivelMenu(ddlBuscar3, 2, ddlBuscar2.SelectedValue)

    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        Dim objMenu As New clsMenu
        objMenu.IDMenuPadre = 0
        If ddlNivel3.Items.Count > 0 AndAlso ddlNivel3.SelectedValue > 0 Then
            objMenu.IDMenuPadre = ddlNivel3.SelectedValue
        ElseIf ddlNivel2.Items.Count > 0 AndAlso ddlNivel2.SelectedValue > 0 Then
            objMenu.IDMenuPadre = ddlNivel2.SelectedValue
        ElseIf ddlNivel1.Items.Count > 0 AndAlso ddlNivel1.SelectedValue > 0 Then
            objMenu.IDMenuPadre = ddlNivel1.SelectedValue
        End If
        If txtCodigo.Text <> "" Then
            objMenu.IDMenu = txtCodigo.Text
        End If

        objMenu.Titulo = txtTitulo.Text
        objMenu.Ruta = txtRuta.Text
        objMenu.Contenedor = ddlContenedor.SelectedValue
        objMenu.Usuario = Session("Usuario")
        If txtCodigo.Text <> "" Then
            If objMenu.Actualizar = True Then
                lblMensaje.Text = "Opcion actualizada"
            Else
                lblMensaje.Text = "No se registro"
            End If
        Else
            If objMenu.Agregar = True Then
                lblMensaje.Text = "Opcion registrado"
            Else
                lblMensaje.Text = "No se registro"
            End If
        End If
        
        BindGrid()
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        txtCodigo.Text = ""
        txtRuta.Text = ""
        txtTitulo.Text = ""
        lblEstado.Text = "ACT"
        lblNivel.Text = "0"
        BindNivelMenu(ddlNivel1, 0, 0)
        ddlNivel1.SelectedValue = ddlBuscar1.SelectedValue
        If ddlNivel1.SelectedValue > 0 Then
            lblNivel.Text = "1"
            BindNivelMenu(ddlNivel2, 1, ddlNivel1.SelectedValue)
            ddlNivel2.SelectedValue = ddlBuscar2.SelectedValue
            If ddlNivel2.SelectedValue > 0 Then
                lblNivel.Text = "2"
                BindNivelMenu(ddlNivel3, 2, ddlNivel2.SelectedValue)
                ddlNivel3.SelectedValue = ddlBuscar3.SelectedValue
                If ddlNivel3.SelectedValue > 0 Then
                    lblNivel.Text = "3"
                End If
            End If
        End If
        pnlFormulario.Visible = True

    End Sub

    Protected Sub ddlNivel1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlNivel1.SelectedIndexChanged
        BindNivelMenu(ddlNivel2, 1, ddlNivel1.SelectedValue)

    End Sub

    Protected Sub ddlNivel2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlNivel2.SelectedIndexChanged
        BindNivelMenu(ddlNivel3, 2, ddlNivel2.SelectedValue)
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        BindGrid()
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        pnlFormulario.Visible = False
    End Sub
End Class
