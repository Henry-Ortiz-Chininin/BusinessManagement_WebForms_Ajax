Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG
Imports EN_ALVINET_CONTA.GENERAL
Imports LN_ALVINET_CONTA.GENERAL

Partial Class CONTROLES_REGISTRO_ctlNivelPlan
    Inherits System.Web.UI.UserControl

    Private _entNivelPlan As New EN_NivelPlan

    Public Property NivelPlan As EN_NivelPlan
        Get
            Return _entNivelPlan
        End Get
        Set(ByVal value As EN_NivelPlan)
            _entNivelPlan = value

            txtNivelPlan.Enabled = False

            If _entNivelPlan.IdEmpresa = ddlEmpresa.SelectedValue Then
                ddlEmpresa.SelectedValue = _entNivelPlan.IdEmpresa
           
            End If

            ddlEmpresa.Enabled = False
            txtNivelPlan.Text = _entNivelPlan.IdNivel
            txtNivelPlan.Enabled = False
            txtDescripcion.Text = _entNivelPlan.Descripcion

        End Set
    End Property

    Public Event cargarGrilla()
    Public Event Registrado()
    Public Event Cerrado()

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click

        If ddlEmpresa.SelectedValue <> "" Then
            Registrar()
            RaiseEvent cargarGrilla()
            RaiseEvent Registrado()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Seleccione una opcion...');</script>")
        End If

    End Sub

    Public Sub Registrar()

        Dim objLNNivelPlan As New LN_NivelPlan
        Dim objENNivelPlan As New EN_NivelPlan

        objENNivelPlan.IdEmpresa = ddlEmpresa.SelectedValue
        objENNivelPlan.IdNivel = txtNivelPlan.Text
        objENNivelPlan.Descripcion = txtDescripcion.Text

        objLNNivelPlan.entNivelPlan = objENNivelPlan

        If objLNNivelPlan.Registrar = True Then
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Registro completo');</script>")
            limpiar()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Sucedio un error. Revisar los datos.');</script>")
        End If

    End Sub

    Public Sub limpiar()

        txtNivelPlan.Text = ""
        ddlEmpresa.Enabled = False
        ddlEmpresa.SelectedIndex = 0

        txtDescripcion.Text = ""

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
        ddlEmpresa.Enabled = False
    End Sub
    'Private Sub LlenarComboEmpresa()
    '    Dim objLNEmpresa As New LN_Empresa
    '    Dim objENEmpresa As New EN_Empresa

    '    objENEmpresa.IdUsuario = hdnUsuario.Value

    '    objLNEmpresa.entEmpresa = objENEmpresa
    '    objLNEmpresa.Listar()

    '    ddlIdEmpresa.Items.Clear()
    '    ddlIdEmpresa.DataTextField = "RazonSocial"
    '    ddlIdEmpresa.DataValueField = "IdEmpresa"
    '    ddlIdEmpresa.DataSource = objLNEmpresa.lstEmpresas
    '    ddlIdEmpresa.DataBind()

    '    ddlIdEmpresa.Items.Insert(0, New ListItem("Seleccione>>>", ""))
    '    ddlIdEmpresa.SelectedIndex = 0
    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            txtNivelPlan.Enabled = False
            SetEmpresa()
            LlenarComboEmpresaInterno()
        End If

    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        RaiseEvent Cerrado()
    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTerminar.Click

        If ddlEmpresa.SelectedValue <> "" Then

            Registrar()
            RaiseEvent cargarGrilla()
            RaiseEvent Cerrado()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Seleccione una opcion...');</script>")
        End If
    End Sub

End Class
