Imports LN_ALVINET_CONTA.CONFIG
Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.GENERAL
Imports EN_ALVINET_CONTA.GENERAL

Partial Class CONTROLES_REGISTRO_ctlPlanContable_Registro
    Inherits System.Web.UI.UserControl

    Private _entPlanContable As New EN_PlanContable

    Public Property PlanContable As EN_PlanContable
        Get
            Return _entPlanContable
        End Get
        Set(ByVal value As EN_PlanContable)

            _entPlanContable = value

            txtCodigo.Text = _entPlanContable.IdPlanContable
            txtCodigo.Enabled = False
            If _entPlanContable.IdEmpresa = ddlEmpresa.SelectedValue Then
                ddlEmpresa.SelectedValue = _entPlanContable.IdEmpresa
            End If


            ddlEmpresa.Enabled = False

            ddlContabilidad.SelectedValue = _entPlanContable.Contabilidad
            ddlContabilidad.Enabled = False

            txtFormato.Text = _entPlanContable.Formato
            txtNivel1.Text = _entPlanContable.LongitudNivel1
            txtNivel2.Text = _entPlanContable.LongitudNivel2
            txtNivel3.Text = _entPlanContable.LongitudNivel3
            txtNivel4.Text = _entPlanContable.LongitudNivel4
            txtNivel5.Text = _entPlanContable.LongitudNivel5
            txtNivel6.Text = _entPlanContable.LongitudNivel6
            txtNivel7.Text = _entPlanContable.LongitudNivel7
            txtNivel8.Text = _entPlanContable.LongitudNivel8
            If _entPlanContable.Estado = "ACT" Then
                chkEstado.Checked = True
            Else
                chkEstado.Checked = False
            End If

        End Set
    End Property

    Public Event cargarGrilla()
    Public Event Registrado()
    Public Event Cerrado()

    Public Sub Limpiar()

        txtCodigo.Text = ""

        ddlContabilidad.Enabled = False
        ddlContabilidad.SelectedIndex = 0

        ddlEmpresa.Enabled = False
        ddlEmpresa.SelectedIndex = 0

        txtFormato.Text = ""
        txtNivel1.Text = ""
        txtNivel2.Text = ""
        txtNivel3.Text = ""
        txtNivel4.Text = ""
        txtNivel5.Text = ""
        txtNivel6.Text = ""
        txtNivel7.Text = ""
        txtNivel8.Text = ""
        chkEstado.Checked = True
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

      

    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario")

            txtCodigo.Enabled = False
            SetEmpresa()
            LlenarComboEmpresaInterno()
            llenarComboContabilidad(ddlEmpresa.SelectedValue)
        End If

    End Sub

    Public Sub registrar()
        Dim objLNPlanContable As New LN_PlanContable
        Dim objENPlanContable As New EN_PlanContable

        objENPlanContable.IdPlanContable = txtCodigo.Text
        objENPlanContable.IdEmpresa = ddlEmpresa.SelectedValue

        objENPlanContable.IdContabilidad = ddlContabilidad.SelectedValue

        objENPlanContable.Formato = txtFormato.Text
        objENPlanContable.LongitudNivel1 = txtNivel1.Text
        objENPlanContable.LongitudNivel2 = txtNivel2.Text
        objENPlanContable.LongitudNivel3 = txtNivel3.Text
        objENPlanContable.LongitudNivel4 = txtNivel4.Text
        objENPlanContable.LongitudNivel5 = txtNivel5.Text
        objENPlanContable.LongitudNivel6 = txtNivel6.Text
        objENPlanContable.LongitudNivel7 = txtNivel7.Text
        objENPlanContable.LongitudNivel8 = txtNivel8.Text
        If chkEstado.Checked = True Then
            objENPlanContable.Estado = "ACT"
        Else
            objENPlanContable.Estado = "ANU"
        End If

        objLNPlanContable.entPlanContable = objENPlanContable
        If objLNPlanContable.Registrar = True Then
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Registro completo');</script>")
            Limpiar()
            RaiseEvent cargarGrilla()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Sucedio un error. Revisar los datos.');</script>")
        End If
    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        If ddlContabilidad.SelectedValue <> "" AndAlso ddlEmpresa.SelectedValue <> "" Then
            registrar()
            Limpiar()
            RaiseEvent cargarGrilla()
            RaiseEvent Registrado()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Seleccione una Opcion...');</script>")
        End If
    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTerminar.Click
        If ddlContabilidad.SelectedValue <> "" AndAlso ddlEmpresa.SelectedValue <> "" Then
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

    Protected Sub ddlEmpresa_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmpresa.SelectedIndexChanged
        llenarComboContabilidad(ddlEmpresa.SelectedValue)
    End Sub

    Protected Sub chkEstado_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEstado.CheckedChanged
        If chkEstado.Checked Then
            chkEstado.Text = "Activo"
        Else
            chkEstado.Text = "Desactivo"
        End If

    End Sub
End Class
