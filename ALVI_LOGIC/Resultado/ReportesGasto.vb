Imports AccesoDatos
Imports System.Data

Namespace Resultado

    Public Class ReportesGasto
#Region "VARIABLES"
        Private _dtbDatos As DataTable
        Private _strUsuario As String
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

#Region "METODOS"

        Public Function ReporteComparativo(ByVal pstrAnno1 As String, ByVal pstrMes1 As String, _
                                           ByVal pstrAnno2 As String, ByVal pstrMes2 As String) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"chr_Anno1", pstrAnno1, _
                                                 "chr_Mes1", pstrMes1, _
                                                 "chr_Anno2", pstrAnno2, _
                                                 "chr_Mes2", pstrMes2}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_GastoComparativo_Resumen", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function


        Public Function ReporteMargenContribucion(ByVal pstr_Anno As String, _
                                              ByVal pstr_Mes As String, _
                                              ByVal pstr_IdFamilia As String, _
                                            ByVal pstr_IdSubFamilia As String, _
                                            ByVal pstr_IdArticulo As String,
                                            ByVal pstr_IdCliente As String, _
                                            ByVal pstr_Mercado As String, _
                                            ByVal pstr_Descripcion As String) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_Anno", pstr_Anno, _
                                                "var_Mes", pstr_Mes, _
                                                "var_IdFamilia", pstr_IdFamilia, _
                                                "var_IdSubFamilia", pstr_IdSubFamilia, _
                                                "var_IdArticulo", pstr_IdArticulo, _
                                                "var_IdCliente", pstr_IdCliente, _
                                                 "var_Mercado", pstr_Mercado, _
                                                "var_Descripcion", pstr_Descripcion}


                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_MargenConstribucion_Obtener", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function


#End Region

    End Class
End Namespace

