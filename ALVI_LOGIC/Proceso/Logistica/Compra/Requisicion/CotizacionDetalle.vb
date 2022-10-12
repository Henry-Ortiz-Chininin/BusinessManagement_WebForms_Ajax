

Imports AccesoDatos
Imports ALVI_LOGIC

Namespace Proceso.Logistica.Compra.Requisicion
    Public Class CotizacionDetalle

        Private _strIdCotizacion As String
        Private _strIdRequision As String
        Private _strIdUnidadMedida As String
        Private _strDescripcionUnidadMedida As String
        Private _strFechaEmision As String
        Private _strIdArticulo As String
        Private _strDescripcionArticulo As String
        Private _strNombreArchivo As String
        Private _strObservacion As String
        Private _strProveedor As String
        Private _intCantidad As Integer
        Private _strArchivo As String
        Private _dtbDatos As DataTable
        Private _strEstado As String

        Private _strUsuario As String

        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer




        Public Property IdRequisicion() As String
            Get
                Return _strIdRequision
            End Get
            Set(ByVal value As String)
                _strIdRequision = value
            End Set
        End Property



        Public Property Archivo() As String
            Get
                Return _strArchivo
            End Get
            Set(ByVal value As String)
                _strArchivo = value
            End Set
        End Property


        Public Property IdCotizacion() As String
            Get
                Return _strIdCotizacion
            End Get
            Set(ByVal value As String)
                _strIdCotizacion = value
            End Set
        End Property


        Public Property NombrerArchivo() As String
            Get
                Return _strNombreArchivo
            End Get
            Set(ByVal value As String)
                _strNombreArchivo = value
            End Set
        End Property

        Public Property Proveedor() As String
            Get
                Return _strProveedor
            End Get
            Set(ByVal value As String)
                _strProveedor = value
            End Set
        End Property


        Public Property Observacion() As String
            Get
                Return _strObservacion
            End Get
            Set(ByVal value As String)
                _strObservacion = value
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


        Public Property IdUnidadMedida() As String
            Get
                Return _strIdUnidadMedida
            End Get
            Set(ByVal value As String)
                _strIdUnidadMedida = value
            End Set
        End Property
        Public Property DescripcionUnidadMedida() As String
            Get
                Return _strDescripcionUnidadMedida
            End Get
            Set(ByVal value As String)
                _strDescripcionUnidadMedida = value
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




        Public Property Estado() As String
            Get
                Return _strEstado
            End Get
            Set(ByVal value As String)
                _strEstado = value
            End Set
        End Property

        Public Property DescripcionArticulo() As String
            Get
                Return _strDescripcionArticulo
            End Get
            Set(ByVal value As String)
                _strDescripcionArticulo = value
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


        Public Property FechaEmision() As String
            Get
                Return _strFechaEmision
            End Get
            Set(ByVal value As String)
                _strFechaEmision = value
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
                Dim objParametros() As String = {"var_IdRequisicion", _strIdRequision}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Requisicion_Buscar1", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Listar1() As Boolean
            Try
                Dim objParametros() As String = {"var_IdCotizacion", _strIdCotizacion}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_CotizacionDetalle_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function





    End Class
End Namespace