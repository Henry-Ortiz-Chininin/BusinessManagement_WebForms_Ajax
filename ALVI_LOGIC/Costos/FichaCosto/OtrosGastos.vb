Imports AccesoDatos
Namespace Costos.FichaCosto


    Public Class OtrosGastos
#Region "VARIABLES"
        Private _strIdFicha As String
        Private _intIdOtroGasto As Integer
        Private _dblImporte As Double


        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer
#End Region

#Region "PROPIEDADES"

        Public Property IdFicha As String
            Get
                Return _strIdFicha
            End Get
            Set(ByVal value As String)
                _strIdFicha = value
            End Set
        End Property
        Public Property IdOtroGasto As Integer
            Get
                Return _intIdOtroGasto
            End Get
            Set(ByVal value As Integer)
                _intIdOtroGasto = value
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
                Dim objParametros() As String = {"var_IdFicha", _strIdFicha, _
                                                 "int_IdOtroGasto", _intIdOtroGasto, _
                                                 "num_Importe", _dblImporte}
                _objConexion.EjecutarComando("SGC_usp_FichaOtrosGastos_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdFicha", _strIdFicha, _
                                                 "int_IdOtroGasto", _intIdOtroGasto}
                _objConexion.EjecutarComando("SGC_usp_FichaOtrosGastos_Delete", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdFicha", _strIdFicha, _
                                               "int_IdOtroGasto", _intIdOtroGasto}

                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_FichaOtrosGastos_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdFicha = _dtbDatos.Rows(0)("var_IdFicha")
                    _intIdOtroGasto = _dtbDatos.Rows(0)("int_IdOtroGasto")
                    _dblImporte = _dtbDatos.Rows(0)("num_Importe")

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
                Dim objParametros() As String = {"var_IdFicha", _strIdFicha}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_FichaOtrosGastos_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function ListarConceptos() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_OtrosGasto_Listar")

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class

End Namespace