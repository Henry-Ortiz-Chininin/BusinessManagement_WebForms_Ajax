
Namespace GENERAL

    Public Class EN_CompraDetalle
        Inherits EN_CompraDocumento

        Private _strIdDocumentoCompra As String = ""
        Private _strIdDetalle As String = ""
        Private _strIdArticulo As String = ""
        Private _strIdArticuloProveedor As String = ""
        Private _strNombreArticuloProveedor As String = ""
        Private _strIdUnidadMedida As String = ""
        Private _strNombreUnidadMedida As String = ""
        Private _dblTipoCambio As Decimal = 0
        Private _dblImporte As Decimal = 0
        Private _dblImporteOrigen As Decimal = 0
        Private _strMoneda As String = ""
        Private _intCantidad As Integer = 0
        Private _strFechaVencimiento As String = ""
        Private _strTipoDocumento As String = ""

        Private _strEstado As String = ""
        Private _strUsuario As String = ""
        Private _exError As Exception
        Private _strNumero As String = ""
        Private _strFechaEmision As String = ""

        Private _bolInafecta As Boolean = False
        Private _bolAfecta As Boolean = False


        Public Property NombreUnidadMedida() As String
            Get
                Return _strNombreUnidadMedida
            End Get
            Set(ByVal value As String)
                _strNombreUnidadMedida = value
            End Set
        End Property

        Public Property IdDocumentoCompra() As String
            Get
                Return _strIdDocumentoCompra
            End Get
            Set(ByVal value As String)
                _strIdDocumentoCompra = value
            End Set
        End Property
        Public Property IdDetalle() As String
            Get
                Return _strIdDetalle
            End Get
            Set(ByVal value As String)
                _strIdDetalle = value
            End Set
        End Property

        Public Property IdArticulo() As String
            Get
                Return _strIdArticulo
            End Get
            Set(ByVal value As String)
                _strIdArticulo = value
            End Set
        End Property

        Public Property IdArticuloProveedor() As String
            Get
                Return _strIdArticuloProveedor
            End Get
            Set(ByVal value As String)
                _strIdArticuloProveedor = value
            End Set
        End Property

        Public Property NombreArticuloProveedor() As String
            Get
                Return _strNombreArticuloProveedor
            End Get
            Set(ByVal value As String)
                _strNombreArticuloProveedor = value
            End Set
        End Property
        Public Property IdUnidadMedida() As String
            Get
                Return _strIdUnidadMedida
            End Get
            Set(ByVal value As String)
                _strIdUnidadMedida = value
            End Set
        End Property

        Public Property TipoCambio As Decimal
            Get
                Return _dblTipoCambio
            End Get
            Set(ByVal value As Decimal)
                _dblTipoCambio = value
            End Set
        End Property
        Public Property Cantidad() As Integer
            Get
                Return _intCantidad
            End Get
            Set(ByVal value As Integer)
                _intCantidad = value
            End Set
        End Property

        Public Property Importe As Decimal
            Get
                Return _dblImporte
            End Get
            Set(ByVal value As Decimal)
                _dblImporte = value
            End Set
        End Property


        Public Property ImporteOrigen() As Decimal
            Get
                Return _dblImporteOrigen
            End Get
            Set(ByVal value As Decimal)
                _dblImporteOrigen = value
            End Set
        End Property


        Public Property Moneda As String
            Get
                Return _strMoneda
            End Get
            Set(ByVal value As String)
                _strMoneda = value
            End Set
        End Property

        Public Property Afecta() As Boolean
            Get
                Return _bolAfecta
            End Get
            Set(ByVal value As Boolean)
                _bolAfecta = value
            End Set
        End Property
        Public Property Inafecta() As Boolean
            Get
                Return _bolInafecta
            End Get
            Set(ByVal value As Boolean)
                _bolInafecta = value
            End Set
        End Property
    End Class

End Namespace

