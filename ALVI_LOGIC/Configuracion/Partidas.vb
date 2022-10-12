Imports AccesoDatos
Imports System.Data

Namespace Configuracion
    Public Class Partidas
#Region "VARIABLES"
        Private _strIdCentroCosto As String
        Private _strIdCuentaGasto As String
        Private _strIdClaseContable As String
        Private _strIdClaseGerencial As String
        Private _strIdClaseFV As String
        Private _strIdClaseTipo As String
        Private _strIdInductor As String
        Private _strDiscresional As String

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"
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
        Public Property IdClaseContable() As String
            Get
                Return _strIdClaseContable
            End Get
            Set(ByVal value As String)
                _strIdClaseContable = value
            End Set
        End Property
        Public Property IdClaseGerencial() As String
            Get
                Return _strIdClaseGerencial
            End Get
            Set(ByVal value As String)
                _strIdClaseGerencial = value
            End Set
        End Property
        Public Property IdClaseFV() As String
            Get
                Return _strIdClaseFV
            End Get
            Set(ByVal value As String)
                _strIdClaseFV = value
            End Set
        End Property
        Public Property IdClaseTipo() As String
            Get
                Return _strIdClaseTipo
            End Get
            Set(ByVal value As String)
                _strIdClaseTipo = value
            End Set
        End Property

        Public Property Discresional() As String
            Get
                Return _strDiscresional
            End Get
            Set(ByVal value As String)
                _strDiscresional = value
            End Set
        End Property

        Public Property IdInductor() As String
            Get
                Return _strIdInductor
            End Get
            Set(ByVal value As String)
                _strIdInductor = value
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
                Dim objParametros() As String = {"var_IdCentroCosto", _strIdCentroCosto, _
                                                "var_IdCuentaGasto", _strIdCuentaGasto, _
                                                "var_IdClaseContable", _strIdClaseContable, _
                                                "var_IdClaseGerencial", _strIdClaseGerencial, _
                                                "var_IdClaseFV", _strIdClaseFV, _
                                                "var_IdClaseTipo", _strIdClaseTipo, _
                                                "var_IdInductor", _strIdInductor, _
                                                "chr_Discresional", _strDiscresional, _
                                                "chr_Estado", _strEstado, _
                                                "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_usp_PartidaClase_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdCentroCosto", _strIdCentroCosto, _
                                                "var_IdCuentaGasto", _strIdCuentaGasto}
                _objConexion.EjecutarComando("SGC_usp_PartidaClase_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdCentroCosto", _strIdCentroCosto, _
                                                "var_IdCuentaGasto", _strIdCuentaGasto}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_PartidaClase_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdCentroCosto = _dtbDatos.Rows(0)("var_Descripcion")
                    _strIdClaseContable = _dtbDatos.Rows(0)("var_Descripcion")
                    _strIdClaseFV = _dtbDatos.Rows(0)("var_Descripcion")
                    _strIdClaseGerencial = _dtbDatos.Rows(0)("var_Descripcion")
                    _strIdClaseTipo = _dtbDatos.Rows(0)("var_Descripcion")
                    _strIdCuentaGasto = _dtbDatos.Rows(0)("var_Descripcion")
                    _strIdInductor = _dtbDatos.Rows(0)("var_Descripcion")
                    _strDiscresional = _dtbDatos.Rows(0)("var_Descripcion")
                    _strIdInductor = _dtbDatos.Rows(0)("var_IdInductor")
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
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_PartidaClase_Listar")

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace

