Imports EN_ALVINET_CONTA.OPERACION
Imports AD_ALVINET_CONTA.AccesoDatos
Imports System.Data.SqlClient

Namespace OPERACION
    Public Class AD_OperacionCuenta
#Region "Variables"
        Private _objConexion As AccesoDatos.AccesoDatosSQLServer
        Private _entOperacionCuenta As EN_OperacionCuenta
        Private _lstOperacionCuentas As List(Of EN_OperacionCuenta)
        Private _objError As New Exception
#End Region
#Region "Propiedades"
        Public Property entPlanCuenta() As EN_OperacionCuenta
            Get
                Return _entOperacionCuenta
            End Get
            Set(ByVal value As EN_OperacionCuenta)
                _entOperacionCuenta = value
            End Set
        End Property

        Public ReadOnly Property lstOperacionCuentas() As List(Of EN_OperacionCuenta)
            Get
                Return _lstOperacionCuentas
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
                _objConexion.Procedimiento = "ERP_usp_VoucherCuenta_Registrar"
                _objConexion.AddParameter("var_Idempresa", _entOperacionCuenta.IdEmpresa)
                _objConexion.AddParameter("var_idEjercicioEmpresa", _entOperacionCuenta.IdEjercicio)
                _objConexion.AddParameter("var_IdContabilidad", _entOperacionCuenta.Idcontabilidad)
                _objConexion.AddParameter("var_IdOperacion", _entOperacionCuenta.IdOperacion)
                '_objConexion.AddParameter("var_IdAsiento", _entOperacionCuenta.IdAsiento)
                '_objConexion.AddParameter("var_IdCuenta", _entOperacionCuenta.IdCuenta)
                _objConexion.AddParameter("var_EsCargo", _entOperacionCuenta.EsCargo)
                _objConexion.AddParameter("dec_Importe", _entOperacionCuenta.Importe)
                _objConexion.AddParameter("var_Observacion", _entOperacionCuenta.Observacion)
                '_objConexion.AddParameter("var_IdConciliacion", _entOperacionCuenta.IdConciliacion)
                _objConexion.AddParameter("var_IdOperacionCuenta", _entOperacionCuenta.IdOperacionCuenta)

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
