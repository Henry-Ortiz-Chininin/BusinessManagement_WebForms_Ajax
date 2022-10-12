Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.CONFIG

Namespace CONFIG
    Public Class LN_Operacion
#Region "Variables"
        Private _objADOperacion As New AD_Operacion
        Private _objError As New Exception
        Private _lstOperacion As List(Of EN_Operacion)
        Private _entOperacion As New EN_Operacion
#End Region
#Region "Propiedades"

        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstOperacion() As List(Of EN_Operacion)
            Get
                Return _lstOperacion
            End Get
        End Property

        Public Property entOperacion() As EN_Operacion
            Get
                Return _entOperacion
            End Get
            Set(ByVal Value As EN_Operacion)
                _entOperacion = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones "

        Public Function Registrar() As Boolean
            If entOperacion.Idempresa <> "" AndAlso _
                entOperacion.IdContabilidad <> "" AndAlso _
                entOperacion.Descripcion <> "" Then

                _objADOperacion.entOperacion = _entOperacion
                Return _objADOperacion.Registrar()
            Else
                Return False
            End If
        End Function

        Public Function Listar() As Boolean

            If entOperacion.Idempresa <> "" Then
                _objADOperacion.entOperacion = _entOperacion
                _objADOperacion.Listar()
                _lstOperacion = _objADOperacion.lstOperacion
                Return (_lstOperacion.Count > 0)
            Else
                Return False
            End If
        End Function
        Public Function ListarSubOp() As Boolean

            If entOperacion.Idempresa <> "" Then
                _objADOperacion.entOperacion = _entOperacion
                _objADOperacion.ListarSubOp()
                _lstOperacion = _objADOperacion.lstOperacion
                Return (_lstOperacion.Count > 0)
            Else
                Return False
            End If
        End Function


        Public Function Eliminar() As Boolean

            If entOperacion.IdOperacion <> "" AndAlso _
                entOperacion.IdContabilidad <> "" AndAlso _
                entOperacion.IdEmpresa <> "" Then

                _objADOperacion.entOperacion = entOperacion
                Return _objADOperacion.Eliminar
            Else
                Return False
            End If
        End Function
#End Region
    End Class
End Namespace