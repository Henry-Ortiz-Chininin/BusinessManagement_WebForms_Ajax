Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.AccesoDatos
Imports System.Data.SqlClient

Namespace CONFIG

    Public Class AD_EjercicioEmpresa
#Region "Variables"

        Private _lstEjerciciosEmpresa As List(Of EN_EjercicioEmpresa)
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As Exception
        Private _entEjercicioEmpresa As New EN_EjercicioEmpresa

#End Region
#Region "Propiedades"

        Public ReadOnly Property lstEjerciciosEmpresa() As List(Of EN_EjercicioEmpresa)
            Get
                Return _lstEjerciciosEmpresa
            End Get
        End Property

        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property

        Public Property entEjercicioEmpresa() As EN_EjercicioEmpresa
            Get
                Return _entEjercicioEmpresa
            End Get
            Set(ByVal value As EN_EjercicioEmpresa)
                _entEjercicioEmpresa = value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"

        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_EjercicioEmpresa_Registrar"

                _objConexion.AddParameter("var_IdEmpresa", _entEjercicioEmpresa.IdEmpresa)
                _objConexion.AddParameter("var_IdEjercicioEmpresa", _entEjercicioEmpresa.IdEjercicioEmpresa)
                _objConexion.AddParameter("var_IdContabilidad", _entEjercicioEmpresa.IdContabilidad)
                _objConexion.AddParameter("var_IdEjercicio", _entEjercicioEmpresa.IdEjercicio)
                _objConexion.AddParameter("var_Estado", _entEjercicioEmpresa.Estado)

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
                _objConexion.Procedimiento = "ERP_usp_EjercicioEmpresa_Buscar"
                _objConexion.AddParameter("var_IdEmpresa", _entEjercicioEmpresa.IdEmpresa)
                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstEjerciciosEmpresa = New List(Of EN_EjercicioEmpresa)

                While odrDatos.Read
                    _entEjercicioEmpresa = New EN_EjercicioEmpresa

                    _entEjercicioEmpresa.IdEjercicioEmpresa = odrDatos("var_IdEjercicioEmpresa")

                    _entEjercicioEmpresa.IdEmpresa = odrDatos("var_IdEmpresa")
                    _entEjercicioEmpresa.IdEmpresa = odrDatos("var_RazonSocial")

                    _entEjercicioEmpresa.IdContabilidad = odrDatos("var_IdContabilidad")
                    _entEjercicioEmpresa.IdContabilidad = odrDatos("var_descContabilidad")

                    _entEjercicioEmpresa.IdEjercicio = odrDatos("var_IdEjercicio")
                    _entEjercicioEmpresa.IdEjercicio = odrDatos("var_desEjercicio")
                    _entEjercicioEmpresa.Estado = odrDatos("var_Estado")

                    _lstEjerciciosEmpresa.Add(_entEjercicioEmpresa)
                End While

                Return (_lstEjerciciosEmpresa.Count > 0)

            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function Eliminar() As Boolean

            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_EjercicioEmpresa_Eliminar"

                _objConexion.AddParameter("var_IdEjercicioEmpresa", _entEjercicioEmpresa.IdEjercicioEmpresa)
                _objConexion.AddParameter("var_IdEmpresa", _entEjercicioEmpresa.IdEmpresa)

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
                _objConexion.Procedimiento = "ERP_usp_EjercicioEmpresa_Listar"
                _objConexion.AddParameter("var_IdEmpresa", _entEjercicioEmpresa.IdEmpresa)

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstEjerciciosEmpresa = New List(Of EN_EjercicioEmpresa)

                While odrDatos.Read
                    _entEjercicioEmpresa = New EN_EjercicioEmpresa

                    _entEjercicioEmpresa.IdEjercicioEmpresa = odrDatos("var_IdEjercicioEmpresa")

                    _entEjercicioEmpresa.IdEmpresa = odrDatos("var_IdEmpresa")
                    _entEjercicioEmpresa.IdEmpresa = odrDatos("var_RazonSocial")

                    _entEjercicioEmpresa.IdContabilidad = odrDatos("var_IdContabilidad")
                    _entEjercicioEmpresa.IdContabilidad = odrDatos("var_descContabilidad")

                    _entEjercicioEmpresa.IdEjercicio = odrDatos("var_IdEjercicio")
                    _entEjercicioEmpresa.IdEjercicio = odrDatos("var_desEjercicio")
                    _entEjercicioEmpresa.Estado = odrDatos("var_Estado")

                    _lstEjerciciosEmpresa.Add(_entEjercicioEmpresa)
                End While

                Return (_lstEjerciciosEmpresa.Count > 0)

            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace