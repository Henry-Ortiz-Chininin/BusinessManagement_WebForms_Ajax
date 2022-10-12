Imports LN_ALVINET_CONTA.CONFIG
Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.GENERAL
Imports EN_ALVINET_CONTA.GENERAL

Partial Class CONTROLES_REGISTRO_ctlOperacion
    Inherits System.Web.UI.UserControl

    Private _entOperacion As New EN_Operacion

    Public Property Operacion As EN_Operacion
        Get
            Return _entOperacion
        End Get
        Set(ByVal value As EN_Operacion)

            _entOperacion = value

            txtCodigo.Text = _entOperacion.IdOperacion
            txtCodigo.Enabled = False
            If _entOperacion.IdEmpresa = ddlEmpresa.SelectedValue Then
                ddlEmpresa.SelectedValue = _entOperacion.IdEmpresa

            End If


            ddlEmpresa.Enabled = False

            ddlIdContabilidad.SelectedValue = _entOperacion.IdContabilidad
            ddlIdContabilidad.Enabled = False

            txtDescripcion.Text = _entOperacion.Descripcion
            txtSunat.Text = _entOperacion.IdSunat
        End Set
    End Property

    Public Event cargarGrilla()
    Public Event Registrado()
    Public Event Cerrado()

    Public Sub Limpiar()

        txtCodigo.Text = ""

        ddlIdContabilidad.Enabled = False
        ddlIdContabilidad.SelectedIndex = 0

        ddlEmpresa.Enabled = False
        ddlEmpresa.SelectedIndex = 0

        txtDescripcion.Text = ""
        txtSunat.Text = ""
    End Sub

    Public Sub registrar()

        Dim objLNOperacion As New LN_Operacion
        Dim objENOperacion As New EN_Operacion

        objENOperacion.IdOperacion = txtCodigo.Text
        objENOperacion.Idempresa = ddlEmpresa.SelectedValue
        objENOperacion.IdContabilidad = ddlIdContabilidad.SelectedValue

        objENOperacion.Descripcion = txtDescripcion.Text
        objENOperacion.IdSunat = txtSunat.Text
        objLNOperacion.entOperacion = objENOperacion
        If objLNOperacion.Registrar = True Then
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Registro completo');</script>")
            Limpiar()
            RaiseEvent cargarGrilla()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Sucedio un error. Revisar los datos.');</script>")
        End If

    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        If ddlEmpresa.SelectedValue <> "" AndAlso ddlIdContabilidad.SelectedValue <> "" Then
            registrar()
            Limpiar()
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
        ddlEmpresa.Enabled = False
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
        ddlEmpresa.SelectedIndex = 0
    End Sub

    Public Sub llenarComboContabilidad(ByVal pstrEmpresa As String)

        Dim objLNContabilidad As New LN_Contabilidad
        Dim objENContabilidad As New EN_Contabilidad

        ddlIdContabilidad.Items.Clear()

        objENContabilidad.IdEmpresa = pstrEmpresa
        objLNContabilidad.entContabilidad = objENContabilidad

        objLNContabilidad.Buscar()
        ddlIdContabilidad.DataTextField = "Contabilidad"
        ddlIdContabilidad.DataValueField = "IdContabilidad"
        ddlIdContabilidad.DataSource = objLNContabilidad.lstContabilidades
        ddlIdContabilidad.DataBind()



    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            SetEmpresa()
            LlenarComboEmpresaInterno()

            llenarComboContabilidad(ddlEmpresa.SelectedValue)
            txtCodigo.Enabled = False
        End If
    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTerminar.Click
        If ddlEmpresa.SelectedValue <> "" AndAlso ddlIdContabilidad.SelectedValue <> "" Then
            registrar()
            Limpiar()
            RaiseEvent cargarGrilla()
            RaiseEvent Cerrado()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Seleccione una Opcion...');</script>")
        End If
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        RaiseEvent Cerrado()
    End Sub

    Protected Sub ddlIdEmpresa_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmpresa.SelectedIndexChanged
        llenarComboContabilidad(ddlEmpresa.SelectedValue)
    End Sub
End Class
