Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.AccesoDatos
Imports System.Data.SqlClient

Namespace CONFIG

    Public Class AD_EjercicioMes
#Region "Variables"

        Private _lstEjerciciosMes As List(Of EN_EjercicioMes)
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As Exception
        Private _entEjercicioMes As New EN_EjercicioMes

#End Region
#Region "Propiedades"

        Public ReadOnly Property lstEjerciciosMes() As List(Of EN_EjercicioMes)
            Get
                Return _lstEjerciciosMes
            End Get
        End Property

        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property

        Public Property entEjercicioMes() As EN_EjercicioMes
            Get
                Return _entEjercicioMes
            End Get
            Set(ByVal value As EN_EjercicioMes)
                _entEjercicioMes = value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"

        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_EjercicioMes_Registrar"

                _objConexion.AddParameter("var_IdEmpresa", _entEjercicioMes.IdEmpresa)
                _objConexion.AddParameter("var_IdEjercicioMEs", _entEjercicioMes.IdEjercicioMes)
                _objConexion.AddParameter("var_IdEjercicioEmpresa", _entEjercicioMes.IdEjercicioEmpresa)
                _objConexion.AddParameter("dtm_FechaInicio", _entEjercicioMes.FechaInicio)
                _objConexion.AddParameter("dtm_Fechafin", _entEjercicioMes.FechaFinal)
                _objConexion.AddParameter("var_descripcion", _entEjercicioMes.EjercicioMes)
                _objConexion.AddParameter("var_Estado", _entEjercicioMes.Estado)

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
                _objConexion.Procedimiento = "ERP_usp_EjercicioMes_Eliminar"

                _objConexion.AddParameter("var_IdEjercicioMEs", _entEjercicioMes.IdEjercicioMes)
                _objConexion.AddParameter("var_IdEjercicioEmpresa", _entEjercicioMes.IdEjercicioEmpresa)
                _objConexion.AddParameter("var_IdEmpresa", _entEjercicioMes.IdEmpresa)

                _objConexion.EjecutarComando()

                Return True

            Catch ex As Exception

                _objError = ex
                Return False

            End Try

        End Function

        Public Function Listar() As Boolean

            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_EjercicioMes_Listar"
                _objConexion.AddParameter("var_IdEmpresa", _entEjercicioMes.IdEmpresa)

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstEjerciciosMes = New List(Of EN_EjercicioMes)

                While odrDatos.Read
                    _entEjercicioMes = New EN_EjercicioMes

                    _entEjercicioMes.IdEmpresa = odrDatos("var_IdEmpresa")
                    _entEjercicioMes.IdEmpresa = odrDatos("var_RazonSocial")

                    _entEjercicioMes.IdEjercicioMes = odrDatos("var_IdEjercicioMes")

                    _entEjercicioMes.IdEjercicioEmpresa = odrDatos("var_IdEjercicioEmpresa")
                    _entEjercicioMes.Ejercicio = odrDatos("var_DesEjercicio")

                    _entEjercicioMes.FechaInicio = odrDatos("dtm_FechaInicio")
                    _entEjercicioMes.FechaFinal = odrDatos("dtm_FechaFin")
                    _entEjercicioMes.Ejercicio = odrDatos("var_Descripcion")
                    _entEjercicioMes.Estado = odrDatos("var_Estado")

                    _lstEjerciciosMes.Add(_entEjercicioMes)
                End While

                Return (_lstEjerciciosMes.Count > 0)

            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace