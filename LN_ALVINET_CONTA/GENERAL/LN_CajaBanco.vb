Imports AD_ALVINET_CONTA.GENERAL
Imports EN_ALVINET_CONTA.GENERAL
Imports EN_ALVINET_CONTA

Namespace GENERAL


    Public Class LN_CajaBanco
#Region "Variables"
        Private _objADCajaBanco As New AD_CajaBanco
        Private _objError As New Exception
        Private _lstCajaBanco As List(Of EN_CajaBanco)
        Private _entCajaBanco As New EN_ALVINET_CONTA.GENERAL.EN_CajaBanco

        Private _lstDepartamento As List(Of EN_Departamento)

        Private _entDepartamento As EN_Departamento

        Private _entBase As EN_Base

#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstCajaBanco As List(Of EN_CajaBanco)
            Get
                Return _lstCajaBanco
            End Get
        End Property

        Public Property entCajaBanco As EN_CajaBanco
            Get
                Return _entCajaBanco
            End Get
            Set(ByVal Value As EN_CajaBanco)
                _entCajaBanco = Value
            End Set
        End Property

        Public ReadOnly Property lstDepartamento() As List(Of EN_Departamento)
            Get
                Return _lstDepartamento
            End Get

        End Property

        Public Property entDepartamento() As EN_Departamento
            Get
                Return _entDepartamento
            End Get
            Set(ByVal value As EN_Departamento)
                _entDepartamento = value
            End Set
        End Property
        Public Property entBase() As EN_Base
            Get
                Return _entBase
            End Get
            Set(ByVal value As EN_Base)
                _entBase = value
            End Set
        End Property

#End Region
#Region "Metodos y Funciones"
        Public Function Registrar() As Boolean

            If _entCajaBanco.Observacion <> "" AndAlso _
                _entCajaBanco.Comprobante <> "" AndAlso _
                _entCajaBanco.Importe > 0 Then
                _objADCajaBanco.entCajaBanco = _entCajaBanco
                Return _objADCajaBanco.Registrar()
            Else
                Return False
            End If


        End Function
        Public Function Eliminar() As Boolean
            'Try

            '    If _entCajaBanco.Id <> "" Then
            '        _objADCajaBanco.entCajaBanco = _entCajaBanco
            '        Return _objADCajaBanco.Eliminar()

            '    End If

            'Catch ex As Exception
            '    _objError = ex
            '    Return False
            'End Try
            Return True
        End Function
        Public Function Buscar(ByVal pstrFechaInicio As String, ByVal pstrFechFinal As String) As Boolean
            Try

                _objADCajaBanco.entCajaBanco = _entCajaBanco
                _objADCajaBanco.Buscar(pstrFechaInicio, pstrFechFinal)
                _lstCajaBanco = _objADCajaBanco.lstCajaBanco

                Return (_lstCajaBanco.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function Listar() As Boolean
            Try

                _objADCajaBanco.entBase = entBase
                _objADCajaBanco.Listar()
                _lstCajaBanco = _objADCajaBanco.lstCajaBanco

                Return (_lstCajaBanco.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function ListarDepartamento() As Boolean
            _objADCajaBanco.ListarDepartamento()
            _lstDepartamento = _objADCajaBanco.lstDepartamento
            Return (_lstDepartamento.Count > 0)
        End Function
#End Region
    End Class
End Namespace