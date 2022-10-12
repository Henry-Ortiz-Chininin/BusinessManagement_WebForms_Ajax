Imports AccesoDatos
Namespace Proceso.Produccion.Servicios
    Public Class DeTerceros
#Region "VARIABLES"
        Private _strIdServicio As String
        Private _strOrdenServicio As String
        Private _strFechaInicio As String
        Private _strFechaFinal As String
        Private _dblCantidad As Double
        Private _strIdProveedor As String
        Private _intSecuencialRuta As Int16
        Private _strCodigoOrden As String
        Private _intSecuenciaArticulo As Int16
        Private _strIdUnidadMedida As String
        Private _dblCosto As Double

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"

        Public Property IdServicio() As String
            Get
                Return _strIdServicio
            End Get
            Set(ByVal value As String)
                _strIdServicio = value
            End Set
        End Property
        Public Property OrdenServicio() As String
            Get
                Return _strOrdenServicio
            End Get
            Set(ByVal value As String)
                _strOrdenServicio = value
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
        Public Property FechaFinal() As String
            Get
                Return _strFechaFinal
            End Get
            Set(ByVal value As String)
                _strFechaFinal = value
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
        Public Property IdUnidadMedida() As String
            Get
                Return _strIdUnidadMedida
            End Get
            Set(ByVal value As String)
                _strIdUnidadMedida = value
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
        Public Property SecuencialRuta() As Int16
            Get
                Return _intSecuencialRuta
            End Get
            Set(ByVal value As Int16)
                _intSecuencialRuta = value
            End Set
        End Property
        Public Property CodigoOrden() As String
            Get
                Return _strCodigoOrden
            End Get
            Set(ByVal value As String)
                _strCodigoOrden = value
            End Set
        End Property
        Public Property SecuenciaArticulo() As Int16
            Get
                Return _intSecuenciaArticulo
            End Get
            Set(ByVal value As Int16)
                _intSecuenciaArticulo = value
            End Set
        End Property

        Public Property Costo As Double
            Get
                Return _dblCosto
            End Get
            Set(ByVal value As Double)
                _dblCosto = value
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

        'Public Property IdTipoDocumento() As String
        '    Get
        '        Return _strIdTipoDocumento
        '    End Get
        '    Set(ByVal value As String)
        '        _strIdTipoDocumento = value
        '    End Set
        'End Property
        'Public Property NumeroDocumento() As String
        '    Get
        '        Return _strNumeroDocumento
        '    End Get
        '    Set(ByVal value As String)
        '        _strNumeroDocumento = value
        '    End Set
        'End Property
#End Region

#Region "METODOS Y FUNCIONES"
        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdServicio", _strIdServicio, _
                                                    "var_OrdenServicio", _strOrdenServicio, _
                                                    "var_Inicio", _strFechaInicio, _
                                                    "var_Final", _strFechaFinal, _
                                                    "num_Cantidad", _dblCantidad, _
                                                    "var_IdUnidadMedida", _strIdUnidadMedida, _
                                                    "var_IdProveedor", _strIdProveedor, _
                                                    "int_SecuencialRuta", _intSecuencialRuta, _
                                                    "var_CodigoOrden", _strCodigoOrden, _
                                                    "int_SecuenciaArticulo", _intSecuenciaArticulo, _
                                                    "num_Costo", _dblCosto, _
                                                    "chr_Estado", _strEstado, _
                                                    "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_usp_Servicio_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdServicio", _strIdServicio}
                _objConexion.EjecutarComando("SGC_usp_Servicio_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdServicio", _strIdServicio}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Servicio_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _dblCantidad = _dtbDatos.Rows(0)("num_Cantidad")
                    _intSecuenciaArticulo = _dtbDatos.Rows(0)("int_SecuenciaArticulo")
                    _intSecuencialRuta = _dtbDatos.Rows(0)("int_SecuencialRuta")
                    _strCodigoOrden = _dtbDatos.Rows(0)("var_CodigoOrden")
                    _strFechaFinal = Format(_dtbDatos.Rows(0)("dtm_Final"), "dd/MM/yyyy")
                    _strFechaInicio = Format(_dtbDatos.Rows(0)("dtm_Inicio"), "dd/MM/yyyy")
                    _strIdProveedor = _dtbDatos.Rows(0)("var_IdProveedor")
                    _strIdServicio = _dtbDatos.Rows(0)("chr_IdServicio")
                    _strIdUnidadMedida = _dtbDatos.Rows(0)("var_IdUnidadMedida")
                    _strOrdenServicio = _dtbDatos.Rows(0)("var_OrdenServicio")
                    _dblCosto = _dtbDatos.Rows(0)("num_Costo")
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
                Dim objParametros() As String = {"var_CodigoOrden", _strCodigoOrden, _
                                                 "int_SecuencialRuta", _intSecuencialRuta, _
                                                 "int_SecuenciaArticulo", _intSecuenciaArticulo}

                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Servicio_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function


#End Region
    End Class
End Namespace


