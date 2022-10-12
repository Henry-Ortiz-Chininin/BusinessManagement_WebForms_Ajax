
Partial Class Controles_ctlArticuloConstruir
    Inherits System.Web.UI.UserControl

    Public Property IdSubFamilia As String
        Get
            Return hdnIdSubFamilia.Value
        End Get
        Set(ByVal value As String)
            hdnIdSubFamilia.Value = value
        End Set
    End Property
    Public Property IdArticulo As String
        Get
            Return txtCodigo.Text
        End Get
        Set(ByVal value As String)
            txtCodigo.Text = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return txtDescripcion.Text
        End Get
        Set(ByVal value As String)
            txtDescripcion.Text = value
        End Set
    End Property

    Public Sub Cargar()
        BindAtributoTipo()
        'CreateSchemaAtributos()
    End Sub

    Private Sub BindAtributoTipo()
        Dim objAtributo As New ALVI_LOGIC.Maestros.Articulo.Atributo.Tipo
        ddlAtributoTipo.Items.Clear()
        objAtributo.IdSubFamilia = hdnIdSubFamilia.Value
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
        objAtributo.IdSubFamilia = hdnIdSubFamilia.Value
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

    Public Sub ReBuilSchema(ByVal pstrIdArticulo As String)
        CreateSchemaAtributos()
        Dim dtbAtributos As Data.DataTable = CType(Session("dtbAtributos"), Data.DataTable)
        Dim objAtributoTipo As New ALVI_LOGIC.Maestros.Articulo.Atributo.Tipo

        objAtributoTipo.IdSubFamilia = Left(pstrIdArticulo, 4)
        objAtributoTipo.Listar()
        Dim intSecuencial As Integer = 0
        For Each dtrItem As Data.DataRow In objAtributoTipo.Datos.Select("int_Posicion>0", "int_Posicion")
            intSecuencial = intSecuencial + 1
            Dim objAtributoValor As New ALVI_LOGIC.Maestros.Articulo.Atributo.Valores
            Dim dtrNuevo As Data.DataRow = dtbAtributos.NewRow
            Dim intLongitud As Integer = 0
            objAtributoValor.IdSubFamilia = dtrItem("var_IdSubFamilia")
            objAtributoValor.IdAtributoTipo = dtrItem("chr_IdAtributo")
            objAtributoValor.Listar()
            intLongitud = Len(objAtributoValor.Datos.Rows(0)("var_IdAtributoValor"))

            dtrNuevo("int_Secuencia") = intSecuencial
            dtrNuevo("int_Posicion") = dtrItem("int_Posicion")
            dtrNuevo("var_IdAtributoTipo") = dtrItem("chr_IdAtributo")
            dtrNuevo("var_IdAtributoValor") = pstrIdArticulo.Substring(dtrItem("int_Posicion") - 1, intLongitud)
            For Each dtrValor As Data.DataRow In objAtributoValor.Datos.Select("var_IdAtributoValor = '" & dtrNuevo("var_IdAtributoValor") & "'")
                dtrNuevo("var_AtributoValor") = dtrValor("var_Descripcion")
            Next

            dtrNuevo("var_AtributoTipo") = dtrItem("var_Descripcion")

            dtrNuevo("var_IdAtributo") = dtrNuevo("var_IdAtributoTipo") & "-" & dtrNuevo("var_IdAtributoValor")

            dtbAtributos.LoadDataRow(dtrNuevo.ItemArray, True)
            dtbAtributos.AcceptChanges()

        Next


        Session("dtbAtributos") = dtbAtributos

        grdAtributos.DataSource = dtbAtributos
        grdAtributos.DataBind()
    End Sub

    Public Sub BuilSchema(ByVal pstrIdArticulo As String)
        CreateSchemaAtributos()
        Dim dtbAtributos As Data.DataTable = CType(Session("dtbAtributos"), Data.DataTable)

        Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Atributo.AtributoxArticulo
        objArticulo.IdArticulo = pstrIdArticulo
        objArticulo.Listar()
        For Each dtrItem As Data.DataRow In objArticulo.Datos.Rows
            Dim dtrNuevo As Data.DataRow = dtbAtributos.NewRow

            dtrNuevo("int_Secuencia") = dtrItem("int_Secuencia")
            dtrNuevo("int_Posicion") = dtrItem("int_Posicion")
            dtrNuevo("var_IdAtributoTipo") = dtrItem("var_IdAtributoTipo")
            dtrNuevo("var_IdAtributoValor") = dtrItem("var_IdAtributoValor")
            dtrNuevo("var_AtributoTipo") = dtrItem("var_AtributoTipo")
            dtrNuevo("var_AtributoValor") = dtrItem("var_AtributoValor")
            dtrNuevo("var_IdAtributo") = dtrNuevo("var_IdAtributoTipo") & "-" & dtrNuevo("var_IdAtributoValor")

            dtbAtributos.LoadDataRow(dtrNuevo.ItemArray, True)
            dtbAtributos.AcceptChanges()
        Next
        Session("dtbAtributos") = dtbAtributos

        grdAtributos.DataSource = dtbAtributos
        grdAtributos.DataBind()
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

            objAtributoTipo.IdSubFamilia = hdnIdSubFamilia.Value
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

    Public Function GenerarCodigo() As String
        Dim strFormato(16) As String
        Dim strDescripcion As String = ""
        Dim intPosicion As Int16
        For Indice As Int16 = 0 To 15
            strFormato(Indice) = "0"
        Next
        If hdnIdSubFamilia.Value <> "" Then
            intPosicion = 0
            If hdnIdSubFamilia.Value <> "" Then
                For Each strItem As String In hdnIdSubFamilia.Value
                    strFormato(intPosicion) = strItem
                    intPosicion = intPosicion + 1
                Next
                strDescripcion = hdnIdSubFamilia.Value & " "

            End If
        End If
        Dim dtbAtributos As Data.DataTable = CType(Session("dtbAtributos"), Data.DataTable)
        For Each dtrItem As Data.DataRow In dtbAtributos.Select("", "int_Posicion asc")
            If dtrItem("int_Posicion") > 0 AndAlso (dtrItem("int_Posicion") - 1 + Len(dtrItem("var_IdAtributoValor"))) <= 16 Then
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
        Dim strSufijo As String = "0001"
        objArticulo.IdSubFamilia = hdnIdSubFamilia.Value
        If objArticulo.Listar() Then
            For Each dtrItem As Data.DataRow In objArticulo.Datos.Select("var_IdArticulo like '" & strIdArticulo & "%'", "var_IdArticulo DESC")
                If CInt(strSufijo) <= CInt(Right(dtrItem("var_IdArticulo"), 4)) Then
                    strSufijo = Format(CInt(Right(dtrItem("var_IdArticulo"), 4)) + 1, "0000")
                End If
            Next

        End If
        txtCodigo.Text = strIdArticulo & strSufijo
        Return strIdArticulo & strSufijo
    End Function


End Class
