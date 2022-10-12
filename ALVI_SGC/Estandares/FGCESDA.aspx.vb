
Partial Class Estandares_FGCESDA
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
        TxtPersonaContacto.Text = ""
        TxtTelefonoPersonaContacto.Text = ""
        ddlMercado.SelectedValue = "N"
    End Sub
    Private Sub BindGrid()
        Dim objCliente As New ALVI_LOGIC.Maestros.Ventas.Cliente
        If objCliente.Listar() = True Then
            grdDatos.DataSource = New Data.DataView(objCliente.Datos, "", "var_IdCliente", Data.DataViewRowState.OriginalRows)
            grdDatos.DataBind()
        End If
    End Sub
    Private Sub BindGridBuscar()
        Dim objCliente As New ALVI_LOGIC.Maestros.Ventas.Cliente
        objCliente.Descripcion = txtBuscar.Text
        objCliente.Buscar()

        grdDatos.DataSource = objCliente.Datos
        grdDatos.DataBind()

    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        Registrar()
    End Sub

    Private Sub Registrar()
        If txtCodigo.Text <> "" AndAlso txtDescripcion.Text <> "" Then
            Dim objCliente As New ALVI_LOGIC.Maestros.Ventas.Cliente
            objCliente.IdCliente = txtCodigo.Text
            objCliente.Descripcion = txtDescripcion.Text
            objCliente.Direccion = txtDireccion.Text
            objCliente.Mercado = ddlMercado.SelectedValue
            objCliente.Telefono = TxtTelefono.Text
            objCliente.PersonaContacto = TxtPersonaContacto.Text
            objCliente.TelefonoPersonaContacto = TxtTelefonoPersonaContacto.Text
            objCliente.Usuario = Session("Usuario")
            objCliente.Estado = "ACT"
            If objCliente.Registrar = True Then
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
            Dim objCliente As New ALVI_LOGIC.Maestros.Ventas.Cliente
            objCliente.IdCliente = e.CommandArgument.ToString
            If objCliente.Obtener = True Then
                pnlFormulario.Visible = True
                txtCodigo.Text = objCliente.IdCliente
                txtDescripcion.Text = objCliente.Descripcion
                txtDireccion.Text = objCliente.Direccion
                ddlMercado.SelectedValue = objCliente.Mercado
                TxtTelefono.Text = objCliente.Telefono
                TxtPersonaContacto.Text = objCliente.PersonaContacto
                TxtTelefonoPersonaContacto.Text = objCliente.TelefonoPersonaContacto
                txtCodigo.ReadOnly = True
            End If
        End If
        If e.CommandName = "Eliminar" Then
            Dim objCliente As New ALVI_LOGIC.Maestros.Ventas.Cliente
            objCliente.IdCliente = e.CommandArgument.ToString
            If objCliente.Eliminar = True Then
                BindGrid()
            End If
        End If
    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTerminar.Click
        Registrar()
        Cancelar()
    End Sub

    Protected Sub txtBuscar_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        BindGridBuscar()
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        BindGridBuscar()
    End Sub
End Class
