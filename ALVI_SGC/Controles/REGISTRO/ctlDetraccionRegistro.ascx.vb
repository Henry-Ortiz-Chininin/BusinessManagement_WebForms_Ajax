
Partial Class Controles_REGISTRO_ctlDetraccionRegistro
    Inherits System.Web.UI.UserControl

    Public Event Cerrado()

    Public Property Codigo As String
        Get
            Return txtCodigo.Text
        End Get
        Set(ByVal value As String)
            txtCodigo.Text = value
        End Set
    End Property
    Public Property CuentDetraccion As String
        Get
            Return txtCuentaDetraccion.Text
        End Get
        Set(ByVal value As String)
            txtCuentaDetraccion.Text = value
        End Set
    End Property

    Public Property FechaDetraccion As String
        Get
            Return txtFechaOperacion.Text
        End Get
        Set(ByVal value As String)
            txtFechaOperacion.Text = value
        End Set
    End Property

    Public Property FechaDocumento As String
        Get
            Return txtFecha.Text
        End Get
        Set(ByVal value As String)
            txtFecha.Text = value
        End Set
    End Property

    Public Property ImporteDocumento As Double
        Get
            Return txtImporte.Text
        End Get
        Set(ByVal value As Double)
            txtImporte.Text = value
        End Set
    End Property

    Public Property DocumentoCompra As String
        Get
            Return txtDocumento.Text
        End Get
        Set(ByVal value As String)
            txtDocumento.Text = value
        End Set
    End Property


    Public Sub Cargar()
        Dim objDocumento As New ALVI_LOGIC.Proceso.Logistica.Detraccion

        objDocumento.IdDocumentoCompra = txtCodigo.Text
        objDocumento.Obtener()

        txtCuentaDetraccion.Text = objDocumento.CuentaDetraccion
        txtDocumento.Text = objDocumento.numerodocumento
        txtFecha.Text = objDocumento.FechaEmision
        txtFechaOperacion.Text = objDocumento.FechaDetraccion
        txtImporte.Text = objDocumento.ImporteDetraccion
        txtTotalDocumento.Text = objDocumento.ImporteDocumento

    End Sub

    Private Sub Registrar()
        Dim objDetraccion As New ALVI_LOGIC.Proceso.Logistica.Detraccion
        objDetraccion.IdDocumentoCompra = txtCodigo.Text
        objDetraccion.FechaDetraccion = txtFechaOperacion.Text
        objDetraccion.CuentaDetraccion = txtCuentaDetraccion.Text
        objDetraccion.ImporteDetraccion = txtImporte.Text
        objDetraccion.Registrar()

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        If txtCodigo.Text <> "" AndAlso txtCuentaDetraccion.Text <> "" AndAlso _
            txtFechaOperacion.Text <> "" AndAlso txtImporte.Text <> "" Then
            Registrar()
        End If
    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTerminar.Click
        If txtCodigo.Text <> "" AndAlso txtCuentaDetraccion.Text <> "" AndAlso _
            txtFechaOperacion.Text <> "" AndAlso txtImporte.Text <> "" Then
            Registrar()
            RaiseEvent Cerrado()
        End If
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        RaiseEvent Cerrado()
    End Sub
End Class
