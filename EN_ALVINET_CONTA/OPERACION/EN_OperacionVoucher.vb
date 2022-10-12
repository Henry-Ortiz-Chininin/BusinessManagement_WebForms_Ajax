Namespace OPERACION

    Public Class EN_OperacionVoucher
        Inherits CONFIG.EN_Operacion

#Region "VARIABLES"
        Private _strIdEjercicio As String
        Private _strIdAsiento As String
        Private _strEstado As String
        Private _strFecha As String
        Private _strIdCentroCosto As String
        Private _strIdCliente As String
        Private _strIdTipoDocumento As String
        Private _strNumeroDocumento As String
        Private _strIdProveedor As String
#End Region

        Public Property IdEjercicio As String
            Get
                Return _strIdEjercicio
            End Get
            Set(ByVal value As String)
                _strIdEjercicio = value
            End Set
        End Property
        Public Property IdAsiento As String
            Get
                Return _strIdAsiento
            End Get
            Set(ByVal value As String)
                _strIdAsiento = value
            End Set
        End Property
        Public Property Estado As String
            Get
                Return _strEstado
            End Get
            Set(ByVal value As String)
                _strEstado = value
            End Set
        End Property
        Public Property Fecha As String
            Get
                Return _strFecha
            End Get
            Set(ByVal value As String)
                _strFecha = value
            End Set
        End Property
        Public Property IdCentroCosto As String
            Get
                Return _strIdCentroCosto
            End Get
            Set(ByVal value As String)
                _strIdCentroCosto = value
            End Set
        End Property
        Public Property IdCliente As String
            Get
                Return _strIdCliente
            End Get
            Set(ByVal value As String)
                _strIdCliente = value
            End Set
        End Property
        Public Property IdTipoDocumento As String
            Get
                Return _strIdTipoDocumento
            End Get
            Set(ByVal value As String)
                _strIdTipoDocumento = value
            End Set
        End Property
        Public Property NumeroDocumento As String
            Get
                Return _strNumeroDocumento
            End Get
            Set(ByVal value As String)
                _strNumeroDocumento = value
            End Set
        End Property
        Public Property IdProveedor As String
            Get
                Return _strIdProveedor
            End Get
            Set(ByVal value As String)
                _strIdProveedor = value
            End Set
        End Property
    End Class

End Namespace