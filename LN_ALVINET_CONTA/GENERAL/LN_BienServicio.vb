Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.AccesoDatos
Imports System.Data
Imports System.Data.SqlClient

Namespace CONFIG
    Public Class LN_BienServicio
#Region "Variables"
        Private _objConexion As AccesoDatosSQLServer
        Private _objADBienServicio As New AD_BienServicio
        Private _objError As New Exception
        Private _lstBienServicio As List(Of EN_BienServicio)
        Private _entBienServicio As New EN_BienServicio

#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property


        Public ReadOnly Property lstBienServicio As List(Of EN_BienServicio)
            Get
                Return _lstBienServicio
            End Get
        End Property

        Public Property entBienServicios As EN_BienServicio
            Get
                Return _entBienServicio
            End Get
            Set(ByVal Value As EN_BienServicio)
                _entBienServicio = Value
            End Set
        End Property

#End Region
#Region "Funciones"
        Public Function Listar() As Boolean
            If _entBienServicio.IdEmpresa <> "" Then
                _objADBienServicio.entBienServicio = _entBienServicio
                _objADBienServicio.Listar()
                _lstBienServicio = _objADBienServicio.lstBienServicio
                Return (_lstBienServicio.Count > 0)
            Else
                Return False
            End If
        End Function
#End Region
    End Class
End Namespace
