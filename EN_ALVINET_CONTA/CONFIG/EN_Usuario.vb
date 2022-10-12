Namespace CONFIG

    Public Class EN_Usuario
        Inherits EN_Base

#Region "Variable"

        Private _strIdUsuario As String = ""
        Private _strClave As String = ""
        Private _strNombre As String = ""
        Private _strEstado As String = ""
        Private _dtmFechaCreacion As Date
        Private _strUsuarioCreacion As String = ""
        Private _dtmFechaModificacion As Date
        Private _strUsuarioModificacion As String = ""
        Private _strIdEmpresas As String = ""
#End Region

#Region "Propiedades"

        Public Property IdUsuario() As String
            Get
                Return _strIdUsuario
            End Get
            Set(ByVal value As String)
                _strIdUsuario = value
            End Set
        End Property

        Public Property Clave() As String
            Get
                Return _strClave
            End Get
            Set(ByVal value As String)
                _strClave = value
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



        Public Property Estado() As String
            Get
                Return _strEstado
            End Get
            Set(ByVal value As String)
                _strEstado = value
            End Set
        End Property

        Public Property FechaCreacion() As Date
            Get
                Return _dtmFechaCreacion
            End Get
            Set(ByVal value As Date)
                _dtmFechaCreacion = value
            End Set
        End Property

        Public Property UsuarioCreacion As String
            Get
                Return _strUsuarioCreacion
            End Get
            Set(ByVal value As String)
                _strUsuarioCreacion = value
            End Set
        End Property

        Public Property FechaModificacion As String
            Get
                Return _dtmFechaModificacion
            End Get
            Set(ByVal value As String)
                _dtmFechaModificacion = value
            End Set
        End Property

        Public Property UsuarioModificacion As String
            Get
                Return _strUsuarioModificacion
            End Get
            Set(ByVal value As String)
                _strUsuarioModificacion = value
            End Set
        End Property

        Public Property IdEmpresas() As String
            Get
                Return _strIdEmpresas
            End Get
            Set(ByVal value As String)
                _strIdEmpresas = value
            End Set
        End Property

#End Region

    End Class
End Namespace