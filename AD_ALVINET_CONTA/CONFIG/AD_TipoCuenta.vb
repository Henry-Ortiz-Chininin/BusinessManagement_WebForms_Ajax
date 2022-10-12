
Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.CONFIG
Imports System.Data
Imports System.Data.SqlClient

Namespace CONFIG

    Public Class AD_TipoCuenta
#Region "Varibles"
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstTipoCuentas As List(Of EN_TipoCuenta)
        Private _entTipoCuenta As New EN_TipoCuenta
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstTipoCuentas As List(Of EN_TipoCuenta)
            Get
                Return _lstTipoCuentas
            End Get
        End Property

        Public Property entTipoCuenta As EN_TipoCuenta
            Get
                Return _entTipoCuenta
            End Get
            Set(ByVal Value As EN_TipoCuenta)
                _entTipoCuenta = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"
        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_TipoCuenta_Registrar"
                _objConexion.AddParameter("var_IdEmpresa", _entTipoCuenta.IdEmpresa)
                _objConexion.AddParameter("var_IdTipoCuenta", _entTipoCuenta.IdTipoCuenta)
                _objConexion.AddParameter("var_Descripcion", _entTipoCuenta.Descripcion)
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
                _objConexion.Procedimiento = "ERP_usp_TipoCuenta_Eliminar"
                _objConexion.AddParameter("var_idEmpresa", _entTipoCuenta.IdEmpresa)
                _objConexion.AddParameter("var_IdTipoCuenta", _entTipoCuenta.IdTipoCuenta)

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
                _objConexion.Procedimiento = "ERP_usp_TipoCuenta_Listar"
                _objConexion.AddParameter("var_IdEmpresa", _entTipoCuenta.IdEmpresa)

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstTipoCuentas = New List(Of EN_TipoCuenta)

                While odrDatos.Read

                    _entTipoCuenta = New EN_TipoCuenta

                    _entTipoCuenta.IdTipoCuenta = odrDatos("var_IdTipoCuenta")
                    _entTipoCuenta.IdEmpresa = odrDatos("var_idEmpresa")
                    _entTipoCuenta.RazonSocial = odrDatos("var_RazonSocial")
                    _entTipoCuenta.Descripcion = odrDatos("var_Descripcion")

                    _lstTipoCuentas.Add(_entTipoCuenta)

                End While

                Return (_lstTipoCuentas.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace