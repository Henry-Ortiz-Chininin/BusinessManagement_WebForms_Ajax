Imports AccesoDatos
Imports System.Data

Namespace Resultado

    Public Class Produccion
#Region "VARIABLES"
        Private _dtbDatos As DataTable
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer
#End Region
#Region "PROPIEDADES"

        Public Property Datos() As DataTable
            Get
                Return _dtbDatos
            End Get
            Set(ByVal value As DataTable)
                _dtbDatos = value
            End Set
        End Property

        Public ReadOnly Property exError() As String
            Get
                Return _exError.ToString
            End Get
        End Property
#End Region

        Public Function ReporteGeneral(ByVal pstrFechaInicio As String, _
                                       ByVal pstrFechaFinal As String, _
                                       ByVal pstrIdOrden As String, _
                                       ByVal pstrIdArticulo As String, _
                                       ByVal pstrIdProceso As String) As Boolean

            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_FechaInicio", pstrFechaInicio, _
                                                 "var_FechaFinal", pstrFechaFinal, _
                                                 "var_IdOrden", pstrIdOrden, _
                                                 "var_IdArticulo", pstrIdArticulo, _
                                                 "var_IdProceso", pstrIdProceso}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Produccion_Reporte1", objParametros)

                Return (_dtbDatos.Rows.Count > 0)

            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try

        End Function
    End Class

End Namespace
