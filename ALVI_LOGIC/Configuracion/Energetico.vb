Imports AccesoDatos
Imports System.Data

Namespace Configuracion
    Public Class Energetico
#Region "VARIABLES"
        Private _strIdEnergetico As String
        Private _strDescripcion As String
        Private _strIdInductor As String
        Private _strUnidadMedida As String
        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"

        Public Property IdEnergetico() As String
            Get
                Return _strIdEnergetico
            End Get
            Set(ByVal value As String)
                _strIdEnergetico = value
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
        Public Property IdInductor() As String
            Get
                Return _strIdInductor
            End Get
            Set(ByVal value As String)
                _strIdInductor = value
            End Set
        End Property
        Public Property UnidadMedida() As String
            Get
                Return _strUnidadMedida
            End Get
            Set(ByVal value As String)
                _strUnidadMedida = value
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
                Dim objParametros() As String = {"var_IdEnergetico", _strIdEnergetico, _
                                                "var_Descripcion", _strDescripcion, _
                                                "var_IdInductor", _strIdInductor, _
                                                "var_IdUnidadMedida", _strUnidadMedida, _
                                                "chr_Estado", _strEstado, _
                                                "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_usp_Energetico_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdEnergetico", _strIdEnergetico}
                _objConexion.EjecutarComando("SGC_usp_Energetico_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdEnergetico", _strIdEnergetico}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Energetico_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdEnergetico = _dtbDatos.Rows(0)("var_IdEnergetico")
                    _strDescripcion = _dtbDatos.Rows(0)("var_Descripcion")
                    _strIdInductor = _dtbDatos.Rows(0)("var_IdInductor")
                    _strUnidadMedida = _dtbDatos.Rows(0)("var_IdUnidadMedida")
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
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Energetico_Listar")

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region

    End Class

End Namespace
