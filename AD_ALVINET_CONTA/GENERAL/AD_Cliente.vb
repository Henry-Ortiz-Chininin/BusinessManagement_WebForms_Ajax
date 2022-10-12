Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.GENERAL
Imports System.Data
Imports System.Data.SqlClient

Namespace GENERAL

    Public Class AD_Cliente
#Region "Variable"
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstCliente As List(Of EN_Cliente)
        Private _entCliente As New EN_Cliente
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstCliente As List(Of EN_Cliente)
            Get
                Return _lstCliente
            End Get
        End Property

        Public Property entCliente As EN_Cliente
            Get
                Return _entCliente
            End Get
            Set(ByVal Value As EN_Cliente)
                _entCliente = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"
        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Cliente_Registrar"
                _objConexion.AddParameter("var_IdEmpresa", _entCliente.IdEmpresa)
                _objConexion.AddParameter("var_IdCliente", _entCliente.IdCliente)
                _objConexion.AddParameter("var_Descripcion", _entCliente.Descripcion)
                _objConexion.AddParameter("var_Direccion", _entCliente.Direccion)
                _objConexion.AddParameter("chr_Mercado", _entCliente.Mercado)
                _objConexion.AddParameter("chr_Estado", _entCliente.Estado)
                _objConexion.AddParameter("var_Telefono", _entCliente.Telefono)
                _objConexion.AddParameter("var_PersonaContacto", _entCliente.PersonaContacto)
                _objConexion.AddParameter("var_TelefonoPersonaContacto", _entCliente.TelefonoPersonaContacto)

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
                _objConexion.Procedimiento = "ERP_usp_Cliente_Eliminar"
                _objConexion.AddParameter("var_IdEmpresa", _entCliente.IdEmpresa)
                _objConexion.AddParameter("var_IdCliente", _entCliente.IdCliente)

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
                _objConexion.Procedimiento = "ERP_usp_Cliente_Listar"
                _objConexion.AddParameter("var_IdEmpresa", _entCliente.IdEmpresa)
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstCliente = New List(Of EN_Cliente)
                While odrDatos.Read
                    _entCliente = New EN_Cliente

                    _entCliente.IdEmpresa = odrDatos("var_IdEmpresa")
                    _entCliente.IdCliente = odrDatos("var_IdCliente")
                    _entCliente.Descripcion = odrDatos("var_Descripcion")
                    _entCliente.Direccion = odrDatos("var_Direccion")
                    _entCliente.Mercado = odrDatos("chr_Mercado")
                    _entCliente.Estado = odrDatos("chr_Estado")
                    _entCliente.FechaCreacion = odrDatos("dtm_FechaCreacion")
                    _entCliente.Telefono = odrDatos("var_Telefono")
                    _entCliente.PersonaContacto = odrDatos("var_PersonaContacto")
                    _entCliente.TelefonoPersonaContacto = odrDatos("var_TelefonoPersonaContacto")

                    _lstCliente.Add(_entCliente)
                End While

                Return (_lstCliente.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Cliente_Obtener"
                _objConexion.AddParameter("var_IdCliente", _entCliente.IdCliente)
                _objConexion.AddParameter("var_Descripcion", _entCliente.Descripcion)
                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstCliente = New List(Of EN_Cliente)
                While odrDatos.Read
                    _entCliente = New EN_Cliente

                    _entCliente.IdEmpresa = odrDatos("var_IdEmpresa")
                    _entCliente.IdCliente = odrDatos("var_IdCliente")
                    _entCliente.Descripcion = odrDatos("var_Descripcion")
                    _entCliente.Direccion = odrDatos("var_Direccion")
                    _entCliente.Mercado = odrDatos("chr_Mercado")
                    _entCliente.Estado = odrDatos("chr_Estado")
                    _entCliente.FechaCreacion = odrDatos("dtm_FechaCreacion")
                    _entCliente.Telefono = odrDatos("var_Telefono")
                    _entCliente.PersonaContacto = odrDatos("var_PersonaContacto")
                    _entCliente.TelefonoPersonaContacto = odrDatos("var_TelefonoPersonaContacto")

                    _lstCliente.Add(_entCliente)
                End While

                Return (_lstCliente.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace