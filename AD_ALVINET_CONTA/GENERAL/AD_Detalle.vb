Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.GENERAL
Imports EN_ALVINET_CONTA
Imports System.Data
Imports System.Data.SqlClient


Namespace GENERAL


    Public Class AD_Detalle


        Private _objConexion As AccesoDatosSQLServer

        Public Function Listar(ByVal detalleDocumento As EN_CompraDetalle) As List(Of EN_CompraDetalle)

            Dim _lstDetalle = New List(Of EN_CompraDetalle)

            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspa_DocumentoCompraDetalle_Listar"
                _objConexion.AddParameter("var_IdDocumentoCompra", detalleDocumento.IdDocumentoCompra)

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()


                While odrDatos.Read

                    Dim _enDetalle = New EN_CompraDetalle

                    _enDetalle.IdDocumentoCompra = odrDatos("var_IdDocumentoCompra")
                    _enDetalle.IdDetalle = odrDatos("var_IdDetalle")
                    _enDetalle.IdArticulo = odrDatos("var_IdArticuloReferencia")
                    _enDetalle.IdArticuloProveedor = odrDatos("var_IdArticuloProveedor")
                    _enDetalle.NombreArticuloProveedor = odrDatos("var_NombreArticuloProveedor")
                    _enDetalle.Cantidad = odrDatos("int_Cantidad")
                    _enDetalle.Importe = odrDatos("num_ImporteTotal")
                    _enDetalle.ImporteOrigen = odrDatos("num_ImporteOrigen")
                    _enDetalle.Moneda = odrDatos("var_IdMoneda")
                    _enDetalle.TipoCambio = odrDatos("dec_TipoCambio")
                    _enDetalle.IdUnidadMedida = odrDatos("var_IdUnidadMedida")
                    _enDetalle.IdProveedor = odrDatos("var_IdProveedor")
                    _lstDetalle.Add(_enDetalle)

                End While

            Catch ex As Exception
                ' _objError = ex

            End Try

            Return _lstDetalle
        End Function


    End Class
End Namespace