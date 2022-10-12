Option Strict On

Imports Microsoft.Win32
Imports System.IO
Imports System.Security

Namespace AccesoDatos
    Public NotInheritable Class GeneradorCadenaConexion

        Private Shared m_strCadenaConexionSQLServer As String = _
         "Data Source={0};Initial Catalog={1};User Id={2};Pwd={3}; Connect Timeout=200"

        Public Shared Function ObtenerCadenaConexionSQLServer() As String
            Try
                Dim strServidor, strBaseDatos, strUsuario, strPassword As String
                strServidor = My.Settings.Server
                strBaseDatos = My.Settings.DataBase
                strUsuario = My.Settings.User
                strPassword = My.Settings.Password

                Return m_strCadenaConexionSQLServer.Format(m_strCadenaConexionSQLServer, _
                    strServidor, _
                    strBaseDatos, _
                    strUsuario, _
                    strPassword)

            Catch IOEx As IOException
                Throw IOEx
            Catch SecEx As SecurityException
                Throw SecEx
            End Try
        End Function
    End Class
End Namespace