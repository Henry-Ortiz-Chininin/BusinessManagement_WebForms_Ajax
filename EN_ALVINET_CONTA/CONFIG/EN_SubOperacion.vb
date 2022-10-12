Imports EN_ALVINET_CONTA.CONFIG

Public Class EN_SubOperacion
    Inherits EN_Operacion
#Region "Variables"

    Private _strIdSubOperacion As String = ""
    Private _strDescSubOperacion As String = ""
    Private _intAgno As Integer

#End Region
#Region "Propiedades"

    Public Property Agno As Integer
        Get
            Return _intAgno
        End Get
        Set(ByVal value As Integer)
            _intAgno = value
        End Set
    End Property
    Public Property SubOperacion() As String
        Get
            Return _strDescSubOperacion
        End Get
        Set(ByVal value As String)
            _strDescSubOperacion = value
        End Set
    End Property

    Public Property IdSubOperacion() As String
        Get
            Return _strIdSubOperacion
        End Get
        Set(ByVal value As String)
            _strIdSubOperacion = value
        End Set
    End Property

#End Region
End Class
