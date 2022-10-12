Imports AccesoDatos

Namespace Proceso.Logistica
    Public Class ConsumoEnergetico
#Region "VARIABLES"
        Private _strAnno As String
        Private _strMes As String
        Private _strIdEnergetico As String
        Private _strIdUnidadMedida As String
        Private _dblConsumo As Double
        Private _dblImporte As Double

        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"

        Public Property Anno As String
            Get
                Return _strAnno
            End Get
            Set(ByVal value As String)
                _strAnno = value
            End Set
        End Property
        Public Property Mes As String
            Get
                Return _strMes
            End Get
            Set(ByVal value As String)
                _strMes = value
            End Set
        End Property
        Public Property Importe As Double
            Get
                Return _dblImporte
            End Get
            Set(ByVal value As Double)
                _dblImporte = value
            End Set
        End Property

        Public Property IdEnergetico() As String
            Get
                Return _strIdEnergetico
            End Get
            Set(ByVal value As String)
                _strIdEnergetico = value
            End Set
        End Property
        Public Property IdUnidadMedida() As String
            Get
                Return _strIdUnidadMedida
            End Get
            Set(ByVal value As String)
                _strIdUnidadMedida = value
            End Set
        End Property

        Public Property Consumo() As Double
            Get
                Return _dblConsumo
            End Get
            Set(ByVal value As Double)
                _dblConsumo = value
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
                                                 "var_IdEnergetico", _strIdEnergetico, _
                                                 "num_Consumo", _dblConsumo, _
                                                 "num_Importe", _dblImporte, _
                                                 "var_IdUnidadMedida", _strIdUnidadMedida, _
                                                "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_usp_ConsumoEnergetico_Registrar", objParametros)

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
                                                "var_IdEnergetico", _strIdEnergetico}
                _objConexion.EjecutarComando("SGC_usp_ConsumoEnergetico_Eliminar", objParametros)

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
                                                "var_IdEnergetico", _strIdEnergetico}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_ConsumoEnergetico_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _dblImporte = _dtbDatos.Rows(0)("num_Importe")
                    _strIdEnergetico = _dtbDatos.Rows(0)("var_IdEnergetico")
                    _strIdUnidadMedida = _dtbDatos.Rows(0)("var_IdUnidadMedida")
                    _dblConsumo = _dtbDatos.Rows(0)("num_Consumo")

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
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_ConsumoEnergetico_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace

