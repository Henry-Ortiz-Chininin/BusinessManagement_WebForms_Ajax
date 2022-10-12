Imports EN_ALVINET_CONTA.GENERAL
Imports AD_ALVINET_CONTA.GENERAL

Namespace GENERAL
    Public Class LN_Empresa
#Region "Variables"
        Private _objADEmpresa As New AD_Empresa
        Private _objError As New Exception
        Private _lstEmpresas As List(Of EN_Empresa)
        Private _entEmpresa As New EN_Empresa
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstEmpresas As List(Of EN_Empresa)
            Get
                Return _lstEmpresas
            End Get
        End Property

        Public Property entEmpresa As EN_Empresa
            Get
                Return _entEmpresa
            End Get
            Set(ByVal Value As EN_Empresa)
                _entEmpresa = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"
        Public Function Registrar() As Boolean
            If entEmpresa.Ruc <> "" AndAlso _
            entEmpresa.RazonSocial <> "" Then
                _objADEmpresa.entEmpresa = _entEmpresa
                Return _objADEmpresa.Registrar()
            Else
                Return False
            End If
        End Function

        Public Function Listar() As Boolean
            If _entEmpresa.IdUsuario <> "" Then
                _objADEmpresa.entEmpresa = _entEmpresa
                _objADEmpresa.Listar()
                _lstEmpresas = _objADEmpresa.lstEmpresas
                Return (_lstEmpresas.Count > 0)
            Else
                Return False
            End If
        End Function


        Public Function Eliminar() As Boolean
            If entEmpresa.IdEmpresa <> "" Then
                _objADEmpresa.entEmpresa = _entEmpresa
                Return _objADEmpresa.Eliminar()
            Else
                Return False
            End If
        End Function
        Public Function ListaInterno(ByVal idEmpresa As String, ByVal nomEmpresa As String) As Boolean
            _objADEmpresa.ListaInterno(idEmpresa, nomEmpresa)
            _lstEmpresas = _objADEmpresa.lstEmpresas
            Return (_lstEmpresas.Count > 0)
        End Function

        Public Function CerrarCompras(ByVal pstr_IdEjercicio As String, ByVal pstr_IdMes As String) As Boolean
            _objADEmpresa = New AD_Empresa
            Return _objADEmpresa.CerrarCompras(pstr_IdEjercicio, pstr_IdMes)

        End Function
        Public Function CerrarVentas(ByVal pstr_IdEjercicio As String, ByVal pstr_IdMes As String) As Boolean
            _objADEmpresa = New AD_Empresa
            Return _objADEmpresa.CerrarVentas(pstr_IdEjercicio, pstr_IdMes)

        End Function
#End Region
    End Class
End Namespace