
Partial Class Estandares_FGLESAB
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlFormulario.Visible = False


            BindGrid()
        End If
    End Sub
    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        Response.Redirect("default.aspx")
    End Sub
    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        'LimpiarFormulario()
        pnlFormulario.Visible = True
        txtCodigoSolicitante.ReadOnly = False
        lblMensaje.Text = ""


    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        LimpiarFormulario()
        Cancelar()
        pnlFormulario.Visible = False
    End Sub


    Private Sub Cancelar()
        LimpiarFormulario()
        pnlFormulario.Visible = False
        BindGrid()
    End Sub

    Private Sub LimpiarFormulario()
        txtCodigoSolicitante.Text = ""
        ctlPersonal_Buscar1.Limpia()
    End Sub

    Private Sub BindGrid()
        Dim objSolicitante As New ALVI_LOGIC.Maestros.Requisicion.Solicitante

        If objSolicitante.Listar = True Then

            grdDatos.DataSource = New Data.DataView(objSolicitante.Datos, "", "var_IdSolicitante", Data.DataViewRowState.OriginalRows)
            grdDatos.DataBind()
        End If
       
    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        Registrar()
    End Sub

    Private Sub Cerrar()
        pnlFormulario.Visible = False
    End Sub
    Private Sub Registrar()
        If txtCodigoSolicitante.Text <> "" AndAlso ctlPersonal_Buscar1.IdPersonal <> "" Then
            Dim objSolicitante As New ALVI_LOGIC.Maestros.Requisicion.Solicitante
            objSolicitante.IdSolicitante = txtCodigoSolicitante.Text
            objSolicitante.IdPersonal = ctlPersonal_Buscar1.IdPersonal
            objSolicitante.Estado = "ACT"
            objSolicitante.Usuario = Session("Usuario")
            If objSolicitante.Registrar = True Then

                lblMensaje.Text = "Registro exitoso"
                LimpiarFormulario()
                grdDatos.EditIndex = -1
                BindGrid()

            Else
                lblMensaje.Text = "Datos Incorrectos"
            End If

        Else : lblMensaje.Text = "Faltan Datos"

        End If


    End Sub


    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTerminar.Click
        Registrar()
        Cerrar()
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        Buscar()
    End Sub

    Private Sub Buscar()

        Dim objSolicitante As New ALVI_LOGIC.Maestros.Requisicion.Solicitante

        objSolicitante.Nombre = txtNombre.Text
        objSolicitante.ApellidoPaterno = txtPaterno.Text
        objSolicitante.ApellidoMaterno = TxtMaterno.Text
        objSolicitante.IdArea = CtlArea_Buscar1.IdArea
        objSolicitante.IdCargo = ctlCargo_Buscar1.IdCargo


        If objSolicitante.Buscar() = True Then
            grdDatos.DataSource = New Data.DataView(objSolicitante.Datos, "", "var_IdSolicitante", Data.DataViewRowState.OriginalRows)
            grdDatos.DataBind()

        End If


    End Sub


    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        If e.CommandName = "Modificar" Then
            Dim objSolicitante As New ALVI_LOGIC.Maestros.Requisicion.Solicitante
            objSolicitante.IdSolicitante = e.CommandArgument.ToString
            If objSolicitante.Obtener = True Then

                txtCodigoSolicitante.Text = objSolicitante.IdSolicitante
                ctlPersonal_Buscar1.IdPersonal = objSolicitante.IdPersonal
                ctlPersonal_Buscar1.Nombre = objSolicitante.Nombre
                ctlPersonal_Buscar1.ApellidoPaterno = objSolicitante.ApellidoPaterno
                ctlPersonal_Buscar1.ApellidoMaterno = objSolicitante.ApellidoMaterno
                pnlFormulario.Visible = True


            End If

        End If


        If e.CommandName = "Eliminar" Then
            Dim objSolicitante As New ALVI_LOGIC.Maestros.Requisicion.Solicitante
            objSolicitante.IdSolicitante = e.CommandArgument.ToString

            If objSolicitante.Eliminar = True Then

                BindGrid()
            End If
        End If


    End Sub

    Protected Sub grdDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDatos.PageIndexChanging
        grdDatos.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub
End Class
