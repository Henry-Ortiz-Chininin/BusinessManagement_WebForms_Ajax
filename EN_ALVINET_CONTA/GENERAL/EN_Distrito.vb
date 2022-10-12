Namespace GENERAL

    Public Class EN_Distrito
        Inherits EN_Provincia
#Region "Variables"

        Private _strIDistrito As String = ""
        Private _strNomDistrito As String = ""




#End Region
#Region "Propiedades"
        Public Property IdDistrito() As String
            Get
                Return _strIDistrito
            End Get
            Set(ByVal value As String)
                _strIDistrito = value
            End Set
        End Property

        Public Property NomDistrito() As String
            Get
                Return _strNomDistrito
            End Get
            Set(ByVal value As String)
                _strNomDistrito = value
            End Set
        End Property



#End Region
    End Class
End Namespace