Imports AccesoDatos
Imports ALVI_LOGIC
Namespace Maestros.Ventas
    Public Class NotaCredito
#Region "VARIABLES"
        Private _strIdNota As String
        Private _strSerieNota As String
        Private _strNumeroNota As String
        Private _strIdComprobante As String
        Private _strSerieComprobante As String
        Private _strNumeroComprobante As String
        Private _strGlosa As String
        Private _dblTipoCambio As Double

        Private _strIdVendedor As String
        Private _strIdCliente As String
        Private _StrDesCliente As String
        Private _strDireccionCliente As String

        Private _strTipoOperacion As String
        Private _strIdMoneda As String
        Private _strEstadoNota As String
        Private _strIdMotivo As String
        Private _strIdTipoNota As String

        Private _strFechaEmision As String
        Private _strFechaInicio As String
        Private _strFechaFinal As String
        Private _strMaximo As String

        Private _dbltotalParcial As Double
        Private _dblDescuento As Double
        Private _dblSubtotal As Double
        Private _dblIGV As Double
        Private _dblTotal As Double

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _dtbAtributos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer
#End Region

#Region "PROPIEDADES"

        Public Property Idnota() As String
            Get
                Return _strIdNota
            End Get
            Set(ByVal value As String)
                _strIdNota = value
            End Set
        End Property
        Public Property SerieNota() As String
            Get
                Return _strSerieNota
            End Get
            Set(ByVal value As String)
                _strSerieNota = value
            End Set
        End Property
        Public Property Glosa() As String
            Get
                Return _strGlosa
            End Get
            Set(ByVal value As String)
                _strGlosa = value
            End Set
        End Property
        Public Property TipoCambio() As Double
            Get
                Return _dblTipoCambio
            End Get
            Set(ByVal value As Double)
                _dblTipoCambio = value
            End Set
        End Property
        Public Property NumeroNota() As String
            Get
                Return _strNumeroNota
            End Get
            Set(ByVal value As String)
                _strNumeroNota = value
            End Set
        End Property
        Public Property IdCliente() As String
            Get
                Return _strIdCliente
            End Get
            Set(ByVal value As String)
                _strIdCliente = value
            End Set
        End Property
        Public Property Cliente() As String
            Get
                Return _StrDesCliente
            End Get
            Set(ByVal value As String)
                _StrDesCliente = value
            End Set
        End Property
        Public Property DireccionCliente() As String
            Get
                Return _strDireccionCliente
            End Get
            Set(ByVal value As String)
                _strDireccionCliente = value
            End Set
        End Property
        Public Property TipoOperacion() As String
            Get
                Return _strTipoOperacion
            End Get
            Set(ByVal value As String)
                _strTipoOperacion = value
            End Set
        End Property
        Public Property idVendedor() As String
            Get
                Return _strIdVendedor
            End Get
            Set(ByVal value As String)
                _strIdVendedor = value
            End Set
        End Property
        Public Property idMoneda() As String
            Get
                Return _strIdMoneda
            End Get
            Set(ByVal value As String)
                _strIdMoneda = value
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
        Public Property IdMotivo() As String
            Get
                Return _strIdMotivo
            End Get
            Set(ByVal value As String)
                _strIdMotivo = value
            End Set
        End Property
        Public Property IdComprobante() As String
            Get
                Return _strIdComprobante
            End Get
            Set(ByVal value As String)
                _strIdComprobante = value
            End Set
        End Property
        Public Property SerieComprobante() As String
            Get
                Return _strSerieComprobante
            End Get
            Set(ByVal value As String)
                _strSerieComprobante = value
            End Set
        End Property
        Public Property NumeroComprobante() As String
            Get
                Return _strNumeroComprobante
            End Get
            Set(ByVal value As String)
                _strNumeroComprobante = value
            End Set
        End Property
        Public Property IdTipoNota() As String
            Get
                Return _strIdTipoNota
            End Get
            Set(ByVal value As String)
                _strIdTipoNota = value
            End Set
        End Property
        Public Property FechaEmision() As String
            Get
                Return _strFechaEmision
            End Get
            Set(ByVal value As String)
                _strFechaEmision = value
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
        Public Property Maximo() As String
            Get
                Return _strMaximo
            End Get
            Set(ByVal value As String)
                _strMaximo = value
            End Set
        End Property
        Public Property totalParcial() As Double
            Get
                Return _dbltotalParcial
            End Get
            Set(ByVal value As Double)
                _dbltotalParcial = value
            End Set
        End Property
        Public Property Descuento() As Double
            Get
                Return _dblDescuento
            End Get
            Set(ByVal value As Double)
                _dblDescuento = value
            End Set
        End Property
        Public Property Subtotal() As Double
            Get
                Return _dblSubtotal
            End Get
            Set(ByVal value As Double)
                _dblSubtotal = value
            End Set
        End Property
        Public Property IGV() As Double
            Get
                Return _dblIGV
            End Get
            Set(ByVal value As Double)
                _dblIGV = value
            End Set
        End Property
        Public Property Total() As Double
            Get
                Return _dblTotal
            End Get
            Set(ByVal value As Double)
                _dblTotal = value
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
        Public Property DatosArticulos() As DataTable
            Get
                Return _dtbAtributos
            End Get
            Set(ByVal value As DataTable)
                _dtbAtributos = value
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
        Public Function Registrar(ByVal dtbAtributos As DataTable) As Boolean
            Try
                Dim objGeneral As New General.Util
                Dim input As String = objGeneral.GeneraXML(dtbAtributos)
                Dim output As String = input.Replace("ñ", "&#241;")
                output = output.Replace("Ñ", "&#209;")
                output = output.Replace(",", "")
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As Object = {"var_IdNota", _strIdNota, _
                "var_SerieNota", _strSerieNota, _
                "var_NumeroNota", _strNumeroNota, _
                "var_IdCliente", _strIdCliente, _
                "var_idVendedor", _strIdVendedor, _
                "var_idMotivo", _strIdMotivo, _
                "var_TipoOperacion", _strTipoOperacion, _
                "var_codMoneda", _strIdMoneda, _
                "var_FechaEmision", _strFechaEmision, _
                "var_Estado", _strEstado, _
                "xml_Atributos", output, _
                "var_Usuario", _strUsuario, _
                "var_IdTipo", _strIdTipoNota, _
                "num_TotalParcial", _dbltotalParcial, _
                "num_Descuento", _dblDescuento, _
                "num_SubTotal", _dblSubtotal, _
                "num_IGV", _dblIGV, _
                "num_TipoCambio", _dblTipoCambio, _
                "var_Glosa", _strGlosa, _
                "num_Total", _dblTotal}
                _objConexion.EjecutarComando("SGC_uspe_NotaCredito_Registrar", objParametros)
                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdNota", _strIdNota}
                _objConexion.EjecutarComando("SGC_uspe_NotaCredito_Eliminar", objParametros)
                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdNota", _strIdNota}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_NotaCredito_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdNota = _dtbDatos.Rows(0)("var_IdNota")
                    _strSerieNota = _dtbDatos.Rows(0)("var_SerieNota")
                    _strEstado = _dtbDatos.Rows(0)("var_Estado")
                    _strNumeroNota = _dtbDatos.Rows(0)("var_NumeroNota")
                    _strIdCliente = _dtbDatos.Rows(0)("var_IdCliente")
                    _StrDesCliente = _dtbDatos.Rows(0)("var_DesCliente")
                    _strDireccionCliente = _dtbDatos.Rows(0)("var_Direccion")
                    _strIdVendedor = _dtbDatos.Rows(0)("var_idVendedor")
                    _strIdMoneda = _dtbDatos.Rows(0)("var_codMoneda")
                    _strIdMotivo = _dtbDatos.Rows(0)("var_idMotivo")
                    _strGlosa = _dtbDatos.Rows(0)("var_Glosa")
                    _strTipoOperacion = _dtbDatos.Rows(0)("var_TipoOperacion")
                    _dblIGV = Math.Round(_dtbDatos.Rows(0)("num_Igv"), 2)
                    _dblSubtotal = Math.Round(_dtbDatos.Rows(0)("num_SubTotal"), 2)
                    _dblDescuento = Math.Round(_dtbDatos.Rows(0)("num_Desc"), 2)
                    _dblTotal = Math.Round(_dtbDatos.Rows(0)("num_Total"), 2)
                    _dbltotalParcial = _dtbDatos.Rows(0)("num_TotalParcial")
                    _strFechaEmision = Format(_dtbDatos.Rows(0)("dtm_FechaEmision"), "dd/MM/yyyy")
                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function ObtenerAtributos() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdNota", _strIdNota}
                _dtbAtributos = _objConexion.ObtenerDataTable("SGC_uspe_NotaCreditoAtributo_Obtener", objParametros)
                Return (_dtbAtributos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function SerieMayor() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_NotaCredito_ObtenerMayor")
                If _dtbDatos.Rows.Count > 0 Then
                    _strMaximo = _dtbDatos.Rows(0)("var_Maximo")
                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Buscar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {
                                "var_IdNota", _strIdNota, _
                                "var_SerieNota", _strSerieNota, _
                                "var_NumeroNota", _strNumeroNota, _
                                "var_Cliente", _strIdCliente, _
                                "var_FechaInicio", _strFechaInicio, _
                                "var_FechaFinal", _strFechaFinal}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_NotaCredito_Buscar", objParametros)
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace
