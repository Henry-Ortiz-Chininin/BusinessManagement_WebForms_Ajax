Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.CONFIG
Imports EN_ALVINET_CONTA.REPORTE
Imports System.Data.SqlClient



Namespace REPORTE
    Public Class AD_Reportes
#Region "Variables"
      Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Dim _lstVouchers As List(Of EN_Voucher)
        Dim _entVoucher As EN_Voucher
        Dim _lstComprobante As List(Of EN_Comprobante)
        Dim _entComprobante As EN_ALVINET_CONTA.REPORTE.EN_Comprobante
        Dim _enDocumentoCompras As EN_CompraDocumento
        Dim _lstDocumentoCompras As List(Of EN_CompraDocumento)
#End Region
#Region "Propiedades"
        Public ReadOnly Property lstVouchers() As List(Of EN_Voucher)
            Get
                Return _lstVouchers
            End Get
        End Property
        Public ReadOnly Property lstComprobantes() As List(Of EN_Comprobante)
            Get
                Return _lstComprobante
            End Get
        End Property
        Public ReadOnly Property lstDocumentoCompras() As List(Of EN_CompraDocumento)
            Get
                Return _lstDocumentoCompras
            End Get
        End Property
        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property
        Public Property entVoucher() As EN_Voucher
            Get
                Return _entVoucher
            End Get
            Set(ByVal value As EN_Voucher)
                _entVoucher = value
            End Set
        End Property
        Public Property entComprobante() As EN_Comprobante
            Get
                Return _entComprobante
            End Get
            Set(ByVal value As EN_Comprobante)
                _entComprobante = value
            End Set
        End Property
        Public Property enDocumentoCompras() As EN_CompraDocumento
            Get
                Return _enDocumentoCompras
            End Get
            Set(ByVal value As EN_CompraDocumento)
                _enDocumentoCompras = value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones"
        Public Function LibroDiario(ByVal ruc As String, ByVal razon As String) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "[dbo].[ERP_usp_Reporte_Libro_Diario]"
                _objConexion.AddParameter("chr_fechaIni", entVoucher.Fecinicio)
                _objConexion.AddParameter("chr_fechaFin", entVoucher.FecFinal)
                '_objConexion.AddParameter("var_IdNivel", entVoucher.IdNivel)
                Dim dr As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstVouchers = New List(Of EN_Voucher)
                Dim intCont As Integer = 0
                While dr.Read
                    intCont += 1
                    _entVoucher = New EN_Voucher
                    _entVoucher.IdAsiento = dr("VAR_IDASIENTO")
                    _entVoucher.Fecha = dr("dtm_Fecha")
                    _entVoucher.Glosa = dr("var_Observacion")
                    _entVoucher.Escargo = dr("var_EsCargo")
                    _entVoucher.IdCuentaContable = dr("var_IdCuenta")
                    _entVoucher.CuentaContable = dr("var_Descripcion")
                    _entVoucher.Total = dr("dec_Importe")
                    If _entVoucher.Escargo = "Ab" Then
                        _entVoucher.CuentaHaber = _entVoucher.Total
                    End If
                    If _entVoucher.Escargo = "Ca" Then
                        _entVoucher.CuentaDebe = _entVoucher.Total

                    End If
                    If intCont = 1 Then
                        _entVoucher.Fecha = Format(Date.Now, "dd/MM/yyyy")
                        _entVoucher.Ruc = ruc
                        _entVoucher.RazonSocial = razon
                        _entVoucher.PeriodoInicial = Convert.ToString(_entVoucher.FechaInicio)
                        _entVoucher.PeriodoFinal = Convert.ToString(_entVoucher.FechaFinal)
                    End If
                    _lstVouchers.Add(_entVoucher)

                End While
               
                Return (_lstVouchers.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function LibroMayor(ByVal ruc As String, ByVal razon As String) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "[dbo].[ERP_usp_Reporte_Libro_Mayor]"
                _objConexion.AddParameter("chr_fechaIni", _entVoucher.Fecinicio)
                _objConexion.AddParameter("chr_fechaFin", _entVoucher.FecFinal)
                _objConexion.AddParameter("var_IdCuentaIni", _entVoucher.CuentaInicio)
                _objConexion.AddParameter("var_IdCuentaFin", _entVoucher.CuentaFinal)

                Dim dr As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstVouchers = New List(Of EN_Voucher)
                Dim intCont As Integer = 0
                While dr.Read
                    intCont += 1
                    _entVoucher = New EN_Voucher
                    _entVoucher.IdAsiento = dr("VAR_IDASIENTO")
                    _entVoucher.Fecha = dr("dtm_Fecha")
                    _entVoucher.Glosa = dr("var_Observacion")
                    _entVoucher.Total = dr("dec_Importe")
                    _entVoucher.Escargo = dr("var_EsCargo")
                    _entVoucher.IdCuentaContable = dr("var_IdCuenta")
                    _entVoucher.CuentaContable = dr("var_Descripcion")
                    _entVoucher.IdOperacion = dr("var_IdOperacion")
                    '_entVoucher.IdConciliaci = dr("var_IdConciliacion")
                    If _entVoucher.Escargo = "Ab" Then
                        _entVoucher.CuentaHaber = _entVoucher.Total
                    End If
                    If _entVoucher.Escargo = "Ca" Then
                        _entVoucher.CuentaDebe = _entVoucher.Total
                    End If
                    If intCont = 1 Then
                        _entVoucher.Ruc = ruc
                        _entVoucher.RazonSocial = razon
                        _entVoucher.PeriodoInicial = Convert.ToString(_entVoucher.FechaInicio)
                        _entVoucher.PeriodoFinal = Convert.ToString(_entVoucher.FechaFinal)

                    End If
                    _lstVouchers.Add(_entVoucher)

                End While
             
                Return (_lstVouchers.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function ListarNivel() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim dr As SqlDataReader = _objConexion.ObtenerDataReader("[dbo].[ERP_usp_Lista_Nivel]")
                Dim _lstNivel As New List(Of EN_NivelPlan)
                Dim _ennivel As EN_NivelPlan

                While dr.Read
                    _ennivel = New EN_NivelPlan
                    _ennivel.IdNivel = dr("var_IdNivel")
                    _ennivel.Descripcion = dr("var_Descripcion")
                    _lstNivel.Add(_ennivel)
                End While
                Return (_lstNivel.Count > 0)
                Return True

            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function RegistroVentas(ByVal ruc As String, ByVal razon As String) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "[dbo].[ERP_usp_Reporte_Registro_Ventas]"
                _objConexion.AddParameter("chr_fechaIni", _entVoucher.Fecinicio)
                _objConexion.AddParameter("chr_fechaFin", _entVoucher.FecFinal)
                _objConexion.AddParameter("var_Descripcion", _entVoucher.Cliente)
                _objConexion.AddParameter("var_IdCliente", _entVoucher.IdCliente)

                Dim dr As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstVouchers = New List(Of EN_Voucher)
                Dim intcont As Integer = 0
                While dr.Read
                    intcont += 1
                    _entVoucher = New EN_Voucher
                    _entVoucher.IdAsiento = dr("CodigoUnico")
                    _entVoucher.Fecinicio = dr("dtm_FechaEmision")
                    _entVoucher.FecFinal = dr("dtm_FechaVencimiento")
                    _entVoucher.IdComprobante = dr("var_IdComprobante")
                    _entVoucher.Glosa = dr("Tipo")
                    _entVoucher.IdCliente = dr("var_IdCliente")
                    _entVoucher.Cliente = dr("Cliente")
                    _entVoucher.Total = dr("num_Total")
                    _entVoucher.SubTotal = dr("num_SubTotal")
                    _entVoucher.IGV = dr("num_Igv")
                    _entVoucher.TipoCambio = dr("num_TipoCambio").ToString

                    If intcont = 1 Then
                        _entVoucher.Fecha = Format(Date.Now, "dd/MM/yyyy")
                        _entVoucher.Ruc = ruc
                        _entVoucher.RazonSocial = razon
                        _entVoucher.PeriodoInicial = Convert.ToString(_entVoucher.FechaInicio)
                        _entVoucher.PeriodoFinal = Convert.ToString(_entVoucher.FechaFinal)
                    End If

                    _lstVouchers.Add(_entVoucher)
                End While

                Return (_lstVouchers.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function RegistroVentasIngreso() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Reporte_Registro_Ventas_Ingreso"
                _objConexion.AddParameter("var_FechaInicio", _entComprobante.Fechainicio)
                _objConexion.AddParameter("var_FechaFin", _entComprobante.FechaFinal)
                _objConexion.AddParameter("var_IdEmpresa", _entComprobante.IdEmpresa)
                Dim intcont As Integer = 0
                Dim drDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstComprobante = New List(Of EN_Comprobante)
                While (drDatos.Read)
                    intcont += 1
                    _entComprobante = New EN_Comprobante
                    _entComprobante.IdComprobanteVenta = drDatos("CodigoUnico")
                    _entComprobante.FechaEmision = drDatos("FechaEmision")
                    _entComprobante.FechaVencimiento = drDatos("FechaVencimiento")
                    _entComprobante.IdTipoDoc = drDatos("TipoDocumento")
                    _entComprobante.Numero = drDatos("NumeroSerie")
                    _entComprobante.NumeroDoc2 = drDatos("NumeroDocumento")
                    _entComprobante.TipoDocIdent = drDatos("TipoDocIdent")
                    _entComprobante.NumeroDocIdent = drDatos("NumeroDocIdent")
                    _entComprobante.NombreCliente = drDatos("NombreCliente")
                    _entComprobante.ValorExportacion = drDatos("ValorFacExporta")
                    _entComprobante.BaseImponible = drDatos("BaseImpoOperacion")
                    _entComprobante.Exonerado = drDatos("Exonerada")
                    _entComprobante.Inafecta = drDatos("Inafecta")
                    _entComprobante.ISC = drDatos("ISC")
                    _entComprobante.IGV = drDatos("IGV")
                    _entComprobante.OtrosImportes = drDatos("OtrosImportes")
                    _entComprobante.Total = drDatos("Importe")
                    _entComprobante.TipoCambio = drDatos("TipoCambio")
                    _entComprobante.FechaModificacion = drDatos("FechaModificacion")
                    _entComprobante.IdTipoDocumento = drDatos("TipoDocumento")
                    _entComprobante.NumeroDoc3 = drDatos("NumeroSerie")
                    _entComprobante.NumeroDoc4 = drDatos("NumeroDoc")
                    _entComprobante.Periodo = drDatos("Periodo")
                    _entComprobante.Ruc = drDatos("RUC")
                    _entComprobante.RazonSocial = drDatos("RazonSocial")
                    _entComprobante.TotalExportado = drDatos("TotalExportacion")
                    _entComprobante.TotalBaseImponible = drDatos("TotalBaseImponible")
                    _entComprobante.TotalExonerado = drDatos("TotalExonerado")
                    _entComprobante.TotalInafecta = drDatos("TotalInafecta")
                    _entComprobante.TotalISC = drDatos("TotalISC")
                    _entComprobante.TotalIGV = drDatos("TotalIGV")
                    _entComprobante.TotalOtrosImportes = drDatos("TotalOtrosImportes")
                    _entComprobante.TotalImportes = drDatos("TotalImportes")

                    If intcont = 1 Then
                        _entComprobante.PeriodoInicial = Convert.ToString(_entComprobante.Fechainicio)
                        _entComprobante.PeriodoFinal = Convert.ToString(_entComprobante.FechaFinal)
                    End If

                    _lstComprobante.Add(_entComprobante)
                End While
                Return (_lstComprobante.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function RegistroCompras() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Reporte_Registro_Compras"
                _objConexion.AddParameter("var_FechaInicio", _enDocumentoCompras.FechaInicio)
                _objConexion.AddParameter("var_FechaFin", _enDocumentoCompras.FechaFin)
                _objConexion.AddParameter("var_IdEmpresa", _enDocumentoCompras.IdEmpresa)

                Dim drDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstDocumentoCompras = New List(Of EN_CompraDocumento)
                While (drDatos.Read)
                    _enDocumentoCompras = New EN_CompraDocumento
                    _enDocumentoCompras.IdDocumentoCompra = drDatos("CodigoUnico")
                    _enDocumentoCompras.FechaEmision = drDatos("FechaEmision")
                    _enDocumentoCompras.FechaVencimiento = drDatos("FechaVencimiento")
                    _enDocumentoCompras.IdTipoDocumento = drDatos("TipoDocumento")
                    _enDocumentoCompras.Numero1 = drDatos("NumeroSerie")
                    _enDocumentoCompras.AnioDua = drDatos("AnioDua")
                    _enDocumentoCompras.Numero2 = drDatos("NumeroDocumento")
                    _enDocumentoCompras.IdDocIdenPro = drDatos("TipoDocIdentProv")
                    _enDocumentoCompras.NumDocIdenPro = drDatos("NumDocIdentProv")
                    _enDocumentoCompras.DescripcionProveedor = drDatos("RazonSocial")
                    _enDocumentoCompras.BaseImponible = drDatos("BaseImpoOperacion_AGDOGE")
                    _enDocumentoCompras.IGV = drDatos("IGV_AGDOGE")
                    _enDocumentoCompras.BaseImponible2 = drDatos("BaseImpoOperacion_AGDOGENG")
                    _enDocumentoCompras.IGV2 = drDatos("IGV_AGDOGENG")
                    _enDocumentoCompras.BaseImponible3 = drDatos("BaseImpoOperacion_AGDONG")
                    _enDocumentoCompras.IGV3 = drDatos("IGV_AGDONG")
                    _enDocumentoCompras.Adquisisiones = drDatos("AdquisionNoGravada")
                    _enDocumentoCompras.ISC = drDatos("ISC")
                    _enDocumentoCompras.Otros = drDatos("OtrosImportes")
                    _enDocumentoCompras.Total = drDatos("Importe")
                    _enDocumentoCompras.NumComproSujNoDom = drDatos("NumComprobanteEmiSujNoDociliado")
                    _enDocumentoCompras.NumeroDetraccion = drDatos("NumeroCostanciaDepos")
                    _enDocumentoCompras.FechaDetraccion = drDatos("FechaEmisionCostanciaDepos")
                    _enDocumentoCompras.TipoCambio = drDatos("TipoCambio")
                    _enDocumentoCompras.FechaModificacion = drDatos("FechaModificacion")
                    _enDocumentoCompras.IdTipoDocumentoRC = drDatos("TipoDocumento")
                    _enDocumentoCompras.NumeroRC1 = drDatos("NumeroSerie")
                    _enDocumentoCompras.NumeroRC2 = drDatos("NumeroDoc")
                    _enDocumentoCompras.Periodo = drDatos("Periodo")
                    _enDocumentoCompras.RucEm = drDatos("RUC")
                    _enDocumentoCompras.RazonSocialEm = drDatos("RazonSocial")
                    _enDocumentoCompras.TotalBaseImponible1 = drDatos("TotalBaseImponible1")
                    _enDocumentoCompras.TotalIGV1 = drDatos("TotalIGV1")
                    _enDocumentoCompras.TotalBaseImponible2 = drDatos("TotalBaseImponible2")
                    _enDocumentoCompras.TotalIGV2 = drDatos("TotalIGV2")
                    _enDocumentoCompras.TotalBaseImponible3 = drDatos("TotalBaseImponible3")
                    _enDocumentoCompras.TotalIGV3 = drDatos("TotalIGV3")
                    _enDocumentoCompras.TotalAdquisision = drDatos("TotalAdquisision")
                    _enDocumentoCompras.TotalISC = drDatos("TotalISC")
                    _enDocumentoCompras.TotalOtros = drDatos("TotalOtros")
                    _enDocumentoCompras.TotalImporteTotal = drDatos("TotalImporteTotal")

                    _lstDocumentoCompras.Add(_enDocumentoCompras)
                End While
                Return (_lstDocumentoCompras.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function

        Public Function LibroDiario51(ByVal pstrIdEmpresa As String, _
                                       ByVal pstrIdEjercicio As String, _
                                       ByVal pstrIdContabilidad As String, _
                                       ByVal pint_Mes As Int16) As DataTable

            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_LibroDiario_Obtener"
                _objConexion.AddParameter("var_IdEmpresa", pstrIdEmpresa)
                _objConexion.AddParameter("var_IdEjercicio", pstrIdEjercicio)
                _objConexion.AddParameter("var_IdContabilidad", pstrIdContabilidad)
                _objConexion.AddParameter("int_Mes", pint_Mes)

                Return _objConexion.ObtenerDataTable

            Catch ex As Exception
                _objError = ex
                Return Nothing
            End Try

        End Function



#End Region

    End Class
End Namespace