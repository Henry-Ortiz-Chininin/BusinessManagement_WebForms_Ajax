
Partial Class Interfaces_FGLINAI
    Inherits System.Web.UI.Page


    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        Buscar()
    End Sub

    Private Sub Buscar()
        Dim objRequisicion As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Requisicion
        Dim strActivo As String = ""
        Dim strAprobado As String = ""
        Dim strRechazado As String = ""

        If chkEstado.Items(0).Selected Then
            strActivo = "ACT"
        End If
        If chkEstado.Items(1).Selected Then
            strAprobado = "APR"
        End If
        If chkEstado.Items(2).Selected Then
            strRechazado = "REC"
        End If

        objRequisicion.BuscarxEstado(txtCodigo.Text, _
                              txtFechaEmisionInicio.Text, _
                              txtFechaEmisionFinal.Text, _
                              rbtTipo.SelectedValue, _
                              ctlCentroCosto_Buscar1.IdCentroCosto, _
                              ctlProyecto_Buscar1.IdProyecto, _
                               strActivo, strAprobado, strRechazado)

        grdDatos.DataSource = objRequisicion.Datos
        grdDatos.DataBind()

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlRequerimientoEstado.Visible = False
            chkEstado.Items(0).Selected = True
            chkEstado.Items(1).Selected = False
            chkEstado.Items(2).Selected = False
            Buscar()
        End If
    End Sub

    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        Dim itmFila As GridViewRow = grdDatos.Rows(e.CommandArgument)
        Dim objSeguridad As New ALVI_Security.General

        If e.CommandName = "ABRIR" Then
            'Response.Redirect("FGLINAA.aspx?IdRequisicion=" & objSeguridad.Encrypta(itmFila.Cells(0).Text), True)
            ctlRequerimientoEstado.idrequerimiento = itmFila.Cells(0).Text
            ctlRequerimientoEstado.Buscar()

            pnlRequerimientoEstado.Visible = True

        End If

    End Sub

    Protected Sub ctlRequerimientoEstado_Cerrado() Handles ctlRequerimientoEstado.Cerrado
        Buscar()
        pnlRequerimientoEstado.Visible = False
    End Sub
End Class
