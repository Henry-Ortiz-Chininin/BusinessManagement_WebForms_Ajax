Imports AccesoDatos

Namespace Maestros.Ruta
    Public Class Material
#Region "VARIABLES"
        Private _strIdRuta As String
        Private _intSecuencia As Int16
        Private _intSecuenciaMaterial As Int16
        Private _strIdArticulo As String
        Private _strIdUnidadMedida As String
        Private _strIdReceta As String
        Private _dblCantidad As Double

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"

        Public Property IdRuta() As String
            Get
                Return _strIdRuta
            End Get
            Set(ByVal value As String)
                _strIdRuta = value
            End Set
        End Property
        Public Property Secuencia() As Int16
            Get
                Return _intSecuencia
            End Get
            Set(ByVal value As Int16)
                _intSecuencia = value
            End Set
        End Property
        Public Property SecuenciaMaterial() As Int16
            Get
                Return _intSecuenciaMaterial
            End Get
            Set(ByVal value As Int16)
                _intSecuenciaMaterial = value
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
        Public Property IdReceta() As String
            Get
                Return _strIdReceta
            End Get
            Set(ByVal value As String)
                _strIdReceta = value
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
                Dim objParametros() As String = {"var_IdRuta", _strIdRuta, _
                                                "int_SecuencialRuta", _intSecuencia, _
                                                "int_SecuencialMaterial", _intSecuenciaMaterial, _
                                                "var_IdArticulo", _strIdArticulo, _
                                                "var_IdUnidadMedida", _strIdUnidadMedida, _
                                                "var_IdReceta", _strIdReceta, _
                                                "num_Cantidad", _dblCantidad, _
                                                "chr_Estado", _strEstado, _
                                                "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_uspe_RutaMaterial_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdRuta", _strIdRuta, _
                                                 "int_SecuencialRuta", _intSecuencia, _
                                                 "int_SecuencialMaterial", _intSecuenciaMaterial}
                _objConexion.EjecutarComando("SGC_uspe_RutaMaterial_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdRuta", _strIdRuta, _
                                                 "int_SecuencialRuta", _intSecuencia, _
                                                 "int_SecuencialMaterial", _intSecuenciaMaterial}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_RutaMaterial_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdRuta = _dtbDatos.Rows(0)("var_IdRuta")
                    _intSecuencia = _dtbDatos.Rows(0)("int_SecuencialRuta")
                    _intSecuenciaMaterial = _dtbDatos.Rows(0)("int_SecuencialMaterial")
                    _strIdArticulo = _dtbDatos.Rows(0)("var_IdArticulo")
                    _strIdReceta = _dtbDatos.Rows(0)("var_IdReceta")
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
                Dim objParametros() As String = {"var_IdRuta", _strIdRuta, _
                                                 "int_SecuencialRuta", _intSecuencia}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_RutaMaterial_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace

