
Imports AccesoDatos

Namespace Maestros.Compras
    Public Class Cargo
        'variables'

        Private _strIdCargo As String
        Private _strNombre As String
        Private _strDescripcion As String
        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

        'propiedades'


        Public Property IdCargo As String
            Get
                Return _strIdCargo
            End Get
            Set(ByVal value As String)
                _strIdCargo = value
            End Set
        End Property



        Public Property Nombre As String
            Get
                Return _strNombre
            End Get
            Set(ByVal value As String)
                _strNombre = value
            End Set
        End Property



        Public Property Descripcion As String
            Get
                Return _strDescripcion
            End Get
            Set(ByVal value As String)
                _strDescripcion = value
            End Set
        End Property



        Public Property Estado As String
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


        Public Property Datos() As DataTable
            Get
                Return _dtbDatos
            End Get
            Set(ByVal value As DataTable)
                _dtbDatos = value
            End Set
        End Property



        'metodos  y funciones..'


        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdCargo", _strIdCargo,
                                                 "var_Descripcion", _strDescripcion, _
                                                 "var_UsuarioCreacion", _strUsuario, _
                                                 "chr_Estado", _strEstado
                                                }
                _objConexion.EjecutarComando("SCP_usp_Cargo_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function



        Public Function Listar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Cargo_Listar")

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function



        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdCargo", _strIdCargo}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Cargo_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdCargo = _dtbDatos.Rows(0)("var_IdCargo")
                    _strDescripcion = _dtbDatos.Rows(0)("var_Descripcion")
                    _strEstado = _dtbDatos.Rows(0)("chr_IdEstado")

                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function



        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdCargo", _strIdCargo}
                _objConexion.EjecutarComando("SGC_usp_Cargo_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function



        Public Function Buscar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_Descripcion", _strDescripcion
                                                 }
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Cargo_Buscar", objParametros)
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function


    End Class





End Namespace

