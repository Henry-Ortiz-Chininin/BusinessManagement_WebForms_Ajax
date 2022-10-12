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
        Public Function ReporteResumido(ByVal pstrFechaInicio As String, _
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
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Produccion_Reporte2", objParametros)

                Return (_dtbDatos.Rows.Count > 0)

            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try

        End Function
        Public Function ReporteDetallado(ByVal pstrFechaInicio As String, _
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
        Public Function Obtener_OPEnProceso(ByVal pstrFechaInicio As String, _
                                       ByVal pstrFechaFinal As String, _
                                       ByVal pstrIdOrden As String, _
                                       ByVal pstrIdCliente As String) As Boolean

            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_FechaInicio", pstrFechaInicio, _
                                                 "var_FechaFinal", pstrFechaFinal, _
                                                 "var_IdOrden", pstrIdOrden, _
                                                 "var_IdCliente", pstrIdCliente}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_OrdenEnProceso_Obtener", objParametros)

                Return (_dtbDatos.Rows.Count > 0)

            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try

        End Function
        Public Function OrdenRequerimientoMaterial(ByVal pstrIdOrden As String) As Boolean

            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdOrden", pstrIdOrden}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_SeguimientoOrden_Requerimiento", objParametros)

                Return (_dtbDatos.Rows.Count > 0)

            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try

        End Function
        Public Function ComparativoEstandarVersusReal(ByVal pstrIdOrden As String) As Boolean

            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdLoteIQ", pstrIdOrden}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_OPEstandarVesusReal_Obtener", objParametros)

                Return (_dtbDatos.Rows.Count > 0)

            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try

        End Function
        Public Function Avance_OP(ByVal pstrIdOrden As String) As Boolean

            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdOrden", pstrIdOrden}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_OrdenProduccionAvance_Obtener", objParametros)

                Return (_dtbDatos.Rows.Count > 0)

            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try

        End Function
        Public Function OrdenDespachoMaterial(ByVal pstrIdOrden As String) As Boolean

            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdOrden", pstrIdOrden}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_SeguimientoOrden_Despacho", objParametros)

                Return (_dtbDatos.Rows.Count > 0)

            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try

        End Function
        Public Function ReporteServicio(ByVal pstrFechaInicio As String, _
                                       ByVal pstrFechaFinal As String, _
                                       ByVal pstrIdArticulo As String, _
                                       ByVal pstrIdOrden As String, _
                                       ByVal pstrIdProveedor As String) As Boolean

            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_FechaInicio", pstrFechaInicio, _
                                                 "var_FechaFinal", pstrFechaFinal, _
                                                  "var_IdArticulo", pstrIdArticulo, _
                                                 "var_IdOrden", pstrIdOrden, _
                                                 "var_IdProveedor", pstrIdProveedor}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Servicio_Reporte1", objParametros)

                Return (_dtbDatos.Rows.Count > 0)

            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try

        End Function
    End Class
End Namespace
