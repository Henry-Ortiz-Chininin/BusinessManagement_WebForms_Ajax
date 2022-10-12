Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports AccesoDatos

Public Class clsPerfilUsuario


#Region "VARIABLES"
    Private _objConexion As AccesoDatos.AccesoDatosSQLServer
    ' AccesoDatosVBSQLServer
    Private _intIDPerfil As Integer
    Private _strIDUsuario As String
    Private _strUsuario As String
    Private _dtbDatos As Data.DataTable
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
    Public Property IDUsuario() As String
        Get
            Return _strIDUsuario
        End Get
        Set(ByVal value As String)
            _strIDUsuario = value
        End Set
    End Property
    Public ReadOnly Property Datos() As Data.DataTable
        Get
            Return _dtbDatos
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
        _intIDPerfil = 0
        _strIDUsuario = ""
        _strUsuario = ""
        CreateSchema()
    End Sub
    Sub New(ByVal pintIDPerfil As Integer)
        CreateSchema()
        Obtener(pintIDPerfil)
    End Sub
#End Region

#Region "METODOS Y FUNCIONES"
    Public Function Agregar() As Boolean
        Try
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            Dim objParametros() As String = {"int_IDPerfil", _intIDPerfil, "var_IDUsuario", _strIDUsuario, "var_Usuario", _strUsuario}
            _objConexion.EjecutarComando("SGC_usp_PerfilUsuario_Agregar", objParametros)
            Return True
        Catch ex As Exception
            Me._exError = ex
            Return False
        End Try
    End Function
    Private Sub CreateSchema()
        Dim dtbDatos As New Data.DataTable
        dtbDatos.Columns.Add("var_IDUsuario", GetType(String))
        dtbDatos.Columns.Add("var_Nombre", GetType(String))
        dtbDatos.Columns.Add("chr_Estado", GetType(String))
        dtbDatos.Columns.Add("var_NombrePerfil", GetType(String))
        dtbDatos.Columns.Add("var_NombreLocal", GetType(String))
        _dtbDatos = dtbDatos
    End Sub


    Public Function Eliminar() As Boolean
        Try
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            Dim objParametros() As String = {"int_IDPerfil", _intIDPerfil, "var_IDUsuario", _strIDUsuario}
            _objConexion.EjecutarComando("SGC_usp_PerfilUsuario_Eliminar", objParametros)

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
            _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_PerfilUsuario_Obtener", objParametros)
            If _dtbDatos.Rows.Count = 0 Then
                CreateSchema()
                Dim dtrItem As Data.DataRow = _dtbDatos.NewRow
                dtrItem("var_IDUsuario") = "--"
                dtrItem("var_Nombre") = "--"
                dtrItem("chr_Estado") = "--"
                dtrItem("var_NombrePerfil") = "--"
                dtrItem("var_NombreLocal") = "--"
                _dtbDatos.LoadDataRow(dtrItem.ItemArray, True)
                _dtbDatos.AcceptChanges()
            End If
            Return True
        Catch ex As Exception
            Me._exError = ex
            Return False
        End Try
    End Function
    Public Function ObtenerxUsuario(ByVal pstrUsuario As String) As Boolean
        Try
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            Dim objParametros() As String = {"var_IDUsuario", pstrUsuario}
            _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_PerfilxUsuario_Obtener", objParametros)
            Return (_dtbDatos.Rows.Count > 0)
        Catch ex As Exception
            Me._exError = ex
            Return False
        End Try
    End Function

#End Region


End Class
