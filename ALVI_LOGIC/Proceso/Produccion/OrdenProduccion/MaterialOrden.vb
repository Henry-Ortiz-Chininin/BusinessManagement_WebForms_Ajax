Imports AccesoDatos
Namespace Proceso.Produccion.OrdenProduccion
    Public Class MaterialOrden
#Region "VARIABLES"
        Private _strIdOrden As String
        Private _intSecuencialRuta As Int16
        Private _intSecuencialMaterial As Int16
        Private _intSecuenciaArticulo As Int16
        Private _strIdUnidadMedida As String
        Private _strIdArticulo As String
        Private _dblCantidad As Double
        Private _intPosicion As Int16

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"

        Public Property IdOrden() As String
            Get
                Return _strIdOrden
            End Get
            Set(ByVal value As String)
                _strIdOrden = value
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
        Public Property SecuencialMaterial() As Int16
            Get
                Return _intSecuencialMaterial
            End Get
            Set(ByVal value As Int16)
                _intSecuencialMaterial = value
            End Set
        End Property
        Public Property Posicion() As Int16
            Get
                Return _intPosicion
            End Get
            Set(ByVal value As Int16)
                _intPosicion = value
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
        Public Property IdArticulo() As String
            Get
                Return _strIdArticulo
            End Get
            Set(ByVal value As String)
                _strIdArticulo = value
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
                Dim objParametros() As String = {"var_IdOrden", _strIdOrden, _
                                                 "int_SecuencialRuta", _intSecuencialRuta, _
                                                 "var_Posicion", _intSecuencialRuta, _
                                                 "int_SecuencialMaterial", _intSecuencialMaterial, _
                                                 "int_SecuenciaArticulo", _intSecuenciaArticulo, _
                                                 "var_IdUnidadMedida", _strIdUnidadMedida, _
                                                 "var_IdArticulo", _strIdArticulo, _
                                                 "num_Cantidad", _dblCantidad, _
                                                "chr_Estado", _strEstado, _
                                                "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_uspo_OPMaterial_Registrar", objParametros)
                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdOrden", _strIdOrden, _
                                                 "int_SecuencialRuta", _intSecuencialRuta, _
                                                 "int_SecuencialMaterial", _intSecuencialMaterial, _
                                                 "int_SecuenciaArticulo", _intSecuenciaArticulo}
                _objConexion.EjecutarComando("SGC_uspo_OPMaterial_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdOrden", _strIdOrden, _
                                                 "int_SecuencialRuta", _intSecuencialRuta, _
                                                 "int_SecuencialMaterial", _intSecuencialMaterial, _
                                                 "int_SecuenciaArticulo", _intSecuenciaArticulo}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspo_OPMaterial_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _intSecuenciaArticulo = _dtbDatos.Rows(0)("int_SecuenciaArticulo")
                    _intSecuencialMaterial = _dtbDatos.Rows(0)("int_SecuencialMaterial")
                    _intSecuencialRuta = _dtbDatos.Rows(0)("int_SecuencialRuta")
                    _strIdArticulo = _dtbDatos.Rows(0)("var_IdArticulo")
                    _strIdOrden = _dtbDatos.Rows(0)("var_IdOrden")
                    _strIdUnidadMedida = _dtbDatos.Rows(0)("var_IdUnidadMedida")
                    _dblCantidad = _dtbDatos.Rows(0)("num_Cantidad")
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
                Dim objParametros() As String = {"var_IdOrden", _strIdOrden, _
                                                 "int_SecuencialRuta", _intSecuencialRuta, _
                                                 "int_SecuenciaArticulo", _intSecuenciaArticulo}

                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspo_OPMaterial_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace

