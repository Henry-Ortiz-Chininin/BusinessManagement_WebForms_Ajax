
Partial Class Estandares_FGCESFA
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
        Cancelar()
    End Sub

    Private Sub Cancelar()
        LimpiarFormulario()
        pnlFormulario.Visible = False
        BindGrid()
    End Sub

    Private Sub LimpiarFormulario()
        txtCodigo.Text = ""
        txtDescripcion.Text = ""
        txtDireccion.Text = ""
        TxtTelefono.Text = ""
        TxtPerContacto.Text = ""
        TxtTelPersonaContacto.Text = ""
        lblMensaje.Text = ""
    End Sub

    Private Sub BindGrid()
        Dim objProveedor As New ALVI_LOGIC.Maestros.Compras.Proveedor
        If objProveedor.Listar() = True Then
            grdDatos.DataSource = New Data.DataView(objProveedor.Datos, "", "var_IdProveedor", Data.DataViewRowState.OriginalRows)
            grdDatos.DataBind()
        End If
    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        Registrar()
    End Sub

    Private Sub Registrar()
        If txtCodigo.Text <> "" AndAlso txtDescripcion.Text <> "" Then
            Dim objProveedor As New ALVI_LOGIC.Maestros.Compras.Proveedor
            objProveedor.IdProveedor = txtCodigo.Text
            objProveedor.Descripcion = txtDescripcion.Text
            objProveedor.Direccion = txtDireccion.Text
            objProveedor.Telefono = TxtTelefono.Text
            objProveedor.PersonaContacto = TxtPerContacto.Text
            objProveedor.TelPersonaContacto = TxtTelPersonaContacto.Text
            objProveedor.Usuario = Session("Usuario")
            objProveedor.Estado = "ACT"
            If objProveedor.Registrar = True Then
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
            Dim objProveedor As New ALVI_LOGIC.Maestros.Compras.Proveedor
            objProveedor.IdProveedor = e.CommandArgument.ToString
            If objProveedor.Obtener = True Then
                txtCodigo.Text = objProveedor.IdProveedor
                txtDescripcion.Text = objProveedor.Descripcion
                txtDireccion.Text = objProveedor.Direccion
                TxtTelefono.Text = objProveedor.Telefono
                TxtPerContacto.Text = objProveedor.PersonaContacto
                TxtTelPersonaContacto.Text = objProveedor.TelPersonaContacto
                txtCodigo.ReadOnly = True
                pnlFormulario.Visible = True
            End If
        End If
        If e.CommandName = "Eliminar" Then
            Dim objProveedor As New ALVI_LOGIC.Maestros.Compras.Proveedor
            objProveedor.IdProveedor = e.CommandArgument.ToString
            If objProveedor.Eliminar = True Then
                BindGrid()
            End If
        End If
    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTerminar.Click
        Registrar()
        Cancelar()
    End Sub
End Class
