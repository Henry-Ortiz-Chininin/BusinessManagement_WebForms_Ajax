
Partial Class Controles_ctlArticulo_BuscarSU
    Inherits System.Web.UI.UserControl


    Public Property IdArticulo() As String
        Get
            Return txtIdArticulo.Text
        End Get
        Set(ByVal value As String)
            txtIdArticulo.Text = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return txtDescripcion.Text
        End Get
        Set(ByVal value As String)
            txtDescripcion.Text = value
        End Set
    End Property

    Public Property IdSubFamilia() As String
        Get
            Return hdnIdSubFamilia.Value
        End Get
        Set(ByVal value As String)
            hdnIdSubFamilia.Value = value
        End Set
    End Property

    Public Sub Limpia()
        txtIdArticulo.Text = ""
        txtDescripcion.Text = ""
        'hdnMetrica.Value = ""
        'lblMetrica.Text = ""
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlLista.Visible = False
            'Limpia()
        End If
    End Sub
    Private Sub BindLista()
        Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Articulo

        objArticulo.IdSubFamilia = hdnIdSubFamilia.value
        objArticulo.IdArticulo = ""
        objArticulo.Descripcion = ""
        If txtIdArticulo.Text <> "" Then
            objArticulo.IdArticulo = txtIdArticulo.Text
        ElseIf txtDescripcion.Text <> "" Then
            objArticulo.Descripcion = Replace(txtDescripcion.Text, " ", "%")
        End If

        objArticulo.Buscar()
        Dim dtbDatos As Data.DataTable = objArticulo.Datos

        Dim dtvDatos As New Data.DataView(dtbDatos, "", "var_IdArticulo ASC", Data.DataViewRowState.OriginalRows)
        dtlLista.DataSource = dtvDatos
        dtlLista.DataBind()
        pnlLista.Visible = True
    End Sub
    Public Sub BuscarId()
        If txtIdArticulo.Text <> "" Then
            Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Articulo
            objArticulo.IdArticulo = txtIdArticulo.Text
            If objArticulo.Obtener() = True Then
                txtDescripcion.Text = objArticulo.Descripcion
                'Metrica = objArticulo.IdUnidadMedida
            Else
                txtDescripcion.Text = ""
                'Metrica = ""
            End If
        End If
    End Sub
    Protected Sub btnBuscar1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar1.Click
        BindLista()
    End Sub
    Protected Sub btnBuscar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar2.Click
        BindLista()
    End Sub
    Protected Sub txtIdArticulo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdArticulo.TextChanged
        BuscarId()
    End Sub
    Protected Sub txtDescripcion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        BindLista()
    End Sub
    Protected Sub dtlLista_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlLista.ItemCommand
        If e.CommandName = "Seleccionar" Then
            txtIdArticulo.Text = e.CommandArgument.ToString
            BuscarId()
            pnlLista.Visible = False
        End If
    End Sub
End Class
