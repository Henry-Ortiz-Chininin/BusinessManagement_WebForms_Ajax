Imports EN_ALVINET_CONTA.GENERAL

Namespace OPERACION
    Public Class EN_Detraccion
        Inherits EN_CompraDocumento

#Region "Variables"
        Private _strNumeroConstancia As String = ""
        Private _strNumeroCuentaDetracciones As String = ""
        Private _strIdEntidadFinanciera As String = ""
        Private _strRucProveedor As String = ""
        Private _strRucAdquiriente As String = ""
        Private _strIdOperacion As String = ""
        Private _strBienoServicio As String = ""
        Private _decMontoDeposito As Decimal
        Private _dtmFechaPago As Date
        Private _strPeriodoTributario As String = ""
        Private _strNumeroOperacion As String = ""
        'Private _strRazonSocialCliente As String = ""
        Private _strRazonSocialProveedor As String = ""
        Private _strDescripcion As String = ""
        Private _strDescripcionServicio As String = ""
        Private _strDescripcionOperacion As String = ""
        Private _strFactura As String = ""
        Private _strIdDocumentoCompra As String = ""
        Private _strNumeroDocumento As String = ""
        Private _strImporte As String = ""
        Private _strRetorno As String = ""
        Private _strMontoDetraccion As String = ""

        Private _strIdDetraccion As String
       
#End Region

#Region "Propiedades"
        Public Property Descripcion As String
            Get
                Return _strDescripcion
            End Get
            Set(ByVal value As String)
                _strDescripcion = value
            End Set
        End Property

        Public Property IdEntidadFinanciera As String
            Get
                Return _strIdEntidadFinanciera
            End Get
            Set(ByVal value As String)
                _strIdEntidadFinanciera = value
            End Set
        End Property
        Public Property MontoDetraccion() As String
            Get
                Return _strMontoDetraccion
            End Get
            Set(ByVal value As String)
                _strMontoDetraccion = value
            End Set
        End Property
        Public Property IdDetraccion() As String
            Get
                Return _strIdDetraccion
            End Get
            Set(ByVal value As String)
                _strIdDetraccion = value
            End Set
        End Property

        Public Property Factura() As String
            Get
                Return _strFactura
            End Get
            Set(ByVal value As String)
                _strFactura = value
            End Set
        End Property

        Public Property RazonSocialProveedor() As String
            Get
                Return _strRazonSocialProveedor
            End Get
            Set(ByVal value As String)
                _strRazonSocialProveedor = value
            End Set
        End Property

        Public Property DescripcionOperacion() As String
            Get
                Return _strDescripcionOperacion
            End Get
            Set(ByVal value As String)
                _strDescripcionOperacion = value
            End Set
        End Property
        Public Property DescripcionServicio() As String
            Get
                Return _strDescripcionServicio
            End Get
            Set(ByVal value As String)
                _strDescripcionServicio = value
            End Set
        End Property

        Public Property NumeroConstancia() As String
            Get
                Return _strNumeroConstancia
            End Get
            Set(ByVal value As String)
                _strNumeroConstancia = value
            End Set
        End Property

        Public Property NumeroCuentaDetracciones() As String
            Get
                Return _strNumeroCuentaDetracciones
            End Get
            Set(ByVal value As String)
                _strNumeroCuentaDetracciones = value
            End Set
        End Property

        Public Property RucProveedor() As String
            Get
                Return _strRucProveedor
            End Get
            Set(ByVal value As String)
                _strRucProveedor = value
            End Set
        End Property

        Public Property RucAdquiriente() As String
            Get
                Return _strRucAdquiriente
            End Get
            Set(ByVal value As String)
                _strRucAdquiriente = value
            End Set
        End Property


        Public Property IdOperacion() As String
            Get
                Return _strIdOperacion
            End Get
            Set(ByVal value As String)
                _strIdOperacion = value
            End Set
        End Property

        Public Property BienoServicio() As String
            Get
                Return _strBienoServicio
            End Get
            Set(ByVal value As String)
                _strBienoServicio = value
            End Set
        End Property

        Public Property MontoDeposito() As Decimal
            Get
                Return _decMontoDeposito
            End Get
            Set(ByVal value As Decimal)
                _decMontoDeposito = value
            End Set
        End Property

        Public Property FechaPago() As String
            Get
                Return _dtmFechaPago
            End Get
            Set(ByVal value As String)
                _dtmFechaPago = value
            End Set
        End Property

        Public Property PeriodoTributario() As String
            Get
                Return _strPeriodoTributario
            End Get
            Set(ByVal value As String)
                _strPeriodoTributario = value
            End Set
        End Property

        Public Property NumeroOperacion() As String
            Get
                Return _strNumeroOperacion
            End Get
            Set(ByVal value As String)
                _strNumeroOperacion = value
            End Set
        End Property

#End Region

    End Class

End Namespace
