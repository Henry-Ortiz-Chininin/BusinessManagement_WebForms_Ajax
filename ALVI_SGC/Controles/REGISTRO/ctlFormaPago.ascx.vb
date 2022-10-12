Imports EN_ALVINET_CONTA.VENTAS
Imports LN_ALVINET_CONTA.VENTAS
Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA
Imports EN_ALVINET_CONTA

Partial Class CONTROLES_REGISTRO_ctlFormaPago
    Inherits System.Web.UI.UserControl


    Public Property MontoCuota() As String
        Get
            Return txtMontoCuota.Text
        End Get
        Set(ByVal value As String)
            txtMontoCuota.Text = value
        End Set
    End Property

    Public Property IdCuota() As String
        Get
            Return ddlCredito.SelectedValue
        End Get
        Set(ByVal value As String)
            ddlCredito.SelectedValue = value
        End Set
    End Property


    Public Event calculaFecha()


    Public Property FechaAdicion As String
        Get
            Return txtFechaAdicion.Text
        End Get
        Set(ByVal value As String)
            txtFechaAdicion.Text = value
        End Set

    End Property
    Private _strContadoCredito As String

    Public Property ContadoCredito() As String
        Get
            Return Contado().ToString
        End Get
        Set(ByVal value As String)
            _strContadoCredito = value
        End Set
    End Property

    Public Function Contado() As String
        If rbtContado.Checked = True Then
            _strContadoCredito = "CN"
        Else
            _strContadoCredito = "CR"
        End If
        Return _strContadoCredito
    End Function

    Public Function Credito() As String
        If rbtCredito.Checked = True Then
            _strContadoCredito = "CR"
        Else
            _strContadoCredito = "CN"

        End If
        Return _strContadoCredito
    End Function

    Public Sub llenarComboFormaPago()
        Dim objLNComboForPago As New LN_FormaPago
        Dim objENComboForPago As New EN_FormaPago

        'objENComboForPago.IdEmpresa = "0000001"
        'Session("Empresa").ToString()
        objLNComboForPago.entFormaPago = objENComboForPago
        objLNComboForPago.Listar()
        ddlCredito.Items.Clear()
        ddlCredito.DataTextField = "Cuota"
        ddlCredito.DataValueField = "IdCuota"
        ddlCredito.DataSource = objLNComboForPago.lstFormaPago
        ddlCredito.DataBind()

        ddlCredito.Items.Insert(0, New ListItem("Seleccione>>>", ""))
        ddlCredito.SelectedIndex = 0
        ddlCredito.Items.Insert(1, New ListItem("Otros", "Otros"))
        updPnlddlCredito.Visible = False
        updPnlFechaAdicion.Visible = False
        UpdPnlMontoCuota.Visible = False

    End Sub
    Private Sub outPutControl()
        If ddlCredito.SelectedIndex = 0 Then
            updPnlddlCredito.Visible = True
            updPnlFechaAdicion.Visible = True
            UpdPnlMontoCuota.Visible = True
        End If
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        llenarComboFormaPago()
        If Not IsPostBack Then
            rbtContado.Checked = False
            ddlCredito.Enabled = False

        End If
    End Sub

    Protected Sub rbtCredito_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtCredito.CheckedChanged
        If rbtCredito.Checked Then
            updPnlddlCredito.Visible = True
            UpdPnlMontoCuota.Visible = True
            ddlCredito.Enabled = True
        End If
    End Sub


    Protected Sub rbtContado_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtContado.CheckedChanged
        If rbtContado.Checked Then
            updPnlddlCredito.Visible = False
            UpdPnlMontoCuota.Visible = False
            updPnlFechaAdicion.Visible = False

        End If
    End Sub

    Protected Sub ddlCredito_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCredito.SelectedIndexChanged
        outPutControl()

    End Sub

    Protected Sub txtFechaAdicion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFechaAdicion.TextChanged
        RaiseEvent calculaFecha()

    End Sub
End Class