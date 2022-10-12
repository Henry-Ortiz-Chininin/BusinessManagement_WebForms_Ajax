
Partial Class Controles_ctlValidacion_Registro
    Inherits System.Web.UI.UserControl

    Private _strIdRequisicion As String
    Public Property IdRequisicion As String
        Get
            Return _strIdRequisicion
        End Get
        Set(ByVal value As String)
            _strIdRequisicion = value
        End Set
    End Property

    Private Function CreateSchema() As Data.DataTable
        Dim dtbValidador As New Data.DataTable
        dtbValidador.Columns.Add("IdValidador", GetType(String))
        dtbValidador.Columns.Add("Validador", GetType(String))
        dtbValidador.Columns.Add("Cargo", GetType(String))
        dtbValidador.Columns.Add("Area", GetType(String))
        dtbValidador.Columns.Add("IdEstado", GetType(String))
        dtbValidador.Columns.Add("Estado", GetType(String))

        Dim pkValidador(1) As Data.DataColumn
        pkValidador(0) = dtbValidador.Columns(0)

        dtbValidador.PrimaryKey = pkValidador
        Return dtbValidador
    End Function

    Private Sub LoadFromGrid(ByRef dtbValidador As Data.DataTable)

        For Each itmValidador As GridViewRow In grdValidador.Rows
            Dim dtrNuevo As Data.DataRow = dtbValidador.NewRow
            dtrNuevo("IdValidador") = itmValidador.Cells(0).Text
            dtrNuevo("Validador") = itmValidador.Cells(1).Text
            dtrNuevo("Cargo") = itmValidador.Cells(2).Text
            dtrNuevo("Area") = itmValidador.Cells(3).Text
            dtrNuevo("IdEstado") = itmValidador.Cells(4).Text
            dtrNuevo("Estado") = itmValidador.Cells(5).Text

            dtbValidador.LoadDataRow(dtrNuevo.ItemArray, True)
            dtbValidador.AcceptChanges()
        Next

    End Sub

    Private Sub BindGrid()

        Dim objValidacion As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Validacion
        objValidacion.IdRequisicion = hdnIdRequisicion.Value
        If objValidacion.Listar Then
            grdValidador.DataSource = New Data.DataView(objValidacion.Datos, "", "var_IdRequisicion", Data.DataViewRowState.OriginalRows)
            grdValidador.DataBind()

        End If
    End Sub

    Public Sub CargarValidacion()
        CreateSchema()
        Dim objValidacion As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Validacion
        objValidacion.IdRequisicion = _strIdRequisicion
        objValidacion.Listar()

        hdnIdRequisicion.Value = objValidacion.IdRequisicion
        Session("Requisicion") = hdnIdRequisicion.Value

        BindGrid()

        
        'Dim dtbValidador As Data.DataTable = CreateSchema()

        'For Each dtrItem As Data.DataRow In objValidacion.Datos.Rows
        '    Dim dtrNuevo As Data.DataRow = dtbValidador.NewRow
        '    dtrNuevo("IdValidador") = dtrItem("var_IdValidador")
        '    dtrNuevo("Validador") = dtrItem("var_Validador")
        '    dtrNuevo("Cargo") = dtrItem("var_Cargo")
        '    dtrNuevo("Area") = dtrItem("var_Area")
        '    dtrNuevo("IdEstado") = dtrItem("chr_IdEstado")
        '    dtrNuevo("Estado") = dtrItem("Estado")

        '    dtbValidador.LoadDataRow(dtrNuevo.ItemArray, True)
        '    dtbValidador.AcceptChanges()
        'Next
        'BindGrid(dtbValidador)


    End Sub
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            'Dim objValidacion As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Validacion
            ' objValidacion.IdRequisicion = _strIdRequisicion
            ' BindGrid(IdRequisicion)




        End If
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        Cerrar()

    End Sub

    Private Function Registrar() As Boolean

        Dim objValidador As New ALVI_LOGIC.Maestros.Requisicion.Validador
        Dim objUsuario As New ALVI_Security.clsUsuario

        'Dim dtbValidador As Data.DataTable = CreateSchema()
        'LoadFromGrid(dtbValidador)


        'OBTENERMOS LOS DATOS DEL VALIDADOR
        objValidador.IdValidador = ctlValidador.IdValidador
        objValidador.Obtener()

        'VALIDAMOS EL USUARIO Y CLAVE
        If objUsuario.Obtener(txtLogin.Text, txtClave.Text) = False Then
            lblMensaje.Text = "Acceso incorrecto"
            Return False
        End If

        If ctlValidador.IdValidador = "" Then
            lblMensaje.Text = "Validador requerido"
            Return False
        End If

        If ddlEstado.SelectedValue = "" Then
            lblMensaje.Text = "Debe asignar estado"
            Return False
        End If


        'Try
        '    'REGISTRAMOS EN LA TABLA
        '    Dim dtrNuevo As Data.DataRow = dtbValidador.NewRow
        '    dtrNuevo("IdValidador") = ctlValidador.IdValidador
        '    dtrNuevo("Validador") = ctlValidador.Nombre
        '    dtrNuevo("Cargo") = objValidador.Cargo
        '    dtrNuevo("Area") = objValidador.Area
        '    dtrNuevo("IdEstado") = ddlEstado.SelectedValue
        '    dtrNuevo("Estado") = ddlEstado.SelectedItem.Text

        '    dtbValidador.LoadDataRow(dtrNuevo.ItemArray, True)
        '    dtbValidador.AcceptChanges()
        '    BindGrid(dtbValidador)
        '    Return True
        'Catch ex As Exception
        '    BindGrid(dtbValidador)
        '    Return False
        'End Try



        ''REGISTRAR DEFRENTE A LA BD
        objValidador.IdRequisicion = Session("Requisicion")
        objValidador.IdValidador = ctlValidador.IdValidador
        objValidador.Estado = ddlEstado.SelectedValue

        If objValidador.RegistrarValidacion = True Then
            lblMensaje.Text = "Registro exitoso"
            BindGrid()
            Return True
        Else
            lblMensaje.Text = "Datos Incorrectos"
            Return False

        End If

    End Function

    Private Sub Cerrar()
        Dim pnlValidadorRegistro As Panel = CType(Parent.FindControl("pnlValidadorRegistro"), Panel)
        pnlValidadorRegistro.Visible = False
    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        Registrar()
    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTerminar.Click
        If Registrar() = True Then
            Cerrar()
        End If

    End Sub
End Class
