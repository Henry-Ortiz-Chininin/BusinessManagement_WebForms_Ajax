Imports EN_ALVINET_CONTA
Imports AD_ALVINET_CONTA
Imports EN_ALVINET_CONTA.CONFIG

Public Class LN_MovimientoBancario
#Region "Variables"
    Private _entMovimientoBancario As New EN_MovimientoBancario

    Private _lstMovimientoBancario As List(Of EN_MovimientoBancario)
    Private _objError As New Exception
    Private _objADMovimientoBancario As New AD_MovimientoBancario

#End Region
#Region "Propiedades"


    Public ReadOnly Property lstMovimientoBancario() As List(Of EN_MovimientoBancario)
        Get
            Return _lstMovimientoBancario
        End Get

    End Property


    Public Property entMovimientoBancario() As EN_MovimientoBancario
        Get
            Return _entMovimientoBancario
        End Get
        Set(ByVal value As EN_MovimientoBancario)
            _entMovimientoBancario = value
        End Set
    End Property


    Public ReadOnly Property objError() As Exception
        Get
            Return _objError
        End Get

    End Property


#End Region
#Region "Metodos"
    Public Function Registrar() As Boolean
        If _entMovimientoBancario.IdMoneda <> "" AndAlso _
            _entMovimientoBancario.IdEntidadFinanciera <> "" AndAlso _
             _entMovimientoBancario.Importe <> 0 Then
            ' _entMovimientoBancario.IdMedioPago <>  Then
            _objADMovimientoBancario.entMovimientoBancario = _entMovimientoBancario
            Return _objADMovimientoBancario.Registrar()
        Else
            Return False
        End If


    End Function
    Public Function Eliminar() As Boolean

        If _entMovimientoBancario.IdBanco <> "" Then
            _objADMovimientoBancario.entMovimientoBancario = _entMovimientoBancario
            Return _objADMovimientoBancario.Eliminar
        Else
            Return False
        End If

    End Function
    Public Function Listar() As Boolean
        _objADMovimientoBancario.Listar()
        _lstMovimientoBancario = _objADMovimientoBancario.lstMovimientoBancario
        Return (_lstMovimientoBancario.Count > 0)
    End Function
#End Region
End Class
