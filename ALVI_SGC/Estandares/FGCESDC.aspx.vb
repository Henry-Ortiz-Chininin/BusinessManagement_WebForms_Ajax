
Partial Class Estandares_FGCESDC
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlFormulario.Visible = False
            BindGrid()
        End If
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        LimpiarFormulario()
        txtDni.ReadOnly = False
        pnlFormulario.Visible = True

    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Private Sub Cancelar()
        LimpiarFormulario()
        pnlFormulario.Visible = False
        BindGrid()
    End Sub
    Private Sub LimpiarFormulario()
        txtDni.Text = ""
        txtNombre.Text = ""
        txtApPaterno.Text = ""
        ddlEstado.SelectedIndex = 0
    End Sub
    Private Sub BindGrid()
        Dim objPersonal As New ALVI_LOGIC.Maestros.Ventas.Vendedor
        If objPersonal.Listar() = True Then
            grdDatos.DataSource = New Data.DataView(objPersonal.Datos, "", "var_Idvendedor", Data.DataViewRowState.OriginalRows)
            grdDatos.DataBind()
        End If
    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        Registrar()
    End Sub
    Private Sub Registrar()
        If txtDni.Text <> "" AndAlso txtNombre.Text <> "" AndAlso txtApPaterno.Text <> "" Then
            Dim objPersonal As New ALVI_LOGIC.Maestros.Ventas.Vendedor
            objPersonal.IdVendedor = txtDni.Text
            objPersonal.Nombre = txtNombre.Text
            objPersonal.ApellidoPaterno = txtApPaterno.Text
            objPersonal.Estado = ddlEstado.SelectedValue
            objPersonal.Usuario = Session("Usuario")
            If objPersonal.Registrar = True Then
                lblMensaje.Text = "Registro exitoso"
                LimpiarFormulario()
                grdDatos.EditIndex = -1
                BindGrid()
            End If
        End If
    End Sub
    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        Response.Redirect("default.aspx")
        pnlFormulario.Visible = False
    End Sub
    Protected Sub grdDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDatos.PageIndexChanging
        grdDatos.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub

    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        If e.CommandName = "Modificar" Then
            Dim objPersonal As New ALVI_LOGIC.Maestros.Ventas.Vendedor
            objPersonal.IdVendedor = e.CommandArgument.ToString
            If objPersonal.Obtener = True Then
                txtDni.Text = objPersonal.IdVendedor
                txtApPaterno.Text = objPersonal.ApellidoPaterno
                txtNombre.Text = objPersonal.Nombre
                ddlEstado.SelectedValue = objPersonal.Estado
                txtDni.ReadOnly = True
                pnlFormulario.Visible = True
            End If
        End If
        If e.CommandName = "Eliminar" Then
            Dim objPersonal As New ALVI_LOGIC.Maestros.Ventas.Vendedor
            objPersonal.IdVendedor = e.CommandArgument.ToString
            If objPersonal.Eliminar = True Then
                BindGrid()
            End If
            BindGrid()
        End If
    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTerminar.Click
        Registrar()
        Cancelar()
    End Sub

End Class
