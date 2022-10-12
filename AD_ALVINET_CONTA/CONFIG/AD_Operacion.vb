Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.CONFIG
Imports System.Data.SqlClient

Namespace CONFIG

    Public Class AD_Operacion
#Region "Variables"
        Private _objConexion As AccesoDatosSQLServer
        Private _entOperacion As EN_Operacion
        Private _lstOperacion As List(Of EN_Operacion)
        Private _objError As New Exception
#End Region
#Region "Propiedades"
        Public Property entOperacion() As EN_Operacion
            Get
                Return _entOperacion
            End Get
            Set(ByVal value As EN_Operacion)
                _entOperacion = value
            End Set
        End Property
        Public ReadOnly Property lstOperacion() As List(Of EN_Operacion)
            Get
                Return _lstOperacion
            End Get
        End Property

        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property
#End Region
#Region "Metodos y Funciones "

        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Operacion_Registrar"

                _objConexion.AddParameter("var_IdEmpresa", _entOperacion.Idempresa)
                _objConexion.AddParameter("var_IdContabilidad", _entOperacion.IdContabilidad)
                _objConexion.AddParameter("var_IdOperacion", _entOperacion.IdOperacion)
                _objConexion.AddParameter("var_Descripcion", _entOperacion.Descripcion)
                _objConexion.AddParameter("var_IdSunat", _entOperacion.IdSunat)

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
                _objConexion.Procedimiento = "ERP_usp_Operacion_Listar2"
                _objConexion.AddParameter("var_IdEmpresa", _entOperacion.Idempresa)
                _objConexion.AddParameter("var_IdSunat", _entOperacion.IdSunat)

                Dim odrDatos As SqlClient.SqlDataReader = _objConexion.ObtenerDataReader()
                _lstOperacion = New List(Of EN_Operacion)

                While odrDatos.Read
                    _entOperacion = New EN_Operacion

                    _entOperacion.IdEmpresa = odrDatos("var_IdEmpresa")
                    _entOperacion.Idempresa = odrDatos("var_RazonSocial")

                    _entOperacion.IdContabilidad = odrDatos("var_IdContabilidad")
                    _entOperacion.Contabilidad = odrDatos("var_desContabilidad")

                    _entOperacion.IdOperacion = odrDatos("var_IdOperacion")
                    _entOperacion.Descripcion = odrDatos("var_desOperacion")
                    _entOperacion.IdSunat = odrDatos("var_IdSunat")
                    _lstOperacion.Add(_entOperacion)
                End While
                Return (_lstOperacion.Count > 0)

            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function ListarSubOp() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Operacion_Listar"
                _objConexion.AddParameter("var_IdEmpresa", _entOperacion.Idempresa)
                _objConexion.AddParameter("var_Tipo", _entOperacion.Flag)

                Dim odrDatos As SqlClient.SqlDataReader = _objConexion.ObtenerDataReader()
                _lstOperacion = New List(Of EN_Operacion)

                While odrDatos.Read
                    _entOperacion = New EN_Operacion

                    _entOperacion.IdEmpresa = odrDatos("var_IdEmpresa")
                    _entOperacion.Idempresa = odrDatos("var_RazonSocial")

                    _entOperacion.IdContabilidad = odrDatos("var_IdContabilidad")
                    _entOperacion.Contabilidad = odrDatos("var_desContabilidad")

                    _entOperacion.IdOperacion = odrDatos("var_IdOperacion")
                    _entOperacion.Descripcion = odrDatos("var_desOperacion")
                    _entOperacion.IdSunat = odrDatos("var_IdSunat")
                    _lstOperacion.Add(_entOperacion)
                End While
                Return (_lstOperacion.Count > 0)

            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function ListarSubOpVenta() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Operacion_Listar"
                _objConexion.AddParameter("var_IdEmpresa", _entOperacion.Idempresa)

                Dim odrDatos As SqlClient.SqlDataReader = _objConexion.ObtenerDataReader()
                _lstOperacion = New List(Of EN_Operacion)

                While odrDatos.Read
                    _entOperacion = New EN_Operacion

                    _entOperacion.IdEmpresa = odrDatos("var_IdEmpresa")
                    _entOperacion.Idempresa = odrDatos("var_RazonSocial")

                    _entOperacion.IdContabilidad = odrDatos("var_IdContabilidad")
                    _entOperacion.Contabilidad = odrDatos("var_desContabilidad")

                    _entOperacion.IdOperacion = odrDatos("var_IdOperacion")
                    _entOperacion.Descripcion = odrDatos("var_desOperacion")
                    _entOperacion.IdSunat = odrDatos("var_IdSunat")
                    _lstOperacion.Add(_entOperacion)
                End While
                Return (_lstOperacion.Count > 0)

            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Operacion_Eliminar"

                _objConexion.AddParameter("var_IdEmpresa", _entOperacion.IdEmpresa)
                _objConexion.AddParameter("var_IdContabilidad", _entOperacion.IdContabilidad)
                _objConexion.AddParameter("var_IdOperacion", _entOperacion.IdOperacion)

                _objConexion.EjecutarComando()
                Return True
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace