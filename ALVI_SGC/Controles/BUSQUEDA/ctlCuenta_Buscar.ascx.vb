Imports LN_ALVINET_CONTA
Imports EN_ALVINET_CONTA
Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG

Partial Class CONTROLES_BUSQUEDA_ctlCuenta_Buscar
    Inherits System.Web.UI.UserControl
    Private entOperacionCuenta As New EN_OperacionesCuenta
    Private objLNOperacionCuenta As New LN_OperacionCuenta



    Private _strSalida As String
    Public Property Salida() As String
        Get
            Return _strSalida
        End Get
        Set(ByVal value As String)
            _strSalida = value
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

    Public Property IdCuenta() As String
        Get
            Return txtCuenta.Text
        End Get
        Set(ByVal value As String)
            txtCuenta.Text = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            'divCuenta.Visible = False
        End If
    End Sub
    Public Sub bindLista()
        entOperacionCuenta.IdCuentaContable = txtCuenta.Text
        entOperacionCuenta.CuentaContable = txtDescripcion.Text
        objLNOperacionCuenta.entOperacionCuenta = entOperacionCuenta
        objLNOperacionCuenta.Buscar()
        dtlLista.DataSource = objLNOperacionCuenta.lstOperacionCuenta
        dtlLista.DataBind()

    End Sub

    Public Event cargarDatos()
    Public Event Cerrado()
    Public Sub Obtener()

        If txtCuenta.Text <> "" Then
            entOperacionCuenta.IdCuentaContable = txtCuenta.Text
        ElseIf txtDescripcion.Text <> "" Then
            entOperacionCuenta.CuentaContable = txtDescripcion.Text
        Else
            entOperacionCuenta.CuentaContable = ""
            entOperacionCuenta.IdCuentaContable = ""
        End If
        objLNOperacionCuenta.entOperacionCuenta = entOperacionCuenta
        If objLNOperacionCuenta.Buscar Then
            txtDescripcion.Text = objLNOperacionCuenta.lstOperacionCuenta(0).CuentaContable
        End If
        RaiseEvent cargarDatos()
        ' RaiseEvent Cerrado()
        limpiar()
    End Sub

    Protected Sub btnBuscar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar2.Click
        bindLista()
    End Sub
    Private Sub limpiar()
        txtCuenta.Text = ""
        txtDescripcion.Text = ""
    End Sub


    Protected Sub dtlLista_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlLista.ItemCommand
        If e.CommandName = "Seleccionar" Then
            txtCuenta.Text = e.CommandArgument.ToString
            Obtener()
        End If
    End Sub

    Protected Sub btnCerrarr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrarr.Click
        RaiseEvent Cerrado()
    End Sub
End Class
