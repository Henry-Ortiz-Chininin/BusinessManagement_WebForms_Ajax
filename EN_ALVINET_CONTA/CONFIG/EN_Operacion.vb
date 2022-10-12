Namespace CONFIG

    Public Class EN_Operacion
        Inherits EN_PlanContable
#Region "Variables"
        Private _strIdEmpresa As String = ""
        Private _strIdContabilidad As String = ""
        Private _strIdOperacion As String = ""
        Private _strDescripcion As String = ""
        Private _strIdSunat As String = ""
        Private _strFlag As String = ""
        Private _strIdEntidad As String = ""
        Private _strIdMoneda As String = ""
        Private _strNomEntidad As String = ""
        Private _strNomMoneda As String = ""
       
#End Region

#Region "Propiedades"

        Public Property Moneda() As String
            Get
                Return _strNomMoneda
            End Get
            Set(ByVal value As String)
                _strNomMoneda = value
            End Set
        End Property

        Public Property IdEntidad() As String
            Get
                Return _strIdEntidad
            End Get
            Set(ByVal value As String)
                _strIdEntidad = value
            End Set
        End Property
        Public Property Flag() As String
            Get
                Return _strFlag
            End Get
            Set(ByVal value As String)
                _strFlag = value
            End Set
        End Property

        Public Property IdOperacion() As String
            Get
                Return _strIdOperacion
            End Get
            Set(ByVal value As String)
                _strIdOperacion = value
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