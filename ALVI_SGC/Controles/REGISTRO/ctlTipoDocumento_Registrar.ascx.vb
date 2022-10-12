Imports EN_ALVINET_CONTA.GENERAL
Imports LN_ALVINET_CONTA.GENERAL

Partial Class CONTROLES_REGISTRO_ctlTipoDocumento
    Inherits System.Web.UI.UserControl

    Private _entTipoDocumento As New EN_TipoDocumento

    Public Property entTipoDocumento As EN_TipoDocumento
        Get
            Return _entTipoDocumento
        End Get
        Set(ByVal value As EN_TipoDocumento)

            _entTipoDocumento = value

            txtIdTipoDocumento.Text = _entTipoDocumento.IdTipoDocumento
            txtIdTipoDocumento.Enabled = True
            If _entTipoDocumento.IdEmpresa = ddlEmpresa.SelectedValue Then
                ddlEmpresa.SelectedValue = _entTipoDocumento.IdEmpresa
            End If


            ddlEmpresa.Enabled = False

            txtDescripcion.Text = _entTipoDocumento.TipoDocumento
            ddlClase.SelectedValue = _entTipoDocumento.Clase

            If _entTipoDocumento.Estado = "ACT" Then
                chkEstado.Checked = True
            ElseIf _entTipoDocumento.Estado = "ANU" Then
                chkEstado.Checked = False
            End If

            txtSunat.Text = _entTipoDocumento.IdSunat

        End Set
    End Property


    Protected Sub Registrar()
        Dim objLNTipoDocumento As New LN_TipoDocumento
        Dim objENTipoDocumento As New EN_TipoDocumento

        objENTipoDocumento.IdTipoDocumento = txtIdTipoDocumento.Text
        objENTipoDocumento.IdEmpresa = ddlEmpresa.SelectedValue
        objENTipoDocumento.TipoDocumento = txtDescripcion.Text
        objENTipoDocumento.Clase = ddlClase.SelectedValue
        objENTipoDocumento.IdSunat = txtSunat.Text
        If chkEstado.Checked = True Then

            objENTipoDocumento.Estado = "ACT"
        Else

            objENTipoDocumento.Estado = "INA"
        End If

        objLNTipoDocumento.entTipoDocumento = objENTipoDocumento
        If objLNTipoDocumento.Registrar = True Then
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Registro completo');</script>")
            limpiar()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Sucedio un error. Revisar los datos.');</script>")
        End If
    End Sub

    Public Sub limpiar()

        txtIdTipoDocumento.Text = ""
        ddlEmpresa.Enabled = False
        ddlEmpresa.SelectedIndex = 0
        txtDescripcion.Text = ""
        'ddlClase.SelectedIndex = 0
        chkEstado.Checked = False
        txtSunat.Text = ""
        chkEstado.Checked = True
    End Sub

    Public Event cargarGrilla()
    Public Event Registrado()
    Public Event Cerrado()

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        If ddlEmpresa.SelectedValue <> "" Then
            Registrar()
            RaiseEvent cargarGrilla()
            RaiseEvent Registrado()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert                ('Seleccione una Opcion');</script>")
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

    Public Sub llenarComboClase()

        ddlClase.Items.Clear()
        ddlClase.Items.Add(New ListItem("Seleccione", ""))
        ddlClase.Items.Add(New ListItem("Ingreso", "I"))
        ddlClase.Items.Add(New ListItem("Salida", "S"))

        ddlClase.SelectedIndex = 0

    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTerminar.Click
        If ddlEmpresa.SelectedValue <> "" Then
            Registrar()
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
            SetEmpresa()
            LlenarComboEmpresaInterno()
            llenarComboClase()
        End If
    End Sub

    Protected Sub chkEstado_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEstado.CheckedChanged
        If chkEstado.Checked Then
            chkEstado.Text = "Activo"
        Else
            chkEstado.Text = "Desactivo"
        End If

    End Sub
End Class
