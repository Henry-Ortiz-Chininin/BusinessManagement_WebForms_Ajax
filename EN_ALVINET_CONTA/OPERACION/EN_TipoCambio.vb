Namespace OPERACION

    Public Class EN_TipoCambio
        Inherits GENERAL.EN_Empresa

#Region "Variables"
        Private _strIdEmpresa As String = ""
        Private _strRazonSocial As String = ""
        Private _strIdTipoCambio As String = ""
        Private _dtmFecha As DateTime
        Private _decCompra As Decimal = 0
        Private _decVenta As Decimal = 0
        Private _strIdMoneda As String = ""
        Private _strDescripcion As String = ""
        Private _strFechaString As String = ""
#End Region
#Region "Propiedades"
        Public Property IdEmpresa() As String
            Get
                Return _strIdEmpresa
            End Get
            Set(ByVal value As String)
                _strIdEmpresa = value
            End Set
        End Property

        Public Property RazonSocial() As String
            Get
                Return _strRazonSocial
            End Get
            Set(ByVal value As String)
                _strRazonSocial = value
            End Set
        End Property
        Public Property IdTipoCambio() As String
            Get
                Return _strIdTipoCambio
            End Get
            Set(ByVal value As String)
                _strIdTipoCambio = value
            End Set
        End Property


        Public Property FechaString() As String
            Get
                Return _strFechaString
            End Get
            Set(ByVal value As String)
                _strFechaString = value
            End Set
        End Property

        Public Property Fecha() As DateTime
            Get
                Return _dtmFecha
            End Get
            Set(ByVal value As DateTime)
                _dtmFecha = value
            End Set
        End Property
        Public Property Compra() As Decimal
            Get
                Return _decCompra
            End Get
            Set(ByVal value As Decimal)
                _decCompra = value
            End Set
        End Property
        Public Property Venta() As Decimal
            Get
                Return _decVenta
            End Get
            Set(ByVal value As Decimal)
                _decVenta = value
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

        Public Property DescMoneda As String
            Get
                Return _strDescripcion
            End Get
            Set(ByVal value As String)
                _strDescripcion = value
            End Set
        End Property
#End Region

    End Class
End Namespace