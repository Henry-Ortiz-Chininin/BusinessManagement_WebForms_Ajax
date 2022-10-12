Imports AccesoDatos
Imports ALVI_LOGIC
Namespace Proceso.Logistica
    Public Class Detalle

        Private _strIdDocumentoCompra As String
        Private _strIdDetalle As String
        Private _strIdArticulo As String
        Private _strIdArticuloProveedor As String
        Private _strNombreArticuloProveedor As String
        Private _strIdUnidadMedida As String
        Private _dblTipoCambio As Double
        Private _dblImporte As Double
        Private _dblImporteOrigen As Double
        Private _strMoneda As String
        Private _intCantidad As Integer
        Private _strFechaVencimiento As String
        Private _strTipoDocumento As String

        Private _strEstado As String
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer
        Private _strNumero As String
        Private _dtbDatos As DataTable
        Private _strFechaEmision As String



        Public Property IdDocumentoCompra() As String
            Get
                Return _strIdDocumentoCompra
            End Get
            Set(ByVal value As String)
                _strIdDocumentoCompra = value
            End Set
        End Property
        Public Property IdDetalle() As String
            Get
                Return _strIdDetalle
            End Get
            Set(ByVal value As String)
                _strIdDetalle = value
            End Set
        End Property

        Public Property IdArticulo() As String
            Get
                Return _strIdArticulo
            End Get
            Set(ByVal value As String)
                _strIdArticulo = value
            End Set
        End Property

        Public Property IdArticuloProveedor() As String
            Get
                Return _strIdArticuloProveedor
            End Get
            Set(ByVal value As String)
                _strIdArticuloProveedor = value
            End Set
        End Property

        Public Property NombreArticuloProveedor() As String
            Get
                Return _strNombreArticuloProveedor
            End Get
            Set(ByVal value As String)
                _strNombreArticuloProveedor = value
            End Set
        End Property
        Public Property IdUnidadMedida() As String
            Get
                Return _strIdUnidadMedida
            End Get
            Set(ByVal value As String)
                _strIdUnidadMedida = value
            End Set
        End Property

        Public Property TipoCambio As Double
            Get
                Return _dblTipoCambio
            End Get
            Set(ByVal value As Double)
                _dblTipoCambio = value
            End Set
        End Property
        Public Property Cantidad() As Integer
            Get
                Return _intCantidad
            End Get
            Set(ByVal value As Integer)
                _intCantidad = value
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


        Public Property ImporteOrigen() As Double
            Get
                Return _dblImporteOrigen
            End Get
            Set(ByVal value As Double)
                _dblImporteOrigen = value
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


        Public Property Datos() As DataTable
            Get
                Return _dtbDatos
            End Get
            Set(ByVal value As DataTable)
                _dtbDatos = value
            End Set
        End Property




        Public Function Listar() As Boolean
            Try
                Dim objParametros() As String = {"var_IdDocumentoCompra", _strIdDocumentoCompra}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspa_DocumentoCompraDetalle_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
    End Class
End Namespace
