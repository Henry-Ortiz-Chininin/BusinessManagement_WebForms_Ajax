Imports AccesoDatos

Namespace Costos.FichaCosto
    Public Class Resumen

#Region "VARIABLES"
        Private _strIdFicha As String
        Private _intSecuencial As Integer
        Private _strTipo As String
        Private _strDescripcion As String
        Private _dblCriterio1 As Double
        Private _dblCriterio2 As Double
        Private _dblCriterio3 As Double
        Private _dblCriterio4 As Double
        Private _dblCriterio5 As Double
        Private _dblCriterio6 As Double
        Private _dblCriterio7 As Double

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

        Public Property Secuencial As Integer
            Get
                Return _intSecuencial
            End Get
            Set(ByVal value As Integer)
                _intSecuencial = value
            End Set
        End Property
        Public Property Tipo As String
            Get
                Return _strTipo
            End Get
            Set(ByVal value As String)
                _strTipo = value
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
        Public Property Criterio1 As Double
            Get
                Return _dblCriterio1
            End Get
            Set(ByVal value As Double)
                _dblCriterio1 = value
            End Set
        End Property
        Public Property Criterio2 As Double
            Get
                Return _dblCriterio2
            End Get
            Set(ByVal value As Double)
                _dblCriterio2 = value
            End Set
        End Property
        Public Property Criterio3 As Double
            Get
                Return _dblCriterio3
            End Get
            Set(ByVal value As Double)
                _dblCriterio3 = value
            End Set
        End Property
        Public Property Criterio4 As Double
            Get
                Return _dblCriterio4
            End Get
            Set(ByVal value As Double)
                _dblCriterio4 = value
            End Set
        End Property
        Public Property Criterio5 As Double
            Get
                Return _dblCriterio5
            End Get
            Set(ByVal value As Double)
                _dblCriterio5 = value
            End Set
        End Property
        Public Property Criterio6 As Double
            Get
                Return _dblCriterio6
            End Get
            Set(ByVal value As Double)
                _dblCriterio6 = value
            End Set
        End Property
        Public Property Criterio7 As Double
            Get
                Return _dblCriterio7
            End Get
            Set(ByVal value As Double)
                _dblCriterio7 = value
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
        Public Function Generar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdFicha", _strIdFicha, _
                                                 "var_Usuario", _strUsuario}
                _strIdFicha = _objConexion.ObtenerValor("SGC_usp_FichaCosto_Generar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdFicha", _strIdFicha}

                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_FichaResumen_Obtener", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Previo() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdFicha", _strIdFicha}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_FichaCosto_Previo", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region


    End Class
End Namespace

