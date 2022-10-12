
Imports System.Data
Imports System.Data.DataRow
Imports System.Data.SqlClient


Partial Class Interfaces_FGLINAA
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            btnFechaPlazo.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaPlazo.ClientID & ", 'dd/mm/yyyy');")
            LimpiarFormulario()

            rbtTipo.RepeatDirection = RepeatDirection.Horizontal
            
            txtCodigo.Enabled = False
            pnlFormulario.Visible = True
            
            btnBuscar.Attributes.Add("onclick", "javascript:return Buscar('" & hdnIdRequisicion.ClientID & "');")

            If Request("IdRequisicion") <> "" Then
                Dim objSeguridad As New ALVI_Security.General
                hdnIdRequisicion.Value = objSeguridad.Decrypta(Request("IdRequisicion"))
                Buscar()
            Else
                CrearEsquemaArticulos()

                Dim dtbDatos As Data.DataTable = CType(Session("dtbArticulos"), Data.DataTable)
                hdnCorrelativo.VALUE = 0
                If dtbDatos.Rows.Count > 0 Then
                    hdnCorrelativo.Value = dtbDatos.Compute("MAX(var_IdDetalle)", "")
                End If
                grdDatos.DataSource = dtbDatos
                grdDatos.DataBind()
            End If

        End If
    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        Registrar()
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        Buscar()
    End Sub


    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        Response.Redirect("default.aspx")
    End Sub
    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        txtFechaPlazo.Text = Format(Now.Date, "dd/MM/yyyy")
        btnFechaPlazo.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaPlazo.ClientID & ", 'dd/mm/yyyy');")
        pnlFormulario.Visible = True

        LimpiarFormulario()
        CrearEsquemaArticulos()

        Dim dtbDatos As Data.DataTable = CType(Session("dtbArticulos"), Data.DataTable)

        grdDatos.DataSource = dtbDatos
        grdDatos.DataBind()
    End Sub


    Private Sub Registrar()

        If ctlCentroCosto_Buscar1.IdCentroCosto <> "" _
            AndAlso ctlSolicitante_Buscar1.IdSolicitante <> "" _
            AndAlso txtFechaPlazo.Text <> "" AndAlso txtMotivo.Text <> "" _
             AndAlso rbtTipo.Text <> "" Then

            Dim dtbDatos As Data.DataTable = CType(Session("dtbArticulos"), Data.DataTable)
            If dtbDatos.Rows.Count > 0 Then
                Dim objRequisicion As New ALVI_LOGIC.Maestros.Requisicion.Requisicion
                objRequisicion.IdRequisicion = txtCodigo.Text
                objRequisicion.Tipo = rbtTipo.Text
                objRequisicion.IdSolicitante = ctlSolicitante_Buscar1.IdSolicitante
                objRequisicion.IdCentroCosto = ctlCentroCosto_Buscar1.IdCentroCosto
                objRequisicion.IdCodigoPROYECTO = ctlProyecto_Buscar1.IdProyecto
                objRequisicion.FechaPlazo = txtFechaPlazo.Text
                objRequisicion.Motivo = txtMotivo.Text
                objRequisicion.Referencia = txtReferencia.Text
                objRequisicion.Proveedores = txtProveedor.Text
                objRequisicion.Estado = "ACT"
                objRequisicion.Usuario = Session("Usuario")


                If objRequisicion.Registrar(dtbDatos) = True Then
                    Dim intRegistros As Int16 = 0
                    'LimpiarFormulario()
                    txtCodigo.Text = objRequisicion.IdRequisicion
                    lblMensaje.Text = "Registro exitoso. REQUISICION Nro: " & txtCodigo.Text
                    ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('Registro exitoso. REQUISICION Nro: " & txtCodigo.Text & "');</script>")
                Else
                    lblMensaje.Text = "Datos Incorrectos"
                End If

            Else
                lblMensaje.Text = "Faltan Datos"
            End If
        End If

    End Sub

    Private Sub LimpiarFormulario()
        txtCodigo.Text = ""
        ctlSolicitante_Buscar1.Limpia()
        ctlCentroCosto_Buscar1.Limpia()
        ctlProyecto_Buscar1.Limpia()
        txtProveedor.Text = ""
        txtReferencia.Text = ""
        txtMotivo.Text = ""
        txtFechaPlazo.Text = ""
        rbtTipo.Items(0).Selected = False

        CrearEsquemaArticulos()

        Dim dtbDatos As Data.DataTable = CType(Session("dtbArticulos"), Data.DataTable)
        hdnCorrelativo.Value = 0
        If dtbDatos.Rows.Count > 0 Then
            hdnCorrelativo.Value = dtbDatos.Compute("MAX(var_IdDetalle)", "")
        End If
        grdDatos.DataSource = dtbDatos
        grdDatos.DataBind()
    End Sub


    Private Sub CrearEsquemaArticulos()
        Dim dtbDatos As New DataTable
        dtbDatos.Columns.Add("var_IdDetalle", GetType(String))
        dtbDatos.Columns.Add("var_IdValeAlmacen", GetType(String))
        dtbDatos.Columns.Add("var_IdArticuloReferencia", GetType(String))
        dtbDatos.Columns.Add("var_Articulo", GetType(String))
        dtbDatos.Columns.Add("var_Descripcion", GetType(String))
        dtbDatos.Columns.Add("num_Cantidad", GetType(Double))
        dtbDatos.Columns.Add("var_IdUnidadMedida", GetType(String))
        dtbDatos.Columns.Add("var_UnidadMedida", GetType(String))
        dtbDatos.Columns.Add("chr_Estado", GetType(String))


        Dim pkDetalle(2) As Data.DataColumn
        pkDetalle(0) = dtbDatos.Columns("var_IdValeAlmacen")
        pkDetalle(1) = dtbDatos.Columns("var_IdArticuloReferencia")
        dtbDatos.PrimaryKey = pkDetalle

        Session("dtbArticulos") = dtbDatos

    End Sub

    

    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        If e.CommandName = "Eliminar" Then
            Dim dtbRegistro As Data.DataTable = CType(Session("dtbArticulos"), Data.DataTable)
            CrearEsquemaArticulos()
            Dim dtbNuevo As Data.DataTable = CType(Session("dtbArticulos"), Data.DataTable)
            Dim strItem As String = e.CommandArgument
            For Each dtrItem As Data.DataRow In dtbRegistro.Rows
                If dtrItem("var_IdDetalle") <> strItem Then
                    dtbNuevo.Rows.Add(dtrItem.ItemArray)
                    dtbNuevo.AcceptChanges()
                End If
            Next

            Session("dtbArticulos") = dtbNuevo
            grdDatos.DataSource = dtbNuevo
            grdDatos.DataBind()
        End If
    End Sub

    Private Sub Buscar()
        If hdnIdRequisicion.Value <> "" Then
            Dim objRequisicion As New ALVI_LOGIC.Maestros.Requisicion.Requisicion
            objRequisicion.IdRequisicion = hdnIdRequisicion.Value

            objRequisicion.IdRequisicion = hdnIdRequisicion.Value
            If objRequisicion.Obtener Then

                txtCodigo.Text = objRequisicion.IdRequisicion
                rbtTipo.Text = objRequisicion.Tipo
                ctlSolicitante_Buscar1.IdSolicitante = objRequisicion.IdSolicitante
                ctlSolicitante_Buscar1.BuscarId()

                ctlCentroCosto_Buscar1.IdCentroCosto = objRequisicion.IdCentroCosto
                ctlCentroCosto_Buscar1.BuscarId()
                ctlProyecto_Buscar1.IdProyecto = objRequisicion.IdCodigoPROYECTO
                ctlProyecto_Buscar1.BuscarId()
                txtFechaPlazo.Text = objRequisicion.FechaPlazo
                rbtTipo.Text = objRequisicion.Tipo
                txtMotivo.Text = objRequisicion.Motivo
                txtReferencia.Text = objRequisicion.Referencia
                txtProveedor.Text = objRequisicion.Proveedores
                BindGrid()
            End If

        End If
    End Sub


    Private Sub BindGrid()
        CrearEsquemaArticulos()
        Dim objRequisicion As New ALVI_LOGIC.Maestros.Requisicion.Requisicion
        Dim objRequisicionDetalle As New ALVI_LOGIC.Maestros.Requisicion.DetalleRequision

        objRequisicionDetalle.IdRequisicion = txtCodigo.Text
        Dim dtbDatos As Data.DataTable = CType(Session("dtbArticulos"), Data.DataTable)
        If objRequisicionDetalle.Listar Then

            Dim objUnidadMedida As New ALVI_LOGIC.Configuracion.UnidadMedida
            Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Articulo

            For Each dtrItem As Data.DataRow In objRequisicionDetalle.Datos.Rows
                Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow

                dtrNuevo("var_IdValeAlmacen") = dtrItem("var_IdValeAlmacen")
                dtrNuevo("var_IdDetalle") = dtrItem("var_IdDetalle")
                dtrNuevo("var_IdArticuloReferencia") = dtrItem("var_IdArticuloReferencia")
                objArticulo.IdArticulo = dtrItem("var_IdArticuloReferencia")
                objArticulo.Obtener1()
                dtrNuevo("var_Articulo") = objArticulo.Descripcion
                dtrNuevo("var_IdUnidadMedida") = dtrItem("var_IdUnidadMedida")
                objUnidadMedida.IdUnidadMedida = dtrItem("var_IdUnidadMedida")
                objUnidadMedida.Obtener1()
                dtrNuevo("var_UnidadMedida") = objUnidadMedida.Descripcion

                dtrNuevo("num_Cantidad") = dtrItem("int_Cantidad")
                dtrNuevo("var_Descripcion") = dtrItem("var_Descripcion")
                dtrNuevo("chr_Estado") = dtrItem("chr_Estado")

                dtbDatos.LoadDataRow(dtrNuevo.ItemArray, True)
                dtbDatos.AcceptChanges()
            Next
        End If

        Session("dtbArticulos") = dtbDatos
        grdDatos.DataSource = dtbDatos
        grdDatos.DataBind()

    End Sub

    Protected Sub ctlNotaPedido_Asignar_Asignado(ByVal dtbDatos As System.Data.DataTable) Handles ctlNotaPedido_Asignar.Asignado
        Dim dtbArticulos As Data.DataTable = CType(Session("dtbArticulos"), Data.DataTable)
        Dim intCorrelativo As Integer = hdnCorrelativo.Value

        For Each dtrItem As Data.DataRow In dtbDatos.Rows
            Dim dtrNuevo As Data.DataRow = dtbArticulos.NewRow
            intCorrelativo = intCorrelativo + 1

            dtrNuevo("var_IdDetalle") = intCorrelativo
            dtrNuevo("var_IdValeAlmacen") = dtrItem("var_IdValeAlmacen")
            dtrNuevo("var_IdArticuloReferencia") = dtrItem("var_IdArticulo")
            dtrNuevo("var_Articulo") = dtrItem("var_Articulo")
            dtrNuevo("var_IdUnidadMedida") = dtrItem("var_IdUnidadMedida")
            dtrNuevo("var_UnidadMedida") = dtrItem("var_UnidadMedida")
            dtrNuevo("num_Cantidad") = dtrItem("num_Cantidad")
            dtrNuevo("var_Descripcion") = dtrItem("var_Observacion")
            dtrNuevo("chr_Estado") = "ACT"

            dtbArticulos.LoadDataRow(dtrNuevo.ItemArray, True)
            dtbArticulos.AcceptChanges()
        Next
        hdnCorrelativo.Value = intCorrelativo

        grdDatos.DataSource = dtbArticulos
        grdDatos.DataBind()

        Session("dtbArticulos") = dtbArticulos

    End Sub
End Class
