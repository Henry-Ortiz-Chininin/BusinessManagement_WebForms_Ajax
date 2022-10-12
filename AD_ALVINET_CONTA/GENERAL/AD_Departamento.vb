Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.GENERAL
Imports EN_ALVINET_CONTA
Imports System.Data.SqlClient


Namespace GENERAL
    Public Class AD_Departamento
#Region "Variables"
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _entDepartamento As EN_Departamento
        Private _lstDepartamento As List(Of EN_Departamento)

#End Region
#Region "Propiedades"
        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
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
            Set(value As EN_Departamento)
                _entDepartamento = value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"
        Public Function Lista() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Departamento_Lista"
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader
                _lstDepartamento = New List(Of EN_Departamento)
                If Not odrDatos Is Nothing Then
                    While odrDatos.Read
                        _entDepartamento = New EN_Departamento
                        _entDepartamento.IdDepartamento = odrDatos("int_IdDepartamento")
                        _entDepartamento.NomDepartamento = odrDatos("var_Descripcion")
                        _lstDepartamento.Add(_entDepartamento)
                    End While
                End If
                Return (_lstDepartamento.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace

