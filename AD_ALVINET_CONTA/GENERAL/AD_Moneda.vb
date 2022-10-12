
Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.GENERAL
Imports System.Data
Imports System.Data.SqlClient

Namespace GENERAL

    Public Class AD_Moneda
#Region "Variable"
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstMonedas As List(Of EN_Moneda)
        Private _entMoneda As New EN_Moneda
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstMonedas As List(Of EN_Moneda)
            Get
                Return _lstMonedas
            End Get
        End Property

        Public Property entMoneda As EN_Moneda
            Get
                Return _entMoneda
            End Get
            Set(ByVal Value As EN_Moneda)
                _entMoneda = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"
        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Moneda_Registrar"
                _objConexion.AddParameter("var_IdEmpresa", _entMoneda.IdEmpresa)
                _objConexion.AddParameter("var_IdMoneda", _entMoneda.IdMoneda)
                _objConexion.AddParameter("var_Descripcion", _entMoneda.Moneda)
                _objConexion.AddParameter("var_Simbolo", _entMoneda.Simbolo)
                _objConexion.AddParameter("var_IdSunat", _entMoneda.IdSunat)
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
                _objConexion.Procedimiento = "ERP_usp_Moneda_Eliminar"
                _objConexion.AddParameter("var_IdEmpresa", _entMoneda.IdEmpresa)
                _objConexion.AddParameter("var_IdMoneda", _entMoneda.IdMoneda)
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
                _objConexion.Procedimiento = "[ERP_usp_Moneda_Buscar]"
                _objConexion.AddParameter("var_IdEmpresa", _entMoneda.IdEmpresa)
                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstMonedas = New List(Of EN_Moneda)

                While odrDatos.Read

                    _entMoneda = New EN_Moneda
                    _entMoneda.IdMoneda = odrDatos("var_IdMoneda")
                    _entMoneda.IdEmpresa = odrDatos("var_idEmpresa")
                    _entMoneda.Moneda = odrDatos("var_Descripcion")
                    _entMoneda.Simbolo = odrDatos("var_Simbolo")

                    _lstMonedas.Add(_entMoneda)
                End While

                Return (_lstMonedas.Count > 0)

            Catch ex As Exception
                _objError = ex

                Return False
            End Try
        End Function
        Public Function Listar() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "[dbo].[ERP_usp_Moneda_Listar]"
                _objConexion.AddParameter("var_IdEmpresa", _entMoneda.IdEmpresa)
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstMonedas = New List(Of EN_Moneda)

                While odrDatos.Read

                    _entMoneda = New EN_Moneda
                    _entMoneda.IdMoneda = odrDatos("var_IdMoneda")
                    _entMoneda.IdEmpresa = odrDatos("var_idEmpresa")
                    _entMoneda.RazonSocial = odrDatos("var_RazonSocial")
                    _entMoneda.Moneda = odrDatos("var_Descripcion")
                    _entMoneda.Simbolo = odrDatos("var_Simbolo")
                    _entMoneda.IdSunat = odrDatos("var_IdSunat")

                    _lstMonedas.Add(_entMoneda)
                End While

                Return (_lstMonedas.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace


