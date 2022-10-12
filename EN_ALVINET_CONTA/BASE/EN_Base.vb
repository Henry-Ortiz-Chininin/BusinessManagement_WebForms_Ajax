Imports EN_ALVINET_CONTA.CONFIG
Imports EN_ALVINET_CONTA.OPERACION

Public Class EN_Base


#Region "Variables"

    Private _strSalida As String
    Private _intCriterioBusqueda As Integer
    Private _strParametro As String
    Private _strSubParametro As String



#End Region
#Region "Propiedades"
    Public Property Salida() As String
        Get
            Return _strSalida
        End Get
        Set(ByVal value As String)
            _strSalida = value
        End Set
    End Property
    Public Property CriterioBusqueda() As Integer
        Get
            Return _intCriterioBusqueda
        End Get
        Set(ByVal value As Integer)
            _intCriterioBusqueda = value
        End Set
    End Property
    Public Property Parametro() As String
        Get
            Return _strParametro
        End Get
        Set(ByVal value As String)
            _strParametro = value
        End Set
    End Property
    Public Property SubParametro() As String
        Get
            Return _strSubParametro
        End Get
        Set(ByVal value As String)
            _strSubParametro = value
        End Set
    End Property


#End Region
End Class
