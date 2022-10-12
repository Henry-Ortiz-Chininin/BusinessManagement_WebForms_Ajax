
Partial Class Estandares_FGCESDB
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
        txtApMaterno.Text = ""
        txtApPaterno.Text = ""
        txtCargo.Text = ""
        ctlCentroCosto1.Limpia()
        CtlArea_Buscar1.Limpia()
        ctlCargo_Buscar1.Limpia()
    End Sub
    Private Sub BindGrid()
        Dim objPersonal As New ALVI_LOGIC.Maestros.Administracion.Personal
        If objPersonal.Listar() = True Then
            grdDatos.DataSource = New Data.DataView(objPersonal.Datos, "", "var_IdPersonal", Data.DataViewRowState.OriginalRows)
            grdDatos.DataBind()
        End If
    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        Registrar()
    End Sub

    Private Sub Registrar()
        If txtDni.Text <> "" AndAlso txtNombre.Text <> "" AndAlso txtApPaterno.Text <> "" AndAlso txtApMaterno.Text <> "" AndAlso ctlCentroCosto1.IdCentroCosto <> "" AndAlso ctlCargo_Buscar1.IdCargo <> "" AndAlso CtlArea_Buscar1.IdArea <> "" Then


            Dim objPersonal As New ALVI_LOGIC.Maestros.Administracion.Personal
            objPersonal.IdPersonal = txtDni.Text
            objPersonal.Nombre = txtNombre.Text
            objPersonal.ApellidoPaterno = txtApPaterno.Text
            objPersonal.ApellidoMaterno = txtApMaterno.Text
            objPersonal.IdCentroCosto = ctlCentroCosto1.IdCentroCosto
            objPersonal.IdCargo = ctlCargo_Buscar1.IdCargo
            objPersonal.IdArea = CtlArea_Buscar1.IdArea
            objPersonal.Usuario = Session("Usuario")
            objPersonal.Estado = "ACT"
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
            Dim objPersonal As New ALVI_LOGIC.Maestros.Administracion.Personal
            objPersonal.IdPersonal = e.CommandArgument.ToString
            If objPersonal.Obtener = True Then
                txtDni.Text = objPersonal.IdPersonal
                txtApPaterno.Text = objPersonal.ApellidoPaterno
                txtApMaterno.Text = objPersonal.ApellidoMaterno
                txtNombre.Text = objPersonal.Nombre
                ctlCargo_Buscar1.IdCargo = objPersonal.IdCargo
                ctlCargo_Buscar1.Nombre = objPersonal.Cargo

                CtlArea_Buscar1.IdArea = objPersonal.IdArea
                CtlArea_Buscar1.Nombre = objPersonal.Area

                ctlCentroCosto1.IdCentroCosto = objPersonal.IdCentroCosto
                ctlCentroCosto1.Descripcion = objPersonal.CentroCosto
                txtDni.ReadOnly = True
                pnlFormulario.Visible = True
            End If
        End If
        If e.CommandName = "Eliminar" Then
            Dim objPersonal As New ALVI_LOGIC.Maestros.Administracion.Personal
            objPersonal.IdPersonal = e.CommandArgument.ToString
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

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        Dim objPersonal As New ALVI_LOGIC.Maestros.Administracion.Personal
        objPersonal.Nombre = txtNombre.Text
        objPersonal.ApellidoMaterno = txtApeMaterno.Text
        objPersonal.ApellidoPaterno = txtApePaterno.Text
        objPersonal.IdPersonal = txtCodigo.Text
        If objPersonal.Buscar = True Then
            grdDatos.DataSource = New Data.DataView(objPersonal.Datos, "", "var_IdPersonal", Data.DataViewRowState.OriginalRows)
            grdDatos.DataBind()
        End If
    End Sub
End Class
