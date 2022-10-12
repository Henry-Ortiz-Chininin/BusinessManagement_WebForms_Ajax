Imports EN_ALVINET_CONTA.GENERAL
Imports AD_ALVINET_CONTA.GENERAL
Imports AD_ALVINET_CONTA.REPORTE

Namespace GENERAL
    Public Class LN_Comprobante
#Region "Variables"
        Private _objADComprobante As New AD_Comprobante
        Private _objADReporte As New AD_Reportes
        Private _objError As New Exception
        Private _lstComprobantes As List(Of EN_Comprobante)
        Private _entComprobante As New EN_Comprobante
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstComprobantes As List(Of EN_Comprobante)
            Get
                Return _lstComprobantes
            End Get
        End Property

        Public Property entComprobante As EN_Comprobante
            Get
                Return _entComprobante
            End Get
            Set(ByVal Value As EN_Comprobante)
                _entComprobante = Value
            End Set
        End Property

#End Region
#Region " Metodos y Funciones"

        Public Function BuscarDocumento() As Boolean

            'If entComprobante.IdTipoDocumento <> "" AndAlso _
            '   entComprobante.IdComprobante <> "" Then

            _objADComprobante.entComprobante = entComprobante

            If _objADComprobante.BuscarDoc() = True Then
                _lstComprobantes = _objADComprobante.lstComprobantes
                Return (_lstComprobantes.Count > 0)
            Else
                Return False
            End If
            'Else
            'Return False
            'End If
        End Function

        Public Function ReporteRegistroVentasIngreso() As Boolean
            If entComprobante.IdEmpresa <> "" Then
                _objADReporte.entComprobante = entComprobante
                _objADReporte.RegistroVentasIngreso()
                Dim lstComprobantes As List(Of EN_ALVINET_CONTA.REPORTE.EN_Comprobante) = _objADReporte.lstComprobantes
                Return (lstComprobantes.Count > 0)
            Else
                Return False
            End If
        End Function
#End Region
    End Class
End Namespace