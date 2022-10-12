Imports AD_ALVINET_CONTA
Imports EN_ALVINET_CONTA

Public Class LN_PlanCuentaAutomatico
#Region "Variables"

    Private _objADPlanCuentaAutomatico As New AD_PlanCuentaAutomatico
    Private _lstPlanCuentaAutomatico As New List(Of EN_PanCuentaAutomatico)
    Private _objENPlanCuentaAutomatico As EN_PanCuentaAutomatico




#End Region
#Region "Propiedades"
    Public Property entPlanCuentaAutomatico() As EN_PanCuentaAutomatico
        Get
            Return _objENPlanCuentaAutomatico
        End Get
        Set(ByVal value As EN_PanCuentaAutomatico)
            _objENPlanCuentaAutomatico = value
        End Set
    End Property


    Public ReadOnly Property lstPlanCuentaAutomatico() As List(Of EN_PanCuentaAutomatico)
        Get
            Return _lstPlanCuentaAutomatico
        End Get

    End Property

#End Region
#Region "Metodos y Funciones"
    Public Function Registrar() As Boolean
        If entPlanCuentaAutomatico.IdOperacion <> "" AndAlso _
             entPlanCuentaAutomatico.IdCuenta <> "" AndAlso _
             entPlanCuentaAutomatico.Nombre <> "" Then
            _objADPlanCuentaAutomatico.entPlanCuentaAutomatico = entPlanCuentaAutomatico
            Return _objADPlanCuentaAutomatico.Registrar()
        Else
            Return False
        End If
    End Function
    Public Function Eliminar() As Boolean

        If entPlanCuentaAutomatico.IdCuenta <> "" AndAlso _
            entPlanCuentaAutomatico.IdOperacion <> "" Then
            _objADPlanCuentaAutomatico.entPlanCuentaAutomatico = entPlanCuentaAutomatico
            Return _objADPlanCuentaAutomatico.Eliminar
        Else
            Return False
        End If
    End Function
    Public Function Listar2() As Boolean
        _objADPlanCuentaAutomatico.entPlanCuentaAutomatico = _objENPlanCuentaAutomatico
        If _objADPlanCuentaAutomatico.Listar2 = True Then
            _lstPlanCuentaAutomatico = _objADPlanCuentaAutomatico.lstPlanCuentaautomatico
            Return (_lstPlanCuentaAutomatico.Count > 0)
        Else
            Return False
        End If
    End Function


    Public Function Buscar() As Boolean
        'If entComprobante.IdTipoDocumento <> "" AndAlso _
        '   entComprobante.IdComprobante <> "" Then

        _objADPlanCuentaAutomatico.entPlanCuentaAutomatico = _objENPlanCuentaAutomatico

        If _objADPlanCuentaAutomatico.Buscar() = True Then
            _lstPlanCuentaAutomatico = _objADPlanCuentaAutomatico.lstPlanCuentaautomatico
            Return (_lstPlanCuentaAutomatico.Count > 0)
        Else
            Return False
        End If
        'Else
        'Return False
        'End If

    End Function
    Public Function DiferenciaListar() As Boolean
        _objADPlanCuentaAutomatico.entPlanCuentaAutomatico = _objENPlanCuentaAutomatico
        _objADPlanCuentaAutomatico.DiferenciaListar()
        _lstPlanCuentaAutomatico = _objADPlanCuentaAutomatico.lstPlanCuentaautomatico
        Return (_lstPlanCuentaAutomatico.Count > 0)

    End Function
    Public Function Listar() As Boolean
        _objADPlanCuentaAutomatico.entPlanCuentaAutomatico = _objENPlanCuentaAutomatico
        _objADPlanCuentaAutomatico.Listar()
        _lstPlanCuentaAutomatico = _objADPlanCuentaAutomatico.lstPlanCuentaautomatico
        Return (_lstPlanCuentaAutomatico.Count > 0)

    End Function
    Public Function MovimientoListar() As Boolean
        _objADPlanCuentaAutomatico.entPlanCuentaAutomatico = _objENPlanCuentaAutomatico
        _objADPlanCuentaAutomatico.MovimientoListar()
        _lstPlanCuentaAutomatico = _objADPlanCuentaAutomatico.lstPlanCuentaautomatico
        Return (_lstPlanCuentaAutomatico.Count > 0)

    End Function
    Public Function BuscarGenerado() As Boolean
        _objADPlanCuentaAutomatico.entPlanCuentaAutomatico = _objENPlanCuentaAutomatico
        _objADPlanCuentaAutomatico.BuscarGenerado()
        _lstPlanCuentaAutomatico = _objADPlanCuentaAutomatico.lstPlanCuentaautomatico
        Return (_lstPlanCuentaAutomatico.Count > 0)

    End Function
#End Region
End Class
