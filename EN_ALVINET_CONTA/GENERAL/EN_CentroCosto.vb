Namespace GENERAL

    Public Class EN_CentroCosto
        Inherits GENERAL.EN_Empresa

#Region "Variable"

        Private _strIdCentroCosto As String = ""
        Private _strDescripcion As String = ""
        Private _strCodigoInductor As String = ""
        Private _strIdCentrocostoPadre As String = ""
        Private _intNivel As Integer = 0

#End Region

#Region "Propiedad"

        Public Property IdCentroCosto As String
            Get
                Return _strIdCentroCosto
            End Get
            Set(ByVal value As String)
                _strIdCentroCosto = value
            End Set
        End Property

        Public Property CentroCosto As String
            Get
                Return _strDescripcion
            End Get
            Set(ByVal value As String)
                _strDescripcion = value
            End Set
        End Property

        Public Property CodigoInductor As String
            Get
                Return _strCodigoInductor
            End Get
            Set(ByVal value As String)
                _strCodigoInductor = value
            End Set
        End Property

        Public Property IdCentroCostoPadre As String
            Get
                Return _strIdCentrocostoPadre
            End Get
            Set(ByVal value As String)
                _strIdCentrocostoPadre = value
            End Set
        End Property

        Public Property Nivel As Integer
            Get
                Return _intNivel
            End Get
            Set(ByVal value As Integer)
                _intNivel = value
            End Set
        End Property

#End Region

    End Class
End Namespace