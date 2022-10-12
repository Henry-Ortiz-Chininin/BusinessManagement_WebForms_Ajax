Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG
Imports EN_ALVINET_CONTA.GENERAL
Imports LN_ALVINET_CONTA.GENERAL

Partial Class CONTROLES_REGISTRO_ctlEjercicio_Registro
    Inherits System.Web.UI.UserControl

    Private _entEjercicio As New EN_Ejercicio

    Public Property Ejercicio() As EN_Ejercicio
        Get
            Return _entEjercicio
        End Get
        Set(ByVal value As EN_Ejercicio)
            _entEjercicio = value

            txtCodigo.Text = _entEjercicio.IdEjercicio
            txtCodigo.Enabled = False
            If _entEjercicio.IdEmpresa = ddlEmpresa.SelectedValue Then
                ddlEmpresa.SelectedValue = _entEjercicio.IdEmpresa


            End If
            ddlEmpresa.Enabled = False


            txtFechaInicio.Text = _entEjercicio.FechaInicio
            txtFechaFin.Text = _entEjercicio.FechaFinal
            txtDescripcion.Text = _entEjercicio.Ejercicio
            txtAgno.Text = _entEjercicio.Agno
        End Set

    End Property

    Public Event cargarGrilla()
    Public Event Registrado()
    Public Event Cerrado()

    Public Sub registrar()
        Dim objENEjercicio As New EN_Ejercicio
        Dim objLNEjercicio As New LN_Ejercicio

        objENEjercicio.IdEjercicio = txtCodigo.Text
        objENEjercicio.IdEmpresa = ddlEmpresa.SelectedValue
        objENEjercicio.FechaInicio = txtFechaInicio.Text
        objENEjercicio.FechaFinal = txtFechaFin.Text
        objENEjercicio.Ejercicio = txtDescripcion.Text
        objENEjercicio.Agno = txtAgno.Text

        objLNEjercicio.entEjercicio = objENEjercicio

        If objLNEjercicio.Registrar() Then
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Registro completo');</script>")
            LIMPIAR()
            RaiseEvent cargarGrilla()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Sucedio un Error, Revisar los Datos');</script>")
        End If
    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        If ddlEmpresa.SelectedValue <> "" Then
            registrar()
            RaiseEvent cargarGrilla()
            RaiseEvent Registrado()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Seleccione un opcion...');</script>")
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

    Public Sub LIMPIAR()

        txtCodigo.Text = ""
        ddlEmpresa.Enabled = False
        ddlEmpresa.SelectedIndex = 0

        txtFechaFin.Text = ""
        txtFechaInicio.Text = ""
        txtDescripcion.Text = ""
        txtAgno.Text = ""

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            SetEmpresa()
            LlenarComboEmpresaInterno()
            txtCodigo.Enabled = False

        End If
    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTerminar.Click
        If ddlEmpresa.SelectedValue <> "" Then
            registrar()
            RaiseEvent cargarGrilla()
            RaiseEvent Cerrado()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Seleccione un opcion...');</script>")
        End If
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        RaiseEvent Cerrado()
    End Sub
End Class
