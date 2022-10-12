Imports AccesoDatos
Imports ALVI_LOGIC
Namespace Maestros.Ventas
    Public Class Pedido
#Region "VARIABLES"
        Private _strIdPedido As String
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
        Private _StrDesCliente As String
        Private _strFechaIngreso As String
        Private _strFechaEntrega As String
        Private _stridArticulo As String
        Private _strdesArticulo As String
        Private _dblRollos As Double
        Private _dblCantidad As Double
        Private _dblImporte As String
        Private _strObservacion As String
        Private _strDireccionCliente As String
        Private _strContacto As String
        Private _strTipoPago As String
        Private _dblTipoCambio As Double

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _dtbAtributos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"

        Public Property IdPedido() As String
            Get
                Return _strIdPedido
            End Get
            Set(ByVal value As String)
                _strIdPedido = value
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
        Public Property Observacion() As String
            Get
                Return _strObservacion
            End Get
            Set(ByVal value As String)
                _strObservacion = value
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
        Public Property Cliente() As String
            Get
                Return _StrDesCliente
            End Get
            Set(ByVal value As String)
                _StrDesCliente = value
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
        Public ReadOnly Property exError() As String
            Get
                Return _exError.ToString
            End Get
        End Property
#End Region

#Region "METODOS Y FUNCIONES"
        Public Function Registrar(ByVal dtbAtributos As DataTable) As Boolean
            Try
                Dim objGeneral As New General.Util
                Dim input As String = objGeneral.GeneraXML(dtbAtributos)
                Dim output As String = input.Replace("ñ", "&#241;")
                output = output.Replace("Ñ", "&#209;")
                output = output.Replace(",", ".")
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As Object = {"var_IdPedido ", _strIdPedido, _
                                                 "var_IdCliente", _strIdCliente, _
                                                 "var_idVendedor", _strIdVendedor, _
                                                 "var_codMoneda", _strIdMoneda, _
                                                 "var_TipoServicio", _strIdServicio, _
                                                 "var_FechaEmision", _strFechaEmision, _
                                                 "var_Estado", _strEstado, _
                                                 "var_Aprobado", _strIdAprobacion, _
                                                 "var_FormaPago", _strFormaPago, _
                                                 "var_Plaso", _strCuotas, _
                                                 "var_TipoPago", _strTipoPago, _
                                                 "num_TipoCambio", _dblTipoCambio, _
                                                 "xml_Atributos", output, _
                                                "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_uspe_Pedido_Registrar", objParametros)
                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdPedido", _strIdPedido}
                _objConexion.EjecutarComando("SGC_uspe_Pedido_Eliminar", objParametros)
                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdPedido", _strIdPedido}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Pedido_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdPedido = _dtbDatos.Rows(0)("var_idPedido")
                    _strIdCliente = _dtbDatos.Rows(0)("var_IdCliente")
                    _strIdVendedor = _dtbDatos.Rows(0)("var_idVendedor")
                    _strIdMoneda = _dtbDatos.Rows(0)("var_codMoneda")
                    _strIdServicio = _dtbDatos.Rows(0)("var_TipoServicio")
                    _strEstadoPedido = _dtbDatos.Rows(0)("var_Estado")
                    _strIdAprobacion = _dtbDatos.Rows(0)("var_Aprobado")
                    _strFormaPago = _dtbDatos.Rows(0)("var_FormaPago")
                    _strCuotas = _dtbDatos.Rows(0)("var_Plaso")
                    _StrDesCliente = _dtbDatos.Rows(0)("var_DesCliente")
                    _strContacto = _dtbDatos.Rows(0)("var_Contacto")
                    _strContacto = _dtbDatos.Rows(0)("var_Direccion")
                    _strTipoPago = _dtbDatos.Rows(0)("var_TipoPago")
                    _strFechaEmision = Format(_dtbDatos.Rows(0)("dtm_FechaEmision"), "dd/MM/yyyy")
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
                Dim objParametros() As String = {"var_IdPedido", _strIdPedido}
                _dtbAtributos = _objConexion.ObtenerDataTable("SGC_uspe_PedidoAtributo_Obtener", objParametros)

                Return (_dtbAtributos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Buscar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {
                                "var_IdPedido", _strIdPedido, _
                                "var_Cliente", _strIdCliente, _
                                "var_FechaInicio", _strFechaIngreso, _
                                "var_FechaFinal", _strFechaEntrega}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Pedido_Buscar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace
