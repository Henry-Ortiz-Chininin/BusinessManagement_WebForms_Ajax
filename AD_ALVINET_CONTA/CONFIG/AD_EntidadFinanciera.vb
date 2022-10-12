Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.CONFIG
Imports System.Data.SqlClient

Namespace CONFIG

    Public Class AD_EntidadFinanciera

#Region "Variables"
        Private _objConexion As AccesoDatos.AccesoDatosSQLServer
        Private _entEntidadFinanciera As EN_EntidadFinanciera
        Private _lstEntidadFinanciera As List(Of EN_EntidadFinanciera)
        Private _objError As New Exception
#End Region
#Region "Propiedades"

        Public Property entEntidadFinanciera() As EN_EntidadFinanciera
            Get
                Return _entEntidadFinanciera
            End Get
            Set(ByVal value As EN_EntidadFinanciera)
                _entEntidadFinanciera = value
            End Set
        End Property

        Public ReadOnly Property lstEntidadFinanciera() As List(Of EN_EntidadFinanciera)
            Get
                Return _lstEntidadFinanciera
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
                _objConexion = New AccesoDatos.AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_EntidadFinanciera_Registrar"

                _objConexion.AddParameter("var_IdEmpresa", _entEntidadFinanciera.IdEmpresa)
                _objConexion.AddParameter("var_IdEntidadFinanciera", _entEntidadFinanciera.IdEntidadFinanciera)
                _objConexion.AddParameter("var_Descripcion", _entEntidadFinanciera.NombreEntidad)
                _objConexion.AddParameter("var_IdSunat", _entEntidadFinanciera.IdSunat)

                _objConexion.EjecutarComando()
                Return True
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function Listar() As Boolean
            Try
                _objConexion = New AccesoDatos.AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_EntidadFinanciera_Listar"
                _objConexion.AddParameter("var_IdEmpresa", _entEntidadFinanciera.IdEmpresa)

                Dim odrDatos As SqlClient.SqlDataReader = _objConexion.ObtenerDataReader()
                _lstEntidadFinanciera = New List(Of EN_EntidadFinanciera)
                While odrDatos.Read
                    _entEntidadFinanciera = New EN_EntidadFinanciera

                    _entEntidadFinanciera.IdEntidadFinanciera = odrDatos("var_IdEntidadFinanciera")
                    _entEntidadFinanciera.IdEmpresa = odrDatos("var_IdEmpresa")
                    _entEntidadFinanciera.RazonSocial = odrDatos("var_RazonSocial")
                    _entEntidadFinanciera.NombreEntidad = odrDatos("var_Descripcion")
                    _entEntidadFinanciera.IdSunat = odrDatos("var_IdSunat")

                    _lstEntidadFinanciera.Add(_entEntidadFinanciera)
                End While
                Return (_lstEntidadFinanciera.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatos.AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_EntidadFinanciera_Eliminar"
                _objConexion.AddParameter("var_IdEntidadFinanciera", _entEntidadFinanciera.IdEntidadFinanciera)
                _objConexion.AddParameter("var_IdEmpresa", _entEntidadFinanciera.IdEmpresa)
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