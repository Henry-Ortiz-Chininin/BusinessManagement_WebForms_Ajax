Imports EN_ALVINET_CONTA.OPERACION
Imports LN_ALVINET_CONTA.OPERACION
Imports EN_ALVINET_CONTA.GENERAL
Imports LN_ALVINET_CONTA.GENERAL
Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG

Partial Class CONTROLES_REGISTRO_ctlVoucherCuenta_Registro
    Inherits System.Web.UI.UserControl

    Private _entVoucherCuenta As New EN_VoucherCuenta

    Public Property VoucherCuenta As EN_VoucherCuenta
        Get
            Return _entVoucherCuenta
        End Get
        Set(ByVal value As EN_VoucherCuenta)

            _entVoucherCuenta = value

            txtcodigo.Text = _entVoucherCuenta.IdCuentaContable
            txtcodigo.Enabled = False

            ddlEjercicioEmpresa.SelectedValue = _entVoucherCuenta.IdEjercicio
            ddlEjercicioEmpresa.Enabled = False

            ddlContabilidad.SelectedValue = _entVoucherCuenta.IdContabilidad
            ddlContabilidad.Enabled = False

            ddlOperacion.SelectedValue = _entVoucherCuenta.IdOperacion
            ddlOperacion.Enabled = False

            ddlAsiento.SelectedValue = _entVoucherCuenta.IdAsiento
            ddlAsiento.Enabled = False

            txtEsCargo.Text = _entVoucherCuenta.Escargo
            txtImporte.Text = _entVoucherCuenta.Total
            txtObservacion.Text = _entVoucherCuenta.Glosa

        End Set
    End Property

    Public Event cargarGrilla()
    Public Event Registrado()
    Public Event Cerrado()

    Public Sub Limpiar()

        txtCodigo.Text = ""

        ddlEmpresa.Enabled = True
        ddlEmpresa.SelectedIndex = 0

        ddlEjercicioEmpresa.Enabled = True
        ddlEjercicioEmpresa.SelectedIndex = 0

        ddlContabilidad.Enabled = True
        ddlContabilidad.SelectedIndex = 0

        ddlOperacion.Enabled = True
        ddlOperacion.SelectedIndex = 0

        ddlAsiento.Enabled = True
        ddlAsiento.SelectedIndex = 0

        txtEsCargo.Text = ""
        txtImporte.Text = ""
        txtObservacion.Text = ""

    End Sub

    Public Sub registrar()

        'Dim objLNVoucherCuenta As New LN_ALVINET_CONTA.LN_VoucherCuenta
        'Dim objENVoucherCuenta As New EN_ALVINET_CONTA.EN_VoucherCuenta

        'objENVoucherCuenta.IdCuenta = txtcodigo.Text
        'objENVoucherCuenta.IdEmpresa = ddlEmpresa.SelectedValue
        'objENVoucherCuenta.IdEjercicioEmpresa = txtcodigo.Text
        'objENVoucherCuenta.IdContabilidad = ddlContabilidad.SelectedValue
        'objENVoucherCuenta.IdOperacion = ddlOperacion.SelectedValue
        'objENVoucherCuenta.IdAsiento = ddlOperacion.SelectedValue

        'objENVoucherCuenta.Escargo = txtEsCargo.Text
        'objENVoucherCuenta.Importe = txtImporte.Text
        'objENVoucherCuenta.Observacion = txtObservacion.Text

        'objLNVoucherCuenta.entVoucherCuenta = objENVoucherCuenta

        'If objLNVoucherCuenta.Registrar = True Then
        '    Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Registro completo');</script>")
        '    Limpiar()
        '    RaiseEvent cargarGrilla()
        'Else
        '    Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Sucedio un error. Revisar los datos.');</script>")
        'End If

    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click

        If ddlEmpresa.SelectedValue <> "" AndAlso ddlEjercicioEmpresa.SelectedValue <> "" AndAlso _
            ddlContabilidad.SelectedValue <> "" AndAlso ddlOperacion.SelectedValue <> "" AndAlso _
            ddlAsiento.SelectedValue <> "" Then
            registrar()
            RaiseEvent cargarGrilla()
            RaiseEvent Registrado()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Seleccione una Opcion...');</script>")
        End If

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

    Public Sub llenarComboEjercicioEmpresa()

        Dim objLNEjercicioEmpresa As New LN_EjercicioEmpresa
        Dim objENEjercicioEmpresa As New EN_EjercicioEmpresa

        objENEjercicioEmpresa.IdEmpresa = hdnEmpresa.Value
        objLNEjercicioEmpresa.entEjercicioEmpresa = objENEjercicioEmpresa

        ddlEjercicioEmpresa.Items.Clear()

        objLNEjercicioEmpresa.Listar()
        ddlEjercicioEmpresa.DataTextField = "IdEjercicio"
        ddlEjercicioEmpresa.DataValueField = "IdEjercicio"
        ddlEjercicioEmpresa.DataSource = objLNEjercicioEmpresa.lstEjerciciosEmpresa
        ddlEjercicioEmpresa.DataBind()

        ddlEjercicioEmpresa.Items.Insert(0, New ListItem("Seleccione>>>", ""))
        ddlEjercicioEmpresa.SelectedIndex = 0

    End Sub

    Public Sub llenarComboContabilidad()

        Dim objLNContabilidad As New LN_Contabilidad
        Dim objENContabilidad As New EN_Contabilidad

        objENContabilidad.IdEmpresa = hdnEmpresa.Value
        objLNContabilidad.entContabilidad = objENContabilidad

        ddlContabilidad.Items.Clear()

        objLNContabilidad.Listar()
        ddlContabilidad.DataTextField = "Contabilidad"
        ddlContabilidad.DataValueField = "IdContabilidad"
        ddlContabilidad.DataSource = objLNContabilidad.lstContabilidades
        ddlContabilidad.DataBind()

        ddlContabilidad.Items.Insert(0, New ListItem("Seleccione>>>", ""))
        ddlContabilidad.SelectedIndex = 0

    End Sub

    Public Sub llenarComboOperacion()

        Dim objLNOperacion As New LN_Operacion
        Dim objENOperacion As New EN_Operacion

        objENOperacion.Idempresa = hdnEmpresa.Value
        objLNOperacion.entOperacion = objENOperacion

        ddlOperacion.Items.Clear()

        objLNOperacion.Listar()
        ddlOperacion.DataTextField = "Operacion"
        ddlOperacion.DataValueField = "IdOperacion"
        ddlOperacion.DataSource = objLNOperacion.lstOperacion
        ddlOperacion.DataBind()

        ddlOperacion.Items.Insert(0, New ListItem("Seleccione>>>", ""))
        ddlOperacion.SelectedIndex = 0

    End Sub

    Public Sub llenarComboAsiento()

        'Dim objLNVoucher As New LN_Voucher
        'ddlAsiento.Items.Clear()

        'objLNVoucher.Listar()
        'ddlOperacion.DataTextField = "Descripcion"
        'ddlOperacion.DataValueField = "IdOperacion"
        'ddlOperacion.DataSource = objLNVoucher.lstOperacion
        'ddlOperacion.DataBind()

        'ddlOperacion.Items.Insert(0, New ListItem("Seleccione>>>", ""))
        'ddlOperacion.SelectedIndex = 0

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            hdnEmpresa.Value = Session("Empresa")
            llenarComboEmpresa()
            llenarComboEjercicioEmpresa()
            llenarComboContabilidad()
            llenarComboOperacion()
            llenarComboAsiento()
            txtcodigo.Enabled = False
        End If
    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTerminar.Click
        If ddlEmpresa.SelectedValue <> "" AndAlso ddlEjercicioEmpresa.SelectedValue <> "" AndAlso _
            ddlContabilidad.SelectedValue <> "" AndAlso ddlOperacion.SelectedValue <> "" AndAlso _
            ddlAsiento.SelectedValue <> "" Then
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

End Class
