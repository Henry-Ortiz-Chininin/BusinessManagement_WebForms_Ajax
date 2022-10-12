
Imports AccesoDatos
Imports ALVI_LOGIC

Namespace Proceso.Logistica.Compra.Requisicion
    Public Class Requisicion

        Private _strEstado As String
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer
        Private _dtbDatos As DataTable
        Private _strFechaEmision As String

        Public Property Estado() As String
            Get
                Return _strEstado
            End Get
            Set(ByVal value As String)
                _strEstado = value
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


        Public Function Buscar1(ByVal pstr_IdRequisicion As String) As DataTable

            Try
                Dim objParametros() As String = {"var_IdRequisicion", pstr_IdRequisicion}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Requisicion_Buscar1", objParametros)

                Return _dtbDatos
            Catch ex As Exception

                Return _dtbDatos
            End Try
        End Function
        Public Function Buscar2(ByVal pstr_IdRequisicion As String) As DataTable

            Try
                Dim objParametros() As String = {"var_IdRequisicion", pstr_IdRequisicion}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Requisicion_Buscar1", objParametros)

                Return _dtbDatos
            Catch ex As Exception

                Return _dtbDatos
            End Try
        End Function

        Public Function Buscar(ByVal pstr_IdRequisicion As String,
                                 ByVal pstr_IdSolicitante As String,
                                 ByVal pstr_FechaEmisionInicio As String,
                                 ByVal pstr_FechaEmisionFinal As String,
                                 ByVal pstr_FechaRecepcionInicio As String,
                                 ByVal pstr_FechaRecepcionFinal As String,
                                 ByVal pstr_FechaPlazoInicio As String,
                                 ByVal pstr_FechaPlazoFinal As String,
                                 ByVal pstr_IdTipoOperacion As String,
                                 ByVal pstr_IdCentroCostoDestino As String,
                                 ByVal pstr_IdProyecto As String,
                                 ByVal pstr_IdCargo As String) As Boolean
            Try
                Dim objParametros() As String = {"var_IdRequisicion", pstr_IdRequisicion, _
                                                 "var_IdSolicitante", pstr_IdSolicitante, _
                                                 "var_FechaEmisionInicio", pstr_FechaEmisionInicio, _
                                                 "var_FechaEmisionFinal", pstr_FechaEmisionFinal, _
                                                 "var_FechaRecepcionInicio", pstr_FechaRecepcionInicio, _
                                                 "var_FechaRecepcionFinal", pstr_FechaRecepcionFinal, _
                                                 "var_FechaPlazoInicio", pstr_FechaPlazoInicio, _
                                                 "var_FechaPlazoFinal", pstr_FechaPlazoFinal, _
                                                 "var_IdTipoOperacion", pstr_IdTipoOperacion, _
                                                 "var_IdCentroCostoDestino", pstr_IdCentroCostoDestino, _
                                                 "var_IdProyecto", pstr_IdProyecto, _
                                                 "var_IdCargo", pstr_IdCargo}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Requisicion_Buscar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function BuscarxEstado(ByVal pstr_IdRequisicion As String,
                                 ByVal pstr_FechaEmisionInicio As String,
                                 ByVal pstr_FechaEmisionFinal As String,
                                 ByVal pstr_IdTipoOperacion As String,
                                 ByVal pstr_IdCentroCostoDestino As String,
                                 ByVal pstr_IdProyecto As String,
                                 ByVal pstr_Activo As String,
                                 ByVal pstr_Aprobado As String,
                                 ByVal pstr_Rechazado As String
                                 ) As Boolean
            Try
                Dim objParametros() As String = {"var_IdRequisicion", pstr_IdRequisicion, _
                                                 "var_FechaEmisionInicio", pstr_FechaEmisionInicio, _
                                                 "var_FechaEmisionFinal", pstr_FechaEmisionFinal, _
                                                 "var_IdTipoOperacion", pstr_IdTipoOperacion, _
                                                 "var_IdCentroCosto", pstr_IdCentroCostoDestino, _
                                                 "var_IdProyecto", pstr_IdProyecto, _
                                                 "var_Activo", pstr_Activo,
                                                 "var_Aprobado", pstr_Aprobado,
                                                 "var_Rechazado", pstr_Rechazado}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_RequisicionEstado_Buscar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function BuscarDetalle(ByVal pstr_IdRequisicion As String,
                                 ByVal pstr_FechaEmisionInicio As String,
                                 ByVal pstr_FechaEmisionFinal As String,
                                 ByVal pstr_IdTipoOperacion As String,
                                 ByVal pstr_IdCentroCostoDestino As String,
                                 ByVal pstr_IdProyecto As String,
                                 ByVal pstr_Activo As String,
                                 ByVal pstr_Aprobado As String,
                                 ByVal pstr_Rechazado As String
                                 ) As Boolean
            Try
                Dim objParametros() As String = {"var_IdRequisicion", pstr_IdRequisicion, _
                                                 "var_FechaEmisionInicio", pstr_FechaEmisionInicio, _
                                                 "var_FechaEmisionFinal", pstr_FechaEmisionFinal, _
                                                 "var_IdTipoOperacion", pstr_IdTipoOperacion, _
                                                 "var_IdCentroCosto", pstr_IdCentroCostoDestino, _
                                                 "var_IdProyecto", pstr_IdProyecto, _
                                                 "var_Activo", pstr_Activo,
                                                 "var_Aprobado", pstr_Aprobado,
                                                 "var_Rechazado", pstr_Rechazado}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_RequisicionDetalle_Buscar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function BuscarCotizacion(ByVal pstr_IdRequisicion As String) As Boolean

            Try
                Dim objParametros() As String = {"var_IdRequisicion", pstr_IdRequisicion}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_RequisicionCotizacion_Obtener", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                _exError = ex
                Return False
            End Try
        End Function


    End Class

End Namespace
