
Partial Class Controles_ctlSolicitante_Buscar
    Inherits System.Web.UI.UserControl

    Private _bolSoloLectura As Boolean = False
    Public Property SoloLectura As Boolean
        Get
            Return _bolSoloLectura
        End Get
        Set(ByVal value As Boolean)
            _bolSoloLectura = value

            txtIdSolicitante.Enabled = Not _bolSoloLectura
            txtNombre.Enabled = Not _bolSoloLectura
            txtApellido.Enabled = Not _bolSoloLectura
            btnBuscar1.Visible = Not _bolSoloLectura
            btnBuscar2.Visible = Not _bolSoloLectura
            btnBuscar3.Visible = Not _bolSoloLectura
        End Set
    End Property

    Public Property IdSolicitante() As String
        Get
            Return txtIdSolicitante.Text
        End Get
        Set(ByVal value As String)
            txtIdSolicitante.Text = value
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
        txtIdSolicitante.Text = ""
        txtNombre.Text = ""
        txtApellido.Text = ""

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlLista.Visible = False
            ' txtIdSolicitante.Text = ""
            'txtNombre.Text = ""
            'txtApellido.Text = ""
        End If
    End Sub

    Private Sub BindLista()
        Dim objSolicitante As New ALVI_LOGIC.Maestros.Requisicion.Solicitante


        objSolicitante.IdSolicitante = ""
        objSolicitante.Nombre = ""
        objSolicitante.Apellidos = ""

        If txtIdSolicitante.Text <> "" Then
            objSolicitante.IdSolicitante = txtIdSolicitante.Text
        ElseIf txtNombre.Text <> "" Then
            objSolicitante.Nombre = Replace(txtNombre.Text, " ", "%")
        ElseIf txtApellido.Text <> "" Then
            objSolicitante.Apellidos = Replace(txtApellido.Text, " ", "%")

        End If


        objSolicitante.Buscar1()
        Dim dtbDatos As Data.DataTable = objSolicitante.Datos

        Dim dtvDatos As New Data.DataView(dtbDatos, "", "var_IdSolicitante", Data.DataViewRowState.OriginalRows)
        dtlLista.DataSource = dtvDatos
        dtlLista.DataBind()
        pnlLista.Visible = True
    End Sub


    Public Sub BuscarId()
        If txtIdSolicitante.Text <> "" Then
            Dim objSolicitante As New ALVI_LOGIC.Maestros.Requisicion.Solicitante
            objSolicitante.IdSolicitante = txtIdSolicitante.Text
            If objSolicitante.Obtener() = True Then
                txtNombre.Text = objSolicitante.Nombre

            Else
                txtNombre.Text = ""

            End If

            If objSolicitante.Obtener() = True Then
                txtApellido.Text = objSolicitante.ApellidoPaterno + " " + objSolicitante.ApellidoMaterno

            Else
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





    Protected Sub txtIdSolicitante_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdSolicitante.TextChanged
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
            txtIdSolicitante.Text = e.CommandArgument.ToString
            BuscarId()
            pnlLista.Visible = False
        End If
    End Sub

 
End Class
