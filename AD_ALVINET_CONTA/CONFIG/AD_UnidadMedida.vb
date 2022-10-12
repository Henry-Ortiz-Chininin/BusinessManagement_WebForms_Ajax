Imports EN_ALVINET_CONTA.CONFIG
Imports System.Data.SqlClient
Imports AD_ALVINET_CONTA.AccesoDatos

Namespace CONFIG


    Public Class AD_UnidadMedida

        Private _objConexion As AccesoDatosSQLServer


#Region "METODOS Y FUNCIONES"
        Public Function Registrar(ByVal um As EN_UnidadMedida) As Boolean
            
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_usp_UnidadMedida_Registrar"

                _objConexion.AddParameter("var_IdUnidadMedida", um.IdUnidadMedida)
                _objConexion.AddParameter("var_Descripcion", um.Descripcion)
                _objConexion.AddParameter("chr_Estado", um.Estado)
                _objConexion.AddParameter("var_Usuario", um.Usuario)


                _objConexion.EjecutarComando()

                Return True

            Catch ex As Exception
                '_objError = ex
                Return False
            End Try


        End Function

        Public Function Eliminar(ByVal um As EN_UnidadMedida) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_usp_UnidadMedida_Eliminar"

                _objConexion.AddParameter("var_IdUnidadMedida", um.IdUnidadMedida)

                _objConexion.EjecutarComando()

                Return True

            Catch ex As Exception

                '_objError = ex
                Return False

            End Try

        End Function

        Public Function Obtener(ByVal um As EN_UnidadMedida) As List(Of EN_UnidadMedida)

            Dim _lstUnidadMedida = New List(Of EN_UnidadMedida)


            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_usp_UnidadMedida_Obtener"
                _objConexion.AddParameter("var_IdUnidadMedida", um.IdUnidadMedida)

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                ' _lstContabilidades = New List(Of EN_Contabilidad)


                While odrDatos.Read
                    Dim _enUnidadMedida = New EN_UnidadMedida()
                    _enUnidadMedida.IdUnidadMedida = odrDatos("var_IdUnidadMedida")
                    _enUnidadMedida.Descripcion = odrDatos("UnidadMedida")
                    _enUnidadMedida.Estado = odrDatos("chr_Estado")
                    _lstUnidadMedida.Add(_enUnidadMedida)
                End While


            Catch ex As Exception
                '_objError = ex

            End Try

            Return _lstUnidadMedida

        End Function

        Public Function Listar(ByVal um As EN_UnidadMedida) As List(Of EN_UnidadMedida)

            Dim _lstUnidadMedida = New List(Of EN_UnidadMedida)

            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_usp_UnidadMedida_Listar"
                _objConexion.AddParameter("var_IdUnidadMedida", um.IdUnidadMedida)
                _objConexion.AddParameter("var_Descripcion", um.Descripcion)

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()


                While odrDatos.Read

                    Dim _enUnidadMedida = New EN_UnidadMedida

                    _enUnidadMedida.IdUnidadMedida = odrDatos("var_IdUnidadMedida")
                    _enUnidadMedida.Descripcion = odrDatos("var_Descripcion")

                    _lstUnidadMedida.Add(_enUnidadMedida)

                End While



            Catch ex As Exception
                ' _objError = ex

            End Try

            Return _lstUnidadMedida

        End Function


        Public Function Obtener1(ByVal um As EN_UnidadMedida) As EN_UnidadMedida

            Dim _enUnidadMedida = New EN_UnidadMedida()

            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_usp_UnidadMedida_Obtener"
                _objConexion.AddParameter("var_IdUnidadMedida", um.IdUnidadMedida)

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                ' _lstContabilidades = New List(Of EN_Contabilidad)


                While odrDatos.Read

                    _enUnidadMedida.IdUnidadMedida = odrDatos("var_IdUnidadMedida")
                    _enUnidadMedida.Descripcion = odrDatos("UnidadMedida")
                    _enUnidadMedida.Estado = odrDatos("chr_Estado")


                End While


            Catch ex As Exception
                '_objError = ex

            End Try

            Return _enUnidadMedida

        End Function

        Public Function Buscar(ByVal um As EN_UnidadMedida) As EN_UnidadMedida
           
            Dim _enUnidadMedida = New EN_UnidadMedida()

            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_usp_UnidadMedida_Buscar"
                _objConexion.AddParameter("var_IdUnidadMedida", um.IdUnidadMedida)

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                ' _lstContabilidades = New List(Of EN_Contabilidad)


                While odrDatos.Read

                    _enUnidadMedida.IdUnidadMedida = odrDatos("var_IdUnidadMedida")
                    _enUnidadMedida.Descripcion = odrDatos("UnidadMedida")
                    _enUnidadMedida.Estado = odrDatos("chr_Estado")


                End While


            Catch ex As Exception
                '_objError = ex

            End Try

            Return _enUnidadMedida

        End Function

#End Region

    End Class
End Namespace