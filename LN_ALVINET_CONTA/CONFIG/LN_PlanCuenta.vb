Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.CONFIG

Namespace CONFIG
    Public Class LN_PlanCuenta
#Region "Variables"
        Private _objADPlanCuenta As New AD_PlanCuenta
        Private _objError As New Exception
        Private _lstPlanCuentas As List(Of EN_PlanCuenta)
        Private _entPlanCuenta As New EN_PlanCuenta
#End Region
#Region "Propiedades"

        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstPlanCuentas() As List(Of EN_PlanCuenta)
            Get
                Return _lstPlanCuentas
            End Get
        End Property

        Public Property entPlanCuenta() As EN_PlanCuenta
            Get
                Return _entPlanCuenta
            End Get
            Set(ByVal Value As EN_PlanCuenta)
                _entPlanCuenta = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones "

        Public Function Registrar() As Boolean
            'If entPlanCuenta.IdEmpresa <> "" <> "" AndAlso _
            '    entPlanCuenta.IdNivel <> "" AndAlso entPlanCuenta.IdContabilidad <> "" Then

            _objADPlanCuenta.entPlanCuenta = _entPlanCuenta
            Return _objADPlanCuenta.Registrar()
            'Else
            'Return False
            'End If
        End Function

        Public Function Listar() As Boolean

            If entPlanCuenta.IdEmpresa <> "" AndAlso entPlanCuenta.IdEmpresa <> "" Then

                _objADPlanCuenta.entPlanCuenta = _entPlanCuenta
                _objADPlanCuenta.Listar()
                _lstPlanCuentas = _objADPlanCuenta.lstPlaneCuentas
                Return (_lstPlanCuentas.Count > 0)
            Else
                Return False
            End If
        End Function
        Public Function ListarxEmpresa() As Boolean

            If entPlanCuenta.IdEmpresa <> "" AndAlso _
            entPlanCuenta.IdUsuario <> "" Then
                _objADPlanCuenta.entPlanCuenta = _entPlanCuenta
                _objADPlanCuenta.ListarxEmpresa()
                _lstPlanCuentas = _objADPlanCuenta.lstPlaneCuentas
                Return (_lstPlanCuentas.Count > 0)
            Else
                Return False
            End If
        End Function


        Public Function Eliminar() As Boolean

            If entPlanCuenta.IdCuentaContable <> "" AndAlso _
                entPlanCuenta.IdPlanContable <> "" AndAlso _
                entPlanCuenta.IdContabilidad <> "" AndAlso _
                entPlanCuenta.IdEmpresa <> "" Then

                _objADPlanCuenta.entPlanCuenta = entPlanCuenta
                Return _objADPlanCuenta.Eliminar
            Else
                Return False
            End If
        End Function
#End Region
    End Class
End Namespace