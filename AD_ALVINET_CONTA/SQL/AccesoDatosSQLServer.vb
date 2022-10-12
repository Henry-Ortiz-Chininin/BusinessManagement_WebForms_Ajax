Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Imports System.Collections.Generic


Namespace AccesoDatos
    Public Class AccesoDatosSQLServer
        Implements IDisposable
        Protected m_strCadenaConexion As String

#Region " Declaracion de Variables Miembro "
        Private m_cnnSQLConexion As SqlConnection
        Private _objParametros As List(Of EN_Parametro)
        Private _strProcedimiento As String
#End Region

#Region " Constructores "
        Sub New()
            m_strCadenaConexion = GeneradorCadenaConexion.ObtenerCadenaConexionSQLServer()

            _objParametros = New List(Of EN_Parametro)
            m_cnnSQLConexion = New SqlConnection(m_strCadenaConexion)
        End Sub
#End Region

#Region " Metodos Privados "
        'Private Sub AsignarParametrosSalida(ByVal sqlPrmParametros As SqlParameter(), ByVal objParametros As Object())
        '    For i As Integer = 1 To sqlPrmParametros.GetUpperBound(0)
        '        If sqlPrmParametros(i).Direction = ParameterDirection.Output Then
        '            If objParametros.Length = 2 Then
        '                objParametros(1) = sqlPrmParametros(i).Value
        '            Else
        '                objParametros(i + 1) = sqlPrmParametros(i).Value
        '            End If
        '        End If
        '    Next i
        'End Sub
#End Region

#Region " Metodos Protegidos "
        Protected Function ConfigurarParametros(ByVal objParametros As List(Of EN_Parametro)) As Object()
            Dim parParametros As SqlParameter()
            ReDim parParametros(CType((objParametros.Count), Integer))
            Dim j As Integer = 1

            For Each objParametro As EN_Parametro In objParametros
                parParametros(j) = New SqlParameter
                With parParametros(j)
                    If (Not objParametro.Valor Is Nothing) AndAlso _
                        (Not objParametro.Valor.GetType.IsByRef) Then
                        '.Direction = ParameterDirection.Input
                        .ParameterName = "@" & CType(objParametro.Nombre, String)
                        .Value = objParametro.Valor
                    Else
                        .Direction = ParameterDirection.Output
                        .ParameterName = "@" & CType(objParametro.Nombre, String)
                        .SqlDbType = SqlDbType.VarChar
                        .Size = 200
                    End If

                End With
                j += 1
            Next

            Return parParametros
        End Function
#End Region

#Region " Metodos Publicos "
        Public Property Procedimiento() As String
            Get
                Return _strProcedimiento
            End Get
            Set(ByVal value As String)
                _strProcedimiento = value
            End Set
        End Property
        Public Sub AddParameter(ByVal pstrNombre As String, ByVal pintValor As Int16)
            Dim entParametro As New EN_Parametro
            entParametro.Nombre = pstrNombre
            entParametro.Valor = pintValor
            entParametro.Tipo = "INT"
            _objParametros.Add(entParametro)
        End Sub
        Public Sub AddParameter(ByVal pstrNombre As String, ByVal pstrValor As String)
            Dim entParametro As New EN_Parametro
            entParametro.Nombre = pstrNombre
            entParametro.Valor = pstrValor
            entParametro.Tipo = "STR"
            _objParametros.Add(entParametro)
        End Sub
        Public Sub AddParameter(ByVal pstrNombre As String, ByVal pdblValor As Double)
            Dim entParametro As New EN_Parametro
            entParametro.Nombre = pstrNombre
            entParametro.Valor = pdblValor
            entParametro.Tipo = "DBL"
            _objParametros.Add(entParametro)
        End Sub
        Public Sub AddParameter(ByVal pstrNombre As String, ByVal pbolValor As Boolean)
            Dim entParametro As New EN_Parametro
            entParametro.Nombre = pstrNombre
            entParametro.Valor = pbolValor
            entParametro.Tipo = "BOL"
            _objParametros.Add(entParametro)
        End Sub
        Public Sub AddParameter(ByVal pstrNombre As String, ByVal pobjValor As Object)
            Dim entParametro As New EN_Parametro
            entParametro.Nombre = pstrNombre
            entParametro.Valor = pobjValor
            entParametro.Tipo = "   OBJ"
            _objParametros.Add(entParametro)
        End Sub
        Public Overloads Function EjecutarComando() As Integer
            If _strProcedimiento <> "" Then
                Return EjecutarComando(_strProcedimiento)
            Else
                Return Nothing
            End If
        End Function
        Public Overloads Function EjecutarComandoSalida() As String
            If _strProcedimiento <> "" Then
                Return EjecutarComandoSalida(_strProcedimiento)
            Else
                Return Nothing
            End If
        End Function
        Public Overloads Function EjecutarComando(ByVal strProcedimiento As String) As Integer
            Dim intNumFilas As Integer

            If m_cnnSQLConexion.State = ConnectionState.Closed Then
                Call m_cnnSQLConexion.Open()
            End If

            Dim tranSQLTransaccion As SqlTransaction = m_cnnSQLConexion.BeginTransaction

            Try
                Dim prmParametros As SqlParameter()
                If _objParametros.Count > 0 Then
                    prmParametros = CType(ConfigurarParametros(_objParametros), SqlParameter())
                    intNumFilas = SqlHelper.ExecuteNonQuery(tranSQLTransaccion, CommandType.StoredProcedure, strProcedimiento, prmParametros)
                Else
                    intNumFilas = SqlHelper.ExecuteNonQuery(tranSQLTransaccion, CommandType.StoredProcedure, strProcedimiento)
                End If

                tranSQLTransaccion.Commit()
            Catch SqlEx As SqlException
                tranSQLTransaccion.Rollback()
                Throw SqlEx
            Catch DatEx As DataException
                tranSQLTransaccion.Rollback()
                Throw DatEx
            Catch ex As Exception
                tranSQLTransaccion.Rollback()
                Throw ex
            Finally
                m_cnnSQLConexion.Close()
            End Try

            Return intNumFilas
        End Function
        Public Overloads Function EjecutarComandoSalida(ByVal strProcedimiento As String) As String
            Dim intNumFilas As String

            If m_cnnSQLConexion.State = ConnectionState.Closed Then
                Call m_cnnSQLConexion.Open()
            End If

            Dim tranSQLTransaccion As SqlTransaction = m_cnnSQLConexion.BeginTransaction

            Try
                Dim prmParametros As SqlParameter()
                If _objParametros.Count > 0 Then
                    prmParametros = CType(ConfigurarParametros(_objParametros), SqlParameter())
                    intNumFilas = SqlHelper.ExecuteScalar(tranSQLTransaccion, CommandType.StoredProcedure, strProcedimiento, prmParametros)
                Else
                    intNumFilas = SqlHelper.ExecuteScalar(tranSQLTransaccion, CommandType.StoredProcedure, strProcedimiento)
                End If

                tranSQLTransaccion.Commit()
            Catch SqlEx As SqlException
                tranSQLTransaccion.Rollback()
                Throw SqlEx
            Catch DatEx As DataException
                tranSQLTransaccion.Rollback()
                Throw DatEx
            Catch ex As Exception
                tranSQLTransaccion.Rollback()
                Throw ex
            Finally
                m_cnnSQLConexion.Close()
            End Try

            Return intNumFilas
        End Function
        Public Overloads Function ObtenerDataReader() As System.Data.IDataReader
            If _strProcedimiento <> "" Then
                Return ObtenerDataReader(_strProcedimiento)
            Else
                Return Nothing
            End If
        End Function
        Public Overloads Function ObtenerDataSet() As System.Data.DataSet
            If _strProcedimiento <> "" Then

                Return ObtenerDataSet(_strProcedimiento)
            Else
                Return Nothing
            End If
        End Function
        Public Overloads Function ObtenerDataTable() As System.Data.DataTable
            If _strProcedimiento <> "" Then
                Return ObtenerDataTable(_strProcedimiento)
            Else
                Return Nothing
            End If
        End Function
        Public Overloads Function ObtenerValor() As Object
            If _strProcedimiento <> "" Then
                Return ObtenerValor(_strProcedimiento)
            Else
                Return Nothing
            End If
        End Function
        Public Overloads Function ObtenerDataReader(ByVal strProcedimiento As String) As System.Data.IDataReader
            Dim dtrReader As SqlDataReader

            Try
                Dim prmParametros As SqlParameter()
                If _objParametros.Count > 0 Then
                    prmParametros = CType(ConfigurarParametros(_objParametros), SqlParameter())
                    dtrReader = SqlHelper.ExecuteReader(m_strCadenaConexion, CommandType.StoredProcedure, strProcedimiento, prmParametros)
                Else
                    dtrReader = SqlHelper.ExecuteReader(m_strCadenaConexion, CommandType.StoredProcedure, strProcedimiento)
                End If
            Catch SqlEx As SqlException
                If Not dtrReader.IsClosed Then
                    dtrReader.Close()
                End If

                Throw SqlEx
            Catch DatEx As DataException
                If Not dtrReader.IsClosed Then
                    dtrReader.Close()
                End If

                Throw DatEx
            Catch ex As Exception
                If Not dtrReader.IsClosed Then
                    dtrReader.Close()
                End If

                Throw ex
            End Try

            Return dtrReader
        End Function
        Public Overloads Function ObtenerDataSet(ByVal strProcedimiento As String) As System.Data.DataSet
            Dim dstDataSet As DataSet

            Try
                Dim prmParametros As SqlParameter()
                If _objParametros.Count > 0 Then
                    prmParametros = CType(ConfigurarParametros(_objParametros), SqlParameter())
                    dstDataSet = SqlHelper.ExecuteDataset(m_strCadenaConexion, CommandType.StoredProcedure, strProcedimiento, prmParametros)
                Else
                    dstDataSet = SqlHelper.ExecuteDataset(m_strCadenaConexion, CommandType.StoredProcedure, strProcedimiento)
                End If
            Catch SqlEx As SqlException
                Throw SqlEx
            Catch DatEx As DataException
                Throw DatEx
            Catch ex As Exception
                Throw ex
            End Try

            Return dstDataSet
        End Function
        Public Overloads Function ObtenerDataTable(ByVal strProcedimiento As String) As System.Data.DataTable
            Dim dtblDatatable As DataTable

            Try
                Dim prmParametros As SqlParameter()
                If _objParametros.Count > 0 Then
                    prmParametros = CType(ConfigurarParametros(_objParametros), SqlParameter())
                    dtblDatatable = SqlHelper.ExecuteDataset(m_strCadenaConexion, CommandType.StoredProcedure, strProcedimiento, prmParametros).Tables(0)
                Else
                    dtblDatatable = SqlHelper.ExecuteDataset(m_strCadenaConexion, CommandType.StoredProcedure, strProcedimiento).Tables(0)
                End If

            Catch SqlEx As SqlException
                Throw SqlEx
            Catch DatEx As DataException
                Throw DatEx
            Catch ex As Exception
                Throw ex
            End Try

            Return dtblDatatable
        End Function
        Public Overloads Function ObtenerXmlReader(ByVal strProcedimiento As String) As System.Xml.XmlReader
            Dim xmlRdrReader As XmlReader

            Try
                Dim prmParametros As SqlParameter()
                If _objParametros.Count > 0 Then
                    prmParametros = CType(ConfigurarParametros(_objParametros), SqlParameter())
                    xmlRdrReader = SqlHelper.ExecuteXmlReader(m_cnnSQLConexion, strProcedimiento, prmParametros)
                Else
                    xmlRdrReader = SqlHelper.ExecuteXmlReader(m_cnnSQLConexion, strProcedimiento, Nothing)
                End If

            Catch SqlEx As SqlException
                Throw SqlEx
            Catch DatEx As DataException
                Throw DatEx
            Catch ex As Exception
                Throw ex
            Finally
                If m_cnnSQLConexion.State <> ConnectionState.Closed Then
                    m_cnnSQLConexion.Close()
                End If
            End Try

            Return xmlRdrReader
        End Function
        Public Overloads Function ObtenerValor(ByVal strProcedimiento As String) As Object
            Dim objValor As Object

            Try
                Dim prmParametros As SqlParameter()
                If _objParametros.Count > 0 Then
                    prmParametros = CType(ConfigurarParametros(_objParametros), SqlParameter())
                    objValor = SqlHelper.ExecuteScalar(m_strCadenaConexion, CommandType.StoredProcedure, strProcedimiento, prmParametros)
                Else
                    objValor = SqlHelper.ExecuteScalar(m_strCadenaConexion, CommandType.StoredProcedure, strProcedimiento)
                End If

            Catch SQLEx As SqlException
                Throw SQLEx
            Catch DatEx As DataException
                Throw DatEx
            Catch ex As Exception
                Throw ex
            End Try

            Return objValor
        End Function
        Public Overloads Function asignarParametrosSalida(ByVal sqlPrmParametros As SqlParameter()) As Object
            For i As Integer = 1 To sqlPrmParametros.GetUpperBound(0)
                If sqlPrmParametros(i).Direction = ParameterDirection.Output Then
                    If sqlPrmParametros.Length = 2 Then
                        sqlPrmParametros(1) = sqlPrmParametros(i).Value
                    Else
                        sqlPrmParametros(i + 1) = sqlPrmParametros(i).Value
                    End If
                End If
            Next i
            Return sqlPrmParametros
        End Function
        Public Sub Dispose() Implements System.IDisposable.Dispose
            If m_cnnSQLConexion.State <> ConnectionState.Closed Then
                m_cnnSQLConexion.Close()
            End If

            m_cnnSQLConexion.Dispose()
        End Sub

#End Region

    End Class
End Namespace