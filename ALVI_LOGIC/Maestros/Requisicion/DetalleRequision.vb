
Imports AccesoDatos
Imports ALVI_LOGIC
Namespace Maestros.Requisicion
    Public Class DetalleRequision


        Private _strIdUnidadMedida As String
        Private _strDescripcionUnidadMedida As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer
        Private _strIdArticulo As String
        Private _strDescripcionArticulo As String
        Private _dtbDatos As DataTable
        Private _intCantidad As Integer
        Private _strIdRequision As String
        Private _strObservacion As String

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

        Public Property IdRequisicion() As String
            Get
                Return _strIdRequision
            End Get
            Set(ByVal value As String)
                _strIdRequision = value
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


        Public Property Observacion() As String
            Get
                Return _strObservacion
            End Get
            Set(ByVal value As String)
                _strObservacion = value
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
                Dim objParametros() As String = {"var_IdRequisicion", _strIdRequision}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_RequisicionDetalle_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
    End Class
End Namespace
