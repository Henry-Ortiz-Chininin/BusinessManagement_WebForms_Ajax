Imports AccesoDatos

Namespace Maestros.Articulo

    Public Class SubFamilia
#Region "VARIABLES"
        Private _strIdSubFamilia As String
        Private _strIdFamilia As String
        Private _strDescripcion As String
        Private _strIdUnidadMedida As String

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"

        Public Property IdSubFamilia() As String
            Get
                Return _strIdSubFamilia
            End Get
            Set(ByVal value As String)
                _strIdSubFamilia = value
            End Set
        End Property

        Public Property IdFamilia() As String
            Get
                Return _strIdFamilia
            End Get
            Set(ByVal value As String)
                _strIdFamilia = value
            End Set
        End Property
        Public Property Descripcion() As String
            Get
                Return _strDescripcion
            End Get
            Set(ByVal value As String)
                _strDescripcion = value
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
                Dim objParametros() As String = {"var_IdSubFamilia", _strIdSubFamilia, _
                                                "chr_IdFamilia", _strIdFamilia, _
                                                "var_Descripcion", _strDescripcion, _
                                                "var_IdUnidadMedida", _strIdUnidadMedida, _
                                                "chr_Estado", _strEstado, _
                                                "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_uspe_SubFamilia_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdSubFamilia", _strIdSubFamilia}
                _objConexion.EjecutarComando("SGC_uspe_SubFamilia_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdSubFamilia", _strIdSubFamilia}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_SubFamilia_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdSubFamilia = _dtbDatos.Rows(0)("var_IdSubfamilia")
                    _strIdFamilia = _dtbDatos.Rows(0)("chr_IdFamilia")
                    _strDescripcion = _dtbDatos.Rows(0)("var_Descripcion")
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
                Dim objParametros() As String = {"var_IdFamilia", _strIdFamilia}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_SubFamilia_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace