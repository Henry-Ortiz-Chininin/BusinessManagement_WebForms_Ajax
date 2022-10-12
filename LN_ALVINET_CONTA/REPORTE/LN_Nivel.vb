Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.REPORTE

Namespace REPORTE
    Public Class LN_Nivel
#Region "Variables"
        Dim _objADNivel As New AD_Nivel
        Private _objError As New Exception
        Dim _lstNivelPlan As List(Of EN_NivelPlan)
        Dim _entNivelPlan As EN_NivelPlan
#End Region
#Region "Propiedades"
        Public Property objError() As Exception
            Get
                Return _objError
            End Get
            Set(ByVal value As Exception)
                _objError = value
            End Set
        End Property

        Public Property lstNivel() As List(Of EN_NivelPlan)
            Get
                Return _lstNivelPlan
            End Get
            Set(ByVal value As List(Of EN_NivelPlan))
                _lstNivelPlan = value
            End Set
        End Property

        Public Property entNivel() As EN_NivelPlan
            Get
                Return _entNivelPlan
            End Get
            Set(ByVal value As EN_NivelPlan)
                _entNivelPlan = value
            End Set
        End Property
#End Region
#Region "Metodo y Funciones"
        Public Function ListaNivel() As Boolean

            If _objADNivel.ListarNivel Then
                _lstNivelPlan = _objADNivel.lstNivel
                Return (_lstNivelPlan.Count > 0)
                Return True
            Else
                Return False
            End If
        End Function

#End Region
    End Class
End Namespace