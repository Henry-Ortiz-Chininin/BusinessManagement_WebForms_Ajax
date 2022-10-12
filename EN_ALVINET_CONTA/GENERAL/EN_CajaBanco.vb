Namespace GENERAL

    Public Class EN_CajaBanco
        Inherits EN_Moneda


#Region "Variables"
        Private _strIdMovimiento As String = ""
        Private _strIdEntidadFinanciera As String = ""
        Private _strIdTipoComprobante As String = ""
        Private _strComprobante As String = ""
        Private _dblImporte As Double = 0
        Private _strFecha As String = ""
        Private _strIdMoneda As String = ""
        Private _strObservacion As String = ""
        Private _strIdMedioPago As String = ""
        Private _strIdCliente As String = ""
        Private _strIdProveedor As String = ""
        Private _strIdTipoDocumento As String = ""
        Private _strNumeroDocumento As String = ""
        Private _strIdOperacion As String = ""
        Private _strIdSubOperacion As String = ""
#End Region


#Region "Propiedades"
        Public Property IdMovimiento As String
            Get
                Return _strIdMovimiento
            End Get
            Set(ByVal value As String)
                _strIdMovimiento = value
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
        Public Property IdTipoComprobante As String
            Get
                Return _strIdTipoComprobante
            End Get
            Set(ByVal value As String)
                _strIdTipoComprobante = value
            End Set
        End Property
        Public Property Comprobante As String
            Get
                Return _strComprobante
            End Get
            Set(ByVal value As String)
                _strComprobante = value
            End Set
        End Property
        Public Property Importe As Double
            Get
                Return _dblImporte
            End Get
            Set(ByVal value As Double)
                _dblImporte = value
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
        Public Property IdMoneda As String
            Get
                Return _strIdMoneda
            End Get
            Set(ByVal value As String)
                _strIdMoneda = value
            End Set
        End Property
        Public Property Observacion As String
            Get
                Return _strObservacion
            End Get
            Set(ByVal value As String)
                _strObservacion = value
            End Set
        End Property
        Public Property IdMedioPago As String
            Get
                Return _strIdMedioPago
            End Get
            Set(ByVal value As String)
                _strIdMedioPago = value
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
        Public Property IdProveedor As String
            Get
                Return _strIdProveedor
            End Get
            Set(ByVal value As String)
                _strIdProveedor = value
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
        Public Property IdOperacion As String
            Get
                Return _strIdOperacion
            End Get
            Set(ByVal value As String)
                _strIdOperacion = value
            End Set
        End Property
        Public Property IdSubOperacion As String
            Get
                Return _strIdSubOperacion
            End Get
            Set(ByVal value As String)
                _strIdSubOperacion = value
            End Set
        End Property
      

#End Region

    End Class

End Namespace
