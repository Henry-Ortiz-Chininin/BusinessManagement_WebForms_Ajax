

Imports AccesoDatos
Imports ALVI_LOGIC

Namespace Maestros.Compras
    Public Class Condicion
        Private _strIdCondicion As String
        Private _strDescripcion As String
        Private _dblMonto As Double
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _strEstado As String




        Public Property IdCondicion As String
            Get
                Return _strIdCondicion
            End Get
            Set(ByVal value As String)
                _strIdCondicion = value
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

        Public Property Estado As String
            Get
                Return _strEstado
            End Get
            Set(ByVal value As String)
                _strEstado = value
            End Set
        End Property



        Public Property Monto As Double
            Get
                Return _dblMonto
            End Get
            Set(ByVal value As Double)
                _dblMonto = value
            End Set
        End Property


        Public Property Descripcion As String
            Get
                Return _strDescripcion
            End Get
            Set(ByVal value As String)
                _strDescripcion = value
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


        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdCondicion", _strIdCondicion, _
                                                 "var_Descripcion", _strDescripcion, _
                                                 "dec_MontoLimitado", _dblMonto, _
                                                 "chr_Estado ", _strEstado, _
                                                 "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SCP_usp_Condicion_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function



        Public Function Listar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Condicion_Listar")

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function



        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdCondicion", _strIdCondicion}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Condicion_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdCondicion = _dtbDatos.Rows(0)("var_IdCondicion")
                    _strDescripcion = _dtbDatos.Rows(0)("var_Descripcion")
                    _dblMonto = _dtbDatos.Rows(0)("dec_MontoLimitado")


                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function



        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdCondicion", _strIdCondicion}
                _objConexion.EjecutarComando("SGC_usp_Condicion_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function



        Public Function Buscar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_Descripcion", _strDescripcion}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Condicion_Buscar", objParametros)
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function


    End Class





End Namespace

