

Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.CONFIG
Imports EN_ALVINET_CONTA
Imports System.Data
Imports System.Data.SqlClient

Namespace CONFIG

    Public Class AD_Usuario
#Region "Varibles"
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstUsuarios As List(Of EN_Usuario)
        Private _entUsuario As New EN_Usuario
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstUsuarios As List(Of EN_Usuario)
            Get
                Return _lstUsuarios
            End Get
        End Property

        Public Property entUsuario As EN_Usuario
            Get
                Return _entUsuario
            End Get
            Set(ByVal Value As EN_Usuario)
                _entUsuario = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"
        Public Function Listar() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SEG_usp_Usuario_Listar"
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstUsuarios = New List(Of EN_Usuario)

                While odrDatos.Read

                    _entUsuario = New EN_Usuario
                    _entUsuario.IdUsuario = odrDatos("var_IDUsuario")
                    _entUsuario.Clave = odrDatos("var_Clave")
                    _entUsuario.Nombre = odrDatos("var_Nombre")
                    _entUsuario.Estado = odrDatos("chr_Estado")
                   
                    _lstUsuarios.Add(_entUsuario)
                End While

                Return (_lstUsuarios.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace