
Imports EN_ALVINET_CONTA.VENTAS
Imports AD_ALVINET_CONTA.VENTAS


Namespace VENTAS

    Public Class LN_Pedido



#Region "Variables"
        Private _objADDatos As New AD_Pedido
        Private _objError As New Exception
        Private _lstPedidos As List(Of EN_Pedido)
        Private _entPedido As New EN_Pedido
#End Region
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
#Region "Metodo y Funciones"
        Public Function Buscar() As Boolean

            If _entPedido.IdPedido <> "" Then

                _objADDatos.entPedido = _entPedido

                _objADDatos.Buscar()
                _lstPedidos = _objADDatos.lstPedidos
                Return (_lstPedidos.Count > 0)
            Else
                Return False
            End If
        End Function

        Public Function Obtener() As Boolean

            If _entPedido.IdPedido <> "" Then

                _objADDatos.entPedido = _entPedido

                _objADDatos.Obtener()
                _lstPedidos = _objADDatos.lstPedidos
                Return (_lstPedidos.Count > 0)
            Else
                Return False
            End If
        End Function


        Public Function ObtenerAtributos() As Boolean

            If _entPedido.IdPedido <> "" Then

                _objADDatos.entPedido = _entPedido

                _objADDatos.ObtenerAtributos()
                _lstPedidos = _objADDatos.lstPedidos
                Return (_lstPedidos.Count > 0)
            Else
                Return False
            End If
        End Function
        Public Function Registrar(ByVal dtbAtributos As DataTable) As Boolean
            If entPedido.IdPedido <> "" Then

                _objADDatos.entPedido = _entPedido
                Return _objADDatos.Registrar(dtbAtributos)
            Else
                Return False
            End If
        End Function
        Public Function Eliminar() As Boolean
            If entPedido.IdPedido <> "" Then

                _objADDatos.entPedido = _entPedido
                Return _objADDatos.Eliminar()
            Else
                Return False
            End If
        End Function
#End Region






    End Class
End Namespace