Imports AccesoDatos
Imports ALVI_LOGIC
Namespace Maestros.Logistica
    Public Class CompraDocumento
        Private _strIdValeAlmacen As String
        Private _strIdTipo As String
        Private _strNumero As String
        Private _strObservacion As String
        Private _dtbDatos As DataTable
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer




        Public Property IdValeAlemacen() As String
            Get
                Return _strIdValeAlmacen
            End Get
            Set(ByVal value As String)
                _strIdValeAlmacen = value
            End Set
        End Property



        Public Property Tipo() As String
            Get
                Return _strIdTipo
            End Get
            Set(ByVal value As String)
                _strIdTipo = value
            End Set
        End Property




        Public Property Numero() As String
            Get
                Return _strNumero
            End Get
            Set(ByVal value As String)
                _strNumero = value
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

        Public Property Observacion() As String
            Get
                Return _strObservacion
            End Get
            Set(ByVal value As String)
                _strObservacion = value
            End Set
        End Property





        Public Function Listar() As Boolean
            Try
                Dim objParametros() As String = {"var_IdOrdenCompra", _strIdValeAlmacen}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_OrdenCompraReferencia_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function


    End Class
End Namespace


