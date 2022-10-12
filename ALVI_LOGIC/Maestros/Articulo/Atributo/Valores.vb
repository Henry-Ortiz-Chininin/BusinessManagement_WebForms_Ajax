Imports AccesoDatos
Imports ALVI_LOGIC

Namespace Maestros.Articulo.Atributo
    Public Class Valores
#Region "VARIABLES"
        Private _strIdAtributoTipo As String
        Private _strIdSubFamilia As String
        Private _strDescripcion As String
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

        Public Property Descripcion() As String
            Get
                Return _strDescripcion
            End Get
            Set(ByVal value As String)
                _strDescripcion = value
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
                                                 "var_Descripcion", _strDescripcion, _
                                                 "var_IdSubFamilia", _strIdSubFamilia, _
                                                 "var_IdAtributoValor", _strIdAtributoValor, _
                                                "chr_Estado", _strEstado, _
                                                "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_uspe_AtributoValor_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"chr_IdAtributo", _strIdAtributoTipo, _
                                                 "var_IdSubFamilia", _strIdSubFamilia, _
                                                 "var_IdAtributoValor", _strIdAtributoValor}
                _objConexion.EjecutarComando("SGC_uspe_AtributoValor_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"chr_IdAtributo", _strIdAtributoTipo, _
                                                 "var_IdSubFamilia", _strIdSubFamilia, _
                                                 "var_IdAtributoValor", _strIdAtributoValor}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_AtributoValor_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdAtributoTipo = _dtbDatos.Rows(0)("chr_IdAtributo")
                    _strIdSubFamilia = _dtbDatos.Rows(0)("var_IdSubFamilia")
                    _strIdAtributoValor = _dtbDatos.Rows(0)("var_IdAtributoValor")
                    _strDescripcion = _dtbDatos.Rows(0)("var_Descripcion")
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
                Dim objParametros() As String = {"var_IdSubFamilia", _strIdSubFamilia, _
                                                 "chr_IdAtributo", _strIdAtributoTipo}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_AtributoValor_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function ListarOP(ByVal pstrIdSubFamilia As String, ByVal pStrValor As String, ByVal pstrDescripcion As String) As Boolean
            Try


                Dim objParametros() As String = {"var_IdSubFamilia", pstrIdSubFamilia, _
                                                 "var_valor", pStrValor, _
                                                 "var_Descripcion", pstrDescripcion}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Articulo_Listar_OP", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function ListarAP(ByVal pstrIdSubFamilia As String) As Boolean
            Try


                Dim objParametros() As String = {"var_IdSubFamilia", pstrIdSubFamilia}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Articulo_Listar_AP", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function ListarVP(ByVal pstrValor As String, ByVal pstrIdSubFamilia As String) As Boolean
            Try


                Dim objParametros() As String = {"var_IdSubFamilia", pstrIdSubFamilia, _
                                                 "var_valor", pstrValor}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Articulo_Listar_VP", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function ListarDP(ByVal pstrDescripcion As String) As Boolean
            Try


                Dim objParametros() As String = {"var_Descripcion", pstrDescripcion}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Articulo_Listar_DP", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function ListarDPD(ByVal pstrDescripcion As String, ByVal pstrIdSubFamilia As String) As Boolean
            Try
                Dim objParametros() As String = {"var_IdSubFamilia", pstrIdSubFamilia, _
                                                 "var_Descripcion", pstrDescripcion}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Articulo_Listar_DPD", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Buscar() As Boolean
            Try
                Dim objParametros() As String = {"var_IdSubFamilia", _strIdSubFamilia, _
                                                 "chr_IdAtributo", _strIdAtributoTipo,
                                                 "var_Descripcion", _strDescripcion}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_AtributoValor_Buscar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
#End Region

    End Class
End Namespace
