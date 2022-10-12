Imports AccesoDatos
Imports ALVI_LOGIC

Namespace Maestros.Articulo.Atributo

    Public Class AtributoxArticulo
#Region "VARIABLES"
        Private _strIdArticulo As String
        Private _intSecuencia As Int16
        Private _strIdAtributoTipo As String
        Private _strIdSubFamilia As String
        Private _strIdAtributoValor As String

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"

        Public Property IdAtributoTipo() As String
            Get
                Return _strIdAtributoTipo
            End Get
            Set(ByVal value As String)
                _strIdAtributoTipo = value
            End Set
        End Property
        Public Property IdSubFamilia() As String
            Get
                Return _strIdSubFamilia
            End Get
            Set(ByVal value As String)
                _strIdSubFamilia = value
            End Set
        End Property
        Public Property IdValor() As String
            Get
                Return _strIdAtributoValor
            End Get
            Set(ByVal value As String)
                _strIdAtributoValor = value
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
        Public Property Secuencia() As Int16
            Get
                Return _intSecuencia
            End Get
            Set(ByVal value As Int16)
                _intSecuencia = value
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
                Dim objParametros() As String = {"chr_IdAtributo", _strIdAtributoTipo, _
                                                 "var_IdArticulo", _strIdArticulo, _
                                                 "int_Secuencia", _intSecuencia, _
                                                 "var_IdSubFamilia", _strIdSubFamilia, _
                                                 "var_IdAtributoValor", _strIdAtributoValor, _
                                                 "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_uspe_ArticuloAtributo_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdArticulo", _strIdArticulo, _
                                                 "int_Secuencia", _intSecuencia}
                _objConexion.EjecutarComando("SGC_uspe_ArticuloAtributo_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdArticulo", _strIdArticulo, _
                                                 "int_Secuencia", _intSecuencia}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_ArticuloAtributo_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdAtributoTipo = _dtbDatos.Rows(0)("chr_IdAtributo")
                    _strIdSubFamilia = _dtbDatos.Rows(0)("var_IdSubFamilia")
                    _strIdAtributoValor = _dtbDatos.Rows(0)("var_IdAtributoValor")
                    _strIdArticulo = _dtbDatos.Rows(0)("var_IdArticulo")
                    _intSecuencia = _dtbDatos.Rows(0)("int_Secuencia")
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
                Dim objParametros() As String = {"var_IdArticulo", _strIdArticulo}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_ArticuloAtributo_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class

End Namespace