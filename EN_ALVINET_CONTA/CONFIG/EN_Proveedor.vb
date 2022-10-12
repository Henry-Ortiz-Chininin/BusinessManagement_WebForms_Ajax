Imports EN_ALVINET_CONTA.OPERACION

Namespace CONFIG

    Public Class EN_Proveedor
        Inherits GENERAL.EN_Empresa

#Region "Variable"

        Private _strIdEmpresa As String = ""
        Private _strIdProveedor As String = ""
        Private _strRazonsocial As String = ""
        Private _strRuc As String = ""
        Private _strDireccion As String = ""
        Private _strENacional As String = ""
        Private _strRetencion As String = ""
        Private _strDetraccion As Decimal
        Private _strEmpresaRazonSocial As String = ""
        Private _strTelefono As String = ""
        Private _strContacto As String = ""
        Private _strDni As String = ""


#End Region

#Region "Propiedades"
        Public Property IdProveedor As String
            Get
                Return _strIdProveedor
            End Get
            Set(ByVal value As String)
                _strIdProveedor = value
            End Set
        End Property

        Public Property Contacto() As String
            Get
                Return _strContacto
            End Get
            Set(ByVal value As String)
                _strContacto = value
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
        Public Property DNI() As String
            Get
                Return _strDni
            End Get
            Set(ByVal value As String)
                _strDni = value
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

        Public Property ENacional() As String
            Get
                Return _strENacional
            End Get
            Set(ByVal value As String)
                _strENacional = value
            End Set
        End Property

        Public Property EmpRazonSocial() As String
            Get
                Return _strEmpresaRazonSocial
            End Get
            Set(ByVal value As String)
                _strEmpresaRazonSocial = value
            End Set
        End Property

        Public Property Retencion As String
            Get
                Return _strRetencion
            End Get
            Set(ByVal value As String)
                _strRetencion = value
            End Set
        End Property

        Public Property Detraccion As Decimal
            Get
                Return _strDetraccion
            End Get
            Set(ByVal value As Decimal)
                _strDetraccion = value
            End Set
        End Property
#End Region

    End Class
End Namespace

