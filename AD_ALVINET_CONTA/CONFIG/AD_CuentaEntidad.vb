Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.CONFIG
Imports System.Data.SqlClient

Namespace CONFIG

    Public Class AD_CuentaEntidad
#Region "Variables"
        Private _objConexion As AccesoDatos.AccesoDatosSQLServer
        Private _entCuentaEntidad As EN_CuentaEntidad
        Private _lstCuentaEntidad As List(Of EN_CuentaEntidad)
        Private _objError As New Exception
#End Region
#Region "Propiedades"

        Public Property entCuentaEntidad() As EN_CuentaEntidad
            Get
                Return _entCuentaEntidad
            End Get
            Set(ByVal value As EN_CuentaEntidad)
                _entCuentaEntidad = value
            End Set
        End Property
        Public ReadOnly Property lstCuentaEntidad() As List(Of EN_CuentaEntidad)
            Get
                Return _lstCuentaEntidad
            End Get
        End Property

        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property
#End Region
#Region "Metodos y Funciones "

        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatos.AccesoDatosSQLServer

                _objConexion.Procedimiento = "ERP_usp_CuentaEntidad_Registrar"

                _objConexion.AddParameter("var_IdEmpresa", _entCuentaEntidad.IdEmpresa)
                _objConexion.AddParameter("var_IdEntidadFinanciera", _entCuentaEntidad.IdEntidadFinanciera)
                _objConexion.AddParameter("int_IdSecuencial", _entCuentaEntidad.Secuencia)
                _objConexion.AddParameter("var_IdMoneda", _entCuentaEntidad.IdMoneda)
                _objConexion.AddParameter("var_NumeroCuenta", _entCuentaEntidad.NumeroCuenta)
                _objConexion.EjecutarComando()

                Return True

            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function

        Public Function Listar() As Boolean
            Try
                _objConexion = New AccesoDatos.AccesoDatosSQLServer

                _objConexion.Procedimiento = "ERP_usp_CuentaEntidad_Listar"
                _objConexion.AddParameter("var_IdEmpresa", _entCuentaEntidad.IdEmpresa)
                _objConexion.AddParameter("var_IdEntidadFinanciera", _entCuentaEntidad.IdEntidadFinanciera)

                Dim odrDatos As SqlClient.SqlDataReader = _objConexion.ObtenerDataReader()
                _lstCuentaEntidad = New List(Of EN_CuentaEntidad)

                While odrDatos.Read
                    _entCuentaEntidad = New EN_CuentaEntidad

                    _entCuentaEntidad.Secuencia = odrDatos("int_IdSecuencial")
                    _entCuentaEntidad.IdEmpresa = odrDatos("var_IdEmpresa")
                    _entCuentaEntidad.RazonSocial = odrDatos("var_RazonSocial")
                    _entCuentaEntidad.IdEntidadFinanciera = odrDatos("var_IdEntidadFinanciera")
                    _entCuentaEntidad.NombreEntidad = odrDatos("var_desEntidadFinanciera")
                    _entCuentaEntidad.IdMoneda = odrDatos("var_IdMoneda")
                    _entCuentaEntidad.Moneda = odrDatos("var_desMoneda")
                    _entCuentaEntidad.NumeroCuenta = odrDatos("var_NumeroCuenta")

                    _lstCuentaEntidad.Add(_entCuentaEntidad)
                End While
                Return (_lstCuentaEntidad.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function ListarDetalle() As Boolean
            Try
                _objConexion = New AccesoDatos.AccesoDatosSQLServer

                _objConexion.Procedimiento = "[dbo].[ERP_usp_CuentaEntidad_Detalle]"
                _objConexion.AddParameter("var_IdEntidadFinanciera", _entCuentaEntidad.IdEntidadFinanciera)

                Dim odrDatos As SqlClient.SqlDataReader = _objConexion.ObtenerDataReader()
                _lstCuentaEntidad = New List(Of EN_CuentaEntidad)

                While odrDatos.Read
                    _entCuentaEntidad = New EN_CuentaEntidad

                    _entCuentaEntidad.Secuencia = odrDatos("int_IdSecuencial")
                    _entCuentaEntidad.IdEmpresa = odrDatos("var_IdEmpresa")
                    _entCuentaEntidad.RazonSocial = odrDatos("var_RazonSocial")
                    _entCuentaEntidad.IdEntidadFinanciera = odrDatos("var_IdEntidadFinanciera")
                    _entCuentaEntidad.NombreEntidad = odrDatos("EntidadFinanciera")
                    _entCuentaEntidad.IdMoneda = odrDatos("var_IdMoneda")
                    _entCuentaEntidad.Moneda = odrDatos("Moneda")
                    _entCuentaEntidad.NumeroCuenta = odrDatos("var_NumeroCuenta")
                    _lstCuentaEntidad.Add(_entCuentaEntidad)
                End While
                Return (_lstCuentaEntidad.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatos.AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_CuentaEntidad_Eliminar"

                _objConexion.AddParameter("int_IdSecuencial", _entCuentaEntidad.Secuencia)
                _objConexion.AddParameter("var_IdEmpresa", _entCuentaEntidad.IdEmpresa)
                _objConexion.AddParameter("var_IdEntidadFinanciera", _entCuentaEntidad.IdEntidadFinanciera)
                _objConexion.EjecutarComando()
                Return True
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace