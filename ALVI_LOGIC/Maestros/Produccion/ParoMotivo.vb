Imports AccesoDatos

Namespace Maestros.Produccion
    Public Class ParoMotivo
#Region "VARIABLES"
        'Private _strIdAtributoTipo As String
        'reemplasamos "_strIdAtributotipo" por "_strIdParoMotivo"
        Private _strIdParoMotivo As String
        Private _strDescripcion As String
        Private _intPosicion As Int16

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"

        'Public Property IdAtributoTipo() As String
        '    Get
        '        Return _strIdAtributoTipo
        '    End Get
        '    Set(ByVal value As String)
        '        _strIdAtributoTipo = value
        '    End Set
        'End Property
        '
        'creamos la propiedad "IdParoMotivo"
        Public Property IdParoMotivo() As String
            Get
                Return _strIdParoMotivo
            End Get
            Set(ByVal value As String)
                _strIdParoMotivo = value
            End Set
        End Property
        Public Property Posicion() As Int16
            Get
                Return _intPosicion
            End Get
            Set(ByVal value As Int16)
                _intPosicion = value
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
                Dim objParametros() As String = {
                                                "var_idParoMotivo", _strIdParoMotivo, _
                                                "var_Descripcion", _strDescripcion, _
                                                "chr_Estado", _strEstado, _
                                                "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_uspe_MotivoParoMaquinaria_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_idParoMotivo", _strIdParoMotivo}
                _objConexion.EjecutarComando("SGC_uspe_MotivoParoMaquinaria_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_idParoMotivo", _strIdParoMotivo}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_MotivoParoMaquinaria_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdParoMotivo = _dtbDatos.Rows(0)("var_idParoMotivo")
                    _strDescripcion = _dtbDatos.Rows(0)("var_Descripcion")
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
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_MotivoParoMaquinaria_Listar")

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Buscar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_Descripcion", _strDescripcion}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_MotivoParoMaquinaria_Buscar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace
