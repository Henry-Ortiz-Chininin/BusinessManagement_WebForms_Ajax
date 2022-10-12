Imports AccesoDatos

Namespace Maestros.Administracion
    Public Class TipoCambio
#Region "VARIABLES"
        Private _strIdTipoCambio As String
        Private _strFecha As String
        Private _dblCompra As Double
        Private _dblVenta As Double

        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"

        Public Property IdTipoCambio As String
            Get
                Return _strIdTipoCambio
            End Get
            Set(ByVal value As String)
                _strIdTipoCambio = value
            End Set
        End Property
        Public Property Fecha As String
            Get
                Return _strFecha
            End Get
            Set(ByVal value As String)
                _strFecha = value
            End Set
        End Property
        Public Property Compra As Double
            Get
                Return _dblCompra
            End Get
            Set(ByVal value As Double)
                _dblCompra = value
            End Set
        End Property
        Public Property Venta As Double
            Get
                Return _dblVenta
            End Get
            Set(ByVal value As Double)
                _dblVenta = value
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
                Dim objParametros() As String = {"var_IdTipoCambio", _strIdTipoCambio, _
                                                 "var_Fecha", _strFecha, _
                                                 "num_Compra", _dblCompra, _
                                                 "num_Venta", _dblVenta, _
                                                 "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_usp_TipoCambio_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdTipoCambio", _strIdTipoCambio}
                _objConexion.EjecutarComando("SGC_usp_TipoCambio_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdTipoCambio", _strIdTipoCambio}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_TipoCambio_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdTipoCambio = _dtbDatos.Rows(0)("var_IdTipoCambio")
                    _strFecha = _dtbDatos.Rows(0)("dtm_fecha")
                    _dblCompra = _dtbDatos.Rows(0)("num_Compra")
                    _dblVenta = _dtbDatos.Rows(0)("num_Venta")
                End If
                Return (_dtbDatos.Rows.Count > 0)
                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Listar(ByVal pstrFechaInicio As String, ByVal pstrFechaFinal As String) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_FechaInicio", pstrFechaInicio, _
                                                 "var_FechaFinal", pstrFechaFinal}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_TipoCambio_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace

