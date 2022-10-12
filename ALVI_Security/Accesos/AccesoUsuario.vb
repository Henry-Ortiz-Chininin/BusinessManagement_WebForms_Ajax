Imports AccesoDatos

Namespace Accesos
    Public Class AccesoUsuario
#Region "VARIABLES"
        Private _strIdAccesoTipo As String
        Private _strIdUsuario As String
        Private _intSecuencia As Int16

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatos.AccesoDatosSQLServer
        '  AccesoDatosVBSQLServer

#End Region

#Region "PROPIEDADES"

        Public Property IdAccesoTipo() As String
            Get
                Return _strIdAccesoTipo
            End Get
            Set(ByVal value As String)
                _strIdAccesoTipo = value
            End Set
        End Property
        Public Property IdUsuario() As String
            Get
                Return _strIdUsuario
            End Get
            Set(ByVal value As String)
                _strIdUsuario = value
            End Set
        End Property
        Public Property Secuencia() As Int16
            Get
                Return _intSecuencia
            End Get
            Set(ByVal value As Int16)
                _intSecuencia = value
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
                _objConexion = New AccesoDatos.AccesoDatosSQLServer
                Dim objParametros() As String = {"chr_IdAccesoTipo", _strIdAccesoTipo, _
                                                 "var_IdUsuario", _strIdUsuario, _
                                                 "int_Secuencia", _intSecuencia, _
                                                "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_usps_AccesoUsuario_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatos.AccesoDatosSQLServer
                Dim objParametros() As String = {"chr_IdAccesoTipo", _strIdAccesoTipo, _
                                                 "var_IdUsuario", _strIdUsuario, _
                                                 "int_Secuencia", _intSecuencia}
                _objConexion.EjecutarComando("SGC_usps_AccesoUsuario_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatos.AccesoDatosSQLServer
                Dim objParametros() As String = {"chr_IdAccesoTipo", _strIdAccesoTipo, _
                                                 "var_IdUsuario", _strIdUsuario, _
                                                 "int_Secuencia", _intSecuencia}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usps_AccesoUsuario_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdAccesoTipo = _dtbDatos.Rows(0)("chr_IdAccesoTipo")
                    _strIdUsuario = _dtbDatos.Rows(0)("var_IdUsuario")
                    _intSecuencia = _dtbDatos.Rows(0)("int_Secuencia")

                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Listar() As Boolean
            Try
                Dim objParametros() As String = {"chr_IdAccesoTipo", _strIdAccesoTipo, _
                                                 "var_IdUsuario", _strIdUsuario}
                _objConexion = New AccesoDatos.AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usps_AccesoUsuario_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace

