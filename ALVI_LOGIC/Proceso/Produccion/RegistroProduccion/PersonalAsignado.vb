Imports AccesoDatos
Namespace Proceso.Produccion.RegistroProduccion
    Public Class PersonalAsignado
#Region "VARIABLES"
        Private _strIdPersonal As String
        Private _strIdProduccion As String
        Private _strOrden As String
        Private _strNombre As String
        Private _strNombreSupervisor As String
        Private _strIdSupervisor As String
        Private _strCargoSupervisor As String
        Private _strInicioJornada As String
        Private _strFinJornada As String
        Private _strHoraInicioJornada As String
        Private _strHoraFinJornada As String
        Private _intSecuencia As Integer
        Private _strTotalHoras As String
        Private _strCargo As String
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
        Public Property IdSupervisor() As String
            Get
                Return _strIdSupervisor
            End Get
            Set(ByVal value As String)
                _strIdSupervisor = value
            End Set
        End Property
        Public Property IdProduccion() As String
            Get
                Return _strIdProduccion
            End Get
            Set(ByVal value As String)
                _strIdProduccion = value
            End Set
        End Property
        Public Property IdOrden() As String
            Get
                Return _strOrden
            End Get
            Set(ByVal value As String)
                _strOrden = value
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
        Public Property NombreSupervisor() As String
            Get
                Return _strNombreSupervisor
            End Get
            Set(ByVal value As String)
                _strNombreSupervisor = value
            End Set
        End Property
        Public Property InicioJornada() As String
            Get
                Return _strInicioJornada
            End Get
            Set(ByVal value As String)
                _strInicioJornada = value
            End Set
        End Property
        Public Property FinJornada() As String
            Get
                Return _strFinJornada
            End Get
            Set(ByVal value As String)
                _strFinJornada = value
            End Set
        End Property
        Public Property HoraInicioJornada() As String
            Get
                Return _strInicioJornada
            End Get
            Set(ByVal value As String)
                _strInicioJornada = value
            End Set
        End Property
        Public Property HoraFinJornada() As String
            Get
                Return _strFinJornada
            End Get
            Set(ByVal value As String)
                _strFinJornada = value
            End Set
        End Property
        Public Property Secuencia() As Integer
            Get
                Return _intSecuencia
            End Get
            Set(ByVal value As Integer)
                _intSecuencia = value
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
        Public Property CargoSupervisor() As String
            Get
                Return _strCargo
            End Get
            Set(ByVal value As String)
                _strCargoSupervisor = value
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
                Dim objParametros() As String = {"var_IdProduccion", _strIdProduccion, _
                                                 "var_IdPersonal", _strIdPersonal, _
                                                 "var_IdSupervisor", _strIdSupervisor, _
                                                 "var_IdOrden", _strOrden, _
                                                 "int_SecuenciaPersonal", _intSecuencia, _
                                                 "var_InicioJornada", _strInicioJornada, _
                                                 "var_FinJornada", _strFinJornada, _
                                                 "var_Usuario", _strUsuario, _
                                                 "chr_Estado", _strEstado
                                                    }
                _objConexion.EjecutarComando("SGC_usp_ProduccionPersonalAsignado_Registrar", objParametros)
                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdPersonal", _strIdPersonal, _
                                                "var_IdProduccion", _strIdProduccion, _
                                                "int_SecuenciaPersonal", _intSecuencia}
                _objConexion.EjecutarComando("SGC_usp_ProduccionPersonalAsignado_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdProduccion", _strIdProduccion}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_ProduccionPersonalAsignado_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdPersonal = _dtbDatos.Rows(0)("var_IdPersonal")
                    _strIdSupervisor = _dtbDatos.Rows(0)("var_IdSupervisor")
                    _strInicioJornada = _dtbDatos.Rows(0)("dtm_InicioJornada")
                    _strFinJornada = _dtbDatos.Rows(0)("dtm_FinJornada")
                    _strHoraInicioJornada = _dtbDatos.Rows(0)("dtm_HoraInicioJornada")
                    _strHoraFinJornada = _dtbDatos.Rows(0)("dtm_HoraFinJornada")
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
                Dim objParametros() As String = {"var_IdProduccion", _strIdProduccion}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_ProduccionPersonalAsignado_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace
