
Imports AccesoDatos
Imports ALVI_LOGIC

Namespace Proceso.Logistica
    Public Class Documento

        Private _strIdDocumentoCompra As String
        Private _strIdProveedor As String
        Private _strDescripcionProveedor As String
        Private _dblSubtotal As Double
        Private _dblIGV As Double
        Private _dblOtros As Double
        Private _dblTotal As Double
        Private _intNumero1 As Integer
        Private _intNumero2 As Integer
        Private _strFechaVencimiento As String
        Private _strTipoDocumento As String
        Private _strMoneda As String
        Private _strOperacion As String
        Private _strEstado As String
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer
        Private _strNumero As String
        Private _dtbDatos As DataTable
        Private _strFechaEmision As String


        Public Property DescripcionProveedor() As String
            Get
                Return _strDescripcionProveedor
            End Get
            Set(ByVal value As String)
                _strDescripcionProveedor = value
            End Set
        End Property


        Public Property IdProveedor() As String
            Get
                Return _strIdProveedor
            End Get
            Set(ByVal value As String)
                _strIdProveedor = value
            End Set
        End Property

        Public Property IdDocumentoCompra() As String
            Get
                Return _strIdDocumentoCompra
            End Get
            Set(ByVal value As String)
                _strIdDocumentoCompra = value
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

        Public Property Otros() As Double
            Get
                Return _dblOtros
            End Get
            Set(ByVal value As Double)
                _dblOtros = value
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

        Public Property FechaVencimiento() As String
            Get
                Return _strFechaVencimiento
            End Get
            Set(ByVal value As String)
                _strFechaVencimiento = value
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
        Public Property Estado() As String
            Get
                Return _strEstado
            End Get
            Set(ByVal value As String)
                _strEstado = value
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

        Public Property Numero1() As Integer
            Get
                Return _intNumero1
            End Get
            Set(ByVal value As Integer)
                _intNumero1 = value
            End Set
        End Property

        Public Property Numero2() As Integer
            Get
                Return _intNumero2
            End Get
            Set(ByVal value As Integer)
                _intNumero2 = value
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

        Public Property Numero() As String
            Get
                Return _strNumero
            End Get
            Set(ByVal value As String)
                _strNumero = value
            End Set
        End Property


        Public Property TipoDocumento() As String
            Get
                Return _strTipoDocumento
            End Get
            Set(ByVal value As String)
                _strTipoDocumento = value
            End Set
        End Property


        Public Property Moneda() As String
            Get
                Return _strMoneda
            End Get
            Set(ByVal value As String)
                _strMoneda = value
            End Set
        End Property


        Public Property Operacion() As String
            Get
                Return _strOperacion
            End Get
            Set(ByVal value As String)
                _strOperacion = value
            End Set
        End Property

        Public ReadOnly Property exError() As String
            Get
                Return _exError.ToString
            End Get
        End Property

        Public Function Registrar(ByVal dtbdatos As Data.DataTable) As Boolean
            Try
                Dim objUtil As New General.Util

                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdDocumentoCompra", _strIdDocumentoCompra, _
                                                 "dtm_FechaEmision", _strFechaEmision, _
                                                 "dtm_FechaVencimiento", _strFechaVencimiento, _
                                                 "var_IdProveedor", _strIdProveedor, _
                                                 "chr_IdTipoDocumento", _strTipoDocumento, _
                                                  "var_IdMoneda", _strMoneda, _
                                                 "var_IdOperacion", _strOperacion, _
                                                 "var_NumeroDocumento", _strNumero, _
                                                 "dec_IGV", _dblIGV, _
                                                 "dec_Otro", _dblOtros, _
                                                 "dec_SubTotal", _dblSubtotal, _
                                                 "dec_Total", _dblTotal, _
                                                 "chr_IdEstado", _strEstado, _
                                                 "xml_Articulos", objUtil.GeneraXML(dtbdatos)}


                _strIdDocumentoCompra = _objConexion.ObtenerValor("SGC_usp_DocumentoCompra_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function



        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdDocumentoCompra", _strIdDocumentoCompra}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspa_DocumentoCompra_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdDocumentoCompra = _dtbDatos.Rows(0)("var_IdDocumentoCompra")
                    _strFechaEmision = _dtbDatos.Rows(0)("dtm_Fecha")
                    _strFechaVencimiento = _dtbDatos.Rows(0)("dtm_FechaVencimiento")
                    _strIdProveedor = _dtbDatos.Rows(0)("var_IdProveedor")
                    _strNumero = _dtbDatos.Rows(0)("var_NumeroDocumento")
                    _strTipoDocumento = _dtbDatos.Rows(0)("chr_IdTipoDocumento")
                    _strMoneda = _dtbDatos.Rows(0)("var_IdMoneda")
                    _strOperacion = _dtbDatos.Rows(0)("var_IdOperacion")
                    _dblSubtotal = _dtbDatos.Rows(0)("dec_SubTotal")
                    _dblTotal = _dtbDatos.Rows(0)("dec_Total")
                    _dblOtros = _dtbDatos.Rows(0)("dec_Otro")
                    _dblIGV = _dtbDatos.Rows(0)("dec_IGV")


                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function



        Public Function Listar() As Boolean
            Try
                Dim objParametros() As String = {"var_IdDocumentoCompra", _strIdDocumentoCompra}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspa_DocumentoCompra_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function




        Public Function Buscar(ByVal pstr_NumeroDocumento As String,
                     ByVal pstr_FechaEmisionInicio As String,
                     ByVal pstr_FechaEmisionFinal As String,
                     ByVal pstr_FechaVencimientoInicio As String,
                     ByVal pstr_FechaVencimientoFinal As String,
                     ByVal pstr_idProveedor As String) As Boolean
            Try
                Dim objParametros() As String = {"var_IdDocumentoCompra", pstr_NumeroDocumento, _
                                                 "var_FechaEmisionInicio", pstr_FechaEmisionInicio, _
                                                 "var_FechaEmisionFinal", pstr_FechaEmisionFinal, _
                                                 "var_FechaVencimientoInicio", pstr_FechaVencimientoInicio, _
                                                 "var_FechaVencimientoFinal", pstr_FechaVencimientoFinal, _
                                                 "var_IdProveedor", pstr_idProveedor
                                                 }
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_CompraDocumento_Buscar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function


        Public Function Actualizar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdDocumentoCompra", _strIdDocumentoCompra,
                                                 "char_IdEstado", _strEstado}
                _objConexion.EjecutarComando("SCP_usp_Documento_Actualizar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function


    End Class

End Namespace
