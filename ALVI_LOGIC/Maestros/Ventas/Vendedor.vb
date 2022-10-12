Imports AccesoDatos

Namespace Maestros.Ventas
    Public Class Vendedor
#Region "VARIABLES"
        Private _strIdVendedor As String
        Private _strNombre As String
        Private _strApellidoMaterno As String
        Private _strApellidoPaterno As String

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"

        Public Property IdVendedor() As String
            Get
                Return _strIdVendedor
            End Get
            Set(ByVal value As String)
                _strIdVendedor = value
            End Set
        End Property
        Public Property Nombre() As String
            Get
                Return _strNombre
            End Get
            Set(ByVal value As String)
                _strNombre = value
            End Set
        End Property
        Public Property ApellidoMaterno() As String
            Get
                Return _strApellidoMaterno
            End Get
            Set(ByVal value As String)
                _strApellidoMaterno = value
            End Set
        End Property
        Public Property ApellidoPaterno() As String
            Get
                Return _strApellidoPaterno
            End Get
            Set(ByVal value As String)
                _strApellidoPaterno = value
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
                Dim objParametros() As String = {"var_IdVendedor", _strIdVendedor, _
                                                 "var_NombreVendedor", _strNombre, _
                                                 "var_ApellidosVendedor", _strApellidoPaterno, _
                                                 "chr_IdEstado", _strEstado, _
                                                 "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_usp_VendedorPtoVenta_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdVendedor", _strIdVendedor}
                _objConexion.EjecutarComando("SGC_usp_VendedorPtoVenta_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdVendedor", _strIdVendedor}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_VendedorPtoVenta_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdVendedor = _dtbDatos.Rows(0)("var_IdVendedor")
                    _strNombre = _dtbDatos.Rows(0)("var_NombreVendedor")
                    _strApellidoPaterno = _dtbDatos.Rows(0)("var_ApellidosVendedor")
                    _strEstado = _dtbDatos.Rows(0)("chr_IdEstado")

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
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_VendedorPtoVenta_Listar")

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace
