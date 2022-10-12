Imports EN_ALVINET_CONTA.GENERAL
Imports LN_ALVINET_CONTA.GENERAL

Partial Class CONTROLES_REGISTRO_ctlCliente_Registro
    Inherits System.Web.UI.UserControl

    Public Event Cancelar()

    Public Property Ruc As TextBox
        Get
            Return txtCodigo
        End Get
        Set(ByVal value As TextBox)
            txtCodigo = value
        End Set
    End Property

    Public Property RazonSocial As TextBox
        Get
            Return txtDescripcion
        End Get
        Set(ByVal value As TextBox)
            txtDescripcion = value
        End Set
    End Property

    Public Property Direccion As TextBox
        Get
            Return txtDireccion
        End Get
        Set(ByVal value As TextBox)
            txtDireccion = value
        End Set
    End Property

    Public Property Telefono As TextBox
        Get
            Return TxtTelefono
        End Get
        Set(ByVal value As TextBox)
            TxtTelefono = value
        End Set
    End Property

    Public Property PersonaContacto As TextBox
        Get
            Return TxtPersonaContacto
        End Get
        Set(ByVal value As TextBox)
            TxtPersonaContacto = value
        End Set
    End Property

    Public Property TelefonoPersonaContacto As TextBox
        Get
            Return TxtTelefonoPersonaContacto
        End Get
        Set(ByVal value As TextBox)
            TxtTelefonoPersonaContacto = value
        End Set
    End Property

    Public Property Mercado As DropDownList
        Get
            Return ddlMercado
        End Get
        Set(ByVal value As DropDownList)
            ddlMercado = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LimpiarC()
        End If
    End Sub

    Public Sub LimpiarC()
        txtCodigo.Text = ""
        txtDescripcion.Text = ""
        txtDireccion.Text = ""
        TxtPersonaContacto.Text = ""
        TxtTelefono.Text = ""
        TxtTelefonoPersonaContacto.Text = ""
        lblMensaje.Text = ""
    End Sub

    Private Sub Registrar()
        If txtCodigo.Text <> "" AndAlso txtDescripcion.Text <> "" Then
            Dim objCliente As New ALVI_LOGIC.Maestros.Ventas.Cliente
            objCliente.IdCliente = txtCodigo.Text
            objCliente.Descripcion = txtDescripcion.Text
            objCliente.Direccion = txtDireccion.Text
            objCliente.Mercado = ddlMercado.SelectedValue
            objCliente.Telefono = TxtTelefono.Text
            objCliente.PersonaContacto = TxtPersonaContacto.Text
            objCliente.TelefonoPersonaContacto = TxtTelefonoPersonaContacto.Text
            objCliente.Usuario = Session("Usuario")
            objCliente.Estado = "ACT"
            If objCliente.Registrar = True Then
                LimpiarC()
                lblMensaje.Text = "Registro exitoso"
            End If
        End If
    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTerminar.Click
        Registrar()
        RaiseEvent Cancelar()
    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        Registrar()
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        LimpiarC()
        RaiseEvent Cancelar()
    End Sub
End Class
