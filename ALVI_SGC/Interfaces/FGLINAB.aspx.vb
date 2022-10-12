
Partial Class Interfaces_FGLINAB
    Inherits System.Web.UI.Page

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        Buscar()
    End Sub

    Private Sub Buscar()
        Dim objRequisicion As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Requisicion
        objRequisicion.Buscar(txtCodigo.Text, _
                              ctlSolicitante_Buscar1.IdSolicitante, _
                              txtFechaEmisionInicio.Text, _
                              txtFechaEmisionFinal.Text, _
                              txtFechaRecepcionInicio.Text, _
                              txtFechaRecepcionFinal.Text, _
                              txtFechaPlazoInicio.Text, _
                              txtFechaPlazoFinal.Text, _
                              rbtTipo.SelectedValue, _
                              ctlCentroCosto_Buscar1.IdCentroCosto, _
                              ctlProyecto_Buscar1.IdProyecto, _
                              ctlCargo_Buscar1.IdCargo)

        grdDatos.DataSource = objRequisicion.Datos
        grdDatos.DataBind()


    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Buscar()
            pnlValidadorRegistro.Visible = False
            pnlAtencion.Visible = False

        End If
    End Sub

    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        Dim itmFila As GridViewRow = grdDatos.Rows(e.CommandArgument)
        Dim objSeguridad As New ALVI_Security.General

        If e.CommandName = "ABRIR" Then
            Response.Redirect("FGLINAA.aspx?IdRequisicion=" & objSeguridad.Encrypta(itmFila.Cells(0).Text), True)
        End If

        If e.CommandName = "APROBAR" Then
            pnlValidadorRegistro.Visible = True
            ctlValidadorRegistro.IdRequisicion = itmFila.Cells(0).Text
            ctlValidadorRegistro.CargarValidacion()
        End If

        If e.CommandName = "ATENDER" Then
            pnlAtencion.Visible = True

        End If

        If e.CommandName = "CERRAR" Then
            Dim objRequisicion As New ALVI_LOGIC.Maestros.Requisicion.Requisicion
            objRequisicion.IdRequisicion = itmFila.Cells(0).Text
            objRequisicion.Estado = "CER"


            If objRequisicion.Actualizar Then

                lblMensaje.Text = "Actualizacion exitosa"

            Else
                lblMensaje.Text = "Datos Incorrectos"


            End If

        End If


        If e.CommandName = "ELIMINAR" Then
            Dim objRequisicion As New ALVI_LOGIC.Maestros.Requisicion.Requisicion
            objRequisicion.IdRequisicion = itmFila.Cells(0).Text
            objRequisicion.Estado = "ANU"


            If objRequisicion.Actualizar Then

                lblMensaje.Text = "Actualizacion exitosa"

            Else
                lblMensaje.Text = "Datos Incorrectos"


            End If

        End If


    End Sub

    Protected Sub grdDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDatos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btnCerrar = CType(e.Row.FindControl("btnCerrar"), ImageButton)
            Dim btnEliminar = CType(e.Row.FindControl("btnEliminar"), ImageButton)
            Dim strIdRequisicion As String = e.Row.Cells(0).Text

            btnCerrar.Attributes.Add("onclick", "return confirm('La Requisicion " & strIdRequisicion & " sera cerrada');")
            btnEliminar.Attributes.Add("onclick", "return confirm('La Requisicion " & strIdRequisicion & " sera eliminada');")

        End If
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        Response.Redirect("FGLINAA.aspx")
        pnlAtencion.Visible = False
    End Sub

    Protected Sub btnValeSalida_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnValeSalida.Click
        Response.Redirect("FGLINAC.aspx")
    End Sub

    Protected Sub btnCompraMenor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCompraMenor.Click
        Response.Redirect("FGLINAF.aspx")
    End Sub

    Protected Sub btnOrdenCompra_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOrdenCompra.Click
        Response.Redirect("FGLINBC.aspx")
        pnlAtencion.Visible = False

    End Sub

End Class
