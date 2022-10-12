Imports EN_ALVINET_CONTA.OPERACION
Imports AD_ALVINET_CONTA.OPERACION

Namespace OPERACION
    Public Class LN_OperacionVoucher
        Private _objADOperacionVoucher As AD_OperacionVoucher
        Private _entOperacion As EN_OperacionVoucher
        Private _lstOperacion As List(Of EN_OperacionVoucher)
        Private _entCuenta As EN_OperacionCuenta
        Private _lstCuenta As List(Of EN_OperacionCuenta)
        Private _objError As New Exception

#Region "Propiedades"
        Public Property entOperacion() As EN_OperacionVoucher
            Get
                Return _entOperacion
            End Get
            Set(ByVal value As EN_OperacionVoucher)
                _entOperacion = value
            End Set
        End Property

        Public ReadOnly Property lstOperacion() As List(Of EN_OperacionVoucher)
            Get
                Return _lstOperacion
            End Get
        End Property

        Public Property entCuenta() As EN_OperacionCuenta
            Get
                Return _entCuenta
            End Get
            Set(ByVal value As EN_OperacionCuenta)
                _entCuenta = value
            End Set
        End Property

        Public Property lstCuenta() As List(Of EN_OperacionCuenta)
            Get
                Return _lstCuenta
            End Get
            Set(ByVal value As List(Of EN_OperacionCuenta))
                _lstCuenta = value
            End Set
        End Property

        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property
#End Region

#Region "Metodos y Funciones"

        Public Function Registrar()
            _objADOperacionVoucher = New AD_OperacionVoucher
            _objADOperacionVoucher.entOperacion = _entOperacion
            _objADOperacionVoucher.lstCuenta = _lstCuenta

            Return _objADOperacionVoucher.Registrar

        End Function
#End Region
    End Class
End Namespace