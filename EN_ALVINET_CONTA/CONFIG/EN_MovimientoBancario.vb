Imports EN_ALVINET_CONTA.GENERAL
Imports EN_ALVINET_CONTA.CONFIG
Namespace CONFIG


    Public Class EN_MovimientoBancario
        Inherits OPERACION.EN_OperacionCuenta

#Region "Variables"

        Private _strIdMovimiento As String
        Private _strIdBanco As String = ""
        Private _strIdMedioPago As String = ""
        Private _strEsCargo As String
        Private _decSaldo As Decimal = 0
        Private _strComprobante As String
        Private _decImporte As Decimal = 0
        Private _strFecha As String = ""
        Private _strIdMoneda As String
        Private _strMoneda As String
        Private _decTotal As Decimal = 0

        Private _Cuentaentidad As New EN_CuentaEntidad
        Private _strObservacion As String = ""
        Private _strNombreBanco As String
        Private _strIdDocumentoCompra As String
        Private _strIdcomProvante As String

        Private _strEsAbono As String = ""
        Private _strCargo As String = ""



#End Region
#Region "Propiedades"

        Public Property IdMedioPago As String
            Get
                Return _strIdMedioPago
            End Get
            Set(ByVal value As String)
                _strIdMedioPago = value
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

        Public Property Fecha As String
            Get
                Return _strFecha
            End Get
            Set(ByVal value As String)
                _strFecha = value
            End Set
        End Property
        Public Property IdMovimiento As String
            Get
                Return _strIdMovimiento
            End Get
            Set(ByVal value As String)
                _strIdMovimiento = value
            End Set
        End Property

        Public Property Cargo() As String
            Get
                Return _strCargo
            End Get
            Set(ByVal value As String)
                _strCargo = value
            End Set
        End Property

        Public Property Total() As Decimal
            Get
                Return _decTotal
            End Get
            Set(ByVal value As Decimal)
                _decTotal = value
            End Set
        End Property


        Public Property Saldo() As String
            Get
                Return _decSaldo
            End Get
            Set(ByVal value As String)
                _decSaldo = value
            End Set
        End Property

        Public Property NombreBanco() As String
            Get
                Return _strNombreBanco
            End Get
            Set(ByVal value As String)
                _strNombreBanco = value
            End Set
        End Property

        Public Property IdBanco() As String
            Get
                Return _strIdBanco
            End Get
            Set(ByVal value As String)
                _strIdBanco = value
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


        Public Property Comprobante() As String
            Get
                Return _strIdcomProvante
            End Get
            Set(ByVal value As String)
                _strIdcomProvante = value
            End Set
        End Property

#End Region
    End Class
End Namespace
