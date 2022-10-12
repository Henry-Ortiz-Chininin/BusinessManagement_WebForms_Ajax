Imports EN_ALVINET_CONTA
Imports LN_ALVINET_CONTA
Partial Class CONTROLES_REGISTRO_ctlLibro_Registrar
    Inherits System.Web.UI.UserControl
    Private _entLibro As New EN_Libro

    Public Property Libro As EN_Libro
        Get
            Return _entLibro
        End Get
        Set(ByVal value As EN_Libro)

            _entLibro = value

            txtIdSunat.Text = _entLibro.IdSunat
            txtIdSunat.Enabled = False

            txtIdLibro.Text = _entLibro.IdLibro
            txtIdLibro.Enabled = False

            txtDescripcion.Text = _entLibro.Descripcion

            If _entLibro.Estado = "ACT" Then
                chkEstado.Checked = True
            Else
                chkEstado.Checked = False
            End If

        End Set
    End Property


    Public Event cargarGrilla()
    Public Event Registrado()
    Public Event Cerrado()

    Public Sub limpiar()
        txtIdSunat.Text = ""
        txtIdSunat.Enabled = True
        txtIdLibro.Text = ""
        txtIdLibro.Enabled = True

        txtDescripcion.Text = ""
        chkEstado.Checked = True
    End Sub

    Public Sub registrar()

        Dim objLNLibro As New LN_Libro
        Dim objENLibro As New EN_Libro

        objENLibro.IdSunat = txtIdSunat.Text
        objENLibro.IdLibro = txtIdLibro.Text
        objENLibro.Descripcion = txtDescripcion.Text

        If chkEstado.Checked = True Then
            objENLibro.Estado = "ACT"
        Else
            objENLibro.Estado = "INA"
        End If


        objLNLibro.entLibro = objENLibro

        If objLNLibro.Registrar = True Then
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Registro completo');</script>")
            limpiar()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Sucedio un error. Revisar los datos.');</script>")
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            chkEstado.Checked = True
        End If
    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        registrar()
        RaiseEvent cargarGrilla()
        RaiseEvent Registrado()
    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTerminar.Click
        registrar()
        RaiseEvent cargarGrilla()
        RaiseEvent Cerrado()
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        RaiseEvent Cerrado()
    End Sub

    
    Protected Sub chkEstado_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEstado.CheckedChanged
        If chkEstado.Checked Then
            chkEstado.Text = "Activo"
        Else
            chkEstado.Text = "Desactivo"
        End If

    End Sub
End Class
