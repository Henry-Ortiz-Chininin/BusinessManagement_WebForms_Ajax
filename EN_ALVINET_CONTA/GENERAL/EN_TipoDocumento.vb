Namespace GENERAL

    Public Class EN_TipoDocumento
        Inherits GENERAL.EN_Empresa

#Region "Variable"

        Private _strIdTipoDocumento As String = ""
        Private _strDescripcion As String = ""
        Private _strClase As String = ""
        Private _strEstado As String = ""
        Private _strIdSunat As String = ""

#End Region

#Region "Propiedades"

        Public Property IdTipoDocumento() As String
            Get
                Return _strIdTipoDocumento
            End Get
            Set(ByVal value As String)
                _strIdTipoDocumento = value
            End Set
        End Property

        Public Property TipoDocumento() As String
            Get
                Return _strDescripcion
            End Get
            Set(ByVal value As String)
                _strDescripcion = value
            End Set
        End Property
        Public Property Clase() As String
            Get
                Return _strClase
            End Get
            Set(ByVal value As String)
                _strClase = value
            End Set
        End Property

        Public Property IdSunat() As String
            Get
                Return _strIdSunat
            End Get
            Set(ByVal value As String)
                _strIdSunat = value
            End Set
        End Property

#End Region

    End Class

End Namespace








