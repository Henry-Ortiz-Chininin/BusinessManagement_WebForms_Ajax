Imports System.Data
Imports System.Data.DataRow
Imports System.Data.SqlClient
Partial Class Interfaces_FGLINAH
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlDocumento.Visible = False

            txtCodigo.Enabled = False
            txtFechaEmision.Text = Format(Now.Date, "dd/MM/yyyy")
            btnFechaEmision.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmision.ClientID & ", 'dd/mm/yyyy');")
            pnlFormulario.Visible = False
            btnFechaEmision.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmision.ClientID & ", 'dd/mm/yyyy');")
            BindAlmacenDestino()
            BindAlmacenOrigen()
            BindDocumento()
            btnBuscar.Attributes.Add("onclick", "javascript:return Buscar('" & hdnIdOrdenProducion.ClientID & "');")


            If Request("IdVale") <> "" Then
                Dim objSeguridad As New ALVI_Security.General
                hdnIdOrdenProducion.Value = objSeguridad.Decrypta(Request("IdVale"))
                ' Buscar()
            End If
            datable()
            datableDocumento()
            BindGrid()
            BindGridDocumento()
           


            ctlElementoReferencial_Buscar1.Titulo = "Articulo"
            ctlUnidadMedida_Buscar1.Titulo = "Unidad de consumo"
            limpìar()
            LimpiarFormulario()
            LimpiarFormularioDocumento()


        End If
    End Sub


    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        txtFechaEmision.Text = Format(Now.Date, "dd/MM/yyyy")
        btnFechaEmision.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmision.ClientID & ", 'dd/mm/yyyy');")
        pnlFormulario.Visible = False
        pnlDocumento.Visible = False
        datableDocumento()
        datable()



        Dim dtbDatos As Data.DataTable = CType(Session("datos"), Data.DataTable)
        grdDatos.DataSource = dtbDatos
        grdDatos.DataBind()

        Dim datableDocumentos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
        grdDatosDocumentos.DataSource = datableDocumentos
        grdDatosDocumentos.DataBind()
        
    End Sub


    Private Sub Cancelar()
        pnlFormulario.Visible = False
    End Sub


    Private Sub BindAlmacenDestino()
        Dim objAlmacen As New ALVI_LOGIC.Maestros.Logistica.Almacen
        ddlAlmacenDestino.Items.Clear()
        If objAlmacen.Listar() = True Then
            ddlAlmacenDestino.DataValueField = "var_IdAlmacen"
            ddlAlmacenDestino.DataTextField = "var_Descripcion"
            ddlAlmacenDestino.DataSource = objAlmacen.Datos
            ddlAlmacenDestino.DataBind()
        End If
        ddlAlmacenDestino.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlAlmacenDestino.SelectedIndex = 0
    End Sub


    Private Sub BindAlmacenOrigen()
        Dim objAlmacen As New ALVI_LOGIC.Maestros.Logistica.Almacen
        ddlAlmacenOrigen.Items.Clear()
        If objAlmacen.Listar() = True Then
            ddlAlmacenOrigen.DataValueField = "var_IdAlmacen"
            ddlAlmacenOrigen.DataTextField = "var_Descripcion"
            ddlAlmacenOrigen.DataSource = objAlmacen.Datos
            ddlAlmacenOrigen.DataBind()
        End If
        ddlAlmacenOrigen.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlAlmacenOrigen.SelectedIndex = 0
    End Sub


    Private Sub datableDocumento()
        Dim dtbDatos1 As New DataTable
        dtbDatos1.Columns.Add("chr_IdTipoDocumento", GetType(String))
        dtbDatos1.Columns.Add("var_TipoDocumento", GetType(String))
        dtbDatos1.Columns.Add("var_IdNumeroDocumento", GetType(String))
        dtbDatos1.Columns.Add("var_IdProveedor", GetType(String))
        dtbDatos1.Columns.Add("var_Descripcion", GetType(String))
        dtbDatos1.Columns.Add("num_ImporteTotal", GetType(Double))

        Dim pkDetalle(1) As Data.DataColumn
        pkDetalle(0) = dtbDatos1.Columns("chr_IdTipoDocumento")
        dtbDatos1.PrimaryKey = pkDetalle
        Session("dtbDatos") = dtbDatos1
    End Sub


    Private Sub datable()

        Dim dtbDatos As New DataTable

        dtbDatos.Columns.Add("var_IdArticulo", GetType(String))
        dtbDatos.Columns.Add("var_Articulo", GetType(String))
        dtbDatos.Columns.Add("var_IdUnidadMedida", GetType(String))
        dtbDatos.Columns.Add("var_UnidadMedida", GetType(String))
        dtbDatos.Columns.Add("int_Cantidad", GetType(Integer))

        Dim pkDetalle(1) As Data.DataColumn
        pkDetalle(0) = dtbDatos.Columns("var_IdArticulo")
        dtbDatos.PrimaryKey = pkDetalle
        Session("datos") = dtbDatos

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
        ddlTipo.Items.Insert(0, New ListItem("Selecionar", ""))
        ddlTipo.SelectedIndex = 0

    End Sub



    Private Sub BindGrid()
        datable()
        datableDocumento()
         Dim objKardexMovimiento As New ALVI_LOGIC.Proceso.Logistica.Kardex.Movimiento


        objKardexMovimiento.IdOrdenProduccion = hdnIdOrdenProducion.Value

        Dim dtbDatos As Data.DataTable = CType(Session("datos"), Data.DataTable)

        If objKardexMovimiento.IdOrdenProduccion = "" Then
            Session("datos") = dtbDatos
            grdDatos.DataSource = dtbDatos
            grdDatos.DataBind()
        Else
            objKardexMovimiento.Listar1()

            Dim objUnidadMedida As New ALVI_LOGIC.Configuracion.UnidadMedida
            Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Articulo

            For Each dtrItem As Data.DataRow In objKardexMovimiento.Datos.Rows
                Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow


                dtrNuevo("var_IdArticulo") = dtrItem("var_IdArticulo")
                objArticulo.IdArticulo = dtrItem("var_IdArticulo")
                objArticulo.Obtener1()
                dtrNuevo("var_Articulo") = objArticulo.Descripcion
                dtrNuevo("var_IdUnidadMedida") = dtrItem("var_IdUnidadMedida")
                objUnidadMedida.IdUnidadMedida = dtrItem("var_IdUnidadMedida")
                objUnidadMedida.Obtener1()
                dtrNuevo("var_UnidadMedida") = objUnidadMedida.Descripcion

                dtrNuevo("int_Cantidad") = dtrItem("num_Cantidad")


                dtbDatos.LoadDataRow(dtrNuevo.ItemArray, True)
                dtbDatos.AcceptChanges()
            Next

        End If


        Session("datos") = dtbDatos
        grdDatos.DataSource = dtbDatos
        grdDatos.DataBind()




    End Sub
    Private Sub BindGridDocumento()
        datableDocumento()
        Dim objKardexMovimiento As New ALVI_LOGIC.Proceso.Logistica.Kardex.Movimiento


        objKardexMovimiento.IdOrdenProduccion = hdnIdOrdenProducion.Value

        Dim dtbDatos1 As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
        If objKardexMovimiento.Listar2 Then
            Dim objTipoDocumento As New ALVI_LOGIC.Maestros.Administracion.TipoDocumento
            Dim objProveedor As New ALVI_LOGIC.Maestros.Compras.Proveedor

            For Each dtrItem As Data.DataRow In objKardexMovimiento.Datos.Rows()

                Dim dtrNuevo As Data.DataRow = dtbDatos1.NewRow

                objTipoDocumento.IdTipoDocumento = dtrItem("chr_IdTipoDocumento")
                objTipoDocumento.Obtener()
                dtrNuevo("chr_IdTipoDocumento") = objTipoDocumento.IdTipoDocumento
                dtrNuevo("var_TipoDocumento") = objTipoDocumento.Descripcion
                dtrNuevo("var_IdNumeroDocumento") = dtrItem("var_NumeroDocumento")
                dtrNuevo("num_ImporteTotal") = dtrItem("num_ImporteTotal")
                dtrNuevo("var_IdProveedor") = dtrItem("var_IdProveedor")
                objProveedor.IdProveedor = dtrItem("var_IdProveedor")
                objProveedor.Obtener()
                dtrNuevo("var_Descripcion") = objProveedor.Descripcion


                dtbDatos1.LoadDataRow(dtrNuevo.ItemArray, True)
                dtbDatos1.AcceptChanges()

            Next

        End If

        Session("dtbDatos") = dtbDatos1
        grdDatosDocumentos.DataSource = dtbDatos1
        grdDatosDocumentos.DataBind()

    End Sub


    Protected Sub grdDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDatos.PageIndexChanging

    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        Buscar()

    End Sub

    Protected Sub btnRegistraCierreDocumento_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistraCierreDocumento.Click
        RegistraDocumento()
        CierreDocumento()
    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTerminar.Click
        RegitraArticulo()
        Cancelar()

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

    Public Sub Buscar()

        Dim objKardexMovimiento As New ALVI_LOGIC.Proceso.Logistica.Kardex.Movimiento
        objKardexMovimiento.IdOrdenProduccion = hdnIdOrdenProducion.Value

        Dim dt As New DataTable
        dt = objKardexMovimiento.Busqueda1(objKardexMovimiento.IdOrdenProduccion)

        If dt.Rows.Count > 0 Then
            Dim i As Integer

            For i = 0 To dt.Rows.Count - 1

                If i = 0 Then
                    ddlAlmacenOrigen.SelectedValue = dt.Rows(i)("var_IdAlmacen")
                Else
                    ddlAlmacenDestino.SelectedValue = dt.Rows(i)("var_IdAlmacen")
                End If

            Next
            txtFechaEmision.Text = dt.Rows(0)("dtm_FechaMovimiento").ToString()

            BindGrid()
            BindGridDocumento()

        End If
    End Sub

    Private Sub RegistraDocumento()

        Dim dtbDatos1 As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
        Dim row As Data.DataRow = dtbDatos1.NewRow

        If (hdnIdtipo.Value = "") Then
            row("chr_IdTipoDocumento") = ddlTipo.SelectedValue
            row("var_TipoDocumento") = ddlTipo.SelectedItem.Text
            row("var_IdNumeroDocumento") = txtNumero.Text
            row("var_IdProveedor") = ctlProveedor_Buscar1.IdProveedor
            row("var_Descripcion") = ctlProveedor_Buscar1.RazonSocial
            row("num_ImporteTotal") = txtImporte.Text
            dtbDatos1.LoadDataRow(row.ItemArray, True)
            dtbDatos1.AcceptChanges()
            LimpiarFormularioDocumento()

            Session("dtbDatos") = dtbDatos1
            grdDatosDocumentos.DataSource = dtbDatos1
            grdDatosDocumentos.DataBind()

        End If
    End Sub

    Private Sub limpìar()
        txtCodigo.Text = ""
  
    End Sub


    Protected Sub btnRegistraDocumento_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistraDocumento.Click
        RegistraDocumento()

    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click

        If ddlAlmacenDestino.SelectedValue <> "" AndAlso ddlAlmacenOrigen.SelectedValue <> "" AndAlso txtFechaEmision.Text <> "" Then

            Dim strFechaEmision() = txtFechaEmision.Text.Split("/")
            Dim dtmFechaEmision As New Date(strFechaEmision(2), strFechaEmision(1), strFechaEmision(0))

            If dtmFechaEmision > Now.Date Then
                ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('La fecha no permitida');</script>")

            End If

            Dim dtbDatos As Data.DataTable = CType(Session("datos"), Data.DataTable)
            Dim Datos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)


            If dtbDatos.Rows.Count AndAlso Datos.Rows.Count > 0 Then
                Dim objKardexMovimiento As New ALVI_LOGIC.Proceso.Logistica.Kardex.Movimiento
                Dim objKardexDetalle As New ALVI_LOGIC.Proceso.Logistica.Kardex.Detalle
                objKardexMovimiento.IdOrdenProduccion = txtCodigo.Text
                objKardexMovimiento.FechaOperacion = txtFechaEmision.Text
                objKardexMovimiento.IdAlmacen = ddlAlmacenOrigen.SelectedValue
                objKardexMovimiento.IdAlmacen1 = ddlAlmacenDestino.SelectedValue
                objKardexMovimiento.Estado = "ACT"
                objKardexMovimiento.Usuario = Session("Usuario")

                If objKardexMovimiento.RegistrarOrigen(dtbDatos, Datos) Then
                    Dim intRegistros As Int16 = 0
                    ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('Registro exitoso.');</script>")
                End If
            End If
        End If



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
        row("int_Cantidad") = txtCantidad.Text
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
        txtImporte.Text = ""
        ctlProveedor_Buscar1.Limpia()
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

                txtCantidad.Text = dtrItem("int_Cantidad")


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
                ctlProveedor_Buscar1.IdProveedor = dtrItem("var_IdProveedor")
                ctlProveedor_Buscar1.BuscarId()
                txtImporte.Text = dtrItem("num_ImporteTotal")



            Next

        End If

        If e.CommandName = "Eliminar" Then
            Dim dtbRegistro As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
            datableDocumento()
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

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        pnlFormulario.Visible = False

    End Sub


End Class
