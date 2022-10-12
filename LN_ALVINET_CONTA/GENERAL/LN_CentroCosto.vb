Imports EN_ALVINET_CONTA.GENERAL
Imports AD_ALVINET_CONTA.GENERAL

Namespace GENERAL
    Public Class LN_CentroCosto
#Region "Variables"
        Private _objADCentroCosto As New AD_CentroCosto
        Private _objError As New Exception
        Private _lstcentroCostos As List(Of EN_CentroCosto)
        Private _entCentroCosto As New EN_CentroCosto
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstcentroCostos As List(Of EN_CentroCosto)
            Get
                Return _lstcentroCostos
            End Get
        End Property

        Public Property entCentroCosto As EN_CentroCosto
            Get
                Return _entCentroCosto
            End Get
            Set(ByVal Value As EN_CentroCosto)
                _entCentroCosto = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"
        Public Function Registrar() As Boolean

            If entCentroCosto.IdEmpresa <> "" AndAlso _
             entCentroCosto.IdCentroCosto <> "" AndAlso _
             entCentroCosto.CentroCosto <> "" AndAlso _
                entCentroCosto.Nivel > 0 Then

                _objADCentroCosto.entCentroCosto = _entCentroCosto
                Return _objADCentroCosto.Registrar()
            Else
                Return False
            End If

        End Function

        Public Function Listar() As Boolean

            If entCentroCosto.IdEmpresa <> "" Then
                _objADCentroCosto.entCentroCosto = entCentroCosto
                _objADCentroCosto.Listar()
                _lstcentroCostos = _objADCentroCosto.lstCentroCostos
                Return (_lstcentroCostos.Count > 0)
            Else
                Return False
            End If
        End Function


        Public Function Eliminar() As Boolean

            If entCentroCosto.IdEmpresa <> "" AndAlso _
                entCentroCosto.IdCentroCosto <> "" Then

                _objADCentroCosto.entCentroCosto = _entCentroCosto
                Return _objADCentroCosto.Eliminar()
            Else
                Return False
            End If
        End Function

        Public Function Obtener() As Boolean

            ' If _entCentroCosto.IdCentroCosto <> "" Or _entCentroCosto.Decripcion <> "" Then

            _objADCentroCosto.entCentroCosto = _entCentroCosto
            _objADCentroCosto.Obtener()

            _lstcentroCostos = _objADCentroCosto.lstCentroCostos

            Return (_lstcentroCostos.Count > 0)
            ' Else
            ' Return False
            ' End If
        End Function
#End Region
    End Class
End Namespace