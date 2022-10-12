Imports AccesoDatos
Imports ALVI_LOGIC

Namespace Maestros.Produccion
    Public Class ParoProgramado
#Region "VARIABLES"
        Private _strIdParoProgramado As String
        Private _strObservacion As String
        Private _strIdMaquinaria As String
        Private _strIdMotivoParo As String
        Private _strFechaInicio As String
        Private _strFechaFinal As String
        Private _strDuracion As String

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer
#End Region

#Region "PROPIEDADES"

        Public Property IdParoProgramado() As String
            Get
                Return _strIdParoProgramado
            End Get
            Set(ByVal value As String)
                _strIdParoProgramado = value
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
        Public Property IdMaquinaria() As String
            Get
                Return _strIdMaquinaria
            End Get
            Set(ByVal value As String)
                _strIdMaquinaria = value
            End Set
        End Property
        Public Property IdMotivoParo() As String
            Get
                Return _strIdMotivoParo
            End Get
            Set(ByVal value As String)
                _strIdMotivoParo = value
            End Set
        End Property
        Public Property FechaInicio() As String
            Get
                Return _strFechaInicio
            End Get
            Set(ByVal value As String)
                _strFechaInicio = value
            End Set
        End Property
        Public Property FechaFinal() As String
            Get
                Return _strFechaFinal
            End Get
            Set(ByVal value As String)
                _strFechaFinal = value
            End Set
        End Property
        Public Property Duracion() As String
            Get
                Return _strDuracion
            End Get
            Set(ByVal value As String)
                _strDuracion = value
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
                'cambiamos var_IdAtributo, por var_idParoProduccion'
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_idParoProduccion", _strIdParoProgramado, _
                                                "var_IdMaquinaria", _strIdMaquinaria, _
                                                 "var_IdMotivo", _strIdMotivoParo, _
                                                  "dtm_FechaInicio", _strFechaInicio, _
                                                  "dtm_FechaFinal", _strFechaFinal, _
                                                "var_Usuario", _strUsuario, _
                                                "chr_Estado", _strEstado}
                _objConexion.EjecutarComando("SGC_uspe_ParoMaquinariaProgramado_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdParoProgramado", _strIdParoProgramado}
                _objConexion.EjecutarComando("SGC_uspe_ParoMaquinariaProgramado_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdAtributo", _strIdParoProgramado}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_ParoProgramado_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdParoProgramado = _dtbDatos.Rows(0)("var_IdParoProgramado")
                    _strIdMaquinaria = _dtbDatos.Rows(0)("var_IdMaquina")
                    _strIdMotivoParo = _dtbDatos.Rows(0)("var_IdMotivo")
                    _strObservacion = _dtbDatos.Rows(0)("var_Observacion")
                    _strFechaInicio = _dtbDatos.Rows(0)("dtm_FechaInicio")
                    _strFechaFinal = _dtbDatos.Rows(0)("dtm_FechaFinal")
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
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_ParoMaquinariaProgramado_Listar")
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Buscar(ByVal strIdMaquina As String) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_idMaquinaria", strIdMaquina}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_ParoMaquinariaProgramado_Listar", objParametros)
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace
