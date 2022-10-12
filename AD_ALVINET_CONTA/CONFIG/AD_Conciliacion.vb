Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.AccesoDatos
Imports System.Data.SqlClient
Imports EN_ALVINET_CONTA

Public Class AD_Conciliacion
#Region "Variables"
    Private _lstConciliacion As List(Of EN_Conciliacion)

    Private _objENConciliacion As New EN_Conciliacion
    Private _objError As New Exception
    Private _objConexion As AccesoDatosSQLServer





#End Region
#Region "Propiedades"

    Public ReadOnly Property lstConciliacion() As List(Of EN_Conciliacion)
        Get
            Return _lstConciliacion
        End Get
    End Property
    Public Property entConciliacion() As EN_Conciliacion
        Get
            Return _objENConciliacion
        End Get
        Set(ByVal value As EN_Conciliacion)
            _objENConciliacion = value
        End Set
    End Property

    Public ReadOnly Property objError() As Exception
        Get
            Return _objError
        End Get

    End Property


#End Region
#Region "Metodos"
    Public Function Registrar() As Boolean
        Try
            _objConexion = New AccesoDatosSQLServer()
            _objConexion.Procedimiento = "dbo.ERP_usp_Conciliacion_Registrar"
            _objConexion.AddParameter("var_IdConciliacion", _objENConciliacion.IdConciliacion)
            _objConexion.AddParameter("var_IdMovimientoBanco", _objENConciliacion.IdBanco)
            _objConexion.AddParameter("var_IdMovimientoCaja", _objENConciliacion.IdCaja)
            _objConexion.AddParameter("var_IdTipoDocumento", _objENConciliacion.IdTipodoc)
            _objConexion.AddParameter("var_Numerodocumento", _objENConciliacion.NumeroDoc)
            _objConexion.AddParameter("var_IdCliente", _objENConciliacion.IdCliente)
            _objConexion.AddParameter("var_IdProveedor", _objENConciliacion.IdProveedor)
            _objConexion.AddParameter("var_IdDocumentoCompra", _objENConciliacion.IdDocumentoCompra)
            _objConexion.AddParameter("var_IdDocumentoVenta", _objENConciliacion.IddocumentoVenta)
            _objENConciliacion.IdConciliacion = _objConexion.EjecutarComandoSalida()
            Return True
        Catch ex As Exception
            _objError = ex
            Return False
        End Try

    End Function
    
    Public Function Listar() As Boolean
        Try
            _objConexion = New AccesoDatosSQLServer()
            _objConexion.Procedimiento = "dbo.ERP_usp_Conciliacion_Listar"
            _objConexion.AddParameter("var_IdMovimientoBanco", _objENConciliacion.IdBanco)
            _objConexion.AddParameter("var_IdMovimientoCaja", _objENConciliacion.IdCaja)
            _objConexion.AddParameter("var_IdCompra", _objENConciliacion.IdDocumentoCompra)
            _objConexion.AddParameter("var_IdVenta", _objENConciliacion.IddocumentoVenta)
            '_objConexion.AddParameter("var_Tipo", _objENConciliacion.Parametro)
            Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader
            _lstConciliacion = New List(Of EN_Conciliacion)
            Dim intCont As Integer = 0
            While odrDatos.Read
                intCont += 1
                _objENConciliacion = New EN_Conciliacion
                _objENConciliacion.intCont = intCont
                _objENConciliacion.NombreCliente = odrDatos("Cliente")
                _objENConciliacion.IdCliente = odrDatos("var_IdCliente")
                _objENConciliacion.Importe = odrDatos("dec_Importe")
                _objENConciliacion.IdTipodoc = odrDatos("var_IdTipoDocumento")
                _objENConciliacion.NumeroDoc = odrDatos("var_NumeroDocumento")
                _objENConciliacion.IdCuenta = odrDatos("var_IdCuenta")
                _objENConciliacion.IdComprobante = odrDatos("var_NumeroDocumento")
                _objENConciliacion.NombreProveedor = odrDatos("var_RazonSocial")
                _lstConciliacion.Add(_objENConciliacion)
            End While
            Return (_lstConciliacion.Count > 0)
        Catch ex As Exception
            _objError = ex
            Return False
        End Try

    End Function




#End Region
End Class
