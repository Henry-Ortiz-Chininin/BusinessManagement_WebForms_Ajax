Namespace CONFIG

    Public Class EN_FormaPago
        Inherits GENERAL.EN_Empresa

#Region "Variable"
        Private _strIdCuota As String = ""
        Private _strDescripcion As String = ""
        Private _strEstado As String = ""
        Private _dtmFechaCreacion As Date
        Private _dtmFechaModificacion As Date
        Private _strUsuarioModificacion As String
        Private _strUsuarioCreacion As String

#End Region

#Region "Propiedades"

        Public Property IdCuota() As String
            Get
                Return _strIdCuota
            End Get
            Set(ByVal value As String)
                _strIdCuota = value
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

        Public Property FechaModificacion() As Date
            Get
                Return _dtmFechaModificacion
            End Get
            Set(ByVal value As Date)
                _dtmFechaModificacion = value
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

        Public Property UsuarioModificacion() As String
            Get
                Return _strUsuarioModificacion
            End Get
            Set(ByVal value As String)
                _strUsuarioModificacion = value
            End Set
        End Property

        Public Property UsuarioCreacion() As String
            Get
                Return _strUsuarioCreacion
            End Get
            Set(ByVal value As String)
                _strUsuarioCreacion = value
            End Set
        End Property


#End Region

    End Class

End Namespace