Namespace CONFIG

    Public Class EN_EjercicioEmpresa
        Inherits EN_Ejercicio

#Region "Variables"
        Private _strIdEjercicioEmpresa As String = ""
#End Region

#Region "Propiedades"

        Public Property IdEjercicioEmpresa() As String
            Get
                Return _strIdEjercicioEmpresa
            End Get
            Set(ByVal value As String)
                _strIdEjercicioEmpresa = value
            End Set
        End Property

#End Region

    End Class
End Namespace