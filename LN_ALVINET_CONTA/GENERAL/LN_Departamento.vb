Imports EN_ALVINET_CONTA.GENERAL
Imports AD_ALVINET_CONTA.GENERAL

Namespace GENERAL
    Public Class LN_Departamento
#Region "Variables"
        Private _objError As New Exception
        Private _entDepartamento As New EN_Departamento
        Private _objDepartamento As New AD_Departamento
        Private _lstDepartamento As List(Of EN_Departamento)
#End Region
#Region "Propiedades"

        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property

        Public Property entDepartamento() As EN_Departamento
            Get
                Return _entDepartamento
            End Get
            Set(value As EN_Departamento)
                _entDepartamento = value
            End Set
        End Property

        Public Property lstDepartamento() As List(Of EN_Departamento)
            Get
                Return _lstDepartamento
            End Get
            Set(value As List(Of EN_Departamento))
                _lstDepartamento = value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"
        Public Function Listar() As Boolean
            If _objDepartamento.Lista = True Then
                _lstDepartamento = _objDepartamento.lstDepartamento
                Return True
            Else
                Return False
            End If
        End Function
#End Region
    End Class
End Namespace

