
Namespace VENTAS
    Public Class EN_Pedido
        Inherits GENERAL.EN_Empresa

#Region "VARIABLES"
        Private _strIdPedido As String
        Private _strIdCliente As String
        Private _strDesServicio As String
        Private _strTipoOperacion As String
        Private _strIdVendedor As String
        Private _strIdMoneda As String
        Private _strFechaEmision As String
        Private _strEstadoPedido As String
        Private _strIdAprobacion As String
        Private _strIdServicio As String
        Private _strFormaPago As String
        Private _strCuotas As String
        Private _StrDesCliente As String
        Private _strFechaIngreso As String
        Private _strFechaEntrega As String
        Private _stridArticulo As String
        Private _strdesArticulo As String
        Private _dblRollos As Double
        Private _dblCantidad As Double
        Private _dblImporte As String
        Private _strObservacion As String
        Private _strDireccionCliente As String
        Private _strContacto As String
        Private _strTipoPago As String
        Private _dblTipoCambio As Double

        Private _strEstado As String

        Private _strUsuario As String

#End Region

#Region "PROPIEDADES"

        Public Property IdPedido() As String
            Get
                Return _strIdPedido
            End Get
            Set(ByVal value As String)
                _strIdPedido = value
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
        Public Property Importe() As Double
            Get
                Return _dblImporte
            End Get
            Set(ByVal value As Double)
                _dblImporte = value
            End Set
        End Property
        Public Property Observacion() As String
            Get
                Return _strObservacion
            End Get
            Set(ByVal value As String)
                _strObservacion = value
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
        Public Property Cliente() As String
            Get
                Return _StrDesCliente
            End Get
            Set(ByVal value As String)
                _StrDesCliente = value
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
        Public Property idMoneda() As String
            Get
                Return _strIdMoneda
            End Get
            Set(ByVal value As String)
                _strIdMoneda = value
            End Set
        End Property
        Public Property FechaEmision() As String
            Get
                Return _strFechaEmision
            End Get
            Set(ByVal value As String)
                _strFechaEmision = value
            End Set
        End Property
        Public Property idVendedor() As String
            Get
                Return _strIdVendedor
            End Get
            Set(ByVal value As String)
                _strIdVendedor = value
            End Set
        End Property
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
        Public Property idArticulo() As String
            Get
                Return _stridArticulo
            End Get
            Set(ByVal value As String)
                _stridArticulo = value
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