Imports EN_ALVINET_CONTA.OPERACION
Imports AD_ALVINET_CONTA.AccesoDatos
Imports System.Data.SqlClient

Namespace OPERACION
    Public Class AD_VoucherCuenta
#Region "Variables"
        Private _objConexion As AccesoDatos.AccesoDatosSQLServer
        Private _entVoucherCuenta As EN_VoucherCuenta
        Private _lstVoucherCuentas As List(Of EN_VoucherCuenta)
        Private _objError As New Exception
#End Region
#Region "Propiedades"
        Public Property entPlanCuenta() As EN_VoucherCuenta
            Get
                Return _entVoucherCuenta
            End Get
            Set(ByVal value As EN_VoucherCuenta)
                _entVoucherCuenta = value
            End Set
        End Property

        Public ReadOnly Property lstPlaneCuentas() As List(Of EN_VoucherCuenta)
            Get
                Return _lstVoucherCuentas
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
                _objConexion.AddParameter("var_Idempresa", _entVoucherCuenta.IdEmpresa)
                _objConexion.AddParameter("var_idEjercicioEmpresa", _entVoucherCuenta.IdEjercicio)
                _objConexion.AddParameter("var_IdContabilidad", _entVoucherCuenta.IdContabilidad)
                _objConexion.AddParameter("var_IdOperacion", _entVoucherCuenta.IdOperacion)
                _objConexion.AddParameter("var_IdAsiento", _entVoucherCuenta.IdAsiento)
                _objConexion.AddParameter("var_IdCuenta", _entVoucherCuenta.IdCuentaContable)
                _objConexion.AddParameter("var_EsCargo", _entVoucherCuenta.EsCargo)
                _objConexion.AddParameter("dec_Importe", _entVoucherCuenta.Total)
                _objConexion.AddParameter("var_Observacion", _entVoucherCuenta.Glosa)
                _objConexion.AddParameter("var_IdConciliacion", _entVoucherCuenta.IdConciliacion)
                _objConexion.AddParameter("var_IdOperacionCuenta", "")

                _objConexion.EjecutarComando()
                Return True
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function Agregar() As Boolean
            Try
                _objConexion = New AccesoDatos.AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_utb_VoucherCuenta_Agregar"

                _objConexion.AddParameter("var_Idempresa", _entVoucherCuenta.IdEmpresa)
                _objConexion.AddParameter("var_idEjercicioEmpresa", _entVoucherCuenta.IdEjercicio)
                _objConexion.AddParameter("var_IdContabilidad", _entVoucherCuenta.IdContabilidad)
                _objConexion.AddParameter("var_IdOperacion", _entVoucherCuenta.IdOperacion)
                _objConexion.AddParameter("var_IdAsiento", _entVoucherCuenta.IdAsiento)
                _objConexion.AddParameter("var_IdCuenta", _entVoucherCuenta.IdCuentaContable)
                _objConexion.AddParameter("var_EsCargo", _entVoucherCuenta.EsCargo)
                _objConexion.AddParameter("dec_Importe", _entVoucherCuenta.Total)
                _objConexion.AddParameter("var_observacion", _entVoucherCuenta.Glosa)

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
                _objConexion.Procedimiento = "ERP_usp_VoucherCuenta_Listar"

                Dim odrDatos As SqlClient.SqlDataReader = _objConexion.ObtenerDataReader()
                _lstVoucherCuentas = New List(Of EN_VoucherCuenta)

                While odrDatos.Read
                    _entVoucherCuenta = New EN_VoucherCuenta

                    _entVoucherCuenta.IdCuentaContable = odrDatos("var_IdCuenta")
                    _entVoucherCuenta.IdEmpresa = odrDatos("var_IdEmpresa")
                    _entVoucherCuenta.IdEmpresa = odrDatos("var_RazonSocial")

                    _entVoucherCuenta.IdEjercicio = odrDatos("var_IdEjercicioEmpresa")

                    _entVoucherCuenta.IdContabilidad = odrDatos("var_IdContabilidad")
                    _entVoucherCuenta.Contabilidad = odrDatos("desContabilidad")

                    _entVoucherCuenta.IdOperacion = odrDatos("var_IdOperacion")
                    _entVoucherCuenta.IdOperacion = odrDatos("desOperacion")

                    _entVoucherCuenta.IdAsiento = odrDatos("var_IdAsiento")
                    _entVoucherCuenta.EsCargo = odrDatos("var_EsCargo")
                    _entVoucherCuenta.Total = odrDatos("dec_Importe")
                    _entVoucherCuenta.Glosa = odrDatos("var_Observacion")

                    _lstVoucherCuentas.Add(_entVoucherCuenta)

                End While
                Return (_lstVoucherCuentas.Count > 0)

            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatos.AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_VoucherCuenta_Eliminar"

                _objConexion.AddParameter("var_Idempresa", _entVoucherCuenta.IdEmpresa)
                _objConexion.AddParameter("var_idEjercicioEmpresa", _entVoucherCuenta.IdEjercicio)
                _objConexion.AddParameter("var_IdContabilidad", _entVoucherCuenta.IdContabilidad)
                _objConexion.AddParameter("var_IdOperacion", _entVoucherCuenta.IdOperacion)
                _objConexion.AddParameter("var_IdAsiento", _entVoucherCuenta.IdAsiento)
                _objConexion.AddParameter("var_IdCuenta", _entVoucherCuenta.IdCuentaContable)

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