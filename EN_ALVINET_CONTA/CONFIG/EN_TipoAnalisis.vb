Namespace CONFIG

    Public Class EN_TipoAnalisis
        Inherits EN_Contabilidad
#Region "Variables"
        Private _strIdTipoAnalisis As String = ""
        Private _strDescripcion As String = ""

#End Region

#Region "Propiedades"

        Public Property IdTipoAnalisis() As String
            Get
                Return _strIdTipoAnalisis
            End Get
            Set(ByVal value As String)
                _strIdTipoAnalisis = value
            End Set
        End Property

        Public Property TipoAnalisis() As String
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