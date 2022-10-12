
Partial Class Interfaces_FGCINVD
    Inherits System.Web.UI.Page

    Private Sub BindGrid()
        Dim objDatos As New LN_ALVINET_CONTA.REPORTE.LN_CajaBanco
        objDatos.Buscar(txtFechaInicio.Text, txtFechaFinal.Text)
        grdDatos.DataSource = objDatos.Datos
        grdDatos.DataBind()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlCajaBanco.Visible = False

        End If
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        If txtFechaInicio.Text <> "" AndAlso txtFechaFinal.Text <> "" Then
            BindGrid()
        End If

    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        pnlCajaBanco.Visible = True
    End Sub

    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        If e.CommandName = "ABRIR" Then
            Dim itmFila As GridViewRow = CType(grdDatos.Rows(e.CommandArgument + 20 * grdDatos.PageIndex), GridViewRow)
            pnlCajaBanco.Visible = True
            ctlCajaBanco.Limpiar()
            ctlCajaBanco.IdCliente = HttpUtility.HtmlDecode(itmFila.Cells(4).Text)
            ctlCajaBanco.IdProveedor = HttpUtility.HtmlDecode(itmFila.Cells(5).Text)
            If HttpUtility.HtmlDecode(itmFila.Cells(6).Text) = "FAC" Then
                ctlCajaBanco.IdTipoDocumentoDebe = HttpUtility.HtmlDecode(itmFila.Cells(2).Text)
                ctlCajaBanco.NumeroDocumentoDebe = HttpUtility.HtmlDecode(itmFila.Cells(11).Text)
                ctlCajaBanco.IdTipoDocumentoHaber = HttpUtility.HtmlDecode(itmFila.Cells(6).Text)
                ctlCajaBanco.NumeroDocumentoHaber = HttpUtility.HtmlDecode(itmFila.Cells(18).Text)
            End If
            If HttpUtility.HtmlDecode(itmFila.Cells(6).Text) = "FAP" Then
                ctlCajaBanco.IdTipoDocumentoHaber = HttpUtility.HtmlDecode(itmFila.Cells(2).Text)
                ctlCajaBanco.NumeroDocumentoHaber = HttpUtility.HtmlDecode(itmFila.Cells(11).Text)
                ctlCajaBanco.IdTipoDocumentoDebe = HttpUtility.HtmlDecode(itmFila.Cells(6).Text)
                ctlCajaBanco.NumeroDocumentoDebe = HttpUtility.HtmlDecode(itmFila.Cells(18).Text)
            End If

            ctlCajaBanco.DocumentoAcreedorHabilitado = False
            ctlCajaBanco.DocumentoDeudorHabilitado = False

            ctlCajaBanco.Importe = itmFila.Cells(12).Text
            ctlCajaBanco.Glosa = HttpUtility.HtmlDecode(itmFila.Cells(21).Text)
            ctlCajaBanco.IdOperacion = HttpUtility.HtmlDecode(itmFila.Cells(7).Text)
            ctlCajaBanco.IdSubOperacion = itmFila.Cells(8).Text
            ctlCajaBanco.OperacionHabilitado = False

        End If
    End Sub
End Class
