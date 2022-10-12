Namespace CONFIG

    Public Class EN_EntidadFinanciera
        Inherits GENERAL.EN_Empresa
#Region "Variables"
        Private _strIdEmpresa As String
        Private _strIdEntidadFinanciera As String = ""
        Private _strDescripcion As String = ""
        Private _strIdSunat As String = ""
#End Region
#Region "Propiedades"
        Public Property IdEntidadFinanciera() As String
            Get
                Return _strIdEntidadFinanciera
            End Get
            Set(ByVal value As String)
                _strIdEntidadFinanciera = value
            End Set
        End Property

        Public Property IdSunat() As String
            Get
                Return _strIdSunat
            End Get
            Set(ByVal value As String)
                _strIdSunat = value
            End Set
        End Property

        Public Property NombreEntidad() As String
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