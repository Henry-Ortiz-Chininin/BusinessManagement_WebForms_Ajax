Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.CONFIG

Namespace CONFIG

    Public Class LN_NivelPlan
#Region "Variables"
        Private _objADNivelPlan As New AD_NivelPlan
        Private _objError As New Exception
        Private _lstNivelPlan As List(Of EN_NivelPlan)
        Private _entNivelPlan As New EN_NivelPlan
#End Region
#Region "Propiedades"

        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstNivelPlan() As List(Of EN_NivelPlan)
            Get
                Return _lstNivelPlan
            End Get
        End Property

        Public Property entNivelPlan() As EN_NivelPlan
            Get
                Return _entNivelPlan
            End Get
            Set(ByVal Value As EN_NivelPlan)
                _entNivelPlan = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones "
        Public Function Registrar() As Boolean

            If entNivelPlan.IdEmpresa <> "" AndAlso _
            entNivelPlan.Descripcion <> "" Then

                _objADNivelPlan.entNivelPlan = _entNivelPlan
                Return _objADNivelPlan.Registrar()

            Else
                Return False
            End If

        End Function

        Public Function Listar() As Boolean

            If entNivelPlan.IdEmpresa <> "" Then
                _objADNivelPlan.entNivelPlan = entNivelPlan
                _objADNivelPlan.Listar()
                _lstNivelPlan = _objADNivelPlan.lstNivelPlan

                Return (_lstNivelPlan.Count > 0)

            Else
                Return False
            End If
        End Function

        Public Function Eliminar() As Boolean

            If entNivelPlan.IdNivel <> "" AndAlso
                entNivelPlan.IdEmpresa <> "" Then

                _objADNivelPlan.entNivelPlan = entNivelPlan
                Return _objADNivelPlan.Eliminar

            Else
                Return False
            End If
        End Function

#End Region
    End Class
End Namespace