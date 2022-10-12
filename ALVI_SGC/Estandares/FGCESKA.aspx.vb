
Partial Class Estandares_FGCESKA
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlFormulario.Visible = False
            BindGrid()
        End If
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        LimpiarFormulario()
        Dim dtbDatos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
        If dtbDatos.Rows.Count > 0 Then
            Try
                Dim intSecuencial As Int16 = CInt(dtbDatos.Compute("Max(var_IdCuota)", ""))
                txtCodigo.Text = Format(intSecuencial + 1, "0000")
            Catch
                txtCodigo.Text = "0000"
            End Try
        Else
            txtCodigo.Text = "0000"
        End If
        txtCodigo.ReadOnly = False
        txtCodigo.MaxLength = 14
        pnlFormulario.Visible = True
        txtCodigo.Enabled = False
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        LimpiarFormulario()
        pnlFormulario.Visible = False
        BindGrid()
    End Sub

    Private Sub LimpiarFormulario()
        Dim dtbDatos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
        txtCodigo.Text = ""
        txtDescripcion.Text = ""
    End Sub
    Private Sub BindGrid()
        Dim objAtributo As New ALVI_LOGIC.Maestros.Administracion.Cuotas
        Dim dtbDatos As New Data.DataTable
        dtbDatos.Columns.Add("var_IdCuota", GetType(String))
        dtbDatos.Columns.Add("var_Descripcion", GetType(String))

        If txtBusqueda.Text <> "" Then
            objAtributo.Descripcion = txtBusqueda.Text
            If objAtributo.Buscar() = True Then
                For Each dtrItem As Data.DataRow In objAtributo.Datos.Rows
                    Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                    dtrNuevo("var_IdCuota") = dtrItem("var_IdCuota")
                    dtrNuevo("var_Descripcion") = dtrItem("var_Descripcion")

                    dtbDatos.Rows.Add(dtrNuevo.ItemArray)
                    dtbDatos.AcceptChanges()
                Next
            End If
        Else

            If objAtributo.Listar() = True Then
                For Each dtrItem As Data.DataRow In objAtributo.Datos.Rows
                    Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                    dtrNuevo("var_IdCuota") = dtrItem("var_IdCuota")
                    dtrNuevo("var_Descripcion") = dtrItem("var_Descripcion")

                    dtbDatos.Rows.Add(dtrNuevo.ItemArray)
                    dtbDatos.AcceptChanges()
                Next
            End If


        End If
        Session("dtbDatos") = dtbDatos
        grdDatos.DataSource = New Data.DataView(dtbDatos, "", "var_IdCuota", Data.DataViewRowState.OriginalRows)
        grdDatos.DataBind()
    End Sub


    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        If txtCodigo.Text <> "" AndAlso txtDescripcion.Text <> "" Then
            Dim objAtributo As New ALVI_LOGIC.Maestros.Administracion.Cuotas
            objAtributo.IdCuota = txtCodigo.Text
            objAtributo.Descripcion = txtDescripcion.Text
            objAtributo.Usuario = Session("Usuario")
            objAtributo.Estado = "ACT"
            If objAtributo.Registrar = True Then
                lblMensaje.Text = "Registro exitoso"
                LimpiarFormulario()
                grdDatos.EditIndex = -1
                BindGrid()
            End If
        Else
            lblMensaje.Text = "Registro fallido"
        End If
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        Response.Redirect("default.aspx")

    End Sub

    Protected Sub grdDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDatos.PageIndexChanging
        grdDatos.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub

    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        If e.CommandName = "Modificar" Then
            Dim dtbDatos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
            For Each dtrItem As Data.DataRow In dtbDatos.Select("var_IdCuota='" & e.CommandArgument.ToString & "'")
                txtCodigo.Text = dtrItem("var_IdCuota")
                txtDescripcion.Text = dtrItem("var_Descripcion")
                txtCodigo.Enabled = False
            Next
            pnlFormulario.Visible = True
            txtCodigo.ReadOnly = True
        End If
        If e.CommandName = "Eliminar" Then
            Dim objAtributo As New ALVI_LOGIC.Maestros.Administracion.Cuotas
            objAtributo.IdCuota = e.CommandArgument
            If objAtributo.Eliminar = True Then
                BindGrid()
            End If
        End If
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        BindGrid()
    End Sub
End Class
