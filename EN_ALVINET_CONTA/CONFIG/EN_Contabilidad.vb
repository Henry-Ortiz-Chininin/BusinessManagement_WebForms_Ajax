Namespace CONFIG

    Public Class EN_Contabilidad
        Inherits GENERAL.EN_Empresa
#Region "Variables"
        Private _strIdContabilidad As String = ""
        Private _strDescripcion As String = ""
        Private _strIdMoneda As String = ""
        Private _strCuentaGananciaCambio As String = ""
        Private _strCuentaPerdidaCambio As String = ""
        Private _strCodMoneda As String = ""

#End Region
#Region "Propiedades"

        Public Property IdContabilidad() As String
            Get
                Return _strIdContabilidad
            End Get
            Set(ByVal value As String)
                _strIdContabilidad = value
            End Set
        End Property

        Public Property Contabilidad() As String
            Get
                Return _strDescripcion
            End Get
            Set(ByVal value As String)
                _strDescripcion = value
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

        Public Property CuentaGananciaCambio() As String
            Get
                Return _strCuentaGananciaCambio
            End Get
            Set(ByVal value As String)
                _strCuentaGananciaCambio = value
            End Set
        End Property

        Public Property CuentaPerdidaCambio() As String
            Get
                Return _strCuentaPerdidaCambio
            End Get
            Set(ByVal value As String)
                _strCuentaPerdidaCambio = value
            End Set
        End Property

#End Region
    End Class

End Namespace
