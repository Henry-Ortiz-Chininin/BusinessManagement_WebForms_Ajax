
Partial Class Controles_ctlProyecto_Buscar
    Inherits System.Web.UI.UserControl

    Private _bolSoloLectura As Boolean = False
    Public Property SoloLectura As Boolean
        Get
            Return _bolSoloLectura
        End Get
        Set(ByVal value As Boolean)
            _bolSoloLectura = value

            txtIdProyecto.Enabled = Not _bolSoloLectura
            txtNombre.Enabled = Not _bolSoloLectura
            btnBuscar1.Visible = Not _bolSoloLectura
            btnBuscar2.Visible = Not _bolSoloLectura
        End Set
    End Property

    Public Property IdProyecto() As String
        Get
            Return txtIdProyecto.Text
        End Get
        Set(ByVal value As String)
            txtIdProyecto.Text = value
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




    Public Sub Limpia()
        txtIdProyecto.Text = ""
        txtNombre.Text = ""

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlLista.Visible = False
            'txtIdProyecto.Text = ""
            'txtNombre.Text = ""
        End If
    End Sub


    Private Sub BindLista()
        Dim objProyecto As New ALVI_LOGIC.Maestros.Compras.Proyectos
        Dim srtCriterio As String = ""

        objProyecto.IdCodigo = ""
        objProyecto.Nombre = ""
        If txtIdProyecto.Text <> "" Then
            objProyecto.IdCodigo = txtIdProyecto.Text
        ElseIf txtNombre.Text <> "" Then
            objProyecto.Nombre = Replace(txtNombre.Text, " ", "%")
        End If

        objProyecto.Buscar1()
        Dim dtbDatos As Data.DataTable = objProyecto.Datos

        Dim dtvDatos As New Data.DataView(dtbDatos, "", "var_IdProyecto", Data.DataViewRowState.OriginalRows)
        dtlLista.DataSource = dtvDatos
        dtlLista.DataBind()
        pnlLista.Visible = True
    End Sub


    Public Sub BuscarId()
        If txtIdProyecto.Text <> "" Then
            Dim objProyecto As New ALVI_LOGIC.Maestros.Compras.Proyectos
            objProyecto.IdCodigo = txtIdProyecto.Text()
            If objProyecto.Obtener() = True Then
                txtNombre.Text = objProyecto.Descripcion

            Else
                txtNombre.Text = ""

            End If
        End If
    End Sub

    Protected Sub btnBuscar1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar1.Click
        BindLista()
    End Sub

    Protected Sub btnBuscar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar2.Click
        BindLista()
    End Sub


    Protected Sub txtIdProyecto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdProyecto.TextChanged
        BuscarId()
    End Sub


    Protected Sub txtNombre_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        BindLista()
    End Sub

    Protected Sub dtlLista_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlLista.ItemCommand
        If e.CommandName = "Seleccionar" Then
            txtIdProyecto.Text = e.CommandArgument.ToString
            BuscarId()
            pnlLista.Visible = False
        End If
    End Sub





End Class

