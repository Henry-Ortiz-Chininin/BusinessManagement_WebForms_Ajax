Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.CONFIG

Namespace CONFIG

    Public Class LN_Ejercicio
#Region "Variables"
        Private _objADEjercicio As New AD_Ejercicio
        Private _objError As New Exception
        Private _lstEjercicios As List(Of EN_Ejercicio)
        Private _entEjercicio As New EN_Ejercicio
#End Region
#Region "Propiedades"

        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstEjercicios() As List(Of EN_Ejercicio)
            Get
                Return _lstEjercicios
            End Get
        End Property

        Public Property entEjercicio() As EN_Ejercicio
            Get
                Return _entEjercicio
            End Get
            Set(ByVal value As EN_Ejercicio)
                _entEjercicio = value
            End Set
        End Property
#End Region
#Region "Metodos y funciones"
        Sub New()
            _entEjercicio = New EN_Ejercicio
        End Sub


        Public Function Registrar() As Boolean

            If entEjercicio.Agno <> "" AndAlso _
                entEjercicio.Ejercicio <> "" AndAlso _
                Not IsDBNull(entEjercicio.FechaInicio) AndAlso _
                Not IsDBNull(entEjercicio.FechaFinal) AndAlso _
                entEjercicio.IdEmpresa <> "" Then

                _objADEjercicio.entEjercicio = _entEjercicio

                Return _objADEjercicio.Registrar
            Else
                Return False
            End If
        End Function

        Public Function Eliminar() As Boolean
            If entEjercicio.IdEjercicio <> "" AndAlso _
                entEjercicio.IdEmpresa <> "" Then
                _objADEjercicio.entEjercicio = _entEjercicio
                Return _objADEjercicio.Eliminar
            Else
                Return False
            End If
        End Function
        Public Function Buscar() As Boolean
            If _entEjercicio.IdEmpresa <> "" Then
                _objADEjercicio.entEjercicio = _entEjercicio
                _objADEjercicio.Buscar()
                _lstEjercicios = _objADEjercicio.lstEjercicios
                Return (_lstEjercicios.Count > 0)
            Else
                Return False
            End If
        End Function

        Public Function Listar() As Boolean

            If entEjercicio.IdEmpresa <> "" Then
                _objADEjercicio.entEjercicio = entEjercicio
                _objADEjercicio.Listar()
                _lstEjercicios = _objADEjercicio.lstEjercicios
                Return (_lstEjercicios.Count > 0)
            Else
                Return False
            End If
        End Function
#End Region
    End Class
End Namespace