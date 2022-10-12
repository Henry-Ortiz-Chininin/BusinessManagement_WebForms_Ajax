Namespace OPERACION

    Public Class EN_VoucherCuenta
        Inherits EN_Voucher
#Region "Variables"
        Private _strIdOperacionCuenta As String = ""
        Private _strIdEmpresa As String = ""
        Private _strIdEjercicioEmpresa As String = ""
        Private _strIcontabilidad As String = ""
        Private _strIdOperacion As String = ""
        Private _strIdAsiento As String = ""
        Private _strIdCuenta As String = ""
        Private _strEsCargo As String = ""
        Private _decImporte As Decimal
        Private _strObservacion As String = ""
        Private _strFlag As String = ""
        Private _decTotalH As Decimal = 0

        Private _decTotalD As Decimal = 0


        Private _strCodContabilidad As String = ""
        Private _strCodOperacion As String = ""
        Private _strIdVenta As String = ""
        Private _strIdCompras As String = ""
        Private _strIdConciliacion As String = ""



#End Region
#Region "Propiedades"

       
        Public Property TotalD() As Decimal
            Get
                Return _decTotalD
            End Get
            Set(ByVal value As Decimal)
                _decTotalD = value
            End Set
        End Property

        Public Property TotalH() As Decimal
            Get
                Return _decTotalH
            End Get
            Set(ByVal value As Decimal)
                _decTotalH = value
            End Set
        End Property
        Public Property IdConciliacion() As String
            Get
                Return _strIdConciliacion
            End Get
            Set(ByVal value As String)
                _strIdConciliacion = value
            End Set
        End Property

        Private _strcuentaIni As String

        Private _strcuentaFin As String
        Public Property CuentaFin() As String
            Get
                Return _strcuentaFin
            End Get
            Set(ByVal value As String)
                _strcuentaFin = value
            End Set
        End Property

        Public Property CuentaIni() As String
            Get
                Return _strcuentaIni
            End Get
            Set(ByVal value As String)
                _strcuentaIni = value
            End Set
        End Property

        Public Property IdVenta() As String
            Get
                Return _strIdVenta
            End Get
            Set(ByVal value As String)
                _strIdVenta = value
            End Set
        End Property
        Public Property IdCompras() As String
            Get
                Return _strIdCompras
            End Get
            Set(ByVal value As String)
                _strIdCompras = value
            End Set
        End Property
#End Region

    End Class
End Namespace