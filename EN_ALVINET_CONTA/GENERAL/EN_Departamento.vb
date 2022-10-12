Namespace GENERAL
    Public Class EN_Departamento
#Region "Variables"

        Private _strIdDepartamento As String = ""
        Private _strNomDepartamento As String = ""

#End Region

#Region "Propiedades"
        Public Property IdDepartamento() As String
            Get
                Return _strIdDepartamento
            End Get
            Set(ByVal value As String)
                _strIdDepartamento = value
            End Set
        End Property

        Public Property NomDepartamento() As String
            Get
                Return _strNomDepartamento
            End Get
            Set(ByVal value As String)
                _strNomDepartamento = value
            End Set
        End Property



#End Region
    End Class
End Namespace