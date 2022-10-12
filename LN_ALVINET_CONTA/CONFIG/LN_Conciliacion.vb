Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA

Public Class LN_Conciliacion

#Region "Variables"
    Private _entConciliacion As New EN_Conciliacion
    Private _lstConciliacion As List(Of EN_Conciliacion)
    Private _objError As New Exception
    Private _objADConciliacion As New AD_Conciliacion

#End Region
#Region "Propiedades"


    Public ReadOnly Property lstConciliacion() As List(Of EN_Conciliacion)
        Get
            Return _lstConciliacion
        End Get

    End Property


    Public Property entConciliacion() As EN_Conciliacion
        Get
            Return _entConciliacion

        End Get
        Set(ByVal value As EN_Conciliacion)
            _entConciliacion = value
        End Set
    End Property


    Public ReadOnly Property objError() As Exception
        Get
            Return _objError
        End Get

    End Property


#End Region
#Region "Metodos"
    Public Function Registrar() As Boolean
        If _entConciliacion.IdTipodoc <> "" Then
            _objADConciliacion.entConciliacion = _entConciliacion
            _objADConciliacion.Registrar()
            Return True
        Else
            Return False
        End If
    End Function
    'Public Function Eliminar() As Boolean
    '    _objADConciliacion.entConciliacion = _entConciliacion
    '    Return _objADConciliacion.Eliminar


    'End Function
    Public Function Listar() As Boolean
        _objADConciliacion.entConciliacion = _entConciliacion
        If _objADConciliacion.Listar() Then
            _lstConciliacion = _objADConciliacion.lstConciliacion
            Return (_lstConciliacion.Count > 0)
            Return True
        Else
            Return False
        End If
    End Function
#End Region

End Class

