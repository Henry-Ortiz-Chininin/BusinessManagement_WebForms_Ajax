Imports AccesoDatos
Namespace Proceso.Produccion.OrdenProduccion
    Public Class OrdenProduccion
#Region "VARIABLES"
        Private _strIdOrden As String
        Private _strIdPartida As String
        Private _strIdArticulo As String
        Private _strIdCliente As String
        Private _strIdTizado As String
        Private _strFecha As String
        Private _strFechaPase As String
        Private _strIdSubFamilia As String
        Private _dblCantidad As Integer
        Private _strAnchoAcabado As String
        Private _strIdTipoProceso As String
        Private _strIdMotivoProceso As String
        Private _strColor As String
        Private _dblRollos As Double
        Private _strArticulo As String
        Private _strArticuloPt As String
        Private _strIdArticuloPt As String
        Private _strIdUnidadPt As String

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"
        Public Property IdOrden() As String
            Get
                Return _strIdOrden
            End Get
            Set(ByVal value As String)
                _strIdOrden = value
            End Set
        End Property
        Public Property IdPartida() As String
            Get
                Return _strIdPartida
            End Get
            Set(ByVal value As String)
                _strIdPartida = value
            End Set
        End Property
        Public Property IdMotivoProceso As String
            Get
                Return _strIdMotivoProceso
            End Get
            Set(ByVal value As String)
                _strIdMotivoProceso = value
            End Set
        End Property
        Public Property IdTipoProceso As String
            Get
                Return _strIdTipoProceso
            End Get
            Set(ByVal value As String)
                _strIdTipoProceso = value
            End Set
        End Property
        Public Property Rollos As Double
            Get
                Return _dblRollos
            End Get
            Set(ByVal value As Double)
                _dblRollos = value
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
        Public Property ArticuloPT() As String
            Get
                Return _strArticuloPt
            End Get
            Set(ByVal value As String)
                _strArticuloPt = value
            End Set
        End Property
        Public Property IdArticuloPT() As String
            Get
                Return _strIdArticuloPt
            End Get
            Set(ByVal value As String)
                _strIdArticuloPt = value
            End Set
        End Property
        Public Property Articulo() As String
            Get
                Return _strArticulo
            End Get
            Set(ByVal value As String)
                _strArticulo = value
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
        Public Property Color() As String
            Get
                Return _strColor
            End Get
            Set(ByVal value As String)
                _strColor = value
            End Set
        End Property
        Public Property AnchoAcabado() As String
            Get
                Return _strAnchoAcabado
            End Get
            Set(ByVal value As String)
                _strAnchoAcabado = value
            End Set
        End Property
        Public Property IdUnidadPT() As String
            Get
                Return _strIdUnidadPt
            End Get
            Set(ByVal value As String)
                _strIdUnidadPt = value
            End Set
        End Property
        Public Property Cantidad() As Double
            Get
                Return _dblCantidad
            End Get
            Set(ByVal value As Double)
                _dblCantidad = value
            End Set
        End Property
        Public Property IdTizado() As String
            Get
                Return _strIdTizado
            End Get
            Set(ByVal value As String)
                _strIdTizado = value
            End Set
        End Property
        Public Property Fecha() As String
            Get
                Return _strFecha
            End Get
            Set(ByVal value As String)
                _strFecha = value
            End Set
        End Property
        Public Property FechaPase() As String
            Get
                Return _strFechaPase
            End Get
            Set(ByVal value As String)
                _strFechaPase = value
            End Set
        End Property

        Public Property IdSubFamilia() As String
            Get
                Return _strIdSubFamilia
            End Get
            Set(ByVal value As String)
                _strIdSubFamilia = value
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
#End Region

#Region "METODOS Y FUNCIONES"
        Public Function Registrar(ByVal dtbAtributos As DataTable) As Boolean
            Try
                If dtbAtributos.Columns.IndexOf("var_AtributoTipo") >= 0 Then
                    dtbAtributos.Columns.Remove("var_AtributoTipo")
                End If

                Dim objGeneral As New General.Util
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdOrden", _strIdOrden, _
                                                 "var_IdPartida", _strIdPartida, _
                                                "var_IdSubFamilia", _strIdSubFamilia, _
                                                 "var_IdTipoProceso", _strIdTipoProceso, _
                                                 "var_IdMotivoProceso", _strIdMotivoProceso, _
                                                "var_IdTizado", _strIdTizado, _
                                                "chr_Estado", _strEstado, _
                                                  "xml_Atributos", objGeneral.GeneraXML(dtbAtributos), _
                                                "var_Usuario", _strUsuario, _
                                                 "var_FechaPase", _strFechaPase, _
                                                 "var_IdArticulo", _strIdArticulo, _
                                                 "var_IdArticuloPT", _strIdArticuloPt, _
                                                 "num_Rollos", _dblRollos, _
                                                 "num_Cantidad", _dblCantidad, _
                                                 "var_IdUnidadPT", _strIdUnidadPt}
                _objConexion.EjecutarComando("SGC_uspo_OrdenProduccion_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdOrden", _strIdOrden}
                _objConexion.EjecutarComando("SGC_uspo_OrdenProduccion_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function EliminarCascada(ByVal pvarnivel As String, ByVal pstr_Partida As String, ByVal pstr_Orden As String, ByVal pstr_IdSecuenciaArticulo As String, ByVal pstr_IdSecuencial As String) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim intAfecto As Int16 = 0
                Dim objParametros() As String = {"var_Nivel", pvarnivel, _
                                                 "var_idPartida", pstr_Partida, _
                                                 "var_idOrdenProduccion", pstr_Orden, _
                                                "int_SecuenciaArticulo", pstr_IdSecuenciaArticulo, _
                                                "int_SecuencialRuta", pstr_IdSecuencial}
                intAfecto = _objConexion.EjecutarComando("SGC_uspo_OrdenProduccion_EliminarCascada", objParametros)

                Return (intAfecto > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function EliminarArticulo(ByVal pstrid_ArticuloAntiguo As String, ByVal pstr_Orden As String, ByVal pstr_NuevoArticulo As String) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"id_articuloAntiguo", pstrid_ArticuloAntiguo, _
                                                 "Orden", pstr_Orden, _
                                                "id_nuevoArticulo", pstr_NuevoArticulo}
                _objConexion.EjecutarComando("SGC_uspo_OrdenProduccion_Registrar_OP", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function RegistrarAprobado(ByVal pstrid_Orden As String, ByVal pstr_UsuarioAprob As String, ByVal pstr_UsuarioMod As String, ByVal var_fechaAprob As String) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdOrden", pstrid_Orden, _
                                                 "var_usuarioAProb", pstr_UsuarioAprob, _
                                                 "var_UsuarioMod", pstr_UsuarioMod, _
                                                "var_fechaAprob", var_fechaAprob}
                _objConexion.EjecutarComando("SGC_uspo_ColorAprobado_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdOrden", _strIdOrden}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspo_OrdenProduccion_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdOrden = _dtbDatos.Rows(0)("var_IdOrden")
                    _strIdSubFamilia = _dtbDatos.Rows(0)("var_IdSubFamilia")
                    _strIdTipoProceso = _dtbDatos.Rows(0)("var_IdTipoProceso")
                    _strIdMotivoProceso = _dtbDatos.Rows(0)("var_IdMotivoProceso")
                    _strIdCliente = _dtbDatos.Rows(0)("var_IdCliente")
                    _strIdTizado = _dtbDatos.Rows(0)("var_IdTizado")
                    _strFecha = Format(_dtbDatos.Rows(0)("dtm_Fecha"), "dd/MM/yyyy")
                    _strEstado = _dtbDatos.Rows(0)("chr_Estado")
                    _dblRollos = _dtbDatos.Rows(0)("num_Rollos")
                    _strColor = _dtbDatos.Rows(0)("var_color")
                    _strIdArticulo = _dtbDatos.Rows(0)("var_IdArticulo")
                    _strArticulo = _dtbDatos.Rows(0)("var_Articulo")
                    _strArticuloPt = _dtbDatos.Rows(0)("var_ArticuloPT")
                    _strIdArticuloPt = _dtbDatos.Rows(0)("var_IdArticuloPT")
                    _dblCantidad = _dtbDatos.Rows(0)("num_Cantidad")
                    _dblRollos = _dtbDatos.Rows(0)("num_Rollos")
                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function ObtenerPartida() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdPartida", _strIdPartida}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspo_OrdenProduccion_Partida_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdOrden = _dtbDatos.Rows(0)("var_IdOrden")
                    _strIdSubFamilia = _dtbDatos.Rows(0)("var_IdSubFamilia")
                    _strIdTipoProceso = _dtbDatos.Rows(0)("var_IdTipoProceso")
                    _strIdCliente = _dtbDatos.Rows(0)("var_IdCliente")
                    _strIdTizado = _dtbDatos.Rows(0)("var_IdTizado")
                    _strFecha = Format(_dtbDatos.Rows(0)("dtm_Fecha"), "dd/MM/yyyy")
                    _strEstado = _dtbDatos.Rows(0)("chr_Estado")
                    _dblRollos = _dtbDatos.Rows(0)("num_Rollos")
                    _strColor = _dtbDatos.Rows(0)("var_color")

                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Orden() As Integer
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim ord As Integer
                Dim objParametros() As String = {"var_IdOrden", _strIdOrden}
                ord = 0
                _objConexion.EjecutarComando("SGC_uspo_OPArticulo_MaxItem", objParametros)
                ord = _objConexion.EjecutarComando("SGC_uspo_OPArticulo_MaxItem", objParametros)
                Return ord
            Catch ex As Exception
                Me._exError = ex
                Return 0
            End Try
        End Function
        Public Function Listar() As Boolean
            Try
                Dim objParametros() As String = {"var_IdPartida", _strIdPartida, _
                                                 "var_IdOrden", _strIdOrden, _
                                                "var_IdSubFamilia", _strIdSubFamilia, _
                                                "var_IdCliente", _strIdCliente}

                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspo_OrdenProduccion_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function BuscarArticuloOP() As Boolean
            Try
                Dim objParametros() As String = {"var_IdPartida", _strIdPartida, _
                                                 "var_IdArticulo", _strIdArticulo, _
                                                "var_Descripcion", _strArticulo}

                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Articulo_BuscarOP", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function ObtenerArticuloOP() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdPartida", _strIdPartida, _
                                                 "var_IdArticulo", _strIdArticulo, _
                                                "var_Descripcion", _strArticulo}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Articulo_BuscarOP", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdArticulo = _dtbDatos.Rows(0)("var_IdArticulo")
                    _strArticulo = _dtbDatos.Rows(0)("var_Descripcion")
                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function ListarProduccion(ByVal IdRuta As String, ByVal ChrProceso As String) As Boolean
            Try
                Dim objParametros() As String = {"var_IdRuta", IdRuta, _
                                                 "chr_IdProceso", ChrProceso}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_SecuencialRuta_Operacion", objParametros)
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function ListarOP(ByVal idOrden As String) As Boolean
            Try
                Dim objParametros() As String = {"var_IdOrden", idOrden}

                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspo_OrdenProduccion_Listar_OP", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function ListarHT(ByVal idPartida As String) As Boolean
            Try
                Dim objParametros() As String = {"var_IdPartida", IdPartida}

                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspo_OrdenProduccion_ListarHT", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace

