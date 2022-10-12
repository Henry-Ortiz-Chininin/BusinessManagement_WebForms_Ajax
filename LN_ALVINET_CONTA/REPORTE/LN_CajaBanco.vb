Imports AD_ALVINET_CONTA.REPORTE
Imports EN_ALVINET_CONTA.GENERAL
Imports EN_ALVINET_CONTA

Namespace REPORTE


    Public Class LN_CajaBanco
#Region "Variables"
        Private _objADCajaBanco As New AD_CajaBanco
        Private _objError As New Exception
        Private _entCajaBanco As New EN_ALVINET_CONTA.GENERAL.EN_CajaBanco
        Private _dtbDatos As Data.DataTable


        Private _entBase As EN_Base

#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
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

        Public Property entBase() As EN_Base
            Get
                Return _entBase
            End Get
            Set(ByVal value As EN_Base)
                _entBase = value
            End Set
        End Property

        Public ReadOnly Property Datos As DataTable
            Get
                Return _dtbDatos
            End Get
        End Property

#End Region
#Region "Metodos y Funciones"
        
        Public Function Buscar(ByVal pstrFechaInicio As String, ByVal pstrFechFinal As String) As Boolean
            Try

                _objADCajaBanco.entCajaBanco = _entCajaBanco
                _objADCajaBanco.Buscar(pstrFechaInicio, pstrFechFinal)
                _dtbDatos = _objADCajaBanco.Datos

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        
#End Region
    End Class
End Namespace