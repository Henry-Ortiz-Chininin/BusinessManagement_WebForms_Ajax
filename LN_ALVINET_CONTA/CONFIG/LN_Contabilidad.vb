Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.CONFIG

Namespace CONFIG
    Public Class LN_Contabilidad

#Region "Variables"
        Private _objADContabilidad As New AD_Contabilidad
        Private _objError As New Exception
        Private _lstContabilidades As List(Of EN_Contabilidad)
        Private _entContabilidad As New EN_Contabilidad
#End Region
#Region "Propiedades"

        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstContabilidades() As List(Of EN_Contabilidad)
            Get
                Return _lstContabilidades
            End Get
        End Property

        Public Property entContabilidad() As EN_Contabilidad
            Get
                Return _entContabilidad
            End Get
            Set(ByVal value As EN_Contabilidad)
                _entContabilidad = value
            End Set
        End Property
#End Region
#Region "Metodos y funciones"
        Sub New()
            _entContabilidad = New EN_Contabilidad
        End Sub


        Public Function Registrar() As Boolean

            If entContabilidad.IdEmpresa <> "" AndAlso _
                entContabilidad.Contabilidad <> "" AndAlso _
                entContabilidad.Estado <> "" AndAlso _
                entContabilidad.IdMoneda <> "" Then

                _objADContabilidad.entContabilidad = _entContabilidad
                Return _objADContabilidad.Registrar

            Else
                Return False
            End If
        End Function

        Public Function Eliminar() As Boolean
            If entContabilidad.IdEmpresa <> "" AndAlso _
                entContabilidad.IdContabilidad <> "" Then

                _objADContabilidad.entContabilidad = _entContabilidad
                Return _objADContabilidad.Eliminar

            Else
                Return False
            End If
        End Function
        Public Function Buscar() As Boolean

            If _entContabilidad.IdEmpresa <> "" Then

                _entContabilidad.Estado = "ACT"
                _objADContabilidad.entContabilidad = _entContabilidad
                _objADContabilidad.Buscar()
                _lstContabilidades = _objADContabilidad.lstContabilidades
                Return (_lstContabilidades.Count > 0)

            Else
                Return False
            End If
        End Function

        Public Function Listar() As Boolean

            If _entContabilidad.IdEmpresa <> "" Then
                _objADContabilidad.entContabilidad = _entContabilidad
                _objADContabilidad.Listar()
                _lstContabilidades = _objADContabilidad.lstContabilidades
                Return (_lstContabilidades.Count > 0)

            Else
                Return False
            End If
        End Function
        Public Function ListarXEmpresa() As Boolean

            If entContabilidad.IdEmpresa <> "" Then
                _objADContabilidad.entContabilidad = entContabilidad
                _objADContabilidad.ListarXEmpresa()
                _lstContabilidades = _objADContabilidad.lstContabilidades
                Return (_lstContabilidades.Count > 0)

            Else
                Return False
            End If
        End Function
#End Region

    End Class
End Namespace