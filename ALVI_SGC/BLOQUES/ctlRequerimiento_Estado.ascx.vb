Imports System.Data

Partial Class BLOQUES_ctlRequerimiento_Estado
    Inherits System.Web.UI.UserControl

    Public Event Cerrado()

    Public Property IdRequerimiento As String
        Get
            Return hdnIdRequisicion.Value
        End Get
        Set(ByVal value As String)
            hdnIdRequisicion.Value = value
        End Set
    End Property

    Public Sub Buscar()
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
                dtrNuevo("var_Articulo") = dtrItem("var_Articulo")
                dtrNuevo("var_IdUnidadMedida") = dtrItem("var_IdUnidadMedida")
                dtrNuevo("var_UnidadMedida") = dtrItem("var_UnidadMedida")

                dtrNuevo("num_Cantidad") = dtrItem("num_CantidadAprobada")
                dtrNuevo("chr_Estado") = dtrItem("chr_Estado")
                dtrNuevo("var_Descripcion") = dtrItem("var_Descripcion")
                dtrNuevo("num_Precio") = dtrItem("num_CostoPromedio")
                dtrNuevo("num_Total") = dtrItem("num_CostoTotal")

                dtbDatos.LoadDataRow(dtrNuevo.ItemArray, True)
                dtbDatos.AcceptChanges()
            Next
        End If

        Session("dtbArticulos") = dtbDatos
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
        dtbDatos.Columns.Add("num_Precio", GetType(Double))
        dtbDatos.Columns.Add("num_Total", GetType(Double))


        Dim pkDetalle(2) As Data.DataColumn
        pkDetalle(0) = dtbDatos.Columns("var_IdValeAlmacen")
        pkDetalle(1) = dtbDatos.Columns("var_IdArticuloReferencia")
        dtbDatos.PrimaryKey = pkDetalle

        Session("dtbArticulos") = dtbDatos

    End Sub

    Protected Sub grdDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDatos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim ddlEstado As DropDownList = CType(e.Row.FindControl("ddlEstado"), DropDownList)
            Dim txtCantidad As TextBox = CType(e.Row.FindControl("txtCantidad"), TextBox)
            Dim drvItem As DataRowView = CType(e.Row.DataItem, DataRowView)

            If drvItem("chr_Estado") = "ACT" Then
                ddlEstado.Items.Clear()
                ddlEstado.Items.Add(New ListItem("Seleccionar", ""))
                ddlEstado.Items.Add(New ListItem("Aprobado", "APR"))
                ddlEstado.Items.Add(New ListItem("Rechazado", "REC"))
            ElseIf drvItem("chr_Estado") = "APR" Then
                ddlEstado.Items.Clear()
                ddlEstado.Items.Add(New ListItem("Aprobado", "APR"))
                ddlEstado.SelectedIndex = 0
                ddlEstado.Enabled = False
                txtCantidad.Enabled = False
            ElseIf drvItem("chr_Estado") = "ACT" Then
                ddlEstado.Items.Clear()
                ddlEstado.Items.Add(New ListItem("Rechazado", "REC"))
                ddlEstado.SelectedIndex = 0
                ddlEstado.Enabled = False
                txtCantidad.Enabled = False
            End If

        End If
    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click

        CrearEsquemaArticulos()

        Dim objRequisicion As New ALVI_LOGIC.Maestros.Requisicion.Requisicion
        
        Dim dtbDatos As Data.DataTable = CType(Session("dtbArticulos"), Data.DataTable)

        
        For Each dtrItem As GridViewRow In grdDatos.Rows
            If CType(dtrItem.FindControl("ddlEstado"), DropDownList).SelectedValue <> "" Then
                Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow

                dtrNuevo("var_IdValeAlmacen") = dtrItem.Cells(0).Text
                dtrNuevo("var_IdDetalle") = dtrItem.Cells(1).Text
                dtrNuevo("var_IdArticuloReferencia") = dtrItem.Cells(2).Text
                dtrNuevo("var_Articulo") = ""
                dtrNuevo("var_IdUnidadMedida") = dtrItem.Cells(6).Text
                dtrNuevo("var_UnidadMedida") = ""

                dtrNuevo("num_Cantidad") = CType(dtrItem.FindControl("txtCantidad"), TextBox).Text
                dtrNuevo("chr_Estado") = CType(dtrItem.FindControl("ddlEstado"), DropDownList).SelectedValue
                dtrNuevo("var_Descripcion") = ""

                dtbDatos.LoadDataRow(dtrNuevo.ItemArray, True)
                dtbDatos.AcceptChanges()
            End If

        Next
        objRequisicion.IdRequisicion = txtCodigo.Text
        objRequisicion.registrarestado(dtbDatos)

        BindGrid()
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        RaiseEvent Cerrado()

    End Sub
End Class
