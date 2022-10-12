Imports AccesoDatos

Namespace Maestros.Produccion
    Public Class Maquina
#Region "VARIABLES"
        Private _strIdMaquina As String
        Private _strIdPlanta As String
        Private _strIdCentroCosto As String
        Private _strDescripcion As String
        Private _strIdTipoMaquina As String
        Private _strvolumenMinimo As String
        Private _strvolumenMaximo As String
        Private _strPesoMinimo As String
        Private _strPesoMaximo As String
        Private _strvelocidad As String
        Private _strIdUnidadvelocidad As String
        Private _strIdUnidadVolumen As String
        Private _strIdUnidadPeso As String
        Private _strrelacionBano As String

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"

        Public Property IdMaquina() As String
            Get
                Return _strIdMaquina
            End Get
            Set(ByVal value As String)
                _strIdMaquina = value
            End Set
        End Property
        Public Property IdPlanta() As String
            Get
                Return _strIdPlanta
            End Get
            Set(ByVal value As String)
                _strIdPlanta = value
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
        Public Property Descripcion() As String
            Get
                Return _strDescripcion
            End Get
            Set(ByVal value As String)
                _strDescripcion = value
            End Set
        End Property

        Public Property IdTipoMaquina() As String
            Get
                Return _strIdTipoMaquina
            End Get
            Set(ByVal value As String)
                _strIdTipoMaquina = value
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
        Public Property VolumenMinimo() As String
            Get
                Return _strvolumenMinimo
            End Get
            Set(ByVal value As String)
                _strvolumenMinimo = value
            End Set
        End Property
        Public Property VolumenMaximo() As String
            Get
                Return _strvolumenMaximo
            End Get
            Set(ByVal value As String)
                _strvolumenMaximo = value
            End Set
        End Property
        Public Property PesoMinimo() As String
            Get
                Return _strPesoMinimo
            End Get
            Set(ByVal value As String)
                _strPesoMinimo = value
            End Set
        End Property
        Public Property PesoMaximo() As String
            Get
                Return _strPesoMaximo
            End Get
            Set(ByVal value As String)
                _strPesoMaximo = value
            End Set
        End Property
        Public Property UnidadVelocidad() As String
            Get
                Return _strIdUnidadvelocidad
            End Get
            Set(ByVal value As String)
                _strIdUnidadvelocidad = value
            End Set
        End Property
        Public Property UnidadVolumen() As String
            Get
                Return _strIdUnidadVolumen
            End Get
            Set(ByVal value As String)
                _strIdUnidadVolumen = value
            End Set
        End Property
        Public Property UnidadPeso() As String
            Get
                Return _strIdUnidadPeso
            End Get
            Set(ByVal value As String)
                _strIdUnidadPeso = value
            End Set
        End Property
        Public Property Velocidad() As String
            Get
                Return _strvelocidad
            End Get
            Set(ByVal value As String)
                _strvelocidad = value
            End Set
        End Property
        Public Property RelacionBaño() As String
            Get
                Return _strrelacionBano
            End Get
            Set(ByVal value As String)
                _strrelacionBano = value
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
                Dim objParametros() As String = {"var_IdMaquina", _strIdMaquina, _
                                                "var_IdPlanta", _strIdPlanta, _
                                                "var_IdCentroCosto", _strIdCentroCosto, _
                                                "var_IdTipoMaquina", _strIdTipoMaquina, _
                                                "var_Descripcion", _strDescripcion, _
                                                "chr_Estado", _strEstado, _
                                                "var_Usuario", _strUsuario, _
                                                "var_volumenMinimo", _strvolumenMinimo, _
                                                "var_volumenMaximo", _strvolumenMaximo, _
                                                "var_PesoMinimo", _strPesoMinimo, _
                                                "var_PesoMaximo", _strPesoMaximo, _
                                                "var_velocidad", _strvelocidad, _
                                                 "var_IdunidadVelocidad", _strIdUnidadvelocidad, _
                                                 "var_IdUnidadPeso", _strIdUnidadPeso, _
                                                 "var_IdUnidadVolumen", _strIdUnidadVolumen, _
                                                "var_relacionBano", _strrelacionBano}
                _objConexion.EjecutarComando("SGC_uspe_Maquina_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdMaquina", _strIdMaquina}
                _objConexion.EjecutarComando("SGC_uspe_Maquina_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdMaquina", _strIdMaquina}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Maquina_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdMaquina = _dtbDatos.Rows(0)("var_IdMaquina")
                    _strIdTipoMaquina = _dtbDatos.Rows(0)("var_IdTipoMaquina")
                    _strIdCentroCosto = _dtbDatos.Rows(0)("var_IdCentroCosto")
                    _strIdPlanta = _dtbDatos.Rows(0)("var_IdPlanta")
                    _strDescripcion = _dtbDatos.Rows(0)("var_Descripcion")
                    _strIdTipoMaquina = _dtbDatos.Rows(0)("var_IdTipoMaquina")
                    _strEstado = _dtbDatos.Rows(0)("chr_Estado")
                    _strvolumenMinimo = _dtbDatos.Rows(0)("var_volmin")
                    _strvolumenMaximo = _dtbDatos.Rows(0)("var_volmax")
                    _strPesoMinimo = _dtbDatos.Rows(0)("var_pesoMin")
                    _strPesoMaximo = _dtbDatos.Rows(0)("var_pesoMax")
                    _strvelocidad = _dtbDatos.Rows(0)("var_velocidad")
                    _strrelacionBano = _dtbDatos.Rows(0)("var_relacionBano")

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
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Maquina_Listar")

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Buscar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_Descripcion", _strDescripcion}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Maquina_Buscar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace

