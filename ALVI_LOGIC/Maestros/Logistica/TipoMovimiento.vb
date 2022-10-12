Imports AccesoDatos
Imports ALVI_LOGIC

Namespace Maestros.Logistica
    Public Class TipoMovimiento

#Region "VARIABLES"
        Private _strIdTipoMovimiento As String
        Private _strClasificacion As String
        Private _strDescripcion As String

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"

        Public Property IdTipoMovimiento() As String
            Get
                Return _strIdTipoMovimiento
            End Get
            Set(ByVal value As String)
                _strIdTipoMovimiento = value
            End Set
        End Property
        Public Property Clasificacion() As String
            Get
                Return _strClasificacion
            End Get
            Set(ByVal value As String)
                _strClasificacion = value
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
                Dim objParametros() As String = {"var_IdTipoMovimiento", _strIdTipoMovimiento, _
                                                "chr_Clase", _strClasificacion, _
                                                "var_Descripcion", _strDescripcion, _
                                                "chr_Estado", _strEstado, _
                                                "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_uspa_TipoMovimiento_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdTipoMovimiento", _strIdTipoMovimiento}
                _objConexion.EjecutarComando("SGC_uspa_TipoMovimiento_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdTipoMovimiento", _strIdTipoMovimiento}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspa_TipoMovimiento_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdTipoMovimiento = _dtbDatos.Rows(0)("var_IdTipoMovimiento")
                    _strClasificacion = _dtbDatos.Rows(0)("chr_Clase")
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
                Dim objParametros() As String = {"var_Clase", _strClasificacion}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspa_TipoMovimiento_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Listar1() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspa_TipoMovimiento_Listar1")

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace

