Imports AccesoDatos
Imports ALVI_LOGIC
Namespace Proceso.Ventas
    Public Class VentasReportes
#Region "VARIABLES"

        Private _strEstatus As String
        Private _strIdNota As String
        Private _strIdCliente As String
        Private _strFechaInicio As String
        Private _strFechaFinal As String
        Private _strEstado As String
        Private _strTipoDocumento As String
        Private _dtbDatos As DataTable
        Private _dtbComprobantes As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer
#End Region

#Region "PROPIEDADES"
        Public Property IdCliente() As String
            Get
                Return _strIdCliente
            End Get
            Set(ByVal value As String)
                _strIdCliente = value
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
        Public Property TipoDocumento() As String
            Get
                Return _strTipoDocumento
            End Get
            Set(ByVal value As String)
                _strTipoDocumento = value
            End Set
        End Property
        Public Property Estatus() As String
            Get
                Return _strEstatus
            End Get
            Set(ByVal value As String)
                _strEstatus = value
            End Set
        End Property
        Public Property IdNota() As String
            Get
                Return _strIdNota
            End Get
            Set(ByVal value As String)
                _strIdNota = value
            End Set
        End Property
        Public Property FechaInicio() As String
            Get
                Return _strFechaInicio
            End Get
            Set(ByVal value As String)
                _strFechaInicio = value
            End Set
        End Property
        Public Property FechaFin() As String
            Get
                Return _strFechaFinal
            End Get
            Set(ByVal value As String)
                _strFechaFinal = value
            End Set
        End Property
        Public Property Datos() As DataTable
            Get
                Return _dtbDatos
            End Get
            Set(ByVal value As DataTable)
                _dtbDatos = value
            End Set
        End Property
        Public Property Comprobantes() As DataTable
            Get
                Return _dtbComprobantes
            End Get
            Set(ByVal value As DataTable)
                _dtbComprobantes = value
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
        Public ReadOnly Property exError() As String
            Get
                Return _exError.ToString
            End Get
        End Property
#End Region

#Region "METODOS Y FUNCIONES"
        Public Function PedidosReporte() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {
                                "dtm_FecInicio", _strFechaInicio, _
                                "dtm_FecFin", _strFechaFinal, _
                                "var_Estatus", _strEstatus, _
                                "var_CodCliente", _strIdCliente}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspo_Pedidos_Reporte", objParametros)
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function VentasReporte() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {
                                "dtm_FecInicio", _strFechaInicio, _
                                "dtm_FecFin", _strFechaFinal, _
                                "var_Estatus", _strEstatus, _
                                "var_TipoDocumento", _strTipoDocumento, _
                                "var_CodCliente", _strIdCliente}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspo_Ventas_Reporte", objParametros)
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function ComprobantesReporte() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {
                                "var_IdNota", _strIdNota}
                _dtbComprobantes = _objConexion.ObtenerDataTable("SGC_uspo_Ventas_Comprobantes", objParametros)
                Return (_dtbComprobantes.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace
