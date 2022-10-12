Imports AccesoDatos

Namespace Maestros.Produccion
    Public Class Maquina
#Region "VARIABLES"
        Private _strIdMaquina As String
        Private _strIdPlanta As String
        Private _strIdCentroCosto As String
        Private _strDescripcion As String
        Private _strIdTipoMaquina As String

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"

        Public Property IdMaquina() As String
            Get
                Return _strIdMaquina
            End Get
            Set(ByVal value As String)
                _strIdMaquina = value
            End Set
        End Property
        Public Property IdPlanta() As String
            Get
                Return _strIdPlanta
            End Get
            Set(ByVal value As String)
                _strIdPlanta = value
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
        Public Property Descripcion() As String
            Get
                Return _strDescripcion
            End Get
            Set(ByVal value As String)
                _strDescripcion = value
            End Set
        End Property

        Public Property IdTipoMaquina() As String
            Get
                Return _strIdTipoMaquina
            End Get
            Set(ByVal value As String)
                _strIdTipoMaquina = value
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
                Dim objParametros() As String = {"var_IdMaquina", _strIdMaquina, _
                                                "var_IdPlanta", _strIdPlanta, _
                                                "var_IdCentroCosto", _strIdCentroCosto, _
                                                "var_IdTipoMaquina", _strIdTipoMaquina, _
                                                "var_Descripcion", _strDescripcion, _
                                                "chr_Estado", _strEstado, _
                                                "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_uspe_Maquina_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdMaquina", _strIdMaquina}
                _objConexion.EjecutarComando("SGC_uspe_Maquina_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdMaquina", _strIdMaquina}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Maquina_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdMaquina = _dtbDatos.Rows(0)("var_IdMaquina")
                    _strIdTipoMaquina = _dtbDatos.Rows(0)("var_IdTipoMaquina")
                    _strIdCentroCosto = _dtbDatos.Rows(0)("var_IdCentroCosto")
                    _strIdPlanta = _dtbDatos.Rows(0)("var_IdPlanta")
                    _strDescripcion = _dtbDatos.Rows(0)("var_Descripcion")
                    _strIdTipoMaquina = _dtbDatos.Rows(0)("var_IdTipoMaquina")
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
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Maquina_Listar")

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace

