Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports AccesoDatos

Public Class clsUsuario

#Region "VARIABLES"
    Private _objConexion As AccesoDatos.AccesoDatosSQLServer
    '  AccesoDatosAccesoDatosVBSQLServer
    Private _strIdUsuario As String
    Private _strNombre As String
    Private _strClave As String
    Private _strEstado As String
    Private _strUsuario As String
    Private _dtbDatos As Data.DataTable
    Private _exError As Exception
#End Region

#Region "Propiedades"
    Public Property IDUsuario() As String
        Get
            Return _strIDUsuario
        End Get
        Set(ByVal value As String)
            _strIDUsuario = value
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
    Public Property Clave() As String
        Get
            Return _strClave
        End Get
        Set(ByVal value As String)
            _strClave = value
        End Set
    End Property

    Public Property Estado() As String
        Get
            Return _strEstado
        End Get
        Set(ByVal value As String)
            _strEstado = value
        End Set
    End Property
    Public Property Usuario() As String
        Get
            Return _strUsuario
        End Get
        Set(ByVal value As String)
            _strUsuario = value
        End Set
    End Property
    Public ReadOnly Property Datos() As Data.DataTable
        Get
            Return _dtbDatos
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
        _strIDUsuario = ""
        _strClave = ""
        _strEstado = ""
        _strUsuario = ""
    End Sub
#End Region

#Region "METODOS Y FUNCIONES"
    Public Function Agregar() As Boolean
        Try
            Dim objShadow As New Shadow.BlitzLock
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            Dim objParametros() As String = {"var_IDUsuario", _strIDUsuario, "var_Clave", objShadow.Encripta(_strClave), _
                                                "var_Nombre", _strNombre, "chr_Estado", _strEstado, _
                                                "var_Usuario", _strUsuario}
            _objConexion.EjecutarComando("SGC_usp_Usuario_Crear", objParametros)
            Return True
        Catch ex As Exception
            Me._exError = ex
            Return False
        End Try
    End Function

    Public Function Actualizar() As Boolean
        Try
            Dim objShadow As New Shadow.BlitzLock
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            Dim objParametros() As String = {"var_IDUsuario", _strIdUsuario, "var_Clave", objShadow.Encripta(_strClave), _
                                                "var_Nombre", _strNombre, "chr_Estado", _strEstado, _
                                                "var_Usuario", _strUsuario}
            _objConexion.EjecutarComando("SGC_usp_Usuario_Actualizar", objParametros)
            Return True
        Catch ex As Exception
            Me._exError = ex
            Return False
        End Try
    End Function

    Public Function CambiarEstado(ByVal pstrEstado As String) As Boolean
        Try
            Dim objParametros() As String = {"var_IDUsuario", _strIdUsuario, "chr_Estado", _strEstado}
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            _objConexion.EjecutarComando("SGC_usp_Usuario_ActualizarEstado", objParametros)
            Return True
        Catch ex As Exception
            Me._exError = ex
            Return False
        End Try
    End Function

    Public Function CambiarContrasena() As Boolean
        Try
            Dim objShadow As New Shadow.BlitzLock
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            Dim objParametros() As String = {"var_IDUsuario", _strIdUsuario, "var_Clave", objShadow.Encripta(_strClave)}
            _objConexion.EjecutarComando("SGC_usp_Usuario_ActualizarContrasena", objParametros)
            Return True
        Catch ex As Exception
            Me._exError = ex
            Return False
        End Try
    End Function

    Public Function Listar() As Boolean
        Try
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Usuario_Listar")
            Return True
        Catch ex As Exception
            Me._exError = ex
            Return False
        End Try
    End Function

    Public Function Obtener(ByVal pstrIDUsuario As String) As Boolean
        Try
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            Dim objParametros() As String = {"var_IDUsuario", _strIdUsuario}
            Dim dtbDatos As Data.DataTable = _objConexion.ObtenerDataTable("SGC_usp_Usuario_Obtener", objParametros)
            If dtbDatos.Rows.Count > 0 Then
                Me._strEstado = dtbDatos.Rows(0)("chr_Estado")
                Me._strNombre = dtbDatos.Rows(0)("var_Nombre")
                Me._strClave = dtbDatos.Rows(0)("var_Clave")
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Me._exError = ex
            Return False
        End Try
    End Function

    Public Function Obtener(ByVal pstrIDUsuario As String, ByVal pstrClave As String) As Boolean
        Try
            Dim objShadow As New Shadow.BlitzLock
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            Dim objParametros() As String = {"var_IDUsuario", pstrIDUsuario, "var_Clave", objShadow.Encripta(pstrClave)}
            Dim dtbDatos As Data.DataTable = _objConexion.ObtenerDataTable("SGC_usp_Usuario_Login", objParametros)

            If dtbDatos.Rows.Count > 0 Then
                Me._strEstado = dtbDatos.Rows(0)("chr_Estado")
                Me._strNombre = dtbDatos.Rows(0)("var_Nombre")
                Me._strClave = dtbDatos.Rows(0)("var_Clave")
                Me._strIdUsuario = dtbDatos.Rows(0)("var_IDUsuario")
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Me._exError = ex
            Return False
        End Try
    End Function

    Public Function RestriccionAcceso(ByVal strIdUsuario As String) As Boolean
        Dim objUsuario As New ALVI_Security.clsPerfilUsuario
        If objUsuario.ObtenerxUsuario(strIdUsuario) = True Then
            For Each dtrItem As Data.DataRow In objUsuario.Datos.Rows
                Dim objAcceso As New ALVI_Security.Accesos.AccesoPerfil
                objAcceso.IdGrupo = dtrItem("int_IDPerfil")
                objAcceso.IdAccesoTipo = "C"
                objAcceso.Secuencia = 0
                If objAcceso.Obtener() Then
                    Return True
                End If
            Next
        End If
        Return False
    End Function

#End Region


End Class
