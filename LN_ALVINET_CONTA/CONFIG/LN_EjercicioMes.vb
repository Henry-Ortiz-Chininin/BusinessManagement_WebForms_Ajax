Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.CONFIG

Namespace CONFIG
    Public Class LN_EjercicioMes
#Region "Variables"
        Private _objADEjercicioMes As New AD_EjercicioMes
        Private _objError As New Exception
        Private _lstEjerciciosMes As List(Of EN_EjercicioMes)
        Private _entEjercicioMes As New EN_EjercicioMes
#End Region
#Region "Propiedades"

        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstEjerciciosMes() As List(Of EN_EjercicioMes)
            Get
                Return _lstEjerciciosMes
            End Get
        End Property

        Public Property entEjercicioMes() As EN_EjercicioMes
            Get
                Return _entEjercicioMes
            End Get
            Set(ByVal value As EN_EjercicioMes)
                _entEjercicioMes = value
            End Set
        End Property
#End Region
#Region "Metodos y funciones"
        Sub New()
            _entEjercicioMes = New EN_EjercicioMes
        End Sub


        Public Function Registrar() As Boolean

            If entEjercicioMes.IdEmpresa <> "" AndAlso _
                entEjercicioMes.IdEjercicioEmpresa <> "" AndAlso _
                Not IsDBNull(entEjercicioMes.FechaInicio) AndAlso _
                Not IsDBNull(entEjercicioMes.FechaFinal) AndAlso _
                entEjercicioMes.EjercicioMes <> "" AndAlso _
                entEjercicioMes.Estado <> "" Then

                _objADEjercicioMes.entEjercicioMes = _entEjercicioMes
                Return _objADEjercicioMes.Registrar
            Else
                Return False
            End If

        End Function

        Public Function Eliminar() As Boolean
            If entEjercicioMes.IdEjercicioMes <> "" AndAlso _
                entEjercicioMes.IdEjercicioEmpresa <> "" AndAlso _
                entEjercicioMes.IdEmpresa <> "" Then

                _objADEjercicioMes.entEjercicioMes = _entEjercicioMes
                Return _objADEjercicioMes.Eliminar
            Else
                Return False
            End If
        End Function

        Public Function Listar() As Boolean

            If entEjercicioMes.IdEmpresa <> "" Then
                _objADEjercicioMes.entEjercicioMes = entEjercicioMes
                _objADEjercicioMes.Listar()
                _lstEjerciciosMes = _objADEjercicioMes.lstEjerciciosMes
                Return (_lstEjerciciosMes.Count > 0)
            Else
                Return False
            End If
        End Function
#End Region

    End Class
End Namespace