Imports AccesoDatos
Imports ALVI_LOGIC
Namespace Maestros.Logistica
    Public Class Partida
#Region "VARIABLES"

        Private _strIdPartida As String
        Private _strPedido As String
        Private _strIdCliente As String
        Private _StrDesCliente As String
        Private _strFechaIngreso As String
        Private _strFechaEntrega As String
        Private _stridArticulo As String
        Private _strdesArticulo As String
        Private _dblRollos As Double
        Private _dblCantidad As Double
        Private _strGuia As String
        Private _strObservacion As String
        Private _strHojaTrabajo As String

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"

        Public Property IdPartida() As String
            Get
                Return _strIdPartida
            End Get
            Set(ByVal value As String)
                _strIdPartida = value
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
        Public Property Cantidad() As Double
            Get
                Return _dblCantidad
            End Get
            Set(ByVal value As Double)
                _dblCantidad = value
            End Set
        End Property
        Public Property Pedido() As String
            Get
                Return _strPedido
            End Get
            Set(ByVal value As String)
                _strPedido = value
            End Set
        End Property
        Public Property HojaTrabajo() As String
            Get
                Return _strHojaTrabajo
            End Get
            Set(ByVal value As String)
                _strHojaTrabajo = value
            End Set
        End Property
        Public Property Guia() As String
            Get
                Return _strGuia
            End Get
            Set(ByVal value As String)
                _strGuia = value
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
                Return _StrDesCliente
            End Get
            Set(ByVal value As String)
                _StrDesCliente = value
            End Set
        End Property
        Public Property FechaIngreso() As String
            Get
                Return _strFechaIngreso
            End Get
            Set(ByVal value As String)
                _strFechaIngreso = value
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
        Public Property desArticulo() As String
            Get
                Return _strdesArticulo
            End Get
            Set(ByVal value As String)
                _strdesArticulo = value
            End Set
        End Property
        Public Property idArticulo() As String
            Get
                Return _stridArticulo
            End Get
            Set(ByVal value As String)
                _stridArticulo = value
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
        Public Function Registrar(ByVal dtbTelas As DataTable) As Boolean
            Try
                Dim objGeneral As New General.Util
                Dim objGeneral2 As New General.Util




                If dtbTelas.Columns.IndexOf("var_AtributoValor") >= 0 Then
                    dtbTelas.Columns.Remove("var_AtributoValor")
                End If


                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdPartida ", _strIdPartida, _
                                                 "var_IdCliente", _strIdCliente, _
                                                 "var_varPedido", _strPedido, _
                                                 "var_FechaIngreso", _strFechaIngreso, _
                                                 "var_FechaEntrega", _strFechaEntrega, _
                                                 "var_Usuario", _strUsuario, _
                                                 "xml_Articulos", objGeneral2.GeneraXML(dtbTelas), _
                                                 "chr_Estado", _strEstado, _
                                                "var_Guia", _strGuia, _
                                                "var_Observacion", _strObservacion}
                _objConexion.EjecutarComando("SGC_uspe_Partida_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdPartida", _strIdPartida}
                _objConexion.EjecutarComando("SGC_uspe_Partida_Eliminar", objParametros)
                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function ValidarGuia() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_Guia", _strGuia}
                _objConexion.EjecutarComando("SGC_uspe_Partida_Guia", objParametros)
                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
         
        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdPartida", _strIdPartida}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Partida_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdPartida = _dtbDatos.Rows(0)("var_idPartida")
                    _strPedido = _dtbDatos.Rows(0)("var_Pedido")
                    _strIdCliente = _dtbDatos.Rows(0)("var_IdCliente")
                    _StrDesCliente = _dtbDatos.Rows(0)("var_DesCliente")
                    _strFechaIngreso = Format(_dtbDatos.Rows(0)("dtm_FechaIngreso"), "dd/MM/yyyy")
                    _strFechaEntrega = Format(_dtbDatos.Rows(0)("dtm_FechaEntrega"), "dd/MM/yyyy")
                    _dblCantidad = _dtbDatos.Rows(0)("num_Cantidad")
                    _dblRollos = _dtbDatos.Rows(0)("num_Rollos")
                    _strEstado = _dtbDatos.Rows(0)("chr_Estado")
                    _strGuia = _dtbDatos.Rows(0)("var_Guia")
                    _strObservacion = _dtbDatos.Rows(0)("var_Observacion")

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
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Partida_Listar")

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Buscar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {
                                "var_IdPartida", _strIdPartida, _
                                "var_Cliente", _strIdCliente, _
                                "var_FechaInicio", _strFechaIngreso, _
                                "var_FechaFinal", _strFechaEntrega, _
                                "var_IdOrden", _strHojaTrabajo}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Partida_Buscar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function BuscarPartida() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdPartida ", _strIdPartida}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Partida_BuscarPartida", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace
