
Imports EN_ALVINET_CONTA.CONFIG
Imports System.Data.SqlClient
Imports AD_ALVINET_CONTA.AccesoDatos

Namespace CONFIG

    Public Class AD_Contabilidad
        Inherits EN_Contabilidad

#Region "Variables"

        Private _lstContabilidades As List(Of EN_Contabilidad)
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As Exception
        Private _entContabilidad As New EN_Contabilidad

#End Region
#Region "Propiedades"

        Public ReadOnly Property lstContabilidades() As List(Of EN_Contabilidad)
            Get
                Return _lstContabilidades
            End Get
        End Property

        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property

        Public Property entContabilidad() As EN_Contabilidad
            Get
                Return _entContabilidad
            End Get
            Set(ByVal value As EN_Contabilidad)
                _entContabilidad = value
            End Set
        End Property
#End Region
#Region "Metodos y funciones"

        Sub New()
            _entContabilidad = New EN_Contabilidad
        End Sub

        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Contabilidad_Registrar"

                _objConexion.AddParameter("var_IdEmpresa", _entContabilidad.IdEmpresa)
                _objConexion.AddParameter("var_IdContabilidad", _entContabilidad.IdContabilidad)
                _objConexion.AddParameter("var_Descripcion", _entContabilidad.Contabilidad)
                _objConexion.AddParameter("var_Estado", _entContabilidad.Estado)
                _objConexion.AddParameter("var_IdMoneda", _entContabilidad.IdMoneda)
                _objConexion.AddParameter("var_CuentaGanaciaCambio", _entContabilidad.CuentaGananciaCambio)
                _objConexion.AddParameter("var_CuentaPerdidaCambio", _entContabilidad.CuentaPerdidaCambio)

                _objConexion.EjecutarComando()

                Return True

            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function Buscar() As Boolean

            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Contabilidad_Buscar"
                _objConexion.AddParameter("var_IdEmpresa", _entContabilidad.IdEmpresa)
                _objConexion.AddParameter("var_Estado", _entContabilidad.Estado)
                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstContabilidades = New List(Of EN_Contabilidad)

                While odrDatos.Read
                    _entContabilidad = New EN_Contabilidad

                    _entContabilidad.IdContabilidad = odrDatos("var_IdContabilidad")

                    _entContabilidad.IdEmpresa = odrDatos("var_IdEmpresa")
                    _entContabilidad.IdEmpresa = odrDatos("var_RazonSocial")

                    entContabilidad.IdMoneda = odrDatos("var_IdMoneda")
                    _entContabilidad.IdMoneda = odrDatos("var_Moneda")

                    _entContabilidad.Contabilidad = odrDatos("var_Descripcion")

                    _entContabilidad.CuentaGananciaCambio = odrDatos("var_CuentaGanaciaCambio")
                    _entContabilidad.CuentaPerdidaCambio = odrDatos("var_CuentaPerdidaCambio")
                    _entContabilidad.Estado = odrDatos("var_Estado")

                    _lstContabilidades.Add(_entContabilidad)
                End While

                Return (_lstContabilidades.Count > 0)

            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function Eliminar() As Boolean

            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Contabilidad_Eliminar"

                _objConexion.AddParameter("var_IdEmpresa", _entContabilidad.IdEmpresa)
                _objConexion.AddParameter("var_IdContabilidad", _entContabilidad.IdContabilidad)
                _objConexion.EjecutarComando()

                Return True

            Catch ex As Exception

                _objError = ex
                Return False

            End Try

        End Function

        Public Function Listar() As Boolean

            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Contabilidad_Listar"
                _objConexion.AddParameter("var_IdEmpresa", entContabilidad.IdEmpresa)

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstContabilidades = New List(Of EN_Contabilidad)

                While odrDatos.Read
                    _entContabilidad = New EN_Contabilidad

                    _entContabilidad.IdContabilidad = odrDatos("var_IdContabilidad")

                    _entContabilidad.IdEmpresa = odrDatos("var_IdEmpresa")
                    _entContabilidad.IdEmpresa = odrDatos("var_RazonSocial")

                    entContabilidad.IdMoneda = odrDatos("var_IdMoneda")
                    _entContabilidad.IdMoneda = odrDatos("var_Moneda")

                    _entContabilidad.Contabilidad = odrDatos("var_Descripcion")

                    _entContabilidad.CuentaGananciaCambio = odrDatos("var_CuentaGanaciaCambio")
                    _entContabilidad.CuentaPerdidaCambio = odrDatos("var_CuentaPerdidaCambio")
                    _entContabilidad.Estado = odrDatos("var_Estado")

                    _lstContabilidades.Add(_entContabilidad)
                End While

                Return (_lstContabilidades.Count > 0)

            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function ListarXEmpresa() As List(Of EN_ALVINET_CONTA.CONFIG.EN_Ejercicio)

            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Conta_Empresa"
                _objConexion.AddParameter("var_IdEmpresa", _entContabilidad.IdEmpresa)

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                Dim lstContabilidades As New List(Of EN_ALVINET_CONTA.CONFIG.EN_Ejercicio)

                While odrDatos.Read
                    Dim entContabilidad = New EN_ALVINET_CONTA.CONFIG.EN_Ejercicio

                    entContabilidad.IdEmpresa = odrDatos("var_IdEmpresa")
                    entContabilidad.IdContabilidad = odrDatos("var_IdContabilidad")
                    entContabilidad.Contabilidad = odrDatos("var_Descripcion")
                    entContabilidad.IdEjercicio = odrDatos("var_IdEjercicioEmpresa")
                    entContabilidad.Ejercicio = odrDatos("var_DescripcionEjer")
                    entContabilidad.IdPlanContable = odrDatos("var_IdPlanContable")
                    lstContabilidades.Add(entContabilidad)
                End While
                Return lstContabilidades
            Catch ex As Exception
                _objError = ex
                Return Nothing
            End Try
        End Function

#End Region

    End Class
End Namespace