Imports AccesoDatos
Namespace Proceso.Logistica.Kardex
    Public Class Resumen

#Region "VARIABLES"
        Private _strAnno As String
        Private _strMes As String
        Private _strIdTipoMovimiento As String
        Private _strIdArticulo As String
        Private _strIdAlmacen As String
        Private _dblCantidad As Double
        Private _dblCostoUnitario As Double
        Private _dblImporte As Double
        Private _strIdUnidadMedida As String
        Private _strFamilia As String
        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"

        Public Property Anno() As String
            Get
                Return _strAnno
            End Get
            Set(ByVal value As String)
                _strAnno = value
            End Set
        End Property
        Public Property Mes() As String
            Get
                Return _strMes
            End Get
            Set(ByVal value As String)
                _strMes = value
            End Set
        End Property
        Public Property IdTipoMovimiento() As String
            Get
                Return _strIdTipoMovimiento
            End Get
            Set(ByVal value As String)
                _strIdTipoMovimiento = value
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
        Public Property IdAlmacen() As String
            Get
                Return _strIdAlmacen
            End Get
            Set(ByVal value As String)
                _strIdAlmacen = value
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
        Public Property CostoUnitario() As Double
            Get
                Return _dblCostoUnitario
            End Get
            Set(ByVal value As Double)
                _dblCostoUnitario = value
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
        Public Property IdUnidadMedida() As String
            Get
                Return _strIdUnidadMedida
            End Get
            Set(ByVal value As String)
                _strIdUnidadMedida = value
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


        Public Property Familia() As String
            Get
                Return _strFamilia
            End Get
            Set(ByVal value As String)
                _strFamilia = value
            End Set
        End Property

#End Region

#Region "METODOS Y FUNCIONES"
        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"chr_Anno", _strAnno, _
                                                 "chr_Mes", _strMes, _
                                                 "var_IdTipoMovimiento", _strIdTipoMovimiento, _
                                                 "var_IdArticulo", _strIdArticulo, _
                                                 "num_Cantidad", _dblCantidad, _
                                                 "num_CostoUnitario", _dblCostoUnitario, _
                                                 "num_Importe", _dblImporte, _
                                                 "var_IdUnidadMedida", _strIdUnidadMedida, _
                                                 "var_IdAlmacen", _strIdAlmacen, _
                                                "chr_Estado", _strEstado, _
                                                "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_uspa_KardexResumen_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"chr_Anno", _strAnno, _
                                                 "chr_Mes", _strMes, _
                                                 "var_IdTipoMovimiento", _strIdTipoMovimiento, _
                                                 "var_IdArticulo", _strIdArticulo, _
                                                 "var_IdAlmacen", _strIdAlmacen}
                _objConexion.EjecutarComando("SGC_uspa_KardexResumen_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"chr_Anno", _strAnno, _
                                                 "chr_Mes", _strMes, _
                                                 "var_IdTipoMovimiento", _strIdTipoMovimiento, _
                                                 "var_IdArticulo", _strIdArticulo, _
                                                 "var_IdAlmacen", _strIdAlmacen}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspa_KardexResumen_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strAnno = _dtbDatos.Rows(0)("chr_Anno")
                    _strMes = _dtbDatos.Rows(0)("chr_IdMes")
                    _strIdAlmacen = _dtbDatos.Rows(0)("var_IdAlmacen")
                    _strIdTipoMovimiento = _dtbDatos.Rows(0)("var_IdTipoMovimiento")
                    _strIdArticulo = _dtbDatos.Rows(0)("var_IdArticulo")
                    _strIdUnidadMedida = _dtbDatos.Rows(0)("var_IdUnidadMedida")
                    _dblCantidad = _dtbDatos.Rows(0)("num_Cantidad")
                    _dblCostoUnitario = _dtbDatos.Rows(0)("num_CostoUnitario")
                    _dblImporte = _dtbDatos.Rows(0)("num_Importe")
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
                Dim objParametros() As String = {"chr_Anno", _strAnno, _
                                                 "chr_Mes", _strMes, _
                                                 "var_IdTipoMovimiento", _strIdTipoMovimiento, _
                                                 "var_IdArticulo", _strFamilia, _
                                                 "var_IdAlmacen", _strIdAlmacen, _
                                                 "var_IdArticulo1", _strIdArticulo}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspa_KardexResumen_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function ObtenerStock(ByVal pstr_IdFamilia As String, _
                                     ByVal pstr_IdSubFamilia As String, _
                                     ByVal pstr_IdArticulo As String, _
                                     ByVal pstr_Fecha As String, _
                                     ByVal pstr_Criterio As String) As Boolean
            Try
                If pstr_Criterio <> "" Then
                    pstr_Criterio = Replace(pstr_Criterio, " ", "%")
                End If

                Dim objParametros() As String = {"var_IdFamilia", pstr_IdFamilia, _
                                                 "var_IdSubFamilia", pstr_IdSubFamilia, _
                                                 "var_IdArticulo", pstr_IdArticulo, _
                                                 "var_Fecha", pstr_Fecha, _
                                                 "var_Criterio", pstr_Criterio}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspa_KardexArticulo_CalculoStock", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace

