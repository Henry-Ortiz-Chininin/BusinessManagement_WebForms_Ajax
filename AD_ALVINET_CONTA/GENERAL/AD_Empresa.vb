
Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.GENERAL
Imports System.Data
Imports System.Data.SqlClient

Namespace GENERAL

    Public Class AD_Empresa
#Region "Variables"
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstEmpresas As List(Of EN_Empresa)
        Private _entEmpresa As New EN_Empresa
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstEmpresas As List(Of EN_Empresa)
            Get
                Return _lstEmpresas
            End Get
        End Property

        Public Property entEmpresa As EN_Empresa
            Get
                Return _entEmpresa
            End Get
            Set(ByVal Value As EN_Empresa)
                _entEmpresa = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"
        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Empresa_Registrar"
                _objConexion.AddParameter("var_idEmpresa", _entEmpresa.IdEmpresa)
                _objConexion.AddParameter("chr_Ruc", _entEmpresa.Ruc)
                _objConexion.AddParameter("var_RazonSocial", _entEmpresa.RazonSocial)
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
                _objConexion.Procedimiento = "ERP_usp_Empresa_Eliminar"
                _objConexion.AddParameter("var_idEmpresa", _entEmpresa.IdEmpresa)
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

                _objConexion.Procedimiento = "ERP_usp_Empresa_Listar"
                _objConexion.AddParameter("var_IdUsuario", _entEmpresa.IdUsuario)

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstEmpresas = New List(Of EN_Empresa)

                While odrDatos.Read
                    _entEmpresa = New EN_Empresa

                    _entEmpresa.IdEmpresa = odrDatos("var_idEmpresa")
                    _entEmpresa.Ruc = odrDatos("chr_Ruc")
                    _entEmpresa.RazonSocial = odrDatos("var_RazonSocial")
                    _entEmpresa.IdUsuario = odrDatos("var_IdUsuario")
                    _lstEmpresas.Add(_entEmpresa)
                End While

                Return (_lstEmpresas.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function ListaInterno(ByVal idEmpresa As String, ByVal nomEmpresa As String) As Boolean
            Try
                _lstEmpresas = New List(Of EN_Empresa)
                _entEmpresa = New EN_Empresa
                If idEmpresa <> "" AndAlso nomEmpresa <> "" Then

                    _entEmpresa.IdEmpresa = idEmpresa
                    _entEmpresa.RazonSocial = nomEmpresa
                    _lstEmpresas.Add(_entEmpresa)

                End If



                Return (_lstEmpresas.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function


        Public Function CerrarCompras(ByVal pstr_IdEjercicio As String, ByVal pstr_IdMes As String) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_CierreCompras_Registrar"
                _objConexion.AddParameter("var_IdEjercicioEmpresa", pstr_IdEjercicio)
                _objConexion.AddParameter("var_IdEjercicioMes", pstr_IdMes)
                _objConexion.EjecutarComando()
                Return True
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function CerrarVentas(ByVal pstr_IdEjercicio As String, ByVal pstr_IdMes As String) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_CierreVentas_Registrar"
                _objConexion.AddParameter("var_IdEjercicioEmpresa", pstr_IdEjercicio)
                _objConexion.AddParameter("var_IdEjercicioMes", pstr_IdMes)
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