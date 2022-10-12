Imports EN_ALVINET_CONTA.GENERAL
Imports AD_ALVINET_CONTA.GENERAL
Namespace GENERAL


    Public Class LN_Empleado
#Region "Variables"
        Private _objADEmpleado As New AD_Empleado
        Private _objError As New Exception
        Private _lstEmpleado As List(Of EN_Empleado)
        Private _entempleado As New EN_Empleado
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstEmpleado As List(Of EN_Empleado)
            Get
                Return _lstEmpleado
            End Get
        End Property

        Public Property entEmpleado As EN_Empleado
            Get
                Return _entempleado
            End Get
            Set(ByVal Value As EN_Empleado)
                _entempleado = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"

        Public Function Listar() As Boolean
            _objADEmpleado.entCliente = entEmpleado
            If _objADEmpleado.Listar = True Then
                _lstEmpleado = _objADEmpleado.lstCliente
                Return (_lstEmpleado.Count > 0)
            Else
                Return False
            End If
        End Function

#End Region
    End Class
End Namespace