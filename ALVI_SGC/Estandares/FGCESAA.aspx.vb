
Partial Class Estandares_FGCESAA
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlFormulario.Visible = False
            BindGrid(txtBusqueda.Text)
            BindFamilia(ddlFamiliaBusqueda)

        End If
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        LimpiarFormulario()
        txtCodigo.ReadOnly = False
        txtCodigo.MaxLength = 21
        pnlFormulario.Visible = True
        txtCodigo.Focus()
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub
    Private Sub Cancelar()
        LimpiarFormulario()
        pnlFormulario.Visible = False
        BindGrid(txtBusqueda.Text)
    End Sub
    Private Sub LimpiarFormulario()
        txtCodigo.Text = ""
        txtDescripcion.Text = ""
        lblMensaje.Text = ""
        ddlSubFamilia.Items.Clear()
        BindFamilia(ddlFamilia)
        BindUnidadMedida()
        BindAtributoTipo()
        BindAtributoValor()
        CreateSchemaAtributos()
        Dim dtbAtributos As Data.DataTable = CType(Session("dtbAtributos"), Data.DataTable)
        grdAtributos.DataSource = dtbAtributos
        grdAtributos.DataBind()
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
        ddlAtributoTipo.Focus()
    End Sub
    Private Sub BindFamilia(ByRef pddlFamilia As DropDownList)
        Dim objFamilia As New ALVI_LOGIC.Maestros.Articulo.Familia
        pddlFamilia.Items.Clear()
        If objFamilia.Listar() = True Then
            pddlFamilia.DataValueField = "chr_IdFamilia"
            pddlFamilia.DataTextField = "var_Descripcion"
            pddlFamilia.DataSource = objFamilia.Datos
            pddlFamilia.DataBind()
        End If
        pddlFamilia.Items.Insert(0, New ListItem("Seleccionar", ""))
        pddlFamilia.SelectedIndex = 0
    End Sub
    Private Sub BindSubFamilia(ByRef pddlSubFamilia As DropDownList, ByVal pstrIdFamilia As String)
        Dim objSubFamilia As New ALVI_LOGIC.Maestros.Articulo.SubFamilia
        pddlSubFamilia.Items.Clear()
        objSubFamilia.IdFamilia = pstrIdFamilia
        If objSubFamilia.Listar() = True Then
            pddlSubFamilia.DataValueField = "var_IdSubFamilia"
            pddlSubFamilia.DataTextField = "var_Descripcion"
            pddlSubFamilia.DataSource = objSubFamilia.Datos
            pddlSubFamilia.DataBind()
        End If
        pddlSubFamilia.Items.Insert(0, New ListItem("Seleccionar", ""))
        pddlSubFamilia.SelectedIndex = 0
    End Sub
    Private Sub BindAtributoTipo()
        Dim objAtributo As New ALVI_LOGIC.Maestros.Articulo.Atributo.Tipo
        ddlAtributoTipo.Items.Clear()
        objAtributo.IdSubFamilia = ddlSubFamilia.SelectedValue
        If objAtributo.Listar() = True Then
            ddlAtributoTipo.DataValueField = "chr_IdAtributo"
            ddlAtributoTipo.DataTextField = "var_Descripcion"
            ddlAtributoTipo.DataSource = objAtributo.Datos
            ddlAtributoTipo.DataBind()
        End If
        ddlAtributoTipo.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlAtributoTipo.SelectedIndex = 0
    End Sub
    Private Sub BindAtributoValor()
        Dim objAtributo As New ALVI_LOGIC.Maestros.Articulo.Atributo.Valores
        ddlAtributoValor.Items.Clear()
        objAtributo.IdSubFamilia = ddlSubFamilia.SelectedValue
        objAtributo.IdAtributoTipo = ddlAtributoTipo.SelectedValue
        If objAtributo.Listar() = True Then
            ddlAtributoValor.DataValueField = "var_IdAtributoValor"
            ddlAtributoValor.DataTextField = "var_Descripcion"
            ddlAtributoValor.DataSource = New Data.DataView(objAtributo.Datos, "", "var_Descripcion", Data.DataViewRowState.OriginalRows)
            ddlAtributoValor.DataBind()
        End If
        ddlAtributoValor.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlAtributoValor.SelectedIndex = 0
    End Sub

    Private Sub CreateSchemaAtributos()
        Dim dtbAtributos As New Data.DataTable
        dtbAtributos.Columns.Add("int_Secuencia", GetType(Int16))
        dtbAtributos.Columns.Add("int_Posicion", GetType(Int16))
        dtbAtributos.Columns.Add("var_IdAtributoTipo", GetType(String))
        dtbAtributos.Columns.Add("var_IdAtributoValor", GetType(String))
        dtbAtributos.Columns.Add("var_AtributoTipo", GetType(String))
        dtbAtributos.Columns.Add("var_AtributoValor", GetType(String))
        dtbAtributos.Columns.Add("var_IdAtributo", GetType(String))
        Dim pkAtributos(1) As Data.DataColumn
        pkAtributos(0) = dtbAtributos.Columns("int_Secuencia")

        dtbAtributos.PrimaryKey = pkAtributos
        Session("dtbAtributos") = dtbAtributos

    End Sub
    Private Sub BindAtributosFromBD()
        Dim objAtributo As New ALVI_LOGIC.Maestros.Articulo.Atributo.AtributoxArticulo
        objAtributo.IdArticulo = txtCodigo.Text
        Dim dtbAtributos As Data.DataTable = CType(Session("dtbAtributos"), Data.DataTable)
        If objAtributo.Listar() Then
            Dim objAtributoValor As New ALVI_LOGIC.Maestros.Articulo.Atributo.Valores
            Dim objAtributoTipo As New ALVI_LOGIC.Maestros.Articulo.Atributo.Tipo
            objAtributoTipo.IdSubFamilia = ddlSubFamilia.SelectedValue
            objAtributoTipo.Listar()

            For Each dtrItem As Data.DataRow In objAtributo.Datos.Rows
                Dim dtrNuevo As Data.DataRow = dtbAtributos.NewRow
                dtrNuevo("int_Secuencia") = dtrItem("int_Secuencia")
                dtrNuevo("var_IdAtributoTipo") = dtrItem("chr_IdAtributo")
                dtrNuevo("var_IdAtributoValor") = dtrItem("var_IdAtributoValor")
                dtrNuevo("var_IdAtributo") = dtrItem("chr_IdAtributo") & "-" & dtrItem("var_IdAtributoValor")

                For Each dtrAuxiliar As Data.DataRow In objAtributoTipo.Datos.Select("chr_IdAtributo='" & dtrItem("chr_IdAtributo") & "'")
                    dtrNuevo("var_AtributoTipo") = dtrAuxiliar("var_Descripcion")
                    dtrNuevo("int_Posicion") = dtrAuxiliar("int_Posicion")

                    objAtributoValor.IdAtributoTipo = dtrNuevo("var_IdAtributoTipo")
                    objAtributoValor.IdValor = dtrItem("var_IdAtributoValor")
                    objAtributoValor.IdSubFamilia = ddlSubFamilia.SelectedValue
                    objAtributoValor.Obtener()
                    dtrNuevo("var_AtributoValor") = objAtributoValor.Descripcion

                Next

                dtbAtributos.Rows.Add(dtrNuevo.ItemArray)
                dtbAtributos.AcceptChanges()
            Next
        End If
        Session("dtbAtributos") = dtbAtributos
        grdAtributos.DataSource = New Data.DataView(dtbAtributos, "", "var_IdAtributoTipo asc", Data.DataViewRowState.OriginalRows)
        grdAtributos.DataBind()
        txtCodigo.Text = GenerarCodigo()
    End Sub

    Private Sub BindGrid(ByVal pstrFiltro As String)
        Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Articulo
        Dim dtbDatos As New Data.DataTable
        dtbDatos.Columns.Add("chr_IdFamilia", GetType(String))
        dtbDatos.Columns.Add("var_Familia", GetType(String))
        dtbDatos.Columns.Add("var_IdSubFamilia", GetType(String))
        dtbDatos.Columns.Add("var_SubFamilia", GetType(String))
        dtbDatos.Columns.Add("var_IdUnidadMedida", GetType(String))
        dtbDatos.Columns.Add("var_UnidadMedida", GetType(String))
        dtbDatos.Columns.Add("var_IdArticulo", GetType(String))
        dtbDatos.Columns.Add("var_Descripcion", GetType(String))
        objArticulo.IdSubFamilia = ""
        If ddlSubFamiliaBusqueda.SelectedValue <> "" Then
            objArticulo.IdSubFamilia = ddlSubFamiliaBusqueda.SelectedValue
        ElseIf ddlFamiliaBusqueda.SelectedValue <> "" Then
            objArticulo.IdSubFamilia = ddlFamiliaBusqueda.SelectedValue
        End If

        If pstrFiltro <> "" OrElse txtIdArticuloBusqueda.Text <> "" Then
            objArticulo.IdArticulo = txtIdArticuloBusqueda.Text
            objArticulo.Descripcion = pstrFiltro
            objArticulo.Buscar()
        Else
            objArticulo.Listar()
        End If

        If objArticulo.Datos.Rows.Count > 0 Then
            Dim objFamilia As New ALVI_LOGIC.Maestros.Articulo.Familia
            Dim objSubFamilia As New ALVI_LOGIC.Maestros.Articulo.SubFamilia
            Dim objUnidadMedida As New ALVI_LOGIC.Configuracion.UnidadMedida
            objFamilia.Listar()
            objSubFamilia.IdFamilia = ""
            objSubFamilia.Listar()
            objUnidadMedida.Listar()
            For Each dtrItem As Data.DataRow In objArticulo.Datos.Rows
                Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                dtrNuevo("var_IdArticulo") = dtrItem("var_IdArticulo")
                dtrNuevo("var_IdSubFamilia") = dtrItem("var_IdSubFamilia")
                dtrNuevo("var_Descripcion") = dtrItem("var_Descripcion")
                dtrNuevo("var_IdUnidadMedida") = dtrItem("var_IdUnidadMedida")
                For Each dtrSubFamilia As Data.DataRow In objSubFamilia.Datos.Select("var_IdSubFamilia='" & dtrItem("var_IdSubFamilia") & "'", "")
                    dtrNuevo("chr_IdFamilia") = dtrSubFamilia("chr_IdFamilia")
                    dtrNuevo("var_SubFamilia") = dtrSubFamilia("var_Descripcion")
                Next
                For Each dtrFamilia As Data.DataRow In objFamilia.Datos.Select("chr_IdFamilia='" & dtrNuevo("chr_IdFamilia") & "'", "")
                    dtrNuevo("var_Familia") = dtrFamilia("var_Descripcion")
                Next
                For Each dtrUnidad As Data.DataRow In objUnidadMedida.Datos.Select("var_IdUnidadMedida='" & dtrItem("var_IdUnidadMedida") & "'", "")
                    dtrNuevo("var_UnidadMedida") = dtrUnidad("var_Descripcion")
                Next
                dtbDatos.Rows.Add(dtrNuevo.ItemArray)
                dtbDatos.AcceptChanges()
            Next

        End If
        grdDatos.DataSource = New Data.DataView(dtbDatos, "", "var_IdSubFamilia, var_IdArticulo", Data.DataViewRowState.OriginalRows)
        grdDatos.DataBind()

    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        Registrar()
        txtCodigo.Focus()
    End Sub

    Private Sub Registrar()
        If txtCodigo.Text <> "" AndAlso txtDescripcion.Text <> "" _
            AndAlso ddlFamilia.SelectedValue <> "" AndAlso ddlSubFamilia.SelectedValue <> "" Then
            Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Articulo

            objArticulo.IdArticulo = txtCodigo.Text

            objArticulo.IdSubFamilia = ddlSubFamilia.SelectedValue
            objArticulo.IdUnidadMedida = ddlUnidadMedida.SelectedValue
            objArticulo.Descripcion = txtDescripcion.Text
            objArticulo.Usuario = Session("Usuario")
            objArticulo.Estado = "ACT"
            If objArticulo.Registrar = True Then
                Dim dtbAtributos As Data.DataTable = CType(Session("dtbAtributos"), Data.DataTable)

                For Each dtrAtributo As Data.DataRow In dtbAtributos.Rows
                    Dim objAtributo As New ALVI_LOGIC.Maestros.Articulo.Atributo.AtributoxArticulo
                    objAtributo.IdArticulo = txtCodigo.Text
                    objAtributo.IdSubFamilia = ddlSubFamilia.SelectedValue
                    objAtributo.IdAtributoTipo = dtrAtributo("var_IdAtributoTipo")
                    objAtributo.IdValor = dtrAtributo("var_IdAtributoValor")
                    objAtributo.Usuario = Session("Usuario")
                    objAtributo.Estado = "ACT"
                    objAtributo.Secuencia = dtrAtributo("int_Secuencia")
                    objAtributo.Registrar()
                Next

                LimpiarFormulario()
                lblMensaje.Text = "Registro exitoso"
                dtbAtributos.Rows.Clear()
                grdAtributos.DataSource = dtbAtributos
                grdAtributos.DataBind()

                grdDatos.EditIndex = -1
                BindGrid(txtBusqueda.Text)
            End If
        Else
            lblMensaje.Text = "Faltan Datos"
        End If

    End Sub
    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        Response.Redirect("default.aspx")

    End Sub

    Protected Sub grdDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDatos.PageIndexChanging
        grdDatos.PageIndex = e.NewPageIndex
        Buscar()
    End Sub

    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        If e.CommandName = "Modificar" Then
            Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Articulo
            Dim objSubFamilia As New ALVI_LOGIC.Maestros.Articulo.SubFamilia
            objArticulo.IdArticulo = e.CommandArgument.ToString
            If objArticulo.Obtener = True Then
                LimpiarFormulario()
                txtCodigo.Text = objArticulo.IdArticulo
                txtDescripcion.Text = objArticulo.Descripcion
                objSubFamilia.IdSubFamilia = objArticulo.IdSubFamilia
                objSubFamilia.Obtener()

                ddlFamilia.SelectedValue = objSubFamilia.IdFamilia
                BindSubFamilia(ddlSubFamilia, ddlFamilia.SelectedValue)

                ddlSubFamilia.SelectedValue = objArticulo.IdSubFamilia

                ddlUnidadMedida.SelectedValue = objArticulo.IdUnidadMedida
                ddlUnidadMedida.Enabled = False
                BindAtributosFromBD()
                BindAtributoTipo()
                BindAtributoValor()

                txtCodigo.ReadOnly = True
                txtCodigo.MaxLength = 20
                pnlFormulario.Visible = True
            End If
        End If
        If e.CommandName = "Eliminar" Then
            Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Articulo
            objArticulo.IdArticulo = e.CommandArgument.ToString
            If objArticulo.Eliminar = True Then
                BindGrid(txtBusqueda.Text)
            End If
        End If
    End Sub

    Protected Sub ddlFamilia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlFamilia.SelectedIndexChanged
        BindSubFamilia(ddlSubFamilia, ddlFamilia.SelectedValue)
        txtCodigo.Text = GenerarCodigo()
        CreateSchemaAtributos()
        grdAtributos.DataSource = CType(Session("dtbAtributos"), Data.DataTable)
        grdAtributos.DataBind()
        ddlSubFamilia.Focus()
    End Sub

    Protected Sub ddlSubFamilia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSubFamilia.SelectedIndexChanged
        BindAtributoTipo()
        Dim objSubFamila As New ALVI_LOGIC.Maestros.Articulo.SubFamilia
        objSubFamila.IdSubFamilia = ddlSubFamilia.SelectedValue
        objSubFamila.Obtener()
        If objSubFamila.IdUnidadMedida <> "" Then
            ddlUnidadMedida.SelectedValue = objSubFamila.IdUnidadMedida
            ddlUnidadMedida.Enabled = False
        Else
            ddlUnidadMedida.Enabled = True
        End If
        txtCodigo.Text = GenerarCodigo()
        CreateSchemaAtributos()
        grdAtributos.DataSource = CType(Session("dtbAtributos"), Data.DataTable)
        grdAtributos.DataBind()
        ddlUnidadMedida.Focus()
    End Sub

    Protected Sub ddlAtributoTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAtributoTipo.SelectedIndexChanged
        BindAtributoValor()
        ddlAtributoValor.Focus()
    End Sub

    Protected Sub btnAsignar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAsignar.Click
        If ddlAtributoTipo.SelectedValue <> "" AndAlso ddlAtributoValor.SelectedValue <> "" Then
            Dim dtbAtributos As Data.DataTable = CType(Session("dtbAtributos"), Data.DataTable)
            Dim objAtributoTipo As New ALVI_LOGIC.Maestros.Articulo.Atributo.Tipo
            Dim dtrNuevo As Data.DataRow = dtbAtributos.NewRow
            Dim intSecuencia As Int16 = 0
            If dtbAtributos.Rows.Count > 0 Then
                intSecuencia = -1
                For Each dtrItem As Data.DataRow In dtbAtributos.Select("var_IdAtributoTipo='" & ddlAtributoTipo.SelectedItem.Value & "'")
                    intSecuencia = dtrItem("int_Secuencia")
                Next
                If intSecuencia = -1 Then
                    intSecuencia = dtbAtributos.Compute("Max(int_Secuencia)", "") + 1
                End If
            End If

            dtrNuevo("int_Secuencia") = intSecuencia
            dtrNuevo("var_IdAtributoTipo") = ddlAtributoTipo.SelectedItem.Value
            dtrNuevo("var_IdAtributoValor") = ddlAtributoValor.SelectedItem.Value
            dtrNuevo("var_AtributoValor") = ddlAtributoValor.SelectedItem.Text
            dtrNuevo("var_AtributoTipo") = ddlAtributoTipo.SelectedItem.Text
            dtrNuevo("var_IdAtributo") = dtrNuevo("var_IdAtributoTipo") & "-" & dtrNuevo("var_IdAtributoValor")

            objAtributoTipo.IdSubFamilia = ddlSubFamilia.SelectedValue
            objAtributoTipo.IdAtributoTipo = ddlAtributoTipo.SelectedValue
            If objAtributoTipo.Obtener Then
                dtrNuevo("int_Posicion") = objAtributoTipo.Posicion
            End If

            dtbAtributos.LoadDataRow(dtrNuevo.ItemArray, True)
            dtbAtributos.AcceptChanges()

            Session("dtbAtributos") = dtbAtributos
            grdAtributos.DataSource = dtbAtributos
            grdAtributos.DataBind()
            txtCodigo.Text = GenerarCodigo()
            ddlAtributoTipo.Focus()
        End If
    End Sub

    Private Function GenerarCodigo() As String
        Dim strFormato(16) As String
        Dim strDescripcion As String = ""
        Dim intPosicion As Int16
        For Indice As Int16 = 0 To 7
            strFormato(Indice) = "0"
        Next
        If ddlFamilia.SelectedValue <> "" AndAlso ddlSubFamilia.SelectedValue <> "" Then
            intPosicion = 0
            If ddlSubFamilia.SelectedValue <> "" Then
                For Each strItem As String In ddlSubFamilia.SelectedValue
                    strFormato(intPosicion) = strItem
                    intPosicion = intPosicion + 1
                Next
                strDescripcion = ddlSubFamilia.SelectedItem.Text & " "

            End If
        End If
        Dim dtbAtributos As Data.DataTable = CType(Session("dtbAtributos"), Data.DataTable)
        For Each dtrItem As Data.DataRow In dtbAtributos.Select("", "int_Posicion asc")
            If dtrItem("int_Posicion") > 0 AndAlso (dtrItem("int_Posicion") - 1 + Len(dtrItem("var_IdAtributoValor"))) <= 8 Then
                intPosicion = dtrItem("int_Posicion")
                For Each strItem As String In dtrItem("var_IdAtributoValor")
                    strFormato(intPosicion - 1) = strItem
                    intPosicion = intPosicion + 1
                Next
            End If
        Next
        For Each dtrItem As Data.DataRow In dtbAtributos.Select("", "var_IdAtributoTipo asc")
            strDescripcion = strDescripcion & " " & dtrItem("var_AtributoValor")
        Next
        txtDescripcion.Text = strDescripcion

        Dim strIdArticulo As String = Join(strFormato, "")
        Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Articulo
        Dim strSufijo As String = "01"
        objArticulo.IdSubFamilia = ddlSubFamilia.SelectedValue
        If objArticulo.Listar() Then
            For Each dtrItem As Data.DataRow In objArticulo.Datos.Select("var_IdArticulo like '" & strIdArticulo & "%'", "var_IdArticulo DESC")
                If CInt(strSufijo) <= CInt(Right(dtrItem("var_IdArticulo"), 2)) Then
                    strSufijo = Format(CInt(Right(dtrItem("var_IdArticulo"), 2)) + 1, "00")
                End If
            Next

        End If

        Return strIdArticulo & strSufijo
    End Function

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTerminar.Click
        Registrar()
        Cancelar()
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        Buscar()
    End Sub

    Private Sub Buscar()
        Dim strBuscar As String = ""
        If txtBusqueda.Text <> "" Then
            strBuscar = Replace(txtBusqueda.Text, " ", "%")
        End If
        BindGrid(strBuscar)
    End Sub

    Protected Sub ddlFamiliaBusqueda_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlFamiliaBusqueda.SelectedIndexChanged
        BindSubFamilia(ddlSubFamiliaBusqueda, ddlFamiliaBusqueda.SelectedValue)
    End Sub
End Class
