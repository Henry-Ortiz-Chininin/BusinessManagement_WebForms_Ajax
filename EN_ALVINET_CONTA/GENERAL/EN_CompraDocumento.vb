Namespace GENERAL

    Public Class EN_CompraDocumento
        Inherits CONFIG.EN_Proveedor

#Region "Variables"
        Private _strIdEjercicioEmpresa As String = ""
        Private str_EsControlada As String = ""

        Private _strIdContabilidad As String = ""
        Private _strError As String = ""
        Private _strIdEmpresa As String = ""
        Private _strIdDocumentoCompra As String = ""
        Private _strIdTipoDocumento As String = ""
        Private _strFechaEmision As String = ""
        Private _strIdProveedor As String = ""
        Private _strObservasion As String = ""
        Private _strEstado As String = ""
        Private _dblTipoCambio As Decimal = 0
        Private _dblImporteTotal As Decimal = 0
        Private _dblImporteOrigenDC As Decimal = 0
        Private _strMoneda As String = ""
        Private _intNumero1 As Integer = 0
        Private _intNumero2 As Integer = 0
        Private _intNumeroRC1 As Integer = 0
        Private _intNumeroRC2 As Integer = 0
        Private _dblSubtotal As Decimal = 0
        Private _dblIGV As Decimal = 0
        Private _dblIGV2 As Decimal = 0
        Private _dblIGV3 As Decimal = 0
        Private _dblOtros As Decimal = 0
        Private _dblTotal As Decimal = 0
        Private _strFechaVencimiento As String = 0
        Private _strOperacion As String = 0
        Private _dblISC As Decimal = 0
        Private _dblBaseImponible As Decimal = 0
        Private _dblBaseImponible2 As Decimal = 0
        Private _dblBaseImponible3 As Decimal = 0
        Private _strFechaModificacion As String = ""
        Private _dblAdquisisiomes As Decimal = 0
        Private _strNumeroDetraccion As String = ""
        Private _strFechaDetraccion As String = ""
        Private _strIdAsiento As String = ""
        Private _strDescripcionProveedor As String = ""
        Private _strTipoDocumento As String = ""
        Private _strUsuario As String = ""
        Private _exError As Exception
        Private _strNumero As String = ""
        Private _dtbDatos As DataTable
        Private _strFechaFin As String = ""
        Private _strFechaInicio As String = ""
        Private _strAñoDua As String = ""
        Private _strNumDocIdenPro As String = ""
        Private _strIdDocIdenPro As String = ""
        Private _strNumComproSujNoDom As String = ""
        Private _strPeriodo As String = ""
        Private _strRucEm As String = ""
        Private _strRazonSocialEm As String = ""
        Private _dblTotalImporteTotal As Double = 0
        Private _dblTotalOtros As Double = 0
        Private _dblTotalISC As Double = 0
        Private _dblTotalAdquisision As Double = 0
        Private _dblTotalIGV3 As Double = 0
        Private _dblTotalBaseImponible3 As Double = 0
        Private _dblTotalIGV2 As Double = 0
        Private _dblTotalBaseImponible2 As Double = 0
        Private _dblTotalIGV1 As Double = 0
        Private _dblTotalBaseImponible1 As Double = 0
        Private _strIdTipoDocumentoRC As String = ""
        Private _strContactoCredito As String = ""
        Private _strCuotas As String = ""
        Private _strMontoCuota As String = ""
        Private _strIdCuota As String = ""
        Private _intCont As Integer
        Private _strIdCuenta As String
        Private str_IdComprobante As String
#End Region

#Region "Propiedades"

        Public Property TipoCambio As Decimal
            Get
                Return _dblTipoCambio
            End Get
            Set(ByVal value As Decimal)
                _dblTipoCambio = value
            End Set
        End Property

        Public Property IdComprobante() As String
            Get
                Return str_IdComprobante
            End Get
            Set(ByVal value As String)
                str_IdComprobante = value
            End Set
        End Property
        Public Property EsControlada() As String
            Get
                Return str_EsControlada
            End Get
            Set(ByVal value As String)
                str_EsControlada = value
            End Set
        End Property

        Public Property IdAsiento() As String
            Get
                Return _strIdAsiento
            End Get
            Set(ByVal value As String)
                _strIdAsiento = value
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

        Public Property IdContabilidad() As String
            Get
                Return _strIdContabilidad
            End Get
            Set(ByVal value As String)
                _strIdContabilidad = value
            End Set
        End Property

        Public Property IdEjercicioEmpresa() As String
            Get
                Return _strIdEjercicioEmpresa
            End Get
            Set(ByVal value As String)
                _strIdEjercicioEmpresa = value
            End Set
        End Property
        Public Property MenjError() As String
            Get
                Return _strError
            End Get
            Set(ByVal value As String)
                _strError = value
            End Set
        End Property

        Public Property IdEmpresaDC() As String
            Get
                Return _strIdEmpresa
            End Get
            Set(ByVal value As String)
                _strIdEmpresa = value
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
        Public Property IdTipoDocumento() As String
            Get
                Return _strIdTipoDocumento
            End Get
            Set(ByVal value As String)
                _strIdTipoDocumento = value
            End Set
        End Property
        Public Property IdProveedor() As String
            Get
                Return _strIdProveedor
            End Get
            Set(ByVal value As String)
                _strIdProveedor = value
            End Set
        End Property
        Public Property Observasion() As String
            Get
                Return _strObservasion
            End Get
            Set(ByVal value As String)
                _strObservasion = value
            End Set
        End Property
        Public Property DescripcionProveedor() As String
            Get
                Return _strDescripcionProveedor
            End Get
            Set(ByVal value As String)
                _strDescripcionProveedor = value
            End Set
        End Property


        Private _decSaldo As Decimal
        Public Property Saldo() As Decimal
            Get
                Return _decSaldo
            End Get
            Set(ByVal value As Decimal)
                _decSaldo = value
            End Set
        End Property

        Private _decPago As Decimal
        Public Property Pago() As Decimal
            Get
                Return _decPago
            End Get
            Set(ByVal value As Decimal)
                _decPago = value
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
        Public Property IGV2() As Double
            Get
                Return _dblIGV2
            End Get
            Set(ByVal value As Double)
                _dblIGV2 = value
            End Set
        End Property
        Public Property IGV3() As Double
            Get
                Return _dblIGV3
            End Get
            Set(ByVal value As Double)
                _dblIGV3 = value
            End Set
        End Property
        Public Property Importetotal() As Double
            Get
                Return _dblImporteTotal
            End Get
            Set(ByVal value As Double)
                _dblImporteTotal = value
            End Set
        End Property
        Public Property ImporteOrigenDC() As Decimal
            Get
                Return _dblImporteOrigenDC
            End Get
            Set(ByVal value As Decimal)
                _dblImporteOrigenDC = value
            End Set
        End Property
        Public Property Otros() As Decimal
            Get
                Return _dblOtros
            End Get
            Set(ByVal value As Decimal)
                _dblOtros = value
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

        Public Property Total() As Decimal
            Get
                Return _dblTotal
            End Get
            Set(ByVal value As Decimal)
                _dblTotal = value
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
        Public Property FechaEmision() As String
            Get
                Return _strFechaEmision
            End Get
            Set(ByVal value As String)
                _strFechaEmision = value
            End Set
        End Property
        Public Property ISC() As Decimal
            Get
                Return _dblISC
            End Get
            Set(ByVal value As Decimal)
                _dblISC = value
            End Set
        End Property
        Public Property BaseImponible() As Decimal
            Get
                Return _dblBaseImponible
            End Get
            Set(ByVal value As Decimal)
                _dblBaseImponible = value
            End Set
        End Property
        Public Property BaseImponible2() As Decimal
            Get
                Return _dblBaseImponible2
            End Get
            Set(ByVal value As Decimal)
                _dblBaseImponible2 = value
            End Set
        End Property
        Public Property BaseImponible3() As Decimal
            Get
                Return _dblBaseImponible3
            End Get
            Set(ByVal value As Decimal)
                _dblBaseImponible3 = value
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
        Public Property FechaModificacion() As String
            Get
                Return _strFechaModificacion
            End Get
            Set(ByVal value As String)
                _strFechaModificacion = value
            End Set
        End Property
        Public Property Numero1() As Integer
            Get
                Return _intNumero1
            End Get
            Set(ByVal value As Integer)
                _intNumero1 = value
            End Set
        End Property
        Public Property Numero2() As Integer
            Get
                Return _intNumero2
            End Get
            Set(ByVal value As Integer)
                _intNumero2 = value
            End Set
        End Property
        Public Property NumeroRC1() As Integer
            Get
                Return _intNumeroRC1
            End Get
            Set(ByVal value As Integer)
                _intNumeroRC1 = value
            End Set
        End Property
        Public Property NumeroRC2() As Integer
            Get
                Return _intNumeroRC2
            End Get
            Set(ByVal value As Integer)
                _intNumeroRC2 = value
            End Set
        End Property
        Public Property Datos() As DataTable
            Get
                Return _dtbDatos
            End Get
            Set(ByVal value As DataTable)
                _dtbDatos = value
            End Set
        End Property
        Public Property Numero() As String
            Get
                Return _strNumero
            End Get
            Set(ByVal value As String)
                _strNumero = value
            End Set
        End Property
        Public Property TipoDocumento() As String
            Get
                Return _strTipoDocumento
            End Get
            Set(ByVal value As String)
                _strTipoDocumento = value
            End Set
        End Property
        Public Property MonedaDC() As String
            Get
                Return _strMoneda
            End Get
            Set(ByVal value As String)
                _strMoneda = value
            End Set
        End Property
        Public Property Operacion() As String
            Get
                Return _strOperacion
            End Get
            Set(ByVal value As String)
                _strOperacion = value
            End Set
        End Property
        'Public ReadOnly Property exError() As String
        '    Get
        '        Return _exError.ToString
        '    End Get
        'End Property
        Public Property Adquisisiones() As Decimal
            Get
                Return _dblAdquisisiomes
            End Get
            Set(ByVal value As Decimal)
                _dblAdquisisiomes = value
            End Set
        End Property
        Public Property NumeroDetraccion() As String
            Get
                Return _strNumeroDetraccion
            End Get
            Set(ByVal value As String)
                _strNumeroDetraccion = value
            End Set
        End Property
        Public Property FechaDetraccion() As String
            Get
                Return _strFechaDetraccion
            End Get
            Set(ByVal value As String)
                _strFechaDetraccion = value
            End Set
        End Property
        Public Property FechaFin() As String
            Get
                Return _strFechaFin
            End Get
            Set(ByVal value As String)
                _strFechaFin = value
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
        Public Property AnioDua() As String
            Get
                Return _strAñoDua
            End Get
            Set(ByVal value As String)
                _strAñoDua = value
            End Set
        End Property
        Public Property NumDocIdenPro() As String
            Get
                Return _strNumDocIdenPro
            End Get
            Set(ByVal value As String)
                _strNumDocIdenPro = value
            End Set
        End Property
        Public Property IdDocIdenPro() As String
            Get
                Return _strIdDocIdenPro
            End Get
            Set(ByVal value As String)
                _strIdDocIdenPro = value
            End Set
        End Property
        Public Property NumComproSujNoDom() As String
            Get
                Return _strNumComproSujNoDom
            End Get
            Set(ByVal value As String)
                _strNumComproSujNoDom = value
            End Set
        End Property
        Public Property Periodo() As String
            Get
                Return _strPeriodo
            End Get
            Set(ByVal value As String)
                _strPeriodo = value
            End Set
        End Property
        Public Property RucEm() As String
            Get
                Return _strRucEm
            End Get
            Set(ByVal value As String)
                _strRucEm = value
            End Set
        End Property
        Public Property RazonSocialEm() As String
            Get
                Return _strRazonSocialEm
            End Get
            Set(ByVal value As String)
                _strRazonSocialEm = value
            End Set
        End Property
        Public Property TotalImporteTotal() As Double
            Get
                Return _dblTotalImporteTotal
            End Get
            Set(ByVal value As Double)
                _dblTotalImporteTotal = value
            End Set
        End Property
        Public Property TotalOtros() As Double
            Get
                Return _dblTotalOtros
            End Get
            Set(ByVal value As Double)
                _dblTotalOtros = value
            End Set
        End Property
        Public Property TotalISC() As Double
            Get
                Return _dblTotalISC
            End Get
            Set(ByVal value As Double)
                _dblTotalISC = value
            End Set
        End Property
        Public Property TotalAdquisision() As Double
            Get
                Return _dblTotalAdquisision
            End Get
            Set(ByVal value As Double)
                _dblTotalAdquisision = value
            End Set
        End Property
        Public Property TotalIGV3() As Double
            Get
                Return _dblTotalIGV3
            End Get
            Set(ByVal value As Double)
                _dblTotalIGV3 = value
            End Set
        End Property
        Public Property TotalBaseImponible3() As String
            Get
                Return _dblTotalBaseImponible3
            End Get
            Set(ByVal value As String)
                _dblTotalBaseImponible3 = value
            End Set
        End Property
        Public Property TotalIGV2() As Double
            Get
                Return _dblTotalIGV2
            End Get
            Set(ByVal value As Double)
                _dblTotalIGV2 = value
            End Set
        End Property
        Public Property TotalBaseImponible2() As Double
            Get
                Return _dblTotalBaseImponible2
            End Get
            Set(ByVal value As Double)
                _dblTotalBaseImponible2 = value
            End Set
        End Property
        Public Property TotalIGV1() As Double
            Get
                Return _dblTotalIGV1
            End Get
            Set(ByVal value As Double)
                _dblTotalIGV1 = value
            End Set
        End Property
        Public Property TotalBaseImponible1() As Double
            Get
                Return _dblTotalBaseImponible1
            End Get
            Set(ByVal value As Double)
                _dblTotalBaseImponible1 = value
            End Set
        End Property

        Public Property IdTipoDocumentoRC() As String
            Get
                Return _strIdTipoDocumentoRC
            End Get
            Set(ByVal value As String)
                _strIdTipoDocumentoRC = value
            End Set
        End Property
        Public Property ContactoCredito() As String
            Get
                Return _strContactoCredito
            End Get
            Set(ByVal value As String)
                _strContactoCredito = value
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
        Public Property IdCuota() As String
            Get
                Return _strIdCuota
            End Get
            Set(ByVal value As String)
                _strIdCuota = value
            End Set
        End Property

#End Region
    End Class
End Namespace