Imports EN_ALVINET_CONTA.GENERAL
Imports AD_ALVINET_CONTA.GENERAL

Namespace GENERAL
    Public Class LN_MedioPago
#Region "Variables"
        Private _objADMedioPago As New AD_MedioPago
        Private _objError As New Exception
        Private _lstMedioPagos As List(Of EN_MedioPago)
        Private _entMedioPago As New EN_MedioPago
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstMedioPagos As List(Of EN_MedioPago)
            Get
                Return _lstMedioPagos
            End Get
        End Property

        Public Property entMedioPago As EN_MedioPago
            Get
                Return _entMedioPago
            End Get
            Set(ByVal Value As EN_MedioPago)
                _entMedioPago = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"
        Public Function Registrar() As Boolean

            If entMedioPago.IdEmpresa <> "" AndAlso _
               entMedioPago.MedioPago <> "" Then

                _objADMedioPago.entMedioPago = _entMedioPago
                Return _objADMedioPago.Registrar()

            Else
                Return False
            End If
        End Function
        Public Function Listar() As Boolean

            If _objADMedioPago.Listar() = True Then
                _lstMedioPagos = _objADMedioPago.lstMedioPagos
                Return (_lstMedioPagos.Count > 0)

            Else
                Return False
            End If
        End Function
        Public Function Eliminar() As Boolean

            If entMedioPago.IdEmpresa <> "" AndAlso _
                entMedioPago.IdMedioPago <> "" Then

                _objADMedioPago.entMedioPago = _entMedioPago
                Return _objADMedioPago.Eliminar()

            Else
                Return False
            End If
        End Function
#End Region
    End Class
End Namespace