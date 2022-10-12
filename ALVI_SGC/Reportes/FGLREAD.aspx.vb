
Partial Class Reportes_FGLREAD
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

        End If
    End Sub

    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand

        If e.CommandName = "IMPRIMIR" Then
            Dim itmFila As GridViewRow = grdDatos.Rows(e.CommandArgument)
            Dim objSeguridad As New ALVI_Security.General
            Dim objRequisicion As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Requisicion

        End If


    End Sub

End Class
