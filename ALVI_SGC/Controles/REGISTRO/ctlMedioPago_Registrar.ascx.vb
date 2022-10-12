Imports EN_ALVINET_CONTA.GENERAL
Imports LN_ALVINET_CONTA.GENERAL

Partial Class CONTROLES_REGISTRO_ctlMedioPago_Registrar
    Inherits System.Web.UI.UserControl

    Public Event cargar()

    Private _entMedioPago As New EN_MedioPago

    Public Property MedioPago As EN_MedioPago
        Get
            Return _entMedioPago
        End Get
        Set(ByVal value As EN_MedioPago)

            _entMedioPago = value

            txtIdMedioPago.Text = _entMedioPago.IdMedioPago
            txtIdMedioPago.Enabled = False
            If ddlEmpresa.SelectedValue = _entMedioPago.IdEmpresa Then
                ddlEmpresa.SelectedValue = _entMedioPago.IdEmpresa

            End If


            ddlEmpresa.Enabled = False

            txtDescripcion.Text = _entMedioPago.MedioPago
            txtCodigoSunat.Text = _entMedioPago.CodigoSunat

        End Set
    End Property

    Public Event cargarGrilla()
    Public Event Registrado()
    Public Event Cerrado()


    Protected Sub registrar()

        Dim objLNMedioPago As New LN_MedioPago
        Dim objENMedioPago As New EN_MedioPago


        objENMedioPago.IdEmpresa = ddlEmpresa.SelectedValue
        objENMedioPago.IdMedioPago = txtIdMedioPago.Text
        objENMedioPago.MedioPago = txtDescripcion.Text
        objENMedioPago.CodigoSunat = txtCodigoSunat.Text

        objLNMedioPago.entMedioPago = objENMedioPago
        If objLNMedioPago.Registrar = True Then
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Registro Completo');</script>")
            limpiar()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Sucedio un error al Registrar.');</script>")
        End If

    End Sub

    Public Sub limpiar()

        txtIdMedioPago.Text = ""
        ddlEmpresa.Enabled = False
        ddlEmpresa.SelectedIndex = 0

        txtDescripcion.Text = ""
        txtCodigoSunat.Text = ""
    End Sub

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

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTerminar.Click

        If ddlEmpresa.SelectedValue <> "" Then
            registrar()
            RaiseEvent cargarGrilla()
            RaiseEvent Cerrado()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Seleccione una Opcion');</script>")
        End If

    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        RaiseEvent Cerrado()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            txtIdMedioPago.Enabled = False
            SetEmpresa()
            LlenarComboEmpresaInterno()
        End If
    End Sub
End Class
