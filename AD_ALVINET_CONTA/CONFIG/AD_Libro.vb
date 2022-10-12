Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA
Imports System.Data
Imports System.Data.SqlClient
Public Class AD_Libro
#Region "Variable"
    Private _objConexion As AccesoDatosSQLServer
    Private _objError As New Exception
    Private _lstLibros As List(Of EN_Libro)
    Private _entLibro As New EN_Libro
#End Region

#Region "Propiedades"
    Public ReadOnly Property objError As Exception
        Get
            Return _objError
        End Get
    End Property

    Public ReadOnly Property lstLibros As List(Of EN_Libro)
        Get
            Return _lstLibros
        End Get
    End Property

    Public Property entLibro As EN_Libro
        Get
            Return _entLibro
        End Get
        Set(ByVal Value As EN_Libro)
            _entLibro = Value
        End Set
    End Property
#End Region

#Region "Metodos y Funciones"
    Public Function Registrar() As Boolean
        Try
            _objConexion = New AccesoDatosSQLServer
            _objConexion.Procedimiento = "ERP_usp_Libro_Registrar"
            _objConexion.AddParameter("var_IdSunat", _entLibro.IdSunat)
            _objConexion.AddParameter("var_IdLibro", _entLibro.IdLibro)
            _objConexion.AddParameter("var_Descripcion", _entLibro.Descripcion)
            _objConexion.AddParameter("var_Estado", _entLibro.Estado)
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
            _objConexion.Procedimiento = "ERP_usp_Libro_Eliminar"
            _objConexion.AddParameter("var_IdSunat", _entLibro.IdSunat)
            _objConexion.AddParameter("var_IdLibro", _entLibro.IdLibro)
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
            _objConexion.Procedimiento = "ERP_usp_Libro_Listar"

            Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

            _lstLibros = New List(Of EN_Libro)

            While odrDatos.Read

                _entLibro = New EN_Libro
                _entLibro.IdSunat = odrDatos("var_IdSunat")
                _entLibro.IdLibro = odrDatos("var_IdLibro")
                _entLibro.Descripcion = odrDatos("var_Descripcion")
                _entLibro.Estado = odrDatos("var_Estado")

                _lstLibros.Add(_entLibro)
            End While

            Return (_lstLibros.Count > 0)
        Catch ex As Exception
            _objError = ex
            Return False
        End Try
    End Function
#End Region
End Class
