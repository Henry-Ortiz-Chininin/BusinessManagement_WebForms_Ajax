
Partial Class Estandares_FGCESAM
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlFormulario.Visible = False
            BindGrid()
            BindFamilia(ddlFamiliaTop)
            BindSubFamilia(ddlSubFamiliaTop, ddlFamiliaTop.SelectedValue)

            If Request("IdFamilia") <> "" AndAlso Request("IdSubFamilia") <> "" Then
                Dim objSeguridad As New ALVI_Security.General
                BindFamilia(ddlFamiliaTop)
                ddlFamiliaTop.SelectedValue = objSeguridad.Decrypta(Request("IdFamilia"))
                BindSubFamilia(ddlSubFamiliaTop, ddlFamiliaTop.SelectedValue)
                ddlSubFamiliaTop.SelectedValue = objSeguridad.Decrypta(Request("IdSubFamilia"))
                BindGrid()

            End If
        End If
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        LimpiarFormulario()
        Dim dtbDatos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
        If dtbDatos.Rows.Count > 0 Then
            Dim intSecuencial As Int16 = CInt(dtbDatos.Compute("Max(var_IdAtributoTipo)", ""))
            txtCodigo.Text = Format(intSecuencial + 1, "00")
        Else
            txtCodigo.Text = "00"
        End If
        txtCodigo.ReadOnly = False
        txtCodigo.MaxLength = 14
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
        txtPosicion.Text = "0"
        BindFamilia(ddlFamilia)
        BindSubFamilia(ddlSubFamilia, ddlFamilia.SelectedValue)
    End Sub

    Private Sub BindFamilia(ByRef ddlDestino As DropDownList)
        Dim objFamilia As New ALVI_LOGIC.Maestros.Articulo.Familia
        ddlDestino.Items.Clear()
        If objFamilia.Listar() = True Then
            ddlDestino.DataValueField = "chr_IdFamilia"
            ddlDestino.DataTextField = "var_Descripcion"
            ddlDestino.DataSource = objFamilia.Datos
            ddlDestino.DataBind()
        End If
        ddlDestino.Items.Insert(0, "Seleccionar")
        ddlDestino.SelectedIndex = 0
    End Sub
    Private Sub BindSubFamilia(ByRef ddlDestino As DropDownList, ByVal strIdFamilia As String)
        Dim objSubFamilia As New ALVI_LOGIC.Maestros.Articulo.SubFamilia
        ddlDestino.Items.Clear()
        objSubFamilia.IdFamilia = strIdFamilia
        If objSubFamilia.Listar() = True Then
            ddlDestino.DataValueField = "var_IdSubFamilia"
            ddlDestino.DataTextField = "var_Descripcion"
            ddlDestino.DataSource = objSubFamilia.Datos
            ddlDestino.DataBind()
        End If
        ddlDestino.Items.Insert(0, "Seleccionar")
        ddlDestino.SelectedIndex = 0
    End Sub

    Private Sub BindGrid()
        Dim objAtributo As New ALVI_LOGIC.Maestros.Articulo.Atributo.Tipo
        Dim dtbDatos As New Data.DataTable
        dtbDatos.Columns.Add("var_Codigo", GetType(String))
        dtbDatos.Columns.Add("chr_IdFamilia", GetType(String))
        dtbDatos.Columns.Add("var_Familia", GetType(String))
        dtbDatos.Columns.Add("var_IdSubFamilia", GetType(String))
        dtbDatos.Columns.Add("var_SubFamilia", GetType(String))
        dtbDatos.Columns.Add("var_IdAtributoTipo", GetType(String))
        dtbDatos.Columns.Add("var_Descripcion", GetType(String))
        dtbDatos.Columns.Add("int_Posicion", GetType(Int16))

        objAtributo.IdSubFamilia = ddlSubFamiliaTop.SelectedValue

        If objAtributo.Listar() = True Then
            Dim objFamilia As New ALVI_LOGIC.Maestros.Articulo.Familia
            Dim objSubFamilia As New ALVI_LOGIC.Maestros.Articulo.SubFamilia
            objFamilia.Listar()
            objSubFamilia.IdFamilia = ""
            objSubFamilia.Listar()
            For Each dtrItem As Data.DataRow In objAtributo.Datos.Rows
                Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                dtrNuevo("var_IdAtributoTipo") = dtrItem("chr_IdAtributo")
                dtrNuevo("var_IdSubFamilia") = dtrItem("var_IdSubFamilia")
                dtrNuevo("var_Descripcion") = dtrItem("var_Descripcion")
                dtrNuevo("int_Posicion") = dtrItem("int_Posicion")
                For Each dtrSubFamilia As Data.DataRow In objSubFamilia.Datos.Select("var_IdSubFamilia='" & dtrItem("var_IdSubFamilia") & "'", "")
                    dtrNuevo("chr_IdFamilia") = dtrSubFamilia("chr_IdFamilia")
                    dtrNuevo("var_SubFamilia") = dtrSubFamilia("var_Descripcion")
                Next
                For Each dtrFamilia As Data.DataRow In objFamilia.Datos.Select("chr_IdFamilia='" & dtrNuevo("chr_IdFamilia") & "'", "")
                    dtrNuevo("var_Familia") = dtrFamilia("var_Descripcion")
                Next
                dtrNuevo("var_Codigo") = dtrNuevo("chr_IdFamilia") & "-" & dtrNuevo("var_IdSubFamilia") & "-" & dtrItem("chr_IdAtributo")

                dtbDatos.Rows.Add(dtrNuevo.ItemArray)
                dtbDatos.AcceptChanges()
            Next

        End If
        Session("dtbDatos") = dtbDatos
        grdDatos.DataSource = New Data.DataView(dtbDatos, "", "var_Codigo", Data.DataViewRowState.OriginalRows)
        grdDatos.DataBind()

    End Sub


    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        If txtCodigo.Text <> "" AndAlso txtDescripcion.Text <> "" AndAlso txtPosicion.Text <> "" _
        AndAlso ddlFamilia.SelectedValue <> "" AndAlso ddlSubFamilia.SelectedValue <> "" Then
            Dim objAtributo As New ALVI_LOGIC.Maestros.Articulo.Atributo.Tipo
            objAtributo.IdAtributoTipo = txtCodigo.Text
            objAtributo.IdSubFamilia = ddlSubFamilia.SelectedValue
            objAtributo.Descripcion = txtDescripcion.Text
            objAtributo.Posicion = txtPosicion.Text
            objAtributo.Usuario = Session("Usuario")
            objAtributo.Estado = "ACT"
            If objAtributo.Registrar = True Then
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
            Dim dtbDatos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
            For Each dtrItem As Data.DataRow In dtbDatos.Select("var_Codigo='" & e.CommandArgument.ToString & "'")
                txtCodigo.Text = dtrItem("var_IdAtributoTipo")
                txtDescripcion.Text = dtrItem("var_Descripcion")
                txtPosicion.Text = dtrItem("int_Posicion")
                BindFamilia(ddlFamilia)
                ddlFamilia.SelectedValue = dtrItem("chr_IdFamilia")
                BindSubFamilia(ddlSubFamilia, dtrItem("chr_IdFamilia"))
                ddlSubFamilia.SelectedValue = dtrItem("var_IdSubFamilia")
            Next
            pnlFormulario.Visible = True
            txtCodigo.ReadOnly = True
        End If
        If e.CommandName = "Detalle" Then
            Dim strParametros() As String = Split(e.CommandArgument.ToString, "-")
            Dim objSecurity As New ALVI_Security.General
            Dim strURL As String = "FGCESAN.ASPX"
            strURL = strURL & "?IdSeccion=" & Master.IdSeccion
            strURL = strURL & "&IdMenu=" & Master.IdMenu
            strURL = strURL & "&IdSubMenu=" & Master.IdSubMenu
            strURL = strURL & "&IdFA=" & objSecurity.Encrypta(strParametros(0))
            strURL = strURL & "&IdSF=" & objSecurity.Encrypta(strParametros(1))
            strURL = strURL & "&IdAT=" & objSecurity.Encrypta(strParametros(2))

            Response.Redirect(strURL)
        End If
        If e.CommandName = "Eliminar" Then
            Dim objAtributo As New ALVI_LOGIC.Maestros.Articulo.Atributo.Tipo
            Dim strParametros() As String = Split(e.CommandArgument.ToString, "-")
            objAtributo.IdSubFamilia = strParametros(1)
            objAtributo.IdAtributoTipo = strParametros(2)
            If objAtributo.Eliminar = True Then
                BindGrid()
            End If
        End If
    End Sub

    Protected Sub ddlFamilia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlFamilia.SelectedIndexChanged
        BindSubFamilia(ddlSubFamilia, ddlFamilia.SelectedValue)
    End Sub

    Protected Sub ddlFamiliaTop_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlFamiliaTop.SelectedIndexChanged
        BindSubFamilia(ddlSubFamiliaTop, ddlFamiliaTop.SelectedValue)
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        BindGrid()
    End Sub
End Class
