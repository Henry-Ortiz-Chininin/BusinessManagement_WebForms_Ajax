Imports AccesoDatos
Imports ALVI_LOGIC
Namespace Maestros.Logistica
    Public Class Compra

        Private _strIdOrdenCompra As String
        Private _strIdArticulo As String
        Private _strIdProveedor As String
        Private _strDescripcionProveedor As String
        Private _strDescripcionArticulo As String
        Private _strIdTipo As String
        Private _strIdUnidadMedida As String
        Private _strDescripcionUnidadMedida As String
        Private _strFechaEmision As String
        Private _strFechaEntrega As String
        Private _intCantidad As Integer
        Private _numPrecioReferencia As Double
        Private _strObservacion As String
        Private _strObservacionDocumento As String
        Private _strTermino As String
        Private _strIdSolicitante As String

        Private _strIdCentroCosto As String
        Private _strDescripcionCentroCosto As String

        Private _strEstado As String
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer
        Private _intNumero As Integer







        Public Property IdArticulo() As String
            Get
                Return _strIdArticulo
            End Get
            Set(ByVal value As String)
                _strIdArticulo = value
            End Set
        End Property

        Public Property IdOrdenCompra() As String
            Get
                Return _strIdOrdenCompra
            End Get
            Set(ByVal value As String)
                _strIdOrdenCompra = value
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


        Public Property DescripcionProveedor() As String
            Get
                Return _strDescripcionProveedor
            End Get
            Set(ByVal value As String)
                _strDescripcionProveedor = value
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

        Public Property Observacion() As String
            Get
                Return _strObservacion
            End Get
            Set(ByVal value As String)
                _strObservacion = value
            End Set
        End Property


        Public Property Termino() As String
            Get
                Return _strTermino
            End Get
            Set(ByVal value As String)
                _strTermino = value
            End Set
        End Property
        Public Property _ObservacionDocumento() As String
            Get
                Return _strObservacionDocumento
            End Get
            Set(ByVal value As String)
                _strObservacionDocumento = value
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


        Public Property IdCentroCosto() As String
            Get
                Return _strIdCentroCosto
            End Get
            Set(ByVal value As String)
                _strIdCentroCosto = value
            End Set
        End Property

        Public Property DescripcionCentroCosto() As String
            Get
                Return _strDescripcionCentroCosto
            End Get
            Set(ByVal value As String)
                _strDescripcionCentroCosto = value
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



        Public Property Cantidad() As Integer
            Get
                Return _intCantidad
            End Get
            Set(ByVal value As Integer)
                _intCantidad = value
            End Set
        End Property


        Public Property PrecioReferencia() As Integer
            Get
                Return _numPrecioReferencia
            End Get
            Set(ByVal value As Integer)
                _numPrecioReferencia = value
            End Set
        End Property


        Public Property Numero() As Integer
            Get
                Return _intNumero
            End Get
            Set(ByVal value As Integer)
                _intNumero = value
            End Set
        End Property


        Public Property IdSolicitante() As String
            Get
                Return _strIdSolicitante
            End Get
            Set(ByVal value As String)
                _strIdSolicitante = value
            End Set
        End Property

        Public Property Tipo() As String
            Get
                Return _strIdTipo
            End Get
            Set(ByVal value As String)
                _strIdTipo = value
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

        Public Property FechaEntrega() As String
            Get
                Return _strFechaEntrega
            End Get
            Set(ByVal value As String)
                _strFechaEntrega = value
            End Set
        End Property

        Public ReadOnly Property exError() As String
            Get
                Return _exError.ToString
            End Get
        End Property



        Public Function Registrar(ByVal dtbdatos As Data.DataTable, ByVal Datos As Data.DataTable) As Boolean
            Try
                Dim objUtil As New General.Util




                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdOrdenCompra", _strIdOrdenCompra, _
                                                 "dtm_FechaEmision", _strFechaEmision, _
                                                 "dtm_FechaEntrega", _strFechaEntrega, _
                                                 "var_Termino", _strTermino, _
                                                 "var_Observacion", _strObservacion, _
                                                  "var_IdProveedor", _strIdProveedor, _
                                                  "xml_Datos", objUtil.GeneraXML(dtbdatos), _
                                                  "xml_Datos1", objUtil.GeneraXML(Datos)}


                _strIdOrdenCompra = _objConexion.ObtenerValor("SGC_usp_CompraDocumento_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function




    End Class
End Namespace