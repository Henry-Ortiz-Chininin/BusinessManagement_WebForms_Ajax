Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.CONFIG

Namespace CONFIG
    Public Class LN_OperacionCuenta
#Region "Variables"
        Private _objADOperacionCuenta As New AD_OperacionCuenta
        Private _objError As New Exception
        Private _lstOperacionCuenta As List(Of EN_OperacionesCuenta)
        Private _entOperacionCuenta As New EN_OperacionesCuenta
#End Region
#Region "Propiedades"

        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstOperacionCuenta() As List(Of EN_OperacionesCuenta)
            Get
                Return _lstOperacionCuenta
            End Get
        End Property

        Public Property entOperacionCuenta() As EN_OperacionesCuenta
            Get
                Return _entOperacionCuenta
            End Get
            Set(ByVal Value As EN_OperacionesCuenta)
                _entOperacionCuenta = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones "

        Public Function Registrar() As Boolean
            If entOperacionCuenta.IdCuentaContable <> "" AndAlso _
                entOperacionCuenta.IdEmpresa <> "" AndAlso _
                entOperacionCuenta.IdOperacion <> "" AndAlso _
                entOperacionCuenta.IdContabilidad <> "" AndAlso _
                entOperacionCuenta.EsCargo <> "" AndAlso _
                entOperacionCuenta.EsAbono <> "" AndAlso _
                entOperacionCuenta.IdSubOperacion <> "" Then

                _objADOperacionCuenta.entOperacionCuenta = _entOperacionCuenta
                Return _objADOperacionCuenta.Registrar()

            Else
                Return False
            End If
        End Function
        Public Function Agregar() As Boolean
            If entOperacionCuenta.IdCuentaContable <> "" AndAlso _
               entOperacionCuenta.Operacion <> "" AndAlso _
                entOperacionCuenta.EsCargo <> "" AndAlso _
                entOperacionCuenta.EsAbono <> "" AndAlso _
                entOperacionCuenta.Observacion <> "" Then

                _objADOperacionCuenta.entOperacionCuenta = _entOperacionCuenta
                Return _objADOperacionCuenta.Agregar

            Else
                Return False
            End If
        End Function
        Public Function Quitar() As Boolean
            ' If entOperacionCuenta.IdCuenta <> "" Then

            _objADOperacionCuenta.entOperacionCuenta = _entOperacionCuenta
            Return _objADOperacionCuenta.Quitar

            'Else
            ' Return False
            'End If
        End Function
        Public Function ListarC() As Boolean

            If _objADOperacionCuenta.ListarC() Then
                _lstOperacionCuenta = _objADOperacionCuenta.lstOperacionCuenta
                Return (_lstOperacionCuenta.Count > 0)
            Else
                Return False
            End If

        End Function
        Public Function Buscar() As Boolean
            _objADOperacionCuenta.entOperacionCuenta = entOperacionCuenta
            If _objADOperacionCuenta.Buscar() Then
                _lstOperacionCuenta = _objADOperacionCuenta.lstOperacionCuenta
                Return (_lstOperacionCuenta.Count > 0)
            Else
                Return False
            End If

        End Function
        Public Function Listar() As Boolean
            If entOperacionCuenta.IdEmpresa <> "" Then
                _objADOperacionCuenta.entOperacionCuenta = entOperacionCuenta
                _objADOperacionCuenta.Listar()
                _lstOperacionCuenta = _objADOperacionCuenta.lstOperacionCuenta
                Return (_lstOperacionCuenta.Count > 0)
            Else
                Return False
            End If
        End Function

        Public Function Eliminar() As Boolean
            If entOperacionCuenta.IdCuentaContable <> "" AndAlso _
                entOperacionCuenta.IdEmpresa <> "" AndAlso _
                entOperacionCuenta.IdOperacion <> "" AndAlso _
                entOperacionCuenta.IdContabilidad <> "" AndAlso _
                entOperacionCuenta.IdSubOperacion <> "" Then
                _objADOperacionCuenta.entOperacionCuenta = entOperacionCuenta
                Return _objADOperacionCuenta.Eliminar
            Else
                Return False
            End If
        End Function

#End Region
    End Class
End Namespace