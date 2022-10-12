
Partial Class Estandares_FGCESAE
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlFormulario.Visible = False
            BindGrid()
        End If
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        LimpiarFormulario()
        pnlFormulario.Visible = True
        txtCodigo.ReadOnly = False
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        LimpiarFormulario()
        pnlFormulario.Visible = False
        BindGrid()
    End Sub

    Private Sub LimpiarFormulario()
        txtCodigo.Text = ""
        txtDescripcion.Text = ""
        txtIdCentroCosto.Text = ""
        lblCentroCosto.Text = ""
    End Sub

    Private Sub BindGrid()
        Dim objPlanta As New ALVI_LOGIC.Maestros.Produccion.Planta
        Dim objCentroCosto As New ALVI_LOGIC.Configuracion.CentroCosto

        Dim dtbDatos As New Data.DataTable
        dtbDatos.Columns.Add("var_IdPlanta", GetType(String))
        dtbDatos.Columns.Add("var_IdCentroCosto", GetType(String))
        dtbDatos.Columns.Add("var_CentroCosto", GetType(String))
        dtbDatos.Columns.Add("var_Descripcion", GetType(String))

        If objCentroCosto.Listar() = True _
        AndAlso objPlanta.Listar() = True Then
            For Each dtrItem As Data.DataRow In objPlanta.Datos.Rows
                Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                dtrNuevo("var_IdPlanta") = dtrItem("var_IdPlanta")
                dtrNuevo("var_IdCentroCosto") = dtrItem("var_IdCentroCosto")
                dtrNuevo("var_Descripcion") = dtrItem("var_Descripcion")
                For Each dtrAuxiliar As Data.DataRow In objCentroCosto.Datos.Select("var_IdCentroCosto='" & dtrItem("var_IdCentroCosto") & "'")
                    dtrNuevo("var_CentroCosto") = dtrAuxiliar("var_Descripcion")
                Next
                dtbDatos.Rows.Add(dtrNuevo.ItemArray)
                dtbDatos.AcceptChanges()
            Next

        End If
        Session("dtbDatos") = dtbDatos
        grdDatos.DataSource = New Data.DataView(dtbDatos, "", "var_IdPlanta", Data.DataViewRowState.OriginalRows)
        grdDatos.DataBind()
    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        If txtCodigo.Text <> "" AndAlso txtDescripcion.Text <> "" Then
            Dim objPlanta As New ALVI_LOGIC.Maestros.Produccion.Planta
            objPlanta.IdCentroCosto = txtIdCentroCosto.Text
            objPlanta.IdPlanta = txtCodigo.Text
            objPlanta.Descripcion = txtDescripcion.Text
            objPlanta.Usuario = Session("Usuario")
            objPlanta.Estado = "ACT"
            If objPlanta.Registrar = True Then
                lblMensaje.Text = "Registro exitoso"
                LimpiarFormulario()
                grdDatos.EditIndex = -1
                BindGrid()
            End If
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
            LimpiarFormulario()
            Dim dtbDatos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
            For Each dtrItem As Data.DataRow In dtbDatos.Select("var_IdPlanta='" & e.CommandArgument.ToString & "'")
                If dtrItem("var_IdCentroCosto") <> "" Then
                    txtIdCentroCosto.Text = dtrItem("var_IdCentroCosto")
                    lblCentroCosto.Text = dtrItem("var_CentroCosto")
                Else
                    txtIdCentroCosto.Text = ""
                    lblCentroCosto.Text = ""
                End If

                txtCodigo.Text = dtrItem("var_IdPlanta")
                txtDescripcion.Text = dtrItem("var_Descripcion")
                txtCodigo.ReadOnly = True
                pnlFormulario.Visible = True
            Next
        End If
        If e.CommandName = "Eliminar" Then
            Dim objPlanta As New ALVI_LOGIC.Maestros.Produccion.Planta
            Dim strParametros As String = e.CommandArgument.ToString
            objPlanta.IdPlanta = strParametros

            If objPlanta.Eliminar = True Then
                BindGrid()
            End If
        End If
    End Sub

    Protected Sub txtIdCentroCosto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdCentroCosto.TextChanged
        If txtIdCentroCosto.Text <> "" Then
            Dim objCentroCosto As New ALVI_LOGIC.Configuracion.CentroCosto
            objCentroCosto.IdCentroCosto = txtIdCentroCosto.Text
            If objCentroCosto.Obtener = True Then
                lblCentroCosto.Text = objCentroCosto.Descripcion
            Else
                lblCentroCosto.Text = ""
            End If
        End If
    End Sub

End Class
