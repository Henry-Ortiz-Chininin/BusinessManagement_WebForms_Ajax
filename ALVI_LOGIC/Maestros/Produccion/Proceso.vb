Imports AccesoDatos

Namespace Maestros.Produccion
    Public Class Proceso
#Region "VARIABLES"
        Private _strIdProceso As String
        Private _strIdEtapa As String
        Private _strDescripcion As String
        Private _dblAvance As Double
        Private _strIdCentroCosto As String
        Private _strIdTipoProceso As String
        Private _strDesOperacion As String
        Private _strDesProceso As String

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"

        Public Property IdProceso() As String
            Get
                Return _strIdProceso
            End Get
            Set(ByVal value As String)
                _strIdProceso = value
            End Set
        End Property
        Public Property IdTipoProceso() As String
            Get
                Return _strIdTipoProceso
            End Get
            Set(ByVal value As String)
                _strIdTipoProceso = value
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

        Public Property IdEtapa() As String
            Get
                Return _strIdEtapa
            End Get
            Set(ByVal value As String)
                _strIdEtapa = value
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
        Public Property DesProceso() As String
            Get
                Return _strDesProceso
            End Get
            Set(ByVal value As String)
                _strDesProceso = value
            End Set
        End Property
        Public Property DesOperacion() As String
            Get
                Return _strDesOperacion
            End Get
            Set(ByVal value As String)
                _strDesOperacion = value
            End Set
        End Property

        Public Property Avance As Double
            Get
                Return _dblAvance
            End Get
            Set(ByVal value As Double)
                _dblAvance = value
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
                Dim objParametros() As String = {"chr_IdProceso", _strIdProceso, _
                                                "chr_IdEtapa", _strIdEtapa, _
                                                "var_IdCentroCosto", _strIdCentroCosto, _
                                                "num_Avance", _dblAvance, _
                                                "var_Descripcion", _strDescripcion, _
                                                "chr_Estado", _strEstado, _
                                                "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_uspe_Proceso_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function ControlListar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_DesProceso", _strDesProceso, _
                                                "var_DesOperacion", _strDesOperacion}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_OperacionxEtapa_Listar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"chr_IdProceso", _strIdProceso}
                _objConexion.EjecutarComando("SGC_uspe_Proceso_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"chr_IdProceso", _strIdProceso}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Proceso_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdProceso = _dtbDatos.Rows(0)("chr_IdProceso")
                    _strIdEtapa = _dtbDatos.Rows(0)("chr_IdEtapa")
                    _strDescripcion = _dtbDatos.Rows(0)("var_Descripcion")
                    _strIdCentroCosto = _dtbDatos.Rows(0)("var_IdCentroCosto")
                    _dblAvance = _dtbDatos.Rows(0)("num_Avance")
                    _strEstado = _dtbDatos.Rows(0)("chr_Estado")

                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
Public Function ListarProcesoyOperacion() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_ProcesoyOperacion")
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Listar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Proceso_Listar")

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function ListarTipo() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_TipoProceso_Listar")

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace

