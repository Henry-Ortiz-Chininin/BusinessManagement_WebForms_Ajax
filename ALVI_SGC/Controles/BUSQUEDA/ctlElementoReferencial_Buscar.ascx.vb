
Imports LN_ALVINET_CONTA.CONFIG
Imports EN_ALVINET_CONTA.CONFIG

Partial Class CONTROLES_BUSQUEDA_ctlElementoReferencial_Buscar
    Inherits System.Web.UI.UserControl


    Public Property idArticulo() As String
        Get
            Return txtIdElementoReferencial.Text
        End Get
        Set(ByVal value As String)
            txtIdElementoReferencial.Text = value
        End Set
    End Property

    Public Property UnidadMedidas() As String
        Get
            Return txtUnidadMedida.Text
        End Get
        Set(ByVal value As String)
            txtUnidadMedida.Text = value
        End Set
    End Property
    Public Property IdUnidadMedida() As String
        Get
            Return txtUnidadMedida.Text
        End Get
        Set(ByVal value As String)
            txtUnidadMedida.Text = value
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
    Public Property Titulo() As String
        Get
            Return txtUnidadMedida.Text
        End Get
        Set(ByVal value As String)
            txtUnidadMedida.Text = value
        End Set
    End Property
    Public Sub Limpia()
        txtIdElementoReferencial.Text = ""
        txtNombre.Text = ""
        txtUnidadMedida.Text = ""
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtUnidadMedida.Enabled = False
            hdnIdEmpresa.Value = Session("Empresa")
            hdnUnidadMedida.Value = ""
            pnlLista.Visible = False
            'Limpia()
        End If
    End Sub
    Private Sub BindLista()
        Dim enArticulo As New EN_Articulo()
        Dim lnArticulo As New LN_Articulo()

        enArticulo.IdEmpresa = hdnIdEmpresa.Value
        enArticulo.IdArticulo = txtIdElementoReferencial.Text.ToString()
        enArticulo.Descripcion = txtNombre.Text

        dtlLista.DataSource = lnArticulo.BuscarEmpresa(enArticulo)
        dtlLista.DataBind()
        pnlLista.Visible = True
    End Sub
    Public Sub BuscarId()
        If txtIdElementoReferencial.Text <> "" Then
            Dim lnArticulo As New LN_Articulo()
            Dim enArticulo As New EN_Articulo()
            Dim lstArticulo As New List(Of EN_Articulo)
            enArticulo.IdArticulo = txtIdElementoReferencial.Text

            If lnArticulo.Obtener1(enArticulo).Count > 0 Then
                lstArticulo = lnArticulo.Obtener1(enArticulo)
                txtNombre.Text = lstArticulo(0).Descripcion
                txtUnidadMedida.Text = lstArticulo(0).DesUnidadMedida
                hdnUnidadMedida.Value = lstArticulo(0).IdUnidadMedida
            End If
        End If
    End Sub
    Protected Sub btnBuscar1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar1.Click
        BindLista()
    End Sub
    Protected Sub btnBuscar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar2.Click
        BindLista()
    End Sub
    Protected Sub txtIdElementoReferencial_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdElementoReferencial.TextChanged
        BuscarId()
    End Sub
    Protected Sub txtNombre_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        BindLista()
    End Sub
    Protected Sub dtlLista_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlLista.ItemCommand
        If e.CommandName = "Seleccionar" Then
            txtIdElementoReferencial.Text = e.CommandArgument.ToString
            BuscarId()
            pnlLista.Visible = False
        End If
    End Sub
End Class


