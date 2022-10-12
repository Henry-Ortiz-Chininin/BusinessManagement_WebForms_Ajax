
Namespace VENTAS
    Public Class EN_NotaDebito


#Region "VARIABLES"
        Private _strIdNota As String
        Private _strSerieNota As String
        Private _strNumeroNota As String
        Private _strIdComprobante As String
        Private _strSerieComprobante As String
        Private _strNumeroComprobante As String
        Private _strGlosa As String
        Private _dblTipoCambio As Double

        Private _strIdVendedor As String
        Private _strIdCliente As String
        Private _StrDesCliente As String
        Private _strDireccionCliente As String

        Private _strTipoOperacion As String
        Private _strIdMoneda As String
        Private _strEstadoNota As String
        Private _strIdMotivo As String
        Private _strIdTipoNota As String

        Private _strFechaEmision As String
        Private _strFechaInicio As String
        Private _strFechaFinal As String
        Private _strMaximo As String

        Private _dbltotalParcial As Double
        Private _dblDescuento As Double
        Private _dblSubtotal As Double
        Private _dblIGV As Double
        Private _dblTotal As Double

        Private _strEstado As String

        Private _strUsuario As String

#End Region

#Region "PROPIEDADES"

        Public Property Idnota() As String
            Get
                Return _strIdNota
            End Get
            Set(ByVal value As String)
                _strIdNota = value
            End Set
        End Property
        Public Property SerieNota() As String
            Get
                Return _strSerieNota
            End Get
            Set(ByVal value As String)
                _strSerieNota = value
            End Set
        End Property
        Public Property NumeroNota() As String
            Get
                Return _strNumeroNota
            End Get
            Set(ByVal value As String)
                _strNumeroNota = value
            End Set
        End Property
        Public Property Glosa() As String
            Get
                Return _strGlosa
            End Get
            Set(ByVal value As String)
                _strGlosa = value
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
        Public Property IdCliente() As String
            Get
                Return _strIdCliente
            End Get
            Set(ByVal value As String)
                _strIdCliente = value
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
        Public Property DireccionCliente() As String
            Get
                Return _strDireccionCliente
            End Get
            Set(ByVal value As String)
                _strDireccionCliente = value
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
        Public Property idVendedor() As String
            Get
                Return _strIdVendedor
            End Get
            Set(ByVal value As String)
                _strIdVendedor = value
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
        Public Property Estado() As String
            Get
                Return _strEstado
            End Get
            Set(ByVal value As String)
                _strEstado = value
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
        Public Property IdComprobante() As String
            Get
                Return _strIdComprobante
            End Get
            Set(ByVal value As String)
                _strIdComprobante = value
            End Set
        End Property
        Public Property SerieComprobante() As String
            Get
                Return _strSerieComprobante
            End Get
            Set(ByVal value As String)
                _strSerieComprobante = value
            End Set
        End Property
        Public Property NumeroComprobante() As String
            Get
                Return _strNumeroComprobante
            End Get
            Set(ByVal value As String)
                _strNumeroComprobante = value
            End Set
        End Property
        Public Property IdTipoNota() As String
            Get
                Return _strIdTipoNota
            End Get
            Set(ByVal value As String)
                _strIdTipoNota = value
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
        Public Property FechaInicio() As String
            Get
                Return _strFechaInicio
            End Get
            Set(ByVal value As String)
                _strFechaInicio = value
            End Set
        End Property
        Public Property FechaFin() As String
            Get
                Return _strFechaFinal
            End Get
            Set(ByVal value As String)
                _strFechaFinal = value
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
        Public Property totalParcial() As Double
            Get
                Return _dbltotalParcial
            End Get
            Set(ByVal value As Double)
                _dbltotalParcial = value
            End Set
        End Property
        Public Property Descuento() As Double
            Get
                Return _dblDescuento
            End Get
            Set(ByVal value As Double)
                _dblDescuento = value
            End Set
        End Property
        Public Property Subtotal() As Double
            Get
                Return _dblSubtotal
            End Get
            Set(ByVal value As Double)
                _dblSubtotal = value
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
        Public Property Total() As Double
            Get
                Return _dblTotal
            End Get
            Set(ByVal value As Double)
                _dblTotal = value
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