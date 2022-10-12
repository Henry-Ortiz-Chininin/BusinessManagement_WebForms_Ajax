Imports AD_ALVINET_CONTA.OPERACION
Imports EN_ALVINET_CONTA.OPERACION

Namespace OPERACION
    Public Class LN_Voucher
#Region "Variables"
        Private _objADVoucher As New AD_Voucher
        Private _objError As New Exception
        Private _lstVouchers As List(Of EN_Voucher)
        Private _entVoucher As New EN_Voucher
#End Region
#Region "Propiedades"

        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstVouchers() As List(Of EN_Voucher)
            Get
                Return _lstVouchers
            End Get
        End Property

        Public Property entVoucher() As EN_Voucher
            Get
                Return _entVoucher
            End Get
            Set(ByVal Value As EN_Voucher)
                _entVoucher = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones "

        Public Function Registrar() As Boolean
            If _entVoucher.IdOperacion <> "" AndAlso _entVoucher.IdEmpresa <> "" _
                AndAlso _entVoucher.EjercicioEmpresa.IdEjercicioEmpresa <> "" AndAlso _entVoucher.IdContabilidad <> "" Then

                _objADVoucher.entVoucher = _entVoucher

                Return _objADVoucher.Registrar()
            Else
                Return False
            End If
        End Function
        Public Function Buscar() As Boolean
            _objADVoucher.entVoucher = _entVoucher

            If _objADVoucher.Buscar() = True Then
                _lstVouchers = _objADVoucher.lstVouchers
                Return (_lstVouchers.Count > 0)
            Else
                Return False
            End If
        End Function
        Public Function BuscarxOp(ByVal idPartida As String, ByVal idasiento As String) As Boolean

            If _objADVoucher.BuscarxOp(idPartida, idasiento) = True Then
                _lstVouchers = _objADVoucher.lstVouchers
                Return (_lstVouchers.Count > 0)
            Else
                Return False
            End If
        End Function
        Public Function ListarDetalle(ByVal idAsiento As String, ByVal idOperacion As String) As Boolean
            If _objADVoucher.ListarDetalle(idAsiento, idOperacion) = True Then

                _lstVouchers = _objADVoucher.lstVouchers
                Return (_lstVouchers.Count > 0)
            Else
                Return False
            End If
        End Function
        Public Function Listar() As Boolean
            _objADVoucher.entVoucher = _entVoucher
            If _objADVoucher.Listar() = True Then

                _lstVouchers = _objADVoucher.lstVouchers
                Return (_lstVouchers.Count > 0)
            Else
                Return False
            End If
        End Function
        Public Function Eliminar() As Boolean

            If entVoucher.IdEmpresa <> "" AndAlso _
                entVoucher.EjercicioEmpresa.IdEjercicioEmpresa <> "" AndAlso _
                entVoucher.IdContabilidad <> "" AndAlso _
                entVoucher.IdOperacion <> "" AndAlso _
                entVoucher.IdAsiento <> "" Then
                _objADVoucher.entVoucher = entVoucher
                Return _objADVoucher.Eliminar
            Else
                Return False
            End If
        End Function
        Public Function BusqXOp(ByVal idPartida As String, ByVal idasiento As String) As Boolean

            If _objADVoucher.BusqXOp(idPartida, idasiento) = True Then
                _lstVouchers = _objADVoucher.lstVouchers
                Return (_lstVouchers.Count > 0)
            Else
                Return False
            End If
        End Function

        Public Function BusquedaOperacion() As Boolean

            _objADVoucher.entVoucher = _entVoucher

            If _objADVoucher.BusquedaOperacion = True Then
                _lstVouchers = _objADVoucher.lstVouchers
                Return (_lstVouchers.Count > 0)
            Else
                Return False
            End If
        End Function
        Public Function BusquedaOperacionN() As Boolean

            _objADVoucher.entVoucher = _entVoucher

            If _objADVoucher.BusquedaOperacionN = True Then
                _lstVouchers = _objADVoucher.lstVouchers
                Return (_lstVouchers.Count > 0)
            Else
                Return False
            End If
        End Function
        Public Function Anular() As Boolean

            If entVoucher.IdAsiento <> "" AndAlso entVoucher.IdEmpresa <> "" _
                AndAlso entVoucher.IdEjercicio <> "" _
                AndAlso entVoucher.IdContabilidad <> "" _
                AndAlso entVoucher.IdOperacion <> "" Then
                _objADVoucher.entVoucher = entVoucher
                _objADVoucher.Anular()
                Return True
            Else
                Return False
            End If

        End Function

#End Region
    End Class
End Namespace