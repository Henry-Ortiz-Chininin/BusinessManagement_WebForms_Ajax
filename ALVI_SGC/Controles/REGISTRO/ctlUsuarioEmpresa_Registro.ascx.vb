Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.GENERAL
Imports EN_ALVINET_CONTA.GENERAL
Partial Class CONTROLES_REGISTRO_ctlUsuarioEmpresa_Registro
    Inherits System.Web.UI.UserControl


    Public Event cargar()
    Public Event Registrado()
    Public Event Cerrado()

    Public Sub registrar()

        Dim objLNUsuarioEmpresa As New LN_UsuarioEmpresa
        Dim objENUsuarioEmpresa As New EN_UsuarioEmpresa


        objENUsuarioEmpresa.IdEmpresa = ddlEmpresa.SelectedValue
        objENUsuarioEmpresa.IdUsuario = ddlUsario.SelectedValue

        objLNUsuarioEmpresa.entUsuarioEmpresa = objENUsuarioEmpresa
        If objLNUsuarioEmpresa.Registrar = True Then
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Registro completo');</script>")
            limpiar()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Sucedio un error. Revisar los datos.');</script>")
        End If

    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        If ddlEmpresa.SelectedValue <> "" AndAlso _
            ddlEmpresa.SelectedValue <> "" Then
            registrar()
            RaiseEvent cargar()
            RaiseEvent Registrado()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Seleccione una Empresa...');</script>")
        End If

    End Sub

    Public Sub limpiar()
        ddlEmpresa.Enabled = True
        ddlEmpresa.SelectedIndex = 0
        ddlUsario.Enabled = True
        ddlUsario.SelectedIndex = 0

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

    Public Sub llenarComboUsuario()

        Dim objLNUsuario As New LN_Usuario
        ddlUsario.Items.Clear()

        objLNUsuario.Listar()
        ddlUsario.DataTextField = "Nombre"
        ddlUsario.DataValueField = "IdUsuario"
        ddlUsario.DataSource = objLNUsuario.lstUsuarios
        ddlUsario.DataBind()

        ddlUsario.Items.Insert(0, New ListItem("Seleccione>>>", ""))
        ddlUsario.SelectedIndex = 0

    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTerminar.Click
        If ddlEmpresa.SelectedValue <> "" AndAlso _
            ddlUsario.SelectedValue <> "" Then

            registrar()
            RaiseEvent cargar()
            RaiseEvent Cerrado()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Seleccione una Opcion...');</script>")
        End If
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        RaiseEvent Cerrado()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            llenarComboEmpresa()
            llenarComboUsuario()
        End If
    End Sub
End Class
