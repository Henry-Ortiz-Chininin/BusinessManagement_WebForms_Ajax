Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.AccesoDatos
Imports System.Data.SqlClient

Namespace CONFIG

    Public Class AD_OperacionCuenta

#Region "Variables"
        Private _lstOperacionCuenta As List(Of EN_OperacionesCuenta)
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As Exception
        Private _entOperacionCuenta As New EN_OperacionesCuenta
#End Region
#Region "Propiedades"

        Public ReadOnly Property lstOperacionCuenta() As List(Of EN_OperacionesCuenta)
            Get
                Return _lstOperacionCuenta
            End Get
        End Property

        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property

        Public Property entOperacionCuenta() As EN_OperacionesCuenta
            Get
                Return _entOperacionCuenta
            End Get
            Set(ByVal value As EN_OperacionesCuenta)
                _entOperacionCuenta = value
            End Set
        End Property




#End Region
#Region "Metodos y funciones"

        Sub New()
            _entOperacionCuenta = New EN_OperacionesCuenta
        End Sub

        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_OperacionCuenta_Registrar"
                _objConexion.AddParameter("var_Id", _entOperacionCuenta.IdOperacionCuenta)
                _objConexion.AddParameter("var_IdEmpresa", _entOperacionCuenta.IdEmpresa)
                _objConexion.AddParameter("var_IdOperacion", _entOperacionCuenta.IdOperacion)
                _objConexion.AddParameter("var_IdContabilidad", _entOperacionCuenta.Idcontabilidad)
                _objConexion.AddParameter("var_IdCuenta", _entOperacionCuenta.IdCuentaContable)
                _objConexion.AddParameter("var_EsCargo", _entOperacionCuenta.EsCargo)
                _objConexion.AddParameter("var_EsAbono", _entOperacionCuenta.EsAbono)
                _objConexion.AddParameter("var_EsObligatorio", _entOperacionCuenta.EsObligatorio)
                _objConexion.AddParameter("var_IdSubOperacion", _entOperacionCuenta.IdSubOperacion)
                _objConexion.AddParameter("var_Descripcion", _entOperacionCuenta.Nombre)
                _objConexion.AddParameter("var_Observacion", _entOperacionCuenta.Observacion)
                _objConexion.AddParameter("var_Movimiento", _entOperacionCuenta.TipoMovimiento)
                _entOperacionCuenta.IdOperacionCuenta = _objConexion.EjecutarComando()

                Return True
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function Agregar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_utb_VoucherCuenta_Agregar"

                _objConexion.AddParameter("var_IdEmpresa", _entOperacionCuenta.IdEmpresa)
                _objConexion.AddParameter("var_IdOperacion", _entOperacionCuenta.IdOperacion)
                _objConexion.AddParameter("var_IdContabilidad", _entOperacionCuenta.Idcontabilidad)
                _objConexion.AddParameter("var_IdCuenta", _entOperacionCuenta.IdCuentaContable)
                _objConexion.AddParameter("var_Descripcion", _entOperacionCuenta.Nombre)
                _objConexion.AddParameter("var_Escargo", _entOperacionCuenta.EsCargo)
                _objConexion.AddParameter("var_EsAbono", _entOperacionCuenta.EsAbono)
                _objConexion.AddParameter("var_Observacion", _entOperacionCuenta.Observacion)

                _objConexion.EjecutarComando()

                Return True
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function Quitar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_utb_VoucherCuenta_Eliminar"
                _objConexion.AddParameter("var_IdCuenta", _entOperacionCuenta.IdCuentaContable)

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
                _objConexion.Procedimiento = "ERP_usp_OperacionCuenta_Eliminar"

                _objConexion.AddParameter("var_IdCuenta", _entOperacionCuenta.IdCuentaContable)
                _objConexion.AddParameter("var_IdEmpresa", _entOperacionCuenta.IdEmpresa)
                _objConexion.AddParameter("var_IdOperacion", _entOperacionCuenta.IdOperacion)
                _objConexion.AddParameter("var_IdContabilidad", _entOperacionCuenta.Idcontabilidad)
                _objConexion.AddParameter("var_IdSubOperacion", _entOperacionCuenta.IdSubOperacion)

                _objConexion.EjecutarComando()
                Return True
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function ListarC() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_utb_VoucherCuenta_Listar"
                Dim drDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstOperacionCuenta = New List(Of EN_OperacionesCuenta)

                While drDatos.Read
                    _entOperacionCuenta = New EN_OperacionesCuenta
                    _entOperacionCuenta.IdCuentaContable = drDatos("var_IdCuenta")
                    _entOperacionCuenta.Nombre = drDatos("var_Descripcion")
                    _entOperacionCuenta.EsCargo = drDatos("var_Escargo")
                    _entOperacionCuenta.EsAbono = drDatos("var_EsAbono")
                    _entOperacionCuenta.Observacion = drDatos("var_Observacion")
                    _entOperacionCuenta.Flag = drDatos("Flag")
                    _lstOperacionCuenta.Add(_entOperacionCuenta)

                End While
                Return (_lstOperacionCuenta.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function Listar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_OperacionCuenta_Listar"
                _objConexion.AddParameter("var_IdEmpresa", _entOperacionCuenta.IdEmpresa)
                _objConexion.AddParameter("var_IdSubOperacion", _entOperacionCuenta.IdSubOperacion)

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstOperacionCuenta = New List(Of EN_OperacionesCuenta)
                While odrDatos.Read
                    _entOperacionCuenta = New EN_OperacionesCuenta

                    _entOperacionCuenta.IdCuentaContable = odrDatos("var_IdCuenta")
                    _entOperacionCuenta.Nombre = odrDatos("var_Nombre")
                    _entOperacionCuenta.IdEmpresa = odrDatos("var_IdEmpresa")
                    _entOperacionCuenta.RazonSocial = odrDatos("var_RazonSocial")
                    _entOperacionCuenta.IdOperacion = odrDatos("var_IdOperacion")
                    _entOperacionCuenta.Operacion = odrDatos("var_desOperacion")
                    _entOperacionCuenta.Idcontabilidad = odrDatos("var_IdContabilidad")
                    _entOperacionCuenta.Contabilidad = odrDatos("var_desContabilidad")
                    _entOperacionCuenta.EsCargo = odrDatos("var_Escargo")
                    _entOperacionCuenta.EsAbono = odrDatos("var_EsAbono")
                    _entOperacionCuenta.EsObligatorio = odrDatos("var_EsObligatorio")
                    _entOperacionCuenta.IdSubOperacion = odrDatos("var_IdSubOperacion")
                    _entOperacionCuenta.SubOperacion = odrDatos("SubOperacion")
                    _entOperacionCuenta.Nombre = odrDatos("var_Descripcion")
                    _entOperacionCuenta.Observacion = odrDatos("var_Observacion")
                    _entOperacionCuenta.IdOperacionCuenta = odrDatos("var_IdOperacionCuenta")
                    _entOperacionCuenta.CuentaEntidad = odrDatos("var_NumeroCuenta")
                    _entOperacionCuenta.IdCuentaEntidad = odrDatos("var_CuentaEntidad")
                    _entOperacionCuenta.EntidadFinanciera = odrDatos("var_NombreEntidad")
                    _entOperacionCuenta.IdEntidadFinanciera = odrDatos("var_IdEntidadFinanciera")
                    _entOperacionCuenta.IdMoneda = odrDatos("var_IdMoneda")
                    _entOperacionCuenta.Moneda = odrDatos("var_NombreMoneda")
                    _lstOperacionCuenta.Add(_entOperacionCuenta)
                End While

                Return (_lstOperacionCuenta.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function Buscar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "[dbo].[ERP_usp_Cuenta_Buscar]"
                _objConexion.AddParameter("var_IdCuenta", _entOperacionCuenta.IdCuentaContable)
                _objConexion.AddParameter("var_descripcion", _entOperacionCuenta.Nombre)
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstOperacionCuenta = New List(Of EN_OperacionesCuenta)
                While odrDatos.Read
                    _entOperacionCuenta = New EN_OperacionesCuenta

                    _entOperacionCuenta.IdCuentaContable = odrDatos("var_IdCuenta")
                    _entOperacionCuenta.Nombre = odrDatos("var_descripcion")
                    _entOperacionCuenta.CuentaContable = odrDatos("var_descripcion")
                    _lstOperacionCuenta.Add(_entOperacionCuenta)
                End While

                Return (_lstOperacionCuenta.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function

        
#End Region

    End Class
End Namespace
