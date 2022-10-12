Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.GENERAL
Imports System.Data
Imports System.Data.SqlClient

Namespace GENERAL
    Public Class AD_Comprobante
#Region "Variable"
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstComprobantes As List(Of EN_Comprobante)
        Private _entComprobante As New EN_Comprobante
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstComprobantes As List(Of EN_Comprobante)
            Get
                Return _lstComprobantes
            End Get
        End Property

        Public Property entComprobante As EN_Comprobante
            Get
                Return _entComprobante
            End Get
            Set(ByVal Value As EN_Comprobante)
                _entComprobante = Value
            End Set
        End Property
#End Region
#Region "Funciones"
        Public Function BuscarDoc() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Documento_Buscar"

                _objConexion.AddParameter("var_IdTipodocumento", _entComprobante.IdTipoDocumento)
                _objConexion.AddParameter("var_IdComprobante", _entComprobante.IdComprobanteVenta)
                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstComprobantes = New List(Of EN_Comprobante)

                While odrDatos.Read

                    _entComprobante = New EN_Comprobante

                    _entComprobante.IdTipoDocumento = odrDatos("var_IdTipodocumento")
                    _entComprobante.IdComprobanteVenta = odrDatos("var_IdComprobante")
                    _entComprobante.IdMoneda = odrDatos("var_codMoneda")
                    _entComprobante.IdCliente = odrDatos("var_idCliente")
                    _entComprobante.Descripcion = odrDatos("var_Descripcion")
                    _entComprobante.Total = odrDatos("num_Total")
                    _entComprobante.FechaEmision = odrDatos("dtm_FechaEmision")

                    _lstComprobantes.Add(_entComprobante)
                End While

                Return (_lstComprobantes.Count > 0)
            Catch ex As Exception

                _objError = ex
                Return False

            End Try
        End Function
#End Region

    End Class
End Namespace