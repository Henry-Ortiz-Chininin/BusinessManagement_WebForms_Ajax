Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.GENERAL
Imports System.Data
Imports System.Data.SqlClient
Imports EN_ALVINET_CONTA.OPERACION

Namespace GENERAL
    Public Class AD_MedioPago


#Region "Variables"
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstMedioPagos As List(Of EN_MedioPago)
        Private _entMedioPago As New EN_MedioPago
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstMedioPagos As List(Of EN_MedioPago)
            Get
                Return _lstMedioPagos
            End Get
        End Property

        Public Property entMedioPago As EN_MedioPago
            Get
                Return _entMedioPago
            End Get
            Set(ByVal Value As EN_MedioPago)
                _entMedioPago = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"
        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_MedioPago_Registrar"

                _objConexion.AddParameter("var_idEmpresa", _entMedioPago.IdEmpresa)
                _objConexion.AddParameter("var_IdMedioPago", _entMedioPago.IdMedioPago)
                _objConexion.AddParameter("var_Descripcion", _entMedioPago.MedioPago)
                _objConexion.AddParameter("var_CodigoSunat", _entMedioPago.CodigoSunat)
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

                _objConexion.Procedimiento = "ERP_usp_MedioPago_Eliminar"
                _objConexion.AddParameter("var_idEmpresa", _entMedioPago.IdEmpresa)
                _objConexion.AddParameter("var_IdMedioPago", _entMedioPago.IdMedioPago)
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
                _objConexion.Procedimiento = "ERP_usp_MedioPago_Listar"

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstMedioPagos = New List(Of EN_MedioPago)

                While odrDatos.Read

                    _entMedioPago = New EN_MedioPago

                    _entMedioPago.IdMedioPago = odrDatos("var_IdMedioPago")
                    _entMedioPago.IdEmpresa = odrDatos("var_idEmpresa")
                    _entMedioPago.RazonSocial = odrDatos("var_RazonSocial")
                    _entMedioPago.MedioPago = odrDatos("var_Descripcion")
                    _entMedioPago.CodigoSunat = odrDatos("var_CodigoSUNAT")
                    _lstMedioPagos.Add(_entMedioPago)

                End While

                Return (_lstMedioPagos.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace