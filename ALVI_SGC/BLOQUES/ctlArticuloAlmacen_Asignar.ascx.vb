
Partial Class BLOQUES_ctlArticuloAlmacen_Asignar
    Inherits System.Web.UI.UserControl


    Private Sub CreateSchemaDetalle()
        Dim dtbDatos As New Data.DataTable
        dtbDatos.Columns.Add("chr_IdFamilia", GetType(String))
        dtbDatos.Columns.Add("var_IdSubFamilia", GetType(String))
        dtbDatos.Columns.Add("var_IdArticulo", GetType(String))
        dtbDatos.Columns.Add("var_Articulo", GetType(String))
        dtbDatos.Columns.Add("var_IdUnidadMedida", GetType(String))
        dtbDatos.Columns.Add("var_UnidadMedida", GetType(String))
        dtbDatos.Columns.Add("var_IdAlmacen", GetType(String))
        dtbDatos.Columns.Add("var_Almacen", GetType(String))
        dtbDatos.Columns.Add("var_IdCentroCosto", GetType(String))
        dtbDatos.Columns.Add("var_CentroCosto", GetType(String))
        dtbDatos.Columns.Add("var_IdCuentaGasto", GetType(String))
        dtbDatos.Columns.Add("var_CuentaGasto", GetType(String))
        dtbDatos.Columns.Add("num_Cantidad", GetType(Double))
        dtbDatos.Columns.Add("num_ImporteMoneda", GetType(Double))
        dtbDatos.Columns.Add("num_TipoCambio", GetType(Double))
        dtbDatos.Columns.Add("var_Moneda", GetType(String))
        dtbDatos.Columns.Add("num_Importe", GetType(Double))
        dtbDatos.Columns.Add("num_CostoUnitario", GetType(Double))
        dtbDatos.Columns.Add("var_Observacion", GetType(String))
        dtbDatos.Columns.Add("var_IdCliente", GetType(String))

        Dim pkDetalle(1) As Data.DataColumn
        pkDetalle(0) = dtbDatos.Columns("var_IdArticulo")
        dtbDatos.PrimaryKey = pkDetalle
        Session("dtbArticulos") = dtbDatos

    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        If txtCantidad.Text <> "" AndAlso _
        txtCostoUnitario.Text <> "" AndAlso _
        txtImporte.Text <> "" AndAlso ctlArticulo.IdArticulo <> "" AndAlso _
        ddlAlmacen.SelectedValue <> "" Then
            Dim dtbDatos As Data.DataTable = CType(Session("dtbArticulos"), Data.DataTable)
            Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
            dtrNuevo("chr_IdFamilia") = Left(ctlArticulo.IdArticulo, 4)
            dtrNuevo("var_IdSubFamilia") = Left(ctlArticulo.IdArticulo, 4)
            dtrNuevo("var_IdArticulo") = ctlArticulo.IdArticulo
            dtrNuevo("var_Articulo") = ctlArticulo.Descripcion
            dtrNuevo("var_IdUnidadMedida") = ctlArticulo.Metrica
            dtrNuevo("var_UnidadMedida") = ctlArticulo.NombreMetrica
            dtrNuevo("var_IdAlmacen") = ddlAlmacen.SelectedItem.Value
            dtrNuevo("var_Almacen") = ddlAlmacen.SelectedItem.Text
            dtrNuevo("var_Observacion") = txtObservacionDetalle.Text
            dtrNuevo("num_Cantidad") = txtCantidad.Text
            dtrNuevo("num_ImporteMoneda") = txtImporte.Text
            dtrNuevo("var_IdCliente") = ""
            If ddlMoneda.SelectedValue = "D" Then
                dtrNuevo("num_Importe") = txtImporte.Text * Session("TipoCambio")
                dtrNuevo("num_TipoCambio") = Session("TipoCambio")
            Else
                dtrNuevo("num_TipoCambio") = 1
                dtrNuevo("num_Importe") = txtImporte.Text
            End If
            dtrNuevo("var_Moneda") = ddlMoneda.SelectedValue
            dtrNuevo("num_CostoUnitario") = txtImporte.Text / txtCantidad.Text

            dtbDatos.LoadDataRow(dtrNuevo.ItemArray, True)
            dtbDatos.AcceptChanges()

            Limpiar()

            Session("dtbDatos") = dtbDatos
            grdDatos.DataSource = dtbDatos
            grdDatos.DataBind()
        End If
    End Sub

    Private Sub BindAlmacen()
        Dim objAlmacen As New ALVI_LOGIC.Maestros.Logistica.Almacen
        ddlAlmacen.Items.Clear()
        If objAlmacen.Listar() = True Then
            ddlAlmacen.DataValueField = "var_IdAlmacen"
            ddlAlmacen.DataTextField = "var_Descripcion"
            ddlAlmacen.DataSource = objAlmacen.Datos
            ddlAlmacen.DataBind()
        End If
        ddlAlmacen.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlAlmacen.SelectedIndex = 0
    End Sub

    Public Sub Limpiar()
        txtCantidad.Text = 0
        txtCostoUnitario.Text = 0
        txtImporte.Text = 0
        txtImporteMoneda.Text = 0
        ddlMoneda.SelectedIndex = 0
        txtObservacionDetalle.Text = ""
        ctlArticulo.IdArticulo = ""
        ctlArticulo.Descripcion = ""
        ctlArticulo.BuscarId()
        BindAlmacen()
    End Sub

    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        If e.CommandName = "Modificar" Then
            Limpiar()
            Dim dtbDatos As Data.DataTable = CType(Session("dtbArticulos"), Data.DataTable)
            For Each dtrItem As Data.DataRow In dtbDatos.Select("var_IdArticulo='" & e.CommandArgument.ToString & "'")
                BindAlmacen()
                ddlAlmacen.SelectedValue = dtrItem("var_IdAlmacen")

                ctlArticulo.IdArticulo = dtrItem("var_IdArticulo")
                ctlArticulo.BuscarId()

                txtObservacionDetalle.Text = dtrItem("var_Observacion")
                txtCantidad.Text = dtrItem("num_Cantidad")
                txtCostoUnitario.Text = dtrItem("num_CostoUnitario")
                txtImporteMoneda.Text = dtrItem("num_Importe")
                txtImporte.Text = dtrItem("num_ImporteMoneda")
                ddlMoneda.SelectedValue = dtrItem("var_Moneda")
            Next
        End If
        If e.CommandName = "Eliminar" Then
            Dim dtbRegistro As Data.DataTable = CType(Session("dtbArticulos"), Data.DataTable)
            CreateSchemaDetalle()
            Dim dtbNuevo As Data.DataTable = CType(Session("dtbArticulos"), Data.DataTable)
            Dim strItem As String = e.CommandArgument
            For Each dtrItem As Data.DataRow In dtbRegistro.Rows
                If dtrItem("var_IdArticulo") <> strItem Then
                    dtbNuevo.Rows.Add(dtrItem.ItemArray)
                    dtbNuevo.AcceptChanges()
                End If
            Next
            Session("dtbArticulos") = dtbNuevo
            grdDatos.DataSource = dtbNuevo
            grdDatos.DataBind()

        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Limpiar()
            CreateSchemaDetalle()
            grdDatos.DataSource = CType(Session("dtbArticulos"), Data.DataTable)
            grdDatos.DataBind()

        End If
    End Sub


    Protected Sub txtImporte_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtImporte.TextChanged
        If txtCantidad.Text <> "" AndAlso txtImporte.Text <> "" Then
            If IsNumeric(txtCantidad.Text) AndAlso IsNumeric(txtImporte.Text) Then
                If txtCantidad.Text > 0 AndAlso txtImporte.Text > 0 Then
                    txtCostoUnitario.Text = Format(txtImporte.Text / txtCantidad.Text, "0.00")
                Else
                    txtCostoUnitario.Text = "0.00"
                End If
            Else
                txtCostoUnitario.Text = "0.00"
            End If

        End If
    End Sub

    Protected Sub txtCantidad_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidad.TextChanged
        If txtCantidad.Text <> "" AndAlso txtImporte.Text <> "" Then
            If IsNumeric(txtCantidad.Text) AndAlso IsNumeric(txtImporte.Text) Then
                If txtCantidad.Text > 0 AndAlso txtImporte.Text > 0 Then
                    txtCostoUnitario.Text = Format(txtImporte.Text / txtCantidad.Text, "0.00")
                Else
                    txtCostoUnitario.Text = "0.00"
                End If
            Else
                txtCostoUnitario.Text = "0.00"
            End If

        End If
    End Sub

End Class
