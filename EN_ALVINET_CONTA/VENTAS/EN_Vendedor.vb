Namespace VENTAS

    Public Class EN_Vendedor


#Region "VARIABLES"
        Private _strIdVendedor As String
        Private _strNombre As String
        Private _strApellidoMaterno As String
        Private _strApellidoPaterno As String
        Private _strEstado As String
        Private _strNombreCompleto As String

        Private _strUsuario As String


#End Region

#Region "PROPIEDADES"

        Public Property IdVendedor() As String
            Get
                Return _strIdVendedor
            End Get
            Set(ByVal value As String)
                _strIdVendedor = value
            End Set
        End Property
        Public Property Nombre() As String
            Get
                Return _strNombre
            End Get
            Set(ByVal value As String)
                _strNombre = value
            End Set
        End Property
        Public Property ApellidoMaterno() As String
            Get
                Return _strApellidoMaterno
            End Get
            Set(ByVal value As String)
                _strApellidoMaterno = value
            End Set
        End Property
        Public Property ApellidoPaterno() As String
            Get
                Return _strApellidoPaterno
            End Get
            Set(ByVal value As String)
                _strApellidoPaterno = value
            End Set
        End Property

        Public Property Estado() As String
            Get
                Return _strEstado
            End Get
            Set(ByVal value As String)
                _strEstado = value
            End Set
        End Property


        Public Property Usuario() As String
            Get
                Return _strUsuario
            End Get
            Set(ByVal value As String)
                _strUsuario = value
            End Set
        End Property

        Public Property NombreCompleto() As String
            Get
                Return _strNombreCompleto
            End Get
            Set(ByVal value As String)
                _strNombreCompleto = value
            End Set
        End Property

#End Region
    End Class
End Namespace