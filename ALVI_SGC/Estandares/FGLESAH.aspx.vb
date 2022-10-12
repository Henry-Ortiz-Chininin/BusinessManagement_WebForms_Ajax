
Partial Class Estandares_FGLESAH
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlFormulario.Visible = False
            BindCondicion()
            LimpiarFormulario()

            BindGrid()
        End If
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        'LimpiarFormulario()
        pnlFormulario.Visible = True
        txtCodigoValidador.ReadOnly = False
        lblMensaje.Text = ""


    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        LimpiarFormulario()
        Cancelar()
        pnlFormulario.Visible = False
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        Response.Redirect("default.aspx")
    End Sub


    Private Sub Cancelar()
        LimpiarFormulario()
        pnlFormulario.Visible = False
        BindGrid()
    End Sub

    Private Sub LimpiarFormulario()
        txtCodigoValidador.Text = ""
        ctlPersonal_Buscar1.Limpia()
        BindCondicion()
        CtlArea_Buscar1.Limpia()
        ctlCargo_Buscar1.Limpia()
        txtNombre.Text = ""
        txtPaterno.Text = ""


    End Sub

    Private Sub BindCondicion()
        Dim objCondicion As New ALVI_LOGIC.Maestros.Compras.Condicion
        ddlCondicion.Items.Clear()

        If objCondicion.Listar = True Then
            ddlCondicion.DataSource = objCondicion.Datos
            ddlCondicion.DataTextField = "var_Descripcion"
            ddlCondicion.DataValueField = "var_IdCondicion"
            ddlCondicion.DataBind()

        End If
        ddlCondicion.Items.Insert(0, New ListItem("Selecionar", ""))
        ddlCondicion.SelectedIndex = 0

    End Sub



    Private Sub BindGrid()
        Dim objValidador As New ALVI_LOGIC.Maestros.Requisicion.Validador

        If objValidador.Listar = True Then

            grdDatos.DataSource = New Data.DataView(objValidador.Datos, "", "var_IdValidador", Data.DataViewRowState.OriginalRows)
            grdDatos.DataBind()
        End If

    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        Registrar()
    End Sub


    Private Sub Registrar()
        If txtCodigoValidador.Text <> "" AndAlso ctlPersonal_Buscar1.IdPersonal <> "" AndAlso ddlCondicion.Text <> "" Then
            Dim objValidador As New ALVI_LOGIC.Maestros.Requisicion.Validador
            objValidador.IdValidador = txtCodigoValidador.Text
            objValidador.IdPersonal = ctlPersonal_Buscar1.IdPersonal
            objValidador.IdCondicion = ddlCondicion.SelectedValue
            objValidador.Usuario = Session("Usuario")
            objValidador.Estado = "ACT"
            If objValidador.Registrar = True Then

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


    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        Buscar()
    End Sub

    Private Sub Buscar()

        Dim objValidador As New ALVI_LOGIC.Maestros.Requisicion.Validador

        objValidador.Nombre = txtNombre.Text
        objValidador.ApellidoPaterno = txtPaterno.Text
        objValidador.ApellidoMaterno = TxtMaterno.Text
        objValidador.IdArea = CtlArea_Buscar1.IdArea
        objValidador.IdCargo = ctlCargo_Buscar1.IdCargo


        If objValidador.Buscar() = True Then
            grdDatos.DataSource = New Data.DataView(objValidador.Datos, "", "var_IdValidador", Data.DataViewRowState.OriginalRows)
            grdDatos.DataBind()

        End If


    End Sub


    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        If e.CommandName = "Modificar" Then
            Dim objValidador As New ALVI_LOGIC.Maestros.Requisicion.Validador
            objValidador.IdValidador = e.CommandArgument.ToString
            If objValidador.Obtener = True Then

                txtCodigoValidador.Text = objValidador.IdValidador
                ctlPersonal_Buscar1.IdPersonal = objValidador.IdPersonal
                ctlPersonal_Buscar1.Nombre = objValidador.Nombre
                ctlPersonal_Buscar1.ApellidoPaterno = objValidador.ApellidoPaterno
                ctlPersonal_Buscar1.ApellidoMaterno = objValidador.ApellidoMaterno
                ddlCondicion.SelectedValue = objValidador.IdCondicion
                pnlFormulario.Visible = True


            End If

        End If


        If e.CommandName = "Eliminar" Then
            Dim objValidador As New ALVI_LOGIC.Maestros.Requisicion.Validador
            objValidador.IdValidador = e.CommandArgument.ToString

            If objValidador.Eliminar = True Then

                BindGrid()
            End If
        End If


    End Sub

End Class
