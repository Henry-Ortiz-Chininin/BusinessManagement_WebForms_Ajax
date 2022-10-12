Namespace CONFIG

    Public Class EN_NivelPlan
        Inherits EN_Contabilidad

#Region "Variables"
        Private _strIdEmpresa As String
        Private _strIdNivel As String
        Private _strDescripcion As String
        Private _strRazonSocial As String
        Private _strId As String
        Private _strNombre As String
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
        Public Property IdNivel() As String
            Get
                Return _strIdNivel
            End Get
            Set(ByVal value As String)
                _strIdNivel = value
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
        Public Property RazonSocial() As String
            Get
                Return _strRazonSocial
            End Get
            Set(ByVal value As String)
                _strRazonSocial = value
            End Set
        End Property
        Public Property ID() As String
            Get
                Return _strId
            End Get
            Set(ByVal value As String)
                _strId = value
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
#End Region

    End Class
End Namespace