Public Class EN_Libro
    Inherits CONFIG.EN_Contabilidad

#Region "Variables"

    Private _strIdSunat As String = ""
    Private _strIdLibro As String = ""
    Private _strDescripcion As String = ""
    Private _strEstado As String = ""

#End Region

#Region "Propiedades"

    Public Property IdSunat() As String
        Get
            Return _strIdSunat
        End Get
        Set(ByVal value As String)
            _strIdSunat = value
        End Set
    End Property

    Public Property IdLibro() As String
        Get
            Return _strIdLibro
        End Get
        Set(ByVal value As String)
            _strIdLibro = value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return _strDescripcion
        End Get
        Set(ByVal value As String)
            _strDescripcion = value
        End Set
    End Property

#End Region
End Class
