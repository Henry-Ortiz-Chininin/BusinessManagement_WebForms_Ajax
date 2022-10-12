
Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.GENERAL
Imports System.Data
Imports System.Data.SqlClient

Namespace GENERAL

    Public Class AD_CentroCosto
#Region "Variables"
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstCentroCostos As List(Of EN_CentroCosto)
        Private _entCentroCosto As New EN_CentroCosto
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstCentroCostos As List(Of EN_CentroCosto)
            Get
                Return _lstCentroCostos
            End Get
        End Property

        Public Property entCentroCosto As EN_CentroCosto
            Get
                Return _entCentroCosto
            End Get
            Set(ByVal Value As EN_CentroCosto)
                _entCentroCosto = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"

        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_CentroCosto_Registrar"

                _objConexion.AddParameter("var_IdEmpresa", _entCentroCosto.IdEmpresa)
                _objConexion.AddParameter("var_IdCentrocosto", _entCentroCosto.IdCentroCosto)
                _objConexion.AddParameter("var_Descripcion", _entCentroCosto.CentroCosto)
                _objConexion.AddParameter("var_CodigoInductor", _entCentroCosto.CodigoInductor)
                _objConexion.AddParameter("var_IdCentroCostoPadre", _entCentroCosto.IdCentroCostoPadre)
                _objConexion.AddParameter("int_Nivel", _entCentroCosto.Nivel)
                _objConexion.EjecutarComando()


                Return True
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function



        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_CentroCosto_Eliminar"
                _objConexion.AddParameter("var_idEmpresa", _entCentroCosto.IdEmpresa)
                _objConexion.AddParameter("var_IdCentrocosto", _entCentroCosto.IdCentroCosto)
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
                _objConexion.Procedimiento = "ERP_usp_CentroCosto_Listar"
                _objConexion.AddParameter("var_IdEmpresa", _entCentroCosto.IdEmpresa)

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstCentroCostos = New List(Of EN_CentroCosto)

                While odrDatos.Read

                    _entCentroCosto = New EN_CentroCosto

                    _entCentroCosto.IdCentroCosto = odrDatos("var_IdCentrocosto")
                    _entCentroCosto.IdEmpresa = odrDatos("var_idEmpresa")
                    _entCentroCosto.RazonSocial = odrDatos("var_RazonSocial")
                    _entCentroCosto.CentroCosto = odrDatos("var_Descripcion")
                    _entCentroCosto.CodigoInductor = odrDatos("var_CodigoInductor")
                    _entCentroCosto.IdCentroCostoPadre = odrDatos("var_IdCentroCostoPadre")
                    _entCentroCosto.Nivel = odrDatos("int_Nivel")

                    _lstCentroCostos.Add(_entCentroCosto)
                End While

                Return (_lstCentroCostos.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function Obtener() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_CentroCosto_Obtener"
                _objConexion.AddParameter("var_IdCentrocosto", _entCentroCosto.IdCentroCosto)
                _objConexion.AddParameter("var_Descripcion", _entCentroCosto.CentroCosto)
                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstCentroCostos = New List(Of EN_CentroCosto)

                While odrDatos.Read

                    _entCentroCosto = New EN_CentroCosto

                    _entCentroCosto.IdCentroCosto = odrDatos("var_IdCentroCosto")
                    _entCentroCosto.IdEmpresa = odrDatos("var_IdEmpresa")
                    _entCentroCosto.CentroCosto = odrDatos("var_Descripcion")
                    _entCentroCosto.CodigoInductor = odrDatos("var_CodigoInductor")
                    _entCentroCosto.IdCentroCostoPadre = odrDatos("var_IdCentroCostoPadre")
                    _entCentroCosto.Nivel = odrDatos("int_Nivel")

                    _lstCentroCostos.Add(_entCentroCosto)
                End While

                Return (_lstCentroCostos.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace