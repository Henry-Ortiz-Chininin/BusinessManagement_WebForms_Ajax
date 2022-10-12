Imports EN_ALVINET_CONTA.GENERAL
Namespace CONFIG

    Public Class EN_MovimientoCaja
        Inherits OPERACION.EN_OperacionCuenta

#Region "Variables"

        Private _strIdCaja As String = ""
        Private _strComprobante As String
        Private _decImporte As Decimal = 0
        Private dtm_Fecha As DateTime
        Private _strFechaString As String = ""
        Public _objMoneda As New EN_Moneda
        Private _strObservacion As String = ""
        Private _decTotalC As Decimal
        Private _decPagoC As Decimal
        Private _decSaldoC As Decimal
        Private _decTotalV As Decimal
        Private _decPagoV As Decimal
        Private _decSaldoV As Decimal



        Public Property Comprobante() As String
            Get
                Return _strComprobante
            End Get
            Set(ByVal value As String)
                _strComprobante = value
            End Set
        End Property


#End Region
#Region "Propiedades"

        Public Property IdCaja() As String
            Get
                Return _strIdCaja
            End Get
            Set(ByVal value As String)
                _strIdCaja = value
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
                Return dtm_Fecha
            End Get
            Set(ByVal value As DateTime)
                dtm_Fecha = value
            End Set
        End Property

        Public Property IdBanco() As String
            Get
                Return _strIdCaja
            End Get
            Set(ByVal value As String)
                _strIdCaja = value
            End Set
        End Property

        Public Property SaldoV() As Decimal
            Get
                Return _decSaldoV
            End Get
            Set(ByVal value As Decimal)
                _decSaldoV = value
            End Set
        End Property

        Public Property PagoV() As Decimal
            Get
                Return _decPagoV
            End Get
            Set(ByVal value As Decimal)
                _decPagoV = value
            End Set
        End Property

        Public Property TotalV() As Decimal
            Get
                Return _decTotalV
            End Get
            Set(ByVal value As Decimal)
                _decTotalV = value
            End Set
        End Property

        Public Property SaldoC() As Decimal
            Get
                Return _decSaldoC
            End Get
            Set(ByVal value As Decimal)
                _decSaldoC = value
            End Set
        End Property

        Public Property PagoC() As Decimal
            Get
                Return _decPagoC
            End Get
            Set(ByVal value As Decimal)
                _decPagoC = value
            End Set
        End Property

        Public Property TotalC() As Decimal
            Get
                Return _decTotalC
            End Get
            Set(ByVal value As Decimal)
                _decTotalC = value
            End Set
        End Property



#End Region
    End Class

End Namespace
