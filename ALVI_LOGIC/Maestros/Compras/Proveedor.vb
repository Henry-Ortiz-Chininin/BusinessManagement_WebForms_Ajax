Imports AccesoDatos

Namespace Maestros.Compras

    Public Class Proveedor
#Region "VARIABLES"
        Private _strIdProveedor As String
        Private _strDireccion As String
        Private _strDescripcion As String
        Private _strEstado As String
        Private _strTelefono As String
        Private _strPersonaContacto As String
        Private _strTelPersonaContacto As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"

        Public Property IdProveedor() As String
            Get
                Return _strIdProveedor
            End Get
            Set(ByVal value As String)
                _strIdProveedor = value
            End Set
        End Property
        Public Property Direccion() As String
            Get
                Return _strDireccion
            End Get
            Set(ByVal value As String)
                _strDireccion = value
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
        Public Property Telefono() As String
            Get
                Return _strTelefono
            End Get
            Set(ByVal value As String)
                _strTelefono = value
            End Set
        End Property
        Public Property PersonaContacto() As String
            Get
                Return _strPersonaContacto
            End Get
            Set(ByVal value As String)
                _strPersonaContacto = value
            End Set
        End Property
        Public Property TelPersonaContacto() As String
            Get
                Return _strTelPersonaContacto
            End Get
            Set(ByVal value As String)
                _strTelPersonaContacto = value
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
                Dim objParametros() As String = {"var_IdProveedor", _strIdProveedor, _
                                                "var_Descripcion", _strDescripcion, _
                                                "var_Direccion", _strDireccion, _
                                                "chr_Estado", _strEstado, _
                                                "var_Usuario", _strUsuario, _
                                                "var_Telefono", _strTelefono, _
                                                "var_PersonaContacto", _strPersonaContacto, _
                                                "var_TelPersonaContacto", _strTelPersonaContacto}
                _objConexion.EjecutarComando("SGC_uspe_Proveedor_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdProveedor", _strIdProveedor}
                _objConexion.EjecutarComando("SGC_uspe_Proveedor_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdProveedor", _strIdProveedor}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Proveedor_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdProveedor = _dtbDatos.Rows(0)("var_IdProveedor")
                    _strDireccion = _dtbDatos.Rows(0)("var_Direccion")
                    _strDescripcion = _dtbDatos.Rows(0)("var_Descripcion")
                    _strEstado = _dtbDatos.Rows(0)("chr_Estado")
                    _strTelefono = _dtbDatos.Rows(0)("var_Telefono")
                    _strPersonaContacto = _dtbDatos.Rows(0)("var_PersonaContacto")
                    _strTelPersonaContacto = _dtbDatos.Rows(0)("var_TelPersonaContacto")
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
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspe_Proveedor_Listar")

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function



        Public Function Buscar1() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {
                                                 "var_Descripcion", _strDescripcion, _
                                                 "var_IdProveedor", _strIdProveedor}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Proveedor_Buscar1", objParametros)
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class

End Namespace