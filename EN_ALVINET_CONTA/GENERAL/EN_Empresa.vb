Namespace GENERAL

    Public Class EN_Empresa
        Inherits CONFIG.EN_Usuario
#Region "Variables"
        Private _strIdEmpresa As String = ""
        Private _strRuc As String = ""
        Private _strRazonSocial As String = ""
#End Region

#Region "Propiedades"
        Public Property IdEmpresa() As String
            Get
                Return _strIdEmpresa
            End Get
            Set(ByVal value As String)
                _strIdEmpresa = value
            End Set
        End Property
        Public Property Ruc() As String
            Get
                Return _strRuc
            End Get
            Set(ByVal value As String)
                _strRuc = value
            End Set
        End Property
        Public Property RazonSocial() As String
            Get
                Return _strRazonSocial
            End Get
            Set(ByVal value As String)
                _strRazonSocial = value
            End Set
        End Property



#End Region

    End Class
End Namespace