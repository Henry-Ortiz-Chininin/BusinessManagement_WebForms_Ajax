Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG
Imports EN_ALVINET_CONTA.GENERAL
Imports LN_ALVINET_CONTA.GENERAL

Partial Class CONTROLES_REGISTRO_ctlCuentaEntidad
    Inherits System.Web.UI.UserControl

    Public Event cargarGrilla()
    Public Event Registrado()
    Public Event Cerrado()

    Private _strIdentidadFinanciera As String
    Public Property IdentidadFinanciera() As String
        Get
            Return _strIdentidadFinanciera
        End Get
        Set(ByVal value As String)
            _strIdentidadFinanciera = value
        End Set
    End Property

    Private _entCuentaEntidad As New EN_CuentaEntidad

    Public Property cuentaEntidad As EN_CuentaEntidad
        Get
            Return _entCuentaEntidad
        End Get

        Set(ByVal value As EN_CuentaEntidad)

            _entCuentaEntidad = value

            txtSecuencia.Text = _entCuentaEntidad.Secuencia
            txtSecuencia.Enabled = False

            ddlIdEmpresa.SelectedValue = _entCuentaEntidad.IdEmpresa
            ddlIdEmpresa.Enabled = False


            ddlIdMoneda.SelectedValue = _entCuentaEntidad.IdMoneda




            ddlEntidadFinanciera.SelectedValue = _entCuentaEntidad.IdEntidadFinanciera
            ddlEntidadFinanciera.Enabled = False

            txtNumeroCuenta.Text = _entCuentaEntidad.NumeroCuenta

        End Set
    End Property

    Public Sub Registrar()

        Dim objLNCuentaEntidad As New LN_CuentaEntidad
        Dim objENcuentaEntidad As New EN_CuentaEntidad

        objENcuentaEntidad.Secuencia = txtSecuencia.Text
        objENcuentaEntidad.IdEmpresa = ddlIdEmpresa.SelectedValue
        objENcuentaEntidad.IdMoneda = ddlIdMoneda.SelectedValue
        objENcuentaEntidad.IdEntidadFinanciera = ddlEntidadFinanciera.SelectedValue
        objENcuentaEntidad.NumeroCuenta = txtNumeroCuenta.Text

        objLNCuentaEntidad.entCuentaEntidad = objENcuentaEntidad

        If objLNCuentaEntidad.Registrar = True Then
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Registro completo');</script>")
            Limpiar()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Sucedio un error. Revisar los datos.');</script>")
        End If

    End Sub

    Protected Sub btnRegistrar_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click

        If ddlIdEmpresa.SelectedValue <> "" AndAlso ddlEntidadFinanciera.SelectedValue <> "" AndAlso _
            ddlIdMoneda.SelectedValue <> "" Then
            Registrar()
            RaiseEvent cargarGrilla()
            RaiseEvent Registrado()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Seleccione una Opcion...');</script>")
        End If

    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTerminar.Click

        If ddlIdEmpresa.SelectedValue <> "" AndAlso ddlEntidadFinanciera.SelectedValue <> "" AndAlso _
            ddlIdMoneda.SelectedValue <> "" Then
            Registrar()
            RaiseEvent cargarGrilla()
            RaiseEvent Cerrado()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Seleccione una Opcion...');</script>")
        End If

    End Sub

    Public Sub Limpiar()

        txtSecuencia.Text = ""
        ddlIdMoneda.Enabled = True
        ddlIdMoneda.SelectedIndex = 0

        txtNumeroCuenta.Text = ""
        ddlEntidadFinanciera.SelectedValue = IdentidadFinanciera
        ddlEntidadFinanciera.Enabled = False
    End Sub
    Public Sub LlenarEmpresaInterno()
        Dim objLNEmpresa As New LN_Empresa
        Dim objENEmpresa As New EN_Empresa

        objLNEmpresa.ListaInterno(hdnEmpresa.Value, hdnNomEmpresa.Value)
        ddlIdEmpresa.DataSource = objLNEmpresa.lstEmpresas
        ddlIdEmpresa.DataTextField = "RazonSocial"
        ddlIdEmpresa.DataValueField = "IdEmpresa"
        ddlIdEmpresa.DataBind()
        ddlIdEmpresa.SelectedIndex = 0
        ddlIdEmpresa.Enabled = False
    End Sub
    Public Sub LlenarComboEmpresa()
        Dim objLNEmpresa As New LN_Empresa
        Dim objENEmpresa As New EN_Empresa

        objENEmpresa.IdUsuario = hdnUsuario.Value

        objLNEmpresa.entEmpresa = objENEmpresa
        objLNEmpresa.Listar()

        ddlIdEmpresa.Items.Clear()
        ddlIdEmpresa.DataTextField = "RazonSocial"
        ddlIdEmpresa.DataValueField = "IdEmpresa"
        ddlIdEmpresa.DataSource = objLNEmpresa.lstEmpresas
        ddlIdEmpresa.DataBind()

        ddlIdEmpresa.Items.Insert(0, New ListItem("Seleccione>>>", ""))
        ddlIdEmpresa.SelectedIndex = 0
    End Sub

    Public Sub LlenarComboEntidadFinanciera(ByVal empresa As String)

        Dim objLNEntidadFinanciera As New LN_EntidadFinanciera
        Dim objENentidadFinan As New EN_EntidadFinanciera

        'objENentidadFinan.IdEmpresa = hdnEmpresa.Value
        objENentidadFinan.IdEmpresa = empresa

        objLNEntidadFinanciera.entEntidadFinanciera = objENentidadFinan

        objLNEntidadFinanciera.Listar()
        ddlEntidadFinanciera.Items.Clear()
        ddlEntidadFinanciera.DataTextField = "NombreEntidad"
        ddlEntidadFinanciera.DataValueField = "IdEntidadFinanciera"
        ddlEntidadFinanciera.DataSource = objLNEntidadFinanciera.lstEntidadFinanciera
        ddlEntidadFinanciera.DataBind()

        ddlEntidadFinanciera.Items.Insert(0, New ListItem("Seleccione>>>", ""))
        ddlEntidadFinanciera.SelectedIndex = 0

    End Sub

    Public Sub LlenarComboMoneda(ByVal empresa As String)
        Dim objLNMoneda As New LN_Moneda
        Dim objENMoneda As New EN_Moneda

        'objENMoneda.IdEmpresa = hdnEmpresa.Value
        objENMoneda.IdEmpresa = empresa
        objLNMoneda.entMoneda = objENMoneda

        objLNMoneda.Listar()
        ddlIdMoneda.Items.Clear()

        ddlIdMoneda.DataTextField = "Moneda"
        ddlIdMoneda.DataValueField = "IdMoneda"
        ddlIdMoneda.DataSource = objLNMoneda.lstMonedas
        ddlIdMoneda.DataBind()


        ddlIdMoneda.Items.Insert(0, New ListItem("Seleccione>>>", ""))
        ddlIdMoneda.SelectedIndex = 0

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario").ToString
            hdnEmpresa.Value = Session("Empresa").ToString
            hdnNomEmpresa.Value = Session("nomEmpresa").ToString
            txtSecuencia.Enabled = False
            LlenarEmpresaInterno()

            LlenarComboEntidadFinanciera(ddlIdEmpresa.SelectedValue)
            LlenarComboMoneda(ddlIdEmpresa.SelectedValue)
        End If
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        RaiseEvent Cerrado()
    End Sub

    Protected Sub ddlIdEmpresa_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlIdEmpresa.SelectedIndexChanged
        LlenarComboEntidadFinanciera(ddlIdEmpresa.SelectedValue)
        LlenarComboMoneda(ddlIdEmpresa.SelectedValue)

    End Sub
End Class
