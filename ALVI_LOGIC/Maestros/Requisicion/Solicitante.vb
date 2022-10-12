
Imports AccesoDatos

Namespace Maestros.Requisicion
    Public Class Solicitante
#Region "VARIABLES"
        Private _strIdSolicitante As String
        Private _strIdPersonal As String


        Private _strNombre As String
        Private _strApellidos As String
        Private _strApellidoMaterno As String
        Private _strApellidoPaterno As String
        Private _strIdCargo As String
        Private _strCargo As String

        Private _strIdArea As String
        Private _strArea As String
        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer
#End Region
#Region "PROPIEDADES"

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

        Public Property Nombre() As String
            Get
                Return _strNombre
            End Get
            Set(ByVal value As String)
                _strNombre = value
            End Set
        End Property

        Public Property Apellidos() As String
            Get
                Return _strApellidos
            End Get
            Set(ByVal value As String)
                _strApellidos = value
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
#End Region
#Region "PROCEDIMIENTOS Y FUNCIONES"

        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdSolicitante", _strIdSolicitante, _
                                                 "var_IdPersonal", _strIdPersonal, _
                                                 "chr_Estado", _strEstado, _
                                                   "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SCP_usp_Solicitante_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Listar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SCP_usp_Solicitante_Listar")

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdSolicitante", _strIdSolicitante}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Solicitante_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdSolicitante = _dtbDatos.Rows(0)("var_IdSolicitante")
                    _strIdPersonal = _dtbDatos.Rows(0)("var_IdPersonal")
                    _strNombre = _dtbDatos.Rows(0)("var_Nombre")
                    _strApellidoPaterno = _dtbDatos.Rows(0)("var_ApePat")
                    _strApellidoMaterno = _dtbDatos.Rows(0)("var_ApeMat")




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
                Dim objParametros() As String = {"var_IdSolicitante", _strIdSolicitante}
                _objConexion.EjecutarComando("SGC_usp_Solicitante_Eliminar", objParametros)

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
                                                  "var_IdCargo", _strIdCargo
                                                     }
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Solicitante_Buscar", objParametros)
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Buscar1() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_Nombre", _strNombre, _
                                                 "var_IdSolicitante", _strIdSolicitante, _
                                                 "var_Apellidos", _strApellidos}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Solicitante_Buscar1", objParametros)
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region

    End Class

End Namespace
