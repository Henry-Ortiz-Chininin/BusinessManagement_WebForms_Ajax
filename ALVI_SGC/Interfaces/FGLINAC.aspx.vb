

Imports System.Data
Imports System.Data.DataRow
Imports System.Data.SqlClient


Partial Class Interfaces_FGLINAC
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlDocumento.Visible = False
            BinOperacion()
            txtCodigo.Enabled = False
            txtFechaEmision.Text = Format(Now.Date, "dd/MM/yyyy")
            btnFechaEmision.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmision.ClientID & ", 'dd/mm/yyyy');")
            pnlFormulario.Visible = False
            btnFechaEmision.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmision.ClientID & ", 'dd/mm/yyyy');")

            BindDocumento()
            btnBuscar.Attributes.Add("onclick", "javascript:return Buscar('" & hdnIdVale.ClientID & "');")


            If Request("IdVale") <> "" Then
                Dim objSeguridad As New ALVI_Security.General
                hdnIdVale.Value = objSeguridad.Decrypta(Request("IdVale"))
                Buscar()
            End If
            CreateSchemaArticulo()
            datableDocumentos()
            BindGrid()
            BindGridDocumento()

        End If
    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        If txtFechaEmision.Text <> "" AndAlso ctlSolicitante_Buscar1.IdSolicitante <> "" AndAlso ctlCentroCosto_Buscar1.IdCentroCosto <> "" _
            AndAlso ddlOperacion.SelectedValue <> "" Then
            Dim strFecha() = txtFechaEmision.Text.Split("/")
            Dim dtmFecha As New Date(strFecha(2), strFecha(1), strFecha(0))


            If dtmFecha > Now.Date Then
                ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('La fecha no permitida');</script>")
                Exit Sub
            End If

            Dim dtbArticulos As Data.DataTable = CType(Session("dtbArticulos"), Data.DataTable)
            Dim Datos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
            If dtbArticulos.Rows.Count Then
                Dim objVale As New ALVI_LOGIC.Maestros.Logistica.Vale
                objVale.IdValeAlemacen = txtCodigo.Text
                objVale.Operacion = ddlOperacion.SelectedValue
                objVale.FechaEmision = txtFechaEmision.Text
                objVale.IdSolicitante = ctlSolicitante_Buscar1.IdSolicitante
                objVale.IdCentroCosto = ctlCentroCosto_Buscar1.IdCentroCosto
                objVale.Estado = "ACT"
                objVale.Usuario = Session("Usuario")

                If objVale.Registrar(dtbArticulos, Datos) Then
                    Dim intRegistros As Int16 = 0
                    txtCodigo.Text = objVale.IdValeAlemacen
                    ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('Registro exitoso. VALE: " & objVale.IdValeAlemacen & "');</script>")
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

            txtCodigo.Text = objVale.IdValeAlemacen
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
        CreateSchemaArticulo()
        datableDocumentos()
        Dim objVale As New ALVI_LOGIC.Maestros.Logistica.Vale
        Dim objValeArticulo As New ALVI_LOGIC.Maestros.Logistica.ValeArticulo


        objValeArticulo.IdValeAlmacen = txtCodigo.Text

        Dim dtbArticulos As Data.DataTable = CType(Session("dtbArticulos"), Data.DataTable)
        If objValeArticulo.Listar Then

            Dim objUnidadMedida As New ALVI_LOGIC.Configuracion.UnidadMedida
            Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Articulo

            For Each dtrItem As Data.DataRow In objValeArticulo.Datos.Rows
                Dim dtrNuevo As Data.DataRow = dtbArticulos.NewRow


                dtrNuevo("var_IdArticulo") = dtrItem("var_IdArticulo")
                objArticulo.IdArticulo = dtrItem("var_IdArticulo")
                objArticulo.Obtener1()
                dtrNuevo("var_Articulo") = objArticulo.Descripcion
                dtrNuevo("var_IdUnidadMedida") = dtrItem("var_IdUnidadMedida")
                objUnidadMedida.IdUnidadMedida = dtrItem("var_IdUnidadMedida")
                objUnidadMedida.Obtener1()
                dtrNuevo("var_UnidadMedida") = objUnidadMedida.Descripcion

                dtrNuevo("int_Cantidad") = dtrItem("int_Cantidad")

                dtbArticulos.LoadDataRow(dtrNuevo.ItemArray, True)
                dtbArticulos.AcceptChanges()
            Next

        End If


        Session("dtbArticulos") = dtbArticulos
        grdDatos.DataSource = dtbArticulos
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


    Private Sub BinOperacion()
        Dim objTipoMovimiento As New ALVI_LOGIC.Maestros.Logistica.TipoMovimiento
        ddlOperacion.Items.Clear()
        If objTipoMovimiento.Listar1 Then
            Dim drvMovimientos As New Data.DataView(objTipoMovimiento.Datos, "chr_Clase='S'", "", DataViewRowState.OriginalRows)
            ddlOperacion.DataSource = drvMovimientos
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
            ddlTipo.DataSource = objTipoDocumento.Datos
            ddlTipo.DataTextField = "var_Descripcion"
            ddlTipo.DataValueField = "chr_IdTipoDocumento"
            ddlTipo.DataBind()

        End If
        ddlTipo.Items.Insert(0, New ListItem("Selecionar", ""))
        ddlTipo.SelectedIndex = 0

    End Sub



    Private Sub CreateSchemaArticulo()
        'CREAMOS LA TABLA
        Dim dtbDatos As New DataTable
        'AGREGAMOS LOS CAMPOS
        dtbDatos.Columns.Add("var_IdArticulo", GetType(String))
        dtbDatos.Columns.Add("var_Articulo", GetType(String))
        dtbDatos.Columns.Add("var_IdUnidadMedida", GetType(String))
        dtbDatos.Columns.Add("var_UnidadMedida", GetType(String))
        dtbDatos.Columns.Add("int_Cantidad", GetType(Integer))
        'AGREGAMOS EL PRIMARY KEY
        Dim pkDetalle(1) As Data.DataColumn
        pkDetalle(0) = dtbDatos.Columns("var_IdArticulo")
        dtbDatos.PrimaryKey = pkDetalle
        'ALMACENAMOS LA TABLA EN VARIABLE DE SESION
        Session("dtbArticulos") = dtbDatos
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
        CreateSchemaArticulo()
        datableDocumentos()

        Dim dtbDatos1 As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
        Dim dtbArticulos As Data.DataTable = CType(Session("dtbArticulos"), Data.DataTable)
        grdDatos.DataSource = dtbArticulos
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

        Dim dtbArticulos As Data.DataTable = CType(Session("dtbArticulos"), Data.DataTable)
        Dim row As Data.DataRow = dtbArticulos.NewRow

        row("var_IdArticulo") = ctlElementoReferencial_Buscar1.idArticulo
        row("var_Articulo") = ctlElementoReferencial_Buscar1.Nombre
        row("int_Cantidad") = txtCantidad.Text
        row("var_IdUnidadMedida") = ctlUnidadMedida_Buscar1.IdUnidadMedida
        row("var_UnidadMedida") = ctlUnidadMedida_Buscar1.Nombre


        dtbArticulos.LoadDataRow(row.ItemArray, True)
        dtbArticulos.AcceptChanges()
        LimpiarFormulario()



        Session("dtbArticulos") = dtbArticulos

        grdDatos.DataSource = dtbArticulos
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
            Dim dtbArticulos As Data.DataTable = CType(Session("dtbArticulos"), Data.DataTable)
            For Each dtrItem As Data.DataRow In dtbArticulos.Select("var_IdArticulo='" & e.CommandArgument.ToString & "'")
                ctlElementoReferencial_Buscar1.idArticulo = dtrItem("var_IdArticulo")
                ctlElementoReferencial_Buscar1.BuscarId()

                ctlUnidadMedida_Buscar1.IdUnidadMedida = dtrItem("var_IdUnidadMedida")
                ctlUnidadMedida_Buscar1.BuscarId()

                txtCantidad.Text = dtrItem("int_Cantidad")
            Next

        End If


        If e.CommandName = "Eliminar" Then
            Dim dtbRegistro As Data.DataTable = CType(Session("dtbArticulos"), Data.DataTable)
            CreateSchemaArticulo()
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




End Class
