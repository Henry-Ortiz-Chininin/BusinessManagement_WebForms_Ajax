Imports EN_ALVINET_CONTA.GENERAL
Imports AD_ALVINET_CONTA.GENERAL

Namespace GENERAL
    Public Class LN_TipoDocumento
#Region "Variables"
        Private _objADTipoDocumento As New AD_TipoDocumento
        Private _objError As New Exception
        Private _lstTipoDocumentos As List(Of EN_TipoDocumento)
        Private _entTipoDocumento As New EN_TipoDocumento
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property
        Public ReadOnly Property lstTipoDocumentos As List(Of EN_TipoDocumento)
            Get
                Return _lstTipoDocumentos
            End Get
        End Property
        Public Property entTipoDocumento As EN_TipoDocumento
            Get
                Return _entTipoDocumento
            End Get
            Set(ByVal Value As EN_TipoDocumento)
                _entTipoDocumento = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"
        Public Function Registrar() As Boolean
            If entTipoDocumento.IdEmpresa <> "" AndAlso _
            entTipoDocumento.TipoDocumento <> "" AndAlso _
            entTipoDocumento.Clase <> "" AndAlso _
             entTipoDocumento.IdSunat <> "" AndAlso _
            entTipoDocumento.Estado <> "" Then
                _objADTipoDocumento.entTipoDocumento = _entTipoDocumento
                Return _objADTipoDocumento.Registrar()
            Else
                Return False
            End If
        End Function
        Public Function Listar() As Boolean
            _objADTipoDocumento.entTipoDocumento = entTipoDocumento
            If _objADTipoDocumento.Listar() = True Then
                _lstTipoDocumentos = _objADTipoDocumento.lstTipoDocumentos
                Return (_lstTipoDocumentos.Count > 0)
            Else
                Return False
            End If
        End Function
        Public Function ListarSE() As Boolean
            _objADTipoDocumento.entTipoDocumento = entTipoDocumento
            If _objADTipoDocumento.ListarSE() = True Then
                _lstTipoDocumentos = _objADTipoDocumento.lstTipoDocumentos
                Return (_lstTipoDocumentos.Count > 0)
            Else
                Return False
            End If
        End Function
        Public Function Eliminar() As Boolean
            If entTipoDocumento.IdEmpresa <> "" AndAlso _
                entTipoDocumento.IdTipoDocumento <> "" Then
                _objADTipoDocumento.entTipoDocumento = _entTipoDocumento
                Return _objADTipoDocumento.Eliminar()
            Else
                Return False
            End If
        End Function
        Public Function Buscar() As Boolean
            _objADTipoDocumento.entTipoDocumento = _entTipoDocumento

            _objADTipoDocumento.Buscar()
            _lstTipoDocumentos = _objADTipoDocumento.lstTipoDocumentos
            Return (_lstTipoDocumentos.Count > 0)
           
        End Function
#End Region
    End Class
End Namespace