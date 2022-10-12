Imports AccesoDatos
Namespace Costos.FichaCosto

    Public Class Material

#Region "VARIABLES"
        Private _strIdFicha As String
        Private _intSecuencialRuta As Integer
        Private _intSecuencialMaterial As Integer
        Private _strIdArticulo As String
        Private _dblCantidad As Double
        Private _strIdUnidadMedida As String
        Private _dblCosto As Double

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
        Public Property SecuencialMaterial As Integer
            Get
                Return _intSecuencialMaterial
            End Get
            Set(ByVal value As Integer)
                _intSecuencialMaterial = value
            End Set
        End Property
        Public Property IdArticulo As String
            Get
                Return _strIdArticulo
            End Get
            Set(ByVal value As String)
                _strIdArticulo = value
            End Set
        End Property
        Public Property Cantidad As Double
            Get
                Return _dblCantidad
            End Get
            Set(ByVal value As Double)
                _dblCantidad = value
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
        Public Property Costo As Double
            Get
                Return _dblCosto
            End Get
            Set(ByVal value As Double)
                _dblCosto = value
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
                                                 "int_SecuencialMaterial", _intSecuencialMaterial, _
                                                 "var_IdArticulo", _strIdArticulo, _
                                                 "num_Cantidad", _dblCantidad, _
                                                 "var_IdUnidadMedida", _strIdUnidadMedida, _
                                                 "num_Costo", _dblCosto, _
                                                 "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_usp_FichaMaterial_Registrar", objParametros)

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
                                                 "int_SecuencialRuta", _intSecuencialRuta, _
                                                 "int_SecuencialMaterial", _intSecuencialMaterial}
                _objConexion.EjecutarComando("SGC_usp_FichaMaterial_Eliminar", objParametros)

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
                                                 "int_SecuencialRuta", _intSecuencialRuta, _
                                                 "int_SecuencialMaterial", _intSecuencialMaterial}

                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_FichaMaterial_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdFicha = _dtbDatos.Rows(0)("var_IdFicha")
                    _intSecuencialRuta = _dtbDatos.Rows(0)("int_SecuencialRuta")
                    _intSecuencialMaterial = _dtbDatos.Rows(0)("int_SecuencialMaterial")
                    _strIdArticulo = _dtbDatos.Rows(0)("var_IdArticulo")
                    _dblCantidad = _dtbDatos.Rows(0)("num_Cantidad")
                    _dblCosto = _dtbDatos.Rows(0)("num_Costo")
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
                Dim objParametros() As String = {"var_IdFicha", _strIdFicha, _
                                                 "int_SecuencialRuta", _intSecuencialRuta}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_FichaMaterial_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region

    End Class

End Namespace