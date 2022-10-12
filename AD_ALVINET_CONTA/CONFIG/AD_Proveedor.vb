Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.CONFIG
Imports System.Data.SqlClient

Namespace CONFIG

    Public Class AD_Proveedor

#Region "Varibles"
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstProveedores As List(Of EN_Proveedor)
        Private _entProveedor As New EN_Proveedor
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstProveedores As List(Of EN_Proveedor)
            Get
                Return _lstProveedores
            End Get
        End Property

        Public Property entProveedor As EN_Proveedor
            Get
                Return _entProveedor
            End Get
            Set(ByVal Value As EN_Proveedor)
                _entProveedor = Value
            End Set
        End Property



#End Region
#Region "Funciones"
        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Proveedor_Registrar"
                _objConexion.AddParameter("var_IdEmpresa", _entProveedor.IdEmpresa)
                _objConexion.AddParameter("var_IdProveedor", _entProveedor.IdProveedor)
                _objConexion.AddParameter("var_RazonSocial", _entProveedor.RazonSocial)
                _objConexion.AddParameter("chr_RUC", _entProveedor.Ruc)
                _objConexion.AddParameter("var_Direccion", _entProveedor.Direccion)
                _objConexion.AddParameter("var_EsNacional", _entProveedor.ENacional)
                _objConexion.AddParameter("var_Retencion", _entProveedor.Retencion)
                _objConexion.AddParameter("var_Detraccion", _entProveedor.Detraccion)
                _objConexion.AddParameter("var_Telefono", _entProveedor.Telefono)
                _objConexion.AddParameter("var_Contacto", _entProveedor.Contacto)
                _objConexion.AddParameter("var_Dni", _entProveedor.DNI)
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
                _objConexion.Procedimiento = "ERP_usp_Proveedor_Eliminar"
                _objConexion.AddParameter("var_idEmpresa", _entProveedor.IdEmpresa)
                _objConexion.AddParameter("var_IdProveedor", _entProveedor.IdProveedor)

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
                _objConexion.Procedimiento = "ERP_usp_Proveedor_Listar"
                _objConexion.AddParameter("var_IdEmpresa", _entProveedor.IdEmpresa)

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstProveedores = New List(Of EN_Proveedor)

                While odrDatos.Read

                    _entProveedor = New EN_Proveedor

                    _entProveedor.IdProveedor = odrDatos("var_IdProveedor")
                    _entProveedor.IdEmpresa = odrDatos("var_idEmpresa")
                    _entProveedor.EmpRazonSocial = odrDatos("var_desEmpresa")
                    _entProveedor.RazonSocial = odrDatos("var_RazonSocial")
                    _entProveedor.Ruc = odrDatos("chr_RUC")
                    _entProveedor.Direccion = odrDatos("var_Direccion")
                    _entProveedor.ENacional = odrDatos("var_EsNacional")

                    _entProveedor.Telefono = odrDatos("var_Telefono")
                    _entProveedor.Contacto = odrDatos("var_Contacto")
                    _entProveedor.DNI = odrDatos("var_Dni")

                    _lstProveedores.Add(_entProveedor)
                End While

                Return (_lstProveedores.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function

        Public Function Buscar() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "erp_usp_proveedor_buscar"
                _objConexion.AddParameter("var_IdEmpresa", _entProveedor.IdEmpresa)
                _objConexion.AddParameter("varRuc", _entProveedor.Ruc)
                _objConexion.AddParameter("var_RazonSocial", _entProveedor.RazonSocial)
                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstProveedores = New List(Of EN_Proveedor)

                While odrDatos.Read

                    _entProveedor = New EN_Proveedor

                    _entProveedor.Ruc = odrDatos("chr_RUC")
                    _entProveedor.RazonSocial = odrDatos("var_RazonSocial")

                    _lstProveedores.Add(_entProveedor)
                End While

                Return (_lstProveedores.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
#End Region

    End Class
End Namespace