
Imports EN_ALVINET_CONTA.VENTAS
Imports System.Data
Imports System.Data.SqlClient
Imports EN_ALVINET_CONTA
Imports AD_ALVINET_CONTA.AccesoDatos
Namespace VENTAS
    Public Class AD_PedidoValor

        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstPedidoValor As List(Of EN_PedidoValor)
        Private _entPedidoValor As New EN_PedidoValor


#Region "Propiedades"

        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property


        Public ReadOnly Property lstPedidoValor As List(Of EN_PedidoValor)
            Get
                Return _lstPedidoValor
            End Get
        End Property

        Public Property entPedidoValor As EN_PedidoValor
            Get
                Return _entPedidoValor
            End Get
            Set(ByVal Value As EN_PedidoValor)
                _entPedidoValor = Value
            End Set
        End Property

#End Region

#Region "METODOS Y FUNCIONES"

        Public Function Registrar(ByVal _dtbAtributos As DataTable) As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_PedidoValor_Registrar"

                _objConexion.AddParameter("chr_IdAtributo", _entPedidoValor.IdAtributoTipo)
                _objConexion.AddParameter("var_Descripcion", _entPedidoValor.Descripcion)
                _objConexion.AddParameter("var_IdAtributoValor", _entPedidoValor.IdAtributoTipo)
                _objConexion.AddParameter("chr_Estado", _entPedidoValor.Estado)
                _objConexion.AddParameter("var_Usuario", _entPedidoValor.Usuario)

                _objConexion.EjecutarComando()
                Return True
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function

        'Public Function Registrar() As Boolean
        '    Try
        '        _objConexion = New AccesoDatosSQLServer
        '        Dim objParametros() As String = {"chr_IdAtributo", _strIdAtributoTipo, _
        '                                         "var_Descripcion", _strDescripcion, _
        '                                         "var_IdAtributoValor", _strIdAtributoValor, _
        '                                        "chr_Estado", _strEstado, _
        '                                        "var_Usuario", _strUsuario}
        '        _objConexion.EjecutarComando("SGC_uspe_PedidoValor_Registrar", objParametros)

        '        Return True
        '    Catch ex As Exception
        '        Me._exError = ex
        '        Return False
        '    End Try
        'End Function
        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_PedidoValor_Eliminar"
                _objConexion.AddParameter("chr_IdAtributo", _entPedidoValor.IdAtributoTipo)
                _objConexion.AddParameter("var_IdAtributoValor", _entPedidoValor.IdValor)

                _objConexion.EjecutarComando()
                Return True
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function

        'Public Function Eliminar() As Boolean
        '    Try
        '        _objConexion = New AccesoDatosSQLServer
        '        Dim objParametros() As String = {"chr_IdAtributo", _strIdAtributoTipo, _
        '                                         "var_IdAtributoValor", _strIdAtributoValor}
        '        _objConexion.EjecutarComando("SGC_uspe_PedidoValor_Eliminar", objParametros)

        '        Return True
        '    Catch ex As Exception
        '        Me._exError = ex
        '        Return False
        '    End Try
        'End Function


        'Public Function Obtener() As Boolean
        '    Try
        '        _objConexion = New AccesoDatosSQLServer
        '        Dim objParametros() As String = {"chr_IdAtributo", _strIdAtributoTipo, _
        '                                         "var_IdAtributoValor", _strIdAtributoValor}
        '        _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_PedidoValor_Obtener", objParametros)
        '        If _dtbDatos.Rows.Count > 0 Then
        '            _strIdAtributoTipo = _dtbDatos.Rows(0)("chr_IdAtributo")
        '            _strIdAtributoValor = _dtbDatos.Rows(0)("var_IdAtributoValor")
        '            _strDescripcion = _dtbDatos.Rows(0)("var_Descripcion")
        '            _strEstado = _dtbDatos.Rows(0)("chr_Estado")

        '        End If
        '        Return (_dtbDatos.Rows.Count > 0)
        '    Catch ex As Exception
        '        Me._exError = ex
        '        Return False
        '    End Try
        'End Function
        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_PedidoValor_Obtener"
                _objConexion.AddParameter("chr_IdAtributo", _entPedidoValor.IdAtributoTipo)
                _objConexion.AddParameter("var_IdAtributoValor", _entPedidoValor.IdValor)
                _objConexion.EjecutarComando()
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstPedidoValor = New List(Of EN_PedidoValor)
                While odrDatos.Read
                    _entPedidoValor = New EN_PedidoValor
                    _entPedidoValor.IdAtributoTipo = odrDatos("chr_IdAtributo")
                    _entPedidoValor.IdValor = odrDatos("var_IdAtributoValor")
                    _entPedidoValor.Descripcion = odrDatos("var_Descripcion")
                    _entPedidoValor.Estado = odrDatos("chr_Estado")
                    _lstPedidoValor.Add(_entPedidoValor)
                End While

                Return (_lstPedidoValor.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function


        Public Function Listar() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer

                _objConexion.Procedimiento = "SGC_uspe_PedidoValor_Listar"
                _objConexion.AddParameter("chr_IdAtributo", _entPedidoValor.IdAtributoTipo)
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstPedidoValor = New List(Of EN_PedidoValor)
                'While odrDatos.Read
                '    _entPedidoValor = New EN_PedidoValor

                '    _entPedidoValor.IdValor = odrDatos("var_IdAtributoValor")
                '    _entPedidoValor.Descripcion = odrDatos("var_Descripcion")
                '    _entPedidoValor.Estado = odrDatos("chr_IdAtributo")
                '    _entPedidoValor.Estado = odrDatos("chr_Estado")
                '    _entPedidoValor.Usuario = odrDatos("var_UsuarioCreacion")
                '    _entPedidoValor.Estado = odrDatos("dtm_FechaCreacion")
                '    _entPedidoValor.Usuario = odrDatos("var_UsuarioModificacion")
                '    _entPedidoValor.Usuario = odrDatos("dtm_FechaModificacion")


                '    _lstPedidoValor.Add(_entPedidoValor)
                'End While

                Return (_lstPedidoValor.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function

        'Public Function Listar() As Boolean
        '    Try
        '        Dim objParametros() As String = {"chr_IdAtributo", _strIdAtributoTipo}

        '        _objConexion = New AccesoDatosSQLServer
        '        _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_PedidoValor_Listar", objParametros)

        '        Return (_dtbDatos.Rows.Count > 0)
        '    Catch ex As Exception
        '        Me._exError = ex
        '        Return False
        '    End Try
        'End Function


        'Public Function Buscar() As Boolean
        '    Try
        '        Dim objParametros() As String = {"chr_IdAtributo", _strIdAtributoTipo,
        '                                         "var_Descripcion", _strDescripcion}
        '        _objConexion = New AccesoDatosSQLServer
        '        _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_PedidoValor_Buscar", objParametros)

        '        Return (_dtbDatos.Rows.Count > 0)
        '    Catch ex As Exception
        '        Me._exError = ex
        '        Return False
        '    End Try
        'End Function


        Public Function Buscar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_PedidoValor_Buscar"
                _objConexion.EjecutarComando()
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstPedidoValor = New List(Of EN_PedidoValor)
                While odrDatos.Read
                    _entPedidoValor = New EN_PedidoValor
                    _entPedidoValor.IdAtributoTipo = odrDatos("chr_IdAtributo")
                    _entPedidoValor.Descripcion = odrDatos("var_Descripcion")

                    _lstPedidoValor.Add(_entPedidoValor)
                End While
                Return (_lstPedidoValor.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
#End Region


    End Class


End Namespace

