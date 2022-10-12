
Partial Class Controles_ctlValidador_Buscar
    Inherits System.Web.UI.UserControl

    Public Property IdValidador() As String
        Get
            Return txtIdValidador.Text
        End Get
        Set(ByVal value As String)
            txtIdValidador.Text = value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return txtNombre.Text
        End Get
        Set(ByVal value As String)
            txtNombre.Text = value
        End Set
    End Property

    Public Property Apellido() As String
        Get
            Return txtApellido.Text
        End Get
        Set(ByVal value As String)
            txtApellido.Text = value
        End Set
    End Property

    Public Sub Limpia()
        txtIdValidador.Text = ""
        txtNombre.Text = ""
        txtApellido.Text = ""

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlLista.Visible = False
            txtIdValidador.Text = ""
            txtNombre.Text = ""
            txtApellido.Text = ""
        End If
    End Sub

    Private Sub BindLista()
        Dim objValidador As New ALVI_LOGIC.Maestros.Requisicion.Validador

        objValidador.IdValidador = ""
        objValidador.Nombre = ""
        objValidador.Apellidos = ""

        If txtIdValidador.Text <> "" Then
            objValidador.IdValidador = txtIdValidador.Text
        ElseIf txtNombre.Text <> "" Then
            objValidador.Nombre = Replace(txtNombre.Text, " ", "%")
        ElseIf txtApellido.Text <> "" Then
            objValidador.Apellidos = Replace(txtApellido.Text, " ", "%")

        End If


        objValidador.Buscarvalidador()
        
        dtlLista.DataSource = objValidador.Datos
        dtlLista.DataBind()
        pnlLista.Visible = True
    End Sub


    Public Sub BuscarId()
        If txtIdValidador.Text <> "" Then
            Dim objValidador As New ALVI_LOGIC.Maestros.Requisicion.Validador
            objValidador.IdValidador = txtIdValidador.Text

            If objValidador.Obtener() = True Then
                txtNombre.Text = objValidador.Nombre
                txtApellido.Text = objValidador.Apellidos

            Else
                txtNombre.Text = ""
                txtApellido.Text = ""
            End If

        End If
    End Sub

    Protected Sub btnBuscar1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar1.Click
        BindLista()
    End Sub

    Protected Sub btnBuscar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar2.Click
        BindLista()
    End Sub


    Protected Sub btnBuscar3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar3.Click
        BindLista()
    End Sub

    Protected Sub txtIdValidador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdValidador.TextChanged
        BuscarId()
    End Sub


    Protected Sub txtNombre_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        BindLista()
    End Sub


    Protected Sub txtApellido_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtApellido.TextChanged
        BindLista()
    End Sub

    Protected Sub dtlLista_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlLista.ItemCommand
        If e.CommandName = "Seleccionar" Then
            txtIdValidador.Text = e.CommandArgument.ToString
            BuscarId()
            pnlLista.Visible = False
        End If
    End Sub


End Class
