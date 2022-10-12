Imports AD_ALVINET_CONTA.CONFIG
Imports EN_ALVINET_CONTA.CONFIG

Namespace CONFIG


    Public Class LN_FormaPago

#Region "Variables"
        Private _objADFormaPago As New AD_FormaPago
        Private _objError As New Exception
        Private _lstFormaPago As List(Of EN_FormaPago)
        Private _entFormaPago As New EN_FormaPago
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstFormaPago As List(Of EN_FormaPago)
            Get
                Return _lstFormaPago
            End Get
        End Property

        Public Property entFormaPago As EN_FormaPago
            Get
                Return _entFormaPago
            End Get
            Set(ByVal Value As EN_FormaPago)
                _entFormaPago = Value
            End Set
        End Property
#End Region

#Region "Metodo y Funciones"

        Public Function Listar() As Boolean

            _objADFormaPago.entFormaPago = _entFormaPago
            _objADFormaPago.Listar()
            _lstFormaPago = _objADFormaPago.lstFormaPago
            Return (_lstFormaPago.Count > 0)

        End Function
#End Region

    End Class
End Namespace