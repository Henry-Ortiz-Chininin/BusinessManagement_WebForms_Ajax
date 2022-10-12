Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports AccesoDatos

Public Class clsPerfilMenu

#Region "VARIABLES"
    Private _objConexion As AccesoDatos.AccesoDatosSQLServer
    '  AccesoDatosVBSQLServer
    Private _intIDPerfil As Integer
    Private _intIDMenu As String
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
    Public Property IDMenu() As Int16
        Get
            Return _intIDMenu
        End Get
        Set(ByVal value As Int16)
            _intIDMenu = value
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
        _intIDMenu = 0
        _strUsuario = ""
        _dtbDatos = Nothing
    End Sub
    Sub New(ByVal pintIDPerfil As Integer)
        Obtener(pintIDPerfil)
    End Sub
#End Region

#Region "METODOS Y FUNCIONES"
    Public Function Agregar() As Boolean
        Try
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            Dim objParametros() As String = {"int_IDPerfil", _intIDPerfil, "int_IDMenu", _intIDMenu, "var_Usuario", _strUsuario}
            _objConexion.EjecutarComando("SGC_usp_PerfilMenu_Agregar", objParametros)

            Return True
        Catch ex As Exception
            Me._exError = ex
            Return False
        End Try
    End Function


    Public Function Eliminar() As Boolean
        Try
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            Dim objParametros() As String = {"int_IDPerfil", _intIDPerfil, "int_IDMenu", _intIDMenu}
            _objConexion.EjecutarComando("SGC_usp_PerfilUsuario_Eliminar", objParametros)
            Return True
        Catch ex As Exception
            Me._exError = ex
            Return False
        End Try
    End Function
    Public Function Obtener(ByVal pintIDPerfil As Int16) As Boolean
        Me._dtbDatos = New Data.DataTable
        _dtbDatos.Columns.Add("int_IDRegistro", GetType(String))
        _dtbDatos.Columns.Add("var_NombrePerfil", GetType(String))
        _dtbDatos.Columns.Add("int_IDPerfil", GetType(Int16))
        _dtbDatos.Columns.Add("var_NombreNivel0", GetType(String))
        _dtbDatos.Columns.Add("var_NombreNivel1", GetType(String))
        _dtbDatos.Columns.Add("var_NombreNivel2", GetType(String))
        _dtbDatos.Columns.Add("var_NombreNivel3", GetType(String))
        _dtbDatos.Columns.Add("int_IDMenu", GetType(Int16))
        _dtbDatos.Columns.Add("int_IDNivel0", GetType(Int16))
        _dtbDatos.Columns.Add("int_IDNivel1", GetType(Int16))
        _dtbDatos.Columns.Add("int_IDNivel2", GetType(Int16))
        _dtbDatos.Columns.Add("int_IDNivel3", GetType(Int16))
        _dtbDatos.Columns.Add("var_RutaNivel0", GetType(String))
        _dtbDatos.Columns.Add("var_RutaNivel1", GetType(String))
        _dtbDatos.Columns.Add("var_RutaNivel2", GetType(String))
        _dtbDatos.Columns.Add("var_RutaNivel3", GetType(String))
        _dtbDatos.Columns.Add("bit_ContenedorNivel0", GetType(Boolean))
        _dtbDatos.Columns.Add("bit_ContenedorNivel1", GetType(Boolean))
        _dtbDatos.Columns.Add("bit_ContenedorNivel2", GetType(Boolean))
        _dtbDatos.Columns.Add("bit_ContenedorNivel3", GetType(Boolean))

        Try
            Dim dtbNivel0 As Data.DataTable = ObtenerxPerfil(pintIDPerfil, 0, 0)

            If dtbNivel0.Rows.Count > 0 Then
                For Each dtrItemNivel As Data.DataRow In dtbNivel0.Rows
                    Dim dtrNuevo As Data.DataRow = _dtbDatos.NewRow
                    dtrNuevo("var_NombrePerfil") = dtrItemNivel("var_NombrePerfil")
                    dtrNuevo("int_IDRegistro") = dtrItemNivel("int_IDMenu") & "0,0"
                    dtrNuevo("int_IDPerfil") = dtrItemNivel("int_IDPerfil")
                    dtrNuevo("var_NombreNivel0") = dtrItemNivel("var_TituloMenu")
                    dtrNuevo("var_NombreNivel1") = ""
                    dtrNuevo("var_NombreNivel2") = ""
                    dtrNuevo("var_NombreNivel3") = ""
                    dtrNuevo("int_IDMenu") = dtrItemNivel("int_IDMenu")
                    dtrNuevo("int_IDNivel0") = dtrItemNivel("int_IDMenu")
                    dtrNuevo("int_IDNivel1") = 0
                    dtrNuevo("int_IDNivel2") = 0
                    dtrNuevo("int_IDNivel3") = 0
                    dtrNuevo("var_RutaNivel0") = dtrItemNivel("var_RutaMenu")
                    dtrNuevo("var_RutaNivel1") = ""
                    dtrNuevo("var_RutaNivel2") = ""
                    dtrNuevo("var_RutaNivel3") = ""
                    dtrNuevo("bit_ContenedorNivel0") = dtrItemNivel("bit_Contenedor")
                    dtrNuevo("bit_ContenedorNivel1") = 0
                    dtrNuevo("bit_ContenedorNivel2") = 0
                    dtrNuevo("bit_ContenedorNivel3") = 0

                    _dtbDatos.LoadDataRow(dtrNuevo.ItemArray, True)
                    _dtbDatos.AcceptChanges()

                    Dim dtbNivel1 As Data.DataTable = ObtenerxPerfil(pintIDPerfil, 1, dtrItemNivel("int_IDMenu"))


                    If dtbNivel1.Rows.Count > 0 Then
                        For Each dtrItemNivel1 As Data.DataRow In dtbNivel1.Rows
                            Dim dtrNuevo1 As Data.DataRow = _dtbDatos.NewRow
                            dtrNuevo("int_IDRegistro") = dtrItemNivel("int_IDMenu") & "," & dtrItemNivel1("int_IDMenu") & "0"
                            dtrNuevo("var_NombrePerfil") = dtrItemNivel("var_NombrePerfil")
                            dtrNuevo("int_IDPerfil") = dtrItemNivel("int_IDPerfil")
                            dtrNuevo("var_NombreNivel0") = dtrItemNivel("var_TituloMenu")
                            dtrNuevo("var_NombreNivel1") = dtrItemNivel1("var_TituloMenu")
                            dtrNuevo("var_NombreNivel2") = ""
                            dtrNuevo("var_NombreNivel3") = ""
                            dtrNuevo("int_IDMenu") = dtrItemNivel1("int_IDMenu")
                            dtrNuevo("int_IDNivel0") = dtrItemNivel("int_IDMenu")
                            dtrNuevo("int_IDNivel1") = dtrItemNivel1("int_IDMenu")
                            dtrNuevo("int_IDNivel2") = 0
                            dtrNuevo("int_IDNivel3") = 0
                            dtrNuevo("var_RutaNivel0") = dtrItemNivel("var_RutaMenu")
                            dtrNuevo("var_RutaNivel1") = dtrItemNivel1("var_RutaMenu")
                            dtrNuevo("var_RutaNivel2") = ""
                            dtrNuevo("var_RutaNivel3") = ""
                            dtrNuevo("bit_ContenedorNivel0") = dtrItemNivel("bit_Contenedor")
                            dtrNuevo("bit_ContenedorNivel1") = dtrItemNivel1("bit_Contenedor")
                            dtrNuevo("bit_ContenedorNivel2") = 0
                            dtrNuevo("bit_ContenedorNivel3") = 0

                            _dtbDatos.LoadDataRow(dtrNuevo.ItemArray, True)
                            _dtbDatos.AcceptChanges()

                            Dim dtbNivel2 As Data.DataTable = ObtenerxPerfil(pintIDPerfil, 2, dtrItemNivel1("int_IDMenu"))

                            If dtbNivel2.Rows.Count > 0 Then
                                For Each dtrItemNivel2 As Data.DataRow In dtbNivel2.Rows
                                    Dim dtrNuevo2 As Data.DataRow = _dtbDatos.NewRow
                                    dtrNuevo("int_IDRegistro") = dtrItemNivel("int_IDMenu") & "," & dtrItemNivel1("int_IDMenu") & "0"
                                    dtrNuevo("var_NombrePerfil") = dtrItemNivel("var_NombrePerfil")
                                    dtrNuevo("int_IDPerfil") = dtrItemNivel("int_IDPerfil")
                                    dtrNuevo("var_NombreNivel0") = dtrItemNivel("var_TituloMenu")
                                    dtrNuevo("var_NombreNivel1") = dtrItemNivel1("var_TituloMenu")
                                    dtrNuevo("var_NombreNivel2") = dtrItemNivel2("var_TituloMenu")
                                    dtrNuevo("var_NombreNivel3") = ""
                                    dtrNuevo("int_IDMenu") = dtrItemNivel2("int_IDMenu")
                                    dtrNuevo("int_IDNivel0") = dtrItemNivel("int_IDMenu")
                                    dtrNuevo("int_IDNivel1") = dtrItemNivel1("int_IDMenu")
                                    dtrNuevo("int_IDNivel2") = dtrItemNivel2("int_IDMenu")
                                    dtrNuevo("int_IDNivel3") = 0
                                    dtrNuevo("var_RutaNivel0") = dtrItemNivel("var_RutaMenu")
                                    dtrNuevo("var_RutaNivel1") = dtrItemNivel1("var_RutaMenu")
                                    dtrNuevo("var_RutaNivel2") = dtrItemNivel2("var_RutaMenu")
                                    dtrNuevo("var_RutaNivel3") = ""
                                    dtrNuevo("bit_ContenedorNivel0") = dtrItemNivel("bit_Contenedor")
                                    dtrNuevo("bit_ContenedorNivel1") = dtrItemNivel1("bit_Contenedor")
                                    dtrNuevo("bit_ContenedorNivel2") = dtrItemNivel2("bit_Contenedor")
                                    dtrNuevo("bit_ContenedorNivel3") = 0

                                    _dtbDatos.LoadDataRow(dtrNuevo.ItemArray, True)
                                    _dtbDatos.AcceptChanges()

                                    Dim dtbNivel3 As Data.DataTable = ObtenerxPerfil(pintIDPerfil, 3, dtrItemNivel2("int_IDMenu"))

                                    If dtbNivel3.Rows.Count > 0 Then
                                        For Each dtrItemNivel3 As Data.DataRow In dtbNivel3.Rows
                                            Dim dtrNuevo3 As Data.DataRow = _dtbDatos.NewRow
                                            dtrNuevo("int_IDRegistro") = dtrItemNivel("int_IDMenu") & "," & dtrItemNivel1("int_IDMenu") & "0"
                                            dtrNuevo("var_NombrePerfil") = dtrItemNivel("var_NombrePerfil")
                                            dtrNuevo("int_IDPerfil") = dtrItemNivel("int_IDPerfil")
                                            dtrNuevo("var_NombreNivel0") = dtrItemNivel("var_TituloMenu")
                                            dtrNuevo("var_NombreNivel1") = dtrItemNivel1("var_TituloMenu")
                                            dtrNuevo("var_NombreNivel2") = dtrItemNivel2("var_TituloMenu")
                                            dtrNuevo("var_NombreNivel3") = dtrItemNivel3("var_TituloMenu")
                                            dtrNuevo("int_IDMenu") = dtrItemNivel2("int_IDMenu")
                                            dtrNuevo("int_IDNivel0") = dtrItemNivel("int_IDMenu")
                                            dtrNuevo("int_IDNivel1") = dtrItemNivel1("int_IDMenu")
                                            dtrNuevo("int_IDNivel2") = dtrItemNivel2("int_IDMenu")
                                            dtrNuevo("int_IDNivel3") = dtrItemNivel3("int_IDMenu")
                                            dtrNuevo("var_RutaNivel0") = dtrItemNivel("var_RutaMenu")
                                            dtrNuevo("var_RutaNivel1") = dtrItemNivel1("var_RutaMenu")
                                            dtrNuevo("var_RutaNivel2") = dtrItemNivel2("var_RutaMenu")
                                            dtrNuevo("var_RutaNivel3") = dtrItemNivel3("var_RutaMenu")
                                            dtrNuevo("bit_ContenedorNivel0") = dtrItemNivel("bit_Contenedor")
                                            dtrNuevo("bit_ContenedorNivel1") = dtrItemNivel1("bit_Contenedor")
                                            dtrNuevo("bit_ContenedorNivel2") = dtrItemNivel2("bit_Contenedor")
                                            dtrNuevo("bit_ContenedorNivel3") = dtrItemNivel3("bit_Contenedor")

                                            _dtbDatos.LoadDataRow(dtrNuevo.ItemArray, True)
                                            _dtbDatos.AcceptChanges()

                                        Next
                                    End If
                                Next

                            End If


                        Next
                    End If

                Next
            Else
                Dim dtrItem As Data.DataRow = _dtbDatos.NewRow
                dtrItem("var_NombrePerfil") = "--"
                dtrItem("int_IDPerfil") = _intIDPerfil
                dtrItem("var_NombreNivel0") = "--"
                dtrItem("var_NombreNivel1") = "--"
                dtrItem("var_NombreNivel2") = "--"
                dtrItem("var_NombreNivel3") = "--"
                dtrItem("int_IDNivel0") = 0
                dtrItem("int_IDNivel1") = 0
                dtrItem("int_IDNivel2") = 0
                dtrItem("int_IDNivel3") = 0
                _dtbDatos.LoadDataRow(dtrItem.ItemArray, True)
                _dtbDatos.AcceptChanges()
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Public Function ObtenerxPerfil(ByVal pintIDPerfil As Integer, ByVal pintNivel As Int16, ByVal pintIDMenuPadre As Int16) As Data.DataTable
        Try
            Dim objConexion = New AccesoDatos.AccesoDatosSQLServer
            Dim objParametros() As String = {"int_IDPerfil", pintIDPerfil, "int_Nivel", pintNivel, "int_IDMenuPadre", pintIDMenuPadre}
            Return objConexion.ObtenerDataTable("SGC_usp_MenuxPerfil_Obtener", objParametros)

        Catch ex As Exception
            Me._exError = ex
            Return Nothing
        End Try
    End Function

    Public Function ObtenerxUsuario(ByVal pstrIdUsuario As String, ByVal pintNivel As Int16, ByVal pintIDMenuPadre As Int16) As Data.DataTable
        Try
            Dim objConexion = New AccesoDatos.AccesoDatosSQLServer
            Dim objParametros() As String = {"var_IdUsuario", pstrIdUsuario, "int_Nivel", pintNivel, "int_IDMenuPadre", pintIDMenuPadre}
            Return objConexion.ObtenerDataTable("SGC_usp_MenuxUsuario_Obtener", objParametros)

        Catch ex As Exception
            Me._exError = ex
            Return Nothing
        End Try
    End Function

    Public Function ObtenerxNivel(ByVal pintNivel As Integer, ByVal pintIDMenuPadre As Int16) As Data.DataTable
        Try
            Dim objConexion = New AccesoDatos.AccesoDatosSQLServer
            Dim objParametros() As String = {"int_Nivel", pintNivel, "int_IDMenuPadre", pintIDMenuPadre}
            Return objConexion.ObtenerDataTable("SGC_usp_MenuxNivel_Obtener", objParametros)

        Catch ex As Exception
            Me._exError = ex
            Return Nothing
        End Try
    End Function

#End Region


End Class
