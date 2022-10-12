
Partial Class Interfaces_FGLINDA
    Inherits System.Web.UI.Page


    Private Sub BinOperacion()
        Dim objTipoMovimiento As New ALVI_LOGIC.Maestros.Logistica.TipoMovimiento
        ddlOperacion.Items.Clear()
        If objTipoMovimiento.Listar1 = True Then
            ddlOperacion.DataSource = objTipoMovimiento.Datos
            ddlOperacion.DataValueField = "var_IdTipoMovimiento"
            ddlOperacion.DataTextField = "var_Descripcion"
            ddlOperacion.DataBind()
        End If

        ddlOperacion.SelectedValue = "I01"
        ddlOperacion.Enabled = False
    End Sub

    Private Sub BindDocumento()
        Dim objTipoDocumento As New ALVI_LOGIC.Maestros.Administracion.TipoDocumento
        ddlTipo.Items.Clear()
        If objTipoDocumento.Listar1 = True Then
            ddlTipo.DataSource = objTipoDocumento.Datos
            ddlTipo.DataTextField = "var_Descripcion"
            ddlTipo.DataValueField = "chr_IdTipoDocumento"
            ddlTipo.DataBind()

        End If
        ddlTipo.SelectedValue = "FAP"
        ddlTipo.Enabled = False
    End Sub

    Private Sub BindGrid()
        Dim dtbDatos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
        grdDatos.DataSource = dtbDatos
        grdDatos.DataBind()

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindDocumento()
            BinOperacion()
            btnEmision.Attributes.Add("onclick", "popUpCalendar(this, " & txtEmision.ClientID & ", 'dd/mm/yyyy');")
            btnVencimiento.Attributes.Add("onclick", "popUpCalendar(this, " & txtVencimiento.ClientID & ", 'dd/mm/yyyy');")

            Dim objSeguridad As New ALVI_Security.General
            If objSeguridad.Decrypta(Request("AC")) = "CCC" Then
                BindGrid()
            End If
        End If
    End Sub

    Protected Sub grdDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDatos.RowDataBound
        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    Dim ddlMoneda As DropDownList = CType(e.Row.FindControl("ddlMoneda"), DropDownList)
        '    Dim drvItem As Data.DataRowView = CType(e.Row.DataItem, Data.DataRowView)
        '    ddlMoneda.SelectedValue = drvItem("var_IdMoneda")

        'End If
    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        If txtEmision.Text <> "" AndAlso txtVencimiento.Text <> "" _
            AndAlso txtSerie.Text <> "" AndAlso txtNumero.Text <> "" _
            AndAlso ctlProveedor.IdProveedor <> "" AndAlso ddlMoneda.SelectedValue <> "" _
            AndAlso ddlOperacion.SelectedValue <> "" AndAlso ddlTipo.SelectedValue <> ""  Then
            'AndAlso txtSubTotal.Text <> "" AndAlso txtIGV.Text <> "" AndAlso txtTotal.Text <> ""

            Dim strFechaEmision() = txtEmision.Text.Split("/")
            Dim strFechaVencimiento() = txtVencimiento.Text.Split("/")
            Dim dtmFechaEmision As New Date(strFechaEmision(2), strFechaEmision(1), strFechaEmision(0))
            Dim dtmFechaVencimiento As New Date(strFechaVencimiento(2), strFechaVencimiento(1), strFechaVencimiento(0))

            If dtmFechaEmision > Now.Date Then
                ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('La fecha de emisión incorrecta');</script>")
                Exit Sub
            End If
            If dtmFechaVencimiento < dtmFechaEmision Then
                ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('La fecha de vencimiento incorrecta');</script>")
                Exit Sub
            End If

            '*******************************************
            'PREPARANDO LA INFORMACION A ENVIAR A LA BD
            '*******************************************
            Dim dtbArticulos As New Data.DataTable
            dtbArticulos.Columns.Add("var_IdRequisicion", GetType(String))
            dtbArticulos.Columns.Add("var_IdValeAlmacen", GetType(String))
            dtbArticulos.Columns.Add("var_IdDetalle", GetType(String))
            dtbArticulos.Columns.Add("var_IdArticulo", GetType(String))
            dtbArticulos.Columns.Add("var_Articulo", GetType(String))
            dtbArticulos.Columns.Add("var_IdUnidadMedida", GetType(String))
            dtbArticulos.Columns.Add("var_UnidadMedida", GetType(String))
            dtbArticulos.Columns.Add("var_IdArticuloProveedor", GetType(String))
            dtbArticulos.Columns.Add("var_NombreArticuloProveedor", GetType(String))
            dtbArticulos.Columns.Add("num_Cantidad", GetType(Double))
            dtbArticulos.Columns.Add("num_ImporteTotal", GetType(Double))
            dtbArticulos.Columns.Add("num_ImporteOrigen", GetType(Double))
            dtbArticulos.Columns.Add("var_IdMoneda", GetType(String))
            dtbArticulos.Columns.Add("dec_TipoCambio", GetType(Double))

            Dim pkDetalle(1) As Data.DataColumn
            pkDetalle(0) = dtbArticulos.Columns("var_IdDetalle")
            dtbArticulos.PrimaryKey = pkDetalle
            Dim hdnTipoCambio As HiddenField = CType(Master.Page.Form.FindControl("hdnTipoCambio"), HiddenField)

            txtTotal.Text = 0
            txtIGV.Text = 0
            txtSubTotal.Text = 0

            For Each grdItem As GridViewRow In grdDatos.Rows
                Dim txtImporte As TextBox = CType(grdItem.FindControl("txtImporte"), TextBox)
                If txtImporte.Text <> "" Then
                    Dim dtrNuevo As Data.DataRow = dtbArticulos.NewRow
                    dtrNuevo("var_IdRequisicion") = grdItem.Cells(0).Text
                    dtrNuevo("var_IdValeAlmacen") = grdItem.Cells(1).Text
                    dtrNuevo("var_IdDetalle") = grdItem.Cells(2).Text
                    dtrNuevo("var_IdArticulo") = grdItem.Cells(3).Text
                    dtrNuevo("var_Articulo") = grdItem.Cells(4).Text
                    dtrNuevo("var_IdUnidadMedida") = grdItem.Cells(5).Text
                    dtrNuevo("var_UnidadMedida") = grdItem.Cells(6).Text
                    dtrNuevo("var_IdArticuloProveedor") = CType(grdItem.Cells(7).FindControl("txtIdArticulo"), TextBox).Text
                    dtrNuevo("var_NombreArticuloProveedor") = CType(grdItem.Cells(8).FindControl("txtArticulo"), TextBox).Text
                    dtrNuevo("num_Cantidad") = CType(grdItem.Cells(9).FindControl("txtCantidad"), TextBox).Text
                    dtrNuevo("num_ImporteOrigen") = CType(grdItem.Cells(10).FindControl("txtImporte"), TextBox).Text
                    dtrNuevo("var_IdMoneda") = ddlMoneda.SelectedValue
                    dtrNuevo("dec_TipoCambio") = grdItem.Cells(11).Text
                    dtrNuevo("num_ImporteTotal") = dtrNuevo("num_ImporteOrigen")
                    If ddlMoneda.SelectedValue = "DOL" Then
                        dtrNuevo("num_ImporteTotal") = dtrNuevo("num_ImporteOrigen") * grdItem.Cells(11).Text
                    End If

                    dtbArticulos.LoadDataRow(dtrNuevo.ItemArray, True)

                    txtSubTotal.Text = CDbl(txtSubTotal.Text) + CDbl(dtrNuevo("num_ImporteOrigen"))
                End If
            Next
            '*******************************************
            txtTotal.Text = CDbl(txtSubTotal.Text) * 118 / 100
            txtIGV.Text = CDbl(txtSubTotal.Text) * 18 / 100

            If dtbArticulos.Rows.Count Then
                Dim objDocumento As New ALVI_LOGIC.Proceso.Logistica.Documento

                objDocumento.IdDocumentoCompra = txtCodigo.Text
                objDocumento.FechaEmision = txtEmision.Text
                objDocumento.FechaVencimiento = txtVencimiento.Text
                objDocumento.IdProveedor = ctlProveedor.IdProveedor
                objDocumento.TipoDocumento = ddlTipo.SelectedValue
                objDocumento.Moneda = ddlMoneda.SelectedValue
                objDocumento.Operacion = ddlOperacion.SelectedValue
                objDocumento.Numero = txtSerie.Text + "-" + txtNumero.Text
                objDocumento.IGV = txtIGV.Text
                objDocumento.Otros = 0
                objDocumento.Subtotal = txtSubTotal.Text
                objDocumento.Total = txtTotal.Text
                objDocumento.Estado = "ACT"

                If objDocumento.Registrar(dtbArticulos) Then
                    Dim intRegistros As Int16 = 0
                    ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('Registro exitoso.');</script>")
                End If
            End If
        End If
    End Sub
End Class
