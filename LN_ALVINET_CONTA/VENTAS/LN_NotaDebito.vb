Imports EN_ALVINET_CONTA.VENTAS
Imports AD_ALVINET_CONTA.VENTAS


Namespace VENTAS
    Public Class LN_NotaDebito


#Region "Variables"
        Private _objADDatos As New AD_NotaDebito
        Private _objError As New Exception
        Private _lstNotasDebito As List(Of EN_NotaDebito)
        Private _entNotaDebito As New EN_NotaDebito
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstNotasDebito As List(Of EN_NotaDebito)
            Get
                Return _lstNotasDebito
            End Get
        End Property

        Public Property entNotaDebito As EN_NotaDebito
            Get
                Return _entNotaDebito
            End Get
            Set(ByVal Value As EN_NotaDebito)
                _entNotaDebito = Value
            End Set
        End Property
#End Region


#Region "Metodo y Funciones"
        Public Function Buscar() As Boolean

            If _entNotaDebito.Idnota <> "" Then
                _objADDatos.entNotaDebito = _entNotaDebito
                _objADDatos.Buscar()
                _lstNotasDebito = _objADDatos.lstNotasDebito
                Return (_lstNotasDebito.Count > 0)
            Else
                Return False
            End If
        End Function

        Public Function Obtener() As Boolean

            If _entNotaDebito.Idnota <> "" Then

                _objADDatos.entNotaDebito = _entNotaDebito

                _objADDatos.Obtener()
                _lstNotasDebito = _objADDatos.lstNotasDebito
                Return (_lstNotasDebito.Count > 0)
            Else
                Return False
            End If
        End Function
        Public Function Registrar(ByVal dtbAtributos As DataTable) As Boolean
            If entNotaDebito.Idnota <> "" Then

                _objADDatos.entNotaDebito = _entNotaDebito
                Return _objADDatos.Registrar(dtbAtributos)
            Else
                Return False
            End If
        End Function

        Public Function Eliminar() As Boolean
            If entNotaDebito.Idnota <> "" Then

                _objADDatos.entNotaDebito = _entNotaDebito
                Return _objADDatos.Eliminar()
            Else
                Return False
            End If
        End Function


        Public Function ObtenerAtributos() As Boolean

            If _entNotaDebito.Idnota <> "" Then

                _objADDatos.entNotaDebito = _entNotaDebito

                _objADDatos.ObtenerAtributos()
                _lstNotasDebito = _objADDatos.lstNotasDebito
                Return (_lstNotasDebito.Count > 0)
            Else
                Return False
            End If
        End Function

        Public Function SerieMayor() As Boolean

            If _entNotaDebito.Maximo <> "" Then

                _objADDatos.entNotaDebito = _entNotaDebito

                _objADDatos.SerieMayor()
                _lstNotasDebito = _objADDatos.lstNotasDebito
                Return (_lstNotasDebito.Count > 0)
            Else
                Return False
            End If
        End Function

#End Region
    End Class
End Namespace