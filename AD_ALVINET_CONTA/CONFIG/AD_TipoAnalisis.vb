
Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.CONFIG
Imports System.Data.SqlClient

Namespace CONFIG

    Public Class AD_TipoAnalisis

#Region "Varibles"
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstTiposAnalisis As List(Of EN_TipoAnalisis)
        Private _entTipoAnalisis As New EN_TipoAnalisis
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstTiposAnalisis As List(Of EN_TipoAnalisis)
            Get
                Return _lstTiposAnalisis
            End Get
        End Property

        Public Property entTipoAnalisis As EN_TipoAnalisis
            Get
                Return _entTipoAnalisis
            End Get
            Set(ByVal Value As EN_TipoAnalisis)
                _entTipoAnalisis = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"

        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_TipoAnalisis_Registrar"
                _objConexion.AddParameter("var_IdEmpresa", _entTipoAnalisis.IdEmpresa)
                _objConexion.AddParameter("var_IdTipoAnalisis", _entTipoAnalisis.IdTipoAnalisis)
                _objConexion.AddParameter("var_Descripcion", _entTipoAnalisis.TipoAnalisis)
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
                _objConexion.Procedimiento = "ERP_usp_TipoAnalisis_Eliminar"

                _objConexion.AddParameter("var_idEmpresa", _entTipoAnalisis.IdEmpresa)
                _objConexion.AddParameter("var_IdTipoAnalisis", _entTipoAnalisis.IdTipoAnalisis)

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
                _objConexion.Procedimiento = "ERP_usp_TipoAnalisis_Listar"
                _objConexion.AddParameter("var_IdEmpresa", _entTipoAnalisis.IdEmpresa)

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstTiposAnalisis = New List(Of EN_TipoAnalisis)

                While odrDatos.Read
                    _entTipoAnalisis = New EN_TipoAnalisis

                    _entTipoAnalisis.IdTipoAnalisis = odrDatos("var_IdTipoAnalisis")
                    _entTipoAnalisis.IdEmpresa = odrDatos("var_idEmpresa")
                    _entTipoAnalisis.RazonSocial = odrDatos("var_RazonSocial")
                    _entTipoAnalisis.TipoAnalisis = odrDatos("var_Descripcion")

                    _lstTiposAnalisis.Add(_entTipoAnalisis)
                End While

                Return (_lstTiposAnalisis.Count > 0)

            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace