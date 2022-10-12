Imports EN_ALVINET_CONTA
Imports AD_ALVINET_CONTA.AccesoDatos
Imports System.Data.SqlClient
Imports EN_ALVINET_CONTA.CONFIG

Public Class AD_MovimientoCaja
#Region "Variables"
    Private _objConexion As AccesoDatosSQLServer
    Private _entMovimientoCaja As New EN_MovimientoCaja
    Private _lstMovimientoCaja As List(Of EN_MovimientoCaja)
    Private _objError As New Exception

#End Region
#Region "Propiedades"


    Public ReadOnly Property lstMovimientoCaja() As List(Of EN_MovimientoCaja)
        Get
            Return _lstMovimientoCaja
        End Get
    End Property


    Public ReadOnly Property objError() As Exception
        Get
            Return _objError
        End Get
    End Property


    Public Property entMovimientoCaja() As EN_MovimientoCaja
        Get
            Return _entMovimientoCaja
        End Get
        Set(ByVal value As EN_MovimientoCaja)
            _entMovimientoCaja = value
        End Set
    End Property



#End Region
#Region "Metodos"
    Public Function Registrar() As Boolean
        Try
            _objConexion = New AccesoDatosSQLServer
            _objConexion.Procedimiento = "[dbo].[ERP_usp_Caja_Registrar]"
            _objConexion.AddParameter("var_Comprobante", _entMovimientoCaja.Comprobante)
            _objConexion.AddParameter("dec_Importe", _entMovimientoCaja.Importe)
            _objConexion.AddParameter("dtm_Fecha", entMovimientoCaja.Fecha)
            _objConexion.AddParameter("var_IdMoneda", entMovimientoCaja.IdMoneda)
            _objConexion.AddParameter("var_Observacion", entMovimientoCaja.Observacion)

            _entMovimientoCaja.IdCaja = _objConexion.EjecutarComandoSalida()
            Return True
        Catch ex As Exception
            _objError = ex
            Return False
        End Try
    End Function
    Public Function Eliminar() As Boolean
        Try
            _objConexion = New AccesoDatosSQLServer
            _objConexion.Procedimiento = "[dbo].[ERP_usp_ERP_utb_MovimientoCaja_Eliminar]"
            _objConexion.AddParameter("var_Id", _entMovimientoCaja.IdCaja)
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
            _objConexion.Procedimiento = "[dbo].[ERP_usp_utb_MovimientoCaja_Listar]"


            Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader
            _lstMovimientoCaja = New List(Of EN_MovimientoCaja)

            If Not odrDatos Is Nothing Then

                While odrDatos.Read
                    _entMovimientoCaja = New EN_MovimientoCaja
                    _entMovimientoCaja.Importe = odrDatos("dec_Importe")
                    _entMovimientoCaja.IdCaja = odrDatos("var_Id")
                    _entMovimientoCaja.FechaString = odrDatos("dtm_Fecha")
                    _entMovimientoCaja.Comprobante = odrDatos("var_Comprobante")
                    _entMovimientoCaja.Glosa = odrDatos("var_Descripcion")
                    _entMovimientoCaja.IdMoneda = odrDatos("var_IdMoneda")
                    _entMovimientoCaja.Observacion = odrDatos("var_Observacion")

                    _entMovimientoCaja.TotalC = odrDatos("dec_TotalC")
                    _entMovimientoCaja.SaldoC = odrDatos("num_SaldoC")
                    _entMovimientoCaja.PagoC = odrDatos("num_pagoC")

                    _entMovimientoCaja.TotalV = odrDatos("num_TotalV")
                    _entMovimientoCaja.SaldoV = odrDatos("num_SaldoV")
                    _entMovimientoCaja.PagoV = odrDatos("num_pagoV")


                    _lstMovimientoCaja.Add(_entMovimientoCaja)
                End While

            End If
            Return (_lstMovimientoCaja.Count > 0)

        Catch ex As Exception
            _objError = ex
            Return True
        End Try
    End Function

#End Region
End Class
