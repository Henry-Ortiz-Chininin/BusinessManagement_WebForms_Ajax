
Imports AccesoDatos
Imports ALVI_LOGIC

Namespace Proceso.Logistica
    Public Class Detraccion
        Private _strIdDocumentoCompra As String
        Private _strIdProveedor As String
        Private _strRazonSocial As String
        Private _dblImporteDetraccion As Double
        Private _strCuentaDetraccion As String
        Private _strFechaDetraccion As String
        Private _dblImporteDocumento As Double
        Private _strFechaEmision As String
        Private _strIdTipoDocumento As String
        Private _strTipoDocumento As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer
        Private _strNumero As String
        Private _dtbDatos As DataTable



        Public Property IdDocumentoCompra As String
            Get
                Return _strIdDocumentoCompra
            End Get
            Set(ByVal value As String)
                _strIdDocumentoCompra = value
            End Set
        End Property
        Public Property IdProveedor As String
            Get
                Return _strIdProveedor
            End Get
            Set(ByVal value As String)
                _strIdProveedor = value
            End Set
        End Property
        Public Property RazonSocial As String
            Get
                Return _strRazonSocial
            End Get
            Set(ByVal value As String)
                _strRazonSocial = value
            End Set
        End Property
        Public Property ImporteDetraccion As Double
            Get
                Return _dblImporteDetraccion
            End Get
            Set(ByVal value As Double)
                _dblImporteDetraccion = value
            End Set
        End Property
        Public Property CuentaDetraccion As String
            Get
                Return _strCuentaDetraccion
            End Get
            Set(ByVal value As String)
                _strCuentaDetraccion = value
            End Set
        End Property
        Public Property FechaDetraccion As String
            Get
                Return _strFechaDetraccion
            End Get
            Set(ByVal value As String)
                _strFechaDetraccion = value
            End Set
        End Property
        Public Property ImporteDocumento As Double
            Get
                Return _dblImporteDocumento
            End Get
            Set(ByVal value As Double)
                _dblImporteDocumento = value
            End Set
        End Property
        Public Property FechaEmision As String
            Get
                Return _strFechaEmision
            End Get
            Set(ByVal value As String)
                _strFechaEmision = value
            End Set
        End Property
        Public Property IdTipoDocumento As String
            Get
                Return _strIdTipoDocumento
            End Get
            Set(ByVal value As String)
                _strIdTipoDocumento = value
            End Set
        End Property
        Public Property TipoDocumento As String
            Get
                Return _strTipoDocumento
            End Get
            Set(ByVal value As String)
                _strTipoDocumento = value
            End Set
        End Property
        Public Property NumeroDocumento As String
            Get
                Return _strNumero
            End Get
            Set(ByVal value As String)
                _strNumero = value
            End Set
        End Property
        Public Function Registrar() As Boolean
            Try
                Dim objUtil As New General.Util

                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdDocumentoCompra", _strIdDocumentoCompra, _
                                                 "var_CuentaDetraccion", _strCuentaDetraccion, _
                                                 "var_FechaDetraccion", _strFechaDetraccion, _
                                                 "num_Importe", _dblImporteDetraccion}


                _strIdDocumentoCompra = _objConexion.ObtenerValor("SGC_usp_DetraccionCompra_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function


        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdDocumentoCompra", _strIdDocumentoCompra}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_DetraccionCompra_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdDocumentoCompra = _dtbDatos.Rows(0)("var_IdDocumentoCompra")
                    _strFechaEmision = Format(_dtbDatos.Rows(0)("dtm_Fecha"), "dd/MM/yyyy")
                    _strIdProveedor = _dtbDatos.Rows(0)("var_IdProveedor")
                    _strNumero = _dtbDatos.Rows(0)("var_NumeroDocumento")
                    _strTipoDocumento = _dtbDatos.Rows(0)("chr_IdTipoDocumento")
                    _strCuentaDetraccion = _dtbDatos.Rows(0)("var_CuentaDetraccion")
                    If Year(_dtbDatos.Rows(0)("dtm_FechaDetraccion")) < Now.Year Then
                        _strFechaDetraccion = ""
                    Else
                        _strFechaDetraccion = _dtbDatos.Rows(0)("dtm_FechaDetraccion")
                    End If
                    _dblImporteDetraccion = _dtbDatos.Rows(0)("num_ImporteDetraccion")
                    _dblImporteDocumento = _dtbDatos.Rows(0)("num_ImporteTotal")

                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
    End Class
End Namespace

