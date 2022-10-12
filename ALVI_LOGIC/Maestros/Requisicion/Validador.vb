
Imports AccesoDatos

Namespace Maestros.Requisicion
    Public Class Validador
        Private _strIdValidador As String
        Private _strIdSolicitante As String
        Private _strIdPersonal As String
        Private _strIdCondicion As String
        Private _strDescripcion As String

        Private _strNombre As String
        Private _strApellidoMaterno As String
        Private _strApellidoPaterno As String
        Private _strIdCargo As String
        Private _strCargo As String

        Private _strApellidos As String
        Private _strIdArea As String
        Private _strArea As String
        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

        Private _strIdRequisicion As String

        Public Property Apellidos() As String
            Get
                Return _strApellidos
            End Get
            Set(ByVal value As String)
                _strApellidos = value
            End Set
        End Property
        Public Property IdValidador() As String
            Get
                Return _strIdValidador
            End Get
            Set(ByVal value As String)
                _strIdValidador = value
            End Set
        End Property

        Public Property IdRequisicion() As String
            Get
                Return _strIdRequisicion
            End Get
            Set(ByVal value As String)
                _strIdRequisicion = value
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

        Public Property IdPersonal() As String
            Get
                Return _strIdPersonal
            End Get
            Set(ByVal value As String)
                _strIdPersonal = value
            End Set
        End Property


        Public Property IdCondicion As String
            Get
                Return _strIdCondicion
            End Get
            Set(ByVal value As String)
                _strIdCondicion = value
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



        Public Property Nombre() As String
            Get
                Return _strNombre
            End Get
            Set(ByVal value As String)
                _strNombre = value
            End Set
        End Property
        Public Property ApellidoMaterno() As String
            Get
                Return _strApellidoMaterno
            End Get
            Set(ByVal value As String)
                _strApellidoMaterno = value
            End Set
        End Property
        Public Property ApellidoPaterno() As String
            Get
                Return _strApellidoPaterno
            End Get
            Set(ByVal value As String)
                _strApellidoPaterno = value
            End Set
        End Property
        Public Property Cargo() As String
            Get
                Return _strCargo
            End Get
            Set(ByVal value As String)
                _strCargo = value
            End Set
        End Property


        Public Property IdCargo() As String
            Get
                Return _strIdCargo
            End Get
            Set(ByVal value As String)
                _strIdCargo = value
            End Set
        End Property



        Public Property Area() As String
            Get
                Return _strArea
            End Get
            Set(ByVal value As String)
                _strArea = value
            End Set
        End Property


        Public Property IdArea() As String
            Get
                Return _strIdArea
            End Get
            Set(ByVal value As String)
                _strIdArea = value
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



        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdValidador", _strIdValidador, _
                                                 "var_IdPersonal", _strIdPersonal, _
                                                 "var_IdCondicion", _strIdCondicion, _
                                                   "chr_Estado", _strEstado, _
                                                   "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SCP_usp_Validador_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function



        Public Function Listar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SCP_usp_Validador_Listar")

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function



        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdValidador", _strIdValidador}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Validador_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdValidador = _dtbDatos.Rows(0)("var_IdValidador")
                    _strIdPersonal = _dtbDatos.Rows(0)("var_IdPersonal")
                    _strNombre = _dtbDatos.Rows(0)("var_Nombre")
                    _strApellidoPaterno = _dtbDatos.Rows(0)("var_ApePat")
                    _strApellidoMaterno = _dtbDatos.Rows(0)("var_ApeMat")
                    _strIdCondicion = _dtbDatos.Rows(0)("var_IdCondicion")




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
                Dim objParametros() As String = {"var_IdValidador", _strIdValidador}
                _objConexion.EjecutarComando("SGC_usp_Validador_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function



        Public Function Buscar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_Nombre", _strNombre, _
                                                 "var_ApePat", _strApellidoPaterno, _
                                                  "var_ApeMat", _strApellidoMaterno, _
                                                  "var_IdArea", _strIdArea, _
                                                  "var_IdCargo", _strIdCargo}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Validador_Buscar", objParametros)
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function




        Public Function RegistrarValidacion() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdValidador", _strIdValidador, _
                                                 "var_IdRequisicion", _strIdRequisicion, _
                                                 "chr_Estado", _strEstado}
                _objConexion.EjecutarComando("SCP_usp_Validacion_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function


        Public Function BuscarValidador() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdValidador", _strIdValidador, _
                                                 "var_Nombre", _strNombre, _
                                                  "var_Apellidos", _strApellidos}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Validador_Busqueda", objParametros)
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function


    End Class






End Namespace
