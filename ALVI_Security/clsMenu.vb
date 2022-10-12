Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports AccesoDatos

Public Class clsMenu

#Region "VARIABLES"
    Private _objConexion As AccesoDatos.AccesoDatosSQLServer
    '  AccesoDatosVBSQLServer
    Private _intIDMenu As Integer
    Private _intIDMenuPadre As Integer
    Private _strTitulo As String
    Private _strRuta As String
    Private _intContenedor As Integer
    Private _intNivel As Integer
    Private _strEstado As String
    Private _strUsuario As String
    Private _exError As Exception
#End Region

#Region "Propiedades"
    Public Property IDMenu() As Integer
        Get
            Return _intIDMenu
        End Get
        Set(ByVal value As Integer)
            _intIDMenu = value
        End Set
    End Property
    Public Property IDMenuPadre() As Integer
        Get
            Return _intIDMenuPadre
        End Get
        Set(ByVal value As Integer)
            _intIDMenuPadre = value
        End Set
    End Property
    Public Property Titulo() As String
        Get
            Return _strTitulo
        End Get
        Set(ByVal value As String)
            _strTitulo = value
        End Set
    End Property
    Public Property Ruta() As String
        Get
            Return _strRuta
        End Get
        Set(ByVal value As String)
            _strRuta = value
        End Set
    End Property
    Public Property Contenedor() As Int16
        Get
            Return _intContenedor
        End Get
        Set(ByVal value As Int16)
            _intContenedor = value
        End Set
    End Property
    Public Property Nivel() As Int16
        Get
            Return _intNivel
        End Get
        Set(ByVal value As Int16)
            _intNivel = value
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
    Public ReadOnly Property exError() As String
        Get
            Return _exError.ToString
        End Get
    End Property

#End Region

#Region "Constructores"
    Sub New()
        _intIDMenu = 0
        _intIDMenuPadre = 0
        _strTitulo = ""
        _strRuta = ""
        _intContenedor = 0
        _intNivel = 0
        _strEstado = ""
        _strUsuario = ""
    End Sub
    Sub New(ByVal pintIDMenu As Integer)
        Obtener(pintIDMenu)
    End Sub
#End Region

#Region "METODOS Y FUNCIONES"
    Public Function Agregar() As Boolean
        Try
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            Dim objParametros() As String = {"int_IDMenuPadre", _intIDMenuPadre, _
                                            "var_TituloMenu", _strTitulo, "var_Ruta", _strRuta, _
                                            "bit_Contenedor", _intContenedor, "var_Usuario", Me._strUsuario}
            _objConexion.EjecutarComando("SGC_usp_Menu_Agregar", objParametros)

            Return True
        Catch ex As Exception
            Me._exError = ex
            Return False
        End Try
    End Function

    Public Function Actualizar() As Boolean
        Try
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            Dim objParametros() As String = {"int_IDMenu", _intIDMenu, "int_IDMenuPadre", _intIDMenuPadre, _
                                            "var_TituloMenu", _strTitulo, "var_Ruta", _strRuta, _
                                            "bit_Contenedor", _intContenedor, "var_Usuario", Me._strUsuario}
            _objConexion.EjecutarComando("SGC_usp_Menu_Actualizar", objParametros)

            Return True
        Catch ex As Exception
            Me._exError = ex
            Return False
        End Try
    End Function

    Public Function CambiarEstado(ByVal pstrEstado As String) As Boolean
        Try
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            Dim objParametros() As String = {"int_IDMenu", _intIDMenu, "chr_Estado", pstrEstado, _
                                             "var_Usuario", Me._strUsuario}
            _objConexion.EjecutarComando("SGC_usp_Menu_Estado", objParametros)

            Return True
        Catch ex As Exception
            Me._exError = ex
            Return False
        End Try
    End Function

    Public Function Obtener(ByVal pintIDMenuPadre As Integer) As DataTable
        Try
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            Dim objParametros() As String = {"int_IDMenuPadre", pintIDMenuPadre}
            Dim dtbDatos As Data.DataTable = _objConexion.ObtenerDataTable("SGC_usp_MenuSucesor_Obtener", objParametros)

            Return dtbDatos
        Catch ex As Exception
            Me._exError = ex
            Return Nothing
        End Try
    End Function

    Public Function Listar() As Data.DataTable
        Try
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            Return _objConexion.ObtenerDataTable("SGC_usp_Menu_Listar")
        Catch ex As Exception
            Me._exError = ex
            Return Nothing
        End Try
    End Function

#End Region


End Class
