Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.OPERACION
Imports EN_ALVINET_CONTA.GENERAL
Imports EN_ALVINET_CONTA.CONFIG
Imports System.Data
Imports System.Data.SqlClient

Namespace OPERACION

    Public Class AD_Voucher
#Region "Variables"
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstVouchers As List(Of EN_Voucher)
        Private _entVoucher As New EN_Voucher

#End Region
#Region "Propiedades"

        Public ReadOnly Property lstVouchers() As List(Of EN_Voucher)
            Get
                Return _lstVouchers
            End Get
        End Property
        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property
        Public Property entVoucher() As EN_Voucher
            Get
                Return _entVoucher
            End Get
            Set(ByVal value As EN_Voucher)
                _entVoucher = value
            End Set
        End Property
#End Region
#Region "Metodos y funciones"
        Sub New()
            _entVoucher = New EN_Voucher
        End Sub
        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Voucher_Registrar"
                _objConexion.AddParameter("var_IdEmpresa", _entVoucher.IdEmpresa)
                _objConexion.AddParameter("var_IdEjercicioEmpresa", _entVoucher.EjercicioEmpresa.IdEjercicioEmpresa)
                _objConexion.AddParameter("var_IdContabilidad", _entVoucher.IdContabilidad)
                _objConexion.AddParameter("var_IdOperacion", _entVoucher.IdOperacion)
                _objConexion.AddParameter("chr_Estado", _entVoucher.Estado)
                _objConexion.AddParameter("dtm_Fecha", _entVoucher.Fecha)
                _objConexion.AddParameter("var_IdCentroCosto", _entVoucher.IdCentroCosto)
                _objConexion.AddParameter("var_IdProveedor", _entVoucher.IdProveedor)
                _objConexion.AddParameter("var_IdCliente", _entVoucher.Cliente.IdCliente)
                _objConexion.AddParameter("var_IdTipoDocumento", _entVoucher.TipoDocumento.IdTipoDocumento)
                _objConexion.AddParameter("var_NumeroDocumento", _entVoucher.NumeroDocumento)
                _entVoucher.Retorno = _objConexion.EjecutarComandoSalida().ToString()

                Return True

            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function

        Public Function Anular() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.AddParameter("prametro", entVoucher.IdNivel)
                _objConexion.AddParameter("var_IdEmpresa", entVoucher.IdEmpresa)
                _objConexion.AddParameter("var_IdEjercicioEmpresa", entVoucher.IdEjercicio)
                _objConexion.AddParameter("var_Idcontabilidad", entVoucher.IdContabilidad)
                _objConexion.AddParameter("var_IdOperacion", entVoucher.IdOperacion)
                _objConexion.AddParameter("var_Idasiento", entVoucher.IdAsiento)
                _objConexion.EjecutarComando("[dbo].[ERP_usp_Voucher_Anular]")
                Return True
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Voucher_Eliminar"
                _objConexion.AddParameter("var_IdAsiento", _entVoucher.IdAsiento)
                _objConexion.AddParameter("var_IdEmpresa", _entVoucher.IdEmpresa)
                _objConexion.AddParameter("var_IdEjercicioEmpresa", _entVoucher.EjercicioEmpresa.IdEjercicioEmpresa)
                _objConexion.AddParameter("var_IdContabilidad", _entVoucher.IdContabilidad)
                _objConexion.AddParameter("var_IdOperacion", _entVoucher.IdOperacion)
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
                _objConexion.Procedimiento = "ERP_usp_Voucher_Listar"
                _objConexion.AddParameter("var_IdOperacion", _entVoucher.IdOperacion)
                _objConexion.AddParameter("var_IdAsiento", _entVoucher.IdAsiento)
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstVouchers = New List(Of EN_Voucher)

                While odrDatos.Read
                    _entVoucher = New EN_Voucher

                    _entVoucher.IdOperacion = odrDatos("var_IdOperacion")
                    _entVoucher.DesOperacion = odrDatos("var_desOperacion")
                    _entVoucher.Fecha = odrDatos("dtm_Fecha")
                    _entVoucher.IdAsiento = odrDatos("var_IdAsiento")
                    _entVoucher.Vouchercuenta = New EN_VoucherCuenta
                    _entVoucher.IdCentroCosto = odrDatos("var_IdCentroCosto")
                    _entVoucher.DesCentroCosto = odrDatos("var_desCentroCosto")
                    _entVoucher.Cliente = New EN_Cliente
                    _entVoucher.IdCliente = odrDatos("var_IdCliente")
                    _entVoucher.Cliente = odrDatos("var_desCliente")
                    _entVoucher.IdProveedor = odrDatos("var_IdProveedor")
                    _entVoucher.Proveedor = odrDatos("var_desProveedor")
                    _entVoucher.TipoDocumento = New EN_TipoDocumento
                    _entVoucher.IdTipoDocumento = odrDatos("var_IdTipoDocumento")
                    _entVoucher.NumeroDocumento = odrDatos("var_NumeroDocumento")
                    _entVoucher.Glosa = odrDatos("var_Descripcion")
                    _entVoucher.DesTipoDocumento = odrDatos("Documento")


                    _lstVouchers.Add(_entVoucher)
                End While

                Return (_lstVouchers.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function

        Public Function BusqXOp(ByVal idPartida As String, ByVal idasiento As String) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer

                _objConexion.Procedimiento = "ERP_usp_CtaxOperacion"
                _objConexion.AddParameter("var_IdOperacion", idPartida)
                _objConexion.AddParameter("var_IdAsiento", idasiento)

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstVouchers = New List(Of EN_Voucher)

                While odrDatos.Read
                    _entVoucher = New EN_Voucher

                    _entVoucher.IdAsiento = odrDatos("var_IdAsiento")

                    _entVoucher.IdOperacion = odrDatos("var_IdOperacion")
                    _entVoucher.IdCuentaContable = odrDatos("var_IdCuenta")
                    _entVoucher.Nombre = odrDatos("var_Nombre")
                    _entVoucher.Total = odrDatos("dec_Importe")
                    _entVoucher.EsCargo = odrDatos("var_EsCargo")
                    _entVoucher.Glosa = odrDatos("var_Observacion")

                    If _entVoucher.EsCargo = "Ab" Then
                        _entVoucher.Abono = _entVoucher.Total
                        _entVoucher.Cargo = 0
                    ElseIf _entVoucher.EsCargo = "Ca" Then
                        _entVoucher.Cargo = _entVoucher.Total
                        _entVoucher.Abono = 0
                    End If

                    _lstVouchers.Add(_entVoucher)

                End While

                Return (_lstVouchers.Count > 0)

            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function

        Public Function ListarDetalle(ByVal idasiento As String, ByVal idOperacion As String) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer

                _objConexion.Procedimiento = "[dbo].[ERP_usp_Voucher_Detalle_Listar]"
                _objConexion.AddParameter("var_IdAsiento", idasiento)
                _objConexion.AddParameter("var_IdOperacion", idOperacion)

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstVouchers = New List(Of EN_Voucher)

                While odrDatos.Read
                    _entVoucher = New EN_Voucher

                    _entVoucher.IdAsiento = odrDatos("var_IdAsiento")

                    _entVoucher.IdOperacion = odrDatos("var_IdOperacion")
                    _entVoucher.DesOperacion = odrDatos("var_desOperacion")
                    _entVoucher.Glosa = odrDatos("var_Observacion")
                    _entVoucher.EsCargo = odrDatos("var_EsCargo")
                    _entVoucher.IdCuentaContable = odrDatos("var_IdCuenta")
                    _entVoucher.Total = odrDatos("dec_Importe")
                    If _entVoucher.EsCargo = "Ab" Then
                        _entVoucher.Abono = _entVoucher.Total
                        _entVoucher.Cargo = 0
                    ElseIf _entVoucher.EsCargo = "Ca" Then
                        _entVoucher.Cargo = _entVoucher.Total
                        _entVoucher.Abono = 0
                    End If

                    _lstVouchers.Add(_entVoucher)

                End While

                Return (_lstVouchers.Count > 0)

            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function BuscarxOp(ByVal idPartida As String, ByVal idasiento As String) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "[dbo].[ERP_usp_Voucher_Buscar_OP]"
                _objConexion.AddParameter("var_Operacion", idPartida)
                _objConexion.AddParameter("var_IdAsiento", idasiento)

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstVouchers = New List(Of EN_Voucher)

                While odrDatos.Read
                    _entVoucher = New EN_Voucher

                    _entVoucher.IdCuentaContable = odrDatos("var_IdCuenta")
                    _entVoucher.Nombre = odrDatos("var_Nombre")
                    _entVoucher.Total = odrDatos("dec_Importe")
                    _entVoucher.Glosa = odrDatos("var_Observacion")
                    _entVoucher.IdAsiento = odrDatos("var_IdAsiento")
                    _entVoucher.IdOperacion = odrDatos("var_IdOperacion")
                    _entVoucher.Fecha = odrDatos("dtm_Fecha")
                    _entVoucher.IdCentroCosto = odrDatos("var_IdCentroCosto")
                    _entVoucher.DesCentroCosto = odrDatos("var_DescripcionC")
                    _entVoucher.IdCliente = odrDatos("var_IdCliente")
                    _entVoucher.Cliente = odrDatos("var_DescripcionCL")
                    ' _entVoucher.NumeroDocuemnto = odrDatos("var_Descripcion")

                    _entVoucher.IdTipoDocumento = odrDatos("var_IdTipoDocumento")
                    _entVoucher.NumeroDocumento = odrDatos("var_Descripcion")
                    _entVoucher.IdProveedor = odrDatos("var_IdProveedor")
                    _entVoucher.Proveedor = odrDatos("var_RazonSocial")
                    _entVoucher.EsCargo = odrDatos("var_EsCargo")

                    If _entVoucher.EsCargo = "Ab" Then
                        _entVoucher.Cargo = _entVoucher.Total
                        _entVoucher.Abono = 0
                    ElseIf _entVoucher.EsCargo = "Ca" Then
                        _entVoucher.Abono = _entVoucher.Total
                        _entVoucher.Cargo = 0
                    End If

                    _lstVouchers.Add(_entVoucher)
                End While

                Return (_lstVouchers.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function


        Public Function Buscar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer

                _objConexion.Procedimiento = "ERP_usp_Voucher_Buscar"

                _objConexion.AddParameter("var_IdOperacion", _entVoucher.IdOperacion)

                '_entVoucher.Fecha = Date.Parse(_entVoucher.FechaString)
                _objConexion.AddParameter("var_Fecha", _entVoucher.Fecha)

                _objConexion.AddParameter("var_IdCentroCosto", _entVoucher.IdCentroCosto)
                _objConexion.AddParameter("var_IdProveedor", _entVoucher.IdProveedor)
                _objConexion.AddParameter("var_IdCliente", _entVoucher.Cliente.IdCliente)
                _objConexion.AddParameter("var_IdTipoDocumento", _entVoucher.TipoDocumento.IdTipoDocumento)
                _objConexion.AddParameter("var_NumeroDocumento", _entVoucher.NumeroDocumento)
                _objConexion.AddParameter("var_IdAsiento", _entVoucher.IdAsiento)

                _objConexion.EjecutarComando()


                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstVouchers = New List(Of EN_Voucher)

                While odrDatos.Read
                    _entVoucher = New EN_Voucher

                    _entVoucher.IdOperacion = odrDatos("var_IdOperacion")
                    _entVoucher.DesOperacion = odrDatos("var_desOperacion")
                    _entVoucher.Fecha = odrDatos("dtm_Fecha")
                    _entVoucher.IdAsiento = odrDatos("var_IdAsiento")
                    _entVoucher.Vouchercuenta = New EN_VoucherCuenta
                    _entVoucher.Total = odrDatos("dec_Importe")
                    _entVoucher.IdCentroCosto = odrDatos("var_IdCentroCosto")
                    _entVoucher.DesCentroCosto = odrDatos("var_desCentroCosto")
                    _entVoucher.Cliente = New EN_Cliente
                    _entVoucher.IdCliente = odrDatos("var_IdCliente")
                    _entVoucher.Cliente = odrDatos("var_desCliente")
                    _entVoucher.IdProveedor = odrDatos("var_IdProveedor")
                    _entVoucher.Proveedor = odrDatos("var_desProveedor")
                    _entVoucher.TipoDocumento = New EN_TipoDocumento
                    _entVoucher.IdTipoDocumento = odrDatos("var_IdTipoDocumento")
                    _entVoucher.NumeroDocumento = odrDatos("var_NumeroDocumento")
                    _entVoucher.Glosa = odrDatos("var_Descripcion")
                    _entVoucher.Estado = odrDatos("chr_Estado")

                    _lstVouchers.Add(_entVoucher)
                End While

                Return (_lstVouchers.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function BusquedaOperacion() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer

                _objConexion.Procedimiento = "[dbo].[ERP_usp_Voucher_Operacion]"
                _objConexion.AddParameter("var_IdOperacion", _entVoucher.IdOperacion)
                _objConexion.AddParameter("var_IdAsiento", _entVoucher.IdAsiento)

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstVouchers = New List(Of EN_Voucher)

                While odrDatos.Read
                    _entVoucher = New EN_Voucher

                    _entVoucher.IdOperacion = odrDatos("var_IdOperacion")

                    _entVoucher.EsCargo = odrDatos("var_EsAbonoOperacionCuenta")
                    _entVoucher.IdAsiento = odrDatos("var_IdAsiento")
                    _entVoucher.EsCargo = odrDatos("var_EsCargoVoucherCuenta")
                    _entVoucher.Vouchercuenta = New EN_VoucherCuenta
                    _entVoucher.Glosa = odrDatos("var_Observacion")
                    _entVoucher.IdCuentaContable = odrDatos("var_IdCuenta")
                    _entVoucher.CuentaContable = odrDatos("var_NombrePlanCuenta")
                    _entVoucher.Total = odrDatos("dec_Importe")
                    ' _entVoucher.Fla = odrDatos("Flag")
                    If odrDatos("var_EsCargoVoucherCuenta") = "Ab" Then
                        _entVoucher.Abono = odrDatos("dec_Importe")

                        'Else
                        '    _entVoucher.Abono = 0
                    End If
                    If odrDatos("var_EsCargoVoucherCuenta") = "Ca" Then
                        _entVoucher.Cargo = odrDatos("dec_Importe")
                    End If

                    _lstVouchers.Add(_entVoucher)

                End While

                Return (_lstVouchers.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function BusquedaOperacionN() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer

                _objConexion.Procedimiento = "ERP_usp_Voucher_OperacionN"
                _objConexion.AddParameter("var_IdSubOperacion", _entVoucher.IdSubOperacion)

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstVouchers = New List(Of EN_Voucher)

                While odrDatos.Read
                    _entVoucher = New EN_Voucher

                    _entVoucher.IdOperacion = odrDatos("var_IdOperacion")

                    _entVoucher.EsCargo = odrDatos("var_EsCargo")
                    _entVoucher.EsAbono = odrDatos("var_EsAbono")
                    _entVoucher.Glosa = odrDatos("var_Observacion")
                    _entVoucher.IdCuentaContable = odrDatos("var_IdCuenta")
                    '_entVoucher.Flag = odrDatos("Flag")
                    _entVoucher.CuentaContable = odrDatos("var_NombrePlanCuenta")
                    _entVoucher.IdOperacion = odrDatos("var_IdOperacion")
                    '_entVoucher.IdOperacio = odrDatos("var_IdOperacionCuenta")

                    _lstVouchers.Add(_entVoucher)

                End While

                Return (_lstVouchers.Count > 0)



            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
#End Region

    End Class
End Namespace
