Imports EN_ALVINET_CONTA.GENERAL
Imports AD_ALVINET_CONTA.GENERAL

Namespace GENERAL
    Public Class LN_Cliente
#Region "Variables"
        Private _objADCliente As New AD_Cliente
        Private _objError As New Exception
        Private _lstCliente As List(Of EN_Cliente)
        Private _entCliente As New EN_Cliente
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstCliente As List(Of EN_Cliente)
            Get
                Return _lstCliente
            End Get
        End Property

        Public Property entCliente As EN_Cliente
            Get
                Return _entCliente
            End Get
            Set(ByVal Value As EN_Cliente)
                _entCliente = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"
        Public Function Registrar() As Boolean
            If entCliente.IdEmpresa <> "" AndAlso _
                entCliente.Descripcion <> "" AndAlso entCliente.Estado <> "" Then
                _objADCliente.entCliente = entCliente
                Return _objADCliente.Registrar()
            Else
                Return False
            End If
        End Function
        Public Function Eliminar() As Boolean

            If entCliente.IdEmpresa <> "" AndAlso entCliente.IdCliente Then
                _objADCliente.entCliente = entCliente
                Return _objADCliente.Eliminar
            Else
                Return False
            End If
        End Function
        Public Function Listar() As Boolean
            _objADCliente.entCliente = _entCliente
            If _objADCliente.Listar = True Then
                _lstCliente = _objADCliente.lstCliente
                Return (_lstCliente.Count > 0)
            Else
                Return False
            End If
        End Function
        Public Function Obtener() As Boolean

            ' If _entCliente.IdCliente <> "" Or _entCliente.Descripcion <> "" Then

            _objADCliente.entCliente = _entCliente

            _objADCliente.Obtener()
            _lstCliente = _objADCliente.lstCliente

            Return (_lstCliente.Count > 0)
            '  Else
            ' Return False
            ' End If

        End Function
#End Region
    End Class
End Namespace