Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.CONFIG

Namespace CONFIG
    Public Class LN_TipoCuenta
#Region "Variables"
        Private _objADTipoCuenta As New AD_TipoCuenta
        Private _objError As New Exception
        Private _lstTipoCuentas As List(Of EN_TipoCuenta)
        Private _entTipoCuenta As New EN_TipoCuenta
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstTipoCuentas As List(Of EN_TipoCuenta)
            Get
                Return _lstTipoCuentas
            End Get
        End Property

        Public Property entTipoCuenta As EN_TipoCuenta
            Get
                Return _entTipoCuenta
            End Get
            Set(ByVal Value As EN_TipoCuenta)
                _entTipoCuenta = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"
        Public Function Registrar() As Boolean
            If entTipoCuenta.IdEmpresa <> "" AndAlso _
            entTipoCuenta.Descripcion <> "" Then

                _objADTipoCuenta.entTipoCuenta = _entTipoCuenta
                Return _objADTipoCuenta.Registrar()

            Else
                Return False
            End If
        End Function



        Public Function Listar() As Boolean
            If entTipoCuenta.IdEmpresa <> "" Then
                _objADTipoCuenta.entTipoCuenta = entTipoCuenta
                _objADTipoCuenta.Listar()
                _lstTipoCuentas = _objADTipoCuenta.lstTipoCuentas
                Return (_lstTipoCuentas.Count > 0)
            Else
                Return False
            End If
        End Function


        Public Function Eliminar() As Boolean
            If entTipoCuenta.IdEmpresa <> "" AndAlso _
                entTipoCuenta.IdTipoCuenta <> "" Then

                _objADTipoCuenta.entTipoCuenta = _entTipoCuenta
                Return _objADTipoCuenta.Eliminar()
            Else
                Return False
            End If
        End Function
#End Region
    End Class
End Namespace