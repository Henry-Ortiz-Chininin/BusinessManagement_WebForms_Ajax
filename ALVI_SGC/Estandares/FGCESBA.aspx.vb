
Partial Class Estandares_FGCESBA
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
        Dim objAlmacen As New ALVI_LOGIC.Maestros.Logistica.Almacen
        If objAlmacen.Listar() = True Then
            grdDatos.DataSource = objAlmacen.Datos
            grdDatos.DataBind()
        End If
    End Sub


    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        If txtCodigo.Text <> "" AndAlso txtDescripcion.Text <> "" Then
            Dim objAlmacen As New ALVI_LOGIC.Maestros.Logistica.Almacen
            objAlmacen.IdAlmacen = txtCodigo.Text
            objAlmacen.Descripcion = txtDescripcion.Text
            objAlmacen.Usuario = Session("Usuario")
            objAlmacen.Estado = "ACT"
            If objAlmacen.Registrar = True Then
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
            Dim objAlmacen As New ALVI_LOGIC.Maestros.Logistica.Almacen
            objAlmacen.IdAlmacen = e.CommandArgument.ToString
            If objAlmacen.Obtener = True Then
                txtCodigo.Text = objAlmacen.IdAlmacen
                txtDescripcion.Text = objAlmacen.Descripcion
                txtCodigo.ReadOnly = True
                pnlFormulario.Visible = True
            End If
        End If
        If e.CommandName = "Eliminar" Then
            Dim objAlmacen As New ALVI_LOGIC.Maestros.Logistica.Almacen
            objAlmacen.IdAlmacen = e.CommandArgument.ToString
            If objAlmacen.Eliminar = True Then
                BindGrid()
            End If
        End If
    End Sub
End Class
