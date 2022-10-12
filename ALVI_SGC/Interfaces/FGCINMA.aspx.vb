
Imports System.Data
Imports System.Data.DataRow
Imports System.Data.SqlClient
Imports System.Drawing.Text

Partial Class Interfaces_FGCINMA
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlDocumento.Visible = False
            BinOpeacion()
            BindTipoDocumento()
            txtCodigo.Enabled = False
            txtFechaEmision.Text = Format(Now.Date, "dd/MM/yyyy")
            btnFechaEmision.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmision.ClientID & ", 'dd/mm/yyyy');")
            pnlFormulario.Visible = False
            btnFechaEmision.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmision.ClientID & ", 'dd/mm/yyyy');")

            BindDocumento()
            btnBuscar.Attributes.Add("onclick", "javascript:return Buscar('" & hdnIdVale.ClientID & "');")
            btnImprimir.Attributes.Add("onclick", "javascript:return Buscar('" & hdnIdKardex.ClientID & "');")

            If Request("IdVale") <> "" Then
                Dim objSeguridad As New ALVI_Security.General
                hdnIdVale.Value = objSeguridad.Decrypta(Request("IdVale"))
                Buscar()
            Else
                datable()
                datableDocumentos()
                BindGrid()
                BindGridDocumento()
            End If



        End If
    End Sub
    Private Sub BindCuentaGasto(ByRef ddlCuentaGasto As DropDownList)
        Dim objAcceso As New ALVI_Security.Accesos.AccesoPerfil
        Dim objCuentaGasto As New ALVI_LOGIC.Configuracion.CuentaGasto
        objCuentaGasto.Listar()
        Dim dtbDatos As Data.DataTable = objAcceso.FiltrarAccesos(objCuentaGasto.Datos, Session("IdPerfil"), "B", "var_IdCuentaGasto")

        Dim dtvDatos As New Data.DataView(dtbDatos, "", "var_IdCuentaGasto ASC", Data.DataViewRowState.OriginalRows)
        ddlCuentaGasto.DataSource = dtvDatos
        ddlCuentaGasto.DataTextField = "var_Descripcion"
        ddlCuentaGasto.DataValueField = "var_IdCuentaGasto"
        ddlCuentaGasto.DataBind()

        ddlCuentaGasto.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlCuentaGasto.SelectedIndex = 0

    End Sub

    Private Sub BindAlmacen(ByRef ddlAlmacen As DropDownList)
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

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click

        If txtFechaEmision.Text <> "" AndAlso txtNumeroDocumento.Text <> "" _
         AndAlso ddlOperacion.SelectedValue <> "" _
         AndAlso ddlTipoDocumento.SelectedValue <> "" Then
            Dim strFecha() = txtFechaEmision.Text.Split("/")
            Dim dtmFecha As New Date(strFecha(2), strFecha(1), strFecha(0))


            If dtmFecha > Now.Date Then
                ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('La fecha no permitida');</script>")
                Exit Sub
            End If

            Dim dtbDatos As Data.DataTable = CType(Session("datos"), Data.DataTable)

            For Each grdItem As GridViewRow In grdDatos.Rows
                Dim txtCantidadSalida As TextBox = CType(grdItem.FindControl("txtCantidadSalida"), TextBox)
                If txtCantidadSalida.Text <> "" Then
                    Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow

                    dtrNuevo("var_IdArticulo") = grdItem.Cells(0).Text
                    dtrNuevo("var_Articulo") = grdItem.Cells(1).Text
                    dtrNuevo("var_IdUnidadMedida") = grdItem.Cells(2).Text
                    dtrNuevo("var_UnidadMedida") = grdItem.Cells(3).Text
                    dtrNuevo("num_Cantidad") = txtCantidadSalida.Text
                    dtrNuevo("var_IdCentroCosto") = ctlCentroCosto_Buscar1.IdCentroCosto
                    dtrNuevo("var_IdAlmacen") = CType(grdItem.Cells(6).FindControl("ddlAlmacen"), DropDownList).SelectedValue
                    dtrNuevo("var_IdCuentaGasto") = CType(grdItem.Cells(7).FindControl("ddlCuentaGasto"), DropDownList).SelectedValue
                    dtbDatos.LoadDataRow(dtrNuevo.ItemArray, True)
                    dtbDatos.AcceptChanges()
                End If


                'If grdItem.Cells(8).Text = "" Then
                '    dtrNuevo("num_ImporteMoneda") = 0
                'Else
                '    dtrNuevo("num_ImporteMoneda") = Convert.ToDouble(grdItem.Cells(8).Text)
                'End If
                'If grdItem.Cells(9).Text = "" Then
                '    dtrNuevo("num_TipoCambio") = 0
                'Else
                '    dtrNuevo("num_TipoCambio") = Convert.ToDouble(grdItem.Cells(9).Text)
                'End If
                'If grdItem.Cells(10).Text = "" Then
                '    dtrNuevo("var_Moneda") = 0
                'Else
                '    dtrNuevo("var_Moneda") = Convert.ToDouble(grdItem.Cells(10).Text)
                'End If
                'If grdItem.Cells(11).Text = "" Then
                '    dtrNuevo("num_Importe") = 0
                'Else
                '    dtrNuevo("num_Importe") = Convert.ToDouble(grdItem.Cells(11).Text)
                'End If

                'If grdItem.Cells(12).Text = "" Then
                '    dtrNuevo("num_CostoUnitario") = 0
                'Else
                '    dtrNuevo("num_CostoUnitario") = Convert.ToDouble(grdItem.Cells(12).Text)
                'End If

                'dtrNuevo("var_Observacion") = Convert.ToDouble(grdItem.Cells(13).Text)

               
            Next


         

            If dtbDatos.Rows.Count > 0 Then
                Dim objMovimiento As New ALVI_LOGIC.Proceso.Logistica.Kardex.Movimiento
                Dim objDetalle As New ALVI_LOGIC.Proceso.Logistica.Kardex.Detalle

                objMovimiento.IdKardex = Right(strFecha(2), 2) & strFecha(1)
                objMovimiento.FechaOperacion = txtFechaEmision.Text
                objMovimiento.IdOrdenProduccion = txtOPReferencia.Text
                objMovimiento.IdTipoDocumento = ddlTipoDocumento.SelectedValue
                objMovimiento.IdTipoMovimiento = ddlOperacion.SelectedValue
                objMovimiento.NumeroDocumento = txtNumeroDocumento.Text
                objMovimiento.Observacion = txtObservacionGeneral.Text
                objMovimiento.Usuario = Session("Usuario")
                objMovimiento.Estado = "ACT"
                If objMovimiento.MovimientoAlmacen(dtbDatos) Then
                    Dim intRegistros As Int16 = 0
                    ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('Registro exitoso.');</script>")
                    hdnIdKardex.Value = objMovimiento.IdKardex
                    txtIdKardex.Text = objMovimiento.IdKardex
                    txtCodigo.Text = objMovimiento.IdKardex
                End If
            End If


        End If




    End Sub



    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTerminar.Click
        RegitraArticulo()
        Cancelar()

    End Sub


    Private Sub Cancelar()
        pnlFormulario.Visible = False
    End Sub


    Private Sub Buscar()

        Dim objVale As New ALVI_LOGIC.Maestros.Logistica.Vale
        objVale.IdValeAlemacen = hdnIdVale.Value
        If objVale.Obtener Then

            txtOPReferencia.Text = objVale.IdValeAlemacen
            ddlOperacion.SelectedValue = objVale.Operacion
            txtFechaEmision.Text = objVale.FechaEmision
            ctlSolicitante_Buscar1.IdSolicitante = objVale.IdSolicitante
            ctlSolicitante_Buscar1.BuscarId()

            ctlCentroCosto_Buscar1.IdCentroCosto = objVale.IdCentroCosto
            ctlCentroCosto_Buscar1.BuscarId()
            BindGrid()
            BindGridDocumento()


        End If

    End Sub

    Private Sub BindGrid()
        datable()
        datableDocumentos()
        Dim objVale As New ALVI_LOGIC.Maestros.Logistica.Vale
        Dim objValeArticulo As New ALVI_LOGIC.Maestros.Logistica.ValeArticulo


        objValeArticulo.IdValeAlmacen = txtOPReferencia.Text

        Dim dtbDatos As Data.DataTable = CType(Session("datos"), Data.DataTable)
        If objValeArticulo.Listar Then

            Dim objUnidadMedida As New ALVI_LOGIC.Configuracion.UnidadMedida
            Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Articulo
            Dim objKardexDetalle As New ALVI_LOGIC.Proceso.Logistica.Kardex.Detalle

            For Each dtrItem As Data.DataRow In objValeArticulo.Datos.Rows
                Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow


                dtrNuevo("var_IdArticulo") = dtrItem("var_IdArticulo")
                objArticulo.IdArticulo = dtrItem("var_IdArticulo")
                objArticulo.Obtener1()
                dtrNuevo("var_Articulo") = objArticulo.Descripcion
                'objKardexDetalle.Obtener()
                dtrNuevo("var_IdAlmacen") = objKardexDetalle.IdAlmacen
                dtrNuevo("var_IdCuentaGasto") = objKardexDetalle.IdCuentaGasto
                'dtrNuevo("num_ImporteMoneda") = objKardexDetalle.ImporteMoneda
                'dtrNuevo("num_TipoCambio") = objKardexDetalle.TipoCambio
                'dtrNuevo("var_Moneda") = objKardexDetalle.Moneda
                'dtrNuevo("num_Importe") = objKardexDetalle.Importe
                'dtrNuevo("num_CostoUnitario") = objKardexDetalle.CostoUnitario
                'dtrNuevo("var_Observacion") = objKardexDetalle.Observacion
                dtrNuevo("var_IdUnidadMedida") = dtrItem("var_IdUnidadMedida")
                objUnidadMedida.IdUnidadMedida = dtrItem("var_IdUnidadMedida")
                objUnidadMedida.Obtener1()
                dtrNuevo("var_UnidadMedida") = objUnidadMedida.Descripcion

                'For Each row As GridView In grdDatos.Rows

                '    Dim txtCantidadArticulo As TextBox = CType(row.FindControl("txtCantidadSalida"), TextBox)

                '    If txtCantidadArticulo.Text = "" Then
                '        dtrNuevo("num_Cantidad") = "0"

                '    Else
                '        dtrNuevo("num_Cantidad") = txtCantidadArticulo.Text

                '    End If

                'Next

                dtrNuevo("num_Cantidad") = dtrItem("int_Cantidad")


                dtbDatos.LoadDataRow(dtrNuevo.ItemArray, True)
                dtbDatos.AcceptChanges()
            Next

        End If


        Session("datos") = dtbDatos
        grdDatos.DataSource = dtbDatos
        grdDatos.DataBind()




    End Sub



    Private Sub BindGridDocumento()
        datableDocumentos()
        Dim objValeDocumento As New ALVI_LOGIC.Maestros.Logistica.ValeDocumento
        objValeDocumento.IdValeAlemacen = txtCodigo.Text

        Dim dtbDatos1 As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
        If objValeDocumento.Listar Then
            Dim objTipoDocumento As New ALVI_LOGIC.Maestros.Administracion.TipoDocumento

            For Each dtrItem As Data.DataRow In objValeDocumento.Datos.Rows()

                Dim dtrNuevo As Data.DataRow = dtbDatos1.NewRow

                objTipoDocumento.IdTipoDocumento = dtrItem("chr_IdTipoDocumento")
                objTipoDocumento.Obtener()
                dtrNuevo("chr_IdTipoDocumento") = objTipoDocumento.IdTipoDocumento
                dtrNuevo("var_TipoDocumento") = objTipoDocumento.Descripcion
                dtrNuevo("var_IdNumeroDocumento") = dtrItem("var_IdNumeroDocumento")

                dtbDatos1.LoadDataRow(dtrNuevo.ItemArray, True)
                dtbDatos1.AcceptChanges()

            Next

        End If

        Session("dtbDatos") = dtbDatos1
        grdDatosDocumentos.DataSource = dtbDatos1
        grdDatosDocumentos.DataBind()

    End Sub







    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        pnlFormulario.Visible = False

    End Sub
    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        Buscar()
    End Sub



    Private Sub BinOpeacion()
        Dim objTipoMovimiento As New ALVI_LOGIC.Maestros.Logistica.TipoMovimiento
        ddlOperacion.Items.Clear()
        If objTipoMovimiento.Listar1 Then
            Dim dtrvMovimientos As New Data.DataView(objTipoMovimiento.Datos, "chr_Clase='S'", "", DataViewRowState.OriginalRows)

            ddlOperacion.DataSource = dtrvMovimientos
            ddlOperacion.DataValueField = "var_IdTipoMovimiento"
            ddlOperacion.DataTextField = "var_Descripcion"

        End If

        ddlOperacion.Items.Insert(0, New ListItem("Selecionar", ""))
        ddlOperacion.DataBind()

    End Sub
    Private Sub BindDocumento()
        Dim objTipoDocumento As New ALVI_LOGIC.Maestros.Administracion.TipoDocumento


        ddlTipo.Items.Clear()


        If objTipoDocumento.Listar1 = True Then
            'Dim dtrvDocumentos As New Data.DataView(objTipoDocumento.Datos, "chr_Clase='S'", "", DataViewRowState.OriginalRows)
            ddlTipo.DataSource = objTipoDocumento.Datos
            ddlTipo.DataTextField = "var_Descripcion"
            ddlTipo.DataValueField = "chr_IdTipoDocumento"
            ddlTipo.DataBind()

        End If
        ddlTipo.Items.Insert(0, New ListItem("Selecionar", ""))
        ddlTipo.SelectedIndex = 0

    End Sub



    Private Sub datable()

        Dim dtbDatos As New DataTable

        dtbDatos.Columns.Add("var_IdArticulo", GetType(String))
        dtbDatos.Columns.Add("var_Articulo", GetType(String))
        dtbDatos.Columns.Add("var_IdUnidadMedida", GetType(String))
        dtbDatos.Columns.Add("var_UnidadMedida", GetType(String))
        dtbDatos.Columns.Add("num_Cantidad", GetType(Integer))
        dtbDatos.Columns.Add("var_IdCentroCosto", GetType(String))
        dtbDatos.Columns.Add("var_IdAlmacen", GetType(String))
        dtbDatos.Columns.Add("var_IdCuentaGasto", GetType(String))
        'dtbDatos.Columns.Add("num_ImporteMoneda", GetType(Double))
        'dtbDatos.Columns.Add("num_TipoCambio", GetType(Double))
        'dtbDatos.Columns.Add("var_Moneda", GetType(String))
        'dtbDatos.Columns.Add("num_Importe", GetType(Double))
        'dtbDatos.Columns.Add("num_CostoUnitario", GetType(Double))
        'dtbDatos.Columns.Add("var_Observacion", GetType(String))

        Dim pkDetalle(1) As Data.DataColumn
        pkDetalle(0) = dtbDatos.Columns("var_IdArticulo")
        dtbDatos.PrimaryKey = pkDetalle


        Session("datos") = dtbDatos



    End Sub



    Private Sub datableDocumentos()

        Dim dtbDatos1 As New DataTable
        dtbDatos1.Columns.Add("chr_IdTipoDocumento", GetType(String))
        dtbDatos1.Columns.Add("var_TipoDocumento", GetType(String))
        dtbDatos1.Columns.Add("var_IdNumeroDocumento", GetType(String))

        Dim pkDetalle(1) As Data.DataColumn
        pkDetalle(0) = dtbDatos1.Columns("chr_IdTipoDocumento")
        dtbDatos1.PrimaryKey = pkDetalle


        Session("dtbDatos") = dtbDatos1



    End Sub

    Protected Sub grdDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDatos.PageIndexChanging

    End Sub



    Protected Sub btnDocumentos_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnDocumentos.Click
        pnlDocumento.Visible = True

    End Sub

    Protected Sub btnCerrarDocumento_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrarDocumento.Click
        CierreDocumento()

    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        Response.Redirect("default.aspx")
    End Sub

    Private Sub CierreDocumento()
        pnlDocumento.Visible = False

    End Sub

    Private Sub RegistraDocumento()

        Dim dtbDatos1 As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
        Dim row As Data.DataRow = dtbDatos1.NewRow

        row("chr_IdTipoDocumento") = ddlTipo.SelectedValue
        row("var_TipoDocumento") = ddlTipo.SelectedItem.Text
        row("var_IdNumeroDocumento") = txtNumero.Text



        dtbDatos1.LoadDataRow(row.ItemArray, True)
        dtbDatos1.AcceptChanges()
        LimpiarFormularioDocumento()



        Session("dtbDatos") = dtbDatos1
        grdDatosDocumentos.DataSource = dtbDatos1
        grdDatosDocumentos.DataBind()


    End Sub
    Protected Sub btnRegistraDocumento_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistraDocumento.Click

        RegistraDocumento()
    End Sub


    Protected Sub btnRegistraCierreDocumento_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistraCierreDocumento.Click
        RegistraDocumento()
        CierreDocumento()

    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        txtFechaEmision.Text = Format(Now.Date, "dd/MM/yyyy")
        btnFechaEmision.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmision.ClientID & ", 'dd/mm/yyyy');")
        datable()
        datableDocumentos()

        Dim dtbDatos1 As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
        Dim dtbDatos As Data.DataTable = CType(Session("datos"), Data.DataTable)
        grdDatos.DataSource = dtbDatos
        grdDatos.DataBind()
        grdDatosDocumentos.DataSource = dtbDatos1
        grdDatosDocumentos.DataBind()



        limpìar()
        pnlFormulario.Visible = False
        pnlDocumento.Visible = False

    End Sub

    Private Sub limpìar()
        txtCodigo.Text = ""
        ctlSolicitante_Buscar1.Limpia()

        ctlCentroCosto_Buscar1.Limpia()




    End Sub






    Protected Sub btnAsignar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAsignar.Click
        pnlFormulario.Visible = True
        pnlDocumento.Visible = False
        LimpiarFormulario()

    End Sub

    Private Sub RegitraArticulo()

        Dim dtbDatos As Data.DataTable = CType(Session("datos"), Data.DataTable)
        Dim row As Data.DataRow = dtbDatos.NewRow

        row("var_IdArticulo") = ctlElementoReferencial_Buscar1.idArticulo
        row("var_Articulo") = ctlElementoReferencial_Buscar1.Nombre
        row("num_Cantidad") = txtCantidad.Text
        row("var_IdUnidadMedida") = ctlUnidadMedida_Buscar1.IdUnidadMedida
        row("var_UnidadMedida") = ctlUnidadMedida_Buscar1.Nombre


        dtbDatos.LoadDataRow(row.ItemArray, True)
        dtbDatos.AcceptChanges()
        LimpiarFormulario()



        Session("datos") = dtbDatos

        grdDatos.DataSource = dtbDatos
        grdDatos.DataBind()

    End Sub

    Protected Sub btnRegistrar_Formulario_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar_Formulario.Click

        RegitraArticulo()


    End Sub

    Private Sub LimpiarFormulario()
        ctlElementoReferencial_Buscar1.Limpia()
        ctlUnidadMedida_Buscar1.Limpia()
        txtCantidad.Text = ""



    End Sub

    Private Sub LimpiarFormularioDocumento()

        ddlTipo.SelectedIndex = 0
        txtNumero.Text = ""



    End Sub


    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        If e.CommandName = "Modificar" Then
            pnlFormulario.Visible = True
            Dim dtbDatos As Data.DataTable = CType(Session("datos"), Data.DataTable)
            For Each dtrItem As Data.DataRow In dtbDatos.Select("var_IdArticulo='" & e.CommandArgument.ToString & "'")
                ctlElementoReferencial_Buscar1.idArticulo = dtrItem("var_IdArticulo")
                ctlElementoReferencial_Buscar1.BuscarId()

                ctlUnidadMedida_Buscar1.IdUnidadMedida = dtrItem("var_IdUnidadMedida")
                ctlUnidadMedida_Buscar1.BuscarId()

                txtCantidad.Text = dtrItem("num_Cantidad")


            Next

        End If


        If e.CommandName = "Eliminar" Then
            Dim dtbRegistro As Data.DataTable = CType(Session("datos"), Data.DataTable)
            datable()
            Dim dtbNuevo As Data.DataTable = CType(Session("datos"), Data.DataTable)
            Dim strItem As String = e.CommandArgument
            For Each dtrItem As Data.DataRow In dtbRegistro.Rows
                If dtrItem("var_IdArticulo") <> strItem Then
                    dtbNuevo.Rows.Add(dtrItem.ItemArray)
                    dtbNuevo.AcceptChanges()
                End If
            Next

            Session("datos") = dtbNuevo
            grdDatos.DataSource = dtbNuevo
            grdDatos.DataBind()

        End If



    End Sub


    Protected Sub grdDatosDocumentos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatosDocumentos.RowCommand
        If e.CommandName = "Modificar" Then
            pnlDocumento.Visible = True

            Dim dtbDatos1 As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
            For Each dtrItem As Data.DataRow In dtbDatos1.Select("chr_IdTipoDocumento='" & e.CommandArgument.ToString & "'")
                BindDocumento()
                ddlTipo.SelectedValue = dtrItem("chr_IdTipoDocumento")
                txtNumero.Text = dtrItem("var_IdNumeroDocumento")



            Next

        End If

        If e.CommandName = "Eliminar" Then
            Dim dtbRegistro As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
            datableDocumentos()
            Dim dtbNuevo As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
            Dim strItem As String = e.CommandArgument
            For Each dtrItem As Data.DataRow In dtbRegistro.Rows
                If dtrItem("chr_IdTipoDocumento") <> strItem Then
                    dtbNuevo.Rows.Add(dtrItem.ItemArray)
                    dtbNuevo.AcceptChanges()
                End If
            Next


            Session("dtbDatos") = dtbNuevo
            grdDatosDocumentos.DataSource = dtbNuevo
            grdDatosDocumentos.DataBind()

        End If

    End Sub


    Private Sub BindTipoDocumento()
        Dim objTipoDocumento As New ALVI_LOGIC.Maestros.Administracion.TipoDocumento
        ddlTipoDocumento.Items.Clear()
        objTipoDocumento.Clasificacion = "S"
        If objTipoDocumento.Listar() = True Then
            ddlTipoDocumento.DataValueField = "chr_IdTipoDocumento"
            ddlTipoDocumento.DataTextField = "var_Descripcion"
            ddlTipoDocumento.DataSource = objTipoDocumento.Datos
            ddlTipoDocumento.DataBind()
        End If
        ddlTipoDocumento.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlTipoDocumento.SelectedIndex = 0
    End Sub


    Protected Sub btnImprimir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnImprimir.Click
        If hdnIdKardex.Value <> "" Then
            Dim stringWrite1 As New System.IO.StringWriter
            Dim stringWrite2 As New System.IO.StringWriter
            Dim htmlWrite1 As New System.Web.UI.HtmlTextWriter(stringWrite1)
            Dim htmlWrite2 As New System.Web.UI.HtmlTextWriter(stringWrite2)
            Dim objMovimiento As New ALVI_LOGIC.Proceso.Logistica.Kardex.Movimiento
            Dim objDetalle As New ALVI_LOGIC.Proceso.Logistica.Kardex.Detalle

            Dim tblMovimiento As New Table
            Dim tblDetalle As New Table
            Dim rowTable As TableRow
            Dim celTable As TableCell

            objMovimiento.IdKardex = hdnIdKardex.Value
            If objMovimiento.Obtener() Then
                Dim objTipoMovimiento As New ALVI_LOGIC.Maestros.Logistica.TipoMovimiento
                Dim objTipoDocumento As New ALVI_LOGIC.Maestros.Administracion.TipoDocumento
                Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Articulo
                Dim objCentroCosto As New ALVI_LOGIC.Configuracion.CentroCosto
                Dim objCuentaGasto As New ALVI_LOGIC.Configuracion.CuentaGasto

                'CODIGO DE INGRESO
                rowTable = New TableRow
                celTable = New TableCell : celTable.Font.Bold = True : celTable.Text = "Cod. Ingreso" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = objMovimiento.IdKardex : rowTable.Cells.Add(celTable)
                tblMovimiento.Rows.Add(rowTable)
                'FECHA
                rowTable = New TableRow
                celTable = New TableCell : celTable.Font.Bold = True : celTable.Text = "Fecha" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = objMovimiento.FechaOperacion : rowTable.Cells.Add(celTable)
                tblMovimiento.Rows.Add(rowTable)
                'TIPO DE MOVIMIENTO
                objTipoMovimiento.IdTipoMovimiento = objMovimiento.IdTipoMovimiento
                objTipoMovimiento.Obtener()
                rowTable = New TableRow
                celTable = New TableCell : celTable.Font.Bold = True : celTable.Text = "Operación:" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = objTipoMovimiento.Descripcion : rowTable.Cells.Add(celTable)
                tblMovimiento.Rows.Add(rowTable)

                'TIPO DE DOCUMENTO
                objTipoDocumento.IdTipoDocumento = objMovimiento.IdTipoDocumento
                objTipoDocumento.Obtener()
                rowTable = New TableRow
                celTable = New TableCell : celTable.Font.Bold = True : celTable.Text = "Documento:" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = objTipoDocumento.Descripcion & " : " & objMovimiento.NumeroDocumento : rowTable.Cells.Add(celTable)
                tblMovimiento.Rows.Add(rowTable)

                'ORDEN DE COMPRA
                rowTable = New TableRow
                celTable = New TableCell : celTable.Font.Bold = True : celTable.Text = "Vale de Pedido:" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = objMovimiento.IdOrdenProduccion : rowTable.Cells.Add(celTable)
                tblMovimiento.Rows.Add(rowTable)

                'OBSERVACION
                rowTable = New TableRow
                celTable = New TableCell : celTable.Font.Bold = True : celTable.Text = "Observación general:" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = objMovimiento.Observacion : rowTable.Cells.Add(celTable)
                tblMovimiento.Rows.Add(rowTable)

                objDetalle.IdKardex = objMovimiento.IdKardex
                If objDetalle.Listar() Then
                    Dim objAlmacen As New ALVI_LOGIC.Maestros.Logistica.Almacen

                    rowTable = New TableRow
                    celTable = New TableCell
                    celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(1, UnitType.Pixel)
                    celTable.Font.Bold = True : celTable.Text = "Cod. Articulo" : rowTable.Cells.Add(celTable)
                    celTable = New TableCell
                    celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(1, UnitType.Pixel)
                    celTable.Font.Bold = True : celTable.Text = "Descripción" : rowTable.Cells.Add(celTable)
                    celTable = New TableCell
                    celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(1, UnitType.Pixel)
                    celTable.Font.Bold = True : celTable.Text = "Almacen" : rowTable.Cells.Add(celTable)
                    celTable = New TableCell
                    celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(1, UnitType.Pixel)
                    celTable.Font.Bold = True : celTable.Text = "Cantidad" : rowTable.Cells.Add(celTable)
                    celTable = New TableCell
                    celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(1, UnitType.Pixel)
                    celTable.Font.Bold = True : celTable.Text = "PU" : rowTable.Cells.Add(celTable)
                    celTable = New TableCell
                    celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(1, UnitType.Pixel)
                    celTable.Font.Bold = True : celTable.Text = "Importe" : rowTable.Cells.Add(celTable)
                    celTable = New TableCell
                    celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(1, UnitType.Pixel)
                    celTable.Font.Bold = True : celTable.Text = "MON" : rowTable.Cells.Add(celTable)
                    celTable = New TableCell
                    celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(1, UnitType.Pixel)
                    celTable.Font.Bold = True : celTable.Text = "TC" : rowTable.Cells.Add(celTable)
                    celTable = New TableCell
                    celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(1, UnitType.Pixel)
                    celTable.Font.Bold = True : celTable.Text = "Importe S/:" : rowTable.Cells.Add(celTable)
                    celTable = New TableCell
                    celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(1, UnitType.Pixel)
                    celTable.Font.Bold = True : celTable.Text = "Observación" : rowTable.Cells.Add(celTable)

                    tblDetalle.Rows.Add(rowTable)

                    For Each dtrItem As Data.DataRow In objDetalle.Datos.Rows
                        objArticulo.IdArticulo = dtrItem("var_IdArticulo")
                        objArticulo.Obtener()
                        'objAlmacen.IdAlmacen = dtrItem("var_IdAlmacen")
                        'objAlmacen.Obtener()
                        objCentroCosto.IdCentroCosto = dtrItem("var_IdCentroCosto")
                        objCentroCosto.Obtener()
                        'objCuentaGasto.IdCuentaGasto = dtrItem("var_IdCuentaGasto")
                        'objCuentaGasto.Obtener()

                        rowTable = New TableRow
                        celTable = New TableCell : celTable.Text = dtrItem("var_IdArticulo") : rowTable.Cells.Add(celTable)
                        celTable = New TableCell : celTable.Text = objArticulo.Descripcion : rowTable.Cells.Add(celTable)
                        celTable = New TableCell : celTable.Text = dtrItem("var_IdAlmacen") & ": " & objAlmacen.Descripcion : rowTable.Cells.Add(celTable)
                        celTable = New TableCell : celTable.Text = dtrItem("num_Cantidad") : rowTable.Cells.Add(celTable)
                        'celTable = New TableCell : celTable.Text = dtrItem("num_CostoUnitario") : rowTable.Cells.Add(celTable)
                        'celTable = New TableCell : celTable.Text = dtrItem("num_ImporteMoneda") : rowTable.Cells.Add(celTable)
                        'celTable = New TableCell : celTable.Text = dtrItem("chr_Moneda") : rowTable.Cells.Add(celTable)
                        'celTable = New TableCell : celTable.Text = dtrItem("num_TipoCambio") : rowTable.Cells.Add(celTable)
                        'celTable = New TableCell : celTable.Text = dtrItem("num_Importe") : rowTable.Cells.Add(celTable)
                        'celTable = New TableCell : celTable.Text = dtrItem("var_Observacion") : rowTable.Cells.Add(celTable)
                        tblDetalle.Rows.Add(rowTable)
                    Next

                End If

                Session("Titulo") = "Salidas de Vales de Pedido"
                tblMovimiento.RenderControl(htmlWrite1)
                Session("Impresion") = stringWrite1.ToString
                tblDetalle.RenderControl(htmlWrite2)
                Session("Impresion") = Session("Impresion") & "<br>" & stringWrite2.ToString
                Session("Datos") = ""

                ClientScript.RegisterStartupScript(ClientScript.GetType, "Imprimir", "<script language='javascript'>window.open('../Controles/frmPrint.aspx','Reporte', 'resizable=1, height=600, width=1000, top=0, left=0');</script>")
            End If
        End If
    End Sub

    Protected Sub grdDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDatos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim ddlAlmacen As DropDownList = CType(e.Row.FindControl("ddlAlmacen"), DropDownList)
            Dim ddlCuentaGasto As DropDownList = CType(e.Row.FindControl("ddlCuentaGasto"), DropDownList)
            BindAlmacen(ddlAlmacen)
            BindCuentaGasto(ddlCuentaGasto)

        End If
    End Sub
End Class
