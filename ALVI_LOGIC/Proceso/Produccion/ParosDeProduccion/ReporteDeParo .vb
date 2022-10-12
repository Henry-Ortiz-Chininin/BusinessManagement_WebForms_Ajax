﻿Imports AccesoDatos
Imports System.Data
Namespace Proceso.Produccion.ParosDeProduccion

    Public Class ReporteDeParo

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
        Public Function Obtener_ParoProduccion(ByVal pstrFechaInicio As String, _
                                            ByVal pstrFechaFin As String, _
                                            ByVal pstrMaquina As String) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_FechaInicio", pstrFechaInicio, _
                                                 "var_FechaFin", pstrFechaFin, _
                                                 "var_IdMaquina", pstrMaquina}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_ParoProduccion_Obtener", objParametros)

                Return (_dtbDatos.Rows.Count > 0)

            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try

        End Function

    End Class
End Namespace
