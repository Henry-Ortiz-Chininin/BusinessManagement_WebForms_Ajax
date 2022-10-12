Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.VENTAS
Imports System.Data
Imports System.Data.SqlClient
Imports EN_ALVINET_CONTA
Imports AD_ALVINET_CONTA.GENERAL

Namespace VENTAS


    Public Class AD_Pedido

        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstPedidos As List(Of EN_Pedido)
        Private _entPedido As New EN_Pedido


#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property


        Public ReadOnly Property lstPedidos As List(Of EN_Pedido)
            Get
                Return _lstPedidos
            End Get
        End Property

        Public Property entPedido As EN_Pedido
            Get
                Return _entPedido
            End Get
            Set(ByVal Value As EN_Pedido)
                _entPedido = Value
            End Set
        End Property

#End Region


#Region "METODOS Y FUNCIONES"


        Public Function Registrar(ByVal _dtbAtributos As DataTable) As Boolean


            Try

                Dim objGeneral As New Util
                Dim input As String = objGeneral.GeneraXML(_dtbAtributos)
                Dim output As String = input.Replace("ñ", "&#241;")
                output = output.Replace("Ñ", "&#209;")
                output = output.Replace(",", ".")
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Pedido_Registrar"

                _objConexion.AddParameter("var_IdPedido", _entPedido.IdPedido)
                _objConexion.AddParameter("var_IdCliente", _entPedido.IdCliente)
                _objConexion.AddParameter("var_idVendedor", _entPedido.idVendedor)
                _objConexion.AddParameter("var_codMoneda", _entPedido.idMoneda)
                _objConexion.AddParameter("var_TipoServicio", _entPedido.IdServicio)
                _objConexion.AddParameter("var_FechaEmision", _entPedido.FechaEmision)
                _objConexion.AddParameter("var_Estado", _entPedido.Estado)
                _objConexion.AddParameter("xml_Atributos", output)
                _objConexion.AddParameter("var_Aprobado", _entPedido.IdAprobacion)
                _objConexion.AddParameter("var_FormaPago", _entPedido.Formapago)
                _objConexion.AddParameter("var_Plaso", _entPedido.Cuotas)
                _objConexion.AddParameter("var_TipoPago", _entPedido.TipoPago)
                _objConexion.AddParameter("num_TipoCambio", _entPedido.TipoCambio)
                _objConexion.AddParameter("var_Usuario", _entPedido.Usuario)



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
                _objConexion.Procedimiento = "SGC_uspe_Pedido_Eliminar"
                _objConexion.AddParameter("var_IdPedido", _entPedido.IdPedido)

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
                _objConexion.Procedimiento = "SGC_uspe_Pedido_Obtener"
                _objConexion.AddParameter("var_IdPedido", _entPedido.IdPedido)

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstPedidos = New List(Of EN_Pedido)
                While odrDatos.Read
                    _entPedido = New EN_Pedido

                    _entPedido.IdPedido = odrDatos("var_idPedido")
                    _entPedido.IdCliente = odrDatos("var_IdCliente")
                    _entPedido.idVendedor = odrDatos("var_idVendedor")

                    _entPedido.idMoneda = odrDatos("var_codMoneda")
                    _entPedido.IdServicio = odrDatos("var_TipoServicio")

                    _entPedido.Estado = odrDatos("var_Estado")
                    _entPedido.IdAprobacion = odrDatos("var_Aprobado")
                    _entPedido.Formapago = odrDatos("var_FormaPago")

                    _entPedido.Cuotas = odrDatos("var_Plaso")
                    _entPedido.Cliente = odrDatos("var_DesCliente")
                    _entPedido.ContactoCliente = odrDatos("var_Contacto")

                    _entPedido.DireccionCliente = odrDatos("var_Direccion")
                    _entPedido.TipoPago = odrDatos("var_TipoPago")
                    _entPedido.FechaEmision = odrDatos("dtm_FechaEmision")


                    _lstPedidos.Add(_entPedido)
                End While

                Return (_lstPedidos.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function





        Public Function ObtenerAtributos() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_PedidoAtributo_Obtener"
                _objConexion.AddParameter("var_IdPedido", _entPedido.IdPedido)

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstPedidos = New List(Of EN_Pedido)
                While odrDatos.Read
                    _entPedido = New EN_Pedido

                    _lstPedidos.Add(_entPedido)
                End While

                Return (_lstPedidos.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try

        End Function



        Public Function Buscar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Pedido_Buscar"
                _objConexion.EjecutarComando()
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstPedidos = New List(Of EN_Pedido)

                While odrDatos.Read
                    _entPedido = New EN_Pedido
                    _entPedido.IdPedido = odrDatos("var_IdPedido")
                    _entPedido.IdCliente = odrDatos("var_Cliente")
                    _entPedido.FechaIngreso = odrDatos("var_FechaInicio")
                    _entPedido.FechaEntrega = odrDatos("var_FechaFinal")
                    _lstPedidos.Add(_entPedido)
                End While
                Return (_lstPedidos.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function




#End Region



    End Class
End Namespace