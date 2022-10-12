Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG
Imports EN_ALVINET_CONTA.GENERAL
Imports LN_ALVINET_CONTA.GENERAL

Partial Class CONTROLES_REGISTRO_ctlTipoAnalisis_Registrarl
    Inherits System.Web.UI.UserControl

    Private _entTipoAnalisis As New EN_TipoAnalisis

    Public Property entTipoAnalisis As EN_TipoAnalisis
        Get
            Return _entTipoAnalisis
        End Get
        Set(ByVal value As EN_TipoAnalisis)

            _entTipoAnalisis = value

            txtcodigoTipoAnalisis.Text = _entTipoAnalisis.IdTipoAnalisis
            txtcodigoTipoAnalisis.Enabled = False

            ddlEmpresa.SelectedValue = _entTipoAnalisis.IdEmpresa
            ddlEmpresa.Enabled = False

            txtDescripcion.Text = _entTipoAnalisis.TipoAnalisis

        End Set
    End Property

    Protected Sub registrar()

        Dim objLNTipoAnalisis As New LN_TipoAnalisis
        Dim objENTipoAnalisis As New EN_TipoAnalisis

        objENTipoAnalisis.IdTipoAnalisis = txtcodigoTipoAnalisis.Text
        objENTipoAnalisis.IdEmpresa = ddlEmpresa.SelectedValue
        objENTipoAnalisis.TipoAnalisis = txtDescripcion.Text

        objLNTipoAnalisis.entTipoAnalisis = objENTipoAnalisis

        If objLNTipoAnalisis.Registrar = True Then
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Registro completo');</script>")
            limpiar()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Sucedio un error. Revisar los datos.');</script>")
        End If
    End Sub

    Public Sub limpiar()

        txtcodigoTipoAnalisis.Text = ""
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
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Seleccione una Opcion');</script>")
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

    Private Sub LlenarComboEmpresa()
        Dim objLNEmpresa As New LN_Empresa
        Dim objENEmpresa As New EN_Empresa

        objENEmpresa.IdUsuario = hdnUsuario.Value
        objLNEmpresa.entEmpresa = objENEmpresa

        objLNEmpresa.Listar()

        ddlEmpresa.Items.Clear()
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
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert                ('Seleccione una Opcion');</script>")
        End If

    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        RaiseEvent Cerrado()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            SetEmpresa()
            LlenarComboEmpresaInterno()
            txtcodigoTipoAnalisis.Enabled = False

        End If
    End Sub

End Class
