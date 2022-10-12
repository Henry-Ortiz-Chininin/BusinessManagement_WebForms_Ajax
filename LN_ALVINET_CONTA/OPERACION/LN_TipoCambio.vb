Imports EN_ALVINET_CONTA.OPERACION
Imports AD_ALVINET_CONTA.OPERACION

Namespace OPERACION
    Public Class LN_TipoCambio
#Region "Variables"
        Private _objADTipoCambio As New AD_TipoCambio
        Private _objError As New Exception
        Private _lstTipoCambios As List(Of EN_TipoCambio)
        Private _entTipoCambio As New EN_TipoCambio
#End Region
#Region "Propiedades"

        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstTipoCambios() As List(Of EN_TipoCambio)
            Get
                Return _lstTipoCambios
            End Get
        End Property

        Public Property entTipoCambio() As EN_TipoCambio
            Get
                Return _entTipoCambio
            End Get
            Set(ByVal Value As EN_TipoCambio)
                _entTipoCambio = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones "
        Public Function Registrar() As Boolean
            If _entTipoCambio.IdEmpresa <> "" AndAlso _
                 Not IsDBNull(entTipoCambio.Fecha) AndAlso _
                _entTipoCambio.Compra > 0 AndAlso _
               _entTipoCambio.Venta > 0 Then

                _objADTipoCambio.entTipoCambio = _entTipoCambio
                Return _objADTipoCambio.Registrar()
            Else
                Return False
            End If
        End Function
        Public Function Listar() As Boolean
            _objADTipoCambio.entTipoCambio = _entTipoCambio
            If _entTipoCambio.IdEmpresa <> "" Then
                _objADTipoCambio.Listar()
                _lstTipoCambios = _objADTipoCambio.lstTipoCambios
                Return (_lstTipoCambios.Count > 0)
            Else
                Return False
            End If
        End Function
        Public Function ListarMax() As Boolean

            If _objADTipoCambio.ListarMax Then
                _lstTipoCambios = _objADTipoCambio.lstTipoCambios
                Return (_lstTipoCambios.Count > 0)
                Return True
            Else
                Return False

            End If


            Return True

        End Function
        Public Function TipoCambioPorFecha() As Boolean

            If entTipoCambio.IdEmpresa <> "" AndAlso entTipoCambio.Fecha.ToString <> "" Then
                _objADTipoCambio.entTipoCambio = entTipoCambio
                _objADTipoCambio.TipoCambioPorFecha()
                _lstTipoCambios = _objADTipoCambio.lstTipoCambios
                Return (_lstTipoCambios.Count > 0)
                Return True
            Else
                Return False

            End If


            Return True

        End Function

        Public Function Eliminar() As Boolean

            If entTipoCambio.IdEmpresa <> "" AndAlso _
                entTipoCambio.IdTipoCambio <> "" Then


                _objADTipoCambio.entTipoCambio = entTipoCambio
                Return _objADTipoCambio.Eliminar
            Else
                Return False
            End If
        End Function
#End Region
    End Class
End Namespace