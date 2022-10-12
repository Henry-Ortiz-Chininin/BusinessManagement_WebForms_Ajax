Imports AccesoDatos

Namespace Proceso.Logistica.Kardex
    Public Class Detalle
#Region "VARIABLES"
        Private _strIdKardex As String
        Private _strIdArticulo As String
        Private _strIdUnidadMedida As String
        Private _dblCantidad As Double
        Private _dblImporteMoneda As Double
        Private _dblTipoCambio As Double
        Private _strMoneda As String
        Private _dblImporte As Double
        Private _dblCostoUnitario As Double
        Private _strIdOrdenProduccion As String
        Private _strIdAlmacen As String
        Private _strIdCentroCosto As String
        Private _strIdCuentaGasto As String
        Private _strObservacion As String

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"

        Public Property IdKardex() As String
            Get
                Return _strIdKardex
            End Get
            Set(ByVal value As String)
                _strIdKardex = value
            End Set
        End Property
        Public Property IdArticulo() As String
            Get
                Return _strIdArticulo
            End Get
            Set(ByVal value As String)
                _strIdArticulo = value
            End Set
        End Property
        Public Property IdUnidadMedida() As String
            Get
                Return _strIdUnidadMedida
            End Get
            Set(ByVal value As String)
                _strIdUnidadMedida = value
            End Set
        End Property
        Public Property Cantidad() As Double
            Get
                Return _dblCantidad
            End Get
            Set(ByVal value As Double)
                _dblCantidad = value
            End Set
        End Property
        Public Property Observacion() As String
            Get
                Return _strObservacion
            End Get
            Set(ByVal value As String)
                _strObservacion = value
            End Set
        End Property

        Public Property Importe() As Double
            Get
                Return _dblImporte
            End Get
            Set(ByVal value As Double)
                _dblImporte = value
            End Set
        End Property
        Public Property ImporteMoneda As Double
            Get
                Return _dblImporteMoneda
            End Get
            Set(ByVal value As Double)
                _dblImporteMoneda = value
            End Set
        End Property

        Public Property TipoCambio As Double
            Get
                Return _dblTipoCambio
            End Get
            Set(ByVal value As Double)
                _dblTipoCambio = value
            End Set
        End Property

        Public Property Moneda As String
            Get
                Return _strMoneda
            End Get
            Set(ByVal value As String)
                _strMoneda = value
            End Set
        End Property

        Public Property CostoUnitario() As Double
            Get
                Return _dblCostoUnitario
            End Get
            Set(ByVal value As Double)
                _dblCostoUnitario = value
            End Set
        End Property
        Public Property IdOrdenProduccion() As String
            Get
                Return _strIdOrdenProduccion
            End Get
            Set(ByVal value As String)
                _strIdOrdenProduccion = value
            End Set
        End Property
        Public Property IdAlmacen() As String
            Get
                Return _strIdAlmacen
            End Get
            Set(ByVal value As String)
                _strIdAlmacen = value
            End Set
        End Property
        Public Property IdCentroCosto() As String
            Get
                Return _strIdCentroCosto
            End Get
            Set(ByVal value As String)
                _strIdCentroCosto = value
            End Set
        End Property
        Public Property IdCuentaGasto() As String
            Get
                Return _strIdCuentaGasto
            End Get
            Set(ByVal value As String)
                _strIdCuentaGasto = value
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

        Public Property Datos() As DataTable
            Get
                Return _dtbDatos
            End Get
            Set(ByVal value As DataTable)
                _dtbDatos = value
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
        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As Object = {"chr_IdKardex", _strIdKardex, _
                                                 "var_IdArticulo", _strIdArticulo, _
                                                 "var_IdUnidadMedida", _strIdUnidadMedida, _
                                                 "num_Cantidad", _dblCantidad, _
                                                 "num_ImporteMoneda", _dblImporteMoneda, _
                                                 "num_TipoCambio", _dblTipoCambio, _
                                                 "chr_Moneda", _strMoneda, _
                                                 "num_Importe", _dblImporte, _
                                                 "num_CostoUnitario", _dblCostoUnitario, _
                                                 "var_IdAlmacen", _strIdAlmacen, _
                                                 "var_IdCentroCosto", _strIdCentroCosto, _
                                                 "var_IdCuentaGasto", _strIdCuentaGasto, _
                                                 "var_Observacion", _strObservacion, _
                                                "chr_Estado", _strEstado, _
                                                "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_uspa_KardexDetalle_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"chr_IdKardex", _strIdKardex, _
                                                 "var_IdArticulo", _strIdArticulo}
                _objConexion.EjecutarComando("SGC_uspa_KardexDetalle_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"chr_IdKardex", _strIdKardex, _
                                                 "var_IdArticulo", _strIdArticulo}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspa_KardexDetalle_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdAlmacen = _dtbDatos.Rows(0)("var_IdAlmacen")
                    _strIdKardex = _dtbDatos.Rows(0)("chr_IdKardex")
                    _strIdArticulo = _dtbDatos.Rows(0)("var_IdArticulo")
                    _strIdCentroCosto = _dtbDatos.Rows(0)("var_IdCentroCosto")
                    _strIdCuentaGasto = _dtbDatos.Rows(0)("var_IdCuentaGasto")
                    _strIdUnidadMedida = _dtbDatos.Rows(0)("var_IdUnidadMedida")
                    _dblCantidad = _dtbDatos.Rows(0)("num_Cantidad")
                    _dblCostoUnitario = _dtbDatos.Rows(0)("num_CostoUnitario")
                    _dblImporteMoneda = _dtbDatos.Rows(0)("num_ImporteMoneda")
                    _dblTipoCambio = _dtbDatos.Rows(0)("num_TipoCambio")
                    _strMoneda = _dtbDatos.Rows(0)("chr_Moneda")
                    _dblImporte = _dtbDatos.Rows(0)("num_Importe")
                    _strObservacion = _dtbDatos.Rows(0)("var_IdObservacion")
                    _strEstado = _dtbDatos.Rows(0)("chr_Estado")

                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Listar() As Boolean
            Try
                Dim objParametros() As String = {"chr_IdKardex", _strIdKardex}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspa_KardexDetalle_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function ListarPeriodo(ByVal pstrAnno As String, ByVal pstrMes As String) As Boolean
            Try
                Dim objParametros() As String = {"chr_Anno", pstrAnno, "chr_Mes", pstrMes}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspa_KardexDetalle_Periodo", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Busqueda(ByVal pstrFechaInicio As String, ByVal pstrFechaFinal As String, _
                                 ByVal pstrIdTipoMovimiento As String, ByVal pstrIdFamilia As String, _
                                 ByVal pstrIdSubFamilia As String, ByVal pstrIdCentroCosto As String, ByVal pstrIdCuentaGasto As String) As Boolean
            Try
                Dim objParametros() As String = {"var_FechaInicio", pstrFechaInicio, _
                                                 "var_FechaFinal", pstrFechaFinal, _
                                                 "var_IdTipoMovimiento", pstrIdTipoMovimiento, _
                                                 "var_IdFamilia", pstrIdFamilia, _
                                                 "var_IdSubFamilia", pstrIdSubFamilia, _
                                                 "var_IdCentroCosto", pstrIdCentroCosto, _
                                                 "var_IdCuentaGasto", pstrIdCuentaGasto}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspa_KardexDetalle_Buscar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace

