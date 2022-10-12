

Imports System.Data
Imports System.Data.DataRow
Imports System.Data.SqlClient
Partial Class Interfaces_FGLINBC
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlDocumento.Visible = False
            BindDocumento()
            datable()
            datableDocumento()
            pnlFormulario.Visible = False
            'btnFechaEmision.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmision.ClientID & ", 'dd/mm/yyyy');")

            'btnFechaEntrega.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEntrega.ClientID & ", 'dd/mm/yyyy');")
            btnBuscar.Attributes.Add("onclick", "javascript:return Buscar('" & hdnIdComprar.ClientID & "');")

            If Request("var_IdOrdenCompra") <> "" Then
                Dim objSeguridad As New ALVI_Security.General
                hdnIdComprar.Value = objSeguridad.Decrypta(Request("var_IdOrdenCompra"))
                Buscar()
            End If

            BindGrid()
            BindGridDocumento()

        End If

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



    Protected Sub btnDocumentos_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnDocumentos.Click
        pnlDocumento.Visible = True

    End Sub

    Protected Sub btnAsignar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAsignar.Click
        pnlFormulario.Visible = True
        LimpiarFormulario()

    End Sub


    Private Sub LimpiarFormulario()
        ctlElementoReferencial_Buscar1.Limpia()
        ctlUnidadMedida_Buscar1.Limpia()
        txtCantidad.Text = ""
        txtPrecioRef.Text = ""
        txtObservacion.Text = ""



    End Sub

    Private Sub LimpiarFormularioDocumento()

        ddlTipo.SelectedIndex = 0
        txtNumero.Text = ""
        txtObservacionDocumento.Text = ""



    End Sub


    Private Sub limpiarArticulo()


        ctlElementoReferencial_Buscar1.Limpia()
        ctlUnidadMedida_Buscar1.Limpia()
        txtCantidad.Text = ""
        txtPrecioRef.Text = ""
        txtObservacion.Text = ""

    End Sub



    Private Sub datable()

        Dim dtbDatos As New DataTable
        dtbDatos.Columns.Add("var_IdDetalle", GetType(String))
        dtbDatos.Columns.Add("var_IdArticulo", GetType(String))
        dtbDatos.Columns.Add("var_Articulo", GetType(String))
        dtbDatos.Columns.Add("var_IdUnidadMedida", GetType(String))
        dtbDatos.Columns.Add("var_UnidadMedida", GetType(String))
        dtbDatos.Columns.Add("int_Cantidad", GetType(Double))
        dtbDatos.Columns.Add("dec_PrecioReferencia", GetType(Double))
        dtbDatos.Columns.Add("var_Observacion", GetType(String))




        Dim pkDetalle(1) As Data.DataColumn
        pkDetalle(0) = dtbDatos.Columns("var_IdDetalle")
        dtbDatos.PrimaryKey = pkDetalle


        Session("datos") = dtbDatos



    End Sub


    Private Sub datableDocumento()

        Dim dtbDatos1 As New DataTable
        dtbDatos1.Columns.Add("var_IdReferencia", GetType(String))
        dtbDatos1.Columns.Add("chr_IdTipoDocumento", GetType(String))
        dtbDatos1.Columns.Add("var_TipoDocumento", GetType(String))
        dtbDatos1.Columns.Add("var_NumeroDocumento", GetType(String))
        dtbDatos1.Columns.Add("var_Observacion", GetType(String))



        Dim pkDetalle(1) As Data.DataColumn
        pkDetalle(0) = dtbDatos1.Columns("var_IdReferencia")
        dtbDatos1.PrimaryKey = pkDetalle


        Session("dtbDatos") = dtbDatos1



    End Sub

    Private Sub RegistraDocumento()

        Dim dtbDatos1 As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
        Dim row As Data.DataRow = dtbDatos1.NewRow
        Dim correlativo As Integer

        If (hdnIdCorrelativo.Value = "") Then
            correlativo = row.Table.Rows.Count
            correlativo = correlativo + 1
            row("var_IdReferencia") = correlativo
            row("chr_IdTipoDocumento") = ddlTipo.SelectedValue
            row("var_TipoDocumento") = ddlTipo.SelectedItem.Text
            row("var_NumeroDocumento") = txtNumero.Text
            row("var_Observacion") = txtObservacionDocumento.Text

            dtbDatos1.LoadDataRow(row.ItemArray, True)
            dtbDatos1.AcceptChanges()
            LimpiarFormularioDocumento()

            Session("dtbDatos") = dtbDatos1
            grdDatosDocumentos.DataSource = dtbDatos1
            grdDatosDocumentos.DataBind()

        Else
            row("var_IdReferencia") = hdnIdCorrelativo.Value
            row("chr_IdTipoDocumento") = ddlTipo.SelectedValue
            row("var_TipoDocumento") = ddlTipo.SelectedItem.Text
            row("var_NumeroDocumento") = txtNumero.Text
            row("var_Observacion") = txtObservacionDocumento.Text

            dtbDatos1.LoadDataRow(row.ItemArray, True)
            dtbDatos1.AcceptChanges()
            LimpiarFormularioDocumento()

            Session("dtbDatos") = dtbDatos1
            grdDatosDocumentos.DataSource = dtbDatos1
            grdDatosDocumentos.DataBind()

        End If

       
       


    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        txtFechaEmision.Text = Format(Now.Date, "dd/MM/yyyy")
        'btnFechaEmision.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmision.ClientID & ", 'dd/mm/yyyy');")

        txtFechaEntrega.Text = Format(Now.Date, "dd/MM/yyyy")
        'btnFechaEntrega.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEntrega.ClientID & ", 'dd/mm/yyyy');")
        pnlFormulario.Visible = False
        pnlDocumento.Visible = False

        datable()

        datableDocumento()


        Dim dtbDatos As Data.DataTable = CType(Session("datos"), Data.DataTable)

        grdDatos.DataSource = dtbDatos
        grdDatos.DataBind()


        Dim datableDocumentos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)

        grdDatosDocumentos.DataSource = datableDocumentos
        grdDatosDocumentos.DataBind()
        limpiar()



    End Sub

    Private Sub limpiar()
        txtCodigo.Text = ""
        txtTerminos.Text = ""
        TxtObservaciones.Text = ""
        ctlProveedor_Buscar1.Limpia()


    End Sub


    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        Response.Redirect("default.aspx")
    End Sub



    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        Buscar()

    End Sub

    Protected Sub btnRegistrar_Formulario_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar_Formulario.Click

        RegitraArticulo()


    End Sub


    Protected Sub btnCancelar_Formulario_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTerminar.Click
        RegitraArticulo()
        Cancelar()

    End Sub

    Protected Sub btnRegistraDocumento_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistraDocumento.Click

        RegistraDocumento()
    End Sub

    Protected Sub btnCerrarDocumento_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrarDocumento.Click
        CerrarDocumento()

    End Sub


    Protected Sub btnRegistraCierreDocumento_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistraCierreDocumento.Click
        RegistraDocumento()
        CerrarDocumento()

    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click

        If txtFechaEmision.Text <> "" AndAlso txtFechaEntrega.Text <> "" _
            AndAlso txtTerminos.Text <> "" AndAlso TxtObservaciones.Text <> "" AndAlso ctlProveedor_Buscar1.IdProveedor <> "" Then

        End If
        Dim strFechaEmision() = txtFechaEmision.Text.Split("/")
        Dim strFechaEntrega() = txtFechaEntrega.Text.Split("/")
        Dim dtmFechaEmision As New Date(strFechaEmision(2), strFechaEmision(1), strFechaEmision(0))
        Dim dtmFechaEntrega As New Date(strFechaEntrega(2), strFechaEntrega(1), strFechaEntrega(0))

        If dtmFechaEmision > Now.Date Then
            ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('La fecha no permitida');</script>")
            If dtmFechaEntrega > Now.Date Then
                ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('La fecha no permitida');</script>")
            End If
            Exit Sub

        End If
        Dim dtbDatosArticulo As Data.DataTable = CType(Session("datos"), Data.DataTable)
        Dim dtbDatosDocume As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)

        If dtbDatosArticulo.Rows.Count > 0 Then
            Dim objCompra As New ALVI_LOGIC.Maestros.Logistica.Compra
            objCompra.IdOrdenCompra = txtCodigo.Text
            objCompra.FechaEmision = txtFechaEmision.Text
            objCompra.FechaEntrega = txtFechaEntrega.Text
            objCompra.Termino = txtTerminos.Text
            objCompra.Observacion = TxtObservaciones.Text
            objCompra.IdProveedor = ctlProveedor_Buscar1.IdProveedor
            objCompra.Estado = "ACT"
            objCompra.Usuario = Session("Usuario")

            If objCompra.Registrar(dtbDatosArticulo, dtbDatosDocume) Then
                Dim intRegistros As Int16 = 0
                txtCodigo.Text = objCompra.IdOrdenCompra
                ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('Registro exitoso. ORDEN COMPRA:" & objCompra.IdOrdenCompra & "');</script>")
            End If



        End If



    End Sub

    Private Sub Buscar()
        Dim objCompra As New ALVI_LOGIC.Maestros.Logistica.Compra
        objCompra.IdOrdenCompra = hdnIdComprar.Value
        If objCompra.Obtener Then

            txtCodigo.Text = objCompra.IdOrdenCompra
            txtFechaEmision.Text = objCompra.FechaEmision
            txtFechaEntrega.Text = objCompra.FechaEntrega
            txtTerminos.Text = objCompra.Termino
            TxtObservaciones.Text = objCompra.Observacion
            ctlProveedor_Buscar1.IdProveedor = objCompra.IdProveedor

            ctlProveedor_Buscar1.BuscarId()
            BindGrid()
            BindGridDocumento()

        End If
    End Sub


    Private Sub BindGrid()
        datable()
        Dim objCompra As New ALVI_LOGIC.Maestros.Logistica.Compra
        Dim objCompraArticulo As New ALVI_LOGIC.Maestros.Logistica.CompraArticulo
        objCompraArticulo.IdOrdenCompra = txtCodigo.Text

        Dim dtbDatos As Data.DataTable = CType(Session("datos"), Data.DataTable)
        If objCompraArticulo.Listar Then

            Dim objUnidadMedida As New ALVI_LOGIC.Configuracion.UnidadMedida
            Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Articulo

            For Each dtrItem As Data.DataRow In objCompraArticulo.Datos.Rows
                Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                dtrNuevo("var_IdDetalle") = dtrItem("var_IdDetalle")
                dtrNuevo("var_IdArticulo") = dtrItem("var_IdArticulo")
                objArticulo.IdArticulo = dtrItem("var_IdArticulo")
                objArticulo.Obtener1()
                dtrNuevo("var_Articulo") = objArticulo.Descripcion
                dtrNuevo("var_IdUnidadMedida") = dtrItem("var_IdUnidadMedida")
                objUnidadMedida.IdUnidadMedida = dtrItem("var_IdUnidadMedida")
                objUnidadMedida.Obtener1()
                dtrNuevo("var_UnidadMedida") = objUnidadMedida.Descripcion

                dtrNuevo("int_Cantidad") = dtrItem("int_Cantidad")
                dtrNuevo("dec_PrecioReferencia") = dtrItem("dec_PrecioReferencia")
                dtrNuevo("var_Observacion") = dtrItem("var_Observacion")

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

        Dim objCompraDocumento As New ALVI_LOGIC.Maestros.Logistica.CompraDocumento
        objCompraDocumento.IdValeAlemacen = txtCodigo.Text

        Dim dtbDatos1 As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
        If objCompraDocumento.Listar Then
            Dim objTipoDocumento As New ALVI_LOGIC.Maestros.Administracion.TipoDocumento

            For Each dtrItem As Data.DataRow In objCompraDocumento.Datos.Rows()

                Dim dtrNuevo As Data.DataRow = dtbDatos1.NewRow

                dtrNuevo("var_IdReferencia") = dtrItem("var_IdReferencia")
                dtrNuevo("chr_IdTipoDocumento") = dtrItem("chr_IdTipoDocumento")
                objTipoDocumento.IdTipoDocumento = dtrItem("chr_IdTipoDocumento")
                objTipoDocumento.Obtener()

                dtrNuevo("var_TipoDocumento") = objTipoDocumento.Descripcion

                dtrNuevo("var_NumeroDocumento") = dtrItem("var_NumeroDocumento")
                dtrNuevo("var_Observacion") = dtrItem("var_Observacion")
                dtbDatos1.LoadDataRow(dtrNuevo.ItemArray, True)
                dtbDatos1.AcceptChanges()

            Next

        End If

        Session("dtbDatos") = dtbDatos1
        grdDatosDocumentos.DataSource = dtbDatos1
        grdDatosDocumentos.DataBind()

    End Sub


    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        If e.CommandName = "Modificar" Then
            pnlFormulario.Visible = True
            Dim dtbDatos As Data.DataTable = CType(Session("datos"), Data.DataTable)
            For Each dtrItem As Data.DataRow In dtbDatos.Select("var_IdDetalle='" & e.CommandArgument.ToString & "'")
                hdnIdCorrelativo1.Value = dtrItem("var_IdDetalle")
                ctlElementoReferencial_Buscar1.idArticulo = dtrItem("var_IdArticulo")
                ctlElementoReferencial_Buscar1.BuscarId()

                ctlUnidadMedida_Buscar1.IdUnidadMedida = dtrItem("var_IdUnidadMedida")
                ctlUnidadMedida_Buscar1.BuscarId()

                txtCantidad.Text = dtrItem("int_Cantidad")
                txtPrecioRef.Text = dtrItem("dec_PrecioReferencia")
                txtObservacion.Text = dtrItem("var_Observacion")


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







    Private Sub RegitraArticulo()
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
            row("dec_PrecioReferencia") = txtPrecioRef.Text
            row("var_Observacion") = txtObservacion.Text


            dtbDatos.LoadDataRow(row.ItemArray, True)
            dtbDatos.AcceptChanges()

            limpiarArticulo()


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
            row("dec_PrecioReferencia") = txtPrecioRef.Text
            row("var_Observacion") = txtObservacion.Text


            dtbDatos.LoadDataRow(row.ItemArray, True)
            dtbDatos.AcceptChanges()

            limpiarArticulo()




            Session("datos") = dtbDatos

            grdDatos.DataSource = dtbDatos
            grdDatos.DataBind()


        End If


    End Sub


    Protected Sub grdDatosDocumentos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatosDocumentos.RowCommand
        If e.CommandName = "Modificar" Then
            pnlDocumento.Visible = True

            Dim dtbDatos1 As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
            For Each dtrItem As Data.DataRow In dtbDatos1.Select("var_IdReferencia='" & e.CommandArgument.ToString & "'")
                BindDocumento()
                hdnIdCorrelativo.Value = dtrItem("var_IdReferencia")
                ddlTipo.SelectedValue = dtrItem("chr_IdTipoDocumento")
                txtNumero.Text = dtrItem("var_NumeroDocumento")
                txtObservacionDocumento.Text = dtrItem("var_Observacion")


            Next

        End If

        If e.CommandName = "Eliminar" Then
            Dim dtbRegistro As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
            datableDocumento()
            Dim dtbNuevo As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
            Dim strItem As String = e.CommandArgument
            For Each dtrItem As Data.DataRow In dtbRegistro.Rows
                If dtrItem("var_IdReferencia") <> strItem Then
                    dtbNuevo.Rows.Add(dtrItem.ItemArray)
                    dtbNuevo.AcceptChanges()
                End If
            Next


            Session("dtbDatos") = dtbNuevo
            grdDatosDocumentos.DataSource = dtbNuevo
            grdDatosDocumentos.DataBind()

        End If
    End Sub

    Private Sub Cancelar()

        pnlFormulario.Visible = False

    End Sub


    Private Sub CerrarDocumento()


        pnlDocumento.Visible = False

    End Sub


    Protected Sub ctlElementoReferencial_Buscar1_BuscarUM(_pstrIdUnidadM As String) Handles ctlElementoReferencial_Buscar1.BuscarUM
        ctlUnidadMedida_Buscar1.IdUnidadMedida = _pstrIdUnidadM
        ctlUnidadMedida_Buscar1.BuscarId()
    End Sub

    Protected Sub ctlElementoReferencial_Buscar1_LimpiarUM() Handles ctlElementoReferencial_Buscar1.LimpiarUM
        ctlUnidadMedida_Buscar1.Limpia()
    End Sub
End Class
