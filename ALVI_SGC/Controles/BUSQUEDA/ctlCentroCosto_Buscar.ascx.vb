
Partial Class CONTROLES_BUSQUEDA_ctlCentroCosto_Buscar
    Inherits System.Web.UI.UserControl

    Private _bolSoloLectura As Boolean = False
    Public Property SoloLectura As Boolean
        Get
            Return _bolSoloLectura
        End Get
        Set(ByVal value As Boolean)
            _bolSoloLectura = value

            txtIdCentroCosto.Enabled = Not _bolSoloLectura
            txtCentroCosto.Enabled = Not _bolSoloLectura
            btnBuscar.Visible = Not _bolSoloLectura
        End Set
    End Property

    Public Property IdCentroCosto() As String
        Get
            Return txtIdCentroCosto.Text
        End Get
        Set(ByVal value As String)
            txtIdCentroCosto.Text = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return txtCentroCosto.Text
        End Get
        Set(ByVal value As String)
            txtCentroCosto.Text = value
        End Set
    End Property
    Public Sub Limpia()
        txtIdCentroCosto.Text = ""
        txtCentroCosto.Text = ""
        pnlLista.Visible = False
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlLista.Visible = False
            'txtCentroCosto.Text = ""
            'txtIdCentroCosto.Text = ""
        End If
    End Sub
    Private Sub BindLista()
        Dim objCentroCosto As New ALVI_LOGIC.Configuracion.CentroCosto
        
        objCentroCosto.IdCentroCosto = txtIdCentroCosto.Text
        objCentroCosto.Descripcion = txtCentroCosto.Text
        objCentroCosto.Buscar()

        dtlLista.DataSource = objCentroCosto.Datos
        dtlLista.DataBind()
        pnlLista.Visible = True
    End Sub
    Public Sub BuscarId()
        If txtIdCentroCosto.Text <> "" Then
            Dim objCentroCosto As New ALVI_LOGIC.Configuracion.CentroCosto
            objCentroCosto.IdCentroCosto = txtIdCentroCosto.Text
            If objCentroCosto.Obtener() = True Then
                txtCentroCosto.Text = objCentroCosto.Descripcion
            Else
                txtCentroCosto.Text = ""
            End If
        End If
    End Sub
    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        BindLista()
    End Sub
    
    Protected Sub txtIdCentroCosto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdCentroCosto.TextChanged
        BuscarId()
    End Sub
    
    Protected Sub dtlLista_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlLista.ItemCommand
        If e.CommandName = "Seleccionar" Then
            txtIdCentroCosto.Text = e.CommandArgument.ToString
            BuscarId()
            pnlLista.Visible = False
        End If
    End Sub
End Class
