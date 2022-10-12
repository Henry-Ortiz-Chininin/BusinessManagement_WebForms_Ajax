Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.GENERAL
Imports EN_ALVINET_CONTA
Imports System.Data
Imports System.Data.SqlClient
Imports UTIL_ALVINET_CONTA.General
Namespace GENERAL

    Public Class AD_Empleado
#Region "Variable"
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstEmpleado As List(Of EN_Empleado)
        Private _entEmpleado As New EN_Empleado
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstCliente As List(Of EN_Empleado)
            Get
                Return _lstEmpleado
            End Get
        End Property

        Public Property entCliente As EN_Empleado
            Get
                Return _entEmpleado
            End Get
            Set(ByVal Value As EN_Empleado)
                _entEmpleado = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"

        Public Function Listar() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Empleado_Listar"
                _objConexion.AddParameter("var_IdEmpresa", _entEmpleado.IdEmpresa)
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstEmpleado = New List(Of EN_Empleado)
                While odrDatos.Read
                    _entEmpleado = New EN_Empleado

                    _entEmpleado.IdEmpleado = odrDatos("var_IdEmpleado")
                    _entEmpleado.Nombre = odrDatos("var_Nombre")
                    _lstEmpleado.Add(_entEmpleado)
                End While

                Return (_lstEmpleado.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function


#End Region
    End Class
End Namespace