
Namespace CONFIG


    Public Class EN_Conciliacion
        Inherits EN_MovimientoBancario

#Region "Variables"
        Private _strId As String
        Private _strIdBanco As String
        Private _strNombreBanco As String
        Private _strIdCaja As String
        Private _strNombreCaja As String
        Private _strIdTipoDoc As String
        Private _strNomTipodoc As String
        Private _strIdCliente As String
        Private _strNombreCliente As String
        Private _strIdProveedor As String
        Private _strNombreProveedor As String
        Private _strNumeroDoc As String
        Private _intCont As Integer
        Private _strIdCuenta As String
        Private _strIdComprobante As String
        Private _strIdDocumentoCompra As String
        Private _strIddocumentoVenta As String



#End Region

#Region "Propiedades"


        Public Property IdComprobante() As String
            Get
                Return _strIdComprobante
            End Get
            Set(ByVal value As String)
                _strIdComprobante = value
            End Set
        End Property

        Public Property IdConciliacion() As String
            Get
                Return _strId
            End Get
            Set(ByVal value As String)
                _strId = value
            End Set
        End Property
        Public Property NombreProveedor() As String
            Get
                Return _strNombreProveedor
            End Get
            Set(ByVal value As String)
                _strNombreProveedor = value
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

        Public Property NombreCliente() As String
            Get
                Return _strNombreCliente
            End Get
            Set(ByVal value As String)
                _strNombreCliente = value
            End Set
        End Property

        Private _strNumeroDocumento As String


        Public Property NomTipodoc() As String
            Get
                Return _strNomTipodoc
            End Get
            Set(ByVal value As String)
                _strNomTipodoc = value
            End Set
        End Property

        Public Property IdCuenta() As String
            Get
                Return _strIdCuenta
            End Get
            Set(ByVal value As String)
                _strIdCuenta = value
            End Set
        End Property

        Public Property NumeroDoc() As String
            Get
                Return _strNumeroDoc
            End Get
            Set(ByVal value As String)
                _strNumeroDoc = value
            End Set
        End Property

        Public Property IdTipodoc() As String
            Get
                Return _strIdTipoDoc
            End Get
            Set(ByVal value As String)
                _strIdTipoDoc = value
            End Set
        End Property

        Public Property IdCaja() As String
            Get
                Return _strIdCaja
            End Get
            Set(ByVal value As String)
                _strIdCaja = value
            End Set
        End Property
        Public Property NombreCaja() As String
            Get
                Return _strNombreCaja
            End Get
            Set(ByVal value As String)
                _strNombreCaja = value
            End Set
        End Property

        Public Property IddocumentoVenta() As String
            Get
                Return _strIddocumentoVenta
            End Get
            Set(ByVal value As String)
                _strIddocumentoVenta = value
            End Set
        End Property


#End Region
    End Class
End Namespace
