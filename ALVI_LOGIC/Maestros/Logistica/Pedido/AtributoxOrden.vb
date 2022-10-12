Imports AccesoDatos
Imports ALVI_LOGIC
Namespace Maestros.Logistica
    Public Class AtributoxOrden
#Region "VARIABLES"
        Private _strIdOrden As String
        Private _intSecuencia As Int16
        Private _strIdAtributoTipo As String
        Private _strIdAtributoValor As String

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"

        Public Property IdAtributoTipo() As String
            Get
                Return _strIdAtributoTipo
            End Get
            Set(ByVal value As String)
                _strIdAtributoTipo = value
            End Set
        End Property
        Public Property IdValor() As String
            Get
                Return _strIdAtributoValor
            End Get
            Set(ByVal value As String)
                _strIdAtributoValor = value
            End Set
        End Property

        Public Property IdOrden() As String
            Get
                Return _strIdOrden
            End Get
            Set(ByVal value As String)
                _strIdOrden = value
            End Set
        End Property
        Public Property Secuencia() As Int16
            Get
                Return _intSecuencia
            End Get
            Set(ByVal value As Int16)
                _intSecuencia = value
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
        'Public Function Registrar() As Boolean
        '    Try
        '        _objConexion = New AccesoDatosSQLServer
        '        Dim objParametros() As String = {"chr_IdAtributo", _strIdAtributoTipo, _
        '                                         "var_IdO", _strIdPartida, _
        '                                         "int_Secuencia", _intSecuencia, _
        '                                         "var_IdAtributoValor", _strIdAtributoValor, _
        '                                         "var_Usuario", _strUsuario}
        '        _objConexion.EjecutarComando("SGC_uspe_PartidaAtributo_Registrar", objParametros)

        '        Return True
        '    Catch ex As Exception
        '        Me._exError = ex
        '        Return False
        '    End Try
        'End Function

        'Public Function Eliminar() As Boolean
        '    Try
        '        _objConexion = New AccesoDatosSQLServer
        '        Dim objParametros() As String = {"var_IdPartida", _strIdPartida, _
        '                                         "int_Secuencia", _intSecuencia}
        '        _objConexion.EjecutarComando("SGC_uspe_PartidaAtributo_Eliminar", objParametros)

        '        Return True
        '    Catch ex As Exception
        '        Me._exError = ex
        '        Return False
        '    End Try
        'End Function

        'Public Function Obtener() As Boolean
        '    Try
        '        _objConexion = New AccesoDatosSQLServer
        '        Dim objParametros() As String = {"var_IdPartida", _strIdPartida, _
        '                                         "int_Secuencia", _intSecuencia}
        '        _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_PartidaAtributo_Obtener", objParametros)
        '        If _dtbDatos.Rows.Count > 0 Then
        '            _strIdAtributoTipo = _dtbDatos.Rows(0)("chr_IdAtributo")
        '            _strIdAtributoValor = _dtbDatos.Rows(0)("var_IdAtributoValor")
        '            _strIdPartida = _dtbDatos.Rows(0)("var_IdPartida")
        '            _intSecuencia = _dtbDatos.Rows(0)("int_Secuencia")
        '            _strEstado = _dtbDatos.Rows(0)("chr_Estado")

        '        End If
        '        Return (_dtbDatos.Rows.Count > 0)
        '    Catch ex As Exception
        '        Me._exError = ex
        '        Return False
        '    End Try
        'End Function 

        Public Function Listar() As Boolean
            Try
                Dim objParametros() As String = {"var_IdOrden", _strIdOrden}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_OrdenAtributo_Listar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace
