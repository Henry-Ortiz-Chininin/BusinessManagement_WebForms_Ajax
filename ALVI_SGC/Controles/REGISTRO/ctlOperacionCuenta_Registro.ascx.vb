Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG
Imports EN_ALVINET_CONTA.GENERAL
Imports LN_ALVINET_CONTA.GENERAL
Imports EN_ALVINET_CONTA
Imports LN_ALVINET_CONTA

Partial Class CONTROLES_REGISTRO_ctlOperacionCuenta_Registro
    Inherits System.Web.UI.UserControl

    Private _enOperacionCuenta As New EN_OperacionesCuenta

    Public Property EnOperacionC() As String
        Get
            Return lblTipoMovimiento.Text
        End Get
        Set(ByVal value As String)
            lblTipoMovimiento.Text = value
        End Set
    End Property


    Public Property enOperacionCuenta As EN_OperacionesCuenta
        Get
            Return _enOperacionCuenta
        End Get
        Set(ByVal value As EN_OperacionesCuenta)

            _enOperacionCuenta = value
            If _enOperacionCuenta.IdEmpresa = ddlEmpresa.SelectedValue Then
                ddlEmpresa.SelectedValue = _enOperacionCuenta.IdEmpresa

            End If
            txtCodigo.Text = _enOperacionCuenta.IdOperacionCuenta

            ddlEmpresa.Enabled = False

            If _enOperacionCuenta.IdOperacion = "" Or _enOperacionCuenta.IdOperacion = "0" Then
                ddlSubOperacion.SelectedIndex = 0
            Else
                ddlSubOperacion.SelectedValue = _enOperacionCuenta.IdOperacion
            End If


            ddlSubOperacion.Enabled = False
            'lblContabilidad.Text = _entOperacionCuenta.Idcontabilidad
            'pnlContabilidad.Visible = Truelimpiar
            'lblContabilidad.Visible = True
            'lblContabilidad.Enabled = False
            hdnIdCuenta.Value = _enOperacionCuenta.IdCuentaContable
            txtDescripcion.Text = _enOperacionCuenta.Observacion
            If _enOperacionCuenta.IdSubOperacion = "" Or _enOperacionCuenta.IdSubOperacion = "0" Then
                ddlSubOperacionn.SelectedIndex = 0
            Else
                ddlSubOperacionn.SelectedValue = _enOperacionCuenta.IdSubOperacion
            End If


            ddlSubOperacionn.Enabled = False
            If _enOperacionCuenta.EsCargo = "S" Then
                chkCargo.Checked = True
                chkAbono.Checked = False
            ElseIf _enOperacionCuenta.EsCargo = "N" Then
                chkCargo.Checked = False
                chkAbono.Checked = True
            End If

            If _enOperacionCuenta.EsAbono = "S" Then
                chkCargo.Checked = False
                chkAbono.Checked = True
            ElseIf _enOperacionCuenta.EsAbono = "N" Then
                chkCargo.Checked = True
                chkAbono.Checked = False
            End If
            If _enOperacionCuenta.EsObligatorio = "S" Then
                chkObligatorio.Checked = True
            End If
            txtDescripcio.Text = _enOperacionCuenta.Nombre
        End Set
    End Property

    Public Event cargarGrilla()
    Public Event Registrado()
    Public Event Cerrado()

    Protected Sub ctlOperacionCuenta_Cerrado() Handles ctlCuentaBuscar.Cerrado
        pnlCuenta.Visible = False

    End Sub
    Public Sub Limpiar()

        hdnIdCuenta.Value = ""
        ddlEmpresa.SelectedIndex = 0
        ddlEmpresa.Enabled = False

        chkAbono.Checked = False
        chkCargo.Checked = False
        chkObligatorio.Checked = False
        txtDescripcio.Text = ""
        txtDescripcion.Text = ""
    End Sub

    Public Sub registrar()

        Dim objLNOperacionCuenta As New LN_OperacionCuenta
        Dim objENOperacionCuenta As New EN_OperacionesCuenta
        objENOperacionCuenta.IdOperacionCuenta = txtCodigo.Text
        objENOperacionCuenta.IdCuentaContable = hdnIdCuenta.Value
        objENOperacionCuenta.IdEmpresa = ddlEmpresa.SelectedValue
        objENOperacionCuenta.IdOperacion = ddlSubOperacion.SelectedValue
        objENOperacionCuenta.Idcontabilidad = hdnContabilidad.Value

        If chkAbono.Checked = True Then
            objENOperacionCuenta.EsAbono = "S"
            objENOperacionCuenta.EsCargo = "N"
        End If
        If chkCargo.Checked = True Then
            objENOperacionCuenta.EsCargo = "S"
            objENOperacionCuenta.EsAbono = "N"
        End If
        If chkObligatorio.Checked Then
            objENOperacionCuenta.EsObligatorio = "S"
        End If
        objENOperacionCuenta.IdSubOperacion = ddlSubOperacionn.SelectedValue
        objENOperacionCuenta.Nombre = txtDescripcio.Text
        objENOperacionCuenta.Observacion = txtDescripcion.Text
        objENOperacionCuenta.TipoMovimiento = lblTipoMovimiento.Text

        objLNOperacionCuenta.entOperacionCuenta = objENOperacionCuenta


        If objLNOperacionCuenta.Registrar = True Then
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Registro completo');</script>")
            txtCodigo.Text = objENOperacionCuenta.IdOperacionCuenta
            Limpiar()
            RaiseEvent cargarGrilla()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Sucedio un error. Revisar los datos.');</script>")
        End If

    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click

        If ddlEmpresa.SelectedValue <> "" AndAlso ddlSubOperacion.SelectedValue <> "" AndAlso _
            hdnContabilidad.Value <> "" AndAlso hdnIdCuenta.Value <> "" Then
            registrar()
            RaiseEvent cargarGrilla()
            RaiseEvent Registrado()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Seleccione una Opcion...');</script>")
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


    Public Sub llenarComboOperacion(ByVal pstrEmpresa As String)
        Dim objLNOperacion As New LN_Operacion
        Dim objENOperacion As New EN_Operacion

        objENOperacion.Idempresa = pstrEmpresa
        objLNOperacion.entOperacion = objENOperacion

        ddlSubOperacion.Items.Clear()

        objLNOperacion.Listar()
        ddlSubOperacion.DataTextField = "Descripcion"
        ddlSubOperacion.DataValueField = "IdOperacion"
        ddlSubOperacion.DataSource = objLNOperacion.lstOperacion
        ddlSubOperacion.DataBind()

        ddlSubOperacion.Items.Insert(0, New ListItem("Seleccione>>>", ""))
        'ddlSubOperacion.SelectedIndex = 0


    End Sub
    Public Sub llenarComboSubOperacion(ByVal pstrOperacion As String)
        Dim objLNSubOperacion As New LN_SubOperacion
        Dim objENSubOperacion As New EN_SubOperacion
        objENSubOperacion.Idempresa = hdnEmpresa.Value
        objENSubOperacion.IdOperacion = pstrOperacion
        objLNSubOperacion.entSubOperacion = objENSubOperacion

        ddlSubOperacionn.Items.Clear()

        objLNSubOperacion.ListarN()
        ddlSubOperacionn.DataTextField = "SubOperacion"
        ddlSubOperacionn.DataValueField = "IdSubOperacion"
        ddlSubOperacionn.DataSource = objLNSubOperacion.lstSubOperacion
        ddlSubOperacionn.DataBind()

        ddlSubOperacionn.Items.Insert(0, New ListItem("Seleccione>>>", ""))


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            hdnContabilidad.Value = Session("Contabilidad")
            SetEmpresa()
            LlenarComboEmpresaInterno()
            llenarComboOperacion(ddlEmpresa.SelectedValue)
            llenarComboSubOperacion(ddlSubOperacion.SelectedValue)
            pnlCuenta.Visible = False
        End If
    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTerminar.Click
        If ddlEmpresa.SelectedValue <> "" AndAlso ddlSubOperacion.SelectedValue <> "" AndAlso _
           hdnContabilidad.Value <> "" AndAlso hdnIdCuenta.Value <> "" Then
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

    Protected Sub ddlEmpresa_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmpresa.SelectedIndexChanged
        'llenarComboContabilidad(ddlEmpresa.SelectedValue)
        llenarComboOperacion(ddlEmpresa.SelectedValue)
    End Sub

    Protected Sub ddlSubOperacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSubOperacion.SelectedIndexChanged
        llenarComboSubOperacion(ddlSubOperacion.SelectedValue)
    End Sub
    Private Sub setLista()
        txtDescripcio.Text = ctlCuentaBuscar.Descripcion
        hdnIdCuenta.Value = ctlCuentaBuscar.IdCuenta
        pnlCuenta.Visible = False
    End Sub
    Protected Sub ctlVoucherBuscar_cargarDatos() Handles ctlCuentaBuscar.cargarDatos
        setLista()
    End Sub
    Public Sub bindLista()
        pnlCuenta.Visible = True

        If IsNumeric(txtDescripcio.Text) Then
            ctlCuentaBuscar.IdCuenta = txtDescripcio.Text
        Else
            ctlCuentaBuscar.Descripcion = txtDescripcio.Text
        End If
        ctlCuentaBuscar.bindLista()

    End Sub
    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        bindLista()
    End Sub
End Class
