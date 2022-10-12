Imports EN_ALVINET_CONTA
Imports AD_ALVINET_CONTA.AccesoDatos
Imports System.Data.SqlClient
Imports System.Data
Imports EN_ALVINET_CONTA.CONFIG

Public Class AD_MovimientoBancario
#Region "Variables"
    Private _lstMovimientoBancario As List(Of EN_MovimientoBancario)

    Private _entMovimientoBancario As New EN_MovimientoBancario
    Private _objError As New Exception
    Private _objConexion As AccesoDatosSQLServer
    Private _objbase As New EN_Base


#End Region
#Region "Propiedades"
    Public Property objBase() As EN_Base
        Get
            Return _objbase
        End Get
        Set(ByVal value As EN_Base)
            _objbase = value
        End Set
    End Property
    Public ReadOnly Property lstMovimientoBancario() As List(Of EN_MovimientoBancario)
        Get
            Return _lstMovimientoBancario
        End Get
    End Property
    Public Property entMovimientoBancario() As EN_MovimientoBancario
        Get
            Return _entMovimientoBancario
        End Get
        Set(ByVal value As EN_MovimientoBancario)
            _entMovimientoBancario = value
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
            _objConexion.Procedimiento = "dbo.ERP_usp_MovimientoBanco_Registrar"
            _objConexion.AddParameter("var_Id", _entMovimientoBancario.IdBanco)
            _objConexion.AddParameter("var_IdEntidadFinanciera", _entMovimientoBancario.IdEntidadFinanciera)
            _objConexion.AddParameter("var_Comprobante", _entMovimientoBancario.Comprobante)
            _objConexion.AddParameter("int_IdSecuencia", _entMovimientoBancario.IdMovimiento)
            _objConexion.AddParameter("dec_Importe", _entMovimientoBancario.Importe)
            _objConexion.AddParameter("dtm_Fecha", _entMovimientoBancario.Fecha)
            _objConexion.AddParameter("var_IdMoneda", _entMovimientoBancario.IdMoneda)
            _objConexion.AddParameter("var_Observacion", _entMovimientoBancario.Observacion)
            _objConexion.AddParameter("var_IdMedioPago", _entMovimientoBancario.IdMedioPago)
            _objConexion.AddParameter("var_IdDetraccion", "")
            _entMovimientoBancario.IdBanco = _objConexion.EjecutarComandoSalida()
            Return True
        Catch ex As Exception
            _objError = ex
            Return False
        End Try

    End Function
    Public Function Eliminar() As Boolean
        Try
            _objConexion = New AccesoDatosSQLServer()
            _objConexion.Procedimiento = "dbo.ERP_usp_MovimientoBanco_Eliminar"
            _objConexion.AddParameter("var_Id", _entMovimientoBancario.IdBanco)
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
            _objConexion.Procedimiento = "dbo.ERP_usp_MovimientoBanco_Listar"
            Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader
            _lstMovimientoBancario = New List(Of EN_MovimientoBancario)
            If Not odrDatos Is Nothing Then

                While odrDatos.Read
                    _entMovimientoBancario = New EN_MovimientoBancario
                    _entMovimientoBancario.IdMovimiento = odrDatos("var_Id")
                    _entMovimientoBancario.NombreBanco = odrDatos("var_Descripcion")
                    _entMovimientoBancario.IdBanco = odrDatos("var_IdEntidadFinanciera")
                    _entMovimientoBancario.Comprobante = odrDatos("var_Comprobante")
                    _entMovimientoBancario.Fecha = odrDatos("dtm_Fecha")

                    _entMovimientoBancario.IdMoneda = odrDatos("var_IdMoneda")
                    _entMovimientoBancario.Moneda = odrDatos("Moneda")
                    _entMovimientoBancario.CuentaEntidad = odrDatos("var_NumeroCuenta")
                    _entMovimientoBancario.Observacion = odrDatos("var_Observacion")
                    _entMovimientoBancario.IdMovimiento = odrDatos("int_IdSecuencia")
                    _entMovimientoBancario.IdMedioPago = odrDatos("var_IdMedioPago")
                    _entMovimientoBancario.Importe = odrDatos("Importe")
                    _entMovimientoBancario.Saldo = odrDatos("Saldo")
                    _entMovimientoBancario.IdTipoDocumento = odrDatos("var_IdComprobante")
                    _entMovimientoBancario.NumeroDocumento = odrDatos("var_IdDocumentoCompra")

                    _lstMovimientoBancario.Add(_entMovimientoBancario)
                End While

            End If
            Return (_lstMovimientoBancario.Count > 0)

        Catch ex As Exception
            _objError = ex
            Return False
        End Try
    End Function



#End Region
End Class
