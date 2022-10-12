
Partial Class Estandares_FGCESAO
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
    End Sub

    Private Sub BindGrid()
        Dim objTipoMaquina As New ALVI_LOGIC.Maestros.Produccion.TipoMaquina
        objTipoMaquina.Listar()
        grdDatos.DataSource = objTipoMaquina.Datos
        grdDatos.DataBind()
    End Sub


    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        If txtCodigo.Text <> "" AndAlso txtDescripcion.Text <> "" Then
            Dim objTipoMaquina As New ALVI_LOGIC.Maestros.Produccion.TipoMaquina
            objTipoMaquina.IdTipoMaquina = txtCodigo.Text
            objTipoMaquina.Descripcion = txtDescripcion.Text
            objTipoMaquina.Usuario = Session("Usuario")
            objTipoMaquina.Estado = "ACT"
            If objTipoMaquina.Registrar = True Then
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
            Dim objTipoMaquina As New ALVI_LOGIC.Maestros.Produccion.TipoMaquina
            objTipoMaquina.IdTipoMaquina = e.CommandArgument.ToString
            If objTipoMaquina.Obtener = True Then
                txtCodigo.Text = objTipoMaquina.IdTipoMaquina
                txtDescripcion.Text = objTipoMaquina.Descripcion
                txtCodigo.ReadOnly = True
                pnlFormulario.Visible = True
            End If
        End If
        If e.CommandName = "Eliminar" Then
            Dim objTipoMaquina As New ALVI_LOGIC.Maestros.Produccion.TipoMaquina
            objTipoMaquina.IdTipoMaquina = e.CommandArgument.ToString
            If objTipoMaquina.Eliminar = True Then
                BindGrid()
            End If
        End If
    End Sub
End Class
