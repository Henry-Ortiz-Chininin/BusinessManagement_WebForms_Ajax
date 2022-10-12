Namespace CONFIG

    Public Class EN_CuentaEntidad
        Inherits EN_EntidadFinanciera

#Region "Variables"

        Private _strIdEmpresa As String = ""
        Private _strIdEntidadFinanciera As String = ""
        Private _strSecuencia As String = ""
        Private _strIdMoneda As String = ""
        Private _strNumeroCuenta As String = ""

        Private _strRazonSocial As String = ""
        Private _strDesEntidadFinanciera As String = ""
        Private _strDesMoneda As String = ""

#End Region

#Region "Propiedades"
        Public Property Secuencia As String
            Get
                Return _strSecuencia
            End Get
            Set(ByVal value As String)
                _strSecuencia = value
            End Set
        End Property

        Public Property IdMoneda() As String
            Get
                Return _strIdMoneda
            End Get
            Set(ByVal value As String)
                _strIdMoneda = value
            End Set
        End Property

        Public Property NumeroCuenta() As String
            Get
                Return _strNumeroCuenta
            End Get
            Set(ByVal value As String)
                _strNumeroCuenta = value
            End Set
        End Property

        Public Property NombreEntidad() As String
            Get
                Return _strDesEntidadFinanciera
            End Get
            Set(ByVal value As String)
                _strDesEntidadFinanciera = value
            End Set
        End Property

        Public Property Moneda() As String
            Get
                Return _strDesMoneda
            End Get
            Set(ByVal value As String)
                _strDesMoneda = value
            End Set
        End Property

#End Region

    End Class
End Namespace