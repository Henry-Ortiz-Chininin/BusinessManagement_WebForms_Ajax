Namespace CONFIG

    Public Class EN_TipoCuenta
        Inherits EN_Contabilidad
#Region "Variables"
        Private _strIdTipoCuenta As String = ""
        Private _strDescripcion As String = ""

#End Region

#Region "Propiedades"
        Public Property IdTipoCuenta() As String
            Get
                Return _strIdTipoCuenta
            End Get
            Set(ByVal value As String)
                _strIdTipoCuenta = value
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

#End Region

    End Class
End Namespace