
Imports EN_ALVINET_CONTA.VENTAS
Imports AD_ALVINET_CONTA.VENTAS



Namespace VENTAS
    Public Class LN_NotaCredito


#Region "Variables"
        Private _objADDatos As New AD_NotaCredito
        Private _objError As New Exception
        Private _lstNotasCredito As List(Of EN_NotaCredito)
        Private _entNotaCredito As New EN_NotaCredito
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstNotasCredito As List(Of EN_NotaCredito)
            Get
                Return _lstNotasCredito
            End Get
        End Property

        Public Property entNotaCredito As EN_NotaCredito
            Get
                Return _entNotaCredito
            End Get
            Set(ByVal Value As EN_NotaCredito)
                _entNotaCredito = Value
            End Set
        End Property
#End Region


#Region "Metodo y Funciones"
        Public Function Buscar() As Boolean

            If _entNotaCredito.Idnota <> "" Then
                _objADDatos.entNotaCredito = _entNotaCredito
                _objADDatos.Buscar()
                _lstNotasCredito = _objADDatos.lstNotasCredito
                Return (_lstNotasCredito.Count > 0)
            Else
                Return False
            End If
        End Function

        Public Function Obtener() As Boolean

            If _entNotaCredito.Idnota <> "" Then

                _objADDatos.entNotaCredito = _entNotaCredito

                _objADDatos.Obtener()
                _lstNotasCredito = _objADDatos.lstNotasCredito
                Return (_lstNotasCredito.Count > 0)
            Else
                Return False
            End If
        End Function
        Public Function Registrar(ByVal dtbAtributos As DataTable) As Boolean
            If entNotaCredito.Idnota <> "" Then

                _objADDatos.entNotaCredito = _entNotaCredito
                Return _objADDatos.Registrar(dtbAtributos)
            Else
                Return False
            End If
        End Function


        Public Function Eliminar() As Boolean
            If entNotaCredito.Idnota <> "" Then

                _objADDatos.entNotaCredito = _entNotaCredito
                Return _objADDatos.Eliminar()
            Else
                Return False
            End If
        End Function


        Public Function ObtenerAtributos() As Boolean

            If _entNotaCredito.Idnota <> "" Then

                _objADDatos.entNotaCredito = _entNotaCredito

                _objADDatos.ObtenerAtributos()
                _lstNotasCredito = _objADDatos.lstNotasCredito
                Return (_lstNotasCredito.Count > 0)
            Else
                Return False
            End If
        End Function

        Public Function SerieMayor() As Boolean

            If _entNotaCredito.Maximo <> "" Then

                _objADDatos.entNotaCredito = _entNotaCredito

                _objADDatos.SerieMayor()
                _lstNotasCredito = _objADDatos.lstNotasCredito
                Return (_lstNotasCredito.Count > 0)
            Else
                Return False
            End If
        End Function
#End Region

    End Class
End Namespace