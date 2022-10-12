Imports System.Data
Imports System.Data.DataRow
Imports System.Data.SqlClient
Partial Class Interfaces_FGLINDC
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ctlElementoReferencial_Buscar1.Titulo = "Articulo"
            ctlUnidadMedida_Buscar1.Titulo = "Unidad de consumo"
            pnlFormulario.Visible = False
            BindDocumento()
            datable()
            BinOpeacion()
            btnFechaEmisionInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmisionInicio.ClientID & ", 'dd/mm/yyyy');")
            btnFechaVencimientoInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaVencimientoInicio.ClientID & ", 'dd/mm/yyyy');")

           
            btnBuscar.Attributes.Add("onclick", "javascript:return Buscar('" & hdnIdComprar.ClientID & "');")

            If Request("var_IdDocumentoCompra") <> "" Then
                Dim objSeguridad As New ALVI_Security.General
                hdnIdComprar.Value = objSeguridad.Decrypta(Request("var_IdDocumentoCompra"))
                Buscar()
            End If


        End If

    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTerminar.Click
        RegistrarArticulo()
        Cancelar()

    End Sub


    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        txtFechaEmisionInicio.Text = Format(Now.Date, "dd/MM/yyyy")
        btnFechaEmisionInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmisionInicio.ClientID & ", 'dd/mm/yyyy');")

        txtFechaVencimientoInicio.Text = Format(Now.Date, "dd/MM/yyyy")
        btnFechaVencimientoInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaVencimientoInicio.ClientID & ", 'dd/mm/yyyy');")
        pnlFormulario.Visible = False
        
        datable()

        Dim dtbDatos As Data.DataTable = CType(Session("datos"), Data.DataTable)

        grdDatos.DataSource = dtbDatos
        grdDatos.DataBind()

        Dim datableDocumentos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)

        Limpia()

    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        CancelarArticulo()
    End Sub

    Private Sub CancelarArticulo()
        pnlFormulario.Visible = False
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        Buscar()
    End Sub

    Private Sub Cancelar()
        pnlFormulario.Visible = False
    End Sub

    Protected Sub btnAsignar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAsignar.Click
        pnlFormulario.Visible = True
        txtTipoCambio.Text = Session("TipoCambio")

    End Sub

    Protected Sub btnRegistrar_Formulario_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar_Formulario.Click
        RegistrarArticulo()

    End Sub
    Private Sub RegistrarArticulo()
        Dim dtbDatos As Data.DataTable = CType(Session("datos"), Data.DataTable)

        Dim row As Data.DataRow = dtbDatos.NewRow
        Dim correlativo As Integer
        If (hdnIdCorrelativo1.Value = "") Then

            correlativo = row.Table.Rows.Count
            correlativo = correlativo + 1

            row("var_IdDetalle") = correlativo
            row("var_IdArticulo") = ctlElementoReferencial_Buscar1.idArticulo
            row("var_Articulo") = ctlElementoReferencial_Buscar1.Nombre
            row("int_Cantidad") = txtCantidad.Text
            row("var_IdUnidadMedida") = ctlUnidadMedida_Buscar1.IdUnidadMedida
            row("var_UnidadMedida") = ctlUnidadMedida_Buscar1.Nombre
            row("var_IdArticuloProveedor") = txtIdArticuloProveedor.Text
            row("var_NombreArticuloProveedor") = txtNombreArticuloProveedor.Text

            row("num_ImporteTotal") = txtImporte.Text
            row("dec_TipoCambio") = txtTipoCambio.Text
            row("var_IdMoneda") = ddlMonedaFormulario.SelectedValue
            row("num_ImporteOrigen") = txtImporteOrigen.Text


            dtbDatos.LoadDataRow(row.ItemArray, True)
            dtbDatos.AcceptChanges()
            LimpiarFormulario()

            Session("datos") = dtbDatos

            grdDatos.DataSource = dtbDatos
            grdDatos.DataBind()

        Else
            row("var_IdDetalle") = hdnIdCorrelativo1.Value
            row("var_IdArticulo") = ctlElementoReferencial_Buscar1.idArticulo
            row("var_Articulo") = ctlElementoReferencial_Buscar1.Nombre
            row("int_Cantidad") = txtCantidad.Text
            row("var_IdUnidadMedida") = ctlUnidadMedida_Buscar1.IdUnidadMedida
            row("var_UnidadMedida") = ctlUnidadMedida_Buscar1.Nombre
            row("var_IdArticuloProveedor") = txtIdArticuloProveedor.Text
            row("var_NombreArticuloProveedor") = txtNombreArticuloProveedor.Text

            row("num_ImporteTotal") = txtImporte.Text
            row("dec_TipoCambio") = txtTipoCambio.Text
            row("var_IdMoneda") = ddlMonedaFormulario.SelectedValue
            row("num_ImporteOrigen") = txtImporteOrigen.Text

            dtbDatos.LoadDataRow(row.ItemArray, True)
            dtbDatos.AcceptChanges()
            LimpiarFormulario()

            Session("datos") = dtbDatos

            grdDatos.DataSource = dtbDatos
            grdDatos.DataBind()

        End If
    End Sub
    Private Sub Limpia()
        txtCodigo.Text = ""
        txtFechaEmisionInicio.Text = ""
        txtFechaVencimientoInicio.Text = ""
        ctlProveedor_Buscar1.IdProveedor = ""
        ctlProveedor_Buscar1.RazonSocial = ""
        ddlTipo.SelectedIndex = 0
        ddlMoneda.SelectedIndex = 0
        ddlOperacion.SelectedIndex = 0
        txtNumero2.Text = ""
        txtIGV.Text = ""
        txtSubTotal.Text = ""
        txtTotal.Text = ""
        txtNumero1.Text = ""

    End Sub

    Private Sub LimpiarFormulario()
        ctlElementoReferencial_Buscar1.Limpia()
        ctlUnidadMedida_Buscar1.Limpia()
        txtCantidad.Text = ""
        txtIdArticuloProveedor.Text = ""
        txtNombreArticuloProveedor.Text = ""
        txtImporteOrigen.Text = ""
        txtTipoCambio.Text = ""
        txtImporte.Text = ""

    End Sub

    Private Sub BindDocumento()
        Dim objTipoDocumento As New ALVI_LOGIC.Maestros.Administracion.TipoDocumento
        ddlTipo.Items.Clear()
        objTipoDocumento.Clasificacion = "I"
        If objTipoDocumento.Listar = True Then
            ddlTipo.DataSource = objTipoDocumento.Datos
            ddlTipo.DataTextField = "var_Descripcion"
            ddlTipo.DataValueField = "chr_IdTipoDocumento"
            ddlTipo.DataBind()

        End If
        ddlTipo.SelectedValue = "FAP"
        ddlTipo.Enabled = False
    End Sub


    Private Sub BinOpeacion()
        Dim objTipoMovimiento As New ALVI_LOGIC.Maestros.Logistica.TipoMovimiento
        ddlOperacion.Items.Clear()
        objTipoMovimiento.Clasificacion = "I"
        If objTipoMovimiento.Listar = True Then
            ddlOperacion.DataSource = objTipoMovimiento.Datos
            ddlOperacion.DataValueField = "var_IdTipoMovimiento"
            ddlOperacion.DataTextField = "var_Descripcion"
            ddlOperacion.DataBind()

        End If
        ddlOperacion.SelectedValue = "I01"
        ddlOperacion.Enabled = False
    End Sub

    Private Sub BindGrid()
        datable()

        Dim objDocumentoArticulo As New ALVI_LOGIC.Proceso.Logistica.Detalle
        objDocumentoArticulo.IdDocumentoCompra = txtCodigo.Text

        Dim dtbDatos As Data.DataTable = CType(Session("datos"), Data.DataTable)
        If objDocumentoArticulo.Listar Then


            Dim objUnidadMedida As New ALVI_LOGIC.Configuracion.UnidadMedida
            Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Articulo
            For Each dtrItem As Data.DataRow In objDocumentoArticulo.Datos.Rows

                Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                dtrNuevo("var_IdDetalle") = dtrItem("var_IdDetalle")
                dtrNuevo("var_IdArticulo") = dtrItem("var_IdArticuloReferencia")
                objArticulo.IdArticulo = dtrItem("var_IdArticuloReferencia")
                objArticulo.Obtener1()
                dtrNuevo("var_Articulo") = objArticulo.Descripcion
                dtrNuevo("var_IdUnidadMedida") = dtrItem("var_IdUnidadMedida")
                objUnidadMedida.IdUnidadMedida = dtrItem("var_IdUnidadMedida")
                objUnidadMedida.Obtener1()
                dtrNuevo("var_UnidadMedida") = objUnidadMedida.Descripcion

                dtrNuevo("var_IdArticuloProveedor") = dtrItem("var_IdArticuloProveedor")
                dtrNuevo("var_NombreArticuloProveedor") = dtrItem("var_NombreArticuloProveedor")
                dtrNuevo("int_Cantidad") = dtrItem("int_Cantidad")
                dtrNuevo("num_ImporteTotal") = dtrItem("num_ImporteTotal")
                dtrNuevo("num_ImporteOrigen") = dtrItem("num_ImporteOrigen")
                dtrNuevo("var_IdMoneda") = dtrItem("var_IdMoneda")
                dtrNuevo("dec_TipoCambio") = dtrItem("dec_TipoCambio")

                dtbDatos.LoadDataRow(dtrNuevo.ItemArray, True)
                dtbDatos.AcceptChanges()

            Next

        End If

        Session("datos") = dtbDatos
        grdDatos.DataSource = dtbDatos
        grdDatos.DataBind()


    End Sub

    Private Sub datable()

        Dim dtbDatos As New DataTable
        dtbDatos.Columns.Add("var_IdDetalle", GetType(String))
        dtbDatos.Columns.Add("var_IdArticulo", GetType(String))
        dtbDatos.Columns.Add("var_Articulo", GetType(String))
        dtbDatos.Columns.Add("var_IdUnidadMedida", GetType(String))
        dtbDatos.Columns.Add("var_UnidadMedida", GetType(String))
        dtbDatos.Columns.Add("var_IdArticuloProveedor", GetType(String))
        dtbDatos.Columns.Add("var_NombreArticuloProveedor", GetType(String))
        dtbDatos.Columns.Add("int_Cantidad", GetType(Double))
        dtbDatos.Columns.Add("num_ImporteTotal", GetType(Double))
        dtbDatos.Columns.Add("num_ImporteOrigen", GetType(Double))
        dtbDatos.Columns.Add("var_IdMoneda", GetType(String))
        dtbDatos.Columns.Add("dec_TipoCambio", GetType(Double))

        Dim pkDetalle(1) As Data.DataColumn
        pkDetalle(0) = dtbDatos.Columns("var_IdDetalle")
        dtbDatos.PrimaryKey = pkDetalle

        Session("datos") = dtbDatos

    End Sub

    Private Sub Buscar()
        Dim objDocumento As New ALVI_LOGIC.Proceso.Logistica.Documento
        Dim objDetalle As New ALVI_LOGIC.Proceso.Logistica.Detalle

        objDocumento.IdDocumentoCompra = hdnIdComprar.Value

        If objDocumento.Obtener Then
            txtCodigo.Text = objDocumento.IdDocumentoCompra
            txtFechaEmisionInicio.Text = objDocumento.FechaEmision
            txtFechaVencimientoInicio.Text = objDocumento.FechaVencimiento
            ctlProveedor_Buscar1.IdProveedor = objDocumento.IdProveedor
            ctlProveedor_Buscar1.BuscarId()
            ddlTipo.SelectedValue = objDocumento.TipoDocumento
            ddlMoneda.SelectedValue = objDocumento.Moneda
            ddlOperacion.SelectedValue = objDocumento.Operacion
            txtNumero1.Text = objDocumento.Numero
            txtIGV.Text = objDocumento.IGV
            txtSubTotal.Text = objDocumento.Subtotal
            txtTotal.Text = objDocumento.Total


            objDetalle.IdDocumentoCompra = hdnIdComprar.Value
            objDetalle.Listar()
            Session("datos") = objDetalle.Datos
            BindGrid()
        End If

    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        If txtFechaEmisionInicio.Text <> "" AndAlso txtFechaVencimientoInicio.Text <> "" _
            AndAlso txtNumero1.Text <> "" AndAlso txtNumero2.Text <> "" AndAlso ctlProveedor_Buscar1.IdProveedor <> "" AndAlso ddlMoneda.SelectedValue <> "" _
            AndAlso ddlOperacion.SelectedValue <> "" AndAlso ddlTipo.SelectedValue <> "" AndAlso txtSubTotal.Text <> "" _
            AndAlso txtIGV.Text <> "" AndAlso txtTotal.Text <> "" Then

            Dim strFechaEmision() = txtFechaEmisionInicio.Text.Split("/")
            Dim strFechaVencimiento() = txtFechaVencimientoInicio.Text.Split("/")
            Dim dtmFechaEmision As New Date(strFechaEmision(2), strFechaEmision(1), strFechaEmision(0))
            Dim dtmFechaVencimiento As New Date(strFechaVencimiento(2), strFechaVencimiento(1), strFechaVencimiento(0))

            If dtmFechaEmision > Now.Date Then
                ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('La fecha no permitida');</script>")
                If dtmFechaVencimiento > Now.Date Then
                    ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('La fecha no permitida');</script>")
                End If
                Exit Sub

            End If
            Dim dtbDatos As Data.DataTable = CType(Session("datos"), Data.DataTable)
            'Dim Datos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)

            If dtbDatos.Rows.Count Then
                Dim objDocumento As New ALVI_LOGIC.Proceso.Logistica.Documento

                objDocumento.IdDocumentoCompra = txtCodigo.Text
                objDocumento.FechaEmision = txtFechaEmisionInicio.Text
                objDocumento.FechaVencimiento = txtFechaVencimientoInicio.Text
                objDocumento.IdProveedor = ctlProveedor_Buscar1.IdProveedor
                objDocumento.TipoDocumento = ddlTipo.SelectedValue
                objDocumento.Moneda = ddlMoneda.SelectedValue
                objDocumento.Operacion = ddlOperacion.SelectedValue
                objDocumento.Numero = txtNumero1.Text + "-" + txtNumero2.Text
                objDocumento.IGV = txtIGV.Text
                objDocumento.Otros = 0
                objDocumento.Subtotal = txtSubTotal.Text
                objDocumento.Total = txtTotal.Text
                objDocumento.Estado = "ACT"

                If objDocumento.Registrar(dtbDatos) Then
                    Dim intRegistros As Int16 = 0
                    ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('Registro exitoso.');</script>")
                End If

            End If

        End If

    End Sub

    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        If e.CommandName = "Modificar" Then
            pnlFormulario.Visible = True
            Dim dtbDatos As Data.DataTable = CType(Session("datos"), Data.DataTable)
            For Each dtrItem As Data.DataRow In dtbDatos.Select("var_IdDetalle='" & e.CommandArgument.ToString & "'")
                ctlElementoReferencial_Buscar1.idArticulo = dtrItem("var_IdDetalle")
                ctlElementoReferencial_Buscar1.BuscarId()

                ctlElementoReferencial_Buscar1.idArticulo = dtrItem("var_IdArticulo")
                ctlElementoReferencial_Buscar1.BuscarId()
                txtIdArticuloProveedor.Text = dtrItem("var_IdArticuloProveedor")
                txtNombreArticuloProveedor.Text = dtrItem("var_NombreArticuloProveedor")

                ctlUnidadMedida_Buscar1.IdUnidadMedida = dtrItem("var_IdUnidadMedida")
                ctlUnidadMedida_Buscar1.BuscarId()


                txtTipoCambio.Text = dtrItem("dec_TipoCambio")
                txtImporteOrigen.Text = dtrItem("num_ImporteOrigen")
                ddlMonedaFormulario.SelectedValue = dtrItem("var_IdMoneda")
                txtCantidad.Text = dtrItem("int_Cantidad")
                txtImporte.Text = dtrItem("num_ImporteTotal")
            Next
        End If

        If e.CommandName = "Eliminar" Then
            Dim dtbRegistro As Data.DataTable = CType(Session("datos"), Data.DataTable)
            datable()
            Dim dtbNuevo As Data.DataTable = CType(Session("datos"), Data.DataTable)
            Dim strItem As String = e.CommandArgument
            For Each dtrItem As Data.DataRow In dtbRegistro.Rows
                If dtrItem("var_IdDetalle") <> strItem Then
                    dtbNuevo.Rows.Add(dtrItem.ItemArray)
                    dtbNuevo.AcceptChanges()
                End If
            Next

            Session("datos") = dtbNuevo
            grdDatos.DataSource = dtbNuevo
            grdDatos.DataBind()

        End If
    End Sub

    Protected Sub grdDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDatos.RowDataBound
        If e.Row.RowType = DataControlRowType.Header Then
            txtSubTotal.Text = 0
            txtIGV.Text = 0
            txtTotal.Text = 0
        ElseIf e.Row.RowType = DataControlRowType.DataRow Then
            Dim drvItem As Data.DataRowView = CType(e.Row.DataItem, Data.DataRowView)
            txtSubTotal.Text = Format(CDbl(txtSubTotal.Text) + drvItem("num_ImporteOrigen"), "#,##0.00")
            txtIGV.Text = Format(txtSubTotal.Text * 0.18, "#,##0.00")
            txtTotal.Text = Format(txtSubTotal.Text * 1.18, "#,##0.00")
        End If
    End Sub

    Protected Sub ddlMonedaFormulario_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMonedaFormulario.SelectedIndexChanged
        Conversion()
    End Sub

    Private Sub Conversion()
        If ddlMonedaFormulario.SelectedValue = "D" AndAlso txtTipoCambio.Text <> "" AndAlso txtImporteOrigen.Text <> "" Then
            txtImporte.Text = Format(CDbl(txtImporteOrigen.Text) * CDbl(txtTipoCambio.Text), "0.00")
        End If
        If ddlMonedaFormulario.SelectedValue = "S" AndAlso txtTipoCambio.Text <> "" AndAlso txtImporteOrigen.Text <> "" Then
            txtImporte.Text = Format(CDbl(txtImporteOrigen.Text), "0.00")
        End If

    End Sub

    Protected Sub txtImporteOrigen_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtImporteOrigen.TextChanged
        Conversion()
    End Sub

    Protected Sub txtTipoCambio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTipoCambio.TextChanged
        Conversion()
    End Sub
End Class
