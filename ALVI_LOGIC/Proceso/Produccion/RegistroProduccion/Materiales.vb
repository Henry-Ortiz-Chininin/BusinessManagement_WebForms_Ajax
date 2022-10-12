Imports AccesoDatos

Namespace Proceso.Produccion.RegistroProduccion
    Public Class Materiales
#Region "VARIABLES"
        Private _strIdProduccion As String
        Private _strFechaInicio As String
        Private _strFechaFinal As String
        Private _strHoraInicio As String
        Private _strHoraFinal As String
        Private _dblCantidad As Double
        Private _intSecuencialRuta As Int16
        Private _strCodigoOrden As String
        Private _intSecuenciaArticulo As Int16
        Private _strIdUnidadMedida As String

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"
        Public Property IdProduccion() As String
            Get
                Return _strIdProduccion
            End Get
            Set(ByVal value As String)
                _strIdProduccion = value
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
        Public Property HoraInicio() As String
            Get
                Return _strHoraInicio
            End Get
            Set(ByVal value As String)
                _strHoraInicio = value
            End Set
        End Property
        Public Property HoraFinal() As String
            Get
                Return _strHoraFinal
            End Get
            Set(ByVal value As String)
                _strHoraFinal = value
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
#End Region

#Region "METODOS Y FUNCIONES"
        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdProduccion", _strIdProduccion, _
                                                 "var_Inicio", _strFechaInicio & " " & _strHoraInicio, _
                                                 "var_Final", _strFechaFinal & " " & _strHoraFinal, _
                                                 "num_Cantidad", _dblCantidad, _
                                                 "int_SecuencialRuta", _intSecuencialRuta, _
                                                 "var_CodigoOrden", _strCodigoOrden, _
                                                 "int_SecuenciaArticulo", _intSecuenciaArticulo, _
                                                 "var_IdUnidadMedida", _strIdUnidadMedida, _
                                                 "chr_Estado", _strEstado, _
                                                 "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_usp_Produccion_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdProduccion", _strIdProduccion}
                _objConexion.EjecutarComando("SGC_usp_Produccion_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdProduccion", _strIdProduccion}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Produccion_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdProduccion = _dtbDatos.Rows(0)("chr_IdProduccion")
                    _strCodigoOrden = _dtbDatos.Rows(0)("var_CodigoOrden")
                    _intSecuenciaArticulo = _dtbDatos.Rows(0)("int_SecuenciaArticulo")
                    _intSecuencialRuta = _dtbDatos.Rows(0)("int_SecuencialRuta")
                    _strFechaFinal = Format(_dtbDatos.Rows(0)("dtm_Final"), "dd/MM/yyyy")
                    _strFechaInicio = Format(_dtbDatos.Rows(0)("dtm_Inicio"), "dd/MM/yyyy")
                    _strHoraFinal = Format(_dtbDatos.Rows(0)("dtm_Final"), "HH:mm")
                    _strHoraInicio = Format(_dtbDatos.Rows(0)("dtm_Inicio"), "HH:mm")
                    _dblCantidad = _dtbDatos.Rows(0)("num_Cantidad")
                    _strIdUnidadMedida = _dtbDatos.Rows(0)("var_IdUnidadMedida")
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
                                                 "int_SecuenciaArticulo", _intSecuenciaArticulo, _
                                                 "int_SecuencialRuta", _intSecuencialRuta}

                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Produccion_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace