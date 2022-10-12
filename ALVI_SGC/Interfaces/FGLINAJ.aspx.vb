
Partial Class Interfaces_FGLINAJ
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


        objRequisicion.BuscarDetalle(txtCodigo.Text, _
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
            chkEstado.Items(0).Selected = False
            chkEstado.Items(1).Selected = True
            chkEstado.Items(2).Selected = False
            Buscar()
        End If
    End Sub

    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        Dim itmFila As GridViewRow = grdDatos.Rows(e.CommandArgument)
        Dim objSeguridad As New ALVI_Security.General

        If e.CommandName = "ABRIR" Then
            'Response.Redirect("FGLINAA.aspx?IdRequisicion=" & objSeguridad.Encrypta(itmFila.Cells(0).Text), True)
            ctlRequerimientoEstado.IdRequerimiento = itmFila.Cells(0).Text
            ctlRequerimientoEstado.Buscar()

            pnlRequerimientoEstado.Visible = True

        End If

    End Sub

   
    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAceptar.Click

        Dim dtbDatos As New Data.DataTable
        dtbDatos.Columns.Add("var_IdRequisicion", GetType(String))
        dtbDatos.Columns.Add("var_IdValeAlmacen", GetType(String))
        dtbDatos.Columns.Add("var_IdDetalle", GetType(String))
        dtbDatos.Columns.Add("var_IdArticulo", GetType(String))
        dtbDatos.Columns.Add("var_Articulo", GetType(String))
        dtbDatos.Columns.Add("var_IdUnidadMedida", GetType(String))
        dtbDatos.Columns.Add("var_UnidadMedida", GetType(String))
        dtbDatos.Columns.Add("var_IdArticuloProveedor", GetType(String))
        dtbDatos.Columns.Add("var_NombreArticuloProveedor", GetType(String))
        dtbDatos.Columns.Add("num_Cantidad", GetType(Double))
        dtbDatos.Columns.Add("num_ImporteTotal", GetType(Double))
        dtbDatos.Columns.Add("num_ImporteOrigen", GetType(Double))
        dtbDatos.Columns.Add("var_IdMoneda", GetType(String))
        dtbDatos.Columns.Add("dec_TipoCambio", GetType(Double))

        Dim pkDetalle(1) As Data.DataColumn
        pkDetalle(0) = dtbDatos.Columns("var_IdDetalle")
        dtbDatos.PrimaryKey = pkDetalle
        Dim hdnTipoCambio As HiddenField = CType(Master.Page.Form.FindControl("hdnTipoCambio"), HiddenField)

        For Each grdItem As GridViewRow In grdDatos.Rows
            Dim chkSeleccion As CheckBox = CType(grdItem.FindControl("chkSeleccion"), CheckBox)
            If chkSeleccion.Checked Then
                Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                dtrNuevo("var_IdRequisicion") = grdItem.Cells(0).Text
                dtrNuevo("var_IdValeAlmacen") = grdItem.Cells(2).Text
                dtrNuevo("var_IdDetalle") = grdItem.Cells(1).Text
                dtrNuevo("var_IdArticulo") = grdItem.Cells(3).Text
                dtrNuevo("var_Articulo") = grdItem.Cells(5).Text
                dtrNuevo("var_IdUnidadMedida") = grdItem.Cells(4).Text
                dtrNuevo("var_UnidadMedida") = grdItem.Cells(7).Text
                dtrNuevo("var_IdArticuloProveedor") = ""
                dtrNuevo("var_NombreArticuloProveedor") = ""
                dtrNuevo("num_Cantidad") = grdItem.Cells(6).Text
                dtrNuevo("num_ImporteTotal") = grdItem.Cells(9).Text
                dtrNuevo("num_ImporteOrigen") = grdItem.Cells(9).Text
                dtrNuevo("var_IdMoneda") = ""
                dtrNuevo("dec_TipoCambio") = hdnTipoCambio.Value
                dtbDatos.LoadDataRow(dtrNuevo.ItemArray, True)
            End If
        Next
        Session("dtbDatos") = dtbDatos

        If dtbDatos.Rows.Count > 0 Then
            If ddlAccion.SelectedValue = "CCC" Then
                Dim objSeguridad As New ALVI_Security.General
                Response.Redirect("FGLINDA.aspx?AC=" & objSeguridad.Encrypta(ddlAccion.SelectedValue), True)
            End If
            If ddlAccion.SelectedValue = "CUR" Then
                Dim objSeguridad As New ALVI_Security.General
                Response.Redirect("FGLINDB.aspx?AC=" & objSeguridad.Encrypta(ddlAccion.SelectedValue), True)
            End If

            If ddlAccion.SelectedValue = "SCO" Then
                Dim objSeguridad As New ALVI_Security.General
                Response.Redirect("FGLINDE.aspx?AC=" & objSeguridad.Encrypta(ddlAccion.SelectedValue), True)
            End If
        End If

    End Sub

    Protected Sub grdDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDatos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim drvItem As Data.DataRowView = CType(e.Row.DataItem, Data.DataRowView)
            Dim chkSeleccion As CheckBox = CType(e.Row.FindControl("chkSeleccion"), CheckBox)
            If drvItem("chr_IdEstado") <> "APR" Then
                chkSeleccion.Enabled = False
            End If

        End If
    End Sub
End Class
