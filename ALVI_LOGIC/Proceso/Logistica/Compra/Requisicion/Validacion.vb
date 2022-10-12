Imports AccesoDatos
Imports ALVI_LOGIC

Namespace Proceso.Logistica.Compra.Requisicion
    Public Class Validacion
        
#Region "VARIABLES"
        Private _strIdRequisicion As String
        Private _strIdValidador As String

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"

        Public Property IdRequisicion() As String
            Get
                Return _strIdRequisicion
            End Get
            Set(ByVal value As String)
                _strIdRequisicion = value
            End Set
        End Property

        Public Property IdValidador() As String
            Get
                Return _strIdValidador
            End Get
            Set(ByVal value As String)
                _strIdValidador = value
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
                Dim objParametros() As String = {"var_IdRequisicion", _strIdRequisicion, _
                                                "var_IdValidador", _strIdValidador, _
                                                "chr_IdEstado", _strEstado}
                _objConexion.EjecutarComando("SGC_usp_Validacion_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdRequisicion", _strIdRequisicion, _
                                                "var_IdValidador", _strIdValidador}
                _objConexion.EjecutarComando("SGC_usp_Validacion_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Listar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdRequisicion", _strIdRequisicion}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Validacion_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace

