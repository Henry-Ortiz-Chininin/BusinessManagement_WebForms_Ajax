Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG
Imports EN_ALVINET_CONTA.GENERAL
Imports LN_ALVINET_CONTA.GENERAL

Partial Class CONTROLES_REGISTRO_ctlEjercicioMes_Registrar
    Inherits System.Web.UI.UserControl

    Private _entEjercicioMes As New EN_EjercicioMes

    Public Property EjercicioMes() As EN_EjercicioMes
        Get
            Return _entEjercicioMes
        End Get
        Set(ByVal value As EN_EjercicioMes)
            _entEjercicioMes = value

            txtCodigo.Text = _entEjercicioMes.IdEjercicioMes
            txtCodigo.Enabled = False
            If _entEjercicioMes.IdEmpresa = ddlEmpresa.SelectedValue Then
                ddlEmpresa.SelectedValue = _entEjercicioMes.IdEmpresa
                ddlEmpresa.Enabled = False

            End If



            ddlEjercicioEmpresa.SelectedValue = _entEjercicioMes.IdEjercicioEmpresa
            ddlEjercicioEmpresa.Enabled = False

            txtDescripcion.Text = _entEjercicioMes.EjercicioMes
            txtFechaInicio.Text = _entEjercicioMes.FechaInicio
            txtFechaFin.Text = _entEjercicioMes.FechaFinal

            If _entEjercicioMes.Estado = "ACT" Then
                chkEstado.Checked = True
            Else
                chkEstado.Checked = False
            End If

        End Set

    End Property

    Public Event cargarGrilla()
    Public Event Registrado()
    Public Event Cerrado()

    Public Sub registrar()

        Dim objENEjercicioMes As New EN_EjercicioMes
        Dim objLNEjercicioMes As New LN_EjercicioMes

        objENEjercicioMes.IdEjercicioMes = txtCodigo.Text
        objENEjercicioMes.IdEmpresa = ddlEmpresa.SelectedValue
        objENEjercicioMes.IdEjercicioEmpresa = ddlEjercicioEmpresa.SelectedValue
        objENEjercicioMes.FechaInicio = txtFechaInicio.Text
        objENEjercicioMes.FechaFinal = txtFechaFin.Text
        objENEjercicioMes.EjercicioMes = txtDescripcion.Text
        If chkEstado.Checked = True Then
            objENEjercicioMes.Estado = "ACT"
        Else
            objENEjercicioMes.Estado = "ANU"
        End If

        objLNEjercicioMes.entEjercicioMes = objENEjercicioMes

        If objLNEjercicioMes.Registrar() Then
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Registro completo');</script>")
            limpiar()
            RaiseEvent cargarGrilla()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Sucedio un Error, Revisar los Datos');</script>")
        End If

    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        If ddlEjercicioEmpresa.SelectedValue <> "" AndAlso ddlEmpresa.SelectedValue <> "" Then
            registrar()
            RaiseEvent cargarGrilla()
            RaiseEvent Registrado()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('RSeleccione una Opcion...');</script>")
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

    Public Sub llenarComboEjerccioEmpresa(ByVal pstrEmpresa As String)
        Dim objLNEjerccioEmpresa As New LN_EjercicioEmpresa
        Dim objENEjerccioEmpresa As New EN_EjercicioEmpresa

        ddlEjercicioEmpresa.Items.Clear()
        objENEjerccioEmpresa.IdEmpresa = pstrEmpresa
        objLNEjerccioEmpresa.entEjercicioEmpresa = objENEjerccioEmpresa
        objLNEjerccioEmpresa.Buscar()
        ddlEjercicioEmpresa.DataTextField = "IdEjercicio"
        ddlEjercicioEmpresa.DataValueField = "IdEjercicioEmpresa"
        ddlEjercicioEmpresa.DataSource = objLNEjerccioEmpresa.lstEjerciciosEmpresa

        ddlEjercicioEmpresa.DataBind()

        ddlEjercicioEmpresa.Items.Insert(0, New ListItem("Seleccione>>>", ""))
        ddlEjercicioEmpresa.SelectedIndex = 0

    End Sub




    Public Sub limpiar()

        ddlEmpresa.Enabled = False
        ddlEmpresa.SelectedIndex = 0

        ddlEjercicioEmpresa.Enabled = True
        ddlEjercicioEmpresa.SelectedIndex = 0

        chkEstado.Checked = True

        txtCodigo.Text = ""
        txtDescripcion.Text = ""
        txtFechaInicio.Text = ""
        txtFechaFin.Text = ""

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            txtCodigo.Enabled = False
            SetEmpresa()
            LlenarComboEmpresaInterno()
            llenarComboEjerccioEmpresa(ddlEmpresa.SelectedValue)

        End If
    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTerminar.Click

        If ddlEjercicioEmpresa.SelectedValue <> "" AndAlso ddlEmpresa.SelectedValue <> "" Then
            registrar()
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
        llenarComboEjerccioEmpresa(ddlEmpresa.SelectedValue)
    End Sub

    Protected Sub chkEstado_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEstado.CheckedChanged
        If chkEstado.Checked Then
            chkEstado.Text = "Activo"
        Else
            chkEstado.Text = "Desactivo"
        End If

    End Sub
End Class
