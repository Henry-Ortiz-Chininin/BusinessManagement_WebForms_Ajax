Imports AccesoDatos

Namespace Maestros.Ruta
    Public Class Ruta
#Region "VARIABLES"
        Private _strIdRuta As String
        Private _strDescripcion As String
        Private _strIdArticulo As String

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

        Public Property IdArticulo() As String
            Get
                Return _strIdArticulo
            End Get
            Set(ByVal value As String)
                _strIdArticulo = value
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
                Dim objParametros() As String = {"var_IdRuta", _strIdRuta, _
                                                "var_IdArticulo", _strIdArticulo, _
                                                "var_Descripcion", _strDescripcion, _
                                                "chr_Estado", _strEstado, _
                                                "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_uspe_Ruta_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdRuta", _strIdRuta}
                _objConexion.EjecutarComando("SGC_uspe_Ruta_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdRuta", _strIdRuta}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Ruta_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdRuta = _dtbDatos.Rows(0)("var_IdRuta")
                    _strIdArticulo = _dtbDatos.Rows(0)("var_IdArticulo")
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
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Ruta_Listar")

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Buscar(ByVal pstrDescripcion As String) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_Descripcion", pstrDescripcion}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Ruta_Buscar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace