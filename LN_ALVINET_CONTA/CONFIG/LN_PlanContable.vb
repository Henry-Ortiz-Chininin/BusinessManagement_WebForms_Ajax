Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.CONFIG

Namespace CONFIG
    Public Class LN_PlanContable
#Region "Variables"
        Private _objADPlanContable As New AD_PlanContable
        Private _objError As New Exception
        Private _lstPlanesContables As List(Of EN_PlanContable)
        Private _entPlanContable As New EN_PlanContable
#End Region
#Region "Propiedades"

        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstPlanesContables() As List(Of EN_PlanContable)
            Get
                Return _lstPlanesContables
            End Get
        End Property

        Public Property entPlanContable() As EN_PlanContable
            Get
                Return _entPlanContable
            End Get
            Set(ByVal Value As EN_PlanContable)
                _entPlanContable = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones "

        Public Function Registrar() As Boolean
            If entPlanContable.IdEmpresa <> "" AndAlso _
                entPlanContable.IdContabilidad <> "" AndAlso _
                entPlanContable.Formato <> "" AndAlso _
                entPlanContable.LongitudNivel1 > 0 AndAlso _
                entPlanContable.LongitudNivel2 > 0 AndAlso _
                entPlanContable.LongitudNivel3 > 0 AndAlso _
                entPlanContable.LongitudNivel4 > 0 AndAlso _
                entPlanContable.LongitudNivel5 > 0 AndAlso _
                entPlanContable.LongitudNivel6 > 0 AndAlso _
                entPlanContable.LongitudNivel7 > 0 AndAlso _
                entPlanContable.LongitudNivel8 > 0 AndAlso _
                entPlanContable.Estado <> "" Then

                _objADPlanContable.entPlanContable = _entPlanContable
                Return _objADPlanContable.Registrar()
            Else
                Return False
            End If
        End Function

        Public Function Listar() As Boolean

            If entPlanContable.IdEmpresa <> "" Then
                _objADPlanContable.entPlanContable = entPlanContable
                _objADPlanContable.Listar()
                _lstPlanesContables = _objADPlanContable.lstPlanesContables
                Return (_lstPlanesContables.Count > 0)
            Else
                Return False
            End If
        End Function

        Public Function Buscar() As Boolean
            If _entPlanContable.IdEmpresa <> "" Then
                _entPlanContable.Estado = "Activo"
                _objADPlanContable.entPlanContable = _entPlanContable
                _objADPlanContable.Buscar()
                _lstPlanesContables = _objADPlanContable.lstPlanesContables
                Return (_lstPlanesContables.Count > 0)
            Else
                Return False
            End If
        End Function

        Public Function Eliminar() As Boolean

            If entPlanContable.IdPlanContable <> "" AndAlso _
                entPlanContable.IdContabilidad <> "" AndAlso _
                entPlanContable.IdEmpresa <> "" Then

                _objADPlanContable.entPlanContable = entPlanContable
                Return _objADPlanContable.Eliminar
            Else
                Return False
            End If
        End Function
#End Region
    End Class
End Namespace