Imports EN_ALVINET_CONTA.GENERAL
Imports LN_ALVINET_CONTA.GENERAL

Partial Class CONTROLES_REGISTRO_ctlEmpresa_Registrar
    Inherits System.Web.UI.UserControl

    Private _entEmpresa As New EN_Empresa

    Public Property Empresa As EN_Empresa
        Get
            Return _entEmpresa
        End Get
        Set(ByVal value As EN_Empresa)

            _entEmpresa = value

            txtCodigo.Text = _entEmpresa.IdEmpresa
            txtCodigo.Enabled = False

            txtRuc.Text = _entEmpresa.Ruc
            txtRazonSocial.Text = _entEmpresa.RazonSocial

        End Set
    End Property

    Public Event CargarGrilla()
    Public Event Registrado()
    Public Event Cerrado()

    Public Sub limpiar()
        txtcodigo.Text = ""
        txtRuc.Text = ""
        txtRazonSocial.Text = ""

    End Sub

    Public Sub registrar()

        Dim objLNEmpresa As New LN_Empresa
        Dim objENEmpresa As New EN_Empresa


        objENEmpresa.IdEmpresa = txtcodigo.Text
        objENEmpresa.Ruc = txtRuc.Text
        objENEmpresa.RazonSocial = txtRazonSocial.Text


        objLNEmpresa.entEmpresa = objENEmpresa
        If objLNEmpresa.Registrar = True Then
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Registro completo');</script>")
            limpiar()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Sucedio un error. Revisar los datos.');</script>")
        End If

    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        registrar()
        RaiseEvent CargarGrilla()
        RaiseEvent Registrado()
    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTerminar.Click
        registrar()
        RaiseEvent CargarGrilla()
        RaiseEvent Cerrado()
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        RaiseEvent Cerrado()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtCodigo.Enabled = False
    End Sub
End Class
