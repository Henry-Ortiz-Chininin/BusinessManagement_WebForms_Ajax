Namespace CONFIG

    Public Class EN_PlanCuenta
        Inherits EN_PlanContable


#Region "Variables"
        Private _strTipo As String
        Private _strIdCuenta As String = ""
        Private _strCuenta As String = ""
        Private _strIdNivel As String = ""
        Private _strNivel As String = ""
        Private _strIdTipoAnalisis As String = ""
        Private _strTipoAnalisis As String = ""
        Private _strIdTipoCuenta As String = ""
        Private _strTipoCuenta As String = ""
        Private _strDifereciaCambio As String = ""
        Private _strIdCuentaEntidad As String = ""
        Private _strCuentaEntidad As String = ""
        Private _strConversionMoneda As String = ""
        Private _strIdEntidadFinanciera As String = ""
        Private _strEntidadFinanciera As String = ""
        Private _strMoneda As String = ""
        Private _strIdMoneda As String = ""

        Private _strIdCuentaPadre As String = ""
        Private _strCuentaDebe As String
        Private _strCuentaHaber As String = ""


#End Region

#Region "Propiedades"
        Public Property IdCuentaEntidad As String
            Get
                Return _strIdCuentaEntidad
            End Get
            Set(ByVal value As String)
                _strIdCuentaEntidad = value
            End Set
        End Property

        Public Property Moneda As String
            Get
                Return _strMoneda
            End Get
            Set(ByVal value As String)
                _strMoneda = value
            End Set
        End Property

        Public Property Nivel() As String
            Get
                Return _strNivel
            End Get
            Set(ByVal value As String)
                _strNivel = value
            End Set
        End Property

        Public Property Tipo() As String
            Get
                Return _strTipo
            End Get
            Set(ByVal value As String)
                _strTipo = value
            End Set
        End Property

        Public Property IdCuentaContable() As String
            Get
                Return _strIdCuenta
            End Get
            Set(ByVal value As String)
                _strIdCuenta = value
            End Set
        End Property

        Public Property CuentaContable() As String
            Get
                Return _strCuenta
            End Get
            Set(ByVal value As String)
                _strCuenta = value
            End Set
        End Property

        Public Property IdNivel() As String
            Get
                Return _strIdNivel
            End Get
            Set(ByVal value As String)
                _strIdNivel = value
            End Set
        End Property
        Public Property DiferenciaCambio() As String
            Get
                Return _strDifereciaCambio
            End Get
            Set(ByVal value As String)
                _strDifereciaCambio = value
            End Set
        End Property

        Public Property CuentaEntidad As String
            Get
                Return _strCuentaEntidad
            End Get
            Set(ByVal value As String)
                _strCuentaEntidad = value
            End Set
        End Property
        Public Property TipoAnalisis() As String
            Get
                Return _strTipoAnalisis
            End Get
            Set(ByVal value As String)
                _strTipoAnalisis = value
            End Set
        End Property
        Public Property IdTipoAnalisis() As String
            Get
                Return _strIdTipoAnalisis
            End Get
            Set(ByVal value As String)
                _strIdTipoAnalisis = value
            End Set
        End Property

        Public Property IdTipoCuenta() As String
            Get
                Return _strIdTipoCuenta
            End Get
            Set(ByVal value As String)
                _strIdTipoCuenta = value
            End Set
        End Property
        Public Property TipoCuenta() As String
            Get
                Return _strTipoCuenta
            End Get
            Set(ByVal value As String)
                _strTipoCuenta = value
            End Set
        End Property
        Public Property ConversionMoneda() As String
            Get
                Return _strConversionMoneda
            End Get
            Set(ByVal value As String)
                _strConversionMoneda = value
            End Set
        End Property
        Public Property EntidadFinanciera() As String
            Get
                Return _strEntidadFinanciera
            End Get
            Set(ByVal value As String)
                _strEntidadFinanciera = value
            End Set
        End Property

        Public Property IdEntidadFinanciera() As String
            Get
                Return _strIdEntidadFinanciera
            End Get
            Set(ByVal value As String)
                _strIdEntidadFinanciera = value
            End Set
        End Property

        Public Property CuentaDebe As String
            Get
                Return _strCuentaDebe
            End Get
            Set(ByVal value As String)
                _strCuentaDebe = value
            End Set
        End Property

        Public Property CuentaHaber() As String
            Get
                Return _strCuentaHaber
            End Get
            Set(ByVal value As String)
                _strCuentaHaber = value
            End Set
        End Property

        Public Property IdCuentaPadre() As String
            Get
                Return _strIdCuentaPadre
            End Get
            Set(ByVal value As String)
                _strIdCuentaPadre = value
            End Set
        End Property


#End Region

    End Class
End Namespace