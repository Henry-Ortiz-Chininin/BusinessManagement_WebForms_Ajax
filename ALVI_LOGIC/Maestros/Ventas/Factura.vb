Imports AccesoDatos
Imports ALVI_LOGIC
Namespace Maestros.Ventas
    Public Class Factura
#Region "VARIABLES"
        Private _strIdComprobante As String
        Private _strNumeroDocumento As String
        Private _strCorrelativo As String
        Private _strIdCliente As String
        Private _strDesServicio As String
        Private _strTipoOperacion As String
        Private _strIdVendedor As String
        Private _strIdMoneda As String
        Private _strFechaEmision As String
        Private _strEstadoPedido As String
        Private _strIdAprobacion As String
        Private _strIdServicio As String
        Private _strFormaPago As String
        Private _strCuotas As String
        Private _strIdDocumento As String
        Private _strIdMotivo As String
        Private _strMaximo As String
        Private _strTipoPago As String

        Private _dblDesc As Double
        Private _dblTotal As Double
        Private _dblsubTotal As Double
        Private _dblIGV As Double
        Private _dblTotalParcial As Double
        Private _dblTipoCambio As Double

        Private _StrDesCliente As String
        Private _strFechaIngreso As String
        Private _strFechaEntrega As String
        Private _strFechaVencimiento As String
        Private _stridArticulo As String
        Private _strdesArticulo As String
        Private _dblRollos As Double
        Private _dblCantidad As Double
        Private _dblImporte As String
        Private _strObservacion As String
        Private _strDireccionCliente As String
        Private _strContacto As String

        Private _strMonto As String
        Private _strMoneda As String

        Private _strIdOrdenServicio As String = ""
        Private _strIdServicioTer As String = ""
        Private _dblImporteSerTer As Double = 0

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _dtbAtributos As DataTable
        Private _dtbOrdenServicio As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"

        Public Property IdComprobante() As String
            Get
                Return _strIdComprobante
            End Get
            Set(ByVal value As String)
                _strIdComprobante = value
            End Set
        End Property
        Public Property NumeroDocumento() As String
            Get
                Return _strNumeroDocumento
            End Get
            Set(ByVal value As String)
                _strNumeroDocumento = value
            End Set
        End Property
        Public Property Maximo() As String
            Get
                Return _strMaximo
            End Get
            Set(ByVal value As String)
                _strMaximo = value
            End Set
        End Property
        Public Property Monto() As String
            Get
                Return _strMonto
            End Get
            Set(ByVal value As String)
                _strMonto = value
            End Set
        End Property
        Public Property Moneda() As String
            Get
                Return _strMoneda
            End Get
            Set(ByVal value As String)
                _strMoneda = value
            End Set
        End Property
        Public Property TipoCambio() As Double
            Get
                Return _dblTipoCambio
            End Get
            Set(ByVal value As Double)
                _dblTipoCambio = value
            End Set
        End Property
        Public Property TipoPago() As String
            Get
                Return _strTipoPago
            End Get
            Set(ByVal value As String)
                _strTipoPago = value
            End Set
        End Property
        Public Property Correlativo() As String
            Get
                Return _strCorrelativo
            End Get
            Set(ByVal value As String)
                _strCorrelativo = value
            End Set
        End Property
        Public Property IdMotivo() As String
            Get
                Return _strIdMotivo
            End Get
            Set(ByVal value As String)
                _strIdMotivo = value
            End Set
        End Property
        Public Property Rollos() As Double
            Get
                Return _dblRollos
            End Get
            Set(ByVal value As Double)
                _dblRollos = value
            End Set
        End Property
        Public Property Cantidad() As Double
            Get
                Return _dblCantidad
            End Get
            Set(ByVal value As Double)
                _dblCantidad = value
            End Set
        End Property
        Public Property Importe() As Double
            Get
                Return _dblImporte
            End Get
            Set(ByVal value As Double)
                _dblImporte = value
            End Set
        End Property
        Public Property Descuento() As Double
            Get
                Return _dblDesc
            End Get
            Set(ByVal value As Double)
                _dblDesc = value
            End Set
        End Property
        Public Property Total() As Double
            Get
                Return _dblTotal
            End Get
            Set(ByVal value As Double)
                _dblTotal = value
            End Set
        End Property
        Public Property SubTotal() As Double
            Get
                Return _dblsubTotal
            End Get
            Set(ByVal value As Double)
                _dblsubTotal = value
            End Set
        End Property
        Public Property IGV() As Double
            Get
                Return _dblIGV
            End Get
            Set(ByVal value As Double)
                _dblIGV = value
            End Set
        End Property
        Public Property TotalParcial() As Double
            Get
                Return _dblTotalParcial
            End Get
            Set(ByVal value As Double)
                _dblTotalParcial = value
            End Set
        End Property
        Public Property Observacion() As String
            Get
                Return _strObservacion
            End Get
            Set(ByVal value As String)
                _strObservacion = value
            End Set
        End Property
        Public Property ContactoCliente() As String
            Get
                Return _strContacto
            End Get
            Set(ByVal value As String)
                _strContacto = value
            End Set
        End Property
        Public Property DireccionCliente() As String
            Get
                Return _strDireccionCliente
            End Get
            Set(ByVal value As String)
                _strDireccionCliente = value
            End Set
        End Property
        Public Property IdCliente() As String
            Get
                Return _strIdCliente
            End Get
            Set(ByVal value As String)
                _strIdCliente = value
            End Set
        End Property
        Public Property IdServicio() As String
            Get
                Return _strIdServicio
            End Get
            Set(ByVal value As String)
                _strIdServicio = value
            End Set
        End Property
        Public Property IdDocumento() As String
            Get
                Return _strIdDocumento
            End Get
            Set(ByVal value As String)
                _strIdDocumento = value
            End Set
        End Property
        Public Property Cliente() As String
            Get
                Return _StrDesCliente
            End Get
            Set(ByVal value As String)
                _StrDesCliente = value
            End Set
        End Property
        Public Property FechaIngreso() As String
            Get
                Return _strFechaIngreso
            End Get
            Set(ByVal value As String)
                _strFechaIngreso = value
            End Set
        End Property
        Public Property FechaEntrega() As String
            Get
                Return _strFechaEntrega
            End Get
            Set(ByVal value As String)
                _strFechaEntrega = value
            End Set
        End Property
        Public Property FechaVencimiento() As String
            Get
                Return _strFechaVencimiento
            End Get
            Set(ByVal value As String)
                _strFechaVencimiento = value
            End Set
        End Property
        Public Property desArticulo() As String
            Get
                Return _strdesArticulo
            End Get
            Set(ByVal value As String)
                _strdesArticulo = value
            End Set
        End Property
        Public Property desServicio() As String
            Get
                Return _strDesServicio
            End Get
            Set(ByVal value As String)
                _strDesServicio = value
            End Set
        End Property
        Public Property TipoOperacion() As String
            Get
                Return _strTipoOperacion
            End Get
            Set(ByVal value As String)
                _strTipoOperacion = value
            End Set
        End Property
        Public Property idMoneda() As String
            Get
                Return _strIdMoneda
            End Get
            Set(ByVal value As String)
                _strIdMoneda = value
            End Set
        End Property
        Public Property FechaEmision() As String
            Get
                Return _strFechaEmision
            End Get
            Set(ByVal value As String)
                _strFechaEmision = value
            End Set
        End Property
        Public Property idVendedor() As String
            Get
                Return _strIdVendedor
            End Get
            Set(ByVal value As String)
                _strIdVendedor = value
            End Set
        End Property
        Public Property EstadoPedido() As String
            Get
                Return _strEstadoPedido
            End Get
            Set(ByVal value As String)
                _strEstadoPedido = value
            End Set
        End Property
        Public Property IdAprobacion() As String
            Get
                Return _strIdAprobacion
            End Get
            Set(ByVal value As String)
                _strIdAprobacion = value
            End Set
        End Property
        Public Property Formapago() As String
            Get
                Return _strFormaPago
            End Get
            Set(ByVal value As String)
                _strFormaPago = value
            End Set
        End Property
        Public Property Cuotas() As String
            Get
                Return _strCuotas
            End Get
            Set(ByVal value As String)
                _strCuotas = value
            End Set
        End Property
        Public Property idArticulo() As String
            Get
                Return _stridArticulo
            End Get
            Set(ByVal value As String)
                _stridArticulo = value
            End Set
        End Property
        Public Property Estado() As String
            Get
                Return _strEstado
            End Get
            Set(ByVal value As String)
                _strEstado = value
            End Set
        End Property
        Public Property Datos() As DataTable
            Get
                Return _dtbDatos
            End Get
            Set(ByVal value As DataTable)
                _dtbDatos = value
            End Set
        End Property
        Public Property DatosOrdenServicio() As DataTable
            Get
                Return _dtbOrdenServicio
            End Get
            Set(ByVal value As DataTable)
                _dtbOrdenServicio = value
            End Set
        End Property
        Public Property DatosArticulos() As DataTable
            Get
                Return _dtbAtributos
            End Get
            Set(ByVal value As DataTable)
                _dtbAtributos = value
            End Set
        End Property
        Public Property Usuario() As String
            Get
                Return _strUsuario
            End Get
            Set(ByVal value As String)
                _strUsuario = value
            End Set
        End Property
        Public ReadOnly Property exError() As Exception
            Get
                Return _exError
            End Get
        End Property
        Public Property IdServicioTer() As String
            Get
                Return _strIdServicioTer
            End Get
            Set(ByVal value As String)
                _strIdServicioTer = value
            End Set
        End Property
        Public Property ImporteSerTer() As Double
            Get
                Return _dblImporteSerTer
            End Get
            Set(ByVal value As Double)
                _dblImporteSerTer = value
            End Set
        End Property

#End Region

#Region "METODOS Y FUNCIONES"
        Public Function Registrar(ByVal dtbAtributos As DataTable) As Boolean
            Try
                Dim objGeneral As New General.Util
                Dim input As String = objGeneral.GeneraXML(dtbAtributos)
                Dim output As String = input.Replace("ñ", "&#241;")
                output = output.Replace("Ñ", "&#209;")
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As Object = {"var_IdFactura ", _strIdComprobante, _
                                                 "var_NDoc", _strNumeroDocumento, _
                                                 "var_Correlativo", _strCorrelativo, _
                                                 "var_IdCliente", _strIdCliente, _
                                                 "var_idVendedor", _strIdVendedor, _
                                                 "var_idMotivo", _strIdMotivo, _
                                                 "var_idTipo", _strIdDocumento, _
                                                 "var_codMoneda", _strIdMoneda, _
                                                 "var_TipoServicio", _strIdServicio, _
                                                 "var_FechaEmision", _strFechaEmision, _
                                                 "var_FechaVencimiento", _strFechaVencimiento, _
                                                 "var_Estado", _strEstado, _
                                                 "xml_Atributos", output, _
                                                 "var_Usuario", _strUsuario, _
                                                 "num_Igv", _dblIGV, _
                                                 "num_SubTotal", _dblsubTotal, _
                                                 "num_Desc", _dblDesc, _
                                                 "num_TotalParcial", _dblTotalParcial, _
                                                 "var_TipoPago", _strTipoPago, _
                                                 "num_TipoCambio", _dblTipoCambio, _
                                                 "num_Total", _dblTotal, _
                                                 "var_IdServicioTer", _strIdServicioTer, _
                                                 "num_ImporteTer", _dblImporteSerTer}
                _objConexion.EjecutarComando("SGC_uspe_comprobante_Registrar", objParametros)
                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdFactura", _strIdComprobante}
                _objConexion.EjecutarComando("SGC_uspe_Pedido_Eliminar", objParametros)
                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function EliminarSecuencia() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"int_NumeroComprobante", _strNumeroDocumento}
                _objConexion.EjecutarComando("SGC_uspe_Comprobante_Eliminar", objParametros)
                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdFactura", _strNumeroDocumento}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_comprobante_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdComprobante = _dtbDatos.Rows(0)("var_IdFactura")
                    _strNumeroDocumento = _dtbDatos.Rows(0)("var_NDoc")
                    _strCorrelativo = _dtbDatos.Rows(0)("var_Correlativo")
                    _strIdCliente = _dtbDatos.Rows(0)("var_IdCliente")
                    _strIdVendedor = _dtbDatos.Rows(0)("var_idVendedor")
                    _strIdDocumento = _dtbDatos.Rows(0)("var_IdDocumento")
                    _strIdMoneda = _dtbDatos.Rows(0)("var_codMoneda")
                    _strIdMotivo = _dtbDatos.Rows(0)("var_idMotivo")
                    _strIdServicio = _dtbDatos.Rows(0)("var_TipoServicio")
                    _strEstadoPedido = _dtbDatos.Rows(0)("var_Estado")
                    _StrDesCliente = _dtbDatos.Rows(0)("var_DesCliente")
                    _strContacto = _dtbDatos.Rows(0)("var_Contacto")
                    _strContacto = _dtbDatos.Rows(0)("var_Direccion")
                    _dblIGV = _dtbDatos.Rows(0)("num_Igv")
                    _dblsubTotal = _dtbDatos.Rows(0)("num_SubTotal")
                    _dblDesc = _dtbDatos.Rows(0)("num_Desc")
                    _dblTotal = _dtbDatos.Rows(0)("num_Total")
                    _dblTotalParcial = _dtbDatos.Rows(0)("num_TotalParcial")
                    _strTipoPago = _dtbDatos.Rows(0)("var_TipoPago")
                    _strIdServicioTer = _dtbDatos.Rows(0)("var_IdServicioTer")
                    _dblImporteSerTer = _dtbDatos.Rows(0)("num_ImporteTer")
                    _strFechaEmision = Format(_dtbDatos.Rows(0)("dtm_FechaEmision"), "dd/MM/yyyy")
                    _strFechaVencimiento = Format(_dtbDatos.Rows(0)("dtm_FechaVencimiento"), "dd/MM/yyy")
                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function ObtenerAtributos() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"int_NumeroComprobante", _strNumeroDocumento}
                _dtbAtributos = _objConexion.ObtenerDataTable("SGC_uspe_ComprobanteAtributo_Obtener", objParametros)
                Return (_dtbAtributos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function MaxID() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_PedidoAtributo_ObtenerMaximo")
                If _dtbDatos.Rows.Count > 0 Then
                    _strMaximo = _dtbDatos.Rows(0)("var_Maximo")
                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Buscar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {
                                "var_IdFactura", _strIdComprobante, _
                                "var_NDoc", _strNumeroDocumento, _
                                "var_Correlativo", _strCorrelativo, _
                                "var_Cliente", _strIdCliente, _
                                "var_FechaInicio", _strFechaIngreso, _
                                "var_FechaFinal", _strFechaEntrega, _
                                "var_Estado", _strEstado}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_comprobante_Buscar", objParametros)
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function BuscarArticulos() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {
                                "var_IdComprobante", _strIdComprobante}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_AsignarAtributocomprobante_Buscar", objParametros)
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function AsignarComprobante() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {
                                "var_IdFactura", _strIdComprobante, _
                                "var_IdCliente", _strIdCliente, _
                                "var_Correlativo", _strCorrelativo, _
                                "var_Moneda", _strMoneda, _
                                "var_Monto", _strMonto, _
                                "var_Cliente", _StrDesCliente, _
                                "var_FechaInicio", _strFechaIngreso, _
                                "var_FechaFinal", _strFechaEntrega}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Asignarcomprobante_Buscar", objParametros)
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Impresion() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdFactura", _strNumeroDocumento}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_comprobante_Impresion", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdComprobante = _dtbDatos.Rows(0)("var_IdComprobante")
                End If
                If (_dtbDatos.Rows.Count > 0) Then
                    _strEstadoPedido = _dtbDatos.Rows(0)("var_Estado")
                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Registrar_ComprobanteOrdenServicio(ByVal dtbAtributos As DataTable) As Boolean
            Try
                Dim objGeneral As New General.Util
                Dim input As String = objGeneral.GeneraXML(dtbAtributos)
                Dim output As String = input.Replace("ñ", "&#241;")
                output = output.Replace("Ñ", "&#209;")
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As Object = {"int_NumeroComprobante ", _strNumeroDocumento, _
                                                 "var_Usuario ", _strUsuario, _
                                                 "xml_OrdeServicio", output}
                _objConexion.EjecutarComando("SGC_uspe_comprobanteOrdenServicio_Registro", objParametros)
                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function ObtenerOrdenServicio() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"int_NumeroComprobante", _strNumeroDocumento}
                _dtbOrdenServicio = _objConexion.ObtenerDataTable("SGC_uspe_ComprobanteOrdenServicio_Obtener", objParametros)
                Return (_dtbOrdenServicio.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace