Imports EN_ALVINET_CONTA.GENERAL
Imports AD_ALVINET_CONTA.GENERAL

Namespace GENERAL
    Public Class LN_Moneda
#Region "Variables"
        Private _objADMoneda As New AD_Moneda
        Private _objError As New Exception
        Private _lstMonedas As List(Of EN_Moneda)
        Private _entMoneda As New EN_Moneda
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstMonedas As List(Of EN_Moneda)
            Get
                Return _lstMonedas
            End Get
        End Property

        Public Property entMoneda As EN_Moneda
            Get
                Return _entMoneda
            End Get
            Set(ByVal Value As EN_Moneda)
                _entMoneda = Value
            End Set
        End Property
#End Region
#Region "Metodo y Funciones"
        Public Function Buscar() As Boolean

            If _entMoneda.IdEmpresa <> "" Then

                _objADMoneda.entMoneda = _entMoneda

                _objADMoneda.Buscar()
                _lstMonedas = _objADMoneda.lstMonedas
                Return (_lstMonedas.Count > 0)
            Else
                Return False
            End If
        End Function
        Public Function Registrar() As Boolean
            If entMoneda.IdEmpresa <> "" AndAlso _
            entMoneda.Moneda <> "" AndAlso _
            entMoneda.Simbolo <> "" Then
                _objADMoneda.entMoneda = _entMoneda
                Return _objADMoneda.Registrar()
            Else
                Return False
            End If
        End Function
        Public Function Listar() As Boolean

            If entMoneda.IdEmpresa <> "" Then
                _objADMoneda.entMoneda = entMoneda
                _objADMoneda.Listar()
                _lstMonedas = _objADMoneda.lstMonedas
                Return (_lstMonedas.Count > 0)
            Else
                Return False
            End If
        End Function
        Public Function Eliminar() As Boolean
            If entMoneda.IdEmpresa <> "" AndAlso _
                entMoneda.IdMoneda <> "" Then
                _objADMoneda.entMoneda = _entMoneda
                Return _objADMoneda.Eliminar()
            Else
                Return False
            End If
        End Function
#End Region
    End Class
End Namespace