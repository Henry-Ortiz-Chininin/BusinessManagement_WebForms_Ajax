
Partial Class Controles_REGISTRO_ctlCajaBanco_Registro
    Inherits System.Web.UI.UserControl

    Public Event Cerrado()

    Public Property IdMovimiento As String
        Get
            Return hdnIdMovimiento.Value
        End Get
        Set(ByVal value As String)
            hdnIdMovimiento.Value = value
        End Set
    End Property
    Public Property IdOperacion As String
        Get
            Return lstOperaciones.SelectedValue
        End Get
        Set(ByVal value As String)
            lstOperaciones.SelectedValue = value
            BindSubOperacion(lstOperaciones.SelectedValue)
        End Set
    End Property
    Public Property IdSubOperacion As String
        Get
            Return lstSubOperacion.SelectedValue
        End Get
        Set(ByVal value As String)
            lstSubOperacion.SelectedValue = value
            lstSubOperacion_SelectedIndexChanged(Nothing, Nothing)
        End Set
    End Property
    Public Property IdCliente As String
        Get
            Return ctlCliente.IdCliente
        End Get
        Set(ByVal value As String)
            ctlCliente.IdCliente = value
            ctlCliente.BuscarId()
        End Set
    End Property
    Public Property IdProveedor As String
        Get
            Return ctlProveedor.IdProveedor
        End Get
        Set(ByVal value As String)
            ctlProveedor.IdProveedor = value
            ctlProveedor.BuscarId()
        End Set
    End Property
    Public Property Glosa As String
        Get
            Return txtGlosa.Text
        End Get
        Set(ByVal value As String)
            txtGlosa.Text = value
        End Set
    End Property
    Public Property Importe As Double
        Get
            Return txtImporte.Text
        End Get
        Set(ByVal value As Double)
            txtImporte.Text = value
        End Set
    End Property
    Public Property IdTipoDocumentoDebe As String
        Get
            Return ctlDocumentoDeudor.codTipoDocumento
        End Get
        Set(ByVal value As String)
            ctlDocumentoDeudor.codTipoDocumento = value
        End Set
    End Property
    Public Property NumeroDocumentoDebe As String
        Get
            Return ctlDocumentoDeudor.NumeroDocumento
        End Get
        Set(ByVal value As String)
            ctlDocumentoDeudor.NumeroDocumento = value
        End Set
    End Property
    Public Property IdTipoDocumentoHaber As String
        Get
            Return ctlDocumentoAcreedor.codTipoDocumento
        End Get
        Set(ByVal value As String)
            ctlDocumentoAcreedor.codTipoDocumento = value
        End Set
    End Property
    Public Property NumeroDocumentoHaber As String
        Get
            Return ctlDocumentoAcreedor.NumeroDocumento
        End Get
        Set(ByVal value As String)
            ctlDocumentoAcreedor.NumeroDocumento = value
        End Set
    End Property
    Public Property OperacionHabilitado As Boolean
        Get
            Return lstOperaciones.Enabled
        End Get
        Set(ByVal value As Boolean)
            lstOperaciones.Enabled = value
        End Set
    End Property
    Public Property DocumentoDeudorHabilitado As Boolean
        Get
            Return ctlDocumentoDeudor.Habilitar
        End Get
        Set(ByVal value As Boolean)
            ctlDocumentoDeudor.Habilitar = value
        End Set
    End Property
    Public Property DocumentoAcreedorHabilitado As Boolean
        Get
            Return ctlDocumentoAcreedor.Habilitar
        End Get
        Set(ByVal value As Boolean)
            ctlDocumentoAcreedor.Habilitar = value
        End Set
    End Property
    Private Sub BindOperacion()
        Dim objOperacion As New LN_ALVINET_CONTA.CONFIG.LN_Operacion
        objOperacion.entOperacion.IdContabilidad = Session("Contabilidad")
        objOperacion.entOperacion.Idempresa = Session("Empresa")
        objOperacion.entOperacion.IdSunat = "03"
        objOperacion.Listar()

        lstOperaciones.DataSource = objOperacion.lstOperacion
        lstOperaciones.DataTextField = "Descripcion"
        lstOperaciones.DataValueField = "IdOperacion"
        lstOperaciones.DataBind()
    End Sub
    Private Sub BindSubOperacion(ByVal strIdOperacion As String)
        Dim objSubOperacion As New LN_ALVINET_CONTA.LN_SubOperacion
        Dim entSubOperacion As New EN_ALVINET_CONTA.EN_SubOperacion

        entSubOperacion.IdContabilidad = Session("Contabilidad")
        entSubOperacion.Idempresa = Session("Empresa")
        entSubOperacion.IdOperacion = strIdOperacion

        objSubOperacion.entSubOperacion = entSubOperacion

        objSubOperacion.Listar()

        lstSubOperacion.DataSource = objSubOperacion.lstSubOperacion
        lstSubOperacion.DataTextField = "SubOperacion"
        lstSubOperacion.DataValueField = "IdSubOperacion"
        lstSubOperacion.DataBind()
    End Sub
    Public Sub Limpiar()
        BindOperacion()
        ctlCliente.Limpia()
        ctlProveedor.Limpia()
        ctlDocumentoAcreedor.Limpiar()
        ctlDocumentoDeudor.Limpiar()
        txtFecha.Text = Format(Now.Date, "dd/MM/yyyy")
        txtGlosa.Text = ""
        txtImporte.Text = 0.0
    End Sub


    'Protected Sub lstOperaciones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstOperaciones.SelectedIndexChanged
    '    BindSubOperacion(lstOperaciones.SelectedValue)
    'End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        Registrar()
    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTerminar.Click
        Registrar()
        RaiseEvent Cerrado()
    End Sub
    Private Sub Registrar()
        Dim entCajaBanco As New EN_ALVINET_CONTA.GENERAL.EN_CajaBanco
        Dim objCajaBanco As New LN_ALVINET_CONTA.GENERAL.LN_CajaBanco

        If ctlDocumentoAcreedor.codTipoDocumento = "FAC" Then
            entCajaBanco.IdTipoDocumento = ctlDocumentoAcreedor.codTipoDocumento
            entCajaBanco.NumeroDocumento = ctlDocumentoAcreedor.NumeroDocumento
            entCajaBanco.IdTipoComprobante = ctlDocumentoDeudor.codTipoDocumento
            entCajaBanco.Comprobante = ctlDocumentoDeudor.NumeroDocumento
        End If
        If ctlDocumentoDeudor.codTipoDocumento = "FAP" Then
            entCajaBanco.IdTipoDocumento = ctlDocumentoDeudor.codTipoDocumento
            entCajaBanco.NumeroDocumento = ctlDocumentoDeudor.NumeroDocumento
            entCajaBanco.IdTipoComprobante = ctlDocumentoAcreedor.codTipoDocumento
            entCajaBanco.Comprobante = ctlDocumentoAcreedor.NumeroDocumento
        End If
        entCajaBanco.IdMedioPago = ""
        entCajaBanco.IdMovimiento = hdnIdMovimiento.value
        entCajaBanco.Observacion = txtGlosa.Text
        entCajaBanco.Fecha = txtFecha.Text
        entCajaBanco.IdCliente = ctlCliente.IdCliente
        entCajaBanco.IdEntidadFinanciera = hdnIdEntidad.Value
        entCajaBanco.IdMoneda = hdnIdMoneda.Value
        entCajaBanco.IdOperacion = lstOperaciones.SelectedValue
        entCajaBanco.IdSubOperacion = lstSubOperacion.SelectedValue
        entCajaBanco.IdProveedor = ctlProveedor.IdProveedor
        entCajaBanco.Importe = txtImporte.Text
        entCajaBanco.Observacion = txtGlosa.Text
        objCajaBanco.entCajaBanco = entCajaBanco
        objCajaBanco.Registrar()

    End Sub

    Protected Sub lstSubOperacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSubOperacion.SelectedIndexChanged
        Dim objOperacion As New LN_ALVINET_CONTA.CONFIG.LN_OperacionCuenta
        Dim entOperacionCuenta As New EN_ALVINET_CONTA.CONFIG.EN_OperacionesCuenta
        objOperacion.entOperacionCuenta.IdEmpresa = Session("Empresa")
        objOperacion.entOperacionCuenta.IdSubOperacion = lstSubOperacion.SelectedValue
        objOperacion.Listar()
        lblEntidad.Text = "CAJA"
        lblCuenta.Text = "EFECTIVO"
        lblMoneda.Text = ""
        For Each entOperacionCuenta In objOperacion.lstOperacionCuenta
            If Left(entOperacionCuenta.IdCuentaContable, 2) = "10" Then
                lblEntidad.Text = entOperacionCuenta.EntidadFinanciera
                hdnIdEntidad.Value = entOperacionCuenta.IdEntidadFinanciera
                lblCuenta.Text = entOperacionCuenta.CuentaEntidad
                hdnIdCuentaEntidad.Value = entOperacionCuenta.IdCuentaEntidad
                lblMoneda.Text = entOperacionCuenta.Moneda
                hdnIdMoneda.Value = entOperacionCuenta.IdMoneda
            End If
        Next


    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Limpiar()
        RaiseEvent Cerrado()
    End Sub

    Protected Sub lstOperaciones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstOperaciones.SelectedIndexChanged
        BindSubOperacion(lstOperaciones.SelectedValue)
    End Sub
End Class
