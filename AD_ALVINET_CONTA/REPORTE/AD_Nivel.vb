Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.OPERACION
Imports EN_ALVINET_CONTA.CONFIG
Imports System.Data.SqlClient

Namespace REPORTE
    Public Class AD_Nivel
#Region "Variable"
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Dim _lstNivel As List(Of EN_NivelPlan)
        Dim _entNivel As EN_NivelPlan
#End Region
#Region "Propiedades"
        Public Property objError() As Exception
            Get
                Return _objError
            End Get
            Set(ByVal value As Exception)
                _objError = value
            End Set
        End Property

        Public Property lstNivel() As List(Of EN_NivelPlan)
            Get
                Return _lstNivel
            End Get
            Set(ByVal value As List(Of EN_NivelPlan))
                _lstNivel = value
            End Set
        End Property

        Public Property entNivel() As EN_NivelPlan
            Get
                Return _entNivel
            End Get
            Set(ByVal value As EN_NivelPlan)
                _entNivel = value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"
        Public Function ListarNivel() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim dr As SqlDataReader = _objConexion.ObtenerDataReader("[dbo].[ERP_usp_Lista_Nivel]")
                _lstNivel = New List(Of EN_NivelPlan)
                While dr.Read
                    _entNivel = New EN_NivelPlan
                    _entNivel.IdNivel = dr("var_IdNivel")
                    _entNivel.Descripcion = dr("var_Descripcion")
                    _entNivel.Nombre = dr("Nombre")
                    _entNivel.ID = dr("Id")
                    _lstNivel.Add(_entNivel)
                End While
                Return (_lstNivel.Count > 0)
                Return True

            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace