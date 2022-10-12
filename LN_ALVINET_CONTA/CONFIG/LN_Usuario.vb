Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.CONFIG

Namespace CONFIG
    Public Class LN_Usuario
#Region "Variables"
        Private _objADUsuario As New AD_Usuario
        Private _objError As New Exception
        Private _lstUsuarios As List(Of EN_Usuario)
        Private _entUsuario As New EN_Usuario
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstUsuarios As List(Of EN_Usuario)
            Get
                Return _lstUsuarios
            End Get
        End Property

        Public Property entUsuario As EN_Usuario
            Get
                Return _entUsuario
            End Get
            Set(ByVal Value As EN_Usuario)
                _entUsuario = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"
        Public Function Listar() As Boolean
            If _objADUsuario.Listar() = True Then
                _lstUsuarios = _objADUsuario.lstUsuarios
                Return (_lstUsuarios.Count > 0)
            Else
                Return False
            End If
        End Function
#End Region
    End Class
End Namespace