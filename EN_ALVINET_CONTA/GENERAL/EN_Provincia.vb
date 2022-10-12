Namespace GENERAL

    Public Class EN_Provincia
        Inherits EN_Departamento
#Region "Variables"

        Private _strIdProvincia As String = ""
        Private _strNomProvincia As String = ""




#End Region

#Region "Propiedades"
        Public Property IdProvincia() As String
            Get
                Return _strIdProvincia
            End Get
            Set(ByVal value As String)
                _strIdProvincia = value
            End Set
        End Property

        Public Property NomProvincia() As String
            Get
                Return _strNomProvincia
            End Get
            Set(ByVal value As String)
                _strNomProvincia = value
            End Set
        End Property



#End Region
    End Class
End Namespace