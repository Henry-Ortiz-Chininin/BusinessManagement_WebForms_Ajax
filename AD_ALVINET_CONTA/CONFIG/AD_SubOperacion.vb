Imports EN_ALVINET_CONTA
Imports EN_ALVINET_CONTA.CONFIG
Imports System.Data.SqlClient

Public Class AD_SubOperacion

#Region "Variables"
    Private _objConexion As AccesoDatos.AccesoDatosSQLServer
    Private _entSubOperacion As EN_SubOperacion
    Private _lstSubOperacion As List(Of EN_SubOperacion)
    Private _objError As New Exception
#End Region
#Region "Propiedades"
    Public Property entOperacion() As EN_SubOperacion
        Get
            Return _entSubOperacion
        End Get
        Set(ByVal value As EN_SubOperacion)
            _entSubOperacion = value
        End Set
    End Property
    Public ReadOnly Property lstSubOperacion() As List(Of EN_SubOperacion)
        Get
            Return _lstSubOperacion
        End Get
    End Property

    Public ReadOnly Property objError() As Exception
        Get
            Return _objError
        End Get
    End Property
#End Region
#Region "Metodos yFunciones"
    Public Function Registrar() As Boolean
        Try
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            _objConexion.Procedimiento = "[dbo].[ERP_usp_SubCuenta_Registrar]"
            _objConexion.AddParameter("var_IdSubOperacion", _entSubOperacion.IdSubOperacion)
            _objConexion.AddParameter("var_IdOperacion", _entSubOperacion.IdOperacion)
            _objConexion.AddParameter("var_IdEmpresa", _entSubOperacion.Idempresa)
            _objConexion.AddParameter("var_Descrpcion", _entSubOperacion.SubOperacion)
            _objConexion.AddParameter("dtm_Fecha", _entSubOperacion.FechaCreacion)
            _objConexion.AddParameter("var_Nivel", "1")
            _objConexion.AddParameter("var_IdMoneda", _entSubOperacion.IdMoneda)
            _objConexion.AddParameter("var_IdEntidad", _entSubOperacion.IdEntidad)
            _entSubOperacion.IdSubOperacion = _objConexion.EjecutarComandoSalida()
            Return True
        Catch ex As Exception
            _objError = ex
            Return False
        End Try



    End Function
    Public Function Eliminar() As Boolean
        Try
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            _objConexion.Procedimiento = "[dbo].[ERP_usp_SubCuenta_Eliminar]"
            _objConexion.AddParameter("var_IdSubOperacion", _entSubOperacion.IdSubOperacion)
            _objConexion.EjecutarComando()
            Return True
        Catch ex As Exception
            _objError = ex
            Return False
        End Try
    End Function
    Public Function Listar() As Boolean
        Try
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            _objConexion.Procedimiento = "[dbo].[ERP_usp_SubCuenta_Listar]"
            _objConexion.AddParameter("var_IdEmpresa", _entSubOperacion.Idempresa)
            _objConexion.AddParameter("var_IdOperacion", _entSubOperacion.IdOperacion)
            _objConexion.AddParameter("var_Flag", _entSubOperacion.Flag)
            Dim dr As SqlDataReader = _objConexion.ObtenerDataReader
            _lstSubOperacion = New List(Of EN_SubOperacion)
            Dim intCont As Integer = 0
            If dr IsNot Nothing Then
                If dr.HasRows Then

                    While dr.Read
                        intCont += 1
                        _entSubOperacion = New EN_SubOperacion
                        _entSubOperacion.Agno = intCont
                        _entSubOperacion.Descripcion = dr("Operacion")
                        _entSubOperacion.Idempresa = dr("var_IdEmpresa")
                        _entSubOperacion.RazonSocial = dr("Empresa")
                        _entSubOperacion.IdSubOperacion = dr("var_IdSubOperacion")
                        _entSubOperacion.SubOperacion = dr("SubOperacion")
                        _entSubOperacion.FechaCreacion = dr("Fecha")
                        _entSubOperacion.IdOperacion = dr("var_IdOperacion")
                        '_entSubOperacion.Nivel = dr("var_Nivel")
                        _entSubOperacion.IdMoneda = dr("var_IdMoneda")
                        _entSubOperacion.Moneda = dr("var_DescripcionMoneda")
                        _entSubOperacion.IdEntidad = dr("var_IdEntidadFinanciera")
                        '_entSubOperacion.IdEntidad = dr("var_DescripcionEntidad")
                        _lstSubOperacion.Add(_entSubOperacion)
                    End While
                End If
            End If
            Return (_lstSubOperacion.Count > 0)
            Return True
        Catch ex As Exception
            _objError = ex
            Return False
        End Try

    End Function
    Public Function Listar1() As Boolean
        Try
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            _objConexion.Procedimiento = "[dbo].[ERP_usp_SubCuenta_Listar1]"
            _objConexion.AddParameter("var_IdOperacion", _entSubOperacion.IdOperacion)
            Dim dr As SqlDataReader = _objConexion.ObtenerDataReader
            _lstSubOperacion = New List(Of EN_SubOperacion)
            If dr IsNot Nothing Then
                If dr.HasRows Then

                    While dr.Read
                        _entSubOperacion = New EN_SubOperacion
                        _entSubOperacion.Descripcion = dr("Operacion")
                        _entSubOperacion.Idempresa = dr("var_IdEmpresa")
                        _entSubOperacion.IdEmpresa = dr("Empresa")
                        _entSubOperacion.IdSubOperacion = dr("var_IdSubOperacion")
                        _entSubOperacion.SubOperacion = dr("SubOperacion")
                        _entSubOperacion.FechaCreacion = dr("Fecha")
                        _entSubOperacion.IdOperacion = dr("var_IdOperacion")
                        '_entSubOperacion.Nivel = dr("var_Nivel")
                        _lstSubOperacion.Add(_entSubOperacion)
                    End While
                End If
            End If
            Return (_lstSubOperacion.Count > 0)
            Return True
        Catch ex As Exception
            _objError = ex
            Return False
        End Try

    End Function
    Public Function ListarN() As Boolean
        Try
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            _objConexion.Procedimiento = "[dbo].[ERP_usp_OperacionCuenta_Listar_S]"
            _objConexion.AddParameter("var_IdEmpresa", _entSubOperacion.Idempresa)
            _objConexion.AddParameter("var_IdOperacion", _entSubOperacion.IdOperacion)
            Dim dr As SqlDataReader = _objConexion.ObtenerDataReader
            _lstSubOperacion = New List(Of EN_SubOperacion)
            If dr IsNot Nothing Then
                If dr.HasRows Then

                    While dr.Read
                        _entSubOperacion = New EN_SubOperacion
                        _entSubOperacion.IdSubOperacion = dr("var_IdSubOperacion")
                        _entSubOperacion.SubOperacion = dr("var_Descripcion")
                        _lstSubOperacion.Add(_entSubOperacion)
                    End While
                End If
            End If
            Return (_lstSubOperacion.Count > 0)
            Return True
        Catch ex As Exception
            _objError = ex
            Return False
        End Try

    End Function
    Public Function ListarXop() As Boolean
        Try
            _objConexion = New AccesoDatos.AccesoDatosSQLServer
            _objConexion.Procedimiento = "[dbo].[ERP_usp_SubOperacion_Buscar]"
            _objConexion.AddParameter("var_IdOperacion", _entSubOperacion.IdOperacion)
            Dim dr As SqlDataReader = _objConexion.ObtenerDataReader
            _lstSubOperacion = New List(Of EN_SubOperacion)
            If dr IsNot Nothing Then
                If dr.HasRows Then

                    While dr.Read
                        _entSubOperacion = New EN_SubOperacion
                        _entSubOperacion.IdSubOperacion = dr("var_IdSubOperacion")
                        _entSubOperacion.SubOperacion = dr("var_Descripcion")
                        _entSubOperacion.IdOperacion = dr("var_IdOperacion")
                        _lstSubOperacion.Add(_entSubOperacion)
                    End While
                End If
            End If
            Return (_lstSubOperacion.Count > 0)
            Return True
        Catch ex As Exception
            _objError = ex
            Return False
        End Try

    End Function
#End Region
End Class
