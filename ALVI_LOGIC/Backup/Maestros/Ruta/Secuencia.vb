Imports AccesoDatos

Namespace Maestros.Ruta
    Public Class Secuencia
#Region "VARIABLES"
        Private _strIdRuta As String
        Private _intSecuencia As Int16
        Private _strIdMaquina As String
        Private _strIdProceso As String
        Private _strIdUnidadMedida As String
        Private _dblVelocidadSTD As Double
        Private _strIdOperacion As String

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"

        Public Property IdRuta() As String
            Get
                Return _strIdRuta
            End Get
            Set(ByVal value As String)
                _strIdRuta = value
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
        Public Property IdMaquina() As String
            Get
                Return _strIdMaquina
            End Get
            Set(ByVal value As String)
                _strIdMaquina = value
            End Set
        End Property
        Public Property IdProceso() As String
            Get
                Return _strIdProceso
            End Get
            Set(ByVal value As String)
                _strIdProceso = value
            End Set
        End Property
        Public Property IdOperacion() As String
            Get
                Return _strIdOperacion
            End Get
            Set(ByVal value As String)
                _strIdOperacion = value
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
        Public Property VelocidadSTD() As Double
            Get
                Return _dblVelocidadSTD
            End Get
            Set(ByVal value As Double)
                _dblVelocidadSTD = value
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
                Dim objParametros() As String = {"var_IdRuta", _strIdRuta, _
                                                "int_SecuencialRuta", _intSecuencia, _
                                                "var_IdMaquina", _strIdMaquina, _
                                                "chr_IdProceso", _strIdProceso, _
                                                "var_IdOperacion", _strIdOperacion, _
                                                "num_VelocidadStd", _dblVelocidadSTD, _
                                                "var_IdUnidadMedida", _strIdUnidadMedida, _
                                                "chr_Estado", _strEstado, _
                                                "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_uspe_RutaSecuencia_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdRuta", _strIdRuta, _
                                                 "int_SecuencialRuta", _intSecuencia}
                _objConexion.EjecutarComando("SGC_uspe_RutaSecuencia_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdRuta", _strIdRuta, _
                                                 "int_SecuencialRuta", _intSecuencia}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_RutaSecuencia_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdRuta = _dtbDatos.Rows(0)("var_IdRuta")
                    _intSecuencia = _dtbDatos.Rows(0)("int_SecuencialRuta")
                    _strIdMaquina = _dtbDatos.Rows(0)("var_IdMaquina")
                    _strIdProceso = _dtbDatos.Rows(0)("chr_IdProceso")
                    _strIdOperacion = _dtbDatos.Rows(0)("var_IdOperacion")
                    _dblVelocidadSTD = _dtbDatos.Rows(0)("num_VelocidadSTD")
                    _strIdUnidadMedida = _dtbDatos.Rows(0)("var_IdUnidadMedida")
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
                Dim objParametros() As String = {"var_IdRuta", _strIdRuta}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_RutaSecuencia_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace

