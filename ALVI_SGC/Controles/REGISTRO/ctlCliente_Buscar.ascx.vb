Imports EN_ALVINET_CONTA.GENERAL
Imports LN_ALVINET_CONTA.GENERAL

Partial Class CONTROLES_REGISTRO_ctlCliente_Buscar
    Inherits System.Web.UI.UserControl

    Public Property IdCliente As String
        Get
            Return txtIdCliente.Text
        End Get
        Set(ByVal value As String)
            txtIdCliente.Text = value
        End Set
    End Property

    Public Property DescripcionCliente As String
        Get
            Return txtDescripcion.Text
        End Get
        Set(ByVal value As String)
            txtDescripcion.Text = value
        End Set
    End Property

    Public Property ctl_txtIdCliente As TextBox
        Get
            Return txtIdCliente
        End Get
        Set(ByVal value As TextBox)
            txtIdCliente = value
        End Set
    End Property

    Public Property ctl_txtDescripcionCliente As TextBox
        Get
            Return txtDescripcion
        End Get
        Set(ByVal value As TextBox)
            txtDescripcion = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlLista.Visible = False
            '  LimpiarC()
        End If
    End Sub

    Public Sub EnlazarLista()
        Dim objLNCliente As New LN_Cliente
        Dim objENCliente As New EN_Cliente

        objENCliente.IdCliente = txtIdCliente.Text
        objENCliente.Descripcion = txtDescripcion.Text
        objLNCliente.entCliente = objENCliente

        objLNCliente.Obtener()
        dtlLista.DataSource = objLNCliente.lstCliente
        dtlLista.DataBind()
        pnlLista.Visible = True
    End Sub

    Public Sub EnlazarId()
        Dim objLNCliente As New LN_Cliente
        Dim objENCliente As New EN_Cliente

        objENCliente.IdCliente = txtIdCliente.Text
        objLNCliente.entCliente = objENCliente

        If objLNCliente.Obtener = True Then
            txtDescripcion.Text = objLNCliente.lstCliente(0).Descripcion
        Else
            txtDescripcion.Text = ""
        End If
    End Sub

    Public Sub LimpiarC()
        txtIdCliente.Text = ""
        txtDescripcion.Text = ""
    End Sub


    Protected Sub btnBuscar1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar1.Click
        EnlazarLista()
    End Sub

    Protected Sub btnBuscar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar2.Click
        EnlazarLista()
    End Sub

    Protected Sub txtIdCliente_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdCliente.TextChanged
        EnlazarId()
    End Sub

    Protected Sub txtDescripcion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        EnlazarLista()
    End Sub

    Protected Sub dtlLista_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlLista.ItemCommand
        If e.CommandName = "Seleccionar" Then
            txtIdCliente.Text = e.CommandArgument.ToString
            EnlazarId()
            pnlLista.Visible = False
        End If
    End Sub
End Class
