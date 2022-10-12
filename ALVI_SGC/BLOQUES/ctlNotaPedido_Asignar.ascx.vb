Imports System.Data

Partial Class BLOQUES_ctlNotaPedido_Asignar
    Inherits System.Web.UI.UserControl

    Public Event Asignado(ByVal dtbDatos As DataTable)


    Private Sub CrearEsquema()

        Dim dtbDatos As New DataTable

        dtbDatos.Columns.Add("var_IdValeAlmacen", GetType(String))
        dtbDatos.Columns.Add("var_IdArticulo", GetType(String))
        dtbDatos.Columns.Add("var_Articulo", GetType(String))
        dtbDatos.Columns.Add("var_IdUnidadMedida", GetType(String))
        dtbDatos.Columns.Add("var_UnidadMedida", GetType(String))
        dtbDatos.Columns.Add("num_Cantidad", GetType(Integer))
        dtbDatos.Columns.Add("var_Observacion", GetType(String))

        Dim pkDetalle(1) As Data.DataColumn
        pkDetalle(0) = dtbDatos.Columns("var_IdArticulo")
        dtbDatos.PrimaryKey = pkDetalle

        Session("dtbDatos") = dtbDatos

    End Sub
    Private Sub Buscar()

        Dim objVale As New ALVI_LOGIC.Maestros.Logistica.Vale
        Dim objValeArticulo As New ALVI_LOGIC.Maestros.Logistica.ValeArticulo

        CrearEsquema()

        objValeArticulo.IdValeAlmacen = txtCodigo.Text
        Dim dtbDatos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)

        If objValeArticulo.Listar Then

            Dim objKardexDetalle As New ALVI_LOGIC.Proceso.Logistica.Kardex.Detalle

            For Each dtrItem As Data.DataRow In objValeArticulo.Datos.Rows
                Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow

                dtrNuevo("var_IdValeAlmacen") = dtrItem("var_IdValeAlmacen")
                dtrNuevo("var_IdArticulo") = dtrItem("var_IdArticulo")
                dtrNuevo("var_Articulo") = dtrItem("var_NombreArticulo")
                dtrNuevo("var_IdUnidadMedida") = dtrItem("var_IdUnidadMedida")
                dtrNuevo("var_UnidadMedida") = dtrItem("var_NombreUnidad")
                dtrNuevo("num_Cantidad") = dtrItem("num_Pendiente")
                dtrNuevo("var_Observacion") = ""

                dtbDatos.LoadDataRow(dtrNuevo.ItemArray, True)
                dtbDatos.AcceptChanges()
            Next

        End If

        Session("dtbDatos") = dtbDatos
        grdDatos.DataSource = dtbDatos
        grdDatos.DataBind()

    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        If txtCodigo.Text <> "" Then
            Buscar()
        End If
    End Sub

    Protected Sub btnAsignar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAsignar.Click

        If txtCodigo.Text <> "" Then
            CrearEsquema()
            Dim dtbDatos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)

            For Each grdItem As GridViewRow In grdDatos.Rows
                Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                If CType(grdItem.Cells(6).FindControl("txtCantidadSalida"), TextBox).Text <> "" Then
                    dtrNuevo("var_IdValeAlmacen") = grdItem.Cells(0).Text
                    dtrNuevo("var_IdArticulo") = grdItem.Cells(1).Text
                    dtrNuevo("var_Articulo") = grdItem.Cells(2).Text
                    dtrNuevo("var_IdUnidadMedida") = grdItem.Cells(3).Text
                    dtrNuevo("var_UnidadMedida") = grdItem.Cells(4).Text
                    dtrNuevo("num_Cantidad") = CType(grdItem.Cells(6).FindControl("txtCantidadSalida"), TextBox).Text
                    dtrNuevo("var_Observacion") = CType(grdItem.Cells(7).FindControl("txtObservacion"), TextBox).Text

                    dtbDatos.LoadDataRow(dtrNuevo.ItemArray, True)
                    dtbDatos.AcceptChanges()
                End If
            Next

            RaiseEvent Asignado(dtbDatos)

        End If
    End Sub
End Class
