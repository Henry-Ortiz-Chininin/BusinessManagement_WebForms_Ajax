Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.VENTAS
Imports System.Data
Imports System.Data.SqlClient
Imports EN_ALVINET_CONTA

Namespace VENTAS

    Public Class AD_AtributoMotivo

#Region "Variables"
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstAtributosMotivo As List(Of EN_AtributoMotivo)
        Private _entAtributoMotivo As New EN_AtributoMotivo

#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property


        Public ReadOnly Property lstAtributosMotivo As List(Of EN_AtributoMotivo)
            Get
                Return _lstAtributosMotivo
            End Get
        End Property

        Public Property entAtributoMotivo As EN_AtributoMotivo
            Get
                Return _entAtributoMotivo
            End Get
            Set(ByVal Value As EN_AtributoMotivo)
                _entAtributoMotivo = Value
            End Set
        End Property

#End Region

#Region "METODOS Y FUNCIONES"

        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_MotivoAtributo_Registrar"
                _objConexion.AddParameter("var_idMotivo", _entAtributoMotivo.IdMotivo)
                _objConexion.AddParameter("var_Descripcion", _entAtributoMotivo.Descripcion)
                _objConexion.AddParameter("var_IdMotivoAtributo", _entAtributoMotivo.IdMotivoAtributo)
                _objConexion.AddParameter("chr_Estado", _entAtributoMotivo.Estado)
                _objConexion.AddParameter("var_Usuario", _entAtributoMotivo.Usuario)
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
                _objConexion.Procedimiento = "SGC_uspe_MotivoAtributo_Eliminar"
                _objConexion.AddParameter("var_idMotivo", _entAtributoMotivo.IdMotivo)
                _objConexion.AddParameter("var_IdMotivoAtributo", _entAtributoMotivo.IdMotivoAtributo)
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

                _objConexion.Procedimiento = "SGC_uspe_MotivoAtributo_Listar"
                _objConexion.AddParameter("var_idMotivo", _entAtributoMotivo.IdMotivo)

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstAtributosMotivo = New List(Of EN_AtributoMotivo)

                While odrDatos.Read
                    _entAtributoMotivo = New EN_AtributoMotivo

                    _entAtributoMotivo.IdMotivo = odrDatos("var_idMotivoAtributo")
                    _entAtributoMotivo.Descripcion = odrDatos("var_Descripcion")
                    _entAtributoMotivo.Estado = odrDatos("chr_Estado")
                    _entAtributoMotivo.Estado = odrDatos("var_UsuarioCreacion")
                    _entAtributoMotivo.Usuario = odrDatos("dtm_FechaCreacion")
                    _entAtributoMotivo.Estado = odrDatos("var_UsuarioModificacion")
                    _entAtributoMotivo.Usuario = odrDatos("dtm_FechaModificacion")
                 
                    _lstAtributosMotivo.Add(_entAtributoMotivo)
                End While

                Return (_lstAtributosMotivo.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function



        Public Function Obtener() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_MotivoAtributo_Obtener"
                _objConexion.AddParameter("var_idMotivo", _entAtributoMotivo.IdMotivo)
                _objConexion.AddParameter("var_IdMotivoAtributo", _entAtributoMotivo.IdMotivoAtributo)
                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstAtributosMotivo = New List(Of EN_AtributoMotivo)
                While odrDatos.Read
                    _entAtributoMotivo = New EN_AtributoMotivo

                    _entAtributoMotivo.IdMotivo = odrDatos("var_idMotivo")
                    _entAtributoMotivo.IdMotivoAtributo = odrDatos("var_IdMotivoAtributo")
                    _entAtributoMotivo.Descripcion = odrDatos("var_Descripcion")
                    _entAtributoMotivo.Estado = odrDatos("chr_Estado")



                    _lstAtributosMotivo.Add(_entAtributoMotivo)
                End While

                Return (_lstAtributosMotivo.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function






        Public Function Buscar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "[SGC_uspe_MotivoAtributo_Buscar]"
                _objConexion.AddParameter("var_idMotivo", _entAtributoMotivo.IdMotivo)
                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstAtributosMotivo = New List(Of EN_AtributoMotivo)

                While odrDatos.Read

                    _entAtributoMotivo = New EN_AtributoMotivo
                    _entAtributoMotivo.Descripcion = odrDatos("var_Descripcion")


                    _lstAtributosMotivo.Add(_entAtributoMotivo)
                End While

                Return (_lstAtributosMotivo.Count > 0)

            Catch ex As Exception
                _objError = ex

                Return False
            End Try
        End Function


#End Region
    End Class
End Namespace