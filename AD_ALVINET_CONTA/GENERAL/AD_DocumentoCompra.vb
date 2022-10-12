Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.GENERAL
Imports EN_ALVINET_CONTA
Imports System.Data
Imports System.Data.SqlClient

Namespace GENERAL

    Public Class AD_DocumentoCompra

        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstDocumentoCompras As New List(Of EN_DocumentoCompra)
        Private _objENDocumentoCompras As EN_DocumentoCompra

        Public ReadOnly Property lstDocumentoCompra() As List(Of EN_DocumentoCompra)
            Get
                Return _lstDocumentoCompras
            End Get
        End Property
        Public Property objENDocumentoCompras() As EN_DocumentoCompra
            Get
                Return _objENDocumentoCompras
            End Get
            Set(ByVal value As EN_DocumentoCompra)
                _objENDocumentoCompras = value
            End Set
        End Property

        Public Property objError() As Exception
            Get
                Return _objError
            End Get
            Set(ByVal value As Exception)
                _objError = value
            End Set
        End Property

        Public Function Registrar(ByVal dtbdatos As Data.DataTable) As Boolean

            If dtbdatos.Columns.IndexOf("var_Articulo") >= 0 Then
                dtbdatos.Columns.Remove("var_Articulo")
            End If

            Dim objUtil As New Util

            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_usp_DocumentoCompra_Registrar"

                _objConexion.AddParameter("var_IdEmpresa", _objENDocumentoCompras.IdEmpresa)
                _objConexion.AddParameter("var_IdEjercicioEmpresa", _objENDocumentoCompras.IdEjercicioEmpresa)
                _objConexion.AddParameter("var_IdContabilidad", _objENDocumentoCompras.IdContabilidad)
                _objConexion.AddParameter("var_IdDocumentoCompra", _objENDocumentoCompras.IdDocumentoCompra)
                _objConexion.AddParameter("dtm_FechaEmision", Convert.ToDateTime(_objENDocumentoCompras.FechaEmision))
                _objConexion.AddParameter("dtm_FechaVencimiento", Convert.ToDateTime(_objENDocumentoCompras.FechaVencimiento))
                _objConexion.AddParameter("var_IdProveedor", _objENDocumentoCompras.IdProveedor)
                _objConexion.AddParameter("chr_IdTipoDocumento", _objENDocumentoCompras.TipoDocumento)
                _objConexion.AddParameter("var_IdMoneda", _objENDocumentoCompras.Moneda)
                _objConexion.AddParameter("var_IdOperacion", _objENDocumentoCompras.Operacion)
                _objConexion.AddParameter("var_NumeroDocumento", _objENDocumentoCompras.Numero)
                _objConexion.AddParameter("dec_IGV", _objENDocumentoCompras.IGV)
                _objConexion.AddParameter("dec_Otro", _objENDocumentoCompras.Otros)
                _objConexion.AddParameter("dec_SubTotal", _objENDocumentoCompras.Subtotal)
                _objConexion.AddParameter("dec_Total", _objENDocumentoCompras.Total)
                _objConexion.AddParameter("chr_IdEstado", _objENDocumentoCompras.Estado)
                _objConexion.AddParameter("var_EsControlada", _objENDocumentoCompras.EsControlada)
                _objConexion.AddParameter("var_Observacion", _objENDocumentoCompras.Observacion)
                _objConexion.AddParameter("xml_Articulos", objUtil.GeneraXML(dtbdatos))

                ' Falta corregir lo campos de var_FechaModificacion y var_FechaDetraccion, 
                ' falta agregarlos al formulario

                _objConexion.AddParameter("num_TipoCambioDC", Convert.ToDecimal(_objENDocumentoCompras.TipoCambio.ToString()))
                _objConexion.AddParameter("num_Isc", _objENDocumentoCompras.ISC)
                _objConexion.AddParameter("num_BaseImponible", _objENDocumentoCompras.BaseImponible)
                _objConexion.AddParameter("var_FechaModificacion", _objENDocumentoCompras.FechaModificacion)
                _objConexion.AddParameter("dec_Adquisisiones", _objENDocumentoCompras.Adquisisiones)
                _objConexion.AddParameter("var_NumeroDetraccion", _objENDocumentoCompras.NumeroDetraccion)
                _objConexion.AddParameter("var_FechaDetraccion", _objENDocumentoCompras.FechaDetraccion)
                _objConexion.AddParameter("var_ContadoCredito", _objENDocumentoCompras.ContactoCredito)
                _objConexion.AddParameter("var_Cuotas", _objENDocumentoCompras.Cuotas)
                _objConexion.AddParameter("var_MontoCuota", _objENDocumentoCompras.MontoCuota)
                _objConexion.AddParameter("var_IdCentroCosto", _objENDocumentoCompras.IdCentroCosto)
                _objConexion.AddParameter("num_Saldo", _objENDocumentoCompras.Saldo)
                _objConexion.AddParameter("num_pago", _objENDocumentoCompras.Pago)
                _objENDocumentoCompras.IdDocumentoCompra = _objConexion.EjecutarComandoSalida()

                Return True

            Catch ex As Exception
                _objError = ex
                Return False
            End Try

        End Function
        Public Function Validar(ByVal objENDocumentoCompra As EN_DocumentoCompra) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "[SGC_usp_DocumentoCompra_Validar]"
                _objConexion.AddParameter("var_NumeroDocumento", objENDocumentoCompra.Numero)
                _objConexion.AddParameter("var_IdProveedor", objENDocumentoCompra.IdProveedor)
                _objConexion.AddParameter("chr_IdTipoDocumento", objENDocumentoCompra.IdTipoDocumento)
                objENDocumentoCompra.Salida = _objConexion.EjecutarComandoSalida()
                Return True

            Catch ex As Exception
                _objError = ex
                Return False
            End Try

        End Function

        Public Function BuscarDocumento(ByVal enDocumento As EN_DocumentoCompra) As List(Of EN_DocumentoCompra)
            Dim enDocumentoCompta As EN_DocumentoCompra
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspa_DocumentoCompra_Obtener"
                _objConexion.AddParameter("var_NumeroDocumento", enDocumento.Numero)
                _objConexion.AddParameter("var_IdAsiento", enDocumento.IdAsiento)
                _objConexion.AddParameter("chr_RUC", enDocumento.Ruc)
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader

                Dim intCont As Integer = 0
                If Not odrDatos Is Nothing Then
                    While odrDatos.Read
                        intCont += 1
                        enDocumentoCompta = New EN_DocumentoCompra
                        enDocumentoCompta.Nivel = intCont
                        enDocumentoCompta.IdCuenta = odrDatos("var_IdCuenta")
                        enDocumentoCompta.EsCargo = odrDatos("var_EsCargo")
                        enDocumentoCompta.Importe = odrDatos("dec_Importe")
                        enDocumentoCompta.Observacion = odrDatos("var_Observacion")
                        enDocumentoCompta.NumeroDocumento = odrDatos("var_IdDocumentoCompra")
                        enDocumentoCompta.IdAsiento = odrDatos("var_IdAsiento")

                        lstDocumentoCompra.Add(enDocumentoCompta)
                    End While
                End If

            Catch ex As Exception

            End Try
            Return lstDocumentoCompra
        End Function
        Public Function Obtener(ByVal enDocumentoCompra As EN_DocumentoCompra) As EN_DocumentoCompra

            Dim objENDocumentoCompra = New EN_DocumentoCompra()

            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "[dbo].[SGC_uspa_DocumentoCompra_Atributos_Obtener]"
                _objConexion.AddParameter("var_IdDocumentoCompra", enDocumentoCompra.IdDocumentoCompra)

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                While odrDatos.Read

                    objENDocumentoCompra.IdDocumentoCompra = odrDatos("var_IdDocumentoCompra")
                    objENDocumentoCompra.IdProveedor = odrDatos("var_IdProveedor")
                    objENDocumentoCompra.DesProveedor = odrDatos("var_Proveedor")
                    objENDocumentoCompra.FechaEmision = odrDatos("dtm_Fecha")
                    objENDocumentoCompra.FechaVencimiento = odrDatos("dtm_FechaVencimiento")
                    objENDocumentoCompra.Numero = odrDatos("var_NumeroDocumento")
                    objENDocumentoCompra.TipoDocumento = odrDatos("TipoDocumento")
                    objENDocumentoCompra.Moneda = odrDatos("var_IdMoneda")
                    objENDocumentoCompra.Operacion = odrDatos("var_IdSubOperacion")
                    objENDocumentoCompra.Subtotal = odrDatos("dec_SubTotal")
                    objENDocumentoCompra.Total = odrDatos("dec_Total")
                    objENDocumentoCompra.Otros = odrDatos("dec_Otro")
                    objENDocumentoCompra.IGV = odrDatos("dec_IGV")
                    objENDocumentoCompra.IdMoneda = odrDatos("var_IdMoneda")
                    objENDocumentoCompra.RazonSocial = odrDatos("var_RazonSocial")
                    objENDocumentoCompra.Cuotas = odrDatos("var_Cuotas")
                    objENDocumentoCompra.MontoCuota = odrDatos("var_MontoCuota")
                    objENDocumentoCompra.Cantidad = odrDatos("int_Cantidad")
                    objENDocumentoCompra.Importetotal = odrDatos("num_ImporteTotal")
                    objENDocumentoCompra.TipoCambio = odrDatos("dec_TipoCambio")
                    objENDocumentoCompra.DesCentroCosto = odrDatos("Centrocosto")
                    objENDocumentoCompra.IdCentroCosto = odrDatos("var_IdCentroCosto")
                    objENDocumentoCompra.EsControlada = odrDatos("var_EsControlada")
                    objENDocumentoCompra.ContactoCredito = odrDatos("var_ContadoCredito")
                    objENDocumentoCompra.Observacion = odrDatos("var_Observacion")
                    objENDocumentoCompra.Afecta = odrDatos("bol_Afecta")

                End While


            Catch ex As Exception
                '_objError = ex

            End Try

            Return objENDocumentoCompra

        End Function


        Public Function Listar(ByVal enDocumentoCompra As EN_DocumentoCompra) As List(Of EN_DocumentoCompra)
            'Try
            '    Dim objParametros() As String = {"var_IdDocumentoCompra", _strIdDocumentoCompra}
            '    _objConexion = New AccesoDatosSQLServer
            '    _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspa_DocumentoCompra_Listar", objParametros)

            '    Return (_dtbDatos.Rows.Count > 0)
            'Catch ex As Exception
            '    Me._exError = ex
            '    Return False
            'End Try

            Dim _lstDocCompra = New List(Of EN_DocumentoCompra)

            'Try
            '    _objConexion = New AccesoDatosSQLServer
            '    _objConexion.Procedimiento = "SGC_uspa_DocumentoCompra_Listar"
            '    _objConexion.AddParameter("var_IdDocumentoCompra", enDocumentoCompra.IdDocumentoCompra)

            '    Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

            '    While odrDatos.Read

            '        Dim dc = New EN_DocumentoCompra

            '        dc.IdArticulo = odrDatos("var_IdArticulo")
            '        dc.IdSubFamilia = odrDatos("var_IdSubFamilia")
            '        dc.IdUnidadMedida = odrDatos("var_IdUnidadMedida")
            '        dc.Descripcion = odrDatos("var_Descripcion")
            '        dc.Estado = odrDatos("chr_Estado")

            '        _lstDocCompra.Add(dc)

            '    End While

            'Catch ex As Exception
            '    ' _objError = ex

            'End Try

            Return _lstDocCompra


        End Function


        'Public Function Buscar(ByVal pstr_NumeroDocumento As String,
        '             ByVal pstr_FechaEmisionInicio As String,
        '             ByVal pstr_FechaEmisionFinal As String,
        '             ByVal pstr_FechaVencimientoInicio As String,
        '             ByVal pstr_FechaVencimientoFinal As String,
        '             ByVal pstr_idProveedor As String) As Boolean
        Public Function Buscar(ByVal enDocumentoCompra As EN_DocumentoCompra) As EN_DocumentoCompra
            'Try
            '    Dim objParametros() As String = {"var_IdDocumentoCompra", pstr_NumeroDocumento, _
            '                                     "var_FechaEmisionInicio", pstr_FechaEmisionInicio, _
            '                                     "var_FechaEmisionFinal", pstr_FechaEmisionFinal, _
            '                                     "var_FechaVencimientoInicio", pstr_FechaVencimientoInicio, _
            '                                     "var_FechaVencimientoFinal", pstr_FechaVencimientoFinal, _
            '                                     "var_IdProveedor", pstr_idProveedor
            '                                     }
            '    _objConexion = New AccesoDatosSQLServer
            '    _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_CompraDocumento_Buscar", objParametros)

            '    Return (_dtbDatos.Rows.Count > 0)
            'Catch ex As Exception
            '    Me._exError = ex
            '    Return False
            'End Try

            Dim dc = New EN_DocumentoCompra()

            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_usp_CompraDocumento_Buscar"

                _objConexion.AddParameter("var_IdDocumentoCompra", enDocumentoCompra.IdDocumentoCompra)
                _objConexion.AddParameter("var_FechaEmisionInicio", enDocumentoCompra.FechaEmision)
                _objConexion.AddParameter("var_FechaEmisionFinal", enDocumentoCompra.FechaEmision)
                _objConexion.AddParameter("var_FechaVencimientoInicio", enDocumentoCompra.FechaVencimiento)
                _objConexion.AddParameter("var_FechaVencimientoFinal", enDocumentoCompra.FechaVencimiento)
                _objConexion.AddParameter("var_IdProveedor", enDocumentoCompra.IdProveedor)

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()


                While odrDatos.Read

                    dc.IdDocumentoCompra = odrDatos("var_IdDocumentoCompra")
                    dc.IdProveedor = odrDatos("var_IdProveedor")
                    dc.DescripcionProveedor = odrDatos("RazonSocial")
                    dc.FechaVencimiento = odrDatos("dtm_FechaVencimiento")
                    dc.Numero = odrDatos("var_NumeroDocumento")
                    dc.Operacion = odrDatos("Documento")

                End While

            Catch ex As Exception
                '_objError = ex

            End Try

            Return dc



        End Function
        Public Function DocumentosListar()
            _objConexion = New AccesoDatosSQLServer
            _objConexion.Procedimiento = "[SGC_utb_DocumentoCompra_Buscar_Documentos]"
            _objConexion.AddParameter("Ruc", _objENDocumentoCompras.IdProveedor)
            _objConexion.AddParameter("RazonSocial", _objENDocumentoCompras.RazonSocial)
            Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader
            _lstDocumentoCompras = New List(Of EN_DocumentoCompra)
            If Not odrDatos Is Nothing Then
                Dim intCont As Integer = 0
                While odrDatos.Read
                    intCont += 1
                    _objENDocumentoCompras = New EN_DocumentoCompra
                    _objENDocumentoCompras.intCont = intCont
                    _objENDocumentoCompras.Numero = odrDatos("var_NumeroDocumento")
                    _objENDocumentoCompras.IdTipoDocumento = odrDatos("var_RazonSocial")
                    _objENDocumentoCompras.Ruc = odrDatos("chr_RUC")
                    _objENDocumentoCompras.Fecha = odrDatos("dtm_Fecha")
                    _objENDocumentoCompras.Total = odrDatos("dec_Total")

                    _lstDocumentoCompras.Add(_objENDocumentoCompras)

                End While

            End If
            Return (_lstDocumentoCompras.Count > 0)

        End Function
        Public Function BuscarxDocumento() As Boolean
            _objConexion = New AccesoDatosSQLServer
            _objConexion.Procedimiento = "dbo.SGC_utb_DocumentoCompra_Buscar"
            _objConexion.AddParameter("chr_IdTipoDocumento", _objENDocumentoCompras.IdTipoDocumento)
            _objConexion.AddParameter("var_NumeroDocumento", _objENDocumentoCompras.Numero)
            _objConexion.AddParameter("var_RazonSocial", _objENDocumentoCompras.RazonSocial)
            Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader
            _lstDocumentoCompras = New List(Of EN_DocumentoCompra)
            If Not odrDatos Is Nothing Then
                Dim intCont As Integer = 0
                While odrDatos.Read
                    intCont += 1
                    _objENDocumentoCompras = New EN_DocumentoCompra
                    _objENDocumentoCompras.intCont = intCont
                    _objENDocumentoCompras.Importe = odrDatos("num_ImporteTotal")
                    _objENDocumentoCompras.IdTipoDocumento = odrDatos("chr_IdTipoDocumento")
                    _objENDocumentoCompras.Total = odrDatos("dec_Total")
                    _objENDocumentoCompras.IdCuenta = odrDatos("IdCuenta")
                    _objENDocumentoCompras.Operacion = odrDatos("var_IdOperacion")
                    _objENDocumentoCompras.IdProveedor = odrDatos("var_IdProveedor")
                    _objENDocumentoCompras.Observasion = odrDatos("var_Observacion")
                    _objENDocumentoCompras.RazonSocial = odrDatos("var_RazonSocial")
                    _objENDocumentoCompras.Numero = odrDatos("var_NumeroDocumento")
                    _objENDocumentoCompras.IdDocumentoCompra = odrDatos("var_IdDocumentoCompra")
                    _objENDocumentoCompras.IdComprobante = odrDatos("var_IdDocumentoCompra")
                    _objENDocumentoCompras.NomMoneda = odrDatos("Moneda")
                    _objENDocumentoCompras.TipoCambio = odrDatos("dec_TipoCambio")
                    _lstDocumentoCompras.Add(_objENDocumentoCompras)

                End While

            End If
            Return (_lstDocumentoCompras.Count > 0)

        End Function
        Public Function BuscarxDocumentoDetalle() As Boolean
            _objConexion = New AccesoDatosSQLServer
            _objConexion.Procedimiento = "[dbo].[ERP_usp_DocumetoCompraDetalle_Listar]"
            _objConexion.AddParameter("var_IdDocumentoCompra", _objENDocumentoCompras.IdDocumentoCompra)
            Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader
            _lstDocumentoCompras = New List(Of EN_DocumentoCompra)
            If Not odrDatos Is Nothing Then
                Dim intCont As Integer = 0
                While odrDatos.Read
                    intCont += 1
                    _objENDocumentoCompras = New EN_DocumentoCompra
                    _objENDocumentoCompras.intCont = intCont
                    _objENDocumentoCompras.IdArticulo = odrDatos("var_IdArticulo")
                    _objENDocumentoCompras.NombreArticuloProveedor = odrDatos("var_Descripcion")
                    _objENDocumentoCompras.IdUnidadMedida = odrDatos("var_IdUnidadMedida")
                    _objENDocumentoCompras.NombreUnidadMedida = odrDatos("UnidadMedida")
                    _objENDocumentoCompras.IdArticuloProveedor = odrDatos("var_IdArticuloProveedor")
                    '_objENDocumentoCompras.NombreArticuloProveedor = odrDatos("var_NombreArticuloProveedor")
                    _objENDocumentoCompras.Cantidad = odrDatos("int_Cantidad")
                    _objENDocumentoCompras.ImporteOrigen = odrDatos("num_ImporteOrigen")
                    _objENDocumentoCompras.Moneda = odrDatos("var_IdMoneda")
                    _objENDocumentoCompras.Importetotal = odrDatos("num_ImporteTotal")
                    _objENDocumentoCompras.Importe = odrDatos("num_ImporteTotal")
                    _objENDocumentoCompras.TipoCambio = odrDatos("dec_TipoCambio")
                    _objENDocumentoCompras.Afecta = odrDatos("bol_Afecta")
                    _objENDocumentoCompras.Numero = odrDatos("var_IdDocumentoCompra")
                    _lstDocumentoCompras.Add(_objENDocumentoCompras)

                End While

            End If
            Return (_lstDocumentoCompras.Count > 0)

        End Function





    End Class
End Namespace