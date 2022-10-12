
Imports AccesoDatos
Imports ALVI_LOGIC
Namespace Maestros.Logistica

    Public Class Vale
        Private _strIdValeAlmacen As String
        Private _strIdArticulo As String
        Private _strDescripcionArticulo As String
        Private _strIdTipo As String
        Private _strIdOperacion As String
        Private _strIdUnidadMedida As String
        Private _strDescripcionUnidadMedida As String
        Private _strFechaEmision As String
        Private _intCantidad As Integer
        Private _strIdSolicitante As String
        Private _dtbDatos As DataTable
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

        Public Property IdValeAlemacen() As String
            Get
                Return _strIdValeAlmacen
            End Get
            Set(ByVal value As String)
                _strIdValeAlmacen = value
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


        Public Property Datos() As DataTable
            Get
                Return _dtbDatos
            End Get
            Set(ByVal value As DataTable)
                _dtbDatos = value
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


        Public Property Operacion() As String
            Get
                Return _strIdOperacion
            End Get
            Set(ByVal value As String)
                _strIdOperacion = value
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

        Public ReadOnly Property exError() As String
            Get
                Return _exError.ToString
            End Get
        End Property


         


        Public Function Regsitra(ByVal dtbdatos As Data.DataTable, ByVal Datos As Data.DataTable) As Boolean
            Try
                Dim objUtil As New General.Util




                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdValeAlmacen", _strIdValeAlmacen, _
                                                 "var_IdTipoOperacion", _strIdOperacion, _
                                                 "dtm_Fecha", _strFechaEmision, _
                                                 "var_IdCentroCostoDestino", _strIdCentroCosto, _
                                                 "var_IdSolicitante", _strIdSolicitante, _
                                                 "xml_Datos", objUtil.GeneraXML(dtbdatos), _
                                                  "xml_Datos1", objUtil.GeneraXML(Datos)}


                _strIdValeAlmacen = _objConexion.ObtenerValor("SGC_usp_ValeAlmacen_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function




        Public Function Busqueda(ByVal pstrFechaInicio As String, ByVal pstrFechaFinal As String) As Boolean
            Try
                Dim objParametros() As String = {"var_FechaInicio", pstrFechaInicio, _
                                                 "var_FechaFinal", pstrFechaFinal, _
                                                 "var_IdSolicitante", _strIdSolicitante, _
                                                 "var_IdArticulo", _strIdArticulo, _
                                                 "var_IdCentroCostoDestino", _strIdCentroCosto, _
                                                 "var_IdNumeroDocumento", _intNumero, _
                                                  "var_IdTipoDocumento", _strIdOperacion, _
                                                  "var_IdValeAlmacen", _strIdValeAlmacen, _
                                                   "var_IdTipoDocumento", _strIdTipo}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_VALEALMACEN_Buscar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function









    End Class

End Namespace

