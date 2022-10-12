Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.CONFIG
Imports System.Data.SqlClient

Namespace CONFIG
    Public Class AD_PlanContable

#Region "Variables"
        Private _objConexion As AccesoDatos.AccesoDatosSQLServer
        Private _entPlanContable As EN_PlanContable
        Private _lstPlanesContables As List(Of EN_PlanContable)
        Private _objError As New Exception
#End Region
#Region "Propiedades"
        Public Property entPlanContable() As EN_PlanContable
            Get
                Return _entPlanContable
            End Get
            Set(ByVal value As EN_PlanContable)
                _entPlanContable = value
            End Set
        End Property
        Public ReadOnly Property lstPlanesContables() As List(Of EN_PlanContable)
            Get
                Return _lstPlanesContables
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
                _objConexion.Procedimiento = "ERP_usp_PlanContable_Registrar"

                _objConexion.AddParameter("var_IdEmpresa", _entPlanContable.IdEmpresa)
                _objConexion.AddParameter("var_IdContabilidad", _entPlanContable.IdContabilidad)
                _objConexion.AddParameter("var_IdPlanContable", _entPlanContable.IdPlanContable)
                _objConexion.AddParameter("var_Formato", _entPlanContable.Formato)
                _objConexion.AddParameter("int_LongitudNivel1", _entPlanContable.LongitudNivel1)
                _objConexion.AddParameter("int_longitudNivel2", _entPlanContable.LongitudNivel2)
                _objConexion.AddParameter("int_LongitudNivel3", _entPlanContable.LongitudNivel3)
                _objConexion.AddParameter("int_LongitudNivel4", _entPlanContable.LongitudNivel4)
                _objConexion.AddParameter("int_LongitudNivel5", _entPlanContable.LongitudNivel5)
                _objConexion.AddParameter("int_longitudNivel6", _entPlanContable.LongitudNivel6)
                _objConexion.AddParameter("int_LongitudNivel7", _entPlanContable.LongitudNivel7)
                _objConexion.AddParameter("int_LongitudNivel8", _entPlanContable.LongitudNivel8)
                _objConexion.AddParameter("var_Estado", _entPlanContable.Estado)

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
                _objConexion.Procedimiento = "ERP_usp_PlanContable_Listar"
                _objConexion.AddParameter("var_IdEmpresa", _entPlanContable.IdEmpresa)

                Dim odrDatos As SqlClient.SqlDataReader = _objConexion.ObtenerDataReader()
                _lstPlanesContables = New List(Of EN_PlanContable)

                While odrDatos.Read
                    _entPlanContable = New EN_PlanContable

                    _entPlanContable.IdPlanContable = odrDatos("var_IdPlanContable")
                    _entPlanContable.IdEmpresa = odrDatos("var_IdEmpresa")
                    _entPlanContable.IdEmpresa = odrDatos("var_RazonSocial")

                    _entPlanContable.IdContabilidad = odrDatos("var_IdContabilidad")
                    _entPlanContable.IdContabilidad = odrDatos("var_Descripcion")

                    _entPlanContable.Formato = odrDatos("var_Formato")
                    _entPlanContable.LongitudNivel1 = odrDatos("int_LongitudNivel1")
                    _entPlanContable.LongitudNivel2 = odrDatos("int_LongitudNivel2")
                    _entPlanContable.LongitudNivel3 = odrDatos("int_LongitudNivel3")
                    _entPlanContable.LongitudNivel4 = odrDatos("int_LongitudNivel4")
                    _entPlanContable.LongitudNivel5 = odrDatos("int_LongitudNivel5")
                    _entPlanContable.LongitudNivel6 = odrDatos("int_LongitudNivel6")
                    _entPlanContable.LongitudNivel7 = odrDatos("int_LongitudNivel7")
                    _entPlanContable.LongitudNivel8 = odrDatos("int_LongitudNivel8")
                    _entPlanContable.Estado = odrDatos("var_Estado")

                    _lstPlanesContables.Add(_entPlanContable)

                End While
                Return (_lstPlanesContables.Count > 0)

            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatos.AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_PlanContable_Eliminar"

                _objConexion.AddParameter("var_IdEmpresa", _entPlanContable.IdEmpresa)
                _objConexion.AddParameter("var_IdContabilidad", _entPlanContable.IdContabilidad)
                _objConexion.AddParameter("var_IdPlanContable", _entPlanContable.IdPlanContable)

                _objConexion.EjecutarComando()
                Return True
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function Buscar() As Boolean
            Try
                _objConexion = New AccesoDatos.AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_PlanContable_Buscar"
                _objConexion.AddParameter("var_IdEmpresa", _entPlanContable.IdEmpresa)
                _objConexion.AddParameter("var_Estado", _entPlanContable.Estado)

                Dim odrDatos As SqlClient.SqlDataReader = _objConexion.ObtenerDataReader()
                _lstPlanesContables = New List(Of EN_PlanContable)

                While odrDatos.Read
                    _entPlanContable = New EN_PlanContable

                    _entPlanContable.IdPlanContable = odrDatos("var_IdPlanContable")
                    _entPlanContable.IdEmpresa = odrDatos("var_IdEmpresa")
                    _entPlanContable.IdEmpresa = odrDatos("var_RazonSocial")

                    _entPlanContable.IdContabilidad = odrDatos("var_IdContabilidad")
                    _entPlanContable.IdContabilidad = odrDatos("var_Descripcion")

                    _entPlanContable.Formato = odrDatos("var_Formato")
                    _entPlanContable.LongitudNivel1 = odrDatos("int_LongitudNivel1")
                    _entPlanContable.LongitudNivel2 = odrDatos("int_LongitudNivel2")
                    _entPlanContable.LongitudNivel3 = odrDatos("int_LongitudNivel3")
                    _entPlanContable.LongitudNivel4 = odrDatos("int_LongitudNivel4")
                    _entPlanContable.LongitudNivel5 = odrDatos("int_LongitudNivel5")
                    _entPlanContable.LongitudNivel6 = odrDatos("int_LongitudNivel6")
                    _entPlanContable.LongitudNivel7 = odrDatos("int_LongitudNivel7")
                    _entPlanContable.LongitudNivel8 = odrDatos("int_LongitudNivel8")
                    _entPlanContable.Estado = odrDatos("var_Estado")

                    _lstPlanesContables.Add(_entPlanContable)

                End While
                Return (_lstPlanesContables.Count > 0)

            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace