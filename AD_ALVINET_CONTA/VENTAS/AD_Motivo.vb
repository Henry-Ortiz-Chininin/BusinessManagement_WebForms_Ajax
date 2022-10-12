Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.VENTAS
Imports System.Data
Imports System.Data.SqlClient
Imports EN_ALVINET_CONTA

Namespace VENTAS
    Public Class AD_Motivo

        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstMotivos As List(Of EN_Motivo)
        Private _entMotivo As New EN_Motivo


#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property


        Public ReadOnly Property lstMotivos As List(Of EN_Motivo)
            Get
                Return _lstMotivos
            End Get
        End Property

        Public Property entMotivo As EN_Motivo
            Get
                Return _entMotivo
            End Get
            Set(ByVal Value As EN_Motivo)
                _entMotivo = Value
            End Set
        End Property

#End Region


#Region "METODOS Y FUNCIONES"


        Public Function Registrar() As Boolean


            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Motivo_Registrar"
                _objConexion.AddParameter("var_idMotivo", _entMotivo.IdMotivo)
                _objConexion.AddParameter("var_Descripcion", _entMotivo.Descripcion)
                _objConexion.AddParameter("chr_Estado", _entMotivo.Estado)
                _objConexion.AddParameter("var_Usuario", _entMotivo.Usuario)


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
                _objConexion.Procedimiento = "SGC_uspe_Motivo_Eliminar"
                _objConexion.AddParameter("var_idMotivo", _entMotivo.IdMotivo)

                _objConexion.EjecutarComando()
                Return True
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function






        Public Function Obtener() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Motivo_Obtener"
                _objConexion.AddParameter("var_idMotivo", _entMotivo.IdMotivo)

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstMotivos = New List(Of EN_Motivo)
                While odrDatos.Read
                    _entMotivo = New EN_Motivo

                    _entMotivo.IdMotivo = odrDatos("var_idMotivo")
                    _entMotivo.Descripcion = odrDatos("var_Descripcion")
                    _entMotivo.Estado = odrDatos("chr_Estado")

                    _lstMotivos.Add(_entMotivo)
                End While

                Return (_lstMotivos.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function



        Public Function Listar() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer

                _objConexion.Procedimiento = "SGC_uspe_Motivo_Listar"

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstMotivos = New List(Of EN_Motivo)

                While odrDatos.Read
                    Dim _entMotivo1 As New EN_Motivo

                    _entMotivo1.IdMotivo = odrDatos("var_idMotivo")
                    _entMotivo1.Descripcion = IIf(IsDBNull(odrDatos("var_Descripcion")), "", odrDatos("var_Descripcion"))
                    _entMotivo1.Estado = IIf(IsDBNull(odrDatos("chr_Estado")), "", odrDatos("chr_Estado"))
                    _entMotivo1.Usuario = IIf(IsDBNull(odrDatos("var_UsuarioCreacion")), "", odrDatos("var_UsuarioCreacion"))

                    _lstMotivos.Add(_entMotivo1)
                End While

                Return (_lstMotivos.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function




        Public Function Buscar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Motivo_Buscar"

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstMotivos = New List(Of EN_Motivo)

                While odrDatos.Read

                    _entMotivo = New EN_Motivo
                    _entMotivo.Descripcion = odrDatos("var_Descripcion")

                    _lstMotivos.Add(_entMotivo)
                End While

                Return (_lstMotivos.Count > 0)

            Catch ex As Exception
                _objError = ex

                Return False
            End Try
        End Function


#End Region

    End Class
End Namespace