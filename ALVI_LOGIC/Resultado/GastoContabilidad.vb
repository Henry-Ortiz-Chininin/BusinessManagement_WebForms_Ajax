Imports AccesoDatos
Imports ALVI_LOGIC
Imports System.Data

Namespace Resultado
    Public Class GastoContabilidad

#Region "VARIABLES"
        Private _strAnno As String
        Private _strMes As String
        Private _strIdCentroCosto As String
        Private _strIdClaseContable As String
        Private _strIdClaseFV As String
        Private _dblImporte As Double

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"
        Public Property Anno() As String
            Get
                Return _strAnno
            End Get
            Set(ByVal value As String)
                _strAnno = value
            End Set
        End Property
        Public Property Mes() As String
            Get
                Return _strMes
            End Get
            Set(ByVal value As String)
                _strMes = value
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
        Public Property IdClaseContabilidad() As String
            Get
                Return _strIdClaseContable
            End Get
            Set(ByVal value As String)
                _strIdClaseContable = value
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

        Public Property Importe() As Double
            Get
                Return _dblImporte
            End Get
            Set(ByVal value As Double)
                _dblImporte = value
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
                Dim objParametros() As String = {"chr_Anno", _strAnno, _
                                                 "chr_Mes", _strMes, _
                                                 "var_IdCentroCosto", _strIdCentroCosto, _
                                                "var_IdClaseContable", _strIdClaseContable, _
                                                "var_IdClaseFV", _strIdClaseFV, _
                                                "num_Importe", _dblImporte, _
                                                "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_usp_GastoContable_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"chr_Anno", _strAnno, _
                                                 "chr_Mes", _strMes, _
                                                 "var_IdCentroCosto", _strIdCentroCosto, _
                                                "var_IdClaseContable", _strIdClaseContable, _
                                                "var_IdClaseFV", _strIdClaseFV}
                _objConexion.EjecutarComando("SGC_usp_GastoContable_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"chr_Anno", _strAnno, _
                                                 "chr_Mes", _strMes, _
                                                 "var_IdCentroCosto", _strIdCentroCosto, _
                                                "var_IdClaseContable", _strIdClaseContable, _
                                                "var_IdClaseFV", _strIdClaseFV}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_GastoContable_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdCentroCosto = _dtbDatos.Rows(0)("var_Descripcion")
                    _strIdClaseContable = _dtbDatos.Rows(0)("var_IdClaseContable")
                    _strIdClaseFV = _dtbDatos.Rows(0)("var_IdClaseFV")
                    _dblImporte = _dtbDatos.Rows(0)("num_Importe")
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
                Dim objParametros() As String = {"chr_Anno", _strAnno, _
                                                 "chr_Mes", _strMes}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_GastoContable_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function


        Public Function CostoProduccionListar(ByVal pstr_Anno As String, _
                                              ByVal pstr_Mes As String, _
                                              ByVal pstr_IdFamilia As String, _
                                            ByVal pstr_IdSubFamilia As String, _
                                            ByVal pstr_IdArticulo As String,
                                            ByVal pstr_IdOrden As String, _
                                            ByVal pstr_Descripcion As String) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_Anno", pstr_Anno, _
                                                 "var_Mes", pstr_Mes, _
                                                 "var_IdFamilia", pstr_IdFamilia, _
                                                 "var_IdSubFamilia", pstr_IdSubFamilia, _
                                                 "var_IdArticulo", pstr_IdArticulo, _
                                                 "var_IdOrden", pstr_IdOrden, _
                                                 "var_Descripcion", pstr_Descripcion}

                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_CostoContable_Obtener", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace

