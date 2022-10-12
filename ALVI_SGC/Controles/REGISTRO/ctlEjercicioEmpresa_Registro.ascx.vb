Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG
Imports EN_ALVINET_CONTA.GENERAL
Imports LN_ALVINET_CONTA.GENERAL

Partial Class CONTROLES_REGISTRO_ctlEjercicioEmpresa_Registro
    Inherits System.Web.UI.UserControl

    Private _entEjercicioEmpresa As New EN_EjercicioEmpresa

    Public Property EjercicioEmpresa() As EN_EjercicioEmpresa
        Get
            Return _entEjercicioEmpresa
        End Get
        Set(ByVal value As EN_EjercicioEmpresa)
            _entEjercicioEmpresa = value

            txtCodigo.Text = _entEjercicioEmpresa.IdEjercicioEmpresa
            txtCodigo.Enabled = False
            If _entEjercicioEmpresa.IdEmpresa = ddlEmpresa.SelectedValue Then
                ddlEmpresa.SelectedValue = _entEjercicioEmpresa.IdEmpresa
                ddlEmpresa.Enabled = False

            End If



            ddlContabilidad.SelectedValue = _entEjercicioEmpresa.IdContabilidad
            ddlEjercicio.SelectedValue = _entEjercicioEmpresa.IdEjercicio
            If _entEjercicioEmpresa.Estado = "ACT" Then
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

        Dim objENEjercicioEmpresa As New EN_EjercicioEmpresa
        Dim objLNEjercicioEmpresa As New LN_EjercicioEmpresa

        objENEjercicioEmpresa.IdEjercicioEmpresa = txtCodigo.Text
        objENEjercicioEmpresa.IdEmpresa = ddlEmpresa.SelectedValue
        objENEjercicioEmpresa.IdContabilidad = ddlContabilidad.SelectedValue
        objENEjercicioEmpresa.IdEjercicio = ddlEjercicio.SelectedValue
        If chkEstado.Checked = True Then
            objENEjercicioEmpresa.Estado = "ACT"
        Else
            objENEjercicioEmpresa.Estado = "ANU"
        End If

        objLNEjercicioEmpresa.entEjercicioEmpresa = objENEjercicioEmpresa

        If objLNEjercicioEmpresa.Registrar() Then
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Registro completo');</script>")
            limpiar()
            RaiseEvent cargarGrilla()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Sucedio un Error, Revisar los Datos');</script>")
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

    Public Sub llenarComboContabilidad(ByVal pstrEmpresa As String)

        Dim objLNContabilidad As New LN_Contabilidad
        Dim objENContabilidad As New EN_Contabilidad

        ddlContabilidad.Items.Clear()

        objENContabilidad.IdEmpresa = pstrEmpresa
        objLNContabilidad.entContabilidad = objENContabilidad

        objLNContabilidad.Buscar()
        ddlContabilidad.DataTextField = "Contabilidad"
        ddlContabilidad.DataValueField = "IdContabilidad"
        ddlContabilidad.DataSource = objLNContabilidad.lstContabilidades
        ddlContabilidad.DataBind()

        ddlContabilidad.Items.Insert(0, New ListItem("Seleccione>>>", ""))
        ddlContabilidad.SelectedIndex = 0

    End Sub

    Public Sub llenarComboEjercicio(ByVal pstrEmpresa As String)
        Dim objLNEjercicio As New LN_Ejercicio
        Dim objENEjercicio As New EN_Ejercicio
        ddlEjercicio.Items.Clear()

        objENEjercicio.IdEmpresa = pstrEmpresa
        objLNEjercicio.entEjercicio = objENEjercicio

        objLNEjercicio.Buscar()
        ddlEjercicio.DataTextField = "Agno"
        ddlEjercicio.DataValueField = "IdEjercicio"
        ddlEjercicio.DataSource = objLNEjercicio.lstEjercicios
        ddlEjercicio.DataBind()

        ddlEjercicio.Items.Insert(0, New ListItem("Seleccione>>>", ""))
        ddlEjercicio.SelectedIndex = 0

    End Sub


    Public Sub limpiar()
        txtCodigo.Text = ""

        ddlEmpresa.SelectedIndex = 0
        ddlEmpresa.Enabled = False

        ddlContabilidad.SelectedIndex = 0
        ddlEjercicio.SelectedIndex = 0
        chkEstado.Checked = True

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            hdnEmpresa.Value = Session("Empresa")
            SetEmpresa()
            LlenarComboEmpresaInterno()

            llenarComboContabilidad(ddlEmpresa.SelectedValue)
            llenarComboEjercicio(ddlEmpresa.SelectedValue)
            txtCodigo.Enabled = False
        End If
    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        If ddlContabilidad.SelectedValue <> "" AndAlso ddlEjercicio.SelectedValue <> "" AndAlso ddlEmpresa.SelectedValue <> "" Then

            registrar()
            RaiseEvent cargarGrilla()
            RaiseEvent Registrado()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Seleccione una Opcion...');</script>")
        End If
    End Sub


    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTerminar.Click

        If ddlContabilidad.SelectedValue <> "" AndAlso ddlEjercicio.SelectedValue <> "" AndAlso ddlEmpresa.SelectedValue <> "" Then

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

    Protected Sub ddlEmpresas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmpresa.SelectedIndexChanged
        llenarComboContabilidad(ddlEmpresa.SelectedValue)
        llenarComboEjercicio(ddlEmpresa.SelectedValue)
    End Sub

    Protected Sub chkEstado_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEstado.CheckedChanged
        If chkEstado.Checked Then
            chkEstado.Text = "Activo"
        Else
            chkEstado.Text = "Desactivo"
        End If

    End Sub
End Class
