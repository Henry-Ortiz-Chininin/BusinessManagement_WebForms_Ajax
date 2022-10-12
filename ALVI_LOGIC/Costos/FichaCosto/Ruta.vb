Imports AccesoDatos
Namespace Costos.FichaCosto


    Public Class Ruta


#Region "VARIABLES"
        Private _strIdFicha As String
        Private _intSecuencialRuta As Integer
        Private _strIdMaquina As String
        Private _strIdProceso As String
        Private _strIdOperacion As String
        Private _dblCostoUnitario As Double
        Private _dblVelocidadSTD As Double
        Private _strIdUnidadMedida As String

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
        Public Property SecuencialRuta As Integer
            Get
                Return _intSecuencialRuta
            End Get
            Set(ByVal value As Integer)
                _intSecuencialRuta = value
            End Set
        End Property
        Public Property IdMaquina As String
            Get
                Return _strIdMaquina
            End Get
            Set(ByVal value As String)
                _strIdMaquina = value
            End Set
        End Property
        Public Property IdProceso As String
            Get
                Return _strIdProceso
            End Get
            Set(ByVal value As String)
                _strIdProceso = value
            End Set
        End Property
        Public Property IdOperacion As String
            Get
                Return _strIdOperacion
            End Get
            Set(ByVal value As String)
                _strIdOperacion = value
            End Set
        End Property
        Public Property CostoUnitario As Double
            Get
                Return _dblCostoUnitario
            End Get
            Set(ByVal value As Double)
                _dblCostoUnitario = value
            End Set
        End Property
        Public Property VelocidadSTD As Double
            Get
                Return _dblVelocidadSTD
            End Get
            Set(ByVal value As Double)
                _dblVelocidadSTD = value
            End Set
        End Property
        Public Property IdUnidadMedida As String
            Get
                Return _strIdUnidadMedida
            End Get
            Set(ByVal value As String)
                _strIdUnidadMedida = value
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
                                                 "int_SecuencialRuta", _intSecuencialRuta, _
                                                 "var_IdMaquina", _strIdMaquina, _
                                                 "chr_IdProceso", _strIdProceso, _
                                                 "var_IdOperacion", _strIdOperacion, _
                                                 "num_CostoUnitario", _dblCostoUnitario, _
                                                 "num_VelocidadSTD", _dblVelocidadSTD, _
                                                 "var_IdUnidadMedida", _strIdUnidadMedida, _
                                                 "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_usp_FichaRuta_Registrar", objParametros)

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
                                                  "int_SecuencialRuta", _intSecuencialRuta}
                _objConexion.EjecutarComando("SGC_usp_FichaRuta_Delete", objParametros)

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
                                                  "int_SecuencialRuta", _intSecuencialRuta}

                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_FichaRuta_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdFicha = _dtbDatos.Rows(0)("var_IdFicha")
                    _intSecuencialRuta = _dtbDatos.Rows(0)("int_SecuencialRuta")
                    _strIdMaquina = _dtbDatos.Rows(0)("var_IdMaquina")
                    _strIdProceso = _dtbDatos.Rows(0)("chr_IdProceso")
                    _strIdOperacion = _dtbDatos.Rows(0)("var_IdOperacion")
                    _dblCostoUnitario = _dtbDatos.Rows(0)("num_CostoUnitario")
                    _dblVelocidadSTD = _dtbDatos.Rows(0)("num_VelocidadSTD")
                    _strIdUnidadMedida = _dtbDatos.Rows(0)("var_IdUnidadMedida")

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
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_FichaRuta_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class

End Namespace