Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG
Imports EN_ALVINET_CONTA.GENERAL
Imports LN_ALVINET_CONTA.GENERAL

Partial Class CONTROLES_REGISTRO_ctlEntidadFinanciera
    Inherits System.Web.UI.UserControl

    Private _entEntidadFinanciera As New EN_EntidadFinanciera

    Public Property EntidadFinanciera As EN_EntidadFinanciera
        Get
            Return _entEntidadFinanciera
        End Get
        Set(ByVal value As EN_EntidadFinanciera)

            _entEntidadFinanciera = value

            txtIdEntidadFinanciera.Text = _entEntidadFinanciera.IdEntidadFinanciera
            txtIdEntidadFinanciera.Enabled = False
            If _entEntidadFinanciera.IdEmpresa = ddlEmpresa.SelectedValue Then
                ddlEmpresa.SelectedValue = _entEntidadFinanciera.IdEmpresa

            End If


            ddlEmpresa.Enabled = False

            txtDescripcion.Text = _entEntidadFinanciera.NombreEntidad
            txtSunat.Text = _entEntidadFinanciera.IdSunat
        End Set
    End Property

    Public Event cargarGrilla()
    Public Event Registrado()
    Public Event Cerrado()

    Public Sub registrar()
        Dim objLNEntidadFinanciera As New LN_EntidadFinanciera
        Dim objENEntidadFinanciera As New EN_EntidadFinanciera

        objENEntidadFinanciera.IdEmpresa = ddlEmpresa.SelectedValue
        objENEntidadFinanciera.IdEntidadFinanciera = txtIdEntidadFinanciera.Text
        objENEntidadFinanciera.NombreEntidad = txtDescripcion.Text
        objENEntidadFinanciera.IdSunat = txtSunat.Text
        objLNEntidadFinanciera.entEntidadFinanciera = objENEntidadFinanciera


        If objLNEntidadFinanciera.Registrar = True Then
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Registro completo');</script>")
            limpiar()
            RaiseEvent cargarGrilla()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Sucedio un error. Revisar los datos.');</script>")
        End If

    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click

        If ddlEmpresa.SelectedValue <> "" Then
            registrar()
            RaiseEvent cargarGrilla()
            RaiseEvent Registrado()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Seleccione una opcion...');</script>")
        End If

    End Sub

    Public Sub limpiar()

        txtIdEntidadFinanciera.Text = ""
        ddlEmpresa.Enabled = False
        ddlEmpresa.SelectedIndex = 0
        txtDescripcion.Text = ""
        txtSunat.Text = ""

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            SetEmpresa()
            LlenarComboEmpresaInterno()
            txtIdEntidadFinanciera.Enabled = False

        End If

    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTerminar.Click

        If ddlEmpresa.SelectedValue <> "" Then
            registrar()
            RaiseEvent cargarGrilla()
            RaiseEvent Cerrado()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Seleccione una opcion...');</script>")
        End If

    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        RaiseEvent Cerrado()
    End Sub

End Class
