Imports EN_ALVINET_CONTA.GENERAL
Imports LN_ALVINET_CONTA.GENERAL

Partial Class CONTROLES_REGISTRO_ctlMoneda_Registrar
    Inherits System.Web.UI.UserControl

    Private _entMoneda As New EN_Moneda

    Public Property Moneda As EN_Moneda
        Get
            Return _entMoneda
        End Get
        Set(ByVal value As EN_Moneda)

            _entMoneda = value

            txtIdMoneda.Text = _entMoneda.IdMoneda
            txtIdMoneda.Enabled = False
            If _entMoneda.IdEmpresa = ddlEmpresa.SelectedValue Then
                ddlEmpresa.SelectedValue = _entMoneda.IdEmpresa
            
            End If


            ddlEmpresa.Enabled = False

            txtDescripcion.Text = _entMoneda.Moneda
            txtSimbolo.Text = _entMoneda.Simbolo
            txtCodSunat.Text = _entMoneda.IdSunat
        End Set
    End Property

    Public Event cargarGrilla()
    Public Event Registrado()
    Public Event Cerrado()

    Public Sub registrar()

        Dim objLNMoneda As New LN_Moneda
        Dim objENMoneda As New EN_Moneda


        objENMoneda.IdEmpresa = ddlEmpresa.SelectedValue
        objENMoneda.IdMoneda = txtIdMoneda.Text
        objENMoneda.Moneda = txtDescripcion.Text
        objENMoneda.Simbolo = txtSimbolo.Text
        objENMoneda.IdSunat = txtCodSunat.Text

        objLNMoneda.entMoneda = objENMoneda
        If objLNMoneda.Registrar = True Then
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Registro completo');</script>")
            limpiar()
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
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Seleccione una Opcion...');</script>")
        End If

    End Sub

    Public Sub limpiar()
        ddlEmpresa.Enabled = False
        ddlEmpresa.SelectedIndex = 0
        txtIdMoneda.Text = ""
        txtDescripcion.Text = ""
        txtSimbolo.Text = ""
        txtCodSunat.Text = ""
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
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Seleccione una Opcion...');</script>")
        End If
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        RaiseEvent Cerrado()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            txtIdMoneda.Enabled = False
            SetEmpresa()
            LlenarComboEmpresaInterno()
        End If
    End Sub
End Class
