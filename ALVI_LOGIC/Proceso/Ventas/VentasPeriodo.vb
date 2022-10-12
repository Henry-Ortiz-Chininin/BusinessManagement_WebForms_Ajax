Imports AccesoDatos

Namespace Proceso.Ventas
    Public Class VentasPeriodo
#Region "VARIABLES"
        Private _strAnno As String
        Private _strMes As String
        Private _strComprobante As String
        Private _strFecha As String
        Private _strTipoDocumento As String
        Private _strNumeroDocumento As String
        Private _strRUC As String
        Private _strDescripcion As String
        Private _strOrden As String
        Private _dblIGV As Double
        Private _dblImporte As Double

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
       
        Public Property Comprobante As String
            Get
                Return _strComprobante
            End Get
            Set(ByVal value As String)
                _strComprobante = value
            End Set
        End Property
        Public Property Fecha As String
            Get
                Return _strFecha
            End Get
            Set(ByVal value As String)
                _strFecha = value
            End Set
        End Property
        Public Property TipoDocumento As String
            Get
                Return _strTipoDocumento
            End Get
            Set(ByVal value As String)
                _strTipoDocumento = value
            End Set
        End Property
        Public Property NumeroDocumento As String
            Get
                Return _strNumeroDocumento
            End Get
            Set(ByVal value As String)
                _strNumeroDocumento = value
            End Set
        End Property
        Public Property RUC As String
            Get
                Return _strRUC
            End Get
            Set(ByVal value As String)
                _strRUC = value
            End Set
        End Property
        Public Property Descripcion As String
            Get
                Return _strDescripcion
            End Get
            Set(ByVal value As String)
                _strDescripcion = value
            End Set
        End Property
        Public Property Orden As String
            Get
                Return _strOrden
            End Get
            Set(ByVal value As String)
                _strOrden = value
            End Set
        End Property
        Public Property IGV As Double
            Get
                Return _dblIGV
            End Get
            Set(ByVal value As Double)
                _dblIGV = value
            End Set
        End Property
        Public Property Importe As Double
            Get
                Return _dblImporte
            End Get
            Set(ByVal value As Double)
                _dblImporte = value
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
                Dim objParametros() As String = {"chr_Anno", _strAnno, _
                                                 "chr_Mes", _strMes, _
                                                 "var_Comprobante", _strComprobante, _
                                                 "var_Fecha", _strFecha, _
                                                 "var_TipoDocumento", _strTipoDocumento, _
                                                 "var_NumeroDocumento", _strNumeroDocumento, _
                                                 "var_RUC", _strRUC, _
                                                 "var_Descripcion", _strDescripcion, _
                                                 "var_Orden", _strOrden, _
                                                 "num_IGV", _dblIGV, _
                                                 "num_Importe", _dblImporte, _
                                                "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_usp_VentaPeriodo_Registrar", objParametros)

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
                                                 "var_Comprobante", _strComprobante}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_VentaPeriodo_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strAnno = _dtbDatos.Rows(0)("chr_Anno")
                    _strMes = _dtbDatos.Rows(0)("chr_Mes")
                    _strComprobante = _dtbDatos.Rows(0)("var_Comprobante")
                    _strFecha = _dtbDatos.Rows(0)("var_Fecha")
                    _strTipoDocumento = _dtbDatos.Rows(0)("var_TipoDocumento")
                    _strNumeroDocumento = _dtbDatos.Rows(0)("var_NumeroDocumento")
                    _strRUC = _dtbDatos.Rows(0)("var_RUC")
                    _strDescripcion = _dtbDatos.Rows(0)("var_Descripcion")
                    _strOrden = _dtbDatos.Rows(0)("var_Orden")
                    _dblIGV = _dtbDatos.Rows(0)("num_IGV")
                    _dblImporte = _dtbDatos.Rows(0)("num_Importe")

                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Listar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"chr_Anno", _strAnno, _
                                                 "chr_Mes", _strMes}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_VentaPeriodo_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class

End Namespace
