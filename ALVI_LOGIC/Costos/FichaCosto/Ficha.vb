Imports AccesoDatos
Namespace Costos.FichaCosto

    Public Class Ficha
#Region "VARIABLES"
        Private _strIdFicha As String
        Private _strDescripcion As String
        Private _strIdArticuloBase As String
        Private _strIdArticulo As String
        Private _dblUnidadHora As Double

        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer
#End Region

#Region "PROPIEDADES"

        Public Property IdFicha As String
            Get
                Return _strIdFicha
            End Get
            Set(ByVal value As String)
                _strIdFicha = value
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
        Public Property IdArticuloBase As String
            Get
                Return _strIdArticuloBase
            End Get
            Set(ByVal value As String)
                _strIdArticuloBase = value
            End Set
        End Property
        Public Property IdArticulo As String
            Get
                Return _strIdArticulo
            End Get
            Set(ByVal value As String)
                _strIdArticulo = value
            End Set
        End Property
        Public Property UnidadHora As Double
            Get
                Return _dblUnidadHora
            End Get
            Set(ByVal value As Double)
                _dblUnidadHora = value
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
                Dim objParametros() As String = {"var_IdFicha", _strIdFicha, _
                                                 "var_Descripcion", _strDescripcion, _
                                                 "var_IdArticuloBase", _strIdArticuloBase, _
                                                 "var_IdArticulo", _strIdArticulo, _
                                                 "num_UnidadHora", _dblUnidadHora, _
                                                 "var_Usuario", _strUsuario}
                _strIdFicha = _objConexion.ObtenerValor("SGC_usp_FichaCosto_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Importar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdFicha", _strIdFicha, _
                                                 "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_usp_FichaCostoDatos_Importar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdFicha", _strIdFicha}
                _objConexion.EjecutarComando("SGC_usp_FichaCosto_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdFicha", _strIdFicha}

                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_FichaCosto_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdFicha = _dtbDatos.Rows(0)("var_IdFicha")
                    _strDescripcion = _dtbDatos.Rows(0)("var_Descripcion")
                    _strIdArticuloBase = _dtbDatos.Rows(0)("var_IdArticuloBase")
                    _strIdArticulo = _dtbDatos.Rows(0)("var_IdArticulo")
                    _dblUnidadHora = _dtbDatos.Rows(0)("num_UnidadHora")

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
                Dim objParametros() As String = {"var_IdArticulo", _strIdArticulo}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_FichaCosto_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region

    End Class

End Namespace


