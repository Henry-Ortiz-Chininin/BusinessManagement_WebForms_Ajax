Imports AD_ALVINET_CONTA.REPORTE
Imports EN_ALVINET_CONTA.OPERACION
Imports EN_ALVINET_CONTA.GENERAL

Namespace REPORTE
    Public Class LN_Reportes
#Region "Variables"
        Private _objADReporte As New AD_Reportes
        Private _objError As New Exception
        Private _lstVouchers As List(Of EN_ALVINET_CONTA.REPORTE.EN_Voucher)
        Private _entVoucher As New EN_ALVINET_CONTA.REPORTE.EN_Voucher
        Dim _enDocumentoCompras As EN_ALVINET_CONTA.REPORTE.EN_CompraDocumento
        Dim _lstDocumentoCompras As List(Of EN_ALVINET_CONTA.REPORTE.EN_CompraDocumento)
        Private _lstComprobantes As List(Of EN_ALVINET_CONTA.REPORTE.EN_Comprobante)
        Private _entComprobante As New EN_ALVINET_CONTA.REPORTE.EN_Comprobante
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstVouchers() As List(Of EN_ALVINET_CONTA.REPORTE.EN_Voucher)
            Get
                Return _lstVouchers
            End Get
        End Property

        Public Property entVoucher() As EN_ALVINET_CONTA.REPORTE.EN_Voucher
            Get
                Return _entVoucher
            End Get
            Set(ByVal Value As EN_ALVINET_CONTA.REPORTE.EN_Voucher)
                _entVoucher = Value
            End Set
        End Property
        Public Property enDocumentoCompras() As EN_ALVINET_CONTA.REPORTE.EN_CompraDocumento
            Get
                Return _enDocumentoCompras
            End Get
            Set(ByVal value As EN_ALVINET_CONTA.REPORTE.EN_CompraDocumento)
                _enDocumentoCompras = value
            End Set
        End Property
        Public ReadOnly Property lstDocumentoCompras() As List(Of EN_ALVINET_CONTA.REPORTE.EN_CompraDocumento)
            Get
                Return _lstDocumentoCompras
            End Get

        End Property
        Public ReadOnly Property lstComprobantes As List(Of EN_ALVINET_CONTA.REPORTE.EN_Comprobante)
            Get
                Return _lstComprobantes
            End Get
        End Property

        Public Property entComprobante As EN_ALVINET_CONTA.REPORTE.EN_Comprobante
            Get
                Return _entComprobante
            End Get
            Set(ByVal Value As EN_ALVINET_CONTA.REPORTE.EN_Comprobante)
                _entComprobante = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"


        Public Function LibroDiario(ByVal ruc As String, ByVal razon As String) As Boolean
            Try
                _objADReporte.entVoucher = entVoucher
                If _objADReporte.LibroDiario(ruc, razon) Then
                    _lstVouchers = _objADReporte.lstVouchers
                    Return (_lstVouchers.Count > 0)
                Else
                    Return False
                End If
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function LibroMayor(ByVal ruc As String, ByVal razon As String) As Boolean
            Try
                _objADReporte.entVoucher = entVoucher
                If _objADReporte.LibroMayor(ruc, razon) Then
                    _lstVouchers = _objADReporte.lstVouchers
                    Return (_lstVouchers.Count > 0)
                Else
                    Return False
                End If
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function RegistroVentas(ByVal ruc As String, ByVal razon As String) As Boolean
            Try
                _objADReporte.entVoucher = entVoucher
                If _objADReporte.RegistroVentas(ruc, razon) Then
                    _lstVouchers = _objADReporte.lstVouchers
                    Return (_lstVouchers.Count > 0)
                Else
                    Return False
                End If
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function RegistroVentasIngreso() As Boolean
            Try
                If entComprobante.IdEmpresa <> "" Then
                    _objADReporte.entComprobante = entComprobante
                    _objADReporte.RegistroVentasIngreso()
                    _lstComprobantes = _objADReporte.lstComprobantes
                    Return (_lstComprobantes.Count > 0)
                Else
                    Return False
                End If
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function ReporteRegistroCompras() As Boolean
            If enDocumentoCompras.IdEmpresa <> "" Then
                _objADReporte.enDocumentoCompras = enDocumentoCompras
                _objADReporte.RegistroCompras()
                _lstDocumentoCompras = _objADReporte.lstDocumentoCompras
                Return (_lstDocumentoCompras.Count > 0)
            Else
                Return False
            End If
        End Function


        Public Function LibroDiario51(ByVal pstrIdEmpresa As String, _
                                       ByVal pstrIdEjercicio As String, _
                                       ByVal pstrIdContabilidad As String, _
                                       ByVal pint_Mes As Int16) As DataTable

            Dim _objADLibroDiario As New AD_ALVINET_CONTA.REPORTE.AD_Reportes

            Return _objADLibroDiario.LibroDiario51(pstrIdEmpresa, pstrIdEjercicio, pstrIdContabilidad, pint_Mes)

        End Function

#End Region
    End Class
End Namespace