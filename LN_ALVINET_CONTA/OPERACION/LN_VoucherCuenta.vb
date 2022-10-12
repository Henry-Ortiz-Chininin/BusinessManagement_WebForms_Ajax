Imports AD_ALVINET_CONTA.OPERACION
Imports EN_ALVINET_CONTA.OPERACION

Namespace OPERACION
    Public Class LN_VoucherCuenta
#Region "Variables"
        Private _objADVoucherCuenta As New AD_VoucherCuenta
        Private _objError As New Exception
        Private _lstVoucherCuentas As List(Of EN_VoucherCuenta)
        Private _entVoucherCuenta As New EN_VoucherCuenta
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property
        Public ReadOnly Property lstVoucherCuentas() As List(Of EN_VoucherCuenta)
            Get
                Return _lstVoucherCuentas
            End Get
        End Property
        Public Property entVoucherCuenta() As EN_VoucherCuenta
            Get
                Return _entVoucherCuenta
            End Get
            Set(ByVal Value As EN_VoucherCuenta)
                _entVoucherCuenta = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones "
        Public Function Registrar() As Boolean
            If entVoucherCuenta.IdEmpresa <> "" AndAlso _
               entVoucherCuenta.IdContabilidad <> "" AndAlso _
                    entVoucherCuenta.IdEjercicio <> "" AndAlso _
                    entVoucherCuenta.IdOperacion <> "" AndAlso _
                    entVoucherCuenta.IdAsiento <> "" Then


                _objADVoucherCuenta.entPlanCuenta = _entVoucherCuenta
                Return _objADVoucherCuenta.Registrar()
            Else
                Return False
            End If
        End Function
        Public Function Listar() As Boolean
            If _objADVoucherCuenta.Listar() = True Then

                _lstVoucherCuentas = _objADVoucherCuenta.lstPlaneCuentas
                Return (_lstVoucherCuentas.Count > 0)
            Else
                Return False
            End If
        End Function
        Public Function Eliminar() As Boolean

            If entVoucherCuenta.IdCuentaContable <> "" AndAlso _
                entVoucherCuenta.IdEjercicio <> "" AndAlso _
                entVoucherCuenta.IdContabilidad <> "" AndAlso _
                entVoucherCuenta.IdEmpresa <> "" AndAlso _
                entVoucherCuenta.IdOperacion <> "" AndAlso _
                entVoucherCuenta.IdAsiento <> "" Then

                _objADVoucherCuenta.entPlanCuenta = entVoucherCuenta
                Return _objADVoucherCuenta.Eliminar
            Else
                Return False
            End If
        End Function
#End Region
    End Class
End Namespace