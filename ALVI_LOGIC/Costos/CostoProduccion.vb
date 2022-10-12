Imports AccesoDatos
Imports System.Data

Namespace Costos
    Public Class Produccion
#Region "VARIABLES"
        Private _strAnno As String
        Private _strMes As String
        Private _strIdCentroCosto As String
        Private _strIdCuentaGasto As String
        Private _dblImporte As Double

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"
        Public Property Anno() As String
            Get
                Return _strAnno
            End Get
            Set(ByVal value As String)
                _strAnno = value
            End Set
        End Property
        Public Property Mes() As String
            Get
                Return _strMes
            End Get
            Set(ByVal value As String)
                _strMes = value
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
        Public Property IdCuentaGasto() As String
            Get
                Return _strIdCuentaGasto
            End Get
            Set(ByVal value As String)
                _strIdCuentaGasto = value
            End Set
        End Property
        Public Property Importe() As Double
            Get
                Return _dblImporte
            End Get
            Set(ByVal value As Double)
                _dblImporte = value
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

        Public Function Distribucion() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"chr_Anno", _strAnno, _
                                                 "chr_Mes", _strMes, _
                                                 "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_usp_CostoProducto_Generar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function ListarDistribucion(ByVal pstr_IdOrden As String, ByVal pstr_IdArticulo As String) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"chr_Anno", _strAnno, _
                                                 "chr_Mes", _strMes, _
                                                 "var_IdOrden", pstr_IdOrden, _
                                                 "var_IdArticulo", pstr_IdArticulo}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_CostoDistribuido_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace

