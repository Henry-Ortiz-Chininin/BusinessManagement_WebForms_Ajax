Imports EN_ALVINET_CONTA
Imports AD_ALVINET_CONTA
Imports EN_ALVINET_CONTA.CONFIG

Public Class LN_MovimientoCaja
#Region "Variables"
    Private _entMovimientoCaja As New EN_MovimientoCaja

    Private _lstMovimientoCaja As List(Of EN_MovimientoCaja)
    Private _objADMovimientoCaja As New AD_MovimientoCaja
    Private _objError As New Exception

#End Region
#Region "Propiedades"


    Public ReadOnly Property lstMovimientoCaja() As List(Of EN_MovimientoCaja)
        Get
            Return _lstMovimientoCaja
        End Get
    End Property


    Public ReadOnly Property objError() As Exception
        Get
            Return _objError
        End Get
    End Property


    Public Property entMovimientoCaja() As EN_MovimientoCaja
        Get
            Return _entMovimientoCaja
        End Get
        Set(ByVal value As EN_MovimientoCaja)
            _entMovimientoCaja = value
        End Set
    End Property



#End Region
#Region "Metodos y Funciones"
    Public Function Registrar() As Boolean

        If _entMovimientoCaja.Comprobante <> "" AndAlso _
            _entMovimientoCaja.Importe <> 0 AndAlso _
            _entMovimientoCaja.IdMoneda <> "" Then
            _objADMovimientoCaja.entMovimientoCaja = _entMovimientoCaja
            Return _objADMovimientoCaja.Registrar()
        Else
            Return False
        End If

    End Function
    Public Function Eliminar() As Boolean

        If _entMovimientoCaja.IdCaja <> "" Then
            _objADMovimientoCaja.entMovimientoCaja = _entMovimientoCaja
            Return _objADMovimientoCaja.Eliminar()
        Else
            Return False
        End If

    End Function
    Public Function Listar() As Boolean

        If _objADMovimientoCaja.Listar Then
            _lstMovimientoCaja = _objADMovimientoCaja.lstMovimientoCaja
            Return (_lstMovimientoCaja.Count > 0)
        Else
            Return False

        End If


    End Function
#End Region
End Class
