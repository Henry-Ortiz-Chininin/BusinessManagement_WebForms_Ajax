Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.CONFIG
Imports System.Data.SqlClient

Namespace CONFIG

    Public Class AD_NivelPlan
#Region "Variables"
        Private _objConexion As AccesoDatos.AccesoDatosSQLServer
        Private _entNivelPlan As EN_NivelPlan
        Private _lstNivelPlan As List(Of EN_NivelPlan)
        Private _objError As New Exception
#End Region
#Region "Propiedades"
        Public Property entNivelPlan() As EN_NivelPlan
            Get
                Return _entNivelPlan
            End Get
            Set(ByVal value As EN_NivelPlan)
                _entNivelPlan = value
            End Set
        End Property
        Public ReadOnly Property lstNivelPlan() As List(Of EN_NivelPlan)
            Get
                Return _lstNivelPlan
            End Get
        End Property

        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property
#End Region
#Region "Metodos y Funciones "

        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatos.AccesoDatosSQLServer

                _objConexion.Procedimiento = "ERP_usp_NivelPlan_Registrar"
                _objConexion.AddParameter("var_IdEmpresa", _entNivelPlan.IdEmpresa)
                _objConexion.AddParameter("var_IdNivel", _entNivelPlan.IdNivel)
                _objConexion.AddParameter("var_Descripcion", _entNivelPlan.Descripcion)

                _objConexion.EjecutarComando()
                Return True
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function

        Public Function Listar() As Boolean
            Try
                _objConexion = New AccesoDatos.AccesoDatosSQLServer

                _objConexion.Procedimiento = "RP_usp_NivelPlan_Listar"
                '_objConexion.AddParameter("var_IdEmpresa", _entNivelPlan.IdEmpresa)

                Dim odrDatos As SqlClient.SqlDataReader = _objConexion.ObtenerDataReader()

                _lstNivelPlan = New List(Of EN_NivelPlan)

                While odrDatos.Read
                    _entNivelPlan = New EN_NivelPlan
                    _entNivelPlan.RazonSocial = odrDatos("var_RazonSocial")
                    _entNivelPlan.IdEmpresa = odrDatos("var_IdEmpresa")
                    _entNivelPlan.IdNivel = odrDatos("var_IdNivel")
                    _entNivelPlan.Descripcion = odrDatos("var_Descripcion")
                    _lstNivelPlan.Add(_entNivelPlan)
                End While

                Return (_lstNivelPlan.Count > 0)

            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatos.AccesoDatosSQLServer
                _objConexion.Procedimiento = "RP_usp_NivelPlan_Eliminar"

                _objConexion.AddParameter("var_IdNivel", _entNivelPlan.IdNivel)
                _objConexion.AddParameter("var_IdEmpresa", _entNivelPlan.IdEmpresa)

                _objConexion.EjecutarComando()

                Return True

            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function

#End Region

    End Class
End Namespace