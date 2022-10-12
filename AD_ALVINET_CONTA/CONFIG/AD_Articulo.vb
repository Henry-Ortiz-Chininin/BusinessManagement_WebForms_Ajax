Imports EN_ALVINET_CONTA.CONFIG
Imports System.Data.SqlClient
Imports AD_ALVINET_CONTA.AccesoDatos

Namespace CONFIG

    Public Class AD_Articulo

        Private _objConexion As AccesoDatosSQLServer
        Private _lstArticulo As List(Of EN_Articulo)
        Private _enArticulo As EN_Articulo
        Private _objError As Exception

        Public Property objError() As Exception
            Get
                Return _objError
            End Get
            Set(ByVal value As Exception)
                _objError = value
            End Set
        End Property

        Public Property lstArtuculo() As List(Of EN_Articulo)
            Get
                Return _lstArticulo
            End Get
            Set(ByVal value As List(Of EN_Articulo))
                _lstArticulo = value
            End Set
        End Property

        Public Property entArticulo() As EN_Articulo
            Get
                Return _enArticulo
            End Get
            Set(ByVal value As EN_Articulo)
                _enArticulo = value
            End Set
        End Property


#Region "METODOS Y FUNCIONES"

        Public Function Registrar(ByVal ar As EN_Articulo) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Articulo_Registrar"

                _objConexion.AddParameter("var_IdArticulo", ar.IdArticulo)
                _objConexion.AddParameter("var_IdSubFamilia", ar.IdSubFamilia)
                _objConexion.AddParameter("var_IdUnidadMedida", ar.IdUnidadMedida)
                _objConexion.AddParameter("var_Descripcion", ar.Descripcion)
                _objConexion.AddParameter("chr_Estado", ar.Estado)
                _objConexion.AddParameter("var_Usuario", ar.Usuario)

                _objConexion.EjecutarComando()

                Return True

            Catch ex As Exception
                '_objError = ex
                Return False
            End Try


        End Function

        Public Function Eliminar(ByVal ar As EN_Articulo) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Articulo_Eliminar"

                _objConexion.AddParameter("var_IdArticulo", ar.IdArticulo)

                _objConexion.EjecutarComando()

                Return True

            Catch ex As Exception

                '_objError = ex
                Return False

            End Try

        End Function

        Public Function Obtener(ByVal ar As EN_Articulo) As EN_Articulo
            Dim _enArticulo = New EN_Articulo()

            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Articulo_Obtener"
                _objConexion.AddParameter("var_IdArticulo", ar.IdArticulo)

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                While odrDatos.Read

                    _enArticulo.IdArticulo = odrDatos("var_IdArticulo")
                    _enArticulo.IdSubFamilia = odrDatos("var_IdSubFamilia")
                    _enArticulo.IdFamilia = odrDatos("var_IdSubFamilia")
                    _enArticulo.IdUnidadMedida = odrDatos("var_IdUnidadMedida")
                    _enArticulo.Descripcion = odrDatos("var_Descripcion")
                    _enArticulo.Estado = odrDatos("chr_Estado")

                End While


            Catch ex As Exception
                '_objError = ex

            End Try

            Return _enArticulo

        End Function

        Public Function Listar(ByVal ar As EN_Articulo) As List(Of EN_Articulo)
            Dim _lstArticulo = New List(Of EN_Articulo)

            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Articulo_Listar"
                _objConexion.AddParameter("var_IdSubFamilia", ar.IdSubFamilia)

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()


                While odrDatos.Read

                    Dim _enArticulo = New EN_Articulo

                    _enArticulo.IdArticulo = odrDatos("var_IdArticulo")
                    _enArticulo.IdSubFamilia = odrDatos("var_IdSubFamilia")
                    _enArticulo.IdUnidadMedida = odrDatos("var_IdUnidadMedida")
                    _enArticulo.Descripcion = odrDatos("var_Descripcion")
                    _enArticulo.Estado = odrDatos("chr_Estado")

                    _lstArticulo.Add(_enArticulo)

                End While

            Catch ex As Exception
                ' _objError = ex

            End Try

            Return _lstArticulo


        End Function

        'OTRAS FUNCIONES
        Public Function Buscar(ByVal ar As EN_Articulo) As EN_Articulo
            Dim _enArticulo = New EN_Articulo()

            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Articulo_Buscar"

                _objConexion.AddParameter("var_IdArticulo", ar.IdArticulo)
                _objConexion.AddParameter("var_IdSubFamilia", ar.IdSubFamilia)
                _objConexion.AddParameter("var_Descripcion", ar.Descripcion)

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()


                While odrDatos.Read

                    _enArticulo.IdArticulo = odrDatos("var_IdArticulo")
                    _enArticulo.IdSubFamilia = odrDatos("var_IdSubFamilia")
                    _enArticulo.Descripcion = odrDatos("var_Descripcion")
                    _enArticulo.Estado = odrDatos("chr_Estado")

                End While

            Catch ex As Exception
                '_objError = ex

            End Try

            Return _enArticulo


        End Function
        Public Function BuscarPT(ByVal ar As EN_Articulo) As EN_Articulo
            Dim _enArticulo = New EN_Articulo()

            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Articulo_BuscarPT"
                _objConexion.AddParameter("var_IdArticulo", ar.IdArticulo)
                _objConexion.AddParameter("var_IdSubFamilia", ar.IdSubFamilia)
                _objConexion.AddParameter("var_Descripcion", ar.Descripcion)

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()


                While odrDatos.Read

                    _enArticulo.IdArticulo = odrDatos("var_IdArticulo")
                    _enArticulo.IdSubFamilia = odrDatos("var_IdSubFamilia")
                    _enArticulo.Descripcion = odrDatos("var_Descripcion")
                    _enArticulo.IdUnidadMedida = odrDatos("var_IdUnidadMedida")
                    _enArticulo.Estado = odrDatos("chr_Estado")

                End While

            Catch ex As Exception
                '_objError = ex

            End Try

            Return _enArticulo

        End Function
        Public Function BuscarEmpresa(ByVal ar As EN_Articulo) As List(Of EN_Articulo)

            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Articulo_BuscarEmpresa"

                _objConexion.AddParameter("var_IdEmpresa", ar.IdEmpresa)
                _objConexion.AddParameter("var_IdArticulo", ar.IdArticulo)
                _objConexion.AddParameter("var_Descripcion", ar.Descripcion)

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstArticulo = New List(Of EN_Articulo)

                While odrDatos.Read
                    Dim _enArticulo = New EN_Articulo()
                    _enArticulo.IdArticulo = odrDatos("var_IdArticulo")
                    _enArticulo.Descripcion = odrDatos("var_Descripcion")
                    _enArticulo.DesUnidadMedida = odrDatos("var_DesUnidadMedida")

                    _lstArticulo.Add(_enArticulo)
                End While
            Catch ex As Exception
                _objError = ex
            End Try

            Return _lstArticulo

        End Function
       
       
        Public Function Buscar1(ByVal ar As EN_Articulo) As EN_Articulo
           
            Dim _enArticulo = New EN_Articulo()

            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Articulo_Buscar1"
                _objConexion.AddParameter("var_IdArticulo", ar.IdArticulo)
                _objConexion.AddParameter("var_Descripcion", ar.Descripcion)

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()


                While odrDatos.Read

                    _enArticulo.IdArticulo = odrDatos("var_IdArticulo")
                    _enArticulo.IdSubFamilia = odrDatos("var_IdSubFamilia")
                    _enArticulo.Descripcion = odrDatos("var_Descripcion")
                    _enArticulo.Estado = odrDatos("chr_Estado")

                End While

            Catch ex As Exception
                '_objError = ex

            End Try

            Return _enArticulo


        End Function
        Public Function Obtener1(ByVal ar As EN_Articulo) As List(Of EN_Articulo)

            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_usp_Articulo_Obtener"
                _objConexion.AddParameter("var_IdArticuloReferencia", ar.IdArticulo)

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstArticulo = New List(Of EN_Articulo)

                While odrDatos.Read
                    Dim _enArticulo = New EN_Articulo()
                    _enArticulo.IdArticulo = odrDatos("var_IdArticulo")
                    _enArticulo.Descripcion = odrDatos("var_Descripcion")
                    _enArticulo.DesUnidadMedida = odrDatos("var_DesUnidadMedida")
                    _enArticulo.IdUnidadMedida = odrDatos("var_IdUnidadMedida")
                    _lstArticulo.Add(_enArticulo)
                End While

            Catch ex As Exception
                '_objError = ex

            End Try

            Return _lstArticulo

        End Function

#End Region


    End Class

End Namespace

