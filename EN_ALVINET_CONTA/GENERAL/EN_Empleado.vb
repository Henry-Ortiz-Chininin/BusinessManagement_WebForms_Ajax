Namespace GENERAL
    Public Class EN_Empleado
        Inherits EN_Empresa
#Region "Variables"
        Private _strIdEmpleado As String = ""
        Private _strNombre As String = ""


#End Region
#Region "Propiedades"



        Public Property IdEmpleado() As String
            Get
                Return _strIdEmpleado
            End Get
            Set(ByVal value As String)
                _strIdEmpleado = value
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