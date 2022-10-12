Namespace VENTAS
    Public Class EN_PedidoValor
        Inherits EN_Pedido

        Private _strIdAtributoTipo As String
        Private _strDescripcion As String
        Private _strIdAtributoValor As String
        Private _strEstado As String
        Private _strUsuario As String
 

        Public Property IdAtributoTipo() As String
            Get
                Return _strIdAtributoTipo
            End Get
            Set(ByVal value As String)
                _strIdAtributoTipo = value
            End Set
        End Property
        Public Property IdValor() As String
            Get
                Return _strIdAtributoValor
            End Get
            Set(ByVal value As String)
                _strIdAtributoValor = value
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


    End Class
End Namespace
