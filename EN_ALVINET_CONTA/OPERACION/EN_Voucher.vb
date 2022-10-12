Imports EN_ALVINET_CONTA.CONFIG
Imports EN_ALVINET_CONTA.GENERAL

Namespace OPERACION

    Public Class EN_Voucher
        Inherits CONFIG.EN_PlanCuenta

#Region "Variables"
        Private _strIdEjercicio As String
        Private _strRetorno As String = ""
        Private _strIdComprobante As String = ""
        Private _strIdEmpresa As String = ""
        Private _ejercicioEmpresa As New EN_EjercicioEmpresa
        Private _strIdContabilidad As String = ""
        Private _strIdProveedor As String = ""
        Private _strProveedor As String = ""
        Private _strIdOperacion As String = ""
        Private _strIdSubOperacion As String = ""
        Private _strSubOperacion As String = ""
        Private _strIdAsiento As String = ""

        Private _strIdCliente As String
        Private _decTipoCambio As Decimal
        Private strIdTipoDocuemnto As String
        Private _strEsAbono As String
        Private _strEsCargo As String
        Private _strRazonSocial As String = ""
        Private _strRuc As String = ""


        Private _strEstado As String = ""
        Private _dtmFecha As Date = Nothing
        Private _strNumerodocumento As String = ""
        Private _idTipoDocumento As New EN_TipoDocumento
        Private _strIdCentroCosto As String = ""
        Private _voucherCuenta As New EN_VoucherCuenta
        Private _strDesOperacion As String = ""
        Private _strDesCentroCosto As String = ""
        Private _strDesCliente As String = ""
        Private _strDesProveedor As String = ""
        Private _cliente As New EN_Cliente
        Private _strDescripcion As String = ""
        Private _strFechaString As String = ""
        Private _empresa As New EN_Empresa
        Private _decAbono As Double
        Private _decCargo As Double
        Private _PlanCuenta As New EN_PlanCuenta
        Private _OperacionCuenta As New EN_OperacionesCuenta
        Private _strIdPlancontable As String = ""
        Private _strNombrePlancontable As String = ""
        Private str_DesTipoDoc As String = ""
        Private _strfecInicio As String
        Private _strFecFin As String
        Private _decTotal As Decimal
        Private _decSubTotal As Decimal
        Private _decIgv As Decimal


        Private _strPeriodoInicial As String = ""

        Private _strPeriodoFinal As String = ""
       




#End Region

#Region "Propiedades"
        Public Property EsAbono As String
            Get
                Return _strEsAbono
            End Get
            Set(ByVal value As String)
                _strEsAbono = value
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
        Public Property SubOperacion As String
            Get
                Return _strSubOperacion
            End Get
            Set(ByVal value As String)
                _strSubOperacion = value
            End Set
        End Property


        Public Property Proveedor As String
            Get
                Return _strProveedor
            End Get
            Set(ByVal value As String)
                _strProveedor = value
            End Set
        End Property
        Public Property IdEjercicio As String
            Get
                Return _strIdEjercicio
            End Get
            Set(ByVal value As String)
                _strIdEjercicio = value
            End Set
        End Property

        Public Property PeriodoFinal() As String
            Get
                Return _strPeriodoFinal
            End Get
            Set(ByVal value As String)
                _strPeriodoFinal = value
            End Set
        End Property


        Public Property PeriodoInicial() As String
            Get
                Return _strPeriodoInicial
            End Get
            Set(ByVal value As String)
                _strPeriodoInicial = value
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


        Public Property DesTipoDocumento() As String
            Get
                Return str_DesTipoDoc
            End Get
            Set(ByVal value As String)
                str_DesTipoDoc = value
            End Set
        End Property

        Public Property IdTipoDocumento() As String
            Get
                Return strIdTipoDocuemnto
            End Get
            Set(ByVal value As String)
                strIdTipoDocuemnto = value
            End Set
        End Property
        Public Property Retorno() As String
            Get
                Return _strRetorno
            End Get
            Set(ByVal value As String)
                _strRetorno = value
            End Set
        End Property

        Public Property NumeroDocumento As String
            Get
                Return _strNumerodocumento
            End Get
            Set(ByVal value As String)
                _strNumerodocumento = value
            End Set
        End Property

        Public Property TipoDocumento() As EN_TipoDocumento
            Get
                Return _idTipoDocumento
            End Get
            Set(ByVal value As EN_TipoDocumento)
                _idTipoDocumento = value
            End Set
        End Property
        Public Property Vouchercuenta() As EN_VoucherCuenta
            Get
                Return _voucherCuenta
            End Get
            Set(ByVal value As EN_VoucherCuenta)
                _voucherCuenta = value
            End Set
        End Property
        Public Property Cliente As EN_Cliente
            Get
                Return _cliente
            End Get
            Set(ByVal value As EN_Cliente)
                _cliente = value
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

        Public Property EjercicioEmpresa() As EN_EjercicioEmpresa
            Get
                Return _ejercicioEmpresa
            End Get
            Set(ByVal value As EN_EjercicioEmpresa)
                _ejercicioEmpresa = value
            End Set
        End Property

        Public Property IdOperacion() As String
            Get
                Return _strIdOperacion
            End Get
            Set(ByVal value As String)
                _strIdOperacion = value
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

        Public Property Fecha As Date
            Get
                Return _dtmFecha
            End Get
            Set(ByVal value As Date)
                _dtmFecha = value
            End Set
        End Property

        Public Property IdCentroCosto() As String
            Get
                Return _strIdCentroCosto
            End Get
            Set(ByVal value As String)
                _strIdCentroCosto = value
            End Set
        End Property


        Public Property DesOperacion() As String
            Get
                Return _strDesOperacion
            End Get
            Set(ByVal value As String)
                _strDesOperacion = value
            End Set
        End Property

        Public Property DesCentroCosto() As String
            Get
                Return _strDesCentroCosto
            End Get
            Set(ByVal value As String)
                _strDesCentroCosto = value
            End Set
        End Property


        Public Property IGV() As Decimal
            Get
                Return _decIgv
            End Get
            Set(ByVal value As Decimal)
                _decIgv = value
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


        Public Property TipoCambio() As Decimal
            Get
                Return _decTipoCambio
            End Get
            Set(ByVal value As Decimal)
                _decTipoCambio = value
            End Set
        End Property

        Public Property Glosa() As String
            Get
                Return _strDescripcion
            End Get
            Set(ByVal value As String)
                _strDescripcion = value
            End Set
        End Property

        Public Property EsCargo() As String
            Get
                Return _strEsCargo
            End Get
            Set(ByVal value As String)
                _strEsCargo = value
            End Set
        End Property

        Public Property Abono As Double
            Get
                Return _decAbono
            End Get
            Set(ByVal value As Double)
                _decAbono = value
            End Set
        End Property

        Public Property Cargo As String
            Get
                Return _decCargo
            End Get
            Set(ByVal value As String)
                _decCargo = value
            End Set
        End Property
        Public Property PlanCuenta As EN_PlanCuenta
            Get
                Return _PlanCuenta
            End Get
            Set(ByVal value As EN_PlanCuenta)
                _PlanCuenta = value
            End Set
        End Property
        Public Property OperacionCuenta As EN_OperacionesCuenta
            Get
                Return _OperacionCuenta
            End Get
            Set(ByVal value As EN_OperacionesCuenta)
                _OperacionCuenta = value
            End Set
        End Property

        Public Property Fecinicio() As String
            Get
                Return _strfecInicio
            End Get
            Set(ByVal value As String)
                _strfecInicio = value
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

        Public Property FecFinal() As String
            Get
                Return _strFecFin
            End Get
            Set(ByVal value As String)
                _strFecFin = value
            End Set
        End Property


#End Region

    End Class
End Namespace