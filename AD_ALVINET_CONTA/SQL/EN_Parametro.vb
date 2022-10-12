Namespace AccesoDatos
    Public Class EN_Parametro
        Private _strNombre As String
        Private _strTipo As String
        Private _objValor As Object

        Public Property Nombre() As String
            Get
                Return _strNombre
            End Get
            Set(ByVal value As String)
                _strNombre = value
            End Set
        End Property
        Public Property Valor As Object
            Get
                Return _objValor
            End Get
            Set(ByVal value As Object)
                _objValor = value
            End Set
        End Property

        Public Property Tipo() As String
            Get
                Return _strTipo
            End Get
            Set(ByVal value As String)
                _strTipo = value
            End Set
        End Property
    End Class
End Namespace