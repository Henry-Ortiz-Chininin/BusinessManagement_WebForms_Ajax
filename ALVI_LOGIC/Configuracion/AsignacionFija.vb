Imports AccesoDatos
Imports System.Data

Namespace Configuracion
    Public Class AsignacionFija
#Region "VARIABLES"
        Private _strIdCentroCosto As String
        Private _strIdCuentaGasto As String
        Private _dblPorcentaje As Double
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

        Public Property Porcentaje() As Double
            Get
                Return _dblPorcentaje
            End Get
            Set(ByVal value As Double)
                If value > 0 AndAlso value <= 100 Then
                    _dblPorcentaje = value
                Else
                    _dblPorcentaje = 0
                End If

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
                                                "num_Porcentaje", _dblPorcentaje, _
                                                "chr_Estado", _strEstado, _
                                                "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_usp_AsignacionFijo_Registrar", objParametros)

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
                _objConexion.EjecutarComando("SGC_usp_AsignacionFijo_Eliminar", objParametros)

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
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_AsignacionFijo_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdCentroCosto = _dtbDatos.Rows(0)("var_IdCentroCosto")
                    _strIdCuentaGasto = _dtbDatos.Rows(0)("var_IdCuentaGasto")
                    _dblPorcentaje = _dtbDatos.Rows(0)("num_Porcentaje")
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
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_AsignacionFijo_Listar")

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace

