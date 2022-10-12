
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
        Private _strNumero As String







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

        Public Property Numero() As String
            Get
                Return _strNumero
            End Get
            Set(ByVal value As String)
                _strNumero = value
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


         


        Public Function Registrar(ByVal dtbArticulos As Data.DataTable, ByVal dtbDocumentos As Data.DataTable) As Boolean
            Try
                Dim objUtil As New General.Util

                If dtbArticulos.Columns.IndexOf("var_Articulo") >= 0 Then
                    dtbArticulos.Columns.Remove("var_Articulo")
                End If
                If dtbArticulos.Columns.IndexOf("var_UnidadMedida") >= 0 Then
                    dtbArticulos.Columns.Remove("var_UnidadMedida")
                End If

                If dtbDocumentos.Columns.IndexOf("var_TipoDocumento") >= 0 Then
                    dtbDocumentos.Columns.Remove("var_TipoDocumento")
                End If

                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdValeAlmacen", _strIdValeAlmacen, _
                                                 "var_IdTipoOperacion", _strIdOperacion, _
                                                 "dtm_Fecha", _strFechaEmision, _
                                                 "var_IdCentroCostoDestino", _strIdCentroCosto, _
                                                 "var_IdSolicitante", _strIdSolicitante, _
                                                  "var_UsuarioCreacion", _strUsuario, _
                                                 "chr_Estado", _strEstado, _
                                                 "xml_Datos", objUtil.GeneraXML(dtbArticulos), _
                                                  "xml_Datos1", objUtil.GeneraXML(dtbDocumentos)}


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
                                                 "var_IdNumeroDocumento", _strNumero, _
                                                  "var_IdTipoOperacion", _strIdOperacion, _
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




        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdValeAlmacen", _strIdValeAlmacen}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_ValeAlmacen_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdValeAlmacen = _dtbDatos.Rows(0)("var_IdValeAlmacen")
                    _strIdSolicitante = _dtbDatos.Rows(0)("var_IdSolicitante")
                    _strFechaEmision = _dtbDatos.Rows(0)("dtm_Fecha")
                    _strIdCentroCosto = _dtbDatos.Rows(0)("var_IdCentroCostoDestino")
                    _strIdTipo = _dtbDatos.Rows(0)("var_IdTipoOperacion")
                   
                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function






        Public Function Buscar(ByVal pstr_IdValeAlmacen As String,
                                 ByVal pstr_IdSolicitante As String,
                                 ByVal pstr_FechaEmisionInicio As String,
                                 ByVal pstr_FechaEmisionFinal As String,
                                 ByVal pstr_IdArticulo As String,
                                 ByVal pstr_IdCentroCostoDestino As String,
                                 ByVal pstr_IdNumeroDocumento As String,
                                 ByVal pstr_IdTipoOperacion As String,
                                 ByVal pstr_IdTipoDocumento As String
                                 ) As Boolean
            Try
                Dim objParametros() As String = {"var_IdValeAlmacen", pstr_IdValeAlmacen, _
                                                 "var_IdSolicitante", pstr_IdSolicitante, _
                                                 "var_FechaInicio", pstr_FechaEmisionInicio, _
                                                 "var_FechaFinal", pstr_FechaEmisionFinal, _
                                                  "var_IdArticulo", pstr_IdArticulo, _
                                                  "var_IdCentroCostoDestino", pstr_IdCentroCostoDestino, _
                                                 "var_IdTipoOperacion", pstr_IdTipoOperacion, _
                                                 "var_IdTipoDocumento", pstr_IdTipoDocumento, _
                                                  "var_IdNumeroDocumento", pstr_IdNumeroDocumento}

                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_VALEALMACEN_Buscar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function


        Public Function Actualizar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdValeAlmacen", _strIdValeAlmacen,
                                                 "chr_Estado", _strEstado}
                _objConexion.EjecutarComando("SCP_usp_Vale_Actualizar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function




        Public Function Buscar1(ByVal pstr_IdValeAlmacen As String,
                               ByVal pstr_IdSolicitante As String,
                               ByVal pstr_FechaEmisionInicio As String,
                               ByVal pstr_FechaEmisionFinal As String,
                               ByVal pstr_IdArticulo As String,
                               ByVal pstr_IdCentroCostoDestino As String) As Boolean
            Try
                Dim objParametros() As String = {"var_IdValeAlmacen", pstr_IdValeAlmacen, _
                                                 "var_IdSolicitante", pstr_IdSolicitante, _
                                                 "var_FechaInicio", pstr_FechaEmisionInicio, _
                                                 "var_FechaFinal", pstr_FechaEmisionFinal, _
                                                  "var_IdArticulo", pstr_IdArticulo, _
                                                  "var_IdCentroCostoDestino", pstr_IdCentroCostoDestino
                                                 }

                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_VALEALMACEN_Buscar1", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function



    End Class



   



End Namespace

