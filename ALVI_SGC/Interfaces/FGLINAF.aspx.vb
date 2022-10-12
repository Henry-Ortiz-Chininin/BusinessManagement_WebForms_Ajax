
Partial Class Interfaces_FGLINAF
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlCajaBanco.Visible = False
            pnlDetracion.Visible = False

            btnFechaEmisionInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmisionInicio.ClientID & ", 'dd/mm/yyyy');")
            btnFechaEmisionFinal.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmisionFinal.ClientID & ", 'dd/mm/yyyy');")
            'txtFechaEmisionFinal.Text = Format(Now.Date, "dd/MM/yyyy")
            'txtFechaEmisionInicio.Text = Format(Now.Date, "dd/MM/yyyy")

            btnFechaVencimientoInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaVencimientoInicio.ClientID & ", 'dd/mm/yyyy');")
            btnFechaVencimientoFinal.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaVencimientoFinal.ClientID & ", 'dd/mm/yyyy');")
            'txtFechaVencimientoFinal.Text = Format(Now.Date, "dd/MM/yyyy")
            'txtFechaVencimientoInicio.Text = Format(Now.Date, "dd/MM/yyyy")
           
            BindGrid()

        End If
    End Sub


    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        txtFechaEmisionInicio.Text = Format(Now.Date, "dd/MM/yyyy")
        btnFechaEmisionInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmisionInicio.ClientID & ", 'dd/mm/yyyy');")

        txtFechaEmisionFinal.Text = Format(Now.Date, "dd/MM/yyyy")
        btnFechaEmisionFinal.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmisionFinal.ClientID & ", 'dd/mm/yyyy');")

        txtFechaVencimientoInicio.Text = Format(Now.Date, "dd/MM/yyyy")
        btnFechaVencimientoInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaVencimientoInicio.ClientID & ", 'dd/mm/yyyy');")

        txtFechaVencimientoFinal.Text = Format(Now.Date, "dd/MM/yyyy")
        btnFechaVencimientoFinal.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaVencimientoFinal.ClientID & ", 'dd/mm/yyyy');")
        LimpiarFormulario()


    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        Response.Redirect("default.aspx")
    End Sub
    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
            BindGrid()
    End Sub


    Private Sub BindGrid()
        Dim objDocumento As New ALVI_LOGIC.Proceso.Logistica.Documento
        objDocumento.Buscar(txtNumeroDumento.Text, _
                         txtFechaEmisionInicio.Text, _
                         txtFechaEmisionFinal.Text, _
                          txtFechaVencimientoInicio.Text, _
                         txtFechaVencimientoFinal.Text, _
                         ctlProveedor_Buscar1.IdProveedor
                        )

        grdDatos.DataSource = objDocumento.Datos
        grdDatos.DataBind()


    End Sub


    Protected Sub grdDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDatos.PageIndexChanging
        grdDatos.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub


    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        Dim itmFila As GridViewRow = grdDatos.Rows(e.CommandArgument)
        Dim objSeguridad As New ALVI_Security.General
        If e.CommandName = "ABRIR" Then
            Response.Redirect("FGLINDC.aspx?var_IdDocumentoCompra=" & objSeguridad.Encrypta(itmFila.Cells(0).Text), True)
        End If

        If e.CommandName = "Eliminar" Then
            Dim objDocumento As New ALVI_LOGIC.Proceso.Logistica.Documento
            objDocumento.IdDocumentoCompra = itmFila.Cells(0).Text
            objDocumento.Estado = "INA"

            objDocumento.Actualizar()

        End If
        If e.CommandName = "CAJABANCO" Then
            pnlCajaBanco.Visible = True
            ctlCajaBanco.Limpiar()
            ctlCajaBanco.IdCliente = ""
            ctlCajaBanco.IdProveedor = itmFila.Cells(2).Text
            ctlCajaBanco.IdTipoDocumentoHaber = "VOB"
            ctlCajaBanco.NumeroDocumentoHaber = ""
            ctlCajaBanco.Importe = itmFila.Cells(6).Text
            ctlCajaBanco.Glosa = "POR EL PAGO DE LA FACTURA " & itmFila.Cells(1).Text
            ctlCajaBanco.IdOperacion = "0000006"
            ctlCajaBanco.IdTipoDocumentoDebe = "FAP"
            ctlCajaBanco.NumeroDocumentoDebe = itmFila.Cells(1).Text
            ctlCajaBanco.OperacionHabilitado = False
            ctlCajaBanco.DocumentoDeudorHabilitado = False
        End If
        If e.CommandName = "DETRACCION" Then
            ctlDetraccion.Codigo = grdDatos.Rows(CInt(e.CommandArgument.ToString) + (grdDatos.PageIndex * grdDatos.PageSize)).Cells(0).Text
            ctlDetraccion.Cargar()
            pnlDetracion.Visible = True
        End If
    End Sub


    Protected Sub grdDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDatos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim btnEliminar = CType(e.Row.FindControl("btnEliminar"), ImageButton)
            Dim strIdDocumentoCompra As String = e.Row.Cells(0).Text

            btnEliminar.Attributes.Add("onclick", "return confirm('El documento Compra " & strIdDocumentoCompra & " sera eliminada');")
            Dim objCompra As New ALVI_LOGIC.Maestros.Logistica.Compra

        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.Cells(7).Text = "ANULADO" Then
                Dim btnCajaBanco As Button = CType(e.Row.FindControl("btnCajaBanco"), Button)
                btnCajaBanco.Visible = False
                e.Row.Cells(7).ForeColor = Drawing.Color.Red
            End If
            If e.Row.Cells(7).Text = "PAGADO" Then
                Dim btnCajaBanco As Button = CType(e.Row.FindControl("btnCajaBanco"), Button)
                btnCajaBanco.Visible = False

            End If
        End If
    End Sub

    Private Sub LimpiarFormulario()
        txtNumeroDumento.Text = ""
        ctlProveedor_Buscar1.IdProveedor = ""

    End Sub


    Protected Sub ctlDetraccion_Cerrado() Handles ctlDetraccion.Cerrado
        pnlDetracion.Visible = False
    End Sub

End Class
