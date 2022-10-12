Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.CONFIG

Namespace CONFIG
    Public Class LN_TipoAnalisis
#Region "Variables"
        Private _objADTipoAnalisis As New AD_TipoAnalisis
        Private _objError As New Exception
        Private _lstTiposAnalisis As List(Of EN_TipoAnalisis)
        Private _entTipoAnalisis As New EN_TipoAnalisis
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstTiposAnalisis As List(Of EN_TipoAnalisis)
            Get
                Return _lstTiposAnalisis
            End Get
        End Property

        Public Property entTipoAnalisis As EN_TipoAnalisis
            Get
                Return _entTipoAnalisis
            End Get
            Set(ByVal Value As EN_TipoAnalisis)
                _entTipoAnalisis = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"
        Public Function Registrar() As Boolean

            If entTipoAnalisis.IdEmpresa <> "" AndAlso _
               entTipoAnalisis.TipoAnalisis <> "" Then

                _objADTipoAnalisis.entTipoAnalisis = _entTipoAnalisis
                Return _objADTipoAnalisis.Registrar()

            Else
                Return False
            End If
        End Function


        Public Function Listar() As Boolean

            If entTipoAnalisis.IdEmpresa <> "" Then
                _objADTipoAnalisis.entTipoAnalisis = entTipoAnalisis
                _objADTipoAnalisis.Listar()
                _lstTiposAnalisis = _objADTipoAnalisis.lstTiposAnalisis
                Return (_lstTiposAnalisis.Count > 0)
            Else
                Return False
            End If
        End Function


        Public Function Eliminar() As Boolean
            If entTipoAnalisis.IdEmpresa <> "" AndAlso _
                entTipoAnalisis.IdTipoAnalisis <> "" Then

                _objADTipoAnalisis.entTipoAnalisis = _entTipoAnalisis
                Return _objADTipoAnalisis.Eliminar()

            Else
                Return False
            End If
        End Function
#End Region
    End Class
End Namespace