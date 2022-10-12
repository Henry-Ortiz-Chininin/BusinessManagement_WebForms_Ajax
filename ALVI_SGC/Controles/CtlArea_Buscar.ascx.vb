
Partial Class Controles_CtlArea_Buscar
    Inherits System.Web.UI.UserControl


    Public Property IdArea() As String
        Get
            Return txtIdArea.Text
        End Get
        Set(ByVal value As String)
            txtIdArea.Text = value
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
        txtIdArea.Text = ""
        txtNombre.Text = ""

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlLista.Visible = False
            txtIdArea.Text = ""
            txtNombre.Text = ""
        End If
    End Sub


    Private Sub BindLista()
        Dim objArea As New ALVI_LOGIC.Maestros.Administracion.Area
        Dim srtCriterio As String = ""

        objArea.IdArea = ""
        objArea.Descripcion = ""
        If txtIdArea.Text <> "" Then
            objArea.IdArea = txtIdArea.Text
        ElseIf txtNombre.Text <> "" Then
            objArea.Descripcion = Replace(txtNombre.Text, " ", "%")
        End If

        objArea.Buscar()
        Dim dtbDatos As Data.DataTable = objArea.Datos

        Dim dtvDatos As New Data.DataView(dtbDatos, "", "var_IdArea", Data.DataViewRowState.OriginalRows)
        dtlLista.DataSource = dtvDatos
        dtlLista.DataBind()
        pnlLista.Visible = True
    End Sub


    Public Sub BuscarId()
        If txtIdArea.Text <> "" Then
            Dim objArea As New ALVI_LOGIC.Maestros.Administracion.Area
            objArea.IdArea = txtIdArea.Text
            If objArea.Obtener() = True Then
                txtNombre.Text = objArea.Descripcion

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


    Protected Sub txtIdArea_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdArea.TextChanged
        BuscarId()
    End Sub


    Protected Sub txtNombre_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        BindLista()
    End Sub

    Protected Sub dtlLista_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlLista.ItemCommand
        If e.CommandName = "Seleccionar" Then
            txtIdArea.Text = e.CommandArgument.ToString
            BuscarId()
            pnlLista.Visible = False
        End If
    End Sub


End Class
