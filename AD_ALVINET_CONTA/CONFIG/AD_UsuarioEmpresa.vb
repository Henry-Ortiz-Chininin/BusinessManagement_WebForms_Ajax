Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.CONFIG
Imports System.Data
Imports System.Data.SqlClient

Namespace CONFIG
    Public Class AD_UsuarioEmpresa
#Region "Varibles"
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstUsuarioEmpresas As List(Of EN_UsuarioEmpresa)
        Private _entUsuarioEmpresa As New EN_UsuarioEmpresa
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstUsuarioEmpresas As List(Of EN_UsuarioEmpresa)
            Get
                Return _lstUsuarioEmpresas
            End Get
        End Property

        Public Property entUsuarioEmpresa As EN_UsuarioEmpresa
            Get
                Return _entUsuarioEmpresa
            End Get
            Set(ByVal Value As EN_UsuarioEmpresa)
                _entUsuarioEmpresa = Value
            End Set
        End Property

#End Region
#Region "Metodos y Funciones"
        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_UsuarioEmpresa_Registrar"
                _objConexion.AddParameter("var_IdUsuario", _entUsuarioEmpresa.IdUsuario)
                _objConexion.AddParameter("var_IdEmpresa", _entUsuarioEmpresa.IdEmpresa)

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
                _objConexion.Procedimiento = "ERP_usp_UsuarioEmpresa_Eliminar"
                _objConexion.AddParameter("var_IdUsuario", _entUsuarioEmpresa.IdUsuario)
                _objConexion.AddParameter("var_IdEmpresa", _entUsuarioEmpresa.IdEmpresa)
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
                _objConexion.Procedimiento = "ERP_usp_UsuarioEmpresa_Listar"
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstUsuarioEmpresas = New List(Of EN_UsuarioEmpresa)

                While odrDatos.Read

                    _entUsuarioEmpresa = New EN_UsuarioEmpresa
                    _entUsuarioEmpresa.IdEmpresa = odrDatos("var_IdEmpresa")
                    _entUsuarioEmpresa.IdUsuario = odrDatos("var_IdUsuario")
                    _entUsuarioEmpresa.Nombre = odrDatos("var_Nombre")
                    _entUsuarioEmpresa.RazonSocial = odrDatos("var_RazonSocial")
                    _entUsuarioEmpresa.Ruc = odrDatos("chr_RUC")


                    _lstUsuarioEmpresas.Add(_entUsuarioEmpresa)
                End While

                Return (_lstUsuarioEmpresas.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function

        Public Function Buscar() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_UsuarioEmpresa_Buscar"
                _objConexion.AddParameter("var_IdUsuario", _entUsuarioEmpresa.IdUsuario)
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstUsuarioEmpresas = New List(Of EN_UsuarioEmpresa)

                While odrDatos.Read

                    _entUsuarioEmpresa = New EN_UsuarioEmpresa
                    _entUsuarioEmpresa.IdEmpresa = odrDatos("var_IdEmpresa")
                    _entUsuarioEmpresa.IdUsuario = odrDatos("var_IdUsuario")
                    _entUsuarioEmpresa.Nombre = odrDatos("var_Nombre")
                    _entUsuarioEmpresa.RazonSocial = odrDatos("var_RazonSocial")
                    _entUsuarioEmpresa.Ruc = odrDatos("chr_RUC")


                    _lstUsuarioEmpresas.Add(_entUsuarioEmpresa)
                End While

                Return (_lstUsuarioEmpresas.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace