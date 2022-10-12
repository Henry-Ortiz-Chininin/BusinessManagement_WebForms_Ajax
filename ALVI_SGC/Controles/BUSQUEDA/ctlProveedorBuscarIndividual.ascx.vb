Imports LN_ALVINET_CONTA.CONFIG
Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.OPERACION
Imports EN_ALVINET_CONTA.OPERACION

Partial Class CONTROLES_BUSQUEDA_ctlProveedorBuscarIndividual
    Inherits System.Web.UI.UserControl
    Public Property codProveedor As String
        Get
            Return txtRuc.Text
        End Get
        Set(ByVal value As String)
            txtRuc.Text = value
        End Set
    End Property

    Public Property DescripcionProveedor As String
        Get
            Return txtDescripcion.Text
        End Get
        Set(ByVal value As String)
            txtDescripcion.Text = value
        End Set
    End Property

    Public Property ctl_txtIdProveedor As TextBox
        Get
            Return txtRuc
        End Get
        Set(ByVal value As TextBox)
            txtRuc = value
        End Set
    End Property

    Public Property ctl_txtDescripcionProveedor As TextBox
        Get
            Return txtDescripcion
        End Get
        Set(ByVal value As TextBox)
            txtDescripcion = value
        End Set
    End Property

    Public Event Registrado()
    Public Event Cerrado()

    Public Sub Limpiar()
        txtRuc.Text = ""
        txtDescripcion.Text = ""
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdnIdEmpresa.Value = Session("Empresa")
            hdnRazonSocialProveedor.Value = ctl_txtDescripcionProveedor.Text
            pnlLista.Visible = False
            ' Limpiar()
        End If
    End Sub




    Public Sub BindLista()

        Dim objLNProveedor As New LN_Detraccion
        Dim objENProveedor As New EN_Detraccion

        objENProveedor.IdEmpresa = hdnIdEmpresa.Value
        objENProveedor.RucProveedor = txtRuc.Text
        objLNProveedor.entDetraccion = objENProveedor
        If objLNProveedor.Buscar() Then
            hdnRazonSocialProveedor.Value = objLNProveedor.lstDetracciones(0).RazonSocialProveedor
            dtlLista.DataSource = objLNProveedor.lstDetracciones
            dtlLista.DataBind()
            pnlLista.Visible = True
        End If



    End Sub



    Public Sub Obtener()

        Dim objLNProveedor As New LN_Detraccion
        Dim objENProveedor As New EN_Detraccion
        objENProveedor.IdEmpresa = hdnIdEmpresa.Value
        objENProveedor.RucProveedor = txtRuc.Text
        objENProveedor.RazonSocialProveedor = hdnRazonSocialProveedor.Value

        objLNProveedor.entDetraccion = objENProveedor

        If objLNProveedor.Buscar() = True Then
            txtDescripcion.Text = objLNProveedor.lstDetracciones(0).RazonSocialProveedor
            hdnRazonSocialProveedor.Value = txtDescripcion.Text

        End If

        'txtDescripcion.Text = hdnRazonSocialProveedor.Value

    End Sub





    Protected Sub btnBuscar1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar1.Click
        BindLista()


        'Limpiar()
    End Sub

    Protected Sub dtlLista_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlLista.ItemCommand

        If e.CommandName = "Seleccionar" Then
            txtRuc.Text = e.CommandArgument.ToString
            Obtener()
            pnlLista.Visible = False
        End If

    End Sub


    Protected Sub txtDescripcion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        BindLista()
    End Sub

    Protected Sub txtRuc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRuc.TextChanged
        Obtener()
    End Sub
End Class
