Namespace GENERAL

    Public Class EN_Cliente
        Inherits GENERAL.EN_Empresa

#Region "Variable"
        Private _strIdCliente As String = ""
        Private _strDescripcion As String = ""
        Private _strDireccion As String = ""
          Private _strEstado As String = ""
        Private _strMercado As String = ""
        Private _strTelefono As String = ""
        Private _strPersonaContacto As String = ""
        Private _strTelefonoPersonaContacto As String = ""
#End Region

#Region "Propiedades"

        Public Property IdCliente() As String
            Get
                Return _strIdCliente
            End Get
            Set(ByVal value As String)
                _strIdCliente = value
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

        Public Property Direccion() As String
            Get
                Return _strDireccion
            End Get
            Set(ByVal value As String)
                _strDireccion = value
            End Set
        End Property

        Public Property Mercado() As String
            Get
                Return _strMercado
            End Get
            Set(ByVal value As String)
                _strMercado = value
            End Set
        End Property

        Public Property Telefono() As String
            Get
                Return _strTelefono
            End Get
            Set(ByVal value As String)
                _strTelefono = value
            End Set
        End Property

        Public Property PersonaContacto() As String
            Get
                Return _strPersonaContacto
            End Get
            Set(ByVal value As String)
                _strPersonaContacto = value
            End Set
        End Property

        Public Property TelefonoPersonaContacto() As String
            Get
                Return _strTelefonoPersonaContacto
            End Get
            Set(ByVal value As String)
                _strTelefonoPersonaContacto = value
            End Set
        End Property

#End Region


    End Class
End Namespace