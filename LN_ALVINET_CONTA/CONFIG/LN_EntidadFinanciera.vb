Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.CONFIG

Namespace CONFIG
    Public Class LN_EntidadFinanciera
#Region "Variables"
        Private _objADEntidadFinanciera As New AD_EntidadFinanciera
        Private _objError As New Exception
        Private _lstEntidadFinanciera As List(Of EN_EntidadFinanciera)
        Private _entEntidadFinanciera As New EN_EntidadFinanciera
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstEntidadFinanciera() As List(Of EN_EntidadFinanciera)
            Get
                Return _lstEntidadFinanciera
            End Get
        End Property

        Public Property entEntidadFinanciera() As EN_EntidadFinanciera
            Get
                Return _entEntidadFinanciera
            End Get
            Set(ByVal Value As EN_EntidadFinanciera)
                _entEntidadFinanciera = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"
        Public Function Registrar() As Boolean

            If entEntidadFinanciera.IdEmpresa <> "" AndAlso _
                entEntidadFinanciera.NombreEntidad <> "" _
                AndAlso entEntidadFinanciera.IdSunat <> "" Then

                _objADEntidadFinanciera.entEntidadFinanciera = _entEntidadFinanciera
                Return _objADEntidadFinanciera.Registrar()

            Else
                Return False
            End If

        End Function

        Public Function Listar() As Boolean

            If entEntidadFinanciera.IdEmpresa <> "" Then
                _objADEntidadFinanciera.entEntidadFinanciera = entEntidadFinanciera
                _objADEntidadFinanciera.Listar()
                _lstEntidadFinanciera = _objADEntidadFinanciera.lstEntidadFinanciera
                Return (_lstEntidadFinanciera.Count > 0)
            Else
                Return False
            End If

        End Function

        Public Function Eliminar() As Boolean

            If entEntidadFinanciera.IdEntidadFinanciera <> "" AndAlso _
               entEntidadFinanciera.IdEmpresa <> "" Then

                _objADEntidadFinanciera.entEntidadFinanciera = entEntidadFinanciera
                Return _objADEntidadFinanciera.Eliminar

            Else
                Return False
            End If

        End Function

#End Region
    End Class
End Namespace