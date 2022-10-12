Imports AccesoDatos
Imports ALVI_LOGIC
Namespace Maestros.Logistica
    Public Class HojaDeTrabajo

#Region "VARIABLES"
        Private _strIdHojadeTrabajo As String
        Private _strIdPartida As String
        Private _strIdCliente As String
        Private _strCliente As String
        Private _strIdArticulo As String
        Private _strArticulo As String
        Private _strAnchoAcabado As String
        Private _intCantidad As Integer
        Private _strFecha As String

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"
        Public Property IdHojadeTrabajo() As String
            Get
                Return _strIdHojadeTrabajo
            End Get
            Set(ByVal value As String)
                _strIdHojadeTrabajo = value
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
        Public Property IdCliente() As String
            Get
                Return _strIdCliente
            End Get
            Set(ByVal value As String)
                _strIdCliente = value
            End Set
        End Property
        Public Property Cliente() As String
            Get
                Return _strCliente
            End Get
            Set(ByVal value As String)
                _strCliente = value
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
        Public Property Articulo() As String
            Get
                Return _strArticulo
            End Get
            Set(ByVal value As String)
                _strArticulo = value
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
        Public Property Cantidad() As Integer
            Get
                Return _intCantidad
            End Get
            Set(ByVal value As Integer)
                _intCantidad = value
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
                Dim objParametros() As String = {"var_IdHojaDeTrabajo", _strIdHojadeTrabajo, _
                                                 "var_IdPartida", _strIdPartida, _
                                                 "var_IdArticulo", _strIdArticulo, _
                                                 "var_AnchoAcabado", _strAnchoAcabado, _
                                                 "num_Cantidad", _intCantidad, _
                                                "chr_Estado", _strEstado, _
                                                "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_usph_HojadeTrabajo_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdHojaDeTrabajo", _strIdHojadeTrabajo}
                _objConexion.EjecutarComando("SGC_usph_HojadeTrabajo_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdHojaDeTrabajo", _strIdHojadeTrabajo}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usph_HojadeTrabajo_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdHojadeTrabajo = _dtbDatos.Rows(0)("var_IdHojaDeTrabajo")
                    _strIdPartida = _dtbDatos.Rows(0)("var_IdPartida")
                    _strIdCliente = _dtbDatos.Rows(0)("var_IdCliente")
                    _strCliente = _dtbDatos.Rows(0)("var_Cliente")
                    _strIdArticulo = _dtbDatos.Rows(0)("var_IdArticulo")
                    _strArticulo = _dtbDatos.Rows(0)("var_Articulo")
                    _strAnchoAcabado = _dtbDatos.Rows(0)("var_AnchoAcabado")
                    _intCantidad = _dtbDatos.Rows(0)("num_Cantidad")
                    _strFecha = Format(_dtbDatos.Rows(0)("dtm_Fecha"), "dd/MM/yyyy")
                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Listar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usph_HojadeTrabajo_Listar")

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Buscar() As Boolean
            Try
                Dim objParametros() As String = {"var_IdPartida", _strIdPartida, _
                                                "var_IdCliente", _strIdCliente}

                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usph_HojadeTrabajo_Buscar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace
