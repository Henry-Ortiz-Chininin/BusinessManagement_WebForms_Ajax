Imports AccesoDatos
Imports ALVI_LOGIC

Namespace Proceso.Logistica.Compra.Requisicion
    Public Class Solicitud

        Private _strIdSolicitud As String
        Private _strIdRequision As String
        Private _strIdUnidadMedida As String
        Private _strDescripcionUnidadMedida As String
        Private _strFechaEmision As String
        Private _strIdArticulo As String
        Private _strDescripcionArticulo As String

        Private _intCantidad As Integer
        Private _strArchivo As String
        Private _dtbDatos As DataTable
        Private _strEstado As String

        Private _strUsuario As String

        Private _strNombreArchivo As String
        Private _strObservacion As String
        Private _strProveedor As String

        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer


        Public Property IdSolicitud() As String
            Get
                Return _strIdSolicitud
            End Get
            Set(ByVal value As String)
                _strIdSolicitud = value
            End Set
        End Property


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




        Public Function Registrar(ByVal dtbdatos As Data.DataTable) As Boolean
            Try
                Dim objUtil As New General.Util

                _objConexion = New AccesoDatosSQLServer

                Dim objParametros() As String = {"var_IdRequisicion", _strIdRequision, _
                                     "dtm_FechaEmision", _strFechaEmision, _
                                     "var_IdProveedor", _strProveedor, _
                                      "chr_Estado", _strEstado, _
                                      "var_UsuarioCreacion", _strUsuario, _
                                     "xml_Datos", objUtil.GeneraXML(dtbdatos)}

                _objConexion.EjecutarComando("SGC_usp_Solicitud_Registrar", objParametros)
                Return True


            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try

        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdSolicitud", _strIdSolicitud}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Solicitud_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdRequision = _dtbDatos.Rows(0)("var_IdRequisicion")
                    _strProveedor = _dtbDatos.Rows(0)("var_IdProveedor")
                    _strFechaEmision = _dtbDatos.Rows(0)("FechaReq")


                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function BuscarRequisicion(ByVal pstrFechaInicio As String, _
                                          ByVal pstrFechaFinal As String, _
                                          ByVal pstrIdProveedor As String) As Boolean
            Try
                Dim objParametros() As String = {"var_IdRequisicion", _strIdRequision, _
                                                 "var_FechaInicio", pstrFechaInicio, _
                                                 "var_FechaFinal", pstrFechaFinal, _
                                                 "var_IdProveedor", pstrIdProveedor}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_SolicitudRequisicion_Buscar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Listar() As Boolean
            Try
                Dim objParametros() As String = {"var_IdRequisicion", _strIdRequision}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Requisicion_Buscar3", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function


        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdRequisicion", _strIdRequision}
                _objConexion.EjecutarComando("SCP_usp_solicitud_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Listar1() As Boolean
            Try
                Dim objParametros() As String = {"var_IdSolicitud", _strIdSolicitud}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_SolicitudDetalle_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function


    End Class
End Namespace

