
Partial Class Estandares_FGCESAC
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlFormulario.Visible = False
            BindGrid()
        End If
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        LimpiarFormulario()
        txtCodigo.ReadOnly = False
        txtCodigo.MaxLength = 4
        pnlFormulario.Visible = True

    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        LimpiarFormulario()
        pnlFormulario.Visible = False
        BindGrid()
    End Sub

    Private Sub LimpiarFormulario()
        txtCodigo.Text = ""
        txtDescripcion.Text = ""
        BindFamilia()
        BindUnidadMedida()
    End Sub
    Private Sub BindFamilia()
        Dim objFamilia As New ALVI_LOGIC.Maestros.Articulo.Familia
        ddlFamilia.Items.Clear()
        If objFamilia.Listar() = True Then
            ddlFamilia.DataValueField = "chr_IdFamilia"
            ddlFamilia.DataTextField = "var_Descripcion"
            ddlFamilia.DataSource = objFamilia.Datos
            ddlFamilia.DataBind()
        End If
        ddlFamilia.Items.Insert(0, "Seleccionar")
        ddlFamilia.SelectedIndex = 0
    End Sub
    Private Sub BindUnidadMedida()
        Dim objUnidad As New ALVI_LOGIC.Configuracion.UnidadMedida
        ddlUnidadMedida.Items.Clear()
        If objUnidad.Listar() = True Then
            ddlUnidadMedida.DataValueField = "var_IdUnidadMedida"
            ddlUnidadMedida.DataTextField = "var_Descripcion"
            ddlUnidadMedida.DataSource = objUnidad.Datos
            ddlUnidadMedida.DataBind()
        End If
        ddlUnidadMedida.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlUnidadMedida.SelectedIndex = 0
    End Sub
    Private Sub BindGrid()
        Dim objSubFamilia As New ALVI_LOGIC.Maestros.Articulo.SubFamilia
        objSubFamilia.IdFamilia = ""
        Dim dtbDatos As New Data.DataTable
        dtbDatos.Columns.Add("chr_IdFamilia", GetType(String))
        dtbDatos.Columns.Add("var_Familia", GetType(String))
        dtbDatos.Columns.Add("var_IdSubFamilia", GetType(String))
        dtbDatos.Columns.Add("var_Descripcion", GetType(String))
        dtbDatos.Columns.Add("var_IdUnidadMedida", GetType(String))
        dtbDatos.Columns.Add("var_UnidadMedida", GetType(String))

        If objSubFamilia.Listar() = True Then
            Dim objUnidadMedida As New ALVI_LOGIC.Configuracion.UnidadMedida
            Dim objFamilia As New ALVI_LOGIC.Maestros.Articulo.Familia
            objFamilia.Listar()
            For Each dtrItem As Data.DataRow In objSubFamilia.Datos.Rows
                Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                dtrNuevo("chr_IdFamilia") = dtrItem("chr_IdFamilia")
                dtrNuevo("var_IdSubFamilia") = dtrItem("var_IdSubFamilia")
                dtrNuevo("var_Descripcion") = dtrItem("var_Descripcion")
                dtrNuevo("var_IdUnidadMedida") = dtrItem("var_IdUnidadMedida")
                objUnidadMedida.IdUnidadMedida = dtrItem("var_IdUnidadMedida")
                If objUnidadMedida.Obtener() Then
                    dtrNuevo("var_UnidadMedida") = objUnidadMedida.Descripcion
                Else
                    dtrNuevo("var_UnidadMedida") = ""
                End If
                For Each dtrFamilia As Data.DataRow In objFamilia.Datos.Select("chr_IdFamilia='" & dtrItem("chr_IdFamilia") & "'", "")
                    dtrNuevo("var_Familia") = dtrFamilia("var_Descripcion")
                Next
                dtbDatos.Rows.Add(dtrNuevo.ItemArray)
                dtbDatos.AcceptChanges()
            Next

        End If
        grdDatos.DataSource = New Data.DataView(dtbDatos, "", "var_IdSubFamilia", Data.DataViewRowState.OriginalRows)
        grdDatos.DataBind()
    End Sub


    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        If txtCodigo.Text <> "" AndAlso txtDescripcion.Text <> "" AndAlso ddlFamilia.SelectedValue <> "" Then
            Dim objSubFamilia As New ALVI_LOGIC.Maestros.Articulo.SubFamilia
            If txtCodigo.ReadOnly Then
                objSubFamilia.IdSubFamilia = txtCodigo.Text
            Else
                objSubFamilia.IdSubFamilia = ddlFamilia.SelectedValue & txtCodigo.Text
            End If

            objSubFamilia.IdFamilia = ddlFamilia.SelectedValue
            objSubFamilia.Descripcion = txtDescripcion.Text
            objSubFamilia.IdUnidadMedida = ddlUnidadMedida.SelectedValue
            objSubFamilia.Usuario = Session("Usuario")
            objSubFamilia.Estado = "ACT"
            If objSubFamilia.Registrar = True Then
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
            Dim objSubFamilia As New ALVI_LOGIC.Maestros.Articulo.SubFamilia
            objSubFamilia.IdSubFamilia = e.CommandArgument.ToString
            If objSubFamilia.Obtener = True Then
                LimpiarFormulario()
                txtCodigo.Text = objSubFamilia.IdSubFamilia
                ddlFamilia.SelectedValue = objSubFamilia.IdFamilia
                ddlUnidadMedida.SelectedValue = objSubFamilia.IdUnidadMedida
                txtDescripcion.Text = objSubFamilia.Descripcion
                txtCodigo.ReadOnly = True
                txtCodigo.MaxLength = 6
                pnlFormulario.Visible = True
            End If
        End If
        If e.CommandName = "Eliminar" Then
            Dim objSubFamilia As New ALVI_LOGIC.Maestros.Articulo.SubFamilia
            objSubFamilia.IdSubFamilia = e.CommandArgument.ToString
            If objSubFamilia.Eliminar = True Then
                BindGrid()
            End If
        End If
    End Sub

End Class
