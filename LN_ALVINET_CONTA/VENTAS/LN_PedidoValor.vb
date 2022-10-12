Imports EN_ALVINET_CONTA.VENTAS
Imports AD_ALVINET_CONTA.VENTAS
Imports AD_ALVINET_CONTA


Namespace VENTAS
    Public Class LN_PedidoValor

#Region "Variables"
        Private _objADDatos As New AD_PedidoValor
        Private _objError As New Exception
        Private _lstPedidoValor As List(Of EN_PedidoValor)
        Private _entPedidoValor As New EN_PedidoValor
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstPedidoValor As List(Of EN_PedidoValor)
            Get
                Return _lstPedidoValor
            End Get
        End Property

        Public Property entPedidoValor As EN_PedidoValor
            Get
                Return _entPedidoValor
            End Get
            Set(ByVal Value As EN_PedidoValor)
                _entPedidoValor = Value
            End Set
        End Property
#End Region
#Region "Metodo y Funciones"
        Public Function Buscar() As Boolean

            If _entPedidoValor.IdAtributoTipo <> "" Then

                _objADDatos.entPedidoValor = _entPedidoValor

                _objADDatos.Buscar()
                _lstPedidoValor = _objADDatos.lstPedidoValor
                Return (_lstPedidoValor.Count > 0)
            Else
                Return False
            End If
        End Function

        Public Function Obtener() As Boolean

            If _entPedidoValor.IdAtributoTipo <> "" Then

                _objADDatos.entPedidoValor = _entPedidoValor

                _objADDatos.Obtener()
                _lstPedidoValor = _objADDatos.lstPedidoValor
                Return (_lstPedidoValor.Count > 0)
            Else
                Return False
            End If
        End Function


        Public Function Registrar(ByVal dtbAtributos As DataTable) As Boolean
            If entPedidoValor.IdAtributoTipo <> "" Then

                _objADDatos.entPedidoValor = _entPedidoValor
                Return _objADDatos.Registrar(dtbAtributos)
            Else
                Return False
            End If
        End Function
        Public Function Eliminar() As Boolean
            If entPedidoValor.IdAtributoTipo <> "" AndAlso
            entPedidoValor.IdAtributoTipo <> "" Then

                _objADDatos.entPedidoValor = _entPedidoValor
                Return _objADDatos.Eliminar()
            Else
                Return False
            End If
        End Function



        Public Function Listar() As Boolean

            If entPedidoValor.IdAtributoTipo <> "" Then
                _objADDatos.entPedidoValor = _entPedidoValor
                _objADDatos.Listar()
                _lstPedidoValor = _objADDatos.lstPedidoValor
                Return (_lstPedidoValor.Count > 0)
            Else
                Return False
            End If
        End Function
#End Region


    End Class
End Namespace
