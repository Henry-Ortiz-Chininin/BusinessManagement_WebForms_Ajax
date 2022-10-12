
Imports AccesoDatos
Imports ALVI_LOGIC
Namespace Maestros.Logistica
    Public Class ValeArticulo

        Private _strIdValeAlmacen As String
        Private _strIdUnidadMedida As String
        Private _strDescripcionUnidadMedida As String
        Private _intCantidad As Integer
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer
        Private _strIdArticulo As String
        Private _strDescripcionArticulo As String
        Private _dtbDatos As DataTable


        Public Property IdUnidadMedida() As String
            Get
                Return _strIdUnidadMedida
            End Get
            Set(ByVal value As String)
                _strIdUnidadMedida = value
            End Set
        End Property
        Public Property DescripcionUnidadMedida() As String
            Get
                Return _strDescripcionUnidadMedida
            End Get
            Set(ByVal value As String)
                _strDescripcionUnidadMedida = value
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

        Public Property DescripcionArticulo() As String
            Get
                Return _strDescripcionArticulo
            End Get
            Set(ByVal value As String)
                _strDescripcionArticulo = value
            End Set
        End Property

        Public Property IdValeAlmacen() As String
            Get
                Return _strIdValeAlmacen
            End Get
            Set(ByVal value As String)
                _strIdValeAlmacen = value
            End Set
        End Property


        Public Property Cantidad() As Integer
            Get
                Return _intCantidad
            End Get
            Set(ByVal value As Integer)
                _intCantidad = value
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



        Public Function Listar() As Boolean
            Try
                Dim objParametros() As String = {"var_IdValeAlmacen", _strIdValeAlmacen}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_ValeArticulo_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

    End Class

End Namespace

