Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports AccesoDatos

Public Class clsPerfil

#Region "VARIABLES"
    Private _objConexion As AccesoDatos.AccesoDatosSQLServer
    ' AccesoDatosVBSQLServer
    Private _intIDPerfil As Integer
    Private _strNombre As String
    Private _intIDLocal As Integer
    Private _strEstado As String
    Private _strUsuario As String
    Private _objPerfilUsuario As clsPerfilUsuario
    Private _exError As Exception
#End Region

#Region "Propiedades"
    Public Property IDPerfil() As Integer
        Get
            Return _intIDPerfil
        End Get
        Set(ByVal value As Integer)
            _intIDPerfil = value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return _strNombre
        End Get
        Set(ByVal value As String)
            _strNombre = value
        End Set
    End Property
    Public Property IDLocal() As Integer
        Get
            Return _intIDLocal
        End Get
        Set(ByVal value As Integer)
            _intIDLocal = value
        End Set
    End Property
    Public ReadOnly Property Estado() As String
        Get
            Return _strEstado
        End Get
    End Property
    Public Property Usuario() As String
        Get
            Return _strUsuario
        End Get
        Set(ByVal value As String)
            _strUsuario = value
        End Set
    End Property
    Public ReadOnly Property PerfilUsuario() As clsPerfilUsuario
        Get
            Return _objPerfilUsuario
        End Get
    End Property
    Public ReadOnly Property exError() As String
        Get
            Return _exError.ToString
        End Get
    End Property

#End Region

#Region "Constructores"
    Sub New()
        _intIDPerfil = 0
        _intIDLocal = 0
        _strEstado = ""
        _strUsuario = ""
    End Sub
    Sub New(ByVal pintIDPerfil As Integer)
        Obtener(pintIDPerfil)
    End Sub
#End Region

#Region "METODOS Y FUNCIONES"
    Public Function Agregar() As Boolean
        Try
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            Dim objParametros() As String = {"var_NombrePerfil", _strNombre, "var_Usuario", _strUsuario}
            _objConexion.EjecutarComando("SGC_usp_Perfil_Agregar", objParametros)
            Return True
        Catch ex As Exception
            Me._exError = ex
            Return False
        End Try
    End Function

    Public Function Actualizar() As Boolean
        Try
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            Dim objParametros() As String = {"int_IDPerfil", _intIDPerfil, "var_NombrePerfil", _strNombre, "var_Usuario", _strUsuario}
            _objConexion.EjecutarComando("SGC_usp_Perfil_Actualizar", objParametros)

            Return True
        Catch ex As Exception
            Me._exError = ex
            Return False
        End Try
    End Function

    Public Function CambiarEstado(ByVal pstrEstado As String) As Boolean
        Try
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            Dim objParametros() As String = {"int_IDPerfil", _intIDPerfil, "chr_Estado", pstrEstado, "var_Usuario", _strUsuario}
            _objConexion.EjecutarComando("SGC_usp_Perfil_Estado", objParametros)

            Return True
        Catch ex As Exception
            Me._exError = ex
            Return False
        End Try
    End Function

    Public Function Obtener(ByVal pintIDPerfil As Integer) As Boolean
        Try
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            Dim objParametros() As String = {"int_IDPerfil", pintIDPerfil}
            Dim dtbDatos As Data.DataTable = _objConexion.ObtenerDataTable("SGC_usp_Perfil_Obtener", objParametros)

            If dtbDatos.Rows.Count > 0 Then
                Me._strEstado = dtbDatos.Rows(0)("chr_Estado")
                Me._strNombre = dtbDatos.Rows(0)("var_NombrePerfil")
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Me._exError = ex
            Return False
        End Try
    End Function

    Public Function Listar() As Data.DataTable
        Try
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            Dim dtbDatos As Data.DataTable = _objConexion.ObtenerDataTable("SGC_usp_Perfil_Listar")

            Return dtbDatos
        Catch ex As Exception
            Me._exError = ex
            Return Nothing
        End Try
    End Function

#End Region


End Class
