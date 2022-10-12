Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.CONFIG
Imports System.Data.SqlClient

Namespace CONFIG

    Public Class AD_PlanCuenta

#Region "Variables"
        Private _objConexion As AccesoDatos.AccesoDatosSQLServer
        Private _entPlanCuenta As EN_PlanCuenta
        Private _lstPlanCuentas As List(Of EN_PlanCuenta)
        Private _objError As New Exception
#End Region
#Region "Propiedades"
        Public Property entPlanCuenta() As EN_PlanCuenta
            Get
                Return _entPlanCuenta
            End Get
            Set(ByVal value As EN_PlanCuenta)
                _entPlanCuenta = value
            End Set
        End Property

        Public ReadOnly Property lstPlaneCuentas() As List(Of EN_PlanCuenta)
            Get
                Return _lstPlanCuentas
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
                _objConexion.Procedimiento = "ERP_usp_PlanCuenta_Registrar"

                _objConexion.AddParameter("var_IdEmpresa", _entPlanCuenta.IdEmpresa)
                _objConexion.AddParameter("var_IdContabilidad", _entPlanCuenta.IdContabilidad)
                _objConexion.AddParameter("var_IdPlanContable", _entPlanCuenta.IdPlanContable)
                _objConexion.AddParameter("var_IdCuenta", _entPlanCuenta.IdCuentaContable)
                _objConexion.AddParameter("var_Nombre", _entPlanCuenta.Nombre)
                _objConexion.AddParameter("var_IdNivel", _entPlanCuenta.IdNivel)
                _objConexion.AddParameter("var_IdTipoAnalisis", _entPlanCuenta.IdTipoAnalisis)
                _objConexion.AddParameter("var_IdTipoCuenta", _entPlanCuenta.IdTipoCuenta)
                _objConexion.AddParameter("var_DiferenciaCambio", _entPlanCuenta.DiferenciaCambio)
                _objConexion.AddParameter("var_ConversionMoneda", _entPlanCuenta.ConversionMoneda)
                _objConexion.AddParameter("var_IdEntidadFinanciera", _entPlanCuenta.IdEntidadFinanciera)
                _objConexion.AddParameter("var_Idmoneda", _entPlanCuenta.IdMoneda)
                _objConexion.AddParameter("var_CuentaEntidad", _entPlanCuenta.CuentaEntidad)
                _objConexion.AddParameter("var_CuentaDebe", _entPlanCuenta.CuentaDebe)
                _objConexion.AddParameter("var_CuentaHaber", _entPlanCuenta.CuentaHaber)
                _objConexion.AddParameter("var_IdCuentaPadre", _entPlanCuenta.IdCuentaPadre)

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
                _objConexion.Procedimiento = "ERP_usp_PlanCuenta_Listar"
                _objConexion.AddParameter("var_IdEmpresa", _entPlanCuenta.IdEmpresa)
                _objConexion.AddParameter("var_IdUsuario", _entPlanCuenta.IdUsuario)
                _objConexion.AddParameter("var_Nombre", _entPlanCuenta.Nombre)
                _objConexion.AddParameter("var_IdCuenta", _entPlanCuenta.IdCuentaContable)

                Dim odrDatos As SqlClient.SqlDataReader = _objConexion.ObtenerDataReader()
                _lstPlanCuentas = New List(Of EN_PlanCuenta)

                While odrDatos.Read
                    _entPlanCuenta = New EN_PlanCuenta

                    _entPlanCuenta.IdCuentaContable = odrDatos("var_IdCuenta")

                    _entPlanCuenta.IdEmpresa = odrDatos("var_IdEmpresa")
                    _entPlanCuenta.RazonSocial = odrDatos("var_RazonSocial")

                    _entPlanCuenta.IdContabilidad = odrDatos("var_IdContabilidad")
                    _entPlanCuenta.Contabilidad = odrDatos("var_desContabilidad")

                    _entPlanCuenta.IdPlanContable = odrDatos("var_IdPlanContable")
                    _entPlanCuenta.Formato = odrDatos("var_Formato")

                    _entPlanCuenta.Nombre = odrDatos("var_Nombre")

                    _entPlanCuenta.IdNivel = odrDatos("var_IdNivel")
                    _entPlanCuenta.Nivel = odrDatos("var_desNivelPlan")

                    _entPlanCuenta.IdTipoAnalisis = odrDatos("var_IdTipoAnalisis")
                    _entPlanCuenta.TipoAnalisis = odrDatos("var_desTipoAnalisis")

                    _entPlanCuenta.IdTipoCuenta = odrDatos("var_IdTipoCuenta")
                    _entPlanCuenta.TipoCuenta = odrDatos("var_desTipoCuenta")

                    _entPlanCuenta.DiferenciaCambio = odrDatos("var_DiferenciaCambio")
                    _entPlanCuenta.ConversionMoneda = odrDatos("var_ConversionMoneda")

                    _entPlanCuenta.IdEntidadFinanciera = odrDatos("var_IdEntidadFinanciera")
                    _entPlanCuenta.EntidadFinanciera = odrDatos("var_desEntidadFinanciera")

                    _entPlanCuenta.IdMoneda = odrDatos("var_idMoneda")
                    _entPlanCuenta.Moneda = odrDatos("var_desMoneda")
                    _entPlanCuenta.CuentaEntidad = odrDatos("var_CuentaEntidad")
                    _entPlanCuenta.CuentaEntidad = odrDatos("var_NumeroCuenta")
                    _entPlanCuenta.CuentaDebe = odrDatos("var_CuentaDebe")
                    _entPlanCuenta.CuentaHaber = odrDatos("var_CuentaHaber")
                    _entPlanCuenta.IdCuentaPadre = odrDatos("var_IdCuentaPadre")
                    _lstPlanCuentas.Add(_entPlanCuenta)

                End While
                Return (_lstPlanCuentas.Count > 0)

            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function

        Public Function ListarxEmpresa() As Boolean
            Try
                _objConexion = New AccesoDatos.AccesoDatosSQLServer
                _objConexion.Procedimiento = "[dbo].[ERP_usp_PlanCuenta_Listar_x_Empresa]"
                _objConexion.AddParameter("var_IdEmpresa", _entPlanCuenta.IdEmpresa)
                _objConexion.AddParameter("var_IdUsuario", _entPlanCuenta.IdUsuario)

                Dim odrDatos As SqlClient.SqlDataReader = _objConexion.ObtenerDataReader()
                _lstPlanCuentas = New List(Of EN_PlanCuenta)

                While odrDatos.Read
                    _entPlanCuenta = New EN_PlanCuenta

                    _entPlanCuenta.IdCuentaContable = odrDatos("var_IdCuenta")
                    _entPlanCuenta.IdEmpresa = odrDatos("var_IdEmpresa")
                    _entPlanCuenta.IdPlanContable = odrDatos("var_IdPlanContable")
                    _entPlanCuenta.Nombre = odrDatos("var_Nombre")

                    _lstPlanCuentas.Add(_entPlanCuenta)

                End While
                Return (_lstPlanCuentas.Count > 0)

            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatos.AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_PlanCuenta_Elimnar"

                _objConexion.AddParameter("var_IdEmpresa", _entPlanCuenta.IdEmpresa)
                _objConexion.AddParameter("var_IdContabilidad", _entPlanCuenta.IdContabilidad)
                _objConexion.AddParameter("var_IdPlanContable", _entPlanCuenta.IdPlanContable)
                _objConexion.AddParameter("var_IdCuenta", _entPlanCuenta.IdCuentaContable)

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