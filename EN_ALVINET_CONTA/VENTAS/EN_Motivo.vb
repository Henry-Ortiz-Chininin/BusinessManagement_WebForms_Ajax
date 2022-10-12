
Namespace VENTAS
    Public Class EN_Motivo

#Region "VARIABLES"
        Private _strIdMotivo As String
        Private _strDescripcion As String
        Private _intPosicion As Int16

        Private _strEstado As String

        Private _strUsuario As String


#End Region
#Region "PROPIEDADES"

        Public Property IdMotivo() As String
            Get
                Return _strIdMotivo
            End Get
            Set(ByVal value As String)
                _strIdMotivo = value
            End Set
        End Property
        Public Property Posicion() As Int16
            Get
                Return _intPosicion
            End Get
            Set(ByVal value As Int16)
                _intPosicion = value
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

#End Region

    End Class
End Namespace