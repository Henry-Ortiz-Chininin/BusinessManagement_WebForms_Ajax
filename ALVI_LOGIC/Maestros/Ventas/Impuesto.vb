Imports AccesoDatos

Namespace Maestros.Produccion
    Public Class Impuesto
#Region "VARIABLES"
        Private _intCodigo As String
        Private _dblImpuesto1 As Double
        Private _dblImpuesto2 As Double
        Private _dblImpuesto3 As Double
        Private _dblDetraccion As Double
        Private _dblPercepcion As Double
        Private _dblRetencion As Double
        Private _strFechaCaducidad As String
        Private _strFechaInicio As String
        Private _strFechaFin As String
        Private _strIdTipo As String

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region
#Region "PROPIEDADES"

        Public Property Codigo() As String
            Get
                Return _intCodigo
            End Get
            Set(ByVal value As String)
                _intCodigo = value
            End Set
        End Property
        Public Property Impuesto1() As Double
            Get
                Return _dblImpuesto1
            End Get
            Set(ByVal value As Double)
                _dblImpuesto1 = value
            End Set
        End Property
        Public Property Impuesto2() As Double
            Get
                Return _dblImpuesto2
            End Get
            Set(ByVal value As Double)
                _dblImpuesto2 = value
            End Set
        End Property
        Public Property Impuesto3() As Double
            Get
                Return _dblImpuesto3
            End Get
            Set(ByVal value As Double)
                _dblImpuesto3 = value
            End Set
        End Property
        Public Property Detraccion() As Double
            Get
                Return _dblDetraccion
            End Get
            Set(ByVal value As Double)
                _dblDetraccion = value
            End Set
        End Property
        Public Property Percepcion() As Double
            Get
                Return _dblPercepcion
            End Get
            Set(ByVal value As Double)
                _dblPercepcion = value
            End Set
        End Property
        Public Property Retencion() As Double
            Get
                Return _dblRetencion
            End Get
            Set(ByVal value As Double)
                _dblRetencion = value
            End Set
        End Property
        Public Property FechaCaducidad() As String
            Get
                Return _strFechaCaducidad
            End Get
            Set(ByVal value As String)
                _strFechaCaducidad = value
            End Set
        End Property
        Public Property IdTipo() As String
            Get
                Return _strIdTipo
            End Get
            Set(ByVal value As String)
                _strIdTipo = value
            End Set
        End Property
        Public Property FechaInicio() As String
            Get
                Return _strFechaInicio
            End Get
            Set(ByVal value As String)
                _strFechaInicio = value
            End Set
        End Property
        Public Property FechaFin() As String
            Get
                Return _strFechaFin
            End Get
            Set(ByVal value As String)
                _strFechaFin = value
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
                Dim objParametros() As String = {"int_Secuencia", _intCodigo, _
                                                "num_Impuesto1", _dblImpuesto1, _
                                                "num_Impuesto2", _dblImpuesto2, _
                                                "num_Impuesto3", _dblImpuesto3, _
                                                "num_Detraccion", _dblDetraccion, _
                                                 "num_Percepcion", _dblPercepcion, _
                                                 "num_Retencion", _dblRetencion, _
                                                 "var_FechaCaducidad", _strFechaCaducidad, _
                                                "chr_Estado", _strEstado, _
                                                "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_uspe_Impuesto_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Buscar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_FechaInicio", _strFechaInicio, _
                                                 "var_FechaFin", _strFechaFin, _
                                                 "var_IdTipo", _strIdTipo}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Impuesto_Buscar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"int_Secuencia", _intCodigo}
                _objConexion.EjecutarComando("SGC_uspe_Impuesto_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"int_Secuencia", _intCodigo}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Impuesto_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _intCodigo = _dtbDatos.Rows(0)("int_Secuencia")
                    _dblImpuesto1 = _dtbDatos.Rows(0)("num_Impuesto1")
                    _dblImpuesto2 = _dtbDatos.Rows(0)("num_Impuesto2")
                    _dblImpuesto3 = _dtbDatos.Rows(0)("num_Impuesto3")
                    _dblDetraccion = _dtbDatos.Rows(0)("num_Detraccion")
                    _dblPercepcion = _dtbDatos.Rows(0)("num_Percepcion")
                    _dblRetencion = _dtbDatos.Rows(0)("num_Retencion")
                    _strFechaCaducidad = _dtbDatos.Rows(0)("dtm_FechaVencimiento")
                    _strEstado = _dtbDatos.Rows(0)("chr_Estado")
                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function ObtenerImpuesto1() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Impuesto_ObtenerImpuesto1")
                If _dtbDatos.Rows.Count > 0 Then
                    _dblImpuesto1 = _dtbDatos.Rows(0)("num_Impuesto1")
                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function ObtenerImpuesto2() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Impuesto_ObtenerImpuesto2")
                If _dtbDatos.Rows.Count > 0 Then
                    _dblImpuesto2 = _dtbDatos.Rows(0)("num_Impuesto2")
                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function ObtenerImpuesto3() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Impuesto_ObtenerImpuesto3")
                If _dtbDatos.Rows.Count > 0 Then
                    _dblImpuesto3 = _dtbDatos.Rows(0)("num_Impuesto3")
                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function ObtenerDetraccion() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Impuesto_ObtenerDetraccion")
                If _dtbDatos.Rows.Count > 0 Then
                    _dblDetraccion = _dtbDatos.Rows(0)("num_Detraccion")
                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function ObtenerPercepcion() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Impuesto_ObtenerPercepcion")
                If _dtbDatos.Rows.Count > 0 Then
                    _dblPercepcion = _dtbDatos.Rows(0)("num_Percepcion")
                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function ObtenerRetencion() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Impuesto_ObtenerRetencion")
                If _dtbDatos.Rows.Count > 0 Then
                    _dblRetencion = _dtbDatos.Rows(0)("num_Retencion")
                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace

