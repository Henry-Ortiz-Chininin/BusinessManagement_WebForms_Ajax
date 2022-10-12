Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.AccesoDatos
Imports System.Data.SqlClient

Namespace CONFIG

    Public Class AD_Ejercicio
#Region "Variables"

        Private _lstEjercicios As List(Of EN_Ejercicio)
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As Exception
        Private _entEjercicio As New EN_Ejercicio

#End Region
#Region "Propiedades"

        Public ReadOnly Property lstEjercicios() As List(Of EN_Ejercicio)
            Get
                Return _lstEjercicios
            End Get
        End Property

        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property

        Public Property entEjercicio() As EN_Ejercicio
            Get
                Return _entEjercicio
            End Get
            Set(ByVal value As EN_Ejercicio)
                _entEjercicio = value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"
        Sub New()
            _entEjercicio = New EN_Ejercicio
        End Sub


        Public Function Registrar() As Boolean

            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Ejercicio_Registrar"

                _objConexion.AddParameter("var_IdEjercicio", _entEjercicio.IdEjercicio)
                _objConexion.AddParameter("var_IdEmpresa", _entEjercicio.IdEmpresa)
                _objConexion.AddParameter("dtm_FechaInicio", _entEjercicio.FechaInicio)
                _objConexion.AddParameter("dtm_FechaFinal", _entEjercicio.FechaFinal)
                _objConexion.AddParameter("var_Descripcion", _entEjercicio.Ejercicio)
                _objConexion.AddParameter("var_Agno", _entEjercicio.Agno)

                _objConexion.EjecutarComando()

                Return True

            Catch ex As Exception
                _objError = ex
                Return False
            End Try

        End Function


        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Ejercicio_Eliminar"

                _objConexion.AddParameter("var_IdEjercicio", _entEjercicio.IdEjercicio)
                _objConexion.AddParameter("var_IdEmpresa", _entEjercicio.IdEmpresa)

                _objConexion.EjecutarComando()

                Return True

            Catch ex As Exception

                _objError = ex
                Return False

            End Try

        End Function
        Public Function Buscar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Ejercicio_Buscar"
                _objConexion.AddParameter("var_IdEmpresa", _entEjercicio.IdEmpresa)
                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstEjercicios = New List(Of EN_Ejercicio)

                While odrDatos.Read
                    _entEjercicio = New EN_Ejercicio

                    _entEjercicio.IdEmpresa = odrDatos("var_IdEmpresa")
                    _entEjercicio.IdEmpresa = odrDatos("var_RazonSocial")
                    _entEjercicio.IdEjercicio = odrDatos("var_IdEjercicio")
                    _entEjercicio.FechaInicio = odrDatos("dtm_FechaInicio")
                    _entEjercicio.FechaFinal = odrDatos("dtm_FechaFinal")
                    _entEjercicio.Ejercicio = odrDatos("var_Descripcion")
                    _entEjercicio.Agno = odrDatos("var_Agno")

                    _lstEjercicios.Add(_entEjercicio)

                End While

                Return (_lstEjercicios.Count > 0)

            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function Listar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Ejercicio_Listar"
                _objConexion.AddParameter("var_IdEmpresa", _entEjercicio.IdEmpresa)

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstEjercicios = New List(Of EN_Ejercicio)

                While odrDatos.Read
                    _entEjercicio = New EN_Ejercicio

                    _entEjercicio.IdEmpresa = odrDatos("var_IdEmpresa")
                    _entEjercicio.IdEmpresa = odrDatos("var_RazonSocial")
                    _entEjercicio.IdEjercicio = odrDatos("var_IdEjercicio")
                    _entEjercicio.FechaInicio = odrDatos("dtm_FechaInicio")
                    _entEjercicio.FechaFinal = odrDatos("dtm_FechaFinal")
                    _entEjercicio.Ejercicio = odrDatos("var_Descripcion")
                    _entEjercicio.Agno = odrDatos("var_Agno")

                    _lstEjercicios.Add(_entEjercicio)

                End While

                Return (_lstEjercicios.Count > 0)

            Catch ex As Exception
                _objError = ex
                Return False
            End Try

        End Function
#End Region
    End Class
End Namespace