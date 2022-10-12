Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.CONFIG

Namespace CONFIG
    Public Class LN_EjercicioEmpresa
#Region "Variables"
        Private _lstEjerciciosEmpresa As List(Of EN_EjercicioEmpresa)
        Private _objADEjercicioEmpresa As New AD_EjercicioEmpresa
        Private _objError As Exception
        Private _entEjercicioEmpresa As New EN_EjercicioEmpresa
#End Region
#Region "Propiedades"

        Public ReadOnly Property lstEjerciciosEmpresa() As List(Of EN_EjercicioEmpresa)
            Get
                Return _lstEjerciciosEmpresa
            End Get
        End Property

        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property

        Public Property entEjercicioEmpresa() As EN_EjercicioEmpresa
            Get
                Return _entEjercicioEmpresa
            End Get
            Set(ByVal value As EN_EjercicioEmpresa)
                _entEjercicioEmpresa = value
            End Set
        End Property
#End Region
#Region "Metodos y funciones"
        Sub New()
            _entEjercicioEmpresa = New EN_EjercicioEmpresa
        End Sub


        Public Function Registrar() As Boolean

            If entEjercicioEmpresa.IdEmpresa <> "" AndAlso _
                entEjercicioEmpresa.IdContabilidad <> "" AndAlso _
                entEjercicioEmpresa.IdEjercicio <> "" AndAlso _
                entEjercicioEmpresa.Estado <> "" Then

                _objADEjercicioEmpresa.entEjercicioEmpresa = _entEjercicioEmpresa

                Return _objADEjercicioEmpresa.Registrar
            Else
                Return False
            End If
        End Function

        Public Function Eliminar() As Boolean
            If entEjercicioEmpresa.IdEjercicioEmpresa <> "" AndAlso _
                entEjercicioEmpresa.IdEmpresa <> "" Then

                _objADEjercicioEmpresa.entEjercicioEmpresa = _entEjercicioEmpresa
                Return _objADEjercicioEmpresa.Eliminar
            Else
                Return False
            End If
        End Function
        Public Function Buscar() As Boolean
            If _entEjercicioEmpresa.IdEmpresa <> "" Then
                _objADEjercicioEmpresa.entEjercicioEmpresa = _entEjercicioEmpresa
                _objADEjercicioEmpresa.Buscar()
                _lstEjerciciosEmpresa = _objADEjercicioEmpresa.lstEjerciciosEmpresa
                Return (_lstEjerciciosEmpresa.Count > 0)
            Else
                Return False
            End If
        End Function


        Public Function Listar() As Boolean

            If entEjercicioEmpresa.IdEmpresa <> "" Then
                _objADEjercicioEmpresa.entEjercicioEmpresa = entEjercicioEmpresa
                _objADEjercicioEmpresa.Listar()
                _lstEjerciciosEmpresa = _objADEjercicioEmpresa.lstEjerciciosEmpresa
                Return (_lstEjerciciosEmpresa.Count > 0)
            Else
                Return False
            End If
        End Function
#End Region
    End Class
End Namespace