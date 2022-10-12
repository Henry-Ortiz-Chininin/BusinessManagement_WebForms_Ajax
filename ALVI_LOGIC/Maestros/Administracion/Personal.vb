Imports AccesoDatos

Namespace Maestros.Administracion
    Public Class Personal
#Region "VARIABLES"
        Private _strIdPersonal As String
        Private _strIdCentroCosto As String
        Private _strCentroCosto As String
        Private _strNombre As String
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

        Public Property IdPersonal() As String
            Get
                Return _strIdPersonal
            End Get
            Set(ByVal value As String)
                _strIdPersonal = value
            End Set
        End Property
        Public Property IdCentroCosto() As String
            Get
                Return _strIdCentroCosto
            End Get
            Set(ByVal value As String)
                _strIdCentroCosto = value
            End Set
        End Property
        Public Property CentroCosto() As String
            Get
                Return _strCentroCosto
            End Get
            Set(ByVal value As String)
                _strCentroCosto = value
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
#End Region

#Region "METODOS Y FUNCIONES"
        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdPersonal", _strIdPersonal, _
                                                 "var_IdCentroCosto", _strIdCentroCosto, _
                                                 "var_Nombre", _strNombre, _
                                                 "var_ApeMat", _strApellidoMaterno, _
                                                 "var_ApePat", _strApellidoPaterno, _
                                                 "var_Cargo", _strIdCargo, _
                                                 "var_IdArea", _strIdArea, _
                                                 "chr_Estado", _strEstado, _
                                                 "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_usp_Personal_Registro", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdPersonal", _strIdPersonal}
                _objConexion.EjecutarComando("SGC_usp_Personal_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdPersonal", _strIdPersonal}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Personal_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdPersonal = _dtbDatos.Rows(0)("var_IdPersonal")
                    _strIdCentroCosto = _dtbDatos.Rows(0)("var_IdCentroCosto")
                    _strNombre = _dtbDatos.Rows(0)("var_Nombre")
                    _strApellidoPaterno = _dtbDatos.Rows(0)("var_ApePat")
                    _strApellidoMaterno = _dtbDatos.Rows(0)("var_ApeMat")
                    _strIdCargo = _dtbDatos.Rows(0)("var_IdCargo")
                    _strCargo = _dtbDatos.Rows(0)("Cargo")
                    _strIdArea = _dtbDatos.Rows(0)("var_IdArea")
                    _strArea = _dtbDatos.Rows(0)("Area")
                    _strCentroCosto = _dtbDatos.Rows(0)("var_CentroCosto")

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
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Personal_Listar")

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Buscar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_Nombre", _strNombre, _
                                                "var_ApeMat", _strApellidoMaterno, _
                                                 "var_ApePat", _strApellidoPaterno, _
                                                 "var_IdPersonal", _strIdPersonal}

                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Personal_Buscar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace

