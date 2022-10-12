Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG
Imports EN_ALVINET_CONTA.GENERAL
Imports LN_ALVINET_CONTA.GENERAL

Partial Class CONTROLES_REGISTRO_ctlTipoCuenta_Registrar
    Inherits System.Web.UI.UserControl

    Private _entTipoCuenta As New EN_TipoCuenta

    Public Property entTipoCuenta As EN_TipoCuenta
        Get
            Return _entTipoCuenta
        End Get
        Set(ByVal value As EN_TipoCuenta)

            _entTipoCuenta = value

            txtcodigoTipoCuenta.Text = _entTipoCuenta.IdTipoCuenta
            txtcodigoTipoCuenta.Enabled = False
            If _entTipoCuenta.IdEmpresa = ddlEmpresa.SelectedValue Then
                ddlEmpresa.SelectedValue = _entTipoCuenta.IdEmpresa
            End If


            ddlEmpresa.Enabled = False

            txtDescripcion.Text = _entTipoCuenta.Descripcion

        End Set
    End Property


    Protected Sub registrar()

        Dim objLNTipoCuenta As New LN_TipoCuenta
        Dim objENTipoCuenta As New EN_TipoCuenta

        objENTipoCuenta.IdEmpresa = ddlEmpresa.SelectedValue
        objENTipoCuenta.IdTipoCuenta = txtcodigoTipoCuenta.Text
        objENTipoCuenta.Descripcion = txtDescripcion.Text


        objLNTipoCuenta.entTipoCuenta = objENTipoCuenta
        If objLNTipoCuenta.Registrar = True Then
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Registro completo');</script>")
            limpiar()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Sucedio un error. Revisar los datos.');</script>")
        End If
    End Sub

    Public Sub limpiar()

        txtcodigoTipoCuenta.Text = ""
        ddlEmpresa.Enabled = False
        ddlEmpresa.SelectedIndex = 0
        txtDescripcion.Text = ""

    End Sub

    Public Event cargarGrilla()
    Public Event Registrado()
    Public Event Cerrado()

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        If ddlEmpresa.SelectedValue <> "" Then
            registrar()
            RaiseEvent cargarGrilla()
            RaiseEvent Registrado()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert                            ('Seleccione una Opcion');</script>")
        End If
    End Sub
    Private Sub SetEmpresa()
        If Session("Empresa") Is Nothing Then
        Else
            hdnEmpresa.Value = Session("Empresa").ToString
        End If
        If Session("nomEmpresa") Is Nothing Then
        Else
            hdnNomEmpresa.Value = Session("nomEmpresa").ToString
        End If


    End Sub
    Private Sub LlenarComboEmpresaInterno()
        Dim objLNEmpresa As New LN_Empresa
        Dim objENEmpresa As New EN_Empresa


        objLNEmpresa.ListaInterno(hdnEmpresa.Value, hdnNomEmpresa.Value)
        ddlEmpresa.Items.Clear()
        ddlEmpresa.DataTextField = "RazonSocial"
        ddlEmpresa.DataValueField = "IdEmpresa"
        ddlEmpresa.DataSource = objLNEmpresa.lstEmpresas
        ddlEmpresa.DataBind()

    End Sub
    Public Sub llenarComboEmpresa()

        Dim objLNEmpresa As New LN_Empresa
        Dim objENEmpresa As New EN_Empresa

        objENEmpresa.IdUsuario = hdnUsuario.Value
        objLNEmpresa.entEmpresa = objENEmpresa

        ddlEmpresa.Items.Clear()

        objLNEmpresa.Listar()
        ddlEmpresa.DataTextField = "RazonSocial"
        ddlEmpresa.DataValueField = "IdEmpresa"
        ddlEmpresa.DataSource = objLNEmpresa.lstEmpresas
        ddlEmpresa.DataBind()

        ddlEmpresa.Items.Insert(0, New ListItem("Seleccione>>>", ""))
        ddlEmpresa.SelectedIndex = 0

    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTerminar.Click
        If ddlEmpresa.SelectedValue <> "" Then
            registrar()
            RaiseEvent cargarGrilla()
            RaiseEvent Cerrado()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert                            ('Seleccione una Opcion');</script>")
        End If
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        RaiseEvent Cerrado()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            txtcodigoTipoCuenta.Enabled = False
            SetEmpresa()
            LlenarComboEmpresaInterno()
        End If
    End Sub

End Class
