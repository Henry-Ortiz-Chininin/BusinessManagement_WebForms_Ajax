

Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.GENERAL
Imports EN_ALVINET_CONTA
Imports System.Data
Imports System.Data.SqlClient

Namespace GENERAL

    Public Class AD_TipoDocumento
#Region "Variables"
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstTipoDocumentos As List(Of EN_TipoDocumento)
        Private _entTipoDocumento As New EN_TipoDocumento
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstTipoDocumentos As List(Of EN_TipoDocumento)
            Get
                Return _lstTipoDocumentos
            End Get
        End Property

        Public Property entTipoDocumento As EN_TipoDocumento
            Get
                Return _entTipoDocumento
            End Get
            Set(ByVal Value As EN_TipoDocumento)
                _entTipoDocumento = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"

        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspa_TipoDocumento_Registrar"
                _objConexion.AddParameter("var_idEmpresa", _entTipoDocumento.IdEmpresa)
                _objConexion.AddParameter("var_IdTipoDocumento", _entTipoDocumento.IdTipoDocumento)
                _objConexion.AddParameter("var_Descripcion", _entTipoDocumento.TipoDocumento)
                _objConexion.AddParameter("chr_Clase", _entTipoDocumento.Clase)
                _objConexion.AddParameter("chr_Estado", _entTipoDocumento.Estado)
                _objConexion.AddParameter("var_IdSunat", _entTipoDocumento.IdSunat)

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
                _objConexion.Procedimiento = "SGC_uspa_TipoDocumento_Eliminar"
                _objConexion.AddParameter("var_idEmpresa", _entTipoDocumento.IdEmpresa)
                _objConexion.AddParameter("var_IdTipoDocumento", _entTipoDocumento.IdTipoDocumento)
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
                _objConexion.Procedimiento = "SGC_uspa_TipoDocumento_Listar"
                _objConexion.AddParameter("var_Clase", _entTipoDocumento.Clase)
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstTipoDocumentos = New List(Of EN_TipoDocumento)
                While odrDatos.Read
                    _entTipoDocumento = New EN_TipoDocumento
                    '_entTipoDocumento.IdEmpresa = odrDatos("var_idEmpresa")
                    _entTipoDocumento.IdTipoDocumento = odrDatos("chr_IdTipoDocumento")
                    _entTipoDocumento.TipoDocumento = odrDatos("var_Descripcion")
                    _entTipoDocumento.Clase = odrDatos("chr_Clase")
                    _entTipoDocumento.Estado = odrDatos("chr_Estado")
                    _entTipoDocumento.IdSunat = odrDatos("var_IdSunat")
                    _lstTipoDocumentos.Add(_entTipoDocumento)
                End While

                Return (_lstTipoDocumentos.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function ListarSE() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "[dbo].[SGC_uspa_TipoDocumento_ListarSE]"
                _objConexion.AddParameter("var_IdEmpresa", _entTipoDocumento.IdEmpresa)
                _objConexion.AddParameter("chr_Criterio", _entTipoDocumento.Clase)
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstTipoDocumentos = New List(Of EN_TipoDocumento)

                While odrDatos.Read

                    _entTipoDocumento = New EN_TipoDocumento

                    _entTipoDocumento.IdEmpresa = odrDatos("var_idEmpresa")
                    _entTipoDocumento.IdTipoDocumento = odrDatos("var_IdTipoDocumento")
                    _entTipoDocumento.RazonSocial = odrDatos("var_RazonSocial")
                    _entTipoDocumento.TipoDocumento = odrDatos("var_Descripcion")
                    _entTipoDocumento.Clase = odrDatos("chr_Clase")
                    _entTipoDocumento.Estado = odrDatos("chr_Estado")
                    _entTipoDocumento.IdSunat = odrDatos("var_IdSunat")


                    _lstTipoDocumentos.Add(_entTipoDocumento)
                End While

                Return (_lstTipoDocumentos.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function Buscar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_usp_TipoDocumento_Buscar "
                _objConexion.AddParameter("var_Descripcion", _entTipoDocumento.TipoDocumento)
                
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstTipoDocumentos = New List(Of EN_TipoDocumento)

                While odrDatos.Read

                    _entTipoDocumento = New EN_TipoDocumento

                    _entTipoDocumento.TipoDocumento = odrDatos("var_Descripcion")
                    _entTipoDocumento.IdTipoDocumento = odrDatos("var_IdTipoDocumento")


                    _lstTipoDocumentos.Add(_entTipoDocumento)
                End While

                Return (_lstTipoDocumentos.Count > 0)

            Catch ex As Exception
                _objError = ex

                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace