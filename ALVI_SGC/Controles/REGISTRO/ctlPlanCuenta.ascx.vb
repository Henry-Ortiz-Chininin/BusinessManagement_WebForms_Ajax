Imports LN_ALVINET_CONTA.CONFIG
Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.GENERAL
Imports EN_ALVINET_CONTA.GENERAL


Partial Class CONTROLES_REGISTRO_ctlPlanCuenta
    Inherits System.Web.UI.UserControl

    Private _entPlanCuenta As New EN_PlanCuenta

    Public Property PlanCuenta As EN_PlanCuenta
        Get
            Return _entPlanCuenta
        End Get
        Set(ByVal value As EN_PlanCuenta)

            _entPlanCuenta = value

            txtCodigo.Text = _entPlanCuenta.IdCuentaContable
            txtCodigo.Enabled = False

            ddlEmpresa.SelectedValue = _entPlanCuenta.IdEmpresa
            ddlEmpresa.Enabled = False

            ddlContabilidad.SelectedValue = _entPlanCuenta.IdContabilidad
            ddlContabilidad.Enabled = False

            hdnPlanContable.Value = _entPlanCuenta.IdPlanContable
            ddlContabilidad.Enabled = False

            txtNombre.Text = _entPlanCuenta.Nombre

            ddlNivelPlan.SelectedValue = _entPlanCuenta.IdNivel
            If _entPlanCuenta.IdTipoAnalisis = "" Or _entPlanCuenta.IdTipoAnalisis = "0" Then
                ddlTipoAnalisis.SelectedIndex = "0"
            Else
                ddlTipoAnalisis.SelectedValue = _entPlanCuenta.IdTipoAnalisis
            End If



            ddlTipoCuenta.SelectedValue = _entPlanCuenta.IdTipoCuenta

            txtDiferenciaCambio.Text = _entPlanCuenta.DiferenciaCambio
            txtConversionMoneda.Text = _entPlanCuenta.ConversionMoneda
            If _entPlanCuenta.IdEntidadFinanciera = "" Or _entPlanCuenta.IdEntidadFinanciera = "0" Then
                ddlEntidadFinanciera.SelectedIndex = 0
            Else
                ddlEntidadFinanciera.SelectedValue = _entPlanCuenta.IdEntidadFinanciera
            End If

            ddlMoneda.SelectedValue = _entPlanCuenta.IdMoneda
            If _entPlanCuenta.CuentaEntidad = "" Or _entPlanCuenta.CuentaEntidad = "0" Then
                ddlCuentaEntidad.SelectedIndex = 0
            Else
                ddlCuentaEntidad.SelectedValue = _entPlanCuenta.CuentaEntidad
            End If




            txtCuentaDebe.Text = _entPlanCuenta.CuentaDebe
            txtCuentaHaber.Text = _entPlanCuenta.CuentaHaber
            txtCuentaPadre.Text = _entPlanCuenta.IdCuentaPadre

        End Set
    End Property

    Public Event cargarGrilla()
    Public Event Registrado()
    Public Event Cerrado()

    Public Sub Limpiar()

        txtCodigo.Text = ""
        txtCodigo.Enabled = True
        ddlContabilidad.Enabled = True
        ddlEmpresa.Enabled = True

        ddlContabilidad.SelectedIndex = 0
        ddlEmpresa.SelectedIndex = 1
        ddlNivelPlan.SelectedIndex = 0
        ddlTipoAnalisis.SelectedIndex = 0
        ddlTipoCuenta.SelectedIndex = 0
        ddlEntidadFinanciera.SelectedIndex = 0
        ddlMoneda.SelectedIndex = 0
        ddlCuentaEntidad.SelectedIndex = 0

        txtNombre.Text = ""
        txtDiferenciaCambio.Text = ""
        txtConversionMoneda.Text = ""
        txtCuentaDebe.Text = ""
        txtCuentaHaber.Text = ""
        txtCuentaPadre.Text = ""

    End Sub

    Public Sub LlenarComboEmpresa()
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
        ddlEmpresa.SelectedIndex = 1
    End Sub

    Public Sub llenarComboContabilidad(ByVal pstrEmpresa As String)

        Dim objLNContabilidad As New LN_Contabilidad
        Dim _entContabilidad As New EN_Contabilidad

        ddlContabilidad.Items.Clear()
        _entContabilidad.IdEmpresa = pstrEmpresa
        objLNContabilidad.entContabilidad = _entContabilidad
        objLNContabilidad.Listar()
        ddlContabilidad.DataTextField = "Contabilidad"
        ddlContabilidad.DataValueField = "IdContabilidad"
        ddlContabilidad.DataSource = objLNContabilidad.lstContabilidades
        ddlContabilidad.DataBind()

        ddlContabilidad.Items.Insert(0, New ListItem("Seleccione>>>", ""))
        ddlContabilidad.SelectedIndex = 0

    End Sub

    Public Sub llenarComboNivelPlan(ByVal pstrEmpresa As String)

        Dim objLNNivelPlan As New LN_NivelPlan
        Dim objENNivelPlan As New EN_NivelPlan

        objENNivelPlan.IdEmpresa = pstrEmpresa
        objLNNivelPlan.entNivelPlan = objENNivelPlan

        ddlNivelPlan.Items.Clear()

        objLNNivelPlan.Listar()

        ddlNivelPlan.DataTextField = "Descripcion"
        ddlNivelPlan.DataValueField = "IdNivel"
        ddlNivelPlan.DataSource = objLNNivelPlan.lstNivelPlan
        ddlNivelPlan.DataBind()

        ddlNivelPlan.Items.Insert(0, New ListItem("Seleccione>>>", ""))
        ddlNivelPlan.SelectedIndex = 0

    End Sub

    Public Sub llenarComboTipoAnalisis(ByVal pstrEmpresa As String)

        Dim objLNTipoAnalisis As New LN_TipoAnalisis
        Dim objENTipoAnalisis As New EN_TipoAnalisis

        objENTipoAnalisis.IdEmpresa = pstrEmpresa
        objLNTipoAnalisis.entTipoAnalisis = objENTipoAnalisis
        ddlTipoAnalisis.Items.Clear()

        objLNTipoAnalisis.Listar()
        ddlTipoAnalisis.DataTextField = "TipoAnalisis"
        ddlTipoAnalisis.DataValueField = "IdTipoAnalisis"
        ddlTipoAnalisis.DataSource = objLNTipoAnalisis.lstTiposAnalisis
        ddlTipoAnalisis.DataBind()

        ddlTipoAnalisis.Items.Insert(0, New ListItem("Seleccione>>>", ""))
        ddlTipoAnalisis.SelectedIndex = 0

    End Sub

    Public Sub llenarComboTipoCuenta(ByVal pstrEmpresa As String)

        Dim objLNTipoCuenta As New LN_TipoCuenta
        Dim objENTipoCuenta As New EN_TipoCuenta

        objENTipoCuenta.IdEmpresa = pstrEmpresa
        objLNTipoCuenta.entTipoCuenta = objENTipoCuenta
        ddlTipoCuenta.Items.Clear()

        objLNTipoCuenta.Listar()
        ddlTipoCuenta.DataTextField = "Descripcion"
        ddlTipoCuenta.DataValueField = "IdTipoCuenta"
        ddlTipoCuenta.DataSource = objLNTipoCuenta.lstTipoCuentas
        ddlTipoCuenta.DataBind()

        ddlTipoCuenta.Items.Insert(0, New ListItem("Seleccione>>>", ""))
        ddlTipoCuenta.SelectedIndex = 0

    End Sub

    Public Sub llenarComboEntidadFinanciera(ByVal pstrEmpresa As String)

        Dim objLNEntidadFinanciera As New LN_EntidadFinanciera
        Dim objENEntidadFinanciera As New EN_EntidadFinanciera

        objENEntidadFinanciera.IdEmpresa = pstrEmpresa
        objLNEntidadFinanciera.entEntidadFinanciera = objENEntidadFinanciera
        ddlEntidadFinanciera.Items.Clear()

        objLNEntidadFinanciera.Listar()
        ddlEntidadFinanciera.DataTextField = "NombreEntidad"
        ddlEntidadFinanciera.DataValueField = "IdEntidadFinanciera"
        ddlEntidadFinanciera.DataSource = objLNEntidadFinanciera.lstEntidadFinanciera
        ddlEntidadFinanciera.DataBind()

        ddlEntidadFinanciera.Items.Insert(0, New ListItem("Seleccione>>>", ""))
        ddlEntidadFinanciera.SelectedIndex = 0

    End Sub

    Public Sub llenarComboMoneda(ByVal pstrEmpresa As String)

        Dim objLNMoneda As New LN_Moneda
        Dim objENMoneda As New EN_Moneda

        objENMoneda.IdEmpresa = pstrEmpresa
        objLNMoneda.entMoneda = objENMoneda
        ddlMoneda.Items.Clear()

        objLNMoneda.Listar()
        ddlMoneda.DataTextField = "Moneda"
        ddlMoneda.DataValueField = "IdMoneda"
        ddlMoneda.DataSource = objLNMoneda.lstMonedas
        ddlMoneda.DataBind()

        ddlMoneda.Items.Insert(0, New ListItem("Seleccione>>>", ""))
        ddlMoneda.SelectedIndex = 0

    End Sub

    Public Sub llenarComboCuentaEntidad(ByVal pstrEmpresa As String)

        Dim objLNCuentaEntidad As New LN_CuentaEntidad
        Dim objENCuentaEntidad As New EN_CuentaEntidad

        objENCuentaEntidad.IdEmpresa = pstrEmpresa
        objENCuentaEntidad.IdEntidadFinanciera = ddlEntidadFinanciera.SelectedValue
        objLNCuentaEntidad.entCuentaEntidad = objENCuentaEntidad

        ddlCuentaEntidad.Items.Clear()

        objLNCuentaEntidad.Listar()
        ddlCuentaEntidad.DataTextField = "NumeroCuenta"
        ddlCuentaEntidad.DataValueField = "Secuencia"
        ddlCuentaEntidad.DataSource = objLNCuentaEntidad.lstCuentaEntidad
        ddlCuentaEntidad.DataBind()

        ddlCuentaEntidad.Items.Insert(0, New ListItem("Seleccione>>>", ""))
        ddlCuentaEntidad.SelectedIndex = 0
    End Sub

    Public Sub registrar()

        Dim objLNPlanCuenta As New LN_PlanCuenta
        Dim objENPlanCuenta As New EN_PlanCuenta


        objENPlanCuenta.IdCuentaContable = txtCodigo.Text
        objENPlanCuenta.IdEmpresa = ddlEmpresa.SelectedValue
        objENPlanCuenta.IdContabilidad = ddlContabilidad.SelectedValue
        objENPlanCuenta.IdPlanContable = hdnPlanContable.Value

        objENPlanCuenta.Nombre = txtNombre.Text
        objENPlanCuenta.IdNivel = ddlNivelPlan.SelectedValue
        objENPlanCuenta.IdTipoAnalisis = ddlTipoAnalisis.SelectedValue
        objENPlanCuenta.IdTipoCuenta = ddlTipoCuenta.SelectedValue

        If txtDiferenciaCambio.Text = "" Then
            txtDiferenciaCambio.Text = ""

        End If
        If txtConversionMoneda.Text = "" Then
            txtConversionMoneda.Text = ""
        End If

        objENPlanCuenta.DiferenciaCambio = txtDiferenciaCambio.Text
        objENPlanCuenta.ConversionMoneda = txtConversionMoneda.Text
        objENPlanCuenta.IdEntidadFinanciera = ddlEntidadFinanciera.SelectedValue
        objENPlanCuenta.IdMoneda = ddlMoneda.SelectedValue

        If ddlCuentaEntidad.SelectedIndex = 0 Then
            objENPlanCuenta.CuentaEntidad = "0"
        Else
            objENPlanCuenta.CuentaEntidad = ddlCuentaEntidad.SelectedValue

        End If


        objENPlanCuenta.CuentaDebe = txtCuentaDebe.Text
        objENPlanCuenta.CuentaHaber = txtCuentaHaber.Text
        objENPlanCuenta.IdCuentaPadre = txtCuentaPadre.Text

        objLNPlanCuenta.entPlanCuenta = objENPlanCuenta

        If objLNPlanCuenta.Registrar = True Then

            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Registro completo');</script>")
            Limpiar()
            RaiseEvent cargarGrilla()

        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Sucedio un error. Revisar los datos.');</script>")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            hdnEmpresa.Value = Session("Empresa")
            hdnContabilidad.Value = Session("Contabilidad")
            hdnPlanContable.Value = Session("PlanContable")
            LlenarComboEmpresa()
            llenarComboContabilidad(hdnEmpresa.Value)
            llenarComboEntidadFinanciera(hdnEmpresa.Value)
            llenarComboMoneda(hdnEmpresa.Value)
            llenarComboNivelPlan(hdnEmpresa.Value)
            'llenarComboPlanContable(ddlEmpresa.SelectedValue)
            llenarComboTipoAnalisis(hdnEmpresa.Value)
            llenarComboTipoCuenta(hdnEmpresa.Value)
            llenarComboCuentaEntidad(hdnEmpresa.Value)

        End If
    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click

        If ddlEmpresa.SelectedValue <> "" Then



            registrar()
            Limpiar()
            RaiseEvent cargarGrilla()
            RaiseEvent Registrado()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('RSeleccione una Opcion...');</script>")
        End If
    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTerminar.Click

        If ddlEmpresa.SelectedValue <> "" Then

            registrar()
            Limpiar()
            RaiseEvent cargarGrilla()
            RaiseEvent Cerrado()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('RSeleccione una Opcion...');</script>")
        End If

    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        RaiseEvent Cerrado()
    End Sub

    Protected Sub ddlEmpresa_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmpresa.SelectedIndexChanged
        llenarComboContabilidad(ddlEmpresa.SelectedValue)
        llenarComboEntidadFinanciera(ddlEmpresa.SelectedValue)
        llenarComboMoneda(ddlEmpresa.SelectedValue)
        llenarComboNivelPlan(ddlEmpresa.SelectedValue)
        'llenarComboPlanContable(ddlEmpresa.SelectedValue)
        llenarComboTipoAnalisis(ddlEmpresa.SelectedValue)
        llenarComboTipoCuenta(ddlEmpresa.SelectedValue)
        llenarComboCuentaEntidad(ddlEmpresa.SelectedValue)
    End Sub

    Protected Sub ddlEntidadFinanciera_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEntidadFinanciera.SelectedIndexChanged
        llenarComboCuentaEntidad(hdnEmpresa.Value)
    End Sub
End Class
