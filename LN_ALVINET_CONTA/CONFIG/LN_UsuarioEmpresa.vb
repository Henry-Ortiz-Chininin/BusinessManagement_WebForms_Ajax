Imports AD_ALVINET_CONTA.CONFIG
Imports EN_ALVINET_CONTA.CONFIG

Namespace CONFIG
    Public Class LN_UsuarioEmpresa
#Region "Variables"
        Private _objADUsuarioEmpresa As New AD_UsuarioEmpresa
        Private _objError As New Exception
        Private _lstUsuarioEmpresas As List(Of EN_UsuarioEmpresa)
        Private _entUsuarioEmpresa As New EN_UsuarioEmpresa
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstUsuarioEmpresas As List(Of EN_UsuarioEmpresa)
            Get
                Return _lstUsuarioEmpresas
            End Get
        End Property

        Public Property entUsuarioEmpresa As EN_UsuarioEmpresa
            Get
                Return _entUsuarioEmpresa
            End Get
            Set(ByVal Value As EN_UsuarioEmpresa)
                _entUsuarioEmpresa = Value
            End Set
        End Property


#End Region
#Region "Funciones"

        Public Function Registrar() As Boolean

            If entUsuarioEmpresa.IdEmpresa <> "" AndAlso _
             entUsuarioEmpresa.IdUsuario <> "" Then
                _objADUsuarioEmpresa.entUsuarioEmpresa = _entUsuarioEmpresa
                Return _objADUsuarioEmpresa.Registrar()

            Else
                Return False
            End If
        End Function


        Public Function Listar() As Boolean

            If _objADUsuarioEmpresa.Listar() = True Then
                _lstUsuarioEmpresas = _objADUsuarioEmpresa.lstUsuarioEmpresas
                Return (_lstUsuarioEmpresas.Count > 0)
            Else
                Return False
            End If
        End Function

        Public Function Buscar() As Boolean

            If entUsuarioEmpresa.IdUsuario <> "" Then
                _objADUsuarioEmpresa.entUsuarioEmpresa = entUsuarioEmpresa
                _objADUsuarioEmpresa.Listar()
                _lstUsuarioEmpresas = _objADUsuarioEmpresa.lstUsuarioEmpresas
                Return (_lstUsuarioEmpresas.Count > 0)
            Else
                Return False
            End If
        End Function


        Public Function Eliminar() As Boolean

            If entUsuarioEmpresa.IdUsuario <> "" AndAlso _
                entUsuarioEmpresa.IdEmpresa <> "" Then

                _objADUsuarioEmpresa.entUsuarioEmpresa = _entUsuarioEmpresa
                Return _objADUsuarioEmpresa.Eliminar()
            Else
                Return False
            End If
        End Function
#End Region
    End Class
End Namespace