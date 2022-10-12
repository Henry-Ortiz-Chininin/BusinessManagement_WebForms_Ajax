Imports AccesoDatos
Namespace Proceso.Produccion.OrdenProduccion
    Public Class ArticuloOrden
#Region "VARIABLES"
        Private _strIdOrden As String
        Private _strIdArticulo As String
        Private _intSecuenciaArticulo As Int16
        Private _dblCantidad As Double
        Private _dblRollos As Double
        Private _strIdUnidadMedida As String
        Private _strIdPartida As String
        Private _strIdCliente As String
        Private _strDesCliente As String
        Private _strAnchoAcabado As String
        Private _strDesArticulo As String

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer
        Private _strMaxItem As String


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

        Public Property SecuenciaArticulo() As Int16
            Get
                Return _intSecuenciaArticulo
            End Get
            Set(ByVal value As Int16)
                _intSecuenciaArticulo = value
            End Set
        End Property
        Public Property Partida() As Double
            Get
                Return _strIdPartida
            End Get
            Set(ByVal value As Double)
                _strIdPartida = value
            End Set
        End Property
        Public Property IdCliente() As Double
            Get
                Return _strIdCliente
            End Get
            Set(ByVal value As Double)
                _strIdCliente = value
            End Set
        End Property
        Public Property DesCliente() As String
            Get
                Return _strDesCliente
            End Get
            Set(ByVal value As String)
                _strDesCliente = value
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
        Public Property DesArticulo() As String
            Get
                Return _strDesArticulo
            End Get
            Set(ByVal value As String)
                _strDesArticulo = value
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
        Public Property Rollos() As Double
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
        Public Property MaxItem() As String
            Get
                Return _strMaxItem
            End Get
            Set(ByVal value As String)
                _strMaxItem = value
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
        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdArticulo", _strIdArticulo, _
                                                "var_IdOrden", _strIdOrden, _
                                                 "int_SecuenciaArticulo", _intSecuenciaArticulo, _
                                                "var_IdUnidadMedida", _strIdUnidadMedida, _
                                                "num_Cantidad", _dblCantidad, _
                                                 "num_Rollos", _dblRollos, _
                                                "chr_Estado", _strEstado, _
                                                "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_uspo_OPArticulo_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Importar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdArticulo", _strIdArticulo, _
                                                "var_IdOrden", _strIdOrden, _
                                                 "int_SecuenciaArticulo", _intSecuenciaArticulo, _
                                                "chr_Estado", _strEstado, _
                                                "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_uspo_OPArticulo_Importar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function ImprimirCabecera() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdOrden", _strIdOrden}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspo_OPArticulo_Imprimir", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdPartida = _dtbDatos.Rows(0)("var_IdPartida")
                    _strDesCliente = _dtbDatos.Rows(0)("var_Cliente")
                    _strAnchoAcabado = _dtbDatos.Rows(0)("var_IdTizado")
                    _strDesArticulo = _dtbDatos.Rows(0)("var_articulo")
                    _dblRollos = _dtbDatos.Rows(0)("num_Rollos")
                    _dblCantidad = _dtbDatos.Rows(0)("num_Cantidad")
                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Orden() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdOrden", _strIdOrden}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspo_OPArticulo_MaxItem", objParametros)
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Medida(ByVal pDescripcion As String) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_Descripcion", pDescripcion}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspo_OPArticulo_IDMedida", objParametros)
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Eliminar() As Boolean
            Try
                Dim objParametros() As String = {"var_IdOrden", _strIdOrden, _
                                "int_SecuenciaArticulo", _intSecuenciaArticulo}
                _objConexion = New AccesoDatosSQLServer
                _objConexion.EjecutarComando("SGC_uspo_OPArticulo_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function EliminarCascada() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdOrden", _strIdOrden, _
                                                "int_SecuenciaArticulo", _intSecuenciaArticulo}
                _objConexion.EjecutarComando("SGC_uspo_OPArticulo_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdOrden", _strIdOrden, _
                                                "int_SecuenciaArticulo", _intSecuenciaArticulo}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspo_OPArticulo_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdArticulo = _dtbDatos.Rows(0)("var_IdArticulo")
                    _strIdOrden = _dtbDatos.Rows(0)("var_IdOrden")
                    _strIdUnidadMedida = _dtbDatos.Rows(0)("var_IdUnidadMedida")
                    _dblCantidad = _dtbDatos.Rows(0)("num_Cantidad")
                    _strEstado = _dtbDatos.Rows(0)("chr_Estado")
                    _dblRollos = _dtbDatos.Rows(0)("num_Rollos")
                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Listar() As Boolean
            Try
                Dim objParametros() As String = {"var_IdOrden", _strIdOrden}

                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspo_OPArticulo_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace


