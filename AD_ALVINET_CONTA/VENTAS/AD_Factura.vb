Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.VENTAS

Imports System.Data
Imports System.Data.SqlClient

Imports AD_ALVINET_CONTA.GENERAL
Imports EN_ALVINET_CONTA.OPERACION

Namespace VENTAS

    Public Class AD_Factura

        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstFacturas As List(Of EN_Factura)
        Private _entFactura As New EN_Factura
        Private _dtbAtributos As DataTable


#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property


        Public ReadOnly Property lstfacturas As List(Of EN_Factura)
            Get
                Return _lstFacturas
            End Get
        End Property

        Public Property entFactura As EN_Factura
            Get
                Return _entFactura
            End Get
            Set(ByVal Value As EN_Factura)
                _entFactura = Value
            End Set
        End Property

#End Region

#Region "METODOS Y FUNCIONES"

        Public Function Registrar(ByVal _dtbAtributos As DataTable) As Boolean

            Dim objGeneral As New Util
            If _dtbAtributos.Columns.IndexOf("var_DesArticulo") >= 0 Then
                _dtbAtributos.Columns.Remove("var_DesArticulo")

            End If
            If _dtbAtributos.Columns.IndexOf("var_Unidad") >= 0 Then
                _dtbAtributos.Columns.Remove("var_Unidad")

            End If


            Dim input As String = objGeneral.GeneraXML(_dtbAtributos)
            Dim output As String = input.Replace("ñ", "&#241;")
            output = output.Replace("Ñ", "&#209;")
            output = output.Replace(",", "")
            Try
                _objConexion = New AccesoDatosSQLServer

                _objConexion.Procedimiento = "SGC_uspe_comprobante_Registrar"
                _objConexion.AddParameter("var_IdEmpresa", _entFactura.IdEmpresa)
                _objConexion.AddParameter("var_IdEjercicioEmpresa", _entFactura.IdEjerccioEmpresa)
                _objConexion.AddParameter("var_IdContabilidad", _entFactura.IdContabilidad)
                _objConexion.AddParameter("var_IdFactura", _entFactura.IdComprobante)
                _objConexion.AddParameter("var_NDoc", _entFactura.NumeroDocumento)
                _objConexion.AddParameter("var_Correlativo", _entFactura.Correlativo)
                _objConexion.AddParameter("var_IdCliente", _entFactura.IdCliente)
                _objConexion.AddParameter("var_idVendedor", _entFactura.IdVendedor)
                _objConexion.AddParameter("var_idMotivo", _entFactura.IdMotivo)
                _objConexion.AddParameter("var_idTipo", _entFactura.IdDocumento)
                _objConexion.AddParameter("var_codMoneda", _entFactura.IdMoneda)
                _objConexion.AddParameter("var_TipoServicio", _entFactura.IdServicio)
                _objConexion.AddParameter("var_FechaEmision", _entFactura.FechaEmision)
                _objConexion.AddParameter("var_FechaVencimiento", _entFactura.FechaVencimiento)
                _objConexion.AddParameter("var_Estado", _entFactura.Estado)
                _objConexion.AddParameter("xml_Atributos", output)
                _objConexion.AddParameter("var_Usuario", _entFactura.Usuario)
                _objConexion.AddParameter("num_Igv", _entFactura.IGV)
                _objConexion.AddParameter("num_SubTotal", _entFactura.SubTotal)
                _objConexion.AddParameter("num_Total", _entFactura.Total)
                _objConexion.AddParameter("num_Desc", _entFactura.Descuento)
                _objConexion.AddParameter("num_TotalParcial", _entFactura.TotalParcial)
                _objConexion.AddParameter("var_TipoPago", _entFactura.TipoPago)
                _objConexion.AddParameter("num_TipoCambio", _entFactura.TipoCambio)
                _objConexion.AddParameter("num_Isc", _entFactura.ISC)
                _objConexion.AddParameter("num_ValorExportacion", _entFactura.ValorExportacion)
                _objConexion.AddParameter("num_BaseImponible", _entFactura.BaseImponible)
                _objConexion.AddParameter("num_OtrosImportes", _entFactura.TipoCambio)
                _objConexion.AddParameter("num_Exonerado", _entFactura.Exonerado)
                _objConexion.AddParameter("num_Inafecta", _entFactura.Inafecta)
                _objConexion.AddParameter("var_FechaModificacion", Format(Now.Date, "dd/MM/yyyy"))
                _objConexion.AddParameter("var_ContadoCredito", _entFactura.ContadoCredito)
                _objConexion.AddParameter("var_Cuotas", _entFactura.Cuotas)
                _objConexion.AddParameter("var_MontoCuota", _entFactura.MontoCuota)
                _objConexion.AddParameter("num_Pago", _entFactura.Pago)
                _objConexion.AddParameter("num_Saldo", _entFactura.Saldo)


                _entFactura.Retorno = _objConexion.EjecutarComandoSalida().ToString()
                'EjecutarComando()
                Return True
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function


        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Pedido_Eliminar"
                _objConexion.AddParameter("var_IdFactura", _entFactura.IdComprobante)

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
                _objConexion.Procedimiento = "SGC_uspe_comprobante_Obtener"
                _objConexion.AddParameter("var_IdFactura", _entFactura.Correlativo)
                _objConexion.EjecutarComando()
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstFacturas = New List(Of EN_Factura)
                While odrDatos.Read
                    'Dim _entFactura1 As New EN_Factura
                    _entFactura.IdComprobante = odrDatos("var_IdFactura")
                    _entFactura.NumeroDocumento = odrDatos("var_NDoc")
                    _entFactura.Correlativo = odrDatos("var_Correlativo")
                    _entFactura.IdCliente = odrDatos("var_IdCliente")
                    _entFactura.IdVendedor = odrDatos("var_idVendedor")
                    _entFactura.IdDocumento = odrDatos("var_IdDocumento")
                    _entFactura.IdMoneda = odrDatos("var_codMoneda")
                    _entFactura.IdMotivo = odrDatos("var_idMotivo")
                    _entFactura.IdServicio = odrDatos("var_TipoServicio")
                    _entFactura.Estado = odrDatos("var_Estado")
                    _entFactura.Cliente = odrDatos("var_DesCliente")
                    _entFactura.ContactoCliente = odrDatos("var_Contacto")
                    _entFactura.DireccionCliente = odrDatos("var_Direccion")
                    _entFactura.IGV = odrDatos("num_Igv")
                    _entFactura.SubTotal = odrDatos("num_SubTotal")
                    _entFactura.Descuento = odrDatos("num_Desc")
                    _entFactura.Total = odrDatos("num_Total")
                    _entFactura.TotalParcial = odrDatos("num_TotalParcial")
                    _entFactura.TipoPago = odrDatos("var_TipoPago")
                    _entFactura.FechaEmision = odrDatos("dtm_FechaEmision")
                    _entFactura.FechaVencimiento = odrDatos("dtm_FechaVencimiento")
                    _entFactura.Cantidad = odrDatos("num_Cantidad")
                    _entFactura.CostoUnitario = odrDatos("num_PrecioUnitario")
                    _entFactura.Descuento = odrDatos("num_Descuento")
                    _entFactura.desArticulo = odrDatos("Articulo")
                    _entFactura.idArticulo = odrDatos("var_IdArticulo")
                    _entFactura.Unidad = odrDatos("UnidadMedida")

                    '_lstFacturas.Add(_entFactura1)
                End While

                Return (_entFactura.IdComprobante <> Nothing)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function


        'Public Function Obtener() As Boolean
        '    Try
        '        _objConexion = New AccesoDatosSQLServer
        '        Dim objParametros() As String = {"var_IdFactura", _strNumeroDocumento}
        '        _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_comprobante_Obtener", objParametros)
        '        If _dtbDatos.Rows.Count > 0 Then
        '            _strIdComprobante = _dtbDatos.Rows(0)("var_IdFactura")
        '            _strNumeroDocumento = _dtbDatos.Rows(0)("var_NDoc")
        '            _strCorrelativo = _dtbDatos.Rows(0)("var_Correlativo")
        '            _strIdCliente = _dtbDatos.Rows(0)("var_IdCliente")
        '            _strIdVendedor = _dtbDatos.Rows(0)("var_idVendedor")
        '            _strIdDocumento = _dtbDatos.Rows(0)("var_IdDocumento")
        '            _strIdMoneda = _dtbDatos.Rows(0)("var_codMoneda")
        '            _strIdMotivo = _dtbDatos.Rows(0)("var_idMotivo")
        '            _strIdServicio = _dtbDatos.Rows(0)("var_TipoServicio")
        '            _strEstadoPedido = _dtbDatos.Rows(0)("var_Estado")
        '            _StrDesCliente = _dtbDatos.Rows(0)("var_DesCliente")
        '            _strContacto = _dtbDatos.Rows(0)("var_Contacto")
        '            _strContacto = _dtbDatos.Rows(0)("var_Direccion")
        '            _dblIGV = _dtbDatos.Rows(0)("num_Igv")
        '            _dblsubTotal = _dtbDatos.Rows(0)("num_SubTotal")
        '            _dblDesc = _dtbDatos.Rows(0)("num_Desc")
        '            _dblTotal = _dtbDatos.Rows(0)("num_Total")
        '            _dblTotalParcial = _dtbDatos.Rows(0)("num_TotalParcial")
        '            _strTipoPago = _dtbDatos.Rows(0)("var_TipoPago")
        '            _strFechaEmision = Format(_dtbDatos.Rows(0)("dtm_FechaEmision"), "dd/MM/yyyy")
        '            _strFechaVencimiento = Format(_dtbDatos.Rows(0)("dtm_FechaVencimiento"), "dd/MM/yyy")
        '        End If
        '        Return (_dtbDatos.Rows.Count > 0)
        '    Catch ex As Exception
        '        Me._exError = ex
        '        Return False
        '    End Try
        'End Function



        Public Function ObtenerAtributos(ByVal enFactura As EN_Factura) As Boolean

            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_ComprobanteAtributo_Obtener"
                _objConexion.AddParameter("int_NumeroComprobante", _entFactura.NumeroDocumento)
                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstFacturas = New List(Of EN_Factura)

                While odrDatos.Read
                    Dim enFactura1 = New EN_Factura

                    enFactura1.Correlativo = IIf(IsDBNull(odrDatos("int_Secuencia")), "", odrDatos("int_Secuencia"))
                    enFactura1.idArticulo = IIf(IsDBNull(odrDatos("var_CodArticulo")), "", odrDatos("var_CodArticulo"))
                    enFactura1.desArticulo = IIf(IsDBNull(odrDatos("var_DesArticulo")), "", odrDatos("var_DesArticulo"))
                    enFactura1.Unidad = IIf(IsDBNull(odrDatos("var_Unidad")), "", odrDatos("var_Unidad"))
                    enFactura1.CostoUnitario = IIf(IsDBNull(odrDatos("num_CostoUnitario")), "", odrDatos("num_CostoUnitario"))
                    enFactura1.Cantidad = IIf(IsDBNull(odrDatos("num_Cantidad")), "", odrDatos("num_Cantidad"))
                    enFactura1.Importe = IIf(IsDBNull(odrDatos("num_Importe")), "", odrDatos("num_Importe"))
                    'enFactura1.Rollos = IIf(IsDBNull(odrDatos("num_Rollos")), "", odrDatos("num_Rollos"))
                    enFactura1.Descuento = IIf(IsDBNull(odrDatos("var_Descuento")), "", odrDatos("var_Descuento"))
                    enFactura1.desServicio = IIf(IsDBNull(odrDatos("var_DesServicio")), "", odrDatos("var_DesServicio"))

                    _lstFacturas.Add(enFactura1)
                End While

                Return (_lstFacturas.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try

        End Function

        Public Function MaxID() As Integer

            Dim max As Integer

            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_PedidoAtributo_ObtenerMaximo"
                _objConexion.EjecutarComando()
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                While odrDatos.Read
                    max = Convert.ToInt32(odrDatos("var_Maximo").ToString())
                End While

            Catch ex As Exception
                '_objError = ex
                ' Return False
            End Try
            Return max

        End Function


        Public Function Buscar(ByVal enFactura1 As EN_Factura) As List(Of EN_Factura)
            Dim _lstFacturas = New List(Of EN_Factura)
            Try
                _objConexion = New AccesoDatosSQLServer
                '[SGC_uspe_comprobante_Buscar]
                _objConexion.Procedimiento = "SGC_uspe_comprobante_Buscar"
                _objConexion.AddParameter("var_IdFactura", enFactura1.IdComprobante)
                _objConexion.AddParameter("var_correlativo", enFactura1.Correlativo)
                _objConexion.AddParameter("var_NDoc", enFactura1.NumeroDocumento)
                _objConexion.AddParameter("var_Cliente", enFactura1.IdCliente.ToString())
                _objConexion.AddParameter("var_FechaInicio", enFactura1.FechaIngreso)
                _objConexion.AddParameter("var_FechaFinal", enFactura1.FechaEntrega)
                _objConexion.EjecutarComando()
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                While odrDatos.Read
                    _entFactura = New EN_Factura
                    _entFactura.IdComprobante = odrDatos("var_IdComprobante")
                    '_entFactura.NumeroDocumento = odrDatos("var_NDoc")
                    _entFactura.Correlativo = odrDatos("int_Secuencia")
                    _entFactura.Cliente = odrDatos("var_IdCliente")
                    _entFactura.FechaIngreso = odrDatos("dtm_FechaEmision")
                    _entFactura.FechaVencimiento = odrDatos("dtm_FechaVencimiento")
                    _entFactura.desServicio = odrDatos("var_TipoServicio")
                    _entFactura.Estado = odrDatos("var_Estado")
                    _entFactura.IdTipoDocumento = odrDatos("var_Tipo")

                    _lstFacturas.Add(_entFactura)
                End While
            Catch ex As Exception
                '_objError = ex
            End Try

            Return _lstFacturas
        End Function
        Public Function BuscarxId(ByVal enFactura1 As EN_Factura) As List(Of EN_Factura)
            Dim _lstFacturas = New List(Of EN_Factura)
            Try
                _objConexion = New AccesoDatosSQLServer
                '[SGC_uspe_comprobante_Buscar]
                _objConexion.Procedimiento = "[dbo].[SGC_uspe_comprobante_Buscar_Id]"
                _objConexion.AddParameter("var_IdFactura", enFactura1.IdComprobante)
                _objConexion.EjecutarComando()
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                While odrDatos.Read
                    _entFactura = New EN_Factura
                    _entFactura.IdComprobante = odrDatos("var_IdComprobante")
                    '_entFactura.NumeroDocumento = odrDatos("var_NDoc")
                    _entFactura.Correlativo = odrDatos("int_Secuencia")
                    _entFactura.Cliente = odrDatos("var_IdCliente")
                    _entFactura.FechaIngreso = odrDatos("dtm_FechaEmision")
                    _entFactura.FechaVencimiento = odrDatos("dtm_FechaVencimiento")
                    _entFactura.desServicio = odrDatos("var_TipoServicio")
                    _entFactura.Estado = odrDatos("var_Estado")
                    _entFactura.IdTipoDocumento = odrDatos("var_Tipo")
                    _lstFacturas.Add(_entFactura)
                End While
            Catch ex As Exception
                '_objError = ex
            End Try

            Return _lstFacturas
        End Function

        Public Function BuscarArticulos(ByVal enFactura As EN_Factura) As List(Of EN_Factura)

            Dim _lstFacturas1 = New List(Of EN_Factura)
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_AsignarAtributocomprobante_Buscar"
                _objConexion.AddParameter("var_IdComprobante", _entFactura.IdComprobante)
                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                While odrDatos.Read

                    Dim _entFactura1 = New EN_Factura
                    _entFactura1.IdComprobante = odrDatos("var_IdFactura")
                    _entFactura1.NumeroDocumento = odrDatos("var_NDoc")
                    _entFactura1.Correlativo = odrDatos("var_Correlativo")
                    _entFactura1.Cliente = odrDatos("var_Cliente")
                    _entFactura1.FechaIngreso = odrDatos("var_FechaInicio")
                    _entFactura1.FechaEntrega = odrDatos("var_FechaFinal")

                    _lstFacturas1.Add(_entFactura1)
                End While

            Catch ex As Exception
                '_objError = ex
            End Try

            Return _lstFacturas1
        End Function

        Public Function AsignarComprobante() As Boolean

            Dim _lstFacturas = New List(Of EN_Factura)
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Asignarcomprobante_Buscar"

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstFacturas = New List(Of EN_Factura)

                While odrDatos.Read

                    _entFactura.IdComprobante = odrDatos("var_IdFactura")
                    _entFactura.NumeroDocumento = odrDatos("var_IdCliente")
                    _entFactura.Correlativo = odrDatos("var_Correlativo")
                    _entFactura.Cliente = odrDatos("var_Moneda")
                    _entFactura.FechaIngreso = odrDatos("var_Monto")
                    _entFactura.FechaEntrega = odrDatos("var_Cliente")
                    _entFactura.FechaIngreso = odrDatos("var_FechaInicio")
                    _entFactura.FechaEntrega = odrDatos("var_FechaFinal")
                    _lstFacturas.Add(_entFactura)
                End While

                Return (_lstFacturas.Count > 0)

            Catch ex As Exception
                _objError = ex

                Return False
            End Try
        End Function
        Public Function ActualizarImporte() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "[dbo].[SGC_utb_Importe_Actualizar]"
                _objConexion.AddParameter("var_TipoDocumento", entFactura.Parametro)
                _objConexion.AddParameter("dec_Monto", entFactura.Importe)
                _objConexion.AddParameter("var_IdDocumento", entFactura.IdComprobante)
                _objConexion.AddParameter("var_IdTipoDocumento", entFactura.IdTipoDocumento)
                _objConexion.AddParameter("chr_IdTipoDoc", entFactura.IdTipoDoc)
                _objConexion.EjecutarComando()
                Return True
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function BuscarXDocumento() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "[dbo].[SGC_utb_DocumentoVenta_Buscar]"
                _objConexion.AddParameter("var_idTipo", _entFactura.IdTipoDocumento)
                _objConexion.AddParameter("var_IdComprobante", _entFactura.IdComprobante)
                _objConexion.AddParameter("var_Descripcion", _entFactura.Descripcion)
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader
                _lstFacturas = New List(Of EN_Factura)
                If Not odrDatos Is Nothing Then
                    Dim intCont As Integer = 0
                    While odrDatos.Read
                        intCont += 1
                        _entFactura = New EN_Factura
                        _entFactura.intCont = intCont
                        _entFactura.IdComprobante = odrDatos("var_IdComprobante")
                        _entFactura.Numero = odrDatos("Numero")
                        _entFactura.Total = odrDatos("num_Total")
                        _entFactura.RazonSocial = odrDatos("var_Descripcion")
                        _entFactura.IdCliente = odrDatos("var_IdCliente")
                        _entFactura.NomMoneda = odrDatos("NomMoneda")
                        _entFactura.TipoCambio = odrDatos("num_TipoCambio")
                        _lstFacturas.Add(_entFactura)
                    End While

                End If
                Return (_lstFacturas.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function ListarCuenta() As List(Of EN_Factura)
            Dim lstFactura As New List(Of EN_Factura)
            Try
                _objConexion = New AccesoDatos.AccesoDatosSQLServer
                _objConexion.Procedimiento = "[ERP_usp_Cuentas_Compra_Listar]"
                _objConexion.AddParameter("var_IdComprobante", _entFactura.IdComprobante)

                Dim odrDatos As SqlClient.SqlDataReader = _objConexion.ObtenerDataReader()
                Dim incremento As Integer

                While odrDatos.Read
                    _entFactura = New EN_Factura
                    incremento = incremento + 1
                    _entFactura.Nivel = Convert.ToString(incremento)
                    _entFactura.IdCuenta = odrDatos("var_IdCuenta")
                    _entFactura.EsCargo = odrDatos("var_EsCargo")
                    _entFactura.Importe = odrDatos("dec_Importe")
                    _entFactura.Observacion = odrDatos("var_Observacion")
                    _entFactura.NumeroDocumento = odrDatos("var_IdDocumentoCompra")
                    _entFactura.IdAsiento = odrDatos("var_IdAsiento")
                    lstFactura.Add(_entFactura)

                End While
                'Return (_lstVoucherCuentas.Count > 0)

            Catch ex As Exception
                _objError = ex
                'Return False
            End Try

            Return lstFactura
        End Function

        Public Function ListarCuentaVenta() As List(Of EN_VoucherCuenta)

            Dim _lstVoucherCuentas = New List(Of EN_VoucherCuenta)

            Try
                _objConexion = New AccesoDatos.AccesoDatosSQLServer
                _objConexion.Procedimiento = "[ERP_usp_Cuentas_Venta_Listar]"
                _objConexion.AddParameter("var_IdComprobante", _entFactura.IdComprobante)
                _objConexion.AddParameter("var_RazonSocial", _entFactura.RazonSocial)
                _objConexion.AddParameter("var_FechaInicio", _entFactura.FechaEmision)
                _objConexion.AddParameter("var_FechaFinal", _entFactura.FechaEntrega)


                Dim odrDatos As SqlClient.SqlDataReader = _objConexion.ObtenerDataReader()
                Dim incremento As Integer

                While odrDatos.Read
                    Dim _entVoucherCuenta = New EN_Voucher
                    incremento = incremento + 1
                    _entVoucherCuenta.Nivel = incremento
                    _entVoucherCuenta.IdCuenta = odrDatos("var_IdCuenta")
                    _entVoucherCuenta.EsCargo = odrDatos("var_EsCargo")
                    _entVoucherCuenta.Importe = odrDatos("dec_Importe")
                    _entVoucherCuenta.Observacion = odrDatos("var_Observacion")
                    _entVoucherCuenta.Comprobante = odrDatos("var_IdComprobante")
                    _entVoucherCuenta.IdAsiento = odrDatos("var_IdAsiento")
                    _lstVoucherCuentas.Add(_entVoucherCuenta)

                End While
                'Return (_lstVoucherCuentas.Count > 0)

            Catch ex As Exception
                _objError = ex
                'Return False
            End Try

            Return _lstVoucherCuentas
        End Function







#End Region



    End Class
End Namespace
