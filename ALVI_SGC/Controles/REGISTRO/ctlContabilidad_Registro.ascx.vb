Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG
Imports EN_ALVINET_CONTA.GENERAL
Imports LN_ALVINET_CONTA.GENERAL

Partial Class CONTROLES_REGISTRO_ctlContabilidad_Registro
    Inherits System.Web.UI.UserControl

    Private _entContabilidad As New EN_Contabilidad

    Public Property Contabilidad() As EN_Contabilidad
        Get
            Return _entContabilidad
        End Get

        Set(ByVal value As EN_Contabilidad)
            _entContabilidad = value

            txtCodigo.Text = _entContabilidad.IdContabilidad
            txtCodigo.Enabled = False
            If _entContabilidad.IdEmpresa = ddlEmpresa.SelectedValue Then
                ddlEmpresa.SelectedValue = _entContabilidad.IdEmpresa
                ddlEmpresa.Enabled = False
            End If

            ddlMoneda.SelectedValue = _entContabilidad.IdMoneda
            If _entContabilidad.Estado = "Activo" Then
                chkEstado.Checked = True
            Else
                chkEstado.Checked = False
            End If

            txtDescripcion.Text = _entContabilidad.Contabilidad

            txtCuentaGananciaCambio.Text = _entContabilidad.CuentaGananciaCambio
            txtCuentaPerdidaCambio.Text = _entContabilidad.CuentaPerdidaCambio

        End Set
    End Property

    Public Event cargarGrilla()
    Public Event Registrado()
    Public Event Cerrado()

    Public Property comboCod() As String
        Get
            Return ddlEmpresa.SelectedValue
        End Get

        Set(ByVal value As String)

            ddlEmpresa.SelectedItem.Text = value
        End Set
    End Property

    Public Sub registrar()

        Dim objENContabilidad As New EN_Contabilidad
        Dim objLNContabilidad As New LN_Contabilidad


        objENContabilidad.IdContabilidad = txtCodigo.Text
        objENContabilidad.IdEmpresa = ddlEmpresa.SelectedValue
        objENContabilidad.Contabilidad = txtDescripcion.Text
        objENContabilidad.IdMoneda = ddlMoneda.SelectedValue
        If chkEstado.Checked = True Then
            objENContabilidad.Estado = "ACT"
        Else
            objENContabilidad.Estado = "ANU"
        End If
        objENContabilidad.CuentaGananciaCambio = txtCuentaGananciaCambio.Text
        objENContabilidad.CuentaPerdidaCambio = txtCuentaPerdidaCambio.Text

        objLNContabilidad.entContabilidad = objENContabilidad

        If objLNContabilidad.Registrar() Then
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Registro completo');</script>")
            limpiar()
            RaiseEvent cargarGrilla()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Sucedio un Error al Registrar.');</script>")
        End If

    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click

        If ddlEmpresa.SelectedValue <> "" AndAlso ddlMoneda.SelectedValue <> "" Then
            registrar()
            RaiseEvent cargarGrilla()
            RaiseEvent Registrado()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Seleccione una Opcion');</script>")
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            SetEmpresa()
            LlenarComboEmpresaInterno()
            llenarComboMoneda(ddlEmpresa.SelectedValue)
            txtCodigo.Enabled = False
        End If

    End Sub

    Public Sub llenarComboMoneda(ByVal pstrEmpresa As String)

        Dim objLNMoneda As New LN_Moneda
        Dim objENMoneda As New EN_Moneda

        ddlMoneda.Items.Clear()

        objENMoneda.IdEmpresa = pstrEmpresa

        objLNMoneda.entMoneda = objENMoneda
        objLNMoneda.Buscar()

        ddlMoneda.DataTextField = "Moneda"
        ddlMoneda.DataValueField = "IdMoneda"
        ddlMoneda.DataSource = objLNMoneda.lstMonedas
        ddlMoneda.DataBind()

        ddlMoneda.Items.Insert(0, New ListItem("Seleccione>>>", ""))
        ddlMoneda.SelectedIndex = 0

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



    Public Sub limpiar()

        txtCodigo.Text = ""

        ddlEmpresa.Enabled = False
        ddlEmpresa.SelectedIndex = 0
        ddlMoneda.SelectedIndex = 0
        txtDescripcion.Text = ""
        txtCuentaGananciaCambio.Text = ""
        txtCuentaPerdidaCambio.Text = ""

        chkEstado.Checked = True
    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTerminar.Click
        If ddlEmpresa.SelectedValue <> "" AndAlso ddlMoneda.SelectedValue <> "" Then
            registrar()
            RaiseEvent cargarGrilla()
            RaiseEvent Cerrado()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Seleccione una Opcion');</script>")
        End If
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        RaiseEvent cargarGrilla()
        RaiseEvent Cerrado()
    End Sub

    Protected Sub ddlEmpresa_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmpresa.SelectedIndexChanged
        llenarComboMoneda(ddlEmpresa.SelectedValue)
    End Sub

    Protected Sub chkEstado_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEstado.CheckedChanged
        If chkEstado.Checked = True Then
            chkEstado.Text = "Activo"
        Else
            chkEstado.Text = "Desactivo"

        End If

    End Sub
End Class
