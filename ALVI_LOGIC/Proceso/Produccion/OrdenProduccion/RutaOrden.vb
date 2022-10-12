Imports AccesoDatos
Namespace Proceso.Produccion.OrdenProduccion
    Public Class RutaOrden
#Region "VARIABLES"
        Private _strIdOrden As String
        Private _intSecuencialRuta As Int16
        Private _intSecuenciaArticulo As Int16
        Private _strIdMaquina As String
        Private _strIdUnidadMedida As String
        Private _strIdProceso As String
        Private _strIdOperacion As String
        Private _intPosicion As String
        Private _dblCostoUnitario As Double
        Private _strFibra As String

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
        Public Property Fribra() As String
            Get
                Return _strFibra
            End Get
            Set(ByVal value As String)
                _strFibra = value
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
        Public Property SecuenciaArticulo() As Int16
            Get
                Return _intSecuenciaArticulo
            End Get
            Set(ByVal value As Int16)
                _intSecuenciaArticulo = value
            End Set
        End Property
        Public Property IdMaquina() As String
            Get
                Return _strIdMaquina
            End Get
            Set(ByVal value As String)
                _strIdMaquina = value
            End Set
        End Property
        Public Property IdProceso() As String
            Get
                Return _strIdProceso
            End Get
            Set(ByVal value As String)
                _strIdProceso = value
            End Set
        End Property
        Public Property IdOperacion() As String
            Get
                Return _strIdOperacion
            End Get
            Set(ByVal value As String)
                _strIdOperacion = value
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
        Public Property Posicion() As Integer
            Get
                Return _intPosicion
            End Get
            Set(ByVal value As Integer)
                _intPosicion = value
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
                Dim objParametros() As String = {"var_IdOrden", _strIdOrden, _
                                                 "int_SecuencialRuta", _intSecuencialRuta, _
                                                 "var_Posicion", _intPosicion, _
                                                 "int_SecuenciaArticulo", _intSecuenciaArticulo, _
                                                 "var_IdMaquina", _strIdMaquina, _
                                                 "var_IdUnidadMedida", _strIdUnidadMedida, _
                                                 "chr_IdProceso", _strIdProceso, _
                                                 "var_IdOperacion", _strIdOperacion, _
                                                 "num_CostoUnitario", _dblCostoUnitario, _
                                                "chr_Estado", _strEstado, _
                                                "var_Usuario", _strUsuario, _
                                                 "chr_IdTipo", _strFibra}
                _objConexion.EjecutarComando("SGC_uspo_OPRuta_Registrar", objParametros)

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
                                                 "int_SecuenciaArticulo", _intSecuenciaArticulo}
                _objConexion.EjecutarComando("SGC_uspo_OPRuta_Eliminar", objParametros)

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
                                                 "int_SecuenciaArticulo", _intSecuenciaArticulo}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspo_OPRuta_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdOrden = _dtbDatos.Rows(0)("var_IdOrden")
                    _intPosicion = _dtbDatos.Rows(0)("var_Posicion")
                    _intSecuenciaArticulo = _dtbDatos.Rows(0)("int_SecuenciaArticulo")
                    _intSecuencialRuta = _dtbDatos.Rows(0)("int_SecuencialRuta")
                    _strIdMaquina = _dtbDatos.Rows(0)("var_IdMaquina")
                    _strIdProceso = _dtbDatos.Rows(0)("chr_IdProceso")
                    _strIdOperacion = _dtbDatos.Rows(0)("var_IdOperacion")
                    _dblCostoUnitario = _dtbDatos.Rows(0)("num_CostoUnitario")
                    _strIdUnidadMedida = _dtbDatos.Rows(0)("var_IdUnidadMedida")
                    _strEstado = _dtbDatos.Rows(0)("chr_Estado")
                    _strFibra = _dtbDatos.Rows(0)("chr_IdTipo")
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
                                                 "int_SecuenciaArticulo", _intSecuenciaArticulo}

                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspo_OPRuta_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace

