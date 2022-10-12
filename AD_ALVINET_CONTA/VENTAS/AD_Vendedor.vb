
Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.VENTAS
Imports System.Data
Imports System.Data.SqlClient
Imports EN_ALVINET_CONTA

Namespace VENTAS


    Public Class AD_Vendedor



        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstVendedores As List(Of EN_Vendedor)
        Private _entVendedor As New EN_Vendedor


#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property


        Public ReadOnly Property lstVendedores As List(Of EN_Vendedor)
            Get
                Return _lstVendedores
            End Get
        End Property

        Public Property entVendedor As EN_Vendedor
            Get
                Return _entVendedor
            End Get
            Set(ByVal Value As EN_Vendedor)
                _entVendedor = Value
            End Set
        End Property

#End Region


#Region "METODOS Y FUNCIONES"

        Public Function Registrar() As Boolean


            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_usp_VendedorPtoVenta_Registrar"

                _objConexion.AddParameter("var_IdVendedor", _entVendedor.IdVendedor)
                _objConexion.AddParameter("var_NombreVendedor", _entVendedor.Nombre)
                _objConexion.AddParameter("var_ApellidosVendedor", _entVendedor.ApellidoPaterno)
                _objConexion.AddParameter("chr_IdEstado", _entVendedor.Estado)
                _objConexion.AddParameter("var_Usuario", _entVendedor.Usuario)

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
                _objConexion.Procedimiento = "SGC_usp_VendedorPtoVenta_Eliminar"
                _objConexion.AddParameter("var_IdVendedor", _entVendedor.IdVendedor)

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
                _objConexion.Procedimiento = "SGC_usp_VendedorPtoVenta_Listar"
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstVendedores = New List(Of EN_Vendedor)
                While odrDatos.Read

                    _entVendedor.IdVendedor = odrDatos("var_IdVendedor")
                    _entVendedor.Usuario = odrDatos("var_IdUsuario")
                    _entVendedor.Estado = odrDatos("var_Estado")
                    _entVendedor.NombreCompleto = odrDatos("var_Nombrecompleto")

                    _lstVendedores.Add(_entVendedor)
                End While
                Return (_lstVendedores.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function



        Public Function Obtener() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_usp_VendedorPtoVenta_Obtener"
                _objConexion.AddParameter("var_IdVendedor", _entVendedor.IdVendedor)

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstVendedores = New List(Of EN_Vendedor)
                While odrDatos.Read
                    _entVendedor = New EN_Vendedor

                    _entVendedor.IdVendedor = odrDatos("var_IdVendedor")
                    _entVendedor.Nombre = odrDatos("var_NombreVendedor")
                    _entVendedor.ApellidoPaterno = odrDatos("var_ApellidosVendedor")
                    _entVendedor.Estado = odrDatos("chr_IdEstado")

                    _lstVendedores.Add(_entVendedor)
                End While

                Return (_lstVendedores.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
#End Region


    End Class
End Namespace