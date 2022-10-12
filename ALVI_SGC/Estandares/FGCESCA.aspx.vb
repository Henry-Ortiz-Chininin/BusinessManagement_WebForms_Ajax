
Partial Class Estandares_FGCESCA
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlFormulario.Visible = False
            BindGrid()
        End If
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        LimpiarFormulario()
        txtCodigo.ReadOnly = False
        pnlFormulario.Visible = True

    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        LimpiarFormulario()
        pnlFormulario.Visible = False
        BindGrid()
    End Sub

    Private Sub LimpiarFormulario()
        txtCodigo.Text = ""
        txtDescripcion.Text = ""
        ddlClase.SelectedValue = ""

    End Sub

    Private Sub BindGrid()
        Dim objTipoDocumento As New ALVI_LOGIC.Maestros.Administracion.TipoDocumento
        objTipoDocumento.Clasificacion = ""
        If objTipoDocumento.Listar() = True Then
            grdDatos.DataSource = objTipoDocumento.Datos
            grdDatos.DataBind()
        End If
    End Sub


    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        If txtCodigo.Text <> "" AndAlso txtDescripcion.Text <> "" Then
            Dim objTipoDocumento As New ALVI_LOGIC.Maestros.Administracion.TipoDocumento
            objTipoDocumento.IdTipoDocumento = txtCodigo.Text
            objTipoDocumento.Descripcion = txtDescripcion.Text
            objTipoDocumento.Clasificacion = ddlClase.SelectedValue
            objTipoDocumento.Usuario = Session("Usuario")
            objTipoDocumento.Estado = "ACT"
            If objTipoDocumento.Registrar = True Then
                lblMensaje.Text = "Registro exitoso"
                LimpiarFormulario()
                grdDatos.EditIndex = -1
                BindGrid()
            End If
        End If
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        Response.Redirect("default.aspx")

    End Sub

    Protected Sub grdDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDatos.PageIndexChanging
        grdDatos.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub

    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        If e.CommandName = "Modificar" Then
            Dim objTipoDocumento As New ALVI_LOGIC.Maestros.Administracion.TipoDocumento
            objTipoDocumento.IdTipoDocumento = e.CommandArgument.ToString
            If objTipoDocumento.Obtener = True Then
                txtCodigo.Text = objTipoDocumento.IdTipoDocumento
                txtDescripcion.Text = objTipoDocumento.Descripcion
                ddlClase.SelectedValue = objTipoDocumento.Clasificacion
                txtCodigo.ReadOnly = True
                pnlFormulario.Visible = True
            End If
        End If
        If e.CommandName = "Eliminar" Then
            Dim objTipoDocumento As New ALVI_LOGIC.Maestros.Administracion.TipoDocumento
            objTipoDocumento.IdTipoDocumento = e.CommandArgument.ToString
            If objTipoDocumento.Eliminar = True Then
                BindGrid()
            End If
        End If
    End Sub
End Class
