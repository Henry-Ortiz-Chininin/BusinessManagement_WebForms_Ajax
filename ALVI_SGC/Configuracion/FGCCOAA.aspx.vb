
Partial Class Configuracion_FGCCOAA
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
        lblMensaje.Text = ""
    End Sub

    Private Sub BindGrid()
        Dim objCentroCosto As New ALVI_LOGIC.Configuracion.CentroCosto
        If objCentroCosto.Listar() = True Then
            grdDatos.DataSource = objCentroCosto.Datos
            grdDatos.DataBind()
        End If
    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        Registrar()
    End Sub

    Private Sub Registrar()
        If txtCodigo.Text <> "" AndAlso txtDescripcion.Text <> "" Then
            Dim objCentroCosto As New ALVI_LOGIC.Configuracion.CentroCosto
            objCentroCosto.IdCentroCosto = txtCodigo.Text
            objCentroCosto.Descripcion = txtDescripcion.Text
            objCentroCosto.Usuario = Session("Usuario")
            objCentroCosto.Estado = "ACT"
            If objCentroCosto.Registrar = True Then
                LimpiarFormulario()
                lblMensaje.Text = "Registro exitoso"
                grdDatos.EditIndex = -1
                BindGrid()
            End If
        Else
            lblMensaje.Text = "Faltan datos"
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
            Dim objCentroCosto As New ALVI_LOGIC.Configuracion.CentroCosto
            objCentroCosto.IdCentroCosto = e.CommandArgument.ToString
            If objCentroCosto.Obtener = True Then
                txtCodigo.Text = objCentroCosto.IdCentroCosto
                txtDescripcion.Text = objCentroCosto.Descripcion
                txtCodigo.ReadOnly = True
                pnlFormulario.Visible = True
            End If
        End If
        If e.CommandName = "Eliminar" Then
            Dim objCentroCosto As New ALVI_LOGIC.Configuracion.CentroCosto
            objCentroCosto.IdCentroCosto = e.CommandArgument.ToString
            If objCentroCosto.Eliminar = True Then
                BindGrid()
            End If
        End If
    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTerminar.Click
        Registrar()
        If lblMensaje.Text = "Registro exitoso" Then
            Cancelar()
        End If

    End Sub
End Class
