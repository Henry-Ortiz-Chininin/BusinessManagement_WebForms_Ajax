Imports AccesoDatos

Namespace Proceso.Logistica.Kardex
    Public Class Movimiento
#Region "VARIABLES"
        Private _strIdKardex As String
        Private _strIdTipoMovimiento As String
        Private _strIdTipoDocumento As String
        Private _strNumeroDocumento As String
        Private _strIdOrdenProduccion As String
        Private _strFechaOperacion As String
        Private _strObservacion As String

        Private _strObservacionOP As String
        Private _strIdProveedor As String
        Private _dblImporteTotal As Double
        Private _strFechaOperacionOP As String

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer
        Private _strOrdenServicio As String

        Private _strIdAlmacen As String
        Private _strIdAlmacen1 As String




#End Region

#Region "PROPIEDADES"

        Public Property IdKardex() As String
            Get
                Return _strIdKardex
            End Get
            Set(ByVal value As String)
                _strIdKardex = value
            End Set
        End Property
        Public Property IdTipoMovimiento() As String
            Get
                Return _strIdTipoMovimiento
            End Get
            Set(ByVal value As String)
                _strIdTipoMovimiento = value
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
        Public Property NumeroDocumento() As String
            Get
                Return _strNumeroDocumento
            End Get
            Set(ByVal value As String)
                _strNumeroDocumento = value
            End Set
        End Property
        Public Property IdOrdenProduccion() As String
            Get
                Return _strIdOrdenProduccion
            End Get
            Set(ByVal value As String)
                _strIdOrdenProduccion = value
            End Set
        End Property
        Public Property FechaOperacion() As String
            Get
                Return _strFechaOperacion
            End Get
            Set(ByVal value As String)
                _strFechaOperacion = value
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
        Public Property ImporteTotal() As Double
            Get
                Return _dblImporteTotal
            End Get
            Set(ByVal value As Double)
                _dblImporteTotal = value
            End Set
        End Property

        Public Property IdProveedor() As Double
            Get
                Return _strIdProveedor
            End Get
            Set(ByVal value As Double)
                _strIdProveedor = value
            End Set
        End Property
        Public Property FechaOperacionOP() As String
            Get
                Return _strFechaOperacionOP
            End Get
            Set(ByVal value As String)
                _strFechaOperacionOP = value
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
        Public Property ObservacionOP() As String
            Get
                Return _strObservacionOP
            End Get
            Set(ByVal value As String)
                _strObservacionOP = value
            End Set
        End Property
        Public Property StrOrdenServicio() As String
            Get
                Return _strOrdenServicio
            End Get
            Set(ByVal value As String)
                _strOrdenServicio = value
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
        Public Property Usuario() As String
            Get
                Return _strUsuario
            End Get
            Set(ByVal value As String)
                _strUsuario = value
            End Set
        End Property
        Public ReadOnly Property exError() As String
            Get
                Return _exError.ToString
            End Get
        End Property


        Public Property IdAlmacen() As String
            Get
                Return _strIdAlmacen
            End Get
            Set(ByVal value As String)
                _strIdAlmacen = value
            End Set
        End Property



        Public Property IdAlmacen1() As String
            Get
                Return _strIdAlmacen1
            End Get
            Set(ByVal value As String)
                _strIdAlmacen1 = value
            End Set
        End Property


#End Region

#Region "METODOS Y FUNCIONES"
        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdKardex", _strIdKardex, _
                                                 "var_IdTipoMovimiento", _strIdTipoMovimiento, _
                                                 "chr_IdTipoDocumento", _strIdTipoDocumento, _
                                                "var_NumeroDocumento", _strNumeroDocumento, _
                                                "var_IdOrdenProduccion", _strIdOrdenProduccion, _
                                                "var_Observacion", _strObservacion, _
                                                "var_FechaMovimiento", _strFechaOperacion, _
                                                "chr_Estado", _strEstado, _
                                                "var_Usuario", _strUsuario}
                _strIdKardex = _objConexion.ObtenerValor("SGC_uspa_KardexMovimiento_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdKardex", _strIdKardex}
                _objConexion.EjecutarComando("SGC_uspa_KardexMovimiento_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdKardex", _strIdKardex}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspa_KardexMovimiento_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strFechaOperacion = Format(_dtbDatos.Rows(0)("dtm_FechaMovimiento"), "dd/MM/yyyy")
                    _strIdKardex = _dtbDatos.Rows(0)("chr_IdKardex")
                    _strIdOrdenProduccion = _dtbDatos.Rows(0)("var_IdOrdenProduccion")
                    _strIdTipoDocumento = _dtbDatos.Rows(0)("chr_IdTipoDocumento")
                    _strIdTipoMovimiento = _dtbDatos.Rows(0)("var_IdTipoMovimiento")
                    _strNumeroDocumento = _dtbDatos.Rows(0)("var_NumeroDocumento")
                    _strObservacion = _dtbDatos.Rows(0)("var_Observacion")
                    _strEstado = _dtbDatos.Rows(0)("chr_Estado")

                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Listar() As Boolean
            Try
                Dim objParametros() As String = {"chr_Estado", _strEstado, _
                                                 "var_IdTipoMovimiento", _strIdTipoMovimiento, _
                                                 "var_IdTipoDocumento", _strIdTipoDocumento, _
                                                 "var_IdOrdenProduccion", _strIdOrdenProduccion}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspa_KardexMovimiento_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function ListarPeriodo(ByVal pstrAnno As String, ByVal pstrMes As String) As Boolean
            Try
                Dim objParametros() As String = {"chr_Anno", pstrAnno, _
                                                 "chr_Mes", pstrMes, _
                                                 "var_IdTipoMovimiento", _strIdTipoMovimiento, _
                                                 "var_IdTipoDocumento", _strIdTipoDocumento, _
                                                 "var_IdOrdenProduccion", _strIdOrdenProduccion}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspa_KardexMovimiento_Periodo", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Busqueda(ByVal pstrFechaInicio As String, ByVal pstrFechaFinal As String) As Boolean
            Try
                Dim objParametros() As String = {"var_FechaInicio", pstrFechaInicio, _
                                                 "var_FechaFinal", pstrFechaFinal, _
                                                 "var_IdTipoMovimiento", _strIdTipoMovimiento, _
                                                 "var_IdTipoDocumento", _strIdTipoDocumento, _
                                                 "var_NumeroDocumento", _strNumeroDocumento, _
                                                 "var_IdOrdenProduccion", _strIdOrdenProduccion}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspa_KardexMovimiento_Buscar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function MovimientoAlmacenop(ByVal dtbdatos As Data.DataTable) As Boolean
            Try
                Dim objUtil As New General.Util

                If dtbdatos.Columns.IndexOf("var_Articulo") >= 0 Then
                    dtbdatos.Columns.Remove("var_Articulo")
                End If
                If dtbdatos.Columns.IndexOf("var_UnidadMedida") >= 0 Then
                    dtbdatos.Columns.Remove("var_UnidadMedida")
                End If
                If dtbdatos.Columns.IndexOf("var_Almacen") >= 0 Then
                    dtbdatos.Columns.Remove("var_Almacen")
                End If
                If dtbdatos.Columns.IndexOf("var_CentroCosto") >= 0 Then
                    dtbdatos.Columns.Remove("var_CentroCosto")
                End If
                If dtbdatos.Columns.IndexOf("var_CuentaGasto") >= 0 Then
                    dtbdatos.Columns.Remove("var_CuentaGasto")
                End If


                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdKardex", _strIdKardex, _
                                                 "var_IdTipoMovimiento", _strIdTipoMovimiento, _
                                                 "var_IdOrdenProduccion", _strIdOrdenProduccion, _
                                                 "var_Observacion", _strObservacion, _
                                                 "var_FechaMovimiento", _strFechaOperacion, _
                                                 "xml_Datos", objUtil.GeneraXML(dtbdatos), _
                                                 "var_Usuario", _strUsuario, _
                                                 "chr_Estado", _strEstado}


                _strIdKardex = _objConexion.ObtenerValor("SGC_uspa_AlmacenMovimiento_Registrar_op", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function RegistroAlmacenOP() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"chr_IdKardex", _strIdKardex, _
                                                 "var_IdTipoDocumento", _strIdTipoDocumento, _
                                                 "var_NumeroDocumento", _strNumeroDocumento, _
                                                 "var_idProveedor", _strIdProveedor, _
                                                 "var_fecha", _strFechaOperacionOP, _
                                                 "num_ImporteTotal", _dblImporteTotal}
                _objConexion.EjecutarComando("SGC_uspa_KardexMovimiento_OP_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function MovimientoAlmacen(ByVal dtbdatos As Data.DataTable) As Boolean
            Try
                Dim objUtil As New General.Util

                If dtbdatos.Columns.IndexOf("var_Articulo") >= 0 Then
                    dtbdatos.Columns.Remove("var_Articulo")
                End If
                If dtbdatos.Columns.IndexOf("var_UnidadMedida") >= 0 Then
                    dtbdatos.Columns.Remove("var_UnidadMedida")
                End If
                If dtbdatos.Columns.IndexOf("var_Almacen") >= 0 Then
                    dtbdatos.Columns.Remove("var_Almacen")
                End If
                If dtbdatos.Columns.IndexOf("var_CentroCosto") >= 0 Then
                    dtbdatos.Columns.Remove("var_CentroCosto")
                End If
                If dtbdatos.Columns.IndexOf("var_CuentaGasto") >= 0 Then
                    dtbdatos.Columns.Remove("var_CuentaGasto")
                End If


                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdKardex", _strIdKardex, _
                                                 "var_IdTipoMovimiento", _strIdTipoMovimiento, _
                                                 "chr_IdTipoDocumento", _strIdTipoDocumento, _
                                                 "var_NumeroDocumento", _strNumeroDocumento, _
                                                 "var_IdOrdenProduccion", _strIdOrdenProduccion, _
                                                 "var_Observacion", _strObservacion, _
                                                 "var_FechaMovimiento", _strFechaOperacion, _
                                                 "xml_Datos", objUtil.GeneraXML(dtbdatos), _
                                                 "var_Usuario", _strUsuario, _
                                                 "chr_Estado", _strEstado}
                                                

                _strIdKardex = _objConexion.ObtenerValor("SGC_uspa_AlmacenMovimiento_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function ListarMaterial(ByVal pstrCodigo As String) As Boolean
            Try
                Dim objParametros() As String = {"var_IdOrden", pstrCodigo}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Almacen_DespachoOrden", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function ListarMaterialPartida(ByVal pstrCodigo As String) As Boolean
            Try
                Dim objParametros() As String = {"var_IdOrden", pstrCodigo}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Almacen_DespachoPartida", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function ListarSalidaOP(ByVal pstrIdOrden As String) As Boolean
            Try
                Dim objParametros() As String = {"var_IdOrden", pstrIdOrden}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Almacen_DespachoProduccion_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)

            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function ListarLiquidacionOP(ByVal pstrIdOrden As String) As Boolean
            Try
                Dim objParametros() As String = {"var_IdOrden", pstrIdOrden}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Almacen_LiquidacionOP_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)

            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function ListarMaterialACT(ByVal pstrCodigo As String) As Boolean
            Try
                Dim objParametros() As String = {"var_OrdenServicio", pstrCodigo}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Almacen_DespachoOrden_ACT", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function ListarIngresoOrdenServicio(ByVal pstrCodigo As String) As Boolean
            Try
                Dim objParametros() As String = {"var_OrdenServicio", pstrCodigo}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Almacen_IngresoServicio", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function KardexSalidaServicio(ByVal dtbArticulos As Data.DataTable, ByVal dtbDocumentos As Data.DataTable) As Boolean
            Try
                Dim objUtil As New General.Util

                If dtbArticulos.Columns.IndexOf("var_Articulo") >= 0 Then
                    dtbArticulos.Columns.Remove("var_Articulo")
                End If
                If dtbArticulos.Columns.IndexOf("var_UnidadMedida") >= 0 Then
                    dtbArticulos.Columns.Remove("var_UnidadMedida")
                End If
                If dtbArticulos.Columns.IndexOf("var_Almacen") >= 0 Then
                    dtbArticulos.Columns.Remove("var_Almacen")
                End If
                If dtbArticulos.Columns.IndexOf("var_CentroCosto") >= 0 Then
                    dtbArticulos.Columns.Remove("var_CentroCosto")
                End If
                If dtbArticulos.Columns.IndexOf("var_CuentaGasto") >= 0 Then
                    dtbArticulos.Columns.Remove("var_CuentaGasto")
                End If
                If dtbDocumentos.Columns.IndexOf("var_CuentaGasto") >= 0 Then
                    dtbArticulos.Columns.Remove("var_CuentaGasto")
                End If

                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdKardex", _strIdKardex, _
                                                 "var_IdTipoMovimiento", _strIdTipoMovimiento, _
                                                 "var_IdOrdenProduccion", _strIdOrdenProduccion, _
                                                 "var_Observacion", _strObservacion, _
                                                 "var_FechaMovimiento", _strFechaOperacion, _
                                                 "xml_Articulos", objUtil.GeneraXML(dtbArticulos), _
                                                 "xml_Documentos", objUtil.GeneraXML(dtbDocumentos), _
                                                 "var_Usuario", _strUsuario, _
                                                 "chr_Estado", _strEstado}
                _strIdKardex = _objConexion.ObtenerValor("SGC_uspa_AlmacenSalidaServicio_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function ListarOP() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspa_KardexMovimiento_Listar")

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function RegistrarOrigen(ByVal dtbdatos As Data.DataTable, ByVal Datos As Data.DataTable) As Boolean
            Try

                Dim objUtil As New General.Util
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdOrdenProduccion", _strIdOrdenProduccion, _
                                                 "var_IdAlmacen", _strIdAlmacen, _
                                                 "var_IdAlmacen1", _strIdAlmacen1, _
                                                "var_FechaMovimiento", _strFechaOperacion, _
                                                "chr_Estado", _strEstado, _
                                                "var_Usuario", _strUsuario, _
                                                "xml_Datos", objUtil.GeneraXML(dtbdatos), _
                                                "xml_Datos1", objUtil.GeneraXML(Datos)}
                _strIdKardex = _objConexion.ObtenerValor("SGC_uspa_Kardex1_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function





        Public Function Busqueda1(ByVal pstrIdOrdenProduccion As String) As DataTable
            Try
                Dim objParametros() As String = {"var_IdOrdenProduccion", _strIdOrdenProduccion}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_KardexMovimiento_Obtener", objParametros)
              
                Return _dtbDatos

            Catch ex As Exception
                Return _dtbDatos

            End Try
        End Function



        Public Function Listar1() As Boolean
            Try
                Dim objParametros() As String = {"var_IdOrdenProduccion", _strIdOrdenProduccion}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_KardexDetalle_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function




        Public Function Listar2() As Boolean
            Try
                Dim objParametros() As String = {"var_IdOrdenProduccion", _strIdOrdenProduccion}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_KardexDoc_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function




#End Region
    End Class
End Namespace

