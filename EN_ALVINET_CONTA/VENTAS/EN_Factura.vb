Imports EN_ALVINET_CONTA.GENERAL

Namespace VENTAS
    Public Class EN_Factura

#Region "VARIABLES"
        Inherits EN_Comprobante
        Private _strIdEmpresa As String = ""
        Private _intCont As Integer
        Private _strIdComprobante As String = ""
        Private _strNumeroDocumento As String = ""
        Private _strCorrelativo As String = ""
        Private _strIdCliente As String = ""
        Private _strDesServicio As String = ""
        Private _strTipoOperacion As String = ""
        Private _strIdVendedor As String = ""
        Private _strIdMoneda As String = ""
        Private _strFechaEmision As String = ""
        Private _strEstadoPedido As String = ""
        Private _strIdAprobacion As String = ""
        Private _strIdServicio As String = ""
        Private _strFormaPago As String = ""

        Private _strCuotas As String = ""
        Private _strMontoCuota As String = ""
        Private _strContadoCredito As String = ""
        Private _strIdDocumento As String = ""
        Private _strIdMotivo As String = ""
        Private _strMaximo As String = ""
        Private _strTipoPago As String = ""

        Private _dblDesc As Double = 0
        Private _dblTotal As Double = 0
        Private _dblsubTotal As Double = 0
        Private _dblIGV As Double = 0
        Private _dblTotalParcial As Double = 0
        Private _dblTipoCambio As Double = 0

        Private _StrDesCliente As String = ""
        Private _strFechaIngreso As String = ""
        Private _strFechaEntrega As String = ""
        Private _strFechaVencimiento As String = ""
        Private _stridArticulo As String = ""
        Private _strdesArticulo As String = ""
        Private _dblRollos As Double = 0
        Private _dblCantidad As Double = 0
        Private _dblImporte As String = ""
        Private _strObservacion As String = ""
        Private _strDireccionCliente As String = ""
        Private _strContacto As String = ""

        Private _strMonto As String = ""
        Private _strMoneda As String = ""
        Private _strEstado As String = ""
        Private _strUsuario As String = ""
        Private _strUnidad As String = ""
        Private _decCostoUnitario As Decimal = 0
        Private _strIdEjeccioEmpre As String = ""
        Private _strIdContabilida As String = ""
        Private _decSaldo As Decimal = 0
        Private _decPago As Decimal = 0
#End Region

#Region "PROPIEDADES"

        'Public Property IdEmpresa() As String
        '    Get
        '        Return _strIdEmpresa
        '    End Get
        '    Set(ByVal value As String)
        '        _strIdEmpresa = value
        '    End Set
        'End Property

        Public Property CostoUnitario() As Decimal
            Get
                Return _decCostoUnitario
            End Get
            Set(ByVal value As Decimal)
                _decCostoUnitario = value
            End Set
        End Property
        Public Property Unidad() As String
            Get
                Return _strUnidad
            End Get
            Set(ByVal value As String)
                _strUnidad = value
            End Set
        End Property

        'Public Property IdComprobante() As String
        '    Get
        '        Return _strIdComprobante
        '    End Get
        '    Set(ByVal value As String)
        '        _strIdComprobante = value
        '    End Set
        'End Property
        Public Property NumeroDocumento() As String
            Get
                Return _strNumeroDocumento
            End Get
            Set(ByVal value As String)
                _strNumeroDocumento = value
            End Set
        End Property
        Public Property Maximo() As String
            Get
                Return _strMaximo
            End Get
            Set(ByVal value As String)
                _strMaximo = value
            End Set
        End Property
        Public Property Monto() As String
            Get
                Return _strMonto
            End Get
            Set(ByVal value As String)
                _strMonto = value
            End Set
        End Property
        Public Property Moneda() As String
            Get
                Return _strMoneda
            End Get
            Set(ByVal value As String)
                _strMoneda = value
            End Set
        End Property
        Public Property TipoCambio() As Double
            Get
                Return _dblTipoCambio
            End Get
            Set(ByVal value As Double)
                _dblTipoCambio = value
            End Set
        End Property
        Public Property TipoPago() As String
            Get
                Return _strTipoPago
            End Get
            Set(ByVal value As String)
                _strTipoPago = value
            End Set
        End Property
        Public Property Correlativo() As String
            Get
                Return _strCorrelativo
            End Get
            Set(ByVal value As String)
                _strCorrelativo = value
            End Set
        End Property
        Public Property IdMotivo() As String
            Get
                Return _strIdMotivo
            End Get
            Set(ByVal value As String)
                _strIdMotivo = value
            End Set
        End Property
        Public Property Rollos() As Double
            Get
                Return _dblRollos
            End Get
            Set(ByVal value As Double)
                _dblRollos = value
            End Set
        End Property
        Public Property Cantidad() As Double
            Get
                Return _dblCantidad
            End Get
            Set(ByVal value As Double)
                _dblCantidad = value
            End Set
        End Property


        Public Property intCont() As Integer
            Get
                Return _intCont
            End Get
            Set(ByVal value As Integer)
                _intCont = value
            End Set
        End Property

        Public Property Importe() As Double
            Get
                Return _dblImporte
            End Get
            Set(ByVal value As Double)
                _dblImporte = value
            End Set
        End Property
        Public Property Descuento() As Double
            Get
                Return _dblDesc
            End Get
            Set(ByVal value As Double)
                _dblDesc = value
            End Set
        End Property
        Public Property Total() As Double
            Get
                Return _dblTotal
            End Get
            Set(ByVal value As Double)
                _dblTotal = value
            End Set
        End Property
        Public Property SubTotal() As Double
            Get
                Return _dblsubTotal
            End Get
            Set(ByVal value As Double)
                _dblsubTotal = value
            End Set
        End Property
        Public Property IGV() As Double
            Get
                Return _dblIGV
            End Get
            Set(ByVal value As Double)
                _dblIGV = value
            End Set
        End Property

       
        Public Property Pago() As Decimal
            Get
                Return _decPago
            End Get
            Set(ByVal value As Decimal)
                _decPago = value
            End Set
        End Property

        Public Property Saldo() As Decimal
            Get
                Return _decSaldo
            End Get
            Set(ByVal value As Decimal)
                _decSaldo = value
            End Set
        End Property
        'Public Property TotalParcial() As Double
        '    Get
        '        Parcial()
        '    End Get
        '    Set(ByVal value As Double)
        '        Parcial = value
        '    End Set
        'End Property
        'Public Property Observacion() As String
        '    Get
        '        Return _strObservacion
        '    End Get
        '    Set(ByVal value As String)
        '        _strObservacion = value
        '    End Set
        'End Property
        Public Property ContactoCliente() As String
            Get
                Return _strContacto
            End Get
            Set(ByVal value As String)
                _strContacto = value
            End Set
        End Property
        Public Property DireccionCliente() As String
            Get
                Return _strDireccionCliente
            End Get
            Set(ByVal value As String)
                _strDireccionCliente = value
            End Set
        End Property
        Public Property IdCliente() As String
            Get
                Return _strIdCliente
            End Get
            Set(ByVal value As String)
                _strIdCliente = value
            End Set
        End Property
        Public Property IdServicio() As String
            Get
                Return _strIdServicio
            End Get
            Set(ByVal value As String)
                _strIdServicio = value
            End Set
        End Property
        Public Property IdDocumento() As String
            Get
                Return _strIdDocumento
            End Get
            Set(ByVal value As String)
                _strIdDocumento = value
            End Set
        End Property
        Public Property Cliente() As String
            Get
                Return _StrDesCliente
            End Get
            Set(ByVal value As String)
                _StrDesCliente = value
            End Set
        End Property
        Public Property FechaIngreso() As String
            Get
                Return _strFechaIngreso
            End Get
            Set(ByVal value As String)
                _strFechaIngreso = value
            End Set
        End Property
        Public Property FechaEntrega() As String
            Get
                Return _strFechaEntrega
            End Get
            Set(ByVal value As String)
                _strFechaEntrega = value
            End Set
        End Property
        'Public Property FechaVencimiento() As String
        '    Get
        '        Return _strFechaVencimiento
        '    End Get
        '    Set(ByVal value As String)
        '        _strFechaVencimiento = value
        '    End Set
        'End Property
        Public Property desArticulo() As String
            Get
                Return _strdesArticulo
            End Get
            Set(ByVal value As String)
                _strdesArticulo = value
            End Set
        End Property
        Public Property desServicio() As String
            Get
                Return _strDesServicio
            End Get
            Set(ByVal value As String)
                _strDesServicio = value
            End Set
        End Property
        Public Property TipoOperacion() As String
            Get
                Return _strTipoOperacion
            End Get
            Set(ByVal value As String)
                _strTipoOperacion = value
            End Set
        End Property
        'Public Property idMoneda() As String
        '    Get
        '        Return _strIdMoneda
        '    End Get
        '    Set(ByVal value As String)
        '        _strIdMoneda = value
        '    End Set
        'End Property
        'Public Property FechaEmision() As String
        '    Get
        '        Return _strFechaEmision
        '    End Get
        '    Set(ByVal value As String)
        '        _strFechaEmision = value
        '    End Set
        'End Property
        'Public Property idVendedor() As String
        '    Get
        '        Return _strIdVendedor
        '    End Get
        '    Set(ByVal value As String)
        '        _strIdVendedor = value
        '    End Set
        'End Property
        Public Property EstadoPedido() As String
            Get
                Return _strEstadoPedido
            End Get
            Set(ByVal value As String)
                _strEstadoPedido = value
            End Set
        End Property
        Public Property IdAprobacion() As String
            Get
                Return _strIdAprobacion
            End Get
            Set(ByVal value As String)
                _strIdAprobacion = value
            End Set
        End Property
        Public Property Formapago() As String
            Get
                Return _strFormaPago
            End Get
            Set(ByVal value As String)
                _strFormaPago = value
            End Set
        End Property



        Public Property Cuotas() As String
            Get
                Return _strCuotas
            End Get
            Set(ByVal value As String)
                _strCuotas = value
            End Set
        End Property


        Public Property MontoCuota() As String
            Get
                Return _strMontoCuota
            End Get
            Set(ByVal value As String)
                _strMontoCuota = value
            End Set
        End Property

        Public Property ContadoCredito() As String
            Get
                Return _strContadoCredito
            End Get
            Set(ByVal value As String)
                _strContadoCredito = value
            End Set
        End Property
        Public Property idArticulo() As String
            Get
                Return _stridArticulo
            End Get
            Set(ByVal value As String)
                _stridArticulo = value
            End Set
        End Property
        'Public Property Estado() As String
        '    Get
        '        Return _strEstado
        '    End Get
        '    Set(ByVal value As String)
        '        _strEstado = value
        '    End Set
        'End Property


        Public Property Usuario() As String
            Get
                Return _strUsuario
            End Get
            Set(ByVal value As String)
                _strUsuario = value
            End Set
        End Property

        Public Property IdEjerccioEmpresa() As String
            Get
                Return _strIdEjeccioEmpre
            End Get
            Set(ByVal value As String)
                _strIdEjeccioEmpre = value
            End Set
        End Property

        'Public Property IdContabilidad() As String
        '    Get
        '        Return _strIdContabilida
        '    End Get
        '    Set(ByVal value As String)
        '        _strIdContabilida = value
        '    End Set
        'End Property
#End Region

    End Class
End Namespace
