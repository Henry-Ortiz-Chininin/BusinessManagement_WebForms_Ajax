Namespace GENERAL
    Public Class EN_Comprobante
        Inherits GENERAL.EN_Empresa

#Region "Variables"
        
        Private _strIdComprobante As String = ""
        Private _intSecuencia As Integer = 0
        Private _strIdMoneda As String = ""
        Private _strIdTipoDoc As String = ""
        Private _strIdVendedor As String = ""
        Private _strIdMotivo As String = ""
        Private _strTipoServicio As String = ""
        Private _strFechaEmision As String = ""
        Private _strFechaVencimiento As String
        Private _strEstado As String = ""
        Private _strIdCliente As String = ""
        Private _strUsuarioCreacion As String = ""
        Private _strFechaCreacion As String
        Private _strUsuarioModificacion As String = ""
        Private _strFechaModificacion As String = ""
        Private _decIGV As Decimal = 0
        Private _decSubTotal As Decimal = 0
        Private _decTotal As Decimal = 0
        Private _decDescuento As Decimal = 0
        Private _decTotalParcial As Decimal = 0
        Private _strTipoPago As String = ""
        Private _strIdTipodocumento As String = ""
        Private _decISC As Decimal = 0
        Private _decValorExportacion As Decimal = 0
        Private _decBaseImponible As Decimal = 0
        Private _decOtrosImportes As Decimal = 0
        Private _decExonerado As Decimal = 0
        Private _decInafecta As Decimal = 0
        Private _strDescripcion As String = ""
        Private _strNumero As String = ""
        Private _decTotalExportado As Decimal = 0
        Private _decTotalBaseImponible As Decimal = 0
        Private _decTotalExonerado As Decimal = 0
        Private _decTotalInafecta As Decimal = 0
        Private _decTotalISC As Decimal = 0
        Private _decTotalIGV As Decimal = 0
        Private _decTotalOtrosImportes As Decimal = 0
        Private _decTotalImportes As Decimal = 0

        Private _strPerido As String
        Private _strTipoDocIdent As String = ""
        Private _strNumeroDocIdent As String = ""
        Private _strNombre As String = ""

        Private _strNumeroDoc2 As String = ""
        Private _strNumeroDoc3 As String = ""
        Private _strNumeroDoc4 As String = ""

#End Region
#Region "Propiedades"

        Public Property Numero() As String
            Get
                Return _strNumero
            End Get
            Set(ByVal value As String)
                _strNumero = value
            End Set
        End Property

        Public Property NumeroDoc2() As String
            Get
                Return _strNumeroDoc2
            End Get
            Set(ByVal value As String)
                _strNumeroDoc2 = value
            End Set
        End Property
        Public Property NumeroDoc3() As String
            Get
                Return _strNumeroDoc3
            End Get
            Set(ByVal value As String)
                _strNumeroDoc3 = value
            End Set
        End Property
        Public Property NumeroDoc4() As String
            Get
                Return _strNumeroDoc4
            End Get
            Set(ByVal value As String)
                _strNumeroDoc4 = value
            End Set
        End Property
        Public Property IdComprobanteVenta() As String
            Get
                Return _strIdComprobante
            End Get
            Set(ByVal value As String)
                _strIdComprobante = value
            End Set
        End Property
        Public Property Secuencia() As Integer
            Get
                Return _intSecuencia
            End Get
            Set(ByVal value As Integer)
                _intSecuencia = value
            End Set
        End Property
        Public Property IdMoneda() As String
            Get
                Return _strIdMoneda
            End Get
            Set(ByVal value As String)
                _strIdMoneda = value
            End Set
        End Property
        Public Property IdTipoDoc() As String
            Get
                Return _strIdTipoDoc
            End Get
            Set(ByVal value As String)
                _strIdTipoDoc = value
            End Set
        End Property
        Public Property IdVendedor() As String
            Get
                Return _strIdVendedor
            End Get
            Set(ByVal value As String)
                _strIdVendedor = value
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
        Public Property TipoServicio() As String
            Get
                Return _strTipoServicio
            End Get
            Set(ByVal value As String)
                _strTipoServicio = value
            End Set
        End Property
        Public Property FechaEmision As String
            Get
                Return _strFechaEmision
            End Get
            Set(ByVal value As String)
                _strFechaEmision = value
            End Set
        End Property
        Public Property FechaVencimiento() As String
            Get
                Return _strFechaVencimiento
            End Get
            Set(ByVal value As String)
                _strFechaVencimiento = value
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
        Public Property FechaCreacionC() As String
            Get
                Return _strFechaCreacion
            End Get
            Set(ByVal value As String)
                _strFechaCreacion = value
            End Set
        End Property
        Public Property FechaModificacionC() As String
            Get
                Return _strFechaModificacion
            End Get
            Set(ByVal value As String)
                _strFechaModificacion = value
            End Set
        End Property
        Public Property IGV() As Decimal
            Get
                Return _decIGV
            End Get
            Set(ByVal value As Decimal)
                _decIGV = value
            End Set
        End Property
        Public Property SubTotal() As Decimal
            Get
                Return _decSubTotal
            End Get
            Set(ByVal value As Decimal)
                _decSubTotal = value
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
        Public Property Descuento() As Decimal
            Get
                Return _decDescuento
            End Get
            Set(ByVal value As Decimal)
                _decDescuento = value
            End Set
        End Property
        Public Property TotalParcial() As Decimal
            Get
                Return _decTotalParcial
            End Get
            Set(ByVal value As Decimal)
                _decTotalParcial = value
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
        Public Property IdTipoDocumento() As String
            Get
                Return _strIdTipodocumento
            End Get
            Set(ByVal value As String)
                _strIdTipodocumento = value
            End Set
        End Property
        Public Property ISC() As Decimal
            Get
                Return _decISC
            End Get
            Set(ByVal value As Decimal)
                _decISC = value
            End Set
        End Property
        Public Property ValorExportacion() As Decimal
            Get
                Return _decValorExportacion
            End Get
            Set(ByVal value As Decimal)
                _decValorExportacion = value
            End Set
        End Property
        Public Property BaseImponible() As Decimal
            Get
                Return _decBaseImponible
            End Get
            Set(ByVal value As Decimal)
                _decBaseImponible = value
            End Set
        End Property
        Public Property OtrosImportes() As Decimal
            Get
                Return _decOtrosImportes
            End Get
            Set(ByVal value As Decimal)
                _decOtrosImportes = value
            End Set
        End Property
        Public Property Exonerado() As Decimal
            Get
                Return _decExonerado
            End Get
            Set(ByVal value As Decimal)
                _decExonerado = value
            End Set
        End Property
        Public Property Inafecta() As Decimal
            Get
                Return _decInafecta
            End Get
            Set(ByVal value As Decimal)
                _decInafecta = value
            End Set
        End Property
        Public Property Descripcion() As String
            Get
                Return _strDescripcion
            End Get
            Set(ByVal value As String)
                _strDescripcion = value
            End Set
        End Property
        Public Property TotalExportado() As Decimal
            Get
                Return _decTotalExportado
            End Get
            Set(ByVal value As Decimal)
                _decTotalExportado = value
            End Set
        End Property
        Public Property TotalBaseImponible() As Decimal
            Get
                Return _decTotalBaseImponible
            End Get
            Set(ByVal value As Decimal)
                _decTotalBaseImponible = value
            End Set
        End Property
        Public Property TotalExonerado() As Decimal
            Get
                Return _decTotalExonerado
            End Get
            Set(ByVal value As Decimal)
                _decTotalExonerado = value
            End Set
        End Property
        Public Property TotalInafecta() As Decimal
            Get
                Return _decTotalInafecta
            End Get
            Set(ByVal value As Decimal)
                _decTotalInafecta = value
            End Set
        End Property
        Public Property TotalISC() As Decimal
            Get
                Return _decTotalISC
            End Get
            Set(ByVal value As Decimal)
                _decTotalISC = value
            End Set
        End Property
        Public Property TotalIGV() As Decimal
            Get
                Return _decTotalIGV
            End Get
            Set(ByVal value As Decimal)
                _decTotalIGV = value
            End Set
        End Property
        Public Property TotalOtrosImportes() As Decimal
            Get
                Return _decTotalOtrosImportes
            End Get
            Set(ByVal value As Decimal)
                _decTotalOtrosImportes = value
            End Set
        End Property
        Public Property TotalImportes() As Decimal
            Get
                Return _decTotalImportes
            End Get
            Set(ByVal value As Decimal)
                _decTotalImportes = value
            End Set
        End Property
        Public Property Periodo() As String
            Get
                Return _strPerido
            End Get
            Set(ByVal value As String)
                _strPerido = value
            End Set
        End Property
        Public Property TipoDocIdent() As String
            Get
                Return _strTipoDocIdent
            End Get
            Set(ByVal value As String)
                _strTipoDocIdent = value
            End Set
        End Property
        Public Property NumeroDocIdent() As String
            Get
                Return _strNumeroDocIdent
            End Get
            Set(ByVal value As String)
                _strNumeroDocIdent = value
            End Set
        End Property
        Public Property NombreCliente() As String
            Get
                Return _strNombre
            End Get
            Set(ByVal value As String)
                _strNombre = value
            End Set
        End Property
#End Region
    End Class
End Namespace